// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Text;
using StarThrower.StringUtilities;

namespace StarThrower.Gis.EsriLibrary
{
    /// <summary>
    /// Reads and writes an ESRI shapefile (a .shp geometry file paired with a .dbf attribute
    /// table), exposing the combined geometry and attribute data as a sequence of
    /// <see cref="Record"/> objects.
    /// </summary>
    public class ShapeFile : IDisposable
    {
        #region Private Member Variables

        private StarThrower.Gis.EsriLibrary.Internal.GeographyFile _geoFile = new StarThrower.Gis.EsriLibrary.Internal.GeographyFile();
        private StarThrower.XBase.XBaseFile _dataFile = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets the number of records in the shapefile.
        /// </summary>
        public int RecordCount
        {
            get { return _geoFile.RecordCount; }
        }

        /// <summary>
        /// Gets the number of attribute fields defined for the shapefile.
        /// </summary>
        public int FieldCount
        {
            get { return _dataFile.FieldCount; }
        }

        /// <summary>
        /// Gets or sets the geometry type stored in the shapefile.
        /// </summary>
        public StarThrower.Gis.EsriLibrary.ShapeType ShapeType
        {
            get { return _geoFile.ShapeType; }
            set { _geoFile.ShapeType = value; }
        }

        /// <summary>
        /// Gets or sets the bounding rectangle that encloses all shapes in the shapefile.
        /// </summary>
        public StarThrower.Gis.GeoUtilities.GeoRectangle Extent
        {
            get { return _geoFile.Extent; }
            set { _geoFile.Extent = value; }
        }

        /// <summary>
        /// Gets or sets the date the attribute table was last updated.
        /// </summary>
        public DateTime LastUpdate
        {
            get { return _dataFile.LastUpdate; }
            set { _dataFile.LastUpdate = value; }
        }

        #endregion


        #region Construction

        /// <summary>
        /// Initializes a new, empty <see cref="ShapeFile"/> that is not associated with a file
        /// on disk.
        /// </summary>
        public ShapeFile() { }

        /// <summary>
        /// Initializes a new <see cref="ShapeFile"/> and opens the underlying .shp/.dbf files
        /// with the specified file mode, access, and sharing options.
        /// </summary>
        /// <param name="fileName">The path to the shapefile (with or without the .shp/.dbf extension).</param>
        /// <param name="fileMode">Specifies how the operating system should open the file.</param>
        /// <param name="fileAccess">Specifies the type of access requested.</param>
        /// <param name="fileShare">Specifies the type of access other threads have to the file.</param>
        /// <exception cref="InvalidDataException">The .shp and .dbf files have mismatched record counts.</exception>
        public ShapeFile(string fileName, System.IO.FileMode fileMode, System.IO.FileAccess fileAccess, System.IO.FileShare fileShare)
            : this()
        {
            this.Open(fileName, fileMode, fileAccess, fileShare);
        }

        /// <summary>
        /// Initializes a new <see cref="ShapeFile"/> and opens the underlying .shp/.dbf files
        /// with the specified file mode and access.
        /// </summary>
        /// <param name="fileName">The path to the shapefile (with or without the .shp/.dbf extension).</param>
        /// <param name="fileMode">Specifies how the operating system should open the file.</param>
        /// <param name="fileAccess">Specifies the type of access requested.</param>
        /// <exception cref="InvalidDataException">The .shp and .dbf files have mismatched record counts.</exception>
        public ShapeFile(string fileName, System.IO.FileMode fileMode, System.IO.FileAccess fileAccess)
            : this()
        {
            this.Open(fileName, fileMode, fileAccess);
        }

        #endregion


        #region IDisposable Members

        /// <summary>
        /// Releases all resources used by this <see cref="ShapeFile"/>.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the underlying file resources if <see cref="Dispose()"/> was not called.
        /// </summary>
        ~ShapeFile()
        {
            Dispose(false);
        }

