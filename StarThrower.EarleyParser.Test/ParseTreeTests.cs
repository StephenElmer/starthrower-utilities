// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AwesomeAssertions;
using Xunit;
using StarThrower.EarleyParser;

namespace StarThrower.EarleyParser.Test
{
    public class ParseTreeTests
    {
        private static Fixture GetCustomFixture()
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

        [Fact]
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
            startTree.Children.Should().BeNull();
        }

        [Fact]
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
            sChildren.Should().NotBeNull();
            sChildren[0].Node.Should().Be(f.NP);
            sChildren[1].Node.Should().Be(f.VP);
        }


        [Fact]
        public void ParseTrees1()
        {
            Fixture f = GetCustomFixture();

            f.parseTrees.Count.Should().Be(2);
        }

        [Fact]
        public void ParseTrees2()
        {
            Fixture f = GetCustomFixture();

            Collection<ParseTree> vpSubTrees = f.parse.GetParseTreesFor(f.VP, 1, 4);
            vpSubTrees.Count.Should().Be(2);
        }

        [Fact]
        public void ParseTrees3()
        {
            Fixture f = GetCustomFixture();

            Collection<ParseTree> vpSubTrees = f.parse.GetParseTreesFor(f.VP, 1, 4);
            ReadOnlyCollection<Edge>? edgesAt4 = f.parse.Chart.GetEdgesAt(4);
            edgesAt4.Should().NotBeNull();
            foreach (Edge edge in edgesAt4)
            {
                if (edge.Origin == 1 && edge.IsPassive && edge.DottedRule.Left.Equals(f.VP))
                {
                    ParseTree? pt = f.parse.GetParseTreeFor(edge);
                    pt.Should().NotBeNull();
                    vpSubTrees.Contains(pt).Should().Be(true);
                }
            }
        }

        [Fact]
        public void ParseTrees4()
        {
            Fixture f = GetCustomFixture();

            Collection<ParseTree> viSubTrees = f.parse.GetParseTreesFor(f.VI, 3, 4);
            viSubTrees.Count.Should().Be(1);
        }

        [Fact]
        public void ParseTrees5()
        {
            Fixture f = GetCustomFixture();

            Collection<ParseTree> npSubTrees = f.parse.GetParseTreesFor(f.NP, 0, 1);
            npSubTrees.Count.Should().Be(1);
        }

        [Fact]
        public void ParseTrees6()
        {
            Fixture f = GetCustomFixture();

            Collection<ParseTree> npSubTrees2 = f.parse.GetParseTreesFor(f.NP, 2, 4);
            npSubTrees2.Count.Should().Be(1);
        }

        [Fact]
        public void ParseTrees7()
        {
            Fixture f = GetCustomFixture();

            Collection<ParseTree> sSubTrees = f.parse.GetParseTreesFor(f.S, 2, 4);
            sSubTrees.Count.Should().Be(1);
        }

        [Fact]
        public void ParseTrees8()
        {
            Fixture f = GetCustomFixture();

            Collection<ParseTree> sSubTrees = f.parse.GetParseTreesFor(f.S, 2, 4);
            ParseTree sSubTree = sSubTrees[0];
            Collection<ParseTree>? sChildren = sSubTree.Children;
            sChildren.Should().NotBeNull();
            sChildren[0].Node.Should().Be(f.NP);
            ParseTree sVPSubTree = sChildren[1];
            sVPSubTree.Node.Should().Be(f.VP);
            Collection<ParseTree>? vpChildren = sVPSubTree.Children;
            vpChildren.Should().NotBeNull();
            ParseTree viSubTree = vpChildren[0];
            viSubTree.Node.Should().Be(f.VI);
            Collection<ParseTree>? viChildren = viSubTree.Children;
            viChildren.Should().NotBeNull();
            ParseTree duckSubTree = viChildren[0];
            duckSubTree.Node.Should().Be(f.duck);

            // back up
            duckSubTree.Parent.Should().Be(viSubTree);
            viSubTree.Parent.Should().Be(sVPSubTree);
            sVPSubTree.Parent.Should().Be(sSubTree);
            sSubTree.Parent.Should().BeNull();

            // wrong stuff in seed
            f.parse.GetParseTreesFor(f.NP, 0, f.tokens.Length).Count.Should().Be(0);

        }

        [Fact]
        public void GetParent()
        {
            Fixture f = GetCustomFixture();

            foreach (ParseTree pt in f.parseTrees)
            {
                pt.Node.Should().Be(f.S);
            }
        }

        [Fact]
        public void GetChildren1()
        {
            Fixture f = GetCustomFixture();

            foreach (ParseTree pt in f.parseTrees)
            {
                Collection<ParseTree>? i = pt.Children;
                i.Should().NotBeNull();
                i[0].Node.Should().Be(f.NP);
                i[1].Node.Should().Be(f.VP);
            }
        }

        [Fact]
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
            treeChildren.Should().NotBeNull();
            foreach (ParseTree c in treeChildren)
            {
                Collection<ParseTree>? cChildren = c.Children;
                cChildren.Should().NotBeNull();
                foreach (ParseTree x in cChildren)
                {
                    if (x.Node.Equals(f.he))
                    {
                        npCount++;
                    }
                }
            }

            npCount.Should().Be(2);
        }

        [Fact]
        public void Equals1()
        {
            Fixture f = GetCustomFixture();

            ParseTree test = new ParseTree(f.edge1.DottedRule.Left, null);
            foreach (ParseTree pt in f.parseTrees)
            {
                test.Equals(pt).Should().Be(false);
            }
        }

        [Fact]
        public void ToString1()
        {
            Fixture f = GetCustomFixture();

            string s1 = "[S[NP[he]][VP[VT[saw]][NP[Det[her]][N[duck]]]]]";
            string s2 = "[S[NP[he]][VP[VS[saw]][S[NP[her]][VP[VI[duck]]]]]]";

            foreach (ParseTree pt in f.parseTrees)
            {
                (pt.ToString().Equals(s1, StringComparison.Ordinal) || pt.ToString().Equals(s2, StringComparison.Ordinal)).Should().Be(true);
            }
        }
    }
}
