// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: GUX 1 ASTRO, Guadalcanal Is.
    /// Ellipsoid: International_1924,  DeltaX: 252,  SigmaX: 25,  DeltaY: -209,  SigmaY: 25,  DeltaZ: -751,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -8,  South: -12,  East: 163,  West: 158
    /// </summary>
    public class GuadalcanalIsland : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal GuadalcanalIsland()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = 252;
            this.SigmaX = 25;
            this.DeltaY = -209;
            this.SigmaY = 25;
            this.DeltaZ = -751;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -8;
            this.Domain.Left = 158;
            this.Domain.Bottom = -12;
            this.Domain.Right = 163;
        }
    }
}


