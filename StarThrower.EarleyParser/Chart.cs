/***********************************************************************************
    StarThrower Utilities / EarleyParser
    Copyright (C) 2005-2026  Stephen Elmer

    This library is free software; you can redistribute it and/or
    modify it under the terms of the GNU Lesser General Public
    License as published by the Free Software Foundation; either
    version 2.1 of the License, or (at your option) any later version.

    This library is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
    Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public
    License along with this library; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
***********************************************************************************/

using System;
using System.Globalization;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StarThrower.EarleyParser
{
    /// <summary>
    /// A chart is produced by an Earley parser.
    /// 
    /// Charts contain sets of edges mapped to the string indices where
    /// the originate.  Since the edge sets are sets, an edge can only
    /// be added at a given index once (as sets do not permit duplicate members).
    /// Edge sets are not guaranteed to maintain edges in their order of insertion.
    /// </summary>
    public class Chart
    {
        private const int NullIndex = -1;

        #region [ Private Instance Variables ]

        private SortedDictionary<int, Collection<Edge>> _edgeSets;

        #endregion


        #region [ Public Properties ]

        /// <summary>
        /// Gets the set of indices at which this chart contains edges.  For
        /// any member of this set, this will return a non-empty set of edges.
        /// Returns a set containing every index in this chart where edges have
        /// been added, sorted in ascending order (0..n).
        /// </summary>
        public SortedDictionary<int, Collection<Edge>>.KeyCollection Indexes
        {
            get { return _edgeSets.Keys; }
        }

        /// <summary>
        /// Gets the first index in this chart that contains edges, returning the minimal member of indices.
        /// In most cases, this will return 0 (unless this chart is a subchart of another chart).
        /// </summary>
        public int FirstIndex
        {
            get
            {
                int result = Chart.NullIndex;
                foreach (int key in _edgeSets.Keys)
                {
                    result = key;
                    break;
                }
                return result;
            }
        }

        /// <summary>
        /// Gets the last index in this chart that contains edges, return the
        /// maximal member of indices.
        /// </summary>
        public int LastIndex
        {
            get
            {
                int result = Chart.NullIndex;
                foreach (int key in _edgeSets.Keys)
                {
                    result = key;
                }
                return result;
            }
        }

        /// <summary>
        /// Tests whether this chart contains any edges at any index, returning true if 
        /// an edge is present at some index, false if otherwise.
        /// </summary>
        public bool IsEmpty
        {
            get { return _edgeSets.Count == 0; }
        }

        /// <summary>
        /// Counts the total number of edges contained in this chart, at any index,
        /// returning the total number of edges contained.
        /// </summary>
        public int EdgeCount
        {
            get
            {
                int count = 0;
                foreach (int key in _edgeSets.Keys)
                {
                    count += _edgeSets[key].Count;
                }
                return count;
            }
        }

        #endregion


        #region [ Construction ]

        /// <summary>
        /// Creates a new chart, initializing it's internal data structure.
        /// </summary>
        public Chart() : this(new SortedDictionary<int, Collection<Edge>>()) { }

        /// <summary>
        /// Creates a new chart based on the specified chart.  The newly created chart
        /// contains all the edges as the specified chart at all the same indices.
        /// </summary>
        /// <param name="chart">The chart to base the newly created chart upon.</param>
        public Chart(Chart chart) : this(new SortedDictionary<int, Collection<Edge>>(chart._edgeSets)) { }

        /// <summary>
        /// Creates a new chart from the specified sorted map of indices mapped to edge sets.
        /// </summary>
        /// <param name="edgeSets">The map of integer-mapped edge sets to use as this chart's
        /// backing data structure.</param>
        private Chart(SortedDictionary<int, Collection<Edge>> edgeSets)
        {
            _edgeSets = edgeSets;
        }

        #endregion


        #region [ Public Methods ]

        /// <summary>
        /// Gets a sub chart of this chart.
        /// </summary>
        /// <param name="from">The low endpoint (inclusive) of the subchart.</param>
        /// <param name="to">The high endpoint (exclusive) of the subchart.</param>
        /// <returns>A new chart containing only the edge sets in this chart where from 
        /// is less than or equal to index and index is less than to.</returns>
        /// <exception cref="InvalidOperationException">Thrown if from is larger than to.</exception>
        public Chart GetSubChart(int from, int to)
        {
            if (from > to) throw new InvalidOperationException("from cannot be larger than to");

            SortedDictionary<int, Collection<Edge>> edgeSets = new SortedDictionary<int, Collection<Edge>>();
            foreach (int key in _edgeSets.Keys)
            {
                if (key >= from && key < to)
                {
                    edgeSets.Add(key, _edgeSets[key]);
                }
            }
            return new Chart(edgeSets);
        }

        /// <summary>
        /// Gets a head chart of this chart (a chart containing only the indices 
        /// from 0 to to.
        /// </summary>
        /// <param name="to">The high endpoint (exclusive) of the new chart.</param>
        /// <returns>A chart containing all the indices strictly less than to.</returns>
        public Chart GetHeadChart(int to)
        {
            SortedDictionary<int, Collection<Edge>> edgeSets = new SortedDictionary<int, Collection<Edge>>();
            foreach (int key in _edgeSets.Keys)
            {
                if (key < to)
                {
                    edgeSets.Add(key, _edgeSets[key]);
                }
            }
            return new Chart(edgeSets);
        }

        /// <summary>
        /// Gets a tail chart of this chart (a chart containing only the indices 
        /// from "from" to the size of it's indices.
        /// </summary>
        /// <param name="from">The low endpoint (inclusive) of the new chart.</param>
        /// <returns>A chart containing all of the indices greater than or equal to "from".</returns>
        public Chart GetTailChart(int from)
        {
            SortedDictionary<int, Collection<Edge>> edgeSets = new SortedDictionary<int, Collection<Edge>>();
            foreach (int key in _edgeSets.Keys)
            {
                if (key >= from)
                {
                    edgeSets.Add(key, _edgeSets[key]);
                }
            }
            return new Chart(edgeSets);
        }

        /// <summary>
        /// Tests whether this chart contains the specified edge.
        /// </summary>
        /// <param name="edge">The edge to test whether this chart contains.</param>
        /// <returns>True if this chart contains the specified edge at some index.</returns>
        public bool ContainsEdge(Edge edge)
        {
            return this.GetIndexOfEdge(edge) != Chart.NullIndex;
        }

        /// <summary>
        /// Gets the index of the specified edge in this chart.
        /// </summary>
        /// <param name="edge">The edge to find the index of.</param>
        /// <returns>The index of the specified edge, or -1 if the specified edge is null
        /// or is not contained in this chart.</returns>
        public int GetIndexOfEdge(Edge? edge)
        {
            if (edge == null) return Chart.NullIndex;
            foreach (int key in _edgeSets.Keys)
            {
                if (_edgeSets[key].Contains(edge)) return key;
            }
            return Chart.NullIndex;
        }

        /// <summary>
        /// Removes all edges from this map at all indices (if any are present)
        /// </summary>
        public void Clear()
        {
            _edgeSets.Clear();
        }

        /// <summary>
        /// Tests whether this chart contains any edges at a given string index.
        /// </summary>
        /// <param name="index">The string index to check for edges.</param>
        /// <returns>True if this chart contains an edge set at index.</returns>
        public bool ContainsEdgesAt(int index)
        {
            return _edgeSets.ContainsKey(index);
        }

        /// <summary>
        /// Gets the edges in this chart at a given index.
        /// </summary>
        /// <param name="index">The index to return edges for.</param>
        /// <returns>The set of edges this chart contains at index, or null
        /// if no edge set exists in this chart for the given index.  The 
        /// edge set returned by this method is not guaranteed to contain the 
        /// edges in the order in which they were added.  This method returns
        /// a read-only collection of edges.</returns>
        public ReadOnlyCollection<Edge>? GetEdgesAt(int index)
        {
            if (!_edgeSets.ContainsKey(index)) return null;
            return new ReadOnlyCollection<Edge>(_edgeSets[index]);
        }

        /// <summary>
        /// Adda an edge to this chart at the given index.  If no other
        /// edges exist in this chart at the same index, a new edge set is
        /// created before adding the edge.
        /// </summary>
        /// <param name="index">The index for edge.</param>
        /// <param name="edge">The edge to add.</param>
        /// <returns>True if this chart did not already contain edge at
        /// the given index.</returns>
        /// <exception cref="ArgumentNullException">Thrown if edge is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if index is less than zero.</exception>
        public bool AddEdge(int index, Edge? edge)
        {
            ArgumentNullException.ThrowIfNull(edge);
            if (index < 0) throw new ArgumentOutOfRangeException("index");

            if (!_edgeSets.ContainsKey(index))
            {
                Collection<Edge> edges = new Collection<Edge>();
                _edgeSets.Add(index, edges);
            }

            Collection<Edge> e = _edgeSets[index];
            if (e.Contains(edge))
            {
                return false;
            }
            else
            {
                e.Add(edge);
                return true;
            }
        }

        #endregion


        #region [ Object Overrides ]

        /// <summary>
        /// Tests whether this chart is equal to another by comparing their internal data structures.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True if the specified object is an instance of Chart ant it
        /// contains the same edges at the same indices as this chart.</returns>
        public override bool Equals(object? obj)
        {
            if (obj == this) return true;
            if (obj == null) return false;
            if (!(obj is Chart)) return false;
            Chart other = (Chart)obj;
            if (_edgeSets.Count != other._edgeSets.Count) return false;
            foreach (int key in _edgeSets.Keys)
            {
                if (!other._edgeSets.ContainsKey(key)) return false;
                if (_edgeSets[key].Count != other._edgeSets[key].Count) return false;
                for (int i = 0; i < _edgeSets[key].Count; i++)
                {
                    if (!_edgeSets[key][i].Equals(other._edgeSets[key][i])) return false;
                }
            }

            return true;
        }

        public bool Equals(Chart? other)
        {
            if (other == this) return true;
            if (other == null) return false;
            if (_edgeSets.Count != other._edgeSets.Count) return false;
            foreach (int key in _edgeSets.Keys)
            {
                if (!other._edgeSets.ContainsKey(key)) return false;
                if (_edgeSets[key].Count != other._edgeSets[key].Count) return false;
                for (int i = 0; i < _edgeSets[key].Count; i++)
                {
                    if (!_edgeSets[key][i].Equals(other._edgeSets[key][i])) return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Computes a hash code for this chart based on its internal data structure.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + _edgeSets.GetHashCode();
            return result;
        }

        /// <summary>
        /// Gets a string representation of this chart.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(String.Empty);
            foreach (int key in _edgeSets.Keys)
            {
                sb.Append("[" + key.ToString(CultureInfo.InvariantCulture) + ": ");
                if (_edgeSets[key].Count == 0)
                {
                    sb.Append("{}");
                }
                else
                {
                    sb.Append("{");
                    for (int i = 0; i < _edgeSets[key].Count; i++)
                    {
                        if (i == 0)
                        {
                            sb.Append(_edgeSets[key][i].ToString());
                        }
                        else
                        {
                            sb.Append(" " + _edgeSets[key][i].ToString());
                        }
                    }
                    sb.Append("}");
                }
                sb.Append("]");
            }
            return sb.ToString();
        }

        #endregion
    }
}
