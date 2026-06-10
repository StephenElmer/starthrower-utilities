// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: IRELAND 1965
    /// Ellipsoid: Airy_Modified,  DeltaX: 506,  SigmaX: 3,  DeltaY: -122,  SigmaY: 3,  DeltaZ: 611,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 57,  South: 50,  East: -4,  West: -12
    /// </summary>
    public class Ireland1965 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Ireland1965()
        {
            this.Ellipsoid = new Ellipsoids.AiryModified();
            this.DeltaX = 506;
            this.SigmaX = 3;
            this.DeltaY = -122;
            this.SigmaY = 3;
            this.DeltaZ = 611;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 57;
            this.Domain.Left = -12;
            this.Domain.Bottom = 50;
            this.Domain.Right = -4;
        }
    }
}


