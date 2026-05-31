/***********************************************************************************
    StarThrower Utilities / Gis.GeoUtilities
    Copyright (C) 2005-2026  Stephen Elmer

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
        private void Ignore()
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


