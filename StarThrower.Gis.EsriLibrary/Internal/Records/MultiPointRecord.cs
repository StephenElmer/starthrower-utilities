// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Text;
using StarThrower.ByteUtilities;

namespace StarThrower.Gis.EsriLibrary.Internal.Records
{
    internal sealed class MultiPointRecord : StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecordContent
    {
        #region Construction

        internal MultiPointRecord(byte[] bytes)
        {
            this.ShapeType = StarThrower.Gis.EsriLibrary.ShapeType.MultiPoint;
            ParseBytes(bytes);
        }

        #endregion


        #region Internal Properties

        internal override StarThrower.Gis.GeoUtilities.GeoRectangle Extent
        {
            get
            {
                //TODO:
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
            StarThrower.Gis.GeoUtilities.Shapes.MultipointShape result = new StarThrower.Gis.GeoUtilities.Shapes.MultipointShape();
            //TODO:
            return result;
        }

        #endregion
    }
}
