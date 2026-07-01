// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: SIRGAS, South America
    /// Ellipsoid: GRS_1980,  DeltaX: 0,  SigmaX: 1,  DeltaY: 0,  SigmaY: 1,  DeltaZ: 0,  SigmaZ: 1,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -50,  South: -65,  East: -25,  West: -90
    /// </summary>
    public class SirgasSouthAmerican : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal SirgasSouthAmerican()
        {
            this.Ellipsoid = new Ellipsoids.Grs1980();
            this.DeltaX = 0;
            this.SigmaX = 1;
            this.DeltaY = 0;
            this.SigmaY = 1;
            this.DeltaZ = 0;
            this.SigmaZ = 1;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -50;
            this.Domain.Left = -90;
            this.Domain.Bottom = -65;
            this.Domain.Right = -25;
        }
    }
}


