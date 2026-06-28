// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text;

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// A single named parameter (e.g. "False_Easting", "Central_Meridian") used to configure an <see cref="IProjection"/>.
    /// </summary>
    public class ProjectionParameter
    {
        #region Private Member Variables

        private string _name;
        private double _value;

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets the Name of the ProjectionParameter
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Gets the Value of the ProjectionParameter
        /// </summary>
        public double Value
        {
            get { return _value; }
        }

        #endregion


        #region Construction

        /// <summary>
        /// Initializes a new, undefined projection parameter with a value of 0.0.
        /// </summary>
        public ProjectionParameter() : this("Undefined", 0.0) { }

        /// <summary>
        /// Initializes a new projection parameter with the specified name and value.
        /// </summary>
        /// <param name="name">The name of the parameter (e.g. "False_Easting").</param>
        /// <param name="value">The value of the parameter.</param>
        public ProjectionParameter(string name, double value)
        {
            _name = name;
            _value = value;
        }

        #endregion


        #region Object Overrides

        /// <summary>
        /// Tests whether the given object is equal to this object.
        /// </summary>
        /// <param name="obj">The object to compare to this object.</param>
        /// <returns>true if obj is a ProjectionParameter with the same Name and Value as this object; otherwise, false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (!(obj is ProjectionParameter)) return false;
            ProjectionParameter other = (ProjectionParameter)obj;
            return _name.Equals(other.Name, StringComparison.Ordinal) &&
                   _value.Equals(other.Value);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current ProjectionParameter.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + _name.GetHashCode();
            result = 31 * result + _value.GetHashCode();
            return result;
        }

        /// <summary>
        /// Returns the string representation of this ProjectionParameter.
        /// </summary>
        /// <returns>A string describing this object.</returns>
        public override string ToString()
        {
            return "[" + this.GetType().Name + ":  Name='" + _name + "', Value=" + _value.ToString(CultureInfo.InvariantCulture) + "]";
        }

        #endregion
    }
}


