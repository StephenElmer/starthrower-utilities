// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: JOHNSTON ISLAND 1961
    /// Ellipsoid: International_1924,  DeltaX: 189,  SigmaX: 25,  DeltaY: -79,  SigmaY: 25,  DeltaZ: -202,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 19,  South: 15,  East: -168,  West: -171
    /// </summary>
    public class JohnstonIsland1961 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal JohnstonIsland1961()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = 189;
            this.SigmaX = 25;
            this.DeltaY = -79;
            this.SigmaY = 25;
            this.DeltaZ = -202;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 19;
            this.Domain.Left = -171;
            this.Domain.Bottom = 15;
            this.Domain.Right = -168;
        }
    }
}


