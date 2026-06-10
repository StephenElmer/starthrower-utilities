// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarThrower.XBase;

namespace StarThrower.XBase.Test
{
    [TestClass]
    public class FloatFieldTest
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
            FieldType t = new FloatField();
            Assert.IsNotNull(t);
            Assert.AreEqual("Float", t.Text);
            Assert.AreEqual('F', t.Code);
        }

        [TestMethod]
        public void TestGoodLength()
        {
            FieldType t = new FloatField();
            Assert.IsTrue(t.IsValidLength(20));
        }

        [TestMethod]
        public void TestLengthBeyondLowerBound()
        {
            FieldType t = new FloatField();
            Assert.IsFalse(t.IsValidLength(0));
        }

        [TestMethod]
        public void TestLengthBeyondUpperBound()
        {
            FieldType t = new FloatField();
            Assert.IsFalse(t.IsValidLength(21));
        }

        [TestMethod]
        public void TestGoodDecimalCount()
        {
            FieldType t = new FloatField();
            Assert.IsTrue(t.IsValidDecimalCount(0));
            Assert.IsTrue(t.IsValidDecimalCount(1));
            Assert.IsTrue(t.IsValidDecimalCount(19));
        }

        [TestMethod]
        public void TestDecimalCountBeyondLowerBound()
        {
            FieldType t = new FloatField();
            Assert.IsFalse(t.IsValidDecimalCount(-1));
        }

        [TestMethod]
        public void TestDecimalCountBeyondUpperBound()
        {
            FieldType t = new FloatField();
            Assert.IsFalse(t.IsValidDecimalCount(20));
        }

        [TestMethod]
        public void TestGoodDecimalCount2()
        {
            FieldType t = new FloatField();
            XBaseField f = new XBaseField();
            f.Length = 5;
            f.FieldType = t;
            Assert.IsTrue(t.IsValidDecimalCount(0));
            Assert.IsTrue(t.IsValidDecimalCount(1));
            Assert.IsTrue(t.IsValidDecimalCount(4));
            Assert.IsTrue(t.IsValidDecimalCount(19));
        }

        [TestMethod]
        public void TestDecimalCountBeyondLowerBound2()
        {
            FieldType t = new FloatField();
            XBaseField f = new XBaseField();
            f.Length = 5;
            f.FieldType = t;
            Assert.IsFalse(t.IsValidDecimalCount(-1));
        }

        [TestMethod]
        public void TestDecimalCountBeyondUpperBound2()
        {
            FieldType t = new FloatField();
            XBaseField f = new XBaseField();
            f.Length = 5;
            f.FieldType = t;
            Assert.IsFalse(t.IsValidDecimalCount(20));
        }
    }
}
