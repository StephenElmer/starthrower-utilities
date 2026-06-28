// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// Represents a gravity-model geoid height grid, used to convert between ellipsoid height
    /// and mean-sea-level (geoid) height at a given geodetic location.
    /// </summary>
    public interface IGeoid
    {
        /// <summary>
        /// Gets the name of the Geoid.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the key value of the Geoid, used to distinguish it from others (particularly user-defined geoids).
        /// </summary>
        string Key { get; }

        /// <summary>
        /// Gets the number of rows in this geoid's height grid.
        /// </summary>
        int Rows { get; }

        /// <summary>
        /// Gets the number of columns in this geoid's height grid.
        /// </summary>
        int Columns { get; }

        /// <summary>
        /// Gets the flattened (row-major) grid of geoid height adjustments, in meters.
        /// </summary>
        float[] HeightGrid { get; }


        /// <summary>
        /// Computes the geoid height adjustment at the specified geodetic coordinates, using
        /// natural-spline interpolation over this geoid's height grid.
        /// </summary>
        /// <param name="longitude">Geodetic longitude, in radians.</param>
        /// <param name="latitude">Geodetic latitude, in radians.</param>
        /// <param name="scaleFactor">Grid scale factor (the angular spacing, in degrees, between grid posts).</param>
        /// <param name="deltaHeight">Height adjustment, in meters.</param>
        void NsInterpolate(double longitude, double latitude, double scaleFactor, ref double deltaHeight);

        /// <summary>
        /// Computes the geoid height adjustment at the specified geodetic coordinates, using
        /// bilinear interpolation over this geoid's height grid.
        /// </summary>
        /// <param name="longitude">Geodetic longitude, in radians.</param>
        /// <param name="latitude">Geodetic latitude, in radians.</param>
        /// <param name="scaleFactor">Grid scale factor (the angular spacing, in degrees, between grid posts).</param>
        /// <param name="deltaHeight">Height adjustment, in meters.</param>
        void BlInterpolate(double longitude, double latitude, double scaleFactor, ref double deltaHeight);

        /// <summary>
        /// Converts a geoid (mean-sea-level) height to an ellipsoid height, using natural-spline interpolation.
        /// </summary>
        /// <param name="xLon">Geodetic longitude, in radians.</param>
        /// <param name="yLat">Geodetic latitude, in radians.</param>
        /// <param name="geoidHeight">The geoid height to convert, in meters.</param>
        /// <param name="ellipsoidHeight">The resulting ellipsoid height, in meters.</param>
        void ToEllipsoidHeightNs(double xLon, double yLat, double geoidHeight, ref double ellipsoidHeight);

        /// <summary>
        /// Converts an ellipsoid height to a geoid (mean-sea-level) height, using natural-spline interpolation.
        /// </summary>
        /// <param name="xLon">Geodetic longitude, in radians.</param>
        /// <param name="yLat">Geodetic latitude, in radians.</param>
        /// <param name="ellipsoidHeight">The ellipsoid height to convert, in meters.</param>
        /// <param name="geoidHeight">The resulting geoid height, in meters.</param>
        void FromEllipsoidHeightNs(double xLon, double yLat, double ellipsoidHeight, ref double geoidHeight);

        /// <summary>
        /// Converts a geoid (mean-sea-level) height to an ellipsoid height, using bilinear interpolation.
        /// </summary>
        /// <param name="xLon">Geodetic longitude, in radians.</param>
        /// <param name="yLat">Geodetic latitude, in radians.</param>
        /// <param name="geoidHeight">The geoid height to convert, in meters.</param>
        /// <param name="ellipsoidHeight">The resulting ellipsoid height, in meters.</param>
        void ToEllipsoidHeightBl(double xLon, double yLat, double geoidHeight, ref double ellipsoidHeight);

        /// <summary>
        /// Converts an ellipsoid height to a geoid (mean-sea-level) height, using bilinear interpolation.
        /// </summary>
        /// <param name="xLon">Geodetic longitude, in radians.</param>
        /// <param name="yLat">Geodetic latitude, in radians.</param>
        /// <param name="ellipsoidHeight">The ellipsoid height to convert, in meters.</param>
        /// <param name="geoidHeight">The resulting geoid height, in meters.</param>
        void FromEllipsoidHeightBl(double xLon, double yLat, double ellipsoidHeight, ref double geoidHeight);

        /// <summary>
        /// Gets an XML representation of the Geoid.
        /// </summary>
        /// <returns>An XML formatted string.</returns>
        string ToXml();
    }
}


