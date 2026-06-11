// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using Xunit;
using AwesomeAssertions;
using StarThrower.DateTimeUtilities;

namespace StarThrower.DateTimeUtilities.Test
{
    public class DTUtilTest
    {
        #region ToMMDDYYString() tests

        [Fact]
        public void TestToMMDDYYString1()
        {
            string expected = "062407";
            DateTime dt = new DateTime(2007, 6, 24);
            string actual = DTUtil.ToMmddyyString(dt);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestToMMDDYYString2()
        {
            string expected = "010101";
            DateTime dt = new DateTime(2001, 1, 1);
            string actual = DTUtil.ToMmddyyString(dt);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestToMMDDYYString3()
        {
            string expected = "010100";
            DateTime dt = new DateTime(2000, 1, 1);
            string actual = DTUtil.ToMmddyyString(dt);
            actual.Should().Be(expected);
        }

        #endregion


        #region DateDiff() tests

        [Fact]
        public void TestDateDiffYear1()
        {
            DateInterval i = DateInterval.Year;
            DateTime d1 = new DateTime(2007, 6, 24);
            DateTime d2 = new DateTime(2007, 6, 24);
            long expected = 0;
            long actual = DTUtil.DateDiff(i, d1, d2);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestDateDiffYear2()
        {
            DateInterval i = DateInterval.Year;
            DateTime d1 = new DateTime(2007, 6, 24);
            DateTime d2 = new DateTime(2008, 6, 24);
            long expected = 1;
            long actual = DTUtil.DateDiff(i, d1, d2);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestDateDiffYear3()
        {
            DateInterval i = DateInterval.Year;
            DateTime d1 = new DateTime(2008, 6, 24);
            DateTime d2 = new DateTime(2007, 6, 24);
            long expected = -1;
            long actual = DTUtil.DateDiff(i, d1, d2);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestDateDiffMonth1()
        {
            DateInterval i = DateInterval.Month;
            DateTime d1 = new DateTime(2007, 6, 24);
            DateTime d2 = new DateTime(2007, 6, 24);
            long expected = 0;
            long actual = DTUtil.DateDiff(i, d1, d2);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestDateDiffMonth2()
        {
            DateInterval i = DateInterval.Month;
            DateTime d1 = new DateTime(2007, 6, 24);
            DateTime d2 = new DateTime(2007, 7, 24);
            long expected = 1;
            long actual = DTUtil.DateDiff(i, d1, d2);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestDateDiffMonth3()
        {
            DateInterval i = DateInterval.Year;
            DateTime d1 = new DateTime(2007, 7, 24);
            DateTime d2 = new DateTime(2007, 6, 24);
            long expected = -1;
            long actual = DTUtil.DateDiff(i, d1, d2);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestDateDiffDay1()
        {
            DateInterval i = DateInterval.Day;
            DateTime d1 = new DateTime(2007, 6, 24);
            DateTime d2 = new DateTime(2007, 6, 24);
            long expected = 0;
            long actual = DTUtil.DateDiff(i, d1, d2);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestDateDiffDay2()
        {
            DateInterval i = DateInterval.Day;
            DateTime d1 = new DateTime(2007, 6, 24);
            DateTime d2 = new DateTime(2007, 6, 25);
            long expected = 1;
            long actual = DTUtil.DateDiff(i, d1, d2);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestDateDiffDay3()
        {
            DateInterval i = DateInterval.Day;
            DateTime d1 = new DateTime(2007, 6, 25);
            DateTime d2 = new DateTime(2007, 6, 24);
            long expected = -1;
            long actual = DTUtil.DateDiff(i, d1, d2);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestDateDiffHour1()
        {
            DateInterval i = DateInterval.Hour;
            DateTime d1 = new DateTime(2007, 6, 24, 8, 13, 15);
            DateTime d2 = new DateTime(2007, 6, 24, 8, 13, 15);
            long expected = 0;
            long actual = DTUtil.DateDiff(i, d1, d2);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestDateDiffHour2()
        {
            DateInterval i = DateInterval.Hour;
            DateTime d1 = new DateTime(2007, 6, 24, 8, 13, 15);
            DateTime d2 = new DateTime(2007, 6, 24, 9, 13, 15);
            long expected = 1;
            long actual = DTUtil.DateDiff(i, d1, d2);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestDateDiffHour3()
        {
            DateInterval i = DateInterval.Hour;
            DateTime d1 = new DateTime(2007, 6, 24, 9, 13, 15);
            DateTime d2 = new DateTime(2007, 6, 24, 8, 13, 15);
            long expected = -1;
            long actual = DTUtil.DateDiff(i, d1, d2);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestDateDiffMinute1()
        {
            DateInterval i = DateInterval.Minute;
            DateTime d1 = new DateTime(2007, 6, 24, 8, 13, 15);
            DateTime d2 = new DateTime(2007, 6, 24, 8, 13, 15);
            long expected = 0;
            long actual = DTUtil.DateDiff(i, d1, d2);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestDateDiffMinute2()
        {
            DateInterval i = DateInterval.Minute;
            DateTime d1 = new DateTime(2007, 6, 24, 8, 13, 15);
            DateTime d2 = new DateTime(2007, 6, 24, 8, 14, 15);
            long expected = 1;
            long actual = DTUtil.DateDiff(i, d1, d2);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestDateDiffMinute3()
        {
            DateInterval i = DateInterval.Minute;
            DateTime d1 = new DateTime(2007, 6, 24, 8, 14, 15);
            DateTime d2 = new DateTime(2007, 6, 24, 8, 13, 15);
            long expected = -1;
            long actual = DTUtil.DateDiff(i, d1, d2);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestDateDiffSecond1()
        {
            DateInterval i = DateInterval.Second;
            DateTime d1 = new DateTime(2007, 6, 24, 8, 13, 15);
            DateTime d2 = new DateTime(2007, 6, 24, 8, 13, 15);
            long expected = 0;
            long actual = DTUtil.DateDiff(i, d1, d2);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestDateDiffSecond2()
        {
            DateInterval i = DateInterval.Second;
            DateTime d1 = new DateTime(2007, 6, 24, 8, 13, 15);
            DateTime d2 = new DateTime(2007, 6, 24, 8, 13, 16);
            long expected = 1;
            long actual = DTUtil.DateDiff(i, d1, d2);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestDateDiffSecond3()
        {
            DateInterval i = DateInterval.Second;
            DateTime d1 = new DateTime(2007, 6, 24, 8, 13, 16);
            DateTime d2 = new DateTime(2007, 6, 24, 8, 13, 15);
            long expected = -1;
            long actual = DTUtil.DateDiff(i, d1, d2);
            actual.Should().Be(expected);
        }

        #endregion


        #region DateTimeToIso8601() tests

        [Fact]
        public void TestDateTimeToIso8601()
        {
            DateTime dt = new DateTime(2007, 6, 24, 8, 13, 15);
            string expected = "2007-06-24T08:13:15.0+00:00";
            string actual = DTUtil.DateTimeToIso8601(dt);
            actual.Should().Be(expected);
        }

        #endregion


        #region Iso8601ToDateTime() tests

        [Fact]
        public void TestIso8601ToDateTime1()
        {
            string iso = "2007-06-24T08:13:15.0";
            DateTime expected = new DateTime(2007, 6, 24, 8, 13, 15);
            DateTime actual = DTUtil.Iso8601ToDateTime(iso);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestIso8601ToDateTime2()
        {
            string iso = "2007-06-24T08:13:15.0+00:00";
            DateTime expected = new DateTime(2007, 6, 24, 8, 13, 15);
            DateTime actual = DTUtil.Iso8601ToDateTime(iso);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestIso8601ToDateTimeArgumentNull()
        {
            string? s = null;
            Action act = () => DTUtil.Iso8601ToDateTime(s);
            act.Should().Throw<ArgumentNullException>();
        }

        #endregion
    }
}
