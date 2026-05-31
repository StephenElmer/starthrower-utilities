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

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// Interface used to represent Prime Meridian Name/Value pairs.
    /// </summary>
    public interface IPrimeMeridian
    {
        /// <summary>
        /// Gets the Name of the PrimeMeridian
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the Value of the PrimeMeridian
        /// </summary>
        double Value { get; }

        /// <summary>
        /// Gets the XML representation of the PrimeMeridian
        /// </summary>
        /// <returns>An XML formatted string.</returns>
        string ToXml();
    }
}


