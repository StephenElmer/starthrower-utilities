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

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: Everest_Definition_1962
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6377301.243, Flattening: 1 / 300.8017255
    /// </summary>
    public class EverestDefinition1962 : Ellipsoid
    {
        internal EverestDefinition1962()
        {
            this.EquatorialRadius = 6377301.243;
            this.Flattening = 1 / 300.8017255;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


