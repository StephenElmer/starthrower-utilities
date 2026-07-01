// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: ORDNANCE GB 1936, Scotland
    /// Ellipsoid: Airy_1830,  DeltaX: 384,  SigmaX: 10,  DeltaY: -111,  SigmaY: 10,  DeltaZ: 425,  SigmaZ: 10,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 66,  South: 49,  East: 4,  West: -14
    /// </summary>
    public class Ogb1936Scotland : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Ogb1936Scotland()
        {
            this.Ellipsoid = new Ellipsoids.Airy1830();
            this.DeltaX = 384;
            this.SigmaX = 10;
            this.DeltaY = -111;
            this.SigmaY = 10;
            this.DeltaZ = 425;
            this.SigmaZ = 10;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 66;
            this.Domain.Left = -14;
            this.Domain.Bottom = 49;
            this.Domain.Right = 4;
        }
    }
}


