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
using StarThrower.StringUtilities;

namespace StarThrower.XBase
{
    /// <summary>
    /// ASCII text up till 18 characters long (including sign and decimal point).  Valid 
    /// characters: '0' - '9', '.', '-'.
    /// A DecimalCount of 0 will be treated as an integer value in the range
    /// -9999999999999999 through 99999999999999999.  Not that this value
    /// must be stored in a C# Int64 - it will overflow an Int32.  However,
    /// the XBase Numeric type is not large enough to contain the maximum range
    /// of an Int64 - so it is possible to overflow this XBase Numeric type with
    /// an Int64.
    /// </summary>
    /// <remarks>
    /// Numeric fields can be up to 20 characters long in FoxPro and Clipper
    /// </remarks>
    public class NumericField : FieldType
    {
        public NumericField()
            : base()
        {
            this.Text = Resources.Numeric;
            this.Code = 'N';
        }

        public override int MinLength
        {
            get { return 1; }
        }

        public override int MaxLength
        {
            get { return 17; }
        }

        public override int MinDecimalCount
        {
            get { return 0; }
        }

        public override int MaxDecimalCount
        {
            get { return 15; }
        }

        public override bool IsValidLength(int length)
        {
            return (length >= MinLength && length <= MaxLength);
        }

        public override bool IsValidDecimalCount(int decimalCount)
        {
            return (decimalCount >= MinDecimalCount && decimalCount <= MaxDecimalCount);
        }

        public override bool IsValidData(object data, out string result)
        {
            ArgumentNullException.ThrowIfNull(data);
            if (this.Owner is null) throw new InvalidOperationException("Owner is not set.");

            if (this.Owner.DecimalCount == 0) //treat this field as if it were a (shortened) Int64
            {
                if (data is Int16 || data is Int32)
                {
                    string dataStr = data.ToString() ?? string.Empty;
                    if (dataStr.Length > this.Owner.Length) throw new BadDataException("data length exceeds field length");
                    result = StringUtil.AppendSpaces(dataStr, this.Owner.Length);
                    return true;
                }
                if (data is Int64 i64)
                {
                    string dataStr = i64.ToString(CultureInfo.InvariantCulture) ?? string.Empty;
                    if (dataStr.Length > this.Owner.Length) throw new BadDataException("data length exceeds field length");

                    if (i64 >= -9999999999999999 && i64 <= 99999999999999999)
                    {
                        result = StringUtil.AppendSpaces(dataStr, this.Owner.Length);
                        return true;
                    }
                    else
                    {
                        result = "Overflow";
                        return false;
                    }
                }
                else
                {
                    result = "Invalid data type";
                    return false;
                }
            }
            else //treat it as if it were a double
            {
                if (data is Single)
                {
                    //TODO: parse data to confirm that it adheres to Lengh & DecimalCount for this Numeric field.
                    //      also, check for overflow/underflow conditions
                    result = String.Empty;
                    return true;
                }
                else if (data is Double)
                {
                    //TODO: parse data to confirm that it adheres to Lengh & DecimalCount for this Numeric field
                    //      also, check for overflow/underflow conditions
                    result = String.Empty;
                    return true;
                }
                else
                {
                    result = "Invalid data type";
                    return false;
                }
            }
        }

        public override object Translate(string data)
        {
            if (this.Owner is null) throw new InvalidOperationException("Owner is not set.");
            if (this.Owner.DecimalCount == 0) //treat this field as if it were an Int64
            {
                Int64 result = 0;
                if (!Int64.TryParse(data, out result)) throw new BadDataException("Invalid data type");
                return result;
            }
            else //treat it as if it were a double
            {
                Double result = 0.0;
                if (!Double.TryParse(data, out result)) throw new BadDataException("Invalid data type");
                return result;
            }
        }

    }
}
