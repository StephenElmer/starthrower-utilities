using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarThrower.Gis.GeoUtilities.CoordinateSystems;
using StarThrower.Gis.GeoUtilities.Ellipsoids;
using StarThrower.Gis.GeoUtilities.Exceptions;

namespace StarThrower.Gis.GeoUtilities.Test
{
    [TestClass]
    public class EllipsoidTest
    {
        private void Ignore()
        {
#if FAIL_ON_IGNORE
                Assert.Fail("This test has been ignored.");
#else
            Assert.Inconclusive("this test has been ignored");
#endif
        }


        #region Non-UserDefined Instantiation

        [TestMethod]
        public void TestGetInsanceOfEllipsoid_WGS_1984()
        {
            Type ellipsoidType = typeof(Ellipsoids.Wgs1984);
            double equatorialRadius = 6378137.0;
            double inverseFlattening = 298.257223563;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            Assert.IsNotNull(e);
            Assert.AreEqual(ellipsoidType.Name, e.GetType().Name);
            Assert.AreEqual(ellipsoidType.Name, e.Name);
            Assert.AreEqual(ellipsoidType.Name, e.Key);
            Assert.AreEqual(equatorialRadius, e.EquatorialRadius);
            Assert.AreEqual(flattening, e.Flattening);
            Assert.AreEqual(equatorialRadius - (flattening * equatorialRadius), e.PolarRadius);
            Assert.AreEqual(inverseFlattening, e.InverseFlattening);
            Assert.AreEqual(firstEccentricitySquared, e.FirstEccentricitySquared);
            Assert.AreEqual(secondEccentricitySquared, e.SecondEccentricitySquared);
            Assert.AreEqual("[" + ellipsoidType.Name + ":  " +
                            "EquatorialRadius=" + equatorialRadius.ToString() +
                            ", PolarRadius=" + polarRadius.ToString() +
                            ", Flattening=" + flattening.ToString() + "]", e.ToString());
            Assert.AreEqual("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString() + "\" polarRadius=\"" + polarRadius.ToString() + "\" flattening=\"" + flattening.ToString() + "\"/>\n", e.ToXml());
        }

        [TestMethod]
        public void TestGetInstanceOfEllipsoid_Airy_Modified()
        {
            Type ellipsoidType = typeof(Ellipsoids.AiryModified);
            double equatorialRadius = 6377340.189;
            double inverseFlattening = 299.3249646;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            Assert.IsNotNull(e);
            Assert.AreEqual(ellipsoidType.Name, e.GetType().Name);
            Assert.AreEqual(ellipsoidType.Name, e.Name);
            Assert.AreEqual(ellipsoidType.Name, e.Key);
            Assert.AreEqual(equatorialRadius, e.EquatorialRadius);
            Assert.AreEqual(flattening, e.Flattening);
            Assert.AreEqual(equatorialRadius - (flattening * equatorialRadius), e.PolarRadius);
            Assert.AreEqual(inverseFlattening, e.InverseFlattening);
            Assert.AreEqual(firstEccentricitySquared, e.FirstEccentricitySquared);
            Assert.AreEqual(secondEccentricitySquared, e.SecondEccentricitySquared);
            Assert.AreEqual("[" + ellipsoidType.Name + ":  " +
                            "EquatorialRadius=" + equatorialRadius.ToString() +
                            ", PolarRadius=" + polarRadius.ToString() +
                            ", Flattening=" + flattening.ToString() + "]", e.ToString());
            Assert.AreEqual("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString() + "\" polarRadius=\"" + polarRadius.ToString() + "\" flattening=\"" + flattening.ToString() + "\"/>\n", e.ToXml());
        }

        [TestMethod]
        public void TestGetInstanceOfEllipsoid_Australian()
        {
            Type ellipsoidType = typeof(Ellipsoids.Australian);
            double equatorialRadius = 6378160.0;
            double inverseFlattening = 298.25;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            Assert.IsNotNull(e);
            Assert.AreEqual(ellipsoidType.Name, e.GetType().Name);
            Assert.AreEqual(ellipsoidType.Name, e.Name);
            Assert.AreEqual(ellipsoidType.Name, e.Key);
            Assert.AreEqual(equatorialRadius, e.EquatorialRadius);
            Assert.AreEqual(flattening, e.Flattening);
            Assert.AreEqual(equatorialRadius - (flattening * equatorialRadius), e.PolarRadius);
            Assert.AreEqual(inverseFlattening, e.InverseFlattening);
            Assert.AreEqual(firstEccentricitySquared, e.FirstEccentricitySquared);
            Assert.AreEqual(secondEccentricitySquared, e.SecondEccentricitySquared);
            Assert.AreEqual("[" + ellipsoidType.Name + ":  " +
                           "EquatorialRadius=" + equatorialRadius.ToString() +
                           ", PolarRadius=" + polarRadius.ToString() +
                           ", Flattening=" + flattening.ToString() + "]", e.ToString());
            Assert.AreEqual("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString() + "\" polarRadius=\"" + polarRadius.ToString() + "\" flattening=\"" + flattening.ToString() + "\"/>\n", e.ToXml());
        }

