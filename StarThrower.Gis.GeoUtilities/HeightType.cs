using System;

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// Identifies whether, and how, a coordinate system's vertical (height/altitude) component
    /// should be converted between ellipsoid height and mean-sea-level (geoid) height during
    /// a translation between coordinate systems.
    /// </summary>
    public enum HeightType
    {
        /// <summary>The coordinate system has no meaningful height component; height is always treated as zero.</summary>
        NoHeight = 0,

        /// <summary>Height is expressed relative to the reference ellipsoid; no geoid correction is applied.</summary>
        EllipsoidHeight = 1,

        /// <summary>Height is mean-sea-level (geoid) height, converted to/from ellipsoid height using this library's built-in geoid undulation model.</summary>
        GeoidOrMslHeight = 2,

        /// <summary>Height is mean-sea-level height per the EGM96 geoid model, converted to/from ellipsoid height using natural-spline interpolation.</summary>
        MslEgm96VgNsHeight = 3,

        /// <summary>Height is mean-sea-level height per the EGM84 (10-degree grid) geoid model, converted to/from ellipsoid height using bilinear interpolation.</summary>
        MslEgm8410dBlHeight = 4,

        /// <summary>Height is mean-sea-level height per the EGM84 (10-degree grid) geoid model, converted to/from ellipsoid height using natural-spline interpolation.</summary>
        MslEgm8410dNsHeight = 5
    }
}
