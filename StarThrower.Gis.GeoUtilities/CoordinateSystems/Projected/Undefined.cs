// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.CoordinateSystems.Projected
{
    /// <summary>
    /// An implementation of the "null object" pattern for the IProjectedCoordinateSystem interface.
    /// </summary>
    public class Undefined : ProjectedCoordinateSystem
    {
        #region Construction

        internal Undefined() : base()
        {
            this.GeographicCoordinateSystem = GeographicCoordinateSystemFactory.GetInstanceOfGeographicCoordinateSystem(typeof(Geographic.Undefined));
            this.Projection = ProjectionFactory.GetInstanceOfProjection(typeof(Projections.Undefined), Array.Empty<ProjectionParameter>());
            this.LinearUnit = LinearUnitFactory.GetInstanceOfLinearUnit(typeof(LinearUnits.Undefined));
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Provides an implementation of the IProjectedCoordinateSystem interface for this "null" object.
        /// </summary>
        /// <param name="xLon">xLon value.</param>
        /// <param name="yLat">yLat value.</param>
        /// <param name="zAlt">Altitude value.</param>
        /// <returns>This method will always throw an InvalidOperationException.</returns>
        /// <exception cref="InvalidOperationException">Thrown any time this method is called.</exception>
        public override ITranslationResult ToGeodetic(double xLon, double yLat, double zAlt)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Provides an implementation of the IProjectedCoordinateSystem interface for this "null" object.
        /// </summary>
        /// <param name="xLon">xLon value.</param>
        /// <param name="yLat">yLat value.</param>
        /// <param name="zAlt">Altitude value.</param>
        /// <returns>This method will always throw an InvalidOperationException.</returns>
        /// <exception cref="InvalidOperationException">Thrown any time this method is called.</exception>
        public override ITranslationResult FromGeodetic(double xLon, double yLat, double zAlt)
        {
            throw new InvalidOperationException();
        }

        #endregion
    }
}


