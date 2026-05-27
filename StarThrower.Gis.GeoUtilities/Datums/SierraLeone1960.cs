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
    /// NGIA GeoTrans: SIERRA LEONE 1960
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -88,  SigmaX: 15,  DeltaY: 4,  SigmaY: 15,  DeltaZ: 101,  SigmaZ: 15,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 16,  South: 1,  East: -4,  West: -19
    /// </summary>
    public class SierraLeone1960 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal SierraLeone1960()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -88;
            this.SigmaX = 15;
            this.DeltaY = 4;
            this.SigmaY = 15;
            this.DeltaZ = 101;
            this.SigmaZ = 15;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 16;
            this.Domain.Left = -19;
            this.Domain.Bottom = 1;
            this.Domain.Right = -4;
        }
    }
}
