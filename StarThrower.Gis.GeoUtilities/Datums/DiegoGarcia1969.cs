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
    /// NGIA GeoTrans: ISTS 073 ASTRO 1969, Diego Garc
    /// Ellipsoid: International_1924,  DeltaX: 208,  SigmaX: 25,  DeltaY: -435,  SigmaY: 25,  DeltaZ: -229,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -4,  South: -10,  East: 75,  West: 69
    /// </summary>
    public class DiegoGarcia1969 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal DiegoGarcia1969()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = 208;
            this.SigmaX = 25;
            this.DeltaY = -435;
            this.SigmaY = 25;
            this.DeltaZ = -229;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -4;
            this.Domain.Left = 69;
            this.Domain.Bottom = -10;
            this.Domain.Right = 75;
        }
    }
}


