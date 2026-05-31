/***********************************************************************************
    StarThrower Utilities / Gis.GeoUtilities
    Copyright (C) 2005-2026  Stephen Elmer

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
using StarThrower.StringUtilities;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// Used for definition of Ellipsoids which are not part of the StarThrower Utilities.  All instances of UserDefined
    /// Ellipsoids must also have the Name field filled in as the Ellipsoid's name will be used to distinguish between
    /// multiple user defined ellipsoids.
    /// </summary>
    public class UserDefined : Ellipsoid
    {
        #region Private Instance Variables

        private string _name; //this is important when _ellipsoidType == EllipsoidType.UserDefined as it can be used to distinguish between multiple instances of user defined ellipsoids.
                              //in all other cases, the _name filed should be initialized to _ellipsoidType.ToString().

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets the unique name of this UserDefined Ellipsoid.
        /// </summary>
        public override string Name
        {
            get { return _name; }
        }

        #endregion


        #region Construction

        internal UserDefined(string name, double paramOne, double paramTwo, EllipsoidParamOrder paramOrder)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (!StringUtil.IsValid(name, ValidNamePattern)) throw new Exceptions.InvalidEllipsoidTypeException("Invalid format for ellipsoid name.");

            _name = name;

            switch (paramOrder)
            {
                case EllipsoidParamOrder.EquatorialRadiusPolarRadius:
                    if (paramOne == 0) throw new ArgumentException("EquatorialRadius cannot be zero for paramOrder " + paramOrder.ToString() + " in Ellipsoid constructor.  This would cause a divide by zero exception.");
                    this.EquatorialRadius = paramOne;
                    this.PolarRadius = paramTwo;
                    this.Flattening = (this.EquatorialRadius - this.PolarRadius) / this.EquatorialRadius;
                    break;
                case EllipsoidParamOrder.EquatorialRadiusFlattening:
                    this.EquatorialRadius = paramOne;
                    this.Flattening = paramTwo;
                    this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
                    break;
                case EllipsoidParamOrder.PolarRadiusFlattening:
                    if (paramOne == 1) throw new ArgumentException("PolarRadius cannot be zero for paramOrder " + paramOrder.ToString() + " in Ellipsoid constructor.  This would cause a divide by zero exception.");
                    this.PolarRadius = paramOne;
                    this.Flattening = paramTwo;
                    this.EquatorialRadius = this.Flattening / ((1 - this.PolarRadius) / 1);
                    break;
                default:
                    throw new ArgumentException("Invalid EllipsoidParamOrder specified in Ellipsoid constructor.");
            }
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Gets an XML representation of the Ellipsoid.
        /// </summary>
        /// <returns>The xml representation of the ellipsoid.</returns>
        public override string ToXml()
        {
            return "<ellipsoid ellipsoidType=\"" + this.GetType().Name + "\" name=\"" + _name + "\" equatorialRadius=\"" + this.EquatorialRadius.ToString(CultureInfo.InvariantCulture) + "\" polarRadius=\"" + this.PolarRadius.ToString(CultureInfo.InvariantCulture) + "\" flattening=\"" + this.Flattening.ToString(CultureInfo.InvariantCulture) + "\"/>\n";
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
            if (!(obj.GetType().Equals(this.GetType()))) return false;
            UserDefined other = (UserDefined)obj;
            return this.EquatorialRadius.Equals(other.EquatorialRadius) &&
                   this.PolarRadius.Equals(other.PolarRadius) &&
                   this.Flattening.Equals(other.Flattening) &&
                   _name.Equals(other._name);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current Ellipsoid.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + this.EquatorialRadius.GetHashCode();
            result = 31 * result + this.PolarRadius.GetHashCode();
            result = 31 * result + this.Flattening.GetHashCode();
            result = 31 * result + _name.GetHashCode();
            return result;
        }

        /// <summary>
        /// Returns the string representation of this Ellipsoid.
        /// </summary>
        /// <returns>A string describing this object.</returns>
        /// <remarks>
        /// Returns a string formatted as "[{type}:  {name}={value}[,{name}={value}]]"
        /// </remarks>
        public override string ToString()
        {
            return "[" + this.GetType().Name + ":  Name='" + _name + "', EquatorialRadius=" + this.EquatorialRadius.ToString(CultureInfo.InvariantCulture) + ", PolarRadius=" + this.PolarRadius.ToString(CultureInfo.InvariantCulture) + ", Flattening=" + this.Flattening.ToString(CultureInfo.InvariantCulture) + "]";
        }

        #endregion
    }
}


