// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text;

namespace StarThrower.Gis.GeoUtilities
{
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

        public ProjectionParameter() : this("Undefined", 0.0) { }

        public ProjectionParameter(string name, double value)
        {
            _name = name;
            _value = value;
        }

        #endregion


        #region Object Overrides

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (!(obj is ProjectionParameter)) return false;
            ProjectionParameter other = (ProjectionParameter)obj;
            return _name.Equals(other.Name, StringComparison.Ordinal) &&
                   _value.Equals(other.Value);
        }

        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + _name.GetHashCode();
            result = 31 * result + _value.GetHashCode();
            return result;
        }

        public override string ToString()
        {
            return "[" + this.GetType().Name + ":  Name='" + _name + "', Value=" + _value.ToString(CultureInfo.InvariantCulture) + "]";
        }

        #endregion
    }
}


