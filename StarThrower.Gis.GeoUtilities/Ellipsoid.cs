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
using StarThrower.Gis.GeoUtilities.Ellipsoids;

namespace StarThrower.Gis.GeoUtilities
{
    public abstract class Ellipsoid : IEllipsoid
    {
        /// <summary>
        /// The regular expression pattern to which the Ellipsoid's Name field must match.
        /// </summary>
        public const string ValidNamePattern = @"^[a-zA-Z_0-9]+$";


        #region Private Instance Variables

        private double _equatorialRadius; //aka Semi-Major Axis
        private double _polarRadius; //aka Semi-Minor Axis
        private double _flattening; //TODO: or should this be inverseFlattening  (1/flattening) ???

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets the name of the Ellipsoid.
        /// This is really only necessary if EllipsoidType == ElipsoidType.UserDefined
        /// as it is intended to distinguish one UserDefined Ellipsoid from another.
        /// </summary>
        public virtual string Name
        {
            get { return this.GetType().Name; }
        }

        /// <summary>
        /// Gets the key value of the Ellipsoid.
        /// If EllipsoidType == EllipsoidType.UserDefined, the Key will be the EllipsoidType,
        /// otherwise, it will be the EllipsoidType + Name so that UserDefined ellipsoids
        /// may be distinguished from one another.
        /// </summary>
        public string Key
        {
            get
            {
                if (this is UserDefined)
                {
                    return this.GetType().Name + this.Name;
                }
                else
                {
                    return this.GetType().Name;
                }
            }
        }

        /// <summary>
        /// Gets the EquatorialRadius of the Ellipsoid<br/>
        /// aka Semi-Major Axis<br/>
        /// (a)
        /// </summary>
        public double EquatorialRadius
        {
            get { return _equatorialRadius; }
            protected set { _equatorialRadius = value; }
        }

        /// <summary>
        /// Gets the PolarRadius of the Ellipsoid<br/>
        /// aka Semi-Minor Axis<br/>
        /// (b)
        /// </summary>
        public double PolarRadius
        {
            get { return _polarRadius; }
            protected set { _polarRadius = value; }
        }

        /// <summary>
        /// Gets the Flattening of the Ellipsoid<br/>
        /// (f)
        /// </summary>
        public double Flattening
        {
            get { return _flattening; }
            protected set { _flattening = value; }
        }

        /// <summary>
        /// Gets the InverseFlattening of the Ellipsoid<br/>
        /// A calculated value: (1 / Flattening)<br/>
        /// (1/f)
        /// </summary>
        public double InverseFlattening
        {
            get { return 1 / _flattening; }
        }

        /// <summary>
        /// Gets the FirstEccentricitySquared of the Ellipsoid<br/>
        /// A calculated value ((2 * Flattening) - (Flattening * Flattening))<br/>
        /// (e2 or es)
        /// </summary>
        public double FirstEccentricitySquared
        {
            get
            {
                return (2 * _flattening) - (_flattening * _flattening);
            }
        }

        /// <summary>
        /// Gets the First Eccentricity of the Ellipsoid<br/>
        /// A calculated value (Math.Sqrt((2 * Flattening) - (Flattening * Flattening)))<br/>
        /// e
        /// </summary>
        public double FirstEccentricity
        {
            get
            {
                return Math.Sqrt(this.FirstEccentricitySquared);
            }
        }

        /// <summary>
        /// Gets the SecondEccentricitySquared of the Ellipsoid<br/>
        /// A calculated value ((1 / (1 - FirstEccentricitySquared)) - 1)<br/>
        /// (ep2)
        /// </summary>
        public double SecondEccentricitySquared
        {
            get { return (1 / (1 - this.FirstEccentricitySquared)) - 1; }
        }


        #endregion


        #region Public Methods

        /// <summary>
        /// Gets an XML representation of the Ellipsoid.
        /// </summary>
        /// <returns>The xml representation of the ellipsoid.</returns>
        public virtual string ToXml()
        {
            return "<ellipsoid ellipsoidType=\"" + this.GetType().Name + "\" equatorialRadius=\"" + _equatorialRadius.ToString(CultureInfo.InvariantCulture) + "\" polarRadius=\"" + _polarRadius.ToString(CultureInfo.InvariantCulture) + "\" flattening=\"" + _flattening.ToString(CultureInfo.InvariantCulture) + "\"/>\n";
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
            Ellipsoid other = (Ellipsoid)obj;
            return _equatorialRadius.Equals(other._equatorialRadius) &&
                   _polarRadius.Equals(other._polarRadius) &&
                   _flattening.Equals(other._flattening);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current Ellipsoid.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + _equatorialRadius.GetHashCode();
            result = 31 * result + _polarRadius.GetHashCode();
            result = 31 * result + _flattening.GetHashCode();
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
            return "[" + this.GetType().Name + ":  EquatorialRadius=" + _equatorialRadius.ToString(CultureInfo.InvariantCulture) + ", PolarRadius=" + _polarRadius.ToString(CultureInfo.InvariantCulture) + ", Flattening=" + _flattening.ToString(CultureInfo.InvariantCulture) + "]";
        }

        #endregion
    }
}


