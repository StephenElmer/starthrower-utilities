// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: MIDWAY ASTRO 1961, Midway Is.
    /// Ellipsoid: International_1924,  DeltaX: 403,  SigmaX: 25,  DeltaY: -81,  SigmaY: 25,  DeltaZ: 277,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 30,  South: 25,  East: -169,  West: -180
    /// </summary>
    public class MidwayIsland1961 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal MidwayIsland1961()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = 403;
            this.SigmaX = 25;
            this.DeltaY = -81;
            this.SigmaY = 25;
            this.DeltaZ = 277;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 30;
            this.Domain.Left = -180;
            this.Domain.Bottom = 25;
            this.Domain.Right = -169;
        }
    }
}


