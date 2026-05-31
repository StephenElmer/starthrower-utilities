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
    /// NGIA GeoTrans: NORTH AMERICAN 1927, Bahamas
    /// Ellipsoid: Clarke_1866,  DeltaX: -4,  SigmaX: 5,  DeltaY: 154,  SigmaY: 3,  DeltaZ: 178,  SigmaZ: 5,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 29,  South: 19,  East: -71,  West: -83
    /// </summary>
    public class Nad1927Bahamas : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1927Bahamas()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = -4;
            this.SigmaX = 5;
            this.DeltaY = 154;
            this.SigmaY = 3;
            this.DeltaZ = 178;
            this.SigmaZ = 5;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 29;
            this.Domain.Left = -83;
            this.Domain.Bottom = 19;
            this.Domain.Right = -71;
        }
    }
}


