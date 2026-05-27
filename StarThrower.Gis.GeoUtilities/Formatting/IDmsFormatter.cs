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

namespace StarThrower.Gis.GeoUtilities.Formatting
{
    public enum DmsFormat
    {
        Default = 0, //see DMS1
        Dms1 = 1, //[±][d][d]d° [m]m' ss.ss"  examples:  31° 56' 31.13"    -31° 56' 31.13"
        Dms2 = 2, //{N|n|E|e|S|s|w|w}[d][d]d{D|d}[m]m{M|m}[s]s[.s[s]]{S|s}  examples:  S31d56m31.13s  n31D56M3.1S   E3d2m3s
    }

    public interface IDmsFormatter
    {
        double DmsToDdNs(string dmsNs);
        double DmsToDdEw(string dmsEw);
        string DdToDmsNs(double ddNs);
        string DdToDmsEw(double ddEw);
    }
}
