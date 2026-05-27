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
    /// NGIA GeoTrans: BELLEVUE (IGN), Efate Is.
    /// Ellipsoid: International_1924,  DeltaX: -127,  SigmaX: 20,  DeltaY: -769,  SigmaY: 20,  DeltaZ: 472,  SigmaZ: 20,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -16,  South: -20,  East: 171,  West: 167
    /// </summary>
    public class BellevueEfate : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal BellevueEfate()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -127;
            this.SigmaX = 20;
            this.DeltaY = -769;
            this.SigmaY = 20;
            this.DeltaZ = 472;
            this.SigmaZ = 20;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -16;
            this.Domain.Left = 167;
            this.Domain.Bottom = -20;
            this.Domain.Right = 171;
        }
    }
}
