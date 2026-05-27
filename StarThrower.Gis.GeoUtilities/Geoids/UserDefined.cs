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

namespace StarThrower.Gis.GeoUtilities.Geoids
{
    /// <summary>
    /// Used for definition of Geoids which are not part of the StarThrower Utilities.  All instances of UserDefined
    /// Geoids must also have the Name field filled in as the Geoid's name will be used to distinguish between
    /// multiple user defined geoids.
    /// </summary>
    public class UserDefined : Geoid
    {
        #region Private Instance Variables

        private string _name; //this is important when _geoidType == GeoidType.UserDefined as it can be used to distinguish between multiple instances of user defined geoids.
                              //in all other cases, the _name filed should be initialized to _geoidType.ToString().

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets the unique name of this UserDefined Geoid.
        /// </summary>
        public override string Name
        {
            get { return _name; }
        }

        #endregion


        #region Construction

        internal UserDefined(string name)
        {
            _name = name;
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Gets an XML representation of the Geoid.
        /// </summary>
        /// <returns>The xml representation of the geoid.</returns>
        public override string ToXml()
        {
            StringBuilder result = new StringBuilder(String.Empty);

            result.AppendLine("<geoid geoidType=\"" + this.GetType().Name + "\" name=\"" + _name + "\">");
            result.AppendLine("</geoid>");

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
            UserDefined other = (UserDefined)obj;
            return _name.Equals(other._name);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current Geoid.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + _name.GetHashCode();
            return result;
        }

        /// <summary>
        /// Returns the string representation of this Geoid.
        /// </summary>
        /// <returns>A string describing this object.</returns>
        /// <remarks>
        /// Returns a string formatted as "[{type}:  {name}={value}[,{name}={value}]]"
        /// </remarks>
        public override string ToString()
        {
            return "[" + this.GetType().Name + ":  Name='" + _name + "']";
        }

        #endregion
    }
}
