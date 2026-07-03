// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Globalization;
using System.IO;
using System.Text;
using StarThrower.ByteUtilities;
using StarThrower.StringUtilities;

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

        /// <summary>
        /// Creates a new File instance and immediately opens and reads the specified .dbf file with the given sharing mode.
        /// </summary>
        internal File(string fileName, System.IO.FileMode fileMode, System.IO.FileAccess fileAccess, System.IO.FileShare fileShare)
            : this()
        {
            this.Open(fileName, fileMode, fileAccess, fileShare);
        }

        /// <summary>
        /// Creates a new File instance and immediately opens and reads the specified .dbf file.
        /// </summary>
        internal File(string fileName, System.IO.FileMode fileMode, System.IO.FileAccess fileAccess)
            : this()
        {
            this.Open(fileName, fileMode, fileAccess);
        }

        #endregion


        #region IDisposable Members

        /// <summary>
        /// Releases the underlying file stream, if one is open.
        /// </summary>
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

        /// <summary>
        /// Appends a new field descriptor to the header and extends every existing record's data
        /// to make room for it.
        /// </summary>
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

        /// <summary>
        /// Removes the field descriptor at the given index from the header and removes the
        /// corresponding bytes from every existing record's data.
        /// </summary>
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

        /// <summary>
        /// Alters the definition of the field at the given index - renaming it, resizing it
        /// (changing <see cref="Field.Length"/> and/or <see cref="Field.DecimalCount"/>), or both.
        /// Existing record data is preserved as raw bytes: shrinking the field truncates trailing
        /// bytes, growing it pads with spaces.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if <paramref name="field"/>.Type differs from
        /// the field's current type.</exception>
        /// <remarks>
        /// Changing a field's data type (e.g. Character to Numeric) is not currently supported.
        /// Doing so correctly requires reinterpreting each record's stored value for the new type
        /// (via the corresponding <see cref="FieldType.Translate"/> / <see cref="FieldType.IsValidData"/>
        /// pair) rather than simply truncating/padding raw bytes, which is only valid when the type
        /// is unchanged. This is tracked as a future enhancement.
        /// </remarks>
        //TODO: #1 — support changing a field's data type, not just rename/resize
        internal void AlterField(Int32 fieldIndex, StarThrower.XBase.Internal.Field field)
        {
            if (field.Type != _header.Fields[fieldIndex].Type)
            {
                throw new ArgumentException(
                    "Changing a field's data type is not currently supported by AlterField. Only renaming and/or resizing (Length/DecimalCount) of a field while keeping its existing Type is supported.",
                    nameof(field));
            }

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

                //Field type is unchanged (enforced above), so resizing is a simple truncate/pad of the raw bytes.
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

        /// <summary>
        /// Creates a new, empty record sized to fit this file's current field schema.
        /// </summary>
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
         * <FieldValue> = <StringValue> | <NumberValue> | <DateValue> | <BooleanValue>
         * <StringValue> = '<String>'
         * <DateValue> = #MM/DD/YYYY#
         * <NumberValue> = valid numeric value including negative sign
         * <BooleanValue> = T | Y | F | N (case insensitive)
         *
         * String comparisons are not case sensitive
         * Floating point number comparisons may not be true for equality comparison
         *
         * NOTE: Only the "=" operator is currently implemented (see remarks on FindRecord below).
         * The remaining comparison operators are reserved for a future LOCATE FOR / CONTINUE
         * style implementation.
         * TODO: #10 — implement the remaining "<", ">", "<=", ">=", "<>" operators.
         *
         * Examples:
         *      "BDate=#05/18/1968#"
         *      "Name='Steve Elmer'"
         *      "Age=38"
         *      "IsActive=T"
         *
         */

        /// <summary>
        /// Searches for the first non-deleted record whose field value matches the given query
        /// expression, and returns its index.
        /// </summary>
        /// <param name="queryText">A query expression in the form &lt;FieldName&gt;=&lt;FieldValue&gt;.
        /// See the QueryString Language documentation above this method for the supported value syntax.</param>
        /// <param name="index">Set to the zero-based index of the matching record if one is found;
        /// otherwise -1.</param>
        /// <returns>true if a matching record was found; otherwise false.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="queryText"/> cannot be parsed,
        /// uses an operator other than "=", references a field that does not exist, or supplies a value
        /// whose syntax does not match the target field's type.</exception>
        /// <remarks>
        /// Only the "=" (equality) operator is currently supported. The query language was designed with
        /// dBase's LOCATE FOR / CONTINUE commands in mind - a future version may implement the remaining
        /// comparison operators as a sequential-scan predicate match (akin to LOCATE FOR), with the
        /// <paramref name="index"/> parameter doubling as the CONTINUE resume position. Deleted records
        /// (IsDeleted == '*') are skipped.
        /// </remarks>
        internal bool FindRecord(string queryText, ref Int32 index)
        {
            if (!TryParseQuery(queryText, out string fieldName, out string op, out string valueText))
            {
                throw new ArgumentException("queryText is not a valid query expression.", nameof(queryText));
            }

            if (!op.Equals("=", StringComparison.Ordinal))
            {
                throw new ArgumentException(
                    "Only the \"=\" operator is currently implemented. See the remarks on FindRecord for planned LOCATE FOR-style support of the remaining operators.",
                    nameof(queryText));
            }

            byte[] fieldNameBytes = StringUtil.ToByteArray(fieldName);
            Int32 fieldIndex = -1;
            if (!_header.Fields.Find(fieldNameBytes, ref fieldIndex))
            {
                throw new ArgumentException("'" + fieldName + "' is not a valid field name.", nameof(queryText));
            }

            char fieldType = (char)_header.Fields[fieldIndex].Type;

            for (Int32 i = 0; i < _records.Count; i++)
            {
                if (_records[i].IsDeleted == 42) continue; //(Hex 2a) skip deleted records

                string rawFieldText = StringUtil.FromByteArray(_records[i][fieldNameBytes]);
                if (ValueEquals(fieldType, rawFieldText, valueText))
                {
                    index = i;
                    return true;
                }
            }

            index = -1;
            return false;
        }

        /// <summary>
        /// Flags the record at the given index as deleted (dBase's soft-delete semantics).
        /// </summary>
        /// <remarks>
        /// <see cref="Header"/>.RecordCount is intentionally left unchanged here - a soft-deleted
        /// record is still physically present in the file and remains part of the record count until
        /// a PACK (<see cref="DestroyRecord"/>) physically removes it.
        /// </remarks>
        internal void DeleteRecord(Int32 index)
        {
            _records[index].IsDeleted = 42; //2Ah  (ASCII '*')
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

        /// <summary>
        /// Opens the specified .dbf file and reads its header and records.
        /// </summary>
        /// <exception cref="FileNotFoundException">Thrown if fileName does not exist.</exception>
        internal void Open(string fileName, System.IO.FileMode fileMode, System.IO.FileAccess fileAccess)
        {
            if (!(System.IO.File.Exists(fileName))) throw new FileNotFoundException();
            _stream = new FileStream(fileName, fileMode, fileAccess);
            Read();
        }

        /// <summary>
        /// Opens the specified .dbf file with the given sharing mode and reads its header and records.
        /// </summary>
        /// <exception cref="FileNotFoundException">Thrown if fileName does not exist.</exception>
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

        /// <summary>
        /// Writes this file's header, records, and EOF marker to the currently open stream,
        /// overwriting its previous contents from the beginning.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if no file is currently open.</exception>
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

        /// <summary>
        /// Saves this file's contents to the specified path. If a different file is currently
        /// open, that stream is closed and replaced; if fileName already exists, it is
        /// overwritten. If fileName matches the currently open file, this is equivalent to <see cref="Save"/>.
        /// </summary>
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

        /// <summary>
        /// Gets an XML representation of this file's header, records, and EOF marker.
        /// </summary>
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

        /// <summary>
        /// Reads the header (including field descriptors) and every record from the currently
        /// open stream, replacing this instance's current contents.
        /// </summary>
        /// <exception cref="IOException">Thrown if the stream is not open or not readable.</exception>
        /// <exception cref="InvalidDataException">Thrown if the header's declared length is outside valid DBF bounds.</exception>
        /// <exception cref="EndOfStreamException">Thrown if the stream ends before the expected EOF marker byte.</exception>
        internal void Read()
        {
            if (_stream == null || !_stream.CanRead) throw new IOException("Stream is not in a readable mode.");

            // Read the fixed 32-byte DBF header prefix first.
            const int fixedHeaderLength = 32;
            byte[] fixedHeader = new byte[fixedHeaderLength];
            _stream.Seek(0, SeekOrigin.Begin);
            _stream.ReadExactly(fixedHeader, 0, fixedHeaderLength);

            // Bytes 8-9 contain the full header length (little-endian Int16).
            short headerLengthValue = ByteUtil.ByteArrayToInt16(
                ByteUtil.ByteSubstring(fixedHeader, 8, 2),
                ByteEndian.Little,
                BitEndian.Little);

            int headerLength = headerLengthValue;

            // Validate before allocating/reading the remaining header bytes.
            if (headerLength < 33 || headerLength > StarThrower.XBase.Internal.FileHeader.MAXSIZE)
            {
                throw new InvalidDataException("Header length is outside valid DBF bounds.");
            }

            // Build the complete header buffer: fixed 32 bytes + remaining bytes.
            byte[] header = new byte[headerLength];
            Buffer.BlockCopy(fixedHeader, 0, header, 0, fixedHeaderLength);

            int remainingHeaderBytes = headerLength - fixedHeaderLength;
            if (remainingHeaderBytes > 0)
            {
                _stream.ReadExactly(header, fixedHeaderLength, remainingHeaderBytes);
            }

            _header.ParseBytes(header);

            _records.Clear();
            _records.FileHeader = _header;

            _stream.Seek(_header.HeaderLength, SeekOrigin.Begin);
            for (int i = 0; i < _header.RecordCount; i++)
            {
                byte[] record = new byte[_header.RecordLength];
                _stream.ReadExactly(record, 0, _header.RecordLength);
                StarThrower.XBase.Internal.Record newRecord = new StarThrower.XBase.Internal.Record(record, _header.Fields);
                _records.Add(newRecord);
            }

            // Read final EOF marker byte.
            int eof = _stream.ReadByte();
            if (eof == -1) throw new EndOfStreamException("Expected DBF EOF marker byte.");
            _endOfFile = (byte)eof;
        }

        /// <summary>
        /// Splits a FindRecord query expression into its field name, operator, and value components.
        /// </summary>
        private static bool TryParseQuery(string queryText, out string fieldName, out string op, out string valueText)
        {
            fieldName = String.Empty;
            op = String.Empty;
            valueText = String.Empty;

            Int32 opStart = queryText.IndexOfAny(['=', '<', '>']);
            if (opStart <= 0) return false;

            Int32 opLength = 1;
            if (opStart + 1 < queryText.Length)
            {
                char first = queryText[opStart];
                char second = queryText[opStart + 1];
                if ((first == '<' && (second == '=' || second == '>')) ||
                    (first == '>' && second == '='))
                {
                    opLength = 2;
                }
            }

            fieldName = queryText[..opStart].Trim();
            op = queryText.Substring(opStart, opLength);
            valueText = queryText[(opStart + opLength)..].Trim();

            return fieldName.Length > 0 && valueText.Length > 0;
        }

        /// <summary>
        /// Compares a record's raw field text against a parsed query value, using comparison rules
        /// appropriate to the field's dBase type.
        /// </summary>
        private static bool ValueEquals(char fieldType, string rawFieldText, string valueText)
        {
            switch (fieldType)
            {
                case 'C':
                    return StringValueEquals(rawFieldText, valueText);
                case 'D':
                    return DateValueEquals(rawFieldText, valueText);
                case 'N':
                case 'F':
                    return NumericValueEquals(rawFieldText, valueText);
                case 'L':
                    return BooleanValueEquals(rawFieldText, valueText);
                default:
                    throw new ArgumentException("Querying fields of type '" + fieldType + "' is not supported.", nameof(valueText));
            }
        }

        private static bool StringValueEquals(string rawFieldText, string valueText)
        {
            if (valueText.Length < 2 || valueText[0] != '\'' || valueText[^1] != '\'')
            {
                throw new ArgumentException("String field values must be enclosed in single quotes.", nameof(valueText));
            }

            string literal = valueText[1..^1];
            return String.Equals(rawFieldText.TrimEnd(), literal.TrimEnd(), StringComparison.OrdinalIgnoreCase);
        }

        private static bool DateValueEquals(string rawFieldText, string valueText)
        {
            if (valueText.Length != 12 || valueText[0] != '#' || valueText[^1] != '#')
            {
                throw new ArgumentException("Date field values must be in #MM/DD/YYYY# format.", nameof(valueText));
            }

            string dateLiteral = valueText[1..^1];
            if (!DateTime.TryParseExact(dateLiteral, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime queryDate))
            {
                throw new ArgumentException("Date field values must be in #MM/DD/YYYY# format.", nameof(valueText));
            }

            if (!Int32.TryParse(rawFieldText.AsSpan(0, 4), out Int32 year) ||
                !Int32.TryParse(rawFieldText.AsSpan(4, 2), out Int32 month) ||
                !Int32.TryParse(rawFieldText.AsSpan(6, 2), out Int32 day))
            {
                return false; //stored data could not be parsed as a date; treat as no match
            }

            DateTime fieldDate = new DateTime(year, month, day);
            return fieldDate == queryDate;
        }

        private static bool NumericValueEquals(string rawFieldText, string valueText)
        {
            const NumberStyles styles = NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite;

            if (!Decimal.TryParse(valueText, styles, CultureInfo.InvariantCulture, out Decimal queryValue))
            {
                throw new ArgumentException("Numeric field values must be a valid number.", nameof(valueText));
            }

            if (!Decimal.TryParse(rawFieldText, styles, CultureInfo.InvariantCulture, out Decimal fieldValue))
            {
                return false; //stored data could not be parsed as a number; treat as no match
            }

            return queryValue == fieldValue;
        }

        private static bool BooleanValueEquals(string rawFieldText, string valueText)
        {
            if (valueText.Length != 1)
            {
                throw new ArgumentException("Boolean field values must be a single character: T, Y, F, or N.", nameof(valueText));
            }

            char queryChar = Char.ToUpperInvariant(valueText[0]);
            if (queryChar != 'T' && queryChar != 'Y' && queryChar != 'F' && queryChar != 'N')
            {
                throw new ArgumentException("Boolean field values must be one of: T, Y, F, N.", nameof(valueText));
            }

            bool queryValue = (queryChar == 'T' || queryChar == 'Y');

            char fieldChar = rawFieldText.Length > 0 ? Char.ToUpperInvariant(rawFieldText[0]) : '\0';
            bool fieldValue = (fieldChar == 'T' || fieldChar == 'Y');

            return queryValue == fieldValue;
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
