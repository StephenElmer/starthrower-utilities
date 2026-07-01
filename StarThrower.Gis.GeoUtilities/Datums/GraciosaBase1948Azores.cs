// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: GRACIOSA BASE SW 1948, Azores
    /// Ellipsoid: International_1924,  DeltaX: -104,  SigmaX: 3,  DeltaY: 167,  SigmaY: 3,  DeltaZ: -38,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 41,  South: 37,  East: -26,  West: -30
    /// </summary>
    public class GraciosaBase1948Azores : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal GraciosaBase1948Azores()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -104;
            this.SigmaX = 3;
            this.DeltaY = 167;
            this.SigmaY = 3;
            this.DeltaZ = -38;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 41;
            this.Domain.Left = -30;
            this.Domain.Bottom = 37;
            this.Domain.Right = -26;
        }
    }
}


