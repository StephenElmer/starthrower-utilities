// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: REUNION, Mascarene Is.
    /// Ellipsoid: International_1924,  DeltaX: 94,  SigmaX: 25,  DeltaY: -948,  SigmaY: 25,  DeltaZ: -1262,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -12,  South: -27,  East: 65,  West: 47
    /// </summary>
    public class ReunionMascareneIsland : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal ReunionMascareneIsland()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = 94;
            this.SigmaX = 25;
            this.DeltaY = -948;
            this.SigmaY = 25;
            this.DeltaZ = -1262;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -12;
            this.Domain.Left = 47;
            this.Domain.Bottom = -27;
            this.Domain.Right = 65;
        }
    }
}


