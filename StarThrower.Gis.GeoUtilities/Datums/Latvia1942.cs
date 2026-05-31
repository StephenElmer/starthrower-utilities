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
    /// NGIA GeoTrans: S-42 (PULKOVO 1942), Latvia
    /// Ellipsoid: Krasovsky_1940,  DeltaX: 24,  SigmaX: 2,  DeltaY: -124,  SigmaY: 2,  DeltaZ: -82,  SigmaZ: 2,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 64,  South: 50,  East: 34,  West: 15
    /// </summary>
    public class Latvia1942 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Latvia1942()
        {
            this.Ellipsoid = new Ellipsoids.Krasovsky1940();
            this.DeltaX = 24;
            this.SigmaX = 2;
            this.DeltaY = -124;
            this.SigmaY = 2;
            this.DeltaZ = -82;
            this.SigmaZ = 2;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 64;
            this.Domain.Left = 15;
            this.Domain.Bottom = 50;
            this.Domain.Right = 34;
        }
    }
}


