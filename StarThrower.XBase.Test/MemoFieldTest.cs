using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarThrower.XBase;

namespace StarThrower.XBase.Test
{
    [TestClass]
    public class MemoFieldTest
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
            FieldType t = new MemoField();
            Assert.IsNotNull(t);
            Assert.AreEqual("Memo", t.Text);
            Assert.AreEqual('M', t.Code);
        }

        [TestMethod]
        public void TestGoodLength()
        {
            FieldType t = new MemoField();
            Assert.IsTrue(t.IsValidLength(10));
        }

        [TestMethod]
        public void TestLengthBeyondLowerBound()
        {
            FieldType t = new MemoField();
            Assert.IsFalse(t.IsValidLength(9));
        }

        [TestMethod]
        public void TestLengthBeyondUpperBound()
        {
            FieldType t = new MemoField();
            Assert.IsFalse(t.IsValidLength(11));
        }

        [TestMethod]
        public void TestIsValidDecimalCount()
        {
            FieldType t = new MemoField();
            Assert.IsTrue(t.IsValidDecimalCount(0));
            Assert.IsFalse(t.IsValidDecimalCount(-1));
            Assert.IsFalse(t.IsValidDecimalCount(1));
        }
    }
}
