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
    /// NGIA GeoTrans: L.C. 5 ASTRO 1961, Cayman Brac
    /// Ellipsoid: Clarke_1866,  DeltaX: 42,  SigmaX: 25,  DeltaY: 124,  SigmaY: 25,  DeltaZ: 147,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 21,  South: 18,  East: -78,  West: -83
    /// </summary>
    public class Cayman1961 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Cayman1961()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = 42;
            this.SigmaX = 25;
            this.DeltaY = 124;
            this.SigmaY = 25;
            this.DeltaZ = 147;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 21;
            this.Domain.Left = -83;
            this.Domain.Bottom = 18;
            this.Domain.Right = -78;
        }
    }
}


