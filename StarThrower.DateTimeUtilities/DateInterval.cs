namespace StarThrower.DateTimeUtilities
{
    /// <summary>
    /// A set of "units" associated with DateTime values.
    /// </summary>
    public enum DateInterval
    {
        /// <summary>
        /// Years
        /// </summary>
        Year = 0,

        /// <summary>
        /// Months
        /// </summary>
        Month = 1,

        /// <summary>
        /// Weekdays (the name of the day: mon, tues, weds, etc)
        /// </summary>
        Weekday = 2,

        /// <summary>
        /// Days (the number of the day, or a count of days)
        /// </summary>
        Day = 3,

        /// <summary>
        /// Hours
        /// </summary>
        Hour = 4,

        /// <summary>
        /// Minutes
        /// </summary>
        Minute = 5,

        /// <summary>
        /// Seconds
        /// </summary>
        Second = 6
    }
}
