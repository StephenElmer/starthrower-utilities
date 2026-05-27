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

        private TestContext testContextInstance;

        #endregion


        #region [ Public Properties ]

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
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
        public void SubChart_1()
        {
            Fixture f = new Fixture();
            Chart subChart = f.chart.GetSubChart(0, 1);
            Assert.AreEqual(true, subChart.ContainsEdge(f.edge1));
        }

        [TestMethod]
        public void SubChart_2()
        {
            Fixture f = new Fixture();
            Chart subChart = f.chart.GetSubChart(0, 1);
            Assert.AreEqual(true, subChart.ContainsEdge(f.edge2));
        }

        [TestMethod]
        public void SubChart_3()
        {
            Fixture f = new Fixture();
            Chart subChart = f.chart.GetSubChart(0, 1);
            Assert.AreEqual(false, subChart.ContainsEdge(f.edge3));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SubChart_4()
        {
            Fixture f = new Fixture();
            Chart subChart = f.chart.GetSubChart(1, 0);
            Assert.Fail("Expected an exception to be thrown here.");
        }

        [TestMethod]
        public void IndexOf_1()
        {
            Fixture f = new Fixture();
            Assert.AreEqual(0, f.chart.GetIndexOfEdge(f.edge1));
        }

        [TestMethod]
        public void IndexOf_2()
        {
            Fixture f = new Fixture();
            Assert.AreEqual(0, f.chart.GetIndexOfEdge(f.edge2));
        }

        [TestMethod]
        public void IndexOf_3()
        {
            Fixture f = new Fixture();
            Assert.AreEqual(1, f.chart.GetIndexOfEdge(f.edge3));
        }

        [TestMethod]
        public void Contains_1()
        {
            Fixture f = new Fixture();
            Assert.AreEqual(true, f.chart.ContainsEdge(f.edge1));
        }

        [TestMethod]
        public void Contains_2()
        {
            Fixture f = new Fixture();
            Assert.AreEqual(true, f.chart.ContainsEdge(f.edge2));
        }

        [TestMethod]
        public void Contains_3()
        {
            Fixture f = new Fixture();
            Assert.AreEqual(true, f.chart.ContainsEdge(f.edge3));
        }

        [TestMethod]
        public void Contains_4()
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
        public void GetIndices_2()
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
            ReadOnlyCollection<Edge> zeroEdges = f.chart.GetEdgesAt(0);
            Assert.AreEqual(true, zeroEdges.Contains(f.edge1));
            Assert.AreEqual(true, zeroEdges.Contains(f.edge2));
        }

        [TestMethod]
        public void Equals_Returns()
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
