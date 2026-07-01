// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

namespace StarThrower.Gis.EsriLibrary.Types
{
    /// <summary>
    /// Represents the Esri/XBase Memo (type code 'M') field type, for variable-length text
    /// stored in an associated .dbt memo file. Delegates its validation and
    /// length/decimal-count constraints to <see cref="StarThrower.XBase.MemoField"/>.
    /// </summary>
    public class MemoField : StarThrower.Gis.EsriLibrary.Types.FieldType
    {
        #region Private Member Variables

        private StarThrower.XBase.MemoField _field = new StarThrower.XBase.MemoField();

        #endregion


        #region Construction

        /// <summary>
        /// Initializes a new <see cref="MemoField"/>, copying its type code and display name
        /// from the underlying <see cref="StarThrower.XBase.MemoField"/>.
        /// </summary>
        public MemoField()
        {
            this.Code = _field.Code;
            this.Text = _field.Text;
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Gets the minimum field length, in characters, allowed for a Memo field.
        /// </summary>
        public override int MinLength
        {
            get { return _field.MinLength; }
        }

        /// <summary>
        /// Gets the maximum field length, in characters, allowed for a Memo field.
        /// </summary>
        public override int MaxLength
        {
            get { return _field.MaxLength; }
        }

        /// <summary>
        /// Gets the minimum decimal count allowed for a Memo field.
        /// </summary>
        public override int MinDecimalCount
        {
            get { return _field.MinDecimalCount; }
        }

        /// <summary>
        /// Gets the maximum decimal count allowed for a Memo field.
        /// </summary>
        public override int MaxDecimalCount
        {
            get { return _field.MaxDecimalCount; }
        }

        /// <summary>
        /// Tests whether the specified field length is valid for a Memo field.
        /// </summary>
        /// <param name="length">The field length, in characters, to test.</param>
        /// <returns><see langword="true"/> if <paramref name="length"/> is within the allowed range; otherwise, <see langword="false"/>.</returns>
        public override bool IsValidLength(int length)
        {
            return _field.IsValidLength(length);
        }

        /// <summary>
        /// Tests whether the specified decimal count is valid for a Memo field.
        /// </summary>
        /// <param name="decimalCount">The decimal count to test.</param>
        /// <returns><see langword="true"/> if <paramref name="decimalCount"/> is within the allowed range; otherwise, <see langword="false"/>.</returns>
        public override bool IsValidDecimalCount(int decimalCount)
        {
            return _field.IsValidDecimalCount(decimalCount);
        }

        /// <summary>
        /// Tests whether the specified in-memory value is valid for a Memo field and, if so,
        /// converts it to its fixed-width text representation for storage in a .dbf record.
        /// </summary>
        /// <param name="data">The in-memory value to validate and convert.</param>
        /// <param name="result">
        /// If <paramref name="data"/> is valid, the fixed-width text representation of the
        /// value; otherwise, a message describing why it is not valid.
        /// </param>
        /// <returns><see langword="true"/> if <paramref name="data"/> is valid for this field type; otherwise, <see langword="false"/>.</returns>
        public override bool IsValidData(object data, out string result)
        {
            return _field.IsValidData(data, out result);
        }

        /// <summary>
        /// Converts the fixed-width text representation of a Memo field's data, as stored in
        /// a .dbf record, into its corresponding in-memory .NET value.
        /// </summary>
        /// <param name="data">The fixed-width text representation to convert.</param>
        /// <returns>The in-memory value represented by <paramref name="data"/>.</returns>
        public override object Translate(string data)
        {
            return _field.Translate(data);
        }

        #endregion
    }
}
