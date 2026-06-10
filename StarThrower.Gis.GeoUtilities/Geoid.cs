// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text;
using StarThrower.Gis.GeoUtilities.Geoids;

namespace StarThrower.Gis.GeoUtilities
{
    public abstract class Geoid : IGeoid
    {
        /// <summary>
        /// The regular expression pattern to which the Geoid's Name field must match.
        /// </summary>
        public const string ValidNamePattern = @"^[a-zA-Z_0-9]+$";


        private int _rows;
        private int _columns;
        private float[] _heightGrid = Array.Empty<float>();


        #region Public Properties

        /// <summary>
        /// Gets the name of the Geoid.
        /// This is really only necessary if GeoidType == GeoidType.UserDefined
        /// as it is intended to distinguish one UserDefined Geoid from another.
        /// </summary>
        public virtual string Name
        {
            get { return this.GetType().Name; }
        }

        /// <summary>
        /// Gets the key value of the Geoid.
        /// If GeoidType == GeoidType.UserDefined, the Key will be the GeoidType,
        /// otherwise, it will be the GeoidType + Name so that UserDefined geoids
        /// may be distinguished from one another.
        /// </summary>
        public string Key
        {
            get
            {
                if (this is UserDefined)
                {
                    return this.GetType().Name + this.Name;
                }
                else
                {
                    return this.GetType().Name;
                }
            }
        }

        public int Rows
        {
            get { return _rows; }
            protected set { _rows = value; }
        }

        public int Columns
        {
            get { return _columns; }
            protected set { _columns = value; }
        }

        public int Elevations
        {
            get { return _rows * _columns; }
        }

        public float[] HeightGrid
        {
            get { return _heightGrid; }
            protected set { _heightGrid = value; }
        }

        #endregion


        #region Public Methods

        public virtual void ToEllipsoidHeightNs(double xLon, double yLat, double geoidHeight, ref double ellipsoidHeight)
        {
            throw new NotSupportedException();
        }

        public virtual void FromEllipsoidHeightNs(double xLon, double yLat, double ellipsoidHeight, ref double geoidHeight)
        {
            throw new NotSupportedException();
        }

        public virtual void ToEllipsoidHeightBl(double xLon, double yLat, double geoidHeight, ref double ellipsoidHeight)
        {
            throw new NotSupportedException();
        }

        public virtual void FromEllipsoidHeightBl(double xLon, double yLat, double ellipsoidHeight, ref double geoidHeight)
        {
            throw new NotSupportedException();
        }


