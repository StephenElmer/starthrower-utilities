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
    /// NGIA GeoTrans: DJAKARTA, INDONESIA
    /// Ellipsoid: Bessel_1841,  DeltaX: -377,  SigmaX: 3,  DeltaY: 681,  SigmaY: 3,  DeltaZ: -50,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 11,  South: -16,  East: 146,  West: 89
    /// </summary>
    public class DjakartaIndonesia : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal DjakartaIndonesia()
        {
            this.Ellipsoid = new Ellipsoids.Bessel1841();
            this.DeltaX = -377;
            this.SigmaX = 3;
            this.DeltaY = 681;
            this.SigmaY = 3;
            this.DeltaZ = -50;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 11;
            this.Domain.Left = 89;
            this.Domain.Bottom = -16;
            this.Domain.Right = 146;
        }
    }
}