        [TestMethod]
        public void TestGetInstanceOfEllipsoid_Bessel_Namibia()
        {
            Type ellipsoidType = typeof(Ellipsoids.BesselNamibia);
            double equatorialRadius = 6377483.865;
            double inverseFlattening = 299.1528128;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            Assert.IsNotNull(e);
            Assert.AreEqual(ellipsoidType.Name, e.GetType().Name);
            Assert.AreEqual(ellipsoidType.Name, e.Name);
            Assert.AreEqual(ellipsoidType.Name, e.Key);
            Assert.AreEqual(equatorialRadius, e.EquatorialRadius);
            Assert.AreEqual(flattening, e.Flattening);
            Assert.AreEqual(equatorialRadius - (flattening * equatorialRadius), e.PolarRadius);
            Assert.AreEqual(inverseFlattening, e.InverseFlattening);
            Assert.AreEqual(firstEccentricitySquared, e.FirstEccentricitySquared);
            Assert.AreEqual(secondEccentricitySquared, e.SecondEccentricitySquared);
            Assert.AreEqual("[" + ellipsoidType.Name + ":  " +
                          "EquatorialRadius=" + equatorialRadius.ToString() +
                          ", PolarRadius=" + polarRadius.ToString() +
                          ", Flattening=" + flattening.ToString() + "]", e.ToString());
            Assert.AreEqual("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString() + "\" polarRadius=\"" + polarRadius.ToString() + "\" flattening=\"" + flattening.ToString() + "\"/>\n", e.ToXml());
        }

        [TestMethod]
        public void TestGetInstanceOfEllipsoid_Bessel_1841()
        {
            Type ellipsoidType = typeof(Ellipsoids.Bessel1841);
            double equatorialRadius = 6377397.155;
            double inverseFlattening = 299.1528128;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            Assert.IsNotNull(e);
            Assert.AreEqual(ellipsoidType.Name, e.GetType().Name);
            Assert.AreEqual(ellipsoidType.Name, e.Name);
            Assert.AreEqual(ellipsoidType.Name, e.Key);
            Assert.AreEqual(equatorialRadius, e.EquatorialRadius);
            Assert.AreEqual(flattening, e.Flattening);
            Assert.AreEqual(equatorialRadius - (flattening * equatorialRadius), e.PolarRadius);
            Assert.AreEqual(inverseFlattening, e.InverseFlattening);
            Assert.AreEqual(firstEccentricitySquared, e.FirstEccentricitySquared);
            Assert.AreEqual(secondEccentricitySquared, e.SecondEccentricitySquared);
            Assert.AreEqual("[" + ellipsoidType.Name + ":  " +
                          "EquatorialRadius=" + equatorialRadius.ToString() +
                          ", PolarRadius=" + polarRadius.ToString() +
                          ", Flattening=" + flattening.ToString() + "]", e.ToString());
            Assert.AreEqual("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString() + "\" polarRadius=\"" + polarRadius.ToString() + "\" flattening=\"" + flattening.ToString() + "\"/>\n", e.ToXml());
        }

        [TestMethod]
        public void TestGetInstanceOfEllipsoid_Clarke_1866()
        {
            Type ellipsoidType = typeof(Ellipsoids.Clarke1866);
            double equatorialRadius = 6378206.4;
            double inverseFlattening = 294.9786982;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            Assert.IsNotNull(e);
            Assert.AreEqual(ellipsoidType.Name, e.GetType().Name);
            Assert.AreEqual(ellipsoidType.Name, e.Name);
            Assert.AreEqual(ellipsoidType.Name, e.Key);
            Assert.AreEqual(equatorialRadius, e.EquatorialRadius);
            Assert.AreEqual(flattening, e.Flattening);
            Assert.AreEqual(equatorialRadius - (flattening * equatorialRadius), e.PolarRadius);
            Assert.AreEqual(inverseFlattening, e.InverseFlattening);
            Assert.AreEqual(firstEccentricitySquared, e.FirstEccentricitySquared);
            Assert.AreEqual(secondEccentricitySquared, e.SecondEccentricitySquared);
            Assert.AreEqual("[" + ellipsoidType.Name + ":  " +
                         "EquatorialRadius=" + equatorialRadius.ToString() +
                         ", PolarRadius=" + polarRadius.ToString() +
                         ", Flattening=" + flattening.ToString() + "]", e.ToString());
            Assert.AreEqual("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString() + "\" polarRadius=\"" + polarRadius.ToString() + "\" flattening=\"" + flattening.ToString() + "\"/>\n", e.ToXml());
        }

