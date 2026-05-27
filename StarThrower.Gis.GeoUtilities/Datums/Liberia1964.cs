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
    /// NGIA GeoTrans: LIBERIA 1964
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -90,  SigmaX: 15,  DeltaY: 40,  SigmaY: 15,  DeltaZ: 88,  SigmaZ: 15,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 14,  South: -1,  East: -1,  West: -17
    /// </summary>
    public class Liberia1964 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Liberia1964()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -90;
            this.SigmaX = 15;
            this.DeltaY = 40;
            this.SigmaY = 15;
            this.DeltaZ = 88;
            this.SigmaZ = 15;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 14;
            this.Domain.Left = -17;
            this.Domain.Bottom = -1;
            this.Domain.Right = -1;
        }
    }
}
