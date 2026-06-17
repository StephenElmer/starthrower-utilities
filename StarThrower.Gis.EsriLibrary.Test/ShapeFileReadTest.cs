// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.IO;
using AwesomeAssertions;
using StarThrower.Gis.EsriLibrary;
using StarThrower.Gis.GeoUtilities.Shapes;
using Xunit;

namespace StarThrower.Gis.EsriLibrary.Test
{
    /// <summary>
    /// Reads the esri007*/esri008* fixtures and verifies the resulting schema, attribute
    /// data, and geometry against values hand-derived directly from the raw .shp/.dbf bytes
    /// (see plan notes) rather than from any of this library's own XML export, so the
    /// expected values are independent of the code under test.
    /// </summary>
    public class ShapeFileReadTest
    {
        private readonly string _inputFolder;

        public ShapeFileReadTest()
        {
            _inputFolder = Path.GetFullPath(
                Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "TestInput"));
        }

        #region Private Methods

        private ShapeFile OpenShapeFile(string fileName)
        {
            string path = Path.Combine(_inputFolder, fileName);
            return new ShapeFile(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        }

        private static void AssertEsri007Schema(ShapeFile shapeFile)
        {
            shapeFile.FieldCount.Should().Be(3);

            shapeFile.GetField(0).Name.Should().Be("FIELDONE");
            shapeFile.GetField(0).Length.Should().Be(17);
            shapeFile.GetField(0).DecimalCount.Should().Be(0);

            shapeFile.GetField(1).Name.Should().Be("FIELDTWO");
            shapeFile.GetField(2).Name.Should().Be("FIELDTHREE");
        }

        private static void AssertEsri007RecordData(Record record)
        {
            record.GetData("FIELDONE").Should().Be("Record 1, Field 1");
            record.GetData("FIELDTWO").Should().Be("Record 1, Field 2");
            record.GetData("FIELDTHREE").Should().Be("Record 1, Field 3");
        }

        private static void AssertPoint(PointShape point, double expectedXLon, double expectedYLat)
        {
            point.xLon.Should().Be(expectedXLon);
            point.yLat.Should().Be(expectedYLat);
        }

        #endregion


        #region Point

        [Fact]
        public void PointSingleRecordReadsSchemaAttributesAndGeometry()
        {
            using ShapeFile shapeFile = OpenShapeFile("esri007a.shp");

            shapeFile.ShapeType.Should().Be(ShapeType.Point);
            shapeFile.RecordCount.Should().Be(1);
            AssertEsri007Schema(shapeFile);

            Record record = shapeFile.GetRecord(0);
            AssertEsri007RecordData(record);

            AssertPoint((PointShape)record.GetShape(), expectedXLon: 2.0, expectedYLat: 3.0);
        }

        [Fact]
        public void PointMultipleRecordsReadsAllGeometry()
        {
            using ShapeFile shapeFile = OpenShapeFile("esri008a.shp");

            shapeFile.RecordCount.Should().Be(3);

            AssertPoint((PointShape)shapeFile.GetRecord(0).GetShape(), expectedXLon: 2.0, expectedYLat: 3.0);
            AssertPoint((PointShape)shapeFile.GetRecord(1).GetShape(), expectedXLon: 4.0, expectedYLat: 5.0);
            AssertPoint((PointShape)shapeFile.GetRecord(2).GetShape(), expectedXLon: 6.0, expectedYLat: 7.0);
        }

        #endregion


        #region PolyLine

        [Fact]
        public void PolyLineSingleRecordReadsSchemaAttributesAndGeometry()
        {
            using ShapeFile shapeFile = OpenShapeFile("esri007b.shp");

            shapeFile.ShapeType.Should().Be(ShapeType.PolyLine);
            shapeFile.RecordCount.Should().Be(1);
            AssertEsri007Schema(shapeFile);

            Record record = shapeFile.GetRecord(0);
            AssertEsri007RecordData(record);

            PolylineShape line = (PolylineShape)record.GetShape();
            line.PartCount.Should().Be(1);

            OpenPart part = line.GetPart(0);
            part.PointCount.Should().Be(3);
            AssertPoint(part.GetPoint(0), expectedXLon: 2.0, expectedYLat: 3.0);
            AssertPoint(part.GetPoint(1), expectedXLon: 4.0, expectedYLat: 5.0);
            AssertPoint(part.GetPoint(2), expectedXLon: 6.0, expectedYLat: 7.0);
        }

        [Fact]
        public void PolyLineMultipleRecordsReadsAllGeometry()
        {
            using ShapeFile shapeFile = OpenShapeFile("esri008b.shp");

            shapeFile.RecordCount.Should().Be(3);

            OpenPart part0 = ((PolylineShape)shapeFile.GetRecord(0).GetShape()).GetPart(0);
            AssertPoint(part0.GetPoint(0), expectedXLon: 2.0, expectedYLat: 3.0);
            AssertPoint(part0.GetPoint(1), expectedXLon: 4.0, expectedYLat: 5.0);
            AssertPoint(part0.GetPoint(2), expectedXLon: 6.0, expectedYLat: 7.0);

            OpenPart part1 = ((PolylineShape)shapeFile.GetRecord(1).GetShape()).GetPart(0);
            AssertPoint(part1.GetPoint(0), expectedXLon: 1.0, expectedYLat: 1.0);
            AssertPoint(part1.GetPoint(1), expectedXLon: 5.0, expectedYLat: 5.0);
            AssertPoint(part1.GetPoint(2), expectedXLon: 9.0, expectedYLat: 9.0);

            OpenPart part2 = ((PolylineShape)shapeFile.GetRecord(2).GetShape()).GetPart(0);
            AssertPoint(part2.GetPoint(0), expectedXLon: 9.0, expectedYLat: 1.0);
            AssertPoint(part2.GetPoint(1), expectedXLon: 4.0, expectedYLat: 5.0);
            AssertPoint(part2.GetPoint(2), expectedXLon: 1.0, expectedYLat: 9.0);
        }

        #endregion


        #region Polygon

        [Fact]
        public void PolygonSingleRecordReadsSchemaAttributesAndGeometry()
        {
            using ShapeFile shapeFile = OpenShapeFile("esri007c.shp");

            shapeFile.ShapeType.Should().Be(ShapeType.Polygon);
            shapeFile.RecordCount.Should().Be(1);
            AssertEsri007Schema(shapeFile);

            Record record = shapeFile.GetRecord(0);
            AssertEsri007RecordData(record);

            PolygonShape polygon = (PolygonShape)record.GetShape();
            polygon.PartCount.Should().Be(1);

            ClosedPart part = polygon.GetPart(0);
            part.PointCount.Should().Be(4);
            AssertPoint(part.GetPoint(0), expectedXLon: 1.0, expectedYLat: 1.0);
            AssertPoint(part.GetPoint(1), expectedXLon: 9.0, expectedYLat: 1.0);
            AssertPoint(part.GetPoint(2), expectedXLon: 9.0, expectedYLat: 9.0);
            AssertPoint(part.GetPoint(3), expectedXLon: 1.0, expectedYLat: 1.0);
        }

        [Fact]
        public void PolygonMultipleRecordsReadsAllGeometry()
        {
            using ShapeFile shapeFile = OpenShapeFile("esri008c.shp");

            shapeFile.RecordCount.Should().Be(3);

            ClosedPart part0 = ((PolygonShape)shapeFile.GetRecord(0).GetShape()).GetPart(0);
            part0.PointCount.Should().Be(4);
            AssertPoint(part0.GetPoint(0), expectedXLon: 1.0, expectedYLat: 1.0);
            AssertPoint(part0.GetPoint(1), expectedXLon: 9.0, expectedYLat: 9.0);
            AssertPoint(part0.GetPoint(2), expectedXLon: 9.0, expectedYLat: 1.0);
            AssertPoint(part0.GetPoint(3), expectedXLon: 1.0, expectedYLat: 1.0);

            ClosedPart part1 = ((PolygonShape)shapeFile.GetRecord(1).GetShape()).GetPart(0);
            part1.PointCount.Should().Be(4);
            AssertPoint(part1.GetPoint(0), expectedXLon: 1.0, expectedYLat: 9.0);
            AssertPoint(part1.GetPoint(1), expectedXLon: 2.0, expectedYLat: 8.0);
            AssertPoint(part1.GetPoint(2), expectedXLon: 1.5, expectedYLat: 5.0);
            AssertPoint(part1.GetPoint(3), expectedXLon: 1.0, expectedYLat: 9.0);

            ClosedPart part2 = ((PolygonShape)shapeFile.GetRecord(2).GetShape()).GetPart(0);
            part2.PointCount.Should().Be(5);
            AssertPoint(part2.GetPoint(0), expectedXLon: 1.0, expectedYLat: 2.0);
            AssertPoint(part2.GetPoint(1), expectedXLon: 1.0, expectedYLat: 3.0);
            AssertPoint(part2.GetPoint(2), expectedXLon: 2.0, expectedYLat: 3.0);
            AssertPoint(part2.GetPoint(3), expectedXLon: 2.0, expectedYLat: 2.0);
            AssertPoint(part2.GetPoint(4), expectedXLon: 1.0, expectedYLat: 2.0);
        }

        #endregion
    }
}
