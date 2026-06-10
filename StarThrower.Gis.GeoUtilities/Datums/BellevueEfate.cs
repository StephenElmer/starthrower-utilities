// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: BELLEVUE (IGN), Efate Is.
    /// Ellipsoid: International_1924,  DeltaX: -127,  SigmaX: 20,  DeltaY: -769,  SigmaY: 20,  DeltaZ: 472,  SigmaZ: 20,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -16,  South: -20,  East: 171,  West: 167
    /// </summary>
    public class BellevueEfate : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal BellevueEfate()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -127;
            this.SigmaX = 20;
            this.DeltaY = -769;
            this.SigmaY = 20;
            this.DeltaZ = 472;
            this.SigmaZ = 20;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -16;
            this.Domain.Left = 167;
            this.Domain.Bottom = -20;
            this.Domain.Right = 171;
        }
    }
}


