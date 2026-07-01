// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: BUKIT RIMPAH, Banka and Belitung
    /// Ellipsoid: Bessel_1841,  DeltaX: -384,  SigmaX: -1,  DeltaY: 664,  SigmaY: -1,  DeltaZ: -48,  SigmaZ: -1,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 0,  South: -6,  East: 110,  West: 103
    /// </summary>
    public class BukitRimpah : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal BukitRimpah()
        {
            this.Ellipsoid = new Ellipsoids.Bessel1841();
            this.DeltaX = -384;
            this.SigmaX = -1;
            this.DeltaY = 664;
            this.SigmaY = -1;
            this.DeltaZ = -48;
            this.SigmaZ = -1;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 0;
            this.Domain.Left = 103;
            this.Domain.Bottom = -6;
            this.Domain.Right = 110;
        }
    }
}


