using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using StarThrower.Gis.GeoUtilities;
using StarThrower.Gis.GeoUtilities.CoordinateSystems;
using StarThrower.Gis.GeoUtilities.CoordinateSystems.Geographic;
using StarThrower.Gis.GeoUtilities.CoordinateSystems.Projected;
using StarThrower.MathUtilities;
using StarThrower.Gis.GeoUtilities.Translations;

namespace StarThrower.Gis.GeoUtilities.Test
{
    [TestClass]
    public class WGS84TranslationTest
    {
        private void Ignore()
        {
            #if FAIL_ON_IGNORE
                Assert.Fail("This test has been ignored.");
            #else
                Assert.Inconclusive("this test has been ignored");
            #endif
        }

        private string _inputFolder = "";

        #region Construction

        public WGS84TranslationTest()
        {
            _inputFolder = @"D:\StarThrower\Development\StarThrower.Utilities\Current\Code\TestInput";
            if (!Directory.Exists(_inputFolder))
            {
                Directory.CreateDirectory(_inputFolder);
            }
        }

        #endregion


        [TestMethod]
        public void Test1a()
        {
            ConductLLToUTM_NS_WGS84Test("test1");
        }

        [TestMethod]
        public void Test1b()
        {
            ConductUTM_NS_WGS84ToLLTest("test1");
        }

        [TestMethod]
        public void Test1c()
        {
            ConductLLToUTM_WGS84Test("test1");
        }

        [TestMethod]
        public void Test1d()
        {
            ConductUTM_WGS84ToLLTest("test1");
        }




        [TestMethod]
        public void Test2a()
        {
            ConductLLToUTM_NS_WGS84Test("test2");
        }

        [TestMethod]
        public void Test2b()
        {
            ConductUTM_NS_WGS84ToLLTest("test2");
        }

        [TestMethod]
        public void Test2c()
        {
            ConductLLToUTM_WGS84Test("test2");
        }

        [TestMethod]
        public void Test2d()
        {
            ConductUTM_WGS84ToLLTest("test2");
        }



        [TestMethod]
        public void Test3a()
        {
            ConductLLToUTM_NS_WGS84Test("test3");
        }

        [TestMethod]
        public void Test3b()
        {
            ConductUTM_NS_WGS84ToLLTest("test3");
        }

        [TestMethod]
        public void Test3c()
        {
            ConductLLToUTM_WGS84Test("test3");
        }

        [TestMethod]
        public void Test3d()
        {
            ConductUTM_WGS84ToLLTest("test3");
        }



        [TestMethod]
        public void Test4a()
        {
            ConductLLToUTM_NS_WGS84Test("test4");
        }

        [TestMethod]
        public void Test4b()
        {
            ConductUTM_NS_WGS84ToLLTest("test4");
        }

        [TestMethod]
        public void Test4c()
        {
            ConductLLToUTM_WGS84Test("test4");
        }

        [TestMethod]
        public void Test4d()
        {
            ConductUTM_WGS84ToLLTest("test4");
        }



        [TestMethod]
        public void Test5a()
        {
            ConductLLToUTM_NS_WGS84Test("test5");
        }

        [TestMethod]
        public void Test5b()
        {
            ConductUTM_NS_WGS84ToLLTest("test5");
        }

        [TestMethod]
        public void Test5c()
        {
            ConductLLToUTM_WGS84Test("test5");
        }

        [TestMethod]
        public void Test5d()
        {
            ConductUTM_WGS84ToLLTest("test5");
        }



        [TestMethod]
        public void Test6a()
        {
            ConductLLToUTM_NS_WGS84Test("test6");
        }

        [TestMethod]
        public void Test6b()
        {
            ConductUTM_NS_WGS84ToLLTest("test6");
        }

        [TestMethod]
        public void Test6c()
        {
            ConductLLToUTM_WGS84Test("test6");
        }

        [TestMethod]
        public void Test6d()
        {
            ConductUTM_WGS84ToLLTest("test6");
        }


        [TestMethod]
        public void Test7a()
        {
            ConductLLToUTM_NS_WGS84Test("test7");
        }

        [TestMethod]
        public void Test7b()
        {
            ConductUTM_NS_WGS84ToLLTest("test7");
        }

        [TestMethod]
        public void Test7c()
        {
            ConductLLToUTM_WGS84Test("test7");
        }

        [TestMethod]
        public void Test7d()
        {
            ConductUTM_WGS84ToLLTest("test7");
        }


