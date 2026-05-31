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
    /// NGIA GeoTrans: EUROPEAN 1950, Cyprus
    /// Ellipsoid: International_1924,  DeltaX: -104,  SigmaX: 15,  DeltaY: -101,  SigmaY: 15,  DeltaZ: -140,  SigmaZ: 15,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 37,  South: 33,  East: 36,  West: 31
    /// </summary>
    public class European1950Cyprus : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal European1950Cyprus()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -104;
            this.SigmaX = 15;
            this.DeltaY = -101;
            this.SigmaY = 15;
            this.DeltaZ = -140;
            this.SigmaZ = 15;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 37;
            this.Domain.Left = 31;
            this.Domain.Bottom = 33;
            this.Domain.Right = 36;
        }
    }
}


