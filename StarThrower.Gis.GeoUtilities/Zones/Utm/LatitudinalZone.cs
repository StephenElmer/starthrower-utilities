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

namespace StarThrower.Gis.GeoUtilities.Zones.Utm
{
    /// <summary>
    /// An enumeration of Latitudinal UTM Zones ranging from A thru Z.
    /// Note, however, that in most cases, zones A, B, Y, and Z are considered invalid.
    /// </summary>
    public enum LatitudinalZone
    {
        Undefined = 0,
        UtmA = 1,
        UtmB = 2,
        UtmC = 3,
        UtmD = 4,
        UtmE = 5,
        UtmF = 6,
        UtmG = 7,
        UtmH = 8,
        UtmJ = 9,
        UtmK = 10,
        UtmL = 11,
        UtmM = 12,
        UtmN = 13,
        UtmP = 14,
        UtmQ = 15,
        UtmR = 16,
        UtmS = 17,
        UtmT = 18,
        UtmU = 19,
        UtmV = 20,
        UtmW = 21,
        UtmX = 22,
        UtmY = 23,
        UtmZ = 24
    }
}