        [TestMethod]
        public void Test8a()
        {
            ConductLLToUTM_NS_WGS84Test("test8");
        }

        [TestMethod]
        public void Test8b()
        {
            ConductUTM_NS_WGS84ToLLTest("test8");
        }

        [TestMethod]
        public void Test8c()
        {
            ConductLLToUTM_WGS84Test("test8");
        }

        [TestMethod]
        public void Test8d()
        {
            ConductUTM_WGS84ToLLTest("test8");
        }


        [TestMethod]
        public void Test9a()
        {
            ConductLLToUTM_NS_WGS84Test("test9");
        }

        [TestMethod]
        public void Test9b()
        {
            ConductUTM_NS_WGS84ToLLTest("test9");
        }

        [TestMethod]
        public void Test9c()
        {
            ConductLLToUTM_WGS84Test("test9");
        }

        [TestMethod]
        public void Test9d()
        {
            ConductUTM_WGS84ToLLTest("test9");
        }


        [TestMethod]
        public void Test10a()
        {
            ConductLLToUTM_NS_WGS84Test("test10");
        }

        [TestMethod]
        public void Test10b()
        {
            ConductUTM_NS_WGS84ToLLTest("test10");
        }

        [TestMethod]
        public void Test10c()
        {
            ConductLLToUTM_WGS84Test("test10");
        }

        [TestMethod]
        public void Test10d()
        {
            ConductUTM_WGS84ToLLTest("test10");
        }


        [TestMethod]
        public void Test11a()
        {
            ConductLLToUTM_NS_WGS84Test("test11");
        }

        [TestMethod]
        public void Test11b()
        {
            ConductUTM_NS_WGS84ToLLTest("test11");
        }

        [TestMethod]
        public void Test11c()
        {
            ConductLLToUTM_WGS84Test("test11");
        }

        [TestMethod]
        public void Test11d()
        {
            ConductUTM_WGS84ToLLTest("test11");
        }


        [TestMethod]
        public void Test12a()
        {
            ConductLLToUTM_NS_WGS84Test("test12");
        }

        [TestMethod]
        public void Test12b()
        {
            ConductUTM_NS_WGS84ToLLTest("test12");
        }

        [TestMethod]
        public void Test12c()
        {
            ConductLLToUTM_WGS84Test("test12");
        }

        [TestMethod]
        public void Test12d()
        {
            ConductUTM_WGS84ToLLTest("test12");
        }


        [TestMethod]
        public void Test13a()
        {
            ConductLLToUTM_NS_WGS84Test("test13");
        }

        [TestMethod]
        public void Test13b()
        {
            ConductUTM_NS_WGS84ToLLTest("test13");
        }

        [TestMethod]
        public void Test13c()
        {
            ConductLLToUTM_WGS84Test("test13");
        }

        [TestMethod]
        public void Test13d()
        {
            ConductUTM_WGS84ToLLTest("test13");
        }


        [TestMethod]
        public void Test14a()
        {
            ConductLLToUTM_NS_WGS84Test("test14");
        }

        [TestMethod]
        public void Test14b()
        {
            ConductUTM_NS_WGS84ToLLTest("test14");
        }

        [TestMethod]
        public void Test14c()
        {
            ConductLLToUTM_WGS84Test("test14");
        }

        [TestMethod]
        public void Test14d()
        {
            ConductUTM_WGS84ToLLTest("test14");
        }


        [TestMethod]
        public void Test15a()
        {
            ConductLLToUTM_NS_WGS84Test("test15");
        }

        [TestMethod]
        public void Test15b()
        {
            ConductUTM_NS_WGS84ToLLTest("test15");
        }

        [TestMethod]
        public void Test15c()
        {
            ConductLLToUTM_WGS84Test("test15");
        }

        [TestMethod]
        public void Test15d()
        {
            ConductUTM_WGS84ToLLTest("test15");
        }


        [TestMethod]
        public void Test16a()
        {
            ConductLLToUTM_NS_WGS84Test("test16");
        }

        [TestMethod]
        public void Test16b()
        {
            ConductUTM_NS_WGS84ToLLTest("test16");
        }

        [TestMethod]
        public void Test16c()
        {
            ConductLLToUTM_WGS84Test("test16");
        }

        [TestMethod]
        public void Test16d()
        {
            ConductUTM_WGS84ToLLTest("test16");
        }


