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
using StarThrower.Gis.GeoUtilities;

namespace StarThrower.Gis.GeoUtilities.Test
{
    [TestClass]
    public class GeoUtilTest
    {
        private static void Ignore()
        {
#if FAIL_ON_IGNORE
                Assert.Fail("This test has been ignored.");
#else
            Assert.Inconclusive("this test has been ignored");
#endif
        }

        [TestMethod]
        public void TestIsValidLat()
        {
            Assert.IsTrue(GeoUtil.IsValidLat(0));
            Assert.IsTrue(GeoUtil.IsValidLat(0.0));
            Assert.IsTrue(GeoUtil.IsValidLat(0.000001));
            Assert.IsTrue(GeoUtil.IsValidLat(-0.000001));
            Assert.IsTrue(GeoUtil.IsValidLat(1));
            Assert.IsTrue(GeoUtil.IsValidLat(-1));
            Assert.IsTrue(GeoUtil.IsValidLat(GeoUtil.MaxLat));
            Assert.IsTrue(GeoUtil.IsValidLat(GeoUtil.MinLat));
            Assert.IsTrue(GeoUtil.IsValidLat(GeoUtil.MaxLat - 1));
            Assert.IsTrue(GeoUtil.IsValidLat(GeoUtil.MinLat + 1));
            Assert.IsTrue(GeoUtil.IsValidLat(GeoUtil.MaxLat - 0.000001));
            Assert.IsTrue(GeoUtil.IsValidLat(GeoUtil.MinLat + 0.000001));

            Assert.IsFalse(GeoUtil.IsValidLat(GeoUtil.MaxLat + 0.000001));
            Assert.IsFalse(GeoUtil.IsValidLat(GeoUtil.MinLat - 0.000001));
        }

        [TestMethod]
        public void TestIsValidLon()
        {
            Assert.IsTrue(GeoUtil.IsValidLon(0));
            Assert.IsTrue(GeoUtil.IsValidLon(0.0));
            Assert.IsTrue(GeoUtil.IsValidLon(0.000001));
            Assert.IsTrue(GeoUtil.IsValidLon(-0.000001));
            Assert.IsTrue(GeoUtil.IsValidLon(1));
            Assert.IsTrue(GeoUtil.IsValidLon(-1));
            Assert.IsTrue(GeoUtil.IsValidLon(GeoUtil.MaxLon));
            Assert.IsTrue(GeoUtil.IsValidLon(GeoUtil.MinLon));
            Assert.IsTrue(GeoUtil.IsValidLon(GeoUtil.MaxLon - 1));
            Assert.IsTrue(GeoUtil.IsValidLon(GeoUtil.MinLon + 1));
            Assert.IsTrue(GeoUtil.IsValidLon(GeoUtil.MaxLon - 0.000001));
            Assert.IsTrue(GeoUtil.IsValidLon(GeoUtil.MinLon + 0.000001));

            Assert.IsFalse(GeoUtil.IsValidLon(GeoUtil.MaxLon + 0.000001));
            Assert.IsFalse(GeoUtil.IsValidLon(GeoUtil.MinLon - 0.000001));
        }


        #region Original Tests

        //GeoCoordSys _wgs84LatLon;
        //GeoCoordSys _wgs84Utm;
        //GeoCoordSys _nad27LatLon;
        //GeoCoordSys _nad27Utm;

        //[SetUp]
        //public void MySetup()
        //{
        //    _wgs84LatLon = GeoCoordSysFactory.CreateGeoCoordSys(GeoCoordSysTypeConst.LatLon, DatumTypeConst.WGS84);
        //    _nad27LatLon = GeoCoordSysFactory.CreateGeoCoordSys(GeoCoordSysTypeConst.LatLon, DatumTypeConst.NAD27);
        //    _wgs84Utm = GeoCoordSysFactory.CreateGeoCoordSys(GeoCoordSysTypeConst.UTM, DatumTypeConst.WGS84);
        //    _nad27Utm = GeoCoordSysFactory.CreateGeoCoordSys(GeoCoordSysTypeConst.UTM, DatumTypeConst.NAD27);
        //}

        //[TearDown]
        //public void MyTearDown()
        //{
        //    _wgs84LatLon = null;
        //    _nad27LatLon = null;
        //    _wgs84Utm = null;
        //    _nad27Utm = null;
        //}



        #endregion
    }
}


