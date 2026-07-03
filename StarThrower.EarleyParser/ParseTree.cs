// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Text;
using System.Collections.ObjectModel;

namespace StarThrower.EarleyParser
{
    /// <summary>
    /// A parse tree that represents the derivation of a string based on the
    /// rules in a grammar.  Parse trees recursively contain other parse
    /// trees, so they can be iterated throught to find the entire
    /// derivation of a category.  A parse tree can also be traversed 
    /// upward by calling Parent for each successive parse tree until
    /// it returns null.
    /// 
    /// Parse trees are essentially partial views of a chart from a given
    /// edge or category.  They represent the completed categories at a
    /// given string index and origin position.  The special Root category
    /// is not included in a parse tree at the root (only categories that
    /// are actually specified in the corresponding grammar are represented).
    /// </summary>
    public class ParseTree
    {
        #region [ Private Instance Variables ]

        private Category _node;
        private ParseTree? _parent;
        private Collection<ParseTree>? _children;

        #endregion


        #region [ Public Properties ]

        /// <summary>
        /// Gets the node category of this parse tree, returning "NP" for a subtree "NP -> Det N"
        /// </summary>
        public Category Node
        {
            get { return _node; }
        }

        /// <summary>
        /// Gets the parent parse tree, if any, returning a parse tree containing (for example)
        /// "S -> NP VP" if this parse tree's node is "NP" and is one of the children of "S".
        /// If this parse tree is the root node in a series of parse trees, null is returned.
        /// </summary>
        public ParseTree? Parent
        {
            get { return _parent; }
        }

        /// <summary>
        /// Gets the child parse trees of this parse tree, retaining their linear ordering,
        /// returning for a subtree "NP -> Det N", an array that contains parse trees
        /// whose node is "Det, N" in that order, or null if this parse tree has no children.
        /// </summary>
        public Collection<ParseTree>? Children
        {
            get { return _children; }
        }

        #endregion


        #region [ Construction ]

        /// <summary>
        /// Creates a new parse tree with the specified category and parent parse tree.
        /// </summary>
        /// <param name="node">The category of the node of this parse tree.</param>
        /// <param name="parent">This parse tree's parent tree, or null if this parse
        /// tree is the root node.</param>
        public ParseTree(Category node, ParseTree? parent) : this(node, parent, null) { }

        /// <summary>
        /// Creates a new parse tree with the specified category, parent, and child trees.
        /// </summary>
        /// <param name="node">The category of the node of this parse tree.</param>
        /// <param name="parent">This parse tree's parent tree, or null if this parse
        /// tree is the root node.</param>
        /// <param name="children">The list of children of this parse tree, in their
        /// linear order.</param>
        public ParseTree(Category node, ParseTree? parent, Collection<ParseTree>? children)
        {
            _node = node;
            _parent = parent;
            _children = children;
        }

        #endregion


        #region [ Public Static Methods ]

        /// <summary>
        /// Creates a parse tree based on the specified edge that is the root of the
        /// resulting parse tree.
        /// </summary>
        /// <param name="edge">The edge that is to be at the root of the parse tree.</param>
        /// <returns>Returns the result of calling NewParseTree(Edge, ParseTree) with 
        /// null as the argument for the parent parse tree.</returns>
        public static ParseTree NewParseTree(Edge edge)
        {
            return ParseTree.NewParseTree(edge, null);
        }

