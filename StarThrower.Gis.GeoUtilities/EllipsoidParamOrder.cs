using System;

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// An argument to the Ellipsoid constructor to indicate the meaning of some of the proir parameters.
    /// </summary>
    /// <remarks>
    /// This type is used in the Ellipsoid(EllipsoidType, string, double, double, EllipsoidParamOrder) constructor
    /// to indicate the meaning of the two double paramaters.
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
