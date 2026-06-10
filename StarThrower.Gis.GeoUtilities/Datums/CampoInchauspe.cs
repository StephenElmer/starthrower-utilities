// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: Campo_Inchauspe_To_WGS_1984
    /// NGIA GeoTrans: CAMPO INCHAUSPE 1969, Arg.
    /// Ellipsoid: International_1924,  DeltaX: -148,  SigmaX: 5,  DeltaY: 136,  SigmaY: 5,  DeltaZ: 90,  SigmaZ: 5,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -20,  South: -62,  East: -47,  West: -76
    /// </summary>
    public class CampoInchauspe : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal CampoInchauspe()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -148;
            this.SigmaX = 5;
            this.DeltaY = 136;
            this.SigmaY = 5;
            this.DeltaZ = 90;
            this.SigmaZ = 5;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -20;
            this.Domain.Left = -76;
            this.Domain.Bottom = -62;
            this.Domain.Right = -47;
        }
    }
}


