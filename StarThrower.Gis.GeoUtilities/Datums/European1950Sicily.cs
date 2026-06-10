// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: EUROPEAN 1950, Sicily(Italy)
    /// Ellipsoid: International_1924,  DeltaX: -97,  SigmaX: 20,  DeltaY: -88,  SigmaY: 20,  DeltaZ: -135,  SigmaZ: 20,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 40,  South: 35,  East: 17,  West: 10
    /// </summary>
    public class European1950Sicily : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal European1950Sicily()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -97;
            this.SigmaX = 20;
            this.DeltaY = -88;
            this.SigmaY = 20;
            this.DeltaZ = -135;
            this.SigmaZ = 20;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 40;
            this.Domain.Left = 10;
            this.Domain.Bottom = 35;
            this.Domain.Right = 17;
        }
    }
}


