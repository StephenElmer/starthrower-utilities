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
    /// NGIA GeoTrans: INDIAN, Bangladesh
    /// Ellipsoid: Everest_Adjustment_1937,  DeltaX: 282,  SigmaX: 10,  DeltaY: 726,  SigmaY: 8,  DeltaZ: 254,  SigmaZ: 12,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 33,  South: 15,  East: 100,  West: 80
    /// </summary>
    public class IndianBangledesh : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal IndianBangledesh()
        {
            this.Ellipsoid = new Ellipsoids.EverestAdjustment1937();
            this.DeltaX = 282;
            this.SigmaX = 10;
            this.DeltaY = 726;
            this.SigmaY = 8;
            this.DeltaZ = 254;
            this.SigmaZ = 12;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 33;
            this.Domain.Left = 80;
            this.Domain.Bottom = 15;
            this.Domain.Right = 100;
        }
    }
}
