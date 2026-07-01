// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: CAPE CANAVERAL, Fla and Bahamas
    /// Ellipsoid: Clarke_1866,  DeltaX: -2,  SigmaX: 3,  DeltaY: 151,  SigmaY: 3,  DeltaZ: 181,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 38,  South: 15,  East: -58,  West: -94
    /// </summary>
    public class CapeCanaveral : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal CapeCanaveral()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = -2;
            this.SigmaX = 3;
            this.DeltaY = 151;
            this.SigmaY = 3;
            this.DeltaZ = 181;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 38;
            this.Domain.Left = -94;
            this.Domain.Bottom = 15;
            this.Domain.Right = -58;
        }
    }
}


