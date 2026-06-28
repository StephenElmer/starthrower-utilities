// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// ITranslation results are returned from the various translation 
    /// methods used for converting coordinates from one coordinate system to another.
    /// </summary>
    public interface ITranslationResult
    {
        /// <summary>
        /// Gets the resulting longitude (or x/easting-equivalent) coordinate.
        /// </summary>
        double xLon { get; }

        /// <summary>
        /// Gets the resulting latitude (or y/northing-equivalent) coordinate.
        /// </summary>
        double yLat { get; }

        /// <summary>
        /// Gets the resulting vertical (height/altitude) coordinate.
        /// </summary>
        double zAlt { get; }

        /// <summary>
        /// Gets the estimated 90% circular error, accumulated across the translation.
        /// </summary>
        double ce90 { get; }

        /// <summary>
        /// Gets the estimated 90% linear error, accumulated across the translation.
        /// </summary>
        double le90 { get; }

        /// <summary>
        /// Gets the estimated 90% spherical error, accumulated across the translation.
        /// </summary>
        double se90 { get; }

        /// <summary>
        /// Sets the estimated accumulated computational error for this translation result.
        /// </summary>
        /// <param name="ce90">The estimated 90% circular error.</param>
        /// <param name="le90">The estimated 90% linear error.</param>
        /// <param name="se90">The estimated 90% spherical error.</param>
        void SetComputationalError(double ce90, double le90, double se90);
    }
}


