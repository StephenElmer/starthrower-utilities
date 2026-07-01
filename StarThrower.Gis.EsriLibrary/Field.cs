// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Globalization;

namespace StarThrower.Gis.EsriLibrary
{
    /// <summary>
    /// Represents the name, data type, and storage characteristics of a single field (column)
    /// in a <see cref="ShapeFile"/>'s attribute table.
    /// </summary>
    public class Field : ICloneable
    {
        #region Private Member Variables

        private string _name = "";
        private StarThrower.Gis.EsriLibrary.Types.FieldType? _type;
        private int _length;
        private int _decimalCount;

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets or sets the field name.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Gets or sets the data type of the field.
        /// </summary>
        public StarThrower.Gis.EsriLibrary.Types.FieldType? Type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// Gets or sets the storage length of the field, in bytes.
        /// </summary>
        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }

        /// <summary>
        /// Gets or sets the number of decimal places stored for numeric field types.
        /// </summary>
        public int DecimalCount
        {
            get { return _decimalCount; }
            set { _decimalCount = value; }
        }

        #endregion


        #region Construction

        /// <summary>
        /// Initializes a new, empty <see cref="Field"/> instance.
        /// </summary>
        public Field() { }

        /// <summary>
        /// Initializes a new <see cref="Field"/> instance by copying the values of an existing field.
        /// </summary>
        /// <param name="other">The field whose values are copied.</param>
        public Field(StarThrower.Gis.EsriLibrary.Field other)
            : this()
        {
            this.ItemCopy(other);
        }

        #endregion


        #region ICloneable Members

        /// <summary>
        /// Creates a new <see cref="Field"/> instance with the same values as this one.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public object Clone()
        {
            return new StarThrower.Gis.EsriLibrary.Field(this);
        }

        #endregion


        #region IItemCopyable Members

        /// <summary>
        /// Copies the <see cref="Name"/>, <see cref="Type"/>, <see cref="Length"/>, and
        /// <see cref="DecimalCount"/> values from another <see cref="Field"/> instance into this one.
        /// </summary>
        /// <param name="value">The <see cref="Field"/> instance to copy values from.</param>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not a <see cref="Field"/>.</exception>
        public void ItemCopy(object value)
        {
            try
            {
                if (!(value is StarThrower.Gis.EsriLibrary.Field)) throw new ArgumentException("Could not cast " + value.GetType().ToString() + " to " + this.GetType().ToString());
                StarThrower.Gis.EsriLibrary.Field other = (StarThrower.Gis.EsriLibrary.Field)value;
                this.Name = other.Name;
                this.Type = other.Type;
                this.Length = other.Length;
                this.DecimalCount = other.DecimalCount;
            }
            catch
            {
                throw;
            }
        }

        #endregion


        #region Object Overrides

        /// <summary>
        /// Determines whether the specified object is a <see cref="Field"/> with the same
        /// <see cref="Name"/>, <see cref="Type"/>, <see cref="Length"/>, and
        /// <see cref="DecimalCount"/> values as this instance.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns><see langword="true"/> if the objects are equivalent; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (!(obj is StarThrower.Gis.EsriLibrary.Field)) return false;
            StarThrower.Gis.EsriLibrary.Field other = (StarThrower.Gis.EsriLibrary.Field)obj;
            return _name.Equals(other.Name, StringComparison.Ordinal) &&
                   object.Equals(_type, other.Type) &&
                   _length.Equals(other.Length) &&
                   _decimalCount.Equals(other.DecimalCount);
        }

        /// <summary>
        /// Returns a hash code based on the <see cref="Name"/>, <see cref="Type"/>,
        /// <see cref="Length"/>, and <see cref="DecimalCount"/> values of this instance.
        /// </summary>
        /// <returns>A hash code for this instance.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + _name.GetHashCode();
            result = 31 * result + (_type?.GetHashCode() ?? 0);
            result = 31 * result + _length.GetHashCode();
            result = 31 * result + _decimalCount.GetHashCode();
            return result;
        }

        /// <summary>
        /// Returns a string representation of this field, including its name, type, length,
        /// and decimal count.
        /// </summary>
        /// <returns>A string that represents the current field.</returns>
        public override string ToString()
        {
            return "[" + this.GetType().Name + ":  Name='" + _name + "', Type=" + (_type?.ToString() ?? "null") + ", Length=" + _length.ToString(CultureInfo.InvariantCulture) + ", DecimalCount=" + _decimalCount.ToString(CultureInfo.InvariantCulture) + "]";
        }

        #endregion
    }
}
