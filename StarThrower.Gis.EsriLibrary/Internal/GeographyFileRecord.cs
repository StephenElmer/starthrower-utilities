// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Text;
using StarThrower.ByteUtilities;

namespace StarThrower.Gis.EsriLibrary.Internal
{
    /// <summary>
    /// A single record in a shapefile geometry (.shp) file: an 8-byte
    /// <see cref="GeographyFileRecordHeader"/> paired with a shape-type-specific
    /// <see cref="GeographyFileRecordContent"/> body.
    /// </summary>
    internal sealed class GeographyFileRecord
    {
        #region Private Member Variables

        private StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecordHeader _header;
        private StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecordContent _content;

        #endregion


        #region Internal Properties

        /// <summary>
        /// Gets the bounding rectangle of this record's geometry.
        /// </summary>
        internal StarThrower.Gis.GeoUtilities.GeoRectangle Extent
        {
            get { return _content.Extent; }
        }

        #endregion


        #region Construction

        /// <summary>
        /// Initializes a new <see cref="GeographyFileRecord"/> for a record being added to a
        /// file, building a fresh header (record number 1; the caller renumbers records as
        /// needed) from the content's byte length.
        /// </summary>
        /// <param name="shapeType">The shape type the content bytes represent.</param>
        /// <param name="bytes">The shape's serialized geometry content, as produced by <see cref="EsriLibrary.ShapeToBytes"/>.</param>
        /// <exception cref="ArgumentException"><paramref name="shapeType"/> is not a recognized shape type.</exception>
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

        /// <summary>
        /// Initializes a new <see cref="GeographyFileRecord"/> for a record read from an
        /// existing file, reusing the <paramref name="header"/> already parsed from disk
        /// rather than building a new one.
        /// </summary>
        /// <param name="shapeType">The shape type the content bytes represent.</param>
        /// <param name="header">The record header parsed from the file.</param>
        /// <param name="bytes">The shape's serialized geometry content, as read from the file.</param>
        /// <exception cref="ArgumentException"><paramref name="shapeType"/> is not a recognized shape type.</exception>
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

        /// <summary>
        /// Converts this record's geometry into a
        /// <see cref="StarThrower.Gis.GeoUtilities.Shapes.Shape"/>.
        /// </summary>
        internal StarThrower.Gis.GeoUtilities.Shapes.Shape GetGeoUtilitiesShape()
        {
            return _content.GetGeoUtilitiesShape();
        }

        /// <summary>
        /// Sets this record's 1-based record number in the file.
        /// </summary>
        internal void SetRecordNumber(Int32 recordNumber)
        {
            _header.RecordNumber = recordNumber;
        }

        /// <summary>
        /// Gets the total length, in bytes, of this record (header plus content) as stored
        /// in the .shp file.
        /// </summary>
        internal Int32 GetLengthInBytes()
        {
            return StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecordHeader.SIZE + _content.GetLengthInBytes();
        }

        /// <summary>
        /// Gets the content length, in 16-bit words (per the ESRI shapefile format), for use
        /// in the record header's <see cref="GeographyFileRecordHeader.ContentLength"/> field.
        /// </summary>
        internal Int32 GetContentLength()
        {
            return _content.GetLengthInBytes() / 2;
        }

        /// <summary>
        /// Serializes this record's header and content to their combined binary representation.
        /// </summary>
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
