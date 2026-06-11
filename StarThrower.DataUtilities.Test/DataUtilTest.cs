// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Data;
using AwesomeAssertions;
using Xunit;
using StarThrower.DataUtilities;

namespace StarThrower.DataUtilities.Test
{
    public class DataUtilTest
    {
        #region GetBoolField() tests

        [Fact]
        public void TestGetBoolField1()
        {
            bool expected = true;
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(bool));
            DataRow? r = t.Rows.Add(new object[] { expected });
            bool actual = DataUtil.GetBooleanField(r, "SomeField");
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestGetBoolField2()
        {
            bool expected = false;
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(bool));
            DataRow? r = t.Rows.Add(new object[] { expected });
            bool actual = DataUtil.GetBooleanField(r, "SomeField");
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestGetBoolField3()
        {
            bool expected = false;
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(bool));
            DataRow? r = t.Rows.Add(new object?[] { null });
            bool actual = DataUtil.GetBooleanField(r, "SomeField");
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestGetBoolFieldArgumentNull1()
        {
            DataRow? r = null;
            string fieldName = "SomeField";
            Action act = () => DataUtil.GetBooleanField(r, fieldName);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestGetBoolFieldArgumentNull2()
        {
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(string));
            DataRow? r = t.Rows.Add(new object[] { "some data" });
            string? fieldName = null;
            Action act = () => DataUtil.GetBooleanField(r, fieldName);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestGetBoolFieldArgumentException1()
        {
            bool expected = false;
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(bool));
            DataRow? r = t.Rows.Add(new object[] { expected });
            Action act = () => DataUtil.GetBooleanField(r, "SomeOtherField");
            act.Should().Throw<ArgumentException>();
        }

        #endregion


        #region GetStringField() tests

        [Fact]
        public void TestGetStringField1()
        {
            string expected = "some data";
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(string));
            DataRow? r = t.Rows.Add(new object[] { expected });
            string actual = DataUtil.GetStringField(r, "SomeField");
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestGetStringField2()
        {
            string expected = String.Empty;
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(string));
            DataRow? r = t.Rows.Add(new object[] { expected });
            string actual = DataUtil.GetStringField(r, "SomeField");
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestGetStringField3()
        {
            string expected = String.Empty;
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(string));
            DataRow? r = t.Rows.Add(new object?[] { null });
            string actual = DataUtil.GetStringField(r, "SomeField");
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestGetStringFieldArgumentNull1()
        {
            DataRow? r = null;
            string fieldName = "SomeField";
            Action act = () => DataUtil.GetStringField(r, fieldName);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestGetStringFieldArgumentNull2()
        {
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(string));
            DataRow? r = t.Rows.Add(new object[] { "some data" });
            string? fieldName = null;
            Action act = () => DataUtil.GetStringField(r, fieldName);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestGetStringFieldArgumentException1()
        {
            string expected = "some data";
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(string));
            DataRow? r = t.Rows.Add(new object[] { expected });
            Action act = () => DataUtil.GetStringField(r, "SomeOtherField");
            act.Should().Throw<ArgumentException>();
        }

        #endregion


        #region GetFloatField() test

        [Fact]
        public void TestGetFloatField1()
        {
            float expected = 0.0f;
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(float));
            DataRow? r = t.Rows.Add(new object[] { expected });
            float actual = DataUtil.GetSingleField(r, "SomeField");
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestGetFloatField2()
        {
            float expected = 123.456f;
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(float));
            DataRow? r = t.Rows.Add(new object[] { expected });
            float actual = DataUtil.GetSingleField(r, "SomeField");
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestGetFloatField3()
        {
            float expected = 0.0f;
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(float));
            DataRow? r = t.Rows.Add(new object?[] { null });
            float actual = DataUtil.GetSingleField(r, "SomeField");
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestGetFloatFieldArgumentNull1()
        {
            DataRow? r = null;
            string fieldName = "SomeField";
            Action act = () => DataUtil.GetSingleField(r, fieldName);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestGetFloatFieldArgumentNull2()
        {
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(string));
            DataRow? r = t.Rows.Add(new object[] { "some data" });
            string? fieldName = null;
            Action act = () => DataUtil.GetSingleField(r, fieldName);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestGetFloatFieldArgumentException1()
        {
            float expected = 0.0f;
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(float));
            DataRow? r = t.Rows.Add(new object[] { expected });
            Action act = () => DataUtil.GetSingleField(r, "SomeOtherField");
            act.Should().Throw<ArgumentException>();
        }

        #endregion


        #region GetDateTimeField() tests

