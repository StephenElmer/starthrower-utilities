/***********************************************************************************
    StarThrower Utilities
    Copyright (C) 2005-2007  Steve Elmer

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
    /// NGIA GeoTrans: INDIAN 1960, Con Son Island
    /// Ellipsoid: Everest_Adjustment_1937,  DeltaX: 182,  SigmaX: 25,  DeltaY: 915,  SigmaY: 25,  DeltaZ: 344,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 11,  South: 6,  East: 109,  West: 104
    /// </summary>
    public class IndianConSonIsland1960 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal IndianConSonIsland1960()
        {
            this.Ellipsoid = new Ellipsoids.EverestAdjustment1937();
            this.DeltaX = 182;
            this.SigmaX = 25;
            this.DeltaY = 915;
            this.SigmaY = 25;
            this.DeltaZ = 344;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 11;
            this.Domain.Left = 104;
            this.Domain.Bottom = 6;
            this.Domain.Right = 109;
        }
    }
}
