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
    /// Represents a parse comleted by an Earley parser.
    /// 
    /// A parse contains the string list of tokens parsed, the
    /// seed category and completed chart.  The status of the completed
    /// parse can also be determined.
    /// 
    /// Parse trees can be retrieved for any category in the parse at a
    /// given string index and origin position.  Parse trees allow the
    /// fully derived parse trees for the seed category to be obtained
    /// using ParseTrees().  For a parse of a string using a grammar
    /// that permits structural or lexical ambiguity, the methods for 
    /// fetching parse trees will return sets that contain more than one 
    /// element.
    /// </summary>
    public class Parse
    {
        #region [ Private Instance Variables ]

        private Collection<string> _tokens;
        private Category _seed;
        private Chart _chart;
        private bool _error;
        private Collection<ParseTree>? _parseTrees;

        #endregion


        #region [ Public Properties ]

        /// <summary>
        /// Gets the seed category for this parse.
        /// </summary>
        public Category Seed
        {
            get { return _seed; }
        }

        /// <summary>
        /// Gets the completed chart for this parse.
        /// </summary>
        public Chart Chart
        {
            get { return _chart; }
        }

        /// <summary>
        /// Gets the status of this parse.  A parse accepts a string when its completed
        /// chart contains an edge where the following conditions hold:
        ///     its index is the last index in the chart,
        ///     it is passive,
        ///     its origin is the beginning of the string (position 0), and
        ///     the left side of its dotted rule is the same as the start category that seeded the parse.
        ///    
        /// Returns Status.Accept for accepted strings, Status.Reject for rejected ones.
        /// Status.Error is returned if an error occurred durign the parse.
        /// </summary>
        public Status Status
        {
            get
            {
                if (_error)
                {
                    return Status.Error;
                }
                else
                {
                    if (GetCompletedEdges(Category.Root, 0, _tokens.Count).Count == 0)
                    {
                        return Status.Reject;
                    }
                    else
                    {
                        return Status.Accept;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the completed parse trees for the seed category spanning the entire
        /// input string.  This method returns valid derivations (if any) that the
        /// parse found for the seed category.
        /// 
        /// Returns a set of parse trees for the seed category spanning the entire 
        /// string, or the empty set if none were derivable.  In the case that the
        /// grammar used in this parse permits ambiguity for the string parsed,
        /// this set will contain more than one member.  If this parse's status 
        /// is Status.Error, the empty set is returned.
        /// </summary>
        public Collection<ParseTree> ParseTrees
        {
            get
            {
                if (_parseTrees == null)
                {
                    if (_error)
                    {
                        _parseTrees = new Collection<ParseTree>();
                    }
                    else
                    {
                        _parseTrees = GetParseTreesFor(Category.Root, 0, _tokens.Count);
                    }
                }
                return _parseTrees;
            }
        }

        #endregion


        #region [ Construction ]

        /// <summary>
        /// Creates a new parse for the given seed category and chart.  This constructor
        /// is used for the parses that complete without errors.
        /// </summary>
        /// <param name="seed"></param>
        /// <param name="chart"></param>
        public Parse(Category seed, Chart chart) : this(seed, chart, false) { }

        /// <summary>
        /// Creates a new parse for the given seed category, chart, and error status.
        /// </summary>
        /// <param name="seed">The seed category for this parse.</param>
        /// <param name="chart">The completed chart for this parse.</param>
        /// <param name="error">Whether an error occurred while parsing.</param>
        private Parse(Category seed, Chart chart, bool error)
        {
            _seed = seed;
            _chart = chart;
            _error = error;
            _tokens = new Collection<string>();
        }

        #endregion


        #region [ Private Methods ]

        private Collection<Edge> GetCompletedEdges(Category category, int origin, int index)
        {
            ReadOnlyCollection<Edge>? edges = _chart.GetEdgesAt(index);
            if (edges == null || edges.Count == 0)
            { // any edges at this index?
                return new Collection<Edge>();
            }

            Collection<Edge> es = new Collection<Edge>();

            foreach (Edge e in edges)
            {
                if (e.Origin == origin && e.IsPassive && e.DottedRule.Left.Equals(category))
                {
                    es.Add(e);
                }
            }

            return es;
        }

        #endregion


        #region [ Public Methods ]

        public void AddToken(string token)
        {
            _tokens.Add(token);
        }

        /// <summary>
        /// Gets a parse tree corresponding to the given edge.
        /// </summary>
        /// <param name="edge">The edge to find a parse tree for.</param>
        /// <returns>The parse tree corresponding to the specified edge.  If 
        /// the edge is not contained in this parse's chart, returns null.  The
        /// parse tree returned will be the same as calling ParseTree.NewParseTree(edge);</returns>
        /// <exception cref="ArgumentNullException">Thrown if edge is null.</exception>
        public ParseTree? GetParseTreeFor(Edge? edge)
        {
            ArgumentNullException.ThrowIfNull(edge);

            if (!_chart.ContainsEdge(edge)) return null;
            return ParseTree.NewParseTree(edge);
        }

        /// <summary>
        /// Gets the parse trees derived during this parse with the specified category
        /// as their parent's left side.  This parse's chart must contain a completed
        /// edge at the specified index that starts at the specified origin with the 
        /// correct category as its left side.
        /// 
        /// For example, the string "Mary saw her duck" parsed using the tiny grammar
        ///  will produce a parse that contains two subtrees for the category "VP" at
        ///  origin position 1 and index 4.  This is because the derived "VP" categories
        ///  for "saw her duck" both start at 1 and end at 4.  To retrieve these 
        ///  subtrees from the parse, use Parse.GetParseTreesFor(VP, 1, 4) where VP 
        ///  represents an instance of Category whose name is "VP".
        /// </summary>
        /// <param name="category">The category of the parse tree's parent.  This is the left side of the edge's dotted rule.</param>
        /// <param name="origin">The origin position of the edge to find parse trees for.</param>
        /// <param name="index">The string index position of the edge to find parse trees for.  This
        /// is the end position of the subtree.</param>
        /// <returns>A set of parse trees for the given category at the given origin and string index position, 
        /// or the empty set if no edges match.</returns>
        /// <exception cref="ArgumentNullException">Thrown if category is null.</exception>
        public Collection<ParseTree> GetParseTreesFor(Category? category, int origin, int index)
        {
            ArgumentNullException.ThrowIfNull(category);

            Collection<ParseTree> trees = new Collection<ParseTree>();
            foreach (Edge e in GetCompletedEdges(category, origin, index))
            {
                trees.Add(ParseTree.NewParseTree(e));
            }
            return trees;
        }

        #endregion


        #region [ Object Overrides ]

        /// <summary>
        /// Tests whether this parse equals another by comparing their tokens,
        /// seed categories, and completed charts, returning true if the given
        /// object is an instance of Parse and its tokens, seed category, and 
        /// chart are equal to those of this parse.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (obj == this) return true;
            if (obj == null) return false;
            if (!(obj is Parse)) return false;
            Parse other = (Parse)obj;
            if (_error != other._error) return false;
            if (!_seed.Equals(other._seed)) return false;
            if (!_chart.Equals(other._chart)) return false;
            if ((_parseTrees == null) != (other._parseTrees == null)) return false;
            if (_parseTrees != null)
            {
                if (other._parseTrees == null || _parseTrees.Count != other._parseTrees.Count) return false;
                for (int i = 0; i < _parseTrees.Count; i++)
                {
                    if (!_parseTrees[i].Equals(other._parseTrees[i])) return false;
                }
            }
            if (_tokens.Count != other._tokens.Count) return false;
            for (int i = 0; i < _tokens.Count; i++)
            {
                if (!_tokens[i].Equals(other._tokens[i], StringComparison.Ordinal)) return false;
            }

            return true;
        }

        public bool Equals(Parse? other)
        {
            if (other == this) return true;
            if (other == null) return false;
            if (_error != other._error) return false;
            if (!_seed.Equals(other._seed)) return false;
            if (!_chart.Equals(other._chart)) return false;
            if ((_parseTrees == null) != (other._parseTrees == null)) return false;
            if (_parseTrees != null)
            {
                if (other._parseTrees == null || _parseTrees.Count != other._parseTrees.Count) return false;
                for (int i = 0; i < _parseTrees.Count; i++)
                {
                    if (!_parseTrees[i].Equals(other._parseTrees[i])) return false;
                }
            }
            if (_tokens.Count != other._tokens.Count) return false;
            for (int i = 0; i < _tokens.Count; i++)
            {
                if (!_tokens[i].Equals(other._tokens[i], StringComparison.Ordinal)) return false;
            }

            return true;
        }

        /// <summary>
        /// Computes a hash code for this parse based on its tokens, seed category, and chart.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int result = 17;
            if (_tokens != null)
            {
                result = 31 * result + _tokens.GetHashCode();
            }
            if (_seed != null)
            {
                result = 31 * result + _seed.GetHashCode();
            }
            if (_chart != null)
            {
                result = 31 * result + _chart.GetHashCode();
            }
            return result;
        }

        /// <summary>
        /// Gets a string representation of this chart, returning "Accept: S -> [the, boy, left] (1)" for
        /// an accepted parse of "the boy left" with seed category S and one posible parse tree.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            Status status = this.Status;
            StringBuilder sb = new StringBuilder(String.Empty);
            sb.Append(status.ToString());
            sb.Append(": ");
            sb.Append(_seed.ToString());
            sb.Append(" -> ");
            for (int i = 0; i < _tokens.Count; i++)
            {
                if (i == 0)
                {
                    sb.Append(_tokens[i]);
                }
                else
                {
                    sb.Append(" " + _tokens[i]);
                }
            }
            if (status == Status.Accept)
            {
                sb.Append(" (");
                sb.Append(this.ParseTrees.Count.ToString(CultureInfo.InvariantCulture));
                sb.Append(")");
            }
            return sb.ToString();
        }

        #endregion
    }
}
