/***********************************************************************************
    StarThrower Utilities / Logging
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
