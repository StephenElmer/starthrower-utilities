/***********************************************************************************
    StarThrower Utilities / XBase
    Copyright (C) 2005-2026  Stephen Elmer

    This library is free software; you can redistribute it and/or
    modify it under the terms of the GNU Lesser General Public
    License as published by the Free Software Foundation; either
    version 2.1 of the License, or (at your option) any later version.

    This library is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
    Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public
    License along with this library; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
***********************************************************************************/

using System;
using System.Globalization;
using System.IO;
using System.Text;
using StarThrower.ByteUtilities;

namespace StarThrower.XBase.Internal
{
    /// <summary>
    /// The data file with suffix .DBF is the central table in an Xbase database.
    /// All other data files are related to this one file.
    /// The Data File is a mix of binary and ASCII data.  Headers contain binary data.
    /// The records are all in ASCII (except, of course, the binary objects like pictures).
    /// 
    /// Several sources claim that dBase clears the header on creation with blanks (20h).
    /// But some have seen data in the reserved areas (http://www.clicketyclick.dk/databases/xbase/format/dbf.html)
    /// 
    /// Some documents state that deleted records are overwritten by new valid records.
    /// Experience is that new records are APPENDED to the data file - not inserted.
    /// 
    /// A deleted record can only be deleted physically using the PACK command.  Even after a PACK, the deleted
    /// record exists after the EOF mark.  The file is not truncated in dBase III (But don't count on it).
    /// 
    /// Note that this structure is valid for Xbase - and dBase v. III - 5.  Later versions of dBase have a 
    /// different layout, like dBase 7.  (see http://www.dbase.com/KnowledgeBase/int/db7_file_fmt.htm)
    /// </summary>
    internal sealed class File : IDisposable
    {
        #region Private Member Variables

        private FileStream? _stream;
        private StarThrower.XBase.Internal.FileHeader _header = new StarThrower.XBase.Internal.FileHeader(); //file header
        private StarThrower.XBase.Internal.RecordCollection _records = new StarThrower.XBase.Internal.RecordCollection(); //records
        private byte _endOfFile = 26; //End of file (Hex 1a)

        #endregion


        #region Internal Properties

        internal Int32 FieldCount
        {
            get { return _header.Fields.Count; }
        }

        internal Int32 RecordCount
        {
            get { return _header.RecordCount; }
        }

        /// <summary>
        /// The file header for this file
        /// </summary>
        internal StarThrower.XBase.Internal.FileHeader Header
        {
            get { return _header; }
        }

        /// <summary>
        /// The collection of records in this file
        /// </summary>
        internal StarThrower.XBase.Internal.RecordCollection Records
        {
            get { return _records; }
        }

        /// <summary>
        /// End of File (Hex 1A)
        /// 
        /// dBase II regards any End-of-File 1Ah value as the end of the file.
        /// dBase III regards an End-of-File as an ordinary character, however
        /// it appends an extra End-of-File character at the physical end of the file.
        /// If the file is packed, the physical size of the file may be larger than the logical
        /// i.e. there may be garbage after the EOF mark.
        /// </summary>
        internal byte EndOfFile
        {
            get { return _endOfFile; }
            set { _endOfFile = value; }
        }

        #endregion


        #region Construction

        internal File() { }

        internal File(string fileName, System.IO.FileMode fileMode, System.IO.FileAccess fileAccess, System.IO.FileShare fileShare)
            : this()
        {
            this.Open(fileName, fileMode, fileAccess, fileShare);
        }

        internal File(string fileName, System.IO.FileMode fileMode, System.IO.FileAccess fileAccess)
            : this()
        {
            this.Open(fileName, fileMode, fileAccess);
        }

        #endregion


        #region IDisposable Members

        public void Dispose()
        {
            if (_stream != null)
            {
                _stream.Dispose();
            }
        }

        #endregion


        #region Internal Methods

        #region Field Related

        internal StarThrower.XBase.Internal.Field GetField(Int32 index)
        {
            if (index < 0 || index >= _header.Fields.Count) throw new ArgumentOutOfRangeException(nameof(index));
            return _header.Fields[index];
        }

        internal StarThrower.XBase.Internal.Field GetField(byte[] fieldName)
        {
            Int32 index = -1;
            if (!this.FindField(fieldName, ref index)) throw new ArgumentException(fieldName + " is an invalid FieldDescriptor.");
            return this.GetField(index);
        }

