// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Logging
{
    /// <summary>
    /// This interface enables you to create and register different output mediums for reported errors.
    /// It provides a lighter weight version of the exception handling application block available in
    /// the Enterprise Library.
    /// </summary>
    /// <remarks>
    /// Classes that implement this interface should get added to the collection of error reporters
    /// in StarThrower.Utilities.Logging by calling the RegisterErrorReporter() method of that class from
    /// Main() method of your program.  To remove an error reporter from the collection in the Logging
    /// class, you call the UnRegisterErrorReporter() method.
    /// Once some error reporters have been registered, in the catch blocks of your exception handling
    /// code, you can call Logging.ReportError("MyClass.SomeMethod()", ex) which will then send the exception
    /// to all registered error reporters.
    /// Thus you can have errors sent to a dialog box, a log file, an e-mail location, etc.
    /// </remarks>
    public interface IErrorReporter
    {
        /// <summary>
        /// The method normally called from the catch block of your exception handling code.
        /// </summary>
        /// <param name="source">A string representing the source of the error.  e.g. "MyClass.SomeMethod()"</param>
        /// <param name="ex">The exception being thrown.</param>
        /// <exception cref="ArgumentNullException">Should be thrown if policy or ex is null.</exception>
        void Report(string source, Exception ex);

        /// <summary>
        /// Informs an IErrorReporter that it should report errors associated with the specified policy.
        /// </summary>
        /// <param name="policy">The policy for which errors should be reported.</param>
        /// <remarks>
        /// This is equiavalent to calling RegisterPolicy(policyName, policyName);
        /// </remarks>
        /// <exception cref="ArgumentNullException">Should be thrown if policy is null.</exception>
        void RegisterPolicy(string policy);

        /// <summary>
        /// Informs an IErrorReporter that it should report errors associated with the specified policy.
        /// </summary>
        /// <param name="policy">The policy for which errors should be reported.</param>
        /// <param name="description">A description of the policy.</param>
        /// <exception cref="ArgumentNullException">Should be thrown if policy or description is null.</exception>
        void RegisterPolicy(string policy, string description);

        /// <summary>
        /// Informs an IErrorReporter that it no longer needs to report errors for the specified policy.
        /// </summary>
        /// <param name="policy">The policy to stop reporting errors for.</param>
        /// <exception cref="ArgumentNullException">Should be thrown if policy is null.</exception>
        void UnregisterPolicy(string policy);

        /// <summary>
        /// Checks to see if a an IErrorReporter is configured to report errors for a particular policy.
        /// </summary>
        /// <param name="policy">The policy to check for.</param>
        /// <returns>True if the IErrorReporter should be reporting for the specified policy; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">Should be thrown if policy is null.</exception>
        bool SupportsPolicy(string policy);
    }
}
