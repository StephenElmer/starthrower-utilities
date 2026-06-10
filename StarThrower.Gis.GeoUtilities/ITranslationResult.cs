// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// ITranslation results are returned from the various translation 
    /// methods used for converting coordinates from one coordinate system to another.
    /// </summary>
    public interface ITranslationResult
    {
        double xLon { get; }
        double yLat { get; }
        double zAlt { get; }

        double ce90 { get; }
        double le90 { get; }
        double se90 { get; }

        void SetComputationalError(double ce90, double le90, double se90);
    }
}


