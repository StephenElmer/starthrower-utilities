// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities
{
    public interface IProjectedCoordinateSystem : ICoordinateSystem
    {
        IGeographicCoordinateSystem GeographicCoordinateSystem { get; }
        IProjection Projection { get; }
        double this[string parameterName] { get; }
        ILinearUnit LinearUnit { get; }
    }
}