        [TestMethod]
        public void TestGetInstanceOfEllipsoid_Clarke_1880_RGS()
        {
            Type ellipsoidType = typeof(Ellipsoids.Clarke1880Rgs);
            double equatorialRadius = 6378249.145;
            double inverseFlattening = 293.465;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            Assert.IsNotNull(e);
            Assert.AreEqual(ellipsoidType.Name, e.GetType().Name);
            Assert.AreEqual(ellipsoidType.Name, e.Name);
            Assert.AreEqual(ellipsoidType.Name, e.Key);
            Assert.AreEqual(equatorialRadius, e.EquatorialRadius);
            Assert.AreEqual(flattening, e.Flattening);
            Assert.AreEqual(equatorialRadius - (flattening * equatorialRadius), e.PolarRadius);
            Assert.AreEqual(inverseFlattening, e.InverseFlattening);
            Assert.AreEqual(firstEccentricitySquared, e.FirstEccentricitySquared);
            Assert.AreEqual(secondEccentricitySquared, e.SecondEccentricitySquared);
            Assert.AreEqual("[" + ellipsoidType.Name + ":  " +
                           "EquatorialRadius=" + equatorialRadius.ToString() +
                           ", PolarRadius=" + polarRadius.ToString() +
                           ", Flattening=" + flattening.ToString() + "]", e.ToString());
            Assert.AreEqual("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString() + "\" polarRadius=\"" + polarRadius.ToString() + "\" flattening=\"" + flattening.ToString() + "\"/>\n", e.ToXml());
        }

        [TestMethod]
        public void TestGetInstanceOfEllipsoid_Everest_Adjustment_1937()
        {
            Type ellipsoidType = typeof(Ellipsoids.EverestAdjustment1937);
            double equatorialRadius = 6377276.345;
            double inverseFlattening = 300.8017;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            Assert.IsNotNull(e);
            Assert.AreEqual(ellipsoidType.Name, e.GetType().Name);
            Assert.AreEqual(ellipsoidType.Name, e.Name);
            Assert.AreEqual(ellipsoidType.Name, e.Key);
            Assert.AreEqual(equatorialRadius, e.EquatorialRadius);
            Assert.AreEqual(flattening, e.Flattening);
            Assert.AreEqual(equatorialRadius - (flattening * equatorialRadius), e.PolarRadius);
            Assert.AreEqual(inverseFlattening, e.InverseFlattening);
            Assert.AreEqual(firstEccentricitySquared, e.FirstEccentricitySquared);
            Assert.AreEqual(secondEccentricitySquared, e.SecondEccentricitySquared);
            Assert.AreEqual("[" + ellipsoidType.Name + ":  " +
                           "EquatorialRadius=" + equatorialRadius.ToString() +
                           ", PolarRadius=" + polarRadius.ToString() +
                           ", Flattening=" + flattening.ToString() + "]", e.ToString());
            Assert.AreEqual("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString() + "\" polarRadius=\"" + polarRadius.ToString() + "\" flattening=\"" + flattening.ToString() + "\"/>\n", e.ToXml());
        }

        [TestMethod]
        public void TestGetInstanceOfEllipsoid_Everest_Definition_1967()
        {
            Type ellipsoidType = typeof(Ellipsoids.EverestDefinition1967);
            double equatorialRadius = 6377298.556;
            double inverseFlattening = 300.8017;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            Assert.IsNotNull(e);
            Assert.AreEqual(ellipsoidType.Name, e.GetType().Name);
            Assert.AreEqual(ellipsoidType.Name, e.Name);
            Assert.AreEqual(ellipsoidType.Name, e.Key);
            Assert.AreEqual(equatorialRadius, e.EquatorialRadius);
            Assert.AreEqual(flattening, e.Flattening);
            Assert.AreEqual(equatorialRadius - (flattening * equatorialRadius), e.PolarRadius);
            Assert.AreEqual(inverseFlattening, e.InverseFlattening);
            Assert.AreEqual(firstEccentricitySquared, e.FirstEccentricitySquared);
            Assert.AreEqual(secondEccentricitySquared, e.SecondEccentricitySquared);
            Assert.AreEqual("[" + ellipsoidType.Name + ":  " +
                          "EquatorialRadius=" + equatorialRadius.ToString() +
                          ", PolarRadius=" + polarRadius.ToString() +
                          ", Flattening=" + flattening.ToString() + "]", e.ToString());
            Assert.AreEqual("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString() + "\" polarRadius=\"" + polarRadius.ToString() + "\" flattening=\"" + flattening.ToString() + "\"/>\n", e.ToXml());
        }

        [TestMethod]
        public void TestGetInstanceOfEllipsoid_Everest_1956_India()
        {
            Type ellipsoidType = typeof(Ellipsoids.Everest1956India);
            double equatorialRadius = 6377301.243;
            double inverseFlattening = 300.8017;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            Assert.IsNotNull(e);
            Assert.AreEqual(ellipsoidType.Name, e.GetType().Name);
            Assert.AreEqual(ellipsoidType.Name, e.Name);
            Assert.AreEqual(ellipsoidType.Name, e.Key);
            Assert.AreEqual(equatorialRadius, e.EquatorialRadius);
            Assert.AreEqual(flattening, e.Flattening);
            Assert.AreEqual(equatorialRadius - (flattening * equatorialRadius), e.PolarRadius);
            Assert.AreEqual(inverseFlattening, e.InverseFlattening);
            Assert.AreEqual(firstEccentricitySquared, e.FirstEccentricitySquared);
            Assert.AreEqual(secondEccentricitySquared, e.SecondEccentricitySquared);
            Assert.AreEqual("[" + ellipsoidType.Name + ":  " +
                          "EquatorialRadius=" + equatorialRadius.ToString() +
                          ", PolarRadius=" + polarRadius.ToString() +
                          ", Flattening=" + flattening.ToString() + "]", e.ToString());
            Assert.AreEqual("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString() + "\" polarRadius=\"" + polarRadius.ToString() + "\" flattening=\"" + flattening.ToString() + "\"/>\n", e.ToXml());
        }

