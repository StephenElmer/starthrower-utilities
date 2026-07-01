// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text;
using System.Collections.Generic;
using StarThrower.ByteUtilities;
using StarThrower.Gis.GeoUtilities;

namespace StarThrower.Gis.EsriLibrary.Internal.Records
{
    /// <summary>
    /// Represents a PolyLine shape record: a bounding box plus a parts-index array and a flat
    /// point array describing one or more connected line segments.
    /// </summary>
    internal sealed class PolyLineRecord : StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecordContent
    {
        #region Private Member Variables

        //bounding box ie extent
        private double _xMin; //bytes 4-11 (Little Endian)
        private double _yMin; //bytes 12-19 (Little Endian)
        private double _xMax; //bytes 20-27 (Little Endian)
        private double _yMax; //bytes 28-35 (Little Endian)

        private Int32 _numParts; //bytes 36-39 (Little Endian)
        private Int32 _numPoints; //bytes 40-43 (Little Endian)
        private List<Int32> _parts = new List<Int32>(); //bytes [44] - [(44 + (4 * _numParts)) - 1] (Little Endian)
        private List<GeoPoint> _points = new List<GeoPoint>(); //bytes [44 + (4 * _numParts)] - [((44 + (4 * _numParts)) + (4 * _numPoints)) - 1] (Little Endian)

        #endregion


        #region Internal Properties

        internal override StarThrower.Gis.GeoUtilities.GeoRectangle Extent
        {
            get
            {
                return new StarThrower.Gis.GeoUtilities.GeoRectangle(_xMin, _yMin, _xMax, _yMax);
            }
        }

        #endregion


        #region Construction

        internal PolyLineRecord(byte[] bytes)
        {
            this.ShapeType = StarThrower.Gis.EsriLibrary.ShapeType.PolyLine;
            ParseBytes(bytes);
        }

        #endregion


        #region Private Methods

        private void ParseBytes(byte[] bytes)
        {
            _xMin = ByteUtil.ByteArrayToDouble(ByteUtil.ByteSubstring(bytes, 4, 8), ByteEndian.Little, BitEndian.Little);
            _yMin = ByteUtil.ByteArrayToDouble(ByteUtil.ByteSubstring(bytes, 12, 8), ByteEndian.Little, BitEndian.Little);
            _xMax = ByteUtil.ByteArrayToDouble(ByteUtil.ByteSubstring(bytes, 20, 8), ByteEndian.Little, BitEndian.Little);
            _yMax = ByteUtil.ByteArrayToDouble(ByteUtil.ByteSubstring(bytes, 28, 8), ByteEndian.Little, BitEndian.Little);

            _numParts = ByteUtil.ByteArrayToInt32(ByteUtil.ByteSubstring(bytes, 36, 4), ByteEndian.Little, BitEndian.Little);
            _numPoints = ByteUtil.ByteArrayToInt32(ByteUtil.ByteSubstring(bytes, 40, 4), ByteEndian.Little, BitEndian.Little);

            Int32 curIdx = 44;
            for (Int32 i = 0; i < _numParts; i++)
            {
                Int32 partVal = ByteUtil.ByteArrayToInt32(ByteUtil.ByteSubstring(bytes, curIdx, 4), ByteEndian.Little, BitEndian.Little);
                _parts.Add(partVal);
                curIdx += 4;
            }

            for (Int32 i = 0; i < _numPoints; i++)
            {
                double x = ByteUtil.ByteArrayToDouble(ByteUtil.ByteSubstring(bytes, curIdx, 8), ByteEndian.Little, BitEndian.Little);
                curIdx += 8;
                double y = ByteUtil.ByteArrayToDouble(ByteUtil.ByteSubstring(bytes, curIdx, 8), ByteEndian.Little, BitEndian.Little);
                curIdx += 8;
                GeoPoint p = new GeoPoint(x, y);
                _points.Add(p);
            }
        }

        /// <summary>
        /// Gets the number of points in the specified part, computed as the gap between that
        /// part's starting point index (from <c>_parts</c>) and the next part's starting
        /// index, or <c>_numPoints</c> if this is the last part.
        /// </summary>
        private Int32 GetNumPointsInPart(Int32 partNumber)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(partNumber);
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(partNumber, _parts.Count);

            if (partNumber == _parts.Count - 1) // it is the last part
            {
                return _numPoints - _parts[partNumber];
            }
            else
            {
                return _parts[partNumber + 1] - _parts[partNumber];
            }
        }

        #endregion


        #region Internal Methods

