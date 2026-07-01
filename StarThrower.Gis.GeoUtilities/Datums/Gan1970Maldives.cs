// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: GAN 1970, Rep. of Maldives
    /// Ellipsoid: International_1924,  DeltaX: -133,  SigmaX: 25,  DeltaY: -321,  SigmaY: 25,  DeltaZ: 50,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 9,  South: -2,  East: 75,  West: 71
    /// </summary>
    public class Gan1970Maldives : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Gan1970Maldives()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -133;
            this.SigmaX = 25;
            this.DeltaY = -321;
            this.SigmaY = 25;
            this.DeltaZ = 50;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 9;
            this.Domain.Left = 71;
            this.Domain.Bottom = -2;
            this.Domain.Right = 75;
        }
    }
}


