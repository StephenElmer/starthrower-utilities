// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: PUERTO RICO and Virgin Is.
    /// Ellipsoid: Clarke_1866,  DeltaX: 11,  SigmaX: 3,  DeltaY: 72,  SigmaY: 3,  DeltaZ: -101,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 20,  South: 16,  East: -63,  West: -69
    /// </summary>
    public class PuertoRicoVirginIslands : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal PuertoRicoVirginIslands()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = 11;
            this.SigmaX = 3;
            this.DeltaY = 72;
            this.SigmaY = 3;
            this.DeltaZ = -101;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 20;
            this.Domain.Left = -69;
            this.Domain.Bottom = 16;
            this.Domain.Right = -63;
        }
    }
}


