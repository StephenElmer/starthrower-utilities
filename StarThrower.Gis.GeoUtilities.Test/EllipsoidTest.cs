// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Globalization;
using AwesomeAssertions;
using StarThrower.Gis.GeoUtilities.Ellipsoids;
using StarThrower.Gis.GeoUtilities.Exceptions;
using Xunit;

namespace StarThrower.Gis.GeoUtilities.Test
{
    public class EllipsoidTest
    {
        #region Non-UserDefined Instantiation

        [Fact]
        public void TestGetInsanceOfEllipsoidWGS1984()
        {
            Type ellipsoidType = typeof(Ellipsoids.Wgs1984);
            double equatorialRadius = 6378137.0;
            double inverseFlattening = 298.257223563;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            e.Should().NotBeNull();
            e.GetType().Name.Should().Be(ellipsoidType.Name);
            e.Name.Should().Be(ellipsoidType.Name);
            e.Key.Should().Be(ellipsoidType.Name);
            e.EquatorialRadius.Should().Be(equatorialRadius);
            e.Flattening.Should().Be(flattening);
            e.PolarRadius.Should().Be(equatorialRadius - (flattening * equatorialRadius));
            e.InverseFlattening.Should().Be(inverseFlattening);
            e.FirstEccentricitySquared.Should().Be(firstEccentricitySquared);
            e.SecondEccentricitySquared.Should().Be(secondEccentricitySquared);
            e.ToString().Should().Be("[" + ellipsoidType.Name + ":  " +
                            "EquatorialRadius=" + equatorialRadius.ToString(CultureInfo.InvariantCulture) +
                            ", PolarRadius=" + polarRadius.ToString(CultureInfo.InvariantCulture) +
                            ", Flattening=" + flattening.ToString(CultureInfo.InvariantCulture) + "]");
            e.ToXml().Should().Be("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString(CultureInfo.InvariantCulture) + "\" polarRadius=\"" + polarRadius.ToString(CultureInfo.InvariantCulture) + "\" flattening=\"" + flattening.ToString(CultureInfo.InvariantCulture) + "\"/>\n");
        }

        [Fact]
        public void TestGetInstanceOfEllipsoidAiryModified()
        {
            Type ellipsoidType = typeof(Ellipsoids.AiryModified);
            double equatorialRadius = 6377340.189;
            double inverseFlattening = 299.3249646;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            e.Should().NotBeNull();
            e.GetType().Name.Should().Be(ellipsoidType.Name);
            e.Name.Should().Be(ellipsoidType.Name);
            e.Key.Should().Be(ellipsoidType.Name);
            e.EquatorialRadius.Should().Be(equatorialRadius);
            e.Flattening.Should().Be(flattening);
            e.PolarRadius.Should().Be(equatorialRadius - (flattening * equatorialRadius));
            e.InverseFlattening.Should().Be(inverseFlattening);
            e.FirstEccentricitySquared.Should().Be(firstEccentricitySquared);
            e.SecondEccentricitySquared.Should().Be(secondEccentricitySquared);
            e.ToString().Should().Be("[" + ellipsoidType.Name + ":  " +
                            "EquatorialRadius=" + equatorialRadius.ToString(CultureInfo.InvariantCulture) +
                            ", PolarRadius=" + polarRadius.ToString(CultureInfo.InvariantCulture) +
                            ", Flattening=" + flattening.ToString(CultureInfo.InvariantCulture) + "]");
            e.ToXml().Should().Be("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString(CultureInfo.InvariantCulture) + "\" polarRadius=\"" + polarRadius.ToString(CultureInfo.InvariantCulture) + "\" flattening=\"" + flattening.ToString(CultureInfo.InvariantCulture) + "\"/>\n");
        }

        [Fact]
        public void TestGetInstanceOfEllipsoidAustralian()
        {
            Type ellipsoidType = typeof(Ellipsoids.Australian);
            double equatorialRadius = 6378160.0;
            double inverseFlattening = 298.25;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            e.Should().NotBeNull();
            e.GetType().Name.Should().Be(ellipsoidType.Name);
            e.Name.Should().Be(ellipsoidType.Name);
            e.Key.Should().Be(ellipsoidType.Name);
            e.EquatorialRadius.Should().Be(equatorialRadius);
            e.Flattening.Should().Be(flattening);
            e.PolarRadius.Should().Be(equatorialRadius - (flattening * equatorialRadius));
            e.InverseFlattening.Should().Be(inverseFlattening);
            e.FirstEccentricitySquared.Should().Be(firstEccentricitySquared);
            e.SecondEccentricitySquared.Should().Be(secondEccentricitySquared);
            e.ToString().Should().Be("[" + ellipsoidType.Name + ":  " +
                           "EquatorialRadius=" + equatorialRadius.ToString(CultureInfo.InvariantCulture) +
                           ", PolarRadius=" + polarRadius.ToString(CultureInfo.InvariantCulture) +
                           ", Flattening=" + flattening.ToString(CultureInfo.InvariantCulture) + "]");
            e.ToXml().Should().Be("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString(CultureInfo.InvariantCulture) + "\" polarRadius=\"" + polarRadius.ToString(CultureInfo.InvariantCulture) + "\" flattening=\"" + flattening.ToString(CultureInfo.InvariantCulture) + "\"/>\n");
        }

