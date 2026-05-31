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
    /// NGIA GeoTrans: NORTH AMERICAN 1927, Yukon
    /// Ellipsoid: Clarke_1866,  DeltaX: -7,  SigmaX: 5,  DeltaY: 139,  SigmaY: 8,  DeltaZ: 181,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 75,  South: 53,  East: -117,  West: -147
    /// </summary>
    public class Nad1927Yukon : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1927Yukon()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = -7;
            this.SigmaX = 5;
            this.DeltaY = 139;
            this.SigmaY = 8;
            this.DeltaZ = 181;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 75;
            this.Domain.Left = -147;
            this.Domain.Bottom = 53;
            this.Domain.Right = -117;
        }
    }
}


