using System;
using System.IO;
using System.Xml;
using AwesomeAssertions;
using StarThrower.Gis.GeoUtilities;
using StarThrower.Gis.GeoUtilities.CoordinateSystems;
using StarThrower.Gis.GeoUtilities.CoordinateSystems.Geographic;
using StarThrower.Gis.GeoUtilities.CoordinateSystems.Projected;
using StarThrower.MathUtilities;
using StarThrower.Gis.GeoUtilities.Translations;
using System.Globalization;
using Xunit;

namespace StarThrower.Gis.GeoUtilities.Test
{
    public class WGS84TranslationTest
    {
        private string _inputFolder = "";

        #region Construction

        public WGS84TranslationTest()
        {
            _inputFolder = Path.GetFullPath(
                Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "TestInput"));
            if (!Directory.Exists(_inputFolder))
            {
                Directory.CreateDirectory(_inputFolder);
            }
        }

        #endregion


        [Fact]
        public void Test1a()
        {
            ConductLLToUTMNSWGS84Test("test1");
        }

        [Fact]
        public void Test1b()
        {
            ConductUTMNSWGS84ToLLTest("test1");
        }

        [Fact]
        public void Test1c()
        {
            ConductLLToUTM_WGS84Test("test1");
        }

        [Fact]
        public void Test1d()
        {
            ConductUTM_WGS84ToLLTest("test1");
        }




        [Fact]
        public void Test2a()
        {
            ConductLLToUTMNSWGS84Test("test2");
        }

        [Fact]
        public void Test2b()
        {
            ConductUTMNSWGS84ToLLTest("test2");
        }

        [Fact]
        public void Test2c()
        {
            ConductLLToUTM_WGS84Test("test2");
        }

        [Fact]
        public void Test2d()
        {
            ConductUTM_WGS84ToLLTest("test2");
        }



        [Fact]
        public void Test3a()
        {
            ConductLLToUTMNSWGS84Test("test3");
        }

        [Fact]
        public void Test3b()
        {
            ConductUTMNSWGS84ToLLTest("test3");
        }

        [Fact]
        public void Test3c()
        {
            ConductLLToUTM_WGS84Test("test3");
        }

        [Fact]
        public void Test3d()
        {
            ConductUTM_WGS84ToLLTest("test3");
        }



        [Fact]
        public void Test4a()
        {
            ConductLLToUTMNSWGS84Test("test4");
        }

        [Fact]
        public void Test4b()
        {
            ConductUTMNSWGS84ToLLTest("test4");
        }

        [Fact]
        public void Test4c()
        {
            ConductLLToUTM_WGS84Test("test4");
        }

        [Fact]
        public void Test4d()
        {
            ConductUTM_WGS84ToLLTest("test4");
        }



        [Fact]
        public void Test5a()
        {
            ConductLLToUTMNSWGS84Test("test5");
        }

        [Fact]
        public void Test5b()
        {
            ConductUTMNSWGS84ToLLTest("test5");
        }

        [Fact]
        public void Test5c()
        {
            ConductLLToUTM_WGS84Test("test5");
        }

        [Fact]
        public void Test5d()
        {
            ConductUTM_WGS84ToLLTest("test5");
        }



        [Fact]
        public void Test6a()
        {
            ConductLLToUTMNSWGS84Test("test6");
        }

        [Fact]
        public void Test6b()
        {
            ConductUTMNSWGS84ToLLTest("test6");
        }

        [Fact]
        public void Test6c()
        {
            ConductLLToUTM_WGS84Test("test6");
        }

        [Fact]
        public void Test6d()
        {
            ConductUTM_WGS84ToLLTest("test6");
        }


        [Fact]
        public void Test7a()
        {
            ConductLLToUTMNSWGS84Test("test7");
        }

        [Fact]
        public void Test7b()
        {
            ConductUTMNSWGS84ToLLTest("test7");
        }

        [Fact]
        public void Test7c()
        {
            ConductLLToUTM_WGS84Test("test7");
        }

        [Fact]
        public void Test7d()
        {
            ConductUTM_WGS84ToLLTest("test7");
        }


        [Fact]
        public void Test8a()
        {
            ConductLLToUTMNSWGS84Test("test8");
        }

        [Fact]
        public void Test8b()
        {
            ConductUTMNSWGS84ToLLTest("test8");
        }

        [Fact]
        public void Test8c()
        {
            ConductLLToUTM_WGS84Test("test8");
        }

        [Fact]
        public void Test8d()
        {
            ConductUTM_WGS84ToLLTest("test8");
        }


