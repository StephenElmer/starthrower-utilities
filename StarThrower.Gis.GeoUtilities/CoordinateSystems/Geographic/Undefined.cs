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

namespace StarThrower.Gis.GeoUtilities.CoordinateSystems.Geographic
{
    /// <summary>
    /// An implementation of the "null object" pattern for the IGeographicCoordinateSystem interface.
    /// </summary>
    public class Undefined : GeographicCoordinateSystem
    {
        #region Construction

        internal Undefined() : base()
        {
            this.Datum = DatumFactory.GetInstanceOfDatum(typeof(Datums.Undefined));
            this.PrimeMeridian = PrimeMeridianFactory.GetInstanceOfPrimeMeridian(typeof(PrimeMeridians.Undefined));
            this.AngularUnit = AngularUnitFactory.GetInstanceOfAngularUnit(typeof(AngularUnits.Undefined));
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Provides an implementation of the IGeographicCoordinateSystem interface for this "null" object.
        /// </summary>
        /// <param name="xLon">xLon value.</param>
        /// <param name="yLat">yLat value.</param>
        /// <param name="zAlt">Altitude value.</param>
        /// <returns>This method will always throw an InvalidOperationException.</returns>
        /// <exception cref="InvalidOperationException">Thrown any time this method is called.</exception>
        public override ITranslationResult ToGeodetic(double xLon, double yLat, double zAlt)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Provides an implementation of the IGeographicCoordinateSystem interface for this "null" object.
        /// </summary>
        /// <param name="xLon">xLon value.</param>
        /// <param name="yLat">yLat value.</param>
        /// <param name="zAlt">Altitude value.</param>
        /// <returns>This method will always throw an InvalidOperationException.</returns>
        /// <exception cref="InvalidOperationException">Thrown any time this method is called.</exception>
        public override ITranslationResult FromGeodetic(double xLon, double yLat, double zAlt)
        {
            throw new InvalidOperationException();
        }

        #endregion
    }
}
