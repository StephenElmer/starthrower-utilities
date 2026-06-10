// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities
{
    public interface IProjection
    {
        double this[string parameterName] { get; }

        string ToXml();
    }
}


