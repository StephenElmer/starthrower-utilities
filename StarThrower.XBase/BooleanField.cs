// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.XBase
{
    /// <summary>
    /// The XBase "Logical" (L) field type: a single-character boolean field, stored as "T" or "F".
    /// </summary>
    public class BooleanField : FieldType
    {
        /// <summary>
        /// Initializes a new instance of the BooleanField class.
        /// </summary>
        public BooleanField()
            : base()
        {
            this.Text = "Boolean";
            this.Code = 'L';
        }

        /// <summary>
        /// Gets or sets the <see cref="XBaseField"/> that this field type instance belongs to.
        /// Setting this forces the owning field's <see cref="XBaseField.Length"/> to 1 and
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
                value.Length = 1;
                value.DecimalCount = 0;
            }
        }

        /// <summary>
        /// Gets the minimum field length, in characters: 1.
        /// </summary>
        public override int MinLength
        {
            get { return 1; }
        }

        /// <summary>
        /// Gets the maximum field length, in characters: 1.
        /// </summary>
        public override int MaxLength
        {
            get { return 1; }
        }

        /// <summary>
        /// Gets the minimum decimal count: 0. Boolean fields have no decimal component.
        /// </summary>
        public override int MinDecimalCount
        {
            get { return 0; }
        }

        /// <summary>
        /// Gets the maximum decimal count: 0. Boolean fields have no decimal component.
        /// </summary>
        public override int MaxDecimalCount
        {
            get { return 0; }
        }

        /// <summary>
        /// Tests whether the specified field length is 1, the only valid length for this type.
        /// </summary>
        /// <param name="length">The field length, in characters, to test.</param>
        /// <returns>True if length is 1.</returns>
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
        /// Tests whether the specified value is a <see cref="bool"/> and, if so, converts it to
        /// its single-character XBase representation.
        /// </summary>
        /// <param name="data">The boolean value to validate and convert.</param>
        /// <param name="result">If data is a bool, "T" for true or "F" for false; otherwise, a message describing why it's invalid.</param>
        /// <returns>True if data is a bool; otherwise, false.</returns>
        public override bool IsValidData(object data, out string result)
        {
            if (!(data is bool))
            {
                result = "Invalid data type";
                return false;
            }

            bool temp = (bool)data;
            if (temp)
            {
                result = "T";
            }
            else
            {
                result = "F";
            }

            return true;
        }

        /// <summary>
        /// Converts a single-character XBase logical value to a <see cref="bool"/>.
        /// </summary>
        /// <param name="data">The XBase logical value: "y" or "t" for true; "n", "f", or "?" for false (case-insensitive).</param>
        /// <returns>True if data is "y" or "t"; false if data is "n", "f", or "?".</returns>
        /// <exception cref="ArgumentNullException">Thrown if data is null.</exception>
        /// <exception cref="BadDataException">Thrown if data is none of the recognized values.</exception>
        public override object Translate(string data)
        {
            ArgumentNullException.ThrowIfNull(data);

            if (string.Equals(data, "y", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(data, "t", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else if (string.Equals(data, "n", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(data, "f", StringComparison.OrdinalIgnoreCase)   ||
                     string.Equals(data, "?", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            else
            {
                throw new BadDataException();
            }
        }
    }
}
