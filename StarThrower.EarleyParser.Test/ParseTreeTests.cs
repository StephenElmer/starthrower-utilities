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
    public class ParseTreeTests
    {
        #region [ Construction ]

        public ParseTreeTests()
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

        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
        }

        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion


        private Fixture GetCustomFixture()
        {
            Fixture f = new Fixture();

            f.grammar = new Grammar("test");

            List<Category> l = new List<Category>();
            l.Add(f.NP);
            l.Add(f.VP);
            ReadOnlyCollection<Category> right1 = new ReadOnlyCollection<Category>(l);
            f.grammar.AddRule(new Rule(f.S, right1));

            l = new List<Category>();
            l.Add(f.he);
            ReadOnlyCollection<Category> right2 = new ReadOnlyCollection<Category>(l);
            f.grammar.AddRule(new Rule(f.NP, right2));

            l = new List<Category>();
            l.Add(f.her);
            ReadOnlyCollection<Category> right3 = new ReadOnlyCollection<Category>(l);
            f.grammar.AddRule(new Rule(f.NP, right3));

            l = new List<Category>();
            l.Add(f.Det);
            l.Add(f.N);
            ReadOnlyCollection<Category> right4 = new ReadOnlyCollection<Category>(l);
            f.grammar.AddRule(new Rule(f.NP, right4));

            l = new List<Category>();
            l.Add(f.saw);
            ReadOnlyCollection<Category> right5 = new ReadOnlyCollection<Category>(l);
            f.grammar.AddRule(new Rule(f.VT, right5));

            l = new List<Category>();
            l.Add(f.saw);
            ReadOnlyCollection<Category> right6 = new ReadOnlyCollection<Category>(l);
            f.grammar.AddRule(new Rule(f.VS, right6));

            l = new List<Category>();
            l.Add(f.duck);
            ReadOnlyCollection<Category> right7 = new ReadOnlyCollection<Category>(l);
            f.grammar.AddRule(new Rule(f.VI, right7));

            l = new List<Category>();
            l.Add(f.duck);
            ReadOnlyCollection<Category> right8 = new ReadOnlyCollection<Category>(l);
            f.grammar.AddRule(new Rule(f.N, right8));

            l = new List<Category>();
            l.Add(f.her);
            ReadOnlyCollection<Category> right9 = new ReadOnlyCollection<Category>(l);
            f.grammar.AddRule(new Rule(f.Det, right9));

            l = new List<Category>();
            l.Add(f.VT);
            l.Add(f.NP);
            ReadOnlyCollection<Category> right10 = new ReadOnlyCollection<Category>(l);
            f.grammar.AddRule(new Rule(f.VP, right10));

            l = new List<Category>();
            l.Add(f.VS);
            l.Add(f.S);
            ReadOnlyCollection<Category> right11 = new ReadOnlyCollection<Category>(l);
            f.grammar.AddRule(new Rule(f.VP, right11));

            l = new List<Category>();
            l.Add(f.VI);
            ReadOnlyCollection<Category> right12 = new ReadOnlyCollection<Category>(l);
            f.grammar.AddRule(new Rule(f.VP, right12));

            f.tokens = new string[4];
            f.tokens[0] = f.he.Name;
            f.tokens[1] = f.saw.Name;
            f.tokens[2] = f.her.Name;
            f.tokens[3] = f.duck.Name;

            Parser parser = new Parser(f.grammar);
            f.parse = parser.Parse(f.tokens, f.S);
            f.parseTrees = f.parse.ParseTrees;

            return f;
        }

        [TestMethod]
        public void NewParseTree1()
        {
            Fixture f = new Fixture();
            Edge startEdge = new Edge(DottedRule.CreateStartRule(f.S), 0);
            List<Category> l = new List<Category>();
            l.Add(f.NP);
            l.Add(f.VP);
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(l);
            startEdge = Edge.Complete(startEdge, new Edge(new DottedRule(new Rule(f.S, right), 2), 0));

            ParseTree startTree = ParseTree.NewParseTree(startEdge);
            Assert.IsNull(startTree.Children);
        }

        [TestMethod]
        public void NewParseTree2()
        {
            Fixture f = new Fixture();

            List<Category> l = new List<Category>();
            l.Add(f.NP);
            l.Add(f.VP);
            ReadOnlyCollection<Category> right1 = new ReadOnlyCollection<Category>(l);
            Edge sEdge = new Edge(new DottedRule(new Rule(f.S, right1)), 0);

            l = new List<Category>();
            l.Add(f.Det);
            l.Add(f.N);
            ReadOnlyCollection<Category> right2 = new ReadOnlyCollection<Category>(l);
            sEdge = Edge.Complete(sEdge, new Edge(new DottedRule(new Rule(f.NP, right2), 2), 0));

            l = new List<Category>();
            l.Add(f.VT);
            l.Add(f.NP);
            ReadOnlyCollection<Category> right3 = new ReadOnlyCollection<Category>(l);
            sEdge = Edge.Complete(sEdge, new Edge(new DottedRule(new Rule(f.VP, right3), 2), 3));

            ParseTree sTree = ParseTree.NewParseTree(sEdge, null);
            Collection<ParseTree>? sChildren = sTree.Children;
            Assert.IsNotNull(sChildren);
            Assert.AreEqual(f.NP, sChildren[0].Node);
            Assert.AreEqual(f.VP, sChildren[1].Node);
        }


        [TestMethod]
        public void ParseTrees1()
        {
            Fixture f = GetCustomFixture();

            Assert.AreEqual(2, f.parseTrees.Count);
        }

        [TestMethod]
        public void ParseTrees2()
        {
            Fixture f = GetCustomFixture();

            Collection<ParseTree> vpSubTrees = f.parse.GetParseTreesFor(f.VP, 1, 4);
            Assert.AreEqual(2, vpSubTrees.Count);
        }

        [TestMethod]
        public void ParseTrees3()
        {
            Fixture f = GetCustomFixture();

            Collection<ParseTree> vpSubTrees = f.parse.GetParseTreesFor(f.VP, 1, 4);
            ReadOnlyCollection<Edge>? edgesAt4 = f.parse.Chart.GetEdgesAt(4);
            Assert.IsNotNull(edgesAt4);
            foreach (Edge edge in edgesAt4)
            {
                if (edge.Origin == 1 && edge.IsPassive && edge.DottedRule.Left.Equals(f.VP))
                {
                    ParseTree? pt = f.parse.GetParseTreeFor(edge);
                    Assert.IsNotNull(pt);
                    Assert.AreEqual(true, vpSubTrees.Contains(pt));
                }
            }
        }

        [TestMethod]
        public void ParseTrees4()
        {
            Fixture f = GetCustomFixture();

            Collection<ParseTree> viSubTrees = f.parse.GetParseTreesFor(f.VI, 3, 4);
            Assert.AreEqual(1, viSubTrees.Count);
        }

        [TestMethod]
        public void ParseTrees5()
        {
            Fixture f = GetCustomFixture();

            Collection<ParseTree> npSubTrees = f.parse.GetParseTreesFor(f.NP, 0, 1);
            Assert.AreEqual(1, npSubTrees.Count);
        }

        [TestMethod]
        public void ParseTrees6()
        {
            Fixture f = GetCustomFixture();

            Collection<ParseTree> npSubTrees2 = f.parse.GetParseTreesFor(f.NP, 2, 4);
            Assert.AreEqual(1, npSubTrees2.Count);
        }

        [TestMethod]
        public void ParseTrees7()
        {
            Fixture f = GetCustomFixture();

            Collection<ParseTree> sSubTrees = f.parse.GetParseTreesFor(f.S, 2, 4);
            Assert.AreEqual(1, sSubTrees.Count);
        }

        [TestMethod]
        public void ParseTrees8()
        {
            Fixture f = GetCustomFixture();

            Collection<ParseTree> sSubTrees = f.parse.GetParseTreesFor(f.S, 2, 4);
            ParseTree sSubTree = sSubTrees[0];
            Collection<ParseTree>? sChildren = sSubTree.Children;
            Assert.IsNotNull(sChildren);
            Assert.AreEqual(f.NP, sChildren[0].Node);
            ParseTree sVPSubTree = sChildren[1];
            Assert.AreEqual(f.VP, sVPSubTree.Node);
            Collection<ParseTree>? vpChildren = sVPSubTree.Children;
            Assert.IsNotNull(vpChildren);
            ParseTree viSubTree = vpChildren[0];
            Assert.AreEqual(f.VI, viSubTree.Node);
            Collection<ParseTree>? viChildren = viSubTree.Children;
            Assert.IsNotNull(viChildren);
            ParseTree duckSubTree = viChildren[0];
            Assert.AreEqual(f.duck, duckSubTree.Node);

            // back up
            Assert.AreEqual(viSubTree, duckSubTree.Parent);
            Assert.AreEqual(sVPSubTree, viSubTree.Parent);
            Assert.AreEqual(sSubTree, sVPSubTree.Parent);
            Assert.AreEqual(true, sSubTree.Parent == null);

            // wrong stuff in seed
            Assert.AreEqual(0, f.parse.GetParseTreesFor(f.NP, 0, f.tokens.Length).Count);

        }

        [TestMethod]
        public void GetParent()
        {
            Fixture f = GetCustomFixture();

            foreach (ParseTree pt in f.parseTrees)
            {
                Assert.AreEqual(f.S, pt.Node);
            }
        }

        [TestMethod]
        public void GetChildren1()
        {
            Fixture f = GetCustomFixture();

            foreach (ParseTree pt in f.parseTrees)
            {
                Collection<ParseTree>? i = pt.Children;
                Assert.IsNotNull(i);
                Assert.AreEqual(f.NP, i[0].Node);
                Assert.AreEqual(f.VP, i[1].Node);
            }
        }

        [TestMethod]
        public void GetChildren2()
        {
            Fixture f = GetCustomFixture();

            Grammar g = new Grammar("g");
            List<Category> l = new List<Category>();
            l.Add(f.NP);
            l.Add(f.NP);
            ReadOnlyCollection<Category> right1 = new ReadOnlyCollection<Category>(l);
            g.AddRule(new Rule(f.S, right1));
            l = new List<Category>();
            l.Add(f.he);
            ReadOnlyCollection<Category> right2 = new ReadOnlyCollection<Category>(l);
            g.AddRule(new Rule(f.NP, right2));

            string[] t = new string[2];
            t[0] = "he";
            t[1] = "he";

            Parser p = new Parser(g);
            Parse prse = p.Parse(t, f.S);
            ParseTree tree = prse.ParseTrees[0];
            int npCount = 0;
            Collection<ParseTree>? treeChildren = tree.Children;
            Assert.IsNotNull(treeChildren);
            foreach (ParseTree c in treeChildren)
            {
                Collection<ParseTree>? cChildren = c.Children;
                Assert.IsNotNull(cChildren);
                foreach (ParseTree x in cChildren)
                {
                    if (x.Node.Equals(f.he))
                    {
                        npCount++;
                    }
                }
            }

            Assert.AreEqual(2, npCount);
        }

        [TestMethod]
        public void Equals1()
        {
            Fixture f = GetCustomFixture();

            ParseTree test = new ParseTree(f.edge1.DottedRule.Left, null);
            foreach (ParseTree pt in f.parseTrees)
            {
                Assert.AreEqual(false, test.Equals(pt));
            }
        }

        [TestMethod]
        public void ToString1()
        {
            Fixture f = GetCustomFixture();

            string s1 = "[S[NP[he]][VP[VT[saw]][NP[Det[her]][N[duck]]]]]";
            string s2 = "[S[NP[he]][VP[VS[saw]][S[NP[her]][VP[VI[duck]]]]]]";

            foreach (ParseTree pt in f.parseTrees)
            {
                Assert.AreEqual(true, pt.ToString().Equals(s1, StringComparison.Ordinal) || pt.ToString().Equals(s2, StringComparison.Ordinal));
            }
        }
    }
}
