// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Projections
{
    /// <summary>
    /// Used for implementation of the null object design pattern; represents the absence of a projection.
    /// </summary>
    public class Undefined : IProjection
    {
        /// <summary>
        /// Validates the given array of parameters. Always returns <see langword="true"/>,
        /// since <see cref="Undefined"/> accepts any parameters (or none).
        /// </summary>
        /// <param name="parameters">The parameters to validate.</param>
        /// <returns><see langword="true"/>, always.</returns>
        public static bool ValidateParameters(ProjectionParameter[] parameters)
        {
            return true;
        }


        #region Public Properties

        /// <summary>
        /// Gets the value of the named projection parameter. Always returns 0.0.
        /// </summary>
        /// <param name="parameterName">The name of the projection parameter to retrieve.</param>
        /// <returns>0.0, always.</returns>
        public double this[string parameterName]
        {
            get { return 0.0; }
        }

        #endregion


        #region Construction

        internal Undefined(ProjectionParameter[] parameters) { }

        #endregion


        #region Public Methods

        /// <summary>
        /// Gets an XML representation of the projection.
        /// </summary>
        /// <returns>An XML formatted string.</returns>
        public string ToXml()
        {
            return "<projection projectionType=\"" + this.GetType().Name + "\"/>\n";
        }

        #endregion
    }
}


