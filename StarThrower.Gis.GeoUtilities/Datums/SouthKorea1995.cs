// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: KOREAN GEO DATUM 1995, S Korea
    /// Ellipsoid: WGS_1984,  DeltaX: 0,  SigmaX: 1,  DeltaY: 0,  SigmaY: 1,  DeltaZ: 0,  SigmaZ: 1,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 45,  South: 27,  East: 139,  West: 120
    /// </summary>
    public class SouthKorea1995 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal SouthKorea1995()
        {
            this.Ellipsoid = new Ellipsoids.Wgs1984();
            this.DeltaX = 0;
            this.SigmaX = 1;
            this.DeltaY = 0;
            this.SigmaY = 1;
            this.DeltaZ = 0;
            this.SigmaZ = 1;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 45;
            this.Domain.Left = 120;
            this.Domain.Bottom = 27;
            this.Domain.Right = 139;
        }
    }
}


