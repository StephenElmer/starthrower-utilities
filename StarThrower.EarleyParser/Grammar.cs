// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StarThrower.EarleyParser
{
    /// <summary>
    /// A named collection of production rules, grouped by their left-hand-side category, that
    /// together define a context-free grammar for use by an Earley parser.
    /// </summary>
    public class Grammar
    {
        #region [ Private Instance Variables ]

        private string _name;
        private Dictionary<Category, Collection<Rule>> _rules;

        #endregion


        #region [ Public Properties ]

        /// <summary>
        /// Gets the name of this grammar which was set during construction.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        #endregion


        #region [ Construction ]

        /// <summary>
        /// Creates a new, empty grammar with the specified name.
        /// </summary>
        /// <param name="name">The name of the new grammar.</param>
        public Grammar(string name)
        {
            _name = name;
            _rules = new Dictionary<Category, Collection<Rule>>();
        }

        #endregion


        #region [ Public Methods ]

        /// <summary>
        /// Adds a rule to this grammar, grouped under its left-hand-side category.
        /// </summary>
        /// <param name="rule">The rule to add.</param>
        /// <exception cref="ArgumentNullException">Thrown if rule is null.</exception>
        public void AddRule(Rule? rule)
        {
            ArgumentNullException.ThrowIfNull(rule);

            if (_rules.TryGetValue(rule.Left, out Collection<Rule>? value))
            {
                value.Add(rule);
            }
            else
            {
                Collection<Rule> rules = new Collection<Rule>();
                rules.Add(rule);
                _rules.Add(rule.Left, rules);
            }
        }

        /// <summary>
        /// Determines whether this grammar contains any rules whose left-hand side is the
        /// specified category.
        /// </summary>
        /// <param name="left">The left-hand-side category to look for.</param>
        /// <returns>True if at least one rule with this left-hand-side category has been added.</returns>
        public bool ContainsRules(Category left)
        {
            return _rules.ContainsKey(left);
        }

        /// <summary>
        /// Gets all rules whose left-hand side is the specified category.
        /// </summary>
        /// <param name="left">The left-hand-side category to look up.</param>
        /// <returns>The rules with this left-hand-side category.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if no rule with this left-hand-side category has been added. Check with <see cref="ContainsRules"/> first if this is not guaranteed.</exception>
        public Collection<Rule> GetRules(Category left)
        {
            return _rules[left];
        }

        /// <summary>
        /// Gets every rule that has been added to this grammar, regardless of left-hand-side category.
        /// </summary>
        /// <returns>All rules in this grammar.</returns>
        public Collection<Rule> GetAllRules()
        {
            Collection<Rule> result = new Collection<Rule>();
            foreach (Category c in _rules.Keys)
            {
                foreach (Rule r in _rules[c])
                {
                    result.Add(r);
                }
            }
            return result;
        }

        /// <summary>
        /// Finds a singleton preterminal rule (a rule whose right-hand side is a single terminal
        /// category) under the specified left-hand-side category whose terminal name matches the
        /// given token.
        /// </summary>
        /// <param name="left">The left-hand-side category to search under.</param>
        /// <param name="token">The literal token text to match against each candidate rule's terminal.</param>
        /// <param name="ignoreCase">Whether the token match should ignore case.</param>
        /// <returns>The matching rule, or null if no rule with this left-hand-side category is a singleton preterminal matching token.</returns>
        public Rule? SingletonPreterminal(Category left, string token, bool ignoreCase)
        {
            if (_rules.TryGetValue(left, out Collection<Rule>? value))
            {
                foreach (Rule r in value)
                {
                    StringComparison sc = (ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
                    if (r.IsSingletonPreterminal && (string.Equals(r.Right[0].Name, token, sc)))
                    {
                        return r;
                    }
                }
            }
            return null;
        }

        #endregion


        #region [ Object Overrides ]

        /// <summary>
        /// Tests whether this grammar is equal to another, with the same name and the same
        /// set of rules under each left-hand-side category.
        /// </summary>
        /// <param name="obj">The object to test.</param>
        /// <returns>True if the objects are equivalent.</returns>
        public override bool Equals(object? obj)
        {
            if (obj == this) return true;
            if (obj == null) return false;
            if (!(obj is Grammar)) return false;
            Grammar other = (Grammar)obj;
            if (!string.Equals(_name, other._name, StringComparison.Ordinal)) return false;
            if (_rules.Count != other._rules.Count) return false;
            foreach (Category key in _rules.Keys)
            {
                if (!other._rules.TryGetValue(key, out Collection<Rule>? value)) return false;
                if (_rules[key].Count != value.Count) return false;
                for (int i = 0; i < _rules[key].Count; i++)
                {
                    if (!_rules[key][i].Equals(other._rules[key][i])) return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Tests whether this grammar is equal to another, with the same name and the same
        /// set of rules under each left-hand-side category.
        /// </summary>
        /// <param name="other">The grammar to test.</param>
        /// <returns>True if the grammars are equivalent.</returns>
        public bool Equals(Grammar? other)
        {
            if (other == this) return true;
            if (other == null) return false;
            if (!string.Equals(_name, other._name, StringComparison.Ordinal)) return false;
            if (_rules.Count != other._rules.Count) return false;
            foreach (Category key in _rules.Keys)
            {
                if (!other._rules.TryGetValue(key, out Collection<Rule>? value)) return false;
                if (_rules[key].Count != value.Count) return false;
                for (int i = 0; i < _rules[key].Count; i++)
                {
                    if (!_rules[key][i].Equals(other._rules[key][i])) return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Computes a hash code for this grammar based on its name and rules.
        /// </summary>
        /// <returns>A hash code.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            if (_name != null)
            {
                result = 31 * result + _name.GetHashCode();
            }
            if (_rules != null)
            {
                result = 31 * result + _rules.GetHashCode();
            }
            return result;
        }

        /// <summary>
        /// Gets a string representation of this grammar, listing its name followed by every rule
        /// it contains.
        /// </summary>
        /// <returns>The string representation of this grammar.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(String.Empty);
            sb.Append('[');
            sb.Append("Grammar");
            sb.Append(' ');
            sb.Append(_name);
            sb.Append(": {");

            int i = 0;
            int ct = _rules.Count;
            foreach (Category key in _rules.Keys)
            {
                Collection<Rule> r = _rules[key];
                for (int j = 0; j < r.Count; j++)
                {
                    if (i == 0)
                    {
                        sb.Append(r[j].ToString());
                    }
                    else
                    {
                        sb.Append(", " + r[j].ToString());
                    }
                }
                i++;
            }

            sb.Append("}]");
            return sb.ToString();
        }

        #endregion
    }
}
