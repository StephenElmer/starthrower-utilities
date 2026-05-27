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
    /// NGIA GeoTrans: TOKYO, Japan
    /// Ellipsoid: Bessel_1841,  DeltaX: -148,  SigmaX: 8,  DeltaY: 507,  SigmaY: 5,  DeltaZ: 685,  SigmaZ: 8,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 51,  South: 19,  East: 156,  West: 119
    /// </summary>
    public class TokyoJapan : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal TokyoJapan()
        {
            this.Ellipsoid = new Ellipsoids.Bessel1841();
            this.DeltaX = -148;
            this.SigmaX = 8;
            this.DeltaY = 507;
            this.SigmaY = 5;
            this.DeltaZ = 685;
            this.SigmaZ = 8;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 51;
            this.Domain.Left = 119;
            this.Domain.Bottom = 19;
            this.Domain.Right = 156;
        }
    }
}
