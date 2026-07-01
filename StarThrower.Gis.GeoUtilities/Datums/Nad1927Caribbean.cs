// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: NORTH AMERICAN 1927, Caribbean
    /// Ellipsoid: Clarke_1866,  DeltaX: -3,  SigmaX: 3,  DeltaY: 142,  SigmaY: 9,  DeltaZ: 183,  SigmaZ: 12,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 29,  South: 8,  East: -58,  West: -87
    /// </summary>
    public class Nad1927Caribbean : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1927Caribbean()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = -3;
            this.SigmaX = 3;
            this.DeltaY = 142;
            this.SigmaY = 9;
            this.DeltaZ = 183;
            this.SigmaZ = 12;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 29;
            this.Domain.Left = -87;
            this.Domain.Bottom = 8;
            this.Domain.Right = -58;
        }
    }
}


