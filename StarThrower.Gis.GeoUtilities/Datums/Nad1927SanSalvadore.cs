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
    /// NGIA GeoTrans: NORTH AMERICAN 1927, San Salv.
    /// Ellipsoid: Clarke_1866,  DeltaX: 1,  SigmaX: 25,  DeltaY: 140,  SigmaY: 25,  DeltaZ: 165,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 26,  South: 23,  East: -74,  West: -75
    /// </summary>
    public class Nad1927SanSalvadore : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1927SanSalvadore()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = 1;
            this.SigmaX = 25;
            this.DeltaY = 140;
            this.SigmaY = 25;
            this.DeltaZ = 165;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 26;
            this.Domain.Left = -75;
            this.Domain.Bottom = 23;
            this.Domain.Right = -74;
        }
    }
}


