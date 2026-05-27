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
    /// NGIA GeoTrans: INDIAN 1975, Thailand
    /// Ellipsoid: Everest_Adjustment_1937,  DeltaX: 209,  SigmaX: 12,  DeltaY: 818,  SigmaY: 10,  DeltaZ: 290,  SigmaZ: 12,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 27,  South: 0,  East: 111,  West: 91
    /// </summary>
    public class IndianThailand1975 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal IndianThailand1975()
        {
            this.Ellipsoid = new Ellipsoids.EverestAdjustment1937();
            this.DeltaX = 209;
            this.SigmaX = 12;
            this.DeltaY = 818;
            this.SigmaY = 10;
            this.DeltaZ = 290;
            this.SigmaZ = 12;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 27;
            this.Domain.Left = 91;
            this.Domain.Bottom = 0;
            this.Domain.Right = 111;
        }
    }
}
