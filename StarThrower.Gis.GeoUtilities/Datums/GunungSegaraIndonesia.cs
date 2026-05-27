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
    /// NGIA GeoTrans: GUNUNG SEGARA, Indonesia
    /// Ellipsoid: Bessel_1841,  DeltaX: -403,  SigmaX: -1,  DeltaY: 684,  SigmaY: -1,  DeltaZ: 41,  SigmaZ: -1,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 9,  South: -6,  East: 121,  West: 106
    /// </summary>
    public class GunungSegaraIndonesia : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal GunungSegaraIndonesia()
        {
            this.Ellipsoid = new Ellipsoids.Bessel1841();
            this.DeltaX = -403;
            this.SigmaX = -1;
            this.DeltaY = 684;
            this.SigmaY = -1;
            this.DeltaZ = 41;
            this.SigmaZ = -1;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 9;
            this.Domain.Left = 106;
            this.Domain.Bottom = -6;
            this.Domain.Right = 121;
        }
    }
}