        [Fact]
        public void Test9a()
        {
            ConductLLToUTMNSWGS84Test("test9");
        }

        [Fact]
        public void Test9b()
        {
            ConductUTMNSWGS84ToLLTest("test9");
        }

        [Fact]
        public void Test9c()
        {
            ConductLLToUTM_WGS84Test("test9");
        }

        [Fact]
        public void Test9d()
        {
            ConductUTM_WGS84ToLLTest("test9");
        }


        [Fact]
        public void Test10a()
        {
            ConductLLToUTMNSWGS84Test("test10");
        }

        [Fact]
        public void Test10b()
        {
            ConductUTMNSWGS84ToLLTest("test10");
        }

        [Fact]
        public void Test10c()
        {
            ConductLLToUTM_WGS84Test("test10");
        }

        [Fact]
        public void Test10d()
        {
            ConductUTM_WGS84ToLLTest("test10");
        }


        [Fact]
        public void Test11a()
        {
            ConductLLToUTMNSWGS84Test("test11");
        }

        [Fact]
        public void Test11b()
        {
            ConductUTMNSWGS84ToLLTest("test11");
        }

        [Fact]
        public void Test11c()
        {
            ConductLLToUTM_WGS84Test("test11");
        }

        [Fact]
        public void Test11d()
        {
            ConductUTM_WGS84ToLLTest("test11");
        }


        [Fact]
        public void Test12a()
        {
            ConductLLToUTMNSWGS84Test("test12");
        }

        [Fact]
        public void Test12b()
        {
            ConductUTMNSWGS84ToLLTest("test12");
        }

        [Fact]
        public void Test12c()
        {
            ConductLLToUTM_WGS84Test("test12");
        }

        [Fact]
        public void Test12d()
        {
            ConductUTM_WGS84ToLLTest("test12");
        }


        [Fact]
        public void Test13a()
        {
            ConductLLToUTMNSWGS84Test("test13");
        }

        [Fact]
        public void Test13b()
        {
            ConductUTMNSWGS84ToLLTest("test13");
        }

        [Fact]
        public void Test13c()
        {
            ConductLLToUTM_WGS84Test("test13");
        }

        [Fact]
        public void Test13d()
        {
            ConductUTM_WGS84ToLLTest("test13");
        }


        [Fact]
        public void Test14a()
        {
            ConductLLToUTMNSWGS84Test("test14");
        }

        [Fact]
        public void Test14b()
        {
            ConductUTMNSWGS84ToLLTest("test14");
        }

        [Fact]
        public void Test14c()
        {
            ConductLLToUTM_WGS84Test("test14");
        }

        [Fact]
        public void Test14d()
        {
            ConductUTM_WGS84ToLLTest("test14");
        }


        [Fact]
        public void Test15a()
        {
            ConductLLToUTMNSWGS84Test("test15");
        }

        [Fact]
        public void Test15b()
        {
            ConductUTMNSWGS84ToLLTest("test15");
        }

        [Fact]
        public void Test15c()
        {
            ConductLLToUTM_WGS84Test("test15");
        }

        [Fact]
        public void Test15d()
        {
            ConductUTM_WGS84ToLLTest("test15");
        }


        [Fact]
        public void Test16a()
        {
            ConductLLToUTMNSWGS84Test("test16");
        }

        [Fact]
        public void Test16b()
        {
            ConductUTMNSWGS84ToLLTest("test16");
        }

        [Fact]
        public void Test16c()
        {
            ConductLLToUTM_WGS84Test("test16");
        }

        [Fact]
        public void Test16d()
        {
            ConductUTM_WGS84ToLLTest("test16");
        }


        [Fact]
        public void Test17a()
        {
            ConductLLToUTMNSWGS84Test("test17");
        }

        [Fact]
        public void Test17b()
        {
            ConductUTMNSWGS84ToLLTest("test17");
        }

        [Fact]
        public void Test17c()
        {
            ConductLLToUTM_WGS84Test("test17");
        }

        [Fact]
        public void Test17d()
        {
            ConductUTM_WGS84ToLLTest("test17");
        }


        [Fact]
        public void Test18a()
        {
            ConductLLToUTMNSWGS84Test("test18");
        }

        [Fact]
        public void Test18b()
        {
            ConductUTMNSWGS84ToLLTest("test18");
        }

        [Fact]
        public void Test18c()
        {
            ConductLLToUTM_WGS84Test("test18");
        }

        [Fact]
        public void Test18d()
        {
            ConductUTM_WGS84ToLLTest("test18");
        }


