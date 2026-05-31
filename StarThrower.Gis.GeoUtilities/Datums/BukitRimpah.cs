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
    /// NGIA GeoTrans: BUKIT RIMPAH, Banka and Belitung
    /// Ellipsoid: Bessel_1841,  DeltaX: -384,  SigmaX: -1,  DeltaY: 664,  SigmaY: -1,  DeltaZ: -48,  SigmaZ: -1,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 0,  South: -6,  East: 110,  West: 103
    /// </summary>
    public class BukitRimpah : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal BukitRimpah()
        {
            this.Ellipsoid = new Ellipsoids.Bessel1841();
            this.DeltaX = -384;
            this.SigmaX = -1;
            this.DeltaY = 664;
            this.SigmaY = -1;
            this.DeltaZ = -48;
            this.SigmaZ = -1;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 0;
            this.Domain.Left = 103;
            this.Domain.Bottom = -6;
            this.Domain.Right = 110;
        }
    }
}


