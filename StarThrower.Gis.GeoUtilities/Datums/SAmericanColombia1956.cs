// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: PROV. S AMERICAN 1956, Colombia
    /// Ellipsoid: International_1924,  DeltaX: -282,  SigmaX: 15,  DeltaY: 169,  SigmaY: 15,  DeltaZ: -371,  SigmaZ: 15,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 16,  South: -10,  East: -61,  West: -85
    /// </summary>
    public class SAmericanColombia1956 : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal SAmericanColombia1956()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -282;
            this.SigmaX = 15;
            this.DeltaY = 169;
            this.SigmaY = 15;
            this.DeltaZ = -371;
            this.SigmaZ = 15;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 16;
            this.Domain.Left = -85;
            this.Domain.Bottom = -10;
            this.Domain.Right = -61;
        }
    }
}


