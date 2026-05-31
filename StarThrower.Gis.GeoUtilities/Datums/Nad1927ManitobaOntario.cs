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
    /// NGIA GeoTrans: NORTH AMERICAN 1927, Man/Ont
    /// Ellipsoid: Clarke_1866,  DeltaX: -9,  SigmaX: 9,  DeltaY: 157,  SigmaY: 5,  DeltaZ: 184,  SigmaZ: 5,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 63,  South: 36,  East: -69,  West: -108
    /// </summary>
    public class Nad1927ManitobaOntario : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1927ManitobaOntario()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = -9;
            this.SigmaX = 9;
            this.DeltaY = 157;
            this.SigmaY = 5;
            this.DeltaZ = 184;
            this.SigmaZ = 5;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 63;
            this.Domain.Left = -108;
            this.Domain.Bottom = 36;
            this.Domain.Right = -69;
        }
    }
}


