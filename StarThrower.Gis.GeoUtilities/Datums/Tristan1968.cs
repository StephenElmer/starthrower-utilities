// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: TRISTAN ASTRO 1968
    /// Ellipsoid: International_1924,  DeltaX: -632,  SigmaX: 25,  DeltaY: 438,  SigmaY: 25,  DeltaZ: -609,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -36,  South: -39,  East: -11,  West: -14
    /// </summary>
    public class Tristan1968 : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Tristan1968()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -632;
            this.SigmaX = 25;
            this.DeltaY = 438;
            this.SigmaY = 25;
            this.DeltaZ = -609;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -36;
            this.Domain.Left = -14;
            this.Domain.Bottom = -39;
            this.Domain.Right = -11;
        }
    }
}


