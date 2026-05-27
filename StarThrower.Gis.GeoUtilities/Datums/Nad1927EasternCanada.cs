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
    /// NGIA GeoTrans: NORTH AMERICAN 1927, E. Canada
    /// Ellipsoid: Clarke_1866,  DeltaX: -22,  SigmaX: 6,  DeltaY: 160,  SigmaY: 6,  DeltaZ: 190,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 68,  South: 38,  East: -45,  West: -85
    /// </summary>
    public class Nad1927EasternCanada : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1927EasternCanada()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = -22;
            this.SigmaX = 6;
            this.DeltaY = 160;
            this.SigmaY = 6;
            this.DeltaZ = 190;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 68;
            this.Domain.Left = -85;
            this.Domain.Bottom = 38;
            this.Domain.Right = -45;
        }
    }
}
