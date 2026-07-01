// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: HU-TZU-SHAN, Taiwan
    /// Ellipsoid: International_1924,  DeltaX: -637,  SigmaX: 15,  DeltaY: -549,  SigmaY: 15,  DeltaZ: -203,  SigmaZ: 15,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 28,  South: 20,  East: 124,  West: 117
    /// </summary>
    public class HuTzuShanTaiwan : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal HuTzuShanTaiwan()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -637;
            this.SigmaX = 15;
            this.DeltaY = -549;
            this.SigmaY = 15;
            this.DeltaZ = -203;
            this.SigmaZ = 15;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 28;
            this.Domain.Left = 117;
            this.Domain.Bottom = 20;
            this.Domain.Right = 124;
        }
    }
}


