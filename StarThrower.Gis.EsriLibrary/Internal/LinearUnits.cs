// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

namespace StarThrower.Gis.EsriLibrary
{
    /// <summary>
    /// ESRI linear unit name constants, as referenced by <c>.prj</c> coordinate system definitions.
    /// </summary>
    internal static class LinearUnits
    {
        // Name reversed relative to value ("150_Kilometers"/"50_Kilometers"): a C# identifier
        // cannot start with a digit, so the number is moved after "Kilometers" in the constant name.
        internal const string Kilometers_150 = "150_Kilometers";
        internal const string Kilometers_50 = "50_Kilometers";
        internal const string Chain_Benoit_1895_B = "Chain_Benoit_1895_B";
        internal const string Chain_Sears = "Chain_Sears";
        internal const string Foot = "Foot";
        internal const string Foot_Clarke = "Foot_Clarke";
        internal const string Foot_Gold_Coast = "Foot_Gold_Coast";
        internal const string Foot_Sears = "Foot_Sears";
        internal const string Foot_US = "Foot_US";
        internal const string Link_Clarke = "Link_Clarke";
        internal const string Meter = "Meter";
        internal const string Yard_Indian = "Yard_Indian";
        internal const string Yard_Indian_1937 = "Yard_Indian_1937";
        internal const string Yard_Sears = "Yard_Sears";
    }
}
