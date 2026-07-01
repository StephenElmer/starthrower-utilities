// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: PROV. S AMERICAN 1956, N Chile
    /// Ellipsoid: International_1924,  DeltaX: -270,  SigmaX: 25,  DeltaY: 183,  SigmaY: 25,  DeltaZ: -390,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -12,  South: -45,  East: -60,  West: -83
    /// </summary>
    public class SAmericanNorthChile1956 : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal SAmericanNorthChile1956()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -270;
            this.SigmaX = 25;
            this.DeltaY = 183;
            this.SigmaY = 25;
            this.DeltaZ = -390;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -12;
            this.Domain.Left = -83;
            this.Domain.Bottom = -45;
            this.Domain.Right = -60;
        }
    }
}


