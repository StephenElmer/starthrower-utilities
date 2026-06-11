// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
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
        public void Parse1()
        {

        }
    }
}
