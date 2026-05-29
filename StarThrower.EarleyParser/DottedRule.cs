using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StarThrower.EarleyParser
{
    /// <summary>
    /// Estension of Rule that maintains a dot position within the rule.
    /// 
    /// Dotted rules are used by Earley parsers to keep track of how far
    /// within a rule processing has succeeded.  In a dotted rule, the
    /// active category is the first category after the dot position,
    /// and is null when processing has fully covered the underlying rule.
    /// Edges test the active category of dotted rules to determine
    /// when an edge is active or passive.
    /// </summary>
    public class DottedRule : Rule
    {
        #region [ Private Instance Variables ]

        private int _position;
        private Category? _activeCategory;

        #endregion


        #region [ Public Properties ]

        /// <summary>
        /// Gets the dot position within the underlying rule's right
        /// side category sequence.  Returns the dot position that
        /// was specified for this dotted rule when it was constructed.
        /// </summary>
        public int Position
        {
            get { return _position; }
        }

        /// <summary>
        /// Gets the active category in the underlying rule, if any.
        /// Returns the category at this dotted rule's dot position in
        /// the underlying rule's right side category sequence.  If this
        /// rule's dot position is already at the end of the right side
        /// category sequence, returns null.
        /// </summary>
        public Category? ActiveCategory
        {
            get { return _activeCategory; }
        }

        #endregion


        #region [ Construction ]

        /// <summary>
        /// Creates a new dotted rule for the given rule, with a dot position
        /// at the beginning of the rule's right side (position 0).
        /// </summary>
        /// <param name="rule"></param>
        public DottedRule(Rule rule) : this(rule, 0) { }

        /// <summary>
        /// Creates a dotted rule maintaining the dot position within the right side
        /// category sequence of the underlying rule.
        /// </summary>
        /// <param name="rule">The underlying rule</param>
        /// <param name="position">The zero-based position within rule right
        /// side categories where this dotted rule's dot is maintinated.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if position less than 0 or
        /// position is greater than the length of the right side sequence in rule.</exception>
        public DottedRule(Rule rule, int position)
            : base(rule.Left, rule.Right)
        {
            if (position < 0 || position > this.Right.Count) throw new ArgumentOutOfRangeException("position");

            _position = position;

            //determine active category
            if (position < this.Right.Count)
            {
                _activeCategory = this.Right[position];
            }
            else
            {
                _activeCategory = null;
            }
        }

        #endregion


        #region [ Public Static Methods ]

        /// <summary>
        /// Creates and returns a new dotted rule exactly like the one provided
        /// except that it's dot position is advanced by 1.
        /// </summary>
        /// <param name="dottedRule">The dotted rule whose dot position should be advanced.</param>
        /// <returns>A new dotted rule wrapping this rule with it's position incremented.</returns>
        /// <exception cref="ArgumentOfRangeException">Thrown if the dotted rule's dot 
        /// position is already at the end of it's right side.</exception>
        public static DottedRule AdvanceDot(DottedRule dottedRule)
        {
            return new DottedRule(dottedRule, dottedRule.Position + 1);
        }

        /// <summary>
        /// Creates a new start rule for a given seed category.
        /// </summary>
        /// <param name="seed">The seed category to use.</param>
        /// <returns>A dotted rule that has the special start rule on 
        /// the left and the specified seed on the right.  This method 
        /// is used by Earley parsers for seeding.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the seed category is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the seed category is a terminal.</exception>
        public static DottedRule CreateStartRule(Category? seed)
        {
            ArgumentNullException.ThrowIfNull(seed);
            if (seed.IsTerminal) throw new InvalidOperationException("seed is a terminal: " + seed.ToString());

            List<Category> l = new List<Category>();
            l.Add(seed);
            ReadOnlyCollection<Category> seeds = new ReadOnlyCollection<Category>(l);
            return new DottedRule(new Rule(Category.Root, seeds), 0);
        }

        #endregion


        #region [ Object Overrides ]

        /// <summary>
        /// Tests whether this dotted rule is equal to another dotted
        /// rule by comparing their underlying rules and dot positions.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True if the specified object is an instance of DottedRule
        /// and it's underlying rule and position are equal to this dotted rule's rule and position.</returns>
        public override bool Equals(object? obj)
        {
            if (obj == this) return true;
            if (obj == null) return false;
            if (!(obj is DottedRule)) return false;
            DottedRule other = (DottedRule)obj;
            return _position == other._position &&
                //TODO: should we be looking at activeCategory here, too?
                //_activeCategory.Equals(other._activeCategory) &&
                base.Equals(other);
        }

        public bool Equals(DottedRule? other)
        {
            if (other == this) return true;
            if (other == null) return false;
            return _position == other._position &&
                //TODO: should we be looking at activeCategory here, too?
                //_activeCategory.Equals(other._activeCategory) &&
                base.Equals(other);
        }

        /// <summary>
        /// Computes a hash code for this dotted rule based on it's underlying
        /// rule and dot position.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + _position.GetHashCode();
            result = 31 * result + base.GetHashCode();
            return result;
        }

        /// <summary>
        /// Gets a string representation of this dotted rule.
        /// </summary>
        /// <returns>Returns "S -> NP * VP" for a dotted rule with
        /// an underlying rule S -> NP VP and a dot position of 1.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(String.Empty);
            sb.Append(this.Left.ToString());
            sb.Append(" ->");
            for (int i = 0; i <= this.Right.Count; i++)
            {
                if (i == _position)
                {
                    sb.Append(" *");
                }

                if (i < this.Right.Count)
                {
                    sb.Append(" ");
                    sb.Append(this.Right[i].ToString());
                }
            }
            return sb.ToString();
        }

        #endregion
    }
}
