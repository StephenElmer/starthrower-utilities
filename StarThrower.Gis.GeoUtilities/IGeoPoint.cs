// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// Represents a single geodetic point, exposing both decimal-degree and
    /// degrees-minutes-seconds string representations of its longitude and latitude.
    /// </summary>
    //TODO: #15 — xLon/yLat here are decimal degrees, but mean radians on IDatum/ICoordinateSystem/ITranslationResult and implementations; no naming distinction
    public interface IGeoPoint
    {
        /// <summary>
        /// Gets or sets the longitude, in decimal degrees.
        /// </summary>
        double xLon { get; set; }

        /// <summary>
        /// Gets or sets the latitude, in decimal degrees.
        /// </summary>
        double yLat { get; set; }

        /// <summary>
        /// Gets or sets the longitude as a degrees-minutes-seconds formatted string.
        /// </summary>
        string xLonDms { get; set; }

        /// <summary>
        /// Gets or sets the latitude as a degrees-minutes-seconds formatted string.
        /// </summary>
        string yLatDms { get; set; }
    }
}


