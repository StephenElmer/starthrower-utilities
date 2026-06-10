// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// Interface used to represent Linear Unit Name/Value pairs.
    /// </summary>
    public interface ILinearUnit
    {
        /// <summary>
        /// Gets the Name of the LinearUnit
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the Value of the LinearUnit
        /// </summary>
        double Value { get; }

        /// <summary>
        /// Gets the XML representation of the LinearUnit
        /// </summary>
        /// <returns>An XML formatted string.</returns>
        string ToXml();
    }
}


