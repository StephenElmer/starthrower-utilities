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
    /// ESRI ArcIMS: GRS_1980_Adj_WI_DG
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378414.93, Flattening: 1 / 298.270218784012
    /// </summary>
    public class Grs1980AdjWiDg : Ellipsoid
    {
        internal Grs1980AdjWiDg()
        {
            this.EquatorialRadius = 6378414.93;
            this.Flattening = 1 / 298.270218784012;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