        [Fact]
        public void TestGetInstanceOfEllipsoidBesselNamibia()
        {
            Type ellipsoidType = typeof(Ellipsoids.BesselNamibia);
            double equatorialRadius = 6377483.865;
            double inverseFlattening = 299.1528128;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            e.Should().NotBeNull();
            e.GetType().Name.Should().Be(ellipsoidType.Name);
            e.Name.Should().Be(ellipsoidType.Name);
            e.Key.Should().Be(ellipsoidType.Name);
            e.EquatorialRadius.Should().Be(equatorialRadius);
            e.Flattening.Should().Be(flattening);
            e.PolarRadius.Should().Be(equatorialRadius - (flattening * equatorialRadius));
            e.InverseFlattening.Should().Be(inverseFlattening);
            e.FirstEccentricitySquared.Should().Be(firstEccentricitySquared);
            e.SecondEccentricitySquared.Should().Be(secondEccentricitySquared);
            e.ToString().Should().Be("[" + ellipsoidType.Name + ":  " +
                          "EquatorialRadius=" + equatorialRadius.ToString(CultureInfo.InvariantCulture) +
                          ", PolarRadius=" + polarRadius.ToString(CultureInfo.InvariantCulture) +
                          ", Flattening=" + flattening.ToString(CultureInfo.InvariantCulture) + "]");
            e.ToXml().Should().Be("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString(CultureInfo.InvariantCulture) + "\" polarRadius=\"" + polarRadius.ToString(CultureInfo.InvariantCulture) + "\" flattening=\"" + flattening.ToString(CultureInfo.InvariantCulture) + "\"/>\n");
        }

        [Fact]
        public void TestGetInstanceOfEllipsoidBessel1841()
        {
            Type ellipsoidType = typeof(Ellipsoids.Bessel1841);
            double equatorialRadius = 6377397.155;
            double inverseFlattening = 299.1528128;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            e.Should().NotBeNull();
            e.GetType().Name.Should().Be(ellipsoidType.Name);
            e.Name.Should().Be(ellipsoidType.Name);
            e.Key.Should().Be(ellipsoidType.Name);
            e.EquatorialRadius.Should().Be(equatorialRadius);
            e.Flattening.Should().Be(flattening);
            e.PolarRadius.Should().Be(equatorialRadius - (flattening * equatorialRadius));
            e.InverseFlattening.Should().Be(inverseFlattening);
            e.FirstEccentricitySquared.Should().Be(firstEccentricitySquared);
            e.SecondEccentricitySquared.Should().Be(secondEccentricitySquared);
            e.ToString().Should().Be("[" + ellipsoidType.Name + ":  " +
                          "EquatorialRadius=" + equatorialRadius.ToString(CultureInfo.InvariantCulture) +
                          ", PolarRadius=" + polarRadius.ToString(CultureInfo.InvariantCulture) +
                          ", Flattening=" + flattening.ToString(CultureInfo.InvariantCulture) + "]");
            e.ToXml().Should().Be("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString(CultureInfo.InvariantCulture) + "\" polarRadius=\"" + polarRadius.ToString(CultureInfo.InvariantCulture) + "\" flattening=\"" + flattening.ToString(CultureInfo.InvariantCulture) + "\"/>\n");
        }

        [Fact]
        public void TestGetInstanceOfEllipsoidClarke1866()
        {
            Type ellipsoidType = typeof(Ellipsoids.Clarke1866);
            double equatorialRadius = 6378206.4;
            double inverseFlattening = 294.9786982;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            e.Should().NotBeNull();
            e.GetType().Name.Should().Be(ellipsoidType.Name);
            e.Name.Should().Be(ellipsoidType.Name);
            e.Key.Should().Be(ellipsoidType.Name);
            e.EquatorialRadius.Should().Be(equatorialRadius);
            e.Flattening.Should().Be(flattening);
            e.PolarRadius.Should().Be(equatorialRadius - (flattening * equatorialRadius));
            e.InverseFlattening.Should().Be(inverseFlattening);
            e.FirstEccentricitySquared.Should().Be(firstEccentricitySquared);
            e.SecondEccentricitySquared.Should().Be(secondEccentricitySquared);
            e.ToString().Should().Be("[" + ellipsoidType.Name + ":  " +
                         "EquatorialRadius=" + equatorialRadius.ToString(CultureInfo.InvariantCulture) +
                         ", PolarRadius=" + polarRadius.ToString(CultureInfo.InvariantCulture) +
                         ", Flattening=" + flattening.ToString(CultureInfo.InvariantCulture) + "]");
            e.ToXml().Should().Be("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString(CultureInfo.InvariantCulture) + "\" polarRadius=\"" + polarRadius.ToString(CultureInfo.InvariantCulture) + "\" flattening=\"" + flattening.ToString(CultureInfo.InvariantCulture) + "\"/>\n");
        }