        /// <summary>
        /// returns the height of the WGS84 geoid above or below the WGS84 ellipsoid, at the specified geodetic coordinates, using a grid of height adjustments and the natural spline interpolation method.
        /// </summary>
        /// <param name="xLon">Geodetic xLon in radians</param>
        /// <param name="yLat">Geodetic yLat in radians</param>
        /// <param name="scaleFactor">Grid scale factor</param>
        /// <param name="num_cols">Number of columns in grid</param>
        /// <param name="num_rows">Number of rows in grid</param>
        /// <param name="max_index"></param>
        /// <param name="height_buffer">Grid of height adjustments</param>
        /// <param name="deltaHeight">Height Adjustment, in meters.</param>
        public void NsInterpolate(double longitude, double latitude, double scaleFactor, ref double deltaHeight)
        {
            int num_cols = _columns;
            int num_rows = _rows;
            float[] height_buffer = _heightGrid;
            int max_index = this.Elevations;

            int index;
            int post_x, post_y;
            int temp_offset_x, temp_offset_y;
            double offset_x, offset_y;
            double delta_x, delta_y;
            double delta_x2, delta_y2;
            double _1_minus_delta_x, _1_minus_delta_y;
            double _1_minus_delta_x2, _1_minus_delta_y2;
            double _3_minus_2_times_1_minus_delta_x, _3_minus_2_times_1_minus_delta_y;
            double _3_minus_2_times_delta_x, _3_minus_2_times_delta_y;
            double latitude_dd, longitude_dd;
            double height_se, height_sw, height_ne, height_nw;
            double w_sw, w_se, w_ne, w_nw;
            double south_lat, west_lon;
            int end_index = 0;
            double skip_factor = 1.0;

            if ((latitude < -GeoUtil.PiOver2) || (latitude > GeoUtil.PiOver2))
            {
                throw new ArgumentOutOfRangeException(nameof(latitude));
            }
            if ((longitude < -Math.PI) || (longitude > GeoUtil.TwoPi))
            {
                throw new ArgumentOutOfRangeException(nameof(longitude));
            }

            latitude_dd = latitude * GeoUtil.PiUnder180;
            longitude_dd = longitude * GeoUtil.PiUnder180;

            //Compute X and Y Offsets into Geoid Height Array

            if (longitude_dd < 0.0)
            {
                offset_x = (longitude_dd + 360.0) / scaleFactor;
            }
            else
            {
                offset_x = longitude_dd / scaleFactor;
            }
            offset_y = (90.0 - latitude_dd) / scaleFactor;

            //Find Four Nearest Geoid Height Cells for specified yLat, xLon
            //Assumes that (0,0) of Geoid Height Array is at Northwest corner

            post_x = (int)offset_x;
            if ((post_x + 1) == num_cols)
            {
                post_x--;
            }
            post_y = (int)(offset_y + 1.0e-11);
            if ((post_y + 1) == num_rows)
            {
                post_y--;
            }

            if (scaleFactor == GeoUtil.ScaleFactor30Minutes)
            {
                skip_factor = 2.0;
                num_rows = _rows;
                num_cols = _columns;
            }
            else if (scaleFactor == GeoUtil.ScaleFactor1Degree)
            {
                skip_factor = 4.0;
                num_rows = _rows;
                num_cols = _columns;
            }
            else if (scaleFactor == GeoUtil.ScaleFactor2Degrees)
            {
                skip_factor = 8.0;
                num_rows = _rows;
                num_cols = _columns;
            }

            temp_offset_x = (int)(post_x * skip_factor);
            temp_offset_y = (int)(post_y * skip_factor + 1.0e-11);
            if ((temp_offset_x + 1) == num_cols)
            {
                temp_offset_x--;
            }
            if ((temp_offset_y + 1) == num_rows)
            {
                temp_offset_y--;
            }

            //NW Height
            index = (int)(temp_offset_y * num_cols + temp_offset_x);
            if (index < 0)
            {
                height_nw = height_buffer[0];
            }
            else if (index > max_index)
            {
                height_nw = height_buffer[max_index];
            }
            else
            {
                height_nw = height_buffer[index];
            }

            // NE Height
            end_index = index + (int)skip_factor;
            if (end_index < 0)
            {
                height_ne = height_buffer[0];
            }
            else if (end_index > max_index)
            {
                height_ne = height_buffer[max_index];
            }
            else
            {
                height_ne = height_buffer[end_index];
            }

            // SW Height
            index = (int)((temp_offset_y + skip_factor) * num_cols + temp_offset_x);
            if (index < 0)
            {
                height_sw = height_buffer[0];
            }
            else if (index > max_index)
            {
                height_sw = height_buffer[max_index];
            }
            else
            {
                height_sw = height_buffer[index];
            }

            // SE Height
            end_index = index + (int)skip_factor;
            if (end_index < 0)
            {
                height_se = height_buffer[0];
            }
            else if (end_index > max_index)
            {
                height_se = height_buffer[max_index];
            }
            else
            {
                height_se = height_buffer[end_index];
            }

            west_lon = post_x * scaleFactor;

            // North yLat - scale_factor
            south_lat = (90 - (post_y * scaleFactor)) - scaleFactor;

            //Perform Non-Linear Interpolation to compute Height above Ellipsoid:

            if (longitude_dd < 0.0)
            {
                delta_x = (longitude_dd + 360.0 - west_lon) / scaleFactor;
            }
            else
            {
                delta_x = (longitude_dd - west_lon) / scaleFactor;
            }
            delta_y = (latitude_dd - south_lat) / scaleFactor;

            delta_x2 = delta_x * delta_x;
            delta_y2 = delta_y * delta_y;

            _1_minus_delta_x = 1 - delta_x;
            _1_minus_delta_y = 1 - delta_y;

            _1_minus_delta_x2 = _1_minus_delta_x * _1_minus_delta_x;
            _1_minus_delta_y2 = _1_minus_delta_y * _1_minus_delta_y;

            _3_minus_2_times_1_minus_delta_x = 3 - 2 * _1_minus_delta_x;
            _3_minus_2_times_1_minus_delta_y = 3 - 2 * _1_minus_delta_y;

            _3_minus_2_times_delta_x = 3 - 2 * delta_x;
            _3_minus_2_times_delta_y = 3 - 2 * delta_y;

            w_sw = _1_minus_delta_x2 * _1_minus_delta_y2 * (_3_minus_2_times_1_minus_delta_x * _3_minus_2_times_1_minus_delta_y);
            w_se = delta_x2 * _1_minus_delta_y2 * (_3_minus_2_times_delta_x * _3_minus_2_times_1_minus_delta_y);
            w_ne = delta_x2 * delta_y2 * (_3_minus_2_times_delta_x * _3_minus_2_times_delta_y);
            w_nw = _1_minus_delta_x2 * delta_y2 * (_3_minus_2_times_1_minus_delta_x * _3_minus_2_times_delta_y);

            deltaHeight = height_sw * w_sw + height_se * w_se + height_ne * w_ne + height_nw * w_nw;
        }