        [TestMethod]
        public void TestGetInstanceOfEllipsoid_Everest_Modified_1969()
        {
            Type ellipsoidType = typeof(Ellipsoids.EverestModified1969);
            double equatorialRadius = 6377295.664;
            double inverseFlattening = 300.8017;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            Assert.IsNotNull(e);
            Assert.AreEqual(ellipsoidType.Name, e.GetType().Name);
            Assert.AreEqual(ellipsoidType.Name, e.Name);
            Assert.AreEqual(ellipsoidType.Name, e.Key);
            Assert.AreEqual(equatorialRadius, e.EquatorialRadius);
            Assert.AreEqual(flattening, e.Flattening);
            Assert.AreEqual(equatorialRadius - (flattening * equatorialRadius), e.PolarRadius);
            Assert.AreEqual(inverseFlattening, e.InverseFlattening);
            Assert.AreEqual(firstEccentricitySquared, e.FirstEccentricitySquared);
            Assert.AreEqual(secondEccentricitySquared, e.SecondEccentricitySquared);
            Assert.AreEqual("[" + ellipsoidType.Name + ":  " +
                           "EquatorialRadius=" + equatorialRadius.ToString() +
                           ", PolarRadius=" + polarRadius.ToString() +
                           ", Flattening=" + flattening.ToString() + "]", e.ToString());
            Assert.AreEqual("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString() + "\" polarRadius=\"" + polarRadius.ToString() + "\" flattening=\"" + flattening.ToString() + "\"/>\n", e.ToXml());
        }

        [TestMethod]
        public void TestGetInstanceOfEllipsoid_Everest_1830_Modified()
        {
            Type ellipsoidType = typeof(Ellipsoids.Everest1830Modified);
            double equatorialRadius = 6377304.063;
            double inverseFlattening = 300.8017;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            Assert.IsNotNull(e);
            Assert.AreEqual(ellipsoidType.Name, e.GetType().Name);
            Assert.AreEqual(ellipsoidType.Name, e.Name);
            Assert.AreEqual(ellipsoidType.Name, e.Key);
            Assert.AreEqual(equatorialRadius, e.EquatorialRadius);
            Assert.AreEqual(flattening, e.Flattening);
            Assert.AreEqual(equatorialRadius - (flattening * equatorialRadius), e.PolarRadius);
            Assert.AreEqual(inverseFlattening, e.InverseFlattening);
            Assert.AreEqual(firstEccentricitySquared, e.FirstEccentricitySquared);
            Assert.AreEqual(secondEccentricitySquared, e.SecondEccentricitySquared);
            Assert.AreEqual("[" + ellipsoidType.Name + ":  " +
                           "EquatorialRadius=" + equatorialRadius.ToString() +
                           ", PolarRadius=" + polarRadius.ToString() +
                           ", Flattening=" + flattening.ToString() + "]", e.ToString());
            Assert.AreEqual("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString() + "\" polarRadius=\"" + polarRadius.ToString() + "\" flattening=\"" + flattening.ToString() + "\"/>\n", e.ToXml());
        }

        [TestMethod]
        public void TestGetInstanceOfEllipsoid_Everest_Pakistan()
        {
            Type ellipsoidType = typeof(Ellipsoids.EverestPakistan);
            double equatorialRadius = 6377309.613;
            double inverseFlattening = 300.8017;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            Assert.IsNotNull(e);
            Assert.AreEqual(ellipsoidType.Name, e.GetType().Name);
            Assert.AreEqual(ellipsoidType.Name, e.Name);
            Assert.AreEqual(ellipsoidType.Name, e.Key);
            Assert.AreEqual(equatorialRadius, e.EquatorialRadius);
            Assert.AreEqual(flattening, e.Flattening);
            Assert.AreEqual(equatorialRadius - (flattening * equatorialRadius), e.PolarRadius);
            Assert.AreEqual(inverseFlattening, e.InverseFlattening);
            Assert.AreEqual(firstEccentricitySquared, e.FirstEccentricitySquared);
            Assert.AreEqual(secondEccentricitySquared, e.SecondEccentricitySquared);
            Assert.AreEqual("[" + ellipsoidType.Name + ":  " +
                           "EquatorialRadius=" + equatorialRadius.ToString() +
                           ", PolarRadius=" + polarRadius.ToString() +
                           ", Flattening=" + flattening.ToString() + "]", e.ToString());
            Assert.AreEqual("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString() + "\" polarRadius=\"" + polarRadius.ToString() + "\" flattening=\"" + flattening.ToString() + "\"/>\n", e.ToXml());
        }

