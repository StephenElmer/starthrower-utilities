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
    /// NGIA GeoTrans: PROV. S AMERICAN 1956, Peru
    /// Ellipsoid: International_1924,  DeltaX: -279,  SigmaX: 6,  DeltaY: 175,  SigmaY: 8,  DeltaZ: -379,  SigmaZ: 12,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 5,  South: -24,  East: -63,  West: -87
    /// </summary>
    public class SAmericanPeru1956 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal SAmericanPeru1956()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -279;
            this.SigmaX = 6;
            this.DeltaY = 175;
            this.SigmaY = 8;
            this.DeltaZ = -379;
            this.SigmaZ = 12;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 5;
            this.Domain.Left = -87;
            this.Domain.Bottom = -24;
            this.Domain.Right = -63;
        }
    }
}
