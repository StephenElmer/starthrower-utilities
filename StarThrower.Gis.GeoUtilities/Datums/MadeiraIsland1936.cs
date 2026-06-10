// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: PORTO SANTO 1936, Madeira Is.
    /// Ellipsoid: International_1924,  DeltaX: -499,  SigmaX: 25,  DeltaY: -249,  SigmaY: 25,  DeltaZ: 314,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 35,  South: 31,  East: -15,  West: -18
    /// </summary>
    public class MadeiraIsland1936 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal MadeiraIsland1936()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -499;
            this.SigmaX = 25;
            this.DeltaY = -249;
            this.SigmaY = 25;
            this.DeltaZ = 314;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 35;
            this.Domain.Left = -18;
            this.Domain.Bottom = 31;
            this.Domain.Right = -15;
        }
    }
}


