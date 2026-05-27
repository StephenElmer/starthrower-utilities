using System;
using System.Globalization;
using System.Text;
using StarThrower.ByteUtilities;

namespace StarThrower.XBase.Internal
{
    internal class FileHeader
    {
        internal const Int32 MAXSIZE = 4129; //maximum size in bytes possible for the header (note this includes XBaseFieldDescriptor.MAXLENGTH * XBaseFieldDescriptorList.MAX)


        #region Private Member Variables

        private byte _signature = 3; //Also called Version.  Valid dBase IV file; bits 0-2 indicate version number, bit 3 the presence of a dBase IV memo file, bits 4-6 the presence of an SQL table, bit 7 the presence of ANY memo file (either dBase III PLUS or dBase IV).
        private byte[] _lastUpdate = new byte[3]; //Date of last update formatted as YYMMDD
        private Int32 _recordCount; //Number of records in the file
        private Int16 _headerLength = 33; //Number of bytes in the header (33 bytes w/ NO fields
        private Int16 _recordLength = 1; //Number of bytes in a record (we initialize this to 1 to account for the delete flag)
        private byte[] _reserved1 = { 0, 0 }; //Reserved, fill with zero
        private byte _incompleteTransaction; //Flag indicating incomplete transaction
        private byte _encryptionFlag; //Encryption flag
        private byte[] _reserved2 = new byte[4]; //Free record thread (Reserved for LAN only)
        private byte[] _reserved3 = new byte[8]; //Reserved for multi-user dBase
        private byte _mdxFlag; //Production MDX flag; (Hex 01) if there is an MDX, (Hex 00) if not
        private byte _languageDriver; //Language Driver ID
        private byte[] _reserved4 = { 0, 0 }; //Reserved, fill with zero (Hex 59, Hex 00)
        private StarThrower.XBase.Internal.FieldCollection _fields = new StarThrower.XBase.Internal.FieldCollection(); //Field descriptor array (max of 128 fields)
        private byte _terminator = 13; //field terminator (Hex 0d)

        #endregion


        #region Internal Properties

        /// <summary>
        /// (Also called Version)
        /// Valid dBase IV file; bits 0-2 indicate version number, bit 3 the presence of a dBase IV memo file, bits 4-6 the presence of an SQL table, bit 7 the presence of ANY memo file (either dBase III PLUS or dBase IV).
        /// 
        /// 
        /// Value       Bit Mask        Description
        /// 02h         00000010        FoxBase
        /// 03h         00000011        File without DBT
        /// 04h         00000100        dBase IV w/o memo file
        /// 05h         00000101        dBase V w/o memo file
        /// 30h         00110000        Visual FoxPro
        /// 30h         00110000        Visual FoxPro w. DBC
        /// 31h         00110001        Visual FoxPro w. AutoIncrement Field
        /// 43h         01000011        .dbv memo var size (Flagship)
        /// 7Bh         01111011        dBase IV with memo
        /// 83h         10000011        dBase III+ with memo file
        /// 8Bh         10001011        dBase IV w. memo
        /// 
        /// dBase IV bit flags:
        /// Bit         Description
        /// 0-2         Version no. i.e. 0-7
        /// 3           Presence of memo file
        /// 4-6         Presence of SQL table
        /// 7           DBT flag
        /// </summary>
        internal byte Signature
        {
            get { return _signature; }
            set { _signature = value; }
        }

        /// <summary>
        /// Date of last update formatted as YYMMDD
        /// 
        /// (3 bytes)
        /// 
        /// Stored at binary (little endian). Unsigned.
        /// Date in header is without century (YYMMDD) and date in records are with century YYYYMMDD.  Valid
        /// interval is 00h - FFh.  Add base year 1900 and you'll have the interval 1900 - 2155.
        /// </summary>
        internal byte[] LastUpdate
        {
            get { return _lastUpdate; }
            set { _lastUpdate = value; }
        }

        /// <summary>
        /// Number of records in the file
        /// 
        /// (32 bits)
        /// Stored at binary (little endian). Unsigned.
        /// </summary>
        internal Int32 RecordCount
        {
            get { return _recordCount; }
            set { _recordCount = value; }
        }

        /// <summary>
        /// Number of bytes in the header
        /// 
        /// (16 bits)
        /// Stored at binary (little endian). Unsigned.
        /// </summary>
        internal Int16 HeaderLength
        {
            get { return _headerLength; }
            set { _headerLength = value; }
        }

        /// <summary>
        /// Number of bytes in a record
        /// 
        /// (16 bits)
        /// Stored at binary (little endian). Unsigned.
        /// </summary>
        internal Int16 RecordLength
        {
            get { return _recordLength; }
            set { _recordLength = value; }
        }

