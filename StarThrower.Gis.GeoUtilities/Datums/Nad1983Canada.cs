// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: NORTH AMERICAN 1983, Canada
    /// Ellipsoid: GRS_1980,  DeltaX: 0,  SigmaX: 2,  DeltaY: 0,  SigmaY: 2,  DeltaZ: 0,  SigmaZ: 2,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 90,  South: 36,  East: -50,  West: -150
    /// </summary>
    public class Nad1983Canada : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1983Canada()
        {
            this.Ellipsoid = new Ellipsoids.Grs1980();
            this.DeltaX = 0;
            this.SigmaX = 2;
            this.DeltaY = 0;
            this.SigmaY = 2;
            this.DeltaZ = 0;
            this.SigmaZ = 2;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 90;
            this.Domain.Left = -150;
            this.Domain.Bottom = 36;
            this.Domain.Right = -50;
        }
    }
}


