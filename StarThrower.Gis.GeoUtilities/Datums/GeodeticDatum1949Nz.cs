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
    /// NGIA GeoTrans: GEODETIC DATUM 1949, NZ
    /// Ellipsoid: International_1924,  DeltaX: 84,  SigmaX: 5,  DeltaY: -22,  SigmaY: 3,  DeltaZ: 209,  SigmaZ: 5,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -33,  South: -48,  East: 180,  West: 165
    /// </summary>
    public class GeodeticDatum1949Nz : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal GeodeticDatum1949Nz()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = 84;
            this.SigmaX = 5;
            this.DeltaY = -22;
            this.SigmaY = 3;
            this.DeltaZ = 209;
            this.SigmaZ = 5;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -33;
            this.Domain.Left = 165;
            this.Domain.Bottom = -48;
            this.Domain.Right = 180;
        }
    }
}


