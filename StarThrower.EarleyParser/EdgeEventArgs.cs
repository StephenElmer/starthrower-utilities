// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.EarleyParser
{
    /// <summary>
    /// Event data describing an edge that has been added to a parser's chart.
    /// </summary>
    public class EdgeEventArgs : EventArgs
    {
        private int _index;
        private Edge _edge;

        /// <summary>
        /// Gets the chart index (position within the string being parsed) at which the edge was added.
        /// </summary>
        public int Index
        {
            get { return _index; }
        }

        /// <summary>
        /// Gets the edge that was added.
        /// </summary>
        public Edge Edge
        {
            get { return _edge; }
        }

        /// <summary>
        /// Creates a new instance of edge event data for the specified edge and chart index.
        /// </summary>
        /// <param name="index">The chart index at which the edge was added.</param>
        /// <param name="edge">The edge that was added.</param>
        public EdgeEventArgs(int index, Edge edge)
        {
            _index = index;
            _edge = edge;
        }
    }
}
