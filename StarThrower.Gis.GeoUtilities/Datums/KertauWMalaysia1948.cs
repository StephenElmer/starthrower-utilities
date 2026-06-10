// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: KERTAU 1948, w Malaysia and Sing.
    /// Ellipsoid: Everest_1830_Modified,  DeltaX: -11,  SigmaX: 10,  DeltaY: 851,  SigmaY: 8,  DeltaZ: 5,  SigmaZ: 6,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 12,  South: -5,  East: 112,  West: 94
    /// </summary>
    public class KertauWMalaysia1948 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal KertauWMalaysia1948()
        {
            this.Ellipsoid = new Ellipsoids.Everest1830Modified();
            this.DeltaX = -11;
            this.SigmaX = 10;
            this.DeltaY = 851;
            this.SigmaY = 8;
            this.DeltaZ = 5;
            this.SigmaZ = 6;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 12;
            this.Domain.Left = 94;
            this.Domain.Bottom = -5;
            this.Domain.Right = 112;
        }
    }
}


