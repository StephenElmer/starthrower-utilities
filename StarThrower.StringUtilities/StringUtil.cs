using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using StarThrower.Logging;
using StarThrower.MathUtilities;

namespace StarThrower.StringUtilities
{
    public static class StringUtil
    {
        private static char[] _invalidXmlChars = { '&', '<', '>', '\"', '=', '\'' };
        private static int[] _invalidXmlCharInts = { 38, 60, 62, 34, 61, 39 };

        // Required on .NET Core: Windows code page encodings (e.g. Windows-1252) are not
        // registered by default. This registers the full code-pages provider once.
        static StringUtil()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        /// <summary>
        /// The symbol used for degrees (as in 32° F).
        /// </summary>
        /// <remarks>
        /// The value of this constant is equivalent to \u00B0 (Unicode); 248 (ASCII); F8 (hex)
        /// </remarks>
        public const string DegreeSymbol = "\u00B0"; //Unicode character for the degree symbol

        /// <summary>
        /// The symbol used for superscript 0.
        /// </summary>
        public const string Superscript0 = "\u2070";

        /// <summary>
        /// The symbol used for superscript 1.
        /// </summary>
        public const string Superscript1 = "\u00B9";

        /// <summary>
        /// The symbol used for superscript 2.
        /// </summary>
        public const string Superscript2 = "\u00B2";

        /// <summary>
        /// The symbol used for superscript 3.
        /// </summary>
        public const string Superscript3 = "\u00B3";

        /// <summary>
        /// The symbol used for superscript 4.
        /// </summary>
        public const string Superscript4 = "\u2074";

        /// <summary>
        /// The symbol used for superscript 5.
        /// </summary>
        public const string Superscript5 = "\u2075";

        /// <summary>
        /// The symbol used for superscript 6.
        /// </summary>
        public const string Superscript6 = "\u2076";

        /// <summary>
        /// The symbol used for superscript 7.
        /// </summary>
        public const string Superscript7 = "\u2077";

        /// <summary>
        /// The symbol used for superscript 8.
        /// </summary>
        public const string Superscript8 = "\u2078";

        /// <summary>
        /// The symbol used for superscript 9.
        /// </summary>
        public const string Superscript9 = "\u2079";

        /// <summary>
        /// The symbol used for superscript plus sign.
        /// </summary>
        public const string SuperscriptPlus = "\u207A";

        /// <summary>
        /// The symbol used for superscript minus sign.
        /// </summary>
        public const string SuperscriptMinus = "\u207B";


        /// <summary>
        /// Converts the source string into a string of hexadecimal characters.
        /// 
        /// Formerly CharToHex()
        /// </summary>
        /// <param name="source">The string to be converted</param>
        /// <returns>The hexidecimal representation of that string</returns>
        /// <example>
        /// Strings.ToHex("A") returns "41" 
        /// Strings.ToHex("ASDF") returns "41534446"
        /// Strings.ToHex("asdf") returns "61736466"
        /// </example>
        /// <exception cref="ArgumentNullException">Thrown if source is null.</exception>
        public static string ToHex(string source)
        {
            if (source == null) throw new ArgumentNullException("source");

            try
            {
                // Use Windows-1252 encoding to convert string to bytes,
                // matching VB.NET's Chr/Hex behavior for characters 128-255
                Encoding encoding = Encoding.GetEncoding("Windows-1252"); // Windows-1252
                byte[] bytes = encoding.GetBytes(source);

                StringBuilder ret = new StringBuilder();
                foreach (byte b in bytes)
                {
                    ret.Append(b.ToString("X2"));
                }

                return ret.ToString();
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Strings.ToHex(string)", ex);
                throw;
            }
        }
        //public static string ToHex_old(string source)
        //{
        //    if (source == null) throw new ArgumentNullException("source");
        //    try
        //    {
        //        StringBuilder ret = new StringBuilder(String.Empty);
        //        for (int i = 0; i < source.Length; i++)
        //        {
        //            string c = "";
        //            //TODO: implement StarThrower.StringUtil.ToHex(string)
        //            //string c = Microsoft.VisualBasic.Conversion.Hex(Microsoft.VisualBasic.Strings.Asc(source[i]));
        //            throw new NotImplementedException();
        //            if (c.Length == 1)
        //            {
        //                //c = "0" + c;
        //                ret.Append("0");
        //            }
        //            ret.Append(c);
        //        }
        //        return ret.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.ReportError(ErrorPolicy.Internal, "Strings.ToHex(string)", ex);
        //        throw;
        //    }
        //}


        /// <summary>
        /// Converts the source integer into a string of hexadecimal characters.
        /// 
        /// Formerly CharToHex()
        /// </summary>
        /// <param name="source">The int to be converted</param>
        /// <returns>The hexidecimal representation of that int</returns>
        /// <example>
        /// .ToHex(255) returns "FF"
        /// .ToHex(16) returns "10"
        /// .ToHex(15) returns "0F"
        /// .ToHex(0) returns "00"
        /// .ToHex(4095) returns "0FFF"
        /// </example>
        public static string ToHex(int source)
        {
            try
            {
                return source.ToString("X");
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Strings.ToHex(int)", ex);
                throw;
            }
        }
        //public static string ToHex_old(int source)
        //{
        //    //TODO: Imlement StarThrower.StringUtil.ToHex(int)
        //    //return Microsoft.VisualBasic.Conversion.Hex(source);
        //    throw new NotImplementedException();
        //}


        /// <summary>
        /// Parses source on delimiter
        /// Each time this method is called, the parsed item is returned, and source is modified
        /// such that the parsed item and its delimiter are removed.
        /// 
        /// Formerly ParseStr()
        /// </summary>
        /// <param name="source">The string to parse</param>
        /// <param name="delimiter">The delimiter on which to parse</param>
        /// <returns>The first token in source delimited by delimiter</returns>
        /// <example>
        /// after the following code executes:
        /// 
        /// string s = "a|s|d|f";
        /// string tok = Strings.ParseString(s, "|");
        /// 
        /// the value of s will be "s|d|f" and the value of tok will be "a"
        /// </example>
        /// <exception cref="ArgumentNullException">Thrown if source or delimiter is null.</exception>
        public static string ParseString(ref string source, string delimiter)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (delimiter == null) throw new ArgumentNullException("delimiter");

            try
            {
                string ret = null;
                StringBuilder temp = new StringBuilder(source);
                int pos = source.IndexOf(delimiter, StringComparison.Ordinal);

                if (pos > -1)
                {
                    ret = StringUtil.Left(source, pos);
                    temp.Remove(0, pos + 1);
                }
                else
                {
                    ret = source;
                    temp.Remove(0, temp.Length);
                }

                source = temp.ToString();
                return ret;
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Strings.ParseString(ref string, string)", ex);
                throw;
            }
        }