        internal void AddField(StarThrower.XBase.Internal.Field field)
        {
            _header.Fields.Add(field);
            _header.HeaderLength += Field.SIZE;
            _header.RecordLength += (Int16)field.Length;
            foreach (StarThrower.XBase.Internal.Record record in _records)
            {
                record.ExtendLength((Int16)(field.Length));
            }
            _header.LastUpdate = XBase.DateTimeToThreeByteArray(DateTime.Now);
        }

        internal bool FindField(byte[] fieldName)
        {
            Int32 index = -1;
            return this.FindField(fieldName, ref index);
        }

        internal bool FindField(byte[] fieldName, ref Int32 index)
        {
            return _header.Fields.Find(fieldName, ref index);
        }

        internal void DeleteField(byte[] fieldName)
        {
            Int32 index = -1;
            if (!_header.Fields.Find(fieldName, ref index)) throw new ArgumentException(fieldName + " does not exist.");
            this.DeleteField(index);
        }

        internal void DeleteField(Int32 fieldIndex)
        {
            Int32 fieldLength = _header.Fields[fieldIndex].Length;
            _header.Fields.RemoveAt(fieldIndex);
            _header.HeaderLength -= StarThrower.XBase.Internal.Field.SIZE;
            _header.RecordLength -= (Int16)fieldLength;
            foreach (StarThrower.XBase.Internal.Record record in _records)
            {
                record.RemoveBytes(fieldIndex, (Int16)fieldLength);
            }
            _header.LastUpdate = XBase.DateTimeToThreeByteArray(DateTime.Now);
        }

        internal void AlterField(byte[] fieldName, StarThrower.XBase.Internal.Field field)
        {
            Int32 index = -1;
            if (!_header.Fields.Find(fieldName, ref index)) throw new ArgumentException(fieldName + " is an invalid FieldDescriptor.");
            if (!field.Name.AsSpan().SequenceEqual(fieldName))
            {
                if (_header.Fields.Find(field.Name)) throw new ArgumentException(fieldName + " cannot be changed to " + field.Name + " because a field named '" + field.Name + "' already exists.");
            }

            this.AlterField(index, field);
        }

        internal void AlterField(Int32 fieldIndex, StarThrower.XBase.Internal.Field field)
        {
            //Header length does not change
            Int16 oldLength = (Int16)_header.Fields[fieldIndex].Length;
            Int16 newLength = (Int16)field.Length;
            _header.RecordLength -= oldLength;
            _header.RecordLength += newLength;

            foreach (StarThrower.XBase.Internal.Record record in _records)
            {
                Int32 startIndex = 0;
                Int32 length = 0;
                record.Fields.GetFieldBounds(fieldIndex, ref startIndex, ref length);
                byte[] originalData = ByteUtil.ByteSubstring(record.Data, startIndex, length);

                record.RemoveBytes(fieldIndex, (Int16)oldLength);
                record.InsertBytes(fieldIndex, (Int16)newLength);

                //TODO: handle conversions to/from field types other than Character!
                //convert any type TO Character (C)
                Int32 curIdx = startIndex;
                if (oldLength > newLength)
                {
                    for (Int32 i = 0; i < newLength; i++)
                    {
                        record.Data[curIdx++] = originalData[i];
                    }
                }
                else
                {
                    for (Int32 i = 0; i < oldLength; i++)
                    {
                        record.Data[curIdx++] = originalData[i];
                    }
                    while (curIdx < (startIndex + newLength))
                    {
                        record.Data[curIdx++] = 32; //(Hex 20) pad with spaces
                    }
                }

            }

            _header.Fields[fieldIndex] = field;
            _header.LastUpdate = XBase.DateTimeToThreeByteArray(DateTime.Now);
        }

        #endregion

        #region Record Related

        internal StarThrower.XBase.Internal.Record CreateRecord()
        {
            return new StarThrower.XBase.Internal.Record(_header.Fields);
        }

        internal void AddRecord(StarThrower.XBase.Internal.Record record)
        {
            _records.Add(record);
            _header.RecordCount += 1;
            _header.LastUpdate = XBase.DateTimeToThreeByteArray(DateTime.Now);
        }

        internal StarThrower.XBase.Internal.Record GetRecord(Int32 index)
        {
            if (index < 0 || index > _records.Count) throw new ArgumentOutOfRangeException(nameof(index));
            return _records[index];
        }

