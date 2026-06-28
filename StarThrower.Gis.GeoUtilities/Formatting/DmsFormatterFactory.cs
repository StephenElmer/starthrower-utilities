// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Formatting
{
    /// <summary>
    /// Creates <see cref="IDmsFormatter"/> instances for a given <see cref="DmsFormat"/>.
    /// </summary>
    public static class DmsFormatterFactory
    {
        /// <summary>
        /// Gets the singleton <see cref="IDmsFormatter"/> instance for the given <see cref="DmsFormat"/>.
        /// </summary>
        /// <param name="dmsFormat">The DMS string format the formatter should use.</param>
        /// <returns>
        /// A <see cref="Dms2Formatter"/> for <see cref="DmsFormat.Dms2"/>; otherwise a
        /// <see cref="DefaultDmsFormatter"/> (used for both <see cref="DmsFormat.Dms1"/> and
        /// <see cref="DmsFormat.Default"/>).
        /// </returns>
        public static IDmsFormatter Create(DmsFormat dmsFormat)
        {
            switch (dmsFormat)
            {
                case DmsFormat.Dms2:
                    return Dms2Formatter.GetInstance();
                case DmsFormat.Dms1:
                case DmsFormat.Default:
                default:
                    return DefaultDmsFormatter.GetInstance();
            }
        }
    }
}


