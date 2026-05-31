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
    /// NGIA GeoTrans: PICO DE LAS NIEVES, Canary Is.
    /// Ellipsoid: International_1924,  DeltaX: -307,  SigmaX: 25,  DeltaY: -92,  SigmaY: 25,  DeltaZ: 127,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 31,  South: 26,  East: -12,  West: -20
    /// </summary>
    public class CanaryIslands : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal CanaryIslands()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -307;
            this.SigmaX = 25;
            this.DeltaY = -92;
            this.SigmaY = 25;
            this.DeltaZ = 127;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 31;
            this.Domain.Left = -20;
            this.Domain.Bottom = 26;
            this.Domain.Right = -12;
        }
    }
}