        /// <summary>
        /// returns the height of the WGS84 geoid above or below the WGS84 ellipsoid, at the specified geodetic coordinates, using a grid of height adjustments and the bilinear interpolation method.
        /// </summary>
        /// <param name="xLon">Geodetic xLon in radians</param>
        /// <param name="yLat">Geodetic yLat in radians</param>
        /// <param name="scaleFactor">Grid scale factor</param>
        /// <param name="num_cols">Number of columns in grid</param>
        /// <param name="num_rows">Number of rows in grid</param>
        /// <param name="height_buffer"></param>
        /// <param name="deltaHeight">Height Adjustment, in meters</param>
        public void BlInterpolate(double longitude, double latitude, double scaleFactor, ref double deltaHeight)
        {
            int num_cols = _columns;
            int num_rows = _rows;
            float[] height_buffer = _heightGrid;

            int index;
            int post_x, post_y;
            double offset_x, offset_y;
            double delta_x, delta_y;
            double _1_minus_delta_x, _1_minus_delta_y;
            double latitude_dd, longitude_dd;
            double height_se, height_sw, height_ne, height_nw;
            double w_sw, w_se, w_ne, w_nw;
            double south_lat, west_lon;
            int end_index = 0;
            int max_index = num_rows * num_cols - 1;

            if ((latitude < -GeoUtil.PiOver2) || (latitude > GeoUtil.PiOver2))
            {
                throw new ArgumentOutOfRangeException(nameof(latitude));
            }
            if ((longitude < -Math.PI) || (longitude > GeoUtil.TwoPi))
            {
                throw new ArgumentOutOfRangeException(nameof(longitude));
            }

            latitude_dd = latitude * GeoUtil.PiUnder180;
            longitude_dd = longitude * GeoUtil.PiUnder180;

            //Compute X and Y Offsets into Geoid Height Array

            if (longitude_dd < 0.0)
            {
                offset_x = (longitude_dd + 360.0) / scaleFactor;
            }
            else
            {
                offset_x = longitude_dd / scaleFactor;
            }
            offset_y = (90 - latitude_dd) / scaleFactor;

            //Find Four Nearest Geoid Height Cells for specified yLat, xLon
            //Assumes that (0,0) of Geoid Height Array is at Northwest corner

            post_x = (int)(offset_x);
            if ((post_x + 1) == num_cols)
            {
                post_x--;
            }
            post_y = (int)(offset_y + 1.0e-11);
            if ((post_y + 1) == num_rows)
            {
                post_y--;
            }

            // NW Height
            index = post_y * num_cols + post_x;
            if (index < 0)
            {
                height_nw = height_buffer[0];
            }
            else if (index > max_index)
            {
                height_nw = height_buffer[max_index];
            }
            else
            {
                height_nw = height_buffer[index];
            }

            // NE Height
            end_index = index + 1;
            if (end_index > max_index)
            {
                height_ne = height_buffer[max_index];
            }
            else
            {
                height_ne = height_buffer[end_index];
            }

            // SW Height
            index = (post_y + 1) * num_cols + post_x;
            if (index < 0)
            {
                height_sw = height_buffer[0];
            }
            else if (index > max_index)
            {
                height_sw = height_buffer[max_index];
            }
            else
            {
                height_sw = height_buffer[index];
            }

            // SE Height
            end_index = index + 1;
            if (end_index > max_index)
            {
                height_se = height_buffer[max_index];
            }
            else
            {
                height_se = height_buffer[end_index];
            }

            west_lon = post_x * scaleFactor;

            // North yLat - scale_factor
            south_lat = (90 - (post_y * scaleFactor)) - scaleFactor;

            //Perform Bi-Linear Interpolation to compute Height above Ellipsoid

            if (longitude_dd < 0.0)
            {
                delta_x = (longitude_dd + 360.0 - west_lon) / scaleFactor;
            }
            else
            {
                delta_x = (longitude_dd - west_lon) / scaleFactor;
            }
            delta_y = (latitude_dd - south_lat) / scaleFactor;

            _1_minus_delta_x = 1 - delta_x;
            _1_minus_delta_y = 1 - delta_y;

            w_sw = _1_minus_delta_x * _1_minus_delta_y;
            w_se = delta_x * _1_minus_delta_y;
            w_ne = delta_x * delta_y;
            w_nw = _1_minus_delta_x * delta_y;

            deltaHeight = height_sw * w_sw + height_se * w_se + height_ne * w_ne + height_nw * w_nw;
        }


