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
    public class MemoFieldTest
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
