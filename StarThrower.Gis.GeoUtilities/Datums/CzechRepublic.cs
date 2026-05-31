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
    /// NGIA GeoTrans: S-JTSK, Czech Republic
    /// Ellipsoid: Bessel_1841,  DeltaX: 589,  SigmaX: 4,  DeltaY: 76,  SigmaY: 2,  DeltaZ: 480,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 56,  South: 43,  East: 28,  West: 6
    /// </summary>
    public class CzechRepublic : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal CzechRepublic()
        {
            this.Ellipsoid = new Ellipsoids.Bessel1841();
            this.DeltaX = 589;
            this.SigmaX = 4;
            this.DeltaY = 76;
            this.SigmaY = 2;
            this.DeltaZ = 480;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 56;
            this.Domain.Left = 6;
            this.Domain.Bottom = 43;
            this.Domain.Right = 28;
        }
    }
}


