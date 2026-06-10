// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: Bermuda_1957_To_WGS_1984
    /// NGIA GeoTrans: BERMUDA 1957, Bermuda Islands
    /// Ellipsoid: Clarke_1866,  DeltaX: -73,  SigmaX: 20,  DeltaY: 213,  SigmaY: 20,  DeltaZ: 296,  SigmaZ: 20,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 34,  South: 31,  East: -63,  West: -66
    /// </summary>
    public class Bermuda1957 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Bermuda1957()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = -73;
            this.SigmaX = 20;
            this.DeltaY = 213;
            this.SigmaY = 20;
            this.DeltaZ = 296;
            this.SigmaZ = 20;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 34;
            this.Domain.Left = -66;
            this.Domain.Bottom = 31;
            this.Domain.Right = -63;
        }
    }
}


