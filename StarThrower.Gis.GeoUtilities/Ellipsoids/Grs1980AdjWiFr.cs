// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_FR
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378591.521, Flattening: 1 / 298.278476609315
    /// </summary>
    public class Grs1980AdjWiFr : Ellipsoid
    {
        internal Grs1980AdjWiFr()
        {
            this.EquatorialRadius = 6378591.521;
            this.Flattening = 1 / 298.278476609315;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


