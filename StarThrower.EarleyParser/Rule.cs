using System;
using System.Text;
using System.Collections.ObjectModel;

namespace StarThrower.EarleyParser
{
    /// <summary>
    /// Represents a production rule in a context-free grammar.
    /// 
    /// Rules contain a single category on the left side that produces the series
    /// of categories on the right side.  Rules that license empty productions
    /// (have an empty right side) can be specified with a rule that has a right
    /// side of length 1 whose member is an empty string.  A rule that contains 
    /// a terminal on the right side must contain only that terminal.
    /// 
    /// Rules are immutable and cannot be changed once instantiated.
    /// </summary>
    public class Rule
    {
        #region [ Private Instance Variables ]

        private readonly Category _left;
        private readonly ReadOnlyCollection<Category> _right;

        #endregion


        #region [ Public Properties ]

        /// <summary>
        /// Gets the left side category of this rule.
        /// </summary>
        public Category Left
        {
            get { return _left; }
        }

        /// <summary>
        /// Gets the series of categories on the right side of this rule.
        /// </summary>
        public ReadOnlyCollection<Category> Right
        {
            get { return _right; }
        }

        /// <summary>
        /// Tests whether this rule is a pre-terminal production rule.  A rule is
        /// a preterminal rule if its right side contains a terminal category.
        /// </summary>
        public bool IsPreterminal
        {
            get
            {
                foreach (Category c in _right)
                {
                    if (c.IsTerminal) return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Tests whether this rule is a pre-terminal with a right side that contains only 1 category.
        /// </summary>
        public bool IsSingletonPreterminal
        {
            get { return (_right.Count == 1 && this.IsPreterminal); }
        }

        #endregion


        #region [ Construction ]

        /// <summary>
        /// Creates a new rule with the specified left side category and series
        /// of categories on the right side.
        /// </summary>
        /// <param name="left">The left side (trigger) for this production rule.</param>
        /// <param name="right">The right side (productions) licensed for this rule's left side.</param>
        /// <exception cref="ArgumentNullException">Thrown if left or right is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if left is terminal, or if right is empty or contains a null category.</exception>
        public Rule(Category left, ReadOnlyCollection<Category> right)
        {
            if (left == null) throw new ArgumentNullException("left");
            if (left.IsTerminal) throw new InvalidOperationException("left Category is terminal.");
            if (right == null) throw new ArgumentNullException("right");
            if (right.Count == 0) throw new InvalidOperationException("no right Categories.");
            foreach (Category c in right)
            {
                if (c == null) throw new InvalidOperationException("right contains a null Category: " + right.ToString());
            }

            _left = left;
            _right = right;
        }

        #endregion


        #region [ Object Overrides ]

        /// <summary>
        /// Tests whether this rule is equal to another, with teh same left and right sides.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == this) return true;
            if (obj == null) return false;
            if (!(obj is Rule)) return false;
            Rule other = (Rule)obj;
            if (!_left.Equals(other._left)) return false;
            if (_right.Count != other._right.Count) return false;
            for (int i = 0; i < _right.Count; i++)
            {
                if (!_right[i].Equals(other._right[i])) return false;
            }

            return true;
        }

        public bool Equals(Rule other)
        {
            if (other == this) return true;
            if (other == null) return false;
            if (!_left.Equals(other._left)) return false;
            if (_right.Count != other._right.Count) return false;
            for (int i = 0; i < _right.Count; i++)
            {
                if (!_right[i].Equals(other._right[i])) return false;
            }

            return true;
        }

        /// <summary>
        /// Computes a hash code for this rule based on its left and right side categories.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + _left.GetHashCode();
            result = 31 * result + _right.GetHashCode();
            return result;
        }

        /// <summary>
        /// Gets a string representation of this rule expressed as "S -> NP VP" for a rule
        /// with left side category of S and a right side sequence of [NP, VP].
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(_left.ToString());
            sb.Append(" ->");
            for (int i = 0; i < _right.Count; i++)
            {
                sb.Append(" ");
                sb.Append(_right[i].ToString());
            }
            return sb.ToString();
        }

        #endregion
    }
}
