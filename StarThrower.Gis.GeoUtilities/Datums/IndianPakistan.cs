// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: INDIAN, Pakistan
    /// Ellipsoid: Everest_Pakistan,  DeltaX: 283,  SigmaX: -1,  DeltaY: 682,  SigmaY: -1,  DeltaZ: 231,  SigmaZ: -1,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 44,  South: 17,  East: 81,  West: 55
    /// </summary>
    public class IndianPakistan : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal IndianPakistan()
        {
            this.Ellipsoid = new Ellipsoids.EverestPakistan();
            this.DeltaX = 283;
            this.SigmaX = -1;
            this.DeltaY = 682;
            this.SigmaY = -1;
            this.DeltaZ = 231;
            this.SigmaZ = -1;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 44;
            this.Domain.Left = 55;
            this.Domain.Bottom = 17;
            this.Domain.Right = 81;
        }
    }
}


