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
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarThrower.EarleyParser;

namespace StarThrower.EarleyParser.Test
{
    [TestClass]
    public class RuleTests
    {
        #region [ Construction ]

        public RuleTests()
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
        [ExpectedException(typeof(ArgumentNullException))]
        public void CtorThrowsOnNullLeft()
        {
            Category? left = null;
            List<Category> l = new List<Category>();
            l.Add(new Category("R"));
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(l);
            Rule r = new Rule(left, right);
            Assert.Fail("Expected an exception here!");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CtorThrowsOnNullTerminalLeft()
        {
            Category left = new Category("l", true);
            List<Category> l = new List<Category>();
            l.Add(new Category("R"));
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(l);
            Rule r = new Rule(left, right);
            Assert.Fail("Expected an exception here!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CtorThrowsOnNullRight()
        {
            Category left = new Category("L", false);
            ReadOnlyCollection<Category>? right = null;
            Rule r = new Rule(left, right);
            Assert.Fail("Expected an exception here!");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CtorThrowsOnEmptyRight()
        {
            Category left = new Category("L", false);
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(new List<Category>());
            Rule r = new Rule(left, right);
            Assert.Fail("Expected an exception here!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CtorThrowsOnNullItemInRight()
        {
            Category? left = null;
            Category[] arr = new Category[3];
            arr[0] = new Category("R", false);
            arr[2] = new Category("r", true);
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(arr);
            Rule r = new Rule(left, right);
            Assert.Fail("Expected an exception here!");
        }

        [TestMethod]
        public void IsPreterminalReturnsTrueForPreTerm()
        {
            Category left = new Category("L", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("R1", false));
            l.Add(new Category("r2", true));
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(l);
            Rule r = new Rule(left, right);
            Assert.AreEqual(true, r.IsPreterminal);
        }

        [TestMethod]
        public void IsPreterminalReturnsFalseForNonPreTerm()
        {
            Category left = new Category("L", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("R1", false));
            l.Add(new Category("R2", false));
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(l);
            Rule r = new Rule(left, right);
            Assert.AreEqual(false, r.IsPreterminal);
        }

        [TestMethod]
        public void IsSingletonPreterminalReturnsTrue()
        {
            Category left = new Category("L", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("r", true));
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(l);
            Rule r = new Rule(left, right);
            Assert.AreEqual(true, r.IsSingletonPreterminal);
        }

        [TestMethod]
        public void IsSingletonPreterminalReturnsFalse1()
        {
            Category left = new Category("L", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("r", false));
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(l);
            Rule r = new Rule(left, right);
            Assert.AreEqual(false, r.IsSingletonPreterminal);
        }

        [TestMethod]
        public void IsSingletonPreterminalReturnsFalse2()
        {
            Category left = new Category("L", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("r", true));
            l.Add(new Category("r", true));
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(l);
            Rule r = new Rule(left, right);
            Assert.AreEqual(false, r.IsSingletonPreterminal);
        }

        [TestMethod]
        public void LeftReturnsLeftReference()
        {
            Category left = new Category("L", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("R1", false));
            l.Add(new Category("R2", false));
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(l);
            Rule r = new Rule(left, right);
            Assert.AreSame(left, r.Left);
        }

        [TestMethod]
        public void LeftReturnsLeftReferenceOnly()
        {
            Category left = new Category("L", false);
            List<Category> l = new List<Category>();
            Category right1 = new Category("R1", false);
            Category right2 = new Category("r1", true);
            l.Add(right1);
            l.Add(right2);
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(l);
            Rule r = new Rule(left, right);
            Assert.AreNotSame(right1, r.Left);
        }

        [TestMethod]
        public void RightReturnsRightReference()
        {
            Category left = new Category("L", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("R1", false));
            l.Add(new Category("R2", false));
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(l);
            Rule r = new Rule(left, right);
            Assert.AreSame(right, r.Right);
        }

        [TestMethod]
        public void ToString1()
        {
            Category left1 = new Category("A", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("B", false));
            l.Add(new Category("C", false));
            l.Add(new Category("D", false));
            l.Add(new Category("E", false));
            ReadOnlyCollection<Category> right1 = new ReadOnlyCollection<Category>(l);
            Rule r1 = new Rule(left1, right1);

            Assert.AreEqual("A -> B C D E", r1.ToString());
        }

        [TestMethod]
        public void ToString2()
        {
            Category left2 = new Category("A", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("a", true));
            ReadOnlyCollection<Category> right2 = new ReadOnlyCollection<Category>(l);
            Rule r2 = new Rule(left2, right2);

            Assert.AreEqual("A -> a", r2.ToString());
        }

        [TestMethod]
        public void ToString3()
        {
            Category left3 = new Category("X", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("Y", false));
            l.Add(new Category("Z", false));
            ReadOnlyCollection<Category> right3 = new ReadOnlyCollection<Category>(l);
            Rule r3 = new Rule(left3, right3);

            Assert.AreEqual("X -> Y Z", r3.ToString());
        }

        [TestMethod]
        public void Equals1()
        {
            Category left1 = new Category("A", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("B", false));
            ReadOnlyCollection<Category> right1 = new ReadOnlyCollection<Category>(l);
            Rule r1 = new Rule(left1, right1);

            Category left2 = new Category("A", false);
            l = new List<Category>();
            l.Add(new Category("B", false));
            ReadOnlyCollection<Category> right2 = new ReadOnlyCollection<Category>(l);
            Rule r2 = new Rule(left2, right2);

            Assert.AreEqual(true, r1.Equals(r2));
        }

        [TestMethod]
        public void EqualsReturnsFalseWhenSame()
        {
            Category left1 = new Category("A", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("B", false));
            ReadOnlyCollection<Category> right1 = new ReadOnlyCollection<Category>(l);
            Rule r1 = new Rule(left1, right1);

            Assert.AreEqual(true, r1.Equals(r1));
        }

        [TestMethod]
        public void EqualsReturnsFalseWhenNull()
        {
            Category left1 = new Category("A", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("B", false));
            ReadOnlyCollection<Category> right1 = new ReadOnlyCollection<Category>(l);
            Rule r1 = new Rule(left1, right1);

            Rule? r2 = null;

            Assert.AreEqual(false, r1.Equals(r2));
        }

        [TestMethod]
        public void EqualsReturnsFalseForOtherType()
        {
            Category left1 = new Category("A", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("B", false));
            ReadOnlyCollection<Category> right1 = new ReadOnlyCollection<Category>(l);
            Rule r1 = new Rule(left1, right1);

            string r2 = "asfd";

            Assert.AreEqual(false, r1.Equals(r2));
        }

        [TestMethod]
        public void EqualsReturnsFalseWhenNotEquivalent()
        {
            Category left1 = new Category("A", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("B", false));
            ReadOnlyCollection<Category> right1 = new ReadOnlyCollection<Category>(l);
            Rule r1 = new Rule(left1, right1);

            Category left2 = new Category("A", false);
            l = new List<Category>();
            l.Add(new Category("C", false));
            ReadOnlyCollection<Category> right2 = new ReadOnlyCollection<Category>(l);
            Rule r2 = new Rule(left2, right2);

            Assert.AreEqual(false, r1.Equals(r2));
        }

        [TestMethod]
        public void EqualsReturnsFalseWhenNotEquivalent2()
        {
            Category left1 = new Category("C", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("B", false));
            ReadOnlyCollection<Category> right1 = new ReadOnlyCollection<Category>(l);
            Rule r1 = new Rule(left1, right1);

            Category left2 = new Category("A", false);
            l = new List<Category>();
            l.Add(new Category("B", false));
            ReadOnlyCollection<Category> right2 = new ReadOnlyCollection<Category>(l);
            Rule r2 = new Rule(left2, right2);

            Assert.AreEqual(false, r1.Equals(r2));
        }

        [TestMethod]
        public void EqualsReturnsFalseWhenNotEquivalent3()
        {
            Category left1 = new Category("A", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("B", false));
            l.Add(new Category("C", false));
            ReadOnlyCollection<Category> right1 = new ReadOnlyCollection<Category>(l);
            Rule r1 = new Rule(left1, right1);

            Category left2 = new Category("A", false);
            l = new List<Category>();
            l.Add(new Category("B", false));
            ReadOnlyCollection<Category> right2 = new ReadOnlyCollection<Category>(l);
            Rule r2 = new Rule(left2, right2);

            Assert.AreEqual(false, r1.Equals(r2));
        }

        [TestMethod]
        public void GetHashCode1()
        {
            Category left = new Category("A", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("B", false));
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(l);
            Rule r = new Rule(left, right);

            int result = 17;
            result = 31 * result + left.GetHashCode();
            result = 31 * result + right.GetHashCode();
            Assert.AreEqual(result, r.GetHashCode());
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor1()
        {
            Fixture f = new Fixture();
            List<Category> l = new List<Category>();
            l.Add(f.X);
            l.Add(f.Z);
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(l);
            Category? nullLeft = null;
            Rule r = new Rule(nullLeft, right);
            Assert.Fail("Expected an exception to be thrown.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor2()
        {
            Fixture f = new Fixture();
            ReadOnlyCollection<Category>? right = null;
            Rule r = new Rule(f.Z, right);
            Assert.Fail("Expected an exception to be thrown.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Ctor3()
        {
            Fixture f = new Fixture();
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(new List<Category>());
            Rule r = new Rule(f.Z, right);
            Assert.Fail("Expected an exception to be thrown.");
        }

        [TestMethod]
        public void Ctor4()
        {
            Fixture f = new Fixture();
            List<Category> l = new List<Category>();
            l.Add(f.a);
            l.Add(f.A);
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(l);
            Rule r = new Rule(f.Z, right);
            Assert.AreEqual(f.Z, r.Left);
            Assert.AreEqual(right, r.Right);
        }

        [TestMethod]
        public void IsPreterminal1()
        {
            Fixture f = new Fixture();
            Assert.AreEqual(true, f.rule2.IsPreterminal);
        }

        [TestMethod]
        public void IsPreterminal2()
        {
            Fixture f = new Fixture();
            Assert.AreEqual(false, f.rule3.IsPreterminal);
        }

        [TestMethod]
        public void Left1()
        {
            Fixture f = new Fixture();
            Assert.AreEqual(f.A, f.rule1.Left);
        }

        [TestMethod]
        public void Left2()
        {
            Fixture f = new Fixture();
            Assert.AreNotEqual(f.B, f.rule2.Left);
        }

        [TestMethod]
        public void Right1()
        {
            Fixture f = new Fixture();
            Collection<Category> expected = new Collection<Category>();
            expected.Add(f.Y);
            expected.Add(f.Z);

            Assert.AreEqual(expected.Count, f.rule3.Right.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], f.rule3.Right[i]);
            }
        }
    }
}
