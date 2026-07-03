// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.XBase
{
    /// <summary>
    /// The XBase "Memo" (M) field type: a 10-character field holding a pointer (block number)
    /// into a separate .dbt memo file, rather than the text content itself.
    /// </summary>
    public class MemoField : FieldType
    {
        /// <summary>
        /// Initializes a new instance of the MemoField class.
        /// </summary>
        public MemoField()
            : base()
        {
            this.Text = "Memo";
            this.Code = 'M';
        }

        /// <summary>
        /// Gets or sets the <see cref="XBaseField"/> that this field type instance belongs to.
        /// Setting this forces the owning field's <see cref="XBaseField.Length"/> to 10 and
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
                value.Length = 10;
                value.DecimalCount = 0;
            }
        }

        /// <summary>
        /// Gets the minimum field length, in characters: 10.
        /// </summary>
        public override int MinLength
        {
            get { return 10; }
        }

        /// <summary>
        /// Gets the maximum field length, in characters: 10.
        /// </summary>
        public override int MaxLength
        {
            get { return 10; }
        }

        /// <summary>
        /// Gets the minimum decimal count: 0. Memo fields have no decimal component.
        /// </summary>
        public override int MinDecimalCount
        {
            get { return 0; }
        }

        /// <summary>
        /// Gets the maximum decimal count: 0. Memo fields have no decimal component.
        /// </summary>
        public override int MaxDecimalCount
        {
            get { return 0; }
        }

        /// <summary>
        /// Tests whether the specified field length is 10, the only valid length for this type.
        /// </summary>
        /// <param name="length">The field length, in characters, to test.</param>
        /// <returns>True if length is 10.</returns>
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
        /// Tests whether the specified value is a string.
        /// </summary>
        /// <param name="data">The value to validate.</param>
        /// <param name="result">
        /// If data is a string, <see cref="string.Empty"/> (memo content is not stored in the
        /// fixed-width field itself; this implementation does not write to the .dbt memo file).
        /// If data is not a string, a message describing why it's invalid.
        /// </param>
        /// <returns>True if data is a string; otherwise, false.</returns>
        //TODO: #9 — memo content is discarded here rather than written to a .dbt file; no .dbt read/write support exists yet
        public override bool IsValidData(object data, out string result)
        {
            if (!(data is string))
            {
                result = "Invalid data type";
                return false;
            }

            result = String.Empty;
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
