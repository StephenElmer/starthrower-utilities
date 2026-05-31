/***********************************************************************************
    StarThrower Utilities / XBase
    Copyright (C) 2005-2026  Stephen Elmer

    This library is free software; you can redistribute it and/or
    modify it under the terms of the GNU Lesser General Public
    License as published by the Free Software Foundation; either
    version 2.1 of the License, or (at your option) any later version.

    This library is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
    Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public
    License along with this library; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
***********************************************************************************/

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarThrower.XBase;

namespace StarThrower.XBase.Test
{
    [TestClass]
    public class FloatFieldTest
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
