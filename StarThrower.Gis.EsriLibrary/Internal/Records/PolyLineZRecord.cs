/***********************************************************************************
    StarThrower Utilities / Gis.EsriLibrary
    Copyright (C) 2005-2026  Stephen Elmer

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

namespace StarThrower.Gis.EsriLibrary.Internal.Records
{
    internal class PolyLineZRecord : StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecordContent
    {
        #region Construction

        internal PolyLineZRecord(byte[] bytes)
        {
            this.ShapeType = StarThrower.Gis.EsriLibrary.ShapeType.PolyLineZ;
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

        }

        #endregion


        #region Internal Methods

        internal override byte[] GetBytes()
        {
            byte[] result = new byte[GetLengthInBytes()];

            Int32 curIdx = 0;
            byte[] shapeType = ByteUtil.Int32ToByteArray((int)(this.ShapeType), ByteEndian.Little, BitEndian.Little);
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
            StarThrower.Gis.GeoUtilities.Shapes.PolylineZShape result = new StarThrower.Gis.GeoUtilities.Shapes.PolylineZShape();
            //TODO:
            return result;
        }

        #endregion
    }
}
