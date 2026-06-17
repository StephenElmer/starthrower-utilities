// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.IO;
using AwesomeAssertions;
using StarThrower.FileUtilities;
using StarThrower.Gis.EsriLibrary;
using StarThrower.Gis.EsriLibrary.Types;
using StarThrower.Gis.GeoUtilities.Shapes;
using Xunit;

namespace StarThrower.Gis.EsriLibrary.Test
{
    /// <summary>
    /// Builds a ShapeFile from scratch (matching the esri007a/b/c fixtures' known schema and
    /// data, hand-derived in ShapeFileReadTest) and verifies the saved .shp/.shx/.dbf are
    /// byte-for-byte identical to the corresponding TestInput fixture, the same pattern
    /// StarThrower.XBase.Test uses for write verification (FileSystem.FileCompare).
    /// </summary>
    public class ShapeFileWriteTest
    {
        private readonly string _inputFolder;
        private readonly string _outputFolder;

        public ShapeFileWriteTest()
        {
            _inputFolder = Path.GetFullPath(
                Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "TestInput"));

            _outputFolder = Path.GetFullPath(
                Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "TestOutput"));
            if (!Directory.Exists(_outputFolder))
            {
                Directory.CreateDirectory(_outputFolder);
            }
        }

        #region Private Methods

        private static ShapeFile CreateShapeFileWithStandardFields(ShapeType shapeType)
        {
            ShapeFile shapeFile = new ShapeFile();
            shapeFile.ShapeType = shapeType;

            shapeFile.AddField(new Field { Name = "FIELDONE", Type = new StringField(), Length = 17, DecimalCount = 0 });
            shapeFile.AddField(new Field { Name = "FIELDTWO", Type = new StringField(), Length = 17, DecimalCount = 0 });
            shapeFile.AddField(new Field { Name = "FIELDTHREE", Type = new StringField(), Length = 17, DecimalCount = 0 });

            return shapeFile;
        }

        private static Record CreateStandardRecord(ShapeFile shapeFile)
        {
            Record record = shapeFile.CreateNewRecord();
            record.SetData("FIELDONE", "Record 1, Field 1");
            record.SetData("FIELDTWO", "Record 1, Field 2");
            record.SetData("FIELDTHREE", "Record 1, Field 3");
            return record;
        }

        private void AssertMatchesFixture(ShapeFile shapeFile, string baseFileName)
        {
            string outputBasePath = Path.Combine(_outputFolder, baseFileName);
            shapeFile.LastUpdate = new DateTime(2007, 1, 1);
            shapeFile.SaveAs(outputBasePath + ".shp");
            shapeFile.Close();
            shapeFile.Dispose();

            FileSystem.FileCompare(
                Path.Combine(_inputFolder, baseFileName + ".dbf"),
                outputBasePath + ".dbf").Should().BeTrue();
            FileSystem.FileCompare(
                Path.Combine(_inputFolder, baseFileName + ".shp"),
                outputBasePath + ".shp").Should().BeTrue();
            FileSystem.FileCompare(
                Path.Combine(_inputFolder, baseFileName + ".shx"),
                outputBasePath + ".shx").Should().BeTrue();
        }

        #endregion

        [Fact]
        public void WritePointMatchesFixture()
        {
            ShapeFile shapeFile = CreateShapeFileWithStandardFields(ShapeType.Point);

            Record record = CreateStandardRecord(shapeFile);
            record.SetShape(new PointShape(xLon: 2.0, yLat: 3.0));
            shapeFile.AddRecord(record);

            AssertMatchesFixture(shapeFile, "esri007a");
        }

        [Fact]
        public void WritePolyLineMatchesFixture()
        {
            ShapeFile shapeFile = CreateShapeFileWithStandardFields(ShapeType.PolyLine);

            Record record = CreateStandardRecord(shapeFile);
            PolylineShape line = new PolylineShape();
            line.AddPart();
            OpenPart part = line.GetPart(0);
            part.AddPoint(new PointShape(xLon: 2.0, yLat: 3.0));
            part.AddPoint(new PointShape(xLon: 4.0, yLat: 5.0));
            part.AddPoint(new PointShape(xLon: 6.0, yLat: 7.0));
            record.SetShape(line);
            shapeFile.AddRecord(record);

            AssertMatchesFixture(shapeFile, "esri007b");
        }

        [Fact]
        public void WritePolygonMatchesFixture()
        {
            ShapeFile shapeFile = CreateShapeFileWithStandardFields(ShapeType.Polygon);

            Record record = CreateStandardRecord(shapeFile);
            PolygonShape polygon = new PolygonShape();
            polygon.AddPart();
            ClosedPart part = polygon.GetPart(0);
            part.AddPoint(new PointShape(xLon: 1.0, yLat: 1.0));
            part.AddPoint(new PointShape(xLon: 9.0, yLat: 1.0));
            part.AddPoint(new PointShape(xLon: 9.0, yLat: 9.0));
            part.AddPoint(new PointShape(xLon: 1.0, yLat: 1.0));
            record.SetShape(polygon);
            shapeFile.AddRecord(record);

            AssertMatchesFixture(shapeFile, "esri007c");
        }
    }
}
