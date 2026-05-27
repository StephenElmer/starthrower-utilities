using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarThrower.Gis.GeoUtilities.Formatting;
using StarThrower.StringUtilities;
using StarThrower.MathUtilities;

namespace StarThrower.Gis.GeoUtilities.Test
{
    [TestClass]
    public class FormattingTest
    {
        private void Ignore()
        {
#if FAIL_ON_IGNORE
                Assert.Fail("This test has been ignored.");
#else
            Assert.Inconclusive("this test has been ignored");
#endif
        }

        #region Instantiation Tests

        [TestMethod]
        public void TestSingleInstanceOfDefaultAndDms1()
        {
            IDmsFormatter f1 = DmsFormatterFactory.Create(DmsFormat.Default);
            IDmsFormatter f2 = DmsFormatterFactory.Create(DmsFormat.Default);
            IDmsFormatter f3 = DmsFormatterFactory.Create(DmsFormat.Dms1);
            IDmsFormatter f4 = DmsFormatterFactory.Create(DmsFormat.Dms1);
            Assert.AreSame(f1, f2);
            Assert.AreSame(f1, f3);
            Assert.AreSame(f1, f4);
        }

        [TestMethod]
        public void TestSingleInstanceOfDms2()
        {
            IDmsFormatter f5 = DmsFormatterFactory.Create(DmsFormat.Dms2);
            IDmsFormatter f6 = DmsFormatterFactory.Create(DmsFormat.Dms2);
            Assert.AreSame(f5, f6);
        }

        [TestMethod]
        public void TestDms1IsNotDms2()
        {
            IDmsFormatter f1 = DmsFormatterFactory.Create(DmsFormat.Default);
            IDmsFormatter f5 = DmsFormatterFactory.Create(DmsFormat.Dms2);
            Assert.AreNotSame(f1, f5);
        }

        #endregion


        #region DDLatToDMSLat (Default)

        [TestMethod]
        public void DefaultTest1()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            double sample = 0.0;
            string expected = "0" + StringUtil.DegreeSymbol + " 0' 0.0\"";
            string actual = f.DdToDmsNs(sample);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DefaultTest2()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            double sample = 45.959711;
            string expected = "45" + StringUtil.DegreeSymbol + " 57' 34.95\"";
            string actual = f.DdToDmsNs(sample);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DefaultTest3()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            double sample = 90.0;
            string expected = "90" + StringUtil.DegreeSymbol + " 0' 0.0\"";
            string actual = f.DdToDmsNs(sample);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DefaultTest4()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            double sample = -45.959711;
            string expected = "-45" + StringUtil.DegreeSymbol + " 57' 34.95\"";
            string actual = f.DdToDmsNs(sample);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DefaultTest5()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            double sample = -90.0;
            string expected = "-90" + StringUtil.DegreeSymbol + " 0' 0.0\"";
            string actual = f.DdToDmsNs(sample);
            Assert.AreEqual(expected, actual);
        }

        #endregion


        #region DDLonToDMSLon (Default)

