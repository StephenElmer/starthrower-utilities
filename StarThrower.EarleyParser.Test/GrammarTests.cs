// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AwesomeAssertions;
using Xunit;
using StarThrower.EarleyParser;

namespace StarThrower.EarleyParser.Test
{
    public class GrammarTests
    {
        [Fact]
        public void NameReturnsConstructorValue()
        {
            Grammar g = new Grammar("my-grammar");
            g.Name.Should().Be("my-grammar");
        }

        [Fact]
        public void AddRuleThrowsOnNull()
        {
            Grammar g = new Grammar("g");
            Rule? nullRule = null;
            Action act = () => g.AddRule(nullRule);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void AddRuleMakesCategoryDiscoverable()
        {
            Category s = new Category("S", false);
            Category a = new Category("a", true);
            Rule rule = new Rule(s, new ReadOnlyCollection<Category>([a]));

            Grammar g = new Grammar("g");
            g.ContainsRules(s).Should().BeFalse();

            g.AddRule(rule);

            g.ContainsRules(s).Should().BeTrue();
            g.GetRules(s).Should().HaveCount(1);
            g.GetRules(s)[0].Should().Be(rule);
        }

        [Fact]
        public void AddRuleAppendsToExistingCategory()
        {
            Category s = new Category("S", false);
            Category a = new Category("a", true);
            Category b = new Category("b", true);
            Rule rule1 = new Rule(s, new ReadOnlyCollection<Category>([a]));
            Rule rule2 = new Rule(s, new ReadOnlyCollection<Category>([b]));

            Grammar g = new Grammar("g");
            g.AddRule(rule1);
            g.AddRule(rule2);

            g.GetRules(s).Should().HaveCount(2);
            g.GetRules(s)[0].Should().Be(rule1);
            g.GetRules(s)[1].Should().Be(rule2);
        }

        [Fact]
        public void ContainsRulesReturnsFalseForUnknownCategory()
        {
            Grammar g = new Grammar("g");
            Category unknown = new Category("Unknown", false);
            g.ContainsRules(unknown).Should().BeFalse();
        }

        [Fact]
        public void GetRulesThrowsForUnknownCategory()
        {
            Grammar g = new Grammar("g");
            Category unknown = new Category("Unknown", false);
            Action act = () => g.GetRules(unknown);
            act.Should().Throw<KeyNotFoundException>();
        }

        [Fact]
        public void GetAllRulesReturnsRulesAcrossAllCategories()
        {
            Category s = new Category("S", false);
            Category np = new Category("NP", false);
            Category a = new Category("a", true);
            Category b = new Category("b", true);
            Rule sRule = new Rule(s, new ReadOnlyCollection<Category>([np]));
            Rule npRule = new Rule(np, new ReadOnlyCollection<Category>([a]));
            Rule npRule2 = new Rule(np, new ReadOnlyCollection<Category>([b]));

            Grammar g = new Grammar("g");
            g.AddRule(sRule);
            g.AddRule(npRule);
            g.AddRule(npRule2);

            g.GetAllRules().Should().HaveCount(3);
            g.GetAllRules().Should().Contain(sRule);
            g.GetAllRules().Should().Contain(npRule);
            g.GetAllRules().Should().Contain(npRule2);
        }

        [Fact]
        public void SingletonPreterminalReturnsRuleForMatchingToken()
        {
            Category np = new Category("NP", false);
            Category mary = new Category("Mary", true);
            Rule rule = new Rule(np, new ReadOnlyCollection<Category>([mary]));

            Grammar g = new Grammar("g");
            g.AddRule(rule);

            g.SingletonPreterminal(np, "Mary", false).Should().Be(rule);
        }

        [Fact]
        public void SingletonPreterminalReturnsNullWhenTokenDoesNotMatch()
        {
            Category np = new Category("NP", false);
            Category mary = new Category("Mary", true);
            Rule rule = new Rule(np, new ReadOnlyCollection<Category>([mary]));

            Grammar g = new Grammar("g");
            g.AddRule(rule);

            g.SingletonPreterminal(np, "John", false).Should().BeNull();
        }

        [Fact]
        public void SingletonPreterminalReturnsNullForUnknownCategory()
        {
            Grammar g = new Grammar("g");
            Category unknown = new Category("Unknown", false);
            g.SingletonPreterminal(unknown, "anything", false).Should().BeNull();
        }

        [Fact]
        public void SingletonPreterminalReturnsNullForNonSingletonRule()
        {
            // A rule with more than one category on the right is a preterminal
            // (it contains a terminal) but not a *singleton* preterminal, so it
            // must not be returned by SingletonPreterminal.
            Category vp = new Category("VP", false);
            Category vt = new Category("VT", false);
            Category np = new Category("NP", false);
            Rule rule = new Rule(vp, new ReadOnlyCollection<Category>([vt, np]));

            Grammar g = new Grammar("g");
            g.AddRule(rule);

            g.SingletonPreterminal(vp, "VT", false).Should().BeNull();
        }

        [Fact]
        public void SingletonPreterminalIsCaseSensitiveByDefault()
        {
            Category np = new Category("NP", false);
            Category mary = new Category("Mary", true);
            Rule rule = new Rule(np, new ReadOnlyCollection<Category>([mary]));

            Grammar g = new Grammar("g");
            g.AddRule(rule);

            g.SingletonPreterminal(np, "mary", false).Should().BeNull();
            g.SingletonPreterminal(np, "mary", true).Should().Be(rule);
        }

        [Fact]
        public void EqualsReturnsTrueForSameNameAndRules()
        {
            Category s = new Category("S", false);
            Category a = new Category("a", true);

            Grammar g1 = new Grammar("g");
            g1.AddRule(new Rule(s, new ReadOnlyCollection<Category>([a])));

            Grammar g2 = new Grammar("g");
            g2.AddRule(new Rule(s, new ReadOnlyCollection<Category>([a])));

            g1.Equals(g2).Should().BeTrue();
        }

        [Fact]
        public void EqualsReturnsFalseForDifferentNames()
        {
            Category s = new Category("S", false);
            Category a = new Category("a", true);

            Grammar g1 = new Grammar("one");
            g1.AddRule(new Rule(s, new ReadOnlyCollection<Category>([a])));

            Grammar g2 = new Grammar("two");
            g2.AddRule(new Rule(s, new ReadOnlyCollection<Category>([a])));

            g1.Equals(g2).Should().BeFalse();
        }

        [Fact]
        public void EqualsReturnsFalseForDifferentRuleSets()
        {
            Category s = new Category("S", false);
            Category a = new Category("a", true);
            Category b = new Category("b", true);

            Grammar g1 = new Grammar("g");
            g1.AddRule(new Rule(s, new ReadOnlyCollection<Category>([a])));

            Grammar g2 = new Grammar("g");
            g2.AddRule(new Rule(s, new ReadOnlyCollection<Category>([b])));

            g1.Equals(g2).Should().BeFalse();
        }

        [Fact]
        public void EqualsReturnsFalseWhenNull()
        {
            Grammar g = new Grammar("g");
            Grammar? other = null;
            g.Equals(other).Should().BeFalse();
        }
    }
}
