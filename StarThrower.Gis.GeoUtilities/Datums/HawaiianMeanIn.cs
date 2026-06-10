// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: OLD HAWAIIAN (IN), Mean
    /// Ellipsoid: International_1924,  DeltaX: 201,  SigmaX: 25,  DeltaY: -228,  SigmaY: 20,  DeltaZ: -346,  SigmaZ: 20,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 24,  South: 17,  East: -153,  West: -164
    /// </summary>
    public class HawaiianMeanIn : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal HawaiianMeanIn()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = 201;
            this.SigmaX = 25;
            this.DeltaY = -228;
            this.SigmaY = 20;
            this.DeltaZ = -346;
            this.SigmaZ = 20;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 24;
            this.Domain.Left = -164;
            this.Domain.Bottom = 17;
            this.Domain.Right = -153;
        }
    }
}


