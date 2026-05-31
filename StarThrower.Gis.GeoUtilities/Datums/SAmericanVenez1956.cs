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
    /// NGIA GeoTrans: PROV. S AMERICAN 1956, Venez
    /// Ellipsoid: International_1924,  DeltaX: -295,  SigmaX: 9,  DeltaY: 173,  SigmaY: 14,  DeltaZ: -371,  SigmaZ: 15,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 18,  South: -5,  East: -54,  West: -79
    /// </summary>
    public class SAmericanVenez1956 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal SAmericanVenez1956()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -295;
            this.SigmaX = 9;
            this.DeltaY = 173;
            this.SigmaY = 14;
            this.DeltaZ = -371;
            this.SigmaZ = 15;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 18;
            this.Domain.Left = -79;
            this.Domain.Bottom = -5;
            this.Domain.Right = -54;
        }
    }
}


