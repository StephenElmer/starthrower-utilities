// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using AwesomeAssertions;
using StarThrower.Gis.GeoUtilities;
using StarThrower.Gis.GeoUtilities.CoordinateSystems.Projected;
using Xunit;

namespace StarThrower.Gis.GeoUtilities.Test
{
    public class ZonedCoordinateSystemTest
    {
        // These tests verify the IZonedCoordinateSystem interface introduced to replace
        // the dynamic duck-typing pattern that was previously used in GeoUtil.cs.

        [Fact]
        public void UtmWgs84ImplementsIZonedCoordinateSystem()
        {
            IProjectedCoordinateSystem cs = ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84));
            cs.Should().BeAssignableTo<IZonedCoordinateSystem>();
        }

        [Fact]
        public void UtmWgs84NsImplementsIZonedCoordinateSystem()
        {
            IProjectedCoordinateSystem cs = ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns));
            cs.Should().BeAssignableTo<IZonedCoordinateSystem>();
        }

        [Fact]
        public void UtmWgs72ImplementsIZonedCoordinateSystem()
        {
            IProjectedCoordinateSystem cs = ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72));
            cs.Should().BeAssignableTo<IZonedCoordinateSystem>();
        }

        [Fact]
        public void UtmWgs72NsImplementsIZonedCoordinateSystem()
        {
            IProjectedCoordinateSystem cs = ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns));
            cs.Should().BeAssignableTo<IZonedCoordinateSystem>();
        }

        [Fact]
        public void UtmWgs84ZoneAccessibleViaInterface()
        {
            IProjectedCoordinateSystem cs = ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84));
            IZone? zone = (cs as IZonedCoordinateSystem)?.Zone;
            // Default (no-zone) instance has an UndefinedZone, not null
            zone.Should().NotBeNull();
        }

        [Fact]
        public void NonUtmProjectedCoordinateSystemDoesNotImplementIZonedCoordinateSystem()
        {
            IProjectedCoordinateSystem cs = ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(MercatorWgs84));
            (cs as IZonedCoordinateSystem).Should().BeNull();
        }
    }
}


