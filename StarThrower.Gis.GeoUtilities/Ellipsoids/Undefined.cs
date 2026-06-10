// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// Used for implementation of the null object design pattern.
    /// </summary>
    public class Undefined : Ellipsoid
    {
        internal Undefined()
        {
            this.EquatorialRadius = 0.0;
            this.Flattening = 0.0;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


