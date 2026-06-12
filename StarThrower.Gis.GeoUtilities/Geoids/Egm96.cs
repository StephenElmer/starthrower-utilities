// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using StarThrower.ByteUtilities;

namespace StarThrower.Gis.GeoUtilities.Geoids
{
    public class Egm96 : Geoid
    {
        private sealed class VariableGrid
        {
            #region Private Instance Variables

            private double _minLat;
            private double _maxLat;
            private double _minLon;
            private double _maxLon;

            #endregion


            #region Public Properties

            public double MinLat
            {
                get { return _minLat; }
                set { _minLat = value; }
            }

            public double MaxLat
            {
                get { return _maxLat; }
                set { _maxLat = value; }
            }

            public double MinLon
            {
                get { return _minLon; }
                set { _minLon = value; }
            }

            public double MaxLon
            {
                get { return _maxLon; }
                set { _maxLon = value; }
            }

            #endregion


            #region Construction

            public VariableGrid(double minLat, double maxLat, double minLon, double maxLon)
            {
                _minLat = minLat;
                _maxLat = maxLat;
                _minLon = minLon;
                _maxLon = maxLon;
            }

            #endregion
        }


        #region Private Instance Variables

        private int _insetAreas;
        private VariableGrid[] _variableGridTable = Array.Empty<VariableGrid>();

        #endregion


        #region Construction

