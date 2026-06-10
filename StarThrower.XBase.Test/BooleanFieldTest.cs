// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarThrower.XBase;

namespace StarThrower.XBase.Test
{
    [TestClass]
    public class BooleanFieldTest
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
            FieldType t = new BooleanField();
            Assert.IsNotNull(t);
            Assert.AreEqual("Boolean", t.Text);
            Assert.AreEqual('L', t.Code);
        }

        [TestMethod]
        public void TestIsValidLength()
        {
            FieldType t = new BooleanField();
            Assert.IsTrue(t.IsValidLength(1));
            Assert.IsFalse(t.IsValidLength(0));
            Assert.IsFalse(t.IsValidLength(2));
        }

        [TestMethod]
        public void TestIsValidDecimalCount()
        {
            FieldType t = new BooleanField();
            Assert.IsTrue(t.IsValidDecimalCount(0));
            Assert.IsFalse(t.IsValidDecimalCount(-1));
            Assert.IsFalse(t.IsValidDecimalCount(1));
        }

        [TestMethod]
        public void TestAddBooleanField()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.BooleanField();
            field.Name = "MYBOOL";
            file.AddField(field);

            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYBOOL", true);
            file.AddRecord(record);

            record = file.CreateRecord();
            record.SetData("MYBOOL", false);
            file.AddRecord(record);

            Assert.IsInstanceOfType<bool>(file.GetRecord(0).GetData("MYBOOL"));
            Assert.AreEqual(true, file.GetRecord(0).GetData("MYBOOL"));

            Assert.IsInstanceOfType<bool>(file.GetRecord(1).GetData("MYBOOL"));
            Assert.AreEqual(false, file.GetRecord(1).GetData("MYBOOL"));
        }
    }
}
