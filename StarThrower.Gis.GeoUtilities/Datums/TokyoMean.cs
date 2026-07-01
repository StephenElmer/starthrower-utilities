// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: TOKYO, Mean
    /// Ellipsoid: Bessel_1841,  DeltaX: -148,  SigmaX: 20,  DeltaY: 507,  SigmaY: 5,  DeltaZ: 685,  SigmaZ: 20,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 53,  South: 23,  East: 155,  West: 120
    /// </summary>
    public class TokyoMean : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal TokyoMean()
        {
            this.Ellipsoid = new Ellipsoids.Bessel1841();
            this.DeltaX = -148;
            this.SigmaX = 20;
            this.DeltaY = 507;
            this.SigmaY = 5;
            this.DeltaZ = 685;
            this.SigmaZ = 20;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 53;
            this.Domain.Left = 120;
            this.Domain.Bottom = 23;
            this.Domain.Right = 155;
        }
    }
}


