// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System.Collections.ObjectModel;
using AwesomeAssertions;
using Xunit;
using StarThrower.EarleyParser;

namespace StarThrower.EarleyParser.Test
{
    /// <summary>
    /// Tests derived from context-free grammar and Earley-parsing theory rather than
    /// from the production implementation. Each test exercises a property that any
    /// correct Earley parser must have, using grammars and expected outcomes that can
    /// be reasoned about independently of how the parser is implemented internally.
    /// </summary>
    public class EarleyAlgorithmTests
    {
        /// <summary>
        /// Earley parsers, unlike naive recursive-descent parsers, must handle direct
        /// left recursion (X -> X a) without infinite regress. "a a a a" is licensed
        /// by repeatedly applying X -> X a, bottoming out at X -> a.
        /// </summary>
        [Fact]
        public void DirectLeftRecursionAccepts()
        {
            Category x = new Category("X", false);
            Category a = new Category("a", true);

            Grammar g = new Grammar("left-recursive");
            g.AddRule(new Rule(x, new ReadOnlyCollection<Category>([x, a])));
            g.AddRule(new Rule(x, new ReadOnlyCollection<Category>([a])));

            Parser parser = new Parser(g);
            Parse parse = parser.Parse(["a", "a", "a", "a"], x);

            parse.Status.Should().Be(Status.Accept);
        }

        /// <summary>
        /// Symmetric to direct left recursion: a directly right-recursive rule
        /// (Y -> a Y) must also be accepted, confirming the parser isn't relying on
        /// some left-recursion-specific special case to produce correct results.
        /// </summary>
        [Fact]
        public void DirectRightRecursionAccepts()
        {
            Category y = new Category("Y", false);
            Category a = new Category("a", true);

            Grammar g = new Grammar("right-recursive");
            g.AddRule(new Rule(y, new ReadOnlyCollection<Category>([a, y])));
            g.AddRule(new Rule(y, new ReadOnlyCollection<Category>([a])));

            Parser parser = new Parser(g);
            Parse parse = parser.Parse(["a", "a", "a", "a"], y);

            parse.Status.Should().Be(Status.Accept);
        }

        /// <summary>
        /// The classic fully-ambiguous grammar S -> S S | a. The number of distinct
        /// binary parse trees over n leaves is the Catalan number C(n-1), a fact about
        /// the grammar itself rather than about any particular parser implementation.
        /// For 3 leaves, C(2) = 2 distinct parses.
        /// </summary>
        [Fact]
        public void StructuralAmbiguityWithThreeLeavesHasTwoParses()
        {
            Category s = new Category("S", false);
            Category a = new Category("a", true);

            Grammar g = new Grammar("fully-ambiguous");
            g.AddRule(new Rule(s, new ReadOnlyCollection<Category>([s, s])));
            g.AddRule(new Rule(s, new ReadOnlyCollection<Category>([a])));

            Parser parser = new Parser(g);
            Parse parse = parser.Parse(["a", "a", "a"], s);

            parse.Status.Should().Be(Status.Accept);
            parse.ParseTrees.Count.Should().Be(2);
        }

        /// <summary>
        /// Same grammar as above, with 4 leaves. C(3) = 5 distinct parses. Checking a
        /// second leaf count guards against a parse-tree-counting bug that happens to
        /// produce the right answer only for the smallest case.
        /// </summary>
        [Fact]
        public void StructuralAmbiguityWithFourLeavesHasFiveParses()
        {
            Category s = new Category("S", false);
            Category a = new Category("a", true);

            Grammar g = new Grammar("fully-ambiguous");
            g.AddRule(new Rule(s, new ReadOnlyCollection<Category>([s, s])));
            g.AddRule(new Rule(s, new ReadOnlyCollection<Category>([a])));

            Parser parser = new Parser(g);
            Parse parse = parser.Parse(["a", "a", "a", "a"], s);

            parse.Status.Should().Be(Status.Accept);
            parse.ParseTrees.Count.Should().Be(5);
        }

