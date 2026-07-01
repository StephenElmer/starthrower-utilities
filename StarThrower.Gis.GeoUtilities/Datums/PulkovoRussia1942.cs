// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: PULKOVO 1942, Russia
    /// Ellipsoid: Krasovsky_1940,  DeltaX: 28,  SigmaX: -1,  DeltaY: -130,  SigmaY: -1,  DeltaZ: -95,  SigmaZ: -1,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 89,  South: 36,  East: 180,  West: -180
    /// </summary>
    public class PulkovoRussia1942 : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal PulkovoRussia1942()
        {
            this.Ellipsoid = new Ellipsoids.Krasovsky1940();
            this.DeltaX = 28;
            this.SigmaX = -1;
            this.DeltaY = -130;
            this.SigmaY = -1;
            this.DeltaZ = -95;
            this.SigmaZ = -1;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 89;
            this.Domain.Left = -180;
            this.Domain.Bottom = 36;
            this.Domain.Right = 180;
        }
    }
}


