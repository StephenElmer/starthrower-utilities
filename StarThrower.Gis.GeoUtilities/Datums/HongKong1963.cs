// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: HONG KONG 1963
    /// Ellipsoid: International_1924,  DeltaX: -156,  SigmaX: 25,  DeltaY: -271,  SigmaY: 25,  DeltaZ: -189,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 24,  South: 21,  East: 116,  West: 112
    /// </summary>
    public class HongKong1963 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal HongKong1963()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -156;
            this.SigmaX = 25;
            this.DeltaY = -271;
            this.SigmaY = 25;
            this.DeltaZ = -189;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 24;
            this.Domain.Left = 112;
            this.Domain.Bottom = 21;
            this.Domain.Right = 116;
        }
    }
}


