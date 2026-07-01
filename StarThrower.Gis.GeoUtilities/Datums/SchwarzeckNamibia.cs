// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: SCHWARZECK, Namibia
    /// Ellipsoid: Bessel_Namibia,  DeltaX: 616,  SigmaX: 20,  DeltaY: 97,  SigmaY: 20,  DeltaZ: -251,  SigmaZ: 20,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -11,  South: -35,  East: 31,  West: 5
    /// </summary>
    public class SchwarzeckNamibia : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal SchwarzeckNamibia()
        {
            this.Ellipsoid = new Ellipsoids.BesselNamibia();
            this.DeltaX = 616;
            this.SigmaX = 20;
            this.DeltaY = 97;
            this.SigmaY = 20;
            this.DeltaZ = -251;
            this.SigmaZ = 20;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -11;
            this.Domain.Left = 5;
            this.Domain.Bottom = -35;
            this.Domain.Right = 31;
        }
    }
}


