/***********************************************************************************
    StarThrower Utilities
    Copyright (C) 2005-2007  Steve Elmer

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
