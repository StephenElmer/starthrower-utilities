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
    /// NGIA GeoTrans: NORTH AMERICAN 1927, Canal Zone
    /// Ellipsoid: Clarke_1866,  DeltaX: 0,  SigmaX: 20,  DeltaY: 125,  SigmaY: 20,  DeltaZ: 201,  SigmaZ: 20,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 15,  South: 3,  East: -74,  West: -86
    /// </summary>
    public class Nad1927CanalZone : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1927CanalZone()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = 0;
            this.SigmaX = 20;
            this.DeltaY = 125;
            this.SigmaY = 20;
            this.DeltaZ = 201;
            this.SigmaZ = 20;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 15;
            this.Domain.Left = -86;
            this.Domain.Bottom = 3;
            this.Domain.Right = -74;
        }
    }
}


