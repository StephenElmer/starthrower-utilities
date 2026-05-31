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
    /// ESRI ArgIMS: Bogota_To_WGS_1984
    /// NGIA GeoTrans: BOGOTA OBSERVATORY, Colombia
    /// Ellipsoid: International_1924,  DeltaX: 307,  SigmaX: 6,  DeltaY: 304,  SigmaY: 5,  DeltaZ: -318,  SigmaZ: 6,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 16,  South: -10,  East: -61,  West: -85
    /// </summary>
    public class Bogota : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Bogota()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = 307;
            this.SigmaX = 6;
            this.DeltaY = 304;
            this.SigmaY = 5;
            this.DeltaZ = -318;
            this.SigmaZ = 6;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 16;
            this.Domain.Left = -85;
            this.Domain.Bottom = -10;
            this.Domain.Right = -61;
        }
    }
}


