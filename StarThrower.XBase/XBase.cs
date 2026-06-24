// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text;
using StarThrower.ByteUtilities;
using StarThrower.StringUtilities;

namespace StarThrower.XBase
{
    /// <summary>
    /// Conversion helpers bridging the public <see cref="StarThrower.XBase"/> types
    /// (<see cref="XBaseField"/>, <see cref="XBaseRecord"/>, <see cref="FieldType"/>) and their
    /// internal, file-format-oriented counterparts in <see cref="StarThrower.XBase.Internal"/>.
    /// </summary>
    internal static class XBase
    {
        /// <summary>
        /// Converts byte[] yymmdd to "mm-dd-yyyy"
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        internal static string ThreeByteArrayToTenCharDateString(byte[] bytes)
        {
            Int16 year = ByteUtil.ByteToInt16(bytes[0], BitEndian.Little);
            Int16 month = ByteUtil.ByteToInt16(bytes[1], BitEndian.Little);
            Int16 day = ByteUtil.ByteToInt16(bytes[2], BitEndian.Little);
            year += 1900;
            return month.ToString(CultureInfo.InvariantCulture) + "-" + day.ToString(CultureInfo.InvariantCulture) + "-" + year.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts "mm-dd-yyyy" to byte[] yymmdd
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        internal static byte[] TenCharDateStringToThreeByteArray(string date)
        {
            byte[] result = new byte[3];

            Int16 month = Int16.Parse(date.AsSpan(0, 2), CultureInfo.InvariantCulture);
            Int16 day = Int16.Parse(date.AsSpan(3, 2), CultureInfo.InvariantCulture);
            Int16 year = Int16.Parse(date.AsSpan(6, 4), CultureInfo.InvariantCulture);
            year -= 1900;

            result[0] = ByteUtil.Int16ToByte(year, BitEndian.Little);
            result[1] = ByteUtil.Int16ToByte(month, BitEndian.Little);
            result[2] = ByteUtil.Int16ToByte(day, BitEndian.Little);

            return result;
        }

        /// <summary>
        /// Converts a DateTime to the 3-byte (year-1900, month, day) representation stored in a
        /// .dbf header, via the same "mm-dd-yyyy" intermediate format as <see cref="TenCharDateStringToThreeByteArray"/>.
        /// </summary>
        internal static byte[] DateTimeToThreeByteArray(DateTime dt)
        {
            StringBuilder temp = new StringBuilder(String.Empty);
            int month = dt.Month;
            int day = dt.Day;
            int year = dt.Year;

            if (month >= 10)
            {
                temp.Append(month.ToString(CultureInfo.InvariantCulture));
            }
            else
            {
                temp.Append('0');
                temp.Append(month.ToString(CultureInfo.InvariantCulture));
            }
            temp.Append('-');

            if (day >= 10)
            {
                temp.Append(day.ToString(CultureInfo.InvariantCulture));
            }
            else
            {
                temp.Append('0');
                temp.Append(day.ToString(CultureInfo.InvariantCulture));
            }
            temp.Append('-');

            temp.Append(year.ToString(CultureInfo.InvariantCulture));

            return TenCharDateStringToThreeByteArray(temp.ToString());
        }

        /// <summary>
        /// Converts the 3-byte (year-1900, month, day) representation stored in a .dbf header to a DateTime.
        /// </summary>
        internal static DateTime ThreeByteArrayToDateTime(byte[] bytes)
        {
            Int16 year = ByteUtil.ByteToInt16(bytes[0], BitEndian.Little);
            Int16 month = ByteUtil.ByteToInt16(bytes[1], BitEndian.Little);
            Int16 day = ByteUtil.ByteToInt16(bytes[2], BitEndian.Little);
            year += 1900;
            return new DateTime(year, month, day);
        }

        /// <summary>
        /// Converts a public <see cref="XBaseField"/> to its internal, file-format representation.
        /// </summary>
        internal static StarThrower.XBase.Internal.Field XBaseFieldToInternalField(StarThrower.XBase.XBaseField field)
        {
            StarThrower.XBase.Internal.Field result = new StarThrower.XBase.Internal.Field();
            result.DecimalCount = (byte)(field.DecimalCount);
            result.Length = (byte)(field.Length);
            result.Name = StringUtil.ToByteArray(field.Name);
            result.Type = (byte)(field.FieldType.Code);

            return result;
        }

        /// <summary>
        /// Converts an internal, file-format field representation to a public <see cref="XBaseField"/>,
        /// resolving its type code via <see cref="GetTypeFromByteCode"/> and trimming the
        /// null-padding from its fixed-width name.
        /// </summary>
        internal static StarThrower.XBase.XBaseField InternalFieldToXBaseField(StarThrower.XBase.Internal.Field field)
        {
            StarThrower.XBase.XBaseField result = new StarThrower.XBase.XBaseField();
            result.DecimalCount = (int)(field.DecimalCount);
            result.Length = (int)(field.Length);
            result.Name = StringUtil.FromByteArray(field.Name).TrimEnd('\0');
            result.FieldType = XBase.GetTypeFromByteCode(field.Type);
            return result;
        }

        /// <summary>
        /// Converts a public <see cref="XBaseRecord"/> to its internal, file-format representation.
        /// The deleted-record marker is stored as the ASCII byte for '*' (42/0x2A) if deleted, or
        /// a space (32/0x20) otherwise, per the XBase record format.
        /// </summary>
        internal static StarThrower.XBase.Internal.Record XBaseRecordToInternalRecord(StarThrower.XBase.XBaseRecord record, StarThrower.XBase.Internal.File file)
        {
            StarThrower.XBase.Internal.Record result = file.CreateRecord();
            if (record.IsDeleted)
            {
                result.IsDeleted = 42; //2Ah
            }
            else
            {
                result.IsDeleted = 32; //20h
            }
            result.Data = StringUtil.ToByteArray(record.Data);
            return result;
        }

        /// <summary>
        /// Converts an internal, file-format record representation to a public <see cref="XBaseRecord"/>.
        /// </summary>
        internal static StarThrower.XBase.XBaseRecord InternalRecordToXBaseRecord(StarThrower.XBase.Internal.Record record)
        {
            StarThrower.XBase.XBaseRecord result = new StarThrower.XBase.XBaseRecord();
            result.Data = StringUtil.FromByteArray(record.Data);
            result.IsDeleted = (record.IsDeleted == 42);
            result.Fields.Clear();
            foreach (StarThrower.XBase.Internal.Field field in record.Fields)
            {
                result.Fields.Add(XBase.InternalFieldToXBaseField(field));
            }
            return result;
        }

        /// <summary>
        /// Maps a single-character XBase field type code (e.g. 'C', 'N', 'D') to its corresponding
        /// <see cref="FieldType"/> instance. Any unrecognized code maps to <see cref="UndefinedField"/>.
        /// </summary>
        internal static StarThrower.XBase.FieldType GetTypeFromByteCode(byte code)
        {
            FieldType result = new StarThrower.XBase.UndefinedField();

            switch ((char)code)
            {
                case 'C':
                    result = new StarThrower.XBase.StringField();
                    break;
                case 'F':
                    result = new StarThrower.XBase.FloatField();
                    break;
                case 'D':
                    result = new StarThrower.XBase.DateField();
                    break;
                case 'N':
                    result = new StarThrower.XBase.NumericField();
                    break;
                case 'M':
                    result = new StarThrower.XBase.MemoField();
                    break;
                case 'L':
                    result = new StarThrower.XBase.BooleanField();
                    break;
                default:
                    result = new StarThrower.XBase.UndefinedField();
                    break;
            }

            return result;
        }
    }
}
