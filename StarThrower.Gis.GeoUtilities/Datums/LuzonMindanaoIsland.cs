// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: LUZON, Mindanao Island
    /// Ellipsoid: Clarke_1866,  DeltaX: -133,  SigmaX: 25,  DeltaY: -79,  SigmaY: 25,  DeltaZ: -72,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 12,  South: 4,  East: 128,  West: 120
    /// </summary>
    public class LuzonMindanaoIsland : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal LuzonMindanaoIsland()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = -133;
            this.SigmaX = 25;
            this.DeltaY = -79;
            this.SigmaY = 25;
            this.DeltaZ = -72;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 12;
            this.Domain.Left = 120;
            this.Domain.Bottom = 4;
            this.Domain.Right = 128;
        }
    }
}