        [TestMethod]
        public void TestGetInstanceOfEllipsoid_Fischer_1960_Modified()
        {
            Type ellipsoidType = typeof(Ellipsoids.Fischer1960Modified);
            double equatorialRadius = 6378155.0;
            double inverseFlattening = 298.3;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            Assert.IsNotNull(e);
            Assert.AreEqual(ellipsoidType.Name, e.GetType().Name);
            Assert.AreEqual(ellipsoidType.Name, e.Name);
            Assert.AreEqual(ellipsoidType.Name, e.Key);
            Assert.AreEqual(equatorialRadius, e.EquatorialRadius);
            Assert.AreEqual(flattening, e.Flattening);
            Assert.AreEqual(equatorialRadius - (flattening * equatorialRadius), e.PolarRadius);
            Assert.AreEqual(inverseFlattening, e.InverseFlattening);
            Assert.AreEqual(firstEccentricitySquared, e.FirstEccentricitySquared);
            Assert.AreEqual(secondEccentricitySquared, e.SecondEccentricitySquared);
            Assert.AreEqual("[" + ellipsoidType.Name + ":  " +
                          "EquatorialRadius=" + equatorialRadius.ToString() +
                          ", PolarRadius=" + polarRadius.ToString() +
                          ", Flattening=" + flattening.ToString() + "]", e.ToString());
            Assert.AreEqual("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString() + "\" polarRadius=\"" + polarRadius.ToString() + "\" flattening=\"" + flattening.ToString() + "\"/>\n", e.ToXml());
        }

        [TestMethod]
        public void TestGetInstanceOfEllipsoid_Helmert_1906()
        {
            Type ellipsoidType = typeof(Ellipsoids.Helmert1906);
            double equatorialRadius = 6378200.0;
            double inverseFlattening = 298.3;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            Assert.IsNotNull(e);
            Assert.AreEqual(ellipsoidType.Name, e.GetType().Name);
            Assert.AreEqual(ellipsoidType.Name, e.Name);
            Assert.AreEqual(ellipsoidType.Name, e.Key);
            Assert.AreEqual(equatorialRadius, e.EquatorialRadius);
            Assert.AreEqual(flattening, e.Flattening);
            Assert.AreEqual(equatorialRadius - (flattening * equatorialRadius), e.PolarRadius);
            Assert.AreEqual(inverseFlattening, e.InverseFlattening);
            Assert.AreEqual(firstEccentricitySquared, e.FirstEccentricitySquared);
            Assert.AreEqual(secondEccentricitySquared, e.SecondEccentricitySquared);
            Assert.AreEqual("[" + ellipsoidType.Name + ":  " +
                          "EquatorialRadius=" + equatorialRadius.ToString() +
                          ", PolarRadius=" + polarRadius.ToString() +
                          ", Flattening=" + flattening.ToString() + "]", e.ToString());
            Assert.AreEqual("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString() + "\" polarRadius=\"" + polarRadius.ToString() + "\" flattening=\"" + flattening.ToString() + "\"/>\n", e.ToXml());
        }

        [TestMethod]
        public void TestGetInstanceOfEllipsoid_Hough_1960()
        {
            Type ellipsoidType = typeof(Ellipsoids.Hough1960);
            double equatorialRadius = 6378270.0;
            double inverseFlattening = 297.0;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            Assert.IsNotNull(e);
            Assert.AreEqual(ellipsoidType.Name, e.GetType().Name);
            Assert.AreEqual(ellipsoidType.Name, e.Name);
            Assert.AreEqual(ellipsoidType.Name, e.Key);
            Assert.AreEqual(equatorialRadius, e.EquatorialRadius);
            Assert.AreEqual(flattening, e.Flattening);
            Assert.AreEqual(equatorialRadius - (flattening * equatorialRadius), e.PolarRadius);
            Assert.AreEqual(inverseFlattening, e.InverseFlattening);
            Assert.AreEqual(firstEccentricitySquared, e.FirstEccentricitySquared);
            Assert.AreEqual(secondEccentricitySquared, e.SecondEccentricitySquared);
            Assert.AreEqual("[" + ellipsoidType.Name + ":  " +
                         "EquatorialRadius=" + equatorialRadius.ToString() +
                         ", PolarRadius=" + polarRadius.ToString() +
                         ", Flattening=" + flattening.ToString() + "]", e.ToString());
            Assert.AreEqual("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString() + "\" polarRadius=\"" + polarRadius.ToString() + "\" flattening=\"" + flattening.ToString() + "\"/>\n", e.ToXml());
        }

        [TestMethod]
        public void TestGetInstanceOfEllipsoid_Indonesian()
        {
            Type ellipsoidType = typeof(Ellipsoids.Indonesian);
            double equatorialRadius = 6378160.0;
            double inverseFlattening = 298.247;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            Assert.IsNotNull(e);
            Assert.AreEqual(ellipsoidType.Name, e.GetType().Name);
            Assert.AreEqual(ellipsoidType.Name, e.Name);
            Assert.AreEqual(ellipsoidType.Name, e.Key);
            Assert.AreEqual(equatorialRadius, e.EquatorialRadius);
            Assert.AreEqual(flattening, e.Flattening);
            Assert.AreEqual(equatorialRadius - (flattening * equatorialRadius), e.PolarRadius);
            Assert.AreEqual(inverseFlattening, e.InverseFlattening);
            Assert.AreEqual(firstEccentricitySquared, e.FirstEccentricitySquared);
            Assert.AreEqual(secondEccentricitySquared, e.SecondEccentricitySquared);
            Assert.AreEqual("[" + ellipsoidType.Name + ":  " +
                           "EquatorialRadius=" + equatorialRadius.ToString() +
                           ", PolarRadius=" + polarRadius.ToString() +
                           ", Flattening=" + flattening.ToString() + "]", e.ToString());
            Assert.AreEqual("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString() + "\" polarRadius=\"" + polarRadius.ToString() + "\" flattening=\"" + flattening.ToString() + "\"/>\n", e.ToXml());
        }

