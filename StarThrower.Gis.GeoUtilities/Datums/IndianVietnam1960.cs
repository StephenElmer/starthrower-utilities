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
    /// NGIA GeoTrans: INDIAN 1960, Vietnam 16N
    /// Ellipsoid: Everest_Adjustment_1937,  DeltaX: 198,  SigmaX: 25,  DeltaY: 881,  SigmaY: 25,  DeltaZ: 317,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 30,  South: 2,  East: 115,  West: 101
    /// </summary>
    public class IndianVietnam1960 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal IndianVietnam1960()
        {
            this.Ellipsoid = new Ellipsoids.EverestAdjustment1937();
            this.DeltaX = 198;
            this.SigmaX = 25;
            this.DeltaY = 881;
            this.SigmaY = 25;
            this.DeltaZ = 317;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 30;
            this.Domain.Left = 101;
            this.Domain.Bottom = 2;
            this.Domain.Right = 115;
        }
    }
}


