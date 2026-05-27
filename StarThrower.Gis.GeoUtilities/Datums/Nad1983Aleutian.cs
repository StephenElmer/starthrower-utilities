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
    /// NGIA GeoTrans: NORTH AMERICAN 1983, Aleutian
    /// Ellipsoid: GRS_1980,  DeltaX: -2,  SigmaX: 5,  DeltaY: 0,  SigmaY: 2,  DeltaZ: 4,  SigmaZ: 5,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 74,  South: 51,  East: 180,  West: -180
    /// </summary>
    public class Nad1983Aleutian : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1983Aleutian()
        {
            this.Ellipsoid = new Ellipsoids.Grs1980();
            this.DeltaX = -2;
            this.SigmaX = 5;
            this.DeltaY = 0;
            this.SigmaY = 2;
            this.DeltaZ = 4;
            this.SigmaZ = 5;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 74;
            this.Domain.Left = -180;
            this.Domain.Bottom = 51;
            this.Domain.Right = 180;
        }
    }
}
