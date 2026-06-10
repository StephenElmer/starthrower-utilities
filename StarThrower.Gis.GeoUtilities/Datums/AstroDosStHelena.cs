// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: ASTRO DOS 71/4, St. Helena Is.
    /// Ellipsoid: International_1924,  DeltaX: -320,  SigmaX: 25,  DeltaY: 550,  SigmaY: 25,  DeltaZ: -494,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -14,  South: -18,  East: -4,  West: -7
    /// </summary>
    public class AstroDosStHelena : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal AstroDosStHelena()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -320;
            this.SigmaX = 25;
            this.DeltaY = 550;
            this.SigmaY = 25;
            this.DeltaZ = -494;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -14;
            this.Domain.Left = -7;
            this.Domain.Bottom = -18;
            this.Domain.Right = -4;
        }
    }
}


