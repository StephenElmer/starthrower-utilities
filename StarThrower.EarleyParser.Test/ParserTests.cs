// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Collections.ObjectModel;
using AwesomeAssertions;
using Xunit;
using StarThrower.EarleyParser;

namespace StarThrower.EarleyParser.Test
{
    public class ParserTests
    {
        [Fact]
        public void GetGrammar()
        {
            Fixture f = new Fixture();

            f.earleyParser.Grammar.Should().Be(f.grammar);
        }

        [Fact]
        public void SetGrammar()
        {
            Fixture f = new Fixture();

            f.earleyParser.Grammar.Should().Be(f.grammar);

            f.earleyParser.Grammar = f.emptyGrammar;

            f.earleyParser.Grammar.Should().Be(f.emptyGrammar);
        }

        [Fact]
        public void Recognize()
        {
            Fixture f = new Fixture();
            f.earleyParser = new Parser(f.grammar);

            f.earleyParser.Recognize(f.tokens, f.seed).Should().Be(Status.Accept);
        }

        [Fact]
        public void RecognizeReturnsRejectForUnrecognizedString()
        {
            Fixture f = new Fixture();
            f.earleyParser = new Parser(f.grammar);

            string[] notInLanguage = ["the", "left", "boy"];
            f.earleyParser.Recognize(notInLanguage, f.seed).Should().Be(Status.Reject);
        }

        [Fact]
        public void ParseThrowsOnNullTokens()
        {
            Fixture f = new Fixture();
            string[]? nullTokens = null;
            Action act = () => f.earleyParser.Parse(nullTokens, f.seed);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ParseThrowsOnNullSeed()
        {
            Fixture f = new Fixture();
            Category? nullSeed = null;
            Action act = () => f.earleyParser.Parse(f.tokens, nullSeed);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ParseThrowsOnEmptyTokens()
        {
            Fixture f = new Fixture();
            Action act = () => f.earleyParser.Parse([], f.seed);
            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void ParseReturnsCompletedChartForAcceptedString()
        {
            Fixture f = new Fixture();
            Parse parse = f.earleyParser.Parse(f.tokens, f.seed);

            parse.Seed.Should().Be(f.seed);
            parse.Status.Should().Be(Status.Accept);
        }

        /// <summary>
        /// ParserOptions.PredictPreterminals is automatically switched on if the
        /// grammar contains a preterminal rule with more than one category on its
        /// right side (e.g. X -> a Y). Just-in-time preterminal prediction (used when
        /// PredictPreterminals is false) only recognizes *singleton* preterminal
        /// rules, so without this safety net such a grammar could never be parsed
        /// correctly in that mode. This test constructs exactly that situation and
        /// confirms both that parsing still succeeds and that the shared
        /// ParserOptions instance is mutated to reflect the auto-enable.
        /// </summary>
        [Fact]
        public void PredictPreterminalsAutoEnablesForIncompatibleGrammar()
        {
            Category s = new Category("S", false);
            Category t = new Category("T", false);
            Category a = new Category("a", true);
            Category b = new Category("b", true);

            Grammar g = new Grammar("g");
            g.AddRule(new Rule(s, new ReadOnlyCollection<Category>([a, t])));
            g.AddRule(new Rule(t, new ReadOnlyCollection<Category>([b])));

            ParserOptions options = new ParserOptions(false, false);
            Parser parser = new Parser(g, options);

            Parse parse = parser.Parse(["a", "b"], s);

            parse.Status.Should().Be(Status.Accept);
            options.PredictPreterminals.Should().BeTrue();
        }

        [Fact]
        public void OnEdgePredictedFiresDuringParse()
        {
            Fixture f = new Fixture();
            int count = 0;
            f.earleyParser.OnEdgePredicted += (sender, e) => count++;

            f.earleyParser.Parse(f.tokens, f.seed);

            count.Should().BeGreaterThan(0);
        }

        /// <summary>
        /// For the unambiguous rule S -> a b, exactly one scan succeeds per input
        /// token, so OnEdgeScanned must fire exactly tokens.Length times - not more,
        /// not fewer.
        /// </summary>
        [Fact]
        public void OnEdgeScannedFiresOncePerToken()
        {
            Category s = new Category("S", false);
            Category a = new Category("a", true);
            Category b = new Category("b", true);

            Grammar g = new Grammar("g");
            g.AddRule(new Rule(s, new ReadOnlyCollection<Category>([a, b])));

            Parser parser = new Parser(g);
            int count = 0;
            parser.OnEdgeScanned += (sender, e) => count++;

            string[] tokens = ["a", "b"];
            parser.Parse(tokens, s);

            count.Should().Be(tokens.Length);
        }

        [Fact]
        public void OnEdgeCompletedFiresWhenSeedCategoryCompletes()
        {
            Fixture f = new Fixture();
            int count = 0;
            f.earleyParser.OnEdgeCompleted += (sender, e) => count++;

            f.earleyParser.Parse(f.tokens, f.seed);

            count.Should().BeGreaterThan(0);
        }
    }
}
