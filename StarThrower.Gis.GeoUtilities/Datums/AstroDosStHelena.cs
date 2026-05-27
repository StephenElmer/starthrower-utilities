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
    /// NGIA GeoTrans: ASTRO DOS 71/4, St. Helena Is.
    /// Ellipsoid: International_1924,  DeltaX: -320,  SigmaX: 25,  DeltaY: 550,  SigmaY: 25,  DeltaZ: -494,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -14,  South: -18,  East: -4,  West: -7
    /// </summary>
    public class AstroDosStHelena : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal AstroDosStHelena()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -320;
            this.SigmaX = 25;
            this.DeltaY = 550;
            this.SigmaY = 25;
            this.DeltaZ = -494;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -14;
            this.Domain.Left = -7;
            this.Domain.Bottom = -18;
            this.Domain.Right = -4;
        }
    }
}
