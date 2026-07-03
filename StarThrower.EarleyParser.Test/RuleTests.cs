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
    public class RuleTests
    {
        [Fact]
        public void CtorThrowsOnNullLeft()
        {
            Category? left = null;
            List<Category> l = new List<Category>();
            l.Add(new Category("R"));
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(l);
            #pragma warning disable CA1806 // false positive: ctor result intentionally discarded to test throw behavior
            Action act = () => new Rule(left, right);
            #pragma warning restore CA1806
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void CtorThrowsOnNullTerminalLeft()
        {
            Category left = new Category("l", true);
            List<Category> l = new List<Category>();
            l.Add(new Category("R"));
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(l);
            #pragma warning disable CA1806 // false positive: ctor result intentionally discarded to test throw behavior
            Action act = () => new Rule(left, right);
            #pragma warning restore CA1806
            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void CtorThrowsOnNullRight()
        {
            Category left = new Category("L", false);
            ReadOnlyCollection<Category>? right = null;
            #pragma warning disable CA1806 // false positive: ctor result intentionally discarded to test throw behavior
            Action act = () => new Rule(left, right);
            #pragma warning restore CA1806
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void CtorThrowsOnEmptyRight()
        {
            Category left = new Category("L", false);
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(new List<Category>());
            #pragma warning disable CA1806 // false positive: ctor result intentionally discarded to test throw behavior
            Action act = () => new Rule(left, right);
            #pragma warning restore CA1806
            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void CtorThrowsOnNullItemInRight()
        {
            Category? left = null;
            Category[] arr = new Category[3];
            arr[0] = new Category("R", false);
            arr[2] = new Category("r", true);
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(arr);
            #pragma warning disable CA1806 // false positive: ctor result intentionally discarded to test throw behavior
            Action act = () => new Rule(left, right);
            #pragma warning restore CA1806
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void IsPreterminalReturnsTrueForPreTerm()
        {
            Category left = new Category("L", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("R1", false));
            l.Add(new Category("r2", true));
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(l);
            Rule r = new Rule(left, right);
            r.IsPreterminal.Should().Be(true);
        }

        [Fact]
        public void IsPreterminalReturnsFalseForNonPreTerm()
        {
            Category left = new Category("L", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("R1", false));
            l.Add(new Category("R2", false));
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(l);
            Rule r = new Rule(left, right);
            r.IsPreterminal.Should().Be(false);
        }

        [Fact]
        public void IsSingletonPreterminalReturnsTrue()
        {
            Category left = new Category("L", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("r", true));
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(l);
            Rule r = new Rule(left, right);
            r.IsSingletonPreterminal.Should().Be(true);
        }

        [Fact]
        public void IsSingletonPreterminalReturnsFalse1()
        {
            Category left = new Category("L", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("r", false));
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(l);
            Rule r = new Rule(left, right);
            r.IsSingletonPreterminal.Should().Be(false);
        }

        [Fact]
        public void IsSingletonPreterminalReturnsFalse2()
        {
            Category left = new Category("L", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("r", true));
            l.Add(new Category("r", true));
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(l);
            Rule r = new Rule(left, right);
            r.IsSingletonPreterminal.Should().Be(false);
        }

        [Fact]
        public void LeftReturnsLeftReference()
        {
            Category left = new Category("L", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("R1", false));
            l.Add(new Category("R2", false));
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(l);
            Rule r = new Rule(left, right);
            r.Left.Should().BeSameAs(left);
        }

        [Fact]
        public void LeftReturnsLeftReferenceOnly()
        {
            Category left = new Category("L", false);
            List<Category> l = new List<Category>();
            Category right1 = new Category("R1", false);
            Category right2 = new Category("r1", true);
            l.Add(right1);
            l.Add(right2);
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(l);
            Rule r = new Rule(left, right);
            r.Left.Should().NotBeSameAs(right1);
        }

        [Fact]
        public void RightReturnsRightReference()
        {
            Category left = new Category("L", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("R1", false));
            l.Add(new Category("R2", false));
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(l);
            Rule r = new Rule(left, right);
            r.Right.Should().BeSameAs(right);
        }

        [Fact]
        public void ToString1()
        {
            Category left1 = new Category("A", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("B", false));
            l.Add(new Category("C", false));
            l.Add(new Category("D", false));
            l.Add(new Category("E", false));
            ReadOnlyCollection<Category> right1 = new ReadOnlyCollection<Category>(l);
            Rule r1 = new Rule(left1, right1);

            r1.ToString().Should().Be("A -> B C D E");
        }

        [Fact]
        public void ToString2()
        {
            Category left2 = new Category("A", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("a", true));
            ReadOnlyCollection<Category> right2 = new ReadOnlyCollection<Category>(l);
            Rule r2 = new Rule(left2, right2);

            r2.ToString().Should().Be("A -> a");
        }

        [Fact]
        public void ToString3()
        {
            Category left3 = new Category("X", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("Y", false));
            l.Add(new Category("Z", false));
            ReadOnlyCollection<Category> right3 = new ReadOnlyCollection<Category>(l);
            Rule r3 = new Rule(left3, right3);

            r3.ToString().Should().Be("X -> Y Z");
        }

        [Fact]
        public void Equals1()
        {
            Category left1 = new Category("A", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("B", false));
            ReadOnlyCollection<Category> right1 = new ReadOnlyCollection<Category>(l);
            Rule r1 = new Rule(left1, right1);

            Category left2 = new Category("A", false);
            l = new List<Category>();
            l.Add(new Category("B", false));
            ReadOnlyCollection<Category> right2 = new ReadOnlyCollection<Category>(l);
            Rule r2 = new Rule(left2, right2);

            r1.Equals(r2).Should().Be(true);
        }

        [Fact]
        public void EqualsReturnsFalseWhenSame()
        {
            Category left1 = new Category("A", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("B", false));
            ReadOnlyCollection<Category> right1 = new ReadOnlyCollection<Category>(l);
            Rule r1 = new Rule(left1, right1);

            r1.Equals(r1).Should().Be(true);
        }

        [Fact]
        public void EqualsReturnsFalseWhenNull()
        {
            Category left1 = new Category("A", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("B", false));
            ReadOnlyCollection<Category> right1 = new ReadOnlyCollection<Category>(l);
            Rule r1 = new Rule(left1, right1);

            Rule? r2 = null;

            r1.Equals(r2).Should().Be(false);
        }

        [Fact]
        public void EqualsReturnsFalseForOtherType()
        {
            Category left1 = new Category("A", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("B", false));
            ReadOnlyCollection<Category> right1 = new ReadOnlyCollection<Category>(l);
            Rule r1 = new Rule(left1, right1);

            string r2 = "asfd";

            r1.Equals(r2).Should().Be(false);
        }

        [Fact]
        public void EqualsReturnsFalseWhenNotEquivalent()
        {
            Category left1 = new Category("A", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("B", false));
            ReadOnlyCollection<Category> right1 = new ReadOnlyCollection<Category>(l);
            Rule r1 = new Rule(left1, right1);

            Category left2 = new Category("A", false);
            l = new List<Category>();
            l.Add(new Category("C", false));
            ReadOnlyCollection<Category> right2 = new ReadOnlyCollection<Category>(l);
            Rule r2 = new Rule(left2, right2);

            r1.Equals(r2).Should().Be(false);
        }

        [Fact]
        public void EqualsReturnsFalseWhenNotEquivalent2()
        {
            Category left1 = new Category("C", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("B", false));
            ReadOnlyCollection<Category> right1 = new ReadOnlyCollection<Category>(l);
            Rule r1 = new Rule(left1, right1);

            Category left2 = new Category("A", false);
            l = new List<Category>();
            l.Add(new Category("B", false));
            ReadOnlyCollection<Category> right2 = new ReadOnlyCollection<Category>(l);
            Rule r2 = new Rule(left2, right2);

            r1.Equals(r2).Should().Be(false);
        }

        [Fact]
        public void EqualsReturnsFalseWhenNotEquivalent3()
        {
            Category left1 = new Category("A", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("B", false));
            l.Add(new Category("C", false));
            ReadOnlyCollection<Category> right1 = new ReadOnlyCollection<Category>(l);
            Rule r1 = new Rule(left1, right1);

            Category left2 = new Category("A", false);
            l = new List<Category>();
            l.Add(new Category("B", false));
            ReadOnlyCollection<Category> right2 = new ReadOnlyCollection<Category>(l);
            Rule r2 = new Rule(left2, right2);

            r1.Equals(r2).Should().Be(false);
        }

        [Fact]
        public void GetHashCode1()
        {
            Category left = new Category("A", false);
            List<Category> l = new List<Category>();
            l.Add(new Category("B", false));
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(l);
            Rule r = new Rule(left, right);

            int result = 17;
            result = 31 * result + left.GetHashCode();
            result = 31 * result + right.GetHashCode();
            r.GetHashCode().Should().Be(result);
        }


        [Fact]
        public void Ctor1()
        {
            Fixture f = new Fixture();
            List<Category> l = new List<Category>();
            l.Add(f.X);
            l.Add(f.Z);
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(l);
            Category? nullLeft = null;
            #pragma warning disable CA1806 // false positive: ctor result intentionally discarded to test throw behavior
            Action act = () => new Rule(nullLeft, right);
            #pragma warning restore CA1806
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Ctor2()
        {
            Fixture f = new Fixture();
            ReadOnlyCollection<Category>? right = null;
            #pragma warning disable CA1806 // false positive: ctor result intentionally discarded to test throw behavior
            Action act = () => new Rule(f.Z, right);
            #pragma warning restore CA1806
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Ctor3()
        {
            Fixture f = new Fixture();
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(new List<Category>());
            #pragma warning disable CA1806 // false positive: ctor result intentionally discarded to test throw behavior
            Action act = () => new Rule(f.Z, right);
            #pragma warning restore CA1806
            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Ctor4()
        {
            Fixture f = new Fixture();
            List<Category> l = new List<Category>();
            l.Add(f.a);
            l.Add(f.A);
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(l);
            Rule r = new Rule(f.Z, right);
            r.Left.Should().Be(f.Z);
            r.Right.Should().BeSameAs(right);
        }

        [Fact]
        public void IsPreterminal1()
        {
            Fixture f = new Fixture();
            f.rule2.IsPreterminal.Should().Be(true);
        }

        [Fact]
        public void IsPreterminal2()
        {
            Fixture f = new Fixture();
            f.rule3.IsPreterminal.Should().Be(false);
        }

        [Fact]
        public void Left1()
        {
            Fixture f = new Fixture();
            f.rule1.Left.Should().Be(f.A);
        }

        [Fact]
        public void Left2()
        {
            Fixture f = new Fixture();
            f.rule2.Left.Should().NotBe(f.B);
        }

        [Fact]
        public void Right1()
        {
            Fixture f = new Fixture();
            Collection<Category> expected = new Collection<Category>();
            expected.Add(f.Y);
            expected.Add(f.Z);

            f.rule3.Right.Count.Should().Be(expected.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                f.rule3.Right[i].Should().Be(expected[i]);
            }
        }
    }
}
