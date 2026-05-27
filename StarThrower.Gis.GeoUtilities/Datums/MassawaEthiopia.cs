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
    /// NGIA GeoTrans: MASSAWA, Ethiopia
    /// Ellipsoid: Bessel_1841,  DeltaX: 639,  SigmaX: 25,  DeltaY: 405,  SigmaY: 25,  DeltaZ: 60,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 25,  South: 7,  East: 53,  West: 37
    /// </summary>
    public class MassawaEthiopia : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal MassawaEthiopia()
        {
            this.Ellipsoid = new Ellipsoids.Bessel1841();
            this.DeltaX = 639;
            this.SigmaX = 25;
            this.DeltaY = 405;
            this.SigmaY = 25;
            this.DeltaZ = 60;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 25;
            this.Domain.Left = 37;
            this.Domain.Bottom = 7;
            this.Domain.Right = 53;
        }
    }
}
