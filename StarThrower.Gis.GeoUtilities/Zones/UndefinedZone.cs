// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Zones
{
    /// <summary>
    /// Used for implementation of the null object design pattern; represents the absence of a zone.
    /// </summary>
    public class UndefinedZone : Zone
    {
        /// <summary>
        /// Gets the unique name of the zone. Always returns "Undefined".
        /// </summary>
        public override string Name
        {
            get { return "Undefined"; }
        }

        /// <summary>
        /// Gets whether this zone lies in the southern hemisphere. Always returns <see langword="false"/>.
        /// </summary>
        public override bool IsSouthernHemisphere
        {
            get { return false; }
        }

        /// <summary>
        /// Gets the standard string designation of this zone. Always returns "Undefined".
        /// </summary>
        public override string ZoneString
        {
            get { return "Undefined"; }
        }

        /// <summary>
        /// Gets the Central Meridian used for the TransverseMercator projection calculation. Always returns 0.0.
        /// </summary>
        public override double CentralMeridian
        {
            get { return 0.0; }
        }

        /// <summary>
        /// Gets the geometric center of the zone's actual boundary extent. Always returns 0.0.
        /// </summary>
        public override double GeometricCenter
        {
            get { return 0.0; }
        }

        /// <summary>
        /// Gets the value of the Reference yLat associated with the zone. Always returns 0.0.
        /// </summary>
        public override double ReferenceLatitude
        {
            get { return 0.0; }
        }
    }
}


