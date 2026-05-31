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
using UtmZones = StarThrower.Gis.GeoUtilities.Zones.Utm;
using UtmNsZones = StarThrower.Gis.GeoUtilities.Zones.UtmNs;

namespace StarThrower.Gis.GeoUtilities.Test
{
    [TestClass]
    public class CsUtilTest
    {
        private void Ignore()
        {
#if FAIL_ON_IGNORE
                Assert.Fail("This test has been ignored.");
#else
            Assert.Inconclusive("this test has been ignored");
#endif
        }

        [TestMethod]
        public void TestGetCentralMeridianForZone()
        {
            Assert.AreEqual(-177.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm01, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(-171.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm02, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(-165.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm03, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(-159.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm04, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(-153.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm05, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(-147.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm06, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(-141.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm07, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(-135.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm08, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(-129.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm09, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(-123.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm10, UtmNsZones.LatitudinalZone.North).CentralMeridian);

            Assert.AreEqual(-117.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm11, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(-111.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm12, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(-105.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm13, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(-99.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm14, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(-93.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm15, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(-87.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm16, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(-81.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm17, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(-75.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm18, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(-69.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm19, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(-63.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm20, UtmNsZones.LatitudinalZone.North).CentralMeridian);

            Assert.AreEqual(-57.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm21, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(-51.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm22, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(-45.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm23, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(-39.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm24, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(-33.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm25, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(-27.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm26, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(-21.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm27, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(-15.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm28, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(-9.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm29, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(-3.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm30, UtmNsZones.LatitudinalZone.North).CentralMeridian);

            Assert.AreEqual(3.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm31, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(3.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm31, UtmZones.LatitudinalZone.UtmN).CentralMeridian);
            //Assert.AreEqual(4.5, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm31, UtmZones.LatitudinalZone.UtmX).CentralMeridian);
            Assert.AreEqual(3.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm31, UtmZones.LatitudinalZone.UtmX).CentralMeridian);
            //Assert.AreEqual(1.5, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm31, UtmZones.LatitudinalZone.UtmV).CentralMeridian);
            Assert.AreEqual(3.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm31, UtmZones.LatitudinalZone.UtmV).CentralMeridian);

            Assert.AreEqual(9.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm32, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(9.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm32, UtmZones.LatitudinalZone.UtmN).CentralMeridian);
            //Assert.AreEqual(7.5, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm32, UtmZones.LatitudinalZone.UtmV).CentralMeridian);
            Assert.AreEqual(9.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm32, UtmZones.LatitudinalZone.UtmV).CentralMeridian);

            Assert.AreEqual(15.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm33, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(15.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm33, UtmZones.LatitudinalZone.UtmN).CentralMeridian);
            Assert.AreEqual(15.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm33, UtmZones.LatitudinalZone.UtmX).CentralMeridian);

            Assert.AreEqual(21.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm34, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(21.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm34, UtmZones.LatitudinalZone.UtmN).CentralMeridian);

            Assert.AreEqual(27.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm35, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(27.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm35, UtmZones.LatitudinalZone.UtmN).CentralMeridian);
            Assert.AreEqual(27.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm35, UtmZones.LatitudinalZone.UtmX).CentralMeridian);

            Assert.AreEqual(33.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm36, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(33.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm36, UtmZones.LatitudinalZone.UtmN).CentralMeridian);

            Assert.AreEqual(39.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm37, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(39.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm37, UtmZones.LatitudinalZone.UtmN).CentralMeridian);
            //Assert.AreEqual(37.5, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm37, UtmZones.LatitudinalZone.UtmX).CentralMeridian);
            Assert.AreEqual(39.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm37, UtmZones.LatitudinalZone.UtmX).CentralMeridian);

            Assert.AreEqual(45.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm38, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(45.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm38, UtmZones.LatitudinalZone.UtmN).CentralMeridian);
            Assert.AreEqual(51.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm39, UtmZones.LatitudinalZone.UtmN).CentralMeridian);
            Assert.AreEqual(57.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm40, UtmZones.LatitudinalZone.UtmN).CentralMeridian);

            Assert.AreEqual(63.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm41, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(69.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm42, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(75.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm43, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(81.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm44, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(87.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm45, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(93.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm46, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(99.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm47, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(105.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm48, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(111.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm49, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(117.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm50, UtmNsZones.LatitudinalZone.North).CentralMeridian);

            Assert.AreEqual(123.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm51, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(129.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm52, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(135.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm53, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(141.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm54, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(147.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm55, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(153.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm56, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(159.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm57, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(165.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm58, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(171.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm59, UtmNsZones.LatitudinalZone.North).CentralMeridian);
            Assert.AreEqual(177.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm60, UtmNsZones.LatitudinalZone.North).CentralMeridian);
        }

        [TestMethod]
        public void TestGetGeometricCenterForZone()
        {
            Assert.AreEqual(-177.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm01, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(-171.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm02, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(-165.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm03, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(-159.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm04, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(-153.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm05, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(-147.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm06, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(-141.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm07, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(-135.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm08, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(-129.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm09, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(-123.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm10, UtmNsZones.LatitudinalZone.North).GeometricCenter);

            Assert.AreEqual(-117.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm11, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(-111.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm12, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(-105.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm13, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(-99.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm14, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(-93.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm15, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(-87.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm16, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(-81.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm17, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(-75.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm18, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(-69.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm19, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(-63.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm20, UtmNsZones.LatitudinalZone.North).GeometricCenter);

            Assert.AreEqual(-57.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm21, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(-51.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm22, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(-45.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm23, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(-39.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm24, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(-33.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm25, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(-27.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm26, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(-21.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm27, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(-15.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm28, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(-9.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm29, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(-3.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm30, UtmNsZones.LatitudinalZone.North).GeometricCenter);

            Assert.AreEqual(3.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm31, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(3.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm31, UtmZones.LatitudinalZone.UtmN).GeometricCenter);
            Assert.AreEqual(4.5, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm31, UtmZones.LatitudinalZone.UtmX).GeometricCenter);
            //Assert.AreEqual(3.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm31, UtmZones.LatitudinalZone.UtmX).GeometricCenter);
            Assert.AreEqual(1.5, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm31, UtmZones.LatitudinalZone.UtmV).GeometricCenter);
            //Assert.AreEqual(3.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm31, UtmZones.LatitudinalZone.UtmV).GeometricCenter);

            Assert.AreEqual(9.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm32, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(9.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm32, UtmZones.LatitudinalZone.UtmN).GeometricCenter);
            Assert.AreEqual(7.5, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm32, UtmZones.LatitudinalZone.UtmV).GeometricCenter);
            //Assert.AreEqual(9.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm32, UtmZones.LatitudinalZone.UtmV).GeometricCenter);

            Assert.AreEqual(15.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm33, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(15.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm33, UtmZones.LatitudinalZone.UtmN).GeometricCenter);
            Assert.AreEqual(15.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm33, UtmZones.LatitudinalZone.UtmX).GeometricCenter);

            Assert.AreEqual(21.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm34, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(21.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm34, UtmZones.LatitudinalZone.UtmN).GeometricCenter);

            Assert.AreEqual(27.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm35, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(27.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm35, UtmZones.LatitudinalZone.UtmN).GeometricCenter);
            Assert.AreEqual(27.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm35, UtmZones.LatitudinalZone.UtmX).GeometricCenter);

            Assert.AreEqual(33.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm36, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(33.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm36, UtmZones.LatitudinalZone.UtmN).GeometricCenter);

            Assert.AreEqual(39.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm37, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(39.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm37, UtmZones.LatitudinalZone.UtmN).GeometricCenter);
            Assert.AreEqual(37.5, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm37, UtmZones.LatitudinalZone.UtmX).GeometricCenter);
            //Assert.AreEqual(39.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm37, UtmZones.LatitudinalZone.UtmX).GeometricCenter);

            Assert.AreEqual(45.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm38, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(45.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm38, UtmZones.LatitudinalZone.UtmN).GeometricCenter);
            Assert.AreEqual(51.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm39, UtmZones.LatitudinalZone.UtmN).GeometricCenter);
            Assert.AreEqual(57.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm40, UtmZones.LatitudinalZone.UtmN).GeometricCenter);

            Assert.AreEqual(63.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm41, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(69.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm42, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(75.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm43, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(81.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm44, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(87.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm45, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(93.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm46, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(99.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm47, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(105.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm48, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(111.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm49, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(117.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm50, UtmNsZones.LatitudinalZone.North).GeometricCenter);

            Assert.AreEqual(123.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm51, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(129.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm52, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(135.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm53, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(141.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm54, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(147.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm55, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(153.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm56, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(159.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm57, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(165.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm58, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(171.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm59, UtmNsZones.LatitudinalZone.North).GeometricCenter);
            Assert.AreEqual(177.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm60, UtmNsZones.LatitudinalZone.North).GeometricCenter);
        }

        [TestMethod]
        public void TestGetReferenceLatitudeForZone()
        {
            Assert.AreEqual(0.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm01, UtmNsZones.LatitudinalZone.North).ReferenceLatitude);
            Assert.AreEqual(0.0, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm01, UtmNsZones.LatitudinalZone.South).ReferenceLatitude);

            Assert.AreEqual(-76.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmC).ReferenceLatitude);
            Assert.AreEqual(-68.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmD).ReferenceLatitude);
            Assert.AreEqual(-60.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmE).ReferenceLatitude);
            Assert.AreEqual(-52.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmF).ReferenceLatitude);
            Assert.AreEqual(-44.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmG).ReferenceLatitude);
            Assert.AreEqual(-36.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmH).ReferenceLatitude);
            Assert.AreEqual(-28.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmJ).ReferenceLatitude);
            Assert.AreEqual(-20.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmK).ReferenceLatitude);
            Assert.AreEqual(-12.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmL).ReferenceLatitude);
            Assert.AreEqual(-4.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmM).ReferenceLatitude);
            Assert.AreEqual(4.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmN).ReferenceLatitude);
            Assert.AreEqual(12.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmP).ReferenceLatitude);
            Assert.AreEqual(20.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmQ).ReferenceLatitude);
            Assert.AreEqual(28.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmR).ReferenceLatitude);
            Assert.AreEqual(36.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmS).ReferenceLatitude);
            Assert.AreEqual(44.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmT).ReferenceLatitude);
            Assert.AreEqual(52.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmU).ReferenceLatitude);
            Assert.AreEqual(60.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmV).ReferenceLatitude);
            Assert.AreEqual(68.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmW).ReferenceLatitude);
            Assert.AreEqual(80.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmX).ReferenceLatitude);
        }

        [TestMethod]
        public void TestIsSouthernHemisphere()
        {
            Assert.AreEqual(true, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm01, UtmNsZones.LatitudinalZone.South).IsSouthernHemisphere);
            Assert.AreEqual(true, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmA).IsSouthernHemisphere);
            Assert.AreEqual(true, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmB).IsSouthernHemisphere);
            Assert.AreEqual(true, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmC).IsSouthernHemisphere);
            Assert.AreEqual(true, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmD).IsSouthernHemisphere);
            Assert.AreEqual(true, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmE).IsSouthernHemisphere);
            Assert.AreEqual(true, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmF).IsSouthernHemisphere);
            Assert.AreEqual(true, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmG).IsSouthernHemisphere);
            Assert.AreEqual(true, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmH).IsSouthernHemisphere);
            Assert.AreEqual(true, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmJ).IsSouthernHemisphere);
            Assert.AreEqual(true, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmK).IsSouthernHemisphere);
            Assert.AreEqual(true, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmL).IsSouthernHemisphere);
            Assert.AreEqual(true, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmM).IsSouthernHemisphere);

            Assert.AreEqual(false, new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm01, UtmNsZones.LatitudinalZone.North).IsSouthernHemisphere);
            Assert.AreEqual(false, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmN).IsSouthernHemisphere);
            Assert.AreEqual(false, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmP).IsSouthernHemisphere);
            Assert.AreEqual(false, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmQ).IsSouthernHemisphere);
            Assert.AreEqual(false, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmR).IsSouthernHemisphere);
            Assert.AreEqual(false, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmS).IsSouthernHemisphere);
            Assert.AreEqual(false, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmT).IsSouthernHemisphere);
            Assert.AreEqual(false, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmU).IsSouthernHemisphere);
            Assert.AreEqual(false, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmV).IsSouthernHemisphere);
            Assert.AreEqual(false, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmW).IsSouthernHemisphere);
            Assert.AreEqual(false, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmX).IsSouthernHemisphere);
            Assert.AreEqual(false, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmY).IsSouthernHemisphere);
            Assert.AreEqual(false, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmZ).IsSouthernHemisphere);
        }

        [TestMethod]
        public void TestGetZoneString()
        {
            Assert.AreEqual("1A", new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmA).ZoneString);
            Assert.AreEqual("1North", new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm01, UtmNsZones.LatitudinalZone.North).ZoneString);
            Assert.AreEqual("1South", new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm01, UtmNsZones.LatitudinalZone.South).ZoneString);
        }

        [TestMethod, ExpectedException(typeof(NotSupportedException))]
        public void TestBadGetCentralMeridianForZone1()
        {
            double lon = new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm32, UtmZones.LatitudinalZone.UtmX).CentralMeridian;
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(NotSupportedException))]
        public void TestBadGetCentralMeridianForZone2()
        {
            double lon = new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm34, UtmZones.LatitudinalZone.UtmX).CentralMeridian;
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(NotSupportedException))]
        public void TestBadGetCentralMeridianForZone3()
        {
            double lon = new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm36, UtmZones.LatitudinalZone.UtmX).CentralMeridian;
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(NotImplementedException))]
        public void TestBadGetReferenceLatitudeForZone1()
        {
            double lat = new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmA).ReferenceLatitude;
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(NotImplementedException))]
        public void TestBadGetReferenceLatitudeForZone2()
        {
            double lat = new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmB).ReferenceLatitude;
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(NotImplementedException))]
        public void TestBadGetReferenceLatitudeForZone3()
        {
            double lat = new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmY).ReferenceLatitude;
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(NotImplementedException))]
        public void TestBadGetReferenceLatitudeForZone4()
        {
            double lat = new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmZ).ReferenceLatitude;
            Assert.Fail();
        }

        [TestMethod]
        public void TestGetLongitudinalZoneForLongitude()
        {
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm01, new UtmZones.UtmZone(180.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm01, new UtmZones.UtmZone(-180.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm01, new UtmZones.UtmZone(-174.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm02, new UtmZones.UtmZone(-174.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm02, new UtmZones.UtmZone(-168.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm03, new UtmZones.UtmZone(-168.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm03, new UtmZones.UtmZone(-162.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm04, new UtmZones.UtmZone(-162.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm04, new UtmZones.UtmZone(-156.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm05, new UtmZones.UtmZone(-156.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm05, new UtmZones.UtmZone(-150.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm06, new UtmZones.UtmZone(-150.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm06, new UtmZones.UtmZone(-144.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm07, new UtmZones.UtmZone(-144.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm07, new UtmZones.UtmZone(-138.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm08, new UtmZones.UtmZone(-138.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm08, new UtmZones.UtmZone(-132.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm09, new UtmZones.UtmZone(-132.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm09, new UtmZones.UtmZone(-126.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm10, new UtmZones.UtmZone(-126.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm10, new UtmZones.UtmZone(-120.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm11, new UtmZones.UtmZone(-120.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm11, new UtmZones.UtmZone(-114.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm12, new UtmZones.UtmZone(-114.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm12, new UtmZones.UtmZone(-108.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm13, new UtmZones.UtmZone(-108.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm13, new UtmZones.UtmZone(-102.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm14, new UtmZones.UtmZone(-102.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm14, new UtmZones.UtmZone(-96.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm15, new UtmZones.UtmZone(-96.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm15, new UtmZones.UtmZone(-90.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm16, new UtmZones.UtmZone(-90.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm16, new UtmZones.UtmZone(-84.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm17, new UtmZones.UtmZone(-84.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm17, new UtmZones.UtmZone(-78.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm18, new UtmZones.UtmZone(-78.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm18, new UtmZones.UtmZone(-72.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm19, new UtmZones.UtmZone(-72.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm19, new UtmZones.UtmZone(-66.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm20, new UtmZones.UtmZone(-66.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm20, new UtmZones.UtmZone(-60.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm21, new UtmZones.UtmZone(-60.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm21, new UtmZones.UtmZone(-54.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm22, new UtmZones.UtmZone(-54.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm22, new UtmZones.UtmZone(-48.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm23, new UtmZones.UtmZone(-48.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm23, new UtmZones.UtmZone(-42.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm24, new UtmZones.UtmZone(-42.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm24, new UtmZones.UtmZone(-36.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm25, new UtmZones.UtmZone(-36.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm25, new UtmZones.UtmZone(-30.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm26, new UtmZones.UtmZone(-30.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm26, new UtmZones.UtmZone(-24.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm27, new UtmZones.UtmZone(-24.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm27, new UtmZones.UtmZone(-18.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm28, new UtmZones.UtmZone(-18.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm28, new UtmZones.UtmZone(-12.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm29, new UtmZones.UtmZone(-12.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm29, new UtmZones.UtmZone(-6.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm30, new UtmZones.UtmZone(-6.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm30, new UtmZones.UtmZone(-0.01, 0.0).LongitudinalZone);

            //--zero--

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm31, new UtmZones.UtmZone(0.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm31, new UtmZones.UtmZone(5.9, 0.0).LongitudinalZone);


            //TODO: Need to fix this up to allow for the anomolies at 31X, 33X, 35X, 37X, 31V, & 32V


            Assert.AreEqual(UtmZones.LongitudinalZone.Utm32, new UtmZones.UtmZone(6.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm32, new UtmZones.UtmZone(11.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm33, new UtmZones.UtmZone(12.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm33, new UtmZones.UtmZone(17.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm34, new UtmZones.UtmZone(18.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm34, new UtmZones.UtmZone(23.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm35, new UtmZones.UtmZone(24.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm35, new UtmZones.UtmZone(29.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm36, new UtmZones.UtmZone(30.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm36, new UtmZones.UtmZone(35.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm37, new UtmZones.UtmZone(36.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm37, new UtmZones.UtmZone(41.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm38, new UtmZones.UtmZone(42.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm38, new UtmZones.UtmZone(47.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm39, new UtmZones.UtmZone(48.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm39, new UtmZones.UtmZone(53.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm40, new UtmZones.UtmZone(54.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm40, new UtmZones.UtmZone(59.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm41, new UtmZones.UtmZone(60.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm41, new UtmZones.UtmZone(65.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm42, new UtmZones.UtmZone(66.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm42, new UtmZones.UtmZone(71.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm43, new UtmZones.UtmZone(72.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm43, new UtmZones.UtmZone(77.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm44, new UtmZones.UtmZone(78.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm44, new UtmZones.UtmZone(83.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm45, new UtmZones.UtmZone(84.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm45, new UtmZones.UtmZone(89.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm46, new UtmZones.UtmZone(90.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm46, new UtmZones.UtmZone(95.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm47, new UtmZones.UtmZone(96.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm47, new UtmZones.UtmZone(101.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm48, new UtmZones.UtmZone(102.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm48, new UtmZones.UtmZone(107.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm49, new UtmZones.UtmZone(108.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm49, new UtmZones.UtmZone(113.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm50, new UtmZones.UtmZone(114.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm50, new UtmZones.UtmZone(119.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm51, new UtmZones.UtmZone(120.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm51, new UtmZones.UtmZone(125.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm52, new UtmZones.UtmZone(126.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm52, new UtmZones.UtmZone(131.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm53, new UtmZones.UtmZone(132.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm53, new UtmZones.UtmZone(137.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm54, new UtmZones.UtmZone(138.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm54, new UtmZones.UtmZone(143.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm55, new UtmZones.UtmZone(144.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm55, new UtmZones.UtmZone(149.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm56, new UtmZones.UtmZone(150.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm56, new UtmZones.UtmZone(155.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm57, new UtmZones.UtmZone(156.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm57, new UtmZones.UtmZone(161.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm58, new UtmZones.UtmZone(162.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm58, new UtmZones.UtmZone(167.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm59, new UtmZones.UtmZone(168.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm59, new UtmZones.UtmZone(173.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm60, new UtmZones.UtmZone(174.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm60, new UtmZones.UtmZone(179.9, 0.0).LongitudinalZone);
        }

        [TestMethod]
        public void TestGetLongitudinalNSZoneForLongitude()
        {
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm01, new UtmNsZones.UtmNsZone(180.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm01, new UtmNsZones.UtmNsZone(-180.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm01, new UtmNsZones.UtmNsZone(-174.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm02, new UtmNsZones.UtmNsZone(-174.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm02, new UtmNsZones.UtmNsZone(-168.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm03, new UtmNsZones.UtmNsZone(-168.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm03, new UtmNsZones.UtmNsZone(-162.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm04, new UtmNsZones.UtmNsZone(-162.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm04, new UtmNsZones.UtmNsZone(-156.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm05, new UtmNsZones.UtmNsZone(-156.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm05, new UtmNsZones.UtmNsZone(-150.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm06, new UtmNsZones.UtmNsZone(-150.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm06, new UtmNsZones.UtmNsZone(-144.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm07, new UtmNsZones.UtmNsZone(-144.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm07, new UtmNsZones.UtmNsZone(-138.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm08, new UtmNsZones.UtmNsZone(-138.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm08, new UtmNsZones.UtmNsZone(-132.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm09, new UtmNsZones.UtmNsZone(-132.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm09, new UtmNsZones.UtmNsZone(-126.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm10, new UtmNsZones.UtmNsZone(-126.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm10, new UtmNsZones.UtmNsZone(-120.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm11, new UtmNsZones.UtmNsZone(-120.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm11, new UtmNsZones.UtmNsZone(-114.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm12, new UtmNsZones.UtmNsZone(-114.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm12, new UtmNsZones.UtmNsZone(-108.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm13, new UtmNsZones.UtmNsZone(-108.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm13, new UtmNsZones.UtmNsZone(-102.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm14, new UtmNsZones.UtmNsZone(-102.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm14, new UtmNsZones.UtmNsZone(-96.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm15, new UtmNsZones.UtmNsZone(-96.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm15, new UtmNsZones.UtmNsZone(-90.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm16, new UtmNsZones.UtmNsZone(-90.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm16, new UtmNsZones.UtmNsZone(-84.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm17, new UtmNsZones.UtmNsZone(-84.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm17, new UtmNsZones.UtmNsZone(-78.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm18, new UtmNsZones.UtmNsZone(-78.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm18, new UtmNsZones.UtmNsZone(-72.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm19, new UtmNsZones.UtmNsZone(-72.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm19, new UtmNsZones.UtmNsZone(-66.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm20, new UtmNsZones.UtmNsZone(-66.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm20, new UtmNsZones.UtmNsZone(-60.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm21, new UtmNsZones.UtmNsZone(-60.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm21, new UtmNsZones.UtmNsZone(-54.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm22, new UtmNsZones.UtmNsZone(-54.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm22, new UtmNsZones.UtmNsZone(-48.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm23, new UtmNsZones.UtmNsZone(-48.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm23, new UtmNsZones.UtmNsZone(-42.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm24, new UtmNsZones.UtmNsZone(-42.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm24, new UtmNsZones.UtmNsZone(-36.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm25, new UtmNsZones.UtmNsZone(-36.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm25, new UtmNsZones.UtmNsZone(-30.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm26, new UtmNsZones.UtmNsZone(-30.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm26, new UtmNsZones.UtmNsZone(-24.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm27, new UtmNsZones.UtmNsZone(-24.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm27, new UtmNsZones.UtmNsZone(-18.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm28, new UtmNsZones.UtmNsZone(-18.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm28, new UtmNsZones.UtmNsZone(-12.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm29, new UtmNsZones.UtmNsZone(-12.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm29, new UtmNsZones.UtmNsZone(-6.01, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm30, new UtmNsZones.UtmNsZone(-6.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm30, new UtmNsZones.UtmNsZone(-0.01, 0.0).LongitudinalZone);

            //--zero--

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm31, new UtmNsZones.UtmNsZone(0.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm31, new UtmNsZones.UtmNsZone(5.9, 0.0).LongitudinalZone);


            //TODO: Need to fix this up to allow for the anomolies at 31X, 33X, 35X, 37X, 31V, & 32V


            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm32, new UtmNsZones.UtmNsZone(6.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm32, new UtmNsZones.UtmNsZone(11.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm33, new UtmNsZones.UtmNsZone(12.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm33, new UtmNsZones.UtmNsZone(17.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm34, new UtmNsZones.UtmNsZone(18.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm34, new UtmNsZones.UtmNsZone(23.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm35, new UtmNsZones.UtmNsZone(24.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm35, new UtmNsZones.UtmNsZone(29.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm36, new UtmNsZones.UtmNsZone(30.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm36, new UtmNsZones.UtmNsZone(35.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm37, new UtmNsZones.UtmNsZone(36.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm37, new UtmNsZones.UtmNsZone(41.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm38, new UtmNsZones.UtmNsZone(42.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm38, new UtmNsZones.UtmNsZone(47.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm39, new UtmNsZones.UtmNsZone(48.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm39, new UtmNsZones.UtmNsZone(53.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm40, new UtmNsZones.UtmNsZone(54.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm40, new UtmNsZones.UtmNsZone(59.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm41, new UtmNsZones.UtmNsZone(60.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm41, new UtmNsZones.UtmNsZone(65.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm42, new UtmNsZones.UtmNsZone(66.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm42, new UtmNsZones.UtmNsZone(71.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm43, new UtmNsZones.UtmNsZone(72.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm43, new UtmNsZones.UtmNsZone(77.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm44, new UtmNsZones.UtmNsZone(78.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm44, new UtmNsZones.UtmNsZone(83.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm45, new UtmNsZones.UtmNsZone(84.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm45, new UtmNsZones.UtmNsZone(89.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm46, new UtmNsZones.UtmNsZone(90.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm46, new UtmNsZones.UtmNsZone(95.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm47, new UtmNsZones.UtmNsZone(96.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm47, new UtmNsZones.UtmNsZone(101.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm48, new UtmNsZones.UtmNsZone(102.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm48, new UtmNsZones.UtmNsZone(107.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm49, new UtmNsZones.UtmNsZone(108.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm49, new UtmNsZones.UtmNsZone(113.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm50, new UtmNsZones.UtmNsZone(114.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm50, new UtmNsZones.UtmNsZone(119.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm51, new UtmNsZones.UtmNsZone(120.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm51, new UtmNsZones.UtmNsZone(125.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm52, new UtmNsZones.UtmNsZone(126.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm52, new UtmNsZones.UtmNsZone(131.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm53, new UtmNsZones.UtmNsZone(132.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm53, new UtmNsZones.UtmNsZone(137.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm54, new UtmNsZones.UtmNsZone(138.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm54, new UtmNsZones.UtmNsZone(143.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm55, new UtmNsZones.UtmNsZone(144.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm55, new UtmNsZones.UtmNsZone(149.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm56, new UtmNsZones.UtmNsZone(150.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm56, new UtmNsZones.UtmNsZone(155.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm57, new UtmNsZones.UtmNsZone(156.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm57, new UtmNsZones.UtmNsZone(161.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm58, new UtmNsZones.UtmNsZone(162.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm58, new UtmNsZones.UtmNsZone(167.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm59, new UtmNsZones.UtmNsZone(168.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm59, new UtmNsZones.UtmNsZone(173.9, 0.0).LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm60, new UtmNsZones.UtmNsZone(174.0, 0.0).LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm60, new UtmNsZones.UtmNsZone(179.9, 0.0).LongitudinalZone);
        }

        [TestMethod]
        public void TestGetLatitudinalZoneForLatitude()
        {
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmC, new UtmZones.UtmZone(0.0, -80.0).LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmC, new UtmZones.UtmZone(0.0, -72.01).LatitudinalZone);

            Assert.AreEqual(UtmZones.LatitudinalZone.UtmD, new UtmZones.UtmZone(0.0, -72.0).LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmD, new UtmZones.UtmZone(0.0, -64.01).LatitudinalZone);

            Assert.AreEqual(UtmZones.LatitudinalZone.UtmE, new UtmZones.UtmZone(0.0, -64.0).LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmE, new UtmZones.UtmZone(0.0, -56.01).LatitudinalZone);

            Assert.AreEqual(UtmZones.LatitudinalZone.UtmF, new UtmZones.UtmZone(0.0, -56.0).LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmF, new UtmZones.UtmZone(0.0, -48.01).LatitudinalZone);

            Assert.AreEqual(UtmZones.LatitudinalZone.UtmG, new UtmZones.UtmZone(0.0, -48.0).LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmG, new UtmZones.UtmZone(0.0, -40.01).LatitudinalZone);

            Assert.AreEqual(UtmZones.LatitudinalZone.UtmH, new UtmZones.UtmZone(0.0, -40.0).LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmH, new UtmZones.UtmZone(0.0, -32.01).LatitudinalZone);

            Assert.AreEqual(UtmZones.LatitudinalZone.UtmJ, new UtmZones.UtmZone(0.0, -32.0).LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmJ, new UtmZones.UtmZone(0.0, -24.01).LatitudinalZone);

            Assert.AreEqual(UtmZones.LatitudinalZone.UtmK, new UtmZones.UtmZone(0.0, -24.0).LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmK, new UtmZones.UtmZone(0.0, -16.01).LatitudinalZone);

            Assert.AreEqual(UtmZones.LatitudinalZone.UtmL, new UtmZones.UtmZone(0.0, -16.0).LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmL, new UtmZones.UtmZone(0.0, -8.01).LatitudinalZone);

            Assert.AreEqual(UtmZones.LatitudinalZone.UtmM, new UtmZones.UtmZone(0.0, -8.0).LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmM, new UtmZones.UtmZone(0.0, -0.01).LatitudinalZone);

            Assert.AreEqual(UtmZones.LatitudinalZone.UtmN, new UtmZones.UtmZone(0.0, 0.0).LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmN, new UtmZones.UtmZone(0.0, 7.99).LatitudinalZone);

            Assert.AreEqual(UtmZones.LatitudinalZone.UtmP, new UtmZones.UtmZone(0.0, 8.0).LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmP, new UtmZones.UtmZone(0.0, 15.99).LatitudinalZone);

            Assert.AreEqual(UtmZones.LatitudinalZone.UtmQ, new UtmZones.UtmZone(0.0, 16.0).LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmQ, new UtmZones.UtmZone(0.0, 23.99).LatitudinalZone);

            Assert.AreEqual(UtmZones.LatitudinalZone.UtmR, new UtmZones.UtmZone(0.0, 24.0).LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmR, new UtmZones.UtmZone(0.0, 31.99).LatitudinalZone);

            Assert.AreEqual(UtmZones.LatitudinalZone.UtmS, new UtmZones.UtmZone(0.0, 32.0).LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmS, new UtmZones.UtmZone(0.0, 39.99).LatitudinalZone);

            Assert.AreEqual(UtmZones.LatitudinalZone.UtmT, new UtmZones.UtmZone(0.0, 40.0).LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmT, new UtmZones.UtmZone(0.0, 47.99).LatitudinalZone);

            Assert.AreEqual(UtmZones.LatitudinalZone.UtmU, new UtmZones.UtmZone(0.0, 48.0).LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmU, new UtmZones.UtmZone(0.0, 55.99).LatitudinalZone);

            Assert.AreEqual(UtmZones.LatitudinalZone.UtmV, new UtmZones.UtmZone(0.0, 56).LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmV, new UtmZones.UtmZone(0.0, 63.99).LatitudinalZone);

            Assert.AreEqual(UtmZones.LatitudinalZone.UtmW, new UtmZones.UtmZone(0.0, 64.0).LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmW, new UtmZones.UtmZone(0.0, 71.99).LatitudinalZone);

            Assert.AreEqual(UtmZones.LatitudinalZone.UtmX, new UtmZones.UtmZone(0.0, 72.0).LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmX, new UtmZones.UtmZone(0.0, 84.0).LatitudinalZone);
        }

        [TestMethod]
        public void TestGetLatitudinalNSZoneForLatitude()
        {
            Assert.AreEqual(UtmNsZones.LatitudinalZone.South, new UtmNsZones.UtmNsZone(0.0, -80.0).LatitudinalZone);
            Assert.AreEqual(UtmNsZones.LatitudinalZone.South, new UtmNsZones.UtmNsZone(0.0, -72.01).LatitudinalZone);

            Assert.AreEqual(UtmNsZones.LatitudinalZone.South, new UtmNsZones.UtmNsZone(0.0, -72.0).LatitudinalZone);
            Assert.AreEqual(UtmNsZones.LatitudinalZone.South, new UtmNsZones.UtmNsZone(0.0, -64.01).LatitudinalZone);

            Assert.AreEqual(UtmNsZones.LatitudinalZone.South, new UtmNsZones.UtmNsZone(0.0, -64.0).LatitudinalZone);
            Assert.AreEqual(UtmNsZones.LatitudinalZone.South, new UtmNsZones.UtmNsZone(0.0, -56.01).LatitudinalZone);

            Assert.AreEqual(UtmNsZones.LatitudinalZone.South, new UtmNsZones.UtmNsZone(0.0, -56.0).LatitudinalZone);
            Assert.AreEqual(UtmNsZones.LatitudinalZone.South, new UtmNsZones.UtmNsZone(0.0, -48.01).LatitudinalZone);

            Assert.AreEqual(UtmNsZones.LatitudinalZone.South, new UtmNsZones.UtmNsZone(0.0, -48.0).LatitudinalZone);
            Assert.AreEqual(UtmNsZones.LatitudinalZone.South, new UtmNsZones.UtmNsZone(0.0, -40.01).LatitudinalZone);

            Assert.AreEqual(UtmNsZones.LatitudinalZone.South, new UtmNsZones.UtmNsZone(0.0, -40.0).LatitudinalZone);
            Assert.AreEqual(UtmNsZones.LatitudinalZone.South, new UtmNsZones.UtmNsZone(0.0, -32.01).LatitudinalZone);

            Assert.AreEqual(UtmNsZones.LatitudinalZone.South, new UtmNsZones.UtmNsZone(0.0, -32.0).LatitudinalZone);
            Assert.AreEqual(UtmNsZones.LatitudinalZone.South, new UtmNsZones.UtmNsZone(0.0, -24.01).LatitudinalZone);

            Assert.AreEqual(UtmNsZones.LatitudinalZone.South, new UtmNsZones.UtmNsZone(0.0, -24.0).LatitudinalZone);
            Assert.AreEqual(UtmNsZones.LatitudinalZone.South, new UtmNsZones.UtmNsZone(0.0, -16.01).LatitudinalZone);

            Assert.AreEqual(UtmNsZones.LatitudinalZone.South, new UtmNsZones.UtmNsZone(0.0, -16.0).LatitudinalZone);
            Assert.AreEqual(UtmNsZones.LatitudinalZone.South, new UtmNsZones.UtmNsZone(0.0, -8.01).LatitudinalZone);

            Assert.AreEqual(UtmNsZones.LatitudinalZone.South, new UtmNsZones.UtmNsZone(0.0, -8.0).LatitudinalZone);
            Assert.AreEqual(UtmNsZones.LatitudinalZone.South, new UtmNsZones.UtmNsZone(0.0, -0.01).LatitudinalZone);

            Assert.AreEqual(UtmNsZones.LatitudinalZone.North, new UtmNsZones.UtmNsZone(0.0, 0.0).LatitudinalZone);
            Assert.AreEqual(UtmNsZones.LatitudinalZone.North, new UtmNsZones.UtmNsZone(0.0, 7.99).LatitudinalZone);

            Assert.AreEqual(UtmNsZones.LatitudinalZone.North, new UtmNsZones.UtmNsZone(0.0, 8.0).LatitudinalZone);
            Assert.AreEqual(UtmNsZones.LatitudinalZone.North, new UtmNsZones.UtmNsZone(0.0, 15.99).LatitudinalZone);

            Assert.AreEqual(UtmNsZones.LatitudinalZone.North, new UtmNsZones.UtmNsZone(0.0, 16.0).LatitudinalZone);
            Assert.AreEqual(UtmNsZones.LatitudinalZone.North, new UtmNsZones.UtmNsZone(0.0, 23.99).LatitudinalZone);

            Assert.AreEqual(UtmNsZones.LatitudinalZone.North, new UtmNsZones.UtmNsZone(0.0, 24.0).LatitudinalZone);
            Assert.AreEqual(UtmNsZones.LatitudinalZone.North, new UtmNsZones.UtmNsZone(0.0, 31.99).LatitudinalZone);

            Assert.AreEqual(UtmNsZones.LatitudinalZone.North, new UtmNsZones.UtmNsZone(0.0, 32.0).LatitudinalZone);
            Assert.AreEqual(UtmNsZones.LatitudinalZone.North, new UtmNsZones.UtmNsZone(0.0, 39.99).LatitudinalZone);

            Assert.AreEqual(UtmNsZones.LatitudinalZone.North, new UtmNsZones.UtmNsZone(0.0, 40.0).LatitudinalZone);
            Assert.AreEqual(UtmNsZones.LatitudinalZone.North, new UtmNsZones.UtmNsZone(0.0, 47.99).LatitudinalZone);

            Assert.AreEqual(UtmNsZones.LatitudinalZone.North, new UtmNsZones.UtmNsZone(0.0, 48.0).LatitudinalZone);
            Assert.AreEqual(UtmNsZones.LatitudinalZone.North, new UtmNsZones.UtmNsZone(0.0, 55.99).LatitudinalZone);

            Assert.AreEqual(UtmNsZones.LatitudinalZone.North, new UtmNsZones.UtmNsZone(0.0, 56).LatitudinalZone);
            Assert.AreEqual(UtmNsZones.LatitudinalZone.North, new UtmNsZones.UtmNsZone(0.0, 63.99).LatitudinalZone);

            Assert.AreEqual(UtmNsZones.LatitudinalZone.North, new UtmNsZones.UtmNsZone(0.0, 64.0).LatitudinalZone);
            Assert.AreEqual(UtmNsZones.LatitudinalZone.North, new UtmNsZones.UtmNsZone(0.0, 71.99).LatitudinalZone);

            Assert.AreEqual(UtmNsZones.LatitudinalZone.North, new UtmNsZones.UtmNsZone(0.0, 72.0).LatitudinalZone);
            Assert.AreEqual(UtmNsZones.LatitudinalZone.North, new UtmNsZones.UtmNsZone(0.0, 84.0).LatitudinalZone);
        }

        [TestMethod]
        public void TestGetLongitudinalZoneFromZoneString()
        {
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm01, new UtmNsZones.UtmNsZone("1north").LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm02, new UtmNsZones.UtmNsZone("2SOUTH").LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm03, new UtmNsZones.UtmNsZone("3North").LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm04, new UtmNsZones.UtmNsZone("4South").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm05, new UtmZones.UtmZone("5a").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm06, new UtmZones.UtmZone("6b").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm07, new UtmZones.UtmZone("7c").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm08, new UtmZones.UtmZone("8d").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm09, new UtmZones.UtmZone("9e").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm10, new UtmZones.UtmZone("10f").LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm11, new UtmZones.UtmZone("11g").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm12, new UtmZones.UtmZone("12h").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm13, new UtmZones.UtmZone("13j").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm14, new UtmZones.UtmZone("14k").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm15, new UtmZones.UtmZone("15l").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm16, new UtmZones.UtmZone("16m").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm17, new UtmZones.UtmZone("17n").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm18, new UtmZones.UtmZone("18p").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm19, new UtmZones.UtmZone("19q").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm20, new UtmZones.UtmZone("20r").LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm21, new UtmZones.UtmZone("21s").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm22, new UtmZones.UtmZone("22t").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm23, new UtmZones.UtmZone("23u").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm24, new UtmZones.UtmZone("24v").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm25, new UtmZones.UtmZone("25w").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm26, new UtmZones.UtmZone("26x").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm27, new UtmZones.UtmZone("27y").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm28, new UtmZones.UtmZone("28z").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm29, new UtmZones.UtmZone("29A").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm30, new UtmZones.UtmZone("30B").LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm31, new UtmZones.UtmZone("31C").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm32, new UtmZones.UtmZone("32D").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm33, new UtmZones.UtmZone("33E").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm34, new UtmZones.UtmZone("34F").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm35, new UtmZones.UtmZone("35G").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm36, new UtmZones.UtmZone("36H").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm37, new UtmZones.UtmZone("37J").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm38, new UtmZones.UtmZone("38K").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm39, new UtmZones.UtmZone("39L").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm40, new UtmZones.UtmZone("40M").LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm41, new UtmZones.UtmZone("41N").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm42, new UtmZones.UtmZone("42P").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm43, new UtmZones.UtmZone("43Q").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm44, new UtmZones.UtmZone("44R").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm45, new UtmZones.UtmZone("45S").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm46, new UtmZones.UtmZone("46T").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm47, new UtmZones.UtmZone("47U").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm48, new UtmZones.UtmZone("48V").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm49, new UtmZones.UtmZone("49W").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm50, new UtmZones.UtmZone("50X").LongitudinalZone);

            Assert.AreEqual(UtmZones.LongitudinalZone.Utm51, new UtmZones.UtmZone("51Y").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm52, new UtmZones.UtmZone("52Z").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm53, new UtmZones.UtmZone("53a").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm54, new UtmZones.UtmZone("54b").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm55, new UtmZones.UtmZone("55c").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm56, new UtmZones.UtmZone("56d").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm57, new UtmZones.UtmZone("57e").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm58, new UtmZones.UtmZone("58f").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm59, new UtmZones.UtmZone("59g").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm60, new UtmZones.UtmZone("60h").LongitudinalZone);
        }

        [TestMethod]
        public void TestGetLatitudinalZoneFromZoneString()
        {
            Assert.AreEqual(UtmNsZones.LatitudinalZone.North, new UtmNsZones.UtmNsZone("1north").LatitudinalZone);
            Assert.AreEqual(UtmNsZones.LatitudinalZone.South, new UtmNsZones.UtmNsZone("2South").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmA, new UtmZones.UtmZone("3a").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmB, new UtmZones.UtmZone("4b").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmC, new UtmZones.UtmZone("5c").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmD, new UtmZones.UtmZone("6d").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmE, new UtmZones.UtmZone("7e").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmF, new UtmZones.UtmZone("8f").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmG, new UtmZones.UtmZone("9g").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmH, new UtmZones.UtmZone("10h").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmJ, new UtmZones.UtmZone("11J").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmK, new UtmZones.UtmZone("12k").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmL, new UtmZones.UtmZone("13l").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmM, new UtmZones.UtmZone("14m").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmN, new UtmZones.UtmZone("15n").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmP, new UtmZones.UtmZone("16p").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmQ, new UtmZones.UtmZone("17q").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmR, new UtmZones.UtmZone("18r").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmS, new UtmZones.UtmZone("19s").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmT, new UtmZones.UtmZone("20t").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmU, new UtmZones.UtmZone("21u").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmV, new UtmZones.UtmZone("22v").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmW, new UtmZones.UtmZone("23w").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmX, new UtmZones.UtmZone("24x").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmY, new UtmZones.UtmZone("25y").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmZ, new UtmZones.UtmZone("26z").LatitudinalZone);
        }

        [TestMethod]
        public void TestGetLongitudinalZoneFromLongitudinalZoneString()
        {
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm01, new UtmNsZones.UtmNsZone("1", "North").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm02, new UtmZones.UtmZone("2", "N").LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm03, new UtmNsZones.UtmNsZone("3", "North").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm04, new UtmZones.UtmZone("4", "N").LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm05, new UtmNsZones.UtmNsZone("5", "North").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm06, new UtmZones.UtmZone("6", "N").LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm07, new UtmNsZones.UtmNsZone("7", "North").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm08, new UtmZones.UtmZone("8", "N").LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm09, new UtmNsZones.UtmNsZone("9", "North").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm10, new UtmZones.UtmZone("10", "N").LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm11, new UtmNsZones.UtmNsZone("11", "North").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm12, new UtmZones.UtmZone("12", "N").LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm13, new UtmNsZones.UtmNsZone("13", "North").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm14, new UtmZones.UtmZone("14", "N").LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm15, new UtmNsZones.UtmNsZone("15", "North").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm16, new UtmZones.UtmZone("16", "N").LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm17, new UtmNsZones.UtmNsZone("17", "North").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm18, new UtmZones.UtmZone("18", "N").LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm19, new UtmNsZones.UtmNsZone("19", "North").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm20, new UtmZones.UtmZone("20", "N").LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm21, new UtmNsZones.UtmNsZone("21", "North").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm22, new UtmZones.UtmZone("22", "N").LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm23, new UtmNsZones.UtmNsZone("23", "North").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm24, new UtmZones.UtmZone("24", "N").LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm25, new UtmNsZones.UtmNsZone("25", "North").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm26, new UtmZones.UtmZone("26", "N").LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm27, new UtmNsZones.UtmNsZone("27", "North").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm28, new UtmZones.UtmZone("28", "N").LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm29, new UtmNsZones.UtmNsZone("29", "North").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm30, new UtmZones.UtmZone("30", "N").LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm31, new UtmNsZones.UtmNsZone("31", "North").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm32, new UtmZones.UtmZone("32", "N").LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm33, new UtmNsZones.UtmNsZone("33", "North").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm34, new UtmZones.UtmZone("34", "N").LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm35, new UtmNsZones.UtmNsZone("35", "North").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm36, new UtmZones.UtmZone("36", "N").LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm37, new UtmNsZones.UtmNsZone("37", "North").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm38, new UtmZones.UtmZone("38", "N").LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm39, new UtmNsZones.UtmNsZone("39", "North").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm40, new UtmZones.UtmZone("40", "N").LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm41, new UtmNsZones.UtmNsZone("41", "North").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm42, new UtmZones.UtmZone("42", "N").LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm43, new UtmNsZones.UtmNsZone("43", "North").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm44, new UtmZones.UtmZone("44", "N").LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm45, new UtmNsZones.UtmNsZone("45", "North").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm46, new UtmZones.UtmZone("46", "N").LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm47, new UtmNsZones.UtmNsZone("47", "North").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm48, new UtmZones.UtmZone("48", "N").LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm49, new UtmNsZones.UtmNsZone("49", "North").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm50, new UtmZones.UtmZone("50", "N").LongitudinalZone);

            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm51, new UtmNsZones.UtmNsZone("51", "North").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm52, new UtmZones.UtmZone("52", "N").LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm53, new UtmNsZones.UtmNsZone("53", "North").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm54, new UtmZones.UtmZone("54", "N").LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm55, new UtmNsZones.UtmNsZone("55", "North").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm56, new UtmZones.UtmZone("56", "N").LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm57, new UtmNsZones.UtmNsZone("57", "North").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm58, new UtmZones.UtmZone("58", "N").LongitudinalZone);
            Assert.AreEqual(UtmNsZones.LongitudinalZone.Utm59, new UtmNsZones.UtmNsZone("59", "North").LongitudinalZone);
            Assert.AreEqual(UtmZones.LongitudinalZone.Utm60, new UtmZones.UtmZone("60", "N").LongitudinalZone);
        }

        [TestMethod]
        public void TestGetLatitudinalZoneFromLatitudinalZoneString()
        {
            Assert.AreEqual(UtmNsZones.LatitudinalZone.North, new UtmNsZones.UtmNsZone("30", "north").LatitudinalZone);
            Assert.AreEqual(UtmNsZones.LatitudinalZone.South, new UtmNsZones.UtmNsZone("30", "South").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmA, new UtmZones.UtmZone("30", "a").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmB, new UtmZones.UtmZone("30", "b").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmC, new UtmZones.UtmZone("30", "c").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmD, new UtmZones.UtmZone("30", "d").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmE, new UtmZones.UtmZone("30", "e").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmF, new UtmZones.UtmZone("30", "f").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmG, new UtmZones.UtmZone("30", "g").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmH, new UtmZones.UtmZone("30", "h").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmJ, new UtmZones.UtmZone("30", "J").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmK, new UtmZones.UtmZone("30", "k").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmL, new UtmZones.UtmZone("30", "l").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmM, new UtmZones.UtmZone("30", "m").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmN, new UtmZones.UtmZone("30", "n").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmP, new UtmZones.UtmZone("30", "p").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmQ, new UtmZones.UtmZone("30", "q").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmR, new UtmZones.UtmZone("30", "r").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmS, new UtmZones.UtmZone("30", "s").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmT, new UtmZones.UtmZone("30", "t").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmU, new UtmZones.UtmZone("30", "u").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmV, new UtmZones.UtmZone("30", "v").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmW, new UtmZones.UtmZone("30", "w").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmX, new UtmZones.UtmZone("30", "x").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmY, new UtmZones.UtmZone("30", "y").LatitudinalZone);
            Assert.AreEqual(UtmZones.LatitudinalZone.UtmZ, new UtmZones.UtmZone("30", "z").LatitudinalZone);
        }
    }
}


