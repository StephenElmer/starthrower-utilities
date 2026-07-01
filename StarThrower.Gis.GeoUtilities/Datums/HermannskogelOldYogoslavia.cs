// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: HERMANNSKOGEL, old Yugoslavia
    /// Ellipsoid: Bessel_1841,  DeltaX: 682,  SigmaX: -1,  DeltaY: -203,  SigmaY: -1,  DeltaZ: 480,  SigmaZ: -1,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 52,  South: 35,  East: 29,  West: 7
    /// </summary>
    public class HermannskogelOldYogoslavia : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal HermannskogelOldYogoslavia()
        {
            this.Ellipsoid = new Ellipsoids.Bessel1841();
            this.DeltaX = 682;
            this.SigmaX = -1;
            this.DeltaY = -203;
            this.SigmaY = -1;
            this.DeltaZ = 480;
            this.SigmaZ = -1;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 52;
            this.Domain.Left = 7;
            this.Domain.Bottom = 35;
            this.Domain.Right = 29;
        }
    }
}


