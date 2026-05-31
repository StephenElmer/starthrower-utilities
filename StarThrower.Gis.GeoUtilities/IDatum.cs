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
    /// An enumeration of the types of Datums which are supported by the StarThrower Utilities.
    /// </summary>
    /// <remarks>
    /// Except for two special cases (described below), Datum types for StarThrower Utilities have been obtained from two sources:
    /// //TODO: update this comment
    /// 
    /// The special cases of DatumType are as follows:
    /// 1) Undefined which is the default type of the cref="Datum" class and represents sort of a Null Object pattern.
    /// In most cases, when this DatumType is encountered, and exception will be thrown.
    /// 2) UserDefined which is provided to allow for dynamic creation of Datums in those cases where you want to define
    /// your own DatumType.  In the case of UserDefined datum types, the associated Datum MUST also have a
    /// Name associated with it, as the Datum's Name will be used to distinguish between different UserDefined Datums.
    /// </remarks>
    public interface IDatum
    {
        string Name { get; }
        string Key { get; }
        IEllipsoid Ellipsoid { get; }
        double DeltaX { get; }
        double DeltaY { get; }
        double DeltaZ { get; }
        double SigmaX { get; }
        double SigmaY { get; }
        double SigmaZ { get; }
        double RotationX { get; }
        double RotationY { get; }
        double RotationZ { get; }
        double RotationScaleFactor { get; }
        GeoRectangle Domain { get; }
        bool IsSevenParamDatum { get; }

        void ToWgs84(double xLon, double yLat, double zAlt, ref double wgs84XLon, ref double wgs84YLat, ref double wgs84ZAlt);
        void FromWgs84(double wgs84XLon, double wgs84YLat, double wgs84ZAlt, ref double xLon, ref double yLat, ref double zAlt);
        bool Validate(double xLon, double yLat);
        string ToXml();
    }
}


