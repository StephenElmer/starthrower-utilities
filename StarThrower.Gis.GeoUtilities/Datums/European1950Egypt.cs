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
    /// NGIA GeoTrans: EUROPEAN 1950, Egypt
    /// Ellipsoid: International_1924,  DeltaX: -130,  SigmaX: 6,  DeltaY: -117,  SigmaY: 8,  DeltaZ: -151,  SigmaZ: 8,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 38,  South: 16,  East: 42,  West: 19
    /// </summary>
    public class European1950Egypt : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal European1950Egypt()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -130;
            this.SigmaX = 6;
            this.DeltaY = -117;
            this.SigmaY = 8;
            this.DeltaZ = -151;
            this.SigmaZ = 8;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 38;
            this.Domain.Left = 19;
            this.Domain.Bottom = 16;
            this.Domain.Right = 42;
        }
    }
}


