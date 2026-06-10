// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: ANNA 1 ASTRO 1965, Cocos Is.
    /// Ellipsoid: Australian,  DeltaX: -491,  SigmaX: 25,  DeltaY: -22,  SigmaY: 25,  DeltaZ: 435,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -10,  South: -14,  East: 99,  West: 94
    /// </summary>
    public class CocosIsland1965 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal CocosIsland1965()
        {
            this.Ellipsoid = new Ellipsoids.Australian();
            this.DeltaX = -491;
            this.SigmaX = 25;
            this.DeltaY = -22;
            this.SigmaY = 25;
            this.DeltaZ = 435;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -10;
            this.Domain.Left = 94;
            this.Domain.Bottom = -14;
            this.Domain.Right = 99;
        }
    }
}


