using System;
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
            if (data == null) throw new ArgumentNullException("data");

            if (this.Owner.DecimalCount == 0) //treat this field as if it were a (shortened) Int64
            {
                if (data is Int16 || data is Int32)
                {
                    if (data.ToString().Length > this.Owner.Length) throw new BadDataException("data length exceeds field length");
                    result = StringUtil.AppendSpaces(data.ToString(), this.Owner.Length);
                    return true;
                }
                if (data is Int64)
                {
                    if (data.ToString().Length > this.Owner.Length) throw new BadDataException("data length exceeds field length");

                    Int64 temp = (Int64)data;
                    if (temp >= -9999999999999999 && temp <= 99999999999999999)
                    {
                        result = StringUtil.AppendSpaces(data.ToString(), this.Owner.Length);
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
