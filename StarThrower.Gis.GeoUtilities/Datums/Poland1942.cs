// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: S-42 (PULKOVO 1942), Poland
    /// Ellipsoid: Krasovsky_1940,  DeltaX: 23,  SigmaX: 4,  DeltaY: -124,  SigmaY: 2,  DeltaZ: -82,  SigmaZ: 4,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 60,  South: 43,  East: 30,  West: 8
    /// </summary>
    public class Poland1942 : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Poland1942()
        {
            this.Ellipsoid = new Ellipsoids.Krasovsky1940();
            this.DeltaX = 23;
            this.SigmaX = 4;
            this.DeltaY = -124;
            this.SigmaY = 2;
            this.DeltaZ = -82;
            this.SigmaZ = 4;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 60;
            this.Domain.Left = 8;
            this.Domain.Bottom = 43;
            this.Domain.Right = 30;
        }
    }
}