        [Fact]
        public void TestGetInstanceOfEllipsoidClarke1880Rgs()
        {
            Type ellipsoidType = typeof(Ellipsoids.Clarke1880Rgs);
            double equatorialRadius = 6378249.145;
            double inverseFlattening = 293.465;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            e.Should().NotBeNull();
            e.GetType().Name.Should().Be(ellipsoidType.Name);
            e.Name.Should().Be(ellipsoidType.Name);
            e.Key.Should().Be(ellipsoidType.Name);
            e.EquatorialRadius.Should().Be(equatorialRadius);
            e.Flattening.Should().Be(flattening);
            e.PolarRadius.Should().Be(equatorialRadius - (flattening * equatorialRadius));
            e.InverseFlattening.Should().Be(inverseFlattening);
            e.FirstEccentricitySquared.Should().Be(firstEccentricitySquared);
            e.SecondEccentricitySquared.Should().Be(secondEccentricitySquared);
            e.ToString().Should().Be("[" + ellipsoidType.Name + ":  " +
                           "EquatorialRadius=" + equatorialRadius.ToString(CultureInfo.InvariantCulture) +
                           ", PolarRadius=" + polarRadius.ToString(CultureInfo.InvariantCulture) +
                           ", Flattening=" + flattening.ToString(CultureInfo.InvariantCulture) + "]");
            e.ToXml().Should().Be("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString(CultureInfo.InvariantCulture) + "\" polarRadius=\"" + polarRadius.ToString(CultureInfo.InvariantCulture) + "\" flattening=\"" + flattening.ToString(CultureInfo.InvariantCulture) + "\"/>\n");
        }

        [Fact]
        public void TestGetInstanceOfEllipsoidEverestAdjustment1937()
        {
            Type ellipsoidType = typeof(Ellipsoids.EverestAdjustment1937);
            double equatorialRadius = 6377276.345;
            double inverseFlattening = 300.8017;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            e.Should().NotBeNull();
            e.GetType().Name.Should().Be(ellipsoidType.Name);
            e.Name.Should().Be(ellipsoidType.Name);
            e.Key.Should().Be(ellipsoidType.Name);
            e.EquatorialRadius.Should().Be(equatorialRadius);
            e.Flattening.Should().Be(flattening);
            e.PolarRadius.Should().Be(equatorialRadius - (flattening * equatorialRadius));
            e.InverseFlattening.Should().Be(inverseFlattening);
            e.FirstEccentricitySquared.Should().Be(firstEccentricitySquared);
            e.SecondEccentricitySquared.Should().Be(secondEccentricitySquared);
            e.ToString().Should().Be("[" + ellipsoidType.Name + ":  " +
                           "EquatorialRadius=" + equatorialRadius.ToString(CultureInfo.InvariantCulture) +
                           ", PolarRadius=" + polarRadius.ToString(CultureInfo.InvariantCulture) +
                           ", Flattening=" + flattening.ToString(CultureInfo.InvariantCulture) + "]");
            e.ToXml().Should().Be("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString(CultureInfo.InvariantCulture) + "\" polarRadius=\"" + polarRadius.ToString(CultureInfo.InvariantCulture) + "\" flattening=\"" + flattening.ToString(CultureInfo.InvariantCulture) + "\"/>\n");
        }

        [Fact]
        public void TestGetInstanceOfEllipsoidEverestDefinition1967()
        {
            Type ellipsoidType = typeof(Ellipsoids.EverestDefinition1967);
            double equatorialRadius = 6377298.556;
            double inverseFlattening = 300.8017;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            e.Should().NotBeNull();
            e.GetType().Name.Should().Be(ellipsoidType.Name);
            e.Name.Should().Be(ellipsoidType.Name);
            e.Key.Should().Be(ellipsoidType.Name);
            e.EquatorialRadius.Should().Be(equatorialRadius);
            e.Flattening.Should().Be(flattening);
            e.PolarRadius.Should().Be(equatorialRadius - (flattening * equatorialRadius));
            e.InverseFlattening.Should().Be(inverseFlattening);
            e.FirstEccentricitySquared.Should().Be(firstEccentricitySquared);
            e.SecondEccentricitySquared.Should().Be(secondEccentricitySquared);
            e.ToString().Should().Be("[" + ellipsoidType.Name + ":  " +
                          "EquatorialRadius=" + equatorialRadius.ToString(CultureInfo.InvariantCulture) +
                          ", PolarRadius=" + polarRadius.ToString(CultureInfo.InvariantCulture) +
                          ", Flattening=" + flattening.ToString(CultureInfo.InvariantCulture) + "]");
            e.ToXml().Should().Be("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString(CultureInfo.InvariantCulture) + "\" polarRadius=\"" + polarRadius.ToString(CultureInfo.InvariantCulture) + "\" flattening=\"" + flattening.ToString(CultureInfo.InvariantCulture) + "\"/>\n");
        }

        [Fact]
        public void TestGetInstanceOfEllipsoidEverest1956India()
        {
            Type ellipsoidType = typeof(Ellipsoids.Everest1956India);
            double equatorialRadius = 6377301.243;
            double inverseFlattening = 300.8017;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            e.Should().NotBeNull();
            e.GetType().Name.Should().Be(ellipsoidType.Name);
            e.Name.Should().Be(ellipsoidType.Name);
            e.Key.Should().Be(ellipsoidType.Name);
            e.EquatorialRadius.Should().Be(equatorialRadius);
            e.Flattening.Should().Be(flattening);
            e.PolarRadius.Should().Be(equatorialRadius - (flattening * equatorialRadius));
            e.InverseFlattening.Should().Be(inverseFlattening);
            e.FirstEccentricitySquared.Should().Be(firstEccentricitySquared);
            e.SecondEccentricitySquared.Should().Be(secondEccentricitySquared);
            e.ToString().Should().Be("[" + ellipsoidType.Name + ":  " +
                          "EquatorialRadius=" + equatorialRadius.ToString(CultureInfo.InvariantCulture) +
                          ", PolarRadius=" + polarRadius.ToString(CultureInfo.InvariantCulture) +
                          ", Flattening=" + flattening.ToString(CultureInfo.InvariantCulture) + "]");
            e.ToXml().Should().Be("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString(CultureInfo.InvariantCulture) + "\" polarRadius=\"" + polarRadius.ToString(CultureInfo.InvariantCulture) + "\" flattening=\"" + flattening.ToString(CultureInfo.InvariantCulture) + "\"/>\n");
        }

