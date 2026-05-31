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
    /// NGIA GeoTrans: NORTH AMERICAN 1983, Hawaii
    /// Ellipsoid: GRS_1980,  DeltaX: 1,  SigmaX: 2,  DeltaY: 1,  SigmaY: 2,  DeltaZ: -1,  SigmaZ: 2,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 24,  South: 17,  East: -153,  West: -164
    /// </summary>
    public class Nad1983Hawaii : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1983Hawaii()
        {
            this.Ellipsoid = new Ellipsoids.Grs1980();
            this.DeltaX = 1;
            this.SigmaX = 2;
            this.DeltaY = 1;
            this.SigmaY = 2;
            this.DeltaZ = -1;
            this.SigmaZ = 2;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 24;
            this.Domain.Left = -164;
            this.Domain.Bottom = 17;
            this.Domain.Right = -153;
        }
    }
}


