// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: NAHRWAN, Masirah Island (Oman)
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -247,  SigmaX: 25,  DeltaY: -148,  SigmaY: 25,  DeltaZ: 369,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 22,  South: 19,  East: 60,  West: 57
    /// </summary>
    public class NahrwanOman : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal NahrwanOman()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -247;
            this.SigmaX = 25;
            this.DeltaY = -148;
            this.SigmaY = 25;
            this.DeltaZ = 369;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 22;
            this.Domain.Left = 57;
            this.Domain.Bottom = 19;
            this.Domain.Right = 60;
        }
    }
}


