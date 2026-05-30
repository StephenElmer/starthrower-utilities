using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarThrower.XBase;

namespace StarThrower.XBase.Test
{
    [TestClass]
    public class StringFieldTest
    {
        private void Ignore()
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
            FieldType t = new StringField();
            Assert.IsNotNull(t);
            Assert.AreEqual("String", t.Text);
            Assert.AreEqual('C', t.Code);
        }

        [TestMethod]
        public void TestGoodLength()
        {
            FieldType t = new StringField();
            Assert.IsTrue(t.IsValidLength(1));
            Assert.IsTrue(t.IsValidLength(253));
        }

        [TestMethod]
        public void TestLengthBeyondLowerBound()
        {
            FieldType t = new StringField();
            Assert.IsFalse(t.IsValidLength(0));
        }

        [TestMethod]
        public void TestLengthBeyondUpperBound()
        {
            FieldType t = new StringField();
            Assert.IsFalse(t.IsValidLength(254));
        }

        [TestMethod]
        public void TestGoodDecimalCount()
        {
            FieldType t = new StringField();
            Assert.IsTrue(t.IsValidDecimalCount(0));
        }

        [TestMethod]
        public void TestDecimalCountBeyondLowerBound()
        {
            FieldType t = new StringField();
            Assert.IsFalse(t.IsValidDecimalCount(-1));
        }

        [TestMethod]
        public void TestDecimalCountBeyondUpperBound()
        {
            FieldType t = new StringField();
            Assert.IsFalse(t.IsValidDecimalCount(1));
        }

        [TestMethod]
        public void TestAddStringField1()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.StringField();
            field.Length = 10;
            field.Name = "MYSTRING";
            file.AddField(field);

            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYSTRING", "1234567890");
            file.AddRecord(record);

            record = file.CreateRecord();
            record.SetData("MYSTRING", "abcdefghij");
            file.AddRecord(record);

            Assert.IsInstanceOfType(file.GetRecord(0).GetData("MYSTRING"), typeof(string));
            Assert.AreEqual("1234567890", file.GetRecord(0).GetData("MYSTRING"));

            Assert.IsInstanceOfType(file.GetRecord(1).GetData("MYSTRING"), typeof(string));
            Assert.AreEqual("abcdefghij", file.GetRecord(1).GetData("MYSTRING"));
        }

        [TestMethod]
        public void TestAddStringField2()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.StringField();
            field.Length = 10;
            field.Name = "MYSTRING";
            file.AddField(field);

            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYSTRING", "");
            file.AddRecord(record);

            record = file.CreateRecord();
            record.SetData("MYSTRING", "1");
            file.AddRecord(record);

            record = file.CreateRecord();
            record.SetData("MYSTRING", "123456789");
            file.AddRecord(record);

            record = file.CreateRecord();
            record.SetData("MYSTRING", "         0");
            file.AddRecord(record);

            Assert.IsInstanceOfType(file.GetRecord(0).GetData("MYSTRING"), typeof(string));
            Assert.AreEqual("          ", file.GetRecord(0).GetData("MYSTRING"));

            Assert.IsInstanceOfType(file.GetRecord(1).GetData("MYSTRING"), typeof(string));
            Assert.AreEqual("1         ", file.GetRecord(1).GetData("MYSTRING"));

            Assert.IsInstanceOfType(file.GetRecord(2).GetData("MYSTRING"), typeof(string));
            Assert.AreEqual("123456789 ", file.GetRecord(2).GetData("MYSTRING"));

            Assert.IsInstanceOfType(file.GetRecord(3).GetData("MYSTRING"), typeof(string));
            Assert.AreEqual("         0", file.GetRecord(3).GetData("MYSTRING"));
        }

        [TestMethod, ExpectedException(typeof(BadDataException))]
        public void TestAddStringField3()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.StringField();
            field.Length = 10;
            field.Name = "MYSTRING";
            file.AddField(field);

            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYSTRING", "          0");
            file.AddRecord(record);

            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(BadDataException))]
        public void TestAddStringField4()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.StringField();
            field.Length = 10;
            field.Name = "MYSTRING";
            file.AddField(field);

            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYSTRING", "12345678901");
            file.AddRecord(record);

            Assert.Fail();
        }
    }
}