        internal bool FindRecord(string queryString)
        {
            Int32 index = -1;
            return FindRecord(queryString, ref index);
        }

        /* QueryString Language:
         * 
         * <QueryString> = <FieldName><Operator><FieldValue>
         * <FieldName> = <String>
         * <Operator> = "=" | "<" | ">" | "<=" | ">=" | "<>"
         * <FieldValue> = <StringValue> | <NumberValue> | <DateValue>
         * <StringValue> = '<String>'
         * <DateValue> = #MM/DD/YYYY#
         * <NumberValue> = valid numeric value including negative sign
         * 
         * String comparisons are not case sensitive
         * Floating point number comparisons may not be true for equality comparison
         * 
         * Examples:
         *      "BDate=#05/18/1968#"
         *      "Name='Steve Elmer'"
         *      "Age=38"
         * 
         */
        internal bool FindRecord(string queryText, ref Int32 index)
        {
            //TODO: handle queryString

            //string fieldName = "Name";
            //string op = "=";
            //string fieldValue = "Steve Elmer";

            //Int32 index = -1;
            //if (!_header.Fields.Find(Strings.ToByteArray(fieldName), ref index)) throw new ArgumentException();
            //for (Int32 i = 0; i < _records.Count; i++)
            //{
            //    if ((op.Equals("=") || op.Equals("<=") || op.Equals(">=")) &&
            //        (_records[i].GetData(fieldName).Compare(fieldValue) == 0))
            //    {
            //        return true;
            //    }
            //    else if ((op.Equals("<") || op.Equals("<=")) && 
            //             (_records[i].GetData(fieldName).Compare(fieldValue) < 0))
            //    {
            //        return true;
            //    }
            //    else if ((op.Equals(">") || op.Equals(">=")) &&
            //             (_records[i].GetData(fieldName).Compare(fieldValue) > 0))
            //    {
            //        return true;
            //    }
            //    else if (op.Equals("<>"))
            //    {
            //        return _records[i].GetData(fieldName).Equals(fieldValue);
            //    }
            //    else
            //    {
            //        throw new ArgumentException();
            //    }
            //}

            return false;
        }

        internal void DeleteRecord(Int32 index)
        {
            //TODO: Does record count get adjusted
            //      when a dBase record is merely flagged for deletion???
            _records[index].IsDeleted = 42; //2Ah  (ASCII '*')
            //_header.RecordCount -= 1;
            _header.LastUpdate = XBase.DateTimeToThreeByteArray(DateTime.Now);
        }

        internal void DestroyRecord(Int32 index)
        {
            _records.RemoveAt(index);
            _header.RecordCount -= 1;
            _header.LastUpdate = XBase.DateTimeToThreeByteArray(DateTime.Now);
        }

        internal void AlterRecord(Int32 index, StarThrower.XBase.Internal.Record record)
        {
            _records[index].Data = record.Data;
            _header.LastUpdate = XBase.DateTimeToThreeByteArray(DateTime.Now);
        }


        #endregion

        #region File Related

        internal void Open(string fileName, System.IO.FileMode fileMode, System.IO.FileAccess fileAccess)
        {
            if (!(System.IO.File.Exists(fileName))) throw new FileNotFoundException();
            _stream = new FileStream(fileName, fileMode, fileAccess);
            Read();
        }

        internal void Open(string fileName, System.IO.FileMode fileMode, System.IO.FileAccess fileAccess, System.IO.FileShare fileShare)
        {
            if (!(System.IO.File.Exists(fileName))) throw new FileNotFoundException();
            _stream = new FileStream(fileName, fileMode, fileAccess, fileShare);
            Read();
        }

        /// <summary>
        /// Closes the file without saving
        /// </summary>
        internal void Close()
        {
            if (_stream != null)
            {
                _stream.Close();
            }
        }

        /// <summary>
        /// Closes the file taking a boolean parameter
        /// which indicates whether the file should be saved or not
        /// </summary>
        /// <param name="save"></param>
        internal void Close(bool save)
        {
            if (save)
            {
                Save();
            }
            if (_stream != null)
            {
                _stream.Close();
            }
        }

