using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarThrower.XBase;

namespace StarThrower.XBase.Test
{
    [TestClass]
    public class DateFieldTest
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
            FieldType t = new DateField();
            Assert.IsNotNull(t);
            Assert.AreEqual("Date", t.Text);
            Assert.AreEqual('D', t.Code);
        }

        [TestMethod]
        public void TestGoodLength()
        {
            FieldType t = new DateField();
            Assert.IsTrue(t.IsValidLength(8));
            Assert.IsFalse(t.IsValidLength(7));
            Assert.IsFalse(t.IsValidLength(9));
        }

        [TestMethod]
        public void TestLengthBeyondLowerBound()
        {
            FieldType t = new DateField();
            Assert.IsFalse(t.IsValidLength(7));
        }

        [TestMethod]
        public void TestLengthBeyondUpperBound()
        {
            FieldType t = new DateField();
            Assert.IsFalse(t.IsValidLength(9));
        }

        [TestMethod]
        public void TestIsValidDecimalCount()
        {
            FieldType t = new DateField();
            Assert.IsTrue(t.IsValidDecimalCount(0));
            Assert.IsFalse(t.IsValidDecimalCount(-1));
            Assert.IsFalse(t.IsValidDecimalCount(1));
        }

        [TestMethod]
        public void TestAddDateTimeField()
        {
            DateTime dtNow = DateTime.Now;
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.DateField();
            field.Name = "MYDATE";
            file.AddField(field);

            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYDATE", dtNow);
            file.AddRecord(record);
            record = null;

            record = file.CreateRecord();
            record.SetData("MYDATE", new DateTime(1968, 5, 18));
            file.AddRecord(record);
            record = null;


            Assert.IsInstanceOfType(file.GetRecord(0).GetData("MYDATE"), typeof(DateTime));
            Assert.AreEqual(dtNow.Date, file.GetRecord(0).GetData("MYDATE"));

            Assert.IsInstanceOfType(file.GetRecord(1).GetData("MYDATE"), typeof(DateTime));
            Assert.AreEqual(new DateTime(1968, 5, 18), file.GetRecord(1).GetData("MYDATE"));
        }
    }
}
