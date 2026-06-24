// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Globalization;

namespace StarThrower.XBase
{
    /// <summary>
    /// The XBase "Date" (D) field type: an 8-character date field, stored as "YYYYMMDD".
    /// </summary>
    public class DateField : FieldType
    {
        /// <summary>
        /// Initializes a new instance of the DateField class.
        /// </summary>
        public DateField()
            : base()
        {
            this.Text = "Date";
            this.Code = 'D';
        }

        /// <summary>
        /// Gets or sets the <see cref="XBaseField"/> that this field type instance belongs to.
        /// Setting this forces the owning field's <see cref="XBaseField.Length"/> to 8 and
        /// <see cref="XBaseField.DecimalCount"/> to 0, the only valid values for this type.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown on set if the value is null.</exception>
        public override XBaseField? Owner
        {
            get { return base.Owner; }
            set
            {
                ArgumentNullException.ThrowIfNull(value);

                base.Owner = value;
                value.Length = 8;
                value.DecimalCount = 0;
            }
        }

        /// <summary>
        /// Gets the minimum field length, in characters: 8.
        /// </summary>
        public override int MinLength
        {
            get { return 8; }
        }

        /// <summary>
        /// Gets the maximum field length, in characters: 8.
        /// </summary>
        public override int MaxLength
        {
            get { return 8; }
        }

        /// <summary>
        /// Gets the minimum decimal count: 0. Date fields have no decimal component.
        /// </summary>
        public override int MinDecimalCount
        {
            get { return 0; }
        }

        /// <summary>
        /// Gets the maximum decimal count: 0. Date fields have no decimal component.
        /// </summary>
        public override int MaxDecimalCount
        {
            get { return 0; }
        }

        /// <summary>
        /// Tests whether the specified field length is 8, the only valid length for this type.
        /// </summary>
        /// <param name="length">The field length, in characters, to test.</param>
        /// <returns>True if length is 8.</returns>
        public override bool IsValidLength(int length)
        {
            return (length >= MinLength && length <= MaxLength);
        }

        /// <summary>
        /// Tests whether the specified decimal count is 0, the only valid value for this type.
        /// </summary>
        /// <param name="decimalCount">The decimal count to test.</param>
        /// <returns>True if decimalCount is 0.</returns>
        public override bool IsValidDecimalCount(int decimalCount)
        {
            return (decimalCount >= MinDecimalCount && decimalCount <= MaxDecimalCount);
        }

        /// <summary>
        /// Tests whether the specified value is a <see cref="DateTime"/> and, if so, converts it
        /// to its "YYYYMMDD" XBase representation.
        /// </summary>
        /// <param name="data">The date value to validate and convert.</param>
        /// <param name="result">If data is a DateTime, its date formatted as "YYYYMMDD"; otherwise, a message describing why it's invalid.</param>
        /// <returns>True if data is a DateTime; otherwise, false.</returns>
        public override bool IsValidData(object data, out string result)
        {
            if (!(data is DateTime))
            {
                result = "Invalid data type";
                return false;
            }

            DateTime temp = (DateTime)data;
            string yr = temp.Year.ToString(CultureInfo.InvariantCulture);
            string mo = String.Empty;
            string day = String.Empty;
            if (temp.Month < 10)
            {
                mo = "0" + temp.Month.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                mo = temp.Month.ToString(CultureInfo.InvariantCulture);
            }
            if (temp.Day < 10)
            {
                day = "0" + temp.Day.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                day = temp.Day.ToString(CultureInfo.InvariantCulture);
            }
            result = yr + mo + day;

            return true;
        }

        /// <summary>
        /// Converts an 8-character "YYYYMMDD" XBase date value to a <see cref="DateTime"/>.
        /// </summary>
        /// <param name="data">The "YYYYMMDD" representation to convert.</param>
        /// <returns>The DateTime represented by data.</returns>
        /// <exception cref="ArgumentNullException">Thrown if data is null.</exception>
        public override object Translate(string data)
        {
            ArgumentNullException.ThrowIfNull(data);

            int yr = int.Parse(data.AsSpan(0, 4), CultureInfo.InvariantCulture);
            int mo = int.Parse(data.AsSpan(4, 2), CultureInfo.InvariantCulture);
            int day = int.Parse(data.AsSpan(6, 2), CultureInfo.InvariantCulture);

            return new DateTime(yr, mo, day);
        }

    }
}
