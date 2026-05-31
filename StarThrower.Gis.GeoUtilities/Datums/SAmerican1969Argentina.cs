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
    /// NGIA GeoTrans: SOUTH AMERICAN 1969, Argentina
    /// Ellipsoid: South_American_1969,  DeltaX: -62,  SigmaX: 5,  DeltaY: -1,  SigmaY: 5,  DeltaZ: -37,  SigmaZ: 5,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -20,  South: -62,  East: -47,  West: -76
    /// </summary>
    public class SAmerican1969Argentina : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal SAmerican1969Argentina()
        {
            this.Ellipsoid = new Ellipsoids.SouthAmerican1969();
            this.DeltaX = -62;
            this.SigmaX = 5;
            this.DeltaY = -1;
            this.SigmaY = 5;
            this.DeltaZ = -37;
            this.SigmaZ = 5;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -20;
            this.Domain.Left = -76;
            this.Domain.Bottom = -62;
            this.Domain.Right = -47;
        }
    }
}


