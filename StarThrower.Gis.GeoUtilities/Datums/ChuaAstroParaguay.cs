/***********************************************************************************
    StarThrower Utilities
    Copyright (C) 2005-2007  Steve Elmer

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
    /// NGIA GeoTrans: CHUA ASTRO, Paraguay
    /// Ellipsoid: International_1924,  DeltaX: -134,  SigmaX: 6,  DeltaY: 229,  SigmaY: 9,  DeltaZ: -29,  SigmaZ: 5,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -14,  South: -33,  East: -49,  West: -69
    /// </summary>
    public class ChuaAstroParaguay : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal ChuaAstroParaguay()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -134;
            this.SigmaX = 6;
            this.DeltaY = 229;
            this.SigmaY = 9;
            this.DeltaZ = -29;
            this.SigmaZ = 5;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -14;
            this.Domain.Left = -69;
            this.Domain.Bottom = -33;
            this.Domain.Right = -49;
        }
    }
}
