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
    /// NGIA GeoTrans: YACARE, Uruguay
    /// Ellipsoid: International_1924,  DeltaX: -155,  SigmaX: -1,  DeltaY: 171,  SigmaY: -1,  DeltaZ: 37,  SigmaZ: -1,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -25,  South: -40,  East: -47,  West: -65
    /// </summary>
    public class YacareUruguay : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal YacareUruguay()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -155;
            this.SigmaX = -1;
            this.DeltaY = 171;
            this.SigmaY = -1;
            this.DeltaZ = 37;
            this.SigmaZ = -1;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -25;
            this.Domain.Left = -65;
            this.Domain.Bottom = -40;
            this.Domain.Right = -47;
        }
    }
}
