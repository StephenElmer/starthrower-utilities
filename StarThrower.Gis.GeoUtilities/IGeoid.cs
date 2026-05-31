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
    public interface IGeoid
    {
        string Name { get; }
        string Key { get; }
        int Rows { get; }
        int Columns { get; }
        float[] HeightGrid { get; }


        void NsInterpolate(double longitude, double latitude, double scaleFactor, ref double deltaHeight);
        void BlInterpolate(double longitude, double latitude, double scaleFactor, ref double deltaHeight);
        void ToEllipsoidHeightNs(double xLon, double yLat, double geoidHeight, ref double ellipsoidHeight);
        void FromEllipsoidHeightNs(double xLon, double yLat, double ellipsoidHeight, ref double geoidHeight);
        void ToEllipsoidHeightBl(double xLon, double yLat, double geoidHeight, ref double ellipsoidHeight);
        void FromEllipsoidHeightBl(double xLon, double yLat, double ellipsoidHeight, ref double geoidHeight);
        string ToXml();
    }
}


