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
    /// NGIA GeoTrans: MERCHICH, Morocco
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: 31,  SigmaX: 5,  DeltaY: 146,  SigmaY: 3,  DeltaZ: 47,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 42,  South: 22,  East: 5,  West: -19
    /// </summary>
    public class MerchichMorocco : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal MerchichMorocco()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = 31;
            this.SigmaX = 5;
            this.DeltaY = 146;
            this.SigmaY = 3;
            this.DeltaZ = 47;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 42;
            this.Domain.Left = -19;
            this.Domain.Bottom = 22;
            this.Domain.Right = 5;
        }
    }
}
