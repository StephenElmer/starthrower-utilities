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
    /// NGIA GeoTrans: MINNA, Nigeria
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -92,  SigmaX: 3,  DeltaY: -93,  SigmaY: 6,  DeltaZ: 122,  SigmaZ: 5,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 21,  South: -1,  East: 20,  West: -4
    /// </summary>
    public class MinnaNigeria : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal MinnaNigeria()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -92;
            this.SigmaX = 3;
            this.DeltaY = -93;
            this.SigmaY = 6;
            this.DeltaZ = 122;
            this.SigmaZ = 5;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 21;
            this.Domain.Left = -4;
            this.Domain.Bottom = -1;
            this.Domain.Right = 20;
        }
    }
}


