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
    /// NGIA GeoTrans: NORTH AMERICAN 1927, Greenland
    /// Ellipsoid: Clarke_1866,  DeltaX: 11,  SigmaX: 25,  DeltaY: 114,  SigmaY: 25,  DeltaZ: 195,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 81,  South: 74,  East: -56,  West: -74
    /// </summary>
    public class Nad1927Greenland : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1927Greenland()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = 11;
            this.SigmaX = 25;
            this.DeltaY = 114;
            this.SigmaY = 25;
            this.DeltaZ = 195;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 81;
            this.Domain.Left = -74;
            this.Domain.Bottom = 74;
            this.Domain.Right = -56;
        }
    }
}