        /// <summary>
        /// Parses source on delimiter starting from the end of the string
        /// Each time this method is called, the parsed item is returned, and source is modified
        /// such that the parsed item and its delimiter are removed.
        /// 
        /// Formerly ParseStrRev()
        /// </summary>
        /// <param name="source">The string to parse</param>
        /// <param name="delimiter">The delimiter on which to parse</param>
        /// <returns>The last token in source delimited by delimiter</returns>
        /// <example>
        /// after the following code executes:
        /// 
        /// string s = "a|s|d|f";
        /// string tok = Strings.ParseStringFromRight(s, "|");
        /// 
        /// the value of s will be "a|s|d" and the value of tok will be "f"
        /// </example>
        /// <exception cref="ArgumentNullException">Thrown if source or delimiter is null.</exception>
        public static string ParseStringFromRight(ref string source, string delimiter)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (delimiter == null) throw new ArgumentNullException("delimiter");

            try
            {
                string ret = null;
                StringBuilder temp = new StringBuilder(source);
                int pos = source.LastIndexOf(delimiter, StringComparison.Ordinal);

                if (pos > -1)
                {
                    ret = StringUtil.Right(source, source.Length - (pos + 1));
                    temp.Remove(pos, ret.Length + 1);
                }
                else
                {
                    ret = source;
                    temp.Remove(0, temp.Length);
                }

                source = temp.ToString();
                return ret;
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Strings.ParseStringFromRight(ref string, string)", ex);
                throw;
            }
        }


        /// <summary>
        /// Performs a case-sensitive subtitution of a sub string (target) in a string (source) by a replacement
        /// 
        /// Formerly StrSub()
        /// </summary>
        /// <param name="source">input string</param>
        /// <param name="target">old sub string</param>
        /// <param name="replacement">new string</param>
        /// <returns>string with substitution portioons</returns>
        /// <exception cref="ArgumentNullException">Thrown if source, target, or replacement is null.</exception>
        public static string Substitute(string source, string target, string replacement)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (target == null) throw new ArgumentNullException("target");
            if (replacement == null) throw new ArgumentNullException("replacement");

            try
            {
                return Substitute(source, target, replacement, ComparisonType.CaseSensitive);
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Strings.Substitute(string, string, string)", ex);
                throw;
            }
        }


        /// <summary>
        /// Subtitude a sub string (target) in a string (source) by a replacement
        /// 
        /// Formerly StrSub()
        /// </summary>
        /// <param name="source">input string</param>
        /// <param name="target">old sub string</param>
        /// <param name="replacement">new string</param>
        /// <param name="compare">0 is case-sensitive (default) = vbBinaryCompare; 1 is noncase-sensitive = vbTextCompare; 2 = vbDatabaseCompare</param>
        /// <returns>string with substitution portioons</returns>
        /// <exception cref="ArgumentNullException">Thrown if source, target, or replacement is null.</exception>
        public static string Substitute(string source, string target, string replacement, ComparisonType compare)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (target == null) throw new ArgumentNullException("target");
            if (replacement == null) throw new ArgumentNullException("replacement");

            try
            {
                if (target.Length <= 0) return source.ToString();

                int pos = 0;
                StringBuilder orig = new StringBuilder(source);
                StringBuilder ret = new StringBuilder(String.Empty);

                while (!orig.Equals(String.Empty))
                {
                    //pos = Strings.InStr(orig.ToString(), target, 0, compare);
                    pos = orig.ToString().IndexOf(target, 0, ConvertComparisonType(compare));

                    if (pos > -1)
                    {
                        StringBuilder temp = new StringBuilder(StringUtil.Left(orig.ToString(), pos));
                        temp.Append(replacement);
                        ret.Append(temp);
                    }
                    else
                    {
                        return ret.Append(orig).ToString();
                    }
                    orig.Remove(0, pos + target.Length);
                }

                return ret.Append(orig).ToString();
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Strings.Substitute(string, string, string, ComparisonType)", ex);
                throw;
            }
        }


        /// <summary>
        /// Given a StarThrower.Utilities.ComparisonType, this method will return the
        /// equivalent StringComparison enumeration.
        /// </summary>
        /// <param name="compare">The ComparisonType to be convereted.</param>
        /// <returns>The equivalent, if any, StringComparison enumeration.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if compare is not CaseSensitieve or CaseInsensitive.</exception>
        public static StringComparison ConvertComparisonType(ComparisonType compare)
        {
            switch (compare)
            {
                case ComparisonType.CaseInsensitive:
                    return StringComparison.OrdinalIgnoreCase;
                case ComparisonType.CaseSensitive:
                    return StringComparison.Ordinal;
                default:
                    throw new ArgumentOutOfRangeException("compare");
            }
        }


        /// <summary>
        /// Replaces the region (startIndex + length) of a string with another string and returns the result.
        /// </summary>
        /// <param name="source">The string you want to be operated on.</param>
        /// <param name="replacement">The replacement string.</param>
        /// <param name="startIndex">The zero-based index at which you wish replacement to begin.</param>
        /// <param name="length">The length of replaced characters.</param>
        /// <returns>The modified variation of the source string.</returns>
        /// <exception cref="ArgumentNullException">Thrown if source or replacement is null.</exception>
        public static string Replace(string source, string replacement, int startIndex, int length)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (replacement == null) throw new ArgumentNullException("replacement");

            try
            {
                StringBuilder result = new StringBuilder(String.Empty);

                if (startIndex == 0) //it is at the front
                {
                    result.Append(replacement);
                    result.Append(source.Substring(startIndex + length, source.Length - (startIndex + length)));
                }
                else if ((startIndex + length) == source.Length) //it is at the end
                {
                    result.Append(source.Substring(0, startIndex));
                    result.Append(replacement);
                }
                else //it is somewhere in the middle
                {
                    result.Append(source.Substring(0, startIndex));
                    result.Append(replacement);
                    result.Append(source.Substring(startIndex + length, source.Length - (startIndex + length)));
                }

                return result.ToString();
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Strings.Replace(string, string, int, int)", ex);
                throw;
            }
        }


        /// <summary>
        /// Trims all newline characters (Chr(13) and Chr(10)) from the tail of a string
        /// 
        /// Formerly StrTrimNewLine()
        /// </summary>
        /// <param name="source">The string to be trimmed</param>
        /// <returns>The trimmed string</returns>
        /// <exception cref="ArgumentNullException">Thrown if source is null.</exception>
        public static string TrimCrLf(string source)
        {
            if (source == null) throw new ArgumentNullException("source");

            try
            {
                StringBuilder ret = new StringBuilder(source);

                while (ret[ret.Length - 1].ToString().Equals("\u000A")) //Chr(10), LineFeed, LF
                {
                    ret.Remove(ret.Length - 1, 1);
                }
                while (ret[ret.Length - 1].ToString().Equals("\u000D")) //Chr(13), CarriageReturn, CR
                {
                    ret.Remove(ret.Length - 1, 1);
                }

                return ret.ToString();
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Strings.TrmCrLf(string)", ex);
                throw;
            }
        }


        /// <summary>
        /// gets the leftmost n characters from s
        /// </summary>
        /// <param name="source">the string to be tested</param>
        /// <param name="length">the number of characters to get</param>
        /// <returns>leftmost n characters from s</returns>
        /// <exception cref="ArgumentNullException">Thrown if source is null.</exception>
        public static string Left(string source, int length)
        {
            if (source == null) throw new ArgumentNullException("source");

            try
            {
                return source.Substring(0, length).ToString();
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Strings.Left(string, int)", ex);
                throw;
            }
        }


        /// <summary>
        /// gets the rightmost n characters from s
        /// </summary>
        /// <param name="source">the string to be tested</param>
        /// <param name="length">the number of characters to get</param>
        /// <returns>rightmost n characters from s</returns>
        /// <exception cref="ArgumentNullException">Thrown if source is null.</exception>
        public static string Right(string source, int length)
        {
            if (source == null) throw new ArgumentNullException("source");

            try
            {
                return source.Substring(source.Length - length, length).ToString();
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Strings.Right(string, int)", ex);
                throw;
            }
        }


        /// <summary>
        /// Tests to see if test is wrapped in double quotes and if so returns
        /// test without the double quotes.
        /// 
        /// Formerly StrUnQuoteString
        /// </summary>
        /// <param name="source">The string to be checked</param>
        /// <returns>The string with the outside double quote marks removed</returns>
        /// <exception cref="ArgumentNullException">Thrown if source is null.</exception>
        public static string RemoveDoubleQuoteWrapper(string source)
        {
            if (source == null) throw new ArgumentNullException("source");

            try
            {
                if (source[0].Equals('"') && source[source.Length - 1].Equals('"'))
                {
                    string result = new StringBuilder(source).ToString(1, source.Length - 2);
                    return result;
                    //return Microsoft.VisualBasic.Strings.Mid(source, 2, source.Length - 2); //note need to start at 2 here, because VB is 1-based
                }
                else
                {
                    return source;
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Strings.RemoveDoubleQuoteWrapper(string)", ex);
                throw;
            }
        }


        /// <summary>
        /// Wraps a value in double quotes.
        /// 
        /// Formerly QuotedString()
        /// </summary>
        /// <param name="value">The value to be converted to a string wrapped in double quotes</param>
        /// <returns>A string wrapped in double quotes</returns>
        /// <example>
        /// Strings.DoubleQuoteString("This is a test") will return ""This is a test""
        /// </example>
        /// <exception cref="ArgumentNullException">Thrown if obj is null.</exception>
        public static string WrapWithDoubleQuotes(object value)
        {
            if (value == null) throw new ArgumentNullException("value");

            return "\"" + value.ToString() + "\"";
        }


        /// <summary>
        /// Wraps a value in single quotes, which is useful to have for DB queries
        /// which require an input string to be wrapped in single quotes.
        /// [This method is solely to enhance readability]
        /// 
        /// Formerly SingleQuotedString()
        /// </summary>
        /// <param name="value">The value to be converted to a string wrapped in single quotes</param>
        /// <returns>A string wrapped in single quotes</returns>
        /// <example>
        /// Strings.SingleQuoteString("This is a test") will return "'This is a test'"
        /// </example>
        /// <exception cref="ArgumentNullException">Thrown if obj is null.</exception>
        public static string WrapWithSingleQuotes(object value)
        {
            if (value == null) throw new ArgumentNullException("value");

            return "'" + value.ToString() + "'";
        }


        /// <summary>
        /// Takes a string and puts each character into an array
        /// </summary>
        /// <param name="source">The string to be split into an array</param>
        /// <returns>An array (of string) where each element is a character from the original string</returns>
        /// <exception cref="ArgumentNullException">Thrown if source is null.</exception>
        public static string[] SplitStringIntoArray(string source)
        {
            if (source == null) throw new ArgumentNullException("source");

            try
            {
                string[] chars = new string[source.Length];
                for (int i = 0; i < source.Length; i++)
                {
                    chars[i] = source[i].ToString();
                }
                return chars;
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Strings.SplitStringIntoArray(string)", ex);
                throw;
            }
        }


        /// <summary>
        /// Compares a string with a list of characters.
        /// If all characters in the test string are in the list
        /// of valid characters, then the string is a valid string.
        /// If not, the string is considered an invalid string.
        /// 
        /// This method can be used to verify that the user entered
        /// a valid string for a password or logon id.
        /// </summary>
        /// <param name="test">The string to be tested</param>
        /// <param name="validChars">A string containing a list of characters that are considered valid</param>
        /// <returns>True if test if a valid string</returns>
        /// <example>
        /// IsValidString("yourmama", "abcdef_12345")  returns False (only the letter a is ontained in the list)
        /// IsValidString("cab", "abcdef_12345")  returns True ("c", "a", "b" are contained in the list)
        /// IsValidString("32 bad", "abcdef_12345") returns False (there is no space contained in the list)
        /// IsValidString("32 bad", "abcdef_12345 ") returns True (a space is contained in the list)
        /// </example>
        /// <exception cref="ArgumentNullException">Thrown if test or validChars is null.</exception>
        public static bool IsValidString(string test, string validChars)
        {
            if (test == null) throw new ArgumentNullException("test");
            if (validChars == null) throw new ArgumentNullException("validChars");

            try
            {
                for (int i = 0; i < test.Length; i++)
                {
                    if (!StringUtil.IsValidCharacter(test[i].ToString(), validChars))
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Strings.IsValidString(string, string)", ex);
                throw;
            }
        }


        /// <summary>
        /// Performs a regular expression validation against a test string.
        /// </summary>
        /// <param name="test">The string to be tested.</param>
        /// <param name="regularExpression">The regular expression pattern to test against.</param>
        /// <returns>True if test is a match against regularExpression.</returns>
        /// <exception cref="ArgumentNullException">Thrown if test or regularExpression is null.</exception>
        public static bool IsValid(string test, string regularExpression)
        {
            if (test == null) throw new ArgumentNullException("test");
            if (regularExpression == null) throw new ArgumentNullException("regularExpression");

            try
            {
                Regex regEx = new Regex(regularExpression);
                return regEx.IsMatch(test);
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Strings.IsValid(string, string)", ex);
                throw;
            }
        }


        /// <summary>
        /// Compares a string that is one character long with a list
        /// of characters.  If the character to be tested is in the list
        /// of characters then it is a valid character.  If not, then it
        /// is not a valid character.
        /// </summary>
        /// <param name="test">A string containing 1 character, the character to be tested</param>
        /// <param name="validChars">A string of characters to be tested against</param>
        /// <returns>True if test is in validChars, False if not</returns>
        /// <example>
        /// Strings.IsValidCharacter("A", "abcdef_12345")  returns False
        /// Strings.IsValidCharacter("a", "abcdef_12345")  returns True
        /// Strings.IsValidCharacter(" ", "abcdef_12345")  returns False
        /// Strings.IsValidCharacter(" ", "abcdef_ 12345")  returns True
        /// </example>
        /// <exception cref="ArgumentNullException">Thrown if test or validChars is null.</exception>
        public static bool IsValidCharacter(string test, string validChars)
        {
            if (test == null) throw new ArgumentNullException("test");
            if (validChars == null) throw new ArgumentNullException("validChars");

            try
            {
                if (test.Length <= 0 || test.Length > 1)
                {
                    return false;
                }

                if (validChars.IndexOf(test, 0, StringComparison.Ordinal) == -1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Strings.IsValidCharacter(string, string)", ex);
                throw;
            }
        }


        /// <summary>
        /// Returns the number of tokens in source separated by delimter
        /// </summary>
        /// <param name="source">The string to be tested</param>
        /// <param name="delimiter">The character or string that delimits each token</param>
        /// <returns>The number of tokens in the string</returns>
        /// <remarks>
        /// In general:
        /// If there is a delimiter, a token is assumed to exist on both sides of it.  If there is no actual character
        /// on one side or the other, the token is considered to be equivalent to String.Empty.
        /// 
        /// More specifically:
        /// Rule 1: An empty source is considered to have 1 token which happens to be String.Empty.
        /// Rule 2: A source which does not contain an instance of delimiter is considered to have 1 token which happens to match source.
        /// Rule 3: In all other cases, the number of tokens is the number of delimiters + 1.
        /// 
        /// A couple of examples:
        /// A source string which does not contain an instance of delimiter is considered to be a string with one token.
        /// A source string which contains a single instance of delimiter is considered to be a string with two tokens.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown if source or delimiter is null.</exception>
        public static int CountTokens(string source, string delimiter)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (delimiter == null) throw new ArgumentNullException("delimiter");

            try
            {
                //Rule 1:
                if (String.IsNullOrEmpty(source)) return 1;

                //Rule 2:
                int pos = source.IndexOf(delimiter, StringComparison.Ordinal);
                if (pos < 0) return 1; //delimiter does not exist

                //Rule 3:
                int delimiterCount = 1;
                while (pos >= 0)
                {
                    pos = source.IndexOf(delimiter, pos + delimiter.Length, StringComparison.Ordinal);
                    delimiterCount++;
                }
                return delimiterCount;
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Strings.NumTokens(string, string)", ex);
                throw;
            }
        }


        /// <summary>
        /// Return the token at pos from source separated by delimiter
        /// </summary>
        /// <param name="source">The string to search for the token</param>
        /// <param name="delimiter">The token delimiter</param>
        /// <param name="pos">Which token to return</param>
        /// <returns>Returns the token at pos from source separated by delimiter</returns>
        /// <exception>ArgumentOutOfRangeException</exception>
        /// <remarks>
        /// In general:
        /// If there is a delimiter, a token is assumed to exist on both sides of it.  If there is no actual character
        /// on one side or the other, the token is considered to be equivalent to String.Empty.
        /// 
        /// More specifically:
        /// Rule 1: An empty source is considered to have 1 token which happens to be String.Empty.
        /// Rule 2: A source which does not contain an instance of delimiter is considered to have 1 token which happens to match source.
        /// Rule 3: In all other cases, the number of tokens is the number of delimiters + 1.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown if source or delimiter is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if pos is less than or equal to zero.</exception>
        public static string GetToken(string source, string delimiter, int pos)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (delimiter == null) throw new ArgumentNullException("delimiter");
            if (pos <= 0) throw new ArgumentOutOfRangeException("pos");

            try
            {
                int delPos = -1;
                StringBuilder temp = new StringBuilder(source);

                for (int i = 1; i < pos; i++)
                {
                    delPos = temp.ToString().IndexOf(delimiter, StringComparison.Ordinal);
                    temp.Remove(0, delPos + delimiter.Length);
                    if (delPos == -1) throw new ArgumentOutOfRangeException("delimiter");
                }

                delPos = temp.ToString().IndexOf(delimiter, StringComparison.Ordinal);
                if (delPos < 0)
                {
                    return temp.ToString();
                }
                else
                {
                    return StringUtil.Left(temp.ToString(), delPos);
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Strings.GetToken(string, string, int)", ex);
                throw;
            }
        }


        /// <summary>
        /// Determines if target is a token in source delimited by delimiter
        /// </summary>
        /// <param name="source">The string to search</param>
        /// <param name="target">The token we are looking for</param>
        /// <param name="delimiter">The character(s) which delimit source</param>
        /// <returns>Returns true if target is a token, false if not</returns>
        /// <remarks>
        /// In general:
        /// If there is a delimiter, a token is assumed to exist on both sides of it.  If there is no actual character
        /// on one side or the other, the token is considered to be equivalent to String.Empty.
        /// 
        /// More specifically:
        /// Rule 1: An empty source is considered to have 1 token which happens to be String.Empty.
        /// Rule 2: A source which does not contain an instance of delimiter is considered to have 1 token which happens to match source.
        /// Rule 3: In all other cases, the number of tokens is the number of delimiters + 1.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown if source, target, or delimiter is null.</exception>
        public static bool IsToken(string source, string target, string delimiter)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (target == null) throw new ArgumentNullException("target");
            if (delimiter == null) throw new ArgumentNullException("delimiter");

            try
            {
                long num = StringUtil.CountTokens(source, delimiter);

                for (int i = 1; i <= num; i++)
                {
                    if (StringUtil.GetToken(source, delimiter, i).Equals(target))
                    {
                        return true;
                    }
                }

                //if got to here then the target was not found in the string
                return false;
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Strings.IsToken(string, string, string)", ex);
                throw;
            }
        }


        /// <summary>
        /// Replaces double quotes with two double quotes for use in SQL statements
        /// 
        /// Formerly SQLText()
        /// </summary>
        /// <param name="text">The string which is to be modified</param>
        /// <returns>The string all double quotes doubled</returns>
        /// <exception cref="ArgumentNullException">Thrown if text is null.</exception>
        public static string SqlText(string text)
        {
            if (text == null) throw new ArgumentNullException("text");

            try
            {
                StringBuilder ret = new StringBuilder(text);
                return ret.Replace("\"", "\"\"").ToString();
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Strings.SqlText(string)", ex);
                throw;
            }
        }


        /// <summary>
        /// Strips any quotation marks off the front of a string.
        /// 
        /// Formerly StripLeadingQuotes()
        /// </summary>
        /// <param name="text">The string which is to be checked for preceding quotation marks.</param>
        /// <returns>Returns a string which is either empty or starts with a character which is not a quotation mark.</returns>
        /// <exception cref="ArgumentNullException">Thrown if text is null.</exception>
        public static string StripLeadingDoubleQuotes(string text)
        {
            if (text == null) throw new ArgumentNullException("text");

            try
            {
                if (text.Length == 0) return text;

                string quote = null;
                string firstChar = null;
                StringBuilder ret = new StringBuilder(text);

                quote = ToChar(34);

                firstChar = ret[0].ToString();
                //while ((!ret.ToString().Equals(String.Empty)) && firstChar.Equals(quote))
                while ((!(ret.Length == 0)) && firstChar.Equals(quote))
                {
                    // strip off the first character
                    ret.Remove(0, 1);
                    if (ret.Length > 0)
                    {
                        firstChar = ret[0].ToString();
                    }
                }
                return ret.ToString();
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Strings.StripLeadingDoubleQuotes(string)", ex);
                throw;
            }
        }


        /// <summary>
        /// Returns a string representation of the ascii character code provided
        /// </summary>
        /// <param name="characterCode">a value from 0 to 256 representing an ascii character</param>
        /// <returns>the string representation of the ascii character at charCode</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if characterCode is less than zero or greater than 255.</exception>
        public static string ToChar(int characterCode)
        {
            if (characterCode < 0 || characterCode > 255) throw new ArgumentOutOfRangeException("characterCode");

            if (characterCode < 0 || characterCode > 0x10FFFF)
                throw new ArgumentOutOfRangeException(nameof(characterCode));

            if (characterCode <= 0xFFFF)
            {
                return ((char)characterCode).ToString();
            }
            else
            {
                // Encode as UTF-16 surrogate pair for characters outside BMP
                characterCode -= 0x10000;
                char highSurrogate = (char)(0xD800 + (characterCode >> 10));
                char lowSurrogate = (char)(0xDC00 + (characterCode & 0x3FF));
                return new string(new[] { highSurrogate, lowSurrogate });
            }
        }
        //public static string ToChar_old(int characterCode)
        //{
        //    if (characterCode < 0 || characterCode > 255) throw new ArgumentOutOfRangeException("characterCode");
        //    //TODO: implement StarThrower.StringUtil.ToChar(int)
        //    //return Microsoft.VisualBasic.Strings.ChrW(characterCode).ToString();
        //    throw new NotImplementedException();
        //}


        /// <summary>
        /// Converts a string into its numeric ASCII value.
        /// </summary>
        /// <param name="target">The string to be converted.</param>
        /// <returns>The ASCII value of the string target.</returns>
        /// <exception cref="ArgumentNullException">Thrown if target is null.</exception>
        public static int ToAscii(string target)
        {
            if (target == null) throw new ArgumentNullException("target");

            try
            {
                if (target.Length == 0) throw new ArgumentOutOfRangeException("target");

                // Use the first character of the string
                // Encode to Windows-1252 bytes to match VB.NET's Asc() behavior
                Encoding encoding = Encoding.GetEncoding("Windows-1252");
                byte[] bytes = encoding.GetBytes(target.Substring(0, 1));

                if (bytes.Length == 0) throw new ArgumentOutOfRangeException("target");

                return (int)bytes[0];
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Strings.ToAscii(string)", ex);
                throw;
            }
        }
        //public static int ToAscii_old(string target)
        //{
        //    if (target == null) throw new ArgumentNullException("target");
        //    //TODO: implement StarThrower.StringUtil.ToAscii(string)
        //    //return Microsoft.VisualBasic.Strings.Asc(target);
        //    throw new NotImplementedException();
        //}


        /// <summary>
        /// Returns an XML-safe representation of the string specified by text.
        /// </summary>
        /// <param name="text">The string you want to clean.</param>
        /// <returns>An XML-safe variation of text.</returns>
        /// <exception cref="ArgumentNullException">Thrown if text is null.</exception>
        public static string XmlEncode(string text)
        {
            if (text == null) throw new ArgumentNullException("text");

            try
            {
                StringBuilder result = new StringBuilder(text);
                for (int i = 0; i < _invalidXmlChars.Length; i++)
                {
                    result.Replace(_invalidXmlChars[i].ToString(), "&#" + _invalidXmlCharInts[i].ToString(CultureInfo.InvariantCulture) + ";");
                    result.Replace("\n", " ");
                    result.Replace("\t", " ");
                }
                return result.ToString();
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Strings.XmlEncode(string)", ex);
                throw;
            }
        }


        /// <summary>
        /// Converts a string to a byte array by casting each character to its byte value.
        /// </summary>
        /// <param name="source">The string to be converted to a byte array.</param>
        /// <returns>A byte array where each byte represents the cast value of the corresponding character in the source string.</returns>
        /// <remarks>
        /// This method performs a direct character-to-byte cast for each character. Characters with values greater than 255 will be truncated to their lower 8 bits.
        /// For an empty string, an empty byte array is returned.
        /// This method does not perform encoding; it simply casts each character's numeric value to a byte.
        /// For proper encoding/decoding of strings with specific character sets, consider using Encoding classes directly.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown if source is null.</exception>
        public static byte[] ToByteArray(string source)
        {
            if (source == null) throw new ArgumentNullException("source");

            try
            {
                byte[] result = new byte[source.Length];

                for (int i = 0; i < source.Length; i++)
                {
                    result[i] = (byte)source[i];
                }

                return result;
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Strings.ToByteArray(string)", ex);
                throw;
            }
        }


        /// <summary>
        /// Converts a byte array to a string using ASCII encoding.
        /// </summary>
        /// <param name="target">The byte array to be converted to a string.</param>
        /// <returns>A string representation of the byte array, decoded using ASCII encoding.</returns>
        /// <remarks>
        /// This method uses ASCII encoding to convert bytes to a string. Byte values 0-127 map to standard ASCII characters.
        /// Byte values 128-255 will be replaced with the ASCII replacement character (typically '?') unless the byte sequence forms a valid ASCII sequence.
        /// For an empty byte array, an empty string is returned.
        /// This method is designed primarily for ASCII-compatible data. For other encodings or binary data, consider using Encoding classes directly.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown if target is null.</exception>
        public static string FromByteArray(byte[] target)
        {
            if (target == null) throw new ArgumentNullException("target");

            try
            {
                var encoding = Encoding.GetEncoding("ascii");
                var chars = encoding.GetChars(target, 0, target.Length);
                return new string(chars);
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Strings.FromByteArray(byte[])", ex);
                throw;
            }
        }
        //public static string FromByteArray_old(byte[] target)
        //{
        //    if (target == null) throw new ArgumentNullException("target");
        //    try
        //    {
        //        //TODO: implement StarThrower.StringUtil.FromByteArray(byte[])
        //        //return Encoding.ASCII.GetString(target);
        //        throw new NotImplementedException();
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.ReportError(ErrorPolicy.Internal, "Strings.FromByteArray(byte[])", ex);
        //        throw;
        //    }
        //}


        /// <summary>
        /// Appends space characters to the end of a string to pad it to a target length.
        /// </summary>
        /// <param name="original">The original string to be padded with spaces.</param>
        /// <param name="finalLength">The desired final length of the resulting string.</param>
        /// <returns>A string with space characters appended. If the original string is already >= finalLength, the original string is returned unchanged.</returns>
        /// <remarks>
        /// This method is useful for right-aligning text in fixed-width columns or creating fixed-width string representations.
        /// The number of spaces appended is (finalLength - original.Length), which may be zero or negative. If original.Length >= finalLength, no spaces are added.
        /// For an empty string with finalLength > 0, a string of that many spaces is returned.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown if original is null.</exception>
        public static string AppendSpaces(string original, int finalLength)
        {
            if (original == null) throw new ArgumentNullException("original");

            try
            {
                if (original.Length < finalLength)
                {
                    char[] padding = new char[finalLength - original.Length];
                    for (int i = 0; i < padding.Length; i++)
                    {
                        padding[i] = ' ';
                    }
                    return original + new string(padding);
                }
                else
                {
                    return original;
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Strings.AppendSpaces(string, int)", ex);
                throw;
            }
        }


        /// <summary>
        /// Counts the number of non-overlapping occurrences of a target string within a source string.
        /// </summary>
        /// <param name="source">The string to be searched.</param>
        /// <param name="target">The substring pattern to count.</param>
        /// <returns>The number of non-overlapping times target appears in source. Returns 0 if target is not found.</returns>
        /// <remarks>
        /// The search is case-sensitive and uses ordinal (binary) string comparison.
        /// Matches are non-overlapping: after a match is found, the search continues from the position immediately after that match.
        /// For example, "aaa" contains "aa" exactly 1 time, not 2 times (the overlapping occurrences are not counted).
        /// An empty source string returns 0.
        /// A source string shorter than the target returns 0.
        /// </remarks>
        /// <example>
        /// StringUtil.GetCountOf("hello world hello", "hello") returns 2
        /// StringUtil.GetCountOf("ababab", "ab") returns 3
        /// StringUtil.GetCountOf("aaa", "aa") returns 1 (non-overlapping matches)
        /// StringUtil.GetCountOf("The quick brown fox", "the") returns 0 (case-sensitive search)
        /// StringUtil.GetCountOf("test", "xyz") returns 0
        /// </example>
        /// <exception cref="ArgumentNullException">Thrown if source or target is null.</exception>
        /// <exception cref="ArgumentException">Thrown if target is an empty string.</exception>
        public static int GetCountOf(string source, string target)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (target == null) throw new ArgumentNullException("target");
            if (target.Length == 0) throw new ArgumentException("target cannot be an empty string", "target");

            int result = 0;
            int startIndex = 0;
            int index = source.IndexOf(target, startIndex, StringComparison.Ordinal);
            while (index != -1)
            {
                result++;
                startIndex = index + target.Length;
                if (startIndex >= source.Length)
                {
                    index = -1;
                }
                else
                {
                    index = source.IndexOf(target, startIndex, StringComparison.Ordinal);
                }
            }

            return result;
        }


        /// <summary>
        /// Takes a number and puts it in standard notation if it will not be
        /// more than length spaces long.  Otherwise, it puts it in scientific notation.
        /// This method is intended to be used for something like making a numeric value
        /// fit within a fixed width textbox.
        /// 
        /// Formerly FormatDouble()
        /// </summary>
        /// <param name="number">The number to be formatted</param>
        /// <param name="length">The length after which it must be in Scientific Notation</param>
        /// <returns>A string representation of the number formatted to fit in length</returns>
        /// <exception cref="ArgumentNullException">Thrown if number is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if number is non-numeric.</exception>
        public static string SqueezeNumber(object number, int length)
        {
            if (number == null) throw new ArgumentNullException("number");
            if (!MathUtil.IsNumeric(number.ToString())) throw new ArgumentOutOfRangeException("number");

            try
            {
                return SqueezeNumber(number, length, ScientificNotationFormat.Exponential);
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Strings.SqueezeNumber(object, int)", ex);
                throw;
            }
        }


        /// <summary>
        /// Takes a number and puts it in standard notation if it will not be
        /// more than length spaces long.  Otherwise, it puts it in scientific notation.
        /// This method is intended to be used for something like making a numeric value
        /// fit within a fixed width textbox.
        /// 
        /// Formerly FormatDouble()
        /// </summary>
        /// <param name="number">The number to be formatted</param>
        /// <param name="length">The length after which it must be in Scientific Notation</param>
        /// <param name="format">One of a number of scientific notation formats supported.</param>
        /// <returns>A string representation of the number formatted to fit in length</returns>
        /// <exception cref="ArgumentNullException">Thrown if number is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if number is non-numeric.</exception>
        public static string SqueezeNumber(object number, int length, ScientificNotationFormat format)
        {
            if (number == null) throw new ArgumentNullException("number");
            if (!MathUtil.IsNumeric(number.ToString())) throw new ArgumentOutOfRangeException("number");

            try
            {
                // Format the number with thousand separators (e.g., "1,234,567")
                string formatted = string.Format(CultureInfo.InvariantCulture, "{0:N0}", number);

                if (formatted.Length <= length)
                {
                    return formatted;
                }
                else
                {
                    // Need to use scientific notation
                    double numValue = Convert.ToDouble(number, CultureInfo.InvariantCulture);

                    // Format with E2 (2 decimal places) to match VB.NET's "Scientific" format
                    string eNotation = numValue.ToString("E2", CultureInfo.InvariantCulture);

                    // VB.NET uses 2-digit exponent without leading zero padding
                    // C# "E2" produces "1.00E+010", we need "1.00E+10"
                    eNotation = Regex.Replace(eNotation, @"E([+-])0(\d)", "E$1$2");

                    switch (format)
                    {
                        case ScientificNotationFormat.Exponential:
                            return eNotation;
                        case ScientificNotationFormat.Base10:
                            return ENotationToBaseTenNotation(eNotation, false, false, true, true);
                        case ScientificNotationFormat.Base10Spaced:
                            return ENotationToBaseTenNotation(eNotation, false, true, true, true);
                        case ScientificNotationFormat.Base10Superscript:
                            return ENotationToBaseTenNotation(eNotation, true, false, true, true);
                        case ScientificNotationFormat.Base10SuperscriptSpaced:
                            return ENotationToBaseTenNotation(eNotation, true, true, true, true);
                        default:
                            throw new ArgumentOutOfRangeException("format");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Strings.SqueezeNumber(object, int, ScientificNotationFormat)", ex);
                throw;
            }
        }
        //public static string SqueezeNumber_old(object number, int length, ScientificNotationFormat format)
        //{
        //    if (number == null) throw new ArgumentNullException("number");
        //    if (!MathUtil.IsNumeric(number.ToString())) throw new ArgumentOutOfRangeException("number");
        //    try
        //    {
        //        //TODO: implement StarThrower.StringUtil.SqueezeNumber(object, int, ScientificNotationFormat)
        //        //if (Microsoft.VisualBasic.Strings.Format(number, "#,###,###").Length <= length)
        //        //{
        //        //    return Microsoft.VisualBasic.Strings.Format(number, "#,###,###");
        //        //}
        //        //else
        //        //{
        //        //    switch (format)
        //        //    {
        //        //        case ScientificNotationFormat.Exponential:
        //        //            return Microsoft.VisualBasic.Strings.Format(number, "Scientific");
        //        //        case ScientificNotationFormat.Base10:
        //        //            return ENotationToBaseTenNotation(Microsoft.VisualBasic.Strings.Format(number, "Scientific"), false, false, true, true);
        //        //        case ScientificNotationFormat.Base10Spaced:
        //        //            return ENotationToBaseTenNotation(Microsoft.VisualBasic.Strings.Format(number, "Scientific"), false, true, true, true);
        //        //        case ScientificNotationFormat.Base10Superscript:
        //        //            return ENotationToBaseTenNotation(Microsoft.VisualBasic.Strings.Format(number, "Scientific"), true, false, true, true);
        //        //        case ScientificNotationFormat.Base10SuperscriptSpaced:
        //        //            return ENotationToBaseTenNotation(Microsoft.VisualBasic.Strings.Format(number, "Scientific"), true, true, true, true);
        //        //        default:
        //        //            throw new ArgumentOutOfRangeException("format");
        //        //    }
        //        //}
        //        throw new NotImplementedException();
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.ReportError(ErrorPolicy.Internal, "Strings.SqueezeNumber(object, int, ScientificNotationFormat)", ex);
        //        throw;
        //    }
        //}


        /// <summary>
        /// Converts E notation (scientific notation) to a base-10 power notation with various formatting options.
        /// </summary>
        /// <param name="source">The string in E notation to be converted (e.g., "1.23E+05", "4.56E-10").</param>
        /// <param name="useSuperscript">If true, uses superscript Unicode characters for the exponent (e.g., "12.3 x 10⁵"). If false, uses regular characters (e.g., "12.3 x 10^5").</param>
        /// <param name="spaced">If true, includes spaces around the 'x' multiplier symbol (e.g., "12.3 x 10^5"). If false, uses no spaces (e.g., "12.3x10^5").</param>
        /// <param name="excludePlusSign">If true, omits the plus sign in the exponent (e.g., "10^5" instead of "10^+5"). If false, includes it (e.g., "10^+5").</param>
        /// <param name="excludeZeroPower">If true, returns only the base value when the exponent is 0 (e.g., returns "12.3" instead of "12.3 x 10^0"). If false, always includes the power notation.</param>
        /// <returns>A string representation of the number in base-10 power notation with the specified formatting options.</returns>
        /// <remarks>
        /// If the source string does not contain "E" (case-insensitive), the string is returned unchanged in uppercase.
        /// The method parses the E notation format: base "E" [+|-]exponent (e.g., "1.23E+05", "4.56E-3").
        /// </remarks>
        /// <example>
        /// ENotationToBaseTenNotation("1.23E+05", false, false, true, true) returns "1.23x10^5"
        /// ENotationToBaseTenNotation("1.23E+05", false, true, true, true) returns "1.23 x 10^5"
        /// ENotationToBaseTenNotation("1.23E+05", true, true, true, true) returns "1.23 x 10⁵"
        /// ENotationToBaseTenNotation("1.23E+00", false, false, true, true) returns "1.23" (excludeZeroPower=true)
        /// </example>
        /// <exception cref="ArgumentNullException">Thrown if source is null.</exception>
        static public string ENotationToBaseTenNotation(string source, bool useSuperscript, bool spaced, bool excludePlusSign, bool excludeZeroPower)
        {
            if (source == null) throw new ArgumentNullException("source");

            try
            {
                string temp = source.ToUpperInvariant();
                if (!temp.Contains("E")) return temp;
                int eIndex = temp.IndexOf("E", StringComparison.Ordinal);
                string baseVal = temp.Substring(0, eIndex);
                string power = temp.Substring(eIndex + 1, temp.Length - (eIndex + 1));
                int pow = 0;
                if (!int.TryParse(power, out pow)) throw new ArgumentOutOfRangeException("source");
                if (excludeZeroPower && pow == 0)
                {
                    return baseVal;
                }
                else
                {
                    if (useSuperscript && spaced)
                    {

                        if (excludePlusSign)
                        {
                            return baseVal + " x 10" + StringUtil.ToSuperscript(power.Replace("+", String.Empty));
                        }
                        else
                        {
                            return baseVal + " x 10" + StringUtil.ToSuperscript(power);
                        }
                    }
                    else if (!useSuperscript && spaced)
                    {
                        if (excludePlusSign)
                        {
                            return temp.Replace("E", " x 10^").Replace("+", String.Empty);
                        }
                        else
                        {
                            return temp.Replace("E", " x 10^");
                        }
                    }
                    else if (useSuperscript && !spaced)
                    {
                        if (excludePlusSign)
                        {
                            return baseVal + "x10" + StringUtil.ToSuperscript(power.Replace("+", String.Empty));
                        }
                        else
                        {
                            return baseVal + "x10" + StringUtil.ToSuperscript(power);
                        }
                    }
                    else
                    {
                        if (excludePlusSign)
                        {
                            return temp.Replace("E", "x10^").Replace("+", String.Empty);
                        }
                        else
                        {
                            return temp.Replace("E", "x10^");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Strings.ENotationToPowerOfTenNotation(string, bool, bool, bool, bool)", ex);
                throw;
            }
        }


        /// <summary>
        /// Converts a string representation of a whole number into a superscript string representation of that number.
        /// </summary>
        /// <param name="target">A string representation of a whole number. May optionally begin with a single '+' or '-' sign character.</param>
        /// <returns>A string where each character (including the optional sign) is replaced with its corresponding Unicode superscript equivalent.</returns>
        /// <remarks>
        /// Supported characters are the digits 0-9 and optionally a leading '+' or '-' sign.
        /// A '+' sign is converted to SuperscriptPlus (U+207A), a '-' sign to SuperscriptMinus (U+207B), and digits 0-9 to their respective superscript equivalents.
        /// Only a single leading sign is permitted; signs in other positions or multiple consecutive signs will cause an ArgumentOutOfRangeException.
        /// A sign character alone ('+' or '-' with no digits) is not a valid integer and will throw ArgumentOutOfRangeException.
        /// An empty string is not a valid integer and will throw ArgumentOutOfRangeException.
        /// Leading zeros are preserved in the output (e.g., "+007" produces SuperscriptPlus + Superscript0 + Superscript0 + Superscript7).
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown if target is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if target is not a valid whole number (empty, contains invalid characters, or has improperly positioned signs).</exception>
        public static string ToSuperscript(string target)
        {
            if (target == null) throw new ArgumentNullException("target");
            if (!MathUtil.IsInteger(target)) throw new ArgumentOutOfRangeException("target");

            try
            {
                StringBuilder result = new StringBuilder(String.Empty);

                for (int i = 0; i < target.Length; i++)
                {
                    switch (target[i])
                    {
                        case '0':
                            result.Append(Superscript0);
                            break;
                        case '1':
                            result.Append(Superscript1);
                            break;
                        case '2':
                            result.Append(Superscript2);
                            break;
                        case '3':
                            result.Append(Superscript3);
                            break;
                        case '4':
                            result.Append(Superscript4);
                            break;
                        case '5':
                            result.Append(Superscript5);
                            break;
                        case '6':
                            result.Append(Superscript6);
                            break;
                        case '7':
                            result.Append(Superscript7);
                            break;
                        case '8':
                            result.Append(Superscript8);
                            break;
                        case '9':
                            result.Append(Superscript9);
                            break;
                        case '+':
                            result.Append(SuperscriptPlus);
                            break;
                        case '-':
                            result.Append(SuperscriptMinus);
                            break;
                        default:
                            throw new NotSupportedException();
                    }
                }

                return result.ToString();
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Strings.ToSuperscript(string)", ex);
                throw;
            }
        }


        /// <summary>
        /// Converts a DateTime to an ISO 8601 XML-compatible string format.
        /// The output format is YYYY-MM-DDTHH:MM:SS.fffZ (where f = millisecond).
        /// </summary>
        /// <param name="dt">The DateTime value to be converted.</param>
        /// <returns>A string representation of the DateTime in XML format with UTC indicator (Z suffix).</returns>
        /// <example>
        /// new DateTime(2024, 3, 15, 14, 30, 45, 123).ToXmlString() returns "2024-03-15T14:30:45.123Z"
        /// new DateTime(1, 1, 1, 0, 0, 0, 0).ToXmlString() returns "0001-01-01T00:00:00.0Z"
        /// new DateTime(2024, 1, 5, 9, 5, 9, 9).ToXmlString() returns "2024-01-05T09:05:09.9Z"
        /// </example>
        /// <remarks>
        /// The format specification:
        /// - YYYY: 4-digit year (zero-padded, e.g., "0001" to "9999")
        /// - MM: 2-digit month (zero-padded, 01-12)
        /// - DD: 2-digit day (zero-padded, 01-31)
        /// - T: Literal separator between date and time components
        /// - HH: 2-digit hour (zero-padded, 00-23)
        /// - MM: 2-digit minute (zero-padded, 00-59)
        /// - SS: 2-digit second (zero-padded, 00-59)
        /// - fff: Milliseconds (NOT zero-padded, 0-999)
        /// - Z: UTC/Zulu time indicator (literal suffix)
        /// </remarks>
        public static string ToXmlString(this DateTime dt)
        {
            string YYYY = null;
            string MM = null;
            string DD = null;
            string hh = null;
            string mm = null;
            string ss = null;
            string s = null;

            if (dt.Year < 10)
            {
                YYYY = "000" + dt.Year.ToString(CultureInfo.InvariantCulture);
            }
            else if (dt.Year < 100)
            {
                YYYY = "00" + dt.Year.ToString(CultureInfo.InvariantCulture);
            }
            else if (dt.Year < 1000)
            {
                YYYY = "0" + dt.Year.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                YYYY = dt.Year.ToString(CultureInfo.InvariantCulture);
            }

            if (dt.Month < 10)
            {
                MM = "0" + dt.Month.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                MM = dt.Month.ToString(CultureInfo.InvariantCulture);
            }

            if (dt.Day < 10)
            {
                DD = "0" + dt.Day.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                DD = dt.Day.ToString(CultureInfo.InvariantCulture);
            }

            if (dt.Hour < 10)
            {
                hh = "0" + dt.Hour.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                hh = dt.Hour.ToString(CultureInfo.InvariantCulture);
            }

            if (dt.Minute < 10)
            {
                mm = "0" + dt.Minute.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                mm = dt.Minute.ToString(CultureInfo.InvariantCulture);
            }

            if (dt.Second < 10)
            {
                ss = "0" + dt.Second.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                ss = dt.Second.ToString(CultureInfo.InvariantCulture);
            }

            s = dt.Millisecond.ToString(CultureInfo.InvariantCulture);

            StringBuilder sb = new StringBuilder();

            sb.Append(YYYY + "-");
            sb.Append(MM + "-");
            sb.Append(DD + "T");
            sb.Append(hh + ":");
            sb.Append(mm + ":");
            sb.Append(ss + ".");
            sb.Append(s);
            sb.Append("Z");

            return sb.ToString();
        }


        /// <summary>
        /// Converts a TimeSpan to an ISO 8601 XML-compatible duration string format.
        /// The output format is P[n]Y[n]M[n]DT[n]H[n]M[n.nnn]S (where n = numeric value).
        /// </summary>
        /// <param name="ts">The TimeSpan value to be converted.</param>
        /// <returns>A string representation of the TimeSpan in ISO 8601 duration format (XML schema duration type).</returns>
        /// <example>
        /// TimeSpan.Zero.ToXmlString() returns "P0Y0M0DT0H0M0.0S"
        /// TimeSpan.FromDays(1).ToXmlString() returns "P0Y0M1DT0H0M0.0S"
        /// TimeSpan.FromDays(365).ToXmlString() returns "P1Y0M0DT0H0M0.0S"
        /// TimeSpan.FromDays(400).Add(TimeSpan.FromHours(5)).Add(TimeSpan.FromMinutes(30)).Add(TimeSpan.FromSeconds(45.250)).ToXmlString() returns "P1Y1M5DT5H30M45.250S"
        /// </example>
        /// <remarks>
        /// The format specification:
        /// - P: Literal prefix denoting "Period" (required)
        /// - Y: Year component (calculated as days / 365, NOT zero-padded)
        /// - M: Month component (calculated as remaining days / 30, NOT zero-padded)
        /// - D: Day component (calculated as remaining days after years and months, NOT zero-padded)
        /// - T: Literal separator between date and time components (required if time present)
        /// - H: Hour component (0-23, NOT zero-padded)
        /// - M: Minute component (0-59, NOT zero-padded; appears after T and before M seconds)
        /// - S: Second component with millisecond precision (NOT zero-padded, format is SS.sss where sss = milliseconds)
        /// 
        /// Important notes on conversion:
        /// - This method uses simplified approximations: 1 year = 365 days, 1 month = 30 days
        /// - Days are not zero-padded in the output
        /// - TimeSpan does not support negative durations; behavior with negative TimeSpans is undefined
        /// - Milliseconds are included as fractional seconds and are NOT zero-padded
        /// </remarks>
        public static string ToXmlString(this TimeSpan ts)
        {
            string yrs = "0";
            string mos = "0";
            string days = "0";
            string hrs = "0";
            string min = "0";
            string sec = "0.0";


            int tsDays = ts.Days;

            int y = tsDays / 365;
            int m = (tsDays - (y * 365)) / 30;
            int d = (tsDays - (y * 365 + m * 30));

            yrs = y.ToString(CultureInfo.InvariantCulture);
            mos = m.ToString(CultureInfo.InvariantCulture);
            days = d.ToString(CultureInfo.InvariantCulture);

            hrs = ts.Hours.ToString(CultureInfo.InvariantCulture);
            min = ts.Minutes.ToString(CultureInfo.InvariantCulture);
            sec = ts.Seconds.ToString(CultureInfo.InvariantCulture) + "." + ts.Milliseconds.ToString(CultureInfo.InvariantCulture);


            StringBuilder sb = new StringBuilder();

            sb.Append("P" + yrs + "Y");
            sb.Append(mos + "M");
            sb.Append(days + "D");
            sb.Append("T" + hrs + "H");
            sb.Append(min + "M");
            sb.Append(sec + "S");

            return sb.ToString();
        }
    }
}
