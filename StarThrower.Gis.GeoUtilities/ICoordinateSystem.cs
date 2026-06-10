// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities
{
    public interface ICoordinateSystem
    {
        long SignificantDigits { get; }
        string Name { get; }
        string Key { get; }
        IDatum Datum { get; }
        IPrimeMeridian PrimeMeridian { get; }
        IAngularUnit AngularUnit { get; }
        HeightType HeightType { get; }

        string ToXml();
        ITranslationResult ToGeodetic(double xLon, double yLat, double zAlt);
        ITranslationResult FromGeodetic(double xLon, double yLat, double zAlt);
    }
}


