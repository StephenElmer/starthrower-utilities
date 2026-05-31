/***********************************************************************************
    StarThrower Utilities
    Copyright (C) 2005-2007  Steve Elmer

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
        public void UtmWgs84_ImplementsIZonedCoordinateSystem()
        {
            IProjectedCoordinateSystem cs = ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84));
            Assert.IsInstanceOfType(cs, typeof(IZonedCoordinateSystem));
        }

        [TestMethod]
        public void UtmWgs84Ns_ImplementsIZonedCoordinateSystem()
        {
            IProjectedCoordinateSystem cs = ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns));
            Assert.IsInstanceOfType(cs, typeof(IZonedCoordinateSystem));
        }

        [TestMethod]
        public void UtmWgs72_ImplementsIZonedCoordinateSystem()
        {
            IProjectedCoordinateSystem cs = ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72));
            Assert.IsInstanceOfType(cs, typeof(IZonedCoordinateSystem));
        }

        [TestMethod]
        public void UtmWgs72Ns_ImplementsIZonedCoordinateSystem()
        {
            IProjectedCoordinateSystem cs = ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns));
            Assert.IsInstanceOfType(cs, typeof(IZonedCoordinateSystem));
        }

        [TestMethod]
        public void UtmWgs84_ZoneAccessibleViaInterface()
        {
            IProjectedCoordinateSystem cs = ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84));
            IZone? zone = (cs as IZonedCoordinateSystem)?.Zone;
            // Default (no-zone) instance has an UndefinedZone, not null
            Assert.IsNotNull(zone);
        }

        [TestMethod]
        public void NonUtmProjectedCoordinateSystem_DoesNotImplementIZonedCoordinateSystem()
        {
            IProjectedCoordinateSystem cs = ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(MercatorWgs84));
            Assert.IsNull(cs as IZonedCoordinateSystem);
        }
    }
}
