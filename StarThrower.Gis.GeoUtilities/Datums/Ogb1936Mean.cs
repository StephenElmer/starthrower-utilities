// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: ORDNANCE GB 1936, Mean (3 Para)
    /// Ellipsoid: Airy_1830,  DeltaX: 375,  SigmaX: 10,  DeltaY: -111,  SigmaY: 10,  DeltaZ: 431,  SigmaZ: 15,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 66,  South: 44,  East: 7,  West: -14
    /// </summary>
    public class Ogb1936Mean : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Ogb1936Mean()
        {
            this.Ellipsoid = new Ellipsoids.Airy1830();
            this.DeltaX = 375;
            this.SigmaX = 10;
            this.DeltaY = -111;
            this.SigmaY = 10;
            this.DeltaZ = 431;
            this.SigmaZ = 15;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 66;
            this.Domain.Left = -14;
            this.Domain.Bottom = 44;
            this.Domain.Right = 7;
        }
    }
}


