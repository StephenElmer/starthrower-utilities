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
    /// NGIA GeoTrans: SOUTH AMERICAN 1969, Peru
    /// Ellipsoid: South_American_1969,  DeltaX: -58,  SigmaX: 5,  DeltaY: 0,  SigmaY: 5,  DeltaZ: -44,  SigmaZ: 5,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 5,  South: -24,  East: -63,  West: -87
    /// </summary>
    public class SAmerican1969Peru : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal SAmerican1969Peru()
        {
            this.Ellipsoid = new Ellipsoids.SouthAmerican1969();
            this.DeltaX = -58;
            this.SigmaX = 5;
            this.DeltaY = 0;
            this.SigmaY = 5;
            this.DeltaZ = -44;
            this.SigmaZ = 5;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 5;
            this.Domain.Left = -87;
            this.Domain.Bottom = -24;
            this.Domain.Right = -63;
        }
    }
}


