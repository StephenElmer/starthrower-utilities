// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// Represents a map projection: a named, parameterized method for converting between
    /// geographic (latitude/longitude) and projected (planar x/y) coordinates.
    /// </summary>
    public interface IProjection
    {
        /// <summary>
        /// Gets the value of the named projection parameter (e.g. "False_Easting", "Central_Meridian").
        /// </summary>
        /// <param name="parameterName">The name of the projection parameter to retrieve.</param>
        double this[string parameterName] { get; }

        /// <summary>
        /// Gets an XML representation of the projection and its parameters.
        /// </summary>
        /// <returns>An XML formatted string.</returns>
        string ToXml();
    }
}


