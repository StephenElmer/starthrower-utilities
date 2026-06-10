// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: ORDNANCE GB 1936, England
    /// Ellipsoid: Airy_1830,  DeltaX: 371,  SigmaX: 5,  DeltaY: -112,  SigmaY: 5,  DeltaZ: 434,  SigmaZ: 6,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 61,  South: 44,  East: 7,  West: -12
    /// </summary>
    public class Ogb1936England : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Ogb1936England()
        {
            this.Ellipsoid = new Ellipsoids.Airy1830();
            this.DeltaX = 371;
            this.SigmaX = 5;
            this.DeltaY = -112;
            this.SigmaY = 5;
            this.DeltaZ = 434;
            this.SigmaZ = 6;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 61;
            this.Domain.Left = -12;
            this.Domain.Bottom = 44;
            this.Domain.Right = 7;
        }
    }
}


