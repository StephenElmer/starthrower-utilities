// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarThrower.XBase;

namespace StarThrower.XBase.Test
{
    [TestClass]
    public class NumericFieldTest
    {
        private static void Ignore()
        {
#if FAIL_ON_IGNORE
                Assert.Fail("This test has been ignored.");
#else
            Assert.Inconclusive("this test has been ignored");
#endif
        }

        [TestMethod]
        public void TestConstructor()
        {
            FieldType t = new NumericField();
            Assert.IsNotNull(t);
            Assert.AreEqual("Numeric", t.Text);
            Assert.AreEqual('N', t.Code);
        }

        [TestMethod]
        public void TestGoodLength()
        {
            FieldType t = new NumericField();
            Assert.IsTrue(t.IsValidLength(1));
            Assert.IsTrue(t.IsValidLength(17));
        }

        [TestMethod]
        public void TestLengthBeyondLowerBound()
        {
            FieldType t = new NumericField();
            Assert.IsFalse(t.IsValidLength(0));
        }

        [TestMethod]
        public void TestLengthBeyondUpperBound()
        {
            FieldType t = new NumericField();
            Assert.IsFalse(t.IsValidLength(18));
        }

        [TestMethod]
        public void TestGoodDecimalCountLowEnd()
        {
            FieldType t = new NumericField();
            Assert.IsTrue(t.IsValidDecimalCount(0));
        }

        [TestMethod]
        public void TestGoodDecimalCountHighEnd()
        {
            FieldType t = new NumericField();
            Assert.IsTrue(t.IsValidDecimalCount(15));
        }

        [TestMethod]
        public void TestDecimalCountBeyondLowerBound()
        {
            FieldType t = new NumericField();
            Assert.IsFalse(t.IsValidDecimalCount(-1));
        }

        [TestMethod]
        public void TestDecimalCountBeyondUpperBound()
        {
            FieldType t = new NumericField();
            Assert.IsFalse(t.IsValidDecimalCount(16));
        }


        #region Short Tests

        [TestMethod]
        public void TestAddShortField1()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 4;
            field.DecimalCount = 0;
            file.AddField(field);

            short val = 7;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYNUM", val);
            file.AddRecord(record);

            Assert.IsInstanceOfType<long>(file.GetRecord(0).GetData("MYNUM"));
            Assert.AreEqual(7L, file.GetRecord(0).GetData("MYNUM"));
        }

        [TestMethod, ExpectedException(typeof(BadDataException))]
        public void TestAddShortField2()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 4;
            field.DecimalCount = 0;
            file.AddField(field);

            short val = 32767;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYNUM", val);
            file.AddRecord(record);

