// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: PROV. S AMERICAN 1956, Mean
    /// Ellipsoid: International_1924,  DeltaX: -288,  SigmaX: 17,  DeltaY: 175,  SigmaY: 27,  DeltaZ: -376,  SigmaZ: 27,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 18,  South: -64,  East: -51,  West: -87
    /// </summary>
    public class SAmerican1956Mean : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal SAmerican1956Mean()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -288;
            this.SigmaX = 17;
            this.DeltaY = 175;
            this.SigmaY = 27;
            this.DeltaZ = -376;
            this.SigmaZ = 27;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 18;
            this.Domain.Left = -87;
            this.Domain.Bottom = -64;
            this.Domain.Right = -51;
        }
    }
}


