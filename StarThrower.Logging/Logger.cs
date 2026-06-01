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

using System;
using System.Collections.Generic;

namespace StarThrower.Logging
{
    public static class Logger
    {
        private static Dictionary<string, IErrorReporter> _errorReporters = new Dictionary<string, IErrorReporter>();

        /// <summary>
        /// Associates an IErrorReporter with a specified error policy.
        /// </summary>
        /// <param name="reporterName">The name of the IErrorReporter.</param>
        /// <param name="policyName">The error policy you wish to be associated with the IErrorReporter.</param>
        /// <remarks>
        /// Using multiple calls to this method, an IErrorReporter may be registered with multiple policies and 
        /// a policy may be associated with multiple IErrorReporters.
        /// </remarks>
        /// <exception cref="ArgumentNullException"></exception>
        public static void RegisterErrorPolicy(string reporterName, string policyName)
        {
            ArgumentNullException.ThrowIfNull(reporterName);
            ArgumentNullException.ThrowIfNull(policyName);

            try
            {
                if (_errorReporters.TryGetValue(reporterName, out var reporter))
                {
                    reporter.RegisterPolicy(policyName);
                }
            }
            catch (Exception ex)
            {
                ReportError(ErrorPolicy.Internal, "Logging.RegisterErrorPolicy(string, string)", ex);
                throw;
            }
        }

        /// <summary>
        /// Registers an IErrorReporter
        /// </summary>
        /// <param name="key">A unique name for the IErrorReporter being registered.</param>
        /// <param name="reporter">The IErrorReporter begin registered.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void RegisterErrorReporter(string key, IErrorReporter reporter)
        {
            ArgumentNullException.ThrowIfNull(key);
            ArgumentNullException.ThrowIfNull(reporter);

            try
            {
                _errorReporters.Add(key, reporter);
            }
            catch (Exception ex)
            {
                ReportError(ErrorPolicy.Internal, "Logging.RegisterErrorReporter(string, IErrorReporter)", ex);
                throw;
            }
        }

        /// <summary>
        /// Removes the IErrorReporter associated with the specified key from the list of IErrorReporters.
        /// </summary>
        /// <param name="key">The key of the IErrorReporter to remove.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void UnregisterErrorReporter(string key)
        {
            ArgumentNullException.ThrowIfNull(key);

            try
            {
                _errorReporters.Remove(key);
            }
            catch (Exception ex)
            {
                ReportError(ErrorPolicy.Internal, "Logging.UnregisterErrorReporter(string)", ex);
                throw;
            }
        }

        /// <summary>
        /// Publishes an exception to all registered IErrorReporters.
        /// </summary>
        /// <param name="ex">The Exception to be published.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ReportError(Exception ex)
        {
            ArgumentNullException.ThrowIfNull(ex);

            ReportError("Unknown", ex);
        }

        /// <summary>
        /// Publishes an exception to all registered IErrorReporters
        /// </summary>
        /// <param name="source">A short textual description which should contain the Class and Method from where the exception originated.</param>
        /// <param name="ex">The exception to be published.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ReportError(string source, Exception ex)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(ex);

            ReportError(ErrorPolicy.Internal, source, ex);
        }

        /// <summary>
        /// Publishes an exception to all registered IErrorReporters
        /// </summary>
        /// <param name="policy">A policy that may be specified in a config file which indicates how this particular exception should be reported.</param>
        /// <param name="source">A short textual description which should contain the Class and Method from where the exception originated.</param>
        /// <param name="ex">The exception to be published.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ReportError(string policy, string source, Exception ex)
        {
            ArgumentNullException.ThrowIfNull(policy);
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(ex);

            try
            {
                foreach (string key in _errorReporters.Keys)
                {
                    IErrorReporter r = _errorReporters[key];
                    if (r.SupportsPolicy(policy))
                    {
                        r.Report(source, ex);
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