        [TestMethod]
        public void TestGetInstanceOfEllipsoid_International_1924()
        {
            Type ellipsoidType = typeof(Ellipsoids.International1924);
            double equatorialRadius = 6378388.0;
            double inverseFlattening = 297.0;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            Assert.IsNotNull(e);
            Assert.AreEqual(ellipsoidType.Name, e.GetType().Name);
            Assert.AreEqual(ellipsoidType.Name, e.Name);
            Assert.AreEqual(ellipsoidType.Name, e.Key);
            Assert.AreEqual(equatorialRadius, e.EquatorialRadius);
            Assert.AreEqual(flattening, e.Flattening);
            Assert.AreEqual(equatorialRadius - (flattening * equatorialRadius), e.PolarRadius);
            Assert.AreEqual(inverseFlattening, e.InverseFlattening);
            Assert.AreEqual(firstEccentricitySquared, e.FirstEccentricitySquared);
            Assert.AreEqual(secondEccentricitySquared, e.SecondEccentricitySquared);
            Assert.AreEqual("[" + ellipsoidType.Name + ":  " +
                            "EquatorialRadius=" + equatorialRadius.ToString() +
                            ", PolarRadius=" + polarRadius.ToString() +
                            ", Flattening=" + flattening.ToString() + "]", e.ToString());
            Assert.AreEqual("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString() + "\" polarRadius=\"" + polarRadius.ToString() + "\" flattening=\"" + flattening.ToString() + "\"/>\n", e.ToXml());
        }

        [TestMethod]
        public void TestGetInstanceOfEllipsoid_Krasovsky_1940()
        {
            Type ellipsoidType = typeof(Ellipsoids.Krasovsky1940);
            double equatorialRadius = 6378245.0;
            double inverseFlattening = 298.3;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            Assert.IsNotNull(e);
            Assert.AreEqual(ellipsoidType.Name, e.GetType().Name);
            Assert.AreEqual(ellipsoidType.Name, e.Name);
            Assert.AreEqual(ellipsoidType.Name, e.Key);
            Assert.AreEqual(equatorialRadius, e.EquatorialRadius);
            Assert.AreEqual(flattening, e.Flattening);
            Assert.AreEqual(equatorialRadius - (flattening * equatorialRadius), e.PolarRadius);
            Assert.AreEqual(inverseFlattening, e.InverseFlattening);
            Assert.AreEqual(firstEccentricitySquared, e.FirstEccentricitySquared);
            Assert.AreEqual(secondEccentricitySquared, e.SecondEccentricitySquared);
            Assert.AreEqual("[" + ellipsoidType.Name + ":  " +
                           "EquatorialRadius=" + equatorialRadius.ToString() +
                           ", PolarRadius=" + polarRadius.ToString() +
                           ", Flattening=" + flattening.ToString() + "]", e.ToString());
            Assert.AreEqual("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString() + "\" polarRadius=\"" + polarRadius.ToString() + "\" flattening=\"" + flattening.ToString() + "\"/>\n", e.ToXml());
        }

        [TestMethod]
        public void TestGetInstanceOfEllipsoid_GRS_1980()
        {
            Type ellipsoidType = typeof(Ellipsoids.Grs1980);
            double equatorialRadius = 6378137.0;
            double inverseFlattening = 298.257222101;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            Assert.IsNotNull(e);
            Assert.AreEqual(ellipsoidType.Name, e.GetType().Name);
            Assert.AreEqual(ellipsoidType.Name, e.Name);
            Assert.AreEqual(ellipsoidType.Name, e.Key);
            Assert.AreEqual(equatorialRadius, e.EquatorialRadius);
            Assert.AreEqual(flattening, e.Flattening);
            Assert.AreEqual(equatorialRadius - (flattening * equatorialRadius), e.PolarRadius);
            Assert.AreEqual(inverseFlattening, e.InverseFlattening);
            Assert.AreEqual(firstEccentricitySquared, e.FirstEccentricitySquared);
            Assert.AreEqual(secondEccentricitySquared, e.SecondEccentricitySquared);
            Assert.AreEqual("[" + ellipsoidType.Name + ":  " +
                          "EquatorialRadius=" + equatorialRadius.ToString() +
                          ", PolarRadius=" + polarRadius.ToString() +
                          ", Flattening=" + flattening.ToString() + "]", e.ToString());
            Assert.AreEqual("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString() + "\" polarRadius=\"" + polarRadius.ToString() + "\" flattening=\"" + flattening.ToString() + "\"/>\n", e.ToXml());
        }

