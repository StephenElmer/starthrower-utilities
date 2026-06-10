// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

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


