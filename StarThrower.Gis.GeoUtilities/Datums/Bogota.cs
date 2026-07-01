// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: Bogota_To_WGS_1984
    /// NGIA GeoTrans: BOGOTA OBSERVATORY, Colombia
    /// Ellipsoid: International_1924,  DeltaX: 307,  SigmaX: 6,  DeltaY: 304,  SigmaY: 5,  DeltaZ: -318,  SigmaZ: 6,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 16,  South: -10,  East: -61,  West: -85
    /// </summary>
    public class Bogota : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Bogota()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = 307;
            this.SigmaX = 6;
            this.DeltaY = 304;
            this.SigmaY = 5;
            this.DeltaZ = -318;
            this.SigmaZ = 6;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 16;
            this.Domain.Left = -85;
            this.Domain.Bottom = -10;
            this.Domain.Right = -61;
        }
    }
}


