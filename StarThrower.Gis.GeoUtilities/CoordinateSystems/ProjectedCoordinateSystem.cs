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

namespace StarThrower.Gis.GeoUtilities.CoordinateSystems
{
    public abstract class ProjectedCoordinateSystem : IProjectedCoordinateSystem
    {
        /// <summary>
        /// The regular expression pattern to which the ProjectedCoordinateSystem's Name field must match.
        /// </summary>
        public const string ValidNamePattern = @"^[a-zA-Z_0-9]+$";


        #region Private Instance Variables

        private long _significantDigits;
        private IGeographicCoordinateSystem _geographicCoordinateSystem;
        private IProjection _projection;
        private ILinearUnit _linearUnit;

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets the SignificantDigits of the CoordinateSystem
        /// </summary>
        public long SignificantDigits
        {
            get { return _significantDigits; }
        }

        /// <summary>
        /// Gets the Datum of the ProjectedCoordinateSystem.
        /// </summary>
        /// <remarks>
        /// This is the equivalent of calling GeographicCoordinateSystem.Datum.
        /// </remarks>
        public IDatum Datum
        {
            get { return _geographicCoordinateSystem.Datum; }
        }

        /// <summary>
        /// Gets the PrimeMeridian of the ProjectedCoordinateSystem.
        /// </summary>
        /// <remarks>
        /// This is the equivalent of calling GeographicCoordinateSystem.PrimeMeridian.
        /// </remarks>
        public IPrimeMeridian PrimeMeridian
        {
            get { return _geographicCoordinateSystem.PrimeMeridian; }
        }

        /// <summary>
        /// Gets the AngularUnit of the ProjectedCoordinateSystem.
        /// </summary>
        /// <remarks>
        /// This is the equivalent of calling GeographicCoordinateSystem.AngularUnit.
        /// </remarks>
        public IAngularUnit AngularUnit
        {
            get { return _geographicCoordinateSystem.AngularUnit; }
        }

        /// <summary>
        /// Gets the GeographicCoordinateSystem of the ProjectedCoordinateSystem.
        /// </summary>
        public IGeographicCoordinateSystem GeographicCoordinateSystem
        {
            get { return _geographicCoordinateSystem; }
            protected set { _geographicCoordinateSystem = value; }
        }

        /// <summary>
        /// Gets the Projection of the ProjectedCoordinateSystem.
        /// </summary>
        public IProjection Projection
        {
            get { return _projection; }
            protected set { _projection = value; }
        }

        /// <summary>
        /// Gets the LinearUnit of the ProjectedCoordinateSystem.
        /// </summary>
        public ILinearUnit LinearUnit
        {
            get { return _linearUnit; }
            protected set { _linearUnit = value; }
        }

        /// <summary>
        /// Gets the value of the ProjectionParameter specified by parameterName
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public double this[string parameterName]
        {
            get
            {
                return _projection[parameterName];
            }
        }

        public virtual string Name
        {
            get { return this.GetType().Name; }
        }

        public virtual string Key
        {
            get
            {
                if (this is StarThrower.Gis.GeoUtilities.CoordinateSystems.Projected.UserDefined)
                {
                    return this.GetType().Name + this.Name;
                }
                else
                {
                    return this.GetType().Name;
                }
            }
        }

        public virtual HeightType HeightType 
        {
            get { return HeightType.NoHeight; } 
        }

        #endregion


        #region Construction

        protected ProjectedCoordinateSystem()
        {
            _significantDigits = 2; // 2 significant digits gets to Centimeters
        }

        #endregion


        #region Public Methods

        public abstract ITranslationResult ToGeodetic(double xLon, double yLat, double zAlt);

        public abstract ITranslationResult FromGeodetic(double xLon, double yLat, double zAlt);

        /// <summary>
        /// Gets the XML representation of the ProjectedCoordinateSystem
        /// </summary>
        /// <returns></returns>
        public virtual string ToXml()
        {
            StringBuilder result = new StringBuilder(String.Empty);

            result.Append("<projectedCoordinateSystem projectedCoordinateSystemType=\"" + this.GetType().Name + "\">\n");
            result.Append(_geographicCoordinateSystem.ToXml());
            result.Append(_projection.ToXml());
            result.Append(_linearUnit.ToXml());
            result.Append("</projectedCoordinateSystem>\n");

            return result.ToString();
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
            if (!(obj.GetType().Equals(this.GetType()))) return false;
            ProjectedCoordinateSystem other = (ProjectedCoordinateSystem)obj;
            return _geographicCoordinateSystem.Equals(other._geographicCoordinateSystem) &&
                   _projection.Equals(other._projection) &&
                   _linearUnit.Equals(other._linearUnit);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current ProjectedCoordinateSystem.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + _geographicCoordinateSystem.GetHashCode();
            result = 31 * result + _projection.GetHashCode();
            result = 31 * result + _linearUnit.GetHashCode();
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
            return "[" + this.GetType().Name + ":  GeographicCoordinateSystem=" + _geographicCoordinateSystem.GetType().Name + ", Projection=" + _projection.GetType().Name + ", LinearUnit=" + _linearUnit.GetType().Name + "]";
        }

        #endregion
    }
}
