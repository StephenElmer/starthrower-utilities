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
    /// NGIA GeoTrans: EUROPEAN 1950, Iran
    /// Ellipsoid: International_1924,  DeltaX: -117,  SigmaX: 9,  DeltaY: -132,  SigmaY: 12,  DeltaZ: -164,  SigmaZ: 11,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 47,  South: 19,  East: 69,  West: 37
    /// </summary>
    public class European1950Iran : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal European1950Iran()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -117;
            this.SigmaX = 9;
            this.DeltaY = -132;
            this.SigmaY = 12;
            this.DeltaZ = -164;
            this.SigmaZ = 11;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 47;
            this.Domain.Left = 37;
            this.Domain.Bottom = 19;
            this.Domain.Right = 69;
        }
    }
}


