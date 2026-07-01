// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: ORDNANCE GB 1936, Wales
    /// Ellipsoid: Airy_1830,  DeltaX: 370,  SigmaX: 20,  DeltaY: -108,  SigmaY: 20,  DeltaZ: 434,  SigmaZ: 20,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 59,  South: 46,  East: 3,  West: -11
    /// </summary>
    public class Ogb1936Wales : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Ogb1936Wales()
        {
            this.Ellipsoid = new Ellipsoids.Airy1830();
            this.DeltaX = 370;
            this.SigmaX = 20;
            this.DeltaY = -108;
            this.SigmaY = 20;
            this.DeltaZ = 434;
            this.SigmaZ = 20;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 59;
            this.Domain.Left = -11;
            this.Domain.Bottom = 46;
            this.Domain.Right = 3;
        }
    }
}


