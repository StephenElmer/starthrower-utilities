// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: NORTH AMERICAN 1927, Man/Ont
    /// Ellipsoid: Clarke_1866,  DeltaX: -9,  SigmaX: 9,  DeltaY: 157,  SigmaY: 5,  DeltaZ: 184,  SigmaZ: 5,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 63,  South: 36,  East: -69,  West: -108
    /// </summary>
    public class Nad1927ManitobaOntario : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1927ManitobaOntario()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = -9;
            this.SigmaX = 9;
            this.DeltaY = 157;
            this.SigmaY = 5;
            this.DeltaZ = 184;
            this.SigmaZ = 5;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 63;
            this.Domain.Left = -108;
            this.Domain.Bottom = 36;
            this.Domain.Right = -69;
        }
    }
}


