// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// A rectangular geographic region, defined by an upper-left and lower-right <see cref="GeoPoint"/>.
    /// Used to represent the valid domain of a <see cref="Datum"/>.
    /// </summary>
    public class GeoRectangle
    {
        #region Private Member Variables

        private GeoPoint _upperLeft = new GeoPoint();
        private GeoPoint _lowerRight = new GeoPoint();

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets or sets the latitude of the bottom edge of this rectangle, in decimal degrees.
        /// </summary>
        public double Bottom
        {
            get { return _lowerRight.yLat; }
            set { _lowerRight.yLat = value; }
        }

        /// <summary>
        /// Gets or sets the height of this rectangle (the difference between <see cref="Bottom"/> and <see cref="Top"/>), in decimal degrees.
        /// Setting this adjusts <see cref="Bottom"/>, keeping <see cref="Top"/> fixed.
        /// </summary>
        public double Height
        {
            get { return _lowerRight.yLat - _upperLeft.yLat; }
            set { _lowerRight.yLat = _upperLeft.yLat + value;  }
        }

        /// <summary>
        /// Gets whether this rectangle's upper-left and lower-right points are both at the origin (0, 0).
        /// </summary>
        public bool IsEmpty
        {
            get { return _upperLeft.xLon == 0.0 && _upperLeft.yLat == 0.0 && _lowerRight.xLon == 0.0 && _lowerRight.yLat == 0.0; }
        }

        /// <summary>
        /// Gets or sets the longitude of the left edge of this rectangle, in decimal degrees.
        /// </summary>
        public double Left
        {
            get { return _upperLeft.xLon; }
            set { _upperLeft.xLon = value; }
        }

        /// <summary>
        /// Gets or sets the upper-left point of this rectangle.
        /// </summary>
        public GeoPoint Location
        {
            get { return _upperLeft; }
            set { _upperLeft = value; }
        }

        /// <summary>
        /// Gets or sets the longitude of the right edge of this rectangle, in decimal degrees.
        /// </summary>
        public double Right
        {
            get { return _lowerRight.xLon; }
            set { _lowerRight.xLon = value; }
        }

        /// <summary>
        /// Gets or sets the latitude of the top edge of this rectangle, in decimal degrees.
        /// </summary>
        public double Top
        {
            get { return _upperLeft.yLat; }
            set { _upperLeft.yLat = value; }
        }

        /// <summary>
        /// Gets or sets the width of this rectangle (the difference between <see cref="Right"/> and <see cref="Left"/>), in decimal degrees.
        /// Setting this adjusts <see cref="Right"/>, keeping <see cref="Left"/> fixed.
        /// </summary>
        public double Width
        {
            get { return _lowerRight.xLon - _upperLeft.xLon; }
            set { _lowerRight.xLon = _upperLeft.xLon + value; }
        }

        /// <summary>
        /// Gets or sets the longitude of the upper-left point of this rectangle, in decimal degrees. Equivalent to <see cref="Left"/>.
        /// </summary>
        public double X
        {
            get { return _upperLeft.xLon; }
            set { _upperLeft.xLon = value; }
        }

        /// <summary>
        /// Gets or sets the latitude of the upper-left point of this rectangle, in decimal degrees. Equivalent to <see cref="Top"/>.
        /// </summary>
        public double Y
        {
            get { return _upperLeft.yLat; }
            set { _upperLeft.yLat = value; }
        }

        #endregion


        #region Construction

        /// <summary>
        /// Initializes a new, empty GeoRectangle with both corners at the origin (0, 0).
        /// </summary>
        public GeoRectangle() { }

        /// <summary>
        /// Initializes a new GeoRectangle with the specified corner coordinates.
        /// </summary>
        /// <param name="x1">The longitude of the upper-left corner, in decimal degrees.</param>
        /// <param name="y1">The latitude of the upper-left corner, in decimal degrees.</param>
        /// <param name="x2">The longitude of the lower-right corner, in decimal degrees.</param>
        /// <param name="y2">The latitude of the lower-right corner, in decimal degrees.</param>
        public GeoRectangle(double x1, double y1, double x2, double y2) : this()
        {
            _upperLeft.xLon = x1;
            _upperLeft.yLat = y1;
            _lowerRight.xLon = x2;
            _lowerRight.yLat = y2;
        }

        /// <summary>
        /// Initializes a new GeoRectangle as a copy of the specified corner points.
        /// </summary>
        /// <param name="upperLeft">The upper-left corner of the new rectangle.</param>
        /// <param name="lowerRight">The lower-right corner of the new rectangle.</param>
        /// <exception cref="ArgumentNullException">Thrown if upperLeft or lowerRight is null.</exception>
        public GeoRectangle(GeoPoint upperLeft, GeoPoint lowerRight) : this()
        {
            ArgumentNullException.ThrowIfNull(upperLeft);
            ArgumentNullException.ThrowIfNull(lowerRight);

            _upperLeft = (GeoPoint)(upperLeft.Clone());
            _lowerRight = (GeoPoint)(lowerRight.Clone());
        }

        #endregion
    }
}


