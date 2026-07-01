// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Text;
using StarThrower.ByteUtilities;

namespace StarThrower.Gis.EsriLibrary.Internal.Records
{
    /// <summary>
    /// Represents a PolygonM shape record (a polygon with measure values per vertex).
    /// Unimplemented: <c>ParseBytes</c> throws <see cref="NotImplementedException"/>, and
    /// <c>GetBytes</c>/<c>GetLengthInBytes</c> only serialize the 4-byte shape-type code.
    /// Tracked in issue #25.
    /// </summary>
    internal sealed class PolygonMRecord : StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecordContent
    {
        #region Construction

        internal PolygonMRecord(byte[] bytes)
        {
            this.ShapeType = StarThrower.Gis.EsriLibrary.ShapeType.PolygonM;
            ParseBytes(bytes);
        }

        #endregion


        #region Internal Properties

        internal override StarThrower.Gis.GeoUtilities.GeoRectangle Extent
        {
            get
            {
                //TODO: #25 — implement Extent once ParseBytes populates bounding box data
                return new StarThrower.Gis.GeoUtilities.GeoRectangle();
            }
        }

        #endregion


        #region Private Methods

        private void ParseBytes(byte[] bytes)
        {
            throw new NotImplementedException();
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

            return result;
        }

        internal override Int32 GetLengthInBytes()
        {
            return 4; //length of _shapeType
        }

        internal override string ToXml()
        {
            StringBuilder result = new StringBuilder(String.Empty);
            result.Append("<content shapeType=\"" + this.ShapeType.ToString() + "\">\n");
            result.Append("</content>\n");
            return result.ToString();
        }

        internal override StarThrower.Gis.GeoUtilities.Shapes.Shape GetGeoUtilitiesShape()
        {
            StarThrower.Gis.GeoUtilities.Shapes.PolygonMShape result = new StarThrower.Gis.GeoUtilities.Shapes.PolygonMShape();
            //TODO: #25 — populate result with parsed parts, points, and M data
            return result;
        }

        #endregion
    }
}
