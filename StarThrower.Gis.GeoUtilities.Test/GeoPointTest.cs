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
using StarThrower.Gis.GeoUtilities.Exceptions;

namespace StarThrower.Gis.GeoUtilities.Test
{
    [TestClass]
    public class GeoPointTest
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
        public void TestConstruction()
        {
            GeoPoint p1 = new GeoPoint();
            GeoPoint p2 = new GeoPoint(1, 2);
            GeoPoint p3 = new GeoPoint(p2);

            Assert.IsNotNull(p1);
            Assert.IsNotNull(p2);
            Assert.IsNotNull(p3);

            Assert.AreEqual(p1.ToString(), "[GeoPoint:  x=0, y=0]");
            Assert.AreEqual(p2.ToString(), "[GeoPoint:  x=1, y=2]");
            Assert.AreEqual(p3.ToString(), "[GeoPoint:  x=1, y=2]");
            Assert.AreEqual(p2, p3);
            Assert.AreNotSame(p2, p3);
        }

        [TestMethod]
        public void TestClone()
        {
            GeoPoint p1 = new GeoPoint(1, 2);
            GeoPoint p2 = (GeoPoint)p1.Clone();

            Assert.AreEqual(p1, p2);
            Assert.AreNotSame(p1, p2);
        }

        [TestMethod]
        public void TestItemCopy()
        {
            GeoPoint p1 = new GeoPoint(1, 2);
            GeoPoint p2 = new GeoPoint();
            p2.ItemCopy(p1);

            Assert.AreEqual(p1, p2);
        }

        [TestMethod, ExpectedException(typeof(FailedItemCopyException))]
        public void TestItemCopyArgument()
        {
            GeoPoint p = new GeoPoint();
            System.Version sv = new System.Version("1.0.1.2");
            p.ItemCopy(sv);
            Assert.Fail();
        }

        [TestMethod]
        public void TestEquals()
        {
            GeoPoint p1 = new GeoPoint(1, 2);
            GeoPoint p2 = new GeoPoint(1, 2);
            GeoPoint p3 = new GeoPoint(2, 3);

            Assert.AreEqual(p1, p2);
            Assert.AreNotEqual(p1, p3);
            Assert.AreEqual(p1, p1);
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            GeoPoint p1 = new GeoPoint();
            GeoPoint p2 = new GeoPoint(1, 2);
            GeoPoint p3 = new GeoPoint(2, 3);

            Assert.AreEqual(p1.GetHashCode(), 31 * (31 * 17 + p1.xLon.GetHashCode()) + p1.yLat.GetHashCode());
            Assert.AreEqual(p2.GetHashCode(), 31 * (31 * 17 + p2.xLon.GetHashCode()) + p2.yLat.GetHashCode());
            Assert.AreEqual(p3.GetHashCode(), 31 * (31 * 17 + p3.xLon.GetHashCode()) + p3.yLat.GetHashCode());
        }

        [TestMethod]
        public void TestToString()
        {
            GeoPoint p1 = new GeoPoint();
            GeoPoint p2 = new GeoPoint(1, 2);
            GeoPoint p3 = new GeoPoint(p2);

            Assert.AreEqual(p1.ToString(), "[GeoPoint:  x=" + 0 + ", y=" + 0 + "]");
            Assert.AreEqual(p2.ToString(), "[GeoPoint:  x=" + 1 + ", y=" + 2 + "]");
            Assert.AreEqual(p3.ToString(), "[GeoPoint:  x=" + 1 + ", y=" + 2 + "]");
        }
    }
}