        internal override byte[] GetBytes()
        {
            byte[] result = new byte[GetLengthInBytes()];

            Int32 curIdx = 0;
            byte[] shapeType = ByteUtil.Int32ToByteArray((Int32)(this.ShapeType), ByteEndian.Little, BitEndian.Little);
            for (Int32 i = 0; i < 4; i++)
            {
                result[curIdx++] = shapeType[i];
            }

            byte[] xMin = ByteUtil.DoubleToByteArray(_xMin, ByteEndian.Little, BitEndian.Little);
            for (Int32 i = 0; i < 8; i++)
            {
                result[curIdx++] = xMin[i];
            }

            byte[] yMin = ByteUtil.DoubleToByteArray(_yMin, ByteEndian.Little, BitEndian.Little);
            for (Int32 i = 0; i < 8; i++)
            {
                result[curIdx++] = yMin[i];
            }

            byte[] xMax = ByteUtil.DoubleToByteArray(_xMax, ByteEndian.Little, BitEndian.Little);
            for (Int32 i = 0; i < 8; i++)
            {
                result[curIdx++] = xMax[i];
            }

            byte[] yMax = ByteUtil.DoubleToByteArray(_yMax, ByteEndian.Little, BitEndian.Little);
            for (Int32 i = 0; i < 8; i++)
            {
                result[curIdx++] = yMax[i];
            }

            byte[] numParts = ByteUtil.Int32ToByteArray(_numParts, ByteEndian.Little, BitEndian.Little);
            for (Int32 i = 0; i < 4; i++)
            {
                result[curIdx++] = numParts[i];
            }

            byte[] numPoints = ByteUtil.Int32ToByteArray(_numPoints, ByteEndian.Little, BitEndian.Little);
            for (Int32 i = 0; i < 4; i++)
            {
                result[curIdx++] = numPoints[i];
            }

            for (Int32 i = 0; i < _parts.Count; i++)
            {
                byte[] partBuffer = ByteUtil.Int32ToByteArray(_parts[i], ByteEndian.Little, BitEndian.Little);
                for (Int32 j = 0; j < 4; j++)
                {
                    result[curIdx++] = partBuffer[j];
                }
            }

            for (Int32 i = 0; i < _points.Count; i++)
            {
                byte[] x = ByteUtil.DoubleToByteArray(_points[i].xLon, ByteEndian.Little, BitEndian.Little);
                for (Int32 j = 0; j < 8; j++)
                {
                    result[curIdx++] = x[j];
                }

                byte[] y = ByteUtil.DoubleToByteArray(_points[i].yLat, ByteEndian.Little, BitEndian.Little);
                for (Int32 j = 0; j < 8; j++)
                {
                    result[curIdx++] = y[j];
                }
            }

            return result;
        }

        internal override Int32 GetLengthInBytes()
        {
            return 4 + 32 + 4 + 4 + _parts.Count * 4 + _points.Count * 16; //length of _shapeType + four doubles + one int + one int + a list of ints + a list of pairs of doubles
        }

        internal override string ToXml()
        {
            StringBuilder result = new StringBuilder(String.Empty);
            result.Append("<content shapeType=\"" + this.ShapeType.ToString() + "\" numParts=\"" + _numParts.ToString(CultureInfo.InvariantCulture) + "\" numPoints=\"" + _numPoints.ToString(CultureInfo.InvariantCulture) + "\">\n");
            result.Append("<extent left=\"" + _xMin.ToString(CultureInfo.InvariantCulture) + "\" top=\"" + _yMin.ToString(CultureInfo.InvariantCulture) + "\" right=\"" + _xMax.ToString(CultureInfo.InvariantCulture) + "\" bottom=\"" + _yMax.ToString(CultureInfo.InvariantCulture) + "\"/>\n");
            result.Append("<parts>\n");
            for (Int32 i = 0; i < _numParts; i++)
            {
                Int32 numPointsInPart = GetNumPointsInPart(i);
                result.Append("<part partNumber=\"" + (i + 1).ToString(CultureInfo.InvariantCulture) + "\" numPointsInPart=\"" + numPointsInPart.ToString(CultureInfo.InvariantCulture) + "\">\n");
                result.Append("<points>\n");
                for (Int32 j = 0; j < numPointsInPart; j++)
                {
                    double xLon = _points[_parts[i] + j].xLon;
                    double yLat = _points[_parts[i] + j].yLat;
                    result.Append("<point xLon=\"" + xLon.ToString(CultureInfo.InvariantCulture) + "\" yLat=\"" + yLat.ToString(CultureInfo.InvariantCulture) + "\"/>\n");
                }
                result.Append("</points>\n");
                result.Append("</part>\n");
            }
            result.Append("</parts>\n");
            result.Append("</content>\n");
            return result.ToString();
        }

        internal override StarThrower.Gis.GeoUtilities.Shapes.Shape GetGeoUtilitiesShape()
        {
            StarThrower.Gis.GeoUtilities.Shapes.PolylineShape result = new StarThrower.Gis.GeoUtilities.Shapes.PolylineShape();
            result.Extent = new GeoRectangle(_xMin, _yMin, _xMax, _yMax);
            for (Int32 i = 0; i < _numParts; i++)
            {
                Int32 numPointsInPart = GetNumPointsInPart(i);
                result.AddPart();
                for (Int32 j = 0; j < numPointsInPart; j++)
                {
                    double xLon = _points[_parts[i] + j].xLon;
                    double yLat = _points[_parts[i] + j].yLat;
                    result.GetPart(i).AddPoint(new StarThrower.Gis.GeoUtilities.Shapes.PointShape(xLon, yLat));
                }
            }
            return result;
        }

        #endregion
    }
}