        /// <summary>
        /// Reserved, fill with zero
        /// 
        /// (2 bytes)
        /// 
        /// Sum of lengths of all fields + 1 (deletion flag)
        /// </summary>
        internal byte[] Reserved1
        {
            get { return _reserved1; }
        }

        /// <summary>
        /// Flag indicating incomplete transaction (dBase IV)
        /// 
        /// Value       Description
        /// 00h         Transaction ended (or rolled back)
        /// 01h         Transaction started
        /// </summary>
        internal byte IncompleteTransaction
        {
            get { return _incompleteTransaction; }
            set { _incompleteTransaction = value; }
        }

        /// <summary>
        /// Encryption flag (dBase IV)
        /// 
        /// Be very careful NOT to modify this flag!
        /// This is the only indication that the content is encrypted.
        /// 
        /// Value       Description
        /// 00h         Not encrypted
        /// 01h         Data encrypted
        /// </summary>
        internal byte EncryptionFlag
        {
            get { return _encryptionFlag; }
            set { _encryptionFlag = value; }
        }

        /// <summary>
        /// Free record thread (Reserved for LAN only)
        /// 
        /// (4 bytes)
        /// </summary>
        internal byte[] Reserved2
        {
            get { return _reserved2; }
        }

        /// <summary>
        /// Reserved for multi-user dBase
        /// 
        /// (8 bytes)
        /// </summary>
        internal byte[] Reserved3
        {
            get { return _reserved3; }
        }

        /// <summary>
        /// MDX Flag (dBase IV)
        /// 
        /// Stored at binary (little endian).  Unsigned.
        /// 
        /// (Hex 01) if there is an MDX, (Hex 00) if not
        /// </summary>
        internal byte MdxFlag
        {
            get { return _mdxFlag; }
            set { _mdxFlag = value; }
        }

        /// <summary>
        /// Language Driver ID
        /// 
        /// (FoxPro) Code page:  These values follow the DOS / Windows Code Page values.
        /// Value       Description             Code Page
        /// 01h         DOS USA                 code page 437
        /// 02h         DOS Multilingual        code page 850
        /// 03h         Windows ANSI            code page 1252
        /// 04h         Standard Macintosh      
        /// 64h         EE MS-DOS               code page 852
        /// 65h         Nordic MS-DOS           code page 865
        /// 66h         Russian MS-DOS          code page 866
        /// 67h         Icelandic MS-DOS
        /// 68h         Kamenicky (Czech) MS-DOS
        /// 69h         Mazovia (Polish) MS-DOS
        /// 6Ah         Greek MS-DOS (437G)
        /// 6Bh         Turkish MS-DOS
        /// 96h         Russian Macintosh
        /// 97h         Eastern European Macintosh
        /// 98h         Greek Macintosh
        /// C8h         Windows EE              code page 1250
        /// C9h         Russian Windows
        /// CAh         Turkish Windows
        /// CBh         Greek Windows
        /// </summary>
        internal byte LanguageDriver
        {
            get { return _languageDriver; }
            set { _languageDriver = value; }
        }

        /// <summary>
        /// Reserved (dBase IV), filled with zero (00h)
        /// 
        /// (2 bytes)
        /// 
        /// Filled with 00h
        /// </summary>
        internal byte[] Reserved4
        {
            get { return _reserved4; }
        }

        /// <summary>
        /// Field descriptor list
        /// 
        /// Max of 128 fields
        /// 
        /// (at 32 bytes per FieldDescriptor, this field property
        ///  maxes out at 4096 bytes)
        /// </summary>
        internal StarThrower.XBase.Internal.FieldCollection Fields
        {
            get { return _fields; }
        }

        /// <summary>
        /// Terminator
        /// 
        /// 0Dh
        /// </summary>
        internal byte Terminator
        {
            get { return _terminator; }
            set { _terminator = value; }
        }

        #endregion


        #region Internal Methods

