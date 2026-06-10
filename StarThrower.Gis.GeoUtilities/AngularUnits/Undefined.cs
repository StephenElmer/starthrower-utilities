// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.AngularUnits
{
    /// <summary>
    /// Used for implementation of the null object design pattern.
    /// </summary>
    public class Undefined : AngularUnit
    {
        internal Undefined()
        {
            this.Value = 0.0;
        }
    }
}


