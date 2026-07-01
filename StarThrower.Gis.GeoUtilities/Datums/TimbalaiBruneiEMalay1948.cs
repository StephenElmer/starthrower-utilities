// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: TIMBALAI 1948, Brunei and E Malay
    /// Ellipsoid: Everest_Definition_1967,  DeltaX: -679,  SigmaX: 10,  DeltaY: 669,  SigmaY: 10,  DeltaZ: -48,  SigmaZ: 12,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 15,  South: -5,  East: 125,  West: 101
    /// </summary>
    public class TimbalaiBruneiEMalay1948 : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal TimbalaiBruneiEMalay1948()
        {
            this.Ellipsoid = new Ellipsoids.EverestDefinition1967();
            this.DeltaX = -679;
            this.SigmaX = 10;
            this.DeltaY = 669;
            this.SigmaY = 10;
            this.DeltaZ = -48;
            this.SigmaZ = 12;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 15;
            this.Domain.Left = 101;
            this.Domain.Bottom = -5;
            this.Domain.Right = 125;
        }
    }
}


