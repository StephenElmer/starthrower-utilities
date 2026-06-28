// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// Represents a coordinate system: a datum, prime meridian, angular unit, and height
    /// interpretation, together with the ability to translate coordinates expressed in this
    /// system to and from geodetic (latitude/longitude) coordinates.
    /// </summary>
    public interface ICoordinateSystem
    {
        /// <summary>
        /// Gets the number of significant digits to which coordinates in this system should be
        /// rounded, used to estimate accumulated translation error (see <see cref="ITranslationResult"/>).
        /// </summary>
        long SignificantDigits { get; }

        /// <summary>
        /// Gets the name of this coordinate system.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the key value of this coordinate system, used to distinguish it from others
        /// (particularly user-defined coordinate systems).
        /// </summary>
        string Key { get; }

        /// <summary>
        /// Gets the datum this coordinate system is based on.
        /// </summary>
        IDatum Datum { get; }

        /// <summary>
        /// Gets the prime meridian this coordinate system is referenced to.
        /// </summary>
        IPrimeMeridian PrimeMeridian { get; }

        /// <summary>
        /// Gets the angular unit used by this coordinate system's geodetic coordinates.
        /// </summary>
        IAngularUnit AngularUnit { get; }

        /// <summary>
        /// Gets how this coordinate system's vertical (height) component should be interpreted
        /// and converted during a translation.
        /// </summary>
        HeightType HeightType { get; }

        /// <summary>
        /// Gets an XML representation of this coordinate system.
        /// </summary>
        /// <returns>An XML formatted string.</returns>
        string ToXml();

        /// <summary>
        /// Converts a coordinate expressed in this coordinate system to geodetic
        /// (latitude/longitude/height) coordinates.
        /// </summary>
        /// <param name="xLon">The x (or longitude/easting-equivalent) coordinate.</param>
        /// <param name="yLat">The y (or latitude/northing-equivalent) coordinate.</param>
        /// <param name="zAlt">The vertical (height/altitude) coordinate.</param>
        /// <returns>The resulting geodetic coordinates, along with estimated accumulated error.</returns>
        ITranslationResult ToGeodetic(double xLon, double yLat, double zAlt);

        /// <summary>
        /// Converts a geodetic (latitude/longitude/height) coordinate to this coordinate system.
        /// </summary>
        /// <param name="xLon">The longitude.</param>
        /// <param name="yLat">The latitude.</param>
        /// <param name="zAlt">The height/altitude.</param>
        /// <returns>The resulting coordinates in this coordinate system, along with estimated accumulated error.</returns>
        ITranslationResult FromGeodetic(double xLon, double yLat, double zAlt);
    }
}


