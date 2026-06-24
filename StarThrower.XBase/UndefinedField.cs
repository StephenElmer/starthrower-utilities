// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.XBase
{
    /// <summary>
    /// The placeholder field type used by a newly-constructed <see cref="XBaseField"/> before
    /// a concrete <see cref="FieldType"/> has been assigned. Rejects all data as invalid and
    /// translates every value to <see cref="string.Empty"/>.
    /// </summary>
    public class UndefinedField : FieldType
    {
        /// <summary>
        /// Initializes a new instance of the UndefinedField class.
        /// </summary>
        public UndefinedField()
            : base()
        {
            this.Text = "Undefined";
            this.Code = 'U';
        }


        /// <summary>
        /// Gets the minimum field length, in characters: 0.
        /// </summary>
        public override int MinLength
        {
            get { return 0; }
        }

        /// <summary>
        /// Gets the maximum field length, in characters: 253.
        /// </summary>
        public override int MaxLength
        {
            get { return 253; }
        }

        /// <summary>
        /// Gets the minimum decimal count: 0.
        /// </summary>
        public override int MinDecimalCount
        {
            get { return 0; }
        }

        /// <summary>
        /// Gets the maximum decimal count: 20.
        /// </summary>
        public override int MaxDecimalCount
        {
            get { return 20; }
        }

        /// <summary>
        /// Tests whether the specified field length is within the range 0-253.
        /// </summary>
        /// <param name="length">The field length, in characters, to test.</param>
        /// <returns>True if length is between <see cref="MinLength"/> and <see cref="MaxLength"/>, inclusive.</returns>
        public override bool IsValidLength(int length)
        {
            return (length >= MinLength && length <= MaxLength);
        }

        /// <summary>
        /// Tests whether the specified decimal count is within the range 0-20.
        /// </summary>
        /// <param name="decimalCount">The decimal count to test.</param>
        /// <returns>True if decimalCount is between <see cref="MinDecimalCount"/> and <see cref="MaxDecimalCount"/>, inclusive.</returns>
        public override bool IsValidDecimalCount(int decimalCount)
        {
            return (decimalCount >= MinDecimalCount && decimalCount <= MaxDecimalCount);
        }

        /// <summary>
        /// Always reports the given data as invalid, since the field type has not yet been defined.
        /// </summary>
        /// <param name="data">The value that would be validated, if this type supported any data.</param>
        /// <param name="result">Always set to "Invalid Data Type".</param>
        /// <returns>Always false.</returns>
        public override bool IsValidData(object data, out string result)
        {
            result = "Invalid Data Type";
            return false;
        }

        /// <summary>
        /// Always returns <see cref="string.Empty"/>, since the field type has not yet been defined.
        /// </summary>
        /// <param name="data">Ignored.</param>
        /// <returns><see cref="string.Empty"/>.</returns>
        public override object Translate(string data)
        {
            return String.Empty;
        }

    }
}
