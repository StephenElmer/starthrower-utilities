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
using System.Globalization;
using System.Text;
using StarThrower.ByteUtilities;

namespace StarThrower.Gis.EsriLibrary.Internal
{
    /// <summary>
    /// IndexFileRecord
    /// 
    /// The I'th record in the index file stores the offset and content length for the I'th record in
    /// the main file.  
    /// </summary>
    /// <remarks>
    /// This table shows the fields in the record with their byte position, value, type, and byte order.
    /// In the table, position is with rewpect to the start of the index file record.
    /// 
    /// Position    Field           Value           Type        Byte Order
    /// Byte 0      Offset          Offset          Integer     Big
    /// Byte 4      Content Length  Content Length  Integer     Big
    /// 
    /// The offset of a record in the main file is the number of 16-bit words from the start of the
    /// main file to the first byte of the record header for the record.  Thus, the offset for the
    /// first record in the main file is 50, given the 100-byte header.
    /// 
    /// The content length stored in the index record is the same as the value stored in the main 
    /// file record header.
    /// </remarks>
    internal class IndexFileRecord
    {
        internal const Int32 SIZE = 8; //length of an index record - 8 bytes


        #region Private Member Variables

        private Int32 _offset = 0; //bytes 0-3 (Big Endian)
        private Int32 _contentLength = 0; //bytes 4-7 (Big Endian)

        #endregion


        #region Construction

        internal IndexFileRecord() { }

        internal IndexFileRecord(byte[] bytes) : this()
        {
            ParseBytes(bytes);
        }

        #endregion


        #region Internal Properties

        internal Int32 Offset
        {
            get { return _offset; }
            set { _offset = value; }
        }

        internal Int32 ContentLength
        {
            get { return _contentLength; }
            set { _contentLength = value; }
        }

        #endregion


        #region Internal Methods

        internal byte[] GetBytes()
        {
            byte[] result = new byte[SIZE];

            Int32 curIdx = 0;

            byte[] offset = ByteUtil.Int32ToByteArray(_offset, ByteEndian.Big, BitEndian.Little);
            for (Int32 i = 0; i < 4; i++)
            {
                result[curIdx++] = offset[i];
            }

            byte[] contentLength = ByteUtil.Int32ToByteArray(_contentLength, ByteEndian.Big, BitEndian.Little);
            for (Int32 i = 0; i < 4; i++)
            {
                result[curIdx++] = contentLength[i];
            }

            return result;
        }

        internal void ParseBytes(byte[] bytes)
        {
            _offset = ByteUtil.ByteArrayToInt32(ByteUtil.ByteSubstring(bytes, 0, 4), ByteEndian.Big, BitEndian.Little);
            _contentLength = ByteUtil.ByteArrayToInt32(ByteUtil.ByteSubstring(bytes, 4, 4), ByteEndian.Big, BitEndian.Little);
        }

        internal string ToXml()
        {
            StringBuilder result = new StringBuilder(String.Empty);
            result.Append("<record offset=\"" + _offset.ToString(CultureInfo.InvariantCulture) + "\" contentLength=\"" + _contentLength.ToString(CultureInfo.InvariantCulture) + "\"/>\n");
            return result.ToString();
        }

        #endregion
    }
}