            Assert.Fail();
        }

        [TestMethod]
        public void TestAddShortField3()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 6;
            field.DecimalCount = 0;
            file.AddField(field);

            short val = short.MinValue;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYNUM", val);
            file.AddRecord(record);

            Assert.IsInstanceOfType<long>(file.GetRecord(0).GetData("MYNUM"));
            Assert.AreEqual((long)(short.MinValue), file.GetRecord(0).GetData("MYNUM"));
        }

        [TestMethod]
        public void TestAddShortField4()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 6;
            field.DecimalCount = 0;
            file.AddField(field);

            short val = short.MaxValue;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYNUM", val);
            file.AddRecord(record);

            Assert.IsInstanceOfType<long>(file.GetRecord(0).GetData("MYNUM"));
            Assert.AreEqual((long)(short.MaxValue), file.GetRecord(0).GetData("MYNUM"));
        }

        [TestMethod, ExpectedException(typeof(BadDataException))]
        public void TestAddShortField5()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 5;
            field.DecimalCount = 0;
            file.AddField(field);

            short val = short.MinValue;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYNUM", val);
            file.AddRecord(record);

            Assert.Fail();
        }

        #endregion


        #region Int Tests

        [TestMethod]
        public void TestAddIntField1()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 4;
            field.DecimalCount = 0;
            file.AddField(field);

            int val = 7;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYNUM", val);
            file.AddRecord(record);

            Assert.IsInstanceOfType<long>(file.GetRecord(0).GetData("MYNUM"));
            Assert.AreEqual(7L, file.GetRecord(0).GetData("MYNUM"));
        }

        [TestMethod, ExpectedException(typeof(BadDataException))]
        public void TestAddIntField2()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 4;
            field.DecimalCount = 0;
            file.AddField(field);

            int val = 32767;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYNUM", val);
            file.AddRecord(record);

            Assert.Fail();
        }

        [TestMethod]
        public void TestAddIntField3()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 11;
            field.DecimalCount = 0;
            file.AddField(field);

            int val = int.MinValue;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYNUM", val);
            file.AddRecord(record);

            Assert.IsInstanceOfType<long>(file.GetRecord(0).GetData("MYNUM"));
            Assert.AreEqual((long)(int.MinValue), file.GetRecord(0).GetData("MYNUM"));
        }

        [TestMethod]
        public void TestAddIntField4()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 10;
            field.DecimalCount = 0;
            file.AddField(field);

            int val = int.MaxValue;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYNUM", val);
            file.AddRecord(record);

            Assert.IsInstanceOfType<long>(file.GetRecord(0).GetData("MYNUM"));
            Assert.AreEqual((long)(int.MaxValue), file.GetRecord(0).GetData("MYNUM"));
        }

        [TestMethod, ExpectedException(typeof(BadDataException))]
        public void TestAddIntField5()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 10;
            field.DecimalCount = 0;
            file.AddField(field);

            int val = int.MinValue;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYNUM", val);
            file.AddRecord(record);

            Assert.Fail();
        }

        #endregion


        #region Long Tests

        [TestMethod]
        public void TestAddLongField1()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 4;
            field.DecimalCount = 0;
            file.AddField(field);

            long val = 7;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYNUM", val);
            file.AddRecord(record);

            Assert.IsInstanceOfType<long>(file.GetRecord(0).GetData("MYNUM"));
            Assert.AreEqual(7L, file.GetRecord(0).GetData("MYNUM"));
        }

        [TestMethod, ExpectedException(typeof(BadDataException))]
        public void TestAddLongField2()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 4;
            field.DecimalCount = 0;
            file.AddField(field);

            long val = 32767;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYNUM", val);
            file.AddRecord(record);

            Assert.Fail();
        }

        [TestMethod]
        public void TestAddLongField3()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 17;
            field.DecimalCount = 0;
            file.AddField(field);

            long val = -9999999999999999;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYNUM", val);
            file.AddRecord(record);

            Assert.IsInstanceOfType<long>(file.GetRecord(0).GetData("MYNUM"));
            Assert.AreEqual(-9999999999999999, file.GetRecord(0).GetData("MYNUM"));
        }

        [TestMethod]
        public void TestAddLongField4()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 17;
            field.DecimalCount = 0;
            file.AddField(field);

            long val = 99999999999999999;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYNUM", val);
            file.AddRecord(record);

            Assert.IsInstanceOfType<long>(file.GetRecord(0).GetData("MYNUM"));
            Assert.AreEqual(99999999999999999, file.GetRecord(0).GetData("MYNUM"));
        }

        [TestMethod, ExpectedException(typeof(BadDataException))]
        public void TestAddLongField5()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 16;
            field.DecimalCount = 0;
            file.AddField(field);

            long val = -9999999999999999;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYNUM", val);
            file.AddRecord(record);

            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(BadDataException))]
        public void TestAddLongField6()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 17;
            field.DecimalCount = 0;
            file.AddField(field);

            long val = long.MinValue;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYNUM", val);
            file.AddRecord(record);

            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(BadDataException))]
        public void TestAddLongField7()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 17;
            field.DecimalCount = 0;
            file.AddField(field);

            long val = long.MaxValue;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYNUM", val);
            file.AddRecord(record);

            Assert.Fail();
        }

        #endregion
    }
}
