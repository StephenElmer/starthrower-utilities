// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: OBSERVATORIO MET. 1939, Flores
    /// Ellipsoid: International_1924,  DeltaX: -425,  SigmaX: 20,  DeltaY: -169,  SigmaY: 20,  DeltaZ: 81,  SigmaZ: 20,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 41,  South: 38,  East: -30,  West: -33
    /// </summary>
    public class Flores1939 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Flores1939()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -425;
            this.SigmaX = 20;
            this.DeltaY = -169;
            this.SigmaY = 20;
            this.DeltaZ = 81;
            this.SigmaZ = 20;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 41;
            this.Domain.Left = -33;
            this.Domain.Bottom = 38;
            this.Domain.Right = -30;
        }
    }
}


