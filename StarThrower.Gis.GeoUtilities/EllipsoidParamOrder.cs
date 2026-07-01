using System;

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// Indicates which two ellipsoid parameters a pair of double values represents.
    /// </summary>
    /// <remarks>
    /// Consumed by the internal <see cref="Ellipsoids.UserDefined"/> constructor to indicate the meaning
    /// of its <c>paramOne</c> and <c>paramTwo</c> arguments. Note that
    /// <see cref="EllipsoidFactory.GetInstanceOfNewUserDefinedEllipsoid"/>, the only public entry point that
    /// creates a <see cref="Ellipsoids.UserDefined"/> instance, always passes
    /// <see cref="EquatorialRadiusFlattening"/>, so the other two values are not currently reachable through
    /// the public API.
    /// </remarks>
    public enum EllipsoidParamOrder
    {
        /// <summary>
        /// Indicates paramOne maps to EquatorialRadius and paramTwo maps to PolarRadius.
        /// </summary>
        EquatorialRadiusPolarRadius = 0,

        /// <summary>
        /// Indicates paramOne maps to EquatorialRadius and paramTwo maps to Flattening.
        /// </summary>
        EquatorialRadiusFlattening = 1,

        /// <summary>
        /// Indicates paramOne maps to PolarRadius and paramTwo maps to Flattening.
        /// </summary>
        PolarRadiusFlattening = 2
    }
}