        internal void ParseBytes(byte[] bytes)
        {
            _signature = bytes[0];

            _lastUpdate = ByteUtil.ByteSubstring(bytes, 1, 3);

            _recordCount = ByteUtil.ByteArrayToInt32(ByteUtil.ByteSubstring(bytes, 4, 4), ByteEndian.Little, BitEndian.Little); // bytes[4 - 7]

            _headerLength = ByteUtil.ByteArrayToInt16(ByteUtil.ByteSubstring(bytes, 8, 2), ByteEndian.Little, BitEndian.Little); // bytes[8 & 9]

            _recordLength = ByteUtil.ByteArrayToInt16(ByteUtil.ByteSubstring(bytes, 10, 2), ByteEndian.Little, BitEndian.Little); // bytes[10 & 11]

            _reserved1 = ByteUtil.ByteSubstring(bytes, 12, 2); // bytes[12 & 13]

            _incompleteTransaction = bytes[14];

            _encryptionFlag = bytes[15];

            _reserved2 = ByteUtil.ByteSubstring(bytes, 16, 4); // bytes[16 - 19]

            _reserved2 = ByteUtil.ByteSubstring(bytes, 20, 8); // bytes[20 - 27]

            _mdxFlag = bytes[28];

            _languageDriver = bytes[29];

            _reserved4 = ByteUtil.ByteSubstring(bytes, 30, 2); // bytes[30 & 31]

            Int32 curIdx = 32;
            bool done = false;
            for (Int32 i = 0; i < StarThrower.XBase.Internal.FieldCollection.MAXSIZE && !done; i++)
            {
                byte[] fieldBuffer = ByteUtil.ByteSubstring(bytes, curIdx, StarThrower.XBase.Internal.Field.SIZE);
                StarThrower.XBase.Internal.Field field = new StarThrower.XBase.Internal.Field(fieldBuffer);
                //if (_fields.Count == 0)
                //{
                //    field.StartIndex = 0;
                //}
                //else
                //{
                //    field.StartIndex = _fields[i - 1].StartIndex + _fields[i - 1].Length;
                //}
                _fields.Add(field);
                curIdx += StarThrower.XBase.Internal.Field.SIZE;

                //it *should* be the case that after the last field descriptor
                //is read, curIdx should equal (length - 1) and that should
                //be the condition for terminating the loop.
                if (curIdx >= (_headerLength - 1))
                {
                    done = true;
                }
            }

            _terminator = bytes[_headerLength - 1];
        }

        internal byte[] GetBytes()
        {
            Int32 curIdx = 0;
            byte[] result = new byte[(_fields.Count * StarThrower.XBase.Internal.Field.SIZE) + 33];

            result[curIdx++] = _signature;

            result[curIdx++] = _lastUpdate[0];
            result[curIdx++] = _lastUpdate[1];
            result[curIdx++] = _lastUpdate[2];

            byte[] recordCount = ByteUtil.Int32ToByteArray(_recordCount, ByteEndian.Little, BitEndian.Little);
            for (Int32 i = 0; i < 4; i++)
            {
                result[curIdx++] = recordCount[i];
            }

            byte[] headerLength = ByteUtil.Int16ToByteArray(_headerLength, ByteEndian.Little, BitEndian.Little);
            for (Int32 i = 0; i < 2; i++)
            {
                result[curIdx++] = headerLength[i];
            }

            byte[] recordLength = ByteUtil.Int16ToByteArray(_recordLength, ByteEndian.Little, BitEndian.Little);
            for (Int32 i = 0; i < 2; i++)
            {
                result[curIdx++] = recordLength[i];
            }

            result[curIdx++] = _reserved1[0];
            result[curIdx++] = _reserved1[1];

            result[curIdx++] = _incompleteTransaction;

            result[curIdx++] = _encryptionFlag;

            result[curIdx++] = _reserved2[0];
            result[curIdx++] = _reserved2[1];
            result[curIdx++] = _reserved2[2];
            result[curIdx++] = _reserved2[3];

            result[curIdx++] = _reserved3[0];
            result[curIdx++] = _reserved3[1];
            result[curIdx++] = _reserved3[2];
            result[curIdx++] = _reserved3[3];
            result[curIdx++] = _reserved3[4];
            result[curIdx++] = _reserved3[5];
            result[curIdx++] = _reserved3[6];
            result[curIdx++] = _reserved3[7];

            result[curIdx++] = _mdxFlag;

            result[curIdx++] = _languageDriver;

            result[curIdx++] = _reserved4[0];
            result[curIdx++] = _reserved4[1];

            foreach (StarThrower.XBase.Internal.Field field in _fields)
            {
                byte[] fieldBuffer = field.GetBytes();
                for (Int32 i = 0; i < fieldBuffer.Length; i++)
                {
                    result[curIdx++] = fieldBuffer[i];
                }
            }

            result[result.Length - 1] = _terminator;

            return result;
        }

