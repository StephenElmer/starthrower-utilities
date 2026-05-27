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
    /// The IZone interface is used in conjunction with some Projected Coordinate Systems, in particular UTM, 
    /// and provide needed data for the initization of instances of those projected coordinate systems.
    /// </summary>
    public interface IZone
    {
        /// <summary>
        /// Gets the unique name of the zone.
        /// </summary>
        string Name { get; }

        bool IsSouthernHemisphere { get; }

        string ZoneString { get; }

        /// <summary>
        /// Gets the Central Meridian used for the TransverseMercator projection calculation.
        /// For special zones (31X, 33X, 35X, 37X, 31V, 32V) this is the standard
        /// longitudinal zone CM, not the geometric center of the zone's actual boundary.
        /// </summary>
        double CentralMeridian { get; }

        /// <summary>
        /// Gets the geometric center of the zone's actual boundary extent.
        /// For standard zones this equals CentralMeridian. For special zones
        /// (31X, 33X, 35X, 37X, 31V, 32V) these will differ due to non-standard
        /// zone widths in the Norway (V) and Svalbard (X) regions.
        /// </summary>
        double GeometricCenter { get; }

        /// <summary>
        /// Gets the value of the Reference yLat associated with the zone.
        /// </summary>
        double ReferenceLatitude { get; }
    }
}
