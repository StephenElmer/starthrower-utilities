// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Formatting
{
    public static class DmsFormatterFactory
    {
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


