// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text;
using StarThrower.ByteUtilities;
using StarThrower.StringUtilities;

namespace StarThrower.XBase.Internal
{
    /// <summary>
    /// The records follow the header in the database file.  Data records are
    /// preceded by one byte; that is, a space (20H) if the record is not deleted,
    /// an asterisk (2AH) if the record is deleted.  Fields are packed into
    /// records without field separators or record terminators.  The end of the
    /// file is marked by a single byte, with the end-of-file marker, an ASCII 26
    /// (1AH) character.
    /// </summary>
    internal sealed class Record : ICloneable
    {
        #region Private Member Variables

        private byte _isDeleted; // (Hex 20) if record is NOT deleted, (Hex 2a) if record IS deleted
        private byte[] _data; //ASCII data
        private StarThrower.XBase.Internal.FieldCollection _fields;  //This is a reference to the Fields of the parent File's FileHeader
        //a Record has access to this so that it can provide access to it's records
        #endregion


        #region Internal Properties

        /// <summary>
        /// Indicates whether the record has been deleted
        /// 
        /// (Hex 20) if record is NOT deleted, (Hex 2a) if record IS deleted
        /// 
        /// Value           Description
        /// 2Ah ('*')       Record is deleted
        /// 20h (' ')       Record is valid
        /// </summary>
        internal byte IsDeleted
        {
            get { return _isDeleted; }
            set { _isDeleted = value; }
        }

        /// <summary>
        /// Text representing the data for the record (ASCII)
        /// 
        /// There are no field separators for record terminators
        /// In the case of a memo field, this data will be a pointer to
        /// the first block in the .DBT file where the data begins.
        /// An empty memo field has a reference filled with 10 blanks
        /// 
        /// 
        /// 
        /// More notes on MEMO fields:
        /// Memo fields store data in .DBT files consisting of blocks numbered
        /// sequentially (0, 1, 2, and so on).  SET BLOCKSIZE determines the size of
        /// each block.  The first block in the .DBT file, block 0, is the .DBT file
        /// header.
        /// 
        /// Each memo field of each record in the .DBF file contains the number of the
        /// block (in OEM code page values) where the field's data actually begins.  If 
        /// a field contains no data, the .DBF file contains blanks (20h) rather than
        /// a number.
        /// 
        /// When data is changed in a field, the block numbers may also change and the 
        /// number in the .DBF may be changed to reflect the new location.
        /// 
        /// This information is from the dBase IV Language Reference manual, Appendix D.
        /// 
        /// 
        /// 
        /// Valid Data:
        /// Data    Type                Data Input
        /// C       Character           All OEM code page characters
        /// D       Date                Numbers and a character to separate monty, day, and year
        ///                             stored internally as 8 digits in YYYYMMDD format
        /// F       Floating point      '-' '.' '0' '1' '2' '3' '4' '5' '6' '7' '8' '9'
        ///         binary numeric
        /// N       Binary coded        '-' '.' '0' '1' '2' '3' '4' '5' '6' '7' '8' '9'
        ///         decimal numeric
        /// L       Logical (boolean)   '?' 'Y' 'y' 'N' 'n' 'T' 't' 'F' 'f' ('?' when not initialized)
        /// M       Memo                All OEM code page characters (stored internally as 10 digits
        ///                             representing a .DBT block number).
        /// </summary>
        internal byte[] Data
        {
            get { return _data; }
            set { _data = value; }
        }

        /// <summary>
        /// An XBaseRecord's field descriptor list should be a reference to
        /// the XBaseFieldDescriptorList of the parent XBaseFile's XBaseFileHeader
        /// 
        /// This reference is given to the XBaseRecord so that the record knows the
        /// format of the Data property and so the record can access it's various
        /// fields.
        /// </summary>
        internal StarThrower.XBase.Internal.FieldCollection Fields
        {
            get { return _fields; }
            set { _fields = value; }
        }

        #endregion


        #region Construction

        private Record()
        {
            _data = Array.Empty<byte>();
            _fields = new FieldCollection();
        }

        internal Record(byte[] bytes, StarThrower.XBase.Internal.FieldCollection fields)
            : this()
        {
            _fields = fields;
            ParseBytes(bytes);
        }

        internal Record(StarThrower.XBase.Internal.FieldCollection fields)
            : this()
        {
            _fields = fields;

            Int32 length = 0;
            for (Int32 i = 0; i < _fields.Count; i++)
            {
                length += _fields[i].Length;
            }

            _data = new byte[length + 1]; //we need to add 1 here to address the deleted flag
        }

        internal Record(StarThrower.XBase.Internal.Record other)
            : this()
        {
            this.ItemCopy(other);
        }

        #endregion


        #region Internal Methods

        internal string ToXml()
        {
            Encoding ascii = Encoding.ASCII;

            StringBuilder result = new StringBuilder(String.Empty);

            string deleted = "";
            if (_isDeleted == 32)
            {
                deleted = "_";
            }
            else if (_isDeleted == 42)
            {
                deleted = "*";
            }
            result.AppendLine("<record isDeleted=\"" + deleted + "\" data=\"" + StringUtil.XmlEncode(StringUtil.FromByteArray(_data)) + "\">");
            foreach (StarThrower.XBase.Internal.Field field in _fields)
            {

                string fieldName = ascii.GetString(field.Name);
                result.AppendLine("<" + StringUtil.XmlEncode(fieldName) + " value=\"" + StringUtil.XmlEncode(StringUtil.FromByteArray(this[field.Name])) + "\"/>");
            }
            result.AppendLine("</record>");
            return result.ToString();
        }

        internal byte[] this[byte[] fieldName]
        {
            get { return GetFieldValue(fieldName); }
            set { SetFieldValue(fieldName, value); }
        }

