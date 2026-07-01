// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Text;
using StarThrower.ByteUtilities;

namespace StarThrower.Gis.EsriLibrary.Internal.Records
{
    /// <summary>
    /// Represents a Null shape record: no geometry beyond the 4-byte shape-type code.
    /// </summary>
    internal sealed class NullRecord : StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecordContent
    {
        #region Construction

        internal NullRecord(byte[] bytes)
        {
            _ = bytes; // NullShape has no content beyond the shape-type field; nothing to parse.
            this.ShapeType = StarThrower.Gis.EsriLibrary.ShapeType.NullShape;
        }

        #endregion


        #region Internal Properties

        internal override StarThrower.Gis.GeoUtilities.GeoRectangle Extent
        {
            get
            {
                // NullShape has no geometry, so its extent is intentionally empty (all zeros).
                return new StarThrower.Gis.GeoUtilities.GeoRectangle();
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
            return new StarThrower.Gis.GeoUtilities.Shapes.NullShape();
        }

        #endregion
    }
}
