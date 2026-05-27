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
using System.IO;
using System.Text;

namespace StarThrower.Gis.EsriLibrary.Internal
{
    internal class GeographyFile : IDisposable
    {
        #region Private Member Variables

        private FileStream _stream = null;
        private StarThrower.Gis.EsriLibrary.Internal.FileHeader _header = new StarThrower.Gis.EsriLibrary.Internal.FileHeader();
        private StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecordList _records = new StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecordList();
        private StarThrower.Gis.EsriLibrary.Internal.IndexFile _indexFile = new StarThrower.Gis.EsriLibrary.Internal.IndexFile();
        private StarThrower.Gis.EsriLibrary.Internal.ProjectionFile _projectionFile = new StarThrower.Gis.EsriLibrary.Internal.ProjectionFile();

        #endregion


        #region Internal Properties

        internal Int32 RecordCount
        {
            get { return _records.Count; }
        }

        internal StarThrower.Gis.EsriLibrary.ShapeType ShapeType
        {
            get { return _header.ShapeType; }
            set 
            { 
                _header.ShapeType = value;
                _indexFile.ShapeType = value;
            }
        }

        internal StarThrower.Gis.GeoUtilities.GeoRectangle Extent
        {
            get { return _header.Extent; }
            set 
            { 
                _header.Extent = value;
                _indexFile.Extent = value;
            }
        }

        #endregion


        #region Construction

        internal GeographyFile() { }

        #endregion


        #region IDisposable Members

        public void Dispose()
        {
            if (_stream != null)
            {
                _stream.Dispose();
            }
            if (_indexFile != null)
            {
                _indexFile.Dispose();
            }
            if (_projectionFile != null)
            {
                _projectionFile.Dispose();
            }
        }

        #endregion


        #region Private Methods

        private void Read()
        {
            if (!_stream.CanRead) throw new IOException("Stream is not in a readable mode.");

            byte[] header = new byte[StarThrower.Gis.EsriLibrary.Internal.FileHeader.SIZE];
            _stream.Seek(0, SeekOrigin.Begin);
            Int32 bytesRead = _stream.Read(header, 0, StarThrower.Gis.EsriLibrary.Internal.FileHeader.SIZE);
            _header.ParseBytes(header);

            _records.Clear();
            _records.FileHeader = _header;
            Int32 curIdx = StarThrower.Gis.EsriLibrary.Internal.FileHeader.SIZE;
            bool done = false;
            _stream.Seek(curIdx, SeekOrigin.Begin);
            Int32 recordCount = _indexFile.RecordCount;
            for (Int32 i = 0; i < recordCount && !done; i++)
            {
                byte[] recordHeaderBuffer = new byte[StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecordHeader.SIZE];
                bytesRead = _stream.Read(recordHeaderBuffer, 0, StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecordHeader.SIZE);
                StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecordHeader recordHeader = new StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecordHeader(recordHeaderBuffer);
                curIdx += StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecordHeader.SIZE;

                byte[] recordContentBuffer = new byte[recordHeader.ContentLength * 2];
                bytesRead = _stream.Read(recordContentBuffer, 0, recordHeader.ContentLength * 2);
                curIdx += recordHeader.ContentLength * 2;
                _records.Add(new StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecord(_header.ShapeType, recordHeader, recordContentBuffer));
            }
        }

        private bool IsValid()
        {
            if (_indexFile.RecordCount != _records.Count) return false;
            return true;
        }

        #endregion


        #region Internal Methods

        #region File Related

        /// <summary>
        /// fileName is assumed to be .shp
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fileMode"></param>
        /// <param name="fileAccess"></param>
        internal void Open(string fileName, System.IO.FileMode fileMode, System.IO.FileAccess fileAccess)
        {
            string baseFileName = Path.GetDirectoryName(fileName) + "\\" + Path.GetFileNameWithoutExtension(fileName);
            _indexFile.Open(baseFileName + ".shx", fileMode, fileAccess);
            if (File.Exists(baseFileName + ".prj"))
            {
                _projectionFile.Open(baseFileName + ".prj", fileMode, fileAccess);
            }
            _stream = new FileStream(fileName, fileMode, fileAccess);
            Read();
            if (!IsValid()) throw new InvalidDataException();
        }

