// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarThrower.EarleyParser;

namespace StarThrower.EarleyParser.Test
{
    [TestClass]
    public class DottedRuleTests
    {
        #region [ Construction ]

        public DottedRuleTests()
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


        #region Additional test attributes
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
        public void AdvanceDot()
        {
            Fixture f = new Fixture();
            Rule advanced = new DottedRule(f.rule3, 1);
            Assert.AreEqual(advanced, DottedRule.AdvanceDot(f.edge2.DottedRule));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AdvanceDotFail()
        {
            Fixture f = new Fixture();
            DottedRule.AdvanceDot(f.edge3.DottedRule);
            Assert.Fail("Should have thrown an exception here.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateStartRuleThrowsOnNull()
        {
            Category? nullSeed = null;
            DottedRule.CreateStartRule(nullSeed);
            Assert.Fail("Should have thrown an exception here.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreateStartRuleThrowsOnTerminalSeed()
        {
            Fixture f = new Fixture();
            DottedRule.CreateStartRule(f.a);
            Assert.Fail("Should have thrown an exception here.");
        }

        [TestMethod]
        public void CreateStartRule()
        {
            Fixture f = new Fixture();
            DottedRule sr = DottedRule.CreateStartRule(f.A);
            Assert.AreSame(Category.Root, sr.Left);
            Assert.AreEqual(Category.Root, sr.Left);
            Assert.AreNotSame(Category.Root, new Category(Category.Root.Name));
            Assert.AreEqual(0, sr.Position);
            Assert.AreEqual(f.A, sr.ActiveCategory);
            Assert.AreEqual(sr, DottedRule.CreateStartRule(f.A));
        }

        [TestMethod]
        public void GetPosition()
        {
            Fixture f = new Fixture();
            Assert.AreEqual(2, f.dot1.Position);
        }

        [TestMethod]
        public void ActiveCategory()
        {
            Fixture f = new Fixture();
            Assert.AreEqual(f.D, f.dot1.ActiveCategory);
            Assert.AreEqual(null, f.dot2.ActiveCategory);
            Assert.AreNotEqual(f.D, f.dot3.ActiveCategory);
        }

        [TestMethod]
        public void GetHashCodeReturnsCorrect()
        {
            Fixture f = new Fixture();

            int bh = 17;
            bh = 31 * bh + f.dot1.Left.GetHashCode();
            bh = 31 * bh + f.dot1.Right.GetHashCode();

            int result = 17;
            result = 31 * result + f.dot1.Position.GetHashCode();
            result = 31 * result + bh;

            Assert.AreEqual(result, f.dot1.GetHashCode());
        }

        [TestMethod]
        public void EqualsReturnsTrue()
        {
            Fixture f = new Fixture();
            DottedRule dr = new DottedRule(f.rule1, 2);
            Assert.AreEqual(true, f.dot1.Equals(dr));
        }

        [TestMethod]
        public void EqualsReturnsFalse()
        {
            Fixture f = new Fixture();
            DottedRule dr = new DottedRule(f.rule1, 2);
            Assert.AreEqual(false, f.dot2.Equals(dr));
        }

        [TestMethod]
        public void ToStringReturnsCorrectly()
        {
            Fixture f = new Fixture();
            Assert.AreEqual("A -> B C * D E", f.dot1.ToString());
            Assert.AreEqual("A -> a *", f.dot2.ToString());
            Assert.AreEqual("X -> * Y Z", f.dot3.ToString());
        }
    }
}
