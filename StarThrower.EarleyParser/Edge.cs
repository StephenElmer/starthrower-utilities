using System;
using System.Globalization;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StarThrower.EarleyParser
{
    /// <summary>
    /// An edge in a chart producted by an Earley parser.  Edges consist of a
    /// dotted rule paired with an origin position within a string.
    /// 
    /// An edge is either active or passive depending on how far
    /// processing has succeeded in the dotted rule.  When an edge is 
    /// passive, parsing has successfully completed the left side category
    /// at the edge's origin position within the string being parsed.
    /// 
    /// Edges can be created by prediction based on a grammar rule,
    /// or by scanning an input token that matches the active category of
    /// some edge's dotted rule.  An edge can also be completed based
    /// on another edge, allowing parse trees to trace the derivation of
    /// a string based on a grammar.
    /// 
    /// Upon creation, a completed edge advances the position of the
    /// edge's dotted rule by 1, but maintains the same origin position
    /// as the edge.  It also maintains backpointers to the edges that
    /// were used in completing the new edge.
    /// 
    /// Edges are immutable and cannot be altered once they have been
    /// instantiated.  In an Earley parser, edges are only ever added, 
    /// never removed or chnged.
    /// </summary>
    public class Edge
    {
        #region [ Private Instance Variables ]

        private readonly DottedRule _dottedRule;
        private readonly int _origin;
        private readonly ReadOnlyCollection<Edge> _bases;

        #endregion


        #region [ Public Properties ]

        /// <summary>
        /// Gets this edge's dotted rule, returning the dotted rule specified when this edge was constructed.
        /// </summary>
        public DottedRule DottedRule
        {
            get { return _dottedRule; }
        }

        /// <summary>
        /// Gets this edge's origin position, returning the origin posistion given for this edge during construction.
        /// </summary>
        public int Origin
        {
            get { return _origin; }
        }

        /// <summary>
        /// Gets the bases for completion of this edge, in order of insertion.  A completed edge
        /// inherits its bases from the edge from which it is created.
        /// If this edge was completed based on other edges, those edges are returned in their 
        /// order of insertion.  Otherwise, empty set is returned.
        /// </summary>
        public ReadOnlyCollection<Edge> Bases
        {
            get { return _bases; }
        }

        /// <summary>
        /// Tests whether this is a passive edge or not.  An edge is passive when it's dotted
        /// rule contains no active category.  Returns true if the active category of this edge's
        /// dotted rule is null.
        /// </summary>
        public bool IsPassive
        {
            get { return (_dottedRule.ActiveCategory == null); }
        }

        #endregion


        #region [ Construction ]

        /// <summary>
        /// Creates an edge containing the specified dotted rule at the 
        /// origin position given.
        /// </summary>
        /// <param name="dottedRule">The dotted rule at origin.</param>
        /// <param name="origin">The origin position within the string being parsed.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if origin is less than 0.</exception>
        public Edge(DottedRule dottedRule, int origin) : this(dottedRule, origin, null) { }

        /// <summary>
        /// Creates an edge for the specified dotted rule and origin position, 
        /// with the given set of edges as bases for it's completion.
        /// </summary>
        /// <param name="dottedRule"></param>
        /// <param name="origin"></param>
        /// <param name="bases">The set of bases, in order, that completed this edge.
        /// If this is null, the empty set is used.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if origin is less than 0.</exception>
        public Edge(DottedRule dottedRule, int origin, ReadOnlyCollection<Edge>? bases)
        {
            if (origin < 0) throw new ArgumentOutOfRangeException("origin");

            _dottedRule = dottedRule;
            _origin = origin;

            if (bases == null)
            {
                _bases = new ReadOnlyCollection<Edge>(new List<Edge>());
            }
            else
            {
                _bases = bases;
            }
        }

        #endregion


        #region [ Public Static Methods ]

        /// <summary>
        /// Makes a predicted edge based on the specified rule, with the
        /// specified origin position.
        /// </summary>
        /// <param name="rule">The rule to construct a predicted edge for.</param>
        /// <param name="origin">The origin position of the newly predicted edge.</param>
        /// <returns>A new edge whose dotted rule is the specified rule at position 0.  The new edge's origin is the specified origin.</returns>
        /// <exception cref="ArgumentNullException">Thrown if rule is null.</exception>
        public static Edge PredictFor(Rule? rule, int origin)
        {
            ArgumentNullException.ThrowIfNull(rule);
            return new Edge(new DottedRule(rule), origin);
        }

        /// <summary>
        /// Creates an edge based on the given edge and the token that 
        /// was just scanned.
        /// </summary>
        /// <param name="edge">The edge whose active category is the just-scanned token.</param>
        /// <param name="token">The just-scanned token.</param>
        /// <returns>A new edge just like the specified edge (including origin), but with its rule's dot position advanced by one.
        /// The new edge's bases incorporates the old edge and all of it's bases.</returns>
        /// <exception cref="ArgumentNullException">Thrown if edge or token is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown in any of the following cases:
        /// The specified edge is passive.
        /// The specified edge's dotted rule's active category is not a terminal.
        /// The edge's rule's active category's name is not equal to the scanned token.
        /// </exception>
        public static Edge Scan(Edge? edge, string? token)
        {
            ArgumentNullException.ThrowIfNull(edge);
            ArgumentNullException.ThrowIfNull(token);
            if (edge.IsPassive) throw new InvalidOperationException("passive edge");

            DottedRule dr = edge.DottedRule;
            Category? activeCategory = dr.ActiveCategory;
            if (activeCategory == null) throw new InvalidOperationException("edge has no active category: " + edge.ToString());
            if (!activeCategory.IsTerminal) { throw new InvalidOperationException("edge's active category is nonterminal: " + edge.ToString()); }
            if (String.Compare(activeCategory.Name, token, StringComparison.OrdinalIgnoreCase) != 0) { throw new InvalidOperationException("token " + token + " incompatible with " + edge.ToString()); }


            //TODO: not so sure about the order of this.  The Java version is expressed as per this commented out code,
            //      but the ReadOnlyCollection in C# complains, so I reworked it as per the uncommented
            //      code below
            //Edge scanEdge = new Edge(DottedRule.AdvanceDot(dr), edge.Origin);
            //scanEdge.Bases = new ReadOnlyCollection<Edge>(Edge.AddBasisEdge(edge, edge));
            //return scanEdge;
            Edge scanEdge = new Edge(DottedRule.AdvanceDot(dr), edge.Origin, new ReadOnlyCollection<Edge>(Edge.AddBasisEdge(edge, edge)));
            return scanEdge;
        }

        /// <summary>
        /// Completes the specified edge based on the specified basis.
        /// </summary>
        /// <param name="toComplete">The edge to complete.</param>
        /// <param name="basis">The basis on which this edge is being completed.  This edge will be added
        /// to the set of bases already in the edge, if any are present.</param>
        /// <returns>A new edge exactly like this one, except that it's dotted rule's position is advanced
        /// by 1 and it's bases contains basis.</returns>
        /// <exception cref="ArgumentNullException">Thrown if toComplete or basis is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the specified basis is not a suitable
        /// edge for completing this edge.  Reasons for this exception are that the basis edge:
        ///     has a dotted rule whose position is 0, (meaning that no completion has actually taken place)
        ///     has a dotted rule whose left category does not equal this edge's dotted rule's active category.
        /// </exception>
        public static Edge Complete(Edge? toComplete, Edge? basis)
        {
            ArgumentNullException.ThrowIfNull(toComplete);
            if (toComplete.IsPassive) throw new InvalidOperationException("attempt to complete passive edge: " + toComplete.ToString());
            ArgumentNullException.ThrowIfNull(basis);
            if (!basis.IsPassive) throw new InvalidOperationException("basis is active: " + basis.ToString());
            if (basis.DottedRule.Position == 0 || !basis.DottedRule.Left.Equals(toComplete.DottedRule.ActiveCategory)) { throw new InvalidOperationException(toComplete.ToString() + " is NotFiniteNumberException completed by basis " + basis.ToString()); }

            Collection<Edge> newBases = Edge.AddBasisEdge(toComplete, basis);

            return new Edge(DottedRule.AdvanceDot(toComplete.DottedRule), toComplete.Origin, new ReadOnlyCollection<Edge>(newBases));
        }

        /// <summary>
        /// Helper for Scan() and Complete()
        /// </summary>
        /// <param name="edge"></param>
        /// <param name="basis"></param>
        /// <returns></returns>
        private static Collection<Edge> AddBasisEdge(Edge edge, Edge basis)
        {
            Collection<Edge> newBases;
            if (edge.Bases.Count == 0)
            {
                newBases = new Collection<Edge>();
                newBases.Add(basis);
            }
            else
            {
                newBases = new Collection<Edge>();
                foreach (Edge e in edge.Bases)
                {
                    newBases.Add(e);
                }
                newBases.Add(basis);
            }
            return newBases;
        }

        #endregion


        #region [ Object Overrides ]

        public override bool Equals(object? obj)
        {
            if (obj == this) return true;
            if (obj == null) return false;
            if (!(obj is Edge)) return false;
            Edge other = (Edge)obj;
            if (_origin != other._origin) return false;
            if (!_dottedRule.Equals(other._dottedRule)) return false;
            if (_bases.Count != other._bases.Count) return false;
            for (int i = 0; i < _bases.Count; i++)
            {
                if (!_bases[i].Equals(other._bases[i])) return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + _origin.GetHashCode();
            result = 31 * result + _dottedRule.GetHashCode();
            result = 31 * result + _bases.GetHashCode();
            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(_origin.ToString(CultureInfo.InvariantCulture));
            sb.Append('[');
            sb.Append(_dottedRule.ToString());
            sb.Append(']');
            return sb.ToString();
        }

        #endregion
    }
}
