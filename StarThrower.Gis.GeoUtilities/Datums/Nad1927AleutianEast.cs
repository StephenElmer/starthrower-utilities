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
    /// NGIA GeoTrans: NORTH AMERICAN 1927, Aleutian E
    /// Ellipsoid: Clarke_1866,  DeltaX: -2,  SigmaX: 6,  DeltaY: 152,  SigmaY: 8,  DeltaZ: 149,  SigmaZ: 10,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 58,  South: 50,  East: -161,  West: -180
    /// </summary>
    public class Nad1927AleutianEast : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1927AleutianEast()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = -2;
            this.SigmaX = 6;
            this.DeltaY = 152;
            this.SigmaY = 8;
            this.DeltaZ = 149;
            this.SigmaZ = 10;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 58;
            this.Domain.Left = -180;
            this.Domain.Bottom = 50;
            this.Domain.Right = -161;
        }
    }
}


