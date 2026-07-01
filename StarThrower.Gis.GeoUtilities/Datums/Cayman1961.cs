// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: L.C. 5 ASTRO 1961, Cayman Brac
    /// Ellipsoid: Clarke_1866,  DeltaX: 42,  SigmaX: 25,  DeltaY: 124,  SigmaY: 25,  DeltaZ: 147,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 21,  South: 18,  East: -78,  West: -83
    /// </summary>
    public class Cayman1961 : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Cayman1961()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = 42;
            this.SigmaX = 25;
            this.DeltaY = 124;
            this.SigmaY = 25;
            this.DeltaZ = 147;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 21;
            this.Domain.Left = -83;
            this.Domain.Bottom = 18;
            this.Domain.Right = -78;
        }
    }
}