        [Fact]
        public void TestGetDateTimeField1()
        {
            DateTime expected = new DateTime(2007, 6, 24);
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(DateTime));
            DataRow? r = t.Rows.Add(new object[] { expected });
            DateTime actual = DataUtil.GetDateTimeField(r, "SomeField");
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestGetDateTimeField2()
        {
            DateTime expected = new DateTime(2007, 6, 24, 7, 39, 15);
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(DateTime));
            DataRow? r = t.Rows.Add(new object[] { expected });
            DateTime actual = DataUtil.GetDateTimeField(r, "SomeField");
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestGetDateTimeField3()
        {
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(DateTime));
            DataRow? r = t.Rows.Add(new object?[] { null });
            DateTime actual = DataUtil.GetDateTimeField(r, "SomeField");
            // When field is null, GetDateTimeField returns DateTime.Now (at the time of call)
            // We verify it's recent (within last second) rather than comparing exact values
            TimeSpan difference = DateTime.Now - actual;
            (difference.TotalSeconds < 1).Should().BeTrue($"Expected current time but got {actual}");
        }

        [Fact]
        public void TestGetDateTimeFieldArgumentNull1()
        {
            DataRow? r = null;
            string fieldName = "SomeField";
            Action act = () => DataUtil.GetDateTimeField(r, fieldName);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestGetDateTimeFieldArgumentNull2()
        {
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(string));
            DataRow? r = t.Rows.Add(new object[] { "some data" });
            string? fieldName = null;
            Action act = () => DataUtil.GetDateTimeField(r, fieldName);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestGetDateTimeArgumentException1()
        {
            DateTime expected = DataUtil.DTNull;
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(DateTime));
            DataRow? r = t.Rows.Add(new object[] { expected });
            Action act = () => DataUtil.GetDateTimeField(r, "SomeOtherField");
            act.Should().Throw<ArgumentException>();
        }
        #endregion


        #region GetIntField() tests

        [Fact]
        public void TestGetIntField1()
        {
            int expected = 1;
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(int));
            DataRow? r = t.Rows.Add(new object[] { expected });
            int actual = DataUtil.GetInt32Field(r, "SomeField");
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestGetIntField2()
        {
            int expected = 0;
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(int));
            DataRow? r = t.Rows.Add(new object[] { expected });
            int actual = DataUtil.GetInt32Field(r, "SomeField");
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestGetIntField3()
        {
            int expected = 0;
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(int));
            DataRow? r = t.Rows.Add(new object?[] { null });
            int actual = DataUtil.GetInt32Field(r, "SomeField");
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestGetIntFieldArgumentNull1()
        {
            DataRow? r = null;
            string fieldName = "SomeField";
            Action act = () => DataUtil.GetInt32Field(r, fieldName);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestGetIntFieldArgumentNull2()
        {
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(string));
            DataRow? r = t.Rows.Add(new object[] { "some data" });
            string? fieldName = null;
            Action act = () => DataUtil.GetInt32Field(r, fieldName);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestGetIntFieldArgumentException1()
        {
            int expected = 0;
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(int));
            DataRow? r = t.Rows.Add(new object[] { expected });
            Action act = () => DataUtil.GetInt32Field(r, "SomeOtherField");
            act.Should().Throw<ArgumentException>();
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

        [Fact]
        public void TestCheckFieldExistsFound()
        {
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(string));
            t.Rows.Add("x");
            using DataTableReader dr = MakeReader(t);
            (DataUtil.CheckFieldExists(dr, "SomeField")).Should().BeTrue();
        }

        [Fact]
        public void TestCheckFieldExistsNotFound()
        {
            DataTable t = new DataTable();
            t.Columns.Add("SomeField", typeof(string));
            t.Rows.Add("x");
            using DataTableReader dr = MakeReader(t);
            (DataUtil.CheckFieldExists(dr, "OtherField")).Should().BeFalse();
        }

        // GetBoolField(DbDataReader)

