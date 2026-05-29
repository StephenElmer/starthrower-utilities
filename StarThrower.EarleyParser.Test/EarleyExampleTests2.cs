using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarThrower.EarleyParser;

namespace StarThrower.EarleyParser.Test
{
    /// <summary>
    /// Summary description for EarleyExampleTests2
    /// </summary>
    [TestClass]
    public class EarleyExampleTests2
    {
        #region [ Construction ]

        public EarleyExampleTests2()
        {
            S = new Category("S", false);
            E = new Category("E", false);
            T = new Category("T", false);

            Plus = new Category("Plus", false);
            Times = new Category("Times", false);
            P = new Category("p", false);

            plus = new Category("+", true);
            times = new Category("*", true);

            List<Category> l = new List<Category>();
            l.Add(E);
            ReadOnlyCollection<Category> rightOfS = new ReadOnlyCollection<Category>(l);
            S_E = new Rule(S, rightOfS);

            l = new List<Category>();
            l.Add(T);
            ReadOnlyCollection<Category> rightOfE_T = new ReadOnlyCollection<Category>(l);
            E_T = new Rule(E, rightOfE_T);

            l = new List<Category>();
            l.Add(E);
            l.Add(Plus);
            l.Add(T);
            ReadOnlyCollection<Category> rightOfE_EPlusT = new ReadOnlyCollection<Category>(l);
            E_EPlusT = new Rule(E, rightOfE_EPlusT);

            l = new List<Category>();
            l.Add(P);
            ReadOnlyCollection<Category> rightOfT_P = new ReadOnlyCollection<Category>(l);
            T_P = new Rule(T, rightOfT_P);

            l = new List<Category>();
            l.Add(T);
            l.Add(Times);
            l.Add(P);
            ReadOnlyCollection<Category> rightOfT_TTimesP = new ReadOnlyCollection<Category>(l);
            T_TTimesP = new Rule(T, rightOfT_TTimesP);

            l = new List<Category>();
            l.Add(new Category("a", true));
            ReadOnlyCollection<Category> rightOfP = new ReadOnlyCollection<Category>(l);
            P_a = new Rule(P, rightOfP);

            l = new List<Category>();
            l.Add(plus);
            ReadOnlyCollection<Category> rightOfPlus = new ReadOnlyCollection<Category>(l);
            Plus_plus = new Rule(Plus, rightOfPlus);

            l = new List<Category>();
            l.Add(times);
            ReadOnlyCollection<Category> rightOfTimes = new ReadOnlyCollection<Category>(l);
            Times_times = new Rule(Times, rightOfTimes);

            g = new Grammar("Earley");
            g.AddRule(S_E);
            g.AddRule(E_T);
            g.AddRule(E_EPlusT);
            g.AddRule(T_P);
            g.AddRule(T_TTimesP);
            g.AddRule(P_a);
            g.AddRule(Plus_plus);
            g.AddRule(Times_times);
        }

        #endregion


        #region [ Private Instance Variables ]

        private TestContext? testContextInstance;
        private Category S;
        private Category E;
        private Category T;

        private Category Plus;
        private Category Times;
        private Category P;

        private Category plus;
        private Category times;

        private Rule S_E;
        private Rule E_T;
        private Rule E_EPlusT;
        private Rule T_P;
        private Rule T_TTimesP;
        private Rule P_a;
        private Rule Plus_plus;
        private Rule Times_times;

        private Grammar g;

        #endregion


        #region [ Public Properties ]

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext? TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #endregion


        #region [ Additional test attributes ]
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion


        [TestMethod]
        public void a_times_a_succeeds()
        {
            string[] aTimesa = new string[3];
            aTimesa[0] = "a";
            aTimesa[1] = "*";
            aTimesa[2] = "a";

            Parser parser = new Parser(g);
            Parse parse = parser.Parse(aTimesa, S);
            Assert.AreEqual(Status.Accept, parse.Status);
        }

        [TestMethod]
        public void a_plus_a_succeeds()
        {
            string[] aTimesa = new string[3];
            aTimesa[0] = "a";
            aTimesa[1] = "+";
            aTimesa[2] = "a";

            Parser parser = new Parser(g);
            Parse parse = parser.Parse(aTimesa, S);
            Assert.AreEqual(Status.Accept, parse.Status);
        }

        [TestMethod]
        public void a_minus_a_fails()
        {
            string[] aTimesa = new string[3];
            aTimesa[0] = "a";
            aTimesa[1] = "-";
            aTimesa[2] = "a";

            Parser parser = new Parser(g);
            Parse parse = parser.Parse(aTimesa, S);
            Assert.AreEqual(Status.Reject, parse.Status);
        }

        [TestMethod]
        public void a_times_a_plus_a_succeeds()
        {
            string[] aTimesa = new string[5];
            aTimesa[0] = "a";
            aTimesa[1] = "*";
            aTimesa[2] = "a";
            aTimesa[3] = "+";
            aTimesa[4] = "a";

            Parser parser = new Parser(g);
            Parse parse = parser.Parse(aTimesa, S);
            Assert.AreEqual(Status.Accept, parse.Status);
        }
    }
}
