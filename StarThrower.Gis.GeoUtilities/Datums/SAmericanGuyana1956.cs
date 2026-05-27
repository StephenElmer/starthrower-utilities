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
    /// NGIA GeoTrans: PROV. S AMERICAN 1956, Guyana
    /// Ellipsoid: International_1924,  DeltaX: -298,  SigmaX: 6,  DeltaY: 159,  SigmaY: 14,  DeltaZ: -369,  SigmaZ: 5,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 14,  South: -4,  East: -51,  West: -67
    /// </summary>
    public class SAmericanGuyana1956 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal SAmericanGuyana1956()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -298;
            this.SigmaX = 6;
            this.DeltaY = 159;
            this.SigmaY = 14;
            this.DeltaZ = -369;
            this.SigmaZ = 5;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 14;
            this.Domain.Left = -67;
            this.Domain.Bottom = -4;
            this.Domain.Right = -51;
        }
    }
}