        internal string ToXml()
        {
            StringBuilder result = new StringBuilder(String.Empty);
            result.Append("<fileHeader ");
            result.Append("signature=\"" + _signature.ToString(CultureInfo.InvariantCulture) + "\" ");
            result.Append("lastUpdate=\"" + XBase.ThreeByteArrayToTenCharDateString(_lastUpdate) + "\" ");
            result.Append("recordCount=\"" + _recordCount.ToString(CultureInfo.InvariantCulture) + "\" ");
            result.Append("headerLength=\"" + _headerLength.ToString(CultureInfo.InvariantCulture) + "\" ");
            result.Append("recordLength=\"" + _recordLength.ToString(CultureInfo.InvariantCulture) + "\" ");
            result.Append("reserved1=\"" + _reserved1.ToString() + "\" ");
            result.Append("incompleteTransaction=\"" + _incompleteTransaction.ToString(CultureInfo.InvariantCulture) + "\" ");
            result.Append("encryptionFlag=\"" + _encryptionFlag.ToString(CultureInfo.InvariantCulture) + "\" ");
            result.Append("reserved2=\"" + _reserved2.ToString() + "\" ");
            result.Append("reserved3=\"" + _reserved3.ToString() + "\" ");
            result.Append("mdxFlag=\"" + _mdxFlag.ToString(CultureInfo.InvariantCulture) + "\" ");
            result.Append("languageDriver=\"" + _languageDriver.ToString(CultureInfo.InvariantCulture) + "\" ");
            result.Append("reserved4=\"" + _reserved4.ToString() + "\" ");
            result.AppendLine(">");
            result.Append(_fields.ToXml());
            result.AppendLine("<terminator value=\"" + _terminator.ToString(CultureInfo.InvariantCulture) + "\"/>");
            result.AppendLine("</fileHeader>");
            return result.ToString();
        }

        #endregion


        #region Object Overrides

        /// <summary>
        /// Tests whether the given object is equal to this object.
        /// </summary>
        /// <param name="obj">The object to compare to this object.</param>
        /// <returns>true if other is an instance of the same class as this object and has reference or value equality with this object; otherwise, false.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(obj, null)) return false;
            if (Object.ReferenceEquals(obj, this)) return true;
            if (!(obj is StarThrower.XBase.Internal.FileHeader)) return false;
            StarThrower.XBase.Internal.FileHeader other = (StarThrower.XBase.Internal.FileHeader)obj;
            return _signature.Equals(other.Signature) &&
                   _lastUpdate.Equals(other.LastUpdate) &&
                   _recordCount.Equals(other.RecordCount) &&
                   _headerLength.Equals(other.HeaderLength) &&
                   _recordLength.Equals(other.RecordLength) &&
                   _reserved1.Equals(other.Reserved1) &&
                   _incompleteTransaction.Equals(other.IncompleteTransaction) &&
                   _encryptionFlag.Equals(other.EncryptionFlag) &&
                   _reserved2.Equals(other.Reserved2) &&
                   _reserved3.Equals(other.Reserved3) &&
                   _mdxFlag.Equals(other.MdxFlag) &&
                   _languageDriver.Equals(other.LanguageDriver) &&
                   _reserved4.Equals(other.Reserved4) &&
                   _fields.Equals(other.Fields) &&
                   _terminator.Equals(other.Terminator);
        }

        /// <summary>
        /// Tests whether the given object is equal to this object.
        /// Optimized for instances of this class.
        /// </summary>
        /// <param name="other">The object to compare to this object.</param>
        /// <returns>true if other has reference or value equality with this object; otherwise, false.</returns>
        public bool Equals(StarThrower.XBase.Internal.FileHeader other)
        {
            if (Object.ReferenceEquals(other, null)) return false;
            if (Object.ReferenceEquals(other, this)) return true;
            return _signature.Equals(other.Signature) &&
                   _lastUpdate.Equals(other.LastUpdate) &&
                   _recordCount.Equals(other.RecordCount) &&
                   _headerLength.Equals(other.HeaderLength) &&
                   _recordLength.Equals(other.RecordLength) &&
                   _reserved1.Equals(other.Reserved1) &&
                   _incompleteTransaction.Equals(other.IncompleteTransaction) &&
                   _encryptionFlag.Equals(other.EncryptionFlag) &&
                   _reserved2.Equals(other.Reserved2) &&
                   _reserved3.Equals(other.Reserved3) &&
                   _mdxFlag.Equals(other.MdxFlag) &&
                   _languageDriver.Equals(other.LanguageDriver) &&
                   _reserved4.Equals(other.Reserved4) &&
                   _fields.Equals(other.Fields) &&
                   _terminator.Equals(other.Terminator);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + _signature.GetHashCode();
            result = 31 * result + _lastUpdate.GetHashCode();
            result = 31 * result + _recordCount.GetHashCode();
            result = 31 * result + _headerLength.GetHashCode();
            result = 31 * result + _recordLength.GetHashCode();
            result = 31 * result + _reserved1.GetHashCode();
            result = 31 * result + _incompleteTransaction.GetHashCode();
            result = 31 * result + _encryptionFlag.GetHashCode();
            result = 31 * result + _reserved2.GetHashCode();
            result = 31 * result + _reserved3.GetHashCode();
            result = 31 * result + _mdxFlag.GetHashCode();
            result = 31 * result + _languageDriver.GetHashCode();
            result = 31 * result + _reserved4.GetHashCode();
            result = 31 * result + _fields.GetHashCode();
            result = 31 * result + _terminator.GetHashCode();
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
            return "[" + this.GetType().Name + "]";
        }

        #endregion
    }
}
