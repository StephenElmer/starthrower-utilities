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
    /// NGIA GeoTrans: TIMBALAI 1948, Brunei and E Malay
    /// Ellipsoid: Everest_Definition_1967,  DeltaX: -679,  SigmaX: 10,  DeltaY: 669,  SigmaY: 10,  DeltaZ: -48,  SigmaZ: 12,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 15,  South: -5,  East: 125,  West: 101
    /// </summary>
    public class TimbalaiBruneiEMalay1948 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal TimbalaiBruneiEMalay1948()
        {
            this.Ellipsoid = new Ellipsoids.EverestDefinition1967();
            this.DeltaX = -679;
            this.SigmaX = 10;
            this.DeltaY = 669;
            this.SigmaY = 10;
            this.DeltaZ = -48;
            this.SigmaZ = 12;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 15;
            this.Domain.Left = 101;
            this.Domain.Bottom = -5;
            this.Domain.Right = 125;
        }
    }
}
