using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarThrower.EarleyParser;

namespace StarThrower.EarleyParser.Test
{
    [TestClass]
    public class ParserTests
    {
        #region [ Construction ]

        public ParserTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion


        #region [ Private Instance Variables ]

        private TestContext testContextInstance;

        #endregion


        #region [ Public Properties ]

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
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
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion


        [TestMethod]
        public void GetGrammar()
        {
            Fixture f = new Fixture();

            Assert.AreEqual(f.grammar, f.earleyParser.Grammar);
        }

        [TestMethod]
        public void SetGrammar()
        {
            Fixture f = new Fixture();

            Assert.AreEqual(f.grammar, f.earleyParser.Grammar);

            f.earleyParser.Grammar = f.emptyGrammar;

            Assert.AreEqual(f.emptyGrammar, f.earleyParser.Grammar);
        }

        [TestMethod]
        public void Recognize()
        {
            Fixture f = new Fixture();
            f.earleyParser = new Parser(f.grammar);

            Assert.AreEqual(Status.Accept, f.earleyParser.Recognize(f.tokens, f.seed));
        }

        [TestMethod]
        public void Parse_1()
        {

        }
    }
}
