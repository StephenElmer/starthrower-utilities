// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Globalization;

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// The abstract base class for implementations of the <see cref="IPrimeMeridian"/> interface,
    /// representing a reference meridian (e.g. Greenwich, Paris) and its longitude offset from Greenwich.
    /// </summary>
    public abstract class PrimeMeridian : IPrimeMeridian
    {
        #region Private Instance Variables

        // Set via the protected Value setter by concrete implementations' constructors.
        private double _value;

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets the Name of the PrimeMeridian
        /// </summary>
        public virtual string Name
        {
            get { return this.GetType().Name; }
        }

        /// <summary>
        /// Gets the longitude of this prime meridian relative to Greenwich, in decimal degrees
        /// (e.g. 2.337229166666667 for <see cref="PrimeMeridians.Paris"/>).
        /// </summary>
        public double Value
        {
            get { return _value; }
            protected set { _value = value; }
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Gets the XML representation of the PrimeMeridian
        /// </summary>
        /// <returns>An XML formatted string.</returns>
        public string ToXml()
        {
            return "<primeMeridian name=\"" + this.GetType().Name + "\" value=\"" + _value.ToString(CultureInfo.InvariantCulture) + "\"/>\n";
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
            PrimeMeridian other = (PrimeMeridian)obj;
            return _value.Equals(other._value);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current PrimeMeridian.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + this.GetType().Name.GetHashCode();
            result = 31 * result + _value.GetHashCode();
            return result;
        }

        /// <summary>
        /// Returns the string representation of this PrimeMeridian.
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


