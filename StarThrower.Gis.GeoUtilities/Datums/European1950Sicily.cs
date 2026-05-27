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
    /// NGIA GeoTrans: EUROPEAN 1950, Sicily(Italy)
    /// Ellipsoid: International_1924,  DeltaX: -97,  SigmaX: 20,  DeltaY: -88,  SigmaY: 20,  DeltaZ: -135,  SigmaZ: 20,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 40,  South: 35,  East: 17,  West: 10
    /// </summary>
    public class European1950Sicily : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal European1950Sicily()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -97;
            this.SigmaX = 20;
            this.DeltaY = -88;
            this.SigmaY = 20;
            this.DeltaZ = -135;
            this.SigmaZ = 20;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 40;
            this.Domain.Left = 10;
            this.Domain.Bottom = 35;
            this.Domain.Right = 17;
        }
    }
}
