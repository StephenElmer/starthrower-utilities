// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: INDIAN, India and Nepal
    /// Ellipsoid: Everest_1956_India,  DeltaX: 295,  SigmaX: 12,  DeltaY: 736,  SigmaY: 10,  DeltaZ: 257,  SigmaZ: 15,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 44,  South: 2,  East: 105,  West: 62
    /// </summary>
    public class IndianIndiaNepal : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal IndianIndiaNepal()
        {
            this.Ellipsoid = new Ellipsoids.Everest1956India();
            this.DeltaX = 295;
            this.SigmaX = 12;
            this.DeltaY = 736;
            this.SigmaY = 10;
            this.DeltaZ = 257;
            this.SigmaZ = 15;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 44;
            this.Domain.Left = 62;
            this.Domain.Bottom = 2;
            this.Domain.Right = 105;
        }
    }
}


