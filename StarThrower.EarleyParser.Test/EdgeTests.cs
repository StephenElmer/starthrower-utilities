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
    public class EdgeTests
    {
        [Fact]
        public void Ctor1()
        {
            Fixture f = new Fixture();
            Action act = () => new Edge(new DottedRule(f.edge1.DottedRule, 0), -1);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetOrigin()
        {
            Fixture f = new Fixture();
            f.edge1.Origin.Should().Be(3);
        }

        [Fact]
        public void GetDottedRule()
        {
            Fixture f = new Fixture();
            f.edge1.DottedRule.Should().Be(new DottedRule(f.rule1, 2));
        }

        [Fact]
        public void Predict1()
        {
            Fixture f = new Fixture();
            Edge pe = Edge.PredictFor(f.rule1, 1);
            pe.DottedRule.Left.Should().Be(f.A);
        }

        [Fact]
        public void Predict2()
        {
            Fixture f = new Fixture();
            Edge pe = Edge.PredictFor(f.rule1, 1);
            pe.DottedRule.ActiveCategory.Should().Be(f.B);
        }

        [Fact]
        public void Predict3()
        {
            Fixture f = new Fixture();
            Edge pe = Edge.PredictFor(f.rule1, 1);
            pe.IsPassive.Should().Be(false);
        }

        [Fact]
        public void Predict4()
        {
            Fixture f = new Fixture();
            Edge pe = Edge.PredictFor(f.rule1, 1);
            pe.Origin.Should().Be(1);
        }

        [Fact]
        public void Predict5()
        {
            Rule? nullRule = null;
            Action act = () => Edge.PredictFor(nullRule, 0);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Predict6()
        {
            Fixture f = new Fixture();
            Action act = () => Edge.PredictFor(f.rule2, -1);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Complete1()
        {
            Fixture f = new Fixture();
            Edge? nullEdge = null;
            Action act = () => Edge.Complete(f.edge2, nullEdge);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Complete2()
        {
            Fixture f = new Fixture();
            List<Category> l = new List<Category>();
            l.Add(f.Z);
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(l);
            Rule r = new Rule(f.D, right);
            DottedRule dr = new DottedRule(r, 1);
            Edge completer = new Edge(dr, f.edge1.Origin);

            completer.DottedRule.Should().Be(dr);
            completer.Origin.Should().Be(f.edge1.Origin);
        }

        [Fact]
        public void Complete3()
        {
            Fixture f = new Fixture();
            List<Category> l = new List<Category>();
            l.Add(f.Z);
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(l);
            Rule r = new Rule(f.D, right);
            DottedRule dr = new DottedRule(r, 1);
            Edge completer = new Edge(dr, f.edge1.Origin);

            Edge e = Edge.Complete(f.edge1, completer);

            e.Bases.Count.Should().Be(1);
            e.DottedRule.ActiveCategory.Should().Be(f.E);
            e.DottedRule.Position.Should().Be(3);
            e.IsPassive.Should().Be(false);
            e.Origin.Should().Be(3);
        }


        [Fact]
        public void Complete4()
        {
            Fixture f = new Fixture();
            List<Category> l = new List<Category>();
            l.Add(f.Z);
            ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(l);
            Rule r = new Rule(f.D, right);
            DottedRule dr = new DottedRule(r, 1);
            Edge completer = new Edge(dr, f.edge1.Origin);

            Action act = () => Edge.Complete(f.edge2, completer);
            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void GetBases()
        {
            Fixture f = new Fixture();

            List<Category> l = new List<Category>();
            l.Add(f.A);
            ReadOnlyCollection<Category> cat1 = new ReadOnlyCollection<Category>(l);
            Edge edge2Completer = new Edge(new DottedRule(new Rule(f.Y, cat1), 1), f.edge2.Origin);

            l = new List<Category>();
            l.Add(f.B);
            ReadOnlyCollection<Category> cat2 = new ReadOnlyCollection<Category>(l);
            Edge ce1Completer = new Edge(new DottedRule(new Rule(f.Z, cat2), 1), f.edge2.Origin);

            Edge ce1 = Edge.Complete(f.edge2, edge2Completer);

            Edge ce2 = Edge.Complete(ce1, ce1Completer);

            List<Edge> el = new List<Edge>(ce1.Bases);
            el.Add(ce1Completer);
            ReadOnlyCollection<Edge> bases = new ReadOnlyCollection<Edge>(el);

            ce2.Bases.Count.Should().Be(bases.Count);
            for (int i = 0; i < bases.Count; i++)
            {
                ce2.Bases[i].Should().Be(bases[i]);
            }
        }

        [Fact]
        public void GetIsPassive()
        {
            Fixture f = new Fixture();
            f.edge1.IsPassive.Should().Be(false);
            f.edge2.IsPassive.Should().Be(false);
            f.edge3.IsPassive.Should().Be(true);
        }

        [Fact]
        public void ToStringReturnsCorrectly()
        {
            Fixture f = new Fixture();
            f.edge1.ToString().Should().Be("3[A -> B C * D E]");
            f.edge2.ToString().Should().Be("0[X -> * Y Z]");
            f.edge3.ToString().Should().Be("2[A -> a *]");
        }

        [Fact]
        public void EqualsReturnsCorrectly()
        {
            Fixture f = new Fixture();
            Edge e = new Edge(f.edge1.DottedRule, f.edge1.Origin);
            e.Should().Be(f.edge1);
            f.edge2.Should().Be(f.edge2);
            f.edge3.Should().NotBeSameAs(f.edge2);
            f.edge2.Equals(f.edge3).Should().Be(false);
        }

        [Fact]
        public void EqualsReturnsCorrectly2()
        {
            Fixture f = new Fixture();
            List<Edge> l = new List<Edge>();
            l.Add(f.edge1);
            Edge e = new Edge(f.edge1.DottedRule, f.edge1.Origin, new ReadOnlyCollection<Edge>(l));

            l = new List<Edge>();
            l.Add(f.edge1);
            Edge e2 = new Edge(f.edge1.DottedRule, f.edge1.Origin, new ReadOnlyCollection<Edge>(l));
            e2.Should().Be(e);
        }

        [Fact]
        public void GetHashCodeReturnsCorrectly()
        {
            Fixture f = new Fixture();

            int result = 17;
            result = 31 * result + f.edge1.Origin.GetHashCode();
            result = 31 * result + f.edge1.DottedRule.GetHashCode();
            result = 31 * result + f.edge1.Bases.GetHashCode();

            f.edge1.GetHashCode().Should().Be(result);
            f.edge3.GetHashCode().Should().NotBe(f.edge2.GetHashCode());
        }

    }
}
