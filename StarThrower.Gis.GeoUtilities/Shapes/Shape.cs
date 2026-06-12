// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Shapes
{
    public enum ShapeType
    {
        NullShape = 0,
        Point = 1,
        Polyline = 3,
        Polygon = 5,
        Multipoint = 8,
        PointZ = 11,
        PolylineZ = 13,
        PolygonZ = 15,
        MultipointZ = 18,
        PointM = 21,
        PolylineM = 23,
        PolygonM = 25,
        MultipointM = 28,
        Multipatch = 31
    }

    public abstract class Shape : ICloneable
    {
        #region Private Instance Variables

        private StarThrower.Gis.GeoUtilities.Shapes.ShapeType _shapeType;

        #endregion


        #region Public Properties

        public StarThrower.Gis.GeoUtilities.Shapes.ShapeType ShapeType 
        {
            get { return _shapeType; }
            protected set { _shapeType = value; }
        }

        #endregion


        #region ICloneable Members

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


