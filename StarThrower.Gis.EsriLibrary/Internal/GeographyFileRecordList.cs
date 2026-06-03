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
using System.Collections.Generic;

namespace StarThrower.Gis.EsriLibrary.Internal
{
    internal sealed class GeographyFileRecordList
    {
        #region Private Member Variables

        private StarThrower.Gis.EsriLibrary.Internal.FileHeader? _fileHeader;
        private List<StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecord> _list = new List<StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecord>();

        #endregion


        #region Internal Properties

        internal StarThrower.Gis.EsriLibrary.Internal.FileHeader? FileHeader
        {
            get { return _fileHeader; }
            set { _fileHeader = value; }
        }

        #endregion


        internal byte[] GetBytes()
        {
            Int32 len = 0;
            foreach (StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecord record in _list)
            {
                len += record.GetLengthInBytes();
            }

            byte[] result = new byte[len];

            Int32 curIdx = 0;
            foreach (StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecord record in _list)
            {
                byte[] recordBuffer = record.GetBytes();
                for (Int32 i = 0; i < recordBuffer.Length; i++)
                {
                    result[curIdx++] = recordBuffer[i];
                }
            }

            return result;
        }

        internal Int32 Count
        {
            get { return _list.Count; }
        }

        internal StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecord this[int index]
        {
            get
            {
                return _list[index];
            }
        }

        internal void Clear()
        {
            _list.Clear();
        }

        internal void Add(StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecord record)
        {
            _list.Add(record);
        }

        internal string ToXml()
        {
            StringBuilder result = new StringBuilder(String.Empty);
            result.AppendLine("<records numRecords=\"" + _list.Count.ToString(CultureInfo.InvariantCulture) + "\">");
            foreach (StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecord record in _list)
            {
                result.Append(record.ToXml());
            }
            result.AppendLine("</records>");
            return result.ToString();
        }
    }
}
