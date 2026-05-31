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
    /// NGIA GeoTrans: NORTH AMERICAN 1927, Alaska
    /// Ellipsoid: Clarke_1866,  DeltaX: -5,  SigmaX: 5,  DeltaY: 135,  SigmaY: 9,  DeltaZ: 172,  SigmaZ: 5,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 78,  South: 47,  East: -130,  West: -175
    /// </summary>
    public class Nad1927Alaska : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1927Alaska()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = -5;
            this.SigmaX = 5;
            this.DeltaY = 135;
            this.SigmaY = 9;
            this.DeltaZ = 172;
            this.SigmaZ = 5;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 78;
            this.Domain.Left = -175;
            this.Domain.Bottom = 47;
            this.Domain.Right = -130;
        }
    }
}


