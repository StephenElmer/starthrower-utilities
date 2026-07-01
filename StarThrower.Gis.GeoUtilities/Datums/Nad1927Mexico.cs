// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: NORTH AMERICAN 1927, Mexico
    /// Ellipsoid: Clarke_1866,  DeltaX: -12,  SigmaX: 8,  DeltaY: 130,  SigmaY: 6,  DeltaZ: 190,  SigmaZ: 6,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 38,  South: 10,  East: -80,  West: -122
    /// </summary>
    public class Nad1927Mexico : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1927Mexico()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = -12;
            this.SigmaX = 8;
            this.DeltaY = 130;
            this.SigmaY = 6;
            this.DeltaZ = 190;
            this.SigmaZ = 6;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 38;
            this.Domain.Left = -122;
            this.Domain.Bottom = 10;
            this.Domain.Right = -80;
        }
    }
}


