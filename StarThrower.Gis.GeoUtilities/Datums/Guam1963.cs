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
    /// NGIA GeoTrans: GUAM 1963
    /// Ellipsoid: Clarke_1866,  DeltaX: -100,  SigmaX: 3,  DeltaY: -248,  SigmaY: 3,  DeltaZ: 259,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 15,  South: 12,  East: 146,  West: 143
    /// </summary>
    public class Guam1963 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Guam1963()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = -100;
            this.SigmaX = 3;
            this.DeltaY = -248;
            this.SigmaY = 3;
            this.DeltaZ = 259;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 15;
            this.Domain.Left = 143;
            this.Domain.Bottom = 12;
            this.Domain.Right = 146;
        }
    }
}
