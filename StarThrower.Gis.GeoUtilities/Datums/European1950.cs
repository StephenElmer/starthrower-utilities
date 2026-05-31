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
    /// NGIA GeoTrans: EUROPEAN 1950, Mean (7 Param)
    /// Ellipsoid: International_1924,  DeltaX: -102,  SigmaX: 0,  DeltaY: -102,  SigmaY: 0,  DeltaZ: -129,  SigmaZ: 0,  RotationX: 0.413,  RotationY: -0.184,  RotationZ: 0.385,  ScaleFactor: 2.4664E-06,  North: 90,  South: -90,  East: 180,  West: -180
    /// </summary>
    public class European1950 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return true; }
        }

        internal European1950()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -102;
            this.SigmaX = 0;
            this.DeltaY = -102;
            this.SigmaY = 0;
            this.DeltaZ = -129;
            this.SigmaZ = 0;
            this.RotationX = 0.413;
            this.RotationY = -0.184;
            this.RotationZ = 0.385;
            this.RotationScaleFactor = 2.4664E-06;
            this.Domain.Top = 90;
            this.Domain.Left = -180;
            this.Domain.Bottom = -90;
            this.Domain.Right = 180;
        }
    }
}


