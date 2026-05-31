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
    /// NGIA GeoTrans: GRACIOSA BASE SW 1948, Azores
    /// Ellipsoid: International_1924,  DeltaX: -104,  SigmaX: 3,  DeltaY: 167,  SigmaY: 3,  DeltaZ: -38,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 41,  South: 37,  East: -26,  West: -30
    /// </summary>
    public class GraciosaBase1948Azores : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal GraciosaBase1948Azores()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -104;
            this.SigmaX = 3;
            this.DeltaY = 167;
            this.SigmaY = 3;
            this.DeltaZ = -38;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 41;
            this.Domain.Left = -30;
            this.Domain.Bottom = 37;
            this.Domain.Right = -26;
        }
    }
}


