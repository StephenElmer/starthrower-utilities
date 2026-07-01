// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: NORTH AMERICAN 1927, Aleutian E
    /// Ellipsoid: Clarke_1866,  DeltaX: -2,  SigmaX: 6,  DeltaY: 152,  SigmaY: 8,  DeltaZ: 149,  SigmaZ: 10,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 58,  South: 50,  East: -161,  West: -180
    /// </summary>
    public class Nad1927AleutianEast : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1927AleutianEast()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = -2;
            this.SigmaX = 6;
            this.DeltaY = 152;
            this.SigmaY = 8;
            this.DeltaZ = 149;
            this.SigmaZ = 10;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 58;
            this.Domain.Left = -180;
            this.Domain.Bottom = 50;
            this.Domain.Right = -161;
        }
    }
}