        internal Egm96() 
        {
            this.Rows = 721; //180 degrees of yLat  at 15 minute spacing
            this.Columns = 1441; //360 degrees of xLon at 15 minute spacing
            this.HeightGrid = new float[this.Elevations];
            InitializeHeightGrid();

            _insetAreas = 53;
            _variableGridTable = new VariableGrid[_insetAreas];
            InitializeVariableGridTable();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// converts the specified WGS84 geoid height at the specified geodetic coordinates to the equivalent ellipsoid height, using the EGM96 gravity model and the natural spline interpolation method.
        /// </summary>
        /// <param name="xLon">Geodetic xLon in radians</param>
        /// <param name="yLat">Geodetic yLat in radians</param>
        /// <param name="geoidHeight">Geoid height, in meters.</param>
        /// <param name="ellipsoidHeight">Ellipsoid height, in meters</param>
        public override void ToEllipsoidHeightNs(double xLon, double yLat, double geoidHeight, ref double ellipsoidHeight)
        {
            int i = 0;
            int num_cols = this.Columns;
            int num_rows = this.Rows;
            double latitude_degrees = yLat * GeoUtil.PiUnder180;
            double longitude_degrees = xLon * GeoUtil.PiUnder180;
            double scale_factor = GeoUtil.ScaleFactor15Minutes;
            double delta_height = 0.0;
            bool found = false;

            if (longitude_degrees < 0.0)
            {
                longitude_degrees += 360.0;
            }

            while (!found && i < _insetAreas)
            {
                if ((latitude_degrees >= _variableGridTable[i].MinLat) && (longitude_degrees >= _variableGridTable[i].MinLon) &&
                    (latitude_degrees < _variableGridTable[i].MaxLat) && (longitude_degrees < _variableGridTable[i].MaxLon))
                {
                    scale_factor = GeoUtil.ScaleFactor30Minutes; // use 30 minute by 30 minute grid
                    num_cols = 721;
                    num_rows = 361;
                    found = true;
                }

                i++;
            }

            if (!found)
            {
                if (latitude_degrees >= -60.0 && latitude_degrees < 60.0)
                {
                    scale_factor = GeoUtil.ScaleFactor1Degree; // use 1 degree by 1 degree grid
                    num_cols = 361;
                    num_rows = 181;
                }
                else
                {
                    scale_factor = GeoUtil.ScaleFactor2Degrees; // use 2 degree by 2 degree grid
                    num_cols = 181;
                    num_rows = 91;
                }
            }

            NsInterpolate(xLon, yLat, scale_factor, ref delta_height);
            ellipsoidHeight = geoidHeight + delta_height;
        }

        /// <summary>
        /// converts the specified WGS84 ellipsoid height at the specified geodetic coordinates to the equivalent geoid height, using the EGM96 gravity model and the natural spline interpolation method.
        /// </summary>
        /// <param name="xLon">Geodetic xLon in radians</param>
        /// <param name="yLat">Geodetic yLat in radians</param>
        /// <param name="ellipsoidHeight">Ellipsoid height, in meters</param>
        /// <param name="geoidHeight">Geoid height, in meters.</param>
        public override void FromEllipsoidHeightNs(double xLon, double yLat, double ellipsoidHeight, ref double geoidHeight)
        {
            int i = 0;
            int num_cols = this.Columns;
            int num_rows = this.Rows;
            double latitude_degrees = yLat * GeoUtil.PiUnder180;
            double longitude_degrees = xLon * GeoUtil.PiUnder180;
            double scale_factor = GeoUtil.ScaleFactor15Minutes;
            double delta_height = 0.0;
            bool found = false;

            if (longitude_degrees < 0.0)
            {
                longitude_degrees += 360.0;
            }

            while (!found && i < _insetAreas)
            {
                if ((latitude_degrees >= _variableGridTable[i].MinLat) && (longitude_degrees >= _variableGridTable[i].MinLon) &&
                    (latitude_degrees < _variableGridTable[i].MaxLat) && (longitude_degrees < _variableGridTable[i].MaxLon))
                {
                    scale_factor = GeoUtil.ScaleFactor30Minutes; // use 30 minute by 30 minute grid
                    num_cols = 721;
                    num_rows = 361;
                    found = true;
                }

                i++;
            }

            if (!found)
            {
                if (latitude_degrees >= -60.0 && latitude_degrees < 60.0)
                {
                    scale_factor = GeoUtil.ScaleFactor1Degree; // use 1 degree by 1 degree grid
                    num_cols = 361;
                    num_rows = 181;
                }
                else
                {
                    scale_factor = GeoUtil.ScaleFactor2Degrees; // use 2 degree by 2 degree grid
                    num_cols = 181;
                    num_rows = 91;
                }
            }

            NsInterpolate(xLon, yLat, scale_factor, ref delta_height);
            geoidHeight = ellipsoidHeight - delta_height;
        }

        #endregion


        #region Private Methods

        private void InitializeHeightGrid()
        {
            using (Stream? stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("StarThrower.Gis.GeoUtilities.Geoids.egm96.grd"))
            {
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
        }

        private void InitializeVariableGridTable()
        {
            _variableGridTable[0] = new VariableGrid(74.5, 75.5, 273.5, 280.0);
            _variableGridTable[1] = new VariableGrid(66.5, 67.5, 293.5, 295.0);
            _variableGridTable[2] = new VariableGrid(62.5, 64.0, 133.0, 136.5);
            _variableGridTable[3] = new VariableGrid(60.5, 61.5, 208.5, 210.0);
            _variableGridTable[4] = new VariableGrid(60.5, 61.0, 219.0, 220.5);
            _variableGridTable[5] = new VariableGrid(51.0, 53.0, 172.0, 174.5);
            _variableGridTable[6] = new VariableGrid(52.0, 53.0, 192.5, 194.0);
            _variableGridTable[7] = new VariableGrid(51.0, 52.0, 188.5, 191.0);
            _variableGridTable[8] = new VariableGrid(50.0, 52.0, 178.0, 182.5);
            _variableGridTable[9] = new VariableGrid(43.0, 46.0, 148.0, 153.5);
            _variableGridTable[10] = new VariableGrid(43.0, 45.0, 84.0, 89.5);
            _variableGridTable[11] = new VariableGrid(40.0, 41.0, 70.5, 72.0);
            _variableGridTable[12] = new VariableGrid(36.5, 37.0, 78.5, 79.0);
            _variableGridTable[13] = new VariableGrid(36.0, 37.0, 348.0, 349.5);
            _variableGridTable[14] = new VariableGrid(35.0, 36.0, 171.0, 172.5);
            _variableGridTable[15] = new VariableGrid(34.0, 35.0, 140.5, 142.0);
            _variableGridTable[16] = new VariableGrid(29.5, 31.0, 78.5, 81.0);
            _variableGridTable[17] = new VariableGrid(28.5, 30.0, 81.5, 83.0);
            _variableGridTable[18] = new VariableGrid(26.5, 30.0, 142.0, 143.5);
            _variableGridTable[19] = new VariableGrid(26.0, 29.0, 91.5, 96.0);
            _variableGridTable[20] = new VariableGrid(27.5, 29.0, 84.0, 86.5);
            _variableGridTable[21] = new VariableGrid(28.0, 29.0, 342.5, 344.0);
            _variableGridTable[22] = new VariableGrid(26.5, 28.0, 88.5, 90.0);
            _variableGridTable[23] = new VariableGrid(25.0, 26.0, 189.0, 190.5);
            _variableGridTable[24] = new VariableGrid(23.0, 24.0, 195.0, 196.5);
            _variableGridTable[25] = new VariableGrid(21.0, 21.5, 204.0, 204.5);
            _variableGridTable[26] = new VariableGrid(20.0, 21.0, 283.5, 288.0);
            _variableGridTable[27] = new VariableGrid(18.5, 20.5, 204.0, 205.5);
            _variableGridTable[28] = new VariableGrid(18.0, 20.0, 291.0, 296.5);
            _variableGridTable[29] = new VariableGrid(17.0, 18.0, 298.0, 299.5);
            _variableGridTable[30] = new VariableGrid(15.0, 16.0, 122.0, 123.5);
            _variableGridTable[31] = new VariableGrid(12.0, 14.0, 144.5, 147.0);
            _variableGridTable[32] = new VariableGrid(11.0, 12.0, 141.5, 144.0);
            _variableGridTable[33] = new VariableGrid(9.5, 11.5, 125.0, 127.5);
            _variableGridTable[34] = new VariableGrid(10.0, 11.0, 286.0, 287.5);
            _variableGridTable[35] = new VariableGrid(6.0, 9.5, 287.0, 289.5);
            _variableGridTable[36] = new VariableGrid(5.0, 7.0, 124.0, 128.5);
            _variableGridTable[37] = new VariableGrid(-1.0, 1.0, 125.0, 128.5);
            _variableGridTable[38] = new VariableGrid(-3.0, -1.5, 281.0, 282.5);
            _variableGridTable[39] = new VariableGrid(-7.0, -5.0, 150.5, 155.0);
            _variableGridTable[40] = new VariableGrid(-8.0, -7.0, 107.0, 108.5);
            _variableGridTable[41] = new VariableGrid(-9.0, -7.0, 147.0, 149.5);
            _variableGridTable[42] = new VariableGrid(-11.0, -10.0, 161.5, 163.0);
            _variableGridTable[43] = new VariableGrid(-14.5, -13.5, 166.0, 167.5);
            _variableGridTable[44] = new VariableGrid(-18.5, -17.0, 186.5, 188.0);
            _variableGridTable[45] = new VariableGrid(-20.5, -20.0, 168.0, 169.5);
            _variableGridTable[46] = new VariableGrid(-23.0, -20.0, 184.5, 187.0);
            _variableGridTable[47] = new VariableGrid(-27.0, -24.0, 288.0, 290.5);
            _variableGridTable[48] = new VariableGrid(-53.0, -52.0, 312.0, 313.5);
            _variableGridTable[49] = new VariableGrid(-56.0, -55.0, 333.0, 334.5);
            _variableGridTable[50] = new VariableGrid(-61.5, -60.0, 312.5, 317.0);
            _variableGridTable[51] = new VariableGrid(-61.5, -60.5, 300.5, 303.0);
            _variableGridTable[52] = new VariableGrid(-73.0, -72.0, 24.5, 26.0);
        }

        #endregion
    }
}


