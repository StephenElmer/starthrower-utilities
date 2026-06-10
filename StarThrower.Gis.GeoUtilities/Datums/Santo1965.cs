// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: SANTO (DOS) 1965
    /// Ellipsoid: International_1924,  DeltaX: 170,  SigmaX: 25,  DeltaY: 42,  SigmaY: 25,  DeltaZ: 84,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -11,  South: -20,  East: 172,  West: 163
    /// </summary>
    public class Santo1965 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Santo1965()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = 170;
            this.SigmaX = 25;
            this.DeltaY = 42;
            this.SigmaY = 25;
            this.DeltaZ = 84;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -11;
            this.Domain.Left = 163;
            this.Domain.Bottom = -20;
            this.Domain.Right = 172;
        }
    }
}


