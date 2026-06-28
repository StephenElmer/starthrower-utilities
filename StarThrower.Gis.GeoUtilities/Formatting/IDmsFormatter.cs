// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Formatting
{
    /// <summary>
    /// Identifies the textual degrees-minutes-seconds (DMS) format used when converting
    /// between decimal-degree values and their DMS string representation.
    /// </summary>
    public enum DmsFormat
    {
        /// <summary>Equivalent to <see cref="Dms1"/>.</summary>
        Default = 0, //see DMS1
        /// <summary>
        /// The format <c>[-]d[d]d&#176; [m]m' ss.ss"</c>, e.g. <c>31&#176; 56' 31.13"</c> or
        /// <c>-31&#176; 56' 31.13"</c>.
        /// </summary>
        Dms1 = 1, //[�][d][d]d� [m]m' ss.ss"  examples:  31� 56' 31.13"    -31� 56' 31.13"
        /// <summary>
        /// The format <c>{N|n|E|e|S|s|W|w}d[d]d{D|d}m[m]{M|m}s[s][.s[s]]{S|s}</c>, e.g.
        /// <c>S31d56m31.13s</c>, <c>n31D56M3.1S</c>, or <c>E3d2m3s</c>.
        /// </summary>
        Dms2 = 2, //{N|n|E|e|S|s|w|w}[d][d]d{D|d}[m]m{M|m}[s]s[.s[s]]{S|s}  examples:  S31d56m31.13s  n31D56M3.1S   E3d2m3s
    }

    /// <summary>
    /// Converts between decimal-degree coordinate values and their textual
    /// degrees-minutes-seconds (DMS) representation.
    /// </summary>
    public interface IDmsFormatter
    {
        /// <summary>
        /// Converts a north/south DMS string to its decimal-degree equivalent.
        /// </summary>
        /// <param name="dmsNs">The north/south coordinate, formatted as DMS.</param>
        /// <returns>The decimal-degree value (negative for south).</returns>
        double DmsToDdNs(string dmsNs);

        /// <summary>
        /// Converts an east/west DMS string to its decimal-degree equivalent.
        /// </summary>
        /// <param name="dmsEw">The east/west coordinate, formatted as DMS.</param>
        /// <returns>The decimal-degree value (negative for west).</returns>
        double DmsToDdEw(string dmsEw);

        /// <summary>
        /// Converts a decimal-degree north/south coordinate to its textual DMS representation.
        /// </summary>
        /// <param name="ddNs">The decimal-degree value (negative for south).</param>
        /// <returns>The coordinate formatted as DMS, with an "N" or "S" designation as appropriate to this formatter's style.</returns>
        string DdToDmsNs(double ddNs);

        /// <summary>
        /// Converts a decimal-degree east/west coordinate to its textual DMS representation.
        /// </summary>
        /// <param name="ddEw">The decimal-degree value (negative for west).</param>
        /// <returns>The coordinate formatted as DMS, with an "E" or "W" designation as appropriate to this formatter's style.</returns>
        string DdToDmsEw(double ddEw);
    }
}


