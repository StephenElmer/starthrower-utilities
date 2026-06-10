// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: HERAT NORTH, Afghanistan
    /// Ellipsoid: International_1924,  DeltaX: -333,  SigmaX: -1,  DeltaY: -222,  SigmaY: -1,  DeltaZ: 114,  SigmaZ: -1,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 44,  South: 23,  East: 81,  West: 55
    /// </summary>
    public class HeratNorthAfghanistan : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal HeratNorthAfghanistan()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -333;
            this.SigmaX = -1;
            this.DeltaY = -222;
            this.SigmaY = -1;
            this.DeltaZ = 114;
            this.SigmaZ = -1;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 44;
            this.Domain.Left = 55;
            this.Domain.Bottom = 23;
            this.Domain.Right = 81;
        }
    }
}


