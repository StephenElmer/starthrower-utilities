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
using System.Text;
using StarThrower.StringUtilities;

namespace StarThrower.Gis.GeoUtilities.CoordinateSystems.Geographic
{
    /// <summary>
    /// Provides the ability to create user defined Geographic Coordinate Systems.
    /// </summary>
    public class UserDefined : GeographicCoordinateSystem
    {
        #region Private Instance Variables

        private string _name;

        #endregion


        #region Public Properties

        public override string Name
        {
            get { return _name; }
        }

        #endregion


        #region Construction

        internal UserDefined(string name, IDatum datum, IPrimeMeridian primeMeridian, IAngularUnit angularUnit) : base()
        {
            if (name == null) throw new ArgumentNullException("name");
            if (!StringUtil.IsValid(name, ValidNamePattern)) throw new Exceptions.InvalidCoordinateSystemException("Invalid format for coordinate system name.");

            _name = name;

            this.Datum = datum;
            this.PrimeMeridian = primeMeridian;
            this.AngularUnit = angularUnit;
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Gets an XML representation of the GeographicCoordinateSystem.
        /// </summary>
        /// <returns>The xml representation of the GeographicCoordinateSystem.</returns>
        public override string ToXml()
        {
            StringBuilder result = new StringBuilder(String.Empty);

            result.Append("<geographicCoordinateSystem geographicCoordinateSystemType=\"" + this.GetType().Name + "\" name=\"" + _name + "\">\n");
            result.Append(this.Datum.ToXml());
            result.Append(this.PrimeMeridian.ToXml());
            result.Append(this.AngularUnit.ToXml());
            result.Append("</geographicCoordinateSystem>\n");

            return result.ToString();
        }

        /// <summary>
        /// Translates the specified coordinates from the UserDefined system to GCS WGS84 coordinates
        /// </summary>
        /// <param name="xLon">xLon value in the UserDefined system coordinates.</param>
        /// <param name="yLat">yLat value in the UserDefined system coordinates</param>
        /// <param name="zAlt">Altitude value in the UserDefined system coordinates</param>
        /// <returns>A GenericResult implementation of the ITranslationResult, containing GCS WGS84 coordinates.</returns>
        public override ITranslationResult ToGeodetic(double xLon, double yLat, double zAlt)
        {
            //TODO: implement this translation
            double resultLon = xLon;
            double resultLat = yLat;
            double resultAlt = zAlt;
            return new Translations.GenericResult(resultLon, resultLat, resultAlt);
        }

        /// <summary>
        /// Translates the specified coordinates from GCS WGS84 coordinates to the UserDefined system.
        /// </summary>
        /// <param name="xLon">xLon value in GCS WGS84 coordinates.</param>
        /// <param name="yLat">yLat value in GCS WGS84 coordinates</param>
        /// <param name="zAlt">Altitude value in GCS WGS84 coordinates</param>
        /// <returns>A GenericResult implementation of the ITranslationResult, containing the UserDefined system coordinates.</returns>
        public override ITranslationResult FromGeodetic(double xLon, double yLat, double zAlt)
        {
            //TODO: implement this translation
            double resultLon = xLon;
            double resultLat = yLat;
            double resultAlt = zAlt;
            return new Translations.GenericResult(resultLon, resultLat, resultAlt);
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
            return this.Datum.Equals(other.Datum) &&
                   this.PrimeMeridian.Equals(other.PrimeMeridian) &&
                   this.AngularUnit.Equals(other.AngularUnit) &&
                   _name.Equals(other._name);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current Datum.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + this.Datum.GetHashCode();
            result = 31 * result + this.PrimeMeridian.GetHashCode();
            result = 31 * result + this.AngularUnit.GetHashCode();
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
            return "[" + this.GetType().Name + ":  Name='" + _name + "', Datum=" + this.Datum.GetType().Name + ", PrimeMeridian=" + this.PrimeMeridian.GetType().Name + "]";
        }

        #endregion
    }
}