        [TestMethod]
        public void Test17a()
        {
            ConductLLToUTM_NS_WGS84Test("test17");
        }

        [TestMethod]
        public void Test17b()
        {
            ConductUTM_NS_WGS84ToLLTest("test17");
        }

        [TestMethod]
        public void Test17c()
        {
            ConductLLToUTM_WGS84Test("test17");
        }

        [TestMethod]
        public void Test17d()
        {
            ConductUTM_WGS84ToLLTest("test17");
        }


        [TestMethod]
        public void Test18a()
        {
            ConductLLToUTM_NS_WGS84Test("test18");
        }

        [TestMethod]
        public void Test18b()
        {
            ConductUTM_NS_WGS84ToLLTest("test18");
        }

        [TestMethod]
        public void Test18c()
        {
            ConductLLToUTM_WGS84Test("test18");
        }

        [TestMethod]
        public void Test18d()
        {
            ConductUTM_WGS84ToLLTest("test18");
        }


        [TestMethod]
        public void Test19a()
        {
            ConductLLToUTM_NS_WGS84Test("test19");
        }

        [TestMethod]
        public void Test19b()
        {
            ConductUTM_NS_WGS84ToLLTest("test19");
        }

        [TestMethod]
        public void Test19c()
        {
            ConductLLToUTM_WGS84Test("test19");
        }

        [TestMethod]
        public void Test19d()
        {
            ConductUTM_WGS84ToLLTest("test19");
        }


        [TestMethod]
        public void Test20a()
        {
            ConductLLToUTM_NS_WGS84Test("test20");
        }

        [TestMethod]
        public void Test20b()
        {
            ConductUTM_NS_WGS84ToLLTest("test20");
        }

        [TestMethod]
        public void Test20c()
        {
            ConductLLToUTM_WGS84Test("test20");
        }

        [TestMethod]
        public void Test20d()
        {
            ConductUTM_WGS84ToLLTest("test20");
        }


        [TestMethod]
        public void Test21a()
        {
            ConductLLToUTM_NS_WGS84Test("test21");
        }

        [TestMethod]
        public void Test21b()
        {
            ConductUTM_NS_WGS84ToLLTest("test21");
        }

        [TestMethod]
        public void Test21c()
        {
            ConductLLToUTM_WGS84Test("test21");
        }

        [TestMethod]
        public void Test21d()
        {
            ConductUTM_WGS84ToLLTest("test21");
        }


        [TestMethod]
        public void Test22a()
        {
            ConductLLToUTM_NS_WGS84Test("test22");
        }

        [TestMethod]
        public void Test22b()
        {
            ConductUTM_NS_WGS84ToLLTest("test22");
        }

        [TestMethod]
        public void Test22c()
        {
            ConductLLToUTM_WGS84Test("test22");
        }

        [TestMethod]
        public void Test22d()
        {
            ConductUTM_WGS84ToLLTest("test22");
        }




        private void ConductLLToUTM_WGS84Test(string testName)
        {
            string inputFile = _inputFolder + "\\WGS84TranslationTests.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(inputFile);
            XmlNode testNode = doc.SelectSingleNode("//tests/test[@name='" + testName + "']");

            double lon = double.Parse(testNode.SelectSingleNode("ll").Attributes.GetNamedItem("lon").Value);
            double lat = double.Parse(testNode.SelectSingleNode("ll").Attributes.GetNamedItem("lat").Value);

            double x = 0.0;
            double y = 0.0;
            string zone = String.Empty;

            double expectedX = MathUtil.RoundTo(double.Parse(testNode.SelectSingleNode("utm").Attributes.GetNamedItem("x").Value), 2);
            double expectedY = MathUtil.RoundTo(double.Parse(testNode.SelectSingleNode("utm").Attributes.GetNamedItem("y").Value), 2);
            string expectedZone = testNode.SelectSingleNode("utm").Attributes.GetNamedItem("zone").Value;

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

            Assert.AreEqual(expectedX, x, "(x)");
            Assert.AreEqual(expectedY, y, "(y)");
            Assert.AreEqual(expectedZone, zone, "(zone)");
        }

