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
    /// NGIA GeoTrans: ORDNANCE GB 1936, Wales
    /// Ellipsoid: Airy_1830,  DeltaX: 370,  SigmaX: 20,  DeltaY: -108,  SigmaY: 20,  DeltaZ: 434,  SigmaZ: 20,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 59,  South: 46,  East: 3,  West: -11
    /// </summary>
    public class Ogb1936Wales : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Ogb1936Wales()
        {
            this.Ellipsoid = new Ellipsoids.Airy1830();
            this.DeltaX = 370;
            this.SigmaX = 20;
            this.DeltaY = -108;
            this.SigmaY = 20;
            this.DeltaZ = 434;
            this.SigmaZ = 20;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 59;
            this.Domain.Left = -11;
            this.Domain.Bottom = 46;
            this.Domain.Right = 3;
        }
    }
}
