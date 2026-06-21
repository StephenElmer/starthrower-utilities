// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text;
using StarThrower.ByteUtilities;
using StarThrower.StringUtilities;

namespace StarThrower.XBase.Internal
{
    internal sealed class Field : ICloneable
    {
        internal const Int32 SIZE = 32;


        #region Private Member Variables

        private byte[] _name = new byte[11]; //Field name in ASCII (zero filled) terminated by (Hex 00).
        private byte _type; //Field type in ASCII (C, D, F, L, M, or N)
        private byte[] _reserved1 = { 0, 0, 0, 0 }; //new byte[4]; //Reserved (Field data address IN MEMORY for dBase III+)
        private byte _length; //Field length in binary
        private byte _decimalCount; //Field decimal count in binary
        private byte[] _reserved2 = { 0, 0 }; //new byte[2]; //Reserved for multi-user dBase
        private byte _workAreaId; //Work area ID
        private byte[] _reserved3 = { 0, 0 }; //new byte[2]; //Reserved for multi-user dBase
        private byte _setFieldsFlag; //Flag for SET FIELDS (Reserved???)
        private byte[] _reserved4 = new byte[7]; //Reserved
        private byte _mdxFlag; //Production MDX field flag; (Hex 01) if field has an index tag in the production MDX file, (Hex 00) if not.

        #endregion


        #region Internal Properties

        /// <summary>
        /// Field name in ASCII (zero filled) terminated by (Hex 00)
        /// 
        /// (11 bytes)
        /// </summary>
        internal byte[] Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Field type in ASCII (C, D, F, L, M, or N)
        /// 
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
        internal byte Type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// Reserved (Field data address IN MEMORY for dBase III+)
        /// 
        /// (4 bytes)
        /// 
        /// Note that this field has two VERY different interpretations
        /// 
        /// Version     Offset      Description
        /// dBase       12 - 15     Address in memory
        /// FoxPro      12 - 13     Offset of field from beginning of record.
        /// 
        /// The field address is irrelevant for other applications
        /// </summary>
        internal byte[] Reserved1
        {
            get { return _reserved1; }
        }

        /// <summary>
        /// Field length in binary
        /// 
        /// Max = 255.  Valid types (see Data Types)
        /// </summary>
        internal byte Length
        {
            get { return _length; }
            set { _length = value; }
        }

        /// <summary>
        /// Field decimal count in binary
        /// 
        /// Used for Numeric data types.
        /// Value must be less than or equal to 15
        /// </summary>
        internal byte DecimalCount
        {
            get { return _decimalCount; }
            set { _decimalCount = value; }
        }

        /// <summary>
        /// Reserved for multi-user dBase
        /// 
        /// (2 bytes)
        /// 
        /// Field Flags (FoxPro / FoxBase)
        /// Value       Description
        /// 01h         System column (not visible to user)
        /// 02h         Column can store null values
        /// 04h         Binary column (for CHAR and MEMO only)
        /// </summary>
        internal byte[] Reserved2
        {
            get { return _reserved2; }
        }

        /// <summary>
        /// Work Area ID
        /// 
        /// The work area id is 01h in all dBase III files
        /// </summary>
        internal byte WorkAreaId
        {
            get { return _workAreaId; }
            set { _workAreaId = value; }
        }

        /// <summary>
        /// Reserved for multi-user dBase
        /// 
        /// (2 bytes)
        /// </summary>
        internal byte[] Reserved3
        {
            get { return _reserved3; }
        }

        /// <summary>
        /// Flat for SET Fields
        /// 
        /// Note:  The XBase documentation declares this field
        /// while the Borland document wraps this field up with
        /// Reserved3 and Reserved4 to make one 12 byte reserved field
        /// </summary>
        internal byte SetFieldsFlag
        {
            get { return _setFieldsFlag; }
            set { _setFieldsFlag = value; }
        }

        /// <summary>
        /// Reserved
        /// 
        /// (7 bytes)
        /// </summary>
        internal byte[] Reserved4
        {
            get { return _reserved4; }
        }

        /// <summary>
        /// MDX Field Flag (dBase IV)
        /// 
        /// (Hex 01) if field has an index tag in the production MDX file, (Hex 00) if not.
        /// 
        /// Value       Description
        /// 00h         No key for this field (ignored)
        /// 01h         Key exists for this field in the .MDX file
        /// </summary>
        internal byte MdxFlag
        {
            get { return _mdxFlag; }
            set { _mdxFlag = value; }
        }

        #endregion


        #region Construction

        internal Field() { }

        internal Field(byte[] bytes)
            : this()
        {
            ParseBytes(bytes);
        }

        internal Field(Field other)
            : this()
        {
            this.ItemCopy(other);
        }

        #endregion


        #region Internal Methods

        internal string ToXml()
        {
            Encoding ascii = Encoding.ASCII;

            string fieldName = ascii.GetString(_name);
            string fieldType = ascii.GetString(new byte[1] { _type });

            StringBuilder result = new StringBuilder(String.Empty);
            result.Append("<field ");
            result.Append("fieldName=\"" + StringUtil.XmlEncode(fieldName) + "\" ");
            result.Append("fieldType=\"" + StringUtil.XmlEncode(fieldType) + "\" ");
            result.Append("reserved1=\"" + _reserved1.ToString() + "\" ");
            result.Append("fieldLength=\"" + _length.ToString(CultureInfo.InvariantCulture) + "\" ");
            result.Append("decimalCount=\"" + _decimalCount.ToString(CultureInfo.InvariantCulture) + "\" ");
            result.Append("reserved2=\"" + _reserved2.ToString() + "\" ");
            result.Append("workAreaId=\"" + _workAreaId.ToString(CultureInfo.InvariantCulture) + "\" ");
            result.Append("reserved3=\"" + _reserved3.ToString() + "\" ");
            result.Append("setFieldsFlag=\"" + _setFieldsFlag.ToString(CultureInfo.InvariantCulture) + "\" ");
            result.Append("reserved4=\"" + _reserved4.ToString() + "\" ");
            result.Append("mdxFlag=\"" + _mdxFlag.ToString(CultureInfo.InvariantCulture) + "\" ");
            result.AppendLine("/>");
            return result.ToString();
        }

