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
    /// NGIA GeoTrans: PROV. S AMERICAN 1956, Ecuador
    /// Ellipsoid: International_1924,  DeltaX: -278,  SigmaX: 3,  DeltaY: 171,  SigmaY: 5,  DeltaZ: -367,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 7,  South: -11,  East: -70,  West: -85
    /// </summary>
    public class SAmericanEcuador1956 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal SAmericanEcuador1956()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -278;
            this.SigmaX = 3;
            this.DeltaY = 171;
            this.SigmaY = 5;
            this.DeltaZ = -367;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 7;
            this.Domain.Left = -85;
            this.Domain.Bottom = -11;
            this.Domain.Right = -70;
        }
    }
}
