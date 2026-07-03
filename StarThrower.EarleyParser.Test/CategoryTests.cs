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
    public class CategoryTests
    {
        [Fact]
        public void Root()
        {
            Category r = Category.Root;
            r.ToString().Should().Be("<start>");
            r.IsTerminal.Should().Be(false);
        }

        [Fact]
        public void RootReturnsSameObject()
        {
            Category r1 = Category.Root;
            Category r2 = Category.Root;
            r2.Should().BeSameAs(r1);
        }

        [Fact]
        public void IsTerminalNamePropertyReturnsName()
        {
            Category c = new Category("A", true);
            c.Name.Should().Be("A");
        }

        [Fact]
        public void IsTerminalReturnsTrue()
        {
            Category c = new Category("A", true);
            c.IsTerminal.Should().Be(true);
        }

        [Fact]
        public void IsTerminalReturnsFalse()
        {
            Category c = new Category("A", false);
            c.IsTerminal.Should().Be(false);
        }

        [Fact]
        public void ToStringReturnsName()
        {
            Category c = new Category("A");
            c.ToString().Should().Be("A");
        }

        [Fact]
        public void ToStringReturnsNameWhenIsTerminal()
        {
            Category c = new Category("A", true);
            c.ToString().Should().Be("A");
        }

        [Fact]
        public void ToStringReturnsNameWhenNotTerminal()
        {
            Category c = new Category("A", false);
            c.ToString().Should().Be("A");
        }

        [Fact]
        public void ToStringReturnsEmptyForEmptyName()
        {
            Category c = new Category(String.Empty, true);
            c.ToString().Should().Be("<empty>");
        }

        [Fact]
        public void CtorThrowsOnNullName()
        {
            string? nullName = null;
            #pragma warning disable CA1806 // false positive: ctor result intentionally discarded to test throw behavior
            Action act = () => new Category(nullName, false);
            #pragma warning restore CA1806
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void CtorThrowsOnEmptyNameWithNonTerminal()
        {
            #pragma warning disable CA1806 // false positive: ctor result intentionally discarded to test throw behavior
            Action act = () => new Category("", false);
            #pragma warning restore CA1806
            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void CtorAcceptsEmptyNameWithTerminal()
        {
            Category c = new Category("", true);
            c.Name.Should().Be(String.Empty);
            c.IsTerminal.Should().Be(true);
        }

        [Fact]
        public void CtorThrowsOnWhitespaceName()
        {
            #pragma warning disable CA1806 // false positive: ctor result intentionally discarded to test throw behavior
            Action act = () => new Category(" ", false);
            #pragma warning restore CA1806
            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void EqualsReturnsTrueWhenSame()
        {
            Category a = new Category("A", false);
            Category b = a;
            a.Equals(b).Should().Be(true);
        }

        [Fact]
        public void EqualsReturnsFalseWhenNull()
        {
            Category a = new Category("A", false);
            Category? b = null;
            a.Equals(b).Should().Be(false);
        }

        [Fact]
        public void EqualsReturnsFalseWhenNotCategory()
        {
            Category a = new Category("A", false);
            String b = "asdf";
            a.Equals(b).Should().Be(false);
        }

        [Fact]
        public void EqualsReturnsTrueWhenEquivalent1()
        {
            Category a = new Category("A", false);
            Category b = new Category("A", false);
            a.Equals(b).Should().Be(true);
        }

        [Fact]
        public void EqualsReturnsTrueWhenEquivalent2()
        {
            Category a = new Category("A", true);
            Category b = new Category("A", true);
            a.Equals(b).Should().Be(true);
        }

        [Fact]
        public void EqualsReturnsTrueWhenNotEquivalent1()
        {
            Category a = new Category("A", false);
            Category b = new Category("B", false);
            a.Equals(b).Should().Be(false);
        }

        [Fact]
        public void EqualsReturnsTrueWhenNotEquivalent2()
        {
            Category a = new Category("A", false);
            Category b = new Category("A", true);
            a.Equals(b).Should().Be(false);
        }

        [Fact]
        public void EqualsReturnsTrueWhenNotEquivalent3()
        {
            Category a = new Category("A", true);
            Category b = new Category("A", false);
            a.Equals(b).Should().Be(false);
        }

        [Fact]
        public void EqualsReturnsTrueWhenNotEquivalent4()
        {
            Category a = new Category("A", true);
            Category b = new Category("B", false);
            a.Equals(b).Should().Be(false);
        }

        [Fact]
        public void EqualsReturnsTrueWhenNotEquivalent5()
        {
            Category a = new Category("A", false);
            Category b = new Category("B", true);
            a.Equals(b).Should().Be(false);
        }

        [Fact]
        public void CtorSingleArgument()
        {
            Category a = new Category("A");
            a.Name.Should().Be("A");
            a.IsTerminal.Should().Be(false);
        }
    }
}
