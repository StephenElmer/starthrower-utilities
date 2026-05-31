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
    /// NGIA GeoTrans: INDIAN, India and Nepal
    /// Ellipsoid: Everest_1956_India,  DeltaX: 295,  SigmaX: 12,  DeltaY: 736,  SigmaY: 10,  DeltaZ: 257,  SigmaZ: 15,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 44,  South: 2,  East: 105,  West: 62
    /// </summary>
    public class IndianIndiaNepal : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal IndianIndiaNepal()
        {
            this.Ellipsoid = new Ellipsoids.Everest1956India();
            this.DeltaX = 295;
            this.SigmaX = 12;
            this.DeltaY = 736;
            this.SigmaY = 10;
            this.DeltaZ = 257;
            this.SigmaZ = 15;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 44;
            this.Domain.Left = 62;
            this.Domain.Bottom = 2;
            this.Domain.Right = 105;
        }
    }
}


