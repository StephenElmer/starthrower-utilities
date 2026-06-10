// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.LinearUnits
{
    /// <summary>
    /// Implements the standard definition of a Foot LinearUnit with a value of 0.3048 Meters.
    /// </summary>
    public class Foot : LinearUnit
    {
        internal Foot()
        {
            this.Value = 0.3048;
        }
    }
}


