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
using System.IO;
using System.Xml;
using System.Text;
using StarThrower.StringUtilities;

namespace StarThrower.Gis.EsriLibrary
{
    public class ShapeFile : IDisposable
    {
        #region Private Member Variables

        private StarThrower.Gis.EsriLibrary.Internal.GeographyFile _geoFile = new StarThrower.Gis.EsriLibrary.Internal.GeographyFile();
        private StarThrower.XBase.XBaseFile _dataFile = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

        #endregion


        #region Public Properties

        public int RecordCount
        {
            get { return _geoFile.RecordCount; }
        }

        public int FieldCount
        {
            get { return _dataFile.FieldCount; }
        }

        public StarThrower.Gis.EsriLibrary.ShapeType ShapeType
        {
            get { return _geoFile.ShapeType; }
            set { _geoFile.ShapeType = value; }
        }

        public StarThrower.Gis.GeoUtilities.GeoRectangle Extent
        {
            get { return _geoFile.Extent; }
            set { _geoFile.Extent = value; }
        }

        public DateTime LastUpdate
        {
            get { return _dataFile.LastUpdate; }
            set { _dataFile.LastUpdate = value; }
        }

        #endregion


        #region Construction

        public ShapeFile() { }

        public ShapeFile(string fileName, System.IO.FileMode fileMode, System.IO.FileAccess fileAccess, System.IO.FileShare fileShare)
            : this()
        {
            this.Open(fileName, fileMode, fileAccess, fileShare);
        }

        public ShapeFile(string fileName, System.IO.FileMode fileMode, System.IO.FileAccess fileAccess)
            : this()
        {
            this.Open(fileName, fileMode, fileAccess);
        }

        #endregion


        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ShapeFile()
        {
            Dispose(false);
        }

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

        private bool IsValid()
        {
            if (_dataFile.RecordCount != _geoFile.RecordCount) return false;
            return true;
        }

        #endregion


        #region Public Methods

        #region Field Related

        public StarThrower.Gis.EsriLibrary.Field GetField(int index)
        {
            StarThrower.XBase.XBaseField field = _dataFile.GetField(index);
            return EsriLibrary.XBaseFieldToEsriField(field);
        }

        public StarThrower.Gis.EsriLibrary.Field GetField(string fieldName)
        {
            StarThrower.XBase.XBaseField field = _dataFile.GetField(fieldName);
            return EsriLibrary.XBaseFieldToEsriField(field);
        }

        public void AddField(StarThrower.Gis.EsriLibrary.Field field)
        {
            if (field == null) throw new ArgumentNullException("field");

            StarThrower.XBase.XBaseField newField = new StarThrower.XBase.XBaseField();
            newField.Name = field.Name;
            newField.Length = field.Length;
            newField.FieldType = field.Type ?? throw new ArgumentException("Field type must not be null.", nameof(field));
            newField.DecimalCount = field.DecimalCount;
            _dataFile.AddField(newField);
        }

        public bool FindField(string fieldName)
        {
            return _dataFile.FindField(fieldName);
        }

        public bool FindField(string fieldName, ref int index)
        {
            return _dataFile.FindField(fieldName, ref index);
        }

        public void DeleteField(int index)
        {
            _dataFile.DeleteField(index);
        }

        public void DeleteField(string fieldName)
        {
            _dataFile.DeleteField(fieldName);
        }

        public void AlterField(int index, StarThrower.Gis.EsriLibrary.Field field)
        {
            _dataFile.AlterField(index, EsriLibrary.EsriFieldToXBaseField(field));
        }

        public void AlterField(string fieldName, StarThrower.Gis.EsriLibrary.Field field)
        {
            _dataFile.AlterField(fieldName, EsriLibrary.EsriFieldToXBaseField(field));
        }

        #endregion


        #region Record Related

        /// <summary>
        /// Creates a new Record object with the appropriate fields already added
        /// </summary>
        /// <returns></returns>
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

        public void AddRecord(StarThrower.Gis.EsriLibrary.Record record)
        {
            if (record == null) throw new ArgumentNullException("record");
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

        public bool FindRecord(string queryString)
        {
            //TODO:  should there be a confirmation here (somehow) that the geoFile also contains this record?
            return _dataFile.FindRecord(queryString);
        }

        public bool FindRecord(string queryString, ref int index)
        {
            //TODO:  should there be a confirmation here (somehow) that the geoFile also contains this record?
            return _dataFile.FindRecord(queryString, ref index);
        }

        public void DeleteRecord(int index)
        {
            _dataFile.DestroyRecord(index);
            _geoFile.DeleteRecord(index);
        }

        public void DeleteRecord(string queryString)
        {
            int index = -1;
            if (FindRecord(queryString, ref index))
            {
                DeleteRecord(index);
            }
        }

        public void AlterRecord(int index, StarThrower.Gis.EsriLibrary.Record record)
        {
        }

        #endregion


        #region File Related

        public void Clear()
        {
            _geoFile.Close();
            _geoFile.Dispose();
            _dataFile.Close();
            _dataFile.Dispose();
            _geoFile = new StarThrower.Gis.EsriLibrary.Internal.GeographyFile();
            _dataFile = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);
        }

        public void Open(string fileName, System.IO.FileMode fileMode, System.IO.FileAccess fileAccess)
        {
            string baseFileName = (Path.GetDirectoryName(fileName) ?? string.Empty) + "\\" + (Path.GetFileNameWithoutExtension(fileName) ?? string.Empty);
            _dataFile.Open(baseFileName + ".dbf", fileMode, fileAccess);
            _geoFile.Open(baseFileName + ".shp", fileMode, fileAccess);
            if (!IsValid()) throw new InvalidDataException();
        }

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
        /// Closes the file taking a boolean parameter
        /// which indicates whether the file should be saved or not
        /// </summary>
        /// <param name="save"></param>
        public void Close(bool save)
        {
            _dataFile.Close(save);
            _geoFile.Close(save);
        }

        public void Save()
        {
            _dataFile.Save();
            _geoFile.Save();
        }

        public void SaveAs(string fileName)
        {

            string baseFileName = (Path.GetDirectoryName(fileName) ?? string.Empty) + "\\" + (Path.GetFileNameWithoutExtension(fileName) ?? string.Empty);
            _dataFile.SaveAs(baseFileName + ".dbf");
            _geoFile.SaveAs(baseFileName + ".shp");
        }

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

        public void LoadXml(XmlDocument doc, StarThrower.Gis.GeoUtilities.Formatting.XmlFormat xmlFormat)
        {
            if (doc == null) throw new ArgumentNullException("doc");

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

                    break;
                case StarThrower.Gis.GeoUtilities.Formatting.XmlFormat.Gml:

                    break;
                case StarThrower.Gis.GeoUtilities.Formatting.XmlFormat.FileWise:

                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public string ToJson()
        {
            StringBuilder result = new StringBuilder(String.Empty);

            return result.ToString();
        }

        public void LoadJson(string doc)
        {

        }

        #endregion

        #endregion
    }
}
