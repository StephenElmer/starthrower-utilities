// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// Extends <see cref="IProjectedCoordinateSystem"/> for projected coordinate systems
    /// that are divided into discrete zones (e.g. UTM).
    /// </summary>
    public interface IZonedCoordinateSystem : IProjectedCoordinateSystem
    {
        /// <summary>
        /// Gets the zone associated with this coordinate system.
        /// </summary>
        IZone Zone { get; }
    }
}


