namespace StarThrower.Logging
{
    public static class ErrorPolicy
    {
        /// <summary>
        /// The policy that applies to reporting internal errors.
        /// </summary>
        public const string Internal = "errorPolicyInternal";

        /// <summary>
        /// The global policy that applies to all error reporting.
        /// </summary>
        public const string Global = "errorPolicyGlobal";
    }
}
