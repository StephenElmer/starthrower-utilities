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
    /// <summary>
    /// Base class for implementations of IErrorReporter
    /// This base class provides the policy functionality that should be available
    /// to all implementations of the IErrorReporter.
    /// </summary>
    public abstract class ErrorReporterBase : IErrorReporter
    {
        #region Private Members

        private Dictionary<string, string> _policies = new Dictionary<string, string>();

        #endregion


        #region Public Methods

        /// <summary>
        /// The method normally called from the catch block of your exception handling code.
        /// </summary>
        /// <param name="source">A string representing the source of the error.  e.g. "MyClass.SomeMethod()"</param>
        /// <param name="ex">The exception being thrown.</param>
        /// <exception cref="ArgumentNullException">Thrown if policy or ex is null.</exception>
        public abstract void Report(string source, Exception ex);

        /// <summary>
        /// Informs an IErrorReporter that it should report errors associated with the specified policy.
        /// </summary>
        /// <param name="policy">The policy for which errors should be reported.</param>
        /// <remarks>
        /// This is equiavalent to calling RegisterPolicy(policyName, policyName);
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown if policy is null.</exception>
        public void RegisterPolicy(string policy)
        {
            ArgumentNullException.ThrowIfNull(policy, nameof(policy));

            RegisterPolicy(policy, policy);
        }

        /// <summary>
        /// Informs an IErrorReporter that it should report errors associated with the specified policy.
        /// </summary>
        /// <param name="policy">The policy for which errors should be reported.</param>
        /// <param name="description">A description of the policy.</param>
        /// <exception cref="ArgumentNullException">Thrown if policy or description is null.</exception>
        public void RegisterPolicy(string policy, string description)
        {
            ArgumentNullException.ThrowIfNull(policy);
            ArgumentNullException.ThrowIfNull(description);

            try
            {
                _policies.TryAdd(policy, description);
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, this.GetType().Name + ".RegisterPolicy(string, string)", ex);
                throw;
            }
        }

        /// <summary>
        /// Informs an IErrorReporter that it no longer needs to report errors for the specified policy.
        /// </summary>
        /// <param name="policy">The policy to stop reporting errors for.</param>
        /// <exception cref="ArgumentNullException">Thrown if policy is null.</exception>
        public void UnregisterPolicy(string policy)
        {
            ArgumentNullException.ThrowIfNull(policy);

            try
            {
                _policies.Remove(policy);
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, this.GetType().Name + ".UnregisterPolicy(string)", ex);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if a an IErrorReporter is configured to report errors for a particular policy.
        /// </summary>
        /// <param name="policy">The policy to check for.</param>
        /// <returns>True if the IErrorReporter should be reporting for the specified policy; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">Thrown if policy is null.</exception>
        public bool SupportsPolicy(string policy)
        {
            ArgumentNullException.ThrowIfNull(policy);

            try
            {
                return _policies.ContainsKey(nameof(policy));
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, this.GetType().Name + ".SupportsPolicy(string)", ex);
                throw;
            }
        }

        #endregion

    }
}
