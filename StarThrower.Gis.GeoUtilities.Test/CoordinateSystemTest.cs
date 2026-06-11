// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using AwesomeAssertions;
using StarThrower.Gis.GeoUtilities.CoordinateSystems;
using StarThrower.Gis.GeoUtilities.CoordinateSystems.Geographic;
using StarThrower.Gis.GeoUtilities.Exceptions;
using Xunit;

namespace StarThrower.Gis.GeoUtilities.Test
{
    public class CoordinateSystemTest
    {
        #region Instantiation Tests

        [Fact]
        public void TestSingleInstanceOfNad27()
        {
            IGeographicCoordinateSystem c1 = GeographicCoordinateSystemFactory.GetInstanceOfGeographicCoordinateSystem(typeof(GeodeticNad27));
            IGeographicCoordinateSystem c2 = GeographicCoordinateSystemFactory.GetInstanceOfGeographicCoordinateSystem(typeof(GeodeticNad27));
            c1.Should().BeSameAs(c2);
        }

        [Fact]
        public void TestSingleInstanceOfNad83()
        {
            IGeographicCoordinateSystem c1 = GeographicCoordinateSystemFactory.GetInstanceOfGeographicCoordinateSystem(typeof(GeodeticNad83));
            IGeographicCoordinateSystem c2 = GeographicCoordinateSystemFactory.GetInstanceOfGeographicCoordinateSystem(typeof(GeodeticNad83));
            c1.Should().BeSameAs(c2);
        }

        [Fact]
        public void TestSingleInstanceOfWgs84()
        {
            IGeographicCoordinateSystem c1 = GeographicCoordinateSystemFactory.GetInstanceOfGeographicCoordinateSystem(typeof(GeodeticWgs84));
            IGeographicCoordinateSystem c2 = GeographicCoordinateSystemFactory.GetInstanceOfGeographicCoordinateSystem(typeof(GeodeticWgs84));
            c1.Should().BeSameAs(c2);
        }

        [Fact]
        public void TestUndefinedThrowsException()
        {
            Action act = () => GeographicCoordinateSystemFactory.GetInstanceOfGeographicCoordinateSystem(typeof(Undefined));
            act.Should().Throw<InvalidCoordinateSystemException>();
        }

        #endregion
    }
}


