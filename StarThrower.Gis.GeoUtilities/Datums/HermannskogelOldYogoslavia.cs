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
    /// NGIA GeoTrans: HERMANNSKOGEL, old Yugoslavia
    /// Ellipsoid: Bessel_1841,  DeltaX: 682,  SigmaX: -1,  DeltaY: -203,  SigmaY: -1,  DeltaZ: 480,  SigmaZ: -1,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 52,  South: 35,  East: 29,  West: 7
    /// </summary>
    public class HermannskogelOldYogoslavia : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal HermannskogelOldYogoslavia()
        {
            this.Ellipsoid = new Ellipsoids.Bessel1841();
            this.DeltaX = 682;
            this.SigmaX = -1;
            this.DeltaY = -203;
            this.SigmaY = -1;
            this.DeltaZ = 480;
            this.SigmaZ = -1;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 52;
            this.Domain.Left = 7;
            this.Domain.Bottom = 35;
            this.Domain.Right = 29;
        }
    }
}


