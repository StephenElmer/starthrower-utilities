// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: QATAR NATIONAL
    /// Ellipsoid: International_1924,  DeltaX: -128,  SigmaX: 20,  DeltaY: -283,  SigmaY: 20,  DeltaZ: 22,  SigmaZ: 20,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 32,  South: 19,  East: 57,  West: 45
    /// </summary>
    public class QatarNational : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal QatarNational()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -128;
            this.SigmaX = 20;
            this.DeltaY = -283;
            this.SigmaY = 20;
            this.DeltaZ = 22;
            this.SigmaZ = 20;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 32;
            this.Domain.Left = 45;
            this.Domain.Bottom = 19;
            this.Domain.Right = 57;
        }
    }
}


