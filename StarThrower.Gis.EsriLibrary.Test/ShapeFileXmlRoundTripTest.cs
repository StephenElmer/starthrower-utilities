// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.IO;
using System.Xml;
using AwesomeAssertions;
using StarThrower.Gis.EsriLibrary;
using StarThrower.Gis.GeoUtilities.Formatting;
using StarThrower.Gis.GeoUtilities.Shapes;
using Xunit;

namespace StarThrower.Gis.EsriLibrary.Test
{
    /// <summary>
    /// Verifies that ShapeFile.ToXml(LayerWise) and LoadXml(LayerWise) round-trip a shape
    /// file: load a fixture, export it to XML, load that XML into a brand new ShapeFile, and
    /// confirm the reloaded schema/attributes/geometry match the same hand-derived expected
    /// values used by ShapeFileReadTest (independent of the XML export code being tested).
    /// </summary>
    public class ShapeFileXmlRoundTripTest
    {
        private readonly string _inputFolder;

        public ShapeFileXmlRoundTripTest()
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

        private static ShapeFile RoundTripThroughLayerWiseXml(ShapeFile original)
        {
            string xml = original.ToXml(XmlFormat.LayerWise);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            ShapeFile reloaded = new ShapeFile();
            reloaded.LoadXml(doc, XmlFormat.LayerWise);
            return reloaded;
        }

        private static void AssertPoint(PointShape point, double expectedXLon, double expectedYLat)
        {
            point.xLon.Should().Be(expectedXLon);
            point.yLat.Should().Be(expectedYLat);
        }

        #endregion

        [Fact]
        public void PointRoundTripsSchemaAttributesAndGeometry()
        {
            using ShapeFile original = OpenShapeFile("esri007a.shp");
            ShapeFile reloaded = RoundTripThroughLayerWiseXml(original);

            reloaded.ShapeType.Should().Be(ShapeType.Point);
            reloaded.RecordCount.Should().Be(1);
            reloaded.FieldCount.Should().Be(3);
            reloaded.GetField(0).Name.Should().Be("FIELDONE");

            Record record = reloaded.GetRecord(0);
            record.GetData("FIELDONE").Should().Be("Record 1, Field 1");
            record.GetData("FIELDTWO").Should().Be("Record 1, Field 2");
            record.GetData("FIELDTHREE").Should().Be("Record 1, Field 3");

            AssertPoint((PointShape)record.GetShape(), expectedXLon: 2.0, expectedYLat: 3.0);
        }

        [Fact]
        public void PolyLineRoundTripsSchemaAttributesAndGeometry()
        {
            using ShapeFile original = OpenShapeFile("esri008b.shp");
            ShapeFile reloaded = RoundTripThroughLayerWiseXml(original);

            reloaded.ShapeType.Should().Be(ShapeType.PolyLine);
            reloaded.RecordCount.Should().Be(3);

            OpenPart part1 = ((PolylineShape)reloaded.GetRecord(1).GetShape()).GetPart(0);
            part1.PointCount.Should().Be(3);
            AssertPoint(part1.GetPoint(0), expectedXLon: 1.0, expectedYLat: 1.0);
            AssertPoint(part1.GetPoint(1), expectedXLon: 5.0, expectedYLat: 5.0);
            AssertPoint(part1.GetPoint(2), expectedXLon: 9.0, expectedYLat: 9.0);
        }

        [Fact]
        public void PolygonRoundTripsSchemaAttributesAndGeometry()
        {
            using ShapeFile original = OpenShapeFile("esri008c.shp");
            ShapeFile reloaded = RoundTripThroughLayerWiseXml(original);

            reloaded.ShapeType.Should().Be(ShapeType.Polygon);
            reloaded.RecordCount.Should().Be(3);

            ClosedPart part2 = ((PolygonShape)reloaded.GetRecord(2).GetShape()).GetPart(0);
            part2.PointCount.Should().Be(5);
            AssertPoint(part2.GetPoint(0), expectedXLon: 1.0, expectedYLat: 2.0);
            AssertPoint(part2.GetPoint(1), expectedXLon: 1.0, expectedYLat: 3.0);
            AssertPoint(part2.GetPoint(2), expectedXLon: 2.0, expectedYLat: 3.0);
            AssertPoint(part2.GetPoint(3), expectedXLon: 2.0, expectedYLat: 2.0);
            AssertPoint(part2.GetPoint(4), expectedXLon: 1.0, expectedYLat: 2.0);
        }
    }
}