        /// <summary>
        /// Creates a new parse tree based on the specified edge and parent tree.
        /// </summary>
        /// <param name="edge">The edge to use to create a parse tree.  For a parse
        /// tree that is the root, this should be null.</param>
        /// <param name="parent">The parent tree of the new parse tree.</param>
        /// <returns>A new parse tree whose node is the specified edge's dotted rule's
        /// left side and whose children are based on the bases of the specified edge.</returns>
        public static ParseTree NewParseTree(Edge edge, ParseTree? parent)
        {
            Edge e;
            ParseTree? parentTree;

            if (edge.DottedRule.Left.Equals(Category.Root))
            {
                //first child if Root
                e = edge.Bases[0];
                parentTree = null;
            }
            else
            {
                e = edge;
                parentTree = (parent != null && parent.Node.Equals(Category.Root) ? null : parent);
            }

            DottedRule dr = e.DottedRule;
            ParseTree newTree;

            if (e.IsPassive) //basis from a completion?
            {
                int basisCount = e.Bases.Count;
                Collection<ParseTree>? children = basisCount > 0 ? new Collection<ParseTree>() : null;
                newTree = new ParseTree(dr.Left, parentTree, children);
                if (basisCount > 0 && children != null)
                {
                    foreach (Edge ed in e.Bases)
                    {
                        children.Add(ParseTree.NewParseTree(ed, newTree));
                    }
                }
            }
            else //from a scan
            {
                Category? activeCategory = dr.ActiveCategory;
                if (activeCategory == null) throw new InvalidOperationException("non-passive edge has no active category");
                newTree = new ParseTree(activeCategory, parentTree, null);
            }
            return newTree;
        }

        #endregion


        #region [ Object Overrides ]

        /// <summary>
        /// Tests whether this parse tree is equal to another by comparing
        /// it's node, parent, and child parse trees.
        /// </summary>
        /// <param name="obj">The object to test.</param>
        /// <returns>True if the objects are equivalent.</returns>
        public override bool Equals(object? obj)
        {
            if (obj == this) return true;
            if (obj == null) return false;
            if (!(obj is ParseTree)) return false;
            ParseTree other = (ParseTree)obj;

            if (!_node.Equals(other._node)) return false;
            if ((_parent == null) != (other._parent == null)) return false;
            if (_parent != null && other._parent != null && !_parent.Node.Equals(other._parent.Node)) return false;
            if ((_children == null) != (other._children == null)) return false;
            if (_children != null && other._children != null)
            {
                if (_children.Count != other._children.Count) return false;
                for (int i = 0; i < _children.Count; i++)
                {
                    if (!_children[i].Equals(other._children[i])) return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Tests whether this parse tree is equal to another by comparing
        /// it's node, parent, and child parse trees.
        /// </summary>
        /// <param name="other">The parse tree to test.</param>
        /// <returns>True if the parse trees are equivalent.</returns>
        public bool Equals(ParseTree? other)
        {
            if (other == this) return true;
            if (other == null) return false;

            if (!_node.Equals(other._node)) return false;
            if ((_parent == null) != (other._parent == null)) return false;
            if (_parent != null && other._parent != null && !_parent.Node.Equals(other._parent.Node)) return false;
            if ((_children == null) != (other._children == null)) return false;
            if (_children != null && other._children != null)
            {
                if (_children.Count != other._children.Count) return false;
                for (int i = 0; i < _children.Count; i++)
                {
                    if (!_children[i].Equals(other._children[i])) return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Computes a hash code for this parse tree based on its node, parent, and child
        /// parse trees.
        /// </summary>
        /// <returns>A hash code.</returns>
        //TODO: #8 — hashes _parent recursively (full ancestor chain) while Equals only compares _parent.Node shallowly
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + _node.GetHashCode();
            if (_parent != null)
            {
                result = 31 * result + _parent.GetHashCode();
            }
            if (_children != null)
            {
                result = 31 * result + _children.GetHashCode();
            }
            return result;
        }

        /// <summary>
        /// Gets a string representation of this parse tree.
        /// </summary>
        /// <returns>For the string "the boy left", possibly something like: "[S[NP[Det[the]][N[boy]]][VP[left]]]"
        /// (the actual string would depend on the grammar rules in effect for the parse).</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(String.Empty);
            sb.Append('[');
            sb.Append(_node.ToString());
            if (_children != null)
            {
                foreach (ParseTree child in _children)
                {
                    sb.Append(child.ToString());
                }
            }
            sb.Append(']');
            return sb.ToString();
        }

        #endregion
    }
}
