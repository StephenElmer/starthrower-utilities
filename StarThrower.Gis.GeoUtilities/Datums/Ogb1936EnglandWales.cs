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
    /// NGIA GeoTrans: ORDNANCE GB 1936, Eng., Wales
    /// Ellipsoid: Airy_1830,  DeltaX: 371,  SigmaX: 10,  DeltaY: -111,  SigmaY: 10,  DeltaZ: 434,  SigmaZ: 15,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 61,  South: 44,  East: 7,  West: -12
    /// </summary>
    public class Ogb1936EnglandWales : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Ogb1936EnglandWales()
        {
            this.Ellipsoid = new Ellipsoids.Airy1830();
            this.DeltaX = 371;
            this.SigmaX = 10;
            this.DeltaY = -111;
            this.SigmaY = 10;
            this.DeltaZ = 434;
            this.SigmaZ = 15;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 61;
            this.Domain.Left = -12;
            this.Domain.Bottom = 44;
            this.Domain.Right = 7;
        }
    }
}


