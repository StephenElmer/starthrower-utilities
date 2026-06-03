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
using System.Globalization;
using System.Text;
using StarThrower.ByteUtilities;

namespace StarThrower.Gis.EsriLibrary.Internal
{
    /// <summary>
    /// GeographyFileRecordHeader
    /// 
    /// The header for each geography record stores the record number and content length for the record.
    /// Record headers have a fixed length of 8 ByteUtil.
    /// </summary>
    /// <remarks>
    /// Table 1 shows the fields in the file header with their byte position, value, type, and byte order.
    /// In the table, position is with respect to the start of the record.
    /// 
    /// Position    Field           Value           Type        Byte Order
    /// Byte 0      Record Number   Record Number   Integer     Big Endian
    /// Byte 4      Content Length  Content Length  Integer     Big Endian
    /// 
    /// Record numbers begin at 1.
    /// 
    /// The content length for a record is the length of the record contents measured in
    /// 16-bit words.  Each record, therefore, contributes (4 [the size of this record header] + content length) 16-bit words
    /// toward the total length of the file, as stored at Byte 24 in the main file header.
    /// 
    /// The above statement translates in bytes to:
    /// ContentLengh = ContentLength * 2   (a 16-bit word is 2 bytes)
    /// Each record therefore contributes (GeographyFileRecordHeader.LENGTH + ContentLength * 2) bytes toward the total length of the file
    /// 
    /// </remarks>
    internal sealed class GeographyFileRecordHeader
    {
        public const Int32 SIZE = 8; //size, in bytes, of a geography file record header


        #region Private Member Variables

        private Int32 _recordNumber = 0; //Record Number - bytes 0-3 (Big Endian)   Record numbers begin at 1
        private Int32 _contentLength = 0; //Record Number - bytes 4-7 (Big Endian)

        #endregion


        #region Internal Properties

        internal Int32 RecordNumber
        {
            get { return _recordNumber; }
            set { _recordNumber = value; }
        }

        internal Int32 ContentLength
        {
            get { return _contentLength; }
            set { _contentLength = value; }
        }

        #endregion


        #region Construction

        internal GeographyFileRecordHeader(byte[] bytes)
        {
            ParseBytes(bytes);
        }

        #endregion


        #region Private Methods

        private void ParseBytes(byte[] bytes)
        {
            _recordNumber = ByteUtil.ByteArrayToInt32(ByteUtil.ByteSubstring(bytes, 0, 4), ByteEndian.Big, BitEndian.Little);
            _contentLength = ByteUtil.ByteArrayToInt32(ByteUtil.ByteSubstring(bytes, 4, 4), ByteEndian.Big, BitEndian.Little);
        }

        #endregion


        #region Internal Methods

        internal byte[] GetBytes()
        {
            byte[] result = new byte[SIZE];

            Int32 curIdx = 0;
            byte[] recordNumber = ByteUtil.Int32ToByteArray(_recordNumber, ByteEndian.Big, BitEndian.Little);
            for (Int32 i = 0; i < 4; i++)
            {
                result[curIdx++] = recordNumber[i];
            }

            byte[] contentLength = ByteUtil.Int32ToByteArray(_contentLength, ByteEndian.Big, BitEndian.Little);
            for (Int32 i = 0; i < 4; i++)
            {
                result[curIdx++] = contentLength[i];
            }

            return result;
        }

        internal string ToXml()
        {
            StringBuilder result = new StringBuilder(String.Empty);
            result.AppendLine("<header recordNumber=\"" + _recordNumber.ToString(CultureInfo.InvariantCulture) + "\" contentLength=\"" + _contentLength.ToString(CultureInfo.InvariantCulture) + "\"/>");
            return result.ToString();
        }

        #endregion
    }
}
