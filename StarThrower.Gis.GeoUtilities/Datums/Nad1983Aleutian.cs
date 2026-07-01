// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: NORTH AMERICAN 1983, Aleutian
    /// Ellipsoid: GRS_1980,  DeltaX: -2,  SigmaX: 5,  DeltaY: 0,  SigmaY: 2,  DeltaZ: 4,  SigmaZ: 5,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 74,  South: 51,  East: 180,  West: -180
    /// </summary>
    public class Nad1983Aleutian : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1983Aleutian()
        {
            this.Ellipsoid = new Ellipsoids.Grs1980();
            this.DeltaX = -2;
            this.SigmaX = 5;
            this.DeltaY = 0;
            this.SigmaY = 2;
            this.DeltaZ = 4;
            this.SigmaZ = 5;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 74;
            this.Domain.Left = -180;
            this.Domain.Bottom = 51;
            this.Domain.Right = 180;
        }
    }
}


