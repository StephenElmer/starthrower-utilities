// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarThrower.Gis.GeoUtilities;
using StarThrower.Gis.GeoUtilities.CoordinateSystems.Projected;

namespace StarThrower.Gis.GeoUtilities.Test
{
    [TestClass]
    public class ZonedCoordinateSystemTest
    {
        // These tests verify the IZonedCoordinateSystem interface introduced to replace
        // the dynamic duck-typing pattern that was previously used in GeoUtil.cs.

        [TestMethod]
        public void UtmWgs84ImplementsIZonedCoordinateSystem()
        {
            IProjectedCoordinateSystem cs = ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84));
            Assert.IsInstanceOfType<IZonedCoordinateSystem>(cs);
        }

        [TestMethod]
        public void UtmWgs84NsImplementsIZonedCoordinateSystem()
        {
            IProjectedCoordinateSystem cs = ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns));
            Assert.IsInstanceOfType<IZonedCoordinateSystem>(cs);
        }

        [TestMethod]
        public void UtmWgs72ImplementsIZonedCoordinateSystem()
        {
            IProjectedCoordinateSystem cs = ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72));
            Assert.IsInstanceOfType<IZonedCoordinateSystem>(cs);
        }

        [TestMethod]
        public void UtmWgs72NsImplementsIZonedCoordinateSystem()
        {
            IProjectedCoordinateSystem cs = ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns));
            Assert.IsInstanceOfType<IZonedCoordinateSystem>(cs);
        }

        [TestMethod]
        public void UtmWgs84ZoneAccessibleViaInterface()
        {
            IProjectedCoordinateSystem cs = ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84));
            IZone? zone = (cs as IZonedCoordinateSystem)?.Zone;
            // Default (no-zone) instance has an UndefinedZone, not null
            Assert.IsNotNull(zone);
        }

        [TestMethod]
        public void NonUtmProjectedCoordinateSystemDoesNotImplementIZonedCoordinateSystem()
        {
            IProjectedCoordinateSystem cs = ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(MercatorWgs84));
            Assert.IsNull(cs as IZonedCoordinateSystem);
        }
    }
}