        [Fact]
        public void TestGetInstanceOfEllipsoidEverestModified1969()
        {
            Type ellipsoidType = typeof(Ellipsoids.EverestModified1969);
            double equatorialRadius = 6377295.664;
            double inverseFlattening = 300.8017;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            e.Should().NotBeNull();
            e.GetType().Name.Should().Be(ellipsoidType.Name);
            e.Name.Should().Be(ellipsoidType.Name);
            e.Key.Should().Be(ellipsoidType.Name);
            e.EquatorialRadius.Should().Be(equatorialRadius);
            e.Flattening.Should().Be(flattening);
            e.PolarRadius.Should().Be(equatorialRadius - (flattening * equatorialRadius));
            e.InverseFlattening.Should().Be(inverseFlattening);
            e.FirstEccentricitySquared.Should().Be(firstEccentricitySquared);
            e.SecondEccentricitySquared.Should().Be(secondEccentricitySquared);
            e.ToString().Should().Be("[" + ellipsoidType.Name + ":  " +
                           "EquatorialRadius=" + equatorialRadius.ToString(CultureInfo.InvariantCulture) +
                           ", PolarRadius=" + polarRadius.ToString(CultureInfo.InvariantCulture) +
                           ", Flattening=" + flattening.ToString(CultureInfo.InvariantCulture) + "]");
            e.ToXml().Should().Be("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString(CultureInfo.InvariantCulture) + "\" polarRadius=\"" + polarRadius.ToString(CultureInfo.InvariantCulture) + "\" flattening=\"" + flattening.ToString(CultureInfo.InvariantCulture) + "\"/>\n");
        }

        [Fact]
        public void TestGetInstanceOfEllipsoidEverest1830Modified()
        {
            Type ellipsoidType = typeof(Ellipsoids.Everest1830Modified);
            double equatorialRadius = 6377304.063;
            double inverseFlattening = 300.8017;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            e.Should().NotBeNull();
            e.GetType().Name.Should().Be(ellipsoidType.Name);
            e.Name.Should().Be(ellipsoidType.Name);
            e.Key.Should().Be(ellipsoidType.Name);
            e.EquatorialRadius.Should().Be(equatorialRadius);
            e.Flattening.Should().Be(flattening);
            e.PolarRadius.Should().Be(equatorialRadius - (flattening * equatorialRadius));
            e.InverseFlattening.Should().Be(inverseFlattening);
            e.FirstEccentricitySquared.Should().Be(firstEccentricitySquared);
            e.SecondEccentricitySquared.Should().Be(secondEccentricitySquared);
            e.ToString().Should().Be("[" + ellipsoidType.Name + ":  " +
                           "EquatorialRadius=" + equatorialRadius.ToString(CultureInfo.InvariantCulture) +
                           ", PolarRadius=" + polarRadius.ToString(CultureInfo.InvariantCulture) +
                           ", Flattening=" + flattening.ToString(CultureInfo.InvariantCulture) + "]");
            e.ToXml().Should().Be("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString(CultureInfo.InvariantCulture) + "\" polarRadius=\"" + polarRadius.ToString(CultureInfo.InvariantCulture) + "\" flattening=\"" + flattening.ToString(CultureInfo.InvariantCulture) + "\"/>\n");
        }

        [Fact]
        public void TestGetInstanceOfEllipsoidEverestPakistan()
        {
            Type ellipsoidType = typeof(Ellipsoids.EverestPakistan);
            double equatorialRadius = 6377309.613;
            double inverseFlattening = 300.8017;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            e.Should().NotBeNull();
            e.GetType().Name.Should().Be(ellipsoidType.Name);
            e.Name.Should().Be(ellipsoidType.Name);
            e.Key.Should().Be(ellipsoidType.Name);
            e.EquatorialRadius.Should().Be(equatorialRadius);
            e.Flattening.Should().Be(flattening);
            e.PolarRadius.Should().Be(equatorialRadius - (flattening * equatorialRadius));
            e.InverseFlattening.Should().Be(inverseFlattening);
            e.FirstEccentricitySquared.Should().Be(firstEccentricitySquared);
            e.SecondEccentricitySquared.Should().Be(secondEccentricitySquared);
            e.ToString().Should().Be("[" + ellipsoidType.Name + ":  " +
                           "EquatorialRadius=" + equatorialRadius.ToString(CultureInfo.InvariantCulture) +
                           ", PolarRadius=" + polarRadius.ToString(CultureInfo.InvariantCulture) +
                           ", Flattening=" + flattening.ToString(CultureInfo.InvariantCulture) + "]");
            e.ToXml().Should().Be("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString(CultureInfo.InvariantCulture) + "\" polarRadius=\"" + polarRadius.ToString(CultureInfo.InvariantCulture) + "\" flattening=\"" + flattening.ToString(CultureInfo.InvariantCulture) + "\"/>\n");
        }

