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
    /// NGIA GeoTrans: S-42 (PULKOVO 1942), Albania
    /// Ellipsoid: Krasovsky_1940,  DeltaX: 24,  SigmaX: 3,  DeltaY: -130,  SigmaY: 3,  DeltaZ: -92,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 48,  South: 34,  East: 26,  West: 14
    /// </summary>
    public class Albania1942 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Albania1942()
        {
            this.Ellipsoid = new Ellipsoids.Krasovsky1940();
            this.DeltaX = 24;
            this.SigmaX = 3;
            this.DeltaY = -130;
            this.SigmaY = 3;
            this.DeltaZ = -92;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 48;
            this.Domain.Left = 14;
            this.Domain.Bottom = 34;
            this.Domain.Right = 26;
        }
    }
}


