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

namespace StarThrower.Gis.GeoUtilities.Formatting
{
    /// <summary>
    /// An enumeration of the various XML formats available to the GeoUtilities Formatting framework.
    /// </summary>
    public enum XmlFormat
    {
        /// <summary>
        /// Data is represented in a manner that easily maps to ESRI formatted shapefiles with
        /// major (separate) elements for geography and data.
        /// </summary>
        FileWise = 0,

        /// <summary>
        /// Data is represented in a manner that easily maps to a map layer with geography and
        /// data combined for each record.
        /// </summary>
        LayerWise = 1,

        /// <summary>
        /// Data is represented in the standard Geographic Markup Language (GML) format.
        /// </summary>
        Gml = 2
    }
}