        [Fact]
        public void TestGetInstanceOfEllipsoidFischer1960Modified()
        {
            Type ellipsoidType = typeof(Ellipsoids.Fischer1960Modified);
            double equatorialRadius = 6378155.0;
            double inverseFlattening = 298.3;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            e.Should().NotBeNull();
            e.GetType().Name.Should().Be(ellipsoidType.Name);
            e.Name.Should().Be(ellipsoidType.Name);
            e.Key.Should().Be(ellipsoidType.Name);
            e.EquatorialRadius.Should().Be(equatorialRadius);
            e.Flattening.Should().Be(flattening);
            e.PolarRadius.Should().Be(equatorialRadius - (flattening * equatorialRadius));
            e.InverseFlattening.Should().Be(inverseFlattening);
            e.FirstEccentricitySquared.Should().Be(firstEccentricitySquared);
            e.SecondEccentricitySquared.Should().Be(secondEccentricitySquared);
            e.ToString().Should().Be("[" + ellipsoidType.Name + ":  " +
                          "EquatorialRadius=" + equatorialRadius.ToString(CultureInfo.InvariantCulture) +
                          ", PolarRadius=" + polarRadius.ToString(CultureInfo.InvariantCulture) +
                          ", Flattening=" + flattening.ToString(CultureInfo.InvariantCulture) + "]");
            e.ToXml().Should().Be("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString(CultureInfo.InvariantCulture) + "\" polarRadius=\"" + polarRadius.ToString(CultureInfo.InvariantCulture) + "\" flattening=\"" + flattening.ToString(CultureInfo.InvariantCulture) + "\"/>\n");
        }

        [Fact]
        public void TestGetInstanceOfEllipsoidHelmert1906()
        {
            Type ellipsoidType = typeof(Ellipsoids.Helmert1906);
            double equatorialRadius = 6378200.0;
            double inverseFlattening = 298.3;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            e.Should().NotBeNull();
            e.GetType().Name.Should().Be(ellipsoidType.Name);
            e.Name.Should().Be(ellipsoidType.Name);
            e.Key.Should().Be(ellipsoidType.Name);
            e.EquatorialRadius.Should().Be(equatorialRadius);
            e.Flattening.Should().Be(flattening);
            e.PolarRadius.Should().Be(equatorialRadius - (flattening * equatorialRadius));
            e.InverseFlattening.Should().Be(inverseFlattening);
            e.FirstEccentricitySquared.Should().Be(firstEccentricitySquared);
            e.SecondEccentricitySquared.Should().Be(secondEccentricitySquared);
            e.ToString().Should().Be("[" + ellipsoidType.Name + ":  " +
                          "EquatorialRadius=" + equatorialRadius.ToString(CultureInfo.InvariantCulture) +
                          ", PolarRadius=" + polarRadius.ToString(CultureInfo.InvariantCulture) +
                          ", Flattening=" + flattening.ToString(CultureInfo.InvariantCulture) + "]");
            e.ToXml().Should().Be("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString(CultureInfo.InvariantCulture) + "\" polarRadius=\"" + polarRadius.ToString(CultureInfo.InvariantCulture) + "\" flattening=\"" + flattening.ToString(CultureInfo.InvariantCulture) + "\"/>\n");
        }

        [Fact]
        public void TestGetInstanceOfEllipsoidHough1960()
        {
            Type ellipsoidType = typeof(Ellipsoids.Hough1960);
            double equatorialRadius = 6378270.0;
            double inverseFlattening = 297.0;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            e.Should().NotBeNull();
            e.GetType().Name.Should().Be(ellipsoidType.Name);
            e.Name.Should().Be(ellipsoidType.Name);
            e.Key.Should().Be(ellipsoidType.Name);
            e.EquatorialRadius.Should().Be(equatorialRadius);
            e.Flattening.Should().Be(flattening);
            e.PolarRadius.Should().Be(equatorialRadius - (flattening * equatorialRadius));
            e.InverseFlattening.Should().Be(inverseFlattening);
            e.FirstEccentricitySquared.Should().Be(firstEccentricitySquared);
            e.SecondEccentricitySquared.Should().Be(secondEccentricitySquared);
            e.ToString().Should().Be("[" + ellipsoidType.Name + ":  " +
                         "EquatorialRadius=" + equatorialRadius.ToString(CultureInfo.InvariantCulture) +
                         ", PolarRadius=" + polarRadius.ToString(CultureInfo.InvariantCulture) +
                         ", Flattening=" + flattening.ToString(CultureInfo.InvariantCulture) + "]");
            e.ToXml().Should().Be("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString(CultureInfo.InvariantCulture) + "\" polarRadius=\"" + polarRadius.ToString(CultureInfo.InvariantCulture) + "\" flattening=\"" + flattening.ToString(CultureInfo.InvariantCulture) + "\"/>\n");
        }

