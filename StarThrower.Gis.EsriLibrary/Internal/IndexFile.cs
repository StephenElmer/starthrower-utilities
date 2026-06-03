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
using System.IO;
using System.Text;

namespace StarThrower.Gis.EsriLibrary.Internal
{
    /// <summary>
    /// IndexFile
    /// 
    /// The index file (.shx) contains a 100-byte header (FileHeader) followed by 8-byte, fixed-length records.
    /// </summary>
    /// <remarks>
    /// Fig. 1 illustrates the index file organization:
    /// 
    /// -------- -------- -------- -------- -------- -------- -------- -------- -------- -------- -------- -------- -------- -------- -------- --------
    /// | File Header                                                                                                                                 |
    /// -------- -------- -------- -------- -------- -------- -------- -------- -------- -------- -------- -------- -------- -------- -------- --------
    /// -------- -------- -------- -------- -------- -------- -------- --------
    /// | Record                                                              |
    /// -------- -------- -------- -------- -------- -------- -------- --------
    /// | Record                                                              |
    /// -------- -------- -------- -------- -------- -------- -------- --------
    /// | ...                                                                 |
    /// -------- -------- -------- -------- -------- -------- -------- --------
    /// | Record                                                              |
    /// -------- -------- -------- -------- -------- -------- -------- --------
    /// 
    /// NOTE: The index file header is identical in organization to the main file header.
    /// The file length stored in the index file header is the total length of the index file
    /// in 16-bit words (the fifty 16-bit words of the header plus 4 times the number of records).
    /// 
    /// </remarks>
    internal class IndexFile : IDisposable
    {
        #region Private Member Variables

        private FileStream? _stream;
        private StarThrower.Gis.EsriLibrary.Internal.FileHeader _header = new StarThrower.Gis.EsriLibrary.Internal.FileHeader();
        private StarThrower.Gis.EsriLibrary.Internal.IndexFileRecordList _records = new StarThrower.Gis.EsriLibrary.Internal.IndexFileRecordList();

        #endregion


        #region Internal Properties

        internal Int32 RecordCount
        {
            get { return _records.Count; }
        }

        internal StarThrower.Gis.EsriLibrary.ShapeType ShapeType
        {
            get { return _header.ShapeType; }
            set { _header.ShapeType = value; }
        }

        internal StarThrower.Gis.GeoUtilities.GeoRectangle Extent
        {
            get { return _header.Extent; }
            set { _header.Extent = value; }
        }

        #endregion


        #region Construction

        internal IndexFile() { }

        #endregion


        #region IDisposable Members

        public void Dispose()
        {
            if (_stream != null)
            {
                _stream.Dispose();
            }
        }

        #endregion


        #region Private Methods

        private void Read()
        {
            if (_stream == null) throw new InvalidOperationException("Stream has not been opened.");
            if (!_stream.CanRead) throw new IOException("Stream is not in a readable mode.");

            byte[] header = new byte[StarThrower.Gis.EsriLibrary.Internal.FileHeader.SIZE];
            _stream.Seek(0, SeekOrigin.Begin);
            int bytesRead = _stream.Read(header, 0, StarThrower.Gis.EsriLibrary.Internal.FileHeader.SIZE);
            _header.ParseBytes(header);

            _records.Clear();
            _records.FileHeader = _header;
            Int32 curIdx = StarThrower.Gis.EsriLibrary.Internal.FileHeader.SIZE;
            bool done = false;
            _stream.Seek(curIdx, SeekOrigin.Begin);
            Int32 recordCount = ((_header.FileLength - StarThrower.Gis.EsriLibrary.Internal.FileHeader.SIZE) / StarThrower.Gis.EsriLibrary.Internal.IndexFileRecord.SIZE);
            for (Int32 i = 0; i < recordCount && !done; i++)
            {
                byte[] record = new byte[StarThrower.Gis.EsriLibrary.Internal.IndexFileRecord.SIZE];
                bytesRead = _stream.Read(record, 0, StarThrower.Gis.EsriLibrary.Internal.IndexFileRecord.SIZE);
                _records.Add(new StarThrower.Gis.EsriLibrary.Internal.IndexFileRecord(record));
                curIdx += StarThrower.Gis.EsriLibrary.Internal.IndexFileRecord.SIZE;

                if (curIdx >= (recordCount * StarThrower.Gis.EsriLibrary.Internal.IndexFileRecord.SIZE) + StarThrower.Gis.EsriLibrary.Internal.FileHeader.SIZE)
                {
                    done = true;
                }
            }
        }

        #endregion


        #region Internal Methods

        #region File Related

        internal void Open(string fileName, System.IO.FileMode fileMode, System.IO.FileAccess fileAccess)
        {
            _stream = new FileStream(fileName, fileMode, fileAccess);
            Read();
        }

        internal void Open(string fileName, FileMode fileMode, FileAccess fileAccess, FileShare fileShare)
        {
            _stream = new FileStream(fileName, fileMode, fileAccess, fileShare);
            Read();
        }

        /// <summary>
        /// Closes the file without saving
        /// </summary>
        internal void Close()
        {
            if (_stream != null)
            {
                _stream.Close();
            }
        }

        /// <summary>
        /// Closes the file taking a boolean parameter
        /// which indicates whether the file should be saved or not
        /// </summary>
        /// <param name="save"></param>
        internal void Close(bool save)
        {
            if (save)
            {
                Save();
            }
            _stream?.Close();
        }

        internal void Save()
        {
            if (_stream == null) throw new InvalidOperationException("FileStream has not yet been assigned.");

            byte[] headerBuffer = _header.GetBytes();
            _stream.Write(headerBuffer, 0, headerBuffer.Length);

            byte[] recordsBuffer = _records.GetBytes();
            _stream.Write(recordsBuffer, 0, recordsBuffer.Length);
        }

        internal void SaveAs(string fileName)
        {
            if (_stream != null)
            {
                if (_stream.Name.Equals(fileName, StringComparison.Ordinal))
                {
                    this.Save();
                }
                else
                {
                    //Close the current stream
                    if (_stream != null)
                    {
                        _stream.Close();
                        _stream.Dispose();
                        _stream = null;
                    }

                    //Create a new stream
                    if (File.Exists(fileName)) File.Delete(fileName);
                    _stream = new FileStream(fileName, FileMode.CreateNew, FileAccess.ReadWrite);

                    //Write the contents of this data structure to the new stream
                    this.Save();
                }
            }
            else
            {
                //Create a new stream
                if (File.Exists(fileName)) File.Delete(fileName);
                _stream = new FileStream(fileName, FileMode.CreateNew, FileAccess.ReadWrite);

                //Write the contents of this data structure to the new stream
                this.Save();
            }
        }

        internal string ToXml()
        {
            StringBuilder result = new StringBuilder(String.Empty);
            result.AppendLine("<indexFile>");
            result.Append(_header.ToXml());
            result.Append(_records.ToXml());
            result.AppendLine("</indexFile>");
            return result.ToString();
        }

        #endregion

        #region Record Related

        internal void AddRecord(StarThrower.Gis.EsriLibrary.Internal.IndexFileRecord record)
        {
            if (_records.Count > 0)
            {
                record.Offset = _records.GetRecord(_records.Count - 1).Offset + _records.GetRecord(_records.Count - 1).ContentLength + (StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecordHeader.SIZE / 2);
            }
            else
            {
                //this is the first record
                record.Offset = 50; //50 16-bit words
            }
            _records.Add(record);
            _header.FileLength += StarThrower.Gis.EsriLibrary.Internal.IndexFileRecord.SIZE;
        }

        #endregion

        #endregion
    }
}
