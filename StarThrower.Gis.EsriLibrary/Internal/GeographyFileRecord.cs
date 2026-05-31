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
using System.Text;
using StarThrower.ByteUtilities;

namespace StarThrower.Gis.EsriLibrary.Internal
{
    internal class GeographyFileRecord
    {
        #region Private Member Variables

        private StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecordHeader _header;
        private StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecordContent _content;

        #endregion


        #region Internal Properties

        internal StarThrower.Gis.GeoUtilities.GeoRectangle Extent
        {
            get { return _content.Extent; }
        }

        #endregion


        #region Construction

        internal GeographyFileRecord(StarThrower.Gis.EsriLibrary.ShapeType shapeType, byte[] bytes)
        {
            byte[] headerBuffer = new byte[8];

            Int32 curIdx = 0;
            byte[] recordNumber = ByteUtil.Int32ToByteArray(1, ByteEndian.Big, BitEndian.Little);
            for (Int32 i = 0; i < 4; i++)
            {
                headerBuffer[curIdx++] = recordNumber[i];
            }

            byte[] contentLength = ByteUtil.Int32ToByteArray((bytes.Length / 2), ByteEndian.Big, BitEndian.Little);
            for (Int32 i = 0; i < 4; i++)
            {
                headerBuffer[curIdx++] = contentLength[i];
            }

            _header = new StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecordHeader(headerBuffer);
            switch (shapeType)
            {
                case StarThrower.Gis.EsriLibrary.ShapeType.NullShape:
                    _content = new StarThrower.Gis.EsriLibrary.Internal.Records.NullRecord(bytes);
                    break;
                case StarThrower.Gis.EsriLibrary.ShapeType.Point:
                    _content = new StarThrower.Gis.EsriLibrary.Internal.Records.PointRecord(bytes);
                    break;
                case StarThrower.Gis.EsriLibrary.ShapeType.PolyLine:
                    _content = new StarThrower.Gis.EsriLibrary.Internal.Records.PolyLineRecord(bytes);
                    break;
                case StarThrower.Gis.EsriLibrary.ShapeType.Polygon:
                    _content = new StarThrower.Gis.EsriLibrary.Internal.Records.PolygonRecord(bytes);
                    break;
                case StarThrower.Gis.EsriLibrary.ShapeType.MultiPoint:
                    _content = new StarThrower.Gis.EsriLibrary.Internal.Records.MultiPointRecord(bytes);
                    break;
                case StarThrower.Gis.EsriLibrary.ShapeType.PointZ:
                    _content = new StarThrower.Gis.EsriLibrary.Internal.Records.PointZRecord(bytes);
                    break;
                case StarThrower.Gis.EsriLibrary.ShapeType.PolyLineZ:
                    _content = new StarThrower.Gis.EsriLibrary.Internal.Records.PolyLineZRecord(bytes);
                    break;
                case StarThrower.Gis.EsriLibrary.ShapeType.PolygonZ:
                    _content = new StarThrower.Gis.EsriLibrary.Internal.Records.PolygonZRecord(bytes);
                    break;
                case StarThrower.Gis.EsriLibrary.ShapeType.MultiPointZ:
                    _content = new StarThrower.Gis.EsriLibrary.Internal.Records.MultiPointZRecord(bytes);
                    break;
                case StarThrower.Gis.EsriLibrary.ShapeType.PointM:
                    _content = new StarThrower.Gis.EsriLibrary.Internal.Records.PointMRecord(bytes);
                    break;
                case StarThrower.Gis.EsriLibrary.ShapeType.PolyLineM:
                    _content = new StarThrower.Gis.EsriLibrary.Internal.Records.PolyLineMRecord(bytes);
                    break;
                case StarThrower.Gis.EsriLibrary.ShapeType.PolygonM:
                    _content = new StarThrower.Gis.EsriLibrary.Internal.Records.PolygonMRecord(bytes);
                    break;
                case StarThrower.Gis.EsriLibrary.ShapeType.MultiPointM:
                    _content = new StarThrower.Gis.EsriLibrary.Internal.Records.MultiPointMRecord(bytes);
                    break;
                case StarThrower.Gis.EsriLibrary.ShapeType.MultiPatch:
                    _content = new StarThrower.Gis.EsriLibrary.Internal.Records.MultiPatchRecord(bytes);
                    break;
                default:
                    throw new ArgumentException($"Unsupported shape type: {shapeType}.", nameof(shapeType));
            }
        }

