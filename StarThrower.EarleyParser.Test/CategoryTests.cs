/***********************************************************************************
    StarThrower Utilities / EarleyParser
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
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarThrower.EarleyParser;

namespace StarThrower.EarleyParser.Test
{
    [TestClass]
    public class CategoryTests
    {
        #region [ Construction ]

        public CategoryTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion


        #region [ Private Instance Variables ]

        private TestContext? testContextInstance;

        #endregion


        #region [ Public Properties ]

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext? TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #endregion


        #region [ Additional test attributes ]
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion


        [TestMethod]
        public void Root()
        {
            Category r = Category.Root;
            Assert.AreEqual("<start>", r.ToString());
            Assert.AreEqual(false, r.IsTerminal);
        }

        [TestMethod]
        public void RootReturnsSameObject()
        {
            Category r1 = Category.Root;
            Category r2 = Category.Root;
            Assert.AreSame(r1, r2);
        }

        [TestMethod]
        public void IsTerminalNamePropertyReturnsName()
        {
            Category c = new Category("A", true);
            Assert.AreEqual("A", c.Name);
        }

        [TestMethod]
        public void IsTerminalReturnsTrue()
        {
            Category c = new Category("A", true);
            Assert.AreEqual(true, c.IsTerminal);
        }

        [TestMethod]
        public void IsTerminalReturnsFalse()
        {
            Category c = new Category("A", false);
            Assert.AreEqual(false, c.IsTerminal);
        }

        [TestMethod]
        public void ToStringReturnsName()
        {
            Category c = new Category("A");
            Assert.AreEqual("A", c.ToString());
        }

        [TestMethod]
        public void ToStringReturnsNameWhenIsTerminal()
        {
            Category c = new Category("A", true);
            Assert.AreEqual("A", c.ToString());
        }

        [TestMethod]
        public void ToStringReturnsNameWhenNotTerminal()
        {
            Category c = new Category("A", false);
            Assert.AreEqual("A", c.ToString());
        }

        [TestMethod]
        public void ToStringReturnsEmptyForEmptyName()
        {
            Category c = new Category(String.Empty, true);
            Assert.AreEqual("<empty>", c.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CtorThrowsOnNullName()
        {
            string? nullName = null;
            Category c = new Category(nullName, false);
            Assert.Fail("Expected an exception to be thrown!");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CtorThrowsOnEmptyNameWithNonTerminal()
        {
            Category c = new Category("", false);
            Assert.Fail("Expected an exception to be thrown!");
        }

        [TestMethod]
        public void CtorAcceptsEmptyNameWithTerminal()
        {
            Category c = new Category("", true);
            Assert.AreEqual(String.Empty, c.Name);
            Assert.AreEqual(true, c.IsTerminal);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CtorThrowsOnWhitespaceName()
        {
            Category c = new Category(" ", false);
            Assert.Fail("Expected an exception to be thrown!");
        }

        [TestMethod]
        public void EqualsReturnsTrueWhenSame()
        {
            Category a = new Category("A", false);
            Category b = a;
            Assert.AreEqual(true, a.Equals(b));
        }

        [TestMethod]
        public void EqualsReturnsFalseWhenNull()
        {
            Category a = new Category("A", false);
            Category? b = null;
            Assert.AreEqual(false, a.Equals(b));
        }

        [TestMethod]
        public void EqualsReturnsFalseWhenNotCategory()
        {
            Category a = new Category("A", false);
            String b = "asdf";
            Assert.AreEqual(false, a.Equals(b));
        }

        [TestMethod]
        public void EqualsReturnsTrueWhenEquivalent1()
        {
            Category a = new Category("A", false);
            Category b = new Category("A", false);
            Assert.AreEqual(true, a.Equals(b));
        }

        [TestMethod]
        public void EqualsReturnsTrueWhenEquivalent2()
        {
            Category a = new Category("A", true);
            Category b = new Category("A", true);
            Assert.AreEqual(true, a.Equals(b));
        }

        [TestMethod]
        public void EqualsReturnsTrueWhenNotEquivalent1()
        {
            Category a = new Category("A", false);
            Category b = new Category("B", false);
            Assert.AreEqual(false, a.Equals(b));
        }

        [TestMethod]
        public void EqualsReturnsTrueWhenNotEquivalent2()
        {
            Category a = new Category("A", false);
            Category b = new Category("A", true);
            Assert.AreEqual(false, a.Equals(b));
        }

        [TestMethod]
        public void EqualsReturnsTrueWhenNotEquivalent3()
        {
            Category a = new Category("A", true);
            Category b = new Category("A", false);
            Assert.AreEqual(false, a.Equals(b));
        }

        [TestMethod]
        public void EqualsReturnsTrueWhenNotEquivalent4()
        {
            Category a = new Category("A", true);
            Category b = new Category("B", false);
            Assert.AreEqual(false, a.Equals(b));
        }

        [TestMethod]
        public void EqualsReturnsTrueWhenNotEquivalent5()
        {
            Category a = new Category("A", false);
            Category b = new Category("B", true);
            Assert.AreEqual(false, a.Equals(b));
        }

        [TestMethod]
        public void CtorSingleArgument()
        {
            Category a = new Category("A");
            Assert.AreEqual("A", a.Name);
            Assert.AreEqual(false, a.IsTerminal);
        }
    }
}
