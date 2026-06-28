// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// The abstract base class for implementations of the IZone interface.
    /// IZones are used in conjunction with some Projected Coordinate Systems, in particular UTM, 
    /// and provide needed data for the initization of instances of those projected coordinate
    /// systems.
    /// </summary>
    public abstract class Zone : IZone
    {
        /// <summary>
        /// Gets the unique name of the zone.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Gets the standard string designation of this zone (e.g. "31N" for a UTM zone).
        /// </summary>
        public abstract string ZoneString { get; }

        /// <summary>
        /// Gets whether this zone lies in the southern hemisphere.
        /// </summary>
        public abstract bool IsSouthernHemisphere { get; }

        /// <summary>
        /// Gets the Central Meridian used for the TransverseMercator projection calculation.
        /// For special zones (31X, 33X, 35X, 37X, 31V, 32V) this is the standard
        /// longitudinal zone CM, not the geometric center of the zone's actual boundary.
        /// </summary>
        public abstract double CentralMeridian { get; }

        /// <summary>
        /// Gets the geometric center of the zone's actual boundary extent.
        /// For standard zones this equals <see cref="CentralMeridian"/>. For special zones
        /// (31X, 33X, 35X, 37X, 31V, 32V) these will differ due to non-standard
        /// zone widths in the Norway (V) and Svalbard (X) regions.
        /// </summary>
        public abstract double GeometricCenter { get; }

        /// <summary>
        /// Gets the value of the Reference yLat associated with the zone.
        /// </summary>
        public abstract double ReferenceLatitude { get; }
    }
}