        internal GeographyFileRecord(ShapeType shapeType, GeographyFileRecordHeader header, byte[] bytes)
        {
            _header = header;
            switch (shapeType)
            {
                case StarThrower.Gis.EsriLibrary.ShapeType.NullShape:
                    _content = new StarThrower.Gis.EsriLibrary.Internal.Records.NullRecord(bytes);
                    break;
                case StarThrower.Gis.EsriLibrary.ShapeType.Point:
                    _content = new StarThrower.Gis.EsriLibrary.Internal.Records.PointRecord(bytes);
                    break;
                case StarThrower.Gis.EsriLibrary.ShapeType.PolyLine:
                    _content = new StarThrower.Gis.EsriLibrary.Internal.Records.PolyLineRecord(bytes);
                    break;
                case StarThrower.Gis.EsriLibrary.ShapeType.Polygon:
                    _content = new StarThrower.Gis.EsriLibrary.Internal.Records.PolygonRecord(bytes);
                    break;
                case StarThrower.Gis.EsriLibrary.ShapeType.MultiPoint:
                    _content = new StarThrower.Gis.EsriLibrary.Internal.Records.MultiPointRecord(bytes);
                    break;
                case StarThrower.Gis.EsriLibrary.ShapeType.PointZ:
                    _content = new StarThrower.Gis.EsriLibrary.Internal.Records.PointZRecord(bytes);
                    break;
                case StarThrower.Gis.EsriLibrary.ShapeType.PolyLineZ:
                    _content = new StarThrower.Gis.EsriLibrary.Internal.Records.PolyLineZRecord(bytes);
                    break;
                case StarThrower.Gis.EsriLibrary.ShapeType.PolygonZ:
                    _content = new StarThrower.Gis.EsriLibrary.Internal.Records.PolygonZRecord(bytes);
                    break;
                case StarThrower.Gis.EsriLibrary.ShapeType.MultiPointZ:
                    _content = new StarThrower.Gis.EsriLibrary.Internal.Records.MultiPointZRecord(bytes);
                    break;
                case StarThrower.Gis.EsriLibrary.ShapeType.PointM:
                    _content = new StarThrower.Gis.EsriLibrary.Internal.Records.PointMRecord(bytes);
                    break;
                case StarThrower.Gis.EsriLibrary.ShapeType.PolyLineM:
                    _content = new StarThrower.Gis.EsriLibrary.Internal.Records.PolyLineMRecord(bytes);
                    break;
                case StarThrower.Gis.EsriLibrary.ShapeType.PolygonM:
                    _content = new StarThrower.Gis.EsriLibrary.Internal.Records.PolygonMRecord(bytes);
                    break;
                case StarThrower.Gis.EsriLibrary.ShapeType.MultiPointM:
                    _content = new StarThrower.Gis.EsriLibrary.Internal.Records.MultiPointMRecord(bytes);
                    break;
                case StarThrower.Gis.EsriLibrary.ShapeType.MultiPatch:
                    _content = new StarThrower.Gis.EsriLibrary.Internal.Records.MultiPatchRecord(bytes);
                    break;
                default:
                    throw new ArgumentException($"Unsupported shape type: {shapeType}.", nameof(shapeType));
            }
        }

        #endregion


        #region Internal Methods

        internal StarThrower.Gis.GeoUtilities.Shapes.Shape GetGeoUtilitiesShape()
        {
            return _content.GetGeoUtilitiesShape();
        }

        internal void SetRecordNumber(Int32 recordNumber)
        {
            _header.RecordNumber = recordNumber;
        }

        internal Int32 GetLengthInBytes()
        {
            return StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecordHeader.SIZE + _content.GetLengthInBytes();
        }

        internal Int32 GetContentLength()
        {
            return _content.GetLengthInBytes() / 2;
        }

        internal byte[] GetBytes()
        {
            byte[] result = new byte[StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecordHeader.SIZE + _content.GetLengthInBytes()];

            Int32 curIdx = 0;
            byte[] headerBuffer = _header.GetBytes();
            for (Int32 i = 0; i < headerBuffer.Length; i++)
            {
                result[curIdx++] = headerBuffer[i];
            }

            byte[] contentBuffer = _content.GetBytes();
            for (Int32 i = 0; i < contentBuffer.Length; i++)
            {
                result[curIdx++] = contentBuffer[i];
            }

            return result;
        }

        internal string ToXml()
        {
            StringBuilder result = new StringBuilder(String.Empty);
            result.AppendLine("<record>");
            result.Append(_header.ToXml());
            result.Append(_content.ToXml());
            result.AppendLine("</record>");
            return result.ToString();
        }

        #endregion
    }
}
