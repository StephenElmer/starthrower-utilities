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
    /// NGIA GeoTrans: MAHE 1971, Mahe Is.
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: 41,  SigmaX: 25,  DeltaY: -220,  SigmaY: 25,  DeltaZ: -134,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -3,  South: -6,  East: 57,  West: 54
    /// </summary>
    public class MaheIsland1971 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal MaheIsland1971()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = 41;
            this.SigmaX = 25;
            this.DeltaY = -220;
            this.SigmaY = 25;
            this.DeltaZ = -134;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -3;
            this.Domain.Left = 54;
            this.Domain.Bottom = -6;
            this.Domain.Right = 57;
        }
    }
}


