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
        /// <summary>
        /// Initializes a new instance of the NumericField class.
        /// </summary>
        public NumericField()
            : base()
        {
            this.Text = "Numeric";
            this.Code = 'N';
        }

        /// <summary>
        /// Gets the minimum field length, in characters: 1.
        /// </summary>
        public override int MinLength
        {
            get { return 1; }
        }

        /// <summary>
        /// Gets the maximum field length, in characters: 17.
        /// </summary>
        public override int MaxLength
        {
            get { return 17; }
        }

        /// <summary>
        /// Gets the minimum decimal count: 0.
        /// </summary>
        public override int MinDecimalCount
        {
            get { return 0; }
        }

        /// <summary>
        /// Gets the maximum decimal count: 15.
        /// </summary>
        public override int MaxDecimalCount
        {
            get { return 15; }
        }

        /// <summary>
        /// Tests whether the specified field length is within the range 1-17.
        /// </summary>
        /// <param name="length">The field length, in characters, to test.</param>
        /// <returns>True if length is between <see cref="MinLength"/> and <see cref="MaxLength"/>, inclusive.</returns>
        public override bool IsValidLength(int length)
        {
            return (length >= MinLength && length <= MaxLength);
        }

        /// <summary>
        /// Tests whether the specified decimal count is within the range 0-15.
        /// </summary>
        /// <param name="decimalCount">The decimal count to test.</param>
        /// <returns>True if decimalCount is between <see cref="MinDecimalCount"/> and <see cref="MaxDecimalCount"/>, inclusive.</returns>
        public override bool IsValidDecimalCount(int decimalCount)
        {
            return (decimalCount >= MinDecimalCount && decimalCount <= MaxDecimalCount);
        }

        /// <summary>
        /// Tests whether the specified value is valid for this field. If the owning field's
        /// decimal count is 0, the value must be an <see cref="short"/>, <see cref="int"/>, or
        /// <see cref="long"/> within the range -9999999999999999 to 99999999999999999; otherwise,
        /// the value must be a finite <see cref="float"/> or <see cref="double"/>. In either case,
        /// the value must fit within this field's defined length once formatted.
        /// </summary>
        /// <param name="data">The numeric value to validate and convert.</param>
        /// <param name="result">
        /// If data is valid, data formatted and right-padded with spaces to this field's length.
        /// If data is not valid, a message describing why ("Invalid data type" or "Overflow").
        /// </param>
        /// <returns>True if data is valid for this field's configured decimal count; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">Thrown if data is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if this field type has not been assigned to an <see cref="XBaseField"/>.</exception>
        /// <exception cref="BadDataException">Thrown if the owning field's decimal count is 0 and the formatted integer value exceeds this field's defined length.</exception>
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

        /// <summary>
        /// Converts the fixed-width text representation of a Numeric field to its in-memory value:
        /// a <see cref="long"/> if the owning field's decimal count is 0, or a <see cref="double"/> otherwise.
        /// </summary>
        /// <param name="data">The fixed-width text representation to convert.</param>
        /// <returns>The long or double represented by data.</returns>
        /// <exception cref="InvalidOperationException">Thrown if this field type has not been assigned to an <see cref="XBaseField"/>.</exception>
        /// <exception cref="BadDataException">Thrown if data cannot be parsed as the expected numeric type.</exception>
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
