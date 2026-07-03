// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities
{
    //TODO: #36 — what were the two sources I used for Datum?

    /// <summary>
    /// Represents a geodetic datum: an ellipsoid plus the shift parameters needed to convert
    /// coordinates between this datum and WGS84.
    /// </summary>
    /// <remarks>
    /// Except for two special cases (described below), Datum implementations in StarThrower Utilities have been obtained from two sources:
    /// 
    /// TODO: #36 — update this comment
    ///
    /// The special cases are as follows:
    /// 1) <see cref="Datums.Undefined"/>, which is the default type of the <see cref="Datum"/> class and represents sort of a Null Object pattern.
    /// In most cases, when this is encountered, an exception will be thrown.
    /// 2) <see cref="Datums.UserDefined"/>, which is provided to allow for dynamic creation of Datums in those cases where you want to define
    /// your own datum type. In the case of user-defined datums, the associated Datum MUST also have a
    /// Name associated with it, as the Datum's Name will be used to distinguish between different user-defined Datums.
    /// </remarks>
    public interface IDatum
    {
        /// <summary>
        /// Gets the name of the Datum.
        /// This is really only necessary if DatumType == DatumType.UserDefined
        /// as it is intended to distinguish one UserDefined Datum from another.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the key value of the Datum.
        /// If DatumType == DatumType.UserDefined, the Key will be the DatumType,
        /// otherwise, it will be the DatumType + Name so that UserDefined datums
        /// may be distinguished from one another.
        /// </summary>
        string Key { get; }

        /// <summary>
        /// Gets the Ellipsoid of the Datum.
        /// </summary>
        IEllipsoid Ellipsoid { get; }

        /// <summary>
        /// Gets the shift in the X direction to convert to WGS 84 (meters).
        /// </summary>
        double DeltaX { get; }

        /// <summary>
        /// Gets the shift in the Y direction to convert to WGS 84 (meters).
        /// </summary>
        double DeltaY { get; }

        /// <summary>
        /// Gets the shift in the Z direction to convert to WGS 84 (meters).
        /// </summary>
        double DeltaZ { get; }

        /// <summary>
        /// Gets the standard error in the X direction to convert to WGS 84 (meters).
        /// A value of -1 indicates that the Standard Error (Sigma) is unknown.
        /// </summary>
        double SigmaX { get; }

        /// <summary>
        /// Gets the standard error in the Y direction to convert to WGS 84 (meters).
        /// A value of -1 indicates that the Standard Error (Sigma) is unknown.
        /// </summary>
        double SigmaY { get; }

        /// <summary>
        /// Gets the standard error in the Z direction to convert to WGS 84 (meters).
        /// A value of -1 indicates that the Standard Error (Sigma) is unknown.
        /// </summary>
        double SigmaZ { get; }

        /// <summary>
        /// Gets the rotation in the X direction, used by seven-parameter datums.
        /// </summary>
        double RotationX { get; }

        /// <summary>
        /// Gets the rotation in the Y direction, used by seven-parameter datums.
        /// </summary>
        double RotationY { get; }

        /// <summary>
        /// Gets the rotation in the Z direction, used by seven-parameter datums.
        /// </summary>
        double RotationZ { get; }

        /// <summary>
        /// Gets the scale factor for the rotation, used by seven-parameter datums.
        /// </summary>
        double RotationScaleFactor { get; }

        /// <summary>
        /// Gets the valid domain for this datum (i.e. the geographic region for which this datum is valid).
        /// </summary>
        GeoRectangle Domain { get; }

        /// <summary>
        /// Gets whether this datum's shift to/from WGS84 uses the full seven-parameter
        /// (3 translation + 3 rotation + scale) transformation rather than the simpler
        /// three-parameter (translation-only) Molodensky shift.
        /// </summary>
        bool IsSevenParamDatum { get; }

        /// <summary>
        /// Shifts a geodetic coordinate in this datum to the equivalent coordinate in the WGS84 datum.
        /// </summary>
        /// <param name="xLon">Longitude, in radians, in this datum.</param>
        /// <param name="yLat">Latitude, in radians, in this datum.</param>
        /// <param name="zAlt">Height, in meters, in this datum.</param>
        /// <param name="wgs84XLon">The resulting longitude, in radians, in WGS84.</param>
        /// <param name="wgs84YLat">The resulting latitude, in radians, in WGS84.</param>
        /// <param name="wgs84ZAlt">The resulting height, in meters, in WGS84.</param>
        void ToWgs84(double xLon, double yLat, double zAlt, ref double wgs84XLon, ref double wgs84YLat, ref double wgs84ZAlt);

        /// <summary>
        /// Shifts a geodetic coordinate in the WGS84 datum to the equivalent coordinate in this datum.
        /// </summary>
        /// <param name="wgs84XLon">Longitude, in radians, in WGS84.</param>
        /// <param name="wgs84YLat">Latitude, in radians, in WGS84.</param>
        /// <param name="wgs84ZAlt">Height, in meters, in WGS84.</param>
        /// <param name="xLon">The resulting longitude, in radians, in this datum.</param>
        /// <param name="yLat">The resulting latitude, in radians, in this datum.</param>
        /// <param name="zAlt">The resulting height, in meters, in this datum.</param>
        void FromWgs84(double wgs84XLon, double wgs84YLat, double wgs84ZAlt, ref double xLon, ref double yLat, ref double zAlt);

        /// <summary>
        /// Tests whether the specified geodetic coordinate falls within this datum's valid domain.
        /// </summary>
        /// <param name="xLon">Longitude, in radians.</param>
        /// <param name="yLat">Latitude, in radians.</param>
        /// <returns>True if the coordinate is within this datum's valid domain.</returns>
        bool Validate(double xLon, double yLat);

        /// <summary>
        /// Gets an XML representation of the Datum.
        /// </summary>
        /// <returns>An XML formatted string.</returns>
        string ToXml();
    }
}


