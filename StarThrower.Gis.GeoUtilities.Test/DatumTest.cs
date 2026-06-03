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
using StarThrower.Gis.GeoUtilities.Datums;
using StarThrower.Gis.GeoUtilities.Ellipsoids;
using StarThrower.Gis.GeoUtilities.Exceptions;
using System.Globalization;

namespace StarThrower.Gis.GeoUtilities.Test
{
    [TestClass]
    public class DatumTest
    {
        private static void Ignore()
        {
            #if FAIL_ON_IGNORE
                Assert.Fail("This test has been ignored.");
            #else
                Assert.Inconclusive("this test has been ignored");
            #endif
        }


        #region Non-UserDefined Instantiation

        [TestMethod]
        public void TestGetInstanceOfDatumDEuropean1950()
        {
            Type datumType = typeof(Datums.European1950);
            Type ellipsoidType = typeof(Ellipsoids.International1924);
            double deltaX = -102.0;
            double sigmaX = 0.0;
            double deltaY = -102.0;
            double sigmaY = 0.0;
            double deltaZ = -129.0;
            double sigmaZ = 0.0;
            double rotationX = 0.413;
            double rotationY = -0.184;
            double rotationZ = 0.385;
            double rotationScaleFactor = 0.0000024664;
            double north = 90.0;
            double south = -90.0;
            double east = 180.0;
            double west = -180.0;

            IDatum d = DatumFactory.GetInstanceOfDatum(datumType);
            Assert.IsNotNull(d);
            Assert.AreEqual(datumType.Name, d.GetType().Name);
            Assert.AreEqual(datumType.Name, d.Name);
            Assert.AreEqual(datumType.Name, d.Key);
            Assert.AreEqual(EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType), d.Ellipsoid);
            Assert.AreEqual(deltaX, d.DeltaX);
            Assert.AreEqual(sigmaX, d.SigmaX);
            Assert.AreEqual(deltaY, d.DeltaY);
            Assert.AreEqual(sigmaY, d.SigmaY);
            Assert.AreEqual(deltaZ, d.DeltaZ);
            Assert.AreEqual(sigmaZ, d.SigmaZ);
            Assert.AreEqual(rotationX, d.RotationX);
            Assert.AreEqual(rotationY, d.RotationY);
            Assert.AreEqual(rotationZ, d.RotationZ);
            Assert.AreEqual(rotationScaleFactor, d.RotationScaleFactor);
            Assert.AreEqual(north, d.Domain.Top);
            Assert.AreEqual(south, d.Domain.Bottom);
            Assert.AreEqual(east, d.Domain.Right);
            Assert.AreEqual(west, d.Domain.Left);
            Assert.AreEqual("[" + datumType.Name + ":  " +
                            "Ellipsoid=" + ellipsoidType.Name +
                            ", DeltaX=" + deltaX.ToString(CultureInfo.InvariantCulture) +
                            ", SigmaX=" + sigmaX.ToString(CultureInfo.InvariantCulture) +
                            ", DeltaY=" + deltaY.ToString(CultureInfo.InvariantCulture) +
                            ", SigmaY=" + sigmaY.ToString(CultureInfo.InvariantCulture) +
                            ", DeltaZ=" + deltaZ.ToString(CultureInfo.InvariantCulture) +
                            ", SigmaZ=" + sigmaZ.ToString(CultureInfo.InvariantCulture) +
                            ", RotationX=" + rotationX.ToString(CultureInfo.InvariantCulture) +
                            ", RotationY=" + rotationY.ToString(CultureInfo.InvariantCulture) +
                            ", RotationZ=" + rotationZ.ToString(CultureInfo.InvariantCulture) +
                            ", RotationScaleFactor=" + rotationScaleFactor.ToString(CultureInfo.InvariantCulture) +
                            ", " + d.Domain.ToString() + "]", d.ToString());
            Assert.AreEqual("<datum datumType=\"" + datumType.Name + "\" deltaX=\"" + deltaX.ToString(CultureInfo.InvariantCulture) + "\" sigmaX=\"" + sigmaX.ToString(CultureInfo.InvariantCulture) + "\" deltaY=\"" + deltaY.ToString(CultureInfo.InvariantCulture) + "\" sigmaY=\"" + sigmaY.ToString(CultureInfo.InvariantCulture) + "\" deltaZ=\"" + deltaZ.ToString(CultureInfo.InvariantCulture) + "\" sigmaZ=\"" + sigmaZ.ToString(CultureInfo.InvariantCulture) + "\" rotationX=\"" + rotationX.ToString(CultureInfo.InvariantCulture) + "\" rotationY=\"" + rotationY.ToString(CultureInfo.InvariantCulture) + "\" rotationZ=\"" + rotationZ.ToString(CultureInfo.InvariantCulture) + "\" rotationScaleFactor=\"" + rotationScaleFactor.ToString(CultureInfo.InvariantCulture) + "\" north=\"" + north.ToString(CultureInfo.InvariantCulture) + "\" south=\"" + south.ToString(CultureInfo.InvariantCulture) + "\" east=\"" + east.ToString(CultureInfo.InvariantCulture) + "\" west=\"" + west.ToString(CultureInfo.InvariantCulture) + "\">\n" +
                            EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType).ToXml() +
                            "</datum>\n", d.ToXml());

        }

        [TestMethod]
        public void TestGetInstanceOfDatumDNorthAmerican1927()
        {
            Type datumType = typeof(Datums.Nad1927Conus);
            Type ellipsoidType = typeof(Ellipsoids.Clarke1866);
            double deltaX = -8.0;
            double sigmaX = 5.0;
            double deltaY = 160.0;
            double sigmaY = 5.0;
            double deltaZ = 176.0;
            double sigmaZ = 6.0;
            double rotationX = 0.0;
            double rotationY = 0.0;
            double rotationZ = 0.0;
            double rotationScaleFactor = 1.0;
            double north = 60.0;
            double south = 15.0;
            double east = -60.0;
            double west = -135.0;

            IDatum d = DatumFactory.GetInstanceOfDatum(datumType);
            Assert.IsNotNull(d);
            Assert.AreEqual(datumType.Name, d.GetType().Name);
            Assert.AreEqual(datumType.Name, d.Name);
            Assert.AreEqual(datumType.Name, d.Key);
            Assert.AreEqual(EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType), d.Ellipsoid);
            Assert.AreEqual(deltaX, d.DeltaX);
            Assert.AreEqual(sigmaX, d.SigmaX);
            Assert.AreEqual(deltaY, d.DeltaY);
            Assert.AreEqual(sigmaY, d.SigmaY);
            Assert.AreEqual(deltaZ, d.DeltaZ);
            Assert.AreEqual(sigmaZ, d.SigmaZ);
            Assert.AreEqual(rotationX, d.RotationX);
            Assert.AreEqual(rotationY, d.RotationY);
            Assert.AreEqual(rotationZ, d.RotationZ);
            Assert.AreEqual(rotationScaleFactor, d.RotationScaleFactor);
            Assert.AreEqual(north, d.Domain.Top);
            Assert.AreEqual(south, d.Domain.Bottom);
            Assert.AreEqual(east, d.Domain.Right);
            Assert.AreEqual(west, d.Domain.Left);
            Assert.AreEqual("[" + datumType.Name + ":  " +
                            "Ellipsoid=" + ellipsoidType.Name +
                            ", DeltaX=" + deltaX.ToString(CultureInfo.InvariantCulture) +
                            ", SigmaX=" + sigmaX.ToString(CultureInfo.InvariantCulture) +
                            ", DeltaY=" + deltaY.ToString(CultureInfo.InvariantCulture) +
                            ", SigmaY=" + sigmaY.ToString(CultureInfo.InvariantCulture) +
                            ", DeltaZ=" + deltaZ.ToString(CultureInfo.InvariantCulture) +
                            ", SigmaZ=" + sigmaZ.ToString(CultureInfo.InvariantCulture) +
                            ", RotationX=" + rotationX.ToString(CultureInfo.InvariantCulture) +
                            ", RotationY=" + rotationY.ToString(CultureInfo.InvariantCulture) +
                            ", RotationZ=" + rotationZ.ToString(CultureInfo.InvariantCulture) +
                            ", RotationScaleFactor=" + rotationScaleFactor.ToString(CultureInfo.InvariantCulture) +
                            ", " + d.Domain.ToString() + "]", d.ToString());
            Assert.AreEqual("<datum datumType=\"" + datumType.Name + "\" deltaX=\"" + deltaX.ToString(CultureInfo.InvariantCulture) + "\" sigmaX=\"" + sigmaX.ToString(CultureInfo.InvariantCulture) + "\" deltaY=\"" + deltaY.ToString(CultureInfo.InvariantCulture) + "\" sigmaY=\"" + sigmaY.ToString(CultureInfo.InvariantCulture) + "\" deltaZ=\"" + deltaZ.ToString(CultureInfo.InvariantCulture) + "\" sigmaZ=\"" + sigmaZ.ToString(CultureInfo.InvariantCulture) + "\" rotationX=\"" + rotationX.ToString(CultureInfo.InvariantCulture) + "\" rotationY=\"" + rotationY.ToString(CultureInfo.InvariantCulture) + "\" rotationZ=\"" + rotationZ.ToString(CultureInfo.InvariantCulture) + "\" rotationScaleFactor=\"" + rotationScaleFactor.ToString(CultureInfo.InvariantCulture) + "\" north=\"" + north.ToString(CultureInfo.InvariantCulture) + "\" south=\"" + south.ToString(CultureInfo.InvariantCulture) + "\" east=\"" + east.ToString(CultureInfo.InvariantCulture) + "\" west=\"" + west.ToString(CultureInfo.InvariantCulture) + "\">\n" +
                            EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType).ToXml() +
                            "</datum>\n", d.ToXml());
        }

        [TestMethod]
        public void TestGetInstanceOfDatumDNorthAmerican1983()
        {
            Type datumType = typeof(Datums.Nad1983Conus);
            Type ellipsoidType = typeof(Ellipsoids.Grs1980);
            double deltaX = 0.0;
            double sigmaX = 2.0;
            double deltaY = 0.0;
            double sigmaY = 2.0;
            double deltaZ = 0.0;
            double sigmaZ = 2.0;
            double rotationX = 0.0;
            double rotationY = 0.0;
            double rotationZ = 0.0;
            double rotationScaleFactor = 1.0;
            double north = 60.0;
            double south = 15.0;
            double east = -60.0;
            double west = -135.0;

            IDatum d = DatumFactory.GetInstanceOfDatum(datumType);
            Assert.IsNotNull(d);
            Assert.AreEqual(datumType.Name, d.GetType().Name);
            Assert.AreEqual(datumType.Name, d.Name);
            Assert.AreEqual(datumType.Name, d.Key);
            Assert.AreEqual(EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType), d.Ellipsoid);
            Assert.AreEqual(deltaX, d.DeltaX);
            Assert.AreEqual(sigmaX, d.SigmaX);
            Assert.AreEqual(deltaY, d.DeltaY);
            Assert.AreEqual(sigmaY, d.SigmaY);
            Assert.AreEqual(deltaZ, d.DeltaZ);
            Assert.AreEqual(sigmaZ, d.SigmaZ);
            Assert.AreEqual(rotationX, d.RotationX);
            Assert.AreEqual(rotationY, d.RotationY);
            Assert.AreEqual(rotationZ, d.RotationZ);
            Assert.AreEqual(rotationScaleFactor, d.RotationScaleFactor);
            Assert.AreEqual(north, d.Domain.Top);
            Assert.AreEqual(south, d.Domain.Bottom);
            Assert.AreEqual(east, d.Domain.Right);
            Assert.AreEqual(west, d.Domain.Left);
            Assert.AreEqual("[" + datumType.Name + ":  " +
                            "Ellipsoid=" + ellipsoidType.Name +
                            ", DeltaX=" + deltaX.ToString(CultureInfo.InvariantCulture) +
                            ", SigmaX=" + sigmaX.ToString(CultureInfo.InvariantCulture) +
                            ", DeltaY=" + deltaY.ToString(CultureInfo.InvariantCulture) +
                            ", SigmaY=" + sigmaY.ToString(CultureInfo.InvariantCulture) +
                            ", DeltaZ=" + deltaZ.ToString(CultureInfo.InvariantCulture) +
                            ", SigmaZ=" + sigmaZ.ToString(CultureInfo.InvariantCulture) +
                            ", RotationX=" + rotationX.ToString(CultureInfo.InvariantCulture) +
                            ", RotationY=" + rotationY.ToString(CultureInfo.InvariantCulture) +
                            ", RotationZ=" + rotationZ.ToString(CultureInfo.InvariantCulture) +
                            ", RotationScaleFactor=" + rotationScaleFactor.ToString(CultureInfo.InvariantCulture) +
                            ", " + d.Domain.ToString() + "]", d.ToString());
            Assert.AreEqual("<datum datumType=\"" + datumType.Name + "\" deltaX=\"" + deltaX.ToString(CultureInfo.InvariantCulture) + "\" sigmaX=\"" + sigmaX.ToString(CultureInfo.InvariantCulture) + "\" deltaY=\"" + deltaY.ToString(CultureInfo.InvariantCulture) + "\" sigmaY=\"" + sigmaY.ToString(CultureInfo.InvariantCulture) + "\" deltaZ=\"" + deltaZ.ToString(CultureInfo.InvariantCulture) + "\" sigmaZ=\"" + sigmaZ.ToString(CultureInfo.InvariantCulture) + "\" rotationX=\"" + rotationX.ToString(CultureInfo.InvariantCulture) + "\" rotationY=\"" + rotationY.ToString(CultureInfo.InvariantCulture) + "\" rotationZ=\"" + rotationZ.ToString(CultureInfo.InvariantCulture) + "\" rotationScaleFactor=\"" + rotationScaleFactor.ToString(CultureInfo.InvariantCulture) + "\" north=\"" + north.ToString(CultureInfo.InvariantCulture) + "\" south=\"" + south.ToString(CultureInfo.InvariantCulture) + "\" east=\"" + east.ToString(CultureInfo.InvariantCulture) + "\" west=\"" + west.ToString(CultureInfo.InvariantCulture) + "\">\n" +
                            EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType).ToXml() +
                            "</datum>\n", d.ToXml());
        }

        [TestMethod]
        public void TestGetInstanceOfDatumDOSGBB1936()
        {
            Type datumType = typeof(Datums.Osgb1936);
            Type ellipsoidType = typeof(Ellipsoids.Airy1830);
            double deltaX = 446.0;
            double sigmaX = 0.0;
            double deltaY = -99.0;
            double sigmaY = 0.0;
            double deltaZ = 544.0;
            double sigmaZ = 0.0;
            double rotationX = -0.945;
            double rotationY = -0.261;
            double rotationZ = -0.435;
            double rotationScaleFactor = -0.0000208927;
            double north = 90.0;
            double south = -90.0;
            double east = 180.0;
            double west = -180.0;

            IDatum d = DatumFactory.GetInstanceOfDatum(datumType);
            Assert.IsNotNull(d);
            Assert.AreEqual(datumType.Name, d.GetType().Name);
            Assert.AreEqual(datumType.Name, d.Name);
            Assert.AreEqual(datumType.Name, d.Key);
            Assert.AreEqual(EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType), d.Ellipsoid);
            Assert.AreEqual(deltaX, d.DeltaX);
            Assert.AreEqual(sigmaX, d.SigmaX);
            Assert.AreEqual(deltaY, d.DeltaY);
            Assert.AreEqual(sigmaY, d.SigmaY);
            Assert.AreEqual(deltaZ, d.DeltaZ);
            Assert.AreEqual(sigmaZ, d.SigmaZ);
            Assert.AreEqual(rotationX, d.RotationX);
            Assert.AreEqual(rotationY, d.RotationY);
            Assert.AreEqual(rotationZ, d.RotationZ);
            Assert.AreEqual(rotationScaleFactor, d.RotationScaleFactor);
            Assert.AreEqual(north, d.Domain.Top);
            Assert.AreEqual(south, d.Domain.Bottom);
            Assert.AreEqual(east, d.Domain.Right);
            Assert.AreEqual(west, d.Domain.Left);
            Assert.AreEqual("[" + datumType.Name + ":  " +
                            "Ellipsoid=" + ellipsoidType.Name +
                            ", DeltaX=" + deltaX.ToString(CultureInfo.InvariantCulture) +
                            ", SigmaX=" + sigmaX.ToString(CultureInfo.InvariantCulture) +
                            ", DeltaY=" + deltaY.ToString(CultureInfo.InvariantCulture) +
                            ", SigmaY=" + sigmaY.ToString(CultureInfo.InvariantCulture) +
                            ", DeltaZ=" + deltaZ.ToString(CultureInfo.InvariantCulture) +
                            ", SigmaZ=" + sigmaZ.ToString(CultureInfo.InvariantCulture) +
                            ", RotationX=" + rotationX.ToString(CultureInfo.InvariantCulture) +
                            ", RotationY=" + rotationY.ToString(CultureInfo.InvariantCulture) +
                            ", RotationZ=" + rotationZ.ToString(CultureInfo.InvariantCulture) +
                            ", RotationScaleFactor=" + rotationScaleFactor.ToString(CultureInfo.InvariantCulture) +
                            ", " + d.Domain.ToString() + "]", d.ToString());
            Assert.AreEqual("<datum datumType=\"" + datumType.Name + "\" deltaX=\"" + deltaX.ToString(CultureInfo.InvariantCulture) + "\" sigmaX=\"" + sigmaX.ToString(CultureInfo.InvariantCulture) + "\" deltaY=\"" + deltaY.ToString(CultureInfo.InvariantCulture) + "\" sigmaY=\"" + sigmaY.ToString(CultureInfo.InvariantCulture) + "\" deltaZ=\"" + deltaZ.ToString(CultureInfo.InvariantCulture) + "\" sigmaZ=\"" + sigmaZ.ToString(CultureInfo.InvariantCulture) + "\" rotationX=\"" + rotationX.ToString(CultureInfo.InvariantCulture) + "\" rotationY=\"" + rotationY.ToString(CultureInfo.InvariantCulture) + "\" rotationZ=\"" + rotationZ.ToString(CultureInfo.InvariantCulture) + "\" rotationScaleFactor=\"" + rotationScaleFactor.ToString(CultureInfo.InvariantCulture) + "\" north=\"" + north.ToString(CultureInfo.InvariantCulture) + "\" south=\"" + south.ToString(CultureInfo.InvariantCulture) + "\" east=\"" + east.ToString(CultureInfo.InvariantCulture) + "\" west=\"" + west.ToString(CultureInfo.InvariantCulture) + "\">\n" +
                            EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType).ToXml() +
                            "</datum>\n", d.ToXml());
        }

        [TestMethod]
        public void TestGetInstanceOfDatumDWGS1972()
        {
            Type datumType = typeof(Datums.Wgs1972);
            Type ellipsoidType = typeof(Ellipsoids.Wgs1972);
            double deltaX = 0.0;
            double sigmaX = 0.0;
            double deltaY = 0.0;
            double sigmaY = 0.0;
            double deltaZ = 0.0;
            double sigmaZ = 0.0;
            double rotationX = 0.0;
            double rotationY = 0.0;
            double rotationZ = 0.0;
            double rotationScaleFactor = 1.0;
            double north = 90.0;
            double south = -90.0;
            double east = 180.0;
            double west = -180.0;

            IDatum d = DatumFactory.GetInstanceOfDatum(datumType);
            Assert.IsNotNull(d);
            Assert.AreEqual(datumType.Name, d.GetType().Name);
            Assert.AreEqual(datumType.Name, d.Name);
            Assert.AreEqual(datumType.Name, d.Key);
            Assert.AreEqual(EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType), d.Ellipsoid);
            Assert.AreEqual(deltaX, d.DeltaX);
            Assert.AreEqual(sigmaX, d.SigmaX);
            Assert.AreEqual(deltaY, d.DeltaY);
            Assert.AreEqual(sigmaY, d.SigmaY);
            Assert.AreEqual(deltaZ, d.DeltaZ);
            Assert.AreEqual(sigmaZ, d.SigmaZ);
            Assert.AreEqual(rotationX, d.RotationX);
            Assert.AreEqual(rotationY, d.RotationY);
            Assert.AreEqual(rotationZ, d.RotationZ);
            Assert.AreEqual(rotationScaleFactor, d.RotationScaleFactor);
            Assert.AreEqual(north, d.Domain.Top);
            Assert.AreEqual(south, d.Domain.Bottom);
            Assert.AreEqual(east, d.Domain.Right);
            Assert.AreEqual(west, d.Domain.Left);
            Assert.AreEqual("[" + datumType.Name + ":  " +
                            "Ellipsoid=" + ellipsoidType.Name +
                            ", DeltaX=" + deltaX.ToString(CultureInfo.InvariantCulture) +
                            ", SigmaX=" + sigmaX.ToString(CultureInfo.InvariantCulture) +
                            ", DeltaY=" + deltaY.ToString(CultureInfo.InvariantCulture) +
                            ", SigmaY=" + sigmaY.ToString(CultureInfo.InvariantCulture) +
                            ", DeltaZ=" + deltaZ.ToString(CultureInfo.InvariantCulture) +
                            ", SigmaZ=" + sigmaZ.ToString(CultureInfo.InvariantCulture) +
                            ", RotationX=" + rotationX.ToString(CultureInfo.InvariantCulture) +
                            ", RotationY=" + rotationY.ToString(CultureInfo.InvariantCulture) +
                            ", RotationZ=" + rotationZ.ToString(CultureInfo.InvariantCulture) +
                            ", RotationScaleFactor=" + rotationScaleFactor.ToString(CultureInfo.InvariantCulture) +
                            ", " + d.Domain.ToString() + "]", d.ToString());
            Assert.AreEqual("<datum datumType=\"" + datumType.Name + "\" deltaX=\"" + deltaX.ToString(CultureInfo.InvariantCulture) + "\" sigmaX=\"" + sigmaX.ToString(CultureInfo.InvariantCulture) + "\" deltaY=\"" + deltaY.ToString(CultureInfo.InvariantCulture) + "\" sigmaY=\"" + sigmaY.ToString(CultureInfo.InvariantCulture) + "\" deltaZ=\"" + deltaZ.ToString(CultureInfo.InvariantCulture) + "\" sigmaZ=\"" + sigmaZ.ToString(CultureInfo.InvariantCulture) + "\" rotationX=\"" + rotationX.ToString(CultureInfo.InvariantCulture) + "\" rotationY=\"" + rotationY.ToString(CultureInfo.InvariantCulture) + "\" rotationZ=\"" + rotationZ.ToString(CultureInfo.InvariantCulture) + "\" rotationScaleFactor=\"" + rotationScaleFactor.ToString(CultureInfo.InvariantCulture) + "\" north=\"" + north.ToString(CultureInfo.InvariantCulture) + "\" south=\"" + south.ToString(CultureInfo.InvariantCulture) + "\" east=\"" + east.ToString(CultureInfo.InvariantCulture) + "\" west=\"" + west.ToString(CultureInfo.InvariantCulture) + "\">\n" +
                            EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType).ToXml() +
                            "</datum>\n", d.ToXml());
        }

        [TestMethod]
        public void TestGetInstanceOfDatumDWGS1984()
        {
            Type datumType = typeof(Datums.Wgs1984);
            Type ellipsoidType = typeof(Ellipsoids.Wgs1984);
            double deltaX = 0.0;
            double sigmaX = 0.0;
            double deltaY = 0.0;
            double sigmaY = 0.0;
            double deltaZ = 0.0;
            double sigmaZ = 0.0;
            double rotationX = 0.0;
            double rotationY = 0.0;
            double rotationZ = 0.0;
            double rotationScaleFactor = 1.0;
            double north = 90.0;
            double south = -90.0;
            double east = 180.0;
            double west = -180.0;

            IDatum d = DatumFactory.GetInstanceOfDatum(datumType);
            Assert.IsNotNull(d);
            Assert.AreEqual(datumType.Name, d.GetType().Name);
            Assert.AreEqual(datumType.Name.ToString(), d.Name);
            Assert.AreEqual(datumType.Name.ToString(), d.Key);
            Assert.AreEqual(EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType), d.Ellipsoid);
            Assert.AreEqual(deltaX, d.DeltaX);
            Assert.AreEqual(sigmaX, d.SigmaX);
            Assert.AreEqual(deltaY, d.DeltaY);
            Assert.AreEqual(sigmaY, d.SigmaY);
            Assert.AreEqual(deltaZ, d.DeltaZ);
            Assert.AreEqual(sigmaZ, d.SigmaZ);
            Assert.AreEqual(rotationX, d.RotationX);
            Assert.AreEqual(rotationY, d.RotationY);
            Assert.AreEqual(rotationZ, d.RotationZ);
            Assert.AreEqual(rotationScaleFactor, d.RotationScaleFactor);
            Assert.AreEqual(north, d.Domain.Top);
            Assert.AreEqual(south, d.Domain.Bottom);
            Assert.AreEqual(east, d.Domain.Right);
            Assert.AreEqual(west, d.Domain.Left);
            Assert.AreEqual("[" + datumType.Name + ":  " +
                            "Ellipsoid=" + ellipsoidType.Name +
                            ", DeltaX=" + deltaX.ToString(CultureInfo.InvariantCulture) +
                            ", SigmaX=" + sigmaX.ToString(CultureInfo.InvariantCulture) +
                            ", DeltaY=" + deltaY.ToString(CultureInfo.InvariantCulture) +
                            ", SigmaY=" + sigmaY.ToString(CultureInfo.InvariantCulture) +
                            ", DeltaZ=" + deltaZ.ToString(CultureInfo.InvariantCulture) +
                            ", SigmaZ=" + sigmaZ.ToString(CultureInfo.InvariantCulture) +
                            ", RotationX=" + rotationX.ToString(CultureInfo.InvariantCulture) +
                            ", RotationY=" + rotationY.ToString(CultureInfo.InvariantCulture) +
                            ", RotationZ=" + rotationZ.ToString(CultureInfo.InvariantCulture) +
                            ", RotationScaleFactor=" + rotationScaleFactor.ToString(CultureInfo.InvariantCulture) +
                            ", " + d.Domain.ToString() + "]", d.ToString());
            Assert.AreEqual("<datum datumType=\"" + datumType.Name + "\" deltaX=\"" + deltaX.ToString(CultureInfo.InvariantCulture) + "\" sigmaX=\"" + sigmaX.ToString(CultureInfo.InvariantCulture) + "\" deltaY=\"" + deltaY.ToString(CultureInfo.InvariantCulture) + "\" sigmaY=\"" + sigmaY.ToString(CultureInfo.InvariantCulture) + "\" deltaZ=\"" + deltaZ.ToString(CultureInfo.InvariantCulture) + "\" sigmaZ=\"" + sigmaZ.ToString(CultureInfo.InvariantCulture) + "\" rotationX=\"" + rotationX.ToString(CultureInfo.InvariantCulture) + "\" rotationY=\"" + rotationY.ToString(CultureInfo.InvariantCulture) + "\" rotationZ=\"" + rotationZ.ToString(CultureInfo.InvariantCulture) + "\" rotationScaleFactor=\"" + rotationScaleFactor.ToString(CultureInfo.InvariantCulture) + "\" north=\"" + north.ToString(CultureInfo.InvariantCulture) + "\" south=\"" + south.ToString(CultureInfo.InvariantCulture) + "\" east=\"" + east.ToString(CultureInfo.InvariantCulture) + "\" west=\"" + west.ToString(CultureInfo.InvariantCulture) + "\">\n" +
                          EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType).ToXml() +
                          "</datum>\n", d.ToXml());
        }

        [TestMethod]
        public void TestSingleton()
        {
            IDatum d1 = DatumFactory.GetInstanceOfDatum(typeof(Datums.Wgs1984));
            IDatum d2 = DatumFactory.GetInstanceOfDatum(typeof(Datums.Wgs1984));
            Assert.AreSame(d1, d2);
        }

        [TestMethod, ExpectedException(typeof(InvalidDatumTypeException))]
        public void TestGetInstanceOfDatumUndefined()
        {
            IDatum d = DatumFactory.GetInstanceOfDatum(typeof(Ellipsoids.Undefined));
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(AmbiguousDatumTypeException))]
        public void TestGetInstanceOfDatumUserDefined()
        {
            IDatum d = DatumFactory.GetInstanceOfDatum(typeof(Datums.UserDefined));
            Assert.Fail();
        }

        #endregion


        #region UserDefined Instantiation

        #endregion
    }
}


