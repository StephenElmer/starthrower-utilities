// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: NORTH AMERICAN 1927, Alberta/BC
    /// Ellipsoid: Clarke_1866,  DeltaX: -7,  SigmaX: 8,  DeltaY: 162,  SigmaY: 8,  DeltaZ: 188,  SigmaZ: 6,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 65,  South: 43,  East: -105,  West: -145
    /// </summary>
    public class Nad1927AlbertaBc : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1927AlbertaBc()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = -7;
            this.SigmaX = 8;
            this.DeltaY = 162;
            this.SigmaY = 8;
            this.DeltaZ = 188;
            this.SigmaZ = 6;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 65;
            this.Domain.Left = -145;
            this.Domain.Bottom = 43;
            this.Domain.Right = -105;
        }
    }
}


