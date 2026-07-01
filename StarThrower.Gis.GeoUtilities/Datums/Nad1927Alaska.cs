// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: NORTH AMERICAN 1927, Alaska
    /// Ellipsoid: Clarke_1866,  DeltaX: -5,  SigmaX: 5,  DeltaY: 135,  SigmaY: 9,  DeltaZ: 172,  SigmaZ: 5,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 78,  South: 47,  East: -130,  West: -175
    /// </summary>
    public class Nad1927Alaska : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1927Alaska()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = -5;
            this.SigmaX = 5;
            this.DeltaY = 135;
            this.SigmaY = 9;
            this.DeltaZ = 172;
            this.SigmaZ = 5;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 78;
            this.Domain.Left = -175;
            this.Domain.Bottom = 47;
            this.Domain.Right = -130;
        }
    }
}


