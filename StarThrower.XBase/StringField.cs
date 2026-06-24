// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using StarThrower.StringUtilities;

namespace StarThrower.XBase
{
    /// <summary>
    /// The XBase "Character" (C) field type: a fixed-width text field, right-padded with spaces
    /// to its defined length, up to 253 characters.
    /// </summary>
    public class StringField : FieldType
    {
        /// <summary>
        /// Initializes a new instance of the StringField class.
        /// </summary>
        public StringField()
            : base()
        {
            this.Text = "String";
            this.Code = 'C';
        }


        /// <summary>
        /// Gets the minimum field length, in characters: 1.
        /// </summary>
        public override int MinLength
        {
            get { return 1; }
        }

        /// <summary>
        /// Gets the maximum field length, in characters: 253.
        /// </summary>
        public override int MaxLength
        {
            get { return 253; }
        }

        /// <summary>
        /// Gets the minimum decimal count: 0. Character fields have no decimal component.
        /// </summary>
        public override int MinDecimalCount
        {
            get { return 0; }
        }

        /// <summary>
        /// Gets the maximum decimal count: 0. Character fields have no decimal component.
        /// </summary>
        public override int MaxDecimalCount
        {
            get { return 0; }
        }

        /// <summary>
        /// Tests whether the specified field length is within the range 1-253.
        /// </summary>
        /// <param name="length">The field length, in characters, to test.</param>
        /// <returns>True if length is between <see cref="MinLength"/> and <see cref="MaxLength"/>, inclusive.</returns>
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
        /// Tests whether the specified value is a string that fits within this field's defined
        /// length and, if so, right-pads it with spaces to that length.
        /// </summary>
        /// <param name="data">The string value to validate and convert.</param>
        /// <param name="result">
        /// If data is valid, data right-padded with spaces to this field's length. If data is
        /// not valid, a message describing why.
        /// </param>
        /// <returns>True if data is a string no longer than this field's length; otherwise, false.</returns>
        /// <exception cref="InvalidOperationException">Thrown if this field type has not been assigned to an <see cref="XBaseField"/>.</exception>
        public override bool IsValidData(object data, out string result)
        {
            if (this.Owner is null) throw new InvalidOperationException("Owner is not set.");

            string? temp = data as String;
            if (temp == null)
            {
                result = "Invalid data type";
                return false;
            }

            if (temp.Length >= 254)
            {
                result = "Data exceeds maximum length for Character data type";
                return false;
            }
            else if (temp.Length > this.Owner.Length)
            {
                result = "Data exceeds length defined for this field";
                return false;
            }

            result = StringUtil.AppendSpaces(temp, this.Owner.Length);
            return true;
        }

        /// <summary>
        /// Returns the given fixed-width text data unchanged.
        /// </summary>
        /// <param name="data">The fixed-width text representation to convert.</param>
        /// <returns>data, unchanged.</returns>
        public override object Translate(string data)
        {
            return data;
        }

    }
}
