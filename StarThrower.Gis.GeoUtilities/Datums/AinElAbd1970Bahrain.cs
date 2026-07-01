// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: Ain_El_Abd_To_WGS_1984_1
    /// NGIA GeoTrans: AIN EL ABD 1970, Bahrain
    /// Ellipsoid: International_1924,  DeltaX: -150,  SigmaX: 25,  DeltaY: -250,  SigmaY: 25,  DeltaZ: -1,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 28,  South: 24,  East: 53,  West: 49
    /// </summary>
    public class AinElAbd1970Bahrain : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal AinElAbd1970Bahrain()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -150;
            this.SigmaX = 25;
            this.DeltaY = -250;
            this.SigmaY = 25;
            this.DeltaZ = -1;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 28;
            this.Domain.Left = 49;
            this.Domain.Bottom = 24;
            this.Domain.Right = 53;
        }
    }
}


