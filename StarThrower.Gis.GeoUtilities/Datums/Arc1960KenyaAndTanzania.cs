// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: Arc_1960_To_WGS_1984
    /// NGIA GeoTrans: ARC 1960, Kenya and Tanzania
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -160,  SigmaX: 20,  DeltaY: -6,  SigmaY: 20,  DeltaZ: -302,  SigmaZ: 20,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 8,  South: -18,  East: 47,  West: 23
    /// </summary>
    public class Arc1960KenyaAndTanzania : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Arc1960KenyaAndTanzania()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -160;
            this.SigmaX = 20;
            this.DeltaY = -6;
            this.SigmaY = 20;
            this.DeltaZ = -302;
            this.SigmaZ = 20;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 8;
            this.Domain.Left = 23;
            this.Domain.Bottom = -18;
            this.Domain.Right = 47;
        }
    }
}