        internal byte[] GetBytes()
        {
            byte[] result = new byte[Field.SIZE];

            Int32 curIdx = 0;
            for (Int32 i = 0; i < 11; i++)
            {
                if (i < _name.Length)
                {
                    result[curIdx++] = _name[i];
                }
                else
                {
                    result[curIdx++] = 0;
                }
            }

            result[curIdx++] = _type;

            for (Int32 i = 0; i < 4; i++)
            {
                result[curIdx++] = _reserved1[i];
            }

            result[curIdx++] = _length;

            result[curIdx++] = _decimalCount;

            for (Int32 i = 0; i < 2; i++)
            {
                result[curIdx++] = _reserved2[i];
            }

            result[curIdx++] = _workAreaId;

            for (Int32 i = 0; i < 2; i++)
            {
                result[curIdx++] = _reserved3[i];
            }

            result[curIdx++] = _setFieldsFlag;

            for (Int32 i = 0; i < 7; i++)
            {
                result[curIdx++] = _reserved4[i];
            }

            result[curIdx++] = _mdxFlag;

            return result;
        }

        #endregion


        #region ICloneable Members

        public object Clone()
        {
            return new Field(this);
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
            StarThrower.XBase.Internal.Field other = (StarThrower.XBase.Internal.Field)obj;
            _name = other.Name;
            _type = other.Type;
            _reserved1 = other.Reserved1;
            _length = other.Length;
            _decimalCount = other.DecimalCount;
            _reserved2 = other.Reserved2;
            _workAreaId = other.WorkAreaId;
            _reserved3 = other.Reserved3;
            _setFieldsFlag = other.SetFieldsFlag;
            _reserved4 = other.Reserved4;
            _mdxFlag = other.MdxFlag;
        }

        #endregion


        #region Private Methods

        private void ParseBytes(byte[] bytes)
        {
            _name = ByteUtil.ByteSubstring(bytes, 0, 11, true);
            _type = bytes[11];
            _reserved1 = ByteUtil.ByteSubstring(bytes, 12, 4);
            _length = bytes[16];
            _decimalCount = bytes[17];
            _reserved2 = ByteUtil.ByteSubstring(bytes, 18, 2);
            _workAreaId = bytes[20];
            _reserved3 = ByteUtil.ByteSubstring(bytes, 21, 2);
            _setFieldsFlag = bytes[23];
            _reserved4 = ByteUtil.ByteSubstring(bytes, 24, 7);
            _mdxFlag = bytes[31];
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
            if (Object.ReferenceEquals(obj, null)) return false;
            if (Object.ReferenceEquals(obj, this)) return true;
            if (!(obj is StarThrower.XBase.Internal.Field)) return false;
            StarThrower.XBase.Internal.Field other = (StarThrower.XBase.Internal.Field)obj;
            return _name.Equals(other.Name) &&
                   _type.Equals(other.Type) &&
                   _reserved1.Equals(other.Reserved1) &&
                   _length.Equals(other.Length) &&
                   _decimalCount.Equals(other.DecimalCount) &&
                   _reserved2.Equals(other.Reserved2) &&
                   _workAreaId.Equals(other.WorkAreaId) &&
                   _reserved3.Equals(other.Reserved3) &&
                   _setFieldsFlag.Equals(other.SetFieldsFlag) &&
                   _reserved4.Equals(other.Reserved4) &&
                   _mdxFlag.Equals(other.MdxFlag);
        }

        /// <summary>
        /// Tests whether the given object is equal to this object.
        /// Optimized for instances of this class.
        /// </summary>
        /// <param name="other">The object to compare to this object.</param>
        /// <returns>true if other has reference or value equality with this object; otherwise, false.</returns>
        public bool Equals(StarThrower.XBase.Internal.Field other)
        {
            if (Object.ReferenceEquals(other, null)) return false;
            if (Object.ReferenceEquals(other, this)) return true;
            return _name.Equals(other.Name) &&
                   _type.Equals(other.Type) &&
                   _reserved1.Equals(other.Reserved1) &&
                   _length.Equals(other.Length) &&
                   _decimalCount.Equals(other.DecimalCount) &&
                   _reserved2.Equals(other.Reserved2) &&
                   _workAreaId.Equals(other.WorkAreaId) &&
                   _reserved3.Equals(other.Reserved3) &&
                   _setFieldsFlag.Equals(other.SetFieldsFlag) &&
                   _reserved4.Equals(other.Reserved4) &&
                   _mdxFlag.Equals(other.MdxFlag);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + _name.GetHashCode();
            result = 31 * result + _type.GetHashCode();
            result = 31 * result + _reserved1.GetHashCode();
            result = 31 * result + _length.GetHashCode();
            result = 31 * result + _decimalCount.GetHashCode();
            result = 31 * result + _reserved2.GetHashCode();
            result = 31 * result + _workAreaId.GetHashCode();
            result = 31 * result + _reserved3.GetHashCode();
            result = 31 * result + _setFieldsFlag.GetHashCode();
            result = 31 * result + _reserved4.GetHashCode();
            result = 31 * result + _mdxFlag.GetHashCode();
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
            return "[" + this.GetType().Name + ":  Name='" + _name + "', Type=" + _type.ToString(CultureInfo.InvariantCulture) + "]";
        }

        #endregion
    }
}