        internal void Save()
        {
            if (_stream == null) throw new InvalidOperationException("FileStream has not yet been assigned.");

            _stream.Seek(0, SeekOrigin.Begin);

            byte[] header = _header.GetBytes();
            _stream.Write(header, 0, header.Length);

            byte[] records = _records.GetBytes();
            _stream.Write(records, 0, records.Length);

            _stream.WriteByte(_endOfFile);
        }

        internal void SaveAs(string fileName)
        {
            if (_stream != null)
            {
                if (_stream.Name.Equals(fileName, StringComparison.Ordinal))
                {
                    this.Save();
                }
                else
                {
                    //Close the current stream
                    if (_stream != null)
                    {
                        _stream.Close();
                        _stream.Dispose();
                        _stream = null;
                    }

                    //Create a new stream
                    if (System.IO.File.Exists(fileName)) System.IO.File.Delete(fileName);
                    _stream = new FileStream(fileName, FileMode.CreateNew, FileAccess.ReadWrite);

                    //Write the contents of this data structure to the new stream
                    this.Save();
                }
            }
            else
            {
                //Create a new stream
                if (System.IO.File.Exists(fileName)) System.IO.File.Delete(fileName);
                _stream = new FileStream(fileName, FileMode.CreateNew, FileAccess.ReadWrite);
                _records.FileHeader = _header;

                //Write the contents of this data structure to the new stream
                this.Save();
            }
        }

        internal string ToXml()
        {
            StringBuilder result = new StringBuilder(String.Empty);
            result.AppendLine("<xBaseFile>");
            result.Append(_header.ToXml());
            result.Append(_records.ToXml());
            result.AppendLine("<eof endOfFile=\"" + _endOfFile.ToString(CultureInfo.InvariantCulture) + "\"/>");
            result.AppendLine("</xBaseFile>");
            return result.ToString();
        }

        #endregion

        #endregion


        #region Private Methods

        internal void Read()
        {
            if (_stream == null || !_stream.CanRead) throw new IOException("Stream is not in a readable mode.");

            byte[] header = new byte[StarThrower.XBase.Internal.FileHeader.MAXSIZE];
            _stream.Seek(0, SeekOrigin.Begin);
            _stream.Read(header, 0, StarThrower.XBase.Internal.FileHeader.MAXSIZE);
            _header.ParseBytes(header);

            _records.Clear();
            _records.FileHeader = _header;
            Int32 curIdx = _header.HeaderLength;
            bool done = false;
            _stream.Seek(curIdx, SeekOrigin.Begin);
            for (Int32 i = 0; i < _header.RecordCount && !done; i++)
            {
                byte[] record = new byte[_header.RecordLength];
                _stream.Read(record, 0, _header.RecordLength);
                StarThrower.XBase.Internal.Record newRecord = new StarThrower.XBase.Internal.Record(record, _header.Fields);
                _records.Add(newRecord);
                curIdx += _header.RecordLength;

                if (curIdx >= (_header.RecordCount * _header.RecordLength) + _header.HeaderLength)
                {
                    done = true;
                }
            }

            byte[] eof = new byte[1];
            _stream.Read(eof, 0, 1);
            _endOfFile = eof[0];
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
            if (!(obj is StarThrower.XBase.Internal.File)) return false;
            StarThrower.XBase.Internal.File other = (StarThrower.XBase.Internal.File)obj;
            return _header.Equals(other.Header) &&
                   _records.Equals(other.Records) &&
                   _endOfFile.Equals(other.EndOfFile);
        }

        /// <summary>
        /// Tests whether the given object is equal to this object.
        /// Optimized for instances of this class.
        /// </summary>
        /// <param name="other">The object to compare to this object.</param>
        /// <returns>true if other has reference or value equality with this object; otherwise, false.</returns>
        public bool Equals(StarThrower.XBase.Internal.File other)
        {
            if (Object.ReferenceEquals(other, null)) return false;
            if (Object.ReferenceEquals(other, this)) return true;
            return _header.Equals(other.Header) &&
                   _records.Equals(other.Records) &&
                   _endOfFile.Equals(other.EndOfFile);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + _header.GetHashCode();
            result = 31 * result + _records.GetHashCode();
            result = 31 * result + _endOfFile.GetHashCode();
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
            return "[" + this.GetType().Name + ":  RecordCount=" + _records.Count.ToString(CultureInfo.InvariantCulture) + "]";
        }

        #endregion

    }
}
