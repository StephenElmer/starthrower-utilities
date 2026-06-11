// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using AwesomeAssertions;
using StarThrower.Gis.GeoUtilities.Formatting;
using StarThrower.MathUtilities;
using StarThrower.StringUtilities;
using Xunit;

namespace StarThrower.Gis.GeoUtilities.Test
{
    public class FormattingTest
    {
        #region Instantiation Tests

        [Fact]
        public void TestSingleInstanceOfDefaultAndDms1()
        {
            IDmsFormatter f1 = DmsFormatterFactory.Create(DmsFormat.Default);
            IDmsFormatter f2 = DmsFormatterFactory.Create(DmsFormat.Default);
            IDmsFormatter f3 = DmsFormatterFactory.Create(DmsFormat.Dms1);
            IDmsFormatter f4 = DmsFormatterFactory.Create(DmsFormat.Dms1);
            f1.Should().BeSameAs(f2);
            f1.Should().BeSameAs(f3);
            f1.Should().BeSameAs(f4);
        }

        [Fact]
        public void TestSingleInstanceOfDms2()
        {
            IDmsFormatter f5 = DmsFormatterFactory.Create(DmsFormat.Dms2);
            IDmsFormatter f6 = DmsFormatterFactory.Create(DmsFormat.Dms2);
            f5.Should().BeSameAs(f6);
        }

        [Fact]
        public void TestDms1IsNotDms2()
        {
            IDmsFormatter f1 = DmsFormatterFactory.Create(DmsFormat.Default);
            IDmsFormatter f5 = DmsFormatterFactory.Create(DmsFormat.Dms2);
            f1.Should().NotBeSameAs(f5);
        }

        #endregion


        #region DDLatToDMSLat (Default)

        [Fact]
        public void DefaultTest1()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            double sample = 0.0;
            string expected = "0" + StringUtil.DegreeSymbol + " 0' 0.0\"";
            string actual = f.DdToDmsNs(sample);
            actual.Should().Be(expected);
        }

