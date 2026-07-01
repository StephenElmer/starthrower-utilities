// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: QORNOQ, South Greenland
    /// Ellipsoid: International_1924,  DeltaX: 164,  SigmaX: 25,  DeltaY: 138,  SigmaY: 25,  DeltaZ: -189,  SigmaZ: 32,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 85,  South: 57,  East: -7,  West: -77
    /// </summary>
    public class QornoqSouthGreenland : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal QornoqSouthGreenland()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = 164;
            this.SigmaX = 25;
            this.DeltaY = 138;
            this.SigmaY = 25;
            this.DeltaZ = -189;
            this.SigmaZ = 32;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 85;
            this.Domain.Left = -77;
            this.Domain.Bottom = 57;
            this.Domain.Right = -7;
        }
    }
}


