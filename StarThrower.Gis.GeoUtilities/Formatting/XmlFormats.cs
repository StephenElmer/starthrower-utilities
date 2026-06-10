// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

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


