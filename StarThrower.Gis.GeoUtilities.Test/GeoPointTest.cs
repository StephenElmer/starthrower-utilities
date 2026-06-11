// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using AwesomeAssertions;
using StarThrower.Gis.GeoUtilities;
using StarThrower.Gis.GeoUtilities.Exceptions;
using Xunit;

namespace StarThrower.Gis.GeoUtilities.Test
{
    public class GeoPointTest
    {
        [Fact]
        public void TestConstruction()
        {
            GeoPoint p1 = new GeoPoint();
            GeoPoint p2 = new GeoPoint(1, 2);
            GeoPoint p3 = new GeoPoint(p2);

            p1.Should().NotBeNull();
            p2.Should().NotBeNull();
            p3.Should().NotBeNull();

            p1.ToString().Should().Be("[GeoPoint:  x=0, y=0]");
            p2.ToString().Should().Be("[GeoPoint:  x=1, y=2]");
            p3.ToString().Should().Be("[GeoPoint:  x=1, y=2]");
            p2.Should().Be(p3);
            p2.Should().NotBeSameAs(p3);
        }

        [Fact]
        public void TestClone()
        {
            GeoPoint p1 = new GeoPoint(1, 2);
            GeoPoint p2 = (GeoPoint)p1.Clone();

            p1.Should().Be(p2);
            p1.Should().NotBeSameAs(p2);
        }

        [Fact]
        public void TestItemCopy()
        {
            GeoPoint p1 = new GeoPoint(1, 2);
            GeoPoint p2 = new GeoPoint();
            p2.ItemCopy(p1);

            p1.Should().Be(p2);
        }

        [Fact]
        public void TestItemCopyArgument()
        {
            GeoPoint p = new GeoPoint();
            System.Version sv = new System.Version("1.0.1.2");
            Action act = () => p.ItemCopy(sv);
            act.Should().Throw<FailedItemCopyException>();
        }

        [Fact]
        public void TestEquals()
        {
            GeoPoint p1 = new GeoPoint(1, 2);
            GeoPoint p2 = new GeoPoint(1, 2);
            GeoPoint p3 = new GeoPoint(2, 3);

            p1.Should().Be(p2);
            p1.Should().NotBe(p3);
            p1.Should().Be(p1);
        }

        [Fact]
        public void TestGetHashCode()
        {
            GeoPoint p1 = new GeoPoint();
            GeoPoint p2 = new GeoPoint(1, 2);
            GeoPoint p3 = new GeoPoint(2, 3);

            p1.GetHashCode().Should().Be(31 * (31 * 17 + p1.xLon.GetHashCode()) + p1.yLat.GetHashCode());
            p2.GetHashCode().Should().Be(31 * (31 * 17 + p2.xLon.GetHashCode()) + p2.yLat.GetHashCode());
            p3.GetHashCode().Should().Be(31 * (31 * 17 + p3.xLon.GetHashCode()) + p3.yLat.GetHashCode());
        }

        [Fact]
        public void TestToString()
        {
            GeoPoint p1 = new GeoPoint();
            GeoPoint p2 = new GeoPoint(1, 2);
            GeoPoint p3 = new GeoPoint(p2);

            p1.ToString().Should().Be("[GeoPoint:  x=" + 0 + ", y=" + 0 + "]");
            p2.ToString().Should().Be("[GeoPoint:  x=" + 1 + ", y=" + 2 + "]");
            p3.ToString().Should().Be("[GeoPoint:  x=" + 1 + ", y=" + 2 + "]");
        }
    }
}


