// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// Interface used to represent Angular Unit Name/Value pairs.
    /// </summary>
    public interface IAngularUnit
    {
        /// <summary>
        /// Gets the Name of the AngularUnit
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the Value of the AngularUnit
        /// </summary>
        double Value { get; }

        /// <summary>
        /// Gets the XML representation of the AngularUnit
        /// </summary>
        /// <returns>An XML formatted string.</returns>
        string ToXml();
    }
}


