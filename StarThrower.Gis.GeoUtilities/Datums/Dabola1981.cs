// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: DABOLA, Guinea
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -83,  SigmaX: 15,  DeltaY: 37,  SigmaY: 15,  DeltaZ: 124,  SigmaZ: 15,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 19,  South: 1,  East: -4,  West: -18
    /// </summary>
    public class Dabola1981 : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Dabola1981()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -83;
            this.SigmaX = 15;
            this.DeltaY = 37;
            this.SigmaY = 15;
            this.DeltaZ = 124;
            this.SigmaZ = 15;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 19;
            this.Domain.Left = -18;
            this.Domain.Bottom = 1;
            this.Domain.Right = -4;
        }
    }
}


