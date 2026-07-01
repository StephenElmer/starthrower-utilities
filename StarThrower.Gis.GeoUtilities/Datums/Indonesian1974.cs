// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: INDONESIAN 1974
    /// Ellipsoid: Indonesian,  DeltaX: -24,  SigmaX: 25,  DeltaY: -15,  SigmaY: 25,  DeltaZ: 5,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 11,  South: -16,  East: 146,  West: 89
    /// </summary>
    public class Indonesian1974 : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Indonesian1974()
        {
            this.Ellipsoid = new Ellipsoids.Indonesian();
            this.DeltaX = -24;
            this.SigmaX = 25;
            this.DeltaY = -15;
            this.SigmaY = 25;
            this.DeltaZ = 5;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 11;
            this.Domain.Left = 89;
            this.Domain.Bottom = -16;
            this.Domain.Right = 146;
        }
    }
}


