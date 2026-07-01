// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: KERGUELEN ISLAND 1949
    /// Ellipsoid: International_1924,  DeltaX: 145,  SigmaX: 25,  DeltaY: -187,  SigmaY: 25,  DeltaZ: 103,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -47,  South: -52,  East: 74,  West: 65
    /// </summary>
    public class KerguelenIsland1949 : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal KerguelenIsland1949()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = 145;
            this.SigmaX = 25;
            this.DeltaY = -187;
            this.SigmaY = 25;
            this.DeltaZ = 103;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -47;
            this.Domain.Left = 65;
            this.Domain.Bottom = -52;
            this.Domain.Right = 74;
        }
    }
}


