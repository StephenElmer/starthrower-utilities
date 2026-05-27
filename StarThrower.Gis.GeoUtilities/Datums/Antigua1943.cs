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
    /// ESRI ArgIMS: Antigua_1943_To_WGS_1984_NGA
    /// NGIA GeoTrans: ANTIGUA ISLAND ASTRO 1943
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -270,  SigmaX: 25,  DeltaY: 13,  SigmaY: 25,  DeltaZ: 62,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 20,  South: 16,  East: -61,  West: -65
    /// </summary>
    public class Antigua1943 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Antigua1943()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -270;
            this.SigmaX = 25;
            this.DeltaY = 13;
            this.SigmaY = 25;
            this.DeltaZ = 62;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 20;
            this.Domain.Left = -65;
            this.Domain.Bottom = 16;
            this.Domain.Right = -61;
        }
    }
}
