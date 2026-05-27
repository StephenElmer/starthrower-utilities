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
    /// NGIA GeoTrans: PULKOVO 1942, Russia
    /// Ellipsoid: Krasovsky_1940,  DeltaX: 28,  SigmaX: -1,  DeltaY: -130,  SigmaY: -1,  DeltaZ: -95,  SigmaZ: -1,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 89,  South: 36,  East: 180,  West: -180
    /// </summary>
    public class PulkovoRussia1942 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal PulkovoRussia1942()
        {
            this.Ellipsoid = new Ellipsoids.Krasovsky1940();
            this.DeltaX = 28;
            this.SigmaX = -1;
            this.DeltaY = -130;
            this.SigmaY = -1;
            this.DeltaZ = -95;
            this.SigmaZ = -1;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 89;
            this.Domain.Left = -180;
            this.Domain.Bottom = 36;
            this.Domain.Right = 180;
        }
    }
}
