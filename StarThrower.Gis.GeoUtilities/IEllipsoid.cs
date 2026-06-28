// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// Represents a reference ellipsoid: the geometric model of the Earth's shape used by a
    /// geodetic datum.
    /// </summary>
    /// <remarks>
    /// Except for two special cases (described below), Ellipsoid implementations in StarThrower Utilities have been obtained from two sources:
    /// The majority have been obtained by reviewing ESRI's ArcIMS documentation (http://edndoc.esri.com/arcims/9.1/elements/pcs.htm)
    /// and parsing out the various Spheroid data.  In addition to the ESRI data, Ellipsoid data has also been obtained by
    /// examination of the source code for the National Geospatial-Intelligence Agency's GeoTran tool (http://earth-info.nga.mil/GandG/geotrans/).
    /// There are several discrepancies between the ESRI and NGIA data which are described in the notes for each implementation.
    ///
    /// The special cases are as follows:
    /// 1) <see cref="Ellipsoids.Undefined"/>, which is the default type of the <see cref="Ellipsoid"/> class and represents sort of a Null Object pattern.
    /// In most cases, when this is encountered, an exception will be thrown.
    /// 2) <see cref="Ellipsoids.UserDefined"/>, which is provided to allow for dynamic creation of Ellipsoids in those cases where you want to define
    /// your own ellipsoid. In the case of user-defined ellipsoids, the associated Ellipsoid MUST also have a
    /// Name associated with it, as the Ellipsoid's Name will be used to distinguish between different user-defined Ellipsoids.
    /// </remarks>
    public interface IEllipsoid
    {
        /// <summary>
        /// Gets the Name of the Ellipsoid.
        /// In most cases, this will be the name of the class.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the Key of the Ellipsoid.
        /// In most cases, this will be the name of the class.  The
        /// exception is for UserDefined Ellipsoids, in which the Key
        /// will be the Name + some unique value data associated with the
        /// UserDefined Ellipsoid.
        /// </summary>
        string Key { get; }
        
        /// <summary>
        /// Gets the Equatorial Radius (a).
        /// aka. Semi-Major axis.
        /// </summary>
        double EquatorialRadius { get; }

        /// <summary>
        /// Gets the Polar Radius (b).
        /// aka. Semi-Minor axis.
        /// </summary>
        double PolarRadius { get; }

        /// <summary>
        /// Gets the Flattening (f).
        /// </summary>
        double Flattening { get; }

        /// <summary>
        /// Gets the Inverse Flattening (1/f).
        /// </summary>
        double InverseFlattening { get; }

        /// <summary>
        /// Gets the First Eccentricity Squared (e2 or es).
        /// </summary>
        double FirstEccentricitySquared { get; }

        /// <summary>
        /// Gets the First Eccentricity (e)
        /// </summary>
        double FirstEccentricity { get; }

        /// <summary>
        /// Gets the Second Eccentricity Squared (ep2).
        /// </summary>
        double SecondEccentricitySquared { get; }

        /// <summary>
        /// Gets an XML representation of the Ellipsoid.
        /// </summary>
        /// <returns>An XML formatted string.</returns>
        string ToXml();
    }
}