        /// <summary>
        /// Appends length spaces (Hex 20) to the end of the record
        /// </summary>
        /// <param name="length"></param>
        internal void ExtendLength(Int16 length)
        {
            byte[] temp = new byte[_data.Length + length];
            Int32 curIdx = 0;
            for (Int32 i = 0; i < _data.Length; i++)
            {
                temp[curIdx++] = _data[i];
            }
            while (curIdx < temp.Length)
            {
                temp[curIdx++] = 32; //(Hex 20) pad with spaces
            }
            _data = temp;
        }

        /// <summary>
        /// Removes length bytes from the record for the field at fieldIndex
        /// </summary>
        /// <param name="fieldIndex"></param>
        /// <param name="length"></param>
        internal void RemoveBytes(Int32 fieldIndex, Int16 length)
        {
            Int32 dataIndex = GetDataIndexForField(fieldIndex);

            byte[] temp = new byte[_data.Length - length];
            Int32 curIdx = 0;
            for (Int32 i = 0; i < _data.Length; i++)
            {
                if ((i < dataIndex) || (i >= (dataIndex + length)))
                {
                    temp[curIdx++] = _data[i];
                }
            }
            _data = temp;
        }

        internal void InsertBytes(Int32 fieldIndex, Int16 length)
        {
            Int32 dataIndex = GetDataIndexForField(fieldIndex);

            byte[] temp = new byte[_data.Length + length];
            Int32 curIdx = 0;
            for (Int32 i = 0; i < _data.Length + length; i++)
            {
                if ((i < dataIndex) || (i >= (dataIndex + length)))
                {
                    temp[i] = _data[curIdx++];
                }
            }
            _data = temp;
        }

        #endregion


        #region Private Methods

        private Int32 GetDataIndexForField(Int32 fieldIndex)
        {
            if (fieldIndex < 0 || fieldIndex > (_fields.Count - 1)) throw new ArgumentOutOfRangeException(nameof(fieldIndex));
            return _fields.CalculateStartIndex(fieldIndex);
        }

        private void ParseBytes(byte[] bytes)
        {
            _isDeleted = bytes[0];
            _data = ByteUtil.ByteSubstring(bytes, 1, bytes.Length - 1);
        }

        private byte[] GetFieldValue(byte[] fieldName)
        {
            Int32 startIndex = -1;
            Int32 length = 0;
            _fields.GetFieldBounds(fieldName, ref startIndex, ref length);
            return ByteUtil.ByteSubstring(_data, startIndex, length);
        }

        private void SetFieldValue(byte[] fieldName, byte[] value)
        {
            Int32 startIndex = -1;
            Int32 length = 0;
            _fields.GetFieldBounds(fieldName, ref startIndex, ref length);
            if (value.Length > length) throw new ArgumentException("The value argument is too large for this field.");

            for (Int32 i = 0; i < length; i++)
            {
                if (i < value.Length)
                {
                    _data[startIndex] = value[i];
                }
                else
                {
                    _data[startIndex] = 0;
                }
                startIndex++;
            }
        }

        #endregion


        #region ICloneable Members

        public object Clone()
        {
            return new StarThrower.XBase.Internal.Record(this);
        }

        #endregion


        #region IItemCopyable Members

        /// <summary>
        /// Sets the state of the current instance equal to a copy of the state of some other instance.
        /// </summary>
        /// <param name="obj">The instance you wish this to be a copy of.  Must be of the same type as this object.</param>
        /// <exception cref="FailedItemCopyException"></exception>
        public void ItemCopy(object obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
            StarThrower.XBase.Internal.Record other = (StarThrower.XBase.Internal.Record)obj;
            _isDeleted = other.IsDeleted;
            _data = other.Data;
            _fields.Clear();
            foreach (StarThrower.XBase.Internal.Field field in other.Fields)
            {
                _fields.Add((StarThrower.XBase.Internal.Field)(field.Clone()));
            }
        }

        #endregion


        #region Object Overrides

        /// <summary>
        /// Tests whether the given object is equal to this object.
        /// </summary>
        /// <param name="obj">The object to compare to this object.</param>
        /// <returns>true if other is an instance of the same class as this object and has reference or value equality with this object; otherwise, false.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (!(obj is StarThrower.XBase.Internal.Record)) return false;
            StarThrower.XBase.Internal.Record other = (StarThrower.XBase.Internal.Record)obj;
            return _isDeleted.Equals(other.IsDeleted) &&
                   _data.Equals(other.Data);
        }

        /// <summary>
        /// Tests whether the given object is equal to this object.
        /// Optimized for instances of this class.
        /// </summary>
        /// <param name="other">The object to compare to this object.</param>
        /// <returns>true if other has reference or value equality with this object; otherwise, false.</returns>
        public bool Equals(StarThrower.XBase.Internal.Record other)
        {
            if (Object.ReferenceEquals(other, null)) return false;
            if (Object.ReferenceEquals(other, this)) return true;
            return _isDeleted.Equals(other.IsDeleted) &&
                   _data.Equals(other.Data);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + _isDeleted.GetHashCode();
            result = 31 * result + _data.GetHashCode();
            return result;
        }

        /// <summary>
        /// Returns the string representation of this object.
        /// </summary>
        /// <returns>A string describing this object.</returns>
        /// <remarks>
        /// Returns a string formatted as "[{type}:  {name}={value}[,{name}={value}]]"
        /// </remarks>
        public override string ToString()
        {
            return "[" + this.GetType().Name + ":  Data='" + _data + "', IsDeleted=" + _isDeleted.ToString(CultureInfo.InvariantCulture) + "]";
        }

        #endregion
    }
}