        [Fact]
        public void TestGetInstanceOfEllipsoidIndonesian()
        {
            Type ellipsoidType = typeof(Ellipsoids.Indonesian);
            double equatorialRadius = 6378160.0;
            double inverseFlattening = 298.247;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            e.Should().NotBeNull();
            e.GetType().Name.Should().Be(ellipsoidType.Name);
            e.Name.Should().Be(ellipsoidType.Name);
            e.Key.Should().Be(ellipsoidType.Name);
            e.EquatorialRadius.Should().Be(equatorialRadius);
            e.Flattening.Should().Be(flattening);
            e.PolarRadius.Should().Be(equatorialRadius - (flattening * equatorialRadius));
            e.InverseFlattening.Should().Be(inverseFlattening);
            e.FirstEccentricitySquared.Should().Be(firstEccentricitySquared);
            e.SecondEccentricitySquared.Should().Be(secondEccentricitySquared);
            e.ToString().Should().Be("[" + ellipsoidType.Name + ":  " +
                           "EquatorialRadius=" + equatorialRadius.ToString(CultureInfo.InvariantCulture) +
                           ", PolarRadius=" + polarRadius.ToString(CultureInfo.InvariantCulture) +
                           ", Flattening=" + flattening.ToString(CultureInfo.InvariantCulture) + "]");
            e.ToXml().Should().Be("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString(CultureInfo.InvariantCulture) + "\" polarRadius=\"" + polarRadius.ToString(CultureInfo.InvariantCulture) + "\" flattening=\"" + flattening.ToString(CultureInfo.InvariantCulture) + "\"/>\n");
        }

        [Fact]
        public void TestGetInstanceOfEllipsoidInternational1924()
        {
            Type ellipsoidType = typeof(Ellipsoids.International1924);
            double equatorialRadius = 6378388.0;
            double inverseFlattening = 297.0;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            e.Should().NotBeNull();
            e.GetType().Name.Should().Be(ellipsoidType.Name);
            e.Name.Should().Be(ellipsoidType.Name);
            e.Key.Should().Be(ellipsoidType.Name);
            e.EquatorialRadius.Should().Be(equatorialRadius);
            e.Flattening.Should().Be(flattening);
            e.PolarRadius.Should().Be(equatorialRadius - (flattening * equatorialRadius));
            e.InverseFlattening.Should().Be(inverseFlattening);
            e.FirstEccentricitySquared.Should().Be(firstEccentricitySquared);
            e.SecondEccentricitySquared.Should().Be(secondEccentricitySquared);
            e.ToString().Should().Be("[" + ellipsoidType.Name + ":  " +
                            "EquatorialRadius=" + equatorialRadius.ToString(CultureInfo.InvariantCulture) +
                            ", PolarRadius=" + polarRadius.ToString(CultureInfo.InvariantCulture) +
                            ", Flattening=" + flattening.ToString(CultureInfo.InvariantCulture) + "]");
            e.ToXml().Should().Be("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString(CultureInfo.InvariantCulture) + "\" polarRadius=\"" + polarRadius.ToString(CultureInfo.InvariantCulture) + "\" flattening=\"" + flattening.ToString(CultureInfo.InvariantCulture) + "\"/>\n");
        }

        [Fact]
        public void TestGetInstanceOfEllipsoidKrasovsky1940()
        {
            Type ellipsoidType = typeof(Ellipsoids.Krasovsky1940);
            double equatorialRadius = 6378245.0;
            double inverseFlattening = 298.3;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            e.Should().NotBeNull();
            e.GetType().Name.Should().Be(ellipsoidType.Name);
            e.Name.Should().Be(ellipsoidType.Name);
            e.Key.Should().Be(ellipsoidType.Name);
            e.EquatorialRadius.Should().Be(equatorialRadius);
            e.Flattening.Should().Be(flattening);
            e.PolarRadius.Should().Be(equatorialRadius - (flattening * equatorialRadius));
            e.InverseFlattening.Should().Be(inverseFlattening);
            e.FirstEccentricitySquared.Should().Be(firstEccentricitySquared);
            e.SecondEccentricitySquared.Should().Be(secondEccentricitySquared);
            e.ToString().Should().Be("[" + ellipsoidType.Name + ":  " +
                           "EquatorialRadius=" + equatorialRadius.ToString(CultureInfo.InvariantCulture) +
                           ", PolarRadius=" + polarRadius.ToString(CultureInfo.InvariantCulture) +
                           ", Flattening=" + flattening.ToString(CultureInfo.InvariantCulture) + "]");
            e.ToXml().Should().Be("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString(CultureInfo.InvariantCulture) + "\" polarRadius=\"" + polarRadius.ToString(CultureInfo.InvariantCulture) + "\" flattening=\"" + flattening.ToString(CultureInfo.InvariantCulture) + "\"/>\n");
        }

        [Fact]
        public void TestGetInstanceOfEllipsoidGrs1980()
        {
            Type ellipsoidType = typeof(Ellipsoids.Grs1980);
            double equatorialRadius = 6378137.0;
            double inverseFlattening = 298.257222101;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            e.Should().NotBeNull();
            e.GetType().Name.Should().Be(ellipsoidType.Name);
            e.Name.Should().Be(ellipsoidType.Name);
            e.Key.Should().Be(ellipsoidType.Name);
            e.EquatorialRadius.Should().Be(equatorialRadius);
            e.Flattening.Should().Be(flattening);
            e.PolarRadius.Should().Be(equatorialRadius - (flattening * equatorialRadius));
            e.InverseFlattening.Should().Be(inverseFlattening);
            e.FirstEccentricitySquared.Should().Be(firstEccentricitySquared);
            e.SecondEccentricitySquared.Should().Be(secondEccentricitySquared);
            e.ToString().Should().Be("[" + ellipsoidType.Name + ":  " +
                          "EquatorialRadius=" + equatorialRadius.ToString(CultureInfo.InvariantCulture) +
                          ", PolarRadius=" + polarRadius.ToString(CultureInfo.InvariantCulture) +
                          ", Flattening=" + flattening.ToString(CultureInfo.InvariantCulture) + "]");
            e.ToXml().Should().Be("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString(CultureInfo.InvariantCulture) + "\" polarRadius=\"" + polarRadius.ToString(CultureInfo.InvariantCulture) + "\" flattening=\"" + flattening.ToString(CultureInfo.InvariantCulture) + "\"/>\n");
        }

