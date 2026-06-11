// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using AwesomeAssertions;
using UtmZones = StarThrower.Gis.GeoUtilities.Zones.Utm;
using UtmNsZones = StarThrower.Gis.GeoUtilities.Zones.UtmNs;
using Xunit;

namespace StarThrower.Gis.GeoUtilities.Test
{
    public class CsUtilTest
    {
        [Fact]
        public void TestGetCentralMeridianForZone()
        {
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm01, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(-177.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm02, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(-171.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm03, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(-165.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm04, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(-159.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm05, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(-153.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm06, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(-147.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm07, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(-141.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm08, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(-135.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm09, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(-129.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm10, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(-123.0);

            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm11, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(-117.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm12, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(-111.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm13, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(-105.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm14, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(-99.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm15, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(-93.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm16, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(-87.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm17, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(-81.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm18, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(-75.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm19, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(-69.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm20, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(-63.0);

            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm21, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(-57.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm22, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(-51.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm23, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(-45.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm24, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(-39.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm25, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(-33.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm26, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(-27.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm27, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(-21.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm28, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(-15.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm29, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(-9.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm30, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(-3.0);

            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm31, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(3.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm31, UtmZones.LatitudinalZone.UtmN).CentralMeridian.Should().Be(3.0);
            //Assert.AreEqual(4.5, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm31, UtmZones.LatitudinalZone.UtmX).CentralMeridian);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm31, UtmZones.LatitudinalZone.UtmX).CentralMeridian.Should().Be(3.0);
            //Assert.AreEqual(1.5, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm31, UtmZones.LatitudinalZone.UtmV).CentralMeridian);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm31, UtmZones.LatitudinalZone.UtmV).CentralMeridian.Should().Be(3.0);

            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm32, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(9.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm32, UtmZones.LatitudinalZone.UtmN).CentralMeridian.Should().Be(9.0);
            //Assert.AreEqual(7.5, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm32, UtmZones.LatitudinalZone.UtmV).CentralMeridian);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm32, UtmZones.LatitudinalZone.UtmV).CentralMeridian.Should().Be(9.0);

            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm33, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(15.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm33, UtmZones.LatitudinalZone.UtmN).CentralMeridian.Should().Be(15.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm33, UtmZones.LatitudinalZone.UtmX).CentralMeridian.Should().Be(15.0);

            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm34, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(21.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm34, UtmZones.LatitudinalZone.UtmN).CentralMeridian.Should().Be(21.0);

            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm35, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(27.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm35, UtmZones.LatitudinalZone.UtmN).CentralMeridian.Should().Be(27.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm35, UtmZones.LatitudinalZone.UtmX).CentralMeridian.Should().Be(27.0);

            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm36, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(33.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm36, UtmZones.LatitudinalZone.UtmN).CentralMeridian.Should().Be(33.0);

            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm37, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(39.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm37, UtmZones.LatitudinalZone.UtmN).CentralMeridian.Should().Be(39.0);
            //Assert.AreEqual(37.5, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm37, UtmZones.LatitudinalZone.UtmX).CentralMeridian);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm37, UtmZones.LatitudinalZone.UtmX).CentralMeridian.Should().Be(39.0);

            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm38, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(45.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm38, UtmZones.LatitudinalZone.UtmN).CentralMeridian.Should().Be(45.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm39, UtmZones.LatitudinalZone.UtmN).CentralMeridian.Should().Be(51.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm40, UtmZones.LatitudinalZone.UtmN).CentralMeridian.Should().Be(57.0);

            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm41, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(63.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm42, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(69.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm43, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(75.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm44, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(81.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm45, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(87.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm46, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(93.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm47, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(99.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm48, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(105.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm49, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(111.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm50, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(117.0);

            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm51, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(123.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm52, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(129.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm53, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(135.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm54, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(141.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm55, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(147.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm56, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(153.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm57, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(159.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm58, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(165.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm59, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(171.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm60, UtmNsZones.LatitudinalZone.North).CentralMeridian.Should().Be(177.0);
        }

        [Fact]
        public void TestGetGeometricCenterForZone()
        {
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm01, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(-177.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm02, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(-171.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm03, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(-165.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm04, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(-159.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm05, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(-153.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm06, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(-147.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm07, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(-141.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm08, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(-135.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm09, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(-129.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm10, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(-123.0);

            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm11, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(-117.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm12, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(-111.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm13, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(-105.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm14, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(-99.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm15, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(-93.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm16, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(-87.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm17, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(-81.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm18, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(-75.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm19, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(-69.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm20, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(-63.0);

            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm21, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(-57.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm22, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(-51.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm23, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(-45.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm24, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(-39.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm25, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(-33.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm26, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(-27.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm27, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(-21.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm28, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(-15.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm29, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(-9.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm30, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(-3.0);

            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm31, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(3.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm31, UtmZones.LatitudinalZone.UtmN).GeometricCenter.Should().Be(3.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm31, UtmZones.LatitudinalZone.UtmX).GeometricCenter.Should().Be(4.5);
            //Assert.AreEqual(3.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm31, UtmZones.LatitudinalZone.UtmX).GeometricCenter);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm31, UtmZones.LatitudinalZone.UtmV).GeometricCenter.Should().Be(1.5);
            //Assert.AreEqual(3.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm31, UtmZones.LatitudinalZone.UtmV).GeometricCenter);

            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm32, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(9.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm32, UtmZones.LatitudinalZone.UtmN).GeometricCenter.Should().Be(9.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm32, UtmZones.LatitudinalZone.UtmV).GeometricCenter.Should().Be(7.5);
            //Assert.AreEqual(9.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm32, UtmZones.LatitudinalZone.UtmV).GeometricCenter);

            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm33, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(15.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm33, UtmZones.LatitudinalZone.UtmN).GeometricCenter.Should().Be(15.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm33, UtmZones.LatitudinalZone.UtmX).GeometricCenter.Should().Be(15.0);

            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm34, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(21.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm34, UtmZones.LatitudinalZone.UtmN).GeometricCenter.Should().Be(21.0);

            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm35, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(27.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm35, UtmZones.LatitudinalZone.UtmN).GeometricCenter.Should().Be(27.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm35, UtmZones.LatitudinalZone.UtmX).GeometricCenter.Should().Be(27.0);

            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm36, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(33.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm36, UtmZones.LatitudinalZone.UtmN).GeometricCenter.Should().Be(33.0);

            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm37, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(39.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm37, UtmZones.LatitudinalZone.UtmN).GeometricCenter.Should().Be(39.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm37, UtmZones.LatitudinalZone.UtmX).GeometricCenter.Should().Be(37.5);
            //Assert.AreEqual(39.0, new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm37, UtmZones.LatitudinalZone.UtmX).GeometricCenter);

            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm38, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(45.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm38, UtmZones.LatitudinalZone.UtmN).GeometricCenter.Should().Be(45.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm39, UtmZones.LatitudinalZone.UtmN).GeometricCenter.Should().Be(51.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm40, UtmZones.LatitudinalZone.UtmN).GeometricCenter.Should().Be(57.0);

            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm41, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(63.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm42, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(69.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm43, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(75.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm44, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(81.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm45, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(87.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm46, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(93.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm47, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(99.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm48, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(105.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm49, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(111.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm50, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(117.0);

            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm51, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(123.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm52, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(129.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm53, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(135.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm54, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(141.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm55, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(147.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm56, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(153.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm57, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(159.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm58, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(165.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm59, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(171.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm60, UtmNsZones.LatitudinalZone.North).GeometricCenter.Should().Be(177.0);
        }

        [Fact]
        public void TestGetReferenceLatitudeForZone()
        {
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm01, UtmNsZones.LatitudinalZone.North).ReferenceLatitude.Should().Be(0.0);
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm01, UtmNsZones.LatitudinalZone.South).ReferenceLatitude.Should().Be(0.0);

            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmC).ReferenceLatitude.Should().Be(-76.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmD).ReferenceLatitude.Should().Be(-68.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmE).ReferenceLatitude.Should().Be(-60.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmF).ReferenceLatitude.Should().Be(-52.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmG).ReferenceLatitude.Should().Be(-44.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmH).ReferenceLatitude.Should().Be(-36.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmJ).ReferenceLatitude.Should().Be(-28.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmK).ReferenceLatitude.Should().Be(-20.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmL).ReferenceLatitude.Should().Be(-12.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmM).ReferenceLatitude.Should().Be(-4.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmN).ReferenceLatitude.Should().Be(4.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmP).ReferenceLatitude.Should().Be(12.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmQ).ReferenceLatitude.Should().Be(20.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmR).ReferenceLatitude.Should().Be(28.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmS).ReferenceLatitude.Should().Be(36.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmT).ReferenceLatitude.Should().Be(44.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmU).ReferenceLatitude.Should().Be(52.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmV).ReferenceLatitude.Should().Be(60.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmW).ReferenceLatitude.Should().Be(68.0);
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmX).ReferenceLatitude.Should().Be(80.0);
        }

        [Fact]
        public void TestIsSouthernHemisphere()
        {
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm01, UtmNsZones.LatitudinalZone.South).IsSouthernHemisphere.Should().BeTrue();
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmA).IsSouthernHemisphere.Should().BeTrue();
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmB).IsSouthernHemisphere.Should().BeTrue();
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmC).IsSouthernHemisphere.Should().BeTrue();
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmD).IsSouthernHemisphere.Should().BeTrue();
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmE).IsSouthernHemisphere.Should().BeTrue();
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmF).IsSouthernHemisphere.Should().BeTrue();
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmG).IsSouthernHemisphere.Should().BeTrue();
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmH).IsSouthernHemisphere.Should().BeTrue();
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmJ).IsSouthernHemisphere.Should().BeTrue();
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmK).IsSouthernHemisphere.Should().BeTrue();
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmL).IsSouthernHemisphere.Should().BeTrue();
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmM).IsSouthernHemisphere.Should().BeTrue();

            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm01, UtmNsZones.LatitudinalZone.North).IsSouthernHemisphere.Should().BeFalse();
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmN).IsSouthernHemisphere.Should().BeFalse();
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmP).IsSouthernHemisphere.Should().BeFalse();
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmQ).IsSouthernHemisphere.Should().BeFalse();
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmR).IsSouthernHemisphere.Should().BeFalse();
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmS).IsSouthernHemisphere.Should().BeFalse();
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmT).IsSouthernHemisphere.Should().BeFalse();
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmU).IsSouthernHemisphere.Should().BeFalse();
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmV).IsSouthernHemisphere.Should().BeFalse();
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmW).IsSouthernHemisphere.Should().BeFalse();
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmX).IsSouthernHemisphere.Should().BeFalse();
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmY).IsSouthernHemisphere.Should().BeFalse();
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmZ).IsSouthernHemisphere.Should().BeFalse();
        }

        [Fact]
        public void TestGetZoneString()
        {
            new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmA).ZoneString.Should().Be("1A");
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm01, UtmNsZones.LatitudinalZone.North).ZoneString.Should().Be("1North");
            new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm01, UtmNsZones.LatitudinalZone.South).ZoneString.Should().Be("1South");
        }

        [Fact]
        public void TestBadGetCentralMeridianForZone1()
        {
            Action act = () => _ = new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm32, UtmZones.LatitudinalZone.UtmX).CentralMeridian;
            act.Should().Throw<NotSupportedException>();
        }

        [Fact]
        public void TestBadGetCentralMeridianForZone2()
        {
            Action act = () => _ = new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm34, UtmZones.LatitudinalZone.UtmX).CentralMeridian;
            act.Should().Throw<NotSupportedException>();
        }

        [Fact]
        public void TestBadGetCentralMeridianForZone3()
        {
            Action act = () => _ = new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm36, UtmZones.LatitudinalZone.UtmX).CentralMeridian;
            act.Should().Throw<NotSupportedException>();
        }

        [Fact]
        public void TestBadGetReferenceLatitudeForZone1()
        {
            Action act = () => _ = new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmA).ReferenceLatitude;
            act.Should().Throw<NotImplementedException>();
        }

        [Fact]
        public void TestBadGetReferenceLatitudeForZone2()
        {
            Action act = () => _ = new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmB).ReferenceLatitude;
            act.Should().Throw<NotImplementedException>();
        }

        [Fact]
        public void TestBadGetReferenceLatitudeForZone3()
        {
            Action act = () => _ = new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmY).ReferenceLatitude;
            act.Should().Throw<NotImplementedException>();
        }

        [Fact]
        public void TestBadGetReferenceLatitudeForZone4()
        {
            Action act = () => _ = new UtmZones.UtmZone(UtmZones.LongitudinalZone.Utm01, UtmZones.LatitudinalZone.UtmZ).ReferenceLatitude;
            act.Should().Throw<NotImplementedException>();
        }

        [Fact]
        public void TestGetLongitudinalZoneForLongitude()
        {
            new UtmZones.UtmZone(180.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm01);
            new UtmZones.UtmZone(-180.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm01);
            new UtmZones.UtmZone(-174.01, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm01);

            new UtmZones.UtmZone(-174.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm02);
            new UtmZones.UtmZone(-168.01, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm02);

            new UtmZones.UtmZone(-168.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm03);
            new UtmZones.UtmZone(-162.01, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm03);

            new UtmZones.UtmZone(-162.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm04);
            new UtmZones.UtmZone(-156.01, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm04);

            new UtmZones.UtmZone(-156.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm05);
            new UtmZones.UtmZone(-150.01, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm05);

            new UtmZones.UtmZone(-150.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm06);
            new UtmZones.UtmZone(-144.01, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm06);

            new UtmZones.UtmZone(-144.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm07);
            new UtmZones.UtmZone(-138.01, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm07);

            new UtmZones.UtmZone(-138.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm08);
            new UtmZones.UtmZone(-132.01, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm08);

            new UtmZones.UtmZone(-132.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm09);
            new UtmZones.UtmZone(-126.01, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm09);

            new UtmZones.UtmZone(-126.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm10);
            new UtmZones.UtmZone(-120.01, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm10);

            new UtmZones.UtmZone(-120.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm11);
            new UtmZones.UtmZone(-114.01, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm11);

            new UtmZones.UtmZone(-114.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm12);
            new UtmZones.UtmZone(-108.01, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm12);

            new UtmZones.UtmZone(-108.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm13);
            new UtmZones.UtmZone(-102.01, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm13);

            new UtmZones.UtmZone(-102.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm14);
            new UtmZones.UtmZone(-96.01, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm14);

            new UtmZones.UtmZone(-96.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm15);
            new UtmZones.UtmZone(-90.01, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm15);

            new UtmZones.UtmZone(-90.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm16);
            new UtmZones.UtmZone(-84.01, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm16);

            new UtmZones.UtmZone(-84.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm17);
            new UtmZones.UtmZone(-78.01, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm17);

            new UtmZones.UtmZone(-78.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm18);
            new UtmZones.UtmZone(-72.01, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm18);

            new UtmZones.UtmZone(-72.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm19);
            new UtmZones.UtmZone(-66.01, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm19);

            new UtmZones.UtmZone(-66.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm20);
            new UtmZones.UtmZone(-60.01, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm20);

            new UtmZones.UtmZone(-60.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm21);
            new UtmZones.UtmZone(-54.01, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm21);

            new UtmZones.UtmZone(-54.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm22);
            new UtmZones.UtmZone(-48.01, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm22);

            new UtmZones.UtmZone(-48.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm23);
            new UtmZones.UtmZone(-42.01, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm23);

            new UtmZones.UtmZone(-42.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm24);
            new UtmZones.UtmZone(-36.01, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm24);

            new UtmZones.UtmZone(-36.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm25);
            new UtmZones.UtmZone(-30.01, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm25);

            new UtmZones.UtmZone(-30.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm26);
            new UtmZones.UtmZone(-24.01, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm26);

            new UtmZones.UtmZone(-24.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm27);
            new UtmZones.UtmZone(-18.01, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm27);

            new UtmZones.UtmZone(-18.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm28);
            new UtmZones.UtmZone(-12.01, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm28);

            new UtmZones.UtmZone(-12.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm29);
            new UtmZones.UtmZone(-6.01, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm29);

            new UtmZones.UtmZone(-6.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm30);
            new UtmZones.UtmZone(-0.01, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm30);

            //--zero--

            new UtmZones.UtmZone(0.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm31);
            new UtmZones.UtmZone(5.9, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm31);


            //TODO: Need to fix this up to allow for the anomolies at 31X, 33X, 35X, 37X, 31V, & 32V


            new UtmZones.UtmZone(6.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm32);
            new UtmZones.UtmZone(11.9, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm32);

            new UtmZones.UtmZone(12.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm33);
            new UtmZones.UtmZone(17.9, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm33);

            new UtmZones.UtmZone(18.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm34);
            new UtmZones.UtmZone(23.9, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm34);

            new UtmZones.UtmZone(24.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm35);
            new UtmZones.UtmZone(29.9, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm35);

            new UtmZones.UtmZone(30.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm36);
            new UtmZones.UtmZone(35.9, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm36);

            new UtmZones.UtmZone(36.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm37);
            new UtmZones.UtmZone(41.9, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm37);

            new UtmZones.UtmZone(42.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm38);
            new UtmZones.UtmZone(47.9, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm38);

            new UtmZones.UtmZone(48.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm39);
            new UtmZones.UtmZone(53.9, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm39);

            new UtmZones.UtmZone(54.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm40);
            new UtmZones.UtmZone(59.9, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm40);

            new UtmZones.UtmZone(60.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm41);
            new UtmZones.UtmZone(65.9, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm41);

            new UtmZones.UtmZone(66.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm42);
            new UtmZones.UtmZone(71.9, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm42);

            new UtmZones.UtmZone(72.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm43);
            new UtmZones.UtmZone(77.9, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm43);

            new UtmZones.UtmZone(78.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm44);
            new UtmZones.UtmZone(83.9, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm44);

            new UtmZones.UtmZone(84.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm45);
            new UtmZones.UtmZone(89.9, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm45);

            new UtmZones.UtmZone(90.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm46);
            new UtmZones.UtmZone(95.9, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm46);

            new UtmZones.UtmZone(96.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm47);
            new UtmZones.UtmZone(101.9, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm47);

            new UtmZones.UtmZone(102.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm48);
            new UtmZones.UtmZone(107.9, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm48);

            new UtmZones.UtmZone(108.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm49);
            new UtmZones.UtmZone(113.9, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm49);

            new UtmZones.UtmZone(114.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm50);
            new UtmZones.UtmZone(119.9, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm50);

            new UtmZones.UtmZone(120.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm51);
            new UtmZones.UtmZone(125.9, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm51);

            new UtmZones.UtmZone(126.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm52);
            new UtmZones.UtmZone(131.9, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm52);

            new UtmZones.UtmZone(132.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm53);
            new UtmZones.UtmZone(137.9, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm53);

            new UtmZones.UtmZone(138.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm54);
            new UtmZones.UtmZone(143.9, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm54);

            new UtmZones.UtmZone(144.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm55);
            new UtmZones.UtmZone(149.9, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm55);

            new UtmZones.UtmZone(150.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm56);
            new UtmZones.UtmZone(155.9, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm56);

            new UtmZones.UtmZone(156.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm57);
            new UtmZones.UtmZone(161.9, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm57);

            new UtmZones.UtmZone(162.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm58);
            new UtmZones.UtmZone(167.9, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm58);

            new UtmZones.UtmZone(168.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm59);
            new UtmZones.UtmZone(173.9, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm59);

            new UtmZones.UtmZone(174.0, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm60);
            new UtmZones.UtmZone(179.9, 0.0).LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm60);
        }

        [Fact]
        public void TestGetLongitudinalNSZoneForLongitude()
        {
            new UtmNsZones.UtmNsZone(180.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm01);
            new UtmNsZones.UtmNsZone(-180.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm01);
            new UtmNsZones.UtmNsZone(-174.01, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm01);

            new UtmNsZones.UtmNsZone(-174.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm02);
            new UtmNsZones.UtmNsZone(-168.01, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm02);

            new UtmNsZones.UtmNsZone(-168.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm03);
            new UtmNsZones.UtmNsZone(-162.01, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm03);

            new UtmNsZones.UtmNsZone(-162.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm04);
            new UtmNsZones.UtmNsZone(-156.01, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm04);

            new UtmNsZones.UtmNsZone(-156.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm05);
            new UtmNsZones.UtmNsZone(-150.01, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm05);

            new UtmNsZones.UtmNsZone(-150.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm06);
            new UtmNsZones.UtmNsZone(-144.01, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm06);

            new UtmNsZones.UtmNsZone(-144.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm07);
            new UtmNsZones.UtmNsZone(-138.01, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm07);

            new UtmNsZones.UtmNsZone(-138.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm08);
            new UtmNsZones.UtmNsZone(-132.01, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm08);

            new UtmNsZones.UtmNsZone(-132.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm09);
            new UtmNsZones.UtmNsZone(-126.01, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm09);

            new UtmNsZones.UtmNsZone(-126.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm10);
            new UtmNsZones.UtmNsZone(-120.01, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm10);

            new UtmNsZones.UtmNsZone(-120.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm11);
            new UtmNsZones.UtmNsZone(-114.01, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm11);

            new UtmNsZones.UtmNsZone(-114.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm12);
            new UtmNsZones.UtmNsZone(-108.01, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm12);

            new UtmNsZones.UtmNsZone(-108.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm13);
            new UtmNsZones.UtmNsZone(-102.01, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm13);

            new UtmNsZones.UtmNsZone(-102.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm14);
            new UtmNsZones.UtmNsZone(-96.01, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm14);

            new UtmNsZones.UtmNsZone(-96.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm15);
            new UtmNsZones.UtmNsZone(-90.01, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm15);

            new UtmNsZones.UtmNsZone(-90.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm16);
            new UtmNsZones.UtmNsZone(-84.01, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm16);

            new UtmNsZones.UtmNsZone(-84.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm17);
            new UtmNsZones.UtmNsZone(-78.01, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm17);

            new UtmNsZones.UtmNsZone(-78.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm18);
            new UtmNsZones.UtmNsZone(-72.01, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm18);

            new UtmNsZones.UtmNsZone(-72.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm19);
            new UtmNsZones.UtmNsZone(-66.01, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm19);

            new UtmNsZones.UtmNsZone(-66.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm20);
            new UtmNsZones.UtmNsZone(-60.01, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm20);

            new UtmNsZones.UtmNsZone(-60.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm21);
            new UtmNsZones.UtmNsZone(-54.01, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm21);

            new UtmNsZones.UtmNsZone(-54.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm22);
            new UtmNsZones.UtmNsZone(-48.01, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm22);

            new UtmNsZones.UtmNsZone(-48.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm23);
            new UtmNsZones.UtmNsZone(-42.01, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm23);

            new UtmNsZones.UtmNsZone(-42.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm24);
            new UtmNsZones.UtmNsZone(-36.01, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm24);

            new UtmNsZones.UtmNsZone(-36.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm25);
            new UtmNsZones.UtmNsZone(-30.01, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm25);

            new UtmNsZones.UtmNsZone(-30.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm26);
            new UtmNsZones.UtmNsZone(-24.01, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm26);

            new UtmNsZones.UtmNsZone(-24.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm27);
            new UtmNsZones.UtmNsZone(-18.01, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm27);

            new UtmNsZones.UtmNsZone(-18.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm28);
            new UtmNsZones.UtmNsZone(-12.01, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm28);

            new UtmNsZones.UtmNsZone(-12.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm29);
            new UtmNsZones.UtmNsZone(-6.01, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm29);

            new UtmNsZones.UtmNsZone(-6.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm30);
            new UtmNsZones.UtmNsZone(-0.01, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm30);

            //--zero--

            new UtmNsZones.UtmNsZone(0.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm31);
            new UtmNsZones.UtmNsZone(5.9, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm31);


            //TODO: Need to fix this up to allow for the anomolies at 31X, 33X, 35X, 37X, 31V, & 32V


            new UtmNsZones.UtmNsZone(6.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm32);
            new UtmNsZones.UtmNsZone(11.9, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm32);

            new UtmNsZones.UtmNsZone(12.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm33);
            new UtmNsZones.UtmNsZone(17.9, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm33);

            new UtmNsZones.UtmNsZone(18.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm34);
            new UtmNsZones.UtmNsZone(23.9, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm34);

            new UtmNsZones.UtmNsZone(24.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm35);
            new UtmNsZones.UtmNsZone(29.9, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm35);

            new UtmNsZones.UtmNsZone(30.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm36);
            new UtmNsZones.UtmNsZone(35.9, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm36);

            new UtmNsZones.UtmNsZone(36.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm37);
            new UtmNsZones.UtmNsZone(41.9, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm37);

            new UtmNsZones.UtmNsZone(42.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm38);
            new UtmNsZones.UtmNsZone(47.9, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm38);

            new UtmNsZones.UtmNsZone(48.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm39);
            new UtmNsZones.UtmNsZone(53.9, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm39);

            new UtmNsZones.UtmNsZone(54.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm40);
            new UtmNsZones.UtmNsZone(59.9, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm40);

            new UtmNsZones.UtmNsZone(60.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm41);
            new UtmNsZones.UtmNsZone(65.9, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm41);

            new UtmNsZones.UtmNsZone(66.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm42);
            new UtmNsZones.UtmNsZone(71.9, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm42);

            new UtmNsZones.UtmNsZone(72.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm43);
            new UtmNsZones.UtmNsZone(77.9, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm43);

            new UtmNsZones.UtmNsZone(78.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm44);
            new UtmNsZones.UtmNsZone(83.9, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm44);

            new UtmNsZones.UtmNsZone(84.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm45);
            new UtmNsZones.UtmNsZone(89.9, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm45);

            new UtmNsZones.UtmNsZone(90.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm46);
            new UtmNsZones.UtmNsZone(95.9, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm46);

            new UtmNsZones.UtmNsZone(96.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm47);
            new UtmNsZones.UtmNsZone(101.9, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm47);

            new UtmNsZones.UtmNsZone(102.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm48);
            new UtmNsZones.UtmNsZone(107.9, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm48);

            new UtmNsZones.UtmNsZone(108.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm49);
            new UtmNsZones.UtmNsZone(113.9, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm49);

            new UtmNsZones.UtmNsZone(114.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm50);
            new UtmNsZones.UtmNsZone(119.9, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm50);

            new UtmNsZones.UtmNsZone(120.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm51);
            new UtmNsZones.UtmNsZone(125.9, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm51);

            new UtmNsZones.UtmNsZone(126.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm52);
            new UtmNsZones.UtmNsZone(131.9, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm52);

            new UtmNsZones.UtmNsZone(132.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm53);
            new UtmNsZones.UtmNsZone(137.9, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm53);

            new UtmNsZones.UtmNsZone(138.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm54);
            new UtmNsZones.UtmNsZone(143.9, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm54);

            new UtmNsZones.UtmNsZone(144.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm55);
            new UtmNsZones.UtmNsZone(149.9, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm55);

            new UtmNsZones.UtmNsZone(150.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm56);
            new UtmNsZones.UtmNsZone(155.9, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm56);

            new UtmNsZones.UtmNsZone(156.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm57);
            new UtmNsZones.UtmNsZone(161.9, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm57);

            new UtmNsZones.UtmNsZone(162.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm58);
            new UtmNsZones.UtmNsZone(167.9, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm58);

            new UtmNsZones.UtmNsZone(168.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm59);
            new UtmNsZones.UtmNsZone(173.9, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm59);

            new UtmNsZones.UtmNsZone(174.0, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm60);
            new UtmNsZones.UtmNsZone(179.9, 0.0).LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm60);
        }

        [Fact]
        public void TestGetLatitudinalZoneForLatitude()
        {
            new UtmZones.UtmZone(0.0, -80.0).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmC);
            new UtmZones.UtmZone(0.0, -72.01).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmC);

            new UtmZones.UtmZone(0.0, -72.0).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmD);
            new UtmZones.UtmZone(0.0, -64.01).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmD);

            new UtmZones.UtmZone(0.0, -64.0).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmE);
            new UtmZones.UtmZone(0.0, -56.01).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmE);

            new UtmZones.UtmZone(0.0, -56.0).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmF);
            new UtmZones.UtmZone(0.0, -48.01).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmF);

            new UtmZones.UtmZone(0.0, -48.0).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmG);
            new UtmZones.UtmZone(0.0, -40.01).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmG);

            new UtmZones.UtmZone(0.0, -40.0).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmH);
            new UtmZones.UtmZone(0.0, -32.01).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmH);

            new UtmZones.UtmZone(0.0, -32.0).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmJ);
            new UtmZones.UtmZone(0.0, -24.01).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmJ);

            new UtmZones.UtmZone(0.0, -24.0).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmK);
            new UtmZones.UtmZone(0.0, -16.01).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmK);

            new UtmZones.UtmZone(0.0, -16.0).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmL);
            new UtmZones.UtmZone(0.0, -8.01).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmL);

            new UtmZones.UtmZone(0.0, -8.0).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmM);
            new UtmZones.UtmZone(0.0, -0.01).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmM);

            new UtmZones.UtmZone(0.0, 0.0).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmN);
            new UtmZones.UtmZone(0.0, 7.99).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmN);

            new UtmZones.UtmZone(0.0, 8.0).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmP);
            new UtmZones.UtmZone(0.0, 15.99).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmP);

            new UtmZones.UtmZone(0.0, 16.0).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmQ);
            new UtmZones.UtmZone(0.0, 23.99).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmQ);

            new UtmZones.UtmZone(0.0, 24.0).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmR);
            new UtmZones.UtmZone(0.0, 31.99).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmR);

            new UtmZones.UtmZone(0.0, 32.0).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmS);
            new UtmZones.UtmZone(0.0, 39.99).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmS);

            new UtmZones.UtmZone(0.0, 40.0).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmT);
            new UtmZones.UtmZone(0.0, 47.99).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmT);

            new UtmZones.UtmZone(0.0, 48.0).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmU);
            new UtmZones.UtmZone(0.0, 55.99).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmU);

            new UtmZones.UtmZone(0.0, 56).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmV);
            new UtmZones.UtmZone(0.0, 63.99).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmV);

            new UtmZones.UtmZone(0.0, 64.0).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmW);
            new UtmZones.UtmZone(0.0, 71.99).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmW);

            new UtmZones.UtmZone(0.0, 72.0).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmX);
            new UtmZones.UtmZone(0.0, 84.0).LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmX);
        }

        [Fact]
        public void TestGetLatitudinalNSZoneForLatitude()
        {
            new UtmNsZones.UtmNsZone(0.0, -80.0).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.South);
            new UtmNsZones.UtmNsZone(0.0, -72.01).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.South);

            new UtmNsZones.UtmNsZone(0.0, -72.0).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.South);
            new UtmNsZones.UtmNsZone(0.0, -64.01).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.South);

            new UtmNsZones.UtmNsZone(0.0, -64.0).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.South);
            new UtmNsZones.UtmNsZone(0.0, -56.01).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.South);

            new UtmNsZones.UtmNsZone(0.0, -56.0).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.South);
            new UtmNsZones.UtmNsZone(0.0, -48.01).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.South);

