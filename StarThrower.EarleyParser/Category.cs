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

namespace StarThrower.EarleyParser
{
    /// <summary>
    /// A category in a grammar.  Categories are the atomic subparts that make up Rule grammar rules.
    /// 
    /// Categories can either be terminal or non-terminal.  A terminal category is
    /// one in which no further categories can be derived, while non-terminal
    /// categories can yield a series of other categories when they occur as
    /// the left-hand side of a rule.  If a category is created by specifying
    /// only its name, this class's corresponding constructor assumes that the
    /// category is non-terminal.
    /// 
    /// Once created, categories are immutable and have no setters.  This ensures that,
    /// once loaded in a grammar, a category will remain as it was when created.
    /// </summary>
    public class Category
    {
        #region [ Static Members ]

        private class RootCategory : Category
        {
            public RootCategory(string name) : base(name) { }

            public RootCategory(string name, bool isTerminal) : base(name, isTerminal) { }

            public override bool Equals(object? obj)
            {
                return this == obj;
            }

            public bool Equals(RootCategory? other)
            {
                return this == other;
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }

        private static readonly RootCategory _root = new RootCategory("<start>", false);

        /// <summary>
        /// Special "start" category for seeding Earley parsers.
        /// </summary>
        public static Category Root
        {
            get { return _root; }
        }

        #endregion


        #region [ Private Instance Variables ]

        private readonly string _name;
        private readonly bool _isTerminal;

        #endregion


        #region [ Public Properties ]

        /// <summary>
        /// Gets the name of this category which was set during construction.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Gets the terminal status of this category which was set during construction.
        /// </summary>
        public bool IsTerminal
        {
            get { return _isTerminal; }
        }

        #endregion


        #region [ Construction ]

        /// <summary>
        /// Creates a new non-terminal category with the specified name.
        /// </summary>
        /// <param name="name">The name of the new non-terminal category</param>
        public Category(string? name) : this(name, false) { }

        /// <summary>
        /// Creates a new category name with the specified terminal status.
        /// </summary>
        /// <param name="name">The Name for this category</param>
        /// <param name="isTerminal">Whether or not this category is a terminal</param>
        /// <exception cref="ArgumentNullException">Thrown if name is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if name is blank or an empty string for a non-terminal category.</exception>
        public Category(string? name, bool isTerminal)
        {
            ArgumentNullException.ThrowIfNull(name);
            
            //TODO: hmm... this was originaly the other way around, but the other way around if fails the Ctor_ThrowsOnWHitespaceName() test.  Why was it made to allow whitespace?
            string temp = name.Trim();
            //string temp = name;
            
            if (!isTerminal && (temp.Length == 0)) throw new InvalidOperationException("empty name specified for Category");

            _name = temp;
            _isTerminal = isTerminal;
        }

        #endregion


        #region [ Object Overrides ]

        /// <summary>
        /// Tests whether this category is equal to another.
        /// Returns true if the specified object is an instance of Category and its name and terminal
        /// status are equal to this category's name and terminal status.
        /// </summary>
        /// <param name="obj">The object to test.</param>
        /// <returns>True if the objects are equivalent.</returns>
        public override bool Equals(object? obj)
        {
            if (obj == this) return true;
            if (obj == null) return false;
            if (!(obj is Category)) return false;
            Category other = (Category)obj;
            return other != Category.Root &&
                _isTerminal == other._isTerminal &&
                (String.Compare(_name, other._name, StringComparison.Ordinal) == 0);

        }

        public bool Equals(Category? other)
        {
            if (other == this) return true;
            if (other == null) return false;
            return other != Category.Root &&
                _isTerminal == other._isTerminal &&
                (String.Compare(_name, other._name, StringComparison.Ordinal) == 0);

        }

        /// <summary>
        /// Computes a hash code for this category based on its name and terminal status.
        /// </summary>
        /// <returns>A hash code.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + _isTerminal.GetHashCode();
            result = 31 * result + _name.GetHashCode();
            return result;
        }

        /// <summary>
        /// Gets a string representation of this category.
        /// </summary>
        /// <returns>The value of this category's name.</returns>
        public override string ToString()
        {
            return ((_name.Length == 0) ? "<empty>" : _name);
        }

        #endregion
    }
}
