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
    /// NGIA GeoTrans: NORTH AMERICAN 1927, Eastern US
    /// Ellipsoid: Clarke_1866,  DeltaX: -9,  SigmaX: 5,  DeltaY: 161,  SigmaY: 5,  DeltaZ: 179,  SigmaZ: 8,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 55,  South: 18,  East: -60,  West: -102
    /// </summary>
    public class Nad1927EasternUs : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1927EasternUs()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = -9;
            this.SigmaX = 5;
            this.DeltaY = 161;
            this.SigmaY = 5;
            this.DeltaZ = 179;
            this.SigmaZ = 8;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 55;
            this.Domain.Left = -102;
            this.Domain.Bottom = 18;
            this.Domain.Right = -60;
        }
    }
}


