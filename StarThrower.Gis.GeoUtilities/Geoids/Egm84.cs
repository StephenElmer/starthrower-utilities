/***********************************************************************************
    StarThrower Utilities
    Copyright (C) 2005-2007  Steve Elmer

    This library is free software; you can redistribute it and/or
    modify it under the terms of the GNU Lesser General Public
    License as published by the Free Software Foundation; either
    version 2.1 of the License, or (at your option) any later version.

    This library is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
    Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public
    License along with this library; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
***********************************************************************************/

using System;
using System.IO;
using System.Reflection;
using StarThrower.ByteUtilities;
using StarThrower.Logging;

namespace StarThrower.Gis.GeoUtilities.Geoids
{
    public class Egm84 : Geoid
    {
        #region Construction

        internal Egm84() 
        {
            this.Rows = 19; //180 degrees of yLat  at 10 degree spacing
            this.Columns = 37; //360 degrees of xLon at 10 degree spacing
            this.HeightGrid = new float[this.Elevations];
            InitializeHeightGrid();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// converts the specified WGS84 geoid height at the specified geodetic coordinates to the equivalent ellipsoid height, using the EGM84 gravity model and the natural spline interpolation method.
        /// </summary>
        /// <param name="xLon">Geodetic xLon in radians</param>
        /// <param name="yLat">Geodetic yLat in radians</param>
        /// <param name="geoidHeight">Geoid height, in meters.</param>
        /// <param name="ellipsoidHeight">Ellipsoid height, in meters</param>
        public override void ToEllipsoidHeightNs(double xLon, double yLat, double geoidHeight, ref double ellipsoidHeight)
        {
            double delta_height = 0.0;
            NsInterpolate(xLon, yLat, GeoUtil.ScaleFactor10Degrees, ref delta_height);
            ellipsoidHeight = geoidHeight + delta_height;
        }

        /// <summary>
        /// converts the specified WGS84 ellipsoid height at the specified geodetic coordinates to the equivalent geoid height, using the EGM84 gravity model and the natural spline interpolation method.
        /// </summary>
        /// <param name="xLon">Geodetic xLon in radians</param>
        /// <param name="yLat">Geodetic yLat in radians</param>
        /// <param name="ellipsoidHeight">Ellipsoid height, in meters</param>
        /// <param name="geoidHeight">Geoid height, in meters.</param>
        public override void FromEllipsoidHeightNs(double xLon, double yLat, double ellipsoidHeight, ref double geoidHeight)
        {
            double delta_height = 0.0;
            NsInterpolate(xLon, yLat, GeoUtil.ScaleFactor10Degrees, ref delta_height);
            geoidHeight = ellipsoidHeight - delta_height;
        }

        /// <summary>
        /// converts the specified WGS84 geoid height at the specified geodetic coordinates to the equivalent ellipsoid height, using the EGM84 gravity model and the bilinear interpolation method.
        /// </summary>
        /// <param name="xLon">Geodetic xLon in radians</param>
        /// <param name="yLat">Geodetic yLat in radians</param>
        /// <param name="geoidHeight">Geoid height, in meters.</param>
        /// <param name="ellipsoidHeight">Ellipsoid height, in meters</param>
        public override void ToEllipsoidHeightBl(double xLon, double yLat, double geoidHeight, ref double ellipsoidHeight)
        {
            double delta_height = 0.0;
            BlInterpolate(xLon, yLat, GeoUtil.ScaleFactor10Degrees, ref delta_height);
            ellipsoidHeight = geoidHeight + delta_height;
        }

        /// <summary>
        /// converts the specified WGS84 ellipsoid height at the specified geodetic coordinates to the equivalent geoid height, using the EGM84 gravity model and the bilinear interpolation method.
        /// </summary>
        /// <param name="xLon">Geodetic xLon in radians</param>
        /// <param name="yLat">Geodetic yLat in radians</param>
        /// <param name="ellipsoidHeight">Ellipsoid height, in meters</param>
        /// <param name="geoidHeight">Geoid height, in meters.</param>
        public override void FromEllipsoidHeightBl(double xLon, double yLat, double ellipsoidHeight, ref double geoidHeight)
        {
            double delta_height = 0.0;
            BlInterpolate(xLon, yLat, GeoUtil.ScaleFactor10Degrees, ref delta_height);
            geoidHeight = ellipsoidHeight - delta_height;
        }

        #endregion


        #region Private Methods

        private void InitializeHeightGrid()
        {
            Stream? stream = null;
            try
            {
                stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("StarThrower.Gis.GeoUtilities.Geoids.egm84.grd");

                if (stream == null || !stream.CanRead) throw new IOException("Stream is not in a readable mode.");

                int pos = 0;
                byte[] buf = new byte[this.Elevations];
                stream.Seek(0, SeekOrigin.Begin);
                Int32 bytesRead = stream.Read(buf, 0, this.Elevations);
                if ((bytesRead % 4) == 0)
                {
                    for (int i = 0; i < bytesRead; i += 4)
                    {
                        byte[] chunk = ByteUtil.ByteSubstring(buf, i, 4);
                        float f = ByteUtil.ByteArrayToSingle(chunk, ByteEndian.Big, BitEndian.Little);
                        this.HeightGrid[pos] = f;
                        pos++;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Egm84.InitializeHeightGrid()", ex);
                throw;
            }
            finally
            {

                if (stream != null)
                {
                    stream.Close();
                }
                if (stream != null)
                {
                    stream.Dispose();
                }
            }
         }

        #endregion
    }
}
