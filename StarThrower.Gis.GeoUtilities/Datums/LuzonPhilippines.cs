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
    /// NGIA GeoTrans: LUZON, Philippines
    /// Ellipsoid: Clarke_1866,  DeltaX: -133,  SigmaX: 8,  DeltaY: -77,  SigmaY: 11,  DeltaZ: -51,  SigmaZ: 9,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 23,  South: 3,  East: 128,  West: 115
    /// </summary>
    public class LuzonPhilippines : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal LuzonPhilippines()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = -133;
            this.SigmaX = 8;
            this.DeltaY = -77;
            this.SigmaY = 11;
            this.DeltaZ = -51;
            this.SigmaZ = 9;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 23;
            this.Domain.Left = 115;
            this.Domain.Bottom = 3;
            this.Domain.Right = 128;
        }
    }
}
