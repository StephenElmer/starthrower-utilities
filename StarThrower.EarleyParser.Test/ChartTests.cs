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
    public class ChartTests
    {
        [Fact]
        public void FirstKey()
        {
            Fixture f = new Fixture();
            f.chart.FirstIndex.Should().Be(0);
        }

        [Fact]
        public void LastKey()
        {
            Fixture f = new Fixture();
            f.chart.LastIndex.Should().Be(1);
        }

        [Fact]
        public void SubChart1()
        {
            Fixture f = new Fixture();
            Chart subChart = f.chart.GetSubChart(0, 1);
            subChart.ContainsEdge(f.edge1).Should().Be(true);
        }

        [Fact]
        public void SubChart2()
        {
            Fixture f = new Fixture();
            Chart subChart = f.chart.GetSubChart(0, 1);
            subChart.ContainsEdge(f.edge2).Should().Be(true);
        }

        [Fact]
        public void SubChart3()
        {
            Fixture f = new Fixture();
            Chart subChart = f.chart.GetSubChart(0, 1);
            subChart.ContainsEdge(f.edge3).Should().Be(false);
        }

        [Fact]
        public void SubChart4()
        {
            Fixture f = new Fixture();
            Action act = () => f.chart.GetSubChart(1, 0);
            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void IndexOf1()
        {
            Fixture f = new Fixture();
            f.chart.GetIndexOfEdge(f.edge1).Should().Be(0);
        }

        [Fact]
        public void IndexOf2()
        {
            Fixture f = new Fixture();
            f.chart.GetIndexOfEdge(f.edge2).Should().Be(0);
        }

        [Fact]
        public void IndexOf3()
        {
            Fixture f = new Fixture();
            f.chart.GetIndexOfEdge(f.edge3).Should().Be(1);
        }

        [Fact]
        public void Contains1()
        {
            Fixture f = new Fixture();
            f.chart.ContainsEdge(f.edge1).Should().Be(true);
        }

        [Fact]
        public void Contains2()
        {
            Fixture f = new Fixture();
            f.chart.ContainsEdge(f.edge2).Should().Be(true);
        }

        [Fact]
        public void Contains3()
        {
            Fixture f = new Fixture();
            f.chart.ContainsEdge(f.edge3).Should().Be(true);
        }

        [Fact]
        public void Contains4()
        {
            Fixture f = new Fixture();
            f.chart.ContainsEdge(new Edge(new DottedRule(f.rule3), 4)).Should().Be(false);
        }

        [Fact]
        public void GetIndices()
        {
            Fixture f = new Fixture();
            SortedDictionary<int, Collection<Edge>>.KeyCollection indices = f.chart.Indexes;
            indices.Contains(0).Should().Be(true);
            indices.Contains(1).Should().Be(true);
        }

        [Fact]
        public void GetIndices2()
        {
            Fixture f = new Fixture();
            SortedDictionary<int, Collection<Edge>>.KeyCollection indices = f.chart.Indexes;

            SortedSet<int> expected = new SortedSet<int>();
            foreach (int i in indices)
            {
                expected.Add(i);
            }
            indices.Count.Should().Be(expected.Count);

            int cur = -1;
            int last = -1;
            foreach (int i in indices)
            {
                last = cur;
                cur = i;
                if (last != -1)
                {
                    (cur > last).Should().Be(true);
                }
            }
        }

        [Fact]
        public void ContainsEdge()
        {
            Fixture f = new Fixture();
            f.chart.ContainsEdgesAt(0).Should().Be(true);
            f.chart.ContainsEdgesAt(1).Should().Be(true);
            f.chart.ContainsEdgesAt(2).Should().Be(false);
        }

        [Fact]
        public void AddEdge()
        {
            Fixture f = new Fixture();
            f.chart.AddEdge(0, f.edge1).Should().Be(false);
        }

        [Fact]
        public void GetEdge()
        {
            Fixture f = new Fixture();
            ReadOnlyCollection<Edge>? zeroEdges = f.chart.GetEdgesAt(0);
            zeroEdges.Should().NotBeNull();
            zeroEdges.Contains(f.edge1).Should().Be(true);
            zeroEdges.Contains(f.edge2).Should().Be(true);
        }

        [Fact]
        public void EqualsReturns()
        {
            Fixture f = new Fixture();
            Chart c = new Chart();
            c.AddEdge(0, f.edge1);
            c.AddEdge(0, f.edge2);
            c.AddEdge(1, f.edge3);

            c.Should().Be(f.chart);
        }
    }
}
