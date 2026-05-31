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
    /// NGIA GeoTrans: ORDNANCE GB 1936, Mean (7 Para)
    /// Ellipsoid: Airy_1830,  DeltaX: 446,  SigmaX: 0,  DeltaY: -99,  SigmaY: 0,  DeltaZ: 544,  SigmaZ: 0,  RotationX: -0.945,  RotationY: -0.261,  RotationZ: -0.435,  ScaleFactor: -2.08927E-05,  North: 90,  South: -90,  East: 180,  West: -180
    /// </summary>
    public class Osgb1936 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return true; }
        }

        internal Osgb1936()
        {
            this.Ellipsoid = new Ellipsoids.Airy1830();
            this.DeltaX = 446;
            this.SigmaX = 0;
            this.DeltaY = -99;
            this.SigmaY = 0;
            this.DeltaZ = 544;
            this.SigmaZ = 0;
            this.RotationX = -0.945;
            this.RotationY = -0.261;
            this.RotationZ = -0.435;
            this.RotationScaleFactor = -2.08927E-05;
            this.Domain.Top = 90;
            this.Domain.Left = -180;
            this.Domain.Bottom = -90;
            this.Domain.Right = 180;
        }
    }
}


