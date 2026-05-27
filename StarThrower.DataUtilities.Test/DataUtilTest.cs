using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarThrower.DataUtilities;

namespace StarThrower.DataUtilities.Test
{
    [TestClass]
    public class DataUtilTest
    {
        private void Ignore()
        {
#if FAIL_ON_IGNORE
                Assert.Fail("This test has been ignored.");
#else
            Assert.Inconclusive("this test has been ignored");
#endif
        }

        #region GetBoolField() tests

        [TestMethod]
        public void TestGetBoolField1()
        {
            bool expected = true;
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(bool));
            DataRow r = t.Rows.Add(new object[] { expected });
            bool actual = DataUtil.GetBooleanField(r, "SomeField");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetBoolField2()
        {
            bool expected = false;
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(bool));
            DataRow r = t.Rows.Add(new object[] { expected });
            bool actual = DataUtil.GetBooleanField(r, "SomeField");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetBoolField3()
        {
            bool expected = false;
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(bool));
            DataRow r = t.Rows.Add(new object[] { null });
            bool actual = DataUtil.GetBooleanField(r, "SomeField");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestGetBoolFieldArgumentNull1()
        {
            DataRow r = null;
            string fieldName = "SomeField";
            bool result = DataUtil.GetBooleanField(r, fieldName);
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestGetBoolFieldArgumentNull2()
        {
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(string));
            DataRow r = t.Rows.Add(new object[] { "some data" });
            string fieldName = null;
            bool actual = DataUtil.GetBooleanField(r, fieldName);
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void TestGetBoolFieldArgumentException1()
        {
            bool expected = false;
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(bool));
            DataRow r = t.Rows.Add(new object[] { expected });
            bool actual = DataUtil.GetBooleanField(r, "SomeOtherField");
            Assert.Fail();
        }

        #endregion


        #region GetStringField() tests

        [TestMethod]
        public void TestGetStringField1()
        {
            string expected = "some data";
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(string));
            DataRow r = t.Rows.Add(new object[] { expected });
            string actual = DataUtil.GetStringField(r, "SomeField");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetStringField2()
        {
            string expected = String.Empty;
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(string));
            DataRow r = t.Rows.Add(new object[] { expected });
            string actual = DataUtil.GetStringField(r, "SomeField");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetStringField3()
        {
            string expected = String.Empty;
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(string));
            DataRow r = t.Rows.Add(new object[] { null });
            string actual = DataUtil.GetStringField(r, "SomeField");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestGetStringFieldArgumentNull1()
        {
            DataRow r = null;
            string fieldName = "SomeField";
            string result = DataUtil.GetStringField(r, fieldName);
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestGetStringFieldArgumentNull2()
        {
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(string));
            DataRow r = t.Rows.Add(new object[] { "some data" });
            string fieldName = null;
            string result = DataUtil.GetStringField(r, fieldName);
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void TestGetStringFieldArgumentException1()
        {
            string expected = "some data";
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(string));
            DataRow r = t.Rows.Add(new object[] { expected });
            string actual = DataUtil.GetStringField(r, "SomeOtherField");
            Assert.Fail();
        }

        #endregion


        #region GetFloatField() test

        [TestMethod]
        public void TestGetFloatField1()
        {
            float expected = 0.0f;
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(float));
            DataRow r = t.Rows.Add(new object[] { expected });
            float actual = DataUtil.GetSingleField(r, "SomeField");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetFloatField2()
        {
            float expected = 123.456f;
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(float));
            DataRow r = t.Rows.Add(new object[] { expected });
            float actual = DataUtil.GetSingleField(r, "SomeField");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetFloatField3()
        {
            float expected = 0.0f;
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(float));
            DataRow r = t.Rows.Add(new object[] { null });
            float actual = DataUtil.GetSingleField(r, "SomeField");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestGetFloatFieldArgumentNull1()
        {
            DataRow r = null;
            string fieldName = "SomeField";
            float actual = DataUtil.GetSingleField(r, fieldName);
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestGetFloatFieldArgumentNull2()
        {
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(string));
            DataRow r = t.Rows.Add(new object[] { "some data" });
            string fieldName = null;
            float actual = DataUtil.GetSingleField(r, fieldName);
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void TestGetFloatFieldArgumentException1()
        {
            float expected = 0.0f;
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(float));
            DataRow r = t.Rows.Add(new object[] { expected });
            float actual = DataUtil.GetSingleField(r, "SomeOtherField");
            Assert.Fail();
        }

        #endregion


        #region GetDateTimeField() tests

        [TestMethod]
        public void TestGetDateTimeField1()
        {
            DateTime expected = new DateTime(2007, 6, 24);
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(DateTime));
            DataRow r = t.Rows.Add(new object[] { expected });
            DateTime actual = DataUtil.GetDateTimeField(r, "SomeField");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetDateTimeField2()
        {
            DateTime expected = new DateTime(2007, 6, 24, 7, 39, 15);
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(DateTime));
            DataRow r = t.Rows.Add(new object[] { expected });
            DateTime actual = DataUtil.GetDateTimeField(r, "SomeField");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetDateTimeField3()
        {
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(DateTime));
            DataRow r = t.Rows.Add(new object[] { null });
            DateTime actual = DataUtil.GetDateTimeField(r, "SomeField");
            // When field is null, GetDateTimeField returns DateTime.Now (at the time of call)
            // We verify it's recent (within last second) rather than comparing exact values
            TimeSpan difference = DateTime.Now - actual;
            Assert.IsTrue(difference.TotalSeconds < 1, $"Expected current time but got {actual}");
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestGetDateTimeFieldArgumentNull1()
        {
            DataRow r = null;
            string fieldName = "SomeField";
            DateTime actual = DataUtil.GetDateTimeField(r, fieldName);
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestGetDateTimeFieldArgumentNull2()
        {
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(string));
            DataRow r = t.Rows.Add(new object[] { "some data" });
            string fieldName = null;
            DateTime actual = DataUtil.GetDateTimeField(r, fieldName);
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void TestGetDateTimeArgumentException1()
        {
            DateTime expected = DataUtil.DTNull;
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(DateTime));
            DataRow r = t.Rows.Add(new object[] { expected });
            DateTime actual = DataUtil.GetDateTimeField(r, "SomeOtherField");
            Assert.Fail();
        }
        #endregion


        #region GetIntField() tests

        [TestMethod]
        public void TestGetIntField1()
        {
            int expected = 1;
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(int));
            DataRow r = t.Rows.Add(new object[] { expected });
            int actual = DataUtil.GetInt32Field(r, "SomeField");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetIntField2()
        {
            int expected = 0;
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(int));
            DataRow r = t.Rows.Add(new object[] { expected });
            int actual = DataUtil.GetInt32Field(r, "SomeField");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetIntField3()
        {
            int expected = 0;
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(int));
            DataRow r = t.Rows.Add(new object[] { null });
            int actual = DataUtil.GetInt32Field(r, "SomeField");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestGetIntFieldArgumentNull1()
        {
            DataRow r = null;
            string fieldName = "SomeField";
            int actual = DataUtil.GetInt32Field(r, fieldName);
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestGetIntFieldArgumentNull2()
        {
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(string));
            DataRow r = t.Rows.Add(new object[] { "some data" });
            string fieldName = null;
            int actual = DataUtil.GetInt32Field(r, fieldName);
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void TestGetIntFieldArgumentException1()
        {
            int expected = 0;
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(int));
            DataRow r = t.Rows.Add(new object[] { expected });
            int actual = DataUtil.GetInt32Field(r, "SomeOtherField");
            Assert.Fail();
        }
        #endregion
    }
}
