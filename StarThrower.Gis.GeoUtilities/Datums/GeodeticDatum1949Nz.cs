// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: GEODETIC DATUM 1949, NZ
    /// Ellipsoid: International_1924,  DeltaX: 84,  SigmaX: 5,  DeltaY: -22,  SigmaY: 3,  DeltaZ: 209,  SigmaZ: 5,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -33,  South: -48,  East: 180,  West: 165
    /// </summary>
    public class GeodeticDatum1949Nz : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal GeodeticDatum1949Nz()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = 84;
            this.SigmaX = 5;
            this.DeltaY = -22;
            this.SigmaY = 3;
            this.DeltaZ = 209;
            this.SigmaZ = 5;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -33;
            this.Domain.Left = 165;
            this.Domain.Bottom = -48;
            this.Domain.Right = 180;
        }
    }
}


