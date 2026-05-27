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
    /// NGIA GeoTrans: NORTH AMERICAN 1927, Aleutian w
    /// Ellipsoid: Clarke_1866,  DeltaX: 2,  SigmaX: 10,  DeltaY: 204,  SigmaY: 10,  DeltaZ: 105,  SigmaZ: 10,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 58,  South: 50,  East: 180,  West: 169
    /// </summary>
    public class Nad1927AleutianWest : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1927AleutianWest()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = 2;
            this.SigmaX = 10;
            this.DeltaY = 204;
            this.SigmaY = 10;
            this.DeltaZ = 105;
            this.SigmaZ = 10;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 58;
            this.Domain.Left = 169;
            this.Domain.Bottom = 50;
            this.Domain.Right = 180;
        }
    }
}