        /// <summary>
        /// Gets an XML representation of the Geoid.
        /// </summary>
        /// <returns></returns>
        public virtual string ToXml()
        {
            StringBuilder result = new StringBuilder(String.Empty);


            result.Append("<geoid geoidType=\"" + this.GetType().Name + "\" rows=\"" + _rows.ToString(CultureInfo.InvariantCulture) + "\" columns=\"" + _columns.ToString(CultureInfo.InvariantCulture) + "\">\n");
            result.Append("<heightGrid>\n");
            for (int i = 0; i < _heightGrid.Length; i++)
            {
                result.Append("<item index=\"" + i.ToString(CultureInfo.InvariantCulture) + "\" value=\"" + _heightGrid[i].ToString(CultureInfo.InvariantCulture) + "\"/>\n");
            }
            result.Append("</heightGrid>\n");
            result.Append("</geoid>\n");

            return result.ToString();
        }

        #endregion


        #region Object Overrides

        /// <summary>
        /// Tests whether the given object is equal to this object.
        /// </summary>
        /// <param name="obj">The object to compare to this object.</param>
        /// <returns>true if other is an instance of the same class as this object and has reference or value equality with this object; otherwise, false.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        public override bool Equals(object? obj)
        {
            if (Object.ReferenceEquals(obj, null)) return false;
            if (Object.ReferenceEquals(obj, this)) return true;
            if (!(obj.GetType().Equals(this.GetType()))) return false;
            Geoid other = (Geoid)obj;
            return _rows.Equals(other._rows) &&
                   _columns.Equals(other._columns);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current Geoid.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + this.Name.GetHashCode();
            result = 31 * result + _rows.GetHashCode();
            result = 31 * result + _columns.GetHashCode();
            return result;
        }

        /// <summary>
        /// Returns the string representation of this Geoid.
        /// </summary>
        /// <returns>A string describing this object.</returns>
        /// <remarks>
        /// Returns a string formatted as "[{type}:  {name}={value}[,{name}={value}]]"
        /// </remarks>
        public override string ToString()
        {
            return "[" + this.GetType().Name + ":  Rows=" + _rows.ToString(CultureInfo.InvariantCulture) + ", Columns=" + _columns.ToString(CultureInfo.InvariantCulture) + "]";
        }

        #endregion
    }
}


