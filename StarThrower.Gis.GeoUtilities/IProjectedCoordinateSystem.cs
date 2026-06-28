// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// Represents a projected (planar x/y) coordinate system, built from an underlying
    /// geographic coordinate system, a map projection, and a linear unit.
    /// </summary>
    public interface IProjectedCoordinateSystem : ICoordinateSystem
    {
        /// <summary>
        /// Gets the geographic coordinate system this projected coordinate system is based on.
        /// </summary>
        IGeographicCoordinateSystem GeographicCoordinateSystem { get; }

        /// <summary>
        /// Gets the map projection used to convert between geographic and projected coordinates.
        /// </summary>
        IProjection Projection { get; }

        /// <summary>
        /// Gets the value of the named projection parameter (e.g. "False_Easting", "Central_Meridian").
        /// </summary>
        /// <param name="parameterName">The name of the projection parameter to retrieve.</param>
        double this[string parameterName] { get; }

        /// <summary>
        /// Gets the linear unit used by this coordinate system's projected (x/y) coordinates.
        /// </summary>
        ILinearUnit LinearUnit { get; }
    }
}


