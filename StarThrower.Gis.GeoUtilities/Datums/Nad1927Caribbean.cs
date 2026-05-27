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
    /// NGIA GeoTrans: NORTH AMERICAN 1927, Caribbean
    /// Ellipsoid: Clarke_1866,  DeltaX: -3,  SigmaX: 3,  DeltaY: 142,  SigmaY: 9,  DeltaZ: 183,  SigmaZ: 12,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 29,  South: 8,  East: -58,  West: -87
    /// </summary>
    public class Nad1927Caribbean : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1927Caribbean()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = -3;
            this.SigmaX = 3;
            this.DeltaY = 142;
            this.SigmaY = 9;
            this.DeltaZ = 183;
            this.SigmaZ = 12;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 29;
            this.Domain.Left = -87;
            this.Domain.Bottom = 8;
            this.Domain.Right = -58;
        }
    }
}
