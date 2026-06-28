// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Globalization;
using AwesomeAssertions;
using StarThrower.Gis.GeoUtilities.Datums;
using StarThrower.Gis.GeoUtilities.Ellipsoids;
using StarThrower.Gis.GeoUtilities.Exceptions;
using Xunit;

namespace StarThrower.Gis.GeoUtilities.Test
{
    public class DatumTest
    {
        #region Non-UserDefined Instantiation

        [Fact]
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
            d.Should().NotBeNull();
            d.GetType().Name.Should().Be(datumType.Name);
            d.Name.Should().Be(datumType.Name);
            d.Key.Should().Be(datumType.Name);
            d.Ellipsoid.Should().Be(EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType));
            d.DeltaX.Should().Be(deltaX);
            d.SigmaX.Should().Be(sigmaX);
            d.DeltaY.Should().Be(deltaY);
            d.SigmaY.Should().Be(sigmaY);
            d.DeltaZ.Should().Be(deltaZ);
            d.SigmaZ.Should().Be(sigmaZ);
            d.RotationX.Should().Be(rotationX);
            d.RotationY.Should().Be(rotationY);
            d.RotationZ.Should().Be(rotationZ);
            d.RotationScaleFactor.Should().Be(rotationScaleFactor);
            d.Domain.Top.Should().Be(north);
            d.Domain.Bottom.Should().Be(south);
            d.Domain.Right.Should().Be(east);
            d.Domain.Left.Should().Be(west);
            d.ToString().Should().Be("[" + datumType.Name + ":  " +
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
                            ", " + d.Domain.ToString() + "]");
            d.ToXml().Should().Be("<datum datumType=\"" + datumType.Name + "\" deltaX=\"" + deltaX.ToString(CultureInfo.InvariantCulture) + "\" sigmaX=\"" + sigmaX.ToString(CultureInfo.InvariantCulture) + "\" deltaY=\"" + deltaY.ToString(CultureInfo.InvariantCulture) + "\" sigmaY=\"" + sigmaY.ToString(CultureInfo.InvariantCulture) + "\" deltaZ=\"" + deltaZ.ToString(CultureInfo.InvariantCulture) + "\" sigmaZ=\"" + sigmaZ.ToString(CultureInfo.InvariantCulture) + "\" rotationX=\"" + rotationX.ToString(CultureInfo.InvariantCulture) + "\" rotationY=\"" + rotationY.ToString(CultureInfo.InvariantCulture) + "\" rotationZ=\"" + rotationZ.ToString(CultureInfo.InvariantCulture) + "\" rotationScaleFactor=\"" + rotationScaleFactor.ToString(CultureInfo.InvariantCulture) + "\" north=\"" + north.ToString(CultureInfo.InvariantCulture) + "\" south=\"" + south.ToString(CultureInfo.InvariantCulture) + "\" east=\"" + east.ToString(CultureInfo.InvariantCulture) + "\" west=\"" + west.ToString(CultureInfo.InvariantCulture) + "\">\n" +
                            EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType).ToXml() +
                            "</datum>\n");

        }

        [Fact]
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
            d.Should().NotBeNull();
            d.GetType().Name.Should().Be(datumType.Name);
            d.Name.Should().Be(datumType.Name);
            d.Key.Should().Be(datumType.Name);
            d.Ellipsoid.Should().Be(EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType));
            d.DeltaX.Should().Be(deltaX);
            d.SigmaX.Should().Be(sigmaX);
            d.DeltaY.Should().Be(deltaY);
            d.SigmaY.Should().Be(sigmaY);
            d.DeltaZ.Should().Be(deltaZ);
            d.SigmaZ.Should().Be(sigmaZ);
            d.RotationX.Should().Be(rotationX);
            d.RotationY.Should().Be(rotationY);
            d.RotationZ.Should().Be(rotationZ);
            d.RotationScaleFactor.Should().Be(rotationScaleFactor);
            d.Domain.Top.Should().Be(north);
            d.Domain.Bottom.Should().Be(south);
            d.Domain.Right.Should().Be(east);
            d.Domain.Left.Should().Be(west);
            d.ToString().Should().Be("[" + datumType.Name + ":  " +
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
                            ", " + d.Domain.ToString() + "]");
            d.ToXml().Should().Be("<datum datumType=\"" + datumType.Name + "\" deltaX=\"" + deltaX.ToString(CultureInfo.InvariantCulture) + "\" sigmaX=\"" + sigmaX.ToString(CultureInfo.InvariantCulture) + "\" deltaY=\"" + deltaY.ToString(CultureInfo.InvariantCulture) + "\" sigmaY=\"" + sigmaY.ToString(CultureInfo.InvariantCulture) + "\" deltaZ=\"" + deltaZ.ToString(CultureInfo.InvariantCulture) + "\" sigmaZ=\"" + sigmaZ.ToString(CultureInfo.InvariantCulture) + "\" rotationX=\"" + rotationX.ToString(CultureInfo.InvariantCulture) + "\" rotationY=\"" + rotationY.ToString(CultureInfo.InvariantCulture) + "\" rotationZ=\"" + rotationZ.ToString(CultureInfo.InvariantCulture) + "\" rotationScaleFactor=\"" + rotationScaleFactor.ToString(CultureInfo.InvariantCulture) + "\" north=\"" + north.ToString(CultureInfo.InvariantCulture) + "\" south=\"" + south.ToString(CultureInfo.InvariantCulture) + "\" east=\"" + east.ToString(CultureInfo.InvariantCulture) + "\" west=\"" + west.ToString(CultureInfo.InvariantCulture) + "\">\n" +
                            EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType).ToXml() +
                            "</datum>\n");
        }

        [Fact]
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
            d.Should().NotBeNull();
            d.GetType().Name.Should().Be(datumType.Name);
            d.Name.Should().Be(datumType.Name);
            d.Key.Should().Be(datumType.Name);
            d.Ellipsoid.Should().Be(EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType));
            d.DeltaX.Should().Be(deltaX);
            d.SigmaX.Should().Be(sigmaX);
            d.DeltaY.Should().Be(deltaY);
            d.SigmaY.Should().Be(sigmaY);
            d.DeltaZ.Should().Be(deltaZ);
            d.SigmaZ.Should().Be(sigmaZ);
            d.RotationX.Should().Be(rotationX);
            d.RotationY.Should().Be(rotationY);
            d.RotationZ.Should().Be(rotationZ);
            d.RotationScaleFactor.Should().Be(rotationScaleFactor);
            d.Domain.Top.Should().Be(north);
            d.Domain.Bottom.Should().Be(south);
            d.Domain.Right.Should().Be(east);
            d.Domain.Left.Should().Be(west);
            d.ToString().Should().Be("[" + datumType.Name + ":  " +
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
                            ", " + d.Domain.ToString() + "]");
            d.ToXml().Should().Be("<datum datumType=\"" + datumType.Name + "\" deltaX=\"" + deltaX.ToString(CultureInfo.InvariantCulture) + "\" sigmaX=\"" + sigmaX.ToString(CultureInfo.InvariantCulture) + "\" deltaY=\"" + deltaY.ToString(CultureInfo.InvariantCulture) + "\" sigmaY=\"" + sigmaY.ToString(CultureInfo.InvariantCulture) + "\" deltaZ=\"" + deltaZ.ToString(CultureInfo.InvariantCulture) + "\" sigmaZ=\"" + sigmaZ.ToString(CultureInfo.InvariantCulture) + "\" rotationX=\"" + rotationX.ToString(CultureInfo.InvariantCulture) + "\" rotationY=\"" + rotationY.ToString(CultureInfo.InvariantCulture) + "\" rotationZ=\"" + rotationZ.ToString(CultureInfo.InvariantCulture) + "\" rotationScaleFactor=\"" + rotationScaleFactor.ToString(CultureInfo.InvariantCulture) + "\" north=\"" + north.ToString(CultureInfo.InvariantCulture) + "\" south=\"" + south.ToString(CultureInfo.InvariantCulture) + "\" east=\"" + east.ToString(CultureInfo.InvariantCulture) + "\" west=\"" + west.ToString(CultureInfo.InvariantCulture) + "\">\n" +
                            EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType).ToXml() +
                            "</datum>\n");
        }

        [Fact]
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
            d.Should().NotBeNull();
            d.GetType().Name.Should().Be(datumType.Name);
            d.Name.Should().Be(datumType.Name);
            d.Key.Should().Be(datumType.Name);
            d.Ellipsoid.Should().Be(EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType));
            d.DeltaX.Should().Be(deltaX);
            d.SigmaX.Should().Be(sigmaX);
            d.DeltaY.Should().Be(deltaY);
            d.SigmaY.Should().Be(sigmaY);
            d.DeltaZ.Should().Be(deltaZ);
            d.SigmaZ.Should().Be(sigmaZ);
            d.RotationX.Should().Be(rotationX);
            d.RotationY.Should().Be(rotationY);
            d.RotationZ.Should().Be(rotationZ);
            d.RotationScaleFactor.Should().Be(rotationScaleFactor);
            d.Domain.Top.Should().Be(north);
            d.Domain.Bottom.Should().Be(south);
            d.Domain.Right.Should().Be(east);
            d.Domain.Left.Should().Be(west);
            d.ToString().Should().Be("[" + datumType.Name + ":  " +
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
                            ", " + d.Domain.ToString() + "]");
            d.ToXml().Should().Be("<datum datumType=\"" + datumType.Name + "\" deltaX=\"" + deltaX.ToString(CultureInfo.InvariantCulture) + "\" sigmaX=\"" + sigmaX.ToString(CultureInfo.InvariantCulture) + "\" deltaY=\"" + deltaY.ToString(CultureInfo.InvariantCulture) + "\" sigmaY=\"" + sigmaY.ToString(CultureInfo.InvariantCulture) + "\" deltaZ=\"" + deltaZ.ToString(CultureInfo.InvariantCulture) + "\" sigmaZ=\"" + sigmaZ.ToString(CultureInfo.InvariantCulture) + "\" rotationX=\"" + rotationX.ToString(CultureInfo.InvariantCulture) + "\" rotationY=\"" + rotationY.ToString(CultureInfo.InvariantCulture) + "\" rotationZ=\"" + rotationZ.ToString(CultureInfo.InvariantCulture) + "\" rotationScaleFactor=\"" + rotationScaleFactor.ToString(CultureInfo.InvariantCulture) + "\" north=\"" + north.ToString(CultureInfo.InvariantCulture) + "\" south=\"" + south.ToString(CultureInfo.InvariantCulture) + "\" east=\"" + east.ToString(CultureInfo.InvariantCulture) + "\" west=\"" + west.ToString(CultureInfo.InvariantCulture) + "\">\n" +
                            EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType).ToXml() +
                            "</datum>\n");
        }

        [Fact]
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
            d.Should().NotBeNull();
            d.GetType().Name.Should().Be(datumType.Name);
            d.Name.Should().Be(datumType.Name);
            d.Key.Should().Be(datumType.Name);
            d.Ellipsoid.Should().Be(EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType));
            d.DeltaX.Should().Be(deltaX);
            d.SigmaX.Should().Be(sigmaX);
            d.DeltaY.Should().Be(deltaY);
            d.SigmaY.Should().Be(sigmaY);
            d.DeltaZ.Should().Be(deltaZ);
            d.SigmaZ.Should().Be(sigmaZ);
            d.RotationX.Should().Be(rotationX);
            d.RotationY.Should().Be(rotationY);
            d.RotationZ.Should().Be(rotationZ);
            d.RotationScaleFactor.Should().Be(rotationScaleFactor);
            d.Domain.Top.Should().Be(north);
            d.Domain.Bottom.Should().Be(south);
            d.Domain.Right.Should().Be(east);
            d.Domain.Left.Should().Be(west);
            d.ToString().Should().Be("[" + datumType.Name + ":  " +
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
                            ", " + d.Domain.ToString() + "]");
            d.ToXml().Should().Be("<datum datumType=\"" + datumType.Name + "\" deltaX=\"" + deltaX.ToString(CultureInfo.InvariantCulture) + "\" sigmaX=\"" + sigmaX.ToString(CultureInfo.InvariantCulture) + "\" deltaY=\"" + deltaY.ToString(CultureInfo.InvariantCulture) + "\" sigmaY=\"" + sigmaY.ToString(CultureInfo.InvariantCulture) + "\" deltaZ=\"" + deltaZ.ToString(CultureInfo.InvariantCulture) + "\" sigmaZ=\"" + sigmaZ.ToString(CultureInfo.InvariantCulture) + "\" rotationX=\"" + rotationX.ToString(CultureInfo.InvariantCulture) + "\" rotationY=\"" + rotationY.ToString(CultureInfo.InvariantCulture) + "\" rotationZ=\"" + rotationZ.ToString(CultureInfo.InvariantCulture) + "\" rotationScaleFactor=\"" + rotationScaleFactor.ToString(CultureInfo.InvariantCulture) + "\" north=\"" + north.ToString(CultureInfo.InvariantCulture) + "\" south=\"" + south.ToString(CultureInfo.InvariantCulture) + "\" east=\"" + east.ToString(CultureInfo.InvariantCulture) + "\" west=\"" + west.ToString(CultureInfo.InvariantCulture) + "\">\n" +
                            EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType).ToXml() +
                            "</datum>\n");
        }

        [Fact]
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
            d.Should().NotBeNull();
            d.GetType().Name.Should().Be(datumType.Name);
            d.Name.Should().Be(datumType.Name.ToString());
            d.Key.Should().Be(datumType.Name.ToString());
            d.Ellipsoid.Should().Be(EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType));
            d.DeltaX.Should().Be(deltaX);
            d.SigmaX.Should().Be(sigmaX);
            d.DeltaY.Should().Be(deltaY);
            d.SigmaY.Should().Be(sigmaY);
            d.DeltaZ.Should().Be(deltaZ);
            d.SigmaZ.Should().Be(sigmaZ);
            d.RotationX.Should().Be(rotationX);
            d.RotationY.Should().Be(rotationY);
            d.RotationZ.Should().Be(rotationZ);
            d.RotationScaleFactor.Should().Be(rotationScaleFactor);
            d.Domain.Top.Should().Be(north);
            d.Domain.Bottom.Should().Be(south);
            d.Domain.Right.Should().Be(east);
            d.Domain.Left.Should().Be(west);
            d.ToString().Should().Be("[" + datumType.Name + ":  " +
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
                            ", " + d.Domain.ToString() + "]");
            d.ToXml().Should().Be("<datum datumType=\"" + datumType.Name + "\" deltaX=\"" + deltaX.ToString(CultureInfo.InvariantCulture) + "\" sigmaX=\"" + sigmaX.ToString(CultureInfo.InvariantCulture) + "\" deltaY=\"" + deltaY.ToString(CultureInfo.InvariantCulture) + "\" sigmaY=\"" + sigmaY.ToString(CultureInfo.InvariantCulture) + "\" deltaZ=\"" + deltaZ.ToString(CultureInfo.InvariantCulture) + "\" sigmaZ=\"" + sigmaZ.ToString(CultureInfo.InvariantCulture) + "\" rotationX=\"" + rotationX.ToString(CultureInfo.InvariantCulture) + "\" rotationY=\"" + rotationY.ToString(CultureInfo.InvariantCulture) + "\" rotationZ=\"" + rotationZ.ToString(CultureInfo.InvariantCulture) + "\" rotationScaleFactor=\"" + rotationScaleFactor.ToString(CultureInfo.InvariantCulture) + "\" north=\"" + north.ToString(CultureInfo.InvariantCulture) + "\" south=\"" + south.ToString(CultureInfo.InvariantCulture) + "\" east=\"" + east.ToString(CultureInfo.InvariantCulture) + "\" west=\"" + west.ToString(CultureInfo.InvariantCulture) + "\">\n" +
                          EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType).ToXml() +
                          "</datum>\n");
        }

        [Fact]
        public void TestSingleton()
        {
            IDatum d1 = DatumFactory.GetInstanceOfDatum(typeof(Datums.Wgs1984));
            IDatum d2 = DatumFactory.GetInstanceOfDatum(typeof(Datums.Wgs1984));
            d1.Should().BeSameAs(d2);
        }

        [Fact]
        public void TestGetInstanceOfDatumUndefined()
        {
            Action act = () => DatumFactory.GetInstanceOfDatum(typeof(Ellipsoids.Undefined));
            act.Should().Throw<InvalidDatumTypeException>();
        }

        [Fact]
        public void TestGetInstanceOfDatumUserDefined()
        {
            Action act = () => DatumFactory.GetInstanceOfDatum(typeof(Datums.UserDefined));
            act.Should().Throw<AmbiguousDatumTypeException>();
        }

        #endregion


        #region UserDefined Instantiation

        [Fact]
        public void TestUserDefinedIsSevenParamDatumFalseWhenAllRotationsZero()
        {
            IDatum d = DatumFactory.GetInstanceOfNewUserDefinedDatum("ZeroRotation", EllipsoidFactory.GetInstanceOfEllipsoid(typeof(Ellipsoids.Wgs1984)),
                0, -1, 0, -1, 0, -1, 0.0, 0.0, 0.0, 1.0, 90, -90, 180, -180);

            d.IsSevenParamDatum.Should().BeFalse();
        }

        [Fact]
        public void TestUserDefinedIsSevenParamDatumFalseWhenOnlyScaleFactorNonDefault()
        {
            // RotationScaleFactor alone is not a reliable signal (its "no scaling" baseline is
            // inconsistent across data sources - 1 in some, 0 in others), so it must not affect
            // IsSevenParamDatum on its own.
            IDatum d = DatumFactory.GetInstanceOfNewUserDefinedDatum("ScaleFactorOnly", EllipsoidFactory.GetInstanceOfEllipsoid(typeof(Ellipsoids.Wgs1984)),
                0, -1, 0, -1, 0, -1, 0.0, 0.0, 0.0, 0.5, 90, -90, 180, -180);

            d.IsSevenParamDatum.Should().BeFalse();
        }

        [Fact]
        public void TestUserDefinedIsSevenParamDatumTrueWhenRotationXNonZero()
        {
            IDatum d = DatumFactory.GetInstanceOfNewUserDefinedDatum("RotationXNonZero", EllipsoidFactory.GetInstanceOfEllipsoid(typeof(Ellipsoids.Wgs1984)),
                0, -1, 0, -1, 0, -1, 0.413, 0.0, 0.0, 1.0, 90, -90, 180, -180);

            d.IsSevenParamDatum.Should().BeTrue();
        }

        [Fact]
        public void TestUserDefinedIsSevenParamDatumTrueWhenRotationYNonZero()
        {
            IDatum d = DatumFactory.GetInstanceOfNewUserDefinedDatum("RotationYNonZero", EllipsoidFactory.GetInstanceOfEllipsoid(typeof(Ellipsoids.Wgs1984)),
                0, -1, 0, -1, 0, -1, 0.0, -0.184, 0.0, 1.0, 90, -90, 180, -180);

            d.IsSevenParamDatum.Should().BeTrue();
        }

        [Fact]
        public void TestUserDefinedIsSevenParamDatumTrueWhenRotationZNonZero()
        {
            IDatum d = DatumFactory.GetInstanceOfNewUserDefinedDatum("RotationZNonZero", EllipsoidFactory.GetInstanceOfEllipsoid(typeof(Ellipsoids.Wgs1984)),
                0, -1, 0, -1, 0, -1, 0.0, 0.0, 0.385, 1.0, 90, -90, 180, -180);

            d.IsSevenParamDatum.Should().BeTrue();
        }

        #endregion


        #region Validate

        [Fact]
        public void TestValidateInsideDomainReturnsTrue()
        {
            IDatum d = DatumFactory.GetInstanceOfDatum(typeof(Datums.Nad1927Conus));
            double xLon = -100.0 * GeoUtil.DegreesToRadians;
            double yLat = 40.0 * GeoUtil.DegreesToRadians;

            d.Validate(xLon, yLat).Should().BeTrue();
        }

        [Fact]
        public void TestValidateNorthOfDomainReturnsFalse()
        {
            IDatum d = DatumFactory.GetInstanceOfDatum(typeof(Datums.Nad1927Conus));
            double xLon = -100.0 * GeoUtil.DegreesToRadians;
            double yLat = 70.0 * GeoUtil.DegreesToRadians; // domain Top is 60

            d.Validate(xLon, yLat).Should().BeFalse();
        }

        [Fact]
        public void TestValidateSouthOfDomainReturnsFalse()
        {
            IDatum d = DatumFactory.GetInstanceOfDatum(typeof(Datums.Nad1927Conus));
            double xLon = -100.0 * GeoUtil.DegreesToRadians;
            double yLat = 5.0 * GeoUtil.DegreesToRadians; // domain Bottom is 15

            d.Validate(xLon, yLat).Should().BeFalse();
        }

        [Fact]
        public void TestValidateEastOfDomainReturnsFalse()
        {
            IDatum d = DatumFactory.GetInstanceOfDatum(typeof(Datums.Nad1927Conus));
            double xLon = -50.0 * GeoUtil.DegreesToRadians; // domain Right is -60
            double yLat = 40.0 * GeoUtil.DegreesToRadians;

            d.Validate(xLon, yLat).Should().BeFalse();
        }

        [Fact]
        public void TestValidateWestOfDomainReturnsFalse()
        {
            IDatum d = DatumFactory.GetInstanceOfDatum(typeof(Datums.Nad1927Conus));
            double xLon = -140.0 * GeoUtil.DegreesToRadians; // domain Left is -135
            double yLat = 40.0 * GeoUtil.DegreesToRadians;

            d.Validate(xLon, yLat).Should().BeFalse();
        }

        [Fact]
        public void TestValidateJustInsideDomainBoundaryReturnsTrue()
        {
            // Points exactly on a degree boundary (e.g. -60.0) are not used here because converting
            // degrees -> radians -> degrees does not always round-trip to the exact same double,
            // which would make the assertion flaky. Points just inside each edge avoid that.
            IDatum d = DatumFactory.GetInstanceOfDatum(typeof(Datums.Nad1927Conus));

            d.Validate(-134.999 * GeoUtil.DegreesToRadians, 59.999 * GeoUtil.DegreesToRadians).Should().BeTrue(); // near top-left corner
            d.Validate(-60.001 * GeoUtil.DegreesToRadians, 15.001 * GeoUtil.DegreesToRadians).Should().BeTrue(); // near bottom-right corner
        }

        #endregion
    }
}