        [TestMethod]
        public void TestGetInstanceOfEllipsoid_South_American_1969()
        {
            Type ellipsoidType = typeof(Ellipsoids.SouthAmerican1969);
            double equatorialRadius = 6378160.0;
            double inverseFlattening = 298.25;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            Assert.IsNotNull(e);
            Assert.AreEqual(ellipsoidType.Name, e.GetType().Name);
            Assert.AreEqual(ellipsoidType.Name, e.Name);
            Assert.AreEqual(ellipsoidType.Name, e.Key);
            Assert.AreEqual(equatorialRadius, e.EquatorialRadius);
            Assert.AreEqual(flattening, e.Flattening);
            Assert.AreEqual(equatorialRadius - (flattening * equatorialRadius), e.PolarRadius);
            Assert.AreEqual(inverseFlattening, e.InverseFlattening);
            Assert.AreEqual(firstEccentricitySquared, e.FirstEccentricitySquared);
            Assert.AreEqual(secondEccentricitySquared, e.SecondEccentricitySquared);
            Assert.AreEqual("[" + ellipsoidType.Name + ":  " +
                          "EquatorialRadius=" + equatorialRadius.ToString() +
                          ", PolarRadius=" + polarRadius.ToString() +
                          ", Flattening=" + flattening.ToString() + "]", e.ToString());
            Assert.AreEqual("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString() + "\" polarRadius=\"" + polarRadius.ToString() + "\" flattening=\"" + flattening.ToString() + "\"/>\n", e.ToXml());
        }

        [TestMethod]
        public void TestGetInstanceOfEllipsoid_WGS_1972()
        {
            Type ellipsoidType = typeof(Ellipsoids.Wgs1972);
            double equatorialRadius = 6378135.0;
            double inverseFlattening = 298.26;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            Assert.IsNotNull(e);
            Assert.AreEqual(ellipsoidType.Name, e.GetType().Name);
            Assert.AreEqual(ellipsoidType.Name, e.Name);
            Assert.AreEqual(ellipsoidType.Name, e.Key);
            Assert.AreEqual(equatorialRadius, e.EquatorialRadius);
            Assert.AreEqual(flattening, e.Flattening);
            Assert.AreEqual(equatorialRadius - (flattening * equatorialRadius), e.PolarRadius);
            Assert.AreEqual(inverseFlattening, e.InverseFlattening);
            Assert.AreEqual(firstEccentricitySquared, e.FirstEccentricitySquared);
            Assert.AreEqual(secondEccentricitySquared, e.SecondEccentricitySquared);
            Assert.AreEqual("[" + ellipsoidType.Name + ":  " +
                           "EquatorialRadius=" + equatorialRadius.ToString() +
                           ", PolarRadius=" + polarRadius.ToString() +
                           ", Flattening=" + flattening.ToString() + "]", e.ToString());
            Assert.AreEqual("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString() + "\" polarRadius=\"" + polarRadius.ToString() + "\" flattening=\"" + flattening.ToString() + "\"/>\n", e.ToXml());
        }

        [TestMethod]
        public void TestGetInstanceOfEllipsoid_WGS_1984()
        {
            Type ellipsoidType = typeof(Ellipsoids.Wgs1984);
            double equatorialRadius = 6378137.0;
            double inverseFlattening = 298.257223563;
            double flattening = 1 / inverseFlattening;
            double firstEccentricitySquared = (2 * flattening) - (flattening * flattening);
            double secondEccentricitySquared = (1 / (1 - firstEccentricitySquared)) - 1;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(ellipsoidType);
            Assert.IsNotNull(e);
            Assert.AreEqual(ellipsoidType.Name, e.GetType().Name);
            Assert.AreEqual(ellipsoidType.Name, e.Name);
            Assert.AreEqual(ellipsoidType.Name, e.Key);
            Assert.AreEqual(equatorialRadius, e.EquatorialRadius);
            Assert.AreEqual(flattening, e.Flattening);
            Assert.AreEqual(equatorialRadius - (flattening * equatorialRadius), e.PolarRadius);
            Assert.AreEqual(inverseFlattening, e.InverseFlattening);
            Assert.AreEqual(firstEccentricitySquared, e.FirstEccentricitySquared);
            Assert.AreEqual(secondEccentricitySquared, e.SecondEccentricitySquared);
            Assert.AreEqual("[" + ellipsoidType.Name + ":  " +
                           "EquatorialRadius=" + equatorialRadius.ToString() +
                           ", PolarRadius=" + polarRadius.ToString() +
                           ", Flattening=" + flattening.ToString() + "]", e.ToString());
            Assert.AreEqual("<ellipsoid ellipsoidType=\"" + ellipsoidType.Name + "\" equatorialRadius=\"" + equatorialRadius.ToString() + "\" polarRadius=\"" + polarRadius.ToString() + "\" flattening=\"" + flattening.ToString() + "\"/>\n", e.ToXml());
        }

