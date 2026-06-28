// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Zones.Utm
{
    /// <summary>
    /// An enumeration of Latitudinal UTM Zones ranging from A thru Z.
    /// Note, however, that in most cases, zones A, B, Y, and Z are considered invalid.
    /// </summary>
    public enum LatitudinalZone
    {
        /// <summary>No latitudinal zone has been assigned.</summary>
        Undefined = 0,
        /// <summary>
        /// Spans 90°S to 80°S. Falls outside the normal UTM projection and is not yet
        /// supported by this library (operations against it throw <see cref="NotImplementedException"/>).
        /// </summary>
        UtmA = 1,
        /// <summary>
        /// Falls outside the normal UTM projection and is not yet supported by this library
        /// (operations against it throw <see cref="NotImplementedException"/>).
        /// </summary>
        UtmB = 2,
        /// <summary>Spans 80°S to 72°S.</summary>
        UtmC = 3,
        /// <summary>Spans 72°S to 64°S.</summary>
        UtmD = 4,
        /// <summary>Spans 64°S to 56°S.</summary>
        UtmE = 5,
        /// <summary>Spans 56°S to 48°S.</summary>
        UtmF = 6,
        /// <summary>Spans 48°S to 40°S.</summary>
        UtmG = 7,
        /// <summary>Spans 40°S to 32°S.</summary>
        UtmH = 8,
        /// <summary>Spans 32°S to 24°S.</summary>
        UtmJ = 9,
        /// <summary>Spans 24°S to 16°S.</summary>
        UtmK = 10,
        /// <summary>Spans 16°S to 8°S.</summary>
        UtmL = 11,
        /// <summary>Spans 8°S to 0°.</summary>
        UtmM = 12,
        /// <summary>Spans 0° to 8°N.</summary>
        UtmN = 13,
        /// <summary>Spans 8°N to 16°N.</summary>
        UtmP = 14,
        /// <summary>Spans 16°N to 24°N.</summary>
        UtmQ = 15,
        /// <summary>Spans 24°N to 32°N.</summary>
        UtmR = 16,
        /// <summary>Spans 32°N to 40°N.</summary>
        UtmS = 17,
        /// <summary>Spans 40°N to 48°N.</summary>
        UtmT = 18,
        /// <summary>Spans 48°N to 56°N.</summary>
        UtmU = 19,
        /// <summary>
        /// Spans 56°N to 64°N. Subject to the Norway anomaly: zone 31V is narrowed and zone
        /// 32V is widened to compensate (see <see cref="UtmZone"/>).
        /// </summary>
        UtmV = 20,
        /// <summary>Spans 64°N to 72°N.</summary>
        UtmW = 21,
        /// <summary>
        /// Spans 72°N to 84°N (a non-standard 12-degree band). Subject to the Svalbard
        /// anomaly: zones 32X, 34X, and 36X do not exist, with their longitudinal coverage
        /// absorbed into the widened 31X, 33X, 35X, and 37X (see <see cref="UtmZone"/>).
        /// </summary>
        UtmX = 22,
        /// <summary>
        /// Spans 84°N to 90°N. Falls outside the normal UTM projection and is not yet
        /// supported by this library (operations against it throw <see cref="NotImplementedException"/>).
        /// </summary>
        UtmY = 23,
        /// <summary>
        /// Falls outside the normal UTM projection and is not yet supported by this library
        /// (operations against it throw <see cref="NotImplementedException"/>).
        /// </summary>
        UtmZ = 24
    }
}


