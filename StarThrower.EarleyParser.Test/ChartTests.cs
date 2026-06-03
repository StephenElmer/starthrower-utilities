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
    public class ChartTests
    {
        #region [ Construction ]

        public ChartTests()
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
        public void FirstKey()
        {
            Fixture f = new Fixture();
            Assert.AreEqual(0, f.chart.FirstIndex);
        }

        [TestMethod]
        public void LastKey()
        {
            Fixture f = new Fixture();
            Assert.AreEqual(1, f.chart.LastIndex);
        }

        [TestMethod]
        public void SubChart1()
        {
            Fixture f = new Fixture();
            Chart subChart = f.chart.GetSubChart(0, 1);
            Assert.AreEqual(true, subChart.ContainsEdge(f.edge1));
        }

        [TestMethod]
        public void SubChart2()
        {
            Fixture f = new Fixture();
            Chart subChart = f.chart.GetSubChart(0, 1);
            Assert.AreEqual(true, subChart.ContainsEdge(f.edge2));
        }

        [TestMethod]
        public void SubChart3()
        {
            Fixture f = new Fixture();
            Chart subChart = f.chart.GetSubChart(0, 1);
            Assert.AreEqual(false, subChart.ContainsEdge(f.edge3));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SubChart4()
        {
            Fixture f = new Fixture();
            Chart subChart = f.chart.GetSubChart(1, 0);
            Assert.Fail("Expected an exception to be thrown here.");
        }

        [TestMethod]
        public void IndexOf1()
        {
            Fixture f = new Fixture();
            Assert.AreEqual(0, f.chart.GetIndexOfEdge(f.edge1));
        }

        [TestMethod]
        public void IndexOf2()
        {
            Fixture f = new Fixture();
            Assert.AreEqual(0, f.chart.GetIndexOfEdge(f.edge2));
        }

        [TestMethod]
        public void IndexOf3()
        {
            Fixture f = new Fixture();
            Assert.AreEqual(1, f.chart.GetIndexOfEdge(f.edge3));
        }

        [TestMethod]
        public void Contains1()
        {
            Fixture f = new Fixture();
            Assert.AreEqual(true, f.chart.ContainsEdge(f.edge1));
        }

        [TestMethod]
        public void Contains2()
        {
            Fixture f = new Fixture();
            Assert.AreEqual(true, f.chart.ContainsEdge(f.edge2));
        }

        [TestMethod]
        public void Contains3()
        {
            Fixture f = new Fixture();
            Assert.AreEqual(true, f.chart.ContainsEdge(f.edge3));
        }

        [TestMethod]
        public void Contains4()
        {
            Fixture f = new Fixture();
            Assert.AreEqual(false, f.chart.ContainsEdge(new Edge(new DottedRule(f.rule3), 4)));
        }

        [TestMethod]
        public void GetIndices()
        {
            Fixture f = new Fixture();
            SortedDictionary<int, Collection<Edge>>.KeyCollection indices = f.chart.Indexes;
            Assert.AreEqual(true, indices.Contains(0));
            Assert.AreEqual(true, indices.Contains(1));
        }

        [TestMethod]
        public void GetIndices2()
        {
            Fixture f = new Fixture();
            SortedDictionary<int, Collection<Edge>>.KeyCollection indices = f.chart.Indexes;

            SortedSet<int> expected = new SortedSet<int>();
            foreach (int i in indices)
            {
                expected.Add(i);
            }
            Assert.AreEqual(expected.Count, indices.Count);

            int cur = -1;
            int last = -1;
            foreach (int i in indices)
            {
                last = cur;
                cur = i;
                if (last != -1)
                {
                    Assert.AreEqual(true, cur > last);
                }
            }
        }

        [TestMethod]
        public void ContainsEdge()
        {
            Fixture f = new Fixture();
            Assert.AreEqual(true, f.chart.ContainsEdgesAt(0));
            Assert.AreEqual(true, f.chart.ContainsEdgesAt(1));
            Assert.AreEqual(false, f.chart.ContainsEdgesAt(2));
        }

        [TestMethod]
        public void AddEdge()
        {
            Fixture f = new Fixture();
            Assert.AreEqual(false, f.chart.AddEdge(0, f.edge1));
        }

        [TestMethod]
        public void GetEdge()
        {
            Fixture f = new Fixture();
            ReadOnlyCollection<Edge>? zeroEdges = f.chart.GetEdgesAt(0);
            Assert.IsNotNull(zeroEdges);
            Assert.AreEqual(true, zeroEdges.Contains(f.edge1));
            Assert.AreEqual(true, zeroEdges.Contains(f.edge2));
        }

        [TestMethod]
        public void EqualsReturns()
        {
            Fixture f = new Fixture();
            Chart c = new Chart();
            c.AddEdge(0, f.edge1);
            c.AddEdge(0, f.edge2);
            c.AddEdge(1, f.edge3);

            Assert.AreEqual(c, f.chart);
        }
    }
}
