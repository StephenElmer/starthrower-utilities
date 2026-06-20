// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Collections.ObjectModel;
using AwesomeAssertions;
using Xunit;
using StarThrower.EarleyParser;

namespace StarThrower.EarleyParser.Test
{
    public class ParseTests
    {
        /// <summary>
        /// A parse accepts when its chart contains a passive edge for the seed
        /// category, spanning the full token sequence from origin 0. This is the
        /// formal CFG acceptance condition for a recognizer, not an implementation
        /// detail.
        /// </summary>
        [Fact]
        public void StatusAcceptsWhenSeedSpansAllTokens()
        {
            Category s = new Category("S", false);
            Category a = new Category("a", true);
            Grammar g = new Grammar("g");
            g.AddRule(new Rule(s, new ReadOnlyCollection<Category>([a])));

            Parser parser = new Parser(g);
            Parse parse = parser.Parse(["a"], s);

            parse.Status.Should().Be(Status.Accept);
        }

        [Fact]
        public void StatusRejectsWhenStringIsNotInTheLanguage()
        {
            Category s = new Category("S", false);
            Category a = new Category("a", true);
            Grammar g = new Grammar("g");
            g.AddRule(new Rule(s, new ReadOnlyCollection<Category>([a])));

            Parser parser = new Parser(g);
            Parse parse = parser.Parse(["b"], s);

            parse.Status.Should().Be(Status.Reject);
        }

        [Fact]
        public void SeedReturnsConstructorValue()
        {
            Category s = new Category("S", false);
            Parse parse = new Parse(s, new Chart());
            parse.Seed.Should().Be(s);
        }

        [Fact]
        public void ChartReturnsConstructorValue()
        {
            Category s = new Category("S", false);
            Chart chart = new Chart();
            Parse parse = new Parse(s, chart);
            parse.Chart.Should().BeSameAs(chart);
        }

        [Fact]
        public void ToStringIncludesStatusSeedAndTokens()
        {
            Category s = new Category("S", false);
            Category a = new Category("a", true);
            Grammar g = new Grammar("g");
            g.AddRule(new Rule(s, new ReadOnlyCollection<Category>([a])));

            Parser parser = new Parser(g);
            Parse parse = parser.Parse(["a"], s);

            parse.ToString().Should().Be("Accept: S -> a (1)");
        }

        [Fact]
        public void GetParseTreeForThrowsOnNullEdge()
        {
            Category s = new Category("S", false);
            Parse parse = new Parse(s, new Chart());
            Edge? nullEdge = null;
            Action act = () => parse.GetParseTreeFor(nullEdge);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void GetParseTreeForReturnsNullWhenEdgeNotInChart()
        {
            Category s = new Category("S", false);
            Category a = new Category("a", true);
            Rule rule = new Rule(s, new ReadOnlyCollection<Category>([a]));
            Edge edgeNotInAnyChart = new Edge(new DottedRule(rule, 1), 0);

            Parse parse = new Parse(s, new Chart());

            parse.GetParseTreeFor(edgeNotInAnyChart).Should().BeNull();
        }

        /// <summary>
        /// For the unambiguous rule S -> a, the derivation tree for "a" must be a
        /// root node S with exactly one child leaf a. This is a direct consequence of
        /// the grammar (a single production with one right-side category), not
        /// something that depends on chart/edge internals.
        /// </summary>
        [Fact]
        public void GetParseTreeForReturnsTheUniqueDerivationForAnUnambiguousRule()
        {
            Category s = new Category("S", false);
            Category a = new Category("a", true);
            Grammar g = new Grammar("g");
            g.AddRule(new Rule(s, new ReadOnlyCollection<Category>([a])));

            Parser parser = new Parser(g);
            Parse parse = parser.Parse(["a"], s);

            ReadOnlyCollection<Edge>? edgesAt1 = parse.Chart.GetEdgesAt(1);
            edgesAt1.Should().NotBeNull();

            Edge? sEdge = null;
            foreach (Edge e in edgesAt1)
            {
                if (e.Origin == 0 && e.IsPassive && e.DottedRule.Left.Equals(s))
                {
                    sEdge = e;
                }
            }
            sEdge.Should().NotBeNull();

            ParseTree? tree = parse.GetParseTreeFor(sEdge);
            tree.Should().NotBeNull();
            tree.Node.Should().Be(s);
            tree.Children.Should().NotBeNull();
            tree.Children.Should().HaveCount(1);
            tree.Children[0].Node.Should().Be(a);
        }

        [Fact]
        public void GetParseTreesForThrowsOnNullCategory()
        {
            Category s = new Category("S", false);
            Parse parse = new Parse(s, new Chart());
            Category? nullCategory = null;
            Action act = () => parse.GetParseTreesFor(nullCategory, 0, 1);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void GetParseTreesForReturnsEmptyCollectionWhenNoEdgeMatches()
        {
            Category s = new Category("S", false);
            Category np = new Category("NP", false);
            Parse parse = new Parse(s, new Chart());

            parse.GetParseTreesFor(np, 0, 1).Should().BeEmpty();
        }

        /// <summary>
        /// The ParseTrees property lazily computes its result once and caches it
        /// (Parse.cs backs it with a nullable field checked for null before
        /// recomputing). Calling it twice must return the same collection instance.
        /// </summary>
        [Fact]
        public void ParseTreesIsCachedAcrossRepeatedAccess()
        {
            Category s = new Category("S", false);
            Category a = new Category("a", true);
            Grammar g = new Grammar("g");
            g.AddRule(new Rule(s, new ReadOnlyCollection<Category>([a])));

            Parser parser = new Parser(g);
            Parse parse = parser.Parse(["a"], s);

            Collection<ParseTree> first = parse.ParseTrees;
            Collection<ParseTree> second = parse.ParseTrees;

            second.Should().BeSameAs(first);
        }

        [Fact]
        public void EqualsReturnsTrueForEquivalentParses()
        {
            Category s = new Category("S", false);
            Category a = new Category("a", true);
            Grammar g = new Grammar("g");
            g.AddRule(new Rule(s, new ReadOnlyCollection<Category>([a])));

            Parser parser1 = new Parser(g);
            Parser parser2 = new Parser(g);
            Parse parse1 = parser1.Parse(["a"], s);
            Parse parse2 = parser2.Parse(["a"], s);

            parse1.Equals(parse2).Should().BeTrue();
        }

        [Fact]
        public void EqualsReturnsFalseForDifferentTokens()
        {
            Category s = new Category("S", false);
            Category a = new Category("a", true);
            Category b = new Category("b", true);
            Grammar g = new Grammar("g");
            g.AddRule(new Rule(s, new ReadOnlyCollection<Category>([a])));
            g.AddRule(new Rule(s, new ReadOnlyCollection<Category>([b])));

            Parser parser1 = new Parser(g);
            Parser parser2 = new Parser(g);
            Parse parse1 = parser1.Parse(["a"], s);
            Parse parse2 = parser2.Parse(["b"], s);

            parse1.Equals(parse2).Should().BeFalse();
        }

        [Fact]
        public void EqualsReturnsFalseWhenNull()
        {
            Category s = new Category("S", false);
            Parse parse = new Parse(s, new Chart());
            Parse? other = null;
            parse.Equals(other).Should().BeFalse();
        }
    }
}
