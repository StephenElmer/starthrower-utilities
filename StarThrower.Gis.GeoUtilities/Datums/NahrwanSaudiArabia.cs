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
    /// NGIA GeoTrans: NAHRWAN, Saudi Arabia
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -243,  SigmaX: 20,  DeltaY: -192,  SigmaY: 20,  DeltaZ: 477,  SigmaZ: 20,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 38,  South: 8,  East: 62,  West: 28
    /// </summary>
    public class NahrwanSaudiArabia : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal NahrwanSaudiArabia()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -243;
            this.SigmaX = 20;
            this.DeltaY = -192;
            this.SigmaY = 20;
            this.DeltaZ = 477;
            this.SigmaZ = 20;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 38;
            this.Domain.Left = 28;
            this.Domain.Bottom = 8;
            this.Domain.Right = 62;
        }
    }
}
