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
    /// NGIA GeoTrans: EASTER ISLAND 1967
    /// Ellipsoid: International_1924,  DeltaX: 211,  SigmaX: 25,  DeltaY: 147,  SigmaY: 25,  DeltaZ: 111,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -26,  South: -29,  East: -108,  West: -111
    /// </summary>
    public class EasterIsland1967 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal EasterIsland1967()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = 211;
            this.SigmaX = 25;
            this.DeltaY = 147;
            this.SigmaY = 25;
            this.DeltaZ = 111;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -26;
            this.Domain.Left = -111;
            this.Domain.Bottom = -29;
            this.Domain.Right = -108;
        }
    }
}
