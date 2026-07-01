// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: NORTH AMERICAN 1927, C. America
    /// Ellipsoid: Clarke_1866,  DeltaX: 0,  SigmaX: 8,  DeltaY: 125,  SigmaY: 3,  DeltaZ: 194,  SigmaZ: 5,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 25,  South: 3,  East: -77,  West: -98
    /// </summary>
    public class Nad1927CentralAmerica : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1927CentralAmerica()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = 0;
            this.SigmaX = 8;
            this.DeltaY = 125;
            this.SigmaY = 3;
            this.DeltaZ = 194;
            this.SigmaZ = 5;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 25;
            this.Domain.Left = -98;
            this.Domain.Bottom = 3;
            this.Domain.Right = -77;
        }
    }
}


