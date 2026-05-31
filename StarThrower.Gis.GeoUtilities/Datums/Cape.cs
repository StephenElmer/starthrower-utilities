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
    /// ESRI ArgIMS: Cape_To_WGS_1984_1
    /// NGIA GeoTrans: CAPE, South Africa
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -136,  SigmaX: 3,  DeltaY: -108,  SigmaY: 6,  DeltaZ: -292,  SigmaZ: 6,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -15,  South: -43,  East: 40,  West: 10
    /// </summary>
    public class Cape : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Cape()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -136;
            this.SigmaX = 3;
            this.DeltaY = -108;
            this.SigmaY = 6;
            this.DeltaZ = -292;
            this.SigmaZ = 6;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -15;
            this.Domain.Left = 10;
            this.Domain.Bottom = -43;
            this.Domain.Right = 40;
        }
    }
}


