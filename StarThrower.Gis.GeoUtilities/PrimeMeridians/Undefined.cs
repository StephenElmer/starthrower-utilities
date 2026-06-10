// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.PrimeMeridians
{
    /// <summary>
    /// Used for implementation of the null object design pattern with a value of 0.0.
    /// </summary>
    public class Undefined : PrimeMeridian
    {
        internal Undefined()
        {
            this.Value = 0.0;
        }
    }
}


