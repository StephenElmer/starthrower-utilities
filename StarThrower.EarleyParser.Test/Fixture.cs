using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using StarThrower.EarleyParser;

namespace StarThrower.EarleyParser.Test
{
    public class Fixture
    {
        public Grammar grammar, mixed;
        public Category A, B, C, D, E, X, Y, Z, a, b;
        public Category seed, S, NP, VP, Det, N, the, boy, girl, left;
        public Rule rule1, rule2, rule3, rule4, rule5, rule6, rule7, rule8;
        public Edge edge1, edge2, edge3;
        public string[] tokens;
        public DottedRule dot1, dot2, dot3;
        public Chart chart;
        public Parse parse;
        public Collection<ParseTree> parseTrees;
        public Category VI, VT, VS, saw, duck, her, he;
        public Parser earleyParser;
        public Grammar emptyGrammar;

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
