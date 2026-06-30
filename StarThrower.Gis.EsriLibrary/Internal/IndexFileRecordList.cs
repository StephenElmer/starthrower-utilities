// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Text;
using System.Collections.Generic;

namespace StarThrower.Gis.EsriLibrary.Internal
{
    internal sealed class IndexFileRecordList
    {
        #region Private Member Variables

        private StarThrower.Gis.EsriLibrary.Internal.FileHeader? _fileHeader;
        private List<StarThrower.Gis.EsriLibrary.Internal.IndexFileRecord> _list = new List<StarThrower.Gis.EsriLibrary.Internal.IndexFileRecord>();

        #endregion


        #region Internal Properties

        internal StarThrower.Gis.EsriLibrary.Internal.FileHeader? FileHeader
        {
            get { return _fileHeader; }
            set { _fileHeader = value; }
        }

        #endregion

        internal IndexFileRecord GetRecord(Int32 index)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(index);
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index, _list.Count);
            
            return _list[index];
        }

        internal byte[] GetBytes()
        {
            byte[] result = new byte[_list.Count * StarThrower.Gis.EsriLibrary.Internal.IndexFileRecord.SIZE];

            Int32 curIdx = 0;
            foreach (StarThrower.Gis.EsriLibrary.Internal.IndexFileRecord record in _list)
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

        internal void Clear()
        {
            _list.Clear();
        }

        internal void Add(StarThrower.Gis.EsriLibrary.Internal.IndexFileRecord record)
        {
            _list.Add(record);
        }

        internal void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        internal string ToXml()
        {
            StringBuilder result = new StringBuilder(String.Empty);
            result.Append("<records>\n");
            foreach (StarThrower.Gis.EsriLibrary.Internal.IndexFileRecord record in _list)
            {
                result.Append(record.ToXml());
            }
            result.Append("</records>\n");
            return result.ToString();
        }
    }
}
