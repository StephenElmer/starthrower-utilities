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
    /// NGIA GeoTrans: SELVAGEM GRANDE 1938, Salvage Is
    /// Ellipsoid: International_1924,  DeltaX: -289,  SigmaX: 25,  DeltaY: -124,  SigmaY: 25,  DeltaZ: 60,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 32,  South: 28,  East: -14,  West: -18
    /// </summary>
    public class SalvageIsland1938 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal SalvageIsland1938()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -289;
            this.SigmaX = 25;
            this.DeltaY = -124;
            this.SigmaY = 25;
            this.DeltaZ = 60;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 32;
            this.Domain.Left = -18;
            this.Domain.Bottom = 28;
            this.Domain.Right = -14;
        }
    }
}
