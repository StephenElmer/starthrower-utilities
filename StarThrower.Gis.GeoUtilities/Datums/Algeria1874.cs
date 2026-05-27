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
    /// NGIA GeoTrans: VOIROL 1874, Algeria
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -73,  SigmaX: -1,  DeltaY: -247,  SigmaY: -1,  DeltaZ: 227,  SigmaZ: -1,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 43,  South: 13,  East: 18,  West: -15
    /// </summary>
    public class Algeria1874 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Algeria1874()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -73;
            this.SigmaX = -1;
            this.DeltaY = -247;
            this.SigmaY = -1;
            this.DeltaZ = 227;
            this.SigmaZ = -1;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 43;
            this.Domain.Left = -15;
            this.Domain.Bottom = 13;
            this.Domain.Right = 18;
        }
    }
}
