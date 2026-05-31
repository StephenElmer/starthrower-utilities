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
    /// ESRI ArgIMS: Arc_1960_To_WGS_1984
    /// NGIA GeoTrans: ARC 1960, Kenya and Tanzania
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -160,  SigmaX: 20,  DeltaY: -6,  SigmaY: 20,  DeltaZ: -302,  SigmaZ: 20,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 8,  South: -18,  East: 47,  West: 23
    /// </summary>
    public class Arc1960KenyaAndTanzania : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Arc1960KenyaAndTanzania()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -160;
            this.SigmaX = 20;
            this.DeltaY = -6;
            this.SigmaY = 20;
            this.DeltaZ = -302;
            this.SigmaZ = 20;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 8;
            this.Domain.Left = 23;
            this.Domain.Bottom = -18;
            this.Domain.Right = 47;
        }
    }
}


