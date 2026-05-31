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
using System.Text;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// Used for definition of Datums which are not part of the StarThrower Utilities.  All instances of UserDefined
    /// Datums must also have the Name field filled in as the Datum's name will be used to distinguish between
    /// multiple user defined datums.
    /// </summary>
    public class UserDefined : Datum
    {
        #region Private Instance Variables

        private string _name; //this is important when _datumType == DatumType.UserDefined as it can be used to distinguish between multiple instances of user defined datums.
                              //in all other cases, the _name filed should be initialized to _datumType.ToString().

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets the unique name of this UserDefined Datum.
        /// </summary>
        public override string Name
        {
            get { return _name; }
        }

        public override bool IsSevenParamDatum
        {
            //TODO: Implement IsSevenParamDatum for UserDefined datum.
            get { return false; }
        }

        #endregion


        #region Construction

        internal UserDefined(string name, IEllipsoid ellipsoid, double deltaX, double sigmaX, double deltaY, double sigmaY, double deltaZ, double sigmaZ, double rotationX, double rotationY, double rotationZ, double rotationScaleFactor, double north, double south, double east, double west)
        {
            _name = name;
            this.Ellipsoid = ellipsoid;

            this.DeltaX = deltaX;
            this.SigmaX = sigmaX;
            this.DeltaY = deltaY;
            this.SigmaY = sigmaY;
            this.DeltaZ = deltaZ;
            this.SigmaZ = sigmaZ;
            this.RotationX = rotationX;
            this.RotationY = rotationY;
            this.RotationZ = rotationZ;
            this.RotationScaleFactor = rotationScaleFactor;
            this.Domain.Top = north;
            this.Domain.Bottom = south;
            this.Domain.Right = east;
            this.Domain.Left = west;
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Gets an XML representation of the Datum.
        /// </summary>
        /// <returns>The xml representation of the datum.</returns>
        public override string ToXml()
        {
            StringBuilder result = new StringBuilder(String.Empty);

            result.AppendLine("<datum datumType=\"" + this.GetType().Name + "\" name=\"" + _name + "\" deltaX=\"" + this.DeltaX.ToString(CultureInfo.InvariantCulture) + "\" sigmaX=\"" + this.SigmaX.ToString(CultureInfo.InvariantCulture) + "\" deltaY=\"" + this.DeltaY.ToString(CultureInfo.InvariantCulture) + "\" sigmaY=\"" + this.SigmaY.ToString(CultureInfo.InvariantCulture) + "\" deltaZ=\"" + this.DeltaZ.ToString(CultureInfo.InvariantCulture) + "\" sigmaZ=\"" + this.SigmaZ.ToString(CultureInfo.InvariantCulture) + "\" rotationX=\"" + this.RotationX.ToString(CultureInfo.InvariantCulture) + "\" rotationY=\"" + this.RotationY.ToString(CultureInfo.InvariantCulture) + "\" rotationZ=\"" + this.RotationZ.ToString(CultureInfo.InvariantCulture) + "\" rotationScaleFactor=\"" + this.RotationScaleFactor.ToString(CultureInfo.InvariantCulture) + "\" north=\"" + this.Domain.Top.ToString(CultureInfo.InvariantCulture) + "\" south=\"" + this.Domain.Bottom.ToString(CultureInfo.InvariantCulture) + "\" east=\"" + this.Domain.Right.ToString(CultureInfo.InvariantCulture) + "\" west=\"" + this.Domain.Left.ToString(CultureInfo.InvariantCulture) + "\">");
            result.Append(this.Ellipsoid.ToXml());
            result.AppendLine("</datum>");

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
        public override bool Equals(object? obj)
        {
            if (Object.ReferenceEquals(obj, null)) return false;
            if (Object.ReferenceEquals(obj, this)) return true;
            if (!(obj.GetType().Equals(this.GetType()))) return false;
            UserDefined other = (UserDefined)obj;
            return this.Ellipsoid.Equals(other.Ellipsoid) &&
                   this.DeltaX.Equals(other.DeltaX) &&
                   this.SigmaX.Equals(other.SigmaX) &&
                   this.DeltaY.Equals(other.DeltaY) &&
                   this.SigmaY.Equals(other.SigmaY) &&
                   this.DeltaZ.Equals(other.DeltaZ) &&
                   this.SigmaZ.Equals(other.SigmaZ) &&
                   this.RotationX.Equals(other.RotationX) &&
                   this.RotationY.Equals(other.RotationY) &&
                   this.RotationZ.Equals(other.RotationZ) &&
                   this.RotationScaleFactor.Equals(other.RotationScaleFactor) &&
                   this.Domain.Equals(other.Domain) &&
                   _name.Equals(other._name);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current Datum.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + this.Ellipsoid.GetHashCode();
            result = 31 * result + this.DeltaX.GetHashCode();
            result = 31 * result + this.SigmaX.GetHashCode();
            result = 31 * result + this.DeltaY.GetHashCode();
            result = 31 * result + this.SigmaY.GetHashCode();
            result = 31 * result + this.DeltaZ.GetHashCode();
            result = 31 * result + this.SigmaZ.GetHashCode();
            result = 31 * result + this.RotationX.GetHashCode();
            result = 31 * result + this.RotationY.GetHashCode();
            result = 31 * result + this.RotationZ.GetHashCode();
            result = 31 * result + this.RotationScaleFactor.GetHashCode();
            result = 31 * result + this.Domain.GetHashCode();
            result = 31 * result + _name.GetHashCode();
            return result;
        }

        /// <summary>
        /// Returns the string representation of this Datum.
        /// </summary>
        /// <returns>A string describing this object.</returns>
        /// <remarks>
        /// Returns a string formatted as "[{type}:  {name}={value}[,{name}={value}]]"
        /// </remarks>
        public override string ToString()
        {
            return "[" + this.GetType().Name + ":  Name='" + _name + "', Ellipsoid=" + this.Ellipsoid.GetType().Name + ", DeltaX=" + this.DeltaX.ToString(CultureInfo.InvariantCulture) + ", SigmaX=" + this.SigmaX.ToString(CultureInfo.InvariantCulture) + ", DeltaY=" + this.DeltaY.ToString(CultureInfo.InvariantCulture) + ", SigmaY=" + this.SigmaY.ToString(CultureInfo.InvariantCulture) + ", DeltaZ=" + this.DeltaZ.ToString(CultureInfo.InvariantCulture) + ", SigmaZ=" + this.SigmaZ.ToString(CultureInfo.InvariantCulture) + ", RotationX=" + this.RotationX.ToString(CultureInfo.InvariantCulture) + ", RotationY=" + this.RotationY.ToString(CultureInfo.InvariantCulture) + ", RotationZ=" + this.RotationZ.ToString(CultureInfo.InvariantCulture) + ", RotationScaleFactor=" + this.RotationScaleFactor.ToString(CultureInfo.InvariantCulture) + ", " + this.Domain.ToString() + "]";
        }

        #endregion
    }
}


