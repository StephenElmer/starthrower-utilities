// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StarThrower.Gis.GeoUtilities.Shapes
{
    /// <summary>
    /// The abstract base class for a single part (ring or line) of a <see cref="PolygonShape"/>
    /// or <see cref="PolylineShape"/>, represented as an ordered list of points.
    /// </summary>
    public abstract class Part : ICloneable
    {
        #region Private Instance Variables

        private Collection<StarThrower.Gis.GeoUtilities.Shapes.PointShape> _pointList = new Collection<StarThrower.Gis.GeoUtilities.Shapes.PointShape>();

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets the ordered list of points that make up this part.
        /// </summary>
        protected Collection<StarThrower.Gis.GeoUtilities.Shapes.PointShape> PointList
        {
            get { return _pointList; }
        }

        /// <summary>
        /// Gets the number of points in this part.
        /// </summary>
        public int PointCount
        {
            get { return _pointList.Count; }
        }

        #endregion


        #region Internal Properties

        internal StarThrower.Gis.GeoUtilities.GeoRectangle Extent
        {
            get
            {
                if (_pointList.Count == 0) return new StarThrower.Gis.GeoUtilities.GeoRectangle(0.0, 0.0, 0.0, 0.0);
                double left = 180.0;
                double top = -90.0;
                double right = -180.0;
                double bottom = 90.0;
                foreach (StarThrower.Gis.GeoUtilities.Shapes.PointShape point in _pointList)
                {
                    if (point.xLon < left) left = point.xLon;
                    if (point.yLat > top) top = point.yLat;
                    if (point.xLon > right) right = point.xLon;
                    if (point.yLat < bottom) bottom = point.yLat;
                }
                return new StarThrower.Gis.GeoUtilities.GeoRectangle(left, top, right, bottom);
            }
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Appends a point to the end of this part.
        /// </summary>
        /// <param name="point">The point to add.</param>
        public void AddPoint(StarThrower.Gis.GeoUtilities.Shapes.PointShape point)
        {
            _pointList.Add(point);
        }

        /// <summary>
        /// Gets the point at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the point to retrieve.</param>
        /// <returns>The point at <paramref name="index"/>.</returns>
        public StarThrower.Gis.GeoUtilities.Shapes.PointShape GetPoint(int index)
        {
            return _pointList[index];
        }

        #endregion


        #region ICloneable Members

        /// <summary>
        /// Creates a deep copy of this part.
        /// </summary>
        /// <returns>A new object that is a deep copy of this part.</returns>
        public abstract object Clone();

        #endregion


        #region IItemCopyable Members

        /// <summary>
        /// Sets the state of the current instance equal to a copy of the state of some other instance.
        /// </summary>
        /// <param name="value">The instance you wish this to be a copy of. Must be a <see cref="Part"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not a <see cref="Part"/>.</exception>
        public virtual void ItemCopy(object value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (!(value is StarThrower.Gis.GeoUtilities.Shapes.Part)) throw new ArgumentException("Could not cast " + value.GetType().ToString() + " to " + this.GetType().ToString());
            StarThrower.Gis.GeoUtilities.Shapes.Part other = (StarThrower.Gis.GeoUtilities.Shapes.Part)value;
            _pointList.Clear();
            foreach (StarThrower.Gis.GeoUtilities.Shapes.PointShape point in other._pointList)
            {
                _pointList.Add((PointShape)(point.Clone()));
            }
        }

        #endregion

    }
}


