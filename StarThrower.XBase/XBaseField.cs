using System;
using System.Globalization;

namespace StarThrower.XBase
{
    public class XBaseField
    {
        #region Private Member Variables

        private string _name = String.Empty;
        private FieldType _fieldType = new UndefinedField();
        private int _length;
        private int _decimalCount;

        #endregion


        #region Public Properties

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public FieldType FieldType
        {
            get { return _fieldType; }
            set
            {
                if (value == null) throw new ArgumentNullException("value");

                _fieldType = value;
                _fieldType.Owner = this; //asign this object as the owner of _type so that _type can perform validation
            }
        }

        public int Length
        {
            get { return _length; }
            set
            {
                if (!_fieldType.IsValidLength(value)) throw new InvalidFieldLengthException();
                _length = value;
            }
        }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#")]
        public bool IsValidData(object data, out string result)
        {
            return _fieldType.IsValidData(data, out result);
        }

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
        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(obj, null)) return false;
            if (Object.ReferenceEquals(obj, this)) return true;
            if (!(obj is StarThrower.XBase.XBaseField)) return false;
            StarThrower.XBase.XBaseField other = (StarThrower.XBase.XBaseField)obj;
            return _name.Equals(other.Name) &&
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
            return _name.Equals(other.Name) &&
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
