// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: Bissau_To_WGS_1984
    /// NGIA GeoTrans: BISSAU, Guinea-Bissau
    /// Ellipsoid: International_1924,  DeltaX: -173,  SigmaX: 25,  DeltaY: 253,  SigmaY: 25,  DeltaZ: 27,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 19,  South: 5,  East: -7,  West: -23
    /// </summary>
    public class Bissau : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Bissau()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -173;
            this.SigmaX = 25;
            this.DeltaY = 253;
            this.SigmaY = 25;
            this.DeltaZ = 27;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 19;
            this.Domain.Left = -23;
            this.Domain.Bottom = 5;
            this.Domain.Right = -7;
        }
    }
}


