// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Projections
{
    public class Undefined : IProjection
    {
        public static bool ValidateParameters(ProjectionParameter[] parameters)
        {
            return true;
        }


        #region Public Properties

        public double this[string parameterName]
        {
            get { return 0.0; }
        }

        #endregion


        #region Construction

        internal Undefined(ProjectionParameter[] parameters) { }

        #endregion


        #region Public Methods

        public string ToXml()
        {
            return "<projection projectionType=\"" + this.GetType().Name + "\"/>\n";
        }

        #endregion
    }
}