        [Fact]
        public void Test19a()
        {
            ConductLLToUTMNSWGS84Test("test19");
        }

        [Fact]
        public void Test19b()
        {
            ConductUTMNSWGS84ToLLTest("test19");
        }

        [Fact]
        public void Test19c()
        {
            ConductLLToUTM_WGS84Test("test19");
        }

        [Fact]
        public void Test19d()
        {
            ConductUTM_WGS84ToLLTest("test19");
        }


        [Fact]
        public void Test20a()
        {
            ConductLLToUTMNSWGS84Test("test20");
        }

        [Fact]
        public void Test20b()
        {
            ConductUTMNSWGS84ToLLTest("test20");
        }

        [Fact]
        public void Test20c()
        {
            ConductLLToUTM_WGS84Test("test20");
        }

        [Fact]
        public void Test20d()
        {
            ConductUTM_WGS84ToLLTest("test20");
        }


        [Fact]
        public void Test21a()
        {
            ConductLLToUTMNSWGS84Test("test21");
        }

        [Fact]
        public void Test21b()
        {
            ConductUTMNSWGS84ToLLTest("test21");
        }

        [Fact]
        public void Test21c()
        {
            ConductLLToUTM_WGS84Test("test21");
        }

        [Fact]
        public void Test21d()
        {
            ConductUTM_WGS84ToLLTest("test21");
        }


        [Fact]
        public void Test22a()
        {
            ConductLLToUTMNSWGS84Test("test22");
        }

        [Fact]
        public void Test22b()
        {
            ConductUTMNSWGS84ToLLTest("test22");
        }

        [Fact]
        public void Test22c()
        {
            ConductLLToUTM_WGS84Test("test22");
        }

        [Fact]
        public void Test22d()
        {
            ConductUTM_WGS84ToLLTest("test22");
        }




        private static string GetAttr(XmlNode? node, string childPath, string attr)
            => node?.SelectSingleNode(childPath)?.Attributes?.GetNamedItem(attr)?.Value
               ?? throw new InvalidOperationException($"Test XML missing {childPath}/@{attr}");

        private void ConductLLToUTM_WGS84Test(string testName)
        {
            string inputFile = _inputFolder + "\\WGS84TranslationTests.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(inputFile);
            XmlNode? testNode = doc.SelectSingleNode("//tests/test[@name='" + testName + "']");

            double lon = double.Parse(GetAttr(testNode, "ll", "lon"), CultureInfo.InvariantCulture);
            double lat = double.Parse(GetAttr(testNode, "ll", "lat"), CultureInfo.InvariantCulture);

            double x = 0.0;
            double y = 0.0;
            string zone = String.Empty;

            double expectedX = MathUtil.RoundTo(double.Parse(GetAttr(testNode, "utm", "x"), CultureInfo.InvariantCulture), 2);
            double expectedY = MathUtil.RoundTo(double.Parse(GetAttr(testNode, "utm", "y"), CultureInfo.InvariantCulture), 2);
            string expectedZone = GetAttr(testNode, "utm", "zone");

            //GeoUtil.ConvertFromGeographicToProjectedCoordSys(typeof(UsngWgs84), typeof(UtmWgs84), lon, lat, ref x, ref y, ref zone);
            IGeographicCoordinateSystem gcs = GeographicCoordinateSystemFactory.GetInstanceOfGeographicCoordinateSystem("GeodeticWgs84");
            IProjectedCoordinateSystem pcs = ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem("UtmWgs84");
            ITranslationResult result = GeoUtil.Translate(gcs, pcs, lon, lat, 0);
            x = result.xLon;
            y = result.yLat;
            //zone = "1North";
            if (result is ZonedResult)
            {
                zone = ((ZonedResult)result).Zone.ZoneString;
            }

            x.Should().Be(expectedX, "(x)");
            y.Should().Be(expectedY, "(y)");
            zone.Should().Be(expectedZone, "(zone)");
        }

