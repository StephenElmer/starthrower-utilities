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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using StarThrower.EarleyParser;

namespace StarThrower.EarleyParser.Test
{
#pragma warning disable CA1708 // Identifiers should differ by more than case
    public class Fixture
#pragma warning restore CA1708 // Identifiers should differ by more than case
    {
        public Grammar grammar { get; set; }
        public Grammar mixed { get; set; }

        public Category A { get; set; }
        public Category B { get; set; }
        public Category C { get; set; }
        public Category D { get; set; }
        public Category E { get; set; }
        public Category X { get; set; }
        public Category Y { get; set; }
        public Category Z { get; set; }
#pragma warning disable IDE1006 // Naming Styles
        public Category a { get; set; }
        public Category b { get; set; }
#pragma warning restore IDE1006 // Naming Styles

        public Category seed { get; set; }
        public Category S { get; set; }
        public Category NP { get; set; }
        public Category VP { get; set; }
        public Category Det { get; set; }
        public Category N { get; set; }
        public Category the { get; set; }
        public Category boy { get; set; }
        public Category girl { get; set; }
        public Category left { get; set; }

        public Rule rule1 { get; set; }
        public Rule rule2 { get; set; }
        public Rule rule3 { get; set; }
        public Rule rule4 { get; set; }
        public Rule rule5 { get; set; }
        public Rule rule6 { get; set; }
        public Rule rule7 { get; set; }
        public Rule rule8 { get; set; }

        public Edge edge1 { get; set; }
        public Edge edge2 { get; set; }
        public Edge edge3 { get; set; }

        public string[] tokens { get; set; }

        public DottedRule dot1 { get; set; }
        public DottedRule dot2 { get; set; }
        public DottedRule dot3 { get; set; }

        public Chart chart { get; set; }

        public Parse parse { get; set; } =
            new Parse(new Category("<uninitialized>"), new Chart());

        public Collection<ParseTree> parseTrees { get; set; } =
            new Collection<ParseTree>();

        public Category VI { get; set; }
        public Category VT { get; set; }
        public Category VS { get; set; }
        public Category saw { get; set; }
        public Category duck { get; set; }
        public Category her { get; set; }
        public Category he { get; set; }
    
        public Parser earleyParser { get; set; }
        public Grammar emptyGrammar { get; set; }

        public Fixture()
        {
            A = new Category("A", false);
            B = new Category("B", false);
            C = new Category("C", false);
            D = new Category("D", false);
            E = new Category("E", false);
            X = new Category("X", false);
            Y = new Category("Y", false);
            Z = new Category("Z", false);
            a = new Category("a", true);
            b = new Category("b", true);

            List<Category> l = new List<Category>();
            l.Add(B);
            l.Add(C);
            l.Add(D);
            l.Add(E);
            ReadOnlyCollection<Category> right1 = new ReadOnlyCollection<Category>(l);
            rule1 = new Rule(A, right1);

            l = new List<Category>();
            l.Add(a);
            ReadOnlyCollection<Category> right2 = new ReadOnlyCollection<Category>(l);
            rule2 = new Rule(A, right2);

            l = new List<Category>();
            l.Add(Y);
            l.Add(Z);
            ReadOnlyCollection<Category> right3 = new ReadOnlyCollection<Category>(l);
            rule3 = new Rule(X, right3);

            l = new List<Category>();
            l.Add(X);
            l.Add(a);
            ReadOnlyCollection<Category> right4 = new ReadOnlyCollection<Category>(l);
            rule4 = new Rule(A, right4);

            l = new List<Category>();
            l.Add(a);
            l.Add(Z);
            ReadOnlyCollection<Category> right5 = new ReadOnlyCollection<Category>(l);
            rule5 = new Rule(X, right5);

            l = new List<Category>();
            l.Add(b);
            ReadOnlyCollection<Category> right6 = new ReadOnlyCollection<Category>(l);
            rule6 = new Rule(Z, right6);

            l = new List<Category>();
            l.Add(a);
            ReadOnlyCollection<Category> right7 = new ReadOnlyCollection<Category>(l);
            rule7 = new Rule(X, right7);

            l = new List<Category>();
            l.Add(b);
            ReadOnlyCollection<Category> right8 = new ReadOnlyCollection<Category>(l);
            rule8 = new Rule(X, right8);

            edge1 = new Edge(new DottedRule(rule1, 2), 3);
            edge2 = new Edge(new DottedRule(rule3, 0), 0);
            edge3 = new Edge(new DottedRule(rule2, 1), 2);

            grammar = new Grammar("test");

            S = new Category("S", false);
            seed = S;
            NP = new Category("NP", false);
            VP = new Category("VP", false);
            Det = new Category("Det", false);
            N = new Category("N", false);

            the = new Category("the", true);
            boy = new Category("boy", true);
            girl = new Category("girl", true);
            left = new Category("left", true);

            l = new List<Category>();
            l.Add(NP);
            l.Add(VP);
            ReadOnlyCollection<Category> gr1 = new ReadOnlyCollection<Category>(l);
            grammar.AddRule(new Rule(S, gr1));

            l = new List<Category>();
            l.Add(Det);
            l.Add(N);
            ReadOnlyCollection<Category> gr2 = new ReadOnlyCollection<Category>(l);
            grammar.AddRule(new Rule(NP, gr2));

            l = new List<Category>();
            l.Add(left);
            ReadOnlyCollection<Category> gr3 = new ReadOnlyCollection<Category>(l);
            grammar.AddRule(new Rule(VP, gr3));

            l = new List<Category>();
            l.Add(a);
            ReadOnlyCollection<Category> gr4 = new ReadOnlyCollection<Category>(l);
            grammar.AddRule(new Rule(Det, gr4));

            l = new List<Category>();
            l.Add(the);
            ReadOnlyCollection<Category> gr5 = new ReadOnlyCollection<Category>(l);
            grammar.AddRule(new Rule(Det, gr5));

            l = new List<Category>();
            l.Add(boy);
            ReadOnlyCollection<Category> gr6 = new ReadOnlyCollection<Category>(l);
            grammar.AddRule(new Rule(N, gr6));

            l = new List<Category>();
            l.Add(girl);
            ReadOnlyCollection<Category> gr7 = new ReadOnlyCollection<Category>(l);
            grammar.AddRule(new Rule(N, gr7));

            tokens = new string[3];
            tokens[0] = the.Name;
            tokens[1] = boy.Name;
            tokens[2] = left.Name;

            mixed = new Grammar("mixed");
            mixed.AddRule(rule4);
            mixed.AddRule(rule5);
            mixed.AddRule(rule6);
            mixed.AddRule(rule7);
            mixed.AddRule(rule8);

            dot1 = new DottedRule(rule1, 2);
            dot2 = new DottedRule(rule2, 1);
            dot3 = new DottedRule(rule3, 0);

            chart = new Chart();
            chart.AddEdge(0, edge1);
            chart.AddEdge(0, edge2);
            chart.AddEdge(1, edge3);

            VI = new Category("VI");
            VT = new Category("VT");
            VS = new Category("VS");
            saw = new Category("saw", true);
            duck = new Category("duck", true);
            her = new Category("her", true);
            he = new Category("he", true);

            earleyParser = new Parser(grammar);
            emptyGrammar = new Grammar("empty");
        }
    }
}
