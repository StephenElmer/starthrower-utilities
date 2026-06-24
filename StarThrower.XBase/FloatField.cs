// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Globalization;
using StarThrower.StringUtilities;

namespace StarThrower.XBase
{
    /// <summary>
    /// The XBase "Float" (F) field type: a 20-character numeric field stored as ASCII text,
    /// holding a <see cref="float"/> or <see cref="double"/> value with up to 19 decimal places.
    /// </summary>
    public class FloatField : FieldType
    {
        /// <summary>
        /// Initializes a new instance of the FloatField class.
        /// </summary>
        public FloatField()
            : base()
        {
            this.Text = "Float";
            this.Code = 'F';
        }

        /// <summary>
        /// Gets or sets the <see cref="XBaseField"/> that this field type instance belongs to.
        /// Setting this forces the owning field's <see cref="XBaseField.Length"/> to 20, the
        /// only valid length for this type.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown on set if the value is null.</exception>
        public override XBaseField? Owner
        {
            get { return base.Owner; }
            set
            {
                ArgumentNullException.ThrowIfNull(value);

                base.Owner = value;
                value.Length = 20;
            }
        }

        /// <summary>
        /// Gets the minimum field length, in characters: 20.
        /// </summary>
        public override int MinLength
        {
            get { return 20; }
        }

        /// <summary>
        /// Gets the maximum field length, in characters: 20.
        /// </summary>
        public override int MaxLength
        {
            get { return 20; }
        }

        /// <summary>
        /// Gets the minimum decimal count: 0.
        /// </summary>
        public override int MinDecimalCount
        {
            get { return 0; }
        }

        /// <summary>
        /// Gets the maximum decimal count: 19.
        /// </summary>
        public override int MaxDecimalCount
        {
            get { return 19; }
        }

        /// <summary>
        /// Tests whether the specified field length is 20, the only valid length for this type.
        /// </summary>
        /// <param name="length">The field length, in characters, to test.</param>
        /// <returns>True if length is 20.</returns>
        public override bool IsValidLength(int length)
        {
            return (length >= MinLength && length <= MaxLength);
        }

        /// <summary>
        /// Tests whether the specified decimal count is within the range 0-19.
        /// </summary>
        /// <param name="decimalCount">The decimal count to test.</param>
        /// <returns>True if decimalCount is between <see cref="MinDecimalCount"/> and <see cref="MaxDecimalCount"/>, inclusive.</returns>
        public override bool IsValidDecimalCount(int decimalCount)
        {
            return (decimalCount >= MinDecimalCount && decimalCount <= MaxDecimalCount);
        }

        /// <summary>
        /// Tests whether the specified value is a finite <see cref="float"/> or <see cref="double"/>
        /// that fits within this field's defined length once formatted, and if so, formats and
        /// right-pads it with spaces to that length.
        /// </summary>
        /// <param name="data">The numeric value to validate and convert.</param>
        /// <param name="result">
        /// If data is valid, data formatted to this field's decimal count and right-padded with
        /// spaces to its length. If data is not valid, a message describing why.
        /// </param>
        /// <returns>True if data is a finite float or double that fits within this field's length; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">Thrown if data is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if this field type has not been assigned to an <see cref="XBaseField"/>.</exception>
        public override bool IsValidData(object data, out string result)
        {
            ArgumentNullException.ThrowIfNull(data);
            if (this.Owner is null) throw new InvalidOperationException("Owner is not set.");

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

        /// <summary>
        /// Converts the fixed-width text representation of a Float field to a <see cref="double"/>.
        /// </summary>
        /// <param name="data">The fixed-width text representation to convert.</param>
        /// <returns>The double represented by data.</returns>
        public override object Translate(string data)
        {
            return double.Parse(data, CultureInfo.InvariantCulture);
        }

    }
}
