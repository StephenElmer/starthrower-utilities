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
    /// NGIA GeoTrans: AUSTRALIAN GEODETIC 1984
    /// Ellipsoid: Australian,  DeltaX: -134,  SigmaX: 2,  DeltaY: -48,  SigmaY: 2,  DeltaZ: 149,  SigmaZ: 2,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -4,  South: -46,  East: 161,  West: 109
    /// </summary>
    public class Australian1984 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Australian1984()
        {
            this.Ellipsoid = new Ellipsoids.Australian();
            this.DeltaX = -134;
            this.SigmaX = 2;
            this.DeltaY = -48;
            this.SigmaY = 2;
            this.DeltaZ = 149;
            this.SigmaZ = 2;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -4;
            this.Domain.Left = 109;
            this.Domain.Bottom = -46;
            this.Domain.Right = 161;
        }
    }
}


