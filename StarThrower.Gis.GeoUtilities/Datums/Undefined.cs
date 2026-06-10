// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// Used for implementation of the null object design pattern.
    /// </summary>
    public class Undefined : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Undefined()
        {
            this.Ellipsoid = new Ellipsoids.Undefined();
            this.DeltaX = 0.0;
            this.SigmaX = -1.0;
            this.DeltaY = 0.0;
            this.SigmaY = -1.0;
            this.DeltaZ = 0.0;
            this.SigmaZ = 0.0;
            this.RotationX = 0.0;
            this.RotationY = 0.0;
            this.RotationZ = 0.0;
            this.RotationScaleFactor = 1.0;
            this.Domain.Top = 90.0;
            this.Domain.Left = -180.0;
            this.Domain.Bottom = -90.0;
            this.Domain.Right = 180.0;
        }
    }
}