        [TestMethod]
        public void TestSingleton()
        {
            IEllipsoid e1 = EllipsoidFactory.GetInstanceOfEllipsoid(typeof(Ellipsoids.Wgs1984));
            IEllipsoid e2 = EllipsoidFactory.GetInstanceOfEllipsoid(typeof(Ellipsoids.Wgs1984));
            Assert.AreSame(e1, e2);
        }

        [TestMethod, ExpectedException(typeof(InvalidEllipsoidTypeException))]
        public void TestGetInstanceOfEllipsoid_Undefined()
        {
            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(typeof(Ellipsoids.Undefined));
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(AmbiguousEllipsoidTypeException))]
        public void TestGetInstanceOfEllipsoid_UserDefined()
        {
            IEllipsoid e = EllipsoidFactory.GetInstanceOfEllipsoid(typeof(Ellipsoids.UserDefined));
            Assert.Fail();
        }

        #endregion


        #region UserDefined Instantiation

        [TestMethod]
        public void TestGetUserDefinedInstances()
        {
            string name = "asdf";
            double equatorialRadius = 6378135.0;
            double inverseFlattening = 298.0;
            double flattening = 1 / inverseFlattening;
            double polarRadius = equatorialRadius - (flattening * equatorialRadius);

            Assert.AreEqual(false, EllipsoidFactory.UserDefinedEllipsoidExists(name));
            Assert.AreEqual(false, EllipsoidFactory.UserDefinedEllipsoidExists(name, equatorialRadius, 1 / inverseFlattening));

            IEllipsoid e1 = EllipsoidFactory.GetInstanceOfNewUserDefinedEllipsoid(name, equatorialRadius, 1 / inverseFlattening);
            Assert.IsNotNull(e1);
            Assert.AreEqual(typeof(Ellipsoids.UserDefined).Name, e1.GetType().Name);
            Assert.AreEqual(name, e1.Name);
            Assert.AreEqual(typeof(Ellipsoids.UserDefined).Name + name, e1.Key);
            Assert.AreEqual(equatorialRadius, e1.EquatorialRadius);
            Assert.AreEqual(flattening, e1.Flattening);
            Assert.AreEqual(e1.EquatorialRadius - (e1.Flattening * e1.EquatorialRadius), e1.PolarRadius);
            Assert.AreEqual(inverseFlattening, e1.InverseFlattening);
            Assert.AreEqual((2 * e1.Flattening) - (e1.Flattening * e1.Flattening), e1.FirstEccentricitySquared);
            Assert.AreEqual("[" + typeof(Ellipsoids.UserDefined).Name + ":  " +
                           "Name='" + name + "'" +
                           ", EquatorialRadius=" + equatorialRadius.ToString() +
                           ", PolarRadius=" + polarRadius.ToString() +
                           ", Flattening=" + flattening.ToString() + "]", e1.ToString());
            Assert.AreEqual("<ellipsoid ellipsoidType=\"" + typeof(Ellipsoids.UserDefined).Name + "\" name=\"" + e1.Name + "\" equatorialRadius=\"" + e1.EquatorialRadius.ToString() + "\" polarRadius=\"" + e1.PolarRadius.ToString() + "\" flattening=\"" + e1.Flattening.ToString() + "\"/>\n", e1.ToXml());

            IEllipsoid e2 = EllipsoidFactory.GetInstanceOfExistingUserDefinedEllipsoid(name);
            Assert.AreSame(e1, e2);

            Assert.AreEqual(true, EllipsoidFactory.UserDefinedEllipsoidExists(name));
            Assert.AreEqual(true, EllipsoidFactory.UserDefinedEllipsoidExists(name, equatorialRadius, 1 / inverseFlattening));

            Assert.AreEqual(false, EllipsoidFactory.UserDefinedEllipsoidExists(name, equatorialRadius, 1 / 298.1));
            Assert.AreEqual(false, EllipsoidFactory.UserDefinedEllipsoidExists(name, 6378135.1, 1 / inverseFlattening));

            IEllipsoid e3 = EllipsoidFactory.GetInstanceOfNewUserDefinedEllipsoid(name, equatorialRadius, 1 / inverseFlattening);
            Assert.AreSame(e1, e3);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestGetInstanceOfNewUserDefinedEllipsoidNull()
        {
            string name = null;
            IEllipsoid e = EllipsoidFactory.GetInstanceOfNewUserDefinedEllipsoid(name, 6378135.0, 1 / 298.0);
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(InvalidEllipsoidTypeException))]
        public void TestGetInstanceOfNewUserDefinedEllipsoidFormat()
        {
            string name = "as$df";
            IEllipsoid e = EllipsoidFactory.GetInstanceOfNewUserDefinedEllipsoid(name, 6378135.0, 1 / 298.0);
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestGetInstanceOfExistingUserDefinedEllipsoidNull()
        {
            string name = null;
            IEllipsoid e = EllipsoidFactory.GetInstanceOfExistingUserDefinedEllipsoid(name);
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(InvalidEllipsoidTypeException))]
        public void TestGetInstanceOfExistingUserDefinedEllipsoidFormat()
        {
            string name = "as$df";
            IEllipsoid e = EllipsoidFactory.GetInstanceOfExistingUserDefinedEllipsoid(name);
            Assert.Fail();
        }


        #endregion
    }
}