        [TestMethod]
        public void DefaultTest6()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            double sample = 0.0;
            string expected = "0" + StringUtil.DegreeSymbol + " 0' 0.0\"";
            string actual = f.DdToDmsEw(sample);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DefaultTest7()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            double sample = 45.959711;
            string expected = "45" + StringUtil.DegreeSymbol + " 57' 34.95\"";
            string actual = f.DdToDmsEw(sample);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DefaultTest8()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            double sample = 180.0;
            string expected = "180" + StringUtil.DegreeSymbol + " 0' 0.0\"";
            string actual = f.DdToDmsEw(sample);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DefaultTest9()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            double sample = -45.959711;
            string expected = "-45" + StringUtil.DegreeSymbol + " 57' 34.95\"";
            string actual = f.DdToDmsEw(sample);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DefaultTest10()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            double sample = -180.0;
            string expected = "-180" + StringUtil.DegreeSymbol + " 0' 0.0\"";
            string actual = f.DdToDmsEw(sample);
            Assert.AreEqual(expected, actual);
        }

        #endregion


        #region DMSLatToDDLat (Default)

        [TestMethod]
        public void DefaultTest11()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            string sample = "0" + StringUtil.DegreeSymbol + " 0' 0\"";
            double expected = 0.0;
            double actual = f.DmsToDdNs(sample);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DefaultTest12()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            string sample = "45" + StringUtil.DegreeSymbol + " 57' 34.96\"";
            double expected = 45.959711;
            double actual = MathUtil.RoundTo(f.DmsToDdNs(sample), 6);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DefaultTest13()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            string sample = "90" + StringUtil.DegreeSymbol + " 0' 0\"";
            double expected = 90.0;
            double actual = f.DmsToDdNs(sample);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DefaultTest14()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            string sample = "-45" + StringUtil.DegreeSymbol + " 57' 34.96\"";
            double expected = -45.959711;
            double actual = MathUtil.RoundTo(f.DmsToDdNs(sample), 6);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DefaultTest15()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            string sample = "-90" + StringUtil.DegreeSymbol + " 0' 0\"";
            double expected = -90.0;
            double actual = f.DmsToDdNs(sample);
            Assert.AreEqual(expected, actual);
        }

        #endregion


        #region DMSLonToDDLon (Default)

        [TestMethod]
        public void DefaultTest16()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            string sample = "0" + StringUtil.DegreeSymbol + " 0' 0\"";
            double expected = 0.0;
            double actual = f.DmsToDdEw(sample);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DefaultTest17()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            string sample = "45" + StringUtil.DegreeSymbol + " 57' 34.96\"";
            double expected = 45.959711;
            double actual = MathUtil.RoundTo(f.DmsToDdEw(sample), 6);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DefaultTest18()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            string sample = "180" + StringUtil.DegreeSymbol + " 0' 0\"";
            double expected = 180.0;
            double actual = f.DmsToDdEw(sample);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DefaultTest19()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            string sample = "-45" + StringUtil.DegreeSymbol + " 57' 34.96\"";
            double expected = -45.959711;
            double actual = MathUtil.RoundTo(f.DmsToDdEw(sample), 6);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DefaultTest20()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            string sample = "-180" + StringUtil.DegreeSymbol + " 0' 0\"";
            double expected = -180.0;
            double actual = f.DmsToDdEw(sample);
            Assert.AreEqual(expected, actual);
        }

        #endregion


        #region DDLatToDMSLat (DMS2)

        [TestMethod]
        public void Dms2Test1()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            double sample = 0.0;
            string expected = "N0d0m0.0s";
            string actual = f.DdToDmsNs(sample);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Dms2Test2()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            double sample = 45.959711;
            string expected = "N45d57m34.95s";
            string actual = f.DdToDmsNs(sample);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Dms2Test3()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            double sample = 90.0;
            string expected = "N90d0m0.0s";
            string actual = f.DdToDmsNs(sample);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Dms2Test4()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            double sample = -45.959711;
            string expected = "S45d57m34.95s";
            string actual = f.DdToDmsNs(sample);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Dms2Test5()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            double sample = -90.0;
            string expected = "S90d0m0.0s";
            string actual = f.DdToDmsNs(sample);
            Assert.AreEqual(expected, actual);
        }

        #endregion


        #region DDLonToDMSLon (DMS2)

        [TestMethod]
        public void Dms2Test6()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            double sample = 0.0;
            string expected = "E0d0m0.0s";
            string actual = f.DdToDmsEw(sample);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Dms2Test7()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            double sample = 45.959711;
            string expected = "E45d57m34.95s";
            string actual = f.DdToDmsEw(sample);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Dms2Test8()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            double sample = 180.0;
            string expected = "E180d0m0.0s";
            string actual = f.DdToDmsEw(sample);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Dms2Test9()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            double sample = -45.959711;
            string expected = "W45d57m34.95s";
            string actual = f.DdToDmsEw(sample);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Dms2Test10()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            double sample = -180.0;
            string expected = "W180d0m0.0s";
            string actual = f.DdToDmsEw(sample);
            Assert.AreEqual(expected, actual);
        }

        #endregion


        #region DMSLatToDDLat (DMS2)

        [TestMethod]
        public void Dms2Test11()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "N0d0m0s";
            double expected = 0.0;
            double actual = f.DmsToDdNs(sample);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Dms2Test11ReverseCase()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "n0D0M0S";
            double expected = 0.0;
            double actual = f.DmsToDdNs(sample);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Dms2Test12()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "N45d57m34.96s";
            double expected = 45.959711;
            double actual = MathUtil.RoundTo(f.DmsToDdNs(sample), 6);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Dms2Test12ReverseCase()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "n45D57M34.96S";
            double expected = 45.959711;
            double actual = MathUtil.RoundTo(f.DmsToDdNs(sample), 6);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Dms2Test13()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "N90d0m0s";
            double expected = 90.0;
            double actual = f.DmsToDdNs(sample);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Dms2Test13ReverseCase()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "n90D0M0S";
            double expected = 90.0;
            double actual = f.DmsToDdNs(sample);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Dms2Test14()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "S45d57m34.96s";
            double expected = -45.959711;
            double actual = MathUtil.RoundTo(f.DmsToDdNs(sample), 6);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Dms2Test14ReverseCase()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "s45D57M34.96S";
            double expected = -45.959711;
            double actual = MathUtil.RoundTo(f.DmsToDdNs(sample), 6);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Dms2Test15()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "S90d0m0s";
            double expected = -90.0;
            double actual = f.DmsToDdNs(sample);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Dms2Test15ReverseCase()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "s90D0M0S";
            double expected = -90.0;
            double actual = f.DmsToDdNs(sample);
            Assert.AreEqual(expected, actual);
        }

        #endregion


        #region DMSLonToDDLon (DMS2)

        [TestMethod]
        public void Dms2Test16()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "E0d0m0s";
            double expected = 0.0;
            double actual = f.DmsToDdEw(sample);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Dms2Test16ReverseCase()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "e0D0M0S";
            double expected = 0.0;
            double actual = f.DmsToDdEw(sample);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Dms2Test17()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "E45d57m34.96s";
            double expected = 45.959711;
            double actual = MathUtil.RoundTo(f.DmsToDdEw(sample), 6);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Dms2Test17ReverseCase()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "e45D57M34.96S";
            double expected = 45.959711;
            double actual = MathUtil.RoundTo(f.DmsToDdEw(sample), 6);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Dms2Test18()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "E180d0m0s";
            double expected = 180.0;
            double actual = f.DmsToDdEw(sample);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Dms2Test18ReverseCase()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "e180D0M0S";
            double expected = 180.0;
            double actual = f.DmsToDdEw(sample);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Dms2Test19()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "W45d57m34.96s";
            double expected = -45.959711;
            double actual = MathUtil.RoundTo(f.DmsToDdEw(sample), 6);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Dms2Test19ReverseCase()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "w45D57M34.96S";
            double expected = -45.959711;
            double actual = MathUtil.RoundTo(f.DmsToDdEw(sample), 6);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Dms2Test20()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "W180d0m0s";
            double expected = -180.0;
            double actual = f.DmsToDdEw(sample);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Dms2Test20ReverseCase()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "w180D0M0s";
            double expected = -180.0;
            double actual = f.DmsToDdEw(sample);
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
