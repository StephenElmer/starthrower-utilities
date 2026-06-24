// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Globalization;

namespace StarThrower.XBase
{
    /// <summary>
    /// Describes a single field (column) in an XBase (.dbf) file: its name, data type, length,
    /// and decimal count.
    /// </summary>
    public class XBaseField
    {
        #region Private Member Variables

        private string _name = String.Empty;
        private FieldType _fieldType = new UndefinedField();
        private int _length;
        private int _decimalCount;

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets or sets the name of this field.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Gets or sets the data type of this field. Setting this property assigns this field
        /// as the new value's <see cref="FieldType.Owner"/>; some field types (e.g. <see cref="DateField"/>,
        /// <see cref="BooleanField"/>) respond by forcing this field's <see cref="Length"/> and
        /// <see cref="DecimalCount"/> to the fixed values they require.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown on set if the value is null.</exception>
        public FieldType FieldType
        {
            get { return _fieldType; }
            set
            {
                ArgumentNullException.ThrowIfNull(value);

                _fieldType = value;
                _fieldType.Owner = this; //asign this object as the owner of _type so that _type can perform validation
            }
        }

        /// <summary>
        /// Gets or sets the length, in characters, of this field.
        /// </summary>
        /// <exception cref="InvalidFieldLengthException">Thrown on set if the value is not valid for this field's <see cref="FieldType"/>.</exception>
        public int Length
        {
            get { return _length; }
            set
            {
                if (!_fieldType.IsValidLength(value)) throw new InvalidFieldLengthException();
                _length = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of decimal places stored in this field.
        /// </summary>
        /// <exception cref="InvalidDecimalCountException">Thrown on set if the value is not valid for this field's <see cref="FieldType"/>.</exception>
        public int DecimalCount
        {
            get { return _decimalCount; }
            set
            {
                if (!_fieldType.IsValidDecimalCount(value)) throw new InvalidDecimalCountException();
                _decimalCount = value;
            }
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Tests whether the specified value is valid for this field's data type and, if so,
        /// converts it to its fixed-width text representation for storage in a .dbf record.
        /// </summary>
        /// <param name="data">The in-memory value to validate and convert.</param>
        /// <param name="result">If data is valid, its fixed-width text representation. If data is not valid, a message describing why.</param>
        /// <returns>True if data is valid for this field's data type; otherwise, false.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#")]
        public bool IsValidData(object data, out string result)
        {
            return _fieldType.IsValidData(data, out result);
        }

        /// <summary>
        /// Converts the fixed-width text representation of this field's data, as stored in a
        /// .dbf record, into its corresponding in-memory .NET value.
        /// </summary>
        /// <param name="data">The fixed-width text representation to convert.</param>
        /// <returns>The in-memory value represented by data.</returns>
        public object Translate(string data)
        {
            return _fieldType.Translate(data);
        }
        #endregion


        #region Object Overrides

        /// <summary>
        /// Tests whether the given object is equal to this object.
        /// </summary>
        /// <param name="obj">The object to compare to this object.</param>
        /// <returns>true if other is an instance of the same class as this object and has reference or value equality with this object; otherwise, false.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        public override bool Equals(object? obj)
        {
            if (Object.ReferenceEquals(obj, null)) return false;
            if (Object.ReferenceEquals(obj, this)) return true;
            if (!(obj is StarThrower.XBase.XBaseField)) return false;
            StarThrower.XBase.XBaseField other = (StarThrower.XBase.XBaseField)obj;
            return _name.Equals(other.Name, StringComparison.Ordinal) &&
                   _fieldType.Equals(other.FieldType) &&
                   _length.Equals(other.Length) &&
                   _decimalCount.Equals(other.DecimalCount);
        }

        /// <summary>
        /// Tests whether the given object is equal to this object.
        /// Optimized for instances of this class.
        /// </summary>
        /// <param name="other">The object to compare to this object.</param>
        /// <returns>true if other has reference or value equality with this object; otherwise, false.</returns>
        public bool Equals(StarThrower.XBase.XBaseField other)
        {
            if (Object.ReferenceEquals(other, null)) return false;
            if (Object.ReferenceEquals(other, this)) return true;
            return _name.Equals(other.Name, StringComparison.Ordinal) &&
                   _fieldType.Equals(other.FieldType) &&
                   _length.Equals(other.Length) &&
                   _decimalCount.Equals(other.DecimalCount);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + _name.GetHashCode();
            result = 31 * result + _fieldType.GetHashCode();
            result = 31 * result + _length.GetHashCode();
            result = 31 * result + _decimalCount.GetHashCode();
            return result;
        }

        /// <summary>
        /// Returns the string representation of this object.
        /// </summary>
        /// <returns>A string describing this object.</returns>
        /// <remarks>
        /// Returns a string formatted as "[{type}:  {name}={value}[,{name}={value}]]"
        /// </remarks>
        public override string ToString()
        {
            return "[" + this.GetType().Name + ":  Name='" + _name + "', Type=" + _fieldType.ToString() + ", Length=" + _length.ToString(CultureInfo.InvariantCulture) + ", DecimalCount=" + _decimalCount.ToString(CultureInfo.InvariantCulture) + "]";
        }

        #endregion
    }
}
