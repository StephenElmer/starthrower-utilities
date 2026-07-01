// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: CORREGO ALEGRE, Brazil
    /// Ellipsoid: International_1924,  DeltaX: -206,  SigmaX: 5,  DeltaY: 172,  SigmaY: 3,  DeltaZ: -6,  SigmaZ: 5,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 9,  South: -39,  East: -29,  West: -80
    /// </summary>
    public class CorregoAlegre : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal CorregoAlegre()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -206;
            this.SigmaX = 5;
            this.DeltaY = 172;
            this.SigmaY = 3;
            this.DeltaZ = -6;
            this.SigmaZ = 5;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 9;
            this.Domain.Left = -80;
            this.Domain.Bottom = -39;
            this.Domain.Right = -29;
        }
    }
}


