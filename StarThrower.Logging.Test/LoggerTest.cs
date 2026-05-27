using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarThrower.Logging;

namespace StarThrower.Logging.Test
{
    [TestClass]
    public class LoggerTest
    {
        private void Ignore()
        {
#if FAIL_ON_IGNORE
                Assert.Fail("This test has been ignored.");
#else
            Assert.Inconclusive("this test has been ignored");
#endif
        }


        #region RegisterErrorReporter() tests

        [TestMethod]
        public void TestRegisterErrorReporter()
        {
            Ignore();
        }

        #endregion


        #region UnregisterErrorReporter() tests

        [TestMethod]
        public void TestUnregisterErrorReporter()
        {
            Ignore();
        }

        #endregion


        #region ReportError() tests

        [TestMethod]
        public void TestReportError()
        {
            Ignore();
        }

        #endregion
    }
}
