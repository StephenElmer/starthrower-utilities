using System;
using System.Globalization;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StarThrower.EarleyParser
{
    public class Grammar
    {
        #region [ Private Instance Variables ]

        private string _name;
        private Dictionary<Category, Collection<Rule>> _rules;

        #endregion


        #region [ Public Properties ]

        public string Name
        {
            get { return _name; }
        }

        #endregion


        #region [ Construction ]

        public Grammar(string name)
        {
            _name = name;
            _rules = new Dictionary<Category, Collection<Rule>>();
        }

        #endregion


        #region [ Public Methods ]

        public void AddRule(Rule? rule)
        {
            ArgumentNullException.ThrowIfNull(rule);

            if (_rules.ContainsKey(rule.Left))
            {
                _rules[rule.Left].Add(rule);
            }
            else
            {
                Collection<Rule> rules = new Collection<Rule>();
                rules.Add(rule);
                _rules.Add(rule.Left, rules);
            }
        }

        public bool ContainsRules(Category left)
        {
            return _rules.ContainsKey(left);
        }

        public Collection<Rule> GetRules(Category left)
        {
            return _rules[left];
        }

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

        public Rule? SingletonPreterminal(Category left, string token, bool ignoreCase)
        {
            if (_rules.ContainsKey(left))
            {
                foreach (Rule r in _rules[left])
                {
                    StringComparison sc = (ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
                    if (r.IsSingletonPreterminal && (String.Compare(r.Right[0].Name, token, sc) == 0))
                    {
                        return r;
                    }
                }
            }
            return null;
        }

        #endregion


        #region [ Object Overrides ]

        public override bool Equals(object? obj)
        {
            if (obj == this) return true;
            if (obj == null) return false;
            if (!(obj is Grammar)) return false;
            Grammar other = (Grammar)obj;
            if (String.Compare(_name, other._name, StringComparison.Ordinal) != 0) return false;
            if (_rules.Count != other._rules.Count) return false;
            foreach (Category key in _rules.Keys)
            {
                if (!other._rules.ContainsKey(key)) return false;
                if (_rules[key].Count != other._rules[key].Count) return false;
                for (int i = 0; i < _rules[key].Count; i++)
                {
                    if (!_rules[key][i].Equals(other._rules[key][i])) return false;
                }
            }
            return true;
        }

        public bool Equals(Grammar? other)
        {
            if (other == this) return true;
            if (other == null) return false;
            if (String.Compare(_name, other._name, StringComparison.Ordinal) != 0) return false;
            if (_rules.Count != other._rules.Count) return false;
            foreach (Category key in _rules.Keys)
            {
                if (!other._rules.ContainsKey(key)) return false;
                if (_rules[key].Count != other._rules[key].Count) return false;
                for (int i = 0; i < _rules[key].Count; i++)
                {
                    if (!_rules[key][i].Equals(other._rules[key][i])) return false;
                }
            }
            return true;
        }

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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(String.Empty);
            sb.Append("[");
            sb.Append("Grammar");
            sb.Append(" ");
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
