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
    /// ESRI ArgIMS: Arc_1950_To_WGS_1984_8
    /// NGIA GeoTrans: ARC 1950, Zambia
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -147,  SigmaX: 21,  DeltaY: -74,  SigmaY: 21,  DeltaZ: -283,  SigmaZ: 27,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -1,  South: -24,  East: 40,  West: 15
    /// </summary>
    public class Arc1950Zambia : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Arc1950Zambia()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -147;
            this.SigmaX = 21;
            this.DeltaY = -74;
            this.SigmaY = 21;
            this.DeltaZ = -283;
            this.SigmaZ = 27;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -1;
            this.Domain.Left = 15;
            this.Domain.Bottom = -24;
            this.Domain.Right = 40;
        }
    }
}
