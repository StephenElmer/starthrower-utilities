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
    public class EdgeTests
    {
        #region [ Construction ]

        public EdgeTests()
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
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Ctor1()
        {
            Fixture f = new Fixture();
            Edge e = new Edge(new DottedRule(f.edge1.DottedRule, 0), -1);
            Assert.Fail("Expected an exception to be thrown");
        }

        [TestMethod]
        public void GetOrigin()
        {
            Fixture f = new Fixture();
            Assert.AreEqual(3, f.edge1.Origin);
        }

        [TestMethod]
        public void GetDottedRule()
        {
            Fixture f = new Fixture();
            Assert.AreEqual(new DottedRule(f.rule1, 2), f.edge1.DottedRule);
        }

        [TestMethod]
        public void Predict1()
        {
            Fixture f = new Fixture();
            Edge pe = Edge.PredictFor(f.rule1, 1);
            Assert.AreEqual(f.A, pe.DottedRule.Left);
        }

        [TestMethod]
        public void Predict2()
        {
            Fixture f = new Fixture();
            Edge pe = Edge.PredictFor(f.rule1, 1);
            Assert.AreEqual(f.B, pe.DottedRule.ActiveCategory);
        }

        [TestMethod]
        public void Predict3()
        {
            Fixture f = new Fixture();
            Edge pe = Edge.PredictFor(f.rule1, 1);
            Assert.AreEqual(false, pe.IsPassive);
        }

        [TestMethod]
        public void Predict4()
        {
            Fixture f = new Fixture();
            Edge pe = Edge.PredictFor(f.rule1, 1);
            Assert.AreEqual(1, pe.Origin);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Predict5()
        {
            Rule? nullRule = null;
            Edge pe = Edge.PredictFor(nullRule, 0);
            Assert.Fail("Expected an exception to be thrown.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Predict6()
        {
            Fixture f = new Fixture();
            Edge pe = Edge.PredictFor(f.rule2, -1);
            Assert.Fail("Expected an exception to be thrown.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Complete1()
        {
            Fixture f = new Fixture();
            Edge? nullEdge = null;
            Edge e = Edge.Complete(f.edge2, nullEdge);
            Assert.Fail("Expected an exception to be thrown.");
        }

        [TestMethod]
        public void Complete2()
        {
            Fixture f = new Fixture();
            List<Category> l = new List<Category>();
            l.Add(f.Z);
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(l);
            Rule r = new Rule(f.D, right);
            DottedRule dr = new DottedRule(r, 1);
            Edge completer = new Edge(dr, f.edge1.Origin);

            Assert.AreEqual(dr, completer.DottedRule);
            Assert.AreEqual(f.edge1.Origin, completer.Origin);
        }

        [TestMethod]
        public void Complete3()
        {
            Fixture f = new Fixture();
            List<Category> l = new List<Category>();
            l.Add(f.Z);
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(l);
            Rule r = new Rule(f.D, right);
            DottedRule dr = new DottedRule(r, 1);
            Edge completer = new Edge(dr, f.edge1.Origin);

            Edge e = Edge.Complete(f.edge1, completer);

            Assert.AreEqual(1, e.Bases.Count);
            Assert.AreEqual(f.E, e.DottedRule.ActiveCategory);
            Assert.AreEqual(3, e.DottedRule.Position);
            Assert.AreEqual(false, e.IsPassive);
            Assert.AreEqual(3, e.Origin);
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Complete4()
        {
            Fixture f = new Fixture();
            List<Category> l = new List<Category>();
            l.Add(f.Z);
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(l);
            Rule r = new Rule(f.D, right);
            DottedRule dr = new DottedRule(r, 1);
            Edge completer = new Edge(dr, f.edge1.Origin);

            Edge e = Edge.Complete(f.edge2, completer);
            Assert.Fail("Expected an exception to be thrown.");
        }

        [TestMethod]
        public void GetBases()
        {
            Fixture f = new Fixture();

            List<Category> l = new List<Category>();
            l.Add(f.A);
            ReadOnlyCollection<Category> cat1 = new ReadOnlyCollection<Category>(l);
            Edge edge2Completer = new Edge(new DottedRule(new Rule(f.Y, cat1), 1), f.edge2.Origin);

            l = new List<Category>();
            l.Add(f.B);
            ReadOnlyCollection<Category> cat2 = new ReadOnlyCollection<Category>(l);
            Edge ce1Completer = new Edge(new DottedRule(new Rule(f.Z, cat2), 1), f.edge2.Origin);

            Edge ce1 = Edge.Complete(f.edge2, edge2Completer);

            Edge ce2 = Edge.Complete(ce1, ce1Completer);

            List<Edge> el = new List<Edge>(ce1.Bases);
            el.Add(ce1Completer);
            ReadOnlyCollection<Edge> bases = new ReadOnlyCollection<Edge>(el);

            Assert.AreEqual(bases.Count, ce2.Bases.Count);
            for (int i = 0; i < bases.Count; i++)
            {
                Assert.AreEqual(bases[i], ce2.Bases[i]);
            }
        }

        [TestMethod]
        public void GetIsPassive()
        {
            Fixture f = new Fixture();
            Assert.AreEqual(false, f.edge1.IsPassive);
            Assert.AreEqual(false, f.edge2.IsPassive);
            Assert.AreEqual(true, f.edge3.IsPassive);
        }

        [TestMethod]
        public void ToStringReturnsCorrectly()
        {
            Fixture f = new Fixture();
            Assert.AreEqual("3[A -> B C * D E]", f.edge1.ToString());
            Assert.AreEqual("0[X -> * Y Z]", f.edge2.ToString());
            Assert.AreEqual("2[A -> a *]", f.edge3.ToString());
        }

        [TestMethod]
        public void EqualsReturnsCorrectly()
        {
            Fixture f = new Fixture();
            Edge e = new Edge(f.edge1.DottedRule, f.edge1.Origin);
            Assert.AreEqual(e, f.edge1);
            Assert.AreEqual(f.edge2, f.edge2);
            Assert.AreNotSame(f.edge2, f.edge3);
            Assert.AreEqual(false, f.edge2.Equals(f.edge3));
        }

        [TestMethod]
        public void EqualsReturnsCorrectly2()
        {
            Fixture f = new Fixture();
            List<Edge> l = new List<Edge>();
            l.Add(f.edge1);
            Edge e = new Edge(f.edge1.DottedRule, f.edge1.Origin, new ReadOnlyCollection<Edge>(l));

            l = new List<Edge>();
            l.Add(f.edge1);
            Edge e2 = new Edge(f.edge1.DottedRule, f.edge1.Origin, new ReadOnlyCollection<Edge>(l));
            Assert.AreEqual(e, e2);
        }

        [TestMethod]
        public void GetHashCodeReturnsCorrectly()
        {
            Fixture f = new Fixture();

            int result = 17;
            result = 31 * result + f.edge1.Origin.GetHashCode();
            result = 31 * result + f.edge1.DottedRule.GetHashCode();
            result = 31 * result + f.edge1.Bases.GetHashCode();

            Assert.AreEqual(result, f.edge1.GetHashCode());
            Assert.AreNotEqual(f.edge2.GetHashCode(), f.edge3.GetHashCode());
        }

    }
}