            new UtmNsZones.UtmNsZone(0.0, -48.0).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.South);
            new UtmNsZones.UtmNsZone(0.0, -40.01).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.South);

            new UtmNsZones.UtmNsZone(0.0, -40.0).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.South);
            new UtmNsZones.UtmNsZone(0.0, -32.01).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.South);

            new UtmNsZones.UtmNsZone(0.0, -32.0).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.South);
            new UtmNsZones.UtmNsZone(0.0, -24.01).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.South);

            new UtmNsZones.UtmNsZone(0.0, -24.0).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.South);
            new UtmNsZones.UtmNsZone(0.0, -16.01).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.South);

            new UtmNsZones.UtmNsZone(0.0, -16.0).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.South);
            new UtmNsZones.UtmNsZone(0.0, -8.01).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.South);

            new UtmNsZones.UtmNsZone(0.0, -8.0).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.South);
            new UtmNsZones.UtmNsZone(0.0, -0.01).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.South);

            new UtmNsZones.UtmNsZone(0.0, 0.0).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.North);
            new UtmNsZones.UtmNsZone(0.0, 7.99).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.North);

            new UtmNsZones.UtmNsZone(0.0, 8.0).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.North);
            new UtmNsZones.UtmNsZone(0.0, 15.99).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.North);

            new UtmNsZones.UtmNsZone(0.0, 16.0).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.North);
            new UtmNsZones.UtmNsZone(0.0, 23.99).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.North);

            new UtmNsZones.UtmNsZone(0.0, 24.0).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.North);
            new UtmNsZones.UtmNsZone(0.0, 31.99).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.North);

            new UtmNsZones.UtmNsZone(0.0, 32.0).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.North);
            new UtmNsZones.UtmNsZone(0.0, 39.99).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.North);

            new UtmNsZones.UtmNsZone(0.0, 40.0).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.North);
            new UtmNsZones.UtmNsZone(0.0, 47.99).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.North);

            new UtmNsZones.UtmNsZone(0.0, 48.0).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.North);
            new UtmNsZones.UtmNsZone(0.0, 55.99).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.North);

            new UtmNsZones.UtmNsZone(0.0, 56).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.North);
            new UtmNsZones.UtmNsZone(0.0, 63.99).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.North);

            new UtmNsZones.UtmNsZone(0.0, 64.0).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.North);
            new UtmNsZones.UtmNsZone(0.0, 71.99).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.North);

            new UtmNsZones.UtmNsZone(0.0, 72.0).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.North);
            new UtmNsZones.UtmNsZone(0.0, 84.0).LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.North);
        }

        [Fact]
        public void TestGetLongitudinalZoneFromZoneString()
        {
            new UtmNsZones.UtmNsZone("1north").LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm01);
            new UtmNsZones.UtmNsZone("2SOUTH").LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm02);
            new UtmNsZones.UtmNsZone("3North").LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm03);
            new UtmNsZones.UtmNsZone("4South").LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm04);
            new UtmZones.UtmZone("5a").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm05);
            new UtmZones.UtmZone("6b").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm06);
            new UtmZones.UtmZone("7c").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm07);
            new UtmZones.UtmZone("8d").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm08);
            new UtmZones.UtmZone("9e").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm09);
            new UtmZones.UtmZone("10f").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm10);

            new UtmZones.UtmZone("11g").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm11);
            new UtmZones.UtmZone("12h").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm12);
            new UtmZones.UtmZone("13j").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm13);
            new UtmZones.UtmZone("14k").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm14);
            new UtmZones.UtmZone("15l").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm15);
            new UtmZones.UtmZone("16m").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm16);
            new UtmZones.UtmZone("17n").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm17);
            new UtmZones.UtmZone("18p").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm18);
            new UtmZones.UtmZone("19q").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm19);
            new UtmZones.UtmZone("20r").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm20);

            new UtmZones.UtmZone("21s").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm21);
            new UtmZones.UtmZone("22t").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm22);
            new UtmZones.UtmZone("23u").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm23);
            new UtmZones.UtmZone("24v").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm24);
            new UtmZones.UtmZone("25w").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm25);
            new UtmZones.UtmZone("26x").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm26);
            new UtmZones.UtmZone("27y").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm27);
            new UtmZones.UtmZone("28z").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm28);
            new UtmZones.UtmZone("29A").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm29);
            new UtmZones.UtmZone("30B").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm30);

            new UtmZones.UtmZone("31C").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm31);
            new UtmZones.UtmZone("32D").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm32);
            new UtmZones.UtmZone("33E").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm33);
            new UtmZones.UtmZone("34F").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm34);
            new UtmZones.UtmZone("35G").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm35);
            new UtmZones.UtmZone("36H").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm36);
            new UtmZones.UtmZone("37J").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm37);
            new UtmZones.UtmZone("38K").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm38);
            new UtmZones.UtmZone("39L").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm39);
            new UtmZones.UtmZone("40M").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm40);

            new UtmZones.UtmZone("41N").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm41);
            new UtmZones.UtmZone("42P").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm42);
            new UtmZones.UtmZone("43Q").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm43);
            new UtmZones.UtmZone("44R").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm44);
            new UtmZones.UtmZone("45S").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm45);
            new UtmZones.UtmZone("46T").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm46);
            new UtmZones.UtmZone("47U").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm47);
            new UtmZones.UtmZone("48V").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm48);
            new UtmZones.UtmZone("49W").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm49);
            new UtmZones.UtmZone("50X").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm50);

            new UtmZones.UtmZone("51Y").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm51);
            new UtmZones.UtmZone("52Z").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm52);
            new UtmZones.UtmZone("53a").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm53);
            new UtmZones.UtmZone("54b").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm54);
            new UtmZones.UtmZone("55c").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm55);
            new UtmZones.UtmZone("56d").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm56);
            new UtmZones.UtmZone("57e").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm57);
            new UtmZones.UtmZone("58f").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm58);
            new UtmZones.UtmZone("59g").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm59);
            new UtmZones.UtmZone("60h").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm60);
        }

        [Fact]
        public void TestGetLatitudinalZoneFromZoneString()
        {
            new UtmNsZones.UtmNsZone("1north").LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.North);
            new UtmNsZones.UtmNsZone("2South").LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.South);
            new UtmZones.UtmZone("3a").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmA);
            new UtmZones.UtmZone("4b").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmB);
            new UtmZones.UtmZone("5c").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmC);
            new UtmZones.UtmZone("6d").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmD);
            new UtmZones.UtmZone("7e").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmE);
            new UtmZones.UtmZone("8f").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmF);
            new UtmZones.UtmZone("9g").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmG);
            new UtmZones.UtmZone("10h").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmH);
            new UtmZones.UtmZone("11J").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmJ);
            new UtmZones.UtmZone("12k").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmK);
            new UtmZones.UtmZone("13l").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmL);
            new UtmZones.UtmZone("14m").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmM);
            new UtmZones.UtmZone("15n").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmN);
            new UtmZones.UtmZone("16p").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmP);
            new UtmZones.UtmZone("17q").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmQ);
            new UtmZones.UtmZone("18r").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmR);
            new UtmZones.UtmZone("19s").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmS);
            new UtmZones.UtmZone("20t").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmT);
            new UtmZones.UtmZone("21u").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmU);
            new UtmZones.UtmZone("22v").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmV);
            new UtmZones.UtmZone("23w").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmW);
            new UtmZones.UtmZone("24x").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmX);
            new UtmZones.UtmZone("25y").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmY);
            new UtmZones.UtmZone("26z").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmZ);
        }

        [Fact]
        public void TestGetLongitudinalZoneFromLongitudinalZoneString()
        {
            new UtmNsZones.UtmNsZone("1", "North").LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm01);
            new UtmZones.UtmZone("2", "N").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm02);
            new UtmNsZones.UtmNsZone("3", "North").LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm03);
            new UtmZones.UtmZone("4", "N").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm04);
            new UtmNsZones.UtmNsZone("5", "North").LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm05);
            new UtmZones.UtmZone("6", "N").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm06);
            new UtmNsZones.UtmNsZone("7", "North").LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm07);
            new UtmZones.UtmZone("8", "N").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm08);
            new UtmNsZones.UtmNsZone("9", "North").LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm09);
            new UtmZones.UtmZone("10", "N").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm10);

            new UtmNsZones.UtmNsZone("11", "North").LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm11);
            new UtmZones.UtmZone("12", "N").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm12);
            new UtmNsZones.UtmNsZone("13", "North").LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm13);
            new UtmZones.UtmZone("14", "N").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm14);
            new UtmNsZones.UtmNsZone("15", "North").LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm15);
            new UtmZones.UtmZone("16", "N").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm16);
            new UtmNsZones.UtmNsZone("17", "North").LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm17);
            new UtmZones.UtmZone("18", "N").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm18);
            new UtmNsZones.UtmNsZone("19", "North").LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm19);
            new UtmZones.UtmZone("20", "N").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm20);

            new UtmNsZones.UtmNsZone("21", "North").LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm21);
            new UtmZones.UtmZone("22", "N").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm22);
            new UtmNsZones.UtmNsZone("23", "North").LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm23);
            new UtmZones.UtmZone("24", "N").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm24);
            new UtmNsZones.UtmNsZone("25", "North").LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm25);
            new UtmZones.UtmZone("26", "N").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm26);
            new UtmNsZones.UtmNsZone("27", "North").LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm27);
            new UtmZones.UtmZone("28", "N").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm28);
            new UtmNsZones.UtmNsZone("29", "North").LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm29);
            new UtmZones.UtmZone("30", "N").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm30);

            new UtmNsZones.UtmNsZone("31", "North").LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm31);
            new UtmZones.UtmZone("32", "N").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm32);
            new UtmNsZones.UtmNsZone("33", "North").LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm33);
            new UtmZones.UtmZone("34", "N").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm34);
            new UtmNsZones.UtmNsZone("35", "North").LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm35);
            new UtmZones.UtmZone("36", "N").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm36);
            new UtmNsZones.UtmNsZone("37", "North").LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm37);
            new UtmZones.UtmZone("38", "N").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm38);
            new UtmNsZones.UtmNsZone("39", "North").LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm39);
            new UtmZones.UtmZone("40", "N").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm40);

            new UtmNsZones.UtmNsZone("41", "North").LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm41);
            new UtmZones.UtmZone("42", "N").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm42);
            new UtmNsZones.UtmNsZone("43", "North").LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm43);
            new UtmZones.UtmZone("44", "N").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm44);
            new UtmNsZones.UtmNsZone("45", "North").LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm45);
            new UtmZones.UtmZone("46", "N").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm46);
            new UtmNsZones.UtmNsZone("47", "North").LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm47);
            new UtmZones.UtmZone("48", "N").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm48);
            new UtmNsZones.UtmNsZone("49", "North").LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm49);
            new UtmZones.UtmZone("50", "N").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm50);

            new UtmNsZones.UtmNsZone("51", "North").LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm51);
            new UtmZones.UtmZone("52", "N").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm52);
            new UtmNsZones.UtmNsZone("53", "North").LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm53);
            new UtmZones.UtmZone("54", "N").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm54);
            new UtmNsZones.UtmNsZone("55", "North").LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm55);
            new UtmZones.UtmZone("56", "N").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm56);
            new UtmNsZones.UtmNsZone("57", "North").LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm57);
            new UtmZones.UtmZone("58", "N").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm58);
            new UtmNsZones.UtmNsZone("59", "North").LongitudinalZone.Should().Be(UtmNsZones.LongitudinalZone.Utm59);
            new UtmZones.UtmZone("60", "N").LongitudinalZone.Should().Be(UtmZones.LongitudinalZone.Utm60);
        }

        [Fact]
        public void TestGetLatitudinalZoneFromLatitudinalZoneString()
        {
            new UtmNsZones.UtmNsZone("30", "north").LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.North);
            new UtmNsZones.UtmNsZone("30", "South").LatitudinalZone.Should().Be(UtmNsZones.LatitudinalZone.South);
            new UtmZones.UtmZone("30", "a").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmA);
            new UtmZones.UtmZone("30", "b").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmB);
            new UtmZones.UtmZone("30", "c").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmC);
            new UtmZones.UtmZone("30", "d").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmD);
            new UtmZones.UtmZone("30", "e").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmE);
            new UtmZones.UtmZone("30", "f").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmF);
            new UtmZones.UtmZone("30", "g").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmG);
            new UtmZones.UtmZone("30", "h").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmH);
            new UtmZones.UtmZone("30", "J").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmJ);
            new UtmZones.UtmZone("30", "k").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmK);
            new UtmZones.UtmZone("30", "l").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmL);
            new UtmZones.UtmZone("30", "m").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmM);
            new UtmZones.UtmZone("30", "n").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmN);
            new UtmZones.UtmZone("30", "p").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmP);
            new UtmZones.UtmZone("30", "q").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmQ);
            new UtmZones.UtmZone("30", "r").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmR);
            new UtmZones.UtmZone("30", "s").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmS);
            new UtmZones.UtmZone("30", "t").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmT);
            new UtmZones.UtmZone("30", "u").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmU);
            new UtmZones.UtmZone("30", "v").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmV);
            new UtmZones.UtmZone("30", "w").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmW);
            new UtmZones.UtmZone("30", "x").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmX);
            new UtmZones.UtmZone("30", "y").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmY);
            new UtmZones.UtmZone("30", "z").LatitudinalZone.Should().Be(UtmZones.LatitudinalZone.UtmZ);
        }
    }
}