        /// <summary>
        /// Releases the underlying geography and attribute file resources.
        /// </summary>
        /// <param name="disposing">
        /// <see langword="true"/> to release both managed and unmanaged resources;
        /// <see langword="false"/> to release only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _geoFile.Dispose();
                _dataFile.Dispose();
            }
        }

        //public void Dispose()
        //{
        //    if (_geoFile != null)
        //    {
        //        _geoFile.Dispose();
        //    }
        //    if (_dataFile != null)
        //    {
        //        _dataFile.Dispose();
        //    }
        //}

        #endregion


        #region Private Methods

        /// <summary>
        /// Checks whether the attribute file and geography file agree on record count.
        /// </summary>
        private bool IsValid()
        {
            if (_dataFile.RecordCount != _geoFile.RecordCount) return false;
            return true;
        }

        /// <summary>
        /// Parses a point shape from a "point" XML element's lat/lon attributes.
        /// </summary>
        private static StarThrower.Gis.GeoUtilities.Shapes.PointShape ReadPointShape(XmlNode pointNode, XmlDocument doc)
        {
            double lat = double.Parse(pointNode.Attributes?.GetNamedItem("lat")?.Value ?? throw new ArgumentException("Invalid XML: point lat attribute not found.", nameof(doc)), CultureInfo.InvariantCulture);
            double lon = double.Parse(pointNode.Attributes?.GetNamedItem("lon")?.Value ?? throw new ArgumentException("Invalid XML: point lon attribute not found.", nameof(doc)), CultureInfo.InvariantCulture);
            return new StarThrower.Gis.GeoUtilities.Shapes.PointShape(lon, lat);
        }

        #endregion


        #region Public Methods

        #region Field Related

        /// <summary>
        /// Gets the field descriptor at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the field.</param>
        /// <returns>The <see cref="Field"/> at the specified index.</returns>
        public StarThrower.Gis.EsriLibrary.Field GetField(int index)
        {
            StarThrower.XBase.XBaseField field = _dataFile.GetField(index);
            return EsriLibrary.XBaseFieldToEsriField(field);
        }

        /// <summary>
        /// Gets the field descriptor with the specified name.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <returns>The <see cref="Field"/> with the specified name.</returns>
        public StarThrower.Gis.EsriLibrary.Field GetField(string fieldName)
        {
            StarThrower.XBase.XBaseField field = _dataFile.GetField(fieldName);
            return EsriLibrary.XBaseFieldToEsriField(field);
        }

        /// <summary>
        /// Adds a new attribute field to the shapefile.
        /// </summary>
        /// <param name="field">The field descriptor to add.</param>
        /// <exception cref="ArgumentNullException"><paramref name="field"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="field"/>.Type is <see langword="null"/>.</exception>
        public void AddField(StarThrower.Gis.EsriLibrary.Field field)
        {
            ArgumentNullException.ThrowIfNull(field);

            StarThrower.XBase.XBaseField newField = new StarThrower.XBase.XBaseField();
            newField.Name = field.Name;
            newField.Length = field.Length;
            newField.FieldType = field.Type ?? throw new ArgumentException("Field type must not be null.", nameof(field));
            newField.DecimalCount = field.DecimalCount;
            _dataFile.AddField(newField);
        }

        /// <summary>
        /// Determines whether a field with the specified name exists.
        /// </summary>
        /// <param name="fieldName">The name of the field to find.</param>
        /// <returns><see langword="true"/> if the field exists; otherwise, <see langword="false"/>.</returns>
        public bool FindField(string fieldName)
        {
            return _dataFile.FindField(fieldName);
        }

        /// <summary>
        /// Determines whether a field with the specified name exists and, if so, returns its index.
        /// </summary>
        /// <param name="fieldName">The name of the field to find.</param>
        /// <param name="index">When this method returns, contains the zero-based index of the field if found.</param>
        /// <returns><see langword="true"/> if the field exists; otherwise, <see langword="false"/>.</returns>
        public bool FindField(string fieldName, ref int index)
        {
            return _dataFile.FindField(fieldName, ref index);
        }

        /// <summary>
        /// Removes the field at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the field to remove.</param>
        public void DeleteField(int index)
        {
            _dataFile.DeleteField(index);
        }

        /// <summary>
        /// Removes the field with the specified name.
        /// </summary>
        /// <param name="fieldName">The name of the field to remove.</param>
        public void DeleteField(string fieldName)
        {
            _dataFile.DeleteField(fieldName);
        }

        /// <summary>
        /// Replaces the field descriptor at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the field to alter.</param>
        /// <param name="field">The new field descriptor.</param>
        public void AlterField(int index, StarThrower.Gis.EsriLibrary.Field field)
        {
            _dataFile.AlterField(index, EsriLibrary.EsriFieldToXBaseField(field));
        }

        /// <summary>
        /// Replaces the field descriptor with the specified name.
        /// </summary>
        /// <param name="fieldName">The name of the field to alter.</param>
        /// <param name="field">The new field descriptor.</param>
        public void AlterField(string fieldName, StarThrower.Gis.EsriLibrary.Field field)
        {
            _dataFile.AlterField(fieldName, EsriLibrary.EsriFieldToXBaseField(field));
        }

        #endregion


        #region Record Related

        /// <summary>
        /// Creates a new <see cref="Record"/> with the shapefile's fields already added and an
        /// empty shape initialized to match the shapefile's <see cref="ShapeType"/>.
        /// </summary>
        /// <returns>A new, empty <see cref="Record"/> ready to have data and shape geometry set.</returns>
        public StarThrower.Gis.EsriLibrary.Record CreateNewRecord()
        {
            StarThrower.Gis.EsriLibrary.Record newRecord = new StarThrower.Gis.EsriLibrary.Record();

            switch (_geoFile.ShapeType)
            {
                case ShapeType.MultiPatch:
                    newRecord.SetShape(new StarThrower.Gis.GeoUtilities.Shapes.MultipatchShape());
                    break;
                case ShapeType.MultiPoint:
                    newRecord.SetShape(new StarThrower.Gis.GeoUtilities.Shapes.MultipointShape());
                    break;
                case ShapeType.MultiPointM:
                    newRecord.SetShape(new StarThrower.Gis.GeoUtilities.Shapes.MultipointMShape());
                    break;
                case ShapeType.MultiPointZ:
                    newRecord.SetShape(new StarThrower.Gis.GeoUtilities.Shapes.MultipointZShape());
                    break;
                case ShapeType.Point:
                    newRecord.SetShape(new StarThrower.Gis.GeoUtilities.Shapes.PointShape());
                    break;
                case ShapeType.PointM:
                    newRecord.SetShape(new StarThrower.Gis.GeoUtilities.Shapes.PointMShape());
                    break;
                case ShapeType.PointZ:
                    newRecord.SetShape(new StarThrower.Gis.GeoUtilities.Shapes.PointZShape());
                    break;
                case ShapeType.Polygon:
                    newRecord.SetShape(new StarThrower.Gis.GeoUtilities.Shapes.PolygonShape());
                    break;
                case ShapeType.PolygonM:
                    newRecord.SetShape(new StarThrower.Gis.GeoUtilities.Shapes.PolygonMShape());
                    break;
                case ShapeType.PolygonZ:
                    newRecord.SetShape(new StarThrower.Gis.GeoUtilities.Shapes.PolygonZShape());
                    break;
                case ShapeType.PolyLine:
                    newRecord.SetShape(new StarThrower.Gis.GeoUtilities.Shapes.PolylineShape());
                    break;
                case ShapeType.PolyLineM:
                    newRecord.SetShape(new StarThrower.Gis.GeoUtilities.Shapes.PolylineMShape());
                    break;
                case ShapeType.PolyLineZ:
                    newRecord.SetShape(new StarThrower.Gis.GeoUtilities.Shapes.PolylineZShape());
                    break;
                case ShapeType.NullShape:
                default:
                    newRecord.SetShape(new StarThrower.Gis.GeoUtilities.Shapes.NullShape());
                    break;
            }

            int length = 0;
            for (int i = 0; i < _dataFile.FieldCount; i++)
            {
                StarThrower.XBase.XBaseField field = _dataFile.GetField(i);
                newRecord.AddField(field);
                length += field.Length;
            }

            //string newData = Strings.FromByteArray(new byte[length]);
            //newRecord.SetAllData(newData);

            return newRecord;
        }

        /// <summary>
        /// Appends a record's attribute data and shape geometry to the shapefile.
        /// </summary>
        /// <param name="record">The record to add.</param>
        /// <exception cref="ArgumentNullException"><paramref name="record"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="record"/>'s shape type does not match the shapefile's <see cref="ShapeType"/>.</exception>
        public void AddRecord(StarThrower.Gis.EsriLibrary.Record record)
        {
            ArgumentNullException.ThrowIfNull(record);
            if (!(EsriLibrary.GeoToEsriShapeType(record.GetShape().ShapeType).Equals(this.ShapeType))) throw new ArgumentException("Record is of invalid ShapeType for this Shape File.");

            StarThrower.XBase.XBaseRecord xBaseRecord = _dataFile.CreateRecord();
            foreach (StarThrower.XBase.XBaseField f in record.GetFieldDescriptors())
            {
                object? value = record.GetData(f.Name);
                if (value != null)
                    xBaseRecord.SetData(f.Name, value);
            }
            _dataFile.AddRecord(xBaseRecord);


            StarThrower.Gis.EsriLibrary.ShapeType shapeType = EsriLibrary.GeoToEsriShapeType(record.GetShape().ShapeType);
            byte[] bytes = EsriLibrary.ShapeToBytes(record.GetShape());
            StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecord geoRecord = new StarThrower.Gis.EsriLibrary.Internal.GeographyFileRecord(shapeType, bytes);
            _geoFile.AddRecord(geoRecord);
        }

        /// <summary>
        /// Reads the record at the specified index, including its attribute data and shape geometry.
        /// </summary>
        /// <param name="index">The zero-based index of the record to retrieve.</param>
        /// <returns>The <see cref="Record"/> at the specified index.</returns>
        public StarThrower.Gis.EsriLibrary.Record GetRecord(int index)
        {
            StarThrower.Gis.EsriLibrary.Record result = new StarThrower.Gis.EsriLibrary.Record();

            for (int i = 0; i < _dataFile.FieldCount; i++)
            {
                result.AddField(_dataFile.GetField(i));
            }

            for (int i = 0; i < _dataFile.FieldCount; i++)
            {
                string fieldName = _dataFile.GetField(i).Name;
                result.SetData(fieldName, _dataFile.GetRecord(index).GetData(fieldName));
            }

            result.SetShape(_geoFile.GetRecord(index).GetGeoUtilitiesShape());

            return result;
        }

        /// <summary>
        /// Searches the attribute table for a record matching the specified query.
        /// </summary>
        /// <param name="queryString">The query expression used to search the attribute data.</param>
        /// <returns><see langword="true"/> if a matching record was found; otherwise, <see langword="false"/>.</returns>
        public bool FindRecord(string queryString)
        {
            // No geo-file check needed: IsValid() at Open time enforces
            // _dataFile.RecordCount == _geoFile.RecordCount, and AddRecord/
            // DeleteRecord keep the two files in sync on every mutation.
            return _dataFile.FindRecord(queryString);
        }

        /// <summary>
        /// Searches the attribute table for a record matching the specified query and returns its index.
        /// </summary>
        /// <param name="queryString">The query expression used to search the attribute data.</param>
        /// <param name="index">When this method returns, contains the zero-based index of the matching record if found.</param>
        /// <returns><see langword="true"/> if a matching record was found; otherwise, <see langword="false"/>.</returns>
        public bool FindRecord(string queryString, ref int index)
        {
            // No geo-file check needed: IsValid() at Open time enforces
            // _dataFile.RecordCount == _geoFile.RecordCount, and AddRecord/
            // DeleteRecord keep the two files in sync on every mutation.
            return _dataFile.FindRecord(queryString, ref index);
        }

        /// <summary>
        /// Removes the attribute data and shape geometry for the record at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the record to remove.</param>
        public void DeleteRecord(int index)
        {
            _dataFile.DestroyRecord(index);
            _geoFile.DeleteRecord(index);
        }

        /// <summary>
        /// Finds and removes the first record matching the specified query. Does nothing if
        /// no matching record is found.
        /// </summary>
        /// <param name="queryString">The query expression used to search the attribute data.</param>
        public void DeleteRecord(string queryString)
        {
            int index = -1;
            if (FindRecord(queryString, ref index))
            {
                DeleteRecord(index);
            }
        }

        /// <summary>
        /// Not implemented. Reserved for future support for altering an existing record's data in place.
        /// </summary>
        /// <param name="index">The zero-based index of the record to alter.</param>
        /// <param name="record">The replacement record data.</param>
        /// <exception cref="NotImplementedException">Always thrown; this method is not yet implemented.</exception>
        //TODO: #35 — unimplemented stub
        public void AlterRecord(int index, StarThrower.Gis.EsriLibrary.Record record)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region File Related

        /// <summary>
        /// Closes the shapefile without saving and resets it to a new, empty state.
        /// </summary>
        public void Clear()
        {
            _geoFile.Close();
            _geoFile.Dispose();
            _dataFile.Close();
            _dataFile.Dispose();
            _geoFile = new StarThrower.Gis.EsriLibrary.Internal.GeographyFile();
            _dataFile = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);
        }

        /// <summary>
        /// Opens the .shp and .dbf files that make up the shapefile.
        /// </summary>
        /// <param name="fileName">The path to the shapefile (with or without the .shp/.dbf extension).</param>
        /// <param name="fileMode">Specifies how the operating system should open the file.</param>
        /// <param name="fileAccess">Specifies the type of access requested.</param>
        /// <exception cref="InvalidDataException">The .shp and .dbf files have mismatched record counts.</exception>
        public void Open(string fileName, System.IO.FileMode fileMode, System.IO.FileAccess fileAccess)
        {
            string baseFileName = (Path.GetDirectoryName(fileName) ?? string.Empty) + "\\" + (Path.GetFileNameWithoutExtension(fileName) ?? string.Empty);
            _dataFile.Open(baseFileName + ".dbf", fileMode, fileAccess);
            _geoFile.Open(baseFileName + ".shp", fileMode, fileAccess);
            if (!IsValid()) throw new InvalidDataException();
        }

        /// <summary>
        /// Opens the .shp and .dbf files that make up the shapefile with the specified sharing option.
        /// </summary>
        /// <param name="fileName">The path to the shapefile (with or without the .shp/.dbf extension).</param>
        /// <param name="fileMode">Specifies how the operating system should open the file.</param>
        /// <param name="fileAccess">Specifies the type of access requested.</param>
        /// <param name="fileShare">Specifies the type of access other threads have to the file.</param>
        /// <exception cref="InvalidDataException">The .shp and .dbf files have mismatched record counts.</exception>
        public void Open(string fileName, System.IO.FileMode fileMode, System.IO.FileAccess fileAccess, System.IO.FileShare fileShare)
        {
            string baseFileName = (Path.GetDirectoryName(fileName) ?? string.Empty) + "\\" + (Path.GetFileNameWithoutExtension(fileName) ?? string.Empty);
            _dataFile.Open(baseFileName + ".dbf", fileMode, fileAccess, fileShare);
            _geoFile.Open(baseFileName + ".shp", fileMode, fileAccess, fileShare);
            if (!IsValid()) throw new InvalidDataException();
        }

        /// <summary>
        /// Closes the file without saving
        /// </summary>
        public void Close()
        {
            _dataFile.Close();
            _geoFile.Close();
        }

        /// <summary>
        /// Closes the shapefile, optionally saving changes first.
        /// </summary>
        /// <param name="save"><see langword="true"/> to save changes before closing; otherwise, <see langword="false"/>.</param>
        public void Close(bool save)
        {
            _dataFile.Close(save);
            _geoFile.Close(save);
        }

        /// <summary>
        /// Saves changes to the .shp and .dbf files.
        /// </summary>
        public void Save()
        {
            _dataFile.Save();
            _geoFile.Save();
        }

        /// <summary>
        /// Saves the shapefile to a new location.
        /// </summary>
        /// <param name="fileName">The destination path (with or without the .shp/.dbf extension).</param>
        public void SaveAs(string fileName)
        {

            string baseFileName = (Path.GetDirectoryName(fileName) ?? string.Empty) + "\\" + (Path.GetFileNameWithoutExtension(fileName) ?? string.Empty);
            _dataFile.SaveAs(baseFileName + ".dbf");
            _geoFile.SaveAs(baseFileName + ".shp");
        }

        /// <summary>
        /// Serializes the shapefile's fields, extent, records, and geometry to an XML string
        /// in the specified format. The <see cref="StarThrower.Gis.GeoUtilities.Formatting.XmlFormat.Gml"/>
        /// format is not yet implemented and currently produces no output for that section.
        /// </summary>
        /// <param name="xmlFormat">The XML format to produce.</param>
        /// <returns>An XML string representing the shapefile's contents.</returns>
        public string ToXml(StarThrower.Gis.GeoUtilities.Formatting.XmlFormat xmlFormat)
        {
            StringBuilder result = new StringBuilder(String.Empty);

            switch (xmlFormat)
            {
                case StarThrower.Gis.GeoUtilities.Formatting.XmlFormat.LayerWise:
                    result.AppendLine("<layer shapeType=\"" + this.ShapeType.ToString() + "\">");

                    result.AppendLine("<coordinateSystem>");
                    result.AppendLine("</coordinateSystem>");

                    result.AppendLine("<fields>");
                    for (int i = 0; i < this.FieldCount; i++)
                    {
                        StarThrower.Gis.EsriLibrary.Field field = this.GetField(i);
                        result.AppendLine("<field " +
                                      "name=\"" + StringUtil.XmlEncode(field.Name) + "\" " +
                                      "type=\"" + field.Type?.ToString() + "\" " +
                                      "length=\"" + field.Length.ToString(CultureInfo.InvariantCulture) + "\" " +
                                      "decimalCount=\"" + field.DecimalCount.ToString(CultureInfo.InvariantCulture) + "\" " +
                                      "/>");
                    }
                    result.AppendLine("</fields>");

                    StarThrower.Gis.GeoUtilities.GeoRectangle extent = this.Extent;
                    result.AppendLine("<extent top=\"" + extent.Top.ToString(CultureInfo.InvariantCulture) + "\" " +
                                           "left=\"" + extent.Left.ToString(CultureInfo.InvariantCulture) + "\" " +
                                           "bottom=\"" + extent.Bottom.ToString(CultureInfo.InvariantCulture) + "\" " +
                                           "right=\"" + extent.Right.ToString(CultureInfo.InvariantCulture) + "\"/>");

                    result.AppendLine("<records>");
                    for (int i = 0; i < this.RecordCount; i++)
                    {
                        result.AppendLine("<record>");
                        StarThrower.Gis.EsriLibrary.Record record = this.GetRecord(i);
                        result.AppendLine("<data>");
                        for (int j = 0; j < this.FieldCount; j++)
                        {
                            string fieldName = this.GetField(j).Name;
                            string dataStr = record.GetData(fieldName)?.ToString()?.Trim() ?? string.Empty;
                            result.AppendLine("<" + StringUtil.XmlEncode(fieldName) + " value=\"" + StringUtil.XmlEncode(dataStr) + "\"/>");
                        }
                        result.AppendLine("</data>");
                        result.AppendLine("<geography>");
                        switch (this.ShapeType)
                        {
                            case ShapeType.Point:
                                StarThrower.Gis.GeoUtilities.Shapes.PointShape pointShape = ((StarThrower.Gis.GeoUtilities.Shapes.PointShape)(record.GetShape()));
                                result.AppendLine("<point lat=\"" + pointShape.yLat.ToString(CultureInfo.InvariantCulture) + "\" lon=\"" + pointShape.xLon.ToString(CultureInfo.InvariantCulture) + "\"/>");
                                break;
                            case ShapeType.PolyLine:
                                StarThrower.Gis.GeoUtilities.Shapes.PolylineShape lineShape = ((StarThrower.Gis.GeoUtilities.Shapes.PolylineShape)(record.GetShape()));
                                result.AppendLine("<polyLine>");
                                result.AppendLine("<partList>");
                                for (int k = 0; k < lineShape.PartCount; k++)
                                {
                                    result.AppendLine("<part>");
                                    result.AppendLine("<pointList>");
                                    for (int l = 0; l < lineShape.GetPart(k).PointCount; l++)
                                    {
                                        result.AppendLine("<point lat=\"" + lineShape.GetPart(k).GetPoint(l).yLat.ToString(CultureInfo.InvariantCulture) + "\" lon=\"" + lineShape.GetPart(k).GetPoint(l).xLon.ToString(CultureInfo.InvariantCulture) + "\"/>");
                                    }
                                    result.AppendLine("</pointList>");
                                    result.AppendLine("</part>");
                                }
                                result.AppendLine("</partList>");
                                result.AppendLine("</polyLine>");
                                break;
                            case ShapeType.Polygon:
                                StarThrower.Gis.GeoUtilities.Shapes.PolygonShape polygonShape = ((StarThrower.Gis.GeoUtilities.Shapes.PolygonShape)(record.GetShape()));
                                result.AppendLine("<polygon>");
                                result.AppendLine("<partList>");
                                for (int k = 0; k < polygonShape.PartCount; k++)
                                {
                                    result.AppendLine("<part>");
                                    result.AppendLine("<pointList>");
                                    for (int l = 0; l < polygonShape.GetPart(k).PointCount; l++)
                                    {
                                        result.AppendLine("<point lat=\"" + polygonShape.GetPart(k).GetPoint(l).yLat.ToString(CultureInfo.InvariantCulture) + "\" lon=\"" + polygonShape.GetPart(k).GetPoint(l).xLon.ToString(CultureInfo.InvariantCulture) + "\"/>");
                                    }
                                    result.AppendLine("</pointList>");
                                    result.AppendLine("</part>");
                                }
                                result.AppendLine("</partList>");
                                result.AppendLine("</polygon>");
                                break;
                        }
                        result.AppendLine("</geography>");
                        result.AppendLine("</record>");
                    }
                    result.AppendLine("</records>");

                    result.AppendLine("</layer>");
                    break;
                case StarThrower.Gis.GeoUtilities.Formatting.XmlFormat.Gml:
                    //TODO: #34 — no Gml output; returns an empty string with no indication the format isn't supported
                    break;
                case StarThrower.Gis.GeoUtilities.Formatting.XmlFormat.FileWise:
                default:
                    result.AppendLine("<shapeFile>");
                    result.Append(_geoFile.ToXml());
                    result.Append(_dataFile.ToXml());
                    result.AppendLine("</shapeFile>");
                    break;
            }

            return result.ToString().Replace("\0", "");
        }

        /// <summary>
        /// Clears the shapefile and repopulates it from XML previously produced by <see cref="ToXml"/>.
        /// Only the <see cref="StarThrower.Gis.GeoUtilities.Formatting.XmlFormat.LayerWise"/>
        /// format is currently implemented.
        /// </summary>
        /// <param name="doc">The XML document to load.</param>
        /// <param name="xmlFormat">The XML format the document is expected to be in.</param>
        /// <exception cref="ArgumentNullException"><paramref name="doc"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="xmlFormat"/> is not supported, or <paramref name="doc"/> is missing
        /// expected elements or attributes for the specified format.
        /// </exception>
        public void LoadXml(XmlDocument doc, StarThrower.Gis.GeoUtilities.Formatting.XmlFormat xmlFormat)
        {
            ArgumentNullException.ThrowIfNull(doc);

            this.Clear();

            switch (xmlFormat)
            {
                case StarThrower.Gis.GeoUtilities.Formatting.XmlFormat.LayerWise:

                    XmlNode layerNode = doc.SelectSingleNode("//layer") ?? throw new ArgumentException("Invalid XML: layer element not found.", nameof(doc));
                    string shapeType = layerNode.Attributes?.GetNamedItem("shapeType")?.Value ?? throw new ArgumentException("Invalid XML: shapeType attribute not found.", nameof(doc));
                    this.ShapeType = EsriLibrary.GetShapeTypeFromString(shapeType);

                    XmlNode? projectionNode = layerNode.SelectSingleNode("coordinateSystem");

                    XmlNode fieldsNode = layerNode.SelectSingleNode("fields") ?? throw new ArgumentException("Invalid XML: fields element not found.", nameof(doc));
                    foreach (XmlNode fieldNode in fieldsNode.SelectNodes("field") ?? throw new ArgumentException("Invalid XML: field elements not found.", nameof(doc)))
                    {
                        StarThrower.Gis.EsriLibrary.Field field = new StarThrower.Gis.EsriLibrary.Field();
                        field.Name = fieldNode.Attributes?.GetNamedItem("name")?.Value ?? throw new ArgumentException("Invalid XML: field name attribute not found.", nameof(doc));
                        string fieldtype = fieldNode.Attributes?.GetNamedItem("type")?.Value ?? throw new ArgumentException("Invalid XML: field type attribute not found.", nameof(doc));
                        switch (fieldtype)
                        {
                            case "StarThrower.Gis.EsriLibrary.Types.BooleanField":
                                field.Type = new StarThrower.Gis.EsriLibrary.Types.BooleanField();
                                break;
                            case "StarThrower.Gis.EsriLibrary.Types.DateField":
                                field.Type = new StarThrower.Gis.EsriLibrary.Types.DateField();
                                break;
                            case "StarThrower.Gis.EsriLibrary.Types.FloatField":
                                field.Type = new StarThrower.Gis.EsriLibrary.Types.FloatField();
                                break;
                            case "StarThrower.Gis.EsriLibrary.Types.MemoField":
                                field.Type = new StarThrower.Gis.EsriLibrary.Types.MemoField();
                                break;
                            case "StarThrower.Gis.EsriLibrary.Types.NumericField":
                                field.Type = new StarThrower.Gis.EsriLibrary.Types.NumericField();
                                break;
                            case "StarThrower.Gis.EsriLibrary.Types.StringField":
                                field.Type = new StarThrower.Gis.EsriLibrary.Types.StringField();
                                break;
                            case "StarThrower.Gis.EsriLibrary.Types.UndefinedField":
                            default:
                                field.Type = new StarThrower.Gis.EsriLibrary.Types.UndefinedField();
                                break;
                        }
                        field.Length = int.Parse(fieldNode.Attributes?.GetNamedItem("length")?.Value ?? throw new ArgumentException("Invalid XML: length attribute not found.", nameof(doc)), CultureInfo.InvariantCulture);
                        field.DecimalCount = int.Parse(fieldNode.Attributes?.GetNamedItem("decimalCount")?.Value ?? throw new ArgumentException("Invalid XML: decimalCount attribute not found.", nameof(doc)), CultureInfo.InvariantCulture);
                        this.AddField(field);
                    }

                    XmlNode? recordsNode = layerNode.SelectSingleNode("records");

                    XmlNode extentNode = layerNode.SelectSingleNode("extent") ?? throw new ArgumentException("Invalid XML: extent element not found.", nameof(doc));
                    double top = double.Parse(extentNode.Attributes?.GetNamedItem("top")?.Value ?? throw new ArgumentException("Invalid XML: extent top attribute not found.", nameof(doc)), CultureInfo.InvariantCulture);
                    double left = double.Parse(extentNode.Attributes?.GetNamedItem("left")?.Value ?? throw new ArgumentException("Invalid XML: extent left attribute not found.", nameof(doc)), CultureInfo.InvariantCulture);
                    double bottom = double.Parse(extentNode.Attributes?.GetNamedItem("bottom")?.Value ?? throw new ArgumentException("Invalid XML: extent bottom attribute not found.", nameof(doc)), CultureInfo.InvariantCulture);
                    double right = double.Parse(extentNode.Attributes?.GetNamedItem("right")?.Value ?? throw new ArgumentException("Invalid XML: extent right attribute not found.", nameof(doc)), CultureInfo.InvariantCulture);
                    this.Extent = new StarThrower.Gis.GeoUtilities.GeoRectangle(left, top, right, bottom);

                    if (recordsNode != null)
                    {
                        foreach (XmlNode recordNode in recordsNode.SelectNodes("record") ?? throw new ArgumentException("Invalid XML: record elements not found.", nameof(doc)))
                        {
                            StarThrower.Gis.EsriLibrary.Record record = this.CreateNewRecord();

                            XmlNode dataNode = recordNode.SelectSingleNode("data") ?? throw new ArgumentException("Invalid XML: data element not found.", nameof(doc));
                            for (int i = 0; i < this.FieldCount; i++)
                            {
                                string fieldName = this.GetField(i).Name;
                                string dataStr = dataNode.SelectSingleNode(fieldName)?.Attributes?.GetNamedItem("value")?.Value ?? string.Empty;
                                StarThrower.XBase.XBaseField xBaseField = record.GetFieldDescriptors()[i];
                                record.SetData(fieldName, xBaseField.FieldType.Translate(dataStr));
                            }

                            XmlNode geographyNode = recordNode.SelectSingleNode("geography") ?? throw new ArgumentException("Invalid XML: geography element not found.", nameof(doc));
                            switch (this.ShapeType)
                            {
                                case ShapeType.Point:
                                    XmlNode pointNode = geographyNode.SelectSingleNode("point") ?? throw new ArgumentException("Invalid XML: point element not found.", nameof(doc));
                                    record.SetShape(ReadPointShape(pointNode, doc));
                                    break;
                                case ShapeType.PolyLine:
                                    StarThrower.Gis.GeoUtilities.Shapes.PolylineShape lineShape = new StarThrower.Gis.GeoUtilities.Shapes.PolylineShape();
                                    XmlNode lineNode = geographyNode.SelectSingleNode("polyLine") ?? throw new ArgumentException("Invalid XML: polyLine element not found.", nameof(doc));
                                    foreach (XmlNode partNode in lineNode.SelectSingleNode("partList")?.SelectNodes("part") ?? throw new ArgumentException("Invalid XML: part elements not found.", nameof(doc)))
                                    {
                                        lineShape.AddPart();
                                        StarThrower.Gis.GeoUtilities.Shapes.OpenPart linePart = lineShape.GetPart(lineShape.PartCount - 1);
                                        foreach (XmlNode linePointNode in partNode.SelectSingleNode("pointList")?.SelectNodes("point") ?? throw new ArgumentException("Invalid XML: point elements not found.", nameof(doc)))
                                        {
                                            linePart.AddPoint(ReadPointShape(linePointNode, doc));
                                        }
                                    }
                                    record.SetShape(lineShape);
                                    break;
                                case ShapeType.Polygon:
                                    StarThrower.Gis.GeoUtilities.Shapes.PolygonShape polygonShape = new StarThrower.Gis.GeoUtilities.Shapes.PolygonShape();
                                    XmlNode polygonNode = geographyNode.SelectSingleNode("polygon") ?? throw new ArgumentException("Invalid XML: polygon element not found.", nameof(doc));
                                    foreach (XmlNode partNode in polygonNode.SelectSingleNode("partList")?.SelectNodes("part") ?? throw new ArgumentException("Invalid XML: part elements not found.", nameof(doc)))
                                    {
                                        polygonShape.AddPart();
                                        StarThrower.Gis.GeoUtilities.Shapes.ClosedPart polygonPart = polygonShape.GetPart(polygonShape.PartCount - 1);
                                        foreach (XmlNode polygonPointNode in partNode.SelectSingleNode("pointList")?.SelectNodes("point") ?? throw new ArgumentException("Invalid XML: point elements not found.", nameof(doc)))
                                        {
                                            polygonPart.AddPoint(ReadPointShape(polygonPointNode, doc));
                                        }
                                    }
                                    record.SetShape(polygonShape);
                                    break;
                            }

                            this.AddRecord(record);
                        }
                    }

                    break;
                case StarThrower.Gis.GeoUtilities.Formatting.XmlFormat.Gml:
                    //TODO: #34 — no Gml support; silently loads nothing rather than throwing
                    break;
                case StarThrower.Gis.GeoUtilities.Formatting.XmlFormat.FileWise:
                    //TODO: #34 — no FileWise read support (asymmetric with ToXml, which writes FileWise); silently loads nothing
                    break;
                default:
                    throw new ArgumentException("Unsupported XML format.", nameof(xmlFormat));
            }
        }

        /// <summary>
        /// Not implemented. Reserved for future JSON serialization support.
        /// </summary>
        /// <returns>Does not return; always throws.</returns>
        /// <exception cref="NotImplementedException">Always thrown; this method is not yet implemented.</exception>
        //TODO: #35 — unimplemented stub
        public string ToJson()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented. Reserved for future JSON deserialization support.
        /// </summary>
        /// <param name="doc">The JSON document to load.</param>
        /// <exception cref="NotImplementedException">Always thrown; this method is not yet implemented.</exception>
        //TODO: #35 — unimplemented stub
        public void LoadJson(string doc)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}
