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
    public class DottedRuleTests
    {
        [Fact]
        public void AdvanceDot()
        {
            Fixture f = new Fixture();
            Rule advanced = new DottedRule(f.rule3, 1);
            DottedRule.AdvanceDot(f.edge2.DottedRule).Should().Be(advanced);
        }

        [Fact]
        public void AdvanceDotFail()
        {
            Fixture f = new Fixture();
            Action act = () => DottedRule.AdvanceDot(f.edge3.DottedRule);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void CreateStartRuleThrowsOnNull()
        {
            Category? nullSeed = null;
            Action act = () => DottedRule.CreateStartRule(nullSeed);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void CreateStartRuleThrowsOnTerminalSeed()
        {
            Fixture f = new Fixture();
            Action act = () => DottedRule.CreateStartRule(f.a);
            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void CreateStartRule()
        {
            Fixture f = new Fixture();
            DottedRule sr = DottedRule.CreateStartRule(f.A);
            sr.Left.Should().BeSameAs(Category.Root);
            sr.Left.Should().Be(Category.Root);
            (new Category(Category.Root.Name)).Should().NotBeSameAs(Category.Root);
            sr.Position.Should().Be(0);
            sr.ActiveCategory.Should().Be(f.A);
            DottedRule.CreateStartRule(f.A).Should().Be(sr);
        }

        [Fact]
        public void GetPosition()
        {
            Fixture f = new Fixture();
            f.dot1.Position.Should().Be(2);
        }

        [Fact]
        public void ActiveCategory()
        {
            Fixture f = new Fixture();
            f.dot1.ActiveCategory.Should().Be(f.D);
            f.dot2.ActiveCategory.Should().BeNull();
            f.dot3.ActiveCategory.Should().NotBe(f.D);
        }

        [Fact]
        public void GetHashCodeReturnsCorrect()
        {
            Fixture f = new Fixture();

            int bh = 17;
            bh = 31 * bh + f.dot1.Left.GetHashCode();
            bh = 31 * bh + f.dot1.Right.GetHashCode();

            int result = 17;
            result = 31 * result + f.dot1.Position.GetHashCode();
            result = 31 * result + bh;

            f.dot1.GetHashCode().Should().Be(result);
        }

        [Fact]
        public void EqualsReturnsTrue()
        {
            Fixture f = new Fixture();
            DottedRule dr = new DottedRule(f.rule1, 2);
            f.dot1.Equals(dr).Should().Be(true);
        }

        [Fact]
        public void EqualsReturnsFalse()
        {
            Fixture f = new Fixture();
            DottedRule dr = new DottedRule(f.rule1, 2);
            f.dot2.Equals(dr).Should().Be(false);
        }

        [Fact]
        public void ToStringReturnsCorrectly()
        {
            Fixture f = new Fixture();
            f.dot1.ToString().Should().Be("A -> B C * D E");
            f.dot2.ToString().Should().Be("A -> a *");
            f.dot3.ToString().Should().Be("X -> * Y Z");
        }
    }
}
