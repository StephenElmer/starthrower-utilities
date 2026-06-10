// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Formatting
{
    public enum DmsFormat
    {
        Default = 0, //see DMS1
        Dms1 = 1, //[�][d][d]d� [m]m' ss.ss"  examples:  31� 56' 31.13"    -31� 56' 31.13"
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


