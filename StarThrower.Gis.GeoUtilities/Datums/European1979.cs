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
    /// NGIA GeoTrans: EUROPEAN 1979
    /// Ellipsoid: International_1924,  DeltaX: -86,  SigmaX: 3,  DeltaY: -98,  SigmaY: 3,  DeltaZ: -119,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 80,  South: 30,  East: 24,  West: -15
    /// </summary>
    public class European1979 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal European1979()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -86;
            this.SigmaX = 3;
            this.DeltaY = -98;
            this.SigmaY = 3;
            this.DeltaZ = -119;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 80;
            this.Domain.Left = -15;
            this.Domain.Bottom = 30;
            this.Domain.Right = 24;
        }
    }
}


