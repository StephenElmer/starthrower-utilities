// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities
{
    public interface IGeoPoint
    {
        double xLon { get; set; }
        double yLat { get; set; }
        string xLonDms { get; set; }
        string yLatDms { get; set; }
    }
}