        /// <summary>
        /// fileName is assumed to be .shp
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fileMode"></param>
        /// <param name="fileAccess"></param>
        /// <param name="fileShare"></param>
        internal void Open(string fileName, System.IO.FileMode fileMode, System.IO.FileAccess fileAccess, System.IO.FileShare fileShare)
        {
            string baseFileName = Path.GetDirectoryName(fileName) + "\\" + Path.GetFileNameWithoutExtension(fileName);
            _indexFile.Open(baseFileName + ".shx", fileMode, fileAccess, fileShare);
            if (File.Exists(baseFileName + ".prj"))
            {
                _projectionFile.Open(baseFileName + ".prj", fileMode, fileAccess, fileShare);
            }
            _stream = new FileStream(fileName, fileMode, fileAccess, fileShare);
            Read();
            if (!IsValid()) throw new InvalidDataException();
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
            _indexFile.Close();
            _projectionFile.Close();
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
            _stream.Close();

            _indexFile.Close(save);
            _projectionFile.Close(save);
        }

        internal void Save()
        {
            if (_stream == null) throw new InvalidOperationException("FileStream has not yet been assigned.");

            byte[] header = _header.GetBytes();
            _stream.Write(header, 0, header.Length);

            byte[] records = _records.GetBytes();
            _stream.Write(records, 0, records.Length);

            _indexFile.Save();
            _projectionFile.Save();
        }

        internal void SaveAs(string fileName)
        {
            if (_stream != null)
            {
                if (_stream.Name.Equals(fileName))
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
                    byte[] header = _header.GetBytes();
                    _stream.Write(header, 0, header.Length);

                    byte[] records = _records.GetBytes();
                    _stream.Write(records, 0, records.Length);
                }
            }
            else
            {
                //Create a new stream
                if (File.Exists(fileName)) File.Delete(fileName);
                _stream = new FileStream(fileName, FileMode.CreateNew, FileAccess.ReadWrite);

                //Write the contents of this data structure to the new stream
                byte[] header = _header.GetBytes();
                _stream.Write(header, 0, header.Length);

                byte[] records = _records.GetBytes();
                _stream.Write(records, 0, records.Length);
            }

            string baseFileName = Path.GetDirectoryName(fileName) + "\\" + Path.GetFileNameWithoutExtension(fileName);
            _indexFile.SaveAs(baseFileName + ".shx");
            _projectionFile.SaveAs(baseFileName + ".prj");
        }

        internal string ToXml()
        {
            StringBuilder result = new StringBuilder(String.Empty);
            result.AppendLine("<geographyFile>");
            result.Append(_header.ToXml());
            result.Append(_records.ToXml());
            result.AppendLine("</geographyFile>");
            result.Append(_indexFile.ToXml());
            result.Append(_projectionFile.ToXml());
            return result.ToString();
        }

        #endregion

        #region Record Related

        internal void DeleteRecord(int index)
        {
            //TODO:
        }

        internal void AddRecord(StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecord record)
        {
            bool firstRecord = (_records.Count == 0);
            record.SetRecordNumber(_records.Count + 1);
            _records.Add(record);
            StarThrower.Gis.EsriLibrary.Internal.IndexFileRecord indexRecord = new StarThrower.Gis.EsriLibrary.Internal.IndexFileRecord();
            //indexRecord.ContentLength = record.GetLengthInBytes();
            indexRecord.ContentLength = record.GetContentLength();
            _indexFile.AddRecord(indexRecord);
            //_header.FileLength += (indexRecord.ContentLength + StarThrower.Gis.EsriLibrary.Internal.IndexFileRecord.SIZE);
            //_header.FileLength += (record.GetLengthInBytes() + StarThrower.Gis.EsriLibrary.Internal.IndexFileRecord.SIZE);
            _header.FileLength += record.GetLengthInBytes();

            if (firstRecord)
            {
                _header.Extent = record.Extent;
                _indexFile.Extent = record.Extent;
            }
            else
            {
                StarThrower.Gis.GeoUtilities.GeoRectangle tempExtent = _header.Extent;
                if (tempExtent.Left > record.Extent.Left)
                {
                    tempExtent.Left = record.Extent.Left;
                }
                if (tempExtent.Top > record.Extent.Top)
                {
                    tempExtent.Top = record.Extent.Top;
                }
                if (tempExtent.Right < record.Extent.Right)
                {
                    tempExtent.Right = record.Extent.Right;
                }
                if (tempExtent.Bottom < record.Extent.Bottom)
                {
                    tempExtent.Bottom = record.Extent.Bottom;
                }
                _header.Extent = tempExtent;
                _indexFile.Extent = tempExtent;
            }
        }

        internal StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecord GetRecord(int index)
        {
            return _records[index];
        }

        #endregion

        #endregion
    }
}
