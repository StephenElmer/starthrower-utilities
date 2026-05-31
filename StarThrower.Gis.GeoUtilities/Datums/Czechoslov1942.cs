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
    /// NGIA GeoTrans: S-42 (PK42) Former Czechoslov.
    /// Ellipsoid: Krasovsky_1940,  DeltaX: 26,  SigmaX: 3,  DeltaY: -121,  SigmaY: 3,  DeltaZ: -78,  SigmaZ: 2,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 57,  South: 42,  East: 28,  West: 6
    /// </summary>
    public class Czechoslov1942 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Czechoslov1942()
        {
            this.Ellipsoid = new Ellipsoids.Krasovsky1940();
            this.DeltaX = 26;
            this.SigmaX = 3;
            this.DeltaY = -121;
            this.SigmaY = 3;
            this.DeltaZ = -78;
            this.SigmaZ = 2;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 57;
            this.Domain.Left = 6;
            this.Domain.Bottom = 42;
            this.Domain.Right = 28;
        }
    }
}


