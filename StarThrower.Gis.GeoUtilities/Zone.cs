// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// The abstract base class for implementations of the IZone interface.
    /// IZones are used in conjunction with some Projected Coordinate Systems, in particular UTM, 
    /// and provide needed data for the initization of instances of those projected coordinate
    /// systems.
    /// </summary>
    public abstract class Zone : IZone
    {
        public abstract string Name { get; }
        public abstract string ZoneString { get; }
        public abstract bool IsSouthernHemisphere { get; }
        public abstract double CentralMeridian { get; }
        public abstract double GeometricCenter { get; }
        public abstract double ReferenceLatitude { get; }
    }
}