        private void ConductUTM_WGS84ToLLTest(string testName)
        {
            string inputFile = _inputFolder + "\\WGS84TranslationTests.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(inputFile);
            XmlNode testNode = doc.SelectSingleNode("//tests/test[@name='" + testName + "']");

            double x = double.Parse(testNode.SelectSingleNode("utm").Attributes.GetNamedItem("x").Value);
            double y = double.Parse(testNode.SelectSingleNode("utm").Attributes.GetNamedItem("y").Value);
            string zone = testNode.SelectSingleNode("utm").Attributes.GetNamedItem("zone").Value;

            double lon = 0.0;
            double lat = 0.0;

            double expectedLon = double.Parse(testNode.SelectSingleNode("ll").Attributes.GetNamedItem("lon").Value);
            double expectedLat = double.Parse(testNode.SelectSingleNode("ll").Attributes.GetNamedItem("lat").Value);

            //GeoUtil.ConvertFromProjectedToGeographicCoordSys(typeof(UtmWgs84Ns), typeof(UsngWgs84), x, y, zone, ref lon, ref lat);
            IZone utmZone = new Zones.Utm.UtmZone(zone);
            IProjectedCoordinateSystem pcs = ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(CoordinateSystems.Projected.UtmWgs84), utmZone);
            IGeographicCoordinateSystem gcs = GeographicCoordinateSystemFactory.GetInstanceOfGeographicCoordinateSystem("GeodeticWgs84");
            ITranslationResult result = GeoUtil.Translate(pcs, gcs, x, y, 0);
            lat = result.yLat;
            lon = result.xLon;

            Assert.AreEqual(expectedLon, lon, "(xLon)");
            Assert.AreEqual(expectedLat, lat, "(yLat)");
        }




        private void ConductLLToUTM_NS_WGS84Test(string testName)
        {
            string inputFile = _inputFolder + "\\WGS84TranslationTests.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(inputFile);
            XmlNode testNode = doc.SelectSingleNode("//tests/test[@name='" + testName + "']");

            double lon = double.Parse(testNode.SelectSingleNode("ll").Attributes.GetNamedItem("lon").Value);
            double lat = double.Parse(testNode.SelectSingleNode("ll").Attributes.GetNamedItem("lat").Value);

            double x = 0.0;
            double y = 0.0;
            string zone = String.Empty;

            double expectedX = MathUtil.RoundTo(double.Parse(testNode.SelectSingleNode("utmns").Attributes.GetNamedItem("x").Value), 2);
            double expectedY = MathUtil.RoundTo(double.Parse(testNode.SelectSingleNode("utmns").Attributes.GetNamedItem("y").Value), 2);
            string expectedZone = testNode.SelectSingleNode("utmns").Attributes.GetNamedItem("zone").Value;

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

            Assert.AreEqual(expectedX, x, "(x)");
            Assert.AreEqual(expectedY, y, "(y)");
            Assert.AreEqual(expectedZone, zone, "(zone)");
        }

        private void ConductUTM_NS_WGS84ToLLTest(string testName)
        {
            string inputFile = _inputFolder + "\\WGS84TranslationTests.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(inputFile);
            XmlNode testNode = doc.SelectSingleNode("//tests/test[@name='" + testName + "']");

            double x = double.Parse(testNode.SelectSingleNode("utmns").Attributes.GetNamedItem("x").Value);
            double y = double.Parse(testNode.SelectSingleNode("utmns").Attributes.GetNamedItem("y").Value);
            string zone = testNode.SelectSingleNode("utmns").Attributes.GetNamedItem("zone").Value;

            double lon = 0.0;
            double lat = 0.0;

            double expectedLon = double.Parse(testNode.SelectSingleNode("ll").Attributes.GetNamedItem("lon").Value);
            double expectedLat = double.Parse(testNode.SelectSingleNode("ll").Attributes.GetNamedItem("lat").Value);

            //GeoUtil.ConvertFromProjectedToGeographicCoordSys(typeof(UtmWgs84Ns), typeof(UsngWgs84), x, y, zone, ref lon, ref lat);
            IZone utmZone = new Zones.UtmNs.UtmNsZone(zone);
            IProjectedCoordinateSystem pcs = ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(CoordinateSystems.Projected.UtmWgs84Ns), utmZone);
            IGeographicCoordinateSystem gcs = GeographicCoordinateSystemFactory.GetInstanceOfGeographicCoordinateSystem("GeodeticWgs84");
            ITranslationResult result = GeoUtil.Translate(pcs, gcs, x, y, 0);
            lat = result.yLat;
            lon = result.xLon;

            Assert.AreEqual(expectedLon, lon, "(xLon)");
            Assert.AreEqual(expectedLat, lat, "(yLat)");
        }
    }
}
