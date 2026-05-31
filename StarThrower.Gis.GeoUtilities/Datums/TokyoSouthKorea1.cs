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
    /// NGIA GeoTrans: TOKYO, South Korea
    /// Ellipsoid: Bessel_1841,  DeltaX: -146,  SigmaX: 8,  DeltaY: 507,  SigmaY: 5,  DeltaZ: 687,  SigmaZ: 8,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 45,  South: 27,  East: 139,  West: 120
    /// </summary>
    public class TokyoSouthKorea1 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal TokyoSouthKorea1()
        {
            this.Ellipsoid = new Ellipsoids.Bessel1841();
            this.DeltaX = -146;
            this.SigmaX = 8;
            this.DeltaY = 507;
            this.SigmaY = 5;
            this.DeltaZ = 687;
            this.SigmaZ = 8;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 45;
            this.Domain.Left = 120;
            this.Domain.Bottom = 27;
            this.Domain.Right = 139;
        }
    }
}