        [Fact]
        public void TestGetBoolFieldDbReaderTrue()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(bool));
            t.Rows.Add(true);
            using DataTableReader dr = MakeReader(t);
            (DataUtil.GetBoolField(dr, "F")).Should().Be(true);
        }

        [Fact]
        public void TestGetBoolFieldDbReaderDBNull()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(bool));
            t.Rows.Add((object?)null);
            using DataTableReader dr = MakeReader(t);
            (DataUtil.GetBoolField(dr, "F")).Should().Be(false);
        }

        [Fact]
        public void TestGetBoolFieldDbReaderCustomDefault()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(bool));
            t.Rows.Add((object?)null);
            using DataTableReader dr = MakeReader(t);
            (DataUtil.GetBoolField(dr, "F", true)).Should().Be(true);
        }

        [Fact]
        public void TestGetBoolFieldDbReaderNullReader()
        {
            Action act = () => DataUtil.GetBoolField((System.Data.Common.DbDataReader?)null, "F");
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestGetBoolFieldDbReaderNullField()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(bool));
            t.Rows.Add(true);
            using DataTableReader dr = MakeReader(t);
            Action act = () => DataUtil.GetBoolField(dr, (string?)null);
            act.Should().Throw<ArgumentNullException>();
        }

        // GetStringField(DbDataReader)

        [Fact]
        public void TestGetStringFieldDbReaderValue()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(string));
            t.Rows.Add("hello");
            using DataTableReader dr = MakeReader(t);
            (DataUtil.GetStringField(dr, "F")).Should().Be("hello");
        }

        [Fact]
        public void TestGetStringFieldDbReaderDBNull()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(string));
            t.Rows.Add((object?)null);
            using DataTableReader dr = MakeReader(t);
            (DataUtil.GetStringField(dr, "F")).Should().Be(string.Empty);
        }

        [Fact]
        public void TestGetStringFieldDbReaderCustomDefault()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(string));
            t.Rows.Add((object?)null);
            using DataTableReader dr = MakeReader(t);
            (DataUtil.GetStringField(dr, "F", "default")).Should().Be("default");
        }

        [Fact]
        public void TestGetStringFieldDbReaderNullReader()
        {
            Action act = () => DataUtil.GetStringField((System.Data.Common.DbDataReader?)null, "F");
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestGetStringFieldDbReaderNullField()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(string));
            t.Rows.Add("x");
            using DataTableReader dr = MakeReader(t);
            Action act = () => DataUtil.GetStringField(dr, (string?)null);
            act.Should().Throw<ArgumentNullException>();
        }

        // GetDateTimeField(DbDataReader)

        [Fact]
        public void TestGetDateTimeFieldDbReaderValue()
        {
            DateTime expected = new DateTime(2007, 6, 24);
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(DateTime));
            t.Rows.Add(expected);
            using DataTableReader dr = MakeReader(t);
            (DataUtil.GetDateTimeField(dr, "F", DateTime.MinValue)).Should().Be(expected);
        }

        [Fact]
        public void TestGetDateTimeFieldDbReaderDBNull()
        {
            DateTime sentinel = new DateTime(1999, 1, 1);
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(DateTime));
            t.Rows.Add((object?)null);
            using DataTableReader dr = MakeReader(t);
            (DataUtil.GetDateTimeField(dr, "F", sentinel)).Should().Be(sentinel);
        }

        [Fact]
        public void TestGetDateTimeFieldDbReaderNullReader()
        {
            Action act = () => DataUtil.GetDateTimeField((System.Data.Common.DbDataReader?)null, "F", DateTime.MinValue);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestGetDateTimeFieldDbReaderNullField()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(DateTime));
            t.Rows.Add(DateTime.Now);
            using DataTableReader dr = MakeReader(t);
            Action act = () => DataUtil.GetDateTimeField(dr, (string?)null, DateTime.MinValue);
            act.Should().Throw<ArgumentNullException>();
        }

        // GetFloatField(DbDataReader)

        [Fact]
        public void TestGetFloatFieldDbReaderValue()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(float));
            t.Rows.Add(3.14f);
            using DataTableReader dr = MakeReader(t);
            (DataUtil.GetFloatField(dr, "F")).Should().Be(3.14f);
        }

        [Fact]
        public void TestGetFloatFieldDbReaderDBNull()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(float));
            t.Rows.Add((object?)null);
            using DataTableReader dr = MakeReader(t);
            (DataUtil.GetFloatField(dr, "F", 99f)).Should().Be(99f);
        }

        [Fact]
        public void TestGetFloatFieldDbReaderNullReader()
        {
            Action act = () => DataUtil.GetFloatField((System.Data.Common.DbDataReader?)null, "F");
            act.Should().Throw<ArgumentNullException>();
        }

        // GetDoubleField(DbDataReader)

        [Fact]
        public void TestGetDoubleFieldDbReaderValue()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(double));
            t.Rows.Add(2.718);
            using DataTableReader dr = MakeReader(t);
            (DataUtil.GetDoubleField(dr, "F")).Should().Be(2.718);
        }

        [Fact]
        public void TestGetDoubleFieldDbReaderDBNull()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(double));
            t.Rows.Add((object?)null);
            using DataTableReader dr = MakeReader(t);
            (DataUtil.GetDoubleField(dr, "F")).Should().Be(0.0);
        }

        [Fact]
        public void TestGetDoubleFieldDbReaderNullReader()
        {
            Action act = () => DataUtil.GetDoubleField((System.Data.Common.DbDataReader?)null, "F");
            act.Should().Throw<ArgumentNullException>();
        }

        // GetLongField(DbDataReader)

        [Fact]
        public void TestGetLongFieldDbReaderValue()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(long));
            t.Rows.Add(123456789L);
            using DataTableReader dr = MakeReader(t);
            (DataUtil.GetLongField(dr, "F")).Should().Be(123456789L);
        }

        [Fact]
        public void TestGetLongFieldDbReaderDBNull()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(long));
            t.Rows.Add((object?)null);
            using DataTableReader dr = MakeReader(t);
            (DataUtil.GetLongField(dr, "F")).Should().Be(0L);
        }

        [Fact]
        public void TestGetLongFieldDbReaderNullReader()
        {
            Action act = () => DataUtil.GetLongField((System.Data.Common.DbDataReader?)null, "F");
            act.Should().Throw<ArgumentNullException>();
        }

        // GetIntField(DbDataReader)

        [Fact]
        public void TestGetIntFieldDbReaderValue()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(int));
            t.Rows.Add(42);
            using DataTableReader dr = MakeReader(t);
            (DataUtil.GetIntField(dr, "F")).Should().Be(42);
        }

        [Fact]
        public void TestGetIntFieldDbReaderDBNull()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(int));
            t.Rows.Add((object?)null);
            using DataTableReader dr = MakeReader(t);
            (DataUtil.GetIntField(dr, "F")).Should().Be(0);
        }

        [Fact]
        public void TestGetIntFieldDbReaderNullReader()
        {
            Action act = () => DataUtil.GetIntField((System.Data.Common.DbDataReader?)null, "F");
            act.Should().Throw<ArgumentNullException>();
        }

        // GetShortField(DbDataReader)

        [Fact]
        public void TestGetShortFieldDbReaderValue()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(short));
            t.Rows.Add((short)7);
            using DataTableReader dr = MakeReader(t);
            (DataUtil.GetShortField(dr, "F")).Should().Be((short)7);
        }

        [Fact]
        public void TestGetShortFieldDbReaderDBNull()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(short));
            t.Rows.Add((object?)null);
            using DataTableReader dr = MakeReader(t);
            (DataUtil.GetShortField(dr, "F")).Should().Be((short)0);
        }

        [Fact]
        public void TestGetShortFieldDbReaderNullReader()
        {
            Action act = () => DataUtil.GetShortField((System.Data.Common.DbDataReader?)null, "F");
            act.Should().Throw<ArgumentNullException>();
        }

        // GetGuidField(DbDataReader)

        [Fact]
        public void TestGetGuidFieldDbReaderValue()
        {
            Guid expected = Guid.NewGuid();
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(Guid));
            t.Rows.Add(expected);
            using DataTableReader dr = MakeReader(t);
            (DataUtil.GetGuidField(dr, "F")).Should().Be(expected);
        }

        [Fact]
        public void TestGetGuidFieldDbReaderDBNull()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(Guid));
            t.Rows.Add((object?)null);
            using DataTableReader dr = MakeReader(t);
            (DataUtil.GetGuidField(dr, "F")).Should().Be(Guid.Empty);
        }

        [Fact]
        public void TestGetGuidFieldDbReaderNullReader()
        {
            Action act = () => DataUtil.GetGuidField((System.Data.Common.DbDataReader?)null, "F");
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestGetGuidFieldDbReaderNullField()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(Guid));
            t.Rows.Add(Guid.NewGuid());
            using DataTableReader dr = MakeReader(t);
            Action act = () => DataUtil.GetGuidField(dr, (string?)null);
            act.Should().Throw<ArgumentNullException>();
        }

        // GetBinaryField(DbDataReader)

        [Fact]
        public void TestGetBinaryFieldDbReaderValue()
        {
            byte[] expected = new byte[] { 1, 2, 3 };
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(byte[]));
            t.Rows.Add((object)expected);
            using DataTableReader dr = MakeReader(t);
            (DataUtil.GetBinaryField(dr, "F")).Should().Equal(expected);
        }

        [Fact]
        public void TestGetBinaryFieldDbReaderDBNull()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(byte[]));
            t.Rows.Add((object?)null);
            using DataTableReader dr = MakeReader(t);
            (DataUtil.GetBinaryField(dr, "F")).Should().BeNull();
        }

        [Fact]
        public void TestGetBinaryFieldDbReaderNullReader()
        {
            Action act = () => DataUtil.GetBinaryField((System.Data.Common.DbDataReader?)null, "F");
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestGetBinaryFieldDbReaderNullField()
        {
            DataTable t = new DataTable();
            t.Columns.Add("F", typeof(byte[]));
            t.Rows.Add((object)new byte[] { 1 });
            using DataTableReader dr = MakeReader(t);
            Action act = () => DataUtil.GetBinaryField(dr, (string?)null);
            act.Should().Throw<ArgumentNullException>();
        }

        #endregion
    }
}
