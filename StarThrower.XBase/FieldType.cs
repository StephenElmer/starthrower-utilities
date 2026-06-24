// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.XBase
{
    /// <summary>
    /// Base class for an XBase (.dbf) field data type (e.g. Character, Numeric, Date, Logical,
    /// Memo, Float). A concrete subclass defines the allowed length and decimal-count range for
    /// the type, and converts between the in-memory .NET representation of field data and the
    /// fixed-width text representation stored in a .dbf file.
    /// </summary>
    public abstract class FieldType
    {
        #region Private Instance Variables

        private XBaseField? _owner;
        private string _text = "Undefined";
        private char _code = 'U';

        #endregion


        #region IFieldType Members

        /// <summary>
        /// Gets the display name of this field type (e.g. "String", "Numeric", "Date").
        /// </summary>
        public string Text
        {
            get { return _text; }
            protected set { _text = value; }
        }

        /// <summary>
        /// Gets the single-character XBase type code for this field type (e.g. 'C', 'N', 'D', 'L', 'M', 'F').
        /// </summary>
        public char Code
        {
            get { return _code; }
            protected set { _code = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="XBaseField"/> that this field type instance belongs to.
        /// Set automatically when this field type is assigned to an <see cref="XBaseField"/>'s
        /// <see cref="XBaseField.FieldType"/> property. Some subclasses override the setter to
        /// also force the owning field's <see cref="XBaseField.Length"/> and
        /// <see cref="XBaseField.DecimalCount"/> to fixed values required by the type (e.g. a
        /// Date field is always 8 characters long).
        /// </summary>
        public virtual XBaseField? Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        /// <summary>
        /// Tests whether the specified field length is valid for this field type.
        /// </summary>
        /// <param name="length">The field length, in characters, to test.</param>
        /// <returns>True if length is within this field type's allowed range.</returns>
        public abstract bool IsValidLength(int length);

        /// <summary>
        /// Tests whether the specified decimal count is valid for this field type.
        /// </summary>
        /// <param name="decimalCount">The decimal count to test.</param>
        /// <returns>True if decimalCount is within this field type's allowed range.</returns>
        public abstract bool IsValidDecimalCount(int decimalCount);

        /// <summary>
        /// Tests whether the specified in-memory value is valid for this field type and, if so,
        /// converts it to its fixed-width text representation for storage in a .dbf record.
        /// </summary>
        /// <param name="data">The in-memory value to validate and convert.</param>
        /// <param name="result">
        /// If data is valid, the fixed-width text representation of data, padded to this field's
        /// length. If data is not valid, a message describing why.
        /// </param>
        /// <returns>True if data is valid for this field type; otherwise, false.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#")]
        public abstract bool IsValidData(object data, out string result);

        /// <summary>
        /// Converts the fixed-width text representation of a field's data, as stored in a .dbf
        /// record, into its corresponding in-memory .NET value.
        /// </summary>
        /// <param name="data">The fixed-width text representation to convert.</param>
        /// <returns>The in-memory value represented by data.</returns>
        public abstract object Translate(string data);

        /// <summary>
        /// Gets the maximum field length, in characters, allowed for this field type.
        /// </summary>
        public abstract int MaxLength { get; }

        /// <summary>
        /// Gets the minimum field length, in characters, allowed for this field type.
        /// </summary>
        public abstract int MinLength { get; }

        /// <summary>
        /// Gets the maximum decimal count allowed for this field type.
        /// </summary>
        public abstract int MaxDecimalCount { get; }

        /// <summary>
        /// Gets the minimum decimal count allowed for this field type.
        /// </summary>
        public abstract int MinDecimalCount { get; }

        #endregion
    }
}
