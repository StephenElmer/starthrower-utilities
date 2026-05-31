/***********************************************************************************
    StarThrower Utilities / Gis.GeoUtilities
    Copyright (C) 2005-2026  Stephen Elmer

    This library is free software; you can redistribute it and/or
    modify it under the terms of the GNU Lesser General Public
    License as published by the Free Software Foundation; either
    version 2.1 of the License, or (at your option) any later version.

    This library is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
    Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public
    License along with this library; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
***********************************************************************************/

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: KANDAWALA, Sri Lanka
    /// Ellipsoid: Everest_Adjustment_1937,  DeltaX: -97,  SigmaX: 20,  DeltaY: 787,  SigmaY: 20,  DeltaZ: 86,  SigmaZ: 20,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 12,  South: 4,  East: 85,  West: 77
    /// </summary>
    public class KandawalaSriLanka : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal KandawalaSriLanka()
        {
            this.Ellipsoid = new Ellipsoids.EverestAdjustment1937();
            this.DeltaX = -97;
            this.SigmaX = 20;
            this.DeltaY = 787;
            this.SigmaY = 20;
            this.DeltaZ = 86;
            this.SigmaZ = 20;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 12;
            this.Domain.Left = 77;
            this.Domain.Bottom = 4;
            this.Domain.Right = 85;
        }
    }
}


