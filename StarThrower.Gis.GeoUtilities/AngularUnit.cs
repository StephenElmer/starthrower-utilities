// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Globalization;

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// The abstract base class for implementations of the <see cref="IAngularUnit"/> interface,
    /// representing a unit of angular measure (e.g. degree, grad) and its conversion factor to radians.
    /// </summary>
    public abstract class AngularUnit : IAngularUnit
    {
        #region Private Instance Variables

        // Set via the protected Value setter by concrete implementations' constructors.
        private double _value;

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets the Name of the AngularUnit
        /// </summary>
        public virtual string Name
        {
            get { return this.GetType().Name; }
        }

        /// <summary>
        /// Gets the number of radians represented by one of this unit (e.g. ~0.01745 for <see cref="AngularUnits.Degree"/>).
        /// </summary>
        public double Value
        {
            get { return _value; }
            protected set { _value = value; }
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Gets the XML representation of the AngularUnit
        /// </summary>
        /// <returns>An XML formatted string.</returns>
        public string ToXml()
        {
            return "<angularUnit name=\"" + this.GetType().Name + "\" value=\"" + _value.ToString(CultureInfo.InvariantCulture) + "\"/>\n";
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
            if (obj == null) return false;
            if (obj == this) return true;
            if (!(obj.GetType().Equals(this.GetType()))) return false;
            AngularUnit other = (AngularUnit)obj;
            return _value.Equals(other._value);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current AngularUnit.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + this.GetType().Name.GetHashCode();
            result = 31 * result + _value.GetHashCode();
            return result;
        }

        /// <summary>
        /// Returns the string representation of this AngularUnit.
        /// </summary>
        /// <returns>A string describing this object.</returns>
        /// <remarks>
        /// Returns a string formatted as "[{type}:  {name}={value}[,{name}={value}]]"
        /// </remarks>
        public override string ToString()
        {
            return "[" + this.GetType().Name + ":  Value=" + this.Value.ToString(CultureInfo.InvariantCulture) + "]";
        }

        #endregion
    }
}