        private void ConductUTM_WGS84ToLLTest(string testName)
        {
            string inputFile = _inputFolder + "\\WGS84TranslationTests.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(inputFile);
            XmlNode? testNode = doc.SelectSingleNode("//tests/test[@name='" + testName + "']");

            double x = double.Parse(GetAttr(testNode, "utm", "x"), CultureInfo.InvariantCulture);
            double y = double.Parse(GetAttr(testNode, "utm", "y"), CultureInfo.InvariantCulture);
            string zone = GetAttr(testNode, "utm", "zone");

            double lon = 0.0;
            double lat = 0.0;

            double expectedLon = double.Parse(GetAttr(testNode, "ll", "lon"), CultureInfo.InvariantCulture);
            double expectedLat = double.Parse(GetAttr(testNode, "ll", "lat"), CultureInfo.InvariantCulture);

            //GeoUtil.ConvertFromProjectedToGeographicCoordSys(typeof(UtmWgs84Ns), typeof(UsngWgs84), x, y, zone, ref lon, ref lat);
            IZone utmZone = new Zones.Utm.UtmZone(zone);
            IProjectedCoordinateSystem pcs = ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(CoordinateSystems.Projected.UtmWgs84), utmZone);
            IGeographicCoordinateSystem gcs = GeographicCoordinateSystemFactory.GetInstanceOfGeographicCoordinateSystem("GeodeticWgs84");
            ITranslationResult result = GeoUtil.Translate(pcs, gcs, x, y, 0);
            lat = result.yLat;
            lon = result.xLon;

            lon.Should().Be(expectedLon, "(xLon)");
            lat.Should().Be(expectedLat, "(yLat)");
        }




        private void ConductLLToUTMNSWGS84Test(string testName)
        {
            string inputFile = _inputFolder + "\\WGS84TranslationTests.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(inputFile);
            XmlNode? testNode = doc.SelectSingleNode("//tests/test[@name='" + testName + "']");

            double lon = double.Parse(GetAttr(testNode, "ll", "lon"), CultureInfo.InvariantCulture);
            double lat = double.Parse(GetAttr(testNode, "ll", "lat"), CultureInfo.InvariantCulture);

            double x = 0.0;
            double y = 0.0;
            string zone = String.Empty;

            double expectedX = MathUtil.RoundTo(double.Parse(GetAttr(testNode, "utmns", "x"), CultureInfo.InvariantCulture), 2);
            double expectedY = MathUtil.RoundTo(double.Parse(GetAttr(testNode, "utmns", "y"), CultureInfo.InvariantCulture), 2);
            string expectedZone = GetAttr(testNode, "utmns", "zone");

            //GeoUtil.ConvertFromGeographicToProjectedCoordSys(typeof(UsngWgs84), typeof(UtmWgs84Ns), lon, lat, ref x, ref y, ref zone);
            IGeographicCoordinateSystem gcs = GeographicCoordinateSystemFactory.GetInstanceOfGeographicCoordinateSystem("GeodeticWgs84");
            IProjectedCoordinateSystem pcs = ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem("UtmWgs84Ns");
            ITranslationResult result = GeoUtil.Translate(gcs, pcs, lon, lat, 0);
            x = result.xLon;
            y = result.yLat;
            if (result is ZonedResult)
            {
                zone = ((ZonedResult)result).Zone.ZoneString;
            }

            x.Should().Be(expectedX, "(x)");
            y.Should().Be(expectedY, "(y)");
            zone.Should().Be(expectedZone, "(zone)");
        }

        private void ConductUTMNSWGS84ToLLTest(string testName)
        {
            string inputFile = _inputFolder + "\\WGS84TranslationTests.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(inputFile);
            XmlNode? testNode = doc.SelectSingleNode("//tests/test[@name='" + testName + "']");

            double x = double.Parse(GetAttr(testNode, "utmns", "x"), CultureInfo.InvariantCulture);
            double y = double.Parse(GetAttr(testNode, "utmns", "y"), CultureInfo.InvariantCulture);
            string zone = GetAttr(testNode, "utmns", "zone");

            double lon = 0.0;
            double lat = 0.0;

            double expectedLon = double.Parse(GetAttr(testNode, "ll", "lon"), CultureInfo.InvariantCulture);
            double expectedLat = double.Parse(GetAttr(testNode, "ll", "lat"), CultureInfo.InvariantCulture);

            //GeoUtil.ConvertFromProjectedToGeographicCoordSys(typeof(UtmWgs84Ns), typeof(UsngWgs84), x, y, zone, ref lon, ref lat);
            IZone utmZone = new Zones.UtmNs.UtmNsZone(zone);
            IProjectedCoordinateSystem pcs = ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(CoordinateSystems.Projected.UtmWgs84Ns), utmZone);
            IGeographicCoordinateSystem gcs = GeographicCoordinateSystemFactory.GetInstanceOfGeographicCoordinateSystem("GeodeticWgs84");
            ITranslationResult result = GeoUtil.Translate(pcs, gcs, x, y, 0);
            lat = result.yLat;
            lon = result.xLon;

            lon.Should().Be(expectedLon, "(xLon)");
            lat.Should().Be(expectedLat, "(yLat)");
        }
    }
}
