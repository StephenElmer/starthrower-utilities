// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarThrower.Gis.GeoUtilities.CoordinateSystems;
using StarThrower.Gis.GeoUtilities.CoordinateSystems.Geographic;
using StarThrower.Gis.GeoUtilities.Exceptions;

namespace StarThrower.Gis.GeoUtilities.Test
{
    [TestClass]
    public class CoordinateSystemTest
    {
        private static void Ignore()
        {
#if FAIL_ON_IGNORE
                Assert.Fail("This test has been ignored.");
#else
            Assert.Inconclusive("this test has been ignored");
#endif
        }

        #region Instantiation Tests

        [TestMethod]
        public void TestSingleInstanceOfNad27()
        {
            IGeographicCoordinateSystem c1 = GeographicCoordinateSystemFactory.GetInstanceOfGeographicCoordinateSystem(typeof(GeodeticNad27));
            IGeographicCoordinateSystem c2 = GeographicCoordinateSystemFactory.GetInstanceOfGeographicCoordinateSystem(typeof(GeodeticNad27));
            Assert.AreSame(c1, c2);
        }

        [TestMethod]
        public void TestSingleInstanceOfNad83()
        {
            IGeographicCoordinateSystem c1 = GeographicCoordinateSystemFactory.GetInstanceOfGeographicCoordinateSystem(typeof(GeodeticNad83));
            IGeographicCoordinateSystem c2 = GeographicCoordinateSystemFactory.GetInstanceOfGeographicCoordinateSystem(typeof(GeodeticNad83));
            Assert.AreSame(c1, c2);
        }

        [TestMethod]
        public void TestSingleInstanceOfWgs84()
        {
            IGeographicCoordinateSystem c1 = GeographicCoordinateSystemFactory.GetInstanceOfGeographicCoordinateSystem(typeof(GeodeticWgs84));
            IGeographicCoordinateSystem c2 = GeographicCoordinateSystemFactory.GetInstanceOfGeographicCoordinateSystem(typeof(GeodeticWgs84));
            Assert.AreSame(c1, c2);
        }

        [TestMethod, ExpectedException(typeof(InvalidCoordinateSystemException))]
        public void TestUndefinedThrowsException()
        {
            IGeographicCoordinateSystem c1 = GeographicCoordinateSystemFactory.GetInstanceOfGeographicCoordinateSystem(typeof(Undefined));
            Assert.Fail();
        }

        #endregion
    }
}


