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
    /// NGIA GeoTrans: OMAN
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -346,  SigmaX: 3,  DeltaY: -1,  SigmaY: 3,  DeltaZ: 224,  SigmaZ: 9,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 32,  South: 10,  East: 65,  West: 46
    /// </summary>
    public class Oman : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Oman()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -346;
            this.SigmaX = 3;
            this.DeltaY = -1;
            this.SigmaY = 3;
            this.DeltaZ = 224;
            this.SigmaZ = 9;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 32;
            this.Domain.Left = 46;
            this.Domain.Bottom = 10;
            this.Domain.Right = 65;
        }
    }
}


