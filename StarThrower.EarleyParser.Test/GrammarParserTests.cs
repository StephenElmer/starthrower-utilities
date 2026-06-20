// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.IO;
using System.Xml;
using System.Collections.ObjectModel;
using AwesomeAssertions;
using Xunit;
using StarThrower.EarleyParser;

namespace StarThrower.EarleyParser.Test
{
    public class GrammarParserTests
    {
        private readonly string _languagesFolder = Path.GetFullPath(
            Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "Samples", "Languages"));

        /// <summary>
        /// Samples/Languages/earley.xml is a committed grammar fixture that encodes
        /// the same arithmetic-expression grammar (S -> E, E -> T | E + T, T -> p |
        /// T * p, p -> a) used by EarleyExampleTests, built directly from source there
        /// rather than via GrammarParser. Parsing the XML and comparing the result
        /// (with Grammar.Equals) against an independently hand-built grammar verifies
        /// the parser produces the grammar the XML actually describes, rather than
        /// just "some grammar that happens to satisfy GrammarParserTests itself."
        /// </summary>
        [Fact]
        public void ParseProducesGrammarEquivalentToHandBuiltGrammar()
        {
            Category s = new Category("S", false);
            Category e = new Category("E", false);
            Category t = new Category("T", false);
            Category p = new Category("p", false);
            Category plus = new Category("+", true);
            Category times = new Category("*", true);
            Category a = new Category("a", true);

            Grammar expected = new Grammar("Earley");
            expected.AddRule(new Rule(s, new ReadOnlyCollection<Category>([e])));
            expected.AddRule(new Rule(e, new ReadOnlyCollection<Category>([t])));
            expected.AddRule(new Rule(e, new ReadOnlyCollection<Category>([e, plus, t])));
            expected.AddRule(new Rule(t, new ReadOnlyCollection<Category>([p])));
            expected.AddRule(new Rule(t, new ReadOnlyCollection<Category>([t, times, p])));
            expected.AddRule(new Rule(p, new ReadOnlyCollection<Category>([a])));

            GrammarParser parser = new GrammarParser(Path.Combine(_languagesFolder, "earley.xml"));
            Grammar actual = parser.Parse();

            actual.Should().Be(expected);
        }

        /// <summary>
        /// The parsed grammar must actually function as a grammar: feeding it into a
        /// Parser and parsing tokens should produce the same accept/reject results as
        /// the in-memory grammar used elsewhere for this arithmetic expression
        /// language. This guards against a grammar that compares unequal-but-close
        /// (or equal-but-broken) in ways Grammar.Equals alone wouldn't catch.
        /// </summary>
        [Fact]
        public void ParsedGrammarParsesTokensCorrectly()
        {
            GrammarParser parser = new GrammarParser(Path.Combine(_languagesFolder, "earley.xml"));
            Grammar grammar = parser.Parse();
            Category s = new Category("S", false);

            Parser earleyParser = new Parser(grammar);

            earleyParser.Parse(["a", "*", "a"], s).Status.Should().Be(Status.Accept);
            earleyParser.Parse(["a", "+", "a"], s).Status.Should().Be(Status.Accept);
            earleyParser.Parse(["a", "-", "a"], s).Status.Should().Be(Status.Reject);
        }

        [Fact]
        public void CtorThrowsWhenFileDoesNotExist()
        {
            Action act = () => new GrammarParser(Path.Combine(_languagesFolder, "does-not-exist.xml"));
            act.Should().Throw<FileNotFoundException>();
        }

        [Fact]
        public void ParseThrowsWhenRootElementMissingNameAttribute()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<grammar><rule category=\"S\"><category terminal=\"true\" name=\"a\"/></rule></grammar>");

            GrammarParser parser = new GrammarParser(doc);
            Action act = () => parser.Parse();
            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void ParseThrowsWhenRuleMissingCategoryAttribute()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<grammar name=\"g\"><rule><category terminal=\"true\" name=\"a\"/></rule></grammar>");

            GrammarParser parser = new GrammarParser(doc);
            Action act = () => parser.Parse();
            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void ParseThrowsWhenRuleCategoryMissingNameAttribute()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<grammar name=\"g\"><rule category=\"S\"><category terminal=\"true\"/></rule></grammar>");

            GrammarParser parser = new GrammarParser(doc);
            Action act = () => parser.Parse();
            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void ParseThrowsWhenTerminalAttributeIsNotABoolean()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<grammar name=\"g\"><rule category=\"S\"><category terminal=\"yes\" name=\"a\"/></rule></grammar>");

            GrammarParser parser = new GrammarParser(doc);
            Action act = () => parser.Parse();
            act.Should().Throw<FormatException>();
        }

        [Fact]
        public void ParseDefaultsTerminalToFalseWhenAttributeAbsent()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<grammar name=\"g\"><rule category=\"S\"><category name=\"NP\"/></rule></grammar>");

            GrammarParser parser = new GrammarParser(doc);
            Grammar g = parser.Parse();

            Category s = new Category("S", false);
            g.GetRules(s)[0].Right[0].IsTerminal.Should().BeFalse();
        }
    }
}
