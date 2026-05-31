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
    /// NGIA GeoTrans: DECEPTION ISLAND
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: 260,  SigmaX: 20,  DeltaY: 12,  SigmaY: 20,  DeltaZ: -147,  SigmaZ: 20,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -62,  South: -65,  East: -58,  West: -62
    /// </summary>
    public class DeceptionIsland : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal DeceptionIsland()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = 260;
            this.SigmaX = 20;
            this.DeltaY = 12;
            this.SigmaY = 20;
            this.DeltaZ = -147;
            this.SigmaZ = 20;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -62;
            this.Domain.Left = -62;
            this.Domain.Bottom = -65;
            this.Domain.Right = -58;
        }
    }
}


