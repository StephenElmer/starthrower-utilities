// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text;
using StarThrower.ByteUtilities;

namespace StarThrower.Gis.EsriLibrary.Internal.Records
{
    internal sealed class PointRecord : StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecordContent
    {
        #region Private Member Variables

        private double _x; //bytes 4-11 (Little Endian)
        private double _y; //bytes 12-19 (Little Endian)

        #endregion


        #region Internal Properties

        internal override StarThrower.Gis.GeoUtilities.GeoRectangle Extent
        {
            get
            {
                //return new StarThrower.Gis.GeoUtilities.GeoRectangle(Math.Max(-180.0, _x - 1), Math.Max(-90.0, _y - 1), Math.Min(180.0, _x + 1), Math.Min(90.0, _y + 1));
                return new StarThrower.Gis.GeoUtilities.GeoRectangle(_x, _y, _x, _y);
            }
        }

        #endregion


        #region Construction

        internal PointRecord(byte[] bytes)
        {
            this.ShapeType = StarThrower.Gis.EsriLibrary.ShapeType.Point;
            ParseBytes(bytes);
        }

        #endregion


        #region Private Methods

        private void ParseBytes(byte[] bytes)
        {
            _x = ByteUtil.ByteArrayToDouble(ByteUtil.ByteSubstring(bytes, 4, 8), ByteEndian.Little, BitEndian.Little);
            _y = ByteUtil.ByteArrayToDouble(ByteUtil.ByteSubstring(bytes, 12, 8), ByteEndian.Little, BitEndian.Little);
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

            byte[] x = ByteUtil.DoubleToByteArray(_x, ByteEndian.Little, BitEndian.Little);
            for (Int32 i = 0; i < 8; i++)
            {
                result[curIdx++] = x[i];
            }

            byte[] y = ByteUtil.DoubleToByteArray(_y, ByteEndian.Little, BitEndian.Little);
            for (Int32 i = 0; i < 8; i++)
            {
                result[curIdx++] = y[i];
            }

            return result;
        }

        internal override Int32 GetLengthInBytes()
        {
            return 4 + 8 + 8; //length of _shapeType + two doubles
        }

        internal override string ToXml()
        {
            StringBuilder result = new StringBuilder(String.Empty);
            result.Append("<content shapeType=\"" + this.ShapeType.ToString() + "\">\n");
            result.Append("<point xLon=\"" + _x.ToString(CultureInfo.InvariantCulture) + "\" yLat=\"" + _y.ToString(CultureInfo.InvariantCulture) + "\"/>\n");
            result.Append("</content>\n");
            return result.ToString();
        }

        internal override StarThrower.Gis.GeoUtilities.Shapes.Shape GetGeoUtilitiesShape()
        {
            StarThrower.Gis.GeoUtilities.Shapes.PointShape result = new StarThrower.Gis.GeoUtilities.Shapes.PointShape();
            result.xLon = _x;
            result.yLat = _y;
            return result;
        }

        #endregion
    }
}
