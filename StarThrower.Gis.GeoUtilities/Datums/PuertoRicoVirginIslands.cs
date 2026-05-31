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
    /// NGIA GeoTrans: PUERTO RICO and Virgin Is.
    /// Ellipsoid: Clarke_1866,  DeltaX: 11,  SigmaX: 3,  DeltaY: 72,  SigmaY: 3,  DeltaZ: -101,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 20,  South: 16,  East: -63,  West: -69
    /// </summary>
    public class PuertoRicoVirginIslands : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal PuertoRicoVirginIslands()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = 11;
            this.SigmaX = 3;
            this.DeltaY = 72;
            this.SigmaY = 3;
            this.DeltaZ = -101;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 20;
            this.Domain.Left = -69;
            this.Domain.Bottom = 16;
            this.Domain.Right = -63;
        }
    }
}