        [Fact]
        public void TestGetInstanceOfEllipsoidSouthAmerican1969()
        {
            Type ellipsoidType = typeof(Ellipsoids.SouthAmerican1969);
            double equatorialRadius = 6378160.0;
            double inverseFlattening = 298.25;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            e.Should().NotBeNull();
            e.GetType().Name.Should().Be(ellipsoidType.Name);
            e.Name.Should().Be(ellipsoidType.Name);
            e.Key.Should().Be(ellipsoidType.Name);
            e.EquatorialRadius.Should().Be(equatorialRadius);
            e.Flattening.Should().Be(flattening);
            e.PolarRadius.Should().Be(equatorialRadius - (flattening * equatorialRadius));
            e.InverseFlattening.Should().Be(inverseFlattening);
            e.FirstEccentricitySquared.Should().Be(firstEccentricitySquared);
            e.SecondEccentricitySquared.Should().Be(secondEccentricitySquared);
            e.ToString().Should().Be("[" + ellipsoidType.Name + ":  " +
                          "EquatorialRadius=" + equatorialRadius.ToString(CultureInfo.InvariantCulture) +
                          ", PolarRadius=" + polarRadius.ToString(CultureInfo.InvariantCulture) +
                          ", Flattening=" + flattening.ToString(CultureInfo.InvariantCulture) + "]");
            e.ToXml().Should().Be("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString(CultureInfo.InvariantCulture) + "\" polarRadius=\"" + polarRadius.ToString(CultureInfo.InvariantCulture) + "\" flattening=\"" + flattening.ToString(CultureInfo.InvariantCulture) + "\"/>\n");
        }

        [Fact]
        public void TestGetInstanceOfEllipsoidWgs1972()
        {
            Type ellipsoidType = typeof(Ellipsoids.Wgs1972);
            double equatorialRadius = 6378135.0;
            double inverseFlattening = 298.26;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            e.Should().NotBeNull();
            e.GetType().Name.Should().Be(ellipsoidType.Name);
            e.Name.Should().Be(ellipsoidType.Name);
            e.Key.Should().Be(ellipsoidType.Name);
            e.EquatorialRadius.Should().Be(equatorialRadius);
            e.Flattening.Should().Be(flattening);
            e.PolarRadius.Should().Be(equatorialRadius - (flattening * equatorialRadius));
            e.InverseFlattening.Should().Be(inverseFlattening);
            e.FirstEccentricitySquared.Should().Be(firstEccentricitySquared);
            e.SecondEccentricitySquared.Should().Be(secondEccentricitySquared);
            e.ToString().Should().Be("[" + ellipsoidType.Name + ":  " +
                           "EquatorialRadius=" + equatorialRadius.ToString(CultureInfo.InvariantCulture) +
                           ", PolarRadius=" + polarRadius.ToString(CultureInfo.InvariantCulture) +
                           ", Flattening=" + flattening.ToString(CultureInfo.InvariantCulture) + "]");
            e.ToXml().Should().Be("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString(CultureInfo.InvariantCulture) + "\" polarRadius=\"" + polarRadius.ToString(CultureInfo.InvariantCulture) + "\" flattening=\"" + flattening.ToString(CultureInfo.InvariantCulture) + "\"/>\n");
        }

        [Fact]
        public void TestGetInstanceOfEllipsoidWgs1984()
        {
            Type ellipsoidType = typeof(Ellipsoids.Wgs1984);
            double equatorialRadius = 6378137.0;
            double inverseFlattening = 298.257223563;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            e.Should().NotBeNull();
            e.GetType().Name.Should().Be(ellipsoidType.Name);
            e.Name.Should().Be(ellipsoidType.Name);
            e.Key.Should().Be(ellipsoidType.Name);
            e.EquatorialRadius.Should().Be(equatorialRadius);
            e.Flattening.Should().Be(flattening);
            e.PolarRadius.Should().Be(equatorialRadius - (flattening * equatorialRadius));
            e.InverseFlattening.Should().Be(inverseFlattening);
            e.FirstEccentricitySquared.Should().Be(firstEccentricitySquared);
            e.SecondEccentricitySquared.Should().Be(secondEccentricitySquared);
            e.ToString().Should().Be("[" + ellipsoidType.Name + ":  " +
                           "EquatorialRadius=" + equatorialRadius.ToString(CultureInfo.InvariantCulture) +
                           ", PolarRadius=" + polarRadius.ToString(CultureInfo.InvariantCulture) +
                           ", Flattening=" + flattening.ToString(CultureInfo.InvariantCulture) + "]");
            e.ToXml().Should().Be("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString(CultureInfo.InvariantCulture) + "\" polarRadius=\"" + polarRadius.ToString(CultureInfo.InvariantCulture) + "\" flattening=\"" + flattening.ToString(CultureInfo.InvariantCulture) + "\"/>\n");
        }

