// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

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
            this.Text = "Numeric";
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
                double value;
                if (data is Single sgl)
                {
                    value = sgl;
                }
                else if (data is Double dbl)
                {
                    value = dbl;
                }
                else
                {
                    result = "Invalid data type";
                    return false;
                }

                if (Double.IsNaN(value) || Double.IsInfinity(value))
                {
                    result = "Invalid data type";
                    return false;
                }

                string dataStr = value.ToString("F" + this.Owner.DecimalCount.ToString(CultureInfo.InvariantCulture), CultureInfo.InvariantCulture);
                if (dataStr.Length > this.Owner.Length)
                {
                    result = "Data exceeds length defined for this field";
                    return false;
                }

                result = StringUtil.AppendSpaces(dataStr, this.Owner.Length);
                return true;
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
