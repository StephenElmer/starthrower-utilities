// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: NORTH AMERICAN 1927, Cuba
    /// Ellipsoid: Clarke_1866,  DeltaX: -9,  SigmaX: 25,  DeltaY: 152,  SigmaY: 25,  DeltaZ: 178,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 25,  South: 18,  East: -72,  West: -87
    /// </summary>
    public class Nad1927Cuba : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1927Cuba()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = -9;
            this.SigmaX = 25;
            this.DeltaY = 152;
            this.SigmaY = 25;
            this.DeltaZ = 178;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 25;
            this.Domain.Left = -87;
            this.Domain.Bottom = 18;
            this.Domain.Right = -72;
        }
    }
}


