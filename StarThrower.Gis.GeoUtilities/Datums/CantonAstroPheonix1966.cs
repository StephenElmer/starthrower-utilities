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
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: CANTON ASTRO 1966, Phoenix Is.
    /// Ellipsoid: International_1924,  DeltaX: 298,  SigmaX: 15,  DeltaY: -304,  SigmaY: 15,  DeltaZ: -375,  SigmaZ: 15,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 3,  South: -13,  East: -165,  West: -180
    /// </summary>
    public class CantonAstroPheonix1966 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal CantonAstroPheonix1966()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = 298;
            this.SigmaX = 15;
            this.DeltaY = -304;
            this.SigmaY = 15;
            this.DeltaZ = -375;
            this.SigmaZ = 15;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 3;
            this.Domain.Left = -180;
            this.Domain.Bottom = -13;
            this.Domain.Right = -165;
        }
    }
}
