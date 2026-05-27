using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarThrower.XBase;

namespace StarThrower.XBase.Test
{
    [TestClass]
    public class UndefinedFieldTest
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
            FieldType t = new UndefinedField();
            Assert.IsNotNull(t);
            Assert.AreEqual("Undefined", t.Text);
            Assert.AreEqual('U', t.Code);
        }

        [TestMethod]
        public void TestGoodLength()
        {
            FieldType t = new UndefinedField();
            Assert.IsTrue(t.IsValidLength(1));
            Assert.IsTrue(t.IsValidLength(253));
        }

        [TestMethod]
        public void TestLengthBeyondLowerBound()
        {
            FieldType t = new UndefinedField();
            Assert.IsFalse(t.IsValidLength(-1));
        }

        [TestMethod]
        public void TestGoodDecimalCount()
        {
            FieldType t = new UndefinedField();
            Assert.IsTrue(t.IsValidDecimalCount(0));
        }

        [TestMethod]
        public void TestDecimalCountBeyondLowerBound()
        {
            FieldType t = new UndefinedField();
            Assert.IsFalse(t.IsValidDecimalCount(-1));
        }
    }
}