        [Fact]
        public void DefaultTest2()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            double sample = 45.959711;
            string expected = "45" + StringUtil.DegreeSymbol + " 57' 34.95\"";
            string actual = f.DdToDmsNs(sample);
            actual.Should().Be(expected);
        }

        [Fact]
        public void DefaultTest3()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            double sample = 90.0;
            string expected = "90" + StringUtil.DegreeSymbol + " 0' 0.0\"";
            string actual = f.DdToDmsNs(sample);
            actual.Should().Be(expected);
        }

        [Fact]
        public void DefaultTest4()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            double sample = -45.959711;
            string expected = "-45" + StringUtil.DegreeSymbol + " 57' 34.95\"";
            string actual = f.DdToDmsNs(sample);
            actual.Should().Be(expected);
        }

        [Fact]
        public void DefaultTest5()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            double sample = -90.0;
            string expected = "-90" + StringUtil.DegreeSymbol + " 0' 0.0\"";
            string actual = f.DdToDmsNs(sample);
            actual.Should().Be(expected);
        }

        #endregion


        #region DDLonToDMSLon (Default)

        [Fact]
        public void DefaultTest6()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            double sample = 0.0;
            string expected = "0" + StringUtil.DegreeSymbol + " 0' 0.0\"";
            string actual = f.DdToDmsEw(sample);
            actual.Should().Be(expected);
        }

        [Fact]
        public void DefaultTest7()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            double sample = 45.959711;
            string expected = "45" + StringUtil.DegreeSymbol + " 57' 34.95\"";
            string actual = f.DdToDmsEw(sample);
            actual.Should().Be(expected);
        }

        [Fact]
        public void DefaultTest8()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            double sample = 180.0;
            string expected = "180" + StringUtil.DegreeSymbol + " 0' 0.0\"";
            string actual = f.DdToDmsEw(sample);
            actual.Should().Be(expected);
        }

        [Fact]
        public void DefaultTest9()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            double sample = -45.959711;
            string expected = "-45" + StringUtil.DegreeSymbol + " 57' 34.95\"";
            string actual = f.DdToDmsEw(sample);
            actual.Should().Be(expected);
        }

        [Fact]
        public void DefaultTest10()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            double sample = -180.0;
            string expected = "-180" + StringUtil.DegreeSymbol + " 0' 0.0\"";
            string actual = f.DdToDmsEw(sample);
            actual.Should().Be(expected);
        }

        #endregion


        #region DMSLatToDDLat (Default)

        [Fact]
        public void DefaultTest11()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            string sample = "0" + StringUtil.DegreeSymbol + " 0' 0\"";
            double expected = 0.0;
            double actual = f.DmsToDdNs(sample);
            actual.Should().Be(expected);
        }

        [Fact]
        public void DefaultTest12()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            string sample = "45" + StringUtil.DegreeSymbol + " 57' 34.96\"";
            double expected = 45.959711;
            double actual = MathUtil.RoundTo(f.DmsToDdNs(sample), 6);
            actual.Should().Be(expected);
        }

        [Fact]
        public void DefaultTest13()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            string sample = "90" + StringUtil.DegreeSymbol + " 0' 0\"";
            double expected = 90.0;
            double actual = f.DmsToDdNs(sample);
            actual.Should().Be(expected);
        }

        [Fact]
        public void DefaultTest14()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            string sample = "-45" + StringUtil.DegreeSymbol + " 57' 34.96\"";
            double expected = -45.959711;
            double actual = MathUtil.RoundTo(f.DmsToDdNs(sample), 6);
            actual.Should().Be(expected);
        }

        [Fact]
        public void DefaultTest15()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            string sample = "-90" + StringUtil.DegreeSymbol + " 0' 0\"";
            double expected = -90.0;
            double actual = f.DmsToDdNs(sample);
            actual.Should().Be(expected);
        }

        #endregion


        #region DMSLonToDDLon (Default)

        [Fact]
        public void DefaultTest16()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            string sample = "0" + StringUtil.DegreeSymbol + " 0' 0\"";
            double expected = 0.0;
            double actual = f.DmsToDdEw(sample);
            actual.Should().Be(expected);
        }

        [Fact]
        public void DefaultTest17()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            string sample = "45" + StringUtil.DegreeSymbol + " 57' 34.96\"";
            double expected = 45.959711;
            double actual = MathUtil.RoundTo(f.DmsToDdEw(sample), 6);
            actual.Should().Be(expected);
        }

        [Fact]
        public void DefaultTest18()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            string sample = "180" + StringUtil.DegreeSymbol + " 0' 0\"";
            double expected = 180.0;
            double actual = f.DmsToDdEw(sample);
            actual.Should().Be(expected);
        }

        [Fact]
        public void DefaultTest19()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            string sample = "-45" + StringUtil.DegreeSymbol + " 57' 34.96\"";
            double expected = -45.959711;
            double actual = MathUtil.RoundTo(f.DmsToDdEw(sample), 6);
            actual.Should().Be(expected);
        }

        [Fact]
        public void DefaultTest20()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Default);
            string sample = "-180" + StringUtil.DegreeSymbol + " 0' 0\"";
            double expected = -180.0;
            double actual = f.DmsToDdEw(sample);
            actual.Should().Be(expected);
        }

        #endregion


        #region DDLatToDMSLat (DMS2)

        [Fact]
        public void Dms2Test1()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            double sample = 0.0;
            string expected = "N0d0m0.0s";
            string actual = f.DdToDmsNs(sample);
            actual.Should().Be(expected);
        }

        [Fact]
        public void Dms2Test2()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            double sample = 45.959711;
            string expected = "N45d57m34.95s";
            string actual = f.DdToDmsNs(sample);
            actual.Should().Be(expected);
        }

        [Fact]
        public void Dms2Test3()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            double sample = 90.0;
            string expected = "N90d0m0.0s";
            string actual = f.DdToDmsNs(sample);
            actual.Should().Be(expected);
        }

        [Fact]
        public void Dms2Test4()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            double sample = -45.959711;
            string expected = "S45d57m34.95s";
            string actual = f.DdToDmsNs(sample);
            actual.Should().Be(expected);
        }

        [Fact]
        public void Dms2Test5()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            double sample = -90.0;
            string expected = "S90d0m0.0s";
            string actual = f.DdToDmsNs(sample);
            actual.Should().Be(expected);
        }

        #endregion


        #region DDLonToDMSLon (DMS2)

        [Fact]
        public void Dms2Test6()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            double sample = 0.0;
            string expected = "E0d0m0.0s";
            string actual = f.DdToDmsEw(sample);
            actual.Should().Be(expected);
        }

        [Fact]
        public void Dms2Test7()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            double sample = 45.959711;
            string expected = "E45d57m34.95s";
            string actual = f.DdToDmsEw(sample);
            actual.Should().Be(expected);
        }

        [Fact]
        public void Dms2Test8()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            double sample = 180.0;
            string expected = "E180d0m0.0s";
            string actual = f.DdToDmsEw(sample);
            actual.Should().Be(expected);
        }

        [Fact]
        public void Dms2Test9()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            double sample = -45.959711;
            string expected = "W45d57m34.95s";
            string actual = f.DdToDmsEw(sample);
            actual.Should().Be(expected);
        }

        [Fact]
        public void Dms2Test10()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            double sample = -180.0;
            string expected = "W180d0m0.0s";
            string actual = f.DdToDmsEw(sample);
            actual.Should().Be(expected);
        }

        #endregion


        #region DMSLatToDDLat (DMS2)

        [Fact]
        public void Dms2Test11()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "N0d0m0s";
            double expected = 0.0;
            double actual = f.DmsToDdNs(sample);
            actual.Should().Be(expected);
        }

        [Fact]
        public void Dms2Test11ReverseCase()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "n0D0M0S";
            double expected = 0.0;
            double actual = f.DmsToDdNs(sample);
            actual.Should().Be(expected);
        }

        [Fact]
        public void Dms2Test12()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "N45d57m34.96s";
            double expected = 45.959711;
            double actual = MathUtil.RoundTo(f.DmsToDdNs(sample), 6);
            actual.Should().Be(expected);
        }

        [Fact]
        public void Dms2Test12ReverseCase()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "n45D57M34.96S";
            double expected = 45.959711;
            double actual = MathUtil.RoundTo(f.DmsToDdNs(sample), 6);
            actual.Should().Be(expected);
        }

        [Fact]
        public void Dms2Test13()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "N90d0m0s";
            double expected = 90.0;
            double actual = f.DmsToDdNs(sample);
            actual.Should().Be(expected);
        }

        [Fact]
        public void Dms2Test13ReverseCase()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "n90D0M0S";
            double expected = 90.0;
            double actual = f.DmsToDdNs(sample);
            actual.Should().Be(expected);
        }

        [Fact]
        public void Dms2Test14()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "S45d57m34.96s";
            double expected = -45.959711;
            double actual = MathUtil.RoundTo(f.DmsToDdNs(sample), 6);
            actual.Should().Be(expected);
        }

        [Fact]
        public void Dms2Test14ReverseCase()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "s45D57M34.96S";
            double expected = -45.959711;
            double actual = MathUtil.RoundTo(f.DmsToDdNs(sample), 6);
            actual.Should().Be(expected);
        }

        [Fact]
        public void Dms2Test15()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "S90d0m0s";
            double expected = -90.0;
            double actual = f.DmsToDdNs(sample);
            actual.Should().Be(expected);
        }

        [Fact]
        public void Dms2Test15ReverseCase()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "s90D0M0S";
            double expected = -90.0;
            double actual = f.DmsToDdNs(sample);
            actual.Should().Be(expected);
        }

        #endregion


        #region DMSLonToDDLon (DMS2)

        [Fact]
        public void Dms2Test16()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "E0d0m0s";
            double expected = 0.0;
            double actual = f.DmsToDdEw(sample);
            actual.Should().Be(expected);
        }

        [Fact]
        public void Dms2Test16ReverseCase()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "e0D0M0S";
            double expected = 0.0;
            double actual = f.DmsToDdEw(sample);
            actual.Should().Be(expected);
        }

        [Fact]
        public void Dms2Test17()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "E45d57m34.96s";
            double expected = 45.959711;
            double actual = MathUtil.RoundTo(f.DmsToDdEw(sample), 6);
            actual.Should().Be(expected);
        }

        [Fact]
        public void Dms2Test17ReverseCase()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "e45D57M34.96S";
            double expected = 45.959711;
            double actual = MathUtil.RoundTo(f.DmsToDdEw(sample), 6);
            actual.Should().Be(expected);
        }

        [Fact]
        public void Dms2Test18()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "E180d0m0s";
            double expected = 180.0;
            double actual = f.DmsToDdEw(sample);
            actual.Should().Be(expected);
        }

        [Fact]
        public void Dms2Test18ReverseCase()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "e180D0M0S";
            double expected = 180.0;
            double actual = f.DmsToDdEw(sample);
            actual.Should().Be(expected);
        }

        [Fact]
        public void Dms2Test19()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "W45d57m34.96s";
            double expected = -45.959711;
            double actual = MathUtil.RoundTo(f.DmsToDdEw(sample), 6);
            actual.Should().Be(expected);
        }

        [Fact]
        public void Dms2Test19ReverseCase()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "w45D57M34.96S";
            double expected = -45.959711;
            double actual = MathUtil.RoundTo(f.DmsToDdEw(sample), 6);
            actual.Should().Be(expected);
        }

        [Fact]
        public void Dms2Test20()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "W180d0m0s";
            double expected = -180.0;
            double actual = f.DmsToDdEw(sample);
            actual.Should().Be(expected);
        }

        [Fact]
        public void Dms2Test20ReverseCase()
        {
            IDmsFormatter f = DmsFormatterFactory.Create(DmsFormat.Dms2);
            string sample = "w180D0M0s";
            double expected = -180.0;
            double actual = f.DmsToDdEw(sample);
            actual.Should().Be(expected);
        }

        #endregion
    }
}


