/***********************************************************************************
    StarThrower Utilities
    Copyright (C) 2005-2007  Steve Elmer

    This library is free software; you can redistribute it and/or
    modify it under the terms of the GNU Lesser General Public
    License as published by the Free Software Foundation; either
    version 2.1 of the License, or (at your option) any later version.

    This library is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
    Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public
    License along with this library; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
***********************************************************************************/

using System;
using System.Globalization;

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// Abstract base class for PrimeMeridian.
    /// </summary>
    public abstract class PrimeMeridian : IPrimeMeridian
    {
        #region Private Instance Variables

        /// <summary>
        /// The protected value is intended to be initialized by concrete implementations of this base class.
        /// </summary>
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
        /// Gets the Value of the PrimeMeridian
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
        /// <returns></returns>
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
