// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.PrimeMeridians
{
    /// <summary>
    /// Implements the Prime Meridian at Greenwich with a value of 0.0.
    /// </summary>
    public class Greenwich : PrimeMeridian
    {
        internal Greenwich()
        {
            this.Value = 0.0;
        }
    }
}


