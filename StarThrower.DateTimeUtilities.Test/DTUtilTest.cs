// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarThrower.DateTimeUtilities;

namespace StarThrower.DateTimeUtilities.Test
{
    [TestClass]
    public class DTUtilTest
    {
        private static void Ignore()
        {
#if FAIL_ON_IGNORE
                Assert.Fail("This test has been ignored.");
#else
            Assert.Inconclusive("this test has been ignored");
#endif
        }

        #region ToMMDDYYString() tests

        [TestMethod]
        public void TestToMMDDYYString1()
        {
            string expected = "062407";
            DateTime dt = new DateTime(2007, 6, 24);
            string actual = DTUtil.ToMmddyyString(dt);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToMMDDYYString2()
        {
            string expected = "010101";
            DateTime dt = new DateTime(2001, 1, 1);
            string actual = DTUtil.ToMmddyyString(dt);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToMMDDYYString3()
        {
            string expected = "010100";
            DateTime dt = new DateTime(2000, 1, 1);
            string actual = DTUtil.ToMmddyyString(dt);
            Assert.AreEqual(expected, actual);
        }

        #endregion


        #region DateDiff() tests

        [TestMethod]
        public void TestDateDiffYear1()
        {
            DateInterval i = DateInterval.Year;
            DateTime d1 = new DateTime(2007, 6, 24);
            DateTime d2 = new DateTime(2007, 6, 24);
            long expected = 0;
            long actual = DTUtil.DateDiff(i, d1, d2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDateDiffYear2()
        {
            DateInterval i = DateInterval.Year;
            DateTime d1 = new DateTime(2007, 6, 24);
            DateTime d2 = new DateTime(2008, 6, 24);
            long expected = 1;
            long actual = DTUtil.DateDiff(i, d1, d2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDateDiffYear3()
        {
            DateInterval i = DateInterval.Year;
            DateTime d1 = new DateTime(2008, 6, 24);
            DateTime d2 = new DateTime(2007, 6, 24);
            long expected = -1;
            long actual = DTUtil.DateDiff(i, d1, d2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDateDiffMonth1()
        {
            DateInterval i = DateInterval.Month;
            DateTime d1 = new DateTime(2007, 6, 24);
            DateTime d2 = new DateTime(2007, 6, 24);
            long expected = 0;
            long actual = DTUtil.DateDiff(i, d1, d2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDateDiffMonth2()
        {
            DateInterval i = DateInterval.Month;
            DateTime d1 = new DateTime(2007, 6, 24);
            DateTime d2 = new DateTime(2007, 7, 24);
            long expected = 1;
            long actual = DTUtil.DateDiff(i, d1, d2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDateDiffMonth3()
        {
            DateInterval i = DateInterval.Year;
            DateTime d1 = new DateTime(2007, 7, 24);
            DateTime d2 = new DateTime(2007, 6, 24);
            long expected = -1;
            long actual = DTUtil.DateDiff(i, d1, d2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDateDiffDay1()
        {
            DateInterval i = DateInterval.Day;
            DateTime d1 = new DateTime(2007, 6, 24);
            DateTime d2 = new DateTime(2007, 6, 24);
            long expected = 0;
            long actual = DTUtil.DateDiff(i, d1, d2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDateDiffDay2()
        {
            DateInterval i = DateInterval.Day;
            DateTime d1 = new DateTime(2007, 6, 24);
            DateTime d2 = new DateTime(2007, 6, 25);
            long expected = 1;
            long actual = DTUtil.DateDiff(i, d1, d2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDateDiffDay3()
        {
            DateInterval i = DateInterval.Day;
            DateTime d1 = new DateTime(2007, 6, 25);
            DateTime d2 = new DateTime(2007, 6, 24);
            long expected = -1;
            long actual = DTUtil.DateDiff(i, d1, d2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDateDiffHour1()
        {
            DateInterval i = DateInterval.Hour;
            DateTime d1 = new DateTime(2007, 6, 24, 8, 13, 15);
            DateTime d2 = new DateTime(2007, 6, 24, 8, 13, 15);
            long expected = 0;
            long actual = DTUtil.DateDiff(i, d1, d2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDateDiffHour2()
        {
            DateInterval i = DateInterval.Hour;
            DateTime d1 = new DateTime(2007, 6, 24, 8, 13, 15);
            DateTime d2 = new DateTime(2007, 6, 24, 9, 13, 15);
            long expected = 1;
            long actual = DTUtil.DateDiff(i, d1, d2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDateDiffHour3()
        {
            DateInterval i = DateInterval.Hour;
            DateTime d1 = new DateTime(2007, 6, 24, 9, 13, 15);
            DateTime d2 = new DateTime(2007, 6, 24, 8, 13, 15);
            long expected = -1;
            long actual = DTUtil.DateDiff(i, d1, d2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDateDiffMinute1()
        {
            DateInterval i = DateInterval.Minute;
            DateTime d1 = new DateTime(2007, 6, 24, 8, 13, 15);
            DateTime d2 = new DateTime(2007, 6, 24, 8, 13, 15);
            long expected = 0;
            long actual = DTUtil.DateDiff(i, d1, d2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDateDiffMinute2()
        {
            DateInterval i = DateInterval.Minute;
            DateTime d1 = new DateTime(2007, 6, 24, 8, 13, 15);
            DateTime d2 = new DateTime(2007, 6, 24, 8, 14, 15);
            long expected = 1;
            long actual = DTUtil.DateDiff(i, d1, d2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDateDiffMinute3()
        {
            DateInterval i = DateInterval.Minute;
            DateTime d1 = new DateTime(2007, 6, 24, 8, 14, 15);
            DateTime d2 = new DateTime(2007, 6, 24, 8, 13, 15);
            long expected = -1;
            long actual = DTUtil.DateDiff(i, d1, d2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDateDiffSecond1()
        {
            DateInterval i = DateInterval.Second;
            DateTime d1 = new DateTime(2007, 6, 24, 8, 13, 15);
            DateTime d2 = new DateTime(2007, 6, 24, 8, 13, 15);
            long expected = 0;
            long actual = DTUtil.DateDiff(i, d1, d2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDateDiffSecond2()
        {
            DateInterval i = DateInterval.Second;
            DateTime d1 = new DateTime(2007, 6, 24, 8, 13, 15);
            DateTime d2 = new DateTime(2007, 6, 24, 8, 13, 16);
            long expected = 1;
            long actual = DTUtil.DateDiff(i, d1, d2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDateDiffSecond3()
        {
            DateInterval i = DateInterval.Second;
            DateTime d1 = new DateTime(2007, 6, 24, 8, 13, 16);
            DateTime d2 = new DateTime(2007, 6, 24, 8, 13, 15);
            long expected = -1;
            long actual = DTUtil.DateDiff(i, d1, d2);
            Assert.AreEqual(expected, actual);
        }

        #endregion


        #region DateTimeToIso8601() tests

        [TestMethod]
        public void TestDateTimeToIso8601()
        {
            DateTime dt = new DateTime(2007, 6, 24, 8, 13, 15);
            string expected = "2007-06-24T08:13:15.0+00:00";
            string actual = DTUtil.DateTimeToIso8601(dt);
            Assert.AreEqual(expected, actual);
        }

        #endregion


        #region Iso8601ToDateTime() tests

        [TestMethod]
        public void TestIso8601ToDateTime1()
        {
            string iso = "2007-06-24T08:13:15.0";
            DateTime expected = new DateTime(2007, 6, 24, 8, 13, 15);
            DateTime actual = DTUtil.Iso8601ToDateTime(iso);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIso8601ToDateTime2()
        {
            string iso = "2007-06-24T08:13:15.0+00:00";
            DateTime expected = new DateTime(2007, 6, 24, 8, 13, 15);
            DateTime actual = DTUtil.Iso8601ToDateTime(iso);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestIso8601ToDateTimeArgumentNull()
        {
            string? s = null;
            DateTime dt = DTUtil.Iso8601ToDateTime(s);
            Assert.Fail();
        }

        #endregion
    }
}
