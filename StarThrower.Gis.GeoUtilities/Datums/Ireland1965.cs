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
    /// NGIA GeoTrans: IRELAND 1965
    /// Ellipsoid: Airy_Modified,  DeltaX: 506,  SigmaX: 3,  DeltaY: -122,  SigmaY: 3,  DeltaZ: 611,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 57,  South: 50,  East: -4,  West: -12
    /// </summary>
    public class Ireland1965 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Ireland1965()
        {
            this.Ellipsoid = new Ellipsoids.AiryModified();
            this.DeltaX = 506;
            this.SigmaX = 3;
            this.DeltaY = -122;
            this.SigmaY = 3;
            this.DeltaZ = 611;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 57;
            this.Domain.Left = -12;
            this.Domain.Bottom = 50;
            this.Domain.Right = -4;
        }
    }
}
