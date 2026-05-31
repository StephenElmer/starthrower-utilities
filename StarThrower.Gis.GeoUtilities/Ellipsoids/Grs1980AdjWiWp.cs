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
    /// ESRI ArcIMS: GRS_1980_Adj_WI_WP
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378375.251, Flattening: 1 / 298.268363297321
    /// </summary>
    public class Grs1980AdjWiWp : Ellipsoid
    {
        internal Grs1980AdjWiWp()
        {
            this.EquatorialRadius = 6378375.251;
            this.Flattening = 1 / 298.268363297321;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


