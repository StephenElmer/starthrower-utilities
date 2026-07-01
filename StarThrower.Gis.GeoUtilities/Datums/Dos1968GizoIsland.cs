// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: DOS 1968, Gizo Island
    /// Ellipsoid: International_1924,  DeltaX: 230,  SigmaX: 25,  DeltaY: -199,  SigmaY: 25,  DeltaZ: -752,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -7,  South: -10,  East: 158,  West: 155
    /// </summary>
    public class Dos1968GizoIsland : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Dos1968GizoIsland()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = 230;
            this.SigmaX = 25;
            this.DeltaY = -199;
            this.SigmaY = 25;
            this.DeltaZ = -752;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -7;
            this.Domain.Left = 155;
            this.Domain.Bottom = -10;
            this.Domain.Right = 158;
        }
    }
}


