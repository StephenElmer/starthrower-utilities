// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

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


