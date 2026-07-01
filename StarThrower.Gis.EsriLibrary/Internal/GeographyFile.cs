// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.IO;
using System.Text;

namespace StarThrower.Gis.EsriLibrary.Internal
{
    /// <summary>
    /// Reads and writes the geometry (.shp) file of a shapefile, keeping its paired index
    /// (.shx) and, if present, projection (.prj) files in sync.
    /// </summary>
    internal sealed class GeographyFile : IDisposable
    {
        #region Private Member Variables

        private FileStream? _stream;
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

        /// <summary>
        /// Gets or sets the geometry type. Setting this also updates the paired index file's
        /// shape type, keeping the two files consistent.
        /// </summary>
        internal StarThrower.Gis.EsriLibrary.ShapeType ShapeType
        {
            get { return _header.ShapeType; }
            set
            {
                _header.ShapeType = value;
                _indexFile.ShapeType = value;
            }
        }

        /// <summary>
        /// Gets or sets the bounding rectangle that encloses all shapes in the file. Setting
        /// this also updates the paired index file's extent, keeping the two files consistent.
        /// </summary>
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

        /// <summary>
        /// Reads the file header and all geometry records from <see cref="_stream"/>. Relies
        /// on <see cref="_indexFile"/> already being open, since the number of records to
        /// read is taken from the index file's record count rather than the .shp file itself.
        /// </summary>
        private void Read()
        {
            if (_stream == null) throw new InvalidOperationException("Stream has not been opened.");
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

        /// <summary>
        /// Checks whether the index file and the loaded geometry records agree on record count.
        /// </summary>
        private bool IsValid()
        {
            if (_indexFile.RecordCount != _records.Count) return false;
            return true;
        }

        #endregion


        #region Internal Methods

        #region File Related

        /// <summary>
        /// Opens the .shp file (<paramref name="fileName"/> is assumed to have a .shp
        /// extension), along with its paired .shx index file and, if present, .prj
        /// projection file.
        /// </summary>
        internal void Open(string fileName, System.IO.FileMode fileMode, System.IO.FileAccess fileAccess)
        {
            string baseFileName = (Path.GetDirectoryName(fileName) ?? string.Empty) + "\\" + (Path.GetFileNameWithoutExtension(fileName) ?? string.Empty);
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
        /// Opens the .shp file (<paramref name="fileName"/> is assumed to have a .shp
        /// extension), along with its paired .shx index file and, if present, .prj
        /// projection file, with the specified sharing option.
        /// </summary>
        internal void Open(string fileName, System.IO.FileMode fileMode, System.IO.FileAccess fileAccess, System.IO.FileShare fileShare)
        {
            string baseFileName = (Path.GetDirectoryName(fileName) ?? string.Empty) + "\\" + (Path.GetFileNameWithoutExtension(fileName) ?? string.Empty);
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
        /// Closes the file, optionally saving changes first.
        /// </summary>
        internal void Close(bool save)
        {
            if (save)
            {
                Save();
            }
            _stream?.Close();

            _indexFile.Close(save);
            _projectionFile.Close(save);
        }

        /// <summary>
        /// Writes the header and all geometry records to the already-open file stream, then
        /// saves the paired index and projection files.
        /// </summary>
        /// <exception cref="InvalidOperationException">The file has not been opened.</exception>
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

        /// <summary>
        /// Saves the file to <paramref name="fileName"/>. If a stream is already open to that
        /// same path, this is equivalent to <see cref="Save"/>; otherwise the current stream
        /// (if any) is closed and a new file is created at the destination, and the paired
        /// index and projection files are saved alongside it.
        /// </summary>
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

            string baseFileName = (Path.GetDirectoryName(fileName) ?? string.Empty) + "\\" + (Path.GetFileNameWithoutExtension(fileName) ?? string.Empty);
            _indexFile.SaveAs(baseFileName + ".shx");
            _projectionFile.SaveAs(baseFileName + ".prj");
        }

        /// <summary>
        /// Serializes the geometry file's header and records, plus the paired index and
        /// projection files' XML, to a single combined XML string.
        /// </summary>
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

        /// <summary>
        /// Removes the geography record at the specified zero-based position, decrements the
        /// file-length field, re-sequences record numbers for all subsequent records, and
        /// recomputes the bounding-box extent from the remaining records.
        /// </summary>
        /// <param name="index">Zero-based position of the record to remove.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="index"/> is negative or greater than or equal to the record count.
        /// </exception>
        /// <remarks>
        /// Extent recomputation after deletion is O(n) in the number of remaining records, since
        /// the removed record may have defined any edge of the bounding box.
        /// </remarks>
        internal void DeleteRecord(int index)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(index);
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index, _records.Count);

            int removedLength = _records[index].GetLengthInBytes();
            _records.RemoveAt(index);
            _indexFile.DeleteRecord(index);
            _header.FileLength -= removedLength;

            // Recompute extent from scratch. Start with empty; skip NullShape records
            // (their IsEmpty extent would corrupt Left/Top by pulling them toward zero).
            // If no records remain, or all remaining are NullShapes, extent stays empty.
            StarThrower.Gis.GeoUtilities.GeoRectangle newExtent = new StarThrower.Gis.GeoUtilities.GeoRectangle(0, 0, 0, 0);
            for (int i = 0; i < _records.Count; i++)
            {
                StarThrower.Gis.GeoUtilities.GeoRectangle r = _records[i].Extent;
                if (r.IsEmpty) continue;
                if (newExtent.IsEmpty)
                {
                    newExtent = r;
                }
                else
                {
                    if (r.Left < newExtent.Left) newExtent.Left = r.Left;
                    if (r.Top < newExtent.Top) newExtent.Top = r.Top;
                    if (r.Right > newExtent.Right) newExtent.Right = r.Right;
                    if (r.Bottom > newExtent.Bottom) newExtent.Bottom = r.Bottom;
                }
            }
            _header.Extent = newExtent;
            _indexFile.Extent = newExtent;
        }

        /// <summary>
        /// Appends a geometry record, assigning it the next sequential record number, adding
        /// a matching entry to the index file, and expanding the file's bounding-box extent
        /// (and the index file's) to include the new record's extent.
        /// </summary>
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

            if (!record.Extent.IsEmpty)
            {
                if (firstRecord || _header.Extent.IsEmpty)
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
        }

        internal StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecord GetRecord(int index)
        {
            return _records[index];
        }

        #endregion

        #endregion
    }
}
