// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using StarThrower.Gis.GeoUtilities.Exceptions;

namespace StarThrower.Gis.GeoUtilities.Shapes
{
    /// <summary>
    /// Identifies the geometry type of a shape, using the numeric type codes defined by the
    /// ESRI Shapefile Technical Description.
    /// </summary>
    public enum ShapeType
    {
        /// <summary>A shape with no geometry. Corresponds to <see cref="NullShape"/>.</summary>
        NullShape = 0,
        /// <summary>A single point. Corresponds to <see cref="PointShape"/>.</summary>
        Point = 1,
        /// <summary>One or more disjoint polylines. Corresponds to <see cref="PolylineShape"/>.</summary>
        Polyline = 3,
        /// <summary>One or more rings forming a polygon. Corresponds to <see cref="PolygonShape"/>.</summary>
        Polygon = 5,
        /// <summary>A set of points. Corresponds to <see cref="MultipointShape"/>.</summary>
        Multipoint = 8,
        /// <summary>A single point with a Z (elevation) value. Corresponds to <see cref="PointZShape"/>.</summary>
        PointZ = 11,
        /// <summary>One or more disjoint polylines with Z (elevation) values. Corresponds to <see cref="PolylineZShape"/>.</summary>
        PolylineZ = 13,
        /// <summary>One or more rings forming a polygon with Z (elevation) values. Corresponds to <see cref="PolygonZShape"/>.</summary>
        PolygonZ = 15,
        /// <summary>A set of points with Z (elevation) values. Corresponds to <see cref="MultipointZShape"/>.</summary>
        MultipointZ = 18,
        /// <summary>A single point with a measure value. Corresponds to <see cref="PointMShape"/>.</summary>
        PointM = 21,
        /// <summary>One or more disjoint polylines with measure values. Corresponds to <see cref="PolylineMShape"/>.</summary>
        PolylineM = 23,
        /// <summary>One or more rings forming a polygon with measure values. Corresponds to <see cref="PolygonMShape"/>.</summary>
        PolygonM = 25,
        /// <summary>A set of points with measure values. Corresponds to <see cref="MultipointMShape"/>.</summary>
        MultipointM = 28,
        /// <summary>A collection of surface patches forming a 3-D object. Corresponds to <see cref="MultipatchShape"/>.</summary>
        Multipatch = 31
    }

    /// <summary>
    /// The abstract base class for all ESRI shapefile geometry types.
    /// </summary>
    public abstract class Shape : ICloneable
    {
        #region Private Instance Variables

        private StarThrower.Gis.GeoUtilities.Shapes.ShapeType _shapeType;

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets the <see cref="Shapes.ShapeType"/> of this shape.
        /// </summary>
        public StarThrower.Gis.GeoUtilities.Shapes.ShapeType ShapeType
        {
            get { return _shapeType; }
            protected set { _shapeType = value; }
        }

        #endregion


        #region ICloneable Members

        /// <summary>
        /// Creates a deep copy of this shape.
        /// </summary>
        /// <returns>A new object that is a deep copy of this shape.</returns>
        public abstract object Clone();

        #endregion


        #region IItemCopyable Members

        /// <summary>
        /// Sets the state of the current instance equal to a copy of the state of some other instance.
        /// </summary>
        /// <param name="value">This instance you wish this to be a copy of.  Must be of type Shape.</param>
        /// <exception cref="FailedItemCopyException"></exception>
        public virtual void ItemCopy(object value)
        {
            ArgumentNullException.ThrowIfNull(value);
            Shape other = (Shape)value;
            _shapeType = other.ShapeType;
        }

        #endregion
    }
}


