// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text;
using System.Collections.Generic;

namespace StarThrower.Gis.EsriLibrary.Internal
{
    /// <summary>
    /// An ordered collection of <see cref="GeographyFileRecord"/> entries, used to build and
    /// serialize the contents of a shapefile geometry (.shp) file.
    /// </summary>
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

        /// <summary>
        /// Removes the record at the specified index and renumbers all subsequent records so
        /// their record numbers remain contiguous.
        /// </summary>
        internal void RemoveAt(int index)
        {
            _list.RemoveAt(index);
            for (int i = index; i < _list.Count; i++)
            {
                _list[i].SetRecordNumber(i + 1);
            }
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
