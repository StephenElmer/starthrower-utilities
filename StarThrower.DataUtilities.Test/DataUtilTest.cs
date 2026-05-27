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


        #region DbDataReader overload tests

        private static DataTableReader MakeReader(DataTable t)
        {
            DataTableReader dr = t.CreateDataReader();
            dr.Read();
            return dr;
        }

        // CheckFieldExists

        [TestMethod]
        public void TestCheckFieldExists_Found()
        {
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(string));
            t.Rows.Add("x");
            using DataTableReader dr = MakeReader(t);
            Assert.IsTrue(DataUtil.CheckFieldExists(dr, "SomeField"));
        }

        [TestMethod]
        public void TestCheckFieldExists_NotFound()
        {
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(string));
            t.Rows.Add("x");
            using DataTableReader dr = MakeReader(t);
            Assert.IsFalse(DataUtil.CheckFieldExists(dr, "OtherField"));
        }

        // GetBoolField(DbDataReader)

        [TestMethod]
        public void TestGetBoolFieldDbReader_True()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(bool));
            t.Rows.Add(true);
            using DataTableReader dr = MakeReader(t);
            Assert.AreEqual(true, DataUtil.GetBoolField(dr, "F"));
        }

        [TestMethod]
        public void TestGetBoolFieldDbReader_DBNull()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(bool));
            t.Rows.Add((object)null);
            using DataTableReader dr = MakeReader(t);
            Assert.AreEqual(false, DataUtil.GetBoolField(dr, "F"));
        }

        [TestMethod]
        public void TestGetBoolFieldDbReader_CustomDefault()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(bool));
            t.Rows.Add((object)null);
            using DataTableReader dr = MakeReader(t);
            Assert.AreEqual(true, DataUtil.GetBoolField(dr, "F", true));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestGetBoolFieldDbReader_NullReader()
        {
            DataUtil.GetBoolField((System.Data.Common.DbDataReader)null, "F");
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestGetBoolFieldDbReader_NullField()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(bool));
            t.Rows.Add(true);
            using DataTableReader dr = MakeReader(t);
            DataUtil.GetBoolField(dr, (string)null);
        }

        // GetStringField(DbDataReader)

        [TestMethod]
        public void TestGetStringFieldDbReader_Value()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(string));
            t.Rows.Add("hello");
            using DataTableReader dr = MakeReader(t);
            Assert.AreEqual("hello", DataUtil.GetStringField(dr, "F"));
        }

        [TestMethod]
        public void TestGetStringFieldDbReader_DBNull()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(string));
            t.Rows.Add((object)null);
            using DataTableReader dr = MakeReader(t);
            Assert.AreEqual(string.Empty, DataUtil.GetStringField(dr, "F"));
        }

        [TestMethod]
        public void TestGetStringFieldDbReader_CustomDefault()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(string));
            t.Rows.Add((object)null);
            using DataTableReader dr = MakeReader(t);
            Assert.AreEqual("default", DataUtil.GetStringField(dr, "F", "default"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestGetStringFieldDbReader_NullReader()
        {
            DataUtil.GetStringField((System.Data.Common.DbDataReader)null, "F");
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestGetStringFieldDbReader_NullField()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(string));
            t.Rows.Add("x");
            using DataTableReader dr = MakeReader(t);
            DataUtil.GetStringField(dr, (string)null);
        }

        // GetDateTimeField(DbDataReader)

        [TestMethod]
        public void TestGetDateTimeFieldDbReader_Value()
        {
            DateTime expected = new DateTime(2007, 6, 24);
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(DateTime));
            t.Rows.Add(expected);
            using DataTableReader dr = MakeReader(t);
            Assert.AreEqual(expected, DataUtil.GetDateTimeField(dr, "F", DateTime.MinValue));
        }

        [TestMethod]
        public void TestGetDateTimeFieldDbReader_DBNull()
        {
            DateTime sentinel = new DateTime(1999, 1, 1);
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(DateTime));
            t.Rows.Add((object)null);
            using DataTableReader dr = MakeReader(t);
            Assert.AreEqual(sentinel, DataUtil.GetDateTimeField(dr, "F", sentinel));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestGetDateTimeFieldDbReader_NullReader()
        {
            DataUtil.GetDateTimeField((System.Data.Common.DbDataReader)null, "F", DateTime.MinValue);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestGetDateTimeFieldDbReader_NullField()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(DateTime));
            t.Rows.Add(DateTime.Now);
            using DataTableReader dr = MakeReader(t);
            DataUtil.GetDateTimeField(dr, (string)null, DateTime.MinValue);
        }

        // GetFloatField(DbDataReader)

        [TestMethod]
        public void TestGetFloatFieldDbReader_Value()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(float));
            t.Rows.Add(3.14f);
            using DataTableReader dr = MakeReader(t);
            Assert.AreEqual(3.14f, DataUtil.GetFloatField(dr, "F"));
        }

        [TestMethod]
        public void TestGetFloatFieldDbReader_DBNull()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(float));
            t.Rows.Add((object)null);
            using DataTableReader dr = MakeReader(t);
            Assert.AreEqual(99f, DataUtil.GetFloatField(dr, "F", 99f));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestGetFloatFieldDbReader_NullReader()
        {
            DataUtil.GetFloatField((System.Data.Common.DbDataReader)null, "F");
        }

        // GetDoubleField(DbDataReader)

        [TestMethod]
        public void TestGetDoubleFieldDbReader_Value()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(double));
            t.Rows.Add(2.718);
            using DataTableReader dr = MakeReader(t);
            Assert.AreEqual(2.718, DataUtil.GetDoubleField(dr, "F"));
        }

        [TestMethod]
        public void TestGetDoubleFieldDbReader_DBNull()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(double));
            t.Rows.Add((object)null);
            using DataTableReader dr = MakeReader(t);
            Assert.AreEqual(0.0, DataUtil.GetDoubleField(dr, "F"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestGetDoubleFieldDbReader_NullReader()
        {
            DataUtil.GetDoubleField((System.Data.Common.DbDataReader)null, "F");
        }

        // GetLongField(DbDataReader)

        [TestMethod]
        public void TestGetLongFieldDbReader_Value()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(long));
            t.Rows.Add(123456789L);
            using DataTableReader dr = MakeReader(t);
            Assert.AreEqual(123456789L, DataUtil.GetLongField(dr, "F"));
        }

        [TestMethod]
        public void TestGetLongFieldDbReader_DBNull()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(long));
            t.Rows.Add((object)null);
            using DataTableReader dr = MakeReader(t);
            Assert.AreEqual(0L, DataUtil.GetLongField(dr, "F"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestGetLongFieldDbReader_NullReader()
        {
            DataUtil.GetLongField((System.Data.Common.DbDataReader)null, "F");
        }

        // GetIntField(DbDataReader)

        [TestMethod]
        public void TestGetIntFieldDbReader_Value()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(int));
            t.Rows.Add(42);
            using DataTableReader dr = MakeReader(t);
            Assert.AreEqual(42, DataUtil.GetIntField(dr, "F"));
        }

        [TestMethod]
        public void TestGetIntFieldDbReader_DBNull()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(int));
            t.Rows.Add((object)null);
            using DataTableReader dr = MakeReader(t);
            Assert.AreEqual(0, DataUtil.GetIntField(dr, "F"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestGetIntFieldDbReader_NullReader()
        {
            DataUtil.GetIntField((System.Data.Common.DbDataReader)null, "F");
        }

        // GetShortField(DbDataReader)

        [TestMethod]
        public void TestGetShortFieldDbReader_Value()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(short));
            t.Rows.Add((short)7);
            using DataTableReader dr = MakeReader(t);
            Assert.AreEqual((short)7, DataUtil.GetShortField(dr, "F"));
        }

        [TestMethod]
        public void TestGetShortFieldDbReader_DBNull()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(short));
            t.Rows.Add((object)null);
            using DataTableReader dr = MakeReader(t);
            Assert.AreEqual((short)0, DataUtil.GetShortField(dr, "F"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestGetShortFieldDbReader_NullReader()
        {
            DataUtil.GetShortField((System.Data.Common.DbDataReader)null, "F");
        }

        // GetGuidField(DbDataReader)

        [TestMethod]
        public void TestGetGuidFieldDbReader_Value()
        {
            Guid expected = Guid.NewGuid();
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(Guid));
            t.Rows.Add(expected);
            using DataTableReader dr = MakeReader(t);
            Assert.AreEqual(expected, DataUtil.GetGuidField(dr, "F"));
        }

        [TestMethod]
        public void TestGetGuidFieldDbReader_DBNull()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(Guid));
            t.Rows.Add((object)null);
            using DataTableReader dr = MakeReader(t);
            Assert.AreEqual(Guid.Empty, DataUtil.GetGuidField(dr, "F"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestGetGuidFieldDbReader_NullReader()
        {
            DataUtil.GetGuidField((System.Data.Common.DbDataReader)null, "F");
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestGetGuidFieldDbReader_NullField()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(Guid));
            t.Rows.Add(Guid.NewGuid());
            using DataTableReader dr = MakeReader(t);
            DataUtil.GetGuidField(dr, (string)null);
        }

        // GetBinaryField(DbDataReader)

        [TestMethod]
        public void TestGetBinaryFieldDbReader_Value()
        {
            byte[] expected = new byte[] { 1, 2, 3 };
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(byte[]));
            t.Rows.Add((object)expected);
            using DataTableReader dr = MakeReader(t);
            CollectionAssert.AreEqual(expected, DataUtil.GetBinaryField(dr, "F"));
        }

        [TestMethod]
        public void TestGetBinaryFieldDbReader_DBNull()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(byte[]));
            t.Rows.Add((object)null);
            using DataTableReader dr = MakeReader(t);
            Assert.IsNull(DataUtil.GetBinaryField(dr, "F"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestGetBinaryFieldDbReader_NullReader()
        {
            DataUtil.GetBinaryField((System.Data.Common.DbDataReader)null, "F");
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestGetBinaryFieldDbReader_NullField()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(byte[]));
            t.Rows.Add((object)new byte[] { 1 });
            using DataTableReader dr = MakeReader(t);
            DataUtil.GetBinaryField(dr, (string)null);
        }

        #endregion
    }
}