        /// <summary>
        /// Lexical ambiguity: a single token belongs to two different preterminal
        /// categories that are both reachable from the seed. A correct parser must
        /// produce one parse tree per licensing category, not collapse or duplicate
        /// them.
        /// </summary>
        [Fact]
        public void LexicalAmbiguityProducesOneParsePerCategory()
        {
            Category s = new Category("S", false);
            Category noun = new Category("Noun", false);
            Category verb = new Category("Verb", false);
            Category duck = new Category("duck", true);

            Grammar g = new Grammar("lexical-ambiguity");
            g.AddRule(new Rule(s, new ReadOnlyCollection<Category>([noun])));
            g.AddRule(new Rule(s, new ReadOnlyCollection<Category>([verb])));
            g.AddRule(new Rule(noun, new ReadOnlyCollection<Category>([duck])));
            g.AddRule(new Rule(verb, new ReadOnlyCollection<Category>([duck])));

            Parser parser = new Parser(g);
            Parse parse = parser.Parse(["duck"], s);

            parse.Status.Should().Be(Status.Accept);
            parse.ParseTrees.Count.Should().Be(2);
        }

        /// <summary>
        /// Terminal matching is case-sensitive by default (ParserOptions.IgnoreCase
        /// defaults to false), so a token differing only in case from the grammar's
        /// terminal must be rejected.
        /// </summary>
        [Fact]
        public void CaseSensitiveByDefaultRejectsMismatchedCase()
        {
            Category s = new Category("S", false);
            Category hello = new Category("Hello", true);

            Grammar g = new Grammar("case-sensitive");
            g.AddRule(new Rule(s, new ReadOnlyCollection<Category>([hello])));

            Parser parser = new Parser(g);
            Parse parse = parser.Parse(["hello"], s);

            parse.Status.Should().Be(Status.Reject);
        }

        /// <summary>
        /// With ParserOptions.IgnoreCase set, the same mismatched-case token must be
        /// accepted, confirming the option actually changes matching behavior rather
        /// than being inert.
        /// </summary>
        [Fact]
        public void IgnoreCaseOptionAcceptsMismatchedCase()
        {
            Category s = new Category("S", false);
            Category hello = new Category("Hello", true);

            Grammar g = new Grammar("case-insensitive");
            g.AddRule(new Rule(s, new ReadOnlyCollection<Category>([hello])));

            Parser parser = new Parser(g, new ParserOptions(true, true));
            Parse parse = parser.Parse(["hello"], s);

            parse.Status.Should().Be(Status.Accept);
        }

        /// <summary>
        /// KNOWN FAILING TEST - documents a real gap, not a regression guard.
        ///
        /// Rule.cs's documentation states that empty (epsilon) productions are
        /// supported by giving a rule a right side consisting of a single terminal
        /// category with an empty name. By CFG theory, a nullable category B in
        /// A -> B C should let A match the same span as C alone. But tracing the
        /// algorithm: a predicted edge for "B -> <empty>" is active (its dot has not
        /// reached the end of a 1-length right side) and is never advanced by Scan,
        /// because Scan only matches edges against real, non-empty input tokens.
        /// There is no completer step for nullable categories, so B can never
        /// legitimately become passive without consuming a token that doesn't exist.
        ///
        /// This test asserts the theoretically-correct result (Accept) and is
        /// expected to fail against the current implementation. Left failing
        /// intentionally per direction from the developer, to be addressed after the
        /// rest of this test pass is complete.
        /// </summary>
        [Fact]
        public void EpsilonProductionAllowsNullableCategoryToBeSkipped()
        {
            Category a = new Category("A", false);
            Category b = new Category("B", false);
            Category c = new Category("C", false);
            Category empty = new Category(string.Empty, true);
            Category x = new Category("x", true);
            Category yCat = new Category("y", true);

            Grammar g = new Grammar("epsilon");
            g.AddRule(new Rule(a, new ReadOnlyCollection<Category>([b, c])));
            g.AddRule(new Rule(b, new ReadOnlyCollection<Category>([empty])));
            g.AddRule(new Rule(b, new ReadOnlyCollection<Category>([x])));
            g.AddRule(new Rule(c, new ReadOnlyCollection<Category>([yCat])));

            Parser parser = new Parser(g);
            Parse parse = parser.Parse(["y"], a);

            parse.Status.Should().Be(Status.Accept);
        }
    }
}
