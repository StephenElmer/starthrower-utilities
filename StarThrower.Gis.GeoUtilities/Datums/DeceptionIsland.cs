// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: DECEPTION ISLAND
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: 260,  SigmaX: 20,  DeltaY: 12,  SigmaY: 20,  DeltaZ: -147,  SigmaZ: 20,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -62,  South: -65,  East: -58,  West: -62
    /// </summary>
    public class DeceptionIsland : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal DeceptionIsland()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = 260;
            this.SigmaX = 20;
            this.DeltaY = 12;
            this.SigmaY = 20;
            this.DeltaZ = -147;
            this.SigmaZ = 20;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -62;
            this.Domain.Left = -62;
            this.Domain.Bottom = -65;
            this.Domain.Right = -58;
        }
    }
}


