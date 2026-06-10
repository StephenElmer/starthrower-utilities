// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.LinearUnits
{
    /// <summary>
    /// Implements the a Meter LinearUnit with a value of 1.0.
    /// All other Linear Units are defined in terms of the Meter.
    /// </summary>
    public class Meter : LinearUnit
    {
        internal Meter()
        {
            this.Value = 1.0;
        }
    }
}


