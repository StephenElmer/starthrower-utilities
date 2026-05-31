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
    /// ESRI ArgIMS: Ain_El_Abd_To_WGS_1984_2
    /// NGIA GeoTrans: AIN EL ABD 1970, Saudi Arabia
    /// Ellipsoid: International_1924,  DeltaX: -143,  SigmaX: 10,  DeltaY: -236,  SigmaY: 10,  DeltaZ: 7,  SigmaZ: 10,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 38,  South: 8,  East: 62,  West: 28
    /// </summary>
    public class AinElAbd1970SaudiArabia : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal AinElAbd1970SaudiArabia()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -143;
            this.SigmaX = 10;
            this.DeltaY = -236;
            this.SigmaY = 10;
            this.DeltaZ = 7;
            this.SigmaZ = 10;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 38;
            this.Domain.Left = 28;
            this.Domain.Bottom = 8;
            this.Domain.Right = 62;
        }
    }
}


