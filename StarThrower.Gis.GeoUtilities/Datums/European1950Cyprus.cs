// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: EUROPEAN 1950, Cyprus
    /// Ellipsoid: International_1924,  DeltaX: -104,  SigmaX: 15,  DeltaY: -101,  SigmaY: 15,  DeltaZ: -140,  SigmaZ: 15,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 37,  South: 33,  East: 36,  West: 31
    /// </summary>
    public class European1950Cyprus : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal European1950Cyprus()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -104;
            this.SigmaX = 15;
            this.DeltaY = -101;
            this.SigmaY = 15;
            this.DeltaZ = -140;
            this.SigmaZ = 15;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 37;
            this.Domain.Left = 31;
            this.Domain.Bottom = 33;
            this.Domain.Right = 36;
        }
    }
}


