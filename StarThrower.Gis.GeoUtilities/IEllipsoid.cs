/***********************************************************************************
    StarThrower Utilities / Gis.GeoUtilities
    Copyright (C) 2005-2026  Stephen Elmer

    This library is free software; you can redistribute it and/or
    modify it under the terms of the GNU Lesser General Public
    License as published by the Free Software Foundation; either
    version 2.1 of the License, or (at your option) any later version.

    This library is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
    Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public
    License along with this library; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
***********************************************************************************/

using System;

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// An enumeration of the types of Ellipsoids which are supported by the StarThrower Utilities.
    /// </summary>
    /// <remarks>
    /// Except for two special cases (described below), Ellipsoid types for StarThrower Utilities have been obtained from two sources:
    /// The majority have been obtained by reviewing ESRI's ArcIMS documentation (http://edndoc.esri.com/arcims/9.1/elements/pcs.htm)
    /// and parsing out the various Spheroid data.  In addition to the ESRI data, Ellipsoid Type data has also been obtained by
    /// examination of the source code for the National Geospatial-Intelligence Agency's GeoTran tool (http://earth-info.nga.mil/GandG/geotrans/).
    /// There are several indiscrepancies between the ESRI and NGIA data which are described in the notes for each enumeration.
    /// 
    /// The special cases of EllipsoidType are as follows:
    /// 1) Undefined which is the default type of the cref="Ellipsoid" class and represents sort of a Null Object pattern.
    /// In most cases, when this EllipsoidType is encountered, and exception will be thrown.
    /// 2) UserDefined which is provided to allow for dynamic creation of Ellipsoids in those cases where you want to define
    /// your own EllipsoidType.  In the case of UserDefined ellipsoid types, the associated Ellipsoid MUST also have a
    /// Name associated with it, as the Ellipsoid's Name will be used to distinguish between different UserDefined Ellipsoids.
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
        /// Gets the Invers Flattening (1/f).
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


