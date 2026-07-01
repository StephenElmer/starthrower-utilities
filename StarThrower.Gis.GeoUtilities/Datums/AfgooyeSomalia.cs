// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: Afgooye_to_WGS_1984
    /// NGIA GeoTrans: AFGOOYE, Somalia
    /// Ellipsoid: Krasovsky_1940,  DeltaX: -43,  SigmaX: 25,  DeltaY: -163,  SigmaY: 25,  DeltaZ: 45,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 19,  South: -8,  East: 60,  West: 35
    /// </summary>
    public class AfgooyeSomalia : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal AfgooyeSomalia()
        {
            this.Ellipsoid = new Ellipsoids.Krasovsky1940();
            this.DeltaX = -43;
            this.SigmaX = 25;
            this.DeltaY = -163;
            this.SigmaY = 25;
            this.DeltaZ = 45;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 19;
            this.Domain.Left = 35;
            this.Domain.Bottom = -8;
            this.Domain.Right = 60;
        }
    }
}