        [Fact]
        public void TestSingleton()
        {
            IEllipsoid e1 = EllipsoidFactory.GetInstanceOfEllipsoid(typeof(Ellipsoids.Wgs1984));
            IEllipsoid e2 = EllipsoidFactory.GetInstanceOfEllipsoid(typeof(Ellipsoids.Wgs1984));
            e1.Should().BeSameAs(e2);
        }

        [Fact]
        public void TestGetInstanceOfEllipsoidUndefined()
        {
            Action act = () => EllipsoidFactory.GetInstanceOfEllipsoid(typeof(Ellipsoids.Undefined));
            act.Should().Throw<InvalidEllipsoidTypeException>();
        }

        [Fact]
        public void TestGetInstanceOfEllipsoidUserDefined()
        {
            Action act = () => EllipsoidFactory.GetInstanceOfEllipsoid(typeof(Ellipsoids.UserDefined));
            act.Should().Throw<AmbiguousEllipsoidTypeException>();
        }

        #endregion


        #region UserDefined Instantiation

        [Fact]
        public void TestGetUserDefinedInstances()
        {
            string name = "asdf";
            double equatorialRadius = 6378135.0;
            double inverseFlattening = 298.0;
            double flattening = 1 / inverseFlattening;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            EllipsoidFactory.UserDefinedEllipsoidExists(name).Should().Be(false);
            EllipsoidFactory.UserDefinedEllipsoidExists(name, equatorialRadius, 1 / inverseFlattening).Should().Be(false);

            IEllipsoid e1 = EllipsoidFactory.GetInstanceOfNewUserDefinedEllipsoid(name, equatorialRadius, 1 / inverseFlattening);
            e1.Should().NotBeNull();
            e1.GetType().Name.Should().Be(typeof(Ellipsoids.UserDefined).Name);
            e1.Name.Should().Be(name);
            e1.Key.Should().Be(typeof(Ellipsoids.UserDefined).Name + name);
            e1.EquatorialRadius.Should().Be(equatorialRadius);
            e1.Flattening.Should().Be(flattening);
            e1.PolarRadius.Should().Be(e1.EquatorialRadius - (e1.Flattening * e1.EquatorialRadius));
            e1.InverseFlattening.Should().Be(inverseFlattening);
            e1.FirstEccentricitySquared.Should().Be((2 * e1.Flattening) - (e1.Flattening * e1.Flattening));
            e1.ToString().Should().Be("[" + typeof(Ellipsoids.UserDefined).Name + ":  " +
                           "Name='" + name + "'" +
                           ", EquatorialRadius=" + equatorialRadius.ToString(CultureInfo.InvariantCulture) +
                           ", PolarRadius=" + polarRadius.ToString(CultureInfo.InvariantCulture) +
                           ", Flattening=" + flattening.ToString(CultureInfo.InvariantCulture) + "]");
            e1.ToXml().Should().Be("<ellipsoid ellipsoidType=\"" + typeof(Ellipsoids.UserDefined).Name + "\" name=\"" + e1.Name + "\" equatorialRadius=\"" + e1.EquatorialRadius.ToString(CultureInfo.InvariantCulture) + "\" polarRadius=\"" + e1.PolarRadius.ToString(CultureInfo.InvariantCulture) + "\" flattening=\"" + e1.Flattening.ToString(CultureInfo.InvariantCulture) + "\"/>\n");

            IEllipsoid e2 = EllipsoidFactory.GetInstanceOfExistingUserDefinedEllipsoid(name);
            e1.Should().BeSameAs(e2);

            EllipsoidFactory.UserDefinedEllipsoidExists(name).Should().Be(true);
            EllipsoidFactory.UserDefinedEllipsoidExists(name, equatorialRadius, 1 / inverseFlattening).Should().Be(true);

            EllipsoidFactory.UserDefinedEllipsoidExists(name, equatorialRadius, 1 / 298.1).Should().Be(false);
            EllipsoidFactory.UserDefinedEllipsoidExists(name, 6378135.1, 1 / inverseFlattening).Should().Be(false);

            IEllipsoid e3 = EllipsoidFactory.GetInstanceOfNewUserDefinedEllipsoid(name, equatorialRadius, 1 / inverseFlattening);
            e1.Should().BeSameAs(e3);
        }

        [Fact]
        public void TestGetInstanceOfNewUserDefinedEllipsoidNull()
        {
            string? name = null;
            Action act = () => EllipsoidFactory.GetInstanceOfNewUserDefinedEllipsoid(name, 6378135.0, 1 / 298.0);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestGetInstanceOfNewUserDefinedEllipsoidFormat()
        {
            string name = "as$df";
            Action act = () => EllipsoidFactory.GetInstanceOfNewUserDefinedEllipsoid(name, 6378135.0, 1 / 298.0);
            act.Should().Throw<InvalidEllipsoidTypeException>();
        }

        [Fact]
        public void TestGetInstanceOfExistingUserDefinedEllipsoidNull()
        {
            string? name = null;
            Action act = () => EllipsoidFactory.GetInstanceOfExistingUserDefinedEllipsoid(name);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestGetInstanceOfExistingUserDefinedEllipsoidFormat()
        {
            string name = "as$df";
            Action act = () => EllipsoidFactory.GetInstanceOfExistingUserDefinedEllipsoid(name);
            act.Should().Throw<InvalidEllipsoidTypeException>();
        }


        #endregion
    }
}


