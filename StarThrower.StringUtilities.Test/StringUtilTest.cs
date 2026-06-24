// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AwesomeAssertions;
using Xunit;
using StarThrower.StringUtilities;

namespace StarThrower.StringUtilities.Test
{
    public class StringUtilTest
    {
        #region ToHex(string) tests

        [Fact]
        public void TestCharToHex1()
        {
            (StringUtil.ToHex(Microsoft.VisualBasic.Strings.Chr(0).ToString())).Should().Be("00");
        }

        [Fact]
        public void TestCharToHex2()
        {
            (StringUtil.ToHex(" ")).Should().Be("20");
        }

        [Fact]
        public void TestCharToHex3()
        {
            (StringUtil.ToHex("A")).Should().Be("41");
        }

        [Fact]
        public void TestCharToHex4()
        {
            (StringUtil.ToHex("ASDF")).Should().Be("41534446");
        }

        [Fact]
        public void TestCharToHex5()
        {
            (StringUtil.ToHex("asdf")).Should().Be("61736466");
        }

        [Fact]
        public void TestCharToHex6()
        {
            (StringUtil.ToHex(Microsoft.VisualBasic.Strings.Chr(127).ToString())).Should().Be("7F");
        }

        [Fact]
        public void TestCharToHex7()
        {
            (StringUtil.ToHex(Microsoft.VisualBasic.Strings.Chr(128).ToString())).Should().Be("80");
        }

        [Fact]
        public void TestCharToHex8()
        {
            (StringUtil.ToHex(Microsoft.VisualBasic.Strings.Chr(255).ToString())).Should().Be("FF");
        }

        [Fact]
        public void TestCharToHex9EmptyString()
        {
            // Empty string should return empty hex string
            (StringUtil.ToHex("")).Should().Be("");
        }

        [Fact]
        public void TestCharToHex10SingleDigit()
        {
            // Test numeric character
            (StringUtil.ToHex("0")).Should().Be("30");
        }

        [Fact]
        public void TestCharToHex11Numbers()
        {
            // Test numeric string
            (StringUtil.ToHex("01234")).Should().Be("3031323334");
        }

        [Fact]
        public void TestCharToHex12SpecialCharacters()
        {
            // Test special characters (!, @, #, $)
            (StringUtil.ToHex("!@#$")).Should().Be("21402324");
        }

        [Fact]
        public void TestCharToHex13Punctuation()
        {
            // Test various punctuation marks
            (StringUtil.ToHex(",.;")).Should().Be("2C2E3B");
        }

        [Fact]
        public void TestCharToHex14MixedCase()
        {
            // Test mixed case (HoLLo - two capital L's)
            (StringUtil.ToHex("HoLLo")).Should().Be("486F4C4C6F");
        }

        [Fact]
        public void TestCharToHex15Tab()
        {
            // Test tab character
            (StringUtil.ToHex("\t")).Should().Be("09");
        }

        [Fact]
        public void TestCharToHex16Newline()
        {
            // Test newline character
            (StringUtil.ToHex("\n")).Should().Be("0A");
        }

        [Fact]
        public void TestCharToHex17CarriageReturn()
        {
            // Test carriage return character
            (StringUtil.ToHex("\r")).Should().Be("0D");
        }

        [Fact]
        public void TestCharToHex18LongString()
        {
            // Test a longer string
            (StringUtil.ToHex("The quick brown fox")).Should().Be("54686520717569636B2062726F776E20666F78");
        }

        [Fact]
        public void TestCharToHex19AllExtendedAsciiRange()
        {
            // Test boundary between ASCII and extended ASCII (char 126 and 127)
            (StringUtil.ToHex("~")).Should().Be("7E");
        }

        [Fact]
        public void TestCharToHex20ExtendedAsciiLow()
        {
            // Test extended ASCII lower range
            (StringUtil.ToHex(Microsoft.VisualBasic.Strings.Chr(128).ToString())).Should().Be("80");
        }

        [Fact]
        public void TestCharToHex21ExtendedAsciiMid()
        {
            // Test extended ASCII middle range (example: 192)
            (StringUtil.ToHex(Microsoft.VisualBasic.Strings.Chr(192).ToString())).Should().Be("C0");
        }

        [Fact]
        public void TestCharToHex22ConsecutiveSpecialChars()
        {
            // Test consecutive special characters
            (StringUtil.ToHex("()")).Should().Be("2829");
        }

        [Fact]
        public void TestCharToHex23AllSpaces()
        {
            // Test multiple spaces
            (StringUtil.ToHex("   ")).Should().Be("202020");
        }

        [Fact]
        public void TestCharToHex24NullString()
        {
            // Test null string throws exception
            Action act = () => StringUtil.ToHex(null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestCharToHex25QuotationMarks()
        {
            // Test quotation marks
            (StringUtil.ToHex("\"")).Should().Be("22");
        }

        [Fact]
        public void TestCharToHex26SingleQuote()
        {
            // Test single quote
            (StringUtil.ToHex("'")).Should().Be("27");
        }

        [Fact]
        public void TestCharToHex27Backslash()
        {
            // Test backslash
            (StringUtil.ToHex("\\")).Should().Be("5C");
        }

        [Fact]
        public void TestCharToHex28ForwardSlash()
        {
            // Test forward slash
            (StringUtil.ToHex("/")).Should().Be("2F");
        }

        [Fact]
        public void TestCharToHex29Equals()
        {
            // Test equals sign
            (StringUtil.ToHex("=")).Should().Be("3D");
        }

        [Fact]
        public void TestCharToHex30Underscore()
        {
            // Test underscore
            (StringUtil.ToHex("_")).Should().Be("5F");
        }

        #endregion


        #region ToHex(int) tests

        [Fact]
        public void TestToHexInt1()
        {
            // Test zero
            (StringUtil.ToHex(0)).Should().Be("0");
        }

        [Fact]
        public void TestToHexInt2()
        {
            // Test single digit hex (1-15)
            (StringUtil.ToHex(1)).Should().Be("1");
        }

        [Fact]
        public void TestToHexInt3()
        {
            // Test single digit hex (1-15)
            (StringUtil.ToHex(15)).Should().Be("F");
        }

        [Fact]
        public void TestToHexInt4()
        {
            // Test two digit hex
            (StringUtil.ToHex(16)).Should().Be("10");
        }

        [Fact]
        public void TestToHexInt5()
        {
            // Test ASCII 'A' (65)
            (StringUtil.ToHex(65)).Should().Be("41");
        }

        [Fact]
        public void TestToHexInt6()
        {
            // Test 255 (max unsigned byte)
            (StringUtil.ToHex(255)).Should().Be("FF");
        }

        [Fact]
        public void TestToHexInt7()
        {
            // Test 256 (overflow from byte range)
            (StringUtil.ToHex(256)).Should().Be("100");
        }

        [Fact]
        public void TestToHexInt8()
        {
            // Test larger number
            (StringUtil.ToHex(4096)).Should().Be("1000");
        }

        [Fact]
        public void TestToHexInt9()
        {
            // Test max int
            (StringUtil.ToHex(int.MaxValue)).Should().Be("7FFFFFFF");
        }

        [Fact]
        public void TestToHexInt10()
        {
            // Test negative number (two's complement representation)
            (StringUtil.ToHex(-1)).Should().Be("FFFFFFFF");
        }

        [Fact]
        public void TestToHexInt11()
        {
            // Test negative number
            (StringUtil.ToHex(-16)).Should().Be("FFFFFFF0");
        }

        [Fact]
        public void TestToHexInt12()
        {
            // Test min int
            (StringUtil.ToHex(int.MinValue)).Should().Be("80000000");
        }

        [Fact]
        public void TestToHexInt13()
        {
            // Test common byte value
            (StringUtil.ToHex(32)).Should().Be("20");
        }

        [Fact]
        public void TestToHexInt14()
        {
            // Test common byte value matching ToHex(string) test
            (StringUtil.ToHex(255)).Should().Be("FF");
        }

        #endregion


        #region ParseString(ref string, string) tests

        [Fact]
        public void TestParseString1()
        {
            string s = "a|s|d|f";
            string? tok = null;

            tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be("a");
            (s).Should().Be("s|d|f");

            tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be("s");
            (s).Should().Be("d|f");

            tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be("d");
            (s).Should().Be("f");

            tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be("f");
            (s).Should().Be("");

            tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be("");
            (s).Should().Be("");
        }

        [Fact]
        public void TestParseStringEdgeCase1()
        {
            string s = "||||";
            string? tok = null;

            tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be(String.Empty);
            (s).Should().Be("|||");

            tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be(String.Empty);
            (s).Should().Be("||");

            tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be(String.Empty);
            (s).Should().Be("|");

            tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be(String.Empty);
            (s).Should().Be(String.Empty);
        }

        [Fact]
        public void TestParseStringEdgeCase2()
        {
            string s = "|a|s|d|f";
            string? tok = null;

            tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be(String.Empty);
            (s).Should().Be("a|s|d|f");

            tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be("a");
            (s).Should().Be("s|d|f");

            tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be("s");
            (s).Should().Be("d|f");

            tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be("d");
            (s).Should().Be("f");

            tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be("f");
            (s).Should().Be(String.Empty);
        }

        [Fact]
        public void TestParseStringEdgeCase3()
        {
            string s = "|a|s|d|f|";
            string? tok = null;

            tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be(String.Empty);
            (s).Should().Be("a|s|d|f|");

            tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be("a");
            (s).Should().Be("s|d|f|");

            tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be("s");
            (s).Should().Be("d|f|");

            tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be("d");
            (s).Should().Be("f|");

            tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be("f");
            (s).Should().Be(String.Empty);

            tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be(String.Empty);
            (s).Should().Be(String.Empty);
        }

        [Fact]
        public void TestParseString2()
        {
            string s = "asdf|qwer|zxcv|1234";
            string? tok = null;

            tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be("asdf");
            (s).Should().Be("qwer|zxcv|1234");

            tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be("qwer");
            (s).Should().Be("zxcv|1234");

            tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be("zxcv");
            (s).Should().Be("1234");

            tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be("1234");
            (s).Should().Be("");

            tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be("");
            (s).Should().Be("");
        }

        [Fact]
        public void TestParseString3NoDelimiterFound()
        {
            // Test when delimiter is not found - should return entire string and clear it
            string s = "hello";
            string tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be("hello");
            (s).Should().Be("");
        }

        [Fact]
        public void TestParseString4SingleCharDelimiter()
        {
            // Test with a single character delimiter
            string s = "one:two:three";
            string tok = StringUtil.ParseString(ref s, ":");
            (tok).Should().Be("one");
            (s).Should().Be("two:three");
        }

        [Fact]
        public void TestParseString5MultiCharDelimiter()
        {
            // Note: ParseString only removes pos+1 chars, so multi-char delimiters will leave extra chars
            // This test documents the actual behavior
            string s = "part1::part2::part3";
            string tok = StringUtil.ParseString(ref s, "::");
            (tok).Should().Be("part1");
            // It removes only the first ':' not both, leaving ":part2::part3"
            (s).Should().Be(":part2::part3");
        }

        [Fact]
        public void TestParseString6SpaceDelimiter()
        {
            // Test with space as delimiter
            string s = "hello world test";
            string tok = StringUtil.ParseString(ref s, " ");
            (tok).Should().Be("hello");
            (s).Should().Be("world test");
        }

        [Fact]
        public void TestParseString7CommaDelimiter()
        {
            // Test with comma delimiter
            string s = "item1,item2,item3";
            string tok = StringUtil.ParseString(ref s, ",");
            (tok).Should().Be("item1");
            (s).Should().Be("item2,item3");
        }

        [Fact]
        public void TestParseString8SingleToken()
        {
            // Test string with single token and delimiter
            string s = "token|";
            string tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be("token");
            (s).Should().Be("");
        }

        [Fact]
        public void TestParseString9EmptyTokenAtEnd()
        {
            // Test parsing to get empty token at end
            string s = "a|b|";
            string tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be("a");
            (s).Should().Be("b|");

            tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be("b");
            (s).Should().Be("");

            tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be("");
            (s).Should().Be("");
        }

        [Fact]
        public void TestParseString10NumericStrings()
        {
            // Test with numeric strings
            string s = "123|456|789";
            string tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be("123");
            (s).Should().Be("456|789");
        }

        [Fact]
        public void TestParseString11SpecialCharactersInTokens()
        {
            // Test with special characters in tokens
            string s = "test@email|another#tag|final$";
            string tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be("test@email");
            (s).Should().Be("another#tag|final$");
        }

        [Fact]
        public void TestParseString12DelimiterAtStart()
        {
            // Test with delimiter at very start
            string s = "|token";
            string tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be("");
            (s).Should().Be("token");
        }

        [Fact]
        public void TestParseString13DelimiterOnly()
        {
            // Test with only the delimiter
            string s = "|";
            string tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be("");
            (s).Should().Be("");
        }

        [Fact]
        public void TestParseString14LongDelimiter()
        {
            // Test with longer delimiter sequence
            // Note: ParseString only removes pos+1 chars, so multi-char delimiters will leave extra chars
            string s = "first---second---third";
            string tok = StringUtil.ParseString(ref s, "---");
            (tok).Should().Be("first");
            // It removes only one dash, leaving "--second---third"
            (s).Should().Be("--second---third");
        }

        [Fact]
        public void TestParseString15ConsecutiveDelimiters()
        {
            // Test with consecutive delimiters
            // Note: ParseString only removes pos+1 chars, so multi-char delimiters will leave extra chars
            string s = "a||b||c";
            string tok = StringUtil.ParseString(ref s, "||");
            (tok).Should().Be("a");
            // It removes only one pipe, leaving "|b||c"
            (s).Should().Be("|b||c");
        }

        [Fact]
        public void TestParseString16MixedContent()
        {
            // Test with mixed alphanumeric and special characters
            string s = "User123|Pass@456!|Email#789";
            string tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be("User123");
            (s).Should().Be("Pass@456!|Email#789");
        }

        [Fact]
        public void TestParseString17CaseSensitiveDelimiter()
        {
            // Test that delimiter is case-sensitive
            string s = "A|B|C";
            string tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be("A");
            (s).Should().Be("B|C");
        }

        [Fact]
        public void TestParseString18TabDelimiter()
        {
            // Test with tab as delimiter
            string s = "col1\tcol2\tcol3";
            string tok = StringUtil.ParseString(ref s, "\t");
            (tok).Should().Be("col1");
            (s).Should().Be("col2\tcol3");
        }

        [Fact]
        public void TestParseString19NewlineDelimiter()
        {
            // Test with newline as delimiter
            string s = "line1\nline2\nline3";
            string tok = StringUtil.ParseString(ref s, "\n");
            (tok).Should().Be("line1");
            (s).Should().Be("line2\nline3");
        }

        [Fact]
        public void TestParseString20NullSource()
        {
            // Test null source throws exception
            string s = null!;
            Action act = () => StringUtil.ParseString(ref s, "x");
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestParseString21NullDelimiter()
        {
            // Test null delimiter throws exception
            string s = "test";
            Action act = () => StringUtil.ParseString(ref s, null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestParseString22WhitespaceTokens()
        {
            // Test parsing tokens that are whitespace
            string s = "  | \t | ";
            string tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be("  ");
            (s).Should().Be(" \t | ");
        }

        [Fact]
        public void TestParseString23VeryLongToken()
        {
            // Test with very long tokens
            string s = new string('a', 1000) + "|" + new string('b', 1000);
            string tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be(new string('a', 1000));
            (s).Should().Be(new string('b', 1000));
        }

        [Fact]
        public void TestParseString24DelimiterLongerThanContent()
        {
            // Test with delimiter longer than content
            string s = "ab";
            string tok = StringUtil.ParseString(ref s, "delimiter");
            (tok).Should().Be("ab");
            (s).Should().Be("");
        }

        [Fact]
        public void TestParseString25DelimiterEqualsContent()
        {
            // Test where delimiter equals entire content
            string s = "|";
            string tok = StringUtil.ParseString(ref s, "|");
            (tok).Should().Be("");
            (s).Should().Be("");
        }

        #endregion


        #region ParseStringFromRight(ref string, string) tests

        [Fact]
        public void TestParseStringFromRight1()
        {
            string s = "a|s|d|f";
            string? tok = null;

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("f");
            (s).Should().Be("a|s|d");

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("d");
            (s).Should().Be("a|s");

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("s");
            (s).Should().Be("a");

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("a");
            (s).Should().Be("");

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("");
            (s).Should().Be("");
        }

        [Fact]
        public void TestParseStringFromRightEdgeCase1()
        {
            string s = "||||";
            string? tok = null;

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be(String.Empty);
            (s).Should().Be("|||");

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be(String.Empty);
            (s).Should().Be("||");

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be(String.Empty);
            (s).Should().Be("|");

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be(String.Empty);
            (s).Should().Be(String.Empty);

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be(String.Empty);
            (s).Should().Be(String.Empty);
        }

        [Fact]
        public void TestParseStringFromRightEdgeCase2()
        {
            string s = "|a|s|d|f";
            string? tok = null;

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("f");
            (s).Should().Be("|a|s|d");

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("d");
            (s).Should().Be("|a|s");

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("s");
            (s).Should().Be("|a");

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("a");
            (s).Should().Be(String.Empty);

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be(String.Empty);
            (s).Should().Be(String.Empty);
        }

        [Fact]
        public void TestParseStringFromRightEdgeCase3()
        {
            string s = "|a|s|d|f|";
            string? tok = null;

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be(String.Empty);
            (s).Should().Be("|a|s|d|f");

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("f");
            (s).Should().Be("|a|s|d");

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("d");
            (s).Should().Be("|a|s");

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("s");
            (s).Should().Be("|a");

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("a");
            (s).Should().Be(String.Empty);

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be(String.Empty);
            (s).Should().Be(String.Empty);
        }

        [Fact]
        public void TestParseStringFromRight2()
        {
            string s = "asdf|qwer|zxcv|1234";
            string? tok = null;

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("1234");
            (s).Should().Be("asdf|qwer|zxcv");

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("zxcv");
            (s).Should().Be("asdf|qwer");

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("qwer");
            (s).Should().Be("asdf");

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("asdf");
            (s).Should().Be("");

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("");
            (s).Should().Be("");
        }

        [Fact]
        public void TestParseStringFromRight3NoDelimiterFound()
        {
            // Test when delimiter is not found - should return entire string and clear it
            string s = "hello";
            string tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("hello");
            (s).Should().Be("");
        }

        [Fact]
        public void TestParseStringFromRight4SingleCharDelimiter()
        {
            // Test with a single character delimiter
            string s = "one:two:three";
            string tok = StringUtil.ParseStringFromRight(ref s, ":");
            (tok).Should().Be("three");
            (s).Should().Be("one:two");
        }

        [Fact]
        public void TestParseStringFromRight5MultiCharDelimiter()
        {
            // Note: ParseStringFromRight has similar behavior to ParseString with multi-char delimiters
            // It removes pos + ret.Length + 1, which may not be the full delimiter length
            string s = "part1::part2::part3";
            string tok = StringUtil.ParseStringFromRight(ref s, "::");
            (tok).Should().Be(":part3");
            // It leaves "part1::part2" but the token includes the extra ':'
            (s).Should().Be("part1::part2");
        }

        [Fact]
        public void TestParseStringFromRight6SpaceDelimiter()
        {
            // Test with space as delimiter
            string s = "hello world test";
            string tok = StringUtil.ParseStringFromRight(ref s, " ");
            (tok).Should().Be("test");
            (s).Should().Be("hello world");
        }

        [Fact]
        public void TestParseStringFromRight7CommaDelimiter()
        {
            // Test with comma delimiter
            string s = "item1,item2,item3";
            string tok = StringUtil.ParseStringFromRight(ref s, ",");
            (tok).Should().Be("item3");
            (s).Should().Be("item1,item2");
        }

        [Fact]
        public void TestParseStringFromRight8SingleToken()
        {
            // Test string with single token and delimiter at end
            string s = "token|";
            string tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("");
            (s).Should().Be("token");
        }

        [Fact]
        public void TestParseStringFromRight9EmptyTokenAtStart()
        {
            // Test parsing to get empty token at start
            string s = "|a|b";
            string tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("b");
            (s).Should().Be("|a");

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("a");
            (s).Should().Be("");

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("");
            (s).Should().Be("");
        }

        [Fact]
        public void TestParseStringFromRight10NumericStrings()
        {
            // Test with numeric strings
            string s = "123|456|789";
            string tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("789");
            (s).Should().Be("123|456");
        }

        [Fact]
        public void TestParseStringFromRight11SpecialCharactersInTokens()
        {
            // Test with special characters in tokens
            string s = "test@email|another#tag|final$";
            string tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("final$");
            (s).Should().Be("test@email|another#tag");
        }

        [Fact]
        public void TestParseStringFromRight12DelimiterAtEnd()
        {
            // Test with delimiter at very end
            string s = "token|";
            string tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("");
            (s).Should().Be("token");
        }

        [Fact]
        public void TestParseStringFromRight13DelimiterOnly()
        {
            // Test with only the delimiter
            string s = "|";
            string tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("");
            (s).Should().Be("");
        }

        [Fact]
        public void TestParseStringFromRight14LongDelimiter()
        {
            // Test with longer delimiter sequence
            // Note: similar limitation with multi-char delimiters
            string s = "first---second---third";
            string tok = StringUtil.ParseStringFromRight(ref s, "---");
            (tok).Should().Be("--third");
            // It leaves "first---second"
            (s).Should().Be("first---second");
        }

        [Fact]
        public void TestParseStringFromRight15ConsecutiveDelimiters()
        {
            // Test with consecutive delimiters
            // Note: similar limitation with multi-char delimiters
            string s = "a||b||c";
            string tok = StringUtil.ParseStringFromRight(ref s, "||");
            (tok).Should().Be("|c");
            // It leaves "a||b" 
            (s).Should().Be("a||b");
        }

        [Fact]
        public void TestParseStringFromRight16MixedContent()
        {
            // Test with mixed alphanumeric and special characters
            string s = "User123|Pass@456!|Email#789";
            string tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("Email#789");
            (s).Should().Be("User123|Pass@456!");
        }

        [Fact]
        public void TestParseStringFromRight17CaseSensitiveDelimiter()
        {
            // Test that delimiter is case-sensitive
            string s = "A|B|C";
            string tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("C");
            (s).Should().Be("A|B");
        }

        [Fact]
        public void TestParseStringFromRight18TabDelimiter()
        {
            // Test with tab as delimiter
            string s = "col1\tcol2\tcol3";
            string tok = StringUtil.ParseStringFromRight(ref s, "\t");
            (tok).Should().Be("col3");
            (s).Should().Be("col1\tcol2");
        }

        [Fact]
        public void TestParseStringFromRight19NewlineDelimiter()
        {
            // Test with newline as delimiter
            string s = "line1\nline2\nline3";
            string tok = StringUtil.ParseStringFromRight(ref s, "\n");
            (tok).Should().Be("line3");
            (s).Should().Be("line1\nline2");
        }

        [Fact]
        public void TestParseStringFromRight20NullSource()
        {
            // Test null source throws exception
            string s = null!;
            Action act = () => StringUtil.ParseStringFromRight(ref s, "x");
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestParseStringFromRight21NullDelimiter()
        {
            // Test null delimiter throws exception
            string s = "test";
            Action act = () => StringUtil.ParseStringFromRight(ref s, null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestParseStringFromRight22WhitespaceTokens()
        {
            // Test parsing tokens that are whitespace
            string s = "  | \t | ";
            string tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be(" ");
            (s).Should().Be("  | \t ");
        }

        [Fact]
        public void TestParseStringFromRight23VeryLongToken()
        {
            // Test with very long tokens
            string s = new string('a', 1000) + "|" + new string('b', 1000);
            string tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be(new string('b', 1000));
            (s).Should().Be(new string('a', 1000));
        }

        [Fact]
        public void TestParseStringFromRight24DelimiterLongerThanContent()
        {
            // Test with delimiter longer than content
            string s = "ab";
            string tok = StringUtil.ParseStringFromRight(ref s, "delimiter");
            (tok).Should().Be("ab");
            (s).Should().Be("");
        }

        [Fact]
        public void TestParseStringFromRight25DelimiterEqualsContent()
        {
            // Test where delimiter equals entire content
            string s = "|";
            string tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("");
            (s).Should().Be("");
        }

        [Fact]
        public void TestParseStringFromRight26MultipleDelimitersInLastToken()
        {
            // Test when the last token contains the delimiter character
            string s = "a|b:c|d:e";
            string tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("d:e");
            (s).Should().Be("a|b:c");
        }

        [Fact]
        public void TestParseStringFromRight27DelimiterAtBothEnds()
        {
            // Test with delimiter at both start and end
            string s = "|content|";
            string tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("");
            (s).Should().Be("|content");

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("content");
            (s).Should().Be("");
        }

        [Fact]
        public void TestParseStringFromRight28SymmetricalWithParseString()
        {
            // Test that ParseStringFromRight is symmetrical with ParseString
            // when parsing all tokens from a string
            string original = "first|second|third|fourth";
            string s = original;
            List<string> fromRight = new List<string>();

            // Extract all tokens from right
            while (s.Length > 0)
            {
                fromRight.Add(StringUtil.ParseStringFromRight(ref s, "|"));
            }

            // Verify we got the expected tokens in reverse order
            (fromRight.Count).Should().Be(4);
            (fromRight[0]).Should().Be("fourth");
            (fromRight[1]).Should().Be("third");
            (fromRight[2]).Should().Be("second");
            (fromRight[3]).Should().Be("first");
        }

        [Fact]
        public void TestParseStringFromRight29DelimiterNotInString()
        {
            // Test when delimiter is not found anywhere in string
            string s = "no delimiter here";
            string tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("no delimiter here");
            (s).Should().Be("");
        }

        [Fact]
        public void TestParseStringFromRight30SingleCharString()
        {
            // Test with single character string
            string s = "a";
            string tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("a");
            (s).Should().Be("");
        }

        [Fact]
        public void TestParseStringFromRight31AlternatingDelimiterAndContent()
        {
            // Test with alternating delimiter and content
            string s = "a|b|c|d|e";
            string tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("e");
            (s).Should().Be("a|b|c|d");

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("d");
            (s).Should().Be("a|b|c");

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            (tok).Should().Be("c");
            (s).Should().Be("a|b");
        }

        #endregion


        #region Substitute(string, string, string) tests

        [Fact]
        public void TestSubstitute1()
        {
            (StringUtil.Substitute("asdf", "", "XY")).Should().Be("asdf");
        }

        [Fact]
        public void TestCSubstitute2()
        {
            (StringUtil.Substitute("asdf", "sd", "XY")).Should().Be("aXYf");
        }

        [Fact]
        public void TestCSubstitute3()
        {
            (StringUtil.Substitute("asdfsdsd", "sd", "XY")).Should().Be("aXYfXYXY");
        }

        [Fact]
        public void TestCSubstitute4()
        {
            (StringUtil.Substitute("a", "a", "X")).Should().Be("X");
        }

        [Fact]
        public void TestCSubstitute5()
        {
            (StringUtil.Substitute("aa", "a", "X")).Should().Be("XX");
        }

        [Fact]
        public void TestCSubstitute6()
        {
            (StringUtil.Substitute("aa", "aa", "XX")).Should().Be("XX");
        }

        [Fact]
        public void TestCSubstitute7()
        {
            (StringUtil.Substitute("asdf", "SD", "XY")).Should().Be("asdf");
        }

        [Fact]
        public void TestCSubstitute8()
        {
            (StringUtil.Substitute("asdfsdsd", "SD", "XY")).Should().Be("asdfsdsd");
        }

        [Fact]
        public void TestCSubstitute9()
        {
            (StringUtil.Substitute("a", "A", "X")).Should().Be("a");
        }

        [Fact]
        public void TestCSubstitute10()
        {
            (StringUtil.Substitute("aa", "A", "X")).Should().Be("aa");
        }

        [Fact]
        public void TestCSubstitute11()
        {
            (StringUtil.Substitute("aa", "AA", "XX")).Should().Be("aa");
        }

        [Fact]
        public void TestSubstitute49SingleCharacterString()
        {
            // Test single character string
            (StringUtil.Substitute("a", "a", "X")).Should().Be("X");
        }

        [Fact]
        public void TestSubstitute50EmptySourceString()
        {
            // Test empty source string
            (StringUtil.Substitute("", "a", "X")).Should().Be("");
        }

        [Fact]
        public void TestSubstitute51RepeatedReplacements()
        {
            // Test multiple replacements in sequence
            string result = StringUtil.Substitute("aaaa", "a", "X");
            (result).Should().Be("XXXX");
        }

        [Fact]
        public void TestSubstitute52TargetWithSpecialCharacters()
        {
            // Test target containing special characters
            (StringUtil.Substitute("a@#f", "@#", "X")).Should().Be("aXf");
        }

        [Fact]
        public void TestSubstitute53WhitespaceTarget()
        {
            // Test whitespace as target
            (StringUtil.Substitute("a b c", " ", "X")).Should().Be("aXbXc");
        }

        [Fact]
        public void TestSubstitute54TabCharacterInSource()
        {
            // Test tab character in source
            (StringUtil.Substitute("a\tb", "\t", "X")).Should().Be("aXb");
        }

        [Fact]
        public void TestSubstitute55NewlineCharacterInSource()
        {
            // Test newline character in source
            (StringUtil.Substitute("a\nb", "\n", "X")).Should().Be("aXb");
        }

        [Fact]
        public void TestSubstitute56LongestMatchFirst()
        {
            // Test that it uses IndexOf behavior (first occurrence)
            (StringUtil.Substitute("ABabc", "A", "X")).Should().Be("XBabc");
        }

        [Fact]
        public void TestSubstitute57NumericInSource()
        {
            // Test numeric content in source
            (StringUtil.Substitute("a456f", "456", "123")).Should().Be("a123f");
        }

        [Fact]
        public void TestSubstitute58TargetLongerThanSource()
        {
            // Test target longer than source (no match)
            (StringUtil.Substitute("abc", "abcdef", "X")).Should().Be("abc");
        }

        [Fact]
        public void TestSubstitute59ReplacementShorterThanTarget()
        {
            // Test replacement shorter than target (deletion effect)
            (StringUtil.Substitute("asdf", "sd", "X")).Should().Be("aXf");
        }

        [Fact]
        public void TestSubstitute23SingleCharacterReplacement()
        {
            // Test replacing with single character
            (StringUtil.Substitute("asdf", "sd", "X")).Should().Be("aXf");
        }

        [Fact]
        public void TestSubstitute24EmptyReplacement()
        {
            // Test replacing with empty string (deletion)
            (StringUtil.Substitute("asdf", "sd", "")).Should().Be("af");
        }

        [Fact]
        public void TestSubstitute25LongerReplacement()
        {
            // Test replacing with longer string
            (StringUtil.Substitute("asdf", "sd", "LONGER")).Should().Be("aLONGERf");
        }

        [Fact]
        public void TestSubstitute26TargetNotFound()
        {
            // Test when target is not in source
            (StringUtil.Substitute("asdf", "xyz", "XY")).Should().Be("asdf");
        }

        [Fact]
        public void TestSubstitute27EntireStringAsTarget()
        {
            // Test replacing the entire string
            (StringUtil.Substitute("entire", "entire", "REPLACEMENT")).Should().Be("REPLACEMENT");
        }

        [Fact]
        public void TestSubstitute28TargetAtStart()
        {
            // Test target at start of string
            (StringUtil.Substitute("asdf", "a", "REPLACED")).Should().Be("REPLACEDsdf");
        }

        [Fact]
        public void TestSubstitute29TargetAtEnd()
        {
            // Test target at end of string
            (StringUtil.Substitute("asdf", "f", "REPLACED")).Should().Be("asdREPLACED");
        }

        [Fact]
        public void TestSubstitute30MultipleNonConsecutiveTargets()
        {
            // Test multiple non-consecutive targets
            (StringUtil.Substitute("XaYaY", "Y", "X")).Should().Be("XaXaX");
        }

        [Fact]
        public void TestSubstitute31OverlappingPattern()
        {
            // Test with pattern that could overlap
            // Algorithm replaces first match then continues from after replacement
            // "AAAA" with target "AA" -> finds at pos 0, replaces, leaves "AA" -> finds at pos 0, replaces
            (StringUtil.Substitute("AAAA", "AA", "X")).Should().Be("XX");
        }

        [Fact]
        public void TestSubstitute32NumericStringReplacement()
        {
            // Test replacing numeric strings
            (StringUtil.Substitute("asdf", "sd", "123")).Should().Be("a123f");
        }

        [Fact]
        public void TestSubstitute33SpecialCharactersInReplacement()
        {
            // Test special characters in replacement
            (StringUtil.Substitute("asdf", "sd", "@#$")).Should().Be("a@#$f");
        }

        [Fact]
        public void TestSubstitute34SpaceInReplacement()
        {
            // Test space in replacement
            (StringUtil.Substitute("asdf", "sd", "  ")).Should().Be("a  f");
        }

        [Fact]
        public void TestSubstitute35VeryLongTarget()
        {
            // Test with very long target string
            string target = new string('a', 100);
            string source = target + "xyz";
            string result = StringUtil.Substitute(source, target, "REPLACED");
            (result).Should().Be("REPLACEDxyz");
        }

        [Fact]
        public void TestSubstitute36VeryLongReplacement()
        {
            // Test with very long replacement string
            string replacement = new string('x', 1000);
            string result = StringUtil.Substitute("abc", "b", replacement);
            (result).Should().Be("a" + replacement + "c");
        }

        [Fact]
        public void TestSubstitute37SelfReplacingTarget()
        {
            // Test replacing target with itself (should return same)
            (StringUtil.Substitute("asdf", "sd", "sd")).Should().Be("asdf");
        }

        [Fact]
        public void TestSubstitute38ConsecutiveIdenticalTargets()
        {
            // Test multiple consecutive identical targets
            (StringUtil.Substitute("ababab", "ab", "XY")).Should().Be("XYXYXY");
        }

        [Fact]
        public void TestSubstitute39SingleCharacterTarget()
        {
            // Test single character target with case-sensitive matching
            // Only lowercase 'x' should be replaced, not uppercase 'X'
            (StringUtil.Substitute("axbxd", "x", "X")).Should().Be("aXbXd");
        }

        [Fact]
        public void TestSubstitute40AllCharactersSame()
        {
            // Test string where all characters are the same
            (StringUtil.Substitute("aaaa", "a", "X")).Should().Be("XXXX");
        }

        [Fact]
        public void TestSubstitute41ReplacementContainsTarget()
        {
            // Test when replacement contains the target
            (StringUtil.Substitute("abc", "abc", "abcabc")).Should().Be("abcabc");
        }

        [Fact]
        public void TestSubstitute42AlternatingPattern()
        {
            // Test alternating pattern
            (StringUtil.Substitute("abab", "a", "X")).Should().Be("XbXb");
        }

        [Fact]
        public void TestSubstitute43NullSource()
        {
            // Test null source throws exception
            Action act = () => StringUtil.Substitute(null, "a", "X");
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestSubstitute44NullTarget()
        {
            // Test null target throws exception
            Action act = () => StringUtil.Substitute("asdf", null, "X");
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestSubstitute45NullReplacement()
        {
            // Test null replacement throws exception
            Action act = () => StringUtil.Substitute("asdf", "a", null);
            act.Should().Throw<ArgumentNullException>();
        }

        #endregion


        #region Substitute(string, string, string, ComparisonType) tests

        [Fact]
        public void TestSubstituteExtended1()
        {
            (StringUtil.Substitute("asdf", "", "XY", ComparisonType.CaseSensitive)).Should().Be("asdf");
        }

        [Fact]
        public void TestSubstituteExtended2()
        {
            (StringUtil.Substitute("asdf", "sd", "XY", ComparisonType.CaseSensitive)).Should().Be("aXYf");
        }

        [Fact]
        public void TestSubstituteExtended3()
        {
            (StringUtil.Substitute("asdfsdsd", "sd", "XY", ComparisonType.CaseSensitive)).Should().Be("aXYfXYXY");
        }

        [Fact]
        public void TestSubstituteExtended4()
        {
            (StringUtil.Substitute("a", "a", "X", ComparisonType.CaseSensitive)).Should().Be("X");
        }

        [Fact]
        public void TestSubstituteExtended5()
        {
            (StringUtil.Substitute("aa", "a", "X", ComparisonType.CaseSensitive)).Should().Be("XX");
        }

        [Fact]
        public void TestSubstituteExtended6()
        {
            (StringUtil.Substitute("aa", "aa", "XX", ComparisonType.CaseSensitive)).Should().Be("XX");
        }

        [Fact]
        public void TestSubstituteExtended7()
        {
            (StringUtil.Substitute("asdf", "SD", "XY", ComparisonType.CaseSensitive)).Should().Be("asdf");
        }

        [Fact]
        public void TestSubstituteExtended8()
        {
            (StringUtil.Substitute("asdfsdsd", "SD", "XY", ComparisonType.CaseSensitive)).Should().Be("asdfsdsd");
        }

        [Fact]
        public void TestSubstituteExtended9()
        {
            (StringUtil.Substitute("a", "A", "X", ComparisonType.CaseSensitive)).Should().Be("a");
        }

        [Fact]
        public void TestSubstituteExtended10()
        {
            (StringUtil.Substitute("aa", "A", "X", ComparisonType.CaseSensitive)).Should().Be("aa");
        }

        [Fact]
        public void TestSubstituteExtended11()
        {
            (StringUtil.Substitute("aa", "AA", "XX", ComparisonType.CaseSensitive)).Should().Be("aa");
        }

        [Fact]
        public void TestSubstituteExtended12()
        {
            (StringUtil.Substitute("asdf", "", "XY", ComparisonType.CaseInsensitive)).Should().Be("asdf");
        }

        [Fact]
        public void TestSubstituteExtended13()
        {
            (StringUtil.Substitute("asdf", "sd", "XY", ComparisonType.CaseInsensitive)).Should().Be("aXYf");
        }

        [Fact]
        public void TestSubstituteExtended14()
        {
            (StringUtil.Substitute("asdfsdsd", "sd", "XY", ComparisonType.CaseInsensitive)).Should().Be("aXYfXYXY");
        }

        [Fact]
        public void TestSubstituteExtended15()
        {
            (StringUtil.Substitute("a", "a", "X", ComparisonType.CaseInsensitive)).Should().Be("X");
        }

        [Fact]
        public void TestSubstituteExtended16()
        {
            (StringUtil.Substitute("aa", "a", "X", ComparisonType.CaseInsensitive)).Should().Be("XX");
        }

        [Fact]
        public void TestSubstituteExtended17()
        {
            (StringUtil.Substitute("aa", "aa", "XX", ComparisonType.CaseInsensitive)).Should().Be("XX");
        }

        [Fact]
        public void TestSubstituteExtended18()
        {
            (StringUtil.Substitute("asdf", "SD", "XY", ComparisonType.CaseInsensitive)).Should().Be("aXYf");
        }

        [Fact]
        public void TestSubstituteExtended19()
        {
            (StringUtil.Substitute("asdfsdsd", "SD", "XY", ComparisonType.CaseInsensitive)).Should().Be("aXYfXYXY");
        }

        [Fact]
        public void TestSubstituteExtended20()
        {
            (StringUtil.Substitute("a", "A", "X", ComparisonType.CaseInsensitive)).Should().Be("X");
        }

        [Fact]
        public void TestSubstituteExtended21()
        {
            (StringUtil.Substitute("aa", "A", "X", ComparisonType.CaseInsensitive)).Should().Be("XX");
        }

        [Fact]
        public void TestSubstituteExtended22()
        {
            (StringUtil.Substitute("aa", "AA", "XX", ComparisonType.CaseInsensitive)).Should().Be("XX");
        }

        [Fact]
        public void TestSubstitute46CaseInsensitiveSimple()
        {
            // Test case-insensitive replacement
            (StringUtil.Substitute("AbAd", "a", "X", ComparisonType.CaseInsensitive)).Should().Be("XbXd");
        }

        [Fact]
        public void TestSubstitute47CaseInsensitiveNoMatch()
        {
            // Test case-insensitive with no match (case matters in target itself)
            (StringUtil.Substitute("ABad", "a", "X", ComparisonType.CaseInsensitive)).Should().Be("XBXd");
        }

        [Fact]
        public void TestSubstitute48MixedCaseTarget()
        {
            // Test mixed case target with case-insensitive
            // "asdf" with target "SD" case-insensitive
            // Iteration 1: Find "sd" at index 1, Left("asdf", 1) = "a", append "a" + "X", remove 0-3, orig = "f"
            // Iteration 2: Not found, append "f"
            // Result: "aXf"
            (StringUtil.Substitute("asdf", "SD", "X", ComparisonType.CaseInsensitive)).Should().Be("aXf");
        }

        [Fact]
        public void TestSubstituteExtended23EmptyTargetCaseSensitive()
        {
            // Test empty target with case-sensitive (should return source unchanged)
            (StringUtil.Substitute("hello", "", "world", ComparisonType.CaseSensitive)).Should().Be("hello");
        }

        [Fact]
        public void TestSubstituteExtended24EmptyTargetCaseInsensitive()
        {
            // Test empty target with case-insensitive (should return source unchanged)
            (StringUtil.Substitute("hello", "", "world", ComparisonType.CaseInsensitive)).Should().Be("hello");
        }

        [Fact]
        public void TestSubstituteExtended25AllUppercaseCaseSensitive()
        {
            // Test all uppercase - should not match lowercase with case-sensitive
            (StringUtil.Substitute("HELLO", "hello", "X", ComparisonType.CaseSensitive)).Should().Be("HELLO");
        }

        [Fact]
        public void TestSubstituteExtended26AllUppercaseCaseInsensitive()
        {
            // Test all uppercase - should match with case-insensitive
            (StringUtil.Substitute("HELLO", "hello", "X", ComparisonType.CaseInsensitive)).Should().Be("X");
        }

        [Fact]
        public void TestSubstituteExtended27MixedCaseCaseSensitive()
        {
            // Test mixed case with case-sensitive - partial case match should not substitute
            (StringUtil.Substitute("HeLLo", "hello", "X", ComparisonType.CaseSensitive)).Should().Be("HeLLo");
        }

        [Fact]
        public void TestSubstituteExtended28MixedCaseCaseInsensitive()
        {
            // Test mixed case with case-insensitive - should match and replace
            (StringUtil.Substitute("HeLLo", "hello", "X", ComparisonType.CaseInsensitive)).Should().Be("X");
        }

        [Fact]
        public void TestSubstituteExtended29PartialCaseMatchCaseSensitive()
        {
            // Test partial case match with case-sensitive
            (StringUtil.Substitute("aBCD", "ABCD", "X", ComparisonType.CaseSensitive)).Should().Be("aBCD");
        }

        [Fact]
        public void TestSubstituteExtended30PartialCaseMatchCaseInsensitive()
        {
            // Test partial case match with case-insensitive - should match
            (StringUtil.Substitute("aBCD", "ABCD", "X", ComparisonType.CaseInsensitive)).Should().Be("X");
        }

        [Fact]
        public void TestSubstituteExtended31NumericTargetCaseSensitive()
        {
            // Test numeric target with case-sensitive
            (StringUtil.Substitute("123456123", "123", "X", ComparisonType.CaseSensitive)).Should().Be("X456X");
        }

        [Fact]
        public void TestSubstituteExtended32NumericTargetCaseInsensitive()
        {
            // Test numeric target with case-insensitive (should work same as case-sensitive for numbers)
            (StringUtil.Substitute("123456123", "123", "X", ComparisonType.CaseInsensitive)).Should().Be("X456X");
        }

        [Fact]
        public void TestSubstituteExtended33SpecialCharactersCaseSensitive()
        {
            // Test special characters with case-sensitive
            (StringUtil.Substitute("a@#$b", "@#$b", "X", ComparisonType.CaseSensitive)).Should().Be("aX");
        }

        [Fact]
        public void TestSubstituteExtended34SpecialCharactersCaseInsensitive()
        {
            // Test special characters with case-insensitive
            (StringUtil.Substitute("a@#$b", "@#$b", "X", ComparisonType.CaseInsensitive)).Should().Be("aX");
        }

        [Fact]
        public void TestSubstituteExtended35WhitespaceCaseSensitive()
        {
            // Test whitespace with case-sensitive
            (StringUtil.Substitute("a b", " ", "X", ComparisonType.CaseSensitive)).Should().Be("aXb");
        }

        [Fact]
        public void TestSubstituteExtended36WhitespaceCaseInsensitive()
        {
            // Test whitespace with case-insensitive (should work same as case-sensitive)
            (StringUtil.Substitute("a b", " ", "X", ComparisonType.CaseInsensitive)).Should().Be("aXb");
        }

        [Fact]
        public void TestSubstituteExtended37TabCaseSensitive()
        {
            // Test tab character with case-sensitive
            (StringUtil.Substitute("a\tb", "\t", "X", ComparisonType.CaseSensitive)).Should().Be("aXb");
        }

        [Fact]
        public void TestSubstituteExtended38TabCaseInsensitive()
        {
            // Test tab character with case-insensitive
            (StringUtil.Substitute("a\tb", "\t", "X", ComparisonType.CaseInsensitive)).Should().Be("aXb");
        }

        [Fact]
        public void TestSubstituteExtended39NewlineCaseSensitive()
        {
            // Test newline character with case-sensitive
            (StringUtil.Substitute("a\nb", "\n", "X", ComparisonType.CaseSensitive)).Should().Be("aXb");
        }

        [Fact]
        public void TestSubstituteExtended40NewlineCaseInsensitive()
        {
            // Test newline character with case-insensitive
            (StringUtil.Substitute("a\nb", "\n", "X", ComparisonType.CaseInsensitive)).Should().Be("aXb");
        }

        [Fact]
        public void TestSubstituteExtended41VeryLongStringCaseSensitive()
        {
            // Test very long string with case-sensitive
            string longStr = new string('a', 1000);
            (StringUtil.Substitute(longStr, longStr, "X", ComparisonType.CaseSensitive)).Should().Be("X");
        }

        [Fact]
        public void TestSubstituteExtended42VeryLongStringCaseInsensitive()
        {
            // Test very long string with case-insensitive
            string longStr = new string('a', 1000);
            (StringUtil.Substitute(longStr, longStr, "X", ComparisonType.CaseInsensitive)).Should().Be("X");
        }

        [Fact]
        public void TestSubstituteExtended43ReplacementLongerThanTargetCaseSensitive()
        {
            // Test replacement longer than target with case-sensitive
            (StringUtil.Substitute("asdf", "sd", "LONGER", ComparisonType.CaseSensitive)).Should().Be("aLONGERf");
        }

        [Fact]
        public void TestSubstituteExtended44ReplacementLongerThanTargetCaseInsensitive()
        {
            // Test replacement longer than target with case-insensitive
            (StringUtil.Substitute("asdf", "SD", "LONGER", ComparisonType.CaseInsensitive)).Should().Be("aLONGERf");
        }

        [Fact]
        public void TestSubstituteExtended45EmptyReplacementCaseSensitive()
        {
            // Test empty replacement (deletion) with case-sensitive
            (StringUtil.Substitute("asdf", "sd", "", ComparisonType.CaseSensitive)).Should().Be("af");
        }

        [Fact]
        public void TestSubstituteExtended46EmptyReplacementCaseInsensitive()
        {
            // Test empty replacement (deletion) with case-insensitive
            (StringUtil.Substitute("asdf", "SD", "", ComparisonType.CaseInsensitive)).Should().Be("af");
        }

        [Fact]
        public void TestSubstituteExtended47SelfReplacingCaseSensitive()
        {
            // Test replacing target with itself (case-sensitive)
            (StringUtil.Substitute("asdf", "sd", "sd", ComparisonType.CaseSensitive)).Should().Be("asdf");
        }

        [Fact]
        public void TestSubstituteExtended48SelfReplacingCaseInsensitive()
        {
            // Test replacing target with itself (case-insensitive)
            // Note: original case is preserved since we're replacing with the exact same string
            (StringUtil.Substitute("asdf", "SD", "sd", ComparisonType.CaseInsensitive)).Should().Be("asdf");
        }

        [Fact]
        public void TestSubstituteExtended49ConsecutiveTargetsCaseSensitive()
        {
            // Test consecutive targets with case-sensitive
            (StringUtil.Substitute("ababab", "ab", "XY", ComparisonType.CaseSensitive)).Should().Be("XYXYXY");
        }

        [Fact]
        public void TestSubstituteExtended50ConsecutiveTargetsCaseInsensitive()
        {
            // Test consecutive targets with case-insensitive
            (StringUtil.Substitute("ababab", "AB", "XY", ComparisonType.CaseInsensitive)).Should().Be("XYXYXY");
        }

        [Fact]
        public void TestSubstituteExtended51AlternatingCaseSensitive()
        {
            // Test alternating pattern with case-sensitive
            (StringUtil.Substitute("abab", "a", "X", ComparisonType.CaseSensitive)).Should().Be("XbXb");
        }

        [Fact]
        public void TestSubstituteExtended52AlternatingCaseInsensitive()
        {
            // Test alternating pattern with case-insensitive
            (StringUtil.Substitute("abab", "A", "X", ComparisonType.CaseInsensitive)).Should().Be("XbXb");
        }

        [Fact]
        public void TestSubstituteExtended53NoMatchCaseSensitive()
        {
            // Test when target doesn't match (case-sensitive)
            (StringUtil.Substitute("asdf", "ASDF", "X", ComparisonType.CaseSensitive)).Should().Be("asdf");
        }

        [Fact]
        public void TestSubstituteExtended54NoMatchCaseInsensitive()
        {
            // Test when target doesn't match (case-insensitive) - but it should match here
            (StringUtil.Substitute("asdf", "ASDF", "X", ComparisonType.CaseInsensitive)).Should().Be("X");
        }

        [Fact]
        public void TestSubstituteExtended55TargetLongerThanSourceCaseSensitive()
        {
            // Test target longer than source with case-sensitive
            (StringUtil.Substitute("abc", "abcdef", "X", ComparisonType.CaseSensitive)).Should().Be("abc");
        }

        [Fact]
        public void TestSubstituteExtended56TargetLongerThanSourceCaseInsensitive()
        {
            // Test target longer than source with case-insensitive
            (StringUtil.Substitute("abc", "ABCDEF", "X", ComparisonType.CaseInsensitive)).Should().Be("abc");
        }

        [Fact]
        public void TestSubstituteExtended57SingleCharacterSourceCaseSensitive()
        {
            // Test single character source with case-sensitive
            (StringUtil.Substitute("a", "a", "X", ComparisonType.CaseSensitive)).Should().Be("X");
        }

        [Fact]
        public void TestSubstituteExtended58SingleCharacterSourceCaseInsensitive()
        {
            // Test single character source with case-insensitive
            (StringUtil.Substitute("A", "a", "X", ComparisonType.CaseInsensitive)).Should().Be("X");
        }

        [Fact]
        public void TestSubstituteExtended59EmptySourceCaseSensitive()
        {
            // Test empty source with case-sensitive
            (StringUtil.Substitute("", "a", "X", ComparisonType.CaseSensitive)).Should().Be("");
        }

        [Fact]
        public void TestSubstituteExtended60EmptySourceCaseInsensitive()
        {
            // Test empty source with case-insensitive
            (StringUtil.Substitute("", "a", "X", ComparisonType.CaseInsensitive)).Should().Be("");
        }

        [Fact]
        public void TestSubstituteExtended61TargetAtStartCaseSensitive()
        {
            // Test target at start with case-sensitive
            (StringUtil.Substitute("asdf", "a", "REPLACED", ComparisonType.CaseSensitive)).Should().Be("REPLACEDsdf");
        }

        [Fact]
        public void TestSubstituteExtended62TargetAtStartCaseInsensitive()
        {
            // Test target at start with case-insensitive
            (StringUtil.Substitute("Asdf", "a", "REPLACED", ComparisonType.CaseInsensitive)).Should().Be("REPLACEDsdf");
        }

        [Fact]
        public void TestSubstituteExtended63TargetAtEndCaseSensitive()
        {
            // Test target at end with case-sensitive
            (StringUtil.Substitute("asdf", "f", "REPLACED", ComparisonType.CaseSensitive)).Should().Be("asdREPLACED");
        }

        [Fact]
        public void TestSubstituteExtended64TargetAtEndCaseInsensitive()
        {
            // Test target at end with case-insensitive
            (StringUtil.Substitute("asdF", "f", "REPLACED", ComparisonType.CaseInsensitive)).Should().Be("asdREPLACED");
        }

        [Fact]
        public void TestSubstituteExtended65MultiCharacterTargetCaseSensitive()
        {
            // Test multi-character target with case-sensitive
            (StringUtil.Substitute("asdf", "sd", "X", ComparisonType.CaseSensitive)).Should().Be("aXf");
        }

        [Fact]
        public void TestSubstituteExtended66MultiCharacterTargetCaseInsensitive()
        {
            // Test multi-character target with case-insensitive
            (StringUtil.Substitute("aSDf", "sd", "X", ComparisonType.CaseInsensitive)).Should().Be("aXf");
        }

        [Fact]
        public void TestSubstituteExtended67OverlappingPatternCaseSensitive()
        {
            // Test overlapping pattern with case-sensitive
            (StringUtil.Substitute("AAAA", "AA", "X", ComparisonType.CaseSensitive)).Should().Be("XX");
        }

        [Fact]
        public void TestSubstituteExtended68OverlappingPatternCaseInsensitive()
        {
            // Test overlapping pattern with case-insensitive
            (StringUtil.Substitute("aaaa", "AA", "X", ComparisonType.CaseInsensitive)).Should().Be("XX");
        }

        [Fact]
        public void TestSubstituteExtended69NullSourceCaseSensitive()
        {
            // Test null source throws exception with case-sensitive
            Action act = () => StringUtil.Substitute(null, "a", "X", ComparisonType.CaseSensitive);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestSubstituteExtended70NullSourceCaseInsensitive()
        {
            // Test null source throws exception with case-insensitive
            Action act = () => StringUtil.Substitute(null, "a", "X", ComparisonType.CaseInsensitive);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestSubstituteExtended71NullTargetCaseSensitive()
        {
            // Test null target throws exception with case-sensitive
            Action act = () => StringUtil.Substitute("test", null, "X", ComparisonType.CaseSensitive);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestSubstituteExtended72NullTargetCaseInsensitive()
        {
            // Test null target throws exception with case-insensitive
            Action act = () => StringUtil.Substitute("test", null, "X", ComparisonType.CaseInsensitive);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestSubstituteExtended73NullReplacementCaseSensitive()
        {
            // Test null replacement throws exception with case-sensitive
            Action act = () => StringUtil.Substitute("test", "e", null, ComparisonType.CaseSensitive);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestSubstituteExtended74NullReplacementCaseInsensitive()
        {
            // Test null replacement throws exception with case-insensitive
            Action act = () => StringUtil.Substitute("test", "e", null, ComparisonType.CaseInsensitive);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestSubstituteExtended75ReplacementContainsTargetCaseSensitive()
        {
            // Test replacement containing target with case-sensitive
            (StringUtil.Substitute("abc", "abc", "abcabc", ComparisonType.CaseSensitive)).Should().Be("abcabc");
        }

        [Fact]
        public void TestSubstituteExtended76ReplacementContainsTargetCaseInsensitive()
        {
            // Test replacement containing target with case-insensitive
            (StringUtil.Substitute("ABC", "abc", "abcabc", ComparisonType.CaseInsensitive)).Should().Be("abcabc");
        }

        [Fact]
        public void TestSubstituteExtended77EntireStringMatchCaseSensitive()
        {
            // Test entire string matches target with case-sensitive
            (StringUtil.Substitute("entire", "entire", "REPLACEMENT", ComparisonType.CaseSensitive)).Should().Be("REPLACEMENT");
        }

        [Fact]
        public void TestSubstituteExtended78EntireStringMatchCaseInsensitive()
        {
            // Test entire string matches target with case-insensitive
            (StringUtil.Substitute("ENTIRE", "entire", "REPLACEMENT", ComparisonType.CaseInsensitive)).Should().Be("REPLACEMENT");
        }

        [Fact]
        public void TestSubstituteExtended79MultipleNonConsecutiveTargetsCaseSensitive()
        {
            // Test multiple non-consecutive targets with case-sensitive
            (StringUtil.Substitute("XaYaY", "Y", "X", ComparisonType.CaseSensitive)).Should().Be("XaXaX");
        }

        [Fact]
        public void TestSubstituteExtended80MultipleNonConsecutiveTargetsCaseInsensitive()
        {
            // Test multiple non-consecutive targets with case-insensitive
            (StringUtil.Substitute("XaYaY", "y", "X", ComparisonType.CaseInsensitive)).Should().Be("XaXaX");
        }

        #endregion


        #region ConvertComparisonType(ComparisonType) tests

        [Fact]
        public void TestConvertComparisonType1CaseSensitive()
        {
            // Test converting CaseSensitive to StringComparison.Ordinal
            StringComparison result = StringUtil.ConvertComparisonType(ComparisonType.CaseSensitive);
            (result).Should().Be(StringComparison.Ordinal);
        }

        [Fact]
        public void TestConvertComparisonType2CaseInsensitive()
        {
            // Test converting CaseInsensitive to StringComparison.OrdinalIgnoreCase
            StringComparison result = StringUtil.ConvertComparisonType(ComparisonType.CaseInsensitive);
            (result).Should().Be(StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void TestConvertComparisonType3InvalidValue()
        {
            // Test converting invalid ComparisonType value throws ArgumentOutOfRangeException
            // Database = 2 is not supported
            Action act = () => StringUtil.ConvertComparisonType(ComparisonType.Database);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestConvertComparisonType4CaseSensitiveConsistency()
        {
            // Test that CaseSensitive always converts to Ordinal
            for (int i = 0; i < 5; i++)
            {
                (StringUtil.ConvertComparisonType(ComparisonType.CaseSensitive)).Should().Be(StringComparison.Ordinal);
            }
        }

        [Fact]
        public void TestConvertComparisonType5CaseInsensitiveConsistency()
        {
            // Test that CaseInsensitive always converts to OrdinalIgnoreCase
            for (int i = 0; i < 5; i++)
            {
                (StringUtil.ConvertComparisonType(ComparisonType.CaseInsensitive)).Should().Be(StringComparison.OrdinalIgnoreCase);
            }
        }

        [Fact]
        public void TestConvertComparisonType6CaseSensitiveUsedInIndexOf()
        {
            // Test that CaseSensitive conversion works correctly with string operations
            string source = "Hello World";
            StringComparison comparison = StringUtil.ConvertComparisonType(ComparisonType.CaseSensitive);
            int result = source.IndexOf("hello", 0, comparison);
            (result).Should().Be(-1); // "hello" is not found (case-sensitive)
        }

        [Fact]
        public void TestConvertComparisonType7CaseInsensitiveUsedInIndexOf()
        {
            // Test that CaseInsensitive conversion works correctly with string operations
            string source = "Hello World";
            StringComparison comparison = StringUtil.ConvertComparisonType(ComparisonType.CaseInsensitive);
            int result = source.IndexOf("hello", 0, comparison);
            (result).Should().Be(0); // "hello" is found at index 0 (case-insensitive)
        }

        [Fact]
        public void TestConvertComparisonType8CaseSensitiveEqualsCheck()
        {
            // Test that CaseSensitive conversion works with Equals
            string str1 = "Test";
            string str2 = "test";
            StringComparison comparison = StringUtil.ConvertComparisonType(ComparisonType.CaseSensitive);
            bool result = str1.Equals(str2, comparison);
            (result).Should().BeFalse(); // Not equal (case-sensitive)
        }

        [Fact]
        public void TestConvertComparisonType9CaseInsensitiveEqualsCheck()
        {
            // Test that CaseInsensitive conversion works with Equals
            string str1 = "Test";
            string str2 = "test";
            StringComparison comparison = StringUtil.ConvertComparisonType(ComparisonType.CaseInsensitive);
            bool result = str1.Equals(str2, comparison);
            (result).Should().BeTrue(); // Equal (case-insensitive)
        }

        [Fact]
        public void TestConvertComparisonType10CaseSensitiveCompare()
        {
            // Test that CaseSensitive conversion produces Ordinal for string comparison
            StringComparison result = StringUtil.ConvertComparisonType(ComparisonType.CaseSensitive);
            (result == StringComparison.Ordinal).Should().BeTrue();
        }

        [Fact]
        public void TestConvertComparisonType11CaseInsensitiveCompare()
        {
            // Test that CaseInsensitive conversion produces OrdinalIgnoreCase
            StringComparison result = StringUtil.ConvertComparisonType(ComparisonType.CaseInsensitive);
            (result == StringComparison.OrdinalIgnoreCase).Should().BeTrue();
        }

        [Fact]
        public void TestConvertComparisonType12CaseSensitiveNotOrdinalIgnoreCase()
        {
            // Test that CaseSensitive does NOT return OrdinalIgnoreCase
            StringComparison result = StringUtil.ConvertComparisonType(ComparisonType.CaseSensitive);
            (result == StringComparison.OrdinalIgnoreCase).Should().BeFalse();
        }

        [Fact]
        public void TestConvertComparisonType13CaseInsensitiveNotOrdinal()
        {
            // Test that CaseInsensitive does NOT return Ordinal
            StringComparison result = StringUtil.ConvertComparisonType(ComparisonType.CaseInsensitive);
            (result == StringComparison.Ordinal).Should().BeFalse();
        }

        [Fact]
        public void TestConvertComparisonType14CaseSensitiveWithMixedCase()
        {
            // Test CaseSensitive with mixed case strings
            string str1 = "TeSt";
            string str2 = "test";
            StringComparison comparison = StringUtil.ConvertComparisonType(ComparisonType.CaseSensitive);
            int result = string.Compare(str1, str2, comparison);
            (result).Should().NotBe(0); // Different (case-sensitive)
        }

        [Fact]
        public void TestConvertComparisonType15CaseInsensitiveWithMixedCase()
        {
            // Test CaseInsensitive with mixed case strings
            string str1 = "TeSt";
            string str2 = "test";
            StringComparison comparison = StringUtil.ConvertComparisonType(ComparisonType.CaseInsensitive);
            bool result = str1.Equals(str2, comparison);
            (result).Should().BeTrue(); // Equal when compared case-insensitively
        }

        [Fact]
        public void TestConvertComparisonType16CaseSensitiveNumericStrings()
        {
            // Test CaseSensitive with numeric strings
            StringComparison comparison = StringUtil.ConvertComparisonType(ComparisonType.CaseSensitive);
            (comparison).Should().Be(StringComparison.Ordinal);
            ("123".Equals("123", comparison)).Should().BeTrue();
        }

        [Fact]
        public void TestConvertComparisonType17CaseInsensitiveNumericStrings()
        {
            // Test CaseInsensitive with numeric strings
            StringComparison comparison = StringUtil.ConvertComparisonType(ComparisonType.CaseInsensitive);
            (comparison).Should().Be(StringComparison.OrdinalIgnoreCase);
            ("123".Equals("123", comparison)).Should().BeTrue();
        }

        [Fact]
        public void TestConvertComparisonType18CaseSensitiveWithSpecialCharacters()
        {
            // Test CaseSensitive with special characters
            StringComparison comparison = StringUtil.ConvertComparisonType(ComparisonType.CaseSensitive);
            ("@#$%".Equals("@#$%", comparison)).Should().BeTrue();
            ("@#$%".Equals("@#$^", comparison)).Should().BeFalse();
        }

        [Fact]
        public void TestConvertComparisonType19CaseInsensitiveWithSpecialCharacters()
        {
            // Test CaseInsensitive with special characters
            StringComparison comparison = StringUtil.ConvertComparisonType(ComparisonType.CaseInsensitive);
            ("@#$%".Equals("@#$%", comparison)).Should().BeTrue();
            ("@#$%".Equals("@#$^", comparison)).Should().BeFalse();
        }

        [Fact]
        public void TestConvertComparisonType20CaseSensitiveEmptyStrings()
        {
            // Test CaseSensitive with empty strings
            StringComparison comparison = StringUtil.ConvertComparisonType(ComparisonType.CaseSensitive);
            (string.Empty.Equals(string.Empty, comparison)).Should().BeTrue();
        }

        [Fact]
        public void TestConvertComparisonType21CaseInsensitiveEmptyStrings()
        {
            // Test CaseInsensitive with empty strings
            StringComparison comparison = StringUtil.ConvertComparisonType(ComparisonType.CaseInsensitive);
            (string.Empty.Equals(string.Empty, comparison)).Should().BeTrue();
        }

        [Fact]
        public void TestConvertComparisonType22DatabaseThrowsException()
        {
            // Test that Database comparison type throws exception (not supported)
            Action act = () => StringUtil.ConvertComparisonType(ComparisonType.Database);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        #endregion


        #region Replace(string, string, int, int) tests

        [Fact]
        public void TestReplace1ReplaceAtStart()
        {
            // Test replacing at the start of the string (startIndex = 0)
            (StringUtil.Replace("abcdef", "XYZ", 0, 3)).Should().Be("XYZdef");
        }

        [Fact]
        public void TestReplace2ReplaceAtEnd()
        {
            // Test replacing at the end of the string
            (StringUtil.Replace("abcdef", "XYZ", 3, 3)).Should().Be("abcXYZ");
        }

        [Fact]
        public void TestReplace3ReplaceInMiddle()
        {
            // Test replacing in the middle of the string
            (StringUtil.Replace("abcdef", "XYZ", 2, 1)).Should().Be("abXYZdef");
        }

        [Fact]
        public void TestReplace4ReplaceEntireString()
        {
            // Test replacing the entire string
            (StringUtil.Replace("original", "REPLACED", 0, 8)).Should().Be("REPLACED");
        }

        [Fact]
        public void TestReplace5ReplacementLongerThanOriginal()
        {
            // Test replacement that is longer than what it replaces
            (StringUtil.Replace("abcd", "VERYLONGREPLACEMENT", 1, 2)).Should().Be("aVERYLONGREPLACEMENTd");
        }

        [Fact]
        public void TestReplace6ReplacementShorterThanOriginal()
        {
            // Test replacement that is shorter than what it replaces
            (StringUtil.Replace("abcd", "X", 1, 2)).Should().Be("aXd");
        }

        [Fact]
        public void TestReplace7EmptyReplacement()
        {
            // Test replacing with empty string (deletion)
            (StringUtil.Replace("abcd", "", 1, 2)).Should().Be("ad");
        }

        [Fact]
        public void TestReplace8ReplaceWithSameLength()
        {
            // Test replacement at end of string (startIndex + length == source.Length)
            (StringUtil.Replace("abcd", "XYZ", 1, 3)).Should().Be("aXYZ");
        }

        [Fact]
        public void TestReplace9ReplaceFirstCharacter()
        {
            // Test replacing only the first character
            (StringUtil.Replace("abcdef", "X", 0, 1)).Should().Be("Xbcdef");
        }

        [Fact]
        public void TestReplace10ReplaceLastCharacter()
        {
            // Test replacing only the last character
            (StringUtil.Replace("abcdef", "X", 5, 1)).Should().Be("abcdeX");
        }

        [Fact]
        public void TestReplace11ReplaceSingleCharacter()
        {
            // Test replacing a single character at various positions
            (StringUtil.Replace("abcdef", "X", 1, 1)).Should().Be("aXcdef");
        }

        [Fact]
        public void TestReplace12ReplaceMultipleCharactersAtStart()
        {
            // Test replacing multiple characters at the start
            (StringUtil.Replace("abcdef", "REPLACED", 0, 3)).Should().Be("REPLACEDdef");
        }

        [Fact]
        public void TestReplace13ReplaceMultipleCharactersInMiddle()
        {
            // Test replacing multiple characters in the middle
            (StringUtil.Replace("abcdef", "REPLACED", 2, 2)).Should().Be("abREPLACEDef");
        }

        [Fact]
        public void TestReplace14ReplaceMultipleCharactersAtEnd()
        {
            // Test replacing multiple characters at the end
            (StringUtil.Replace("abcdef", "REPLACED", 3, 3)).Should().Be("abcREPLACED");
        }

        [Fact]
        public void TestReplace15LengthZero()
        {
            // Test with length = 0 (insert without replacement)
            (StringUtil.Replace("abcd", "INSERT", 1, 0)).Should().Be("aINSERTbcd");
        }

        [Fact]
        public void TestReplace16LengthZeroAtStart()
        {
            // Test with length = 0 at start (prepend)
            (StringUtil.Replace("abcd", "PREFIX", 0, 0)).Should().Be("PREFIXabcd");
        }

        [Fact]
        public void TestReplace17LengthZeroAtEnd()
        {
            // Test with length = 0 at end (append)
            (StringUtil.Replace("abcd", "SUFFIX", 4, 0)).Should().Be("abcdSUFFIX");
        }

        [Fact]
        public void TestReplace18StartIndexZeroLengthZero()
        {
            // Test with both startIndex and length = 0 (insert at start)
            (StringUtil.Replace("original", "INSERT", 0, 0)).Should().Be("INSERToriginal");
        }

        [Fact]
        public void TestReplace19NumericReplacement()
        {
            // Test numeric replacement
            (StringUtil.Replace("abcd", "123", 1, 2)).Should().Be("a123d");
        }

        [Fact]
        public void TestReplace20SpecialCharactersInReplacement()
        {
            // Test special characters in replacement
            (StringUtil.Replace("abcd", "@#$", 1, 2)).Should().Be("a@#$d");
        }

        [Fact]
        public void TestReplace21SpaceInReplacement()
        {
            // Test space in replacement
            (StringUtil.Replace("abcd", "   ", 1, 2)).Should().Be("a   d");
        }

        [Fact]
        public void TestReplace22TabInReplacement()
        {
            // Test tab character in replacement
            (StringUtil.Replace("abcd", "\t", 1, 2)).Should().Be("a\td");
        }

        [Fact]
        public void TestReplace23NewlineInReplacement()
        {
            // Test newline character in replacement
            (StringUtil.Replace("abcd", "\n", 1, 2)).Should().Be("a\nd");
        }

        [Fact]
        public void TestReplace24VeryLongString()
        {
            // Test with very long string
            string longStr = new string('a', 1000);
            string result = StringUtil.Replace(longStr, "X", 500, 1);
            (result.Length).Should().Be(1000);
            (result.Substring(500, 1)).Should().Be("X");
        }

        [Fact]
        public void TestReplace25VeryLongReplacement()
        {
            // Test with very long replacement
            string longReplacement = new string('x', 1000);
            string result = StringUtil.Replace("abcd", longReplacement, 1, 2);
            (result.Length).Should().Be(1 + 1000 + 1); // a + replacement + d
            (result.Substring(0, 1)).Should().Be("a");
            (result.Substring(result.Length - 1, 1)).Should().Be("d");
        }

        [Fact]
        public void TestReplace26SingleCharacterSource()
        {
            // Test with single character source
            (StringUtil.Replace("a", "X", 0, 1)).Should().Be("X");
        }

        [Fact]
        public void TestReplace27TwoCharacterSource()
        {
            // Test with two character source
            (StringUtil.Replace("ab", "XY", 0, 2)).Should().Be("XY");
        }

        [Fact]
        public void TestReplace28ReplaceMiddleOfTwoCharacters()
        {
            // Test replacing one character in two character string
            (StringUtil.Replace("ab", "X", 1, 1)).Should().Be("aX");
        }

        [Fact]
        public void TestReplace29SelfReplacement()
        {
            // Test replacing with the same content
            (StringUtil.Replace("abcd", "bc", 1, 2)).Should().Be("abcd");
        }

        [Fact]
        public void TestReplace30StartIndexLarge()
        {
            // Test with large start index near end
            (StringUtil.Replace("abcdefgh", "X", 6, 2)).Should().Be("abcdefX");
        }

        [Fact]
        public void TestReplace31AllCharactersReplaced()
        {
            // Test replacing all characters one by one
            string original = "abcd";
            string result = original;
            for (int i = 0; i < original.Length; i++)
            {
                result = StringUtil.Replace(result, "X", i, 1);
            }
            (result).Should().Be("XXXX");
        }

        [Fact]
        public void TestReplace32ConsecutiveReplacements()
        {
            // Test multiple consecutive replacements
            string result = StringUtil.Replace("abcdef", "XY", 0, 2);
            // After first: "XYcdef"
            result = StringUtil.Replace(result, "ZW", 2, 2);
            // Replaces "cd" (indices 2-3) with "ZW": "XYZWef"
            (result).Should().Be("XYZWef");
        }

        [Fact]
        public void TestReplace33ReplaceWithNumbers()
        {
            // Test replacing with numeric content
            // Replace indices 0-3 with "1234", leaving "efgh"
            (StringUtil.Replace("abcdefgh", "1234", 0, 4)).Should().Be("1234efgh");
        }

        [Fact]
        public void TestReplace34MixedCaseReplacement()
        {
            // Test with mixed case replacement
            // Replace indices 3-4 ("de") with "De", leaving "fgH"
            (StringUtil.Replace("aBcdefgH", "De", 3, 2)).Should().Be("aBcDefgH");
        }

        [Fact]
        public void TestReplace35UnicodeCharactersInReplacement()
        {
            // Test with unicode characters in replacement
            (StringUtil.Replace("abcd", "★", 1, 2)).Should().Be("a★d");
        }

        [Fact]
        public void TestReplace36ReplaceWithMultipleSpaces()
        {
            // Test replacing with multiple spaces
            (StringUtil.Replace("abcd", "     ", 1, 2)).Should().Be("a     d");
        }

        [Fact]
        public void TestReplace37EmptyStringToSingleChar()
        {
            // Test replacing nothing with a character (length = 0)
            (StringUtil.Replace("abcd", "X", 1, 0)).Should().Be("aXbcd");
        }

        [Fact]
        public void TestReplace38ReplaceAllButFirst()
        {
            // Test replacing all but the first character
            (StringUtil.Replace("abcdefg", "X", 1, 6)).Should().Be("aX");
        }

        [Fact]
        public void TestReplace39ReplaceAllButLast()
        {
            // Test replacing all but the last character
            (StringUtil.Replace("abcdefg", "X", 0, 6)).Should().Be("Xg");
        }

        [Fact]
        public void TestReplace40MultipleConsecutiveReplacements()
        {
            // Test chain of replacements
            string result = "abcdefgh";
            result = StringUtil.Replace(result, "XX", 0, 2);
            // After: "XXcdefgh"
            result = StringUtil.Replace(result, "YY", 2, 2);
            // After: "XXYYefgh"
            result = StringUtil.Replace(result, "ZZ", 4, 2);
            // After: "XXYYZZgh"
            (result).Should().Be("XXYYZZgh");
        }

        [Fact]
        public void TestReplace41NullSource()
        {
            // Test null source throws exception
            Action act = () => StringUtil.Replace(null, "replacement", 0, 1);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestReplace42NullReplacement()
        {
            // Test null replacement throws exception
            Action act = () => StringUtil.Replace("source", null, 0, 1);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestReplace43EmptySourceEmptyReplacement()
        {
            // Test empty source with empty replacement
            (StringUtil.Replace("", "", 0, 0)).Should().Be("");
        }

        [Fact]
        public void TestReplace44EmptySourceNonEmptyReplacement()
        {
            // Test empty source with non-empty replacement
            (StringUtil.Replace("", "X", 0, 0)).Should().Be("X");
        }

        [Fact]
        public void TestReplace45ReplaceFirstThreeCharacters()
        {
            // Test replacing first three characters
            (StringUtil.Replace("abcdefgh", "XYZ", 0, 3)).Should().Be("XYZdefgh");
        }

        [Fact]
        public void TestReplace46ReplaceLastThreeCharacters()
        {
            // Test replacing last three characters
            (StringUtil.Replace("abcdefgh", "XYZ", 5, 3)).Should().Be("abcdeXYZ");
        }

        [Fact]
        public void TestReplace47ReplaceMiddleThreeCharacters()
        {
            // Test replacing middle three characters
            (StringUtil.Replace("abcdefgh", "XYZ", 2, 3)).Should().Be("abXYZfgh");
        }

        [Fact]
        public void TestReplace48ReplaceWithReplacementContainingOriginalContent()
        {
            // Test replacement containing part of original content
            // Replace indices 1-2 ("bc") with "abc", leaving "d"
            (StringUtil.Replace("abcd", "abc", 1, 2)).Should().Be("aabcd");
        }

        [Fact]
        public void TestReplace49ReplaceWithMuchLongerString()
        {
            // Test replacing a small section with much longer string
            string longReplacement = "VERYLONGREPLACEMENTSTRING";
            (StringUtil.Replace("abcd", longReplacement, 1, 2)).Should().Be("aVERYLONGREPLACEMENTSTRINGd");
        }

        [Fact]
        public void TestReplace50ReplaceWithMuchShorterString()
        {
            // Test replacing a long section with much shorter string
            string longSource = "abcdefghijklmnopqrst";
            (StringUtil.Replace(longSource, "X", 1, 19)).Should().Be("aX");
        }

        #endregion


        #region TrimCrLf(string) tests

        [Fact]
        public void TestTrimCrLf1()
        {
            (StringUtil.TrimCrLf("asdf\r\n")).Should().Be("asdf");
        }

        [Fact]
        public void TestTrimCrLf2()
        {
            (StringUtil.TrimCrLf("asdf\n")).Should().Be("asdf");
        }

        [Fact]
        public void TestTrimCrLf3()
        {
            (StringUtil.TrimCrLf("asdf" + StringUtil.ToChar(13) + StringUtil.ToChar(10))).Should().Be("asdf");
        }

        [Fact]
        public void TestTrimCrLf4OnlyCarriageReturn()
        {
            // Test with only carriage return
            (StringUtil.TrimCrLf("asdf\r")).Should().Be("asdf");
        }

        [Fact]
        public void TestTrimCrLf5OnlyLineFeed()
        {
            // Test with only line feed
            (StringUtil.TrimCrLf("asdf\n")).Should().Be("asdf");
        }

        [Fact]
        public void TestTrimCrLf6MultipleLineFeeds()
        {
            // Test with multiple line feeds (only LF, not CR)
            (StringUtil.TrimCrLf("asdf\n\n\n")).Should().Be("asdf");
        }

        [Fact]
        public void TestTrimCrLf7MultipleLineFeeds()
        {
            // Test with multiple line feeds at end
            (StringUtil.TrimCrLf("asdf\n\n\n")).Should().Be("asdf");
        }

        [Fact]
        public void TestTrimCrLf8MultipleCarriageReturns()
        {
            // Test with multiple carriage returns at end
            (StringUtil.TrimCrLf("asdf\r\r\r")).Should().Be("asdf");
        }

        [Fact]
        public void TestTrimCrLf9OnlyLineFeeds()
        {
            // Test with only line feeds (no CR)
            (StringUtil.TrimCrLf("asdf\n\n\n")).Should().Be("asdf");
        }

        [Fact]
        public void TestTrimCrLf10NoLineEndings()
        {
            // Test with no line endings
            (StringUtil.TrimCrLf("asdf")).Should().Be("asdf");
        }

        [Fact]
        public void TestTrimCrLf11EmptyString()
        {
            // An empty string has nothing to trim and should be returned unchanged, not throw.
            (StringUtil.TrimCrLf("")).Should().Be("");
        }

        [Fact]
        public void TestTrimCrLf12SingleLineFeed()
        {
            // A string consisting only of a line feed should trim down to an empty string, not throw.
            (StringUtil.TrimCrLf("\n")).Should().Be("");
        }

        [Fact]
        public void TestTrimCrLf13SingleCarriageReturn()
        {
            // A string consisting only of a carriage return should trim down to an empty string, not throw.
            (StringUtil.TrimCrLf("\r")).Should().Be("");
        }

        [Fact]
        public void TestTrimCrLf14SingleCRLF()
        {
            // A string consisting only of a CRLF pair should trim down to an empty string, not throw.
            (StringUtil.TrimCrLf("\r\n")).Should().Be("");
        }

        [Fact]
        public void TestTrimCrLf41MultipleAlternatingCRLFPairs()
        {
            // Multiple alternating CRLF pairs at the tail must all be trimmed, not just the outermost pair.
            (StringUtil.TrimCrLf("asdf\r\n\r\n")).Should().Be("asdf");
        }

        [Fact]
        public void TestTrimCrLf15LineEndingsInMiddle()
        {
            // Test with line endings in the middle (should only trim end)
            (StringUtil.TrimCrLf("asdf\r\nqwer\r\n")).Should().Be("asdf\r\nqwer");
        }

        [Fact]
        public void TestTrimCrLf16LineEndingsAtStart()
        {
            // Test with line endings at start (should not be trimmed)
            (StringUtil.TrimCrLf("\r\nasdf")).Should().Be("\r\nasdf");
        }

        [Fact]
        public void TestTrimCrLf17LongStringWithLineEndings()
        {
            // Test with long string
            string longStr = new string('a', 1000);
            (StringUtil.TrimCrLf(longStr + "\r\n")).Should().Be(longStr);
        }

        [Fact]
        public void TestTrimCrLf18SingleCharacterWithLineFeed()
        {
            // Test single character with line feed
            (StringUtil.TrimCrLf("a\n")).Should().Be("a");
        }

        [Fact]
        public void TestTrimCrLf19SingleCharacterWithCarriageReturn()
        {
            // Test single character with carriage return
            (StringUtil.TrimCrLf("a\r")).Should().Be("a");
        }

        [Fact]
        public void TestTrimCrLf20TwoCharactersWithCRLF()
        {
            // Test two characters with CRLF
            (StringUtil.TrimCrLf("ab\r\n")).Should().Be("ab");
        }

        [Fact]
        public void TestTrimCrLf21SpecialCharactersBeforeLineEndings()
        {
            // Test special characters before line endings
            (StringUtil.TrimCrLf("@#$%\r\n")).Should().Be("@#$%");
        }

        [Fact]
        public void TestTrimCrLf22SpacesBeforeLineEndings()
        {
            // Test spaces before line endings
            (StringUtil.TrimCrLf("asdf   \r\n")).Should().Be("asdf   ");
        }

        [Fact]
        public void TestTrimCrLf23TabsBeforeLineEndings()
        {
            // Test tabs before line endings (tabs should NOT be trimmed)
            (StringUtil.TrimCrLf("asdf\t\t\r\n")).Should().Be("asdf\t\t");
        }

        [Fact]
        public void TestTrimCrLf24UnicodeCharactersBeforeLineEndings()
        {
            // Test unicode characters before line endings
            (StringUtil.TrimCrLf("★★★\r\n")).Should().Be("★★★");
        }

        [Fact]
        public void TestTrimCrLf25NumericStringWithLineEndings()
        {
            // Test numeric string with line endings
            (StringUtil.TrimCrLf("12345\r\n")).Should().Be("12345");
        }

        [Fact]
        public void TestTrimCrLf26MixedCaseWithLineEndings()
        {
            // Test mixed case with line endings
            (StringUtil.TrimCrLf("AsDf\r\n")).Should().Be("AsDf");
        }

        [Fact]
        public void TestTrimCrLf27OnlyLineFeedsMultiple()
        {
            // Test multiple line feeds in sequence
            (StringUtil.TrimCrLf("test\n\n\n\n\n")).Should().Be("test");
        }

        [Fact]
        public void TestTrimCrLf28OnlyCarriageReturnsMultiple()
        {
            // Test multiple carriage returns in sequence
            (StringUtil.TrimCrLf("test\r\r\r\r\r")).Should().Be("test");
        }

        [Fact]
        public void TestTrimCrLf29CRFollowedByLF()
        {
            // Test CR followed by LF (proper Windows line ending)
            // Note: This is the standard case that works correctly
            (StringUtil.TrimCrLf("test\r\n")).Should().Be("test");
        }

        [Fact]
        public void TestTrimCrLf30OnlyCarriageReturns()
        {
            // Test with only carriage returns (no LF)
            (StringUtil.TrimCrLf("test\r\r\r")).Should().Be("test");
        }

        [Fact]
        public void TestTrimCrLf31CRBeforeLFOnly()
        {
            // Test CR before LF (the expected Windows line ending order)
            (StringUtil.TrimCrLf("test\r\n")).Should().Be("test");
        }

        [Fact]
        public void TestTrimCrLf32OnlyCarriageReturnsMultiple()
        {
            // Test multiple carriage returns without LF
            (StringUtil.TrimCrLf("test\r\r\r")).Should().Be("test");
        }

        [Fact]
        public void TestTrimCrLf33LongStringWithSimpleLineEndings()
        {
            // Test with long string and simple line endings
            string source = new string('a', 100) + "\r\n";
            (StringUtil.TrimCrLf(source)).Should().Be(new string('a', 100));
        }

        [Fact]
        public void TestTrimCrLf34ContentWithInternalNewlines()
        {
            // Test content with internal newlines (only end should be trimmed)
            string source = "line1\nline2\nline3\n";
            (StringUtil.TrimCrLf(source)).Should().Be("line1\nline2\nline3");
        }

        [Fact]
        public void TestTrimCrLf35ContentWithInternalCarriageReturns()
        {
            // Test content with internal carriage returns (only end should be trimmed)
            string source = "line1\rline2\rline3\r";
            (StringUtil.TrimCrLf(source)).Should().Be("line1\rline2\rline3");
        }

        [Fact]
        public void TestTrimCrLf36MultipleConsecutiveTrimmer()
        {
            // Test applying trim multiple times (should be idempotent after first call)
            string source = "test\r\n";
            string first = StringUtil.TrimCrLf(source);
            string second = StringUtil.TrimCrLf(first);
            (second).Should().Be(first);
            (second).Should().Be("test");
        }

        [Fact]
        public void TestTrimCrLf37NullSource()
        {
            // Test null source throws exception
            Action act = () => StringUtil.TrimCrLf(null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestTrimCrLf38OnlySpaceNoLineEndings()
        {
            // Test string with only spaces (no line endings)
            (StringUtil.TrimCrLf("     ")).Should().Be("     ");
        }

        [Fact]
        public void TestTrimCrLf39OnlyTabsNoLineEndings()
        {
            // Test string with only tabs (no line endings)
            (StringUtil.TrimCrLf("\t\t\t")).Should().Be("\t\t\t");
        }

        [Fact]
        public void TestTrimCrLf40WhitespaceBeforeLineEndings()
        {
            // Test various whitespace before line endings (should be preserved)
            (StringUtil.TrimCrLf("  \t  \r\n")).Should().Be("  \t  ");
        }

        #endregion


        #region Right(string, int) tests

        [Fact]
        public void TestRight1()
        {
            (StringUtil.Right("asdf", 0)).Should().Be("");
        }

        [Fact]
        public void TestRight2()
        {
            (StringUtil.Right("asdf", 1)).Should().Be("f");
        }

        [Fact]
        public void TestRight3()
        {
            (StringUtil.Right("asdf", 2)).Should().Be("df");
        }

        [Fact]
        public void TestRight4()
        {
            (StringUtil.Right("asdf", 3)).Should().Be("sdf");
        }

        [Fact]
        public void TestRight5()
        {
            (StringUtil.Right("asdf", 4)).Should().Be("asdf");
        }

        [Fact]
        public void TestRight6LengthGreaterThanString()
        {
            // Test when length exceeds string length (throws ArgumentOutOfRangeException)
            Action act = () => StringUtil.Right("asdf", 5);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestRight7NegativeLength()
        {
            // Test with negative length (throws ArgumentOutOfRangeException)
            Action act = () => StringUtil.Right("asdf", -1);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestRight8NullSource()
        {
            // Test null source throws exception
            Action act = () => StringUtil.Right(null, 2);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestRight9SingleCharacter()
        {
            // Test with single character string
            (StringUtil.Right("a", 1)).Should().Be("a");
        }

        [Fact]
        public void TestRight10SingleCharacterZeroLength()
        {
            // Test with single character and length 0
            (StringUtil.Right("a", 0)).Should().Be("");
        }

        [Fact]
        public void TestRight11EmptyString()
        {
            // Test with empty string and length 0
            (StringUtil.Right("", 0)).Should().Be("");
        }

        [Fact]
        public void TestRight12EmptyStringNonZeroLength()
        {
            // Test with empty string and non-zero length (throws ArgumentOutOfRangeException)
            Action act = () => StringUtil.Right("", 1);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestRight13LongString()
        {
            // Test with long string
            string source = new string('a', 1000);
            (StringUtil.Right(source, 10)).Should().Be(new string('a', 10));
        }

        [Fact]
        public void TestRight14LongStringFullLength()
        {
            // Test extracting entire long string
            string source = new string('a', 100);
            (StringUtil.Right(source, 100)).Should().Be(source);
        }

        [Fact]
        public void TestRight15NumericString()
        {
            // Test with numeric string
            (StringUtil.Right("123456", 3)).Should().Be("456");
        }

        [Fact]
        public void TestRight16SpecialCharacters()
        {
            // Test with special characters
            (StringUtil.Right("abc@#$", 3)).Should().Be("@#$");
        }

        [Fact]
        public void TestRight17Spaces()
        {
            // Test with spaces at the end
            (StringUtil.Right("abc   ", 3)).Should().Be("   ");
        }

        [Fact]
        public void TestRight18Tabs()
        {
            // Test with tabs at the end
            (StringUtil.Right("abc\t\t", 2)).Should().Be("\t\t");
        }

        [Fact]
        public void TestRight19MixedCase()
        {
            // Test with mixed case
            (StringUtil.Right("AbCDeF", 3)).Should().Be("DeF");
        }

        [Fact]
        public void TestRight20UnicodeCharacters()
        {
            // Test with unicode characters
            (StringUtil.Right("abc★★", 2)).Should().Be("★★");
        }

        [Fact]
        public void TestRight21StringWithNewlines()
        {
            // Test string containing newlines
            (StringUtil.Right("abcd\nef\n", 3)).Should().Be("ef\n");
        }

        [Fact]
        public void TestRight22AllCharactersTheSame()
        {
            // Test string where all characters are identical
            (StringUtil.Right("aaaaaaaa", 4)).Should().Be("aaaa");
        }

        [Fact]
        public void TestRight23TwoCharacterString()
        {
            // Test with two character string
            (StringUtil.Right("ef", 1)).Should().Be("f");
        }

        [Fact]
        public void TestRight24TwoCharacterStringFullLength()
        {
            // Test extracting both characters
            (StringUtil.Right("ef", 2)).Should().Be("ef");
        }

        [Fact]
        public void TestRight25WhitespaceCharacters()
        {
            // Test various whitespace at end
            (StringUtil.Right("abc \t ", 3)).Should().Be(" \t ");
        }

        #endregion


        #region Left(string, int) tests

        [Fact]
        public void TestLeft1()
        {
            (StringUtil.Left("asdf", 0)).Should().Be("");
        }

        [Fact]
        public void TestLeft2()
        {
            (StringUtil.Left("asdf", 1)).Should().Be("a");
        }

        [Fact]
        public void TestLeft3()
        {
            (StringUtil.Left("asdf", 2)).Should().Be("as");
        }

        [Fact]
        public void TestLeft4()
        {
            (StringUtil.Left("asdf", 3)).Should().Be("asd");
        }

        [Fact]
        public void TestLeft5()
        {
            (StringUtil.Left("asdf", 4)).Should().Be("asdf");
        }

        [Fact]
        public void TestLeft6LengthGreaterThanString()
        {
            // Test when length exceeds string length (throws ArgumentOutOfRangeException)
            Action act = () => StringUtil.Left("asdf", 5);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestLeft7NegativeLength()
        {
            // Test with negative length (throws ArgumentOutOfRangeException)
            Action act = () => StringUtil.Left("asdf", -1);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestLeft8NullSource()
        {
            // Test null source throws exception
            Action act = () => StringUtil.Left(null, 2);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestLeft9SingleCharacter()
        {
            // Test with single character string
            (StringUtil.Left("a", 1)).Should().Be("a");
        }

        [Fact]
        public void TestLeft10SingleCharacterZeroLength()
        {
            // Test with single character and length 0
            (StringUtil.Left("a", 0)).Should().Be("");
        }

        [Fact]
        public void TestLeft11EmptyString()
        {
            // Test with empty string and length 0
            (StringUtil.Left("", 0)).Should().Be("");
        }

        [Fact]
        public void TestLeft12EmptyStringNonZeroLength()
        {
            // Test with empty string and non-zero length (throws ArgumentOutOfRangeException)
            Action act = () => StringUtil.Left("", 1);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestLeft13LongString()
        {
            // Test with long string
            string source = new string('a', 1000);
            (StringUtil.Left(source, 10)).Should().Be(new string('a', 10));
        }

        [Fact]
        public void TestLeft14LongStringFullLength()
        {
            // Test extracting entire long string
            string source = new string('a', 100);
            (StringUtil.Left(source, 100)).Should().Be(source);
        }

        [Fact]
        public void TestLeft15NumericString()
        {
            // Test with numeric string
            (StringUtil.Left("123456", 3)).Should().Be("123");
        }

        [Fact]
        public void TestLeft16SpecialCharacters()
        {
            // Test with special characters
            (StringUtil.Left("abc@#$", 3)).Should().Be("abc");
        }

        [Fact]
        public void TestLeft17Spaces()
        {
            // Test with leading spaces
            (StringUtil.Left("   abc", 3)).Should().Be("   ");
        }

        [Fact]
        public void TestLeft18Tabs()
        {
            // Test with leading tabs
            (StringUtil.Left("\t\tabc", 2)).Should().Be("\t\t");
        }

        [Fact]
        public void TestLeft19MixedCase()
        {
            // Test with mixed case
            (StringUtil.Left("AbCDeF", 3)).Should().Be("AbC");
        }

        [Fact]
        public void TestLeft20UnicodeCharacters()
        {
            // Test with unicode characters
            (StringUtil.Left("★★abc", 2)).Should().Be("★★");
        }

        [Fact]
        public void TestLeft21StringWithNewlines()
        {
            // Test string containing newlines
            (StringUtil.Left("ab\ncd\nef", 3)).Should().Be("ab\n");
        }

        [Fact]
        public void TestLeft22AllCharactersTheSame()
        {
            // Test string where all characters are identical
            (StringUtil.Left("aaaaaaaa", 4)).Should().Be("aaaa");
        }

        [Fact]
        public void TestLeft23TwoCharacterString()
        {
            // Test with two character string
            (StringUtil.Left("ef", 1)).Should().Be("e");
        }

        [Fact]
        public void TestLeft24TwoCharacterStringFullLength()
        {
            // Test extracting both characters
            (StringUtil.Left("ef", 2)).Should().Be("ef");
        }

        [Fact]
        public void TestLeft25WhitespaceCharacters()
        {
            // Test various whitespace at start
            (StringUtil.Left(" \t abc", 3)).Should().Be(" \t ");
        }

        #endregion


        #region RemoveDoubleQuoteWrapper(string) tests

        [Fact]
        public void RemoveDoubleQuoteWrapper1()
        {
            (StringUtil.RemoveDoubleQuoteWrapper("\"This is a test\"")).Should().Be("This is a test");
        }

        [Fact]
        public void RemoveDoubleQuoteWrapper2()
        {
            (StringUtil.RemoveDoubleQuoteWrapper("\"This\" is \"a test\"")).Should().Be("This\" is \"a test");
        }

        [Fact]
        public void RemoveDoubleQuoteWrapper3()
        {
            (StringUtil.RemoveDoubleQuoteWrapper("\"\"This is a test\"\"")).Should().Be("\"This is a test\"");
        }

        [Fact]
        public void RemoveDoubleQuoteWrapper4()
        {
            (StringUtil.RemoveDoubleQuoteWrapper("\"\"This\" is \"a test\"\"")).Should().Be("\"This\" is \"a test\"");
        }

        [Fact]
        public void RemoveDoubleQuoteWrapper5()
        {
            (StringUtil.RemoveDoubleQuoteWrapper("This is a test")).Should().Be("This is a test");
        }

        [Fact]
        public void RemoveDoubleQuoteWrapper6NullInput()
        {
            // Test null input throws ArgumentNullException
            Action act = () => StringUtil.RemoveDoubleQuoteWrapper(null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void RemoveDoubleQuoteWrapper7EmptyString()
        {
            // An empty string has no wrapping quotes to remove and should be returned unchanged, not throw.
            (StringUtil.RemoveDoubleQuoteWrapper("")).Should().Be("");
        }

        [Fact]
        public void RemoveDoubleQuoteWrapper8SingleCharacterNonQuote()
        {
            // Single character that's not a quote should return unchanged
            (StringUtil.RemoveDoubleQuoteWrapper("a")).Should().Be("a");
        }

        [Fact]
        public void RemoveDoubleQuoteWrapper9SingleQuoteCharacter()
        {
            // A single quote character is too short to be a wrapped pair (opening and closing quote
            // would be the same character) and should be returned unchanged, not throw.
            (StringUtil.RemoveDoubleQuoteWrapper("\"")).Should().Be("\"");
        }

        [Fact]
        public void RemoveDoubleQuoteWrapper10TwoQuotes()
        {
            // Two quotes should remove both, returning empty string
            (StringUtil.RemoveDoubleQuoteWrapper("\"\"")).Should().Be("");
        }

        [Fact]
        public void RemoveDoubleQuoteWrapper11SingleCharWithQuotes()
        {
            // Single character wrapped in quotes
            (StringUtil.RemoveDoubleQuoteWrapper("\"a\"")).Should().Be("a");
        }

        [Fact]
        public void RemoveDoubleQuoteWrapper12OpeningQuoteOnly()
        {
            // Only opening quote - should return unchanged
            (StringUtil.RemoveDoubleQuoteWrapper("\"test")).Should().Be("\"test");
        }

        [Fact]
        public void RemoveDoubleQuoteWrapper13ClosingQuoteOnly()
        {
            // Only closing quote - should return unchanged
            (StringUtil.RemoveDoubleQuoteWrapper("test\"")).Should().Be("test\"");
        }

        [Fact]
        public void RemoveDoubleQuoteWrapper14TripleQuotes()
        {
            // Three quotes - outer two removed, middle one remains
            (StringUtil.RemoveDoubleQuoteWrapper("\"\"\"")).Should().Be("\"");
        }

        [Fact]
        public void RemoveDoubleQuoteWrapper15FourQuotes()
        {
            // Four quotes - outer two removed, inner two remain
            (StringUtil.RemoveDoubleQuoteWrapper("\"\"\"\"")).Should().Be("\"\"");
        }

        [Fact]
        public void RemoveDoubleQuoteWrapper16FiveQuotes()
        {
            // Five quotes - outer two removed, three remain
            (StringUtil.RemoveDoubleQuoteWrapper("\"\"\"\"\"")).Should().Be("\"\"\"");
        }

        [Fact]
        public void RemoveDoubleQuoteWrapper17WhitespaceOnly()
        {
            // Whitespace only - no quotes, return unchanged
            (StringUtil.RemoveDoubleQuoteWrapper("   ")).Should().Be("   ");
        }

        [Fact]
        public void RemoveDoubleQuoteWrapper18WhitespaceWithQuotes()
        {
            // Whitespace wrapped in quotes
            (StringUtil.RemoveDoubleQuoteWrapper("\"   \"")).Should().Be("   ");
        }

        [Fact]
        public void RemoveDoubleQuoteWrapper19TabWithQuotes()
        {
            // Tab wrapped in quotes
            (StringUtil.RemoveDoubleQuoteWrapper("\"\t\"")).Should().Be("\t");
        }

        [Fact]
        public void RemoveDoubleQuoteWrapper20NewlineWithQuotes()
        {
            // Newline wrapped in quotes
            (StringUtil.RemoveDoubleQuoteWrapper("\"\n\"")).Should().Be("\n");
        }

        [Fact]
        public void RemoveDoubleQuoteWrapper21SpecialCharactersWithQuotes()
        {
            // Special characters wrapped in quotes
            (StringUtil.RemoveDoubleQuoteWrapper("\"!@#$%\"")).Should().Be("!@#$%");
        }

        [Fact]
        public void RemoveDoubleQuoteWrapper22UnicodeWithQuotes()
        {
            // Unicode characters wrapped in quotes
            (StringUtil.RemoveDoubleQuoteWrapper("\"★★★\"")).Should().Be("★★★");
        }

        [Fact]
        public void RemoveDoubleQuoteWrapper23MixedContentWithQuotes()
        {
            // Mixed content with numbers, letters, special chars
            (StringUtil.RemoveDoubleQuoteWrapper("\"abc123!@#\"")).Should().Be("abc123!@#");
        }

        [Fact]
        public void RemoveDoubleQuoteWrapper24LongStringWithQuotes()
        {
            // Very long string wrapped in quotes
            string longContent = new string('a', 1000);
            (StringUtil.RemoveDoubleQuoteWrapper("\"" + longContent + "\"")).Should().Be(longContent);
        }

        [Fact]
        public void RemoveDoubleQuoteWrapper25StringWithLeadingAndTrailingSpaces()
        {
            // String with leading and trailing spaces wrapped in quotes
            (StringUtil.RemoveDoubleQuoteWrapper("\"  test  \"")).Should().Be("  test  ");
        }

        [Fact]
        public void RemoveDoubleQuoteWrapper26StringWithInternalQuotesAndSpaces()
        {
            // String with internal quotes and spaces
            (StringUtil.RemoveDoubleQuoteWrapper("\"test \" with \" quotes\"")).Should().Be("test \" with \" quotes");
        }

        [Fact]
        public void RemoveDoubleQuoteWrapper27StringWithBackslashes()
        {
            // String with backslashes wrapped in quotes
            (StringUtil.RemoveDoubleQuoteWrapper("\"path\\to\\file\"")).Should().Be("path\\to\\file");
        }

        [Fact]
        public void RemoveDoubleQuoteWrapper28StringWithForwardSlashes()
        {
            // String with forward slashes wrapped in quotes
            (StringUtil.RemoveDoubleQuoteWrapper("\"path/to/file\"")).Should().Be("path/to/file");
        }

        [Fact]
        public void RemoveDoubleQuoteWrapper29StringWithEqualSign()
        {
            // String with equals sign wrapped in quotes
            (StringUtil.RemoveDoubleQuoteWrapper("\"key=value\"")).Should().Be("key=value");
        }

        [Fact]
        public void RemoveDoubleQuoteWrapper30StringWithColons()
        {
            // String with colons (like URLs) wrapped in quotes
            (StringUtil.RemoveDoubleQuoteWrapper("\"http://example.com\"")).Should().Be("http://example.com");
        }

        #endregion


        #region WrapWithDoubleQuote(object) tests

        [Fact]
        public void TestWrapWithDoubleQuotes()
        {
            (StringUtil.WrapWithDoubleQuotes("This is a test")).Should().Be("\"This is a test\"");
        }

        [Fact]
        public void TestWrapWithDoubleQuotes2NullInput()
        {
            // Test null input throws ArgumentNullException
            Action act = () => StringUtil.WrapWithDoubleQuotes(null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestWrapWithDoubleQuotes3EmptyString()
        {
            // Empty string should be wrapped in quotes
            (StringUtil.WrapWithDoubleQuotes("")).Should().Be("\"\"");
        }

        [Fact]
        public void TestWrapWithDoubleQuotes4SingleCharacter()
        {
            // Single character string
            (StringUtil.WrapWithDoubleQuotes("a")).Should().Be("\"a\"");
        }

        [Fact]
        public void TestWrapWithDoubleQuotes5StringWithLeadingSpaces()
        {
            // String with leading spaces
            (StringUtil.WrapWithDoubleQuotes("   text")).Should().Be("\"   text\"");
        }

        [Fact]
        public void TestWrapWithDoubleQuotes6StringWithTrailingSpaces()
        {
            // String with trailing spaces
            (StringUtil.WrapWithDoubleQuotes("text   ")).Should().Be("\"text   \"");
        }

        [Fact]
        public void TestWrapWithDoubleQuotes7StringWithLeadingAndTrailingSpaces()
        {
            // String with both leading and trailing spaces
            (StringUtil.WrapWithDoubleQuotes("   text   ")).Should().Be("\"   text   \"");
        }

        [Fact]
        public void TestWrapWithDoubleQuotes8StringWithInternalQuotes()
        {
            // String with internal double quotes
            (StringUtil.WrapWithDoubleQuotes("text \" with \" quotes")).Should().Be("\"text \" with \" quotes\"");
        }

        [Fact]
        public void TestWrapWithDoubleQuotes9StringWithSingleQuotes()
        {
            // String with single quotes
            (StringUtil.WrapWithDoubleQuotes("text 'with' quotes")).Should().Be("\"text 'with' quotes\"");
        }

        [Fact]
        public void TestWrapWithDoubleQuotes10StringWithTab()
        {
            // String with tab character
            (StringUtil.WrapWithDoubleQuotes("text\twith\ttabs")).Should().Be("\"text\twith\ttabs\"");
        }

        [Fact]
        public void TestWrapWithDoubleQuotes11StringWithNewline()
        {
            // String with newline character
            (StringUtil.WrapWithDoubleQuotes("text\nwith\nnewlines")).Should().Be("\"text\nwith\nnewlines\"");
        }

        [Fact]
        public void TestWrapWithDoubleQuotes12StringWithSpecialCharacters()
        {
            // String with special characters
            (StringUtil.WrapWithDoubleQuotes("!@#$%^&*()")).Should().Be("\"!@#$%^&*()\"");
        }

        [Fact]
        public void TestWrapWithDoubleQuotes13StringWithBackslash()
        {
            // String with backslashes
            (StringUtil.WrapWithDoubleQuotes("path\\to\\file")).Should().Be("\"path\\to\\file\"");
        }

        [Fact]
        public void TestWrapWithDoubleQuotes14StringWithForwardSlash()
        {
            // String with forward slashes
            (StringUtil.WrapWithDoubleQuotes("path/to/file")).Should().Be("\"path/to/file\"");
        }

        [Fact]
        public void TestWrapWithDoubleQuotes15UnicodeCharacters()
        {
            // String with unicode characters
            (StringUtil.WrapWithDoubleQuotes("★★★")).Should().Be("\"★★★\"");
        }

        [Fact]
        public void TestWrapWithDoubleQuotes16LongString()
        {
            // Very long string
            string longText = new string('a', 1000);
            (StringUtil.WrapWithDoubleQuotes(longText)).Should().Be("\"" + longText + "\"");
        }

        [Fact]
        public void TestWrapWithDoubleQuotes17IntegerValue()
        {
            // Integer wrapped in quotes
            (StringUtil.WrapWithDoubleQuotes(42)).Should().Be("\"42\"");
        }

        [Fact]
        public void TestWrapWithDoubleQuotes18NegativeInteger()
        {
            // Negative integer
            (StringUtil.WrapWithDoubleQuotes(-42)).Should().Be("\"-42\"");
        }

        [Fact]
        public void TestWrapWithDoubleQuotes19ZeroInteger()
        {
            // Zero integer
            (StringUtil.WrapWithDoubleQuotes(0)).Should().Be("\"0\"");
        }

        [Fact]
        public void TestWrapWithDoubleQuotes20LongValue()
        {
            // Long integer value
            (StringUtil.WrapWithDoubleQuotes(1234567890123L)).Should().Be("\"1234567890123\"");
        }

        [Fact]
        public void TestWrapWithDoubleQuotes21DoubleValue()
        {
            // Double value
            (StringUtil.WrapWithDoubleQuotes(3.14)).Should().Be("\"3.14\"");
        }

        [Fact]
        public void TestWrapWithDoubleQuotes22DecimalValue()
        {
            // Decimal value
            (StringUtil.WrapWithDoubleQuotes(99.99m)).Should().Be("\"99.99\"");
        }

        [Fact]
        public void TestWrapWithDoubleQuotes23BooleanTrue()
        {
            // Boolean true value
            (StringUtil.WrapWithDoubleQuotes(true)).Should().Be("\"True\"");
        }

        [Fact]
        public void TestWrapWithDoubleQuotes24BooleanFalse()
        {
            // Boolean false value
            (StringUtil.WrapWithDoubleQuotes(false)).Should().Be("\"False\"");
        }

        [Fact]
        public void TestWrapWithDoubleQuotes25DateTime()
        {
            // DateTime object
            DateTime dt = new DateTime(2023, 12, 25, 10, 30, 45);
            string expected = "\"" + dt.ToString("MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture) + "\"";
            (StringUtil.WrapWithDoubleQuotes(dt)).Should().Be(expected);
        }

        [Fact]
        public void TestWrapWithDoubleQuotes26TimeSpan()
        {
            // TimeSpan object
            TimeSpan ts = new TimeSpan(1, 2, 3, 4);
            string expected = "\"" + ts.ToString() + "\"";
            (StringUtil.WrapWithDoubleQuotes(ts)).Should().Be(expected);
        }

        [Fact]
        public void TestWrapWithDoubleQuotes27Guid()
        {
            // GUID object
            Guid g = new Guid("12345678-1234-1234-1234-123456789abc");
            string expected = "\"" + g.ToString() + "\"";
            (StringUtil.WrapWithDoubleQuotes(g)).Should().Be(expected);
        }

        [Fact]
        public void TestWrapWithDoubleQuotes28CharValue()
        {
            // Character value
            (StringUtil.WrapWithDoubleQuotes('A')).Should().Be("\"A\"");
        }

        [Fact]
        public void TestWrapWithDoubleQuotes29FloatValue()
        {
            // Float value
            (StringUtil.WrapWithDoubleQuotes(2.5f)).Should().Be("\"2.5\"");
        }

        [Fact]
        public void TestWrapWithDoubleQuotes30ByteValue()
        {
            // Byte value
            byte b = 255;
            (StringUtil.WrapWithDoubleQuotes(b)).Should().Be("\"255\"");
        }

        [Fact]
        public void TestWrapWithDoubleQuotes31StringBuilder()
        {
            // StringBuilder object (calls ToString on it)
            StringBuilder sb = new StringBuilder("Hello World");
            (StringUtil.WrapWithDoubleQuotes(sb)).Should().Be("\"Hello World\"");
        }

        [Fact]
        public void TestWrapWithDoubleQuotes32List()
        {
            // List object (default ToString representation)
            List<string> list = new List<string> { "a", "b", "c" };
            string expected = "\"" + list.ToString() + "\"";
            (StringUtil.WrapWithDoubleQuotes(list)).Should().Be(expected);
        }

        [Fact]
        public void TestWrapWithDoubleQuotes33Dictionary()
        {
            // Dictionary object (default ToString representation)
            Dictionary<string, int> dict = new Dictionary<string, int> { { "key", 42 } };
            string expected = "\"" + dict.ToString() + "\"";
            (StringUtil.WrapWithDoubleQuotes(dict)).Should().Be(expected);
        }

        [Fact]
        public void TestWrapWithDoubleQuotes34Array()
        {
            // Array object (default ToString representation)
            string[] arr = { "a", "b", "c" };
            string expected = "\"" + arr.ToString() + "\"";
            (StringUtil.WrapWithDoubleQuotes(arr)).Should().Be(expected);
        }

        [Fact]
        public void TestWrapWithDoubleQuotes35EqualsSign()
        {
            // String with equals sign (key=value pattern)
            (StringUtil.WrapWithDoubleQuotes("key=value")).Should().Be("\"key=value\"");
        }

        [Fact]
        public void TestWrapWithDoubleQuotes36Colon()
        {
            // String with colon (URL pattern)
            (StringUtil.WrapWithDoubleQuotes("http://example.com")).Should().Be("\"http://example.com\"");
        }

        [Fact]
        public void TestWrapWithDoubleQuotes37Comma()
        {
            // String with comma (CSV pattern)
            (StringUtil.WrapWithDoubleQuotes("value1,value2,value3")).Should().Be("\"value1,value2,value3\"");
        }

        [Fact]
        public void TestWrapWithDoubleQuotes38Semicolon()
        {
            // String with semicolon
            (StringUtil.WrapWithDoubleQuotes("item1;item2;item3")).Should().Be("\"item1;item2;item3\"");
        }

        [Fact]
        public void TestWrapWithDoubleQuotes39CarriageReturn()
        {
            // String with carriage return
            (StringUtil.WrapWithDoubleQuotes("line1\rline2")).Should().Be("\"line1\rline2\"");
        }

        [Fact]
        public void TestWrapWithDoubleQuotes40FormFeed()
        {
            // String with form feed
            (StringUtil.WrapWithDoubleQuotes("page1\fpage2")).Should().Be("\"page1\fpage2\"");
        }

        #endregion


        #region WrapWithSingleQuotes(object) tests

        [Fact]
        public void TestWrapWithSingleQuotes()
        {
            (StringUtil.WrapWithSingleQuotes("This is a test")).Should().Be("'This is a test'");
        }

        [Fact]
        public void TestWrapWithSingleQuotes2NullInput()
        {
            // Test null input throws ArgumentNullException
            Action act = () => StringUtil.WrapWithSingleQuotes(null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestWrapWithSingleQuotes3EmptyString()
        {
            // Empty string should be wrapped in quotes
            (StringUtil.WrapWithSingleQuotes("")).Should().Be("''");
        }

        [Fact]
        public void TestWrapWithSingleQuotes4SingleCharacter()
        {
            // Single character string
            (StringUtil.WrapWithSingleQuotes("a")).Should().Be("'a'");
        }

        [Fact]
        public void TestWrapWithSingleQuotes5StringWithLeadingSpaces()
        {
            // String with leading spaces
            (StringUtil.WrapWithSingleQuotes("   text")).Should().Be("'   text'");
        }

        [Fact]
        public void TestWrapWithSingleQuotes6StringWithTrailingSpaces()
        {
            // String with trailing spaces
            (StringUtil.WrapWithSingleQuotes("text   ")).Should().Be("'text   '");
        }

        [Fact]
        public void TestWrapWithSingleQuotes7StringWithLeadingAndTrailingSpaces()
        {
            // String with both leading and trailing spaces
            (StringUtil.WrapWithSingleQuotes("   text   ")).Should().Be("'   text   '");
        }

        [Fact]
        public void TestWrapWithSingleQuotes8StringWithInternalSingleQuotes()
        {
            // String with internal single quotes
            (StringUtil.WrapWithSingleQuotes("text ' with ' quotes")).Should().Be("'text ' with ' quotes'");
        }

        [Fact]
        public void TestWrapWithSingleQuotes9StringWithDoubleQuotes()
        {
            // String with double quotes
            (StringUtil.WrapWithSingleQuotes("text \"with\" quotes")).Should().Be("'text \"with\" quotes'");
        }

        [Fact]
        public void TestWrapWithSingleQuotes10StringWithTab()
        {
            // String with tab character
            (StringUtil.WrapWithSingleQuotes("text\twith\ttabs")).Should().Be("'text\twith\ttabs'");
        }

        [Fact]
        public void TestWrapWithSingleQuotes11StringWithNewline()
        {
            // String with newline character
            (StringUtil.WrapWithSingleQuotes("text\nwith\nnewlines")).Should().Be("'text\nwith\nnewlines'");
        }

        [Fact]
        public void TestWrapWithSingleQuotes12StringWithSpecialCharacters()
        {
            // String with special characters
            (StringUtil.WrapWithSingleQuotes("!@#$%^&*()")).Should().Be("'!@#$%^&*()'");
        }

        [Fact]
        public void TestWrapWithSingleQuotes13StringWithBackslash()
        {
            // String with backslashes
            (StringUtil.WrapWithSingleQuotes("path\\to\\file")).Should().Be("'path\\to\\file'");
        }

        [Fact]
        public void TestWrapWithSingleQuotes14StringWithForwardSlash()
        {
            // String with forward slashes
            (StringUtil.WrapWithSingleQuotes("path/to/file")).Should().Be("'path/to/file'");
        }

        [Fact]
        public void TestWrapWithSingleQuotes15UnicodeCharacters()
        {
            // String with unicode characters
            (StringUtil.WrapWithSingleQuotes("★★★")).Should().Be("'★★★'");
        }

        [Fact]
        public void TestWrapWithSingleQuotes16LongString()
        {
            // Very long string
            string longText = new string('a', 1000);
            (StringUtil.WrapWithSingleQuotes(longText)).Should().Be("'" + longText + "'");
        }

        [Fact]
        public void TestWrapWithSingleQuotes17IntegerValue()
        {
            // Integer wrapped in quotes
            (StringUtil.WrapWithSingleQuotes(42)).Should().Be("'42'");
        }

        [Fact]
        public void TestWrapWithSingleQuotes18NegativeInteger()
        {
            // Negative integer
            (StringUtil.WrapWithSingleQuotes(-42)).Should().Be("'-42'");
        }

        [Fact]
        public void TestWrapWithSingleQuotes19ZeroInteger()
        {
            // Zero integer
            (StringUtil.WrapWithSingleQuotes(0)).Should().Be("'0'");
        }

        [Fact]
        public void TestWrapWithSingleQuotes20LongValue()
        {
            // Long integer value
            (StringUtil.WrapWithSingleQuotes(1234567890123L)).Should().Be("'1234567890123'");
        }

        [Fact]
        public void TestWrapWithSingleQuotes21DoubleValue()
        {
            // Double value
            (StringUtil.WrapWithSingleQuotes(3.14)).Should().Be("'3.14'");
        }

        [Fact]
        public void TestWrapWithSingleQuotes22DecimalValue()
        {
            // Decimal value
            (StringUtil.WrapWithSingleQuotes(99.99m)).Should().Be("'99.99'");
        }

        [Fact]
        public void TestWrapWithSingleQuotes23BooleanTrue()
        {
            // Boolean true value
            (StringUtil.WrapWithSingleQuotes(true)).Should().Be("'True'");
        }

        [Fact]
        public void TestWrapWithSingleQuotes24BooleanFalse()
        {
            // Boolean false value
            (StringUtil.WrapWithSingleQuotes(false)).Should().Be("'False'");
        }

        [Fact]
        public void TestWrapWithSingleQuotes25DateTime()
        {
            // DateTime object
            DateTime dt = new DateTime(2023, 12, 25, 10, 30, 45);
            string expected = "'" + dt.ToString("MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture) + "'";
            (StringUtil.WrapWithSingleQuotes(dt)).Should().Be(expected);
        }

        [Fact]
        public void TestWrapWithSingleQuotes26TimeSpan()
        {
            // TimeSpan object
            TimeSpan ts = new TimeSpan(1, 2, 3, 4);
            string expected = "'" + ts.ToString() + "'";
            (StringUtil.WrapWithSingleQuotes(ts)).Should().Be(expected);
        }

        [Fact]
        public void TestWrapWithSingleQuotes27Guid()
        {
            // GUID object
            Guid g = new Guid("12345678-1234-1234-1234-123456789abc");
            string expected = "'" + g.ToString() + "'";
            (StringUtil.WrapWithSingleQuotes(g)).Should().Be(expected);
        }

        [Fact]
        public void TestWrapWithSingleQuotes28CharValue()
        {
            // Character value
            (StringUtil.WrapWithSingleQuotes('A')).Should().Be("'A'");
        }

        [Fact]
        public void TestWrapWithSingleQuotes29FloatValue()
        {
            // Float value
            (StringUtil.WrapWithSingleQuotes(2.5f)).Should().Be("'2.5'");
        }

        [Fact]
        public void TestWrapWithSingleQuotes30ByteValue()
        {
            // Byte value
            byte b = 255;
            (StringUtil.WrapWithSingleQuotes(b)).Should().Be("'255'");
        }

        [Fact]
        public void TestWrapWithSingleQuotes31StringBuilder()
        {
            // StringBuilder object (calls ToString on it)
            StringBuilder sb = new StringBuilder("Hello World");
            (StringUtil.WrapWithSingleQuotes(sb)).Should().Be("'Hello World'");
        }

        [Fact]
        public void TestWrapWithSingleQuotes32List()
        {
            // List object (default ToString representation)
            List<string> list = new List<string> { "a", "b", "c" };
            string expected = "'" + list.ToString() + "'";
            (StringUtil.WrapWithSingleQuotes(list)).Should().Be(expected);
        }

        [Fact]
        public void TestWrapWithSingleQuotes33Dictionary()
        {
            // Dictionary object (default ToString representation)
            Dictionary<string, int> dict = new Dictionary<string, int> { { "key", 42 } };
            string expected = "'" + dict.ToString() + "'";
            (StringUtil.WrapWithSingleQuotes(dict)).Should().Be(expected);
        }

        [Fact]
        public void TestWrapWithSingleQuotes34Array()
        {
            // Array object (default ToString representation)
            string[] arr = { "a", "b", "c" };
            string expected = "'" + arr.ToString() + "'";
            (StringUtil.WrapWithSingleQuotes(arr)).Should().Be(expected);
        }

        [Fact]
        public void TestWrapWithSingleQuotes35EqualsSign()
        {
            // String with equals sign (key=value pattern)
            (StringUtil.WrapWithSingleQuotes("key=value")).Should().Be("'key=value'");
        }

        [Fact]
        public void TestWrapWithSingleQuotes36Colon()
        {
            // String with colon (URL pattern)
            (StringUtil.WrapWithSingleQuotes("http://example.com")).Should().Be("'http://example.com'");
        }

        [Fact]
        public void TestWrapWithSingleQuotes37Comma()
        {
            // String with comma (CSV pattern)
            (StringUtil.WrapWithSingleQuotes("value1,value2,value3")).Should().Be("'value1,value2,value3'");
        }

        [Fact]
        public void TestWrapWithSingleQuotes38Semicolon()
        {
            // String with semicolon
            (StringUtil.WrapWithSingleQuotes("item1;item2;item3")).Should().Be("'item1;item2;item3'");
        }

        [Fact]
        public void TestWrapWithSingleQuotes39CarriageReturn()
        {
            // String with carriage return
            (StringUtil.WrapWithSingleQuotes("line1\rline2")).Should().Be("'line1\rline2'");
        }

        [Fact]
        public void TestWrapWithSingleQuotes40FormFeed()
        {
            // String with form feed
            (StringUtil.WrapWithSingleQuotes("page1\fpage2")).Should().Be("'page1\fpage2'");
        }

        #endregion


        #region SplitStringIntoArray(string) tests

        [Fact]
        public void TestSplitStringIntoArray()
        {
            string[] ary1 = { "a", "s", "d", "f" };
            string[] actual = StringUtil.SplitStringIntoArray("asdf");
            (actual.Length).Should().Be(ary1.Length);
            for (int i = 0; i < ary1.Length; i++)
            {
                (actual[i]).Should().Be(ary1[i]);
            }

            string[] ary2 = { "a" };
            actual = StringUtil.SplitStringIntoArray("a");
            (actual.Length).Should().Be(ary2.Length);
            for (int i = 0; i < ary2.Length; i++)
            {
                (actual[i]).Should().Be(ary2[i]);
            }

            string[] ary3 = Array.Empty<string>();
            actual = StringUtil.SplitStringIntoArray("");
            (actual.Length).Should().Be(ary3.Length);
            for (int i = 0; i < ary3.Length; i++)
            {
                (actual[i]).Should().Be(ary3[i]);
            }

        }

        [Fact]
        public void TestSplitStringIntoArray2NullInput()
        {
            // Test null input throws ArgumentNullException
            Action act = () => StringUtil.SplitStringIntoArray(null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestSplitStringIntoArray3UppercaseLetters()
        {
            // Test with uppercase letters
            string[] expected = { "A", "B", "C", "D" };
            string[] actual = StringUtil.SplitStringIntoArray("ABCD");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray4MixedCase()
        {
            // Test with mixed case letters
            string[] expected = { "A", "b", "C", "d" };
            string[] actual = StringUtil.SplitStringIntoArray("AbCd");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray5Digits()
        {
            // Test with digits
            string[] expected = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[] actual = StringUtil.SplitStringIntoArray("0123456789");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray6AlphanumericMixed()
        {
            // Test with alphanumeric mix
            string[] expected = { "a", "1", "b", "2", "c", "3" };
            string[] actual = StringUtil.SplitStringIntoArray("a1b2c3");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray7ExclamationMark()
        {
            // Test with exclamation mark
            string[] expected = { "!", "!" };
            string[] actual = StringUtil.SplitStringIntoArray("!!");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray8AtSymbol()
        {
            // Test with at symbol
            string[] expected = { "@", "@" };
            string[] actual = StringUtil.SplitStringIntoArray("@@");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray9SpecialCharacters()
        {
            // Test with various special characters
            string[] expected = { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")" };
            string[] actual = StringUtil.SplitStringIntoArray("!@#$%^&*()");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray10Backslash()
        {
            // Test with backslash
            string[] expected = { "\\", "\\", "\\" };
            string[] actual = StringUtil.SplitStringIntoArray("\\\\\\");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray11ForwardSlash()
        {
            // Test with forward slash
            string[] expected = { "/", "/", "/" };
            string[] actual = StringUtil.SplitStringIntoArray("///");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray12Punctuation()
        {
            // Test with punctuation marks
            string[] expected = { ".", ",", ";", ":", "?", "!" };
            string[] actual = StringUtil.SplitStringIntoArray(".,;:?!");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray13Quotes()
        {
            // Test with single and double quotes
            string[] expected = { "\"", "'", "\"", "'" };
            string[] actual = StringUtil.SplitStringIntoArray("\"'\"'");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray14Space()
        {
            // Test with space character
            string[] expected = { " ", " ", " " };
            string[] actual = StringUtil.SplitStringIntoArray("   ");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray15Tab()
        {
            // Test with tab character
            string[] expected = { "\t", "\t" };
            string[] actual = StringUtil.SplitStringIntoArray("\t\t");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray16Newline()
        {
            // Test with newline character
            string[] expected = { "\n", "\n" };
            string[] actual = StringUtil.SplitStringIntoArray("\n\n");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray17CarriageReturn()
        {
            // Test with carriage return character
            string[] expected = { "\r", "\r" };
            string[] actual = StringUtil.SplitStringIntoArray("\r\r");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray18FormFeed()
        {
            // Test with form feed character
            string[] expected = { "\f", "\f" };
            string[] actual = StringUtil.SplitStringIntoArray("\f\f");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray19Unicode()
        {
            // Test with unicode characters
            string[] expected = { "★", "☆", "✓" };
            string[] actual = StringUtil.SplitStringIntoArray("★☆✓");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray20RepeatingCharacters()
        {
            // Test with repeating characters
            string[] expected = { "a", "a", "a", "a", "a" };
            string[] actual = StringUtil.SplitStringIntoArray("aaaaa");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray21LongString()
        {
            // Test with a long string
            string longString = new string('x', 100);
            string[] actual = StringUtil.SplitStringIntoArray(longString);
            (actual.Length).Should().Be(100);
            for (int i = 0; i < 100; i++)
            {
                (actual[i]).Should().Be("x");
            }
        }

        [Fact]
        public void TestSplitStringIntoArray22StringWithWhitespace()
        {
            // Test with mixed text and whitespace
            string[] expected = { "h", "e", "l", "l", "o", " ", "w", "o", "r", "l", "d" };
            string[] actual = StringUtil.SplitStringIntoArray("hello world");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray23StringWithPunctuation()
        {
            // Test with text and punctuation
            string[] expected = { "h", "e", "l", "l", "o", ",", " ", "w", "o", "r", "l", "d", "!" };
            string[] actual = StringUtil.SplitStringIntoArray("hello, world!");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray24Hyphen()
        {
            // Test with hyphen
            string[] expected = { "-", "-" };
            string[] actual = StringUtil.SplitStringIntoArray("--");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray25Underscore()
        {
            // Test with underscore
            string[] expected = { "_", "_" };
            string[] actual = StringUtil.SplitStringIntoArray("__");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray26Equals()
        {
            // Test with equals sign
            string[] expected = { "=", "=" };
            string[] actual = StringUtil.SplitStringIntoArray("==");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray27Plus()
        {
            // Test with plus sign
            string[] expected = { "+", "+" };
            string[] actual = StringUtil.SplitStringIntoArray("++");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray28Minus()
        {
            // Test with minus sign
            string[] expected = { "-", "-" };
            string[] actual = StringUtil.SplitStringIntoArray("--");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray29Multiplication()
        {
            // Test with asterisk (multiplication)
            string[] expected = { "*", "*" };
            string[] actual = StringUtil.SplitStringIntoArray("**");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray30Division()
        {
            // Test with slash (division)
            string[] expected = { "/", "/" };
            string[] actual = StringUtil.SplitStringIntoArray("//");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray31Brackets()
        {
            // Test with brackets
            string[] expected = { "[", "]", "{", "}" };
            string[] actual = StringUtil.SplitStringIntoArray("[]{}");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray32Pipe()
        {
            // Test with pipe character
            string[] expected = { "|", "|" };
            string[] actual = StringUtil.SplitStringIntoArray("||");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray33Ampersand()
        {
            // Test with ampersand
            string[] expected = { "&", "&" };
            string[] actual = StringUtil.SplitStringIntoArray("&&");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray34Tilde()
        {
            // Test with tilde
            string[] expected = { "~", "~" };
            string[] actual = StringUtil.SplitStringIntoArray("~~");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray35Caret()
        {
            // Test with caret
            string[] expected = { "^", "^" };
            string[] actual = StringUtil.SplitStringIntoArray("^^");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray36Question()
        {
            // Test with question mark
            string[] expected = { "?", "?" };
            string[] actual = StringUtil.SplitStringIntoArray("??");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray37Colon()
        {
            // Test with colon
            string[] expected = { ":", ":" };
            string[] actual = StringUtil.SplitStringIntoArray("::");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray38Semicolon()
        {
            // Test with semicolon
            string[] expected = { ";", ";" };
            string[] actual = StringUtil.SplitStringIntoArray(";;");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray39Comma()
        {
            // Test with comma
            string[] expected = { ",", "," };
            string[] actual = StringUtil.SplitStringIntoArray(",,");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestSplitStringIntoArray40Period()
        {
            // Test with period
            string[] expected = { ".", "." };
            string[] actual = StringUtil.SplitStringIntoArray("..");
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        #endregion


        #region IsValidString(string, string) tests

        [Fact]
        public void TestIsValidString()
        {
            (StringUtil.IsValidCharacter("A", "abcdef_12345")).Should().Be(false);
            (StringUtil.IsValidCharacter("a", "abcdef_12345")).Should().Be(true);
            (StringUtil.IsValidCharacter(" ", "abcdef_12345")).Should().Be(false);
            (StringUtil.IsValidCharacter(" ", "abcdef_ 12345")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidString2NullTest()
        {
            // Test null test string throws ArgumentNullException
            Action act = () => StringUtil.IsValidString(null, "abcdef_12345");
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestIsValidString3NullValidChars()
        {
            // Test null validChars throws ArgumentNullException
            Action act = () => StringUtil.IsValidString("test", null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestIsValidString4EmptyTestString()
        {
            // Empty test string should return true (vacuously true)
            (StringUtil.IsValidString("", "abc")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidString5EmptyValidChars()
        {
            // Empty validChars with non-empty test should return false
            (StringUtil.IsValidString("a", "")).Should().Be(false);
        }

        [Fact]
        public void TestIsValidString6BothEmpty()
        {
            // Both empty strings should return true
            (StringUtil.IsValidString("", "")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidString7SingleLetterValid()
        {
            // Single lowercase letter that is valid
            (StringUtil.IsValidString("a", "abcdefghijklmnopqrstuvwxyz")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidString8SingleLetterInvalid()
        {
            // Single lowercase letter that is invalid (uppercase not in valid list)
            (StringUtil.IsValidString("A", "abcdefghijklmnopqrstuvwxyz")).Should().Be(false);
        }

        [Fact]
        public void TestIsValidString9SingleDigitValid()
        {
            // Single digit that is valid
            (StringUtil.IsValidString("5", "0123456789")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidString10SingleDigitInvalid()
        {
            // Single digit that is invalid (2 is not in the list)
            (StringUtil.IsValidString("2", "013579")).Should().Be(false);
        }

        [Fact]
        public void TestIsValidString11SingleSymbolValid()
        {
            // Single symbol that is valid
            (StringUtil.IsValidString("!", "!@#$%")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidString12SingleSymbolInvalid()
        {
            // Single symbol that is invalid
            (StringUtil.IsValidString("!", "abcdef")).Should().Be(false);
        }

        [Fact]
        public void TestIsValidString13AllDigitsValid()
        {
            // All digits and all are valid
            (StringUtil.IsValidString("12345", "0123456789")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidString14AllDigitsInvalid()
        {
            // All digits but some are invalid
            (StringUtil.IsValidString("12345", "13579")).Should().Be(false);
        }

        [Fact]
        public void TestIsValidString15AllLettersLowercaseValid()
        {
            // All lowercase letters and all are valid
            (StringUtil.IsValidString("abc", "abcdefghijklmnopqrstuvwxyz")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidString16MixedCaseInvalid()
        {
            // Mixed case with uppercase not in valid list
            (StringUtil.IsValidString("aBc", "abcdefghijklmnopqrstuvwxyz")).Should().Be(false);
        }

        [Fact]
        public void TestIsValidString17Alphanumeric()
        {
            // Alphanumeric string that is valid
            (StringUtil.IsValidString("abc123", "abcdefghijklmnopqrstuvwxyz0123456789")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidString18AlphanumericPartialInvalid()
        {
            // Alphanumeric with one invalid character
            (StringUtil.IsValidString("abc!23", "abcdefghijklmnopqrstuvwxyz0123456789")).Should().Be(false);
        }

        [Fact]
        public void TestIsValidString19RepeatingCharacters()
        {
            // String with repeating valid characters
            (StringUtil.IsValidString("aaaa", "a")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidString20RepeatingCharactersInvalid()
        {
            // String with repeating characters where one is invalid
            (StringUtil.IsValidString("aaab", "a")).Should().Be(false);
        }

        [Fact]
        public void TestIsValidString21SpaceValid()
        {
            // String with space that is valid
            (StringUtil.IsValidString("a b", "ab ")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidString22SpaceInvalid()
        {
            // String with space that is not in valid list
            (StringUtil.IsValidString("a b", "ab")).Should().Be(false);
        }

        [Fact]
        public void TestIsValidString23TabValid()
        {
            // String with tab character that is valid
            (StringUtil.IsValidString("a\tb", "ab\t")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidString24TabInvalid()
        {
            // String with tab character not in valid list
            (StringUtil.IsValidString("a\tb", "ab")).Should().Be(false);
        }

        [Fact]
        public void TestIsValidString25NewlineValid()
        {
            // String with newline that is valid
            (StringUtil.IsValidString("a\nb", "ab\n")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidString26NewlineInvalid()
        {
            // String with newline not in valid list
            (StringUtil.IsValidString("a\nb", "ab")).Should().Be(false);
        }

        [Fact]
        public void TestIsValidString27SpecialCharactersValid()
        {
            // String with special characters all valid
            (StringUtil.IsValidString("!@#$%", "!@#$%^&*()")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidString28SpecialCharactersInvalid()
        {
            // String with special characters, some invalid
            (StringUtil.IsValidString("!@#$%", "!@#")).Should().Be(false);
        }

        [Fact]
        public void TestIsValidString29UnicodeValid()
        {
            // String with unicode characters all valid
            (StringUtil.IsValidString("★☆✓", "★☆✓")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidString30UnicodeInvalid()
        {
            // String with unicode character not in valid list
            (StringUtil.IsValidString("★☆✓", "★☆")).Should().Be(false);
        }

        [Fact]
        public void TestIsValidString31LongStringValid()
        {
            // Long string with all valid characters
            string test = new string('a', 100);
            (StringUtil.IsValidString(test, "a")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidString32LongStringInvalid()
        {
            // Long string with one invalid character at the end
            string test = new string('a', 99) + "b";
            (StringUtil.IsValidString(test, "a")).Should().Be(false);
        }

        [Fact]
        public void TestIsValidString33NumericStringValid()
        {
            // All digits string that is valid
            (StringUtil.IsValidString("123456789", "0123456789")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidString34NumericStringInvalid()
        {
            // Numeric string with invalid character
            (StringUtil.IsValidString("12345a789", "0123456789")).Should().Be(false);
        }

        [Fact]
        public void TestIsValidString35OnlySymbols()
        {
            // String with only symbols all valid
            (StringUtil.IsValidString("!@#$%", "!@#$%^&*()_+-=[]{}|;':\",./<>?")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidString36OnlySymbolsPartialInvalid()
        {
            // String with only symbols, some invalid
            (StringUtil.IsValidString("!@#$%", "!@#$")).Should().Be(false);
        }

        [Fact]
        public void TestIsValidString37UppercaseLettersValid()
        {
            // All uppercase letters valid
            (StringUtil.IsValidString("ABC", "ABCDEFGHIJKLMNOPQRSTUVWXYZ")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidString38UppercaseLettersInvalid()
        {
            // Uppercase letters but not in valid list
            (StringUtil.IsValidString("ABC", "abcdefghijklmnopqrstuvwxyz")).Should().Be(false);
        }

        [Fact]
        public void TestIsValidString39CaseSensitiveValidation()
        {
            // Verify case sensitivity - 'a' is not same as 'A'
            (StringUtil.IsValidString("a", "aA")).Should().Be(true);
            (StringUtil.IsValidString("a", "A")).Should().Be(false);
        }

        [Fact]
        public void TestIsValidString40ValidCharsWithRepeats()
        {
            // Valid chars string can have repeated characters (should still work)
            (StringUtil.IsValidString("abc", "aabbccdd")).Should().Be(true);
        }

        #endregion


        #region IsValid(string, string) tests

        [Fact]
        public void TestIsValid()
        {
            (StringUtil.IsValid("asdf", @"[a-zA-Z_0-9]")).Should().Be(true);
            (StringUtil.IsValid("asdf", @"[0-9]")).Should().Be(false);
        }

        [Fact]
        public void TestIsValidNullTest()
        {
            string? test = null;
            string pattern = @"[a-zA-Z_0-9]";
            Action act = () => StringUtil.IsValid(test, pattern);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestIsValidNullPattern()
        {
            string test = "asdf";
            string? pattern = null;
            Action act = () => StringUtil.IsValid(test, pattern);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestIsValid4EmptyTestString()
        {
            // Empty test string matches empty pattern
            (StringUtil.IsValid("", "")).Should().Be(true);
        }

        [Fact]
        public void TestIsValid5EmptyPatternNonEmptyTest()
        {
            // Empty pattern matches any string (zero or more of anything)
            (StringUtil.IsValid("abc", "")).Should().Be(true);
        }

        [Fact]
        public void TestIsValid6OnlyDigits()
        {
            // Test digit-only pattern
            (StringUtil.IsValid("12345", @"^[0-9]+$")).Should().Be(true);
            (StringUtil.IsValid("1234a", @"^[0-9]+$")).Should().Be(false);
        }

        [Fact]
        public void TestIsValid7OnlyLetters()
        {
            // Test letter-only pattern
            (StringUtil.IsValid("abcde", @"^[a-zA-Z]+$")).Should().Be(true);
            (StringUtil.IsValid("abcd1", @"^[a-zA-Z]+$")).Should().Be(false);
        }

        [Fact]
        public void TestIsValid8OnlyUppercase()
        {
            // Test uppercase-only pattern
            (StringUtil.IsValid("ABCDE", @"^[A-Z]+$")).Should().Be(true);
            (StringUtil.IsValid("ABCDe", @"^[A-Z]+$")).Should().Be(false);
        }

        [Fact]
        public void TestIsValid9OnlyLowercase()
        {
            // Test lowercase-only pattern
            (StringUtil.IsValid("abcde", @"^[a-z]+$")).Should().Be(true);
            (StringUtil.IsValid("abcDE", @"^[a-z]+$")).Should().Be(false);
        }

        [Fact]
        public void TestIsValid10Whitespace()
        {
            // Test whitespace pattern
            (StringUtil.IsValid("a b", @".*\s.*")).Should().Be(true);
            (StringUtil.IsValid("abc", @".*\s.*")).Should().Be(false);
        }

        [Fact]
        public void TestIsValid11WordCharacters()
        {
            // Test word character pattern (letters, digits, underscore)
            (StringUtil.IsValid("abc_123", @"^\w+$")).Should().Be(true);
            (StringUtil.IsValid("abc-123", @"^\w+$")).Should().Be(false);
        }

        [Fact]
        public void TestIsValid12AnchorStart()
        {
            // Test anchor ^ (start of string)
            (StringUtil.IsValid("abc", @"^abc")).Should().Be(true);
            (StringUtil.IsValid("xabc", @"^abc")).Should().Be(false);
        }

        [Fact]
        public void TestIsValid13AnchorEnd()
        {
            // Test anchor $ (end of string)
            (StringUtil.IsValid("abc", @"abc$")).Should().Be(true);
            (StringUtil.IsValid("abcx", @"abc$")).Should().Be(false);
        }

        [Fact]
        public void TestIsValid14AnchorBoth()
        {
            // Test both anchors (exact match)
            (StringUtil.IsValid("abc", @"^abc$")).Should().Be(true);
            (StringUtil.IsValid("xabcx", @"^abc$")).Should().Be(false);
        }

        [Fact]
        public void TestIsValid15QuantifierZeroOrMore()
        {
            // Test * quantifier (zero or more)
            (StringUtil.IsValid("", @"^[a-z]*$")).Should().Be(true);
            (StringUtil.IsValid("abc", @"^[a-z]*$")).Should().Be(true);
            (StringUtil.IsValid("abc1", @"^[a-z]*$")).Should().Be(false);
        }

        [Fact]
        public void TestIsValid16QuantifierOneOrMore()
        {
            // Test + quantifier (one or more)
            (StringUtil.IsValid("", @"^[a-z]+$")).Should().Be(false);
            (StringUtil.IsValid("abc", @"^[a-z]+$")).Should().Be(true);
            (StringUtil.IsValid("abc1", @"^[a-z]+$")).Should().Be(false);
        }

        [Fact]
        public void TestIsValid17QuantifierOptional()
        {
            // Test ? quantifier (zero or one)
            (StringUtil.IsValid("ac", @"^ab?c$")).Should().Be(true);
            (StringUtil.IsValid("abc", @"^ab?c$")).Should().Be(true);
            (StringUtil.IsValid("abbc", @"^ab?c$")).Should().Be(false);
        }

        [Fact]
        public void TestIsValid18QuantifierExact()
        {
            // Test {n} quantifier (exactly n)
            (StringUtil.IsValid("aaa", @"^a{3}$")).Should().Be(true);
            (StringUtil.IsValid("aa", @"^a{3}$")).Should().Be(false);
            (StringUtil.IsValid("aaaa", @"^a{3}$")).Should().Be(false);
        }

        [Fact]
        public void TestIsValid19QuantifierRange()
        {
            // Test {n,m} quantifier (between n and m)
            (StringUtil.IsValid("aa", @"^a{2,4}$")).Should().Be(true);
            (StringUtil.IsValid("aaa", @"^a{2,4}$")).Should().Be(true);
            (StringUtil.IsValid("a", @"^a{2,4}$")).Should().Be(false);
            (StringUtil.IsValid("aaaaa", @"^a{2,4}$")).Should().Be(false);
        }

        [Fact]
        public void TestIsValid20Alternation()
        {
            // Test alternation |
            (StringUtil.IsValid("abc", @"^(abc|def)$")).Should().Be(true);
            (StringUtil.IsValid("def", @"^(abc|def)$")).Should().Be(true);
            (StringUtil.IsValid("xyz", @"^(abc|def)$")).Should().Be(false);
        }

        [Fact]
        public void TestIsValid21Group()
        {
            // Test grouping ()
            (StringUtil.IsValid("abab", @"^(ab)+$")).Should().Be(true);
            (StringUtil.IsValid("aba", @"^(ab)+$")).Should().Be(false);
        }

        [Fact]
        public void TestIsValid22NegatedCharacterClass()
        {
            // Test negated character class [^...]
            (StringUtil.IsValid("abc", @"^[^0-9]+$")).Should().Be(true);
            (StringUtil.IsValid("abc1", @"^[^0-9]+$")).Should().Be(false);
        }

        [Fact]
        public void TestIsValid23EmailPattern()
        {
            // Basic email pattern
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            (StringUtil.IsValid("test@example.com", emailPattern)).Should().Be(true);
            (StringUtil.IsValid("user.name+tag@example.co.uk", emailPattern)).Should().Be(true);
            (StringUtil.IsValid("invalid.email@", emailPattern)).Should().Be(false);
        }

        [Fact]
        public void TestIsValid24URLPattern()
        {
            // Basic URL pattern
            string urlPattern = @"^https?://[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}";
            (StringUtil.IsValid("http://example.com", urlPattern)).Should().Be(true);
            (StringUtil.IsValid("https://example.com/path", urlPattern)).Should().Be(true);
            (StringUtil.IsValid("ftp://example.com", urlPattern)).Should().Be(false);
        }

        [Fact]
        public void TestIsValid25PhonePattern()
        {
            // Phone number pattern (simple: digits and hyphens)
            string phonePattern = @"^[\d\-\(\)]+$";
            (StringUtil.IsValid("123-456-7890", phonePattern)).Should().Be(true);
            (StringUtil.IsValid("(123)456-7890", phonePattern)).Should().Be(true);
            (StringUtil.IsValid("123-456-789a", phonePattern)).Should().Be(false);
        }

        [Fact]
        public void TestIsValid26USZipCode()
        {
            // US Zip code pattern
            string zipPattern = @"^\d{5}(-\d{4})?$";
            (StringUtil.IsValid("12345", zipPattern)).Should().Be(true);
            (StringUtil.IsValid("12345-6789", zipPattern)).Should().Be(true);
            (StringUtil.IsValid("1234", zipPattern)).Should().Be(false);
        }

        [Fact]
        public void TestIsValid27DatePattern()
        {
            // Date pattern (YYYY-MM-DD)
            string datePattern = @"^\d{4}-\d{2}-\d{2}$";
            (StringUtil.IsValid("2023-12-25", datePattern)).Should().Be(true);
            (StringUtil.IsValid("25-12-2023", datePattern)).Should().Be(false);
        }

        [Fact]
        public void TestIsValid28TimePattern()
        {
            // Time pattern (HH:MM:SS)
            string timePattern = @"^\d{2}:\d{2}:\d{2}$";
            (StringUtil.IsValid("14:30:00", timePattern)).Should().Be(true);
            (StringUtil.IsValid("14:30", timePattern)).Should().Be(false);
        }

        [Fact]
        public void TestIsValid29HexadecimalPattern()
        {
            // Hexadecimal pattern
            string hexPattern = @"^[0-9A-Fa-f]+$";
            (StringUtil.IsValid("ABCDEF123", hexPattern)).Should().Be(true);
            (StringUtil.IsValid("GHIJKL", hexPattern)).Should().Be(false);
        }

        [Fact]
        public void TestIsValid30IPAddressPattern()
        {
            // Simple IP address pattern
            string ipPattern = @"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$";
            (StringUtil.IsValid("192.168.1.1", ipPattern)).Should().Be(true);
            (StringUtil.IsValid("10.0.0.1", ipPattern)).Should().Be(true);
            (StringUtil.IsValid("256.256.256.256", ipPattern)).Should().Be(true);
        }

        [Fact]
        public void TestIsValid31CreditCardPattern()
        {
            // Credit card pattern (simplified, just digits)
            string ccPattern = @"^\d{13,19}$";
            (StringUtil.IsValid("4532015112830366", ccPattern)).Should().Be(true);
            (StringUtil.IsValid("4532-0151-1283-0366", ccPattern)).Should().Be(false);
        }

        [Fact]
        public void TestIsValid32SpecialCharactersLiteral()
        {
            // Matching literal special characters
            (StringUtil.IsValid("a.b", @"^a\.b$")).Should().Be(true);
            (StringUtil.IsValid("aXb", @"^a\.b$")).Should().Be(false);
        }

        [Fact]
        public void TestIsValid33DotAnyCharacter()
        {
            // . matches any character
            (StringUtil.IsValid("abc", @"^a.c$")).Should().Be(true);
            (StringUtil.IsValid("aXc", @"^a.c$")).Should().Be(true);
            (StringUtil.IsValid("ac", @"^a.c$")).Should().Be(false);
        }

        [Fact]
        public void TestIsValid34CaseSensitivity()
        {
            // Regex is case-sensitive by default
            (StringUtil.IsValid("ABC", @"^ABC$")).Should().Be(true);
            (StringUtil.IsValid("abc", @"^ABC$")).Should().Be(false);
        }

        [Fact]
        public void TestIsValid35PartialMatch()
        {
            // Without anchors, matches anywhere in string
            (StringUtil.IsValid("xabcy", @"abc")).Should().Be(true);
            (StringUtil.IsValid("xabcy", @"^abc$")).Should().Be(false);
        }

        [Fact]
        public void TestIsValid36MultilineText()
        {
            // Pattern matching with multiple lines - . doesn't match newlines by default
            (StringUtil.IsValid("abc\ndef", @"abc.*def")).Should().Be(false);
            (StringUtil.IsValid("abc\ndef", @"^abc.*def$")).Should().Be(false);
        }

        [Fact]
        public void TestIsValid37EscapedBackslash()
        {
            // Escaped backslash
            (StringUtil.IsValid(@"a\b", @"^a\\b$")).Should().Be(true);
            (StringUtil.IsValid("a/b", @"^a\\b$")).Should().Be(false);
        }

        [Fact]
        public void TestIsValid38CharacterRanges()
        {
            // Character ranges
            (StringUtil.IsValid("m", @"^[a-z]$")).Should().Be(true);
            (StringUtil.IsValid("5", @"^[0-9]$")).Should().Be(true);
            (StringUtil.IsValid("M", @"^[a-z]$")).Should().Be(false);
        }

        [Fact]
        public void TestIsValid39MultipleCharacterRanges()
        {
            // Multiple character ranges in one class
            (StringUtil.IsValid("a", @"^[a-zA-Z0-9_]$")).Should().Be(true);
            (StringUtil.IsValid("Z", @"^[a-zA-Z0-9_]$")).Should().Be(true);
            (StringUtil.IsValid("5", @"^[a-zA-Z0-9_]$")).Should().Be(true);
            (StringUtil.IsValid("-", @"^[a-zA-Z0-9_]$")).Should().Be(false);
        }

        [Fact]
        public void TestIsValid40Asterisk()
        {
            // * matches zero or more occurrences
            (StringUtil.IsValid("", @"^a*$")).Should().Be(true);
            (StringUtil.IsValid("aaa", @"^a*$")).Should().Be(true);
            (StringUtil.IsValid("aab", @"^a*$")).Should().Be(false);
        }

        #endregion


        #region IsValidCharacter(string, string) tests

        [Fact]
        public void TestIsValidCharacter()
        {
            (StringUtil.IsValidCharacter("A", "abcdef_12345")).Should().Be(false);
            (StringUtil.IsValidCharacter("a", "abcdef_12345")).Should().Be(true);
            (StringUtil.IsValidCharacter(" ", "abcdef_12345")).Should().Be(false);
            (StringUtil.IsValidCharacter(" ", "abcdef_ 12345")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter2EmptyTestString()
        {
            // Empty test string should return false
            (StringUtil.IsValidCharacter("", "abc")).Should().Be(false);
        }

        [Fact]
        public void TestIsValidCharacter3MultiCharTestString()
        {
            // Multi-character test string should return false
            (StringUtil.IsValidCharacter("ab", "abcdef")).Should().Be(false);
        }

        [Fact]
        public void TestIsValidCharacter4MultiCharTestString2()
        {
            // Multi-character test string should return false even if chars are in validChars
            (StringUtil.IsValidCharacter("abc", "abcdef")).Should().Be(false);
        }

        [Fact]
        public void TestIsValidCharacter5NullTestString()
        {
            Action act = () => StringUtil.IsValidCharacter(null, "abc");
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestIsValidCharacter6NullValidChars()
        {
            Action act = () => StringUtil.IsValidCharacter("a", null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestIsValidCharacter7BothNull()
        {
            Action act = () => StringUtil.IsValidCharacter(null, null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestIsValidCharacter8Digit0()
        {
            (StringUtil.IsValidCharacter("0", "0123456789")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter9Digit5()
        {
            (StringUtil.IsValidCharacter("5", "0123456789")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter10Digit9()
        {
            (StringUtil.IsValidCharacter("9", "0123456789")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter11DigitNotInSet()
        {
            (StringUtil.IsValidCharacter("5", "abcdef")).Should().Be(false);
        }

        [Fact]
        public void TestIsValidCharacter12ExclamationMark()
        {
            (StringUtil.IsValidCharacter("!", "!@#$%")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter13DollarSign()
        {
            (StringUtil.IsValidCharacter("$", "!@#$%")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter14SpecialCharNotInSet()
        {
            (StringUtil.IsValidCharacter("&", "!@#$%")).Should().Be(false);
        }

        [Fact]
        public void TestIsValidCharacter15OpenParen()
        {
            (StringUtil.IsValidCharacter("(", "()[]{}")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter16CloseBracket()
        {
            (StringUtil.IsValidCharacter("]", "()[]{}")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter17OpenBrace()
        {
            (StringUtil.IsValidCharacter("{", "()[]{}")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter18Tab()
        {
            (StringUtil.IsValidCharacter("\t", "a\tb\tc")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter19TabNotInSet()
        {
            (StringUtil.IsValidCharacter("\t", "abc")).Should().Be(false);
        }

        [Fact]
        public void TestIsValidCharacter20Newline()
        {
            (StringUtil.IsValidCharacter("\n", "a\nb\nc")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter21NewlineNotInSet()
        {
            (StringUtil.IsValidCharacter("\n", "abc")).Should().Be(false);
        }

        [Fact]
        public void TestIsValidCharacter22CarriageReturn()
        {
            (StringUtil.IsValidCharacter("\r", "a\rb\rc")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter23CaseSensitiveUppercase()
        {
            // Uppercase A not in lowercase-only set
            (StringUtil.IsValidCharacter("A", "abcdef")).Should().Be(false);
        }

        [Fact]
        public void TestIsValidCharacter24CaseSensitiveLowercase()
        {
            // Lowercase a not in uppercase-only set
            (StringUtil.IsValidCharacter("a", "ABCDEF")).Should().Be(false);
        }

        [Fact]
        public void TestIsValidCharacter25CaseSensitiveMixed()
        {
            // Lowercase a in mixed case set
            (StringUtil.IsValidCharacter("a", "AaBbCc")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter26CharAtStart()
        {
            // Character at start of validChars
            (StringUtil.IsValidCharacter("a", "abcdef")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter27CharAtMiddle()
        {
            // Character in middle of validChars
            (StringUtil.IsValidCharacter("c", "abcdef")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter28CharAtEnd()
        {
            // Character at end of validChars
            (StringUtil.IsValidCharacter("f", "abcdef")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter29SingleCharValidChars()
        {
            // Single character in validChars
            (StringUtil.IsValidCharacter("x", "x")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter30SingleCharValidCharsNotMatching()
        {
            // Single character in validChars but doesn't match
            (StringUtil.IsValidCharacter("y", "x")).Should().Be(false);
        }

        [Fact]
        public void TestIsValidCharacter31LongValidCharsSet()
        {
            // Long set of valid characters
            string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+-=[]{}|;':\",./<>?";
            (StringUtil.IsValidCharacter("z", validChars)).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter32LongValidCharsSetChar()
        {
            // Long set of valid characters
            string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+-=[]{}|;':\",./<>?";
            (StringUtil.IsValidCharacter("@", validChars)).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter33LongValidCharsSetNotFound()
        {
            // Long set of valid characters, but character not found
            string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+-=[]{}|;':\",./<>?";
            (StringUtil.IsValidCharacter("~", validChars)).Should().Be(false);
        }

        [Fact]
        public void TestIsValidCharacter34SpaceAtStart()
        {
            // Space at start of validChars
            (StringUtil.IsValidCharacter(" ", " abc")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter35SpaceAtEnd()
        {
            // Space at end of validChars
            (StringUtil.IsValidCharacter(" ", "abc ")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter36SpaceInMiddle()
        {
            // Space in middle of validChars
            (StringUtil.IsValidCharacter(" ", "ab c")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter37Plus()
        {
            (StringUtil.IsValidCharacter("+", "+-*/")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter38Minus()
        {
            (StringUtil.IsValidCharacter("-", "+-*/")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter39Asterisk()
        {
            (StringUtil.IsValidCharacter("*", "+-*/")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter40Slash()
        {
            (StringUtil.IsValidCharacter("/", "+-*/")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter41Dot()
        {
            (StringUtil.IsValidCharacter(".", "0123456789.")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter42Underscore()
        {
            (StringUtil.IsValidCharacter("_", "abcdef_12345")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter43Hyphen()
        {
            (StringUtil.IsValidCharacter("-", "a-b-c")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter44Comma()
        {
            (StringUtil.IsValidCharacter(",", "a,b,c")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter45Semicolon()
        {
            (StringUtil.IsValidCharacter(";", "a;b;c")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter46Colon()
        {
            (StringUtil.IsValidCharacter(":", "a:b:c")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter47DoubleQuote()
        {
            (StringUtil.IsValidCharacter("\"", "\"'`")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter48SingleQuote()
        {
            (StringUtil.IsValidCharacter("'", "\"'`")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter49Backtick()
        {
            (StringUtil.IsValidCharacter("`", "\"'`")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter50LessThan()
        {
            (StringUtil.IsValidCharacter("<", "<>")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter51GreaterThan()
        {
            (StringUtil.IsValidCharacter(">", "<>")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter52Equals()
        {
            (StringUtil.IsValidCharacter("=", "=!<>")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter53At()
        {
            (StringUtil.IsValidCharacter("@", "@#$%^")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter54Hash()
        {
            (StringUtil.IsValidCharacter("#", "@#$%^")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter55Percent()
        {
            (StringUtil.IsValidCharacter("%", "@#$%^")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter56Caret()
        {
            (StringUtil.IsValidCharacter("^", "@#$%^")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter57Ampersand()
        {
            (StringUtil.IsValidCharacter("&", "&*()")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter58Pipe()
        {
            (StringUtil.IsValidCharacter("|", "||")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter59Backslash()
        {
            (StringUtil.IsValidCharacter("\\", "\\|/")).Should().Be(true);
        }

        [Fact]
        public void TestIsValidCharacter60Question()
        {
            (StringUtil.IsValidCharacter("?", "?!.")).Should().Be(true);
        }

        #endregion


        #region CountTokens(string, string) tests

        [Fact]
        public void TestCountTokens1()
        {
            (StringUtil.CountTokens("", "|")).Should().Be(1);
        }

        [Fact]
        public void TestCountTokens2()
        {
            (StringUtil.CountTokens("a|", "|")).Should().Be(2);
        }

        [Fact]
        public void TestCountTokens3()
        {
            (StringUtil.CountTokens("a|b", "|")).Should().Be(2);
        }

        [Fact]
        public void TestCountTokens4()
        {
            (StringUtil.CountTokens("a|b|c", "|")).Should().Be(3);
        }

        [Fact]
        public void TestCountTokens5()
        {
            (StringUtil.CountTokens("a|b|c|", "|")).Should().Be(4);
        }

        [Fact]
        public void TestCountTokens6()
        {
            (StringUtil.CountTokens("|", "|")).Should().Be(2);
        }

        [Fact]
        public void TestCountTokens7()
        {
            (StringUtil.CountTokens("|a", "|")).Should().Be(2);
        }

        [Fact]
        public void TestCountTokens8()
        {
            (StringUtil.CountTokens("a", "|")).Should().Be(1);
        }

        [Fact]
        public void TestCountTokens9NullSource()
        {
            Action act = () => StringUtil.CountTokens(null, "|");
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestCountTokens10NullDelimiter()
        {
            Action act = () => StringUtil.CountTokens("a|b|c", null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestCountTokens11BothNull()
        {
            Action act = () => StringUtil.CountTokens(null, null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestCountTokens12MultiCharDelimiter()
        {
            (StringUtil.CountTokens("a||b", "||")).Should().Be(2);
        }

        [Fact]
        public void TestCountTokens13MultiCharDelimiter2()
        {
            (StringUtil.CountTokens("a||b||c", "||")).Should().Be(3);
        }

        [Fact]
        public void TestCountTokens14MultiCharDelimiterArrow()
        {
            (StringUtil.CountTokens("a->b", "->")).Should().Be(2);
        }

        [Fact]
        public void TestCountTokens15MultiCharDelimiterArrow2()
        {
            (StringUtil.CountTokens("a->b->c", "->")).Should().Be(3);
        }

        [Fact]
        public void TestCountTokens16ConsecutiveDelimiters3Times()
        {
            (StringUtil.CountTokens("a|||b", "|")).Should().Be(4);
        }

        [Fact]
        public void TestCountTokens17ConsecutiveDelimiters4Times()
        {
            (StringUtil.CountTokens("a||||b", "|")).Should().Be(5);
        }

        [Fact]
        public void TestCountTokens18OnlyConsecutiveDelimiters()
        {
            (StringUtil.CountTokens("|||", "|")).Should().Be(4);
        }

        [Fact]
        public void TestCountTokens19CommaDelimiter()
        {
            (StringUtil.CountTokens("a,b,c", ",")).Should().Be(3);
        }

        [Fact]
        public void TestCountTokens20SemicolonDelimiter()
        {
            (StringUtil.CountTokens("a;b;c", ";")).Should().Be(3);
        }

        [Fact]
        public void TestCountTokens21ColonDelimiter()
        {
            (StringUtil.CountTokens("a:b:c", ":")).Should().Be(3);
        }

        [Fact]
        public void TestCountTokens22SpaceDelimiter()
        {
            (StringUtil.CountTokens("a b c", " ")).Should().Be(3);
        }

        [Fact]
        public void TestCountTokens23TabDelimiter()
        {
            (StringUtil.CountTokens("a\tb\tc", "\t")).Should().Be(3);
        }

        [Fact]
        public void TestCountTokens24NewlineDelimiter()
        {
            (StringUtil.CountTokens("a\nb\nc", "\n")).Should().Be(3);
        }

        [Fact]
        public void TestCountTokens25SlashDelimiter()
        {
            (StringUtil.CountTokens("a/b/c", "/")).Should().Be(3);
        }

        [Fact]
        public void TestCountTokens26BackslashDelimiter()
        {
            (StringUtil.CountTokens("a\\b\\c", "\\")).Should().Be(3);
        }

        [Fact]
        public void TestCountTokens27DotDelimiter()
        {
            (StringUtil.CountTokens("192.168.0.1", ".")).Should().Be(4);
        }

        [Fact]
        public void TestCountTokens28HyphenDelimiter()
        {
            (StringUtil.CountTokens("a-b-c", "-")).Should().Be(3);
        }

        [Fact]
        public void TestCountTokens29UnderscoreDelimiter()
        {
            (StringUtil.CountTokens("a_b_c", "_")).Should().Be(3);
        }

        [Fact]
        public void TestCountTokens30PlusDelimiter()
        {
            (StringUtil.CountTokens("a+b+c", "+")).Should().Be(3);
        }

        [Fact]
        public void TestCountTokens31AsteriskDelimiter()
        {
            (StringUtil.CountTokens("a*b*c", "*")).Should().Be(3);
        }

        [Fact]
        public void TestCountTokens32AtDelimiter()
        {
            (StringUtil.CountTokens("a@b@c", "@")).Should().Be(3);
        }

        [Fact]
        public void TestCountTokens33HashDelimiter()
        {
            (StringUtil.CountTokens("a#b#c", "#")).Should().Be(3);
        }

        [Fact]
        public void TestCountTokens34DollarDelimiter()
        {
            (StringUtil.CountTokens("a$b$c", "$")).Should().Be(3);
        }

        [Fact]
        public void TestCountTokens35AmpersandDelimiter()
        {
            (StringUtil.CountTokens("a&b&c", "&")).Should().Be(3);
        }

        [Fact]
        public void TestCountTokens36PipeDelimiter()
        {
            (StringUtil.CountTokens("a|b|c", "|")).Should().Be(3);
        }

        [Fact]
        public void TestCountTokens37SourceEqualsDelimiter()
        {
            (StringUtil.CountTokens("|", "|")).Should().Be(2);
        }

        [Fact]
        public void TestCountTokens38DelimiterLongerThanSource()
        {
            // Delimiter "||" not found in "a" = 1 token
            (StringUtil.CountTokens("a", "||")).Should().Be(1);
        }

        [Fact]
        public void TestCountTokens39SingleLetter()
        {
            (StringUtil.CountTokens("a", ",")).Should().Be(1);
        }

        [Fact]
        public void TestCountTokens40LongString()
        {
            // Test with a string containing many delimiters
            (StringUtil.CountTokens("1,2,3,4,5,6,7,8,9,10,11", ",")).Should().Be(11);
        }

        [Fact]
        public void TestCountTokens41LeadingDelimiters()
        {
            (StringUtil.CountTokens("||a|b", "|")).Should().Be(4);
        }

        [Fact]
        public void TestCountTokens42TrailingDelimiters()
        {
            (StringUtil.CountTokens("a|b||", "|")).Should().Be(4);
        }

        [Fact]
        public void TestCountTokens43MiddleDelimiters()
        {
            (StringUtil.CountTokens("a||b|c", "|")).Should().Be(4);
        }

        [Fact]
        public void TestCountTokens44MultiCharDelimiterLeading()
        {
            (StringUtil.CountTokens("::a", "::")).Should().Be(2);
        }

        [Fact]
        public void TestCountTokens45MultiCharDelimiterTrailing()
        {
            (StringUtil.CountTokens("a::", "::")).Should().Be(2);
        }

        [Fact]
        public void TestCountTokens46MultiCharDelimiterConsecutive()
        {
            // "a::::b" split by "::" should give ["a", "", "b"] = 3 tokens
            (StringUtil.CountTokens("a::::b", "::")).Should().Be(3);
        }

        [Fact]
        public void TestCountTokens47WordDelimiter()
        {
            // "-OR-" appears once, so 2 tokens
            (StringUtil.CountTokens("apple-OR-orange", "-OR-")).Should().Be(2);
        }

        [Fact]
        public void TestCountTokens48WordDelimiter2()
        {
            // "-OR-" appears twice, so 3 tokens
            (StringUtil.CountTokens("apple-OR-orange-OR-banana", "-OR-")).Should().Be(3);
        }

        [Fact]
        public void TestCountTokens49CaseSensitiveDelimiter()
        {
            // "A" (uppercase) appears twice in "aAbAc", so 3 tokens
            (StringUtil.CountTokens("aAbAc", "A")).Should().Be(3);
        }

        [Fact]
        public void TestCountTokens50CaseSensitiveDelimiter2()
        {
            (StringUtil.CountTokens("aAaAa", "A")).Should().Be(3);
        }

        [Fact]
        public void TestCountTokens51DoubleCharDelimiterNoMatch()
        {
            // ">>" not found in "a>b>c" = 1 token
            (StringUtil.CountTokens("a>b>c", ">>")).Should().Be(1);
        }

        [Fact]
        public void TestCountTokens52SpecialRegexChars()
        {
            // Test with characters that are special in regex
            (StringUtil.CountTokens("a.b.c", ".")).Should().Be(3);
        }

        [Fact]
        public void TestCountTokens53SpecialRegexChars2()
        {
            (StringUtil.CountTokens("a*b*c", "*")).Should().Be(3);
        }

        [Fact]
        public void TestCountTokens54SpecialRegexChars3()
        {
            (StringUtil.CountTokens("a+b+c", "+")).Should().Be(3);
        }

        [Fact]
        public void TestCountTokens55SpecialRegexChars4()
        {
            (StringUtil.CountTokens("a?b?c", "?")).Should().Be(3);
        }

        [Fact]
        public void TestCountTokens56SingleSpaceDelimiter()
        {
            (StringUtil.CountTokens("one two three four", " ")).Should().Be(4);
        }

        [Fact]
        public void TestCountTokens57MultipleSpaces()
        {
            // Each space is a delimiter, so multiple spaces = multiple tokens with empty strings between
            (StringUtil.CountTokens("a  b  c", " ")).Should().Be(5);
        }

        [Fact]
        public void TestCountTokens58ThreeCharDelimiter()
        {
            (StringUtil.CountTokens("a***b***c", "***")).Should().Be(3);
        }

        [Fact]
        public void TestCountTokens59VeryLongDelimiter()
        {
            (StringUtil.CountTokens("a---b", "---")).Should().Be(2);
        }

        [Fact]
        public void TestCountTokens60DelimiterWithNumbers()
        {
            // "|2" appears once in "item1|2item2|3item3", so 2 tokens
            (StringUtil.CountTokens("item1|2item2|3item3", "|2")).Should().Be(2);
        }

        #endregion


        #region GetToken(string, string, int) tests

        [Fact]
        public void TestGetToken1()
        {
            (StringUtil.GetToken("a|s|d|f", "|", 1)).Should().Be("a");
        }

        [Fact]
        public void TestGetToken2()
        {
            (StringUtil.GetToken("a|s|d|f", "|", 2)).Should().Be("s");
        }

        [Fact]
        public void TestGetToken3()
        {
            (StringUtil.GetToken("a|s|d|f", "|", 3)).Should().Be("d");
        }

        [Fact]
        public void TestGetToken4()
        {
            (StringUtil.GetToken("a|s|d|f", "|", 4)).Should().Be("f");
        }

        [Fact]
        public void TestGetToken5()
        {
            (StringUtil.GetToken("a|s|d|f|", "|", 5)).Should().Be("");
        }

        [Fact]
        public void TestGetToken6()
        {
            (StringUtil.GetToken("|a|s|d|f|", "|", 1)).Should().Be("");
        }

        [Fact]
        public void TestGetToken7()
        {
            (StringUtil.GetToken("|a|s|d|f", "|", 2)).Should().Be("a");
        }

        [Fact]
        public void TestGetToken8()
        {
            (StringUtil.GetToken("|a|s|d|f", "|", 3)).Should().Be("s");
        }

        [Fact]
        public void TestGetToken9()
        {
            (StringUtil.GetToken("|a|s|d|f", "|", 4)).Should().Be("d");
        }

        [Fact]
        public void TestGetToken10()
        {
            (StringUtil.GetToken("|a|s|d|f", "|", 5)).Should().Be("f");
        }

        [Fact]
        public void TestGetToken11()
        {
            (StringUtil.GetToken("|a|s|d|f|", "|", 6)).Should().Be("");
        }

        [Fact]
        public void TestGetToken12()
        {
            (StringUtil.GetToken("asdf|qwer|zxcv|1234", "|", 1)).Should().Be("asdf");
        }

        [Fact]
        public void TestGetToken13()
        {
            (StringUtil.GetToken("asdf|qwer|zxcv|1234", "|", 2)).Should().Be("qwer");
        }

        [Fact]
        public void TestGetToken14()
        {
            (StringUtil.GetToken("asdf|qwer|zxcv|1234", "|", 3)).Should().Be("zxcv");
        }

        [Fact]
        public void TestGetToken15()
        {
            (StringUtil.GetToken("asdf|qwer|zxcv|1234", "|", 4)).Should().Be("1234");
        }

        [Fact]
        public void TestGetToken16()
        {
            (StringUtil.GetToken("asdf|qwer|zxcv|1234|", "|", 5)).Should().Be("");
        }

        [Fact]
        public void TestGetToken17()
        {
            (StringUtil.GetToken("|asdf|qwer|zxcv|1234", "|", 1)).Should().Be("");
        }

        [Fact]
        public void TestGetToken18()
        {
            (StringUtil.GetToken("|asdf|qwer|zxcv|1234", "|", 2)).Should().Be("asdf");
        }

        [Fact]
        public void TestGetToken19()
        {
            (StringUtil.GetToken("|asdf|qwer|zxcv|1234", "|", 3)).Should().Be("qwer");
        }

        [Fact]
        public void TestGetToken20()
        {
            (StringUtil.GetToken("|asdf|qwer|zxcv|1234", "|", 4)).Should().Be("zxcv");
        }

        [Fact]
        public void TestGetToken21()
        {
            (StringUtil.GetToken("|asdf|qwer|zxcv|1234", "|", 5)).Should().Be("1234");
        }

        [Fact]
        public void TestGetToken22()
        {
            (StringUtil.GetToken("|asdf|qwer|zxcv|1234|", "|", 6)).Should().Be("");
        }

        [Fact]
        public void TestGetToken23()
        {
            (StringUtil.GetToken("||||", "|", 1)).Should().Be("");
        }

        [Fact]
        public void TestGetToken24()
        {
            (StringUtil.GetToken("||||", "|", 2)).Should().Be("");
        }

        [Fact]
        public void TestGetToken25()
        {
            (StringUtil.GetToken("||||", "|", 3)).Should().Be("");
        }

        [Fact]
        public void TestGetToken26()
        {
            (StringUtil.GetToken("||||", "|", 4)).Should().Be("");
        }

        [Fact]
        public void TestGetToken27()
        {
            (StringUtil.GetToken("||||", "|", 5)).Should().Be("");
        }

        [Fact]
        public void TestGetToken28()
        {
            (StringUtil.GetToken("a|b", "|", 1)).Should().Be("a");
            (StringUtil.GetToken("a|b", "|", 2)).Should().Be("b");
        }

        [Fact]
        public void TestGetToken29()
        {
            (StringUtil.GetToken("a|", "|", 1)).Should().Be("a");
        }

        [Fact]
        public void TestGetToken30()
        {
            (StringUtil.GetToken("a", "|", 1)).Should().Be("a");
        }

        [Fact]
        public void TestGetToken31()
        {
            (StringUtil.GetToken("|a", "|", 2)).Should().Be("a");
        }

        [Fact]
        public void TestGetToken32()
        {
            (StringUtil.GetToken("|a", "|", 1)).Should().Be(String.Empty);
        }

        [Fact]
        public void TestGetToken33()
        {
            (StringUtil.GetToken("", "|", 1)).Should().Be(String.Empty);
        }

        [Fact]
        public void TestGetTokenBigPos1()
        {
            Action act = () => StringUtil.GetToken("a|s|d|f", "|", 5);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestGetTokenBigPos2()
        {
            Action act = () => StringUtil.GetToken("a|s|d|f", "|", 6);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestGetTokenBigPos3()
        {
            Action act = () => StringUtil.GetToken("a|s|d|f|", "|", 6);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestGetTokenBigPos4()
        {
            Action act = () => StringUtil.GetToken("a|s|d|f|", "|", 7);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestGetTokenSmallPos1()
        {
            Action act = () => StringUtil.GetToken("a|s|d|f", "|", 0);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestGetTokenSmallPos2()
        {
            Action act = () => StringUtil.GetToken("a|s|d|f", "|", -1);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        // Multi-character delimiter tests
        [Fact]
        public void TestGetToken34MultiCharDelimiterBasic()
        {
            (StringUtil.GetToken("a::b::c", "::", 1)).Should().Be("a");
        }

        [Fact]
        public void TestGetToken35MultiCharDelimiterSecondToken()
        {
            (StringUtil.GetToken("a::b::c", "::", 2)).Should().Be("b");
        }

        [Fact]
        public void TestGetToken36MultiCharDelimiterThirdToken()
        {
            (StringUtil.GetToken("a::b::c", "::", 3)).Should().Be("c");
        }

        [Fact]
        public void TestGetToken37MultiCharDelimiterConsecutive()
        {
            // "a::::b" split by "::" should give ["a", "", "b"]
            (StringUtil.GetToken("a::::b", "::", 1)).Should().Be("a");
        }

        [Fact]
        public void TestGetToken38MultiCharDelimiterConsecutiveEmptyToken()
        {
            // "a::::b" split by "::" should give ["a", "", "b"]
            (StringUtil.GetToken("a::::b", "::", 2)).Should().Be("");
        }

        [Fact]
        public void TestGetToken39MultiCharDelimiterConsecutiveThirdToken()
        {
            // "a::::b" split by "::" should give ["a", "", "b"]
            (StringUtil.GetToken("a::::b", "::", 3)).Should().Be("b");
        }

        [Fact]
        public void TestGetToken40MultiCharDelimiterDashDelimiter()
        {
            (StringUtil.GetToken("hello--world--test", "--", 1)).Should().Be("hello");
        }

        [Fact]
        public void TestGetToken41MultiCharDelimiterDashDelimiterSecond()
        {
            (StringUtil.GetToken("hello--world--test", "--", 2)).Should().Be("world");
        }

        [Fact]
        public void TestGetToken42MultiCharDelimiterDashDelimiterThird()
        {
            (StringUtil.GetToken("hello--world--test", "--", 3)).Should().Be("test");
        }

        [Fact]
        public void TestGetToken43MultiCharDelimiterAngleBrackets()
        {
            (StringUtil.GetToken("one<<two<<three", "<<", 1)).Should().Be("one");
        }

        [Fact]
        public void TestGetToken44MultiCharDelimiterGreaterThan()
        {
            (StringUtil.GetToken("a>>b>>c>>d", ">>", 1)).Should().Be("a");
        }

        [Fact]
        public void TestGetToken45MultiCharDelimiterGreaterThanSecond()
        {
            (StringUtil.GetToken("a>>b>>c>>d", ">>", 2)).Should().Be("b");
        }

        [Fact]
        public void TestGetToken46MultiCharDelimiterGreaterThanThird()
        {
            (StringUtil.GetToken("a>>b>>c>>d", ">>", 3)).Should().Be("c");
        }

        [Fact]
        public void TestGetToken47MultiCharDelimiterGreaterThanFourth()
        {
            (StringUtil.GetToken("a>>b>>c>>d", ">>", 4)).Should().Be("d");
        }

        [Fact]
        public void TestGetToken48MultiCharDelimiterAtStart()
        {
            (StringUtil.GetToken("::a::b", "::", 1)).Should().Be("");
        }

        [Fact]
        public void TestGetToken49MultiCharDelimiterAtStartSecond()
        {
            (StringUtil.GetToken("::a::b", "::", 2)).Should().Be("a");
        }

        [Fact]
        public void TestGetToken50MultiCharDelimiterAtEnd()
        {
            // "a::b::" split by "::" should give ["a", "b", ""]
            (StringUtil.GetToken("a::b::", "::", 2)).Should().Be("b");
        }

        [Fact]
        public void TestGetToken51MultiCharDelimiterAtEndEmpty()
        {
            (StringUtil.GetToken("a::b::", "::", 3)).Should().Be("");
        }

        [Fact]
        public void TestGetToken52MultiCharDelimiterThreeChars()
        {
            (StringUtil.GetToken("x:::y:::z", ":::", 1)).Should().Be("x");
        }

        [Fact]
        public void TestGetToken53MultiCharDelimiterThreeCharsSecond()
        {
            (StringUtil.GetToken("x:::y:::z", ":::", 2)).Should().Be("y");
        }

        [Fact]
        public void TestGetToken54MultiCharDelimiterThreeCharsThird()
        {
            (StringUtil.GetToken("x:::y:::z", ":::", 3)).Should().Be("z");
        }

        [Fact]
        public void TestGetToken55MultiCharDelimiterLongString()
        {
            (StringUtil.GetToken("firstname::lastname::email", "::", 1)).Should().Be("firstname");
        }

        [Fact]
        public void TestGetToken56MultiCharDelimiterLongStringSecond()
        {
            (StringUtil.GetToken("firstname::lastname::email", "::", 2)).Should().Be("lastname");
        }

        [Fact]
        public void TestGetToken57MultiCharDelimiterLongStringThird()
        {
            (StringUtil.GetToken("firstname::lastname::email", "::", 3)).Should().Be("email");
        }

        [Fact]
        public void TestGetToken58WhitespaceDelimiter()
        {
            (StringUtil.GetToken("hello  world", "  ", 1)).Should().Be("hello");
        }

        [Fact]
        public void TestGetToken59WhitespaceDelimiterSecond()
        {
            (StringUtil.GetToken("hello  world", "  ", 2)).Should().Be("world");
        }

        [Fact]
        public void TestGetToken60TabDelimiter()
        {
            (StringUtil.GetToken("a\t\tb", "\t\t", 1)).Should().Be("a");
        }

        [Fact]
        public void TestGetToken61TabDelimiterSecond()
        {
            (StringUtil.GetToken("a\t\tb", "\t\t", 2)).Should().Be("b");
        }

        [Fact]
        public void TestGetToken62SpecialCharDelimiter()
        {
            (StringUtil.GetToken("test##value", "##", 1)).Should().Be("test");
        }

        [Fact]
        public void TestGetToken63SpecialCharDelimiterSecond()
        {
            (StringUtil.GetToken("test##value", "##", 2)).Should().Be("value");
        }

        [Fact]
        public void TestGetToken64CaseSensitivity1()
        {
            (StringUtil.GetToken("abc::ABC::def", "::", 1)).Should().Be("abc");
        }

        [Fact]
        public void TestGetToken65CaseSensitivity2()
        {
            (StringUtil.GetToken("abc::ABC::def", "::", 2)).Should().Be("ABC");
        }

        [Fact]
        public void TestGetToken66CaseSensitivity3()
        {
            (StringUtil.GetToken("abc::ABC::def", "::", 3)).Should().Be("def");
        }

        [Fact]
        public void TestGetToken67NumericTokens()
        {
            (StringUtil.GetToken("123::456::789", "::", 1)).Should().Be("123");
        }

        [Fact]
        public void TestGetToken68NumericTokensSecond()
        {
            (StringUtil.GetToken("123::456::789", "::", 2)).Should().Be("456");
        }

        [Fact]
        public void TestGetToken69NumericTokensThird()
        {
            (StringUtil.GetToken("123::456::789", "::", 3)).Should().Be("789");
        }

        [Fact]
        public void TestGetToken70MultiCharDelimiterWithNumbers()
        {
            (StringUtil.GetToken("a1@@b2@@c3", "@@", 1)).Should().Be("a1");
        }

        [Fact]
        public void TestGetToken71MultiCharDelimiterWithNumbersSecond()
        {
            (StringUtil.GetToken("a1@@b2@@c3", "@@", 2)).Should().Be("b2");
        }

        [Fact]
        public void TestGetToken72MultiCharDelimiterWithNumbersThird()
        {
            (StringUtil.GetToken("a1@@b2@@c3", "@@", 3)).Should().Be("c3");
        }

        [Fact]
        public void TestGetToken73LongMultiCharDelimiter()
        {
            (StringUtil.GetToken("start----middle----end", "----", 1)).Should().Be("start");
        }

        [Fact]
        public void TestGetToken74LongMultiCharDelimiterSecond()
        {
            (StringUtil.GetToken("start----middle----end", "----", 2)).Should().Be("middle");
        }

        [Fact]
        public void TestGetToken75LongMultiCharDelimiterThird()
        {
            (StringUtil.GetToken("start----middle----end", "----", 3)).Should().Be("end");
        }

        [Fact]
        public void TestGetToken76MultiCharDelimiterMultipleConsecutive()
        {
            // "a::::::b" split by "::" should give ["a", "", "", "b"]
            (StringUtil.GetToken("a::::::b", "::", 1)).Should().Be("a");
        }

        [Fact]
        public void TestGetToken77MultiCharDelimiterMultipleConsecutiveEmpty1()
        {
            // "a::::::b" split by "::" should give ["a", "", "", "b"]
            (StringUtil.GetToken("a::::::b", "::", 2)).Should().Be("");
        }

        [Fact]
        public void TestGetToken78MultiCharDelimiterMultipleConsecutiveEmpty2()
        {
            // "a::::::b" split by "::" should give ["a", "", "", "b"]
            (StringUtil.GetToken("a::::::b", "::", 3)).Should().Be("");
        }

        [Fact]
        public void TestGetToken79MultiCharDelimiterMultipleConsecutiveLastToken()
        {
            // "a::::::b" split by "::" should give ["a", "", "", "b"]
            (StringUtil.GetToken("a::::::b", "::", 4)).Should().Be("b");
        }

        [Fact]
        public void TestGetToken80SingleCharInSourceMultiCharDelimiter()
        {
            (StringUtil.GetToken("x", "::", 1)).Should().Be("x");
        }

        [Fact]
        public void TestGetToken81DelimiterLongerThanSourceBasic()
        {
            // When delimiter is longer than source, source has no delimiters
            (StringUtil.GetToken("short", "verylongdelimiter", 1)).Should().Be("short");
        }

        [Fact]
        public void TestGetToken82MultiTokenLongValues()
        {
            (StringUtil.GetToken("verylongfirsttoken::verylongsecondtoken::verylongthirdtoken", "::", 1)).Should().Be("verylongfirsttoken");
        }

        [Fact]
        public void TestGetToken83MultiTokenLongValuesSecond()
        {
            (StringUtil.GetToken("verylongfirsttoken::verylongsecondtoken::verylongthirdtoken", "::", 2)).Should().Be("verylongsecondtoken");
        }

        [Fact]
        public void TestGetToken84MultiTokenLongValuesThird()
        {
            (StringUtil.GetToken("verylongfirsttoken::verylongsecondtoken::verylongthirdtoken", "::", 3)).Should().Be("verylongthirdtoken");
        }

        #endregion


        #region IsToken(string, string, string) tests

        [Fact]
        public void TestIsToken1()
        {
            (StringUtil.IsToken("a|s|d|f", "a", "|")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken2()
        {
            (StringUtil.IsToken("a|s|d|f", "s", "|")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken3()
        {
            (StringUtil.IsToken("a|s|d|f", "d", "|")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken4()
        {
            (StringUtil.IsToken("a|s|d|f", "f", "|")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken5()
        {
            (StringUtil.IsToken("a|s|d|f", "", "|")).Should().Be(false);
        }

        [Fact]
        public void TestIsToken6()
        {
            (StringUtil.IsToken("a|s|d|f", "|", "|")).Should().Be(false);
        }

        [Fact]
        public void TestIsToken7()
        {
            (StringUtil.IsToken("|a|s|d|f", "", "|")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken8()
        {
            (StringUtil.IsToken("a|s|d|f|", "", "|")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken9()
        {
            (StringUtil.IsToken(String.Empty, String.Empty, "|")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken10()
        {
            (StringUtil.IsToken("a", "a", "|")).Should().Be(true);
        }

        // Multi-character delimiter tests
        [Fact]
        public void TestIsToken11MultiCharDelimiterBasic()
        {
            (StringUtil.IsToken("a::b::c", "a", "::")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken12MultiCharDelimiterSecondToken()
        {
            (StringUtil.IsToken("a::b::c", "b", "::")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken13MultiCharDelimiterThirdToken()
        {
            (StringUtil.IsToken("a::b::c", "c", "::")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken14MultiCharDelimiterNotFound()
        {
            (StringUtil.IsToken("a::b::c", "d", "::")).Should().Be(false);
        }

        [Fact]
        public void TestIsToken15MultiCharDelimiterConsecutiveEmptyToken()
        {
            // "a::::b" split by "::" should give ["a", "", "b"]
            (StringUtil.IsToken("a::::b", "", "::")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken16MultiCharDelimiterDashDelimiter()
        {
            (StringUtil.IsToken("hello--world--test", "hello", "--")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken17MultiCharDelimiterDashDelimiterSecond()
        {
            (StringUtil.IsToken("hello--world--test", "world", "--")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken18MultiCharDelimiterDashDelimiterThird()
        {
            (StringUtil.IsToken("hello--world--test", "test", "--")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken19MultiCharDelimiterAngleBrackets()
        {
            (StringUtil.IsToken("one<<two<<three", "one", "<<")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken20MultiCharDelimiterGreaterThan()
        {
            (StringUtil.IsToken("a>>b>>c>>d", "a", ">>")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken21MultiCharDelimiterGreaterThanNotFound()
        {
            (StringUtil.IsToken("a>>b>>c>>d", "x", ">>")).Should().Be(false);
        }

        [Fact]
        public void TestIsToken22MultiCharDelimiterAtStart()
        {
            (StringUtil.IsToken("::a::b", "", "::")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken23MultiCharDelimiterAtEnd()
        {
            (StringUtil.IsToken("a::b::", "b", "::")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken24MultiCharDelimiterAtEndEmpty()
        {
            (StringUtil.IsToken("a::b::", "", "::")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken25MultiCharDelimiterThreeChars()
        {
            (StringUtil.IsToken("x:::y:::z", "x", ":::")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken26MultiCharDelimiterThreeCharsSecond()
        {
            (StringUtil.IsToken("x:::y:::z", "y", ":::")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken27MultiCharDelimiterThreeCharsThird()
        {
            (StringUtil.IsToken("x:::y:::z", "z", ":::")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken28MultiCharDelimiterLongString()
        {
            (StringUtil.IsToken("firstname::lastname::email", "firstname", "::")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken29MultiCharDelimiterLongStringSecond()
        {
            (StringUtil.IsToken("firstname::lastname::email", "lastname", "::")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken30MultiCharDelimiterLongStringThird()
        {
            (StringUtil.IsToken("firstname::lastname::email", "email", "::")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken31CaseSensitivity1()
        {
            // "abc::ABC::def" split by "::" gives ["abc", "ABC", "def"]
            // Token "abc" exists, so IsToken returns true
            (StringUtil.IsToken("abc::ABC::def", "abc", "::")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken32CaseSensitivity2()
        {
            // "abc::ABC::def" split by "::" gives ["abc", "ABC", "def"]
            // Token "ABC" exists, so IsToken returns true
            (StringUtil.IsToken("abc::ABC::def", "ABC", "::")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken33CaseSensitivity3()
        {
            // "abc::ABC::def" split by "::" gives ["abc", "ABC", "def"]
            // Token "Abc" does not exist, so IsToken returns false
            (StringUtil.IsToken("abc::ABC::def", "Abc", "::")).Should().Be(false);
        }

        [Fact]
        public void TestIsToken34NumericTokens()
        {
            (StringUtil.IsToken("123::456::789", "123", "::")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken35NumericTokensSecond()
        {
            (StringUtil.IsToken("123::456::789", "456", "::")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken36NumericTokensThird()
        {
            (StringUtil.IsToken("123::456::789", "789", "::")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken37PartialMatch()
        {
            // "hello" is not a token; "helloworld" is
            (StringUtil.IsToken("helloworld::test", "hello", "::")).Should().Be(false);
        }

        [Fact]
        public void TestIsToken38PartialMatchSecond()
        {
            (StringUtil.IsToken("helloworld::test", "world", "::")).Should().Be(false);
        }

        [Fact]
        public void TestIsToken39ExactMatch()
        {
            (StringUtil.IsToken("helloworld::test", "helloworld", "::")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken40WhitespaceDelimiter()
        {
            (StringUtil.IsToken("hello  world", "hello", "  ")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken41WhitespaceDelimiterSecond()
        {
            (StringUtil.IsToken("hello  world", "world", "  ")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken42SpecialCharDelimiter()
        {
            (StringUtil.IsToken("test@@value", "test", "@@")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken43SpecialCharDelimiterSecond()
        {
            (StringUtil.IsToken("test@@value", "value", "@@")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken44MultiCharDelimiterWithNumbers()
        {
            (StringUtil.IsToken("a1@@b2@@c3", "a1", "@@")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken45MultiCharDelimiterWithNumbersSecond()
        {
            (StringUtil.IsToken("a1@@b2@@c3", "b2", "@@")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken46MultiCharDelimiterWithNumbersThird()
        {
            (StringUtil.IsToken("a1@@b2@@c3", "c3", "@@")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken47LongMultiCharDelimiter()
        {
            (StringUtil.IsToken("start----middle----end", "start", "----")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken48LongMultiCharDelimiterSecond()
        {
            (StringUtil.IsToken("start----middle----end", "middle", "----")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken49LongMultiCharDelimiterThird()
        {
            (StringUtil.IsToken("start----middle----end", "end", "----")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken50MultiCharDelimiterMultipleConsecutive()
        {
            // "a::::::b" split by "::" should give ["a", "", "", "b"]
            // Check for "a"
            (StringUtil.IsToken("a::::::b", "a", "::")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken51MultiCharDelimiterMultipleConsecutiveEmpty()
        {
            // "a::::::b" split by "::" should give ["a", "", "", "b"]
            // Check for empty token
            (StringUtil.IsToken("a::::::b", "", "::")).Should().Be(true);
        }

        [Fact]
        public void TestIsToken52MultiCharDelimiterMultipleConsecutiveLastToken()
        {
            // "a::::::b" split by "::" should give ["a", "", "", "b"]
            (StringUtil.IsToken("a::::::b", "b", "::")).Should().Be(true);
        }

        #endregion


        #region SqlText(string) tests

        [Fact]
        public void TestSqlText1()
        {
            (StringUtil.SqlText("\"asdf\"")).Should().Be("\"\"asdf\"\"");
        }

        [Fact]
        public void TestSqlText2()
        {
            (StringUtil.SqlText("asdf\"")).Should().Be("asdf\"\"");
        }

        [Fact]
        public void TestSqlText3()
        {
            (StringUtil.SqlText("\"asdf")).Should().Be("\"\"asdf");
        }

        [Fact]
        public void TestSqlText4()
        {
            (StringUtil.SqlText("\"\"asdf\"\"")).Should().Be("\"\"\"\"asdf\"\"\"\"");
        }

        // Empty and null tests
        [Fact]
        public void TestSqlText5EmptyString()
        {
            (StringUtil.SqlText("")).Should().Be("");
        }

        [Fact]
        public void TestSqlText6NullString()
        {
            Action act = () => StringUtil.SqlText(null);
            act.Should().Throw<ArgumentNullException>();
        }

        // No quotes tests
        [Fact]
        public void TestSqlText7NoQuotes()
        {
            (StringUtil.SqlText("asdf")).Should().Be("asdf");
        }

        [Fact]
        public void TestSqlText8NoQuotesWithSpecialChars()
        {
            (StringUtil.SqlText("hello world!")).Should().Be("hello world!");
        }

        [Fact]
        public void TestSqlText9NoQuotesNumericOnly()
        {
            (StringUtil.SqlText("12345")).Should().Be("12345");
        }

        // Single character tests
        [Fact]
        public void TestSqlText10SingleQuote()
        {
            (StringUtil.SqlText("\"")).Should().Be("\"\"");
        }

        [Fact]
        public void TestSqlText11SingleCharNoQuote()
        {
            (StringUtil.SqlText("a")).Should().Be("a");
        }

        // Quote in middle tests
        [Fact]
        public void TestSqlText12QuoteInMiddle()
        {
            (StringUtil.SqlText("a\"b")).Should().Be("a\"\"b");
        }

        [Fact]
        public void TestSqlText13QuoteInMiddleWithSpaces()
        {
            (StringUtil.SqlText("hello \"world")).Should().Be("hello \"\"world");
        }

        [Fact]
        public void TestSqlText14MultipleQuotesInMiddle()
        {
            (StringUtil.SqlText("a\"b\"c")).Should().Be("a\"\"b\"\"c");
        }

        // Consecutive quotes tests
        [Fact]
        public void TestSqlText15ThreeConsecutiveQuotes()
        {
            (StringUtil.SqlText("\"\"\"")).Should().Be("\"\"\"\"\"\"");
        }

        [Fact]
        public void TestSqlText16FourConsecutiveQuotes()
        {
            (StringUtil.SqlText("\"\"\"\"")).Should().Be("\"\"\"\"\"\"\"\"");
        }

        [Fact]
        public void TestSqlText17FiveConsecutiveQuotes()
        {
            (StringUtil.SqlText("\"\"\"\"\"")).Should().Be("\"\"\"\"\"\"\"\"\"\"");
        }

        [Fact]
        public void TestSqlText18ConsecutiveQuotesWithText()
        {
            (StringUtil.SqlText("start\"\"end")).Should().Be("start\"\"\"\"end");
        }

        // Special characters with quotes
        [Fact]
        public void TestSqlText19QuoteWithBackslash()
        {
            (StringUtil.SqlText("a\\\"b")).Should().Be("a\\\"\"b");
        }

        [Fact]
        public void TestSqlText20QuoteWithNewline()
        {
            (StringUtil.SqlText("a\n\"b")).Should().Be("a\n\"\"b");
        }

        [Fact]
        public void TestSqlText21QuoteWithTab()
        {
            (StringUtil.SqlText("a\t\"b")).Should().Be("a\t\"\"b");
        }

        [Fact]
        public void TestSqlText22QuoteWithCarriageReturn()
        {
            (StringUtil.SqlText("a\r\"b")).Should().Be("a\r\"\"b");
        }

        // Long strings with quotes
        [Fact]
        public void TestSqlText23LongStringWithQuotes()
        {
            (StringUtil.SqlText("verylongstringwithouquote\"inside")).Should().Be("verylongstringwithouquote\"\"inside");
        }

        [Fact]
        public void TestSqlText24LongStringWithMultipleQuotes()
        {
            (StringUtil.SqlText("start\"middle\"end\"more")).Should().Be("start\"\"middle\"\"end\"\"more");
        }

        // Only quotes tests
        [Fact]
        public void TestSqlText25OnlyTwoQuotes()
        {
            (StringUtil.SqlText("\"\"")).Should().Be("\"\"\"\"");
        }

        [Fact]
        public void TestSqlText26OnlyThreeQuotes()
        {
            (StringUtil.SqlText("\"\"\"")).Should().Be("\"\"\"\"\"\"");
        }

        // Whitespace and quotes
        [Fact]
        public void TestSqlText27QuoteWithLeadingSpace()
        {
            (StringUtil.SqlText(" \"")).Should().Be(" \"\"");
        }

        [Fact]
        public void TestSqlText28QuoteWithTrailingSpace()
        {
            (StringUtil.SqlText("\" ")).Should().Be("\"\" ");
        }

        [Fact]
        public void TestSqlText29SpacesBetweenQuotes()
        {
            (StringUtil.SqlText("\" \"")).Should().Be("\"\" \"\"");
        }

        // Numeric and alphanumeric with quotes
        [Fact]
        public void TestSqlText30NumericWithQuote()
        {
            (StringUtil.SqlText("12\"34")).Should().Be("12\"\"34");
        }

        [Fact]
        public void TestSqlText31AlphanumericWithQuotes()
        {
            (StringUtil.SqlText("a1\"b2\"c3")).Should().Be("a1\"\"b2\"\"c3");
        }

        // Mixed content tests
        [Fact]
        public void TestSqlText32MixedContentQuoteEverywhere()
        {
            (StringUtil.SqlText("\"hello\"world\"test\"")).Should().Be("\"\"hello\"\"world\"\"test\"\"");
        }

        [Fact]
        public void TestSqlText33SQLStatementLike()
        {
            // Simulating: INSERT INTO table VALUES ("value")
            (StringUtil.SqlText("INSERT INTO table VALUES (\"value\")")).Should().Be("INSERT INTO table VALUES (\"\"value\"\")");
        }

        [Fact]
        public void TestSqlText34QuotedString()
        {
            (StringUtil.SqlText("\"\"This is a test\"\"")).Should().Be("\"\"\"\"This is a test\"\"\"\"");
        }

        [Fact]
        public void TestSqlText35ManyScatteredQuotes()
        {
            (StringUtil.SqlText("a\"b\"c\"d\"e\"f")).Should().Be("a\"\"b\"\"c\"\"d\"\"e\"\"f");
        }

        [Fact]
        public void TestSqlText36PathWithQuotes()
        {
            (StringUtil.SqlText("C:\\path\\to\\file\"name.txt")).Should().Be("C:\\path\\to\\file\"\"name.txt");
        }

        #endregion


        #region StripLeadingDoubleQuotes(string) tests

        [Fact]
        public void TestStripLeadingDoubleQuotes1()
        {
            (StringUtil.StripLeadingDoubleQuotes("\"asdf\"")).Should().Be("asdf\"");
        }

        [Fact]
        public void TestStripLeadingDoubleQuotes2()
        {
            (StringUtil.StripLeadingDoubleQuotes("\"asdf")).Should().Be("asdf");
        }

        [Fact]
        public void TestStripLeadingDoubleQuotes3()
        {
            (StringUtil.StripLeadingDoubleQuotes("\"\"\"asdf")).Should().Be("asdf");
        }

        [Fact]
        public void TestStripLeadingDoubleQuotes4()
        {
            (StringUtil.StripLeadingDoubleQuotes("asdf")).Should().Be("asdf");
        }

        [Fact]
        public void TestStripLeadingDoubleQuotes5()
        {
            (StringUtil.StripLeadingDoubleQuotes("\"")).Should().Be("");
        }

        [Fact]
        public void TestStripLeadingDoubleQuotes6()
        {
            (StringUtil.StripLeadingDoubleQuotes("\"\"")).Should().Be("");
        }

        [Fact]
        public void TestStripLeadingDoubleQuotes7()
        {
            (StringUtil.StripLeadingDoubleQuotes("")).Should().Be("");
        }

        // Null input test
        [Fact]
        public void TestStripLeadingDoubleQuotes8NullInput()
        {
            Action act = () => StringUtil.StripLeadingDoubleQuotes(null);
            act.Should().Throw<ArgumentNullException>();
        }

        // No quotes tests
        [Fact]
        public void TestStripLeadingDoubleQuotes9SingleCharNoQuote()
        {
            (StringUtil.StripLeadingDoubleQuotes("a")).Should().Be("a");
        }

        [Fact]
        public void TestStripLeadingDoubleQuotes10NoQuotesWithText()
        {
            (StringUtil.StripLeadingDoubleQuotes("hello world")).Should().Be("hello world");
        }

        [Fact]
        public void TestStripLeadingDoubleQuotes11NoQuotesNumeric()
        {
            (StringUtil.StripLeadingDoubleQuotes("12345")).Should().Be("12345");
        }

        // Multiple leading quotes tests
        [Fact]
        public void TestStripLeadingDoubleQuotes12FourLeadingQuotes()
        {
            (StringUtil.StripLeadingDoubleQuotes("\"\"\"\"text")).Should().Be("text");
        }

        [Fact]
        public void TestStripLeadingDoubleQuotes13FiveLeadingQuotes()
        {
            (StringUtil.StripLeadingDoubleQuotes("\"\"\"\"\"content")).Should().Be("content");
        }

        [Fact]
        public void TestStripLeadingDoubleQuotes14SixLeadingQuotes()
        {
            (StringUtil.StripLeadingDoubleQuotes("\"\"\"\"\"\"data")).Should().Be("data");
        }

        [Fact]
        public void TestStripLeadingDoubleQuotes15TenLeadingQuotes()
        {
            (StringUtil.StripLeadingDoubleQuotes("\"\"\"\"\"\"\"\"\"\"result")).Should().Be("result");
        }

        // Quotes with different content types
        [Fact]
        public void TestStripLeadingDoubleQuotes16QuotesWithSymbols()
        {
            (StringUtil.StripLeadingDoubleQuotes("\"!@#$%")).Should().Be("!@#$%");
        }

        [Fact]
        public void TestStripLeadingDoubleQuotes17QuotesWithAlphanumeric()
        {
            (StringUtil.StripLeadingDoubleQuotes("\"abc123def456")).Should().Be("abc123def456");
        }

        [Fact]
        public void TestStripLeadingDoubleQuotes18MultipleQuotesWithAlphanumeric()
        {
            (StringUtil.StripLeadingDoubleQuotes("\"\"\"test123")).Should().Be("test123");
        }

        // Only quotes strings
        [Fact]
        public void TestStripLeadingDoubleQuotes19ThreeQuotesOnly()
        {
            (StringUtil.StripLeadingDoubleQuotes("\"\"\"")).Should().Be("");
        }

        [Fact]
        public void TestStripLeadingDoubleQuotes20FourQuotesOnly()
        {
            (StringUtil.StripLeadingDoubleQuotes("\"\"\"\"")).Should().Be("");
        }

        [Fact]
        public void TestStripLeadingDoubleQuotes21FiveQuotesOnly()
        {
            (StringUtil.StripLeadingDoubleQuotes("\"\"\"\"\"")).Should().Be("");
        }

        [Fact]
        public void TestStripLeadingDoubleQuotes22ManyQuotesOnly()
        {
            (StringUtil.StripLeadingDoubleQuotes("\"\"\"\"\"\"\"\"\"\"")).Should().Be("");
        }

        // Quotes followed by special characters
        [Fact]
        public void TestStripLeadingDoubleQuotes23QuoteWithLeadingSpace()
        {
            (StringUtil.StripLeadingDoubleQuotes("\" text")).Should().Be(" text");
        }

        [Fact]
        public void TestStripLeadingDoubleQuotes24QuoteWithNewline()
        {
            (StringUtil.StripLeadingDoubleQuotes("\"\ntext")).Should().Be("\ntext");
        }

        [Fact]
        public void TestStripLeadingDoubleQuotes25QuoteWithTab()
        {
            (StringUtil.StripLeadingDoubleQuotes("\"\ttext")).Should().Be("\ttext");
        }

        [Fact]
        public void TestStripLeadingDoubleQuotes26QuoteWithBackslash()
        {
            (StringUtil.StripLeadingDoubleQuotes("\"\\path\\to\\file")).Should().Be("\\path\\to\\file");
        }

        [Fact]
        public void TestStripLeadingDoubleQuotes27MultipleQuotesWithSpace()
        {
            (StringUtil.StripLeadingDoubleQuotes("\" ")).Should().Be(" ");
        }

        [Fact]
        public void TestStripLeadingDoubleQuotes28QuoteWithSingleQuoteChar()
        {
            (StringUtil.StripLeadingDoubleQuotes("\"'")).Should().Be("'");
        }

        // Quotes with numeric content
        [Fact]
        public void TestStripLeadingDoubleQuotes29QuoteWithNumberOnly()
        {
            (StringUtil.StripLeadingDoubleQuotes("\"123")).Should().Be("123");
        }

        [Fact]
        public void TestStripLeadingDoubleQuotes30QuoteWithDecimal()
        {
            (StringUtil.StripLeadingDoubleQuotes("\"3.14159")).Should().Be("3.14159");
        }

        [Fact]
        public void TestStripLeadingDoubleQuotes31MultipleQuotesWithNumeric()
        {
            (StringUtil.StripLeadingDoubleQuotes("\"\"\"999")).Should().Be("999");
        }

        // Quotes with punctuation
        [Fact]
        public void TestStripLeadingDoubleQuotes32QuoteWithComma()
        {
            (StringUtil.StripLeadingDoubleQuotes("\",test")).Should().Be(",test");
        }

        [Fact]
        public void TestStripLeadingDoubleQuotes33QuoteWithPeriod()
        {
            (StringUtil.StripLeadingDoubleQuotes("\".file")).Should().Be(".file");
        }

        [Fact]
        public void TestStripLeadingDoubleQuotes34QuoteWithParens()
        {
            (StringUtil.StripLeadingDoubleQuotes("\"(test)")).Should().Be("(test)");
        }

        // Quotes with path-like content
        [Fact]
        public void TestStripLeadingDoubleQuotes35QuoteWithPathWindows()
        {
            (StringUtil.StripLeadingDoubleQuotes("\"C:\\Users\\file.txt")).Should().Be("C:\\Users\\file.txt");
        }

        [Fact]
        public void TestStripLeadingDoubleQuotes36QuoteWithPathUnix()
        {
            (StringUtil.StripLeadingDoubleQuotes("\"/home/user/file.txt")).Should().Be("/home/user/file.txt");
        }

        // Mixed content with quotes
        [Fact]
        public void TestStripLeadingDoubleQuotes37QuoteWithMixedContent()
        {
            (StringUtil.StripLeadingDoubleQuotes("\"hello123world!\"test")).Should().Be("hello123world!\"test");
        }

        [Fact]
        public void TestStripLeadingDoubleQuotes38MultipleQuotesWithMixedContent()
        {
            (StringUtil.StripLeadingDoubleQuotes("\"\"\"test\"data\"value")).Should().Be("test\"data\"value");
        }

        [Fact]
        public void TestStripLeadingDoubleQuotes39QuoteWithEmbeddedQuotes()
        {
            // Strips all leading quotes: "\"hello\" -> hello\"
            (StringUtil.StripLeadingDoubleQuotes("\"\"hello\"")).Should().Be("hello\"");
        }

        [Fact]
        public void TestStripLeadingDoubleQuotes40QuoteFollowedByNonQuoteSymbol()
        {
            (StringUtil.StripLeadingDoubleQuotes("\"@user")).Should().Be("@user");
        }

        [Fact]
        public void TestStripLeadingDoubleQuotes41LongStringWithLeadingQuotes()
        {
            (StringUtil.StripLeadingDoubleQuotes("\"verylongstringwithouquotes")).Should().Be("verylongstringwithouquotes");
        }

        [Fact]
        public void TestStripLeadingDoubleQuotes42QuoteWithURLContent()
        {
            (StringUtil.StripLeadingDoubleQuotes("\"https://example.com/path")).Should().Be("https://example.com/path");
        }

        [Fact]
        public void TestStripLeadingDoubleQuotes43QuoteWithJSONLike()
        {
            (StringUtil.StripLeadingDoubleQuotes("\"{\"key\": \"value\"}")).Should().Be("{\"key\": \"value\"}");
        }

        [Fact]
        public void TestStripLeadingDoubleQuotes44QuoteWithSQLLike()
        {
            (StringUtil.StripLeadingDoubleQuotes("\"SELECT * FROM table")).Should().Be("SELECT * FROM table");
        }

        [Fact]
        public void TestStripLeadingDoubleQuotes45QuoteWithWhitespaceOnly()
        {
            (StringUtil.StripLeadingDoubleQuotes("\"   ")).Should().Be("   ");
        }

        #endregion


        #region ToChar() tests (ASCII character set 1)

        [Fact]
        public void TestToChar0()
        {
            (StringUtil.ToChar(0)).Should().Be("\u0000");
        }

        [Fact]
        public void TestToChar65()
        {
            (StringUtil.ToChar(65)).Should().Be("A");
        }

        [Fact]
        public void TestToChar127()
        {
            (StringUtil.ToChar(127)).Should().Be("\u007F");
        }

        [Fact]
        public void TestToCharLowerAsciiSet()
        {
            int characterCode = 0;
            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 15; j++)
                {
                    StringBuilder target = new StringBuilder("00");
                    target.Append(i.ToString(CultureInfo.InvariantCulture));
                    switch (j)
                    {
                        case 10:
                            target.Append('A');
                            break;
                        case 11:
                            target.Append('B');
                            break;
                        case 12:
                            target.Append('C');
                            break;
                        case 13:
                            target.Append('D');
                            break;
                        case 14:
                            target.Append('E');
                            break;
                        case 15:
                            target.Append('F');
                            break;
                        default:
                            target.Append(j.ToString(CultureInfo.InvariantCulture));
                            break;
                    }

                    char c = (char)ushort.Parse(target.ToString(), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture);
                    string s = new String(new char[] { c });

                    (StringUtil.ToChar(characterCode)).Should().Be(s);
                    characterCode++;
                }
            }
        }

        #endregion


        #region ToChar(int) test (ASCII character set 2)

        [Fact]
        public void TestToChar128()
        {
            (StringUtil.ToChar(128)).Should().Be("\u0080");
        }

        [Fact]
        public void TestToChar129()
        {
            (StringUtil.ToChar(129)).Should().Be("\u0081");
        }

        [Fact]
        public void TestToChar130()
        {
            (StringUtil.ToChar(130)).Should().Be("\u0082");
        }

        [Fact]
        public void TestToChar131()
        {
            (StringUtil.ToChar(131)).Should().Be("\u0083");
        }

        [Fact]
        public void TestToChar132()
        {
            (StringUtil.ToChar(132)).Should().Be("\u0084");
        }

        [Fact]
        public void TestToChar133()
        {
            (StringUtil.ToChar(133)).Should().Be("\u0085");
        }

        [Fact]
        public void TestToChar134()
        {
            (StringUtil.ToChar(134)).Should().Be("\u0086");
        }

        [Fact]
        public void TestToChar135()
        {
            (StringUtil.ToChar(135)).Should().Be("\u0087");
        }

        [Fact]
        public void TestToChar136()
        {
            (StringUtil.ToChar(136)).Should().Be("\u0088");
        }

        [Fact]
        public void TestToChar137()
        {
            (StringUtil.ToChar(137)).Should().Be("\u0089");
        }

        [Fact]
        public void TestToChar138()
        {
            (StringUtil.ToChar(138)).Should().Be("\u008A");
        }

        [Fact]
        public void TestToChar139()
        {
            (StringUtil.ToChar(139)).Should().Be("\u008B");
        }

        [Fact]
        public void TestToChar140()
        {
            (StringUtil.ToChar(140)).Should().Be("\u008C");
        }

        [Fact]
        public void TestToChar141()
        {
            (StringUtil.ToChar(141)).Should().Be("\u008D");
        }

        [Fact]
        public void TestToChar142()
        {
            (StringUtil.ToChar(142)).Should().Be("\u008E");
        }

        [Fact]
        public void TestToChar143()
        {
            (StringUtil.ToChar(143)).Should().Be("\u008F");
        }

        [Fact]
        public void TestToChar144()
        {
            (StringUtil.ToChar(144)).Should().Be("\u0090");
        }

        [Fact]
        public void TestToChar145()
        {
            (StringUtil.ToChar(145)).Should().Be("\u0091");
        }

        [Fact]
        public void TestToChar146()
        {
            (StringUtil.ToChar(146)).Should().Be("\u0092");
        }

        [Fact]
        public void TestToChar147()
        {
            (StringUtil.ToChar(147)).Should().Be("\u0093");
        }

        [Fact]
        public void TestToChar148()
        {
            (StringUtil.ToChar(148)).Should().Be("\u0094");
        }

        [Fact]
        public void TestToChar149()
        {
            (StringUtil.ToChar(149)).Should().Be("\u0095");
        }

        [Fact]
        public void TestToChar150()
        {
            (StringUtil.ToChar(150)).Should().Be("\u0096");
        }

        [Fact]
        public void TestToChar151()
        {
            (StringUtil.ToChar(151)).Should().Be("\u0097");
        }

        [Fact]
        public void TestToChar152()
        {
            (StringUtil.ToChar(152)).Should().Be("\u0098");
        }

        [Fact]
        public void TestToChar153()
        {
            (StringUtil.ToChar(153)).Should().Be("\u0099");
        }

        [Fact]
        public void TestToChar154()
        {
            (StringUtil.ToChar(154)).Should().Be("\u009A");
        }

        [Fact]
        public void TestToChar155()
        {
            (StringUtil.ToChar(155)).Should().Be("\u009B");
        }

        [Fact]
        public void TestToChar156()
        {
            (StringUtil.ToChar(156)).Should().Be("\u009C");
        }

        [Fact]
        public void TestToChar157()
        {
            (StringUtil.ToChar(157)).Should().Be("\u009D");
        }

        [Fact]
        public void TestToChar158()
        {
            (StringUtil.ToChar(158)).Should().Be("\u009E");
        }

        [Fact]
        public void TestToChar159()
        {
            (StringUtil.ToChar(159)).Should().Be("\u009F");
        }

        [Fact]
        public void TestToChar176()
        {
            (StringUtil.ToChar(176)).Should().Be(StringUtil.DegreeSymbol);
        }

        [Fact]
        public void TestToChar255()
        {
            (StringUtil.ToChar(255)).Should().Be("\u00FF");
        }

        [Fact]
        public void TestToCharUpperAsciiSet()
        {
            int characterCode = 128;
            for (int i = 8; i <= 15; i++)
            {
                for (int j = 0; j <= 15; j++)
                {
                    StringBuilder target = new StringBuilder("00");

                    switch (i)
                    {
                        case 10:
                            target.Append('A');
                            break;
                        case 11:
                            target.Append('B');
                            break;
                        case 12:
                            target.Append('C');
                            break;
                        case 13:
                            target.Append('D');
                            break;
                        case 14:
                            target.Append('E');
                            break;
                        case 15:
                            target.Append('F');
                            break;
                        default:
                            target.Append(i.ToString(CultureInfo.InvariantCulture));
                            break;
                    }

                    switch (j)
                    {
                        case 10:
                            target.Append('A');
                            break;
                        case 11:
                            target.Append('B');
                            break;
                        case 12:
                            target.Append('C');
                            break;
                        case 13:
                            target.Append('D');
                            break;
                        case 14:
                            target.Append('E');
                            break;
                        case 15:
                            target.Append('F');
                            break;
                        default:
                            target.Append(j.ToString(CultureInfo.InvariantCulture));
                            break;
                    }

                    switch (characterCode)
                    {
                        case 128:
                        case 130:
                        case 131:
                        case 132:
                        case 133:
                        case 134:
                        case 135:
                        case 136:
                        case 137:
                        case 138:
                        case 139:
                        case 140:
                        case 141:
                        case 142:
                        case 145:
                        case 146:
                        case 147:
                        case 148:
                        case 149:
                        case 150:
                        case 151:
                        case 152:
                        case 153:
                        case 154:
                        case 155:
                        case 156:
                        case 158:
                        case 159:
                            //for some reason, while chr() returns the right character, it isn't quite a match to the unicode character.
                            //These were resolved with the Chr() function was modified to return the VisualBasic ChrW() method rather
                            //than the Chr() method.
                            break;
                        default:
                            char c = (char)ushort.Parse(target.ToString(), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture);
                            string s = new String(new char[] { c });
                            (StringUtil.ToChar(characterCode)).Should().Be(s);
                            break;
                    }

                    characterCode++;
                }
            }
        }

        #endregion


        #region ToChar(int) (exception) tests

        [Fact]
        public void TestToCharTooBig()
        {
            Action act = () => StringUtil.ToChar(256);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestToCharTooSmall()
        {
            Action act = () => StringUtil.ToChar(-1);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        #endregion


        #region ToUnicodeChar(int) tests

        [Fact]
        public void TestToUnicodeChar0()
        {
            (StringUtil.ToUnicodeChar(0)).Should().Be("\u0000");
        }

        [Fact]
        public void TestToUnicodeChar65()
        {
            (StringUtil.ToUnicodeChar(65)).Should().Be("A");
        }

        [Fact]
        public void TestToUnicodeChar255()
        {
            (StringUtil.ToUnicodeChar(255)).Should().Be("ÿ");
        }

        [Fact]
        public void TestToUnicodeCharWithinBmp()
        {
            // U+20AC EURO SIGN - within the Basic Multilingual Plane, single UTF-16 char
            (StringUtil.ToUnicodeChar(0x20AC)).Should().Be("€");
        }

        [Fact]
        public void TestToUnicodeCharOutsideBmpEncodesAsSurrogatePair()
        {
            // U+1F600 GRINNING FACE - outside the BMP, requires a UTF-16 surrogate pair
            (StringUtil.ToUnicodeChar(0x1F600)).Should().Be("😀");
        }

        [Fact]
        public void TestToUnicodeCharMaxCodePoint()
        {
            (StringUtil.ToUnicodeChar(0x10FFFF)).Should().Be("􏿿");
        }

        #endregion


        #region ToUnicodeChar(int) (exception) tests

        [Fact]
        public void TestToUnicodeCharTooSmall()
        {
            Action act = () => StringUtil.ToUnicodeChar(-1);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestToUnicodeCharTooBig()
        {
            Action act = () => StringUtil.ToUnicodeChar(0x110000);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestToUnicodeCharHighSurrogateRangeRejected()
        {
            Action act = () => StringUtil.ToUnicodeChar(0xD800);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestToUnicodeCharLowSurrogateRangeRejected()
        {
            Action act = () => StringUtil.ToUnicodeChar(0xDFFF);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        #endregion


        #region ToAscii(string) tests

        [Fact]
        public void TestToAscii1()
        {
            (StringUtil.ToAscii("\u0000")).Should().Be(0);
        }

        [Fact]
        public void TestToAscii2()
        { 
            (StringUtil.ToAscii("\u007F")).Should().Be(127);
        }

        [Fact]
        public void TestToAscii3()
        {
            (StringUtil.ToAscii("A")).Should().Be(65);
        }

        [Fact]
        public void TestToAscii4()
        {
            (StringUtil.ToAscii(StringUtil.DegreeSymbol)).Should().Be(176);
        }

        [Fact]
        public void TestToAscii5()
        {
            (StringUtil.ToAscii("\u0081")).Should().Be(129);
        }

        [Fact]
        public void TestToAscii6()
        {
            (StringUtil.ToAscii("\u00FF")).Should().Be(255);
        }

        [Fact]
        public void TestToAscii7LowercaseA()
        {
            (StringUtil.ToAscii("a")).Should().Be(97);
        }

        [Fact]
        public void TestToAscii8LowercaseZ()
        {
            (StringUtil.ToAscii("z")).Should().Be(122);
        }

        [Fact]
        public void TestToAscii9UppercaseZ()
        {
            (StringUtil.ToAscii("Z")).Should().Be(90);
        }

        [Fact]
        public void TestToAscii10Digit0()
        {
            (StringUtil.ToAscii("0")).Should().Be(48);
        }

        [Fact]
        public void TestToAscii11Digit5()
        {
            (StringUtil.ToAscii("5")).Should().Be(53);
        }

        [Fact]
        public void TestToAscii12Digit9()
        {
            (StringUtil.ToAscii("9")).Should().Be(57);
        }

        [Fact]
        public void TestToAscii13Space()
        {
            (StringUtil.ToAscii(" ")).Should().Be(32);
        }

        [Fact]
        public void TestToAscii14Tab()
        {
            (StringUtil.ToAscii("\t")).Should().Be(9);
        }

        [Fact]
        public void TestToAscii15Newline()
        {
            (StringUtil.ToAscii("\n")).Should().Be(10);
        }

        [Fact]
        public void TestToAscii16CarriageReturn()
        {
            (StringUtil.ToAscii("\r")).Should().Be(13);
        }

        [Fact]
        public void TestToAscii17ExclamationMark()
        {
            (StringUtil.ToAscii("!")).Should().Be(33);
        }

        [Fact]
        public void TestToAscii18DoubleQuote()
        {
            (StringUtil.ToAscii("\"")).Should().Be(34);
        }

        [Fact]
        public void TestToAscii19Hash()
        {
            (StringUtil.ToAscii("#")).Should().Be(35);
        }

        [Fact]
        public void TestToAscii20Dollar()
        {
            (StringUtil.ToAscii("$")).Should().Be(36);
        }

        [Fact]
        public void TestToAscii21Percent()
        {
            (StringUtil.ToAscii("%")).Should().Be(37);
        }

        [Fact]
        public void TestToAscii22Ampersand()
        {
            (StringUtil.ToAscii("&")).Should().Be(38);
        }

        [Fact]
        public void TestToAscii23SingleQuote()
        {
            (StringUtil.ToAscii("'")).Should().Be(39);
        }

        [Fact]
        public void TestToAscii24OpenParen()
        {
            (StringUtil.ToAscii("(")).Should().Be(40);
        }

        [Fact]
        public void TestToAscii25CloseParen()
        {
            (StringUtil.ToAscii(")")).Should().Be(41);
        }

        [Fact]
        public void TestToAscii26Asterisk()
        {
            (StringUtil.ToAscii("*")).Should().Be(42);
        }

        [Fact]
        public void TestToAscii27Plus()
        {
            (StringUtil.ToAscii("+")).Should().Be(43);
        }

        [Fact]
        public void TestToAscii28Comma()
        {
            (StringUtil.ToAscii(",")).Should().Be(44);
        }

        [Fact]
        public void TestToAscii29Hyphen()
        {
            (StringUtil.ToAscii("-")).Should().Be(45);
        }

        [Fact]
        public void TestToAscii30Period()
        {
            (StringUtil.ToAscii(".")).Should().Be(46);
        }

        [Fact]
        public void TestToAscii31ForwardSlash()
        {
            (StringUtil.ToAscii("/")).Should().Be(47);
        }

        [Fact]
        public void TestToAscii32Colon()
        {
            (StringUtil.ToAscii(":")).Should().Be(58);
        }

        [Fact]
        public void TestToAscii33Semicolon()
        {
            (StringUtil.ToAscii(";")).Should().Be(59);
        }

        [Fact]
        public void TestToAscii34LessThan()
        {
            (StringUtil.ToAscii("<")).Should().Be(60);
        }

        [Fact]
        public void TestToAscii35Equals()
        {
            (StringUtil.ToAscii("=")).Should().Be(61);
        }

        [Fact]
        public void TestToAscii36GreaterThan()
        {
            (StringUtil.ToAscii(">")).Should().Be(62);
        }

        [Fact]
        public void TestToAscii37Question()
        {
            (StringUtil.ToAscii("?")).Should().Be(63);
        }

        [Fact]
        public void TestToAscii38At()
        {
            (StringUtil.ToAscii("@")).Should().Be(64);
        }

        [Fact]
        public void TestToAscii39OpenBracket()
        {
            (StringUtil.ToAscii("[")).Should().Be(91);
        }

        [Fact]
        public void TestToAscii40Backslash()
        {
            (StringUtil.ToAscii("\\")).Should().Be(92);
        }

        [Fact]
        public void TestToAscii41CloseBracket()
        {
            (StringUtil.ToAscii("]")).Should().Be(93);
        }

        [Fact]
        public void TestToAscii42Caret()
        {
            (StringUtil.ToAscii("^")).Should().Be(94);
        }

        [Fact]
        public void TestToAscii43Underscore()
        {
            (StringUtil.ToAscii("_")).Should().Be(95);
        }

        [Fact]
        public void TestToAscii44Backtick()
        {
            (StringUtil.ToAscii("`")).Should().Be(96);
        }

        [Fact]
        public void TestToAscii45OpenBrace()
        {
            (StringUtil.ToAscii("{")).Should().Be(123);
        }

        [Fact]
        public void TestToAscii46Pipe()
        {
            (StringUtil.ToAscii("|")).Should().Be(124);
        }

        [Fact]
        public void TestToAscii47CloseBrace()
        {
            (StringUtil.ToAscii("}")).Should().Be(125);
        }

        [Fact]
        public void TestToAscii48Tilde()
        {
            (StringUtil.ToAscii("~")).Should().Be(126);
        }

        [Fact]
        public void TestToAscii49MultiCharStringFirstCharOnly()
        {
            // Test that only the first character is converted
            (StringUtil.ToAscii("ABC")).Should().Be(65);
        }

        [Fact]
        public void TestToAscii50MultiCharStringFirstCharOnly2()
        {
            // Test that only the first character is converted
            (StringUtil.ToAscii("apple")).Should().Be(97);
        }

        [Fact]
        public void TestToAscii51ControlCharacterBEL()
        {
            (StringUtil.ToAscii("\u0007")).Should().Be(7);
        }

        [Fact]
        public void TestToAscii52ControlCharacterBS()
        {
            (StringUtil.ToAscii("\u0008")).Should().Be(8);
        }

        [Fact]
        public void TestToAscii53ControlCharacterFF()
        {
            (StringUtil.ToAscii("\u000C")).Should().Be(12);
        }

        [Fact]
        public void TestToAscii54ControlCharacterVT()
        {
            (StringUtil.ToAscii("\u000B")).Should().Be(11);
        }

        [Fact]
        public void TestToAscii55NullString()
        {
            Action act = () => StringUtil.ToAscii(null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestToAscii56EmptyString()
        {
            Action act = () => StringUtil.ToAscii("");
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestToAscii57ExtendedASCIIA0()
        {
            // Non-breaking space in Windows-1252
            (StringUtil.ToAscii("\u00A0")).Should().Be(160);
        }

        [Fact]
        public void TestToAscii58ExtendedASCIIA9()
        {
            // Copyright symbol in Windows-1252
            (StringUtil.ToAscii("©")).Should().Be(169);
        }

        [Fact]
        public void TestToAscii59ExtendedASCIIAE()
        {
            // Registered trademark in Windows-1252
            (StringUtil.ToAscii("®")).Should().Be(174);
        }

        [Fact]
        public void TestToAscii60ExtendedASCIIBE()
        {
            // One-half in Windows-1252
            (StringUtil.ToAscii("¾")).Should().Be(190);
        }

        #endregion


        #region XmlEncode(string) tests

        // Null and empty tests
        [Fact]
        public void TestXmlEncode1NullInput()
        {
            Action act = () => StringUtil.XmlEncode(null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestXmlEncode2EmptyString()
        {
            (StringUtil.XmlEncode("")).Should().Be("");
        }

        // No special characters tests
        [Fact]
        public void TestXmlEncode3NoSpecialChars()
        {
            (StringUtil.XmlEncode("hello")).Should().Be("hello");
        }

        [Fact]
        public void TestXmlEncode4NoSpecialCharsWithNumbers()
        {
            (StringUtil.XmlEncode("test123")).Should().Be("test123");
        }

        [Fact]
        public void TestXmlEncode5NoSpecialCharsWithSpaces()
        {
            (StringUtil.XmlEncode("hello world test")).Should().Be("hello world test");
        }

        // Ampersand tests
        [Fact]
        public void TestXmlEncode6SingleAmpersand()
        {
            (StringUtil.XmlEncode("&")).Should().Be("&#38;");
        }

        [Fact]
        public void TestXmlEncode7AmpersandAtStart()
        {
            (StringUtil.XmlEncode("&test")).Should().Be("&#38;test");
        }

        [Fact]
        public void TestXmlEncode8AmpersandAtEnd()
        {
            (StringUtil.XmlEncode("test&")).Should().Be("test&#38;");
        }

        [Fact]
        public void TestXmlEncode9AmpersandInMiddle()
        {
            (StringUtil.XmlEncode("hello&world")).Should().Be("hello&#38;world");
        }

        [Fact]
        public void TestXmlEncode10MultipleAmpersands()
        {
            (StringUtil.XmlEncode("&&&")).Should().Be("&#38;&#38;&#38;");
        }

        // Less-than tests
        [Fact]
        public void TestXmlEncode11SingleLessThan()
        {
            (StringUtil.XmlEncode("<")).Should().Be("&#60;");
        }

        [Fact]
        public void TestXmlEncode12LessThanAtStart()
        {
            (StringUtil.XmlEncode("<test")).Should().Be("&#60;test");
        }

        [Fact]
        public void TestXmlEncode13LessThanInMiddle()
        {
            (StringUtil.XmlEncode("a<b")).Should().Be("a&#60;b");
        }

        [Fact]
        public void TestXmlEncode14MultipleLessThan()
        {
            (StringUtil.XmlEncode("<<<")).Should().Be("&#60;&#60;&#60;");
        }

        // Greater-than tests
        [Fact]
        public void TestXmlEncode15SingleGreaterThan()
        {
            (StringUtil.XmlEncode(">")).Should().Be("&#62;");
        }

        [Fact]
        public void TestXmlEncode16GreaterThanAtStart()
        {
            (StringUtil.XmlEncode(">test")).Should().Be("&#62;test");
        }

        [Fact]
        public void TestXmlEncode17GreaterThanInMiddle()
        {
            (StringUtil.XmlEncode("a>b")).Should().Be("a&#62;b");
        }

        [Fact]
        public void TestXmlEncode18MultipleGreaterThan()
        {
            (StringUtil.XmlEncode(">>>")).Should().Be("&#62;&#62;&#62;");
        }

        // Double quote tests
        [Fact]
        public void TestXmlEncode19SingleDoubleQuote()
        {
            (StringUtil.XmlEncode("\"")).Should().Be("&#34;");
        }

        [Fact]
        public void TestXmlEncode20DoubleQuoteAtStart()
        {
            (StringUtil.XmlEncode("\"test")).Should().Be("&#34;test");
        }

        [Fact]
        public void TestXmlEncode21DoubleQuoteInMiddle()
        {
            (StringUtil.XmlEncode("hello\"world")).Should().Be("hello&#34;world");
        }

        [Fact]
        public void TestXmlEncode22MultipleDoubleQuotes()
        {
            (StringUtil.XmlEncode("\"\"\"")).Should().Be("&#34;&#34;&#34;");
        }

        // Equals sign tests
        [Fact]
        public void TestXmlEncode23SingleEquals()
        {
            (StringUtil.XmlEncode("=")).Should().Be("&#61;");
        }

        [Fact]
        public void TestXmlEncode24EqualsAtStart()
        {
            (StringUtil.XmlEncode("=test")).Should().Be("&#61;test");
        }

        [Fact]
        public void TestXmlEncode25EqualsInMiddle()
        {
            (StringUtil.XmlEncode("a=b")).Should().Be("a&#61;b");
        }

        // Single quote tests
        [Fact]
        public void TestXmlEncode26SingleSingleQuote()
        {
            (StringUtil.XmlEncode("'")).Should().Be("&#39;");
        }

        [Fact]
        public void TestXmlEncode27SingleQuoteAtStart()
        {
            (StringUtil.XmlEncode("'test")).Should().Be("&#39;test");
        }

        [Fact]
        public void TestXmlEncode28SingleQuoteInMiddle()
        {
            (StringUtil.XmlEncode("don't")).Should().Be("don&#39;t");
        }

        [Fact]
        public void TestXmlEncode29MultipleSingleQuotes()
        {
            (StringUtil.XmlEncode("'''")).Should().Be("&#39;&#39;&#39;");
        }

        // Newline tests
        [Fact]
        public void TestXmlEncode30SingleNewline()
        {
            (StringUtil.XmlEncode("\n")).Should().Be(" ");
        }

        [Fact]
        public void TestXmlEncode31NewlineAtStart()
        {
            (StringUtil.XmlEncode("\ntest")).Should().Be(" test");
        }

        [Fact]
        public void TestXmlEncode32NewlineInMiddle()
        {
            (StringUtil.XmlEncode("hello\nworld")).Should().Be("hello world");
        }

        [Fact]
        public void TestXmlEncode33MultipleNewlines()
        {
            (StringUtil.XmlEncode("\n\n\n")).Should().Be("   ");
        }

        // Tab tests
        [Fact]
        public void TestXmlEncode34SingleTab()
        {
            (StringUtil.XmlEncode("\t")).Should().Be(" ");
        }

        [Fact]
        public void TestXmlEncode35TabAtStart()
        {
            (StringUtil.XmlEncode("\ttest")).Should().Be(" test");
        }

        [Fact]
        public void TestXmlEncode36TabInMiddle()
        {
            (StringUtil.XmlEncode("hello\tworld")).Should().Be("hello world");
        }

        [Fact]
        public void TestXmlEncode37MultipleTabs()
        {
            (StringUtil.XmlEncode("\t\t\t")).Should().Be("   ");
        }

        // Multiple different special characters
        [Fact]
        public void TestXmlEncode38AmpersandAndLessThan()
        {
            (StringUtil.XmlEncode("&<")).Should().Be("&#38;&#60;");
        }

        [Fact]
        public void TestXmlEncode39AllSpecialChars()
        {
            (StringUtil.XmlEncode("&<>\"='")).Should().Be("&#38;&#60;&#62;&#34;&#61;&#39;");
        }

        [Fact]
        public void TestXmlEncode40MixedSpecialCharsAndNewline()
        {
            (StringUtil.XmlEncode("test&data\nworld")).Should().Be("test&#38;data world");
        }

        [Fact]
        public void TestXmlEncode41MixedSpecialCharsAndTab()
        {
            // Tab is replaced with space, then < is encoded
            (StringUtil.XmlEncode("hello<\tworld")).Should().Be("hello&#60; world");
        }

        // Real-world XML scenarios
        [Fact]
        public void TestXmlEncode42XMLTag()
        {
            (StringUtil.XmlEncode("<tag>")).Should().Be("&#60;tag&#62;");
        }

        [Fact]
        public void TestXmlEncode43XMLAttribute()
        {
            (StringUtil.XmlEncode("attr=\"value\"")).Should().Be("attr&#61;&#34;value&#34;");
        }

        [Fact]
        public void TestXmlEncode44XMLWithAmpersand()
        {
            (StringUtil.XmlEncode("A & B")).Should().Be("A &#38; B");
        }

        [Fact]
        public void TestXmlEncode45XMLComplexContent()
        {
            (StringUtil.XmlEncode("<element attr=\"val\">content</element>")).Should().Be("&#60;element attr&#61;&#34;val&#34;&#62;content&#60;/element&#62;");
        }

        // Mixed content with numbers and special characters
        [Fact]
        public void TestXmlEncode46NumbersWithAmpersand()
        {
            (StringUtil.XmlEncode("123&456")).Should().Be("123&#38;456");
        }

        [Fact]
        public void TestXmlEncode47URLWithSpecialChars()
        {
            (StringUtil.XmlEncode("http://example.com?a=1&b=2")).Should().Be("http://example.com?a&#61;1&#38;b&#61;2");
        }

        [Fact]
        public void TestXmlEncode48JSONLikeWithSpecialChars()
        {
            (StringUtil.XmlEncode("{\"key\":\"value\"}")).Should().Be("{&#34;key&#34;:&#34;value&#34;}");
        }

        #endregion


        #region ToByteArray(string) tests

        // Null and empty tests
        [Fact]
        public void TestToByteArray1NullInput()
        {
            Action act = () => StringUtil.ToByteArray(null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestToByteArray2EmptyString()
        {
            byte[] result = StringUtil.ToByteArray("");
            (result.Length).Should().Be(0);
        }

        // Single character tests
        [Fact]
        public void TestToByteArray3SingleLowerCaseLetter()
        {
            byte[] result = StringUtil.ToByteArray("a");
            (result.Length).Should().Be(1);
            (result[0]).Should().Be(97); // ASCII value of 'a'
        }

        [Fact]
        public void TestToByteArray4SingleUpperCaseLetter()
        {
            byte[] result = StringUtil.ToByteArray("A");
            (result.Length).Should().Be(1);
            (result[0]).Should().Be(65); // ASCII value of 'A'
        }

        [Fact]
        public void TestToByteArray5SingleDigit()
        {
            byte[] result = StringUtil.ToByteArray("5");
            (result.Length).Should().Be(1);
            (result[0]).Should().Be(53); // ASCII value of '5'
        }

        [Fact]
        public void TestToByteArray6SingleSpace()
        {
            byte[] result = StringUtil.ToByteArray(" ");
            (result.Length).Should().Be(1);
            (result[0]).Should().Be(32); // ASCII value of space
        }

        [Fact]
        public void TestToByteArray7SingleSymbol()
        {
            byte[] result = StringUtil.ToByteArray("!");
            (result.Length).Should().Be(1);
            (result[0]).Should().Be(33); // ASCII value of '!'
        }

        // Multiple character tests with length verification
        [Fact]
        public void TestToByteArray8TwoCharacters()
        {
            byte[] result = StringUtil.ToByteArray("ab");
            (result.Length).Should().Be(2);
            (result[0]).Should().Be(97); // 'a'
            (result[1]).Should().Be(98); // 'b'
        }

        [Fact]
        public void TestToByteArray9ThreeCharacters()
        {
            byte[] result = StringUtil.ToByteArray("abc");
            (result.Length).Should().Be(3);
            (result[0]).Should().Be(97); // 'a'
            (result[1]).Should().Be(98); // 'b'
            (result[2]).Should().Be(99); // 'c'
        }

        [Fact]
        public void TestToByteArray10AlphabetLowerCase()
        {
            byte[] result = StringUtil.ToByteArray("abcdefghijklmnopqrstuvwxyz");
            (result.Length).Should().Be(26);
        }

        [Fact]
        public void TestToByteArray11AlphabetUpperCase()
        {
            byte[] result = StringUtil.ToByteArray("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            (result.Length).Should().Be(26);
        }

        [Fact]
        public void TestToByteArray12Digits()
        {
            byte[] result = StringUtil.ToByteArray("0123456789");
            (result.Length).Should().Be(10);
            (result[0]).Should().Be(48); // '0'
            (result[9]).Should().Be(57); // '9'
        }

        // Case sensitivity tests
        [Fact]
        public void TestToByteArray13LowercaseA()
        {
            byte[] result = StringUtil.ToByteArray("a");
            (result[0]).Should().Be(97);
        }

        [Fact]
        public void TestToByteArray14UppercaseA()
        {
            byte[] result = StringUtil.ToByteArray("A");
            (result[0]).Should().Be(65);
        }

        [Fact]
        public void TestToByteArray15MixedCase()
        {
            byte[] result = StringUtil.ToByteArray("AaBbCc");
            (result.Length).Should().Be(6);
            (result[0]).Should().Be(65); // 'A'
            (result[1]).Should().Be(97); // 'a'
        }

        // Special characters tests
        [Fact]
        public void TestToByteArray16PunctuationMarks()
        {
            byte[] result = StringUtil.ToByteArray(".,!?;:");
            (result.Length).Should().Be(6);
        }

        [Fact]
        public void TestToByteArray17Symbols()
        {
            byte[] result = StringUtil.ToByteArray("@#$%^&*()");
            (result.Length).Should().Be(9);
        }

        [Fact]
        public void TestToByteArray18BracketsAndParens()
        {
            byte[] result = StringUtil.ToByteArray("[]{}()<>");
            (result.Length).Should().Be(8);
        }

        // Whitespace tests
        [Fact]
        public void TestToByteArray19SpaceCharacter()
        {
            byte[] result = StringUtil.ToByteArray(" ");
            (result.Length).Should().Be(1);
            (result[0]).Should().Be(32); // ASCII value of space
        }

        [Fact]
        public void TestToByteArray20MultipleSpaces()
        {
            byte[] result = StringUtil.ToByteArray("   ");
            (result.Length).Should().Be(3);
            (result[0]).Should().Be(32);
            (result[1]).Should().Be(32);
            (result[2]).Should().Be(32);
        }

        [Fact]
        public void TestToByteArray21TabCharacter()
        {
            byte[] result = StringUtil.ToByteArray("\t");
            (result.Length).Should().Be(1);
            (result[0]).Should().Be(9); // ASCII value of tab
        }

        [Fact]
        public void TestToByteArray22NewlineCharacter()
        {
            byte[] result = StringUtil.ToByteArray("\n");
            (result.Length).Should().Be(1);
            (result[0]).Should().Be(10); // ASCII value of newline
        }

        [Fact]
        public void TestToByteArray23CarriageReturnCharacter()
        {
            byte[] result = StringUtil.ToByteArray("\r");
            (result.Length).Should().Be(1);
            (result[0]).Should().Be(13); // ASCII value of carriage return
        }

        // Repeated characters
        [Fact]
        public void TestToByteArray24RepeatedCharacter()
        {
            byte[] result = StringUtil.ToByteArray("aaaa");
            (result.Length).Should().Be(4);
            (result[0]).Should().Be(97);
            (result[1]).Should().Be(97);
            (result[2]).Should().Be(97);
            (result[3]).Should().Be(97);
        }

        [Fact]
        public void TestToByteArray25RepeatedDigit()
        {
            byte[] result = StringUtil.ToByteArray("1111");
            (result.Length).Should().Be(4);
            (result[0]).Should().Be(49); // '1'
        }

        // Mixed content
        [Fact]
        public void TestToByteArray26AlphanumericMixed()
        {
            byte[] result = StringUtil.ToByteArray("a1b2c3");
            (result.Length).Should().Be(6);
        }

        [Fact]
        public void TestToByteArray27WordWithSpaces()
        {
            byte[] result = StringUtil.ToByteArray("hello world");
            (result.Length).Should().Be(11);
            (result[0]).Should().Be(104); // 'h'
            (result[5]).Should().Be(32); // space
            (result[6]).Should().Be(119); // 'w'
        }

        [Fact]
        public void TestToByteArray28SentenceWithPunctuation()
        {
            byte[] result = StringUtil.ToByteArray("Hello, World!");
            (result.Length).Should().Be(13);
        }

        // Longer strings
        [Fact]
        public void TestToByteArray29LongAlphabeticalString()
        {
            string longString = "abcdefghijklmnopqrstuvwxyz";
            byte[] result = StringUtil.ToByteArray(longString);
            (result.Length).Should().Be(longString.Length);
        }

        [Fact]
        public void TestToByteArray30VeryLongString()
        {
            string longString = new string('a', 1000);
            byte[] result = StringUtil.ToByteArray(longString);
            (result.Length).Should().Be(1000);
            // Verify all bytes are 'a'
            for (int i = 0; i < result.Length; i++)
            {
                (result[i]).Should().Be(97);
            }
        }

        // Numeric strings
        [Fact]
        public void TestToByteArray31NumericString()
        {
            byte[] result = StringUtil.ToByteArray("12345");
            (result.Length).Should().Be(5);
            (result[0]).Should().Be(49); // '1'
            (result[1]).Should().Be(50); // '2'
            (result[2]).Should().Be(51); // '3'
            (result[3]).Should().Be(52); // '4'
            (result[4]).Should().Be(53); // '5'
        }

        [Fact]
        public void TestToByteArray32NumericWithDecimal()
        {
            byte[] result = StringUtil.ToByteArray("3.14159");
            (result.Length).Should().Be(7);
        }

        // Special sequences
        [Fact]
        public void TestToByteArray33QuotedString()
        {
            byte[] result = StringUtil.ToByteArray("\"hello\"");
            (result.Length).Should().Be(7);
            (result[0]).Should().Be(34); // '"'
        }

        [Fact]
        public void TestToByteArray34URLLike()
        {
            byte[] result = StringUtil.ToByteArray("http://example.com");
            (result.Length).Should().Be(18);
        }

        [Fact]
        public void TestToByteArray35EmailLike()
        {
            byte[] result = StringUtil.ToByteArray("user@example.com");
            (result.Length).Should().Be(16);
        }

        // Array content verification
        [Fact]
        public void TestToByteArray36VerifyArrayContent()
        {
            byte[] result = StringUtil.ToByteArray("ABC");
            (result.Length).Should().Be(3);
            (result[0]).Should().Be(65); // 'A'
            (result[1]).Should().Be(66); // 'B'
            (result[2]).Should().Be(67); // 'C'
        }

        [Fact]
        public void TestToByteArray37VerifyNumericContent()
        {
            byte[] result = StringUtil.ToByteArray("789");
            (result.Length).Should().Be(3);
            (result[0]).Should().Be(55); // '7'
            (result[1]).Should().Be(56); // '8'
            (result[2]).Should().Be(57); // '9'
        }

        [Fact]
        public void TestToByteArray38JSONLikeString()
        {
            byte[] result = StringUtil.ToByteArray("{\"key\":\"value\"}");
            (result.Length).Should().Be(15);
        }

        [Fact]
        public void TestToByteArray39XMLLikeString()
        {
            byte[] result = StringUtil.ToByteArray("<tag>content</tag>");
            (result.Length).Should().Be(18);
        }

        [Fact]
        public void TestToByteArray40SpecialSymbolCombination()
        {
            byte[] result = StringUtil.ToByteArray("+-*/=");
            (result.Length).Should().Be(5);
            (result[0]).Should().Be(43); // '+'
            (result[1]).Should().Be(45); // '-'
        }

        [Fact]
        public void TestToByteArray41MixedWhitespace()
        {
            byte[] result = StringUtil.ToByteArray("a b\tc");
            (result.Length).Should().Be(5);
            (result[0]).Should().Be(97); // 'a'
            (result[1]).Should().Be(32); // space
            (result[2]).Should().Be(98); // 'b'
            (result[3]).Should().Be(9); // tab
            (result[4]).Should().Be(99); // 'c'
        }

        [Fact]
        public void TestToByteArray42UnderscoresAndDashes()
        {
            byte[] result = StringUtil.ToByteArray("test_name-value");
            (result.Length).Should().Be(15);
            (result[4]).Should().Be(95); // '_'
            (result[9]).Should().Be(45); // '-'
        }

        #endregion


        #region FromByteArray(byte[]) tests

        // Null and empty tests
        [Fact]
        public void TestFromByteArray1NullInput()
        {
            Action act = () => StringUtil.FromByteArray(null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestFromByteArray2EmptyArray()
        {
            string result = StringUtil.FromByteArray([]);
            (result).Should().Be("");
            (result.Length).Should().Be(0);
        }

        // Single byte tests
        [Fact]
        public void TestFromByteArray3SingleByteLowercaseA()
        {
            byte[] bytes = new byte[] { 97 }; // ASCII 'a'
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be("a");
            (result.Length).Should().Be(1);
        }

        [Fact]
        public void TestFromByteArray4SingleByteUppercaseA()
        {
            byte[] bytes = new byte[] { 65 }; // ASCII 'A'
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be("A");
        }

        [Fact]
        public void TestFromByteArray5SingleByteDigit()
        {
            byte[] bytes = new byte[] { 53 }; // ASCII '5'
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be("5");
        }

        [Fact]
        public void TestFromByteArray6SingleByteSpace()
        {
            byte[] bytes = new byte[] { 32 }; // ASCII space
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(" ");
        }

        [Fact]
        public void TestFromByteArray7SingleByteExclamation()
        {
            byte[] bytes = new byte[] { 33 }; // ASCII '!'
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be("!");
        }

        // Multiple byte tests
        [Fact]
        public void TestFromByteArray8TwoBytes()
        {
            byte[] bytes = new byte[] { 97, 98 }; // 'a', 'b'
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be("ab");
            (result.Length).Should().Be(2);
        }

        [Fact]
        public void TestFromByteArray9ThreeBytes()
        {
            byte[] bytes = new byte[] { 97, 98, 99 }; // 'a', 'b', 'c'
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be("abc");
            (result.Length).Should().Be(3);
        }

        [Fact]
        public void TestFromByteArray10LowercaseAlphabet()
        {
            byte[] bytes = new byte[] { 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122 };
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be("abcdefghijklmnopqrstuvwxyz");
            (result.Length).Should().Be(26);
        }

        [Fact]
        public void TestFromByteArray11UppercaseAlphabet()
        {
            byte[] bytes = new byte[] { 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90 };
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            (result.Length).Should().Be(26);
        }

        [Fact]
        public void TestFromByteArray12Digits()
        {
            byte[] bytes = new byte[] { 48, 49, 50, 51, 52, 53, 54, 55, 56, 57 }; // '0' through '9'
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be("0123456789");
            (result.Length).Should().Be(10);
        }

        // Case sensitivity tests
        [Fact]
        public void TestFromByteArray13MixedCase()
        {
            byte[] bytes = new byte[] { 65, 97, 66, 98, 67, 99 }; // 'A', 'a', 'B', 'b', 'C', 'c'
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be("AaBbCc");
            (result.Length).Should().Be(6);
        }

        // Special characters and punctuation
        [Fact]
        public void TestFromByteArray14PunctuationMarks()
        {
            byte[] bytes = new byte[] { 46, 44, 33, 63, 59, 58 }; // '.', ',', '!', '?', ';', ':'
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(".,!?;:");
            (result.Length).Should().Be(6);
        }

        [Fact]
        public void TestFromByteArray15CommonSymbols()
        {
            byte[] bytes = new byte[] { 64, 35, 36, 37, 94, 38, 42, 40, 41 }; // '@', '#', '$', '%', '^', '&', '*', '(', ')'
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be("@#$%^&*()");
            (result.Length).Should().Be(9);
        }

        [Fact]
        public void TestFromByteArray16BracketsAndBraces()
        {
            byte[] bytes = new byte[] { 91, 93, 123, 125, 40, 41, 60, 62 }; // '[', ']', '{', '}', '(', ')', '<', '>'
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be("[]{}()<>");
            (result.Length).Should().Be(8);
        }

        [Fact]
        public void TestFromByteArray17QuotesAndApostrophes()
        {
            byte[] bytes = new byte[] { 34, 39 }; // '"', '\''
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be("\"'");
        }

        // Whitespace tests
        [Fact]
        public void TestFromByteArray18Space()
        {
            byte[] bytes = new byte[] { 32 }; // space
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(" ");
        }

        [Fact]
        public void TestFromByteArray19MultipleSpaces()
        {
            byte[] bytes = new byte[] { 32, 32, 32 };
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be("   ");
            (result.Length).Should().Be(3);
        }

        [Fact]
        public void TestFromByteArray20TabCharacter()
        {
            byte[] bytes = new byte[] { 9 }; // ASCII tab
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be("\t");
        }

        [Fact]
        public void TestFromByteArray21NewlineCharacter()
        {
            byte[] bytes = new byte[] { 10 }; // ASCII newline
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be("\n");
        }

        [Fact]
        public void TestFromByteArray22CarriageReturnCharacter()
        {
            byte[] bytes = new byte[] { 13 }; // ASCII carriage return
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be("\r");
        }

        // Repeated bytes
        [Fact]
        public void TestFromByteArray23RepeatedCharacter()
        {
            byte[] bytes = new byte[] { 97, 97, 97, 97 }; // 'a', 'a', 'a', 'a'
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be("aaaa");
            (result.Length).Should().Be(4);
        }

        [Fact]
        public void TestFromByteArray24RepeatedDigit()
        {
            byte[] bytes = new byte[] { 49, 49, 49, 49 }; // '1', '1', '1', '1'
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be("1111");
        }

        // Mixed content
        [Fact]
        public void TestFromByteArray25AlphanumericMixed()
        {
            byte[] bytes = new byte[] { 97, 49, 98, 50, 99, 51 }; // 'a', '1', 'b', '2', 'c', '3'
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be("a1b2c3");
            (result.Length).Should().Be(6);
        }

        [Fact]
        public void TestFromByteArray26WordWithSpaces()
        {
            byte[] bytes = new byte[] { 104, 101, 108, 108, 111, 32, 119, 111, 114, 108, 100 }; // 'h', 'e', 'l', 'l', 'o', ' ', 'w', 'o', 'r', 'l', 'd'
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be("hello world");
            (result.Length).Should().Be(11);
        }

        [Fact]
        public void TestFromByteArray27SentenceWithPunctuation()
        {
            byte[] bytes = new byte[] { 72, 101, 108, 108, 111, 44, 32, 87, 111, 114, 108, 100, 33 }; // 'H', 'e', 'l', 'l', 'o', ',', ' ', 'W', 'o', 'r', 'l', 'd', '!'
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be("Hello, World!");
            (result.Length).Should().Be(13);
        }

        // Numeric strings
        [Fact]
        public void TestFromByteArray28NumericString()
        {
            byte[] bytes = new byte[] { 49, 50, 51, 52, 53 }; // '1', '2', '3', '4', '5'
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be("12345");
            (result.Length).Should().Be(5);
        }

        [Fact]
        public void TestFromByteArray29NumericWithDecimal()
        {
            byte[] bytes = new byte[] { 51, 46, 49, 52, 49, 53, 57 }; // '3', '.', '1', '4', '1', '5', '9'
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be("3.14159");
            (result.Length).Should().Be(7);
        }

        // Special sequences
        [Fact]
        public void TestFromByteArray30QuotedString()
        {
            byte[] bytes = new byte[] { 34, 104, 101, 108, 108, 111, 34 }; // '"hello"'
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be("\"hello\"");
            (result.Length).Should().Be(7);
        }

        [Fact]
        public void TestFromByteArray31URLLike()
        {
            byte[] bytes = new byte[] { 104, 116, 116, 112, 58, 47, 47, 101, 120, 97, 109, 112, 108, 101, 46, 99, 111, 109 }; // 'h', 't', 't', 'p', ':', '/', '/', 'e', 'x', 'a', 'm', 'p', 'l', 'e', '.', 'c', 'o', 'm'
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be("http://example.com");
            (result.Length).Should().Be(18);
        }

        [Fact]
        public void TestFromByteArray32EmailLike()
        {
            byte[] bytes = new byte[] { 117, 115, 101, 114, 64, 101, 120, 97, 109, 112, 108, 101, 46, 99, 111, 109 }; // 'u', 's', 'e', 'r', '@', 'e', 'x', 'a', 'm', 'p', 'l', 'e', '.', 'c', 'o', 'm'
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be("user@example.com");
            (result.Length).Should().Be(16);
        }

        // Array content verification
        [Fact]
        public void TestFromByteArray33VerifyCharacterValues()
        {
            byte[] bytes = new byte[] { 65, 66, 67 }; // 'A', 'B', 'C'
            string result = StringUtil.FromByteArray(bytes);
            (result.Length).Should().Be(3);
            (result[0]).Should().Be('A');
            (result[1]).Should().Be('B');
            (result[2]).Should().Be('C');
        }

        [Fact]
        public void TestFromByteArray34VerifyNumericCharacters()
        {
            byte[] bytes = new byte[] { 55, 56, 57 }; // '7', '8', '9'
            string result = StringUtil.FromByteArray(bytes);
            (result.Length).Should().Be(3);
            (result[0]).Should().Be('7');
            (result[1]).Should().Be('8');
            (result[2]).Should().Be('9');
        }

        [Fact]
        public void TestFromByteArray35JSONLikeString()
        {
            byte[] bytes = new byte[] { 123, 34, 107, 101, 121, 34, 58, 34, 118, 97, 108, 117, 101, 34, 125 }; // {"key":"value"}
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be("{\"key\":\"value\"}");
            (result.Length).Should().Be(15);
        }

        [Fact]
        public void TestFromByteArray36XMLLikeString()
        {
            byte[] bytes = new byte[] { 60, 116, 97, 103, 62, 99, 111, 110, 116, 101, 110, 116, 60, 47, 116, 97, 103, 62 }; // <tag>content</tag>
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be("<tag>content</tag>");
            (result.Length).Should().Be(18);
        }

        [Fact]
        public void TestFromByteArray37OperatorSymbols()
        {
            byte[] bytes = new byte[] { 43, 45, 42, 47, 61 }; // '+', '-', '*', '/', '='
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be("+-*/=");
            (result.Length).Should().Be(5);
        }

        [Fact]
        public void TestFromByteArray38MixedWhitespace()
        {
            byte[] bytes = new byte[] { 97, 32, 98, 9, 99 }; // 'a', ' ', 'b', '\t', 'c'
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be("a b\tc");
            (result.Length).Should().Be(5);
        }

        [Fact]
        public void TestFromByteArray39UnderscoresAndDashes()
        {
            byte[] bytes = new byte[] { 116, 101, 115, 116, 95, 110, 97, 109, 101, 45, 118, 97, 108, 117, 101 }; // 'test_name-value'
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be("test_name-value");
            (result.Length).Should().Be(15);
        }

        [Fact]
        public void TestFromByteArray40LongString()
        {
            byte[] bytes = new byte[1000];
            for (int i = 0; i < 1000; i++)
            {
                bytes[i] = 97; // 'a'
            }
            string result = StringUtil.FromByteArray(bytes);
            (result.Length).Should().Be(1000);
            // Verify all characters are 'a'
            for (int i = 0; i < result.Length; i++)
            {
                (result[i]).Should().Be('a');
            }
        }

        [Fact]
        public void TestFromByteArray41AllPrintableASCII()
        {
            // Test a range of printable ASCII characters (32-126)
            byte[] bytes = new byte[95]; // 95 printable ASCII characters
            for (byte b = 32; b <= 126; b++)
            {
                bytes[b - 32] = b;
            }
            string result = StringUtil.FromByteArray(bytes);
            (result.Length).Should().Be(95);
            // Verify first and last
            (result[0]).Should().Be(' '); // space (32)
            (result[94]).Should().Be('~'); // tilde (126)
        }

        [Fact]
        public void TestFromByteArray42RoundTripConversion()
        {
            // Test that ToByteArray and FromByteArray are inverses
            string original = "Hello, World! 123";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        #endregion


        #region ToByteArray / FromByteArray round-trip tests

        [Fact]
        public void TestRoundTrip1EmptyString()
        {
            string original = "";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip2SingleCharacterLowercase()
        {
            string original = "a";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
            (result).Should().Be("a");
        }

        [Fact]
        public void TestRoundTrip3SingleCharacterUppercase()
        {
            string original = "Z";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip4SingleDigit()
        {
            string original = "7";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip5SingleSpecialCharacter()
        {
            string original = "!";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip6SimpleWord()
        {
            string original = "hello";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip7TwoWords()
        {
            string original = "hello world";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip8SentenceWithPunctuation()
        {
            string original = "Hello, World!";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip9MixedCase()
        {
            string original = "CamelCase";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip10AlphanumericString()
        {
            string original = "abc123xyz";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip11WithNumbers()
        {
            string original = "The year is 2024";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip12WithDecimal()
        {
            string original = "3.14159";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip13AllLowercaseAlphabet()
        {
            string original = "abcdefghijklmnopqrstuvwxyz";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip14AllUppercaseAlphabet()
        {
            string original = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip15AllDigits()
        {
            string original = "0123456789";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip16WithSpaces()
        {
            string original = "a b c d e";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip17WithMultipleSpaces()
        {
            string original = "word1   word2";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip18WithTab()
        {
            string original = "column1\tcolumn2";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip19WithNewline()
        {
            string original = "line1\nline2";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip20WithCarriageReturn()
        {
            string original = "line1\rline2";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip21WithMultipleWhitespaceTypes()
        {
            string original = "a b\tc\r\nd";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip22Punctuation()
        {
            string original = ".,!?;:";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip23CommonSymbols()
        {
            string original = "@#$%^&*()";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip24Brackets()
        {
            string original = "[]{}()<>";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip25Quotes()
        {
            string original = "\"hello\"";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip26Apostrophes()
        {
            string original = "'world'";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip27MixedQuotes()
        {
            string original = "\"It's a test\"";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip28OperatorSymbols()
        {
            string original = "+-*/=";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip29UnderscoreAndDash()
        {
            string original = "test_name-value";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip30URLString()
        {
            string original = "http://example.com";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip31EmailString()
        {
            string original = "user@example.com";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip32FilePathStyle()
        {
            string original = "C:\\Users\\Test\\file.txt";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip33JSONData()
        {
            string original = "{\"key\":\"value\"}";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip34XMLData()
        {
            string original = "<tag>content</tag>";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip35ComplexSentence()
        {
            string original = "The quick brown fox jumps over the lazy dog!";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip36MixedContentString()
        {
            string original = "Test@123 with-symbols_and MIXED Case!";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip37CodeLikeString()
        {
            string original = "public void Method(int x) { return x + 1; }";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip38CSVLine()
        {
            string original = "Name,Age,City,Email";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip39SQLStatementFragment()
        {
            string original = "SELECT * FROM users WHERE id=123;";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
        }

        [Fact]
        public void TestRoundTrip40LongString()
        {
            string original = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
            (result.Length).Should().Be(62);
        }

        [Fact]
        public void TestRoundTrip41VeryLongRepeatedString()
        {
            string original = new string('x', 500);
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
            (result.Length).Should().Be(500);
        }

        [Fact]
        public void TestRoundTrip42AllPrintableASCIICharacters()
        {
            // Build a string with all printable ASCII characters (32-126)
            string original = "";
            for (char c = (char)32; c <= (char)126; c++)
            {
                original += c;
            }
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            (result).Should().Be(original);
            (result.Length).Should().Be(95);
        }

        #endregion


        #region AppendSpaces(string, int) tests

        // Null input tests
        [Fact]
        public void TestAppendSpaces1NullInput()
        {
            Action act = () => StringUtil.AppendSpaces(null, 10);
            act.Should().Throw<ArgumentNullException>();
        }

        // Empty string tests
        [Fact]
        public void TestAppendSpaces2EmptyStringWithZeroLength()
        {
            string result = StringUtil.AppendSpaces("", 0);
            (result).Should().Be("");
            (result.Length).Should().Be(0);
        }

        [Fact]
        public void TestAppendSpaces3EmptyStringWithPositiveLength()
        {
            string result = StringUtil.AppendSpaces("", 5);
            (result).Should().Be("     ");
            (result.Length).Should().Be(5);
        }

        [Fact]
        public void TestAppendSpaces4EmptyStringWithLargeLength()
        {
            string result = StringUtil.AppendSpaces("", 20);
            (result.Length).Should().Be(20);
            // Verify all spaces
            for (int i = 0; i < result.Length; i++)
            {
                (result[i]).Should().Be(' ');
            }
        }

        // No padding needed tests (string already meets or exceeds length)
        [Fact]
        public void TestAppendSpaces5StringExactLength()
        {
            string result = StringUtil.AppendSpaces("hello", 5);
            (result).Should().Be("hello");
            (result.Length).Should().Be(5);
        }

        [Fact]
        public void TestAppendSpaces6StringLongerThanTarget()
        {
            string result = StringUtil.AppendSpaces("hello", 3);
            (result).Should().Be("hello");
            (result.Length).Should().Be(5);
        }

        [Fact]
        public void TestAppendSpaces7StringMuchLongerThanTarget()
        {
            string result = StringUtil.AppendSpaces("supercalifragilisticexpialidocious", 10);
            (result).Should().Be("supercalifragilisticexpialidocious");
            (result.Length).Should().Be(34);
        }

        // Padding required tests - single character
        [Fact]
        public void TestAppendSpaces8SingleCharPaddedToTwo()
        {
            string result = StringUtil.AppendSpaces("a", 2);
            (result).Should().Be("a ");
            (result.Length).Should().Be(2);
        }

        [Fact]
        public void TestAppendSpaces9SingleCharPaddedToTen()
        {
            string result = StringUtil.AppendSpaces("x", 10);
            (result).Should().Be("x         ");
            (result.Length).Should().Be(10);
        }

        // Padding required tests - multiple characters
        [Fact]
        public void TestAppendSpaces10TwoCharPaddedToFour()
        {
            string result = StringUtil.AppendSpaces("hi", 4);
            (result).Should().Be("hi  ");
            (result.Length).Should().Be(4);
        }

        [Fact]
        public void TestAppendSpaces11ThreeCharPaddedToEight()
        {
            string result = StringUtil.AppendSpaces("cat", 8);
            (result).Should().Be("cat     ");
            (result.Length).Should().Be(8);
        }

        [Fact]
        public void TestAppendSpaces12FiveCharPaddedToTen()
        {
            string result = StringUtil.AppendSpaces("hello", 10);
            (result).Should().Be("hello     ");
            (result.Length).Should().Be(10);
        }

        // Padding required tests - various lengths
        [Fact]
        public void TestAppendSpaces13PaddingByOne()
        {
            string result = StringUtil.AppendSpaces("test", 5);
            (result).Should().Be("test ");
            (result.Length).Should().Be(5);
        }

        [Fact]
        public void TestAppendSpaces14PaddingByThree()
        {
            string result = StringUtil.AppendSpaces("word", 7);
            (result).Should().Be("word   ");
            (result.Length).Should().Be(7);
        }

        [Fact]
        public void TestAppendSpaces15PaddingByFive()
        {
            string result = StringUtil.AppendSpaces("go", 7);
            (result).Should().Be("go     ");
            (result.Length).Should().Be(7);
        }

        // Word and sentence padding
        [Fact]
        public void TestAppendSpaces16SingleWordPadding()
        {
            string result = StringUtil.AppendSpaces("apple", 15);
            (result).Should().Be("apple          ");
            (result.Length).Should().Be(15);
        }

        [Fact]
        public void TestAppendSpaces17TwoWordsPadding()
        {
            string result = StringUtil.AppendSpaces("hello world", 20);
            (result).Should().Be("hello world         ");
            (result.Length).Should().Be(20);
        }

        [Fact]
        public void TestAppendSpaces18SentencePadding()
        {
            string result = StringUtil.AppendSpaces("Hello, World!", 25);
            (result).Should().Be("Hello, World!            ");
            (result.Length).Should().Be(25);
        }

        // Special characters and symbols
        [Fact]
        public void TestAppendSpaces19WithNumberPadding()
        {
            string result = StringUtil.AppendSpaces("123", 8);
            (result).Should().Be("123     ");
            (result.Length).Should().Be(8);
        }

        [Fact]
        public void TestAppendSpaces20WithSymbolsPadding()
        {
            string result = StringUtil.AppendSpaces("@#$", 10);
            (result).Should().Be("@#$       ");
            (result.Length).Should().Be(10);
        }

        [Fact]
        public void TestAppendSpaces21WithMixedContentPadding()
        {
            string result = StringUtil.AppendSpaces("abc123!@#", 15);
            (result).Should().Be("abc123!@#      ");
            (result.Length).Should().Be(15);
        }

        // Edge cases with specific target lengths
        [Fact]
        public void TestAppendSpaces22StringLengthOne()
        {
            string result = StringUtil.AppendSpaces("a", 1);
            (result).Should().Be("a");
            (result.Length).Should().Be(1);
        }

        [Fact]
        public void TestAppendSpaces23TargetLengthOne()
        {
            string result = StringUtil.AppendSpaces("", 1);
            (result).Should().Be(" ");
            (result.Length).Should().Be(1);
        }

        [Fact]
        public void TestAppendSpaces24LargeTargetLength()
        {
            string result = StringUtil.AppendSpaces("hi", 100);
            (result.Length).Should().Be(100);
            (result.Substring(0, 2)).Should().Be("hi");
            // Verify all remaining characters are spaces
            for (int i = 2; i < result.Length; i++)
            {
                (result[i]).Should().Be(' ');
            }
        }

        // Verification of padding character
        [Fact]
        public void TestAppendSpaces25VerifyPaddingCharacter()
        {
            string result = StringUtil.AppendSpaces("test", 10);
            for (int i = 4; i < 10; i++)
            {
                (result[i]).Should().Be(' ');
            }
        }

        [Fact]
        public void TestAppendSpaces26VerifyOriginalContentPreserved()
        {
            string result = StringUtil.AppendSpaces("hello", 15);
            (result.Substring(0, 5)).Should().Be("hello");
        }

        // Case sensitivity preservation
        [Fact]
        public void TestAppendSpaces27LowercasePreserved()
        {
            string result = StringUtil.AppendSpaces("abc", 10);
            (result.Substring(0, 3)).Should().Be("abc");
            for (int i = 0; i < 3; i++)
            {
                (char.IsLower(result[i])).Should().BeTrue();
            }
        }

        [Fact]
        public void TestAppendSpaces28UppercasePreserved()
        {
            string result = StringUtil.AppendSpaces("ABC", 10);
            (result.Substring(0, 3)).Should().Be("ABC");
            for (int i = 0; i < 3; i++)
            {
                (char.IsUpper(result[i])).Should().BeTrue();
            }
        }

        [Fact]
        public void TestAppendSpaces29MixedCasePreserved()
        {
            string result = StringUtil.AppendSpaces("CamelCase", 15);
            (result.Substring(0, 9)).Should().Be("CamelCase");
        }

        // Whitespace in original strings
        [Fact]
        public void TestAppendSpaces30StringWithSpaces()
        {
            string result = StringUtil.AppendSpaces("hello world", 20);
            (result).Should().Be("hello world         ");
            (result.Length).Should().Be(20);
        }

        [Fact]
        public void TestAppendSpaces31StringWithTab()
        {
            string result = StringUtil.AppendSpaces("col1\tcol2", 15);
            (result).Should().Be("col1\tcol2      ");
            (result.Length).Should().Be(15);
        }

        [Fact]
        public void TestAppendSpaces32StringWithLeadingSpace()
        {
            string result = StringUtil.AppendSpaces(" hello", 12);
            (result).Should().Be(" hello      ");
            (result.Length).Should().Be(12);
        }

        [Fact]
        public void TestAppendSpaces33StringWithTrailingSpace()
        {
            string result = StringUtil.AppendSpaces("hello ", 12);
            (result).Should().Be("hello       ");
            (result.Length).Should().Be(12);
        }

        // Numeric padding values
        [Fact]
        public void TestAppendSpaces34SmallStringLargeTargetLength()
        {
            string result = StringUtil.AppendSpaces("x", 50);
            (result.Length).Should().Be(50);
            (result.Substring(0, 1)).Should().Be("x");
        }

        [Fact]
        public void TestAppendSpaces35MediumStringMediumTargetLength()
        {
            string result = StringUtil.AppendSpaces("medium", 20);
            (result).Should().Be("medium              ");
            (result.Length).Should().Be(20);
        }

        // Specific real-world scenarios
        [Fact]
        public void TestAppendSpaces36NamePadding()
        {
            string result = StringUtil.AppendSpaces("John", 20);
            (result).Should().Be("John                ");
            (result.Length).Should().Be(20);
        }

        [Fact]
        public void TestAppendSpaces37AddressPadding()
        {
            string result = StringUtil.AppendSpaces("123 Main St", 30);
            (result.Length).Should().Be(30);
            (result.Substring(0, 11)).Should().Be("123 Main St");
        }

        [Fact]
        public void TestAppendSpaces38PhoneNumberPadding()
        {
            string result = StringUtil.AppendSpaces("555-1234", 15);
            (result).Should().Be("555-1234       ");
            (result.Length).Should().Be(15);
        }

        [Fact]
        public void TestAppendSpaces39EmailPadding()
        {
            string result = StringUtil.AppendSpaces("user@example.com", 25);
            (result).Should().Be("user@example.com         ");
            (result.Length).Should().Be(25);
        }

        [Fact]
        public void TestAppendSpaces40AlphanumericPadding()
        {
            string result = StringUtil.AppendSpaces("ABC123", 12);
            (result).Should().Be("ABC123      ");
            (result.Length).Should().Be(12);
        }

        [Fact]
        public void TestAppendSpaces41SymbolsAndNumbersPadding()
        {
            string result = StringUtil.AppendSpaces("#123-456", 20);
            (result).Should().Be("#123-456            ");
            (result.Length).Should().Be(20);
        }

        [Fact]
        public void TestAppendSpaces42VeryLongStringWithSmallTarget()
        {
            string result = StringUtil.AppendSpaces("This is a very long string with many characters", 10);
            (result).Should().Be("This is a very long string with many characters");
            // No padding should occur
            (result.Length).Should().Be(47);
        }

        #endregion


        #region GetCountOf(string ,string) tests

        // Null input tests
        [Fact]
        public void TestGetCountOf1NullSource()
        {
            Action act = () => StringUtil.GetCountOf(null, "test");
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestGetCountOf2NullTarget()
        {
            Action act = () => StringUtil.GetCountOf("test", null);
            act.Should().Throw<ArgumentNullException>();
        }

        // Empty string tests
        [Fact]
        public void TestGetCountOf3EmptySourceEmptyTarget()
        {
            Action act = () => StringUtil.GetCountOf("", "");
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TestGetCountOf4EmptySourceNonEmptyTarget()
        {
            int result = StringUtil.GetCountOf("", "test");
            (result).Should().Be(0);
        }

        [Fact]
        public void TestGetCountOf5NonEmptySourceEmptyTarget()
        {
            Action act = () => StringUtil.GetCountOf("hello", "");
            act.Should().Throw<ArgumentException>();
        }

        // Simple single occurrence tests
        [Fact]
        public void TestGetCountOf6SingleCharSingleOccurrence()
        {
            int result = StringUtil.GetCountOf("a", "a");
            (result).Should().Be(1);
        }

        [Fact]
        public void TestGetCountOf7SingleCharNoOccurrence()
        {
            int result = StringUtil.GetCountOf("a", "b");
            (result).Should().Be(0);
        }

        [Fact]
        public void TestGetCountOf8WordSingleOccurrence()
        {
            int result = StringUtil.GetCountOf("hello", "hello");
            (result).Should().Be(1);
        }

        [Fact]
        public void TestGetCountOf9WordNoOccurrence()
        {
            int result = StringUtil.GetCountOf("hello", "world");
            (result).Should().Be(0);
        }

        // Multiple occurrences tests
        [Fact]
        public void TestGetCountOf10SingleCharTwoOccurrences()
        {
            int result = StringUtil.GetCountOf("aa", "a");
            (result).Should().Be(2);
        }

        [Fact]
        public void TestGetCountOf11SingleCharThreeOccurrences()
        {
            int result = StringUtil.GetCountOf("aaa", "a");
            (result).Should().Be(3);
        }

        [Fact]
        public void TestGetCountOf12SingleCharManyOccurrences()
        {
            int result = StringUtil.GetCountOf("aaaaaaaaaa", "a");
            (result).Should().Be(10);
        }

        [Fact]
        public void TestGetCountOf13TwoCharPatternMultipleOccurrences()
        {
            int result = StringUtil.GetCountOf("ababab", "ab");
            (result).Should().Be(3);
        }

        [Fact]
        public void TestGetCountOf14WordPatternMultipleOccurrences()
        {
            int result = StringUtil.GetCountOf("testtest", "test");
            (result).Should().Be(2);
        }

        // Case sensitivity tests
        [Fact]
        public void TestGetCountOf15CaseSensitiveLowercase()
        {
            int result = StringUtil.GetCountOf("hello", "hello");
            (result).Should().Be(1);
        }

        [Fact]
        public void TestGetCountOf16CaseSensitiveUppercase()
        {
            int result = StringUtil.GetCountOf("HELLO", "HELLO");
            (result).Should().Be(1);
        }

        [Fact]
        public void TestGetCountOf17CaseSensitiveMixedSource()
        {
            int result = StringUtil.GetCountOf("HeLLo", "LL");
            (result).Should().Be(1);
        }

        [Fact]
        public void TestGetCountOf18CaseSensitiveDifferentCase()
        {
            int result = StringUtil.GetCountOf("hello", "HELLO");
            (result).Should().Be(0);
        }

        [Fact]
        public void TestGetCountOf19CaseSensitivePartialMismatch()
        {
            int result = StringUtil.GetCountOf("HeLLo", "hello");
            (result).Should().Be(0);
        }

        // Substring tests
        [Fact]
        public void TestGetCountOf20SubstringAtBeginning()
        {
            int result = StringUtil.GetCountOf("hello world", "hello");
            (result).Should().Be(1);
        }

        [Fact]
        public void TestGetCountOf21SubstringAtEnd()
        {
            int result = StringUtil.GetCountOf("hello world", "world");
            (result).Should().Be(1);
        }

        [Fact]
        public void TestGetCountOf22SubstringInMiddle()
        {
            int result = StringUtil.GetCountOf("hello world", "lo wo");
            (result).Should().Be(1);
        }

        [Fact]
        public void TestGetCountOf23MultipleSubstringOccurrences()
        {
            int result = StringUtil.GetCountOf("the cat and the dog and the bird", "the");
            (result).Should().Be(3);
        }

        // Non-overlapping occurrence tests (important for this implementation)
        [Fact]
        public void TestGetCountOf24NonOverlappingPattern()
        {
            int result = StringUtil.GetCountOf("aabbaa", "aa");
            (result).Should().Be(2);
        }

        [Fact]
        public void TestGetCountOf25PotentiallyOverlappingPattern()
        {
            int result = StringUtil.GetCountOf("aaa", "aa");
            (result).Should().Be(1); // Non-overlapping: matches first "aa", then index advances to 2, "a" left doesn't match
        }

        [Fact]
        public void TestGetCountOf26OverlappingPotentialAtEnd()
        {
            int result = StringUtil.GetCountOf("aaaa", "aa");
            (result).Should().Be(2); // Non-overlapping: first "aa" at 0, second "aa" at 2
        }

        [Fact]
        public void TestGetCountOf27ComplexNonOverlappingPattern()
        {
            int result = StringUtil.GetCountOf("abababab", "ab");
            (result).Should().Be(4);
        }

        // Pattern at different positions
        [Fact]
        public void TestGetCountOf28PatternRepeatedConsecutively()
        {
            int result = StringUtil.GetCountOf("testingtesting", "testing");
            (result).Should().Be(2);
        }

        [Fact]
        public void TestGetCountOf29PatternSeparatedBySpaces()
        {
            int result = StringUtil.GetCountOf("cat cat cat", "cat");
            (result).Should().Be(3);
        }

        [Fact]
        public void TestGetCountOf30PatternWithSpaces()
        {
            int result = StringUtil.GetCountOf("hello world hello world", "hello world");
            (result).Should().Be(2);
        }

        // Digit and number tests
        [Fact]
        public void TestGetCountOf31SingleDigit()
        {
            int result = StringUtil.GetCountOf("12121212", "1");
            (result).Should().Be(4);
        }

        [Fact]
        public void TestGetCountOf32MultiDigitPattern()
        {
            int result = StringUtil.GetCountOf("123123123", "123");
            (result).Should().Be(3);
        }

        [Fact]
        public void TestGetCountOf33NumberInText()
        {
            int result = StringUtil.GetCountOf("abc123def123ghi", "123");
            (result).Should().Be(2);
        }

        // Special characters tests
        [Fact]
        public void TestGetCountOf34SpecialCharacter()
        {
            int result = StringUtil.GetCountOf("a.b.c.d", ".");
            (result).Should().Be(3);
        }

        [Fact]
        public void TestGetCountOf35MultipleSpecialCharacters()
        {
            int result = StringUtil.GetCountOf("@#$@#$", "@#");
            (result).Should().Be(2);
        }

        [Fact]
        public void TestGetCountOf36Hyphen()
        {
            int result = StringUtil.GetCountOf("123-456-789", "-");
            (result).Should().Be(2);
        }

        // Whitespace tests
        [Fact]
        public void TestGetCountOf37Space()
        {
            int result = StringUtil.GetCountOf("hello world test", " ");
            (result).Should().Be(2);
        }

        [Fact]
        public void TestGetCountOf38MultipleSpaces()
        {
            int result = StringUtil.GetCountOf("hello  world  test", "  ");
            (result).Should().Be(2);
        }

        [Fact]
        public void TestGetCountOf39Tab()
        {
            int result = StringUtil.GetCountOf("col1\tcol2\tcol3", "\t");
            (result).Should().Be(2);
        }

        // Edge cases with target length
        [Fact]
        public void TestGetCountOf40TargetLongerThanSource()
        {
            int result = StringUtil.GetCountOf("cat", "catastrophe");
            (result).Should().Be(0);
        }

        [Fact]
        public void TestGetCountOf41TargetEqualToSource()
        {
            int result = StringUtil.GetCountOf("exact", "exact");
            (result).Should().Be(1);
        }

        [Fact]
        public void TestGetCountOf42SingleCharTargetInLongString()
        {
            int result = StringUtil.GetCountOf("abcdefghijklmnopqrstuvwxyz", "e");
            (result).Should().Be(1);
        }

        [Fact]
        public void TestGetCountOf43MultiCharTargetInLongString()
        {
            int result = StringUtil.GetCountOf("The quick brown fox jumps over the lazy dog", "the");
            (result).Should().Be(1); // Case sensitive, finds lowercase "the" in "the lazy dog"
        }

        [Fact]
        public void TestGetCountOf44MultiCharTargetInLongStringCaseSensitive()
        {
            int result = StringUtil.GetCountOf("The quick brown fox jumps over the lazy dog", "The");
            (result).Should().Be(1); // Only one "The" at beginning
        }

        // Real-world scenarios
        [Fact]
        public void TestGetCountOf45URLCount()
        {
            int result = StringUtil.GetCountOf("http://example.com http://test.com", "http://");
            (result).Should().Be(2);
        }

        [Fact]
        public void TestGetCountOf46EmailDomainCount()
        {
            int result = StringUtil.GetCountOf("user1@example.com user2@example.com", "@example.com");
            (result).Should().Be(2);
        }

        [Fact]
        public void TestGetCountOf47CSVValueCount()
        {
            int result = StringUtil.GetCountOf("a,b,c,d,e", ",");
            (result).Should().Be(4);
        }

        [Fact]
        public void TestGetCountOf48SQLKeywordCount()
        {
            int result = StringUtil.GetCountOf("SELECT * FROM table WHERE SELECT id FROM", "SELECT");
            (result).Should().Be(2);
        }

        [Fact]
        public void TestGetCountOf49FilePathCount()
        {
            int result = StringUtil.GetCountOf("C:\\Users\\Test\\Documents\\file.txt", "\\");
            (result).Should().Be(4);
        }

        [Fact]
        public void TestGetCountOf50WordCountInSentence()
        {
            int result = StringUtil.GetCountOf("the cat sat on the mat the dog ran", " the ");
            (result).Should().Be(2); // " the " (with spaces) appears twice: "on the " and "mat the "
        }

        #endregion


        #region SqueezeNumber() tests

        [Fact]
        public void TestSqueezeNumber1()
        {
            (StringUtil.SqueezeNumber(9999999999, 5)).Should().Be("1.00E+10");
        }

        [Fact]
        public void TestSqueezeNumber2()
        {
            (StringUtil.SqueezeNumber(9999999999, 12)).Should().Be("1.00E+10");
        }

        [Fact]
        public void TestSqueezeNumber3()
        {
            (StringUtil.SqueezeNumber(9999999999, 13)).Should().Be("9,999,999,999");
        }

        [Fact]
        public void TestSqueezeNumber4()
        {
            (StringUtil.SqueezeNumber(9999999999, 20)).Should().Be("9,999,999,999");
        }

        [Fact]
        public void TestSqueezeNumberWithNegativeNumbersThatFit()
        {
            (StringUtil.SqueezeNumber(-123, 10)).Should().Be("-123");
        }

        [Fact]
        public void TestSqueezeNumberWithNegativeNumbersThatFitLarge()
        {
            (StringUtil.SqueezeNumber(-1234567, 15)).Should().Be("-1,234,567");
        }

        [Fact]
        public void TestSqueezeNumberWithNegativeNumbersRequiringScientificNotation()
        {
            (StringUtil.SqueezeNumber(-9999999999, 5)).Should().Be("-1.00E+10");
        }

        [Fact]
        public void TestSqueezeNumberWithNegativeNumbersRequiringScientificNotationLarge()
        {
            (StringUtil.SqueezeNumber(-9999999999, 12)).Should().Be("-1.00E+10");
        }

        [Fact]
        public void TestSqueezeNumberWithZero()
        {
            (StringUtil.SqueezeNumber(0, 5)).Should().Be("0");
        }

        [Fact]
        public void TestSqueezeNumberWithZeroSmallLength()
        {
            (StringUtil.SqueezeNumber(0, 1)).Should().Be("0");
        }

        [Fact]
        public void TestSqueezeNumberWithSmallDecimals()
        {
            (StringUtil.SqueezeNumber(0.123, 10)).Should().Be("0");
        }

        [Fact]
        public void TestSqueezeNumberWithSmallDecimalsSmallLength()
        {
            (StringUtil.SqueezeNumber(0.123, 4)).Should().Be("0");
        }

        [Fact]
        public void TestSqueezeNumberWithVerySmallNumbers()
        {
            (StringUtil.SqueezeNumber(0.000000000123, 5)).Should().Be("0");
        }

        [Fact]
        public void TestSqueezeNumberWithDoubles()
        {
            (StringUtil.SqueezeNumber(123.456, 10)).Should().Be("123");
        }

        [Fact]
        public void TestSqueezeNumberWithDoublesSmallLength()
        {
            (StringUtil.SqueezeNumber(123.456, 4)).Should().Be("123");
        }

        [Fact]
        public void TestSqueezeNumberWithFloats()
        {
            (StringUtil.SqueezeNumber(456.789f, 10)).Should().Be("457");
        }

        [Fact]
        public void TestSqueezeNumberWithDecimals()
        {
            (StringUtil.SqueezeNumber(789.123m, 10)).Should().Be("789");
        }

        [Fact]
        public void TestSqueezeNumberWithLongs()
        {
            (StringUtil.SqueezeNumber(1000000L, 10)).Should().Be("1,000,000");
        }

        [Fact]
        public void TestSqueezeNumberWithLongsRequiringScientificNotation()
        {
            (StringUtil.SqueezeNumber(1000000000000000L, 5)).Should().Be("1.00E+15");
        }

        [Fact]
        public void TestSqueezeNumberWithVeryLargeNumbers()
        {
            (StringUtil.SqueezeNumber(100000000000000000000d, 5)).Should().Be("1.00E+20");
        }


        [Fact]
        public void TestSqueezeNumberENotation1()
        {
            (StringUtil.SqueezeNumber(9999999999, 5, ScientificNotationFormat.Exponential)).Should().Be("1.00E+10");
        }

        [Fact]
        public void TestSqueezeNumberENotation2()
        {
            (StringUtil.SqueezeNumber(9999999999, 12, ScientificNotationFormat.Exponential)).Should().Be("1.00E+10");
        }

        [Fact]
        public void TestSqueezeNumberENotation3()
        {
            (StringUtil.SqueezeNumber(9999999999, 13, ScientificNotationFormat.Exponential)).Should().Be("9,999,999,999");
        }

        [Fact]
        public void TestSqueezeNumberENotation4()
        {
            (StringUtil.SqueezeNumber(9999999999, 20, ScientificNotationFormat.Exponential)).Should().Be("9,999,999,999");
        }

         [Fact]
         public void TestSqueezeNumberENotationWithNegativeNumbersThatFit()
         {
             (StringUtil.SqueezeNumber(-123, 10, ScientificNotationFormat.Exponential)).Should().Be("-123");
         }

         [Fact]
         public void TestSqueezeNumberENotationWithNegativeNumbersThatFitLarge()
         {
             (StringUtil.SqueezeNumber(-1234567, 15, ScientificNotationFormat.Exponential)).Should().Be("-1,234,567");
         }

         [Fact]
         public void TestSqueezeNumberENotationWithNegativeNumbersRequiringScientificNotation()
         {
             (StringUtil.SqueezeNumber(-9999999999, 5, ScientificNotationFormat.Exponential)).Should().Be("-1.00E+10");
         }

         [Fact]
         public void TestSqueezeNumberENotationWithNegativeNumbersRequiringScientificNotationLarge()
         {
             (StringUtil.SqueezeNumber(-9999999999, 12, ScientificNotationFormat.Exponential)).Should().Be("-1.00E+10");
         }

         [Fact]
         public void TestSqueezeNumberENotationWithZero()
         {
             (StringUtil.SqueezeNumber(0, 5, ScientificNotationFormat.Exponential)).Should().Be("0");
         }

         [Fact]
         public void TestSqueezeNumberENotationWithSmallDecimals()
         {
             (StringUtil.SqueezeNumber(0.123, 10, ScientificNotationFormat.Exponential)).Should().Be("0");
         }

         [Fact]
         public void TestSqueezeNumberENotationWithSmallDecimalsSmallLength()
         {
             (StringUtil.SqueezeNumber(0.123, 4, ScientificNotationFormat.Exponential)).Should().Be("0");
         }

         [Fact]
         public void TestSqueezeNumberENotationWithVerySmallNumbers()
         {
             (StringUtil.SqueezeNumber(0.000000000123, 5, ScientificNotationFormat.Exponential)).Should().Be("0");
         }

         [Fact]
         public void TestSqueezeNumberENotationWithDoubles()
         {
             (StringUtil.SqueezeNumber(123.456, 10, ScientificNotationFormat.Exponential)).Should().Be("123");
         }

         [Fact]
         public void TestSqueezeNumberENotationWithDoublesSmallLength()
         {
             (StringUtil.SqueezeNumber(123.456, 4, ScientificNotationFormat.Exponential)).Should().Be("123");
         }

         [Fact]
         public void TestSqueezeNumberENotationWithFloats()
         {
             (StringUtil.SqueezeNumber(456.789f, 10, ScientificNotationFormat.Exponential)).Should().Be("457");
         }

         [Fact]
         public void TestSqueezeNumberENotationWithDecimals()
         {
             (StringUtil.SqueezeNumber(789.123m, 10, ScientificNotationFormat.Exponential)).Should().Be("789");
         }

         [Fact]
         public void TestSqueezeNumberENotationWithLongs()
         {
             (StringUtil.SqueezeNumber(1000000L, 10, ScientificNotationFormat.Exponential)).Should().Be("1,000,000");
         }

         [Fact]
         public void TestSqueezeNumberENotationWithLongsRequiringScientificNotation()
         {
             (StringUtil.SqueezeNumber(1000000000000000L, 5, ScientificNotationFormat.Exponential)).Should().Be("1.00E+15");
         }


        [Fact]
        public void TestSqueezeNumberBase101()
        {
            (StringUtil.SqueezeNumber(9999999999, 5, ScientificNotationFormat.Base10)).Should().Be("1.00x10^10");
        }

        [Fact]
        public void TestSqueezeNumberBase102()
        {
            (StringUtil.SqueezeNumber(9999999999, 12, ScientificNotationFormat.Base10)).Should().Be("1.00x10^10");
        }

        [Fact]
        public void TestSqueezeNumberBase103()
        {
            (StringUtil.SqueezeNumber(9999999999, 13, ScientificNotationFormat.Base10)).Should().Be("9,999,999,999");
        }

        [Fact]
        public void TestSqueezeNumberBase104()
        {
            (StringUtil.SqueezeNumber(9999999999, 20, ScientificNotationFormat.Base10)).Should().Be("9,999,999,999");
        }

        [Fact]
        public void TestSqueezeNumberBase10WithNegativeNumbersThatFit()
        {
            (StringUtil.SqueezeNumber(-123, 10, ScientificNotationFormat.Base10)).Should().Be("-123");
        }

        [Fact]
        public void TestSqueezeNumberBase10WithNegativeNumbersThatFitLarge()
        {
            (StringUtil.SqueezeNumber(-1234567, 15, ScientificNotationFormat.Base10)).Should().Be("-1,234,567");
        }

        [Fact]
        public void TestSqueezeNumberBase10WithNegativeNumbersRequiringScientificNotation()
        {
            (StringUtil.SqueezeNumber(-9999999999, 5, ScientificNotationFormat.Base10)).Should().Be("-1.00x10^10");
        }

        [Fact]
        public void TestSqueezeNumberBase10WithNegativeNumbersRequiringScientificNotationLarge()
        {
            (StringUtil.SqueezeNumber(-9999999999, 12, ScientificNotationFormat.Base10)).Should().Be("-1.00x10^10");
        }

        [Fact]
        public void TestSqueezeNumberBase10WithZero()
        {
            (StringUtil.SqueezeNumber(0, 5, ScientificNotationFormat.Base10)).Should().Be("0");
        }

        [Fact]
        public void TestSqueezeNumberBase10WithSmallDecimals()
        {
            (StringUtil.SqueezeNumber(0.123, 10, ScientificNotationFormat.Base10)).Should().Be("0");
        }

        [Fact]
        public void TestSqueezeNumberBase10WithSmallDecimalsSmallLength()
        {
            (StringUtil.SqueezeNumber(0.123, 4, ScientificNotationFormat.Base10)).Should().Be("0");
        }

        [Fact]
        public void TestSqueezeNumberBase10WithVerySmallNumbers()
        {
            (StringUtil.SqueezeNumber(0.000000000123, 5, ScientificNotationFormat.Base10)).Should().Be("0");
        }

        [Fact]
        public void TestSqueezeNumberBase10WithDoubles()
        {
            (StringUtil.SqueezeNumber(123.456, 10, ScientificNotationFormat.Base10)).Should().Be("123");
        }

        [Fact]
        public void TestSqueezeNumberBase10WithDoublesSmallLength()
        {
            (StringUtil.SqueezeNumber(123.456, 4, ScientificNotationFormat.Base10)).Should().Be("123");
        }

        [Fact]
        public void TestSqueezeNumberBase10WithFloats()
        {
            (StringUtil.SqueezeNumber(456.789f, 10, ScientificNotationFormat.Base10)).Should().Be("457");
        }

        [Fact]
        public void TestSqueezeNumberBase10WithDecimals()
        {
            (StringUtil.SqueezeNumber(789.123m, 10, ScientificNotationFormat.Base10)).Should().Be("789");
        }

        [Fact]
        public void TestSqueezeNumberBase10WithLongs()
        {
            (StringUtil.SqueezeNumber(1000000L, 10, ScientificNotationFormat.Base10)).Should().Be("1,000,000");
        }

        [Fact]
        public void TestSqueezeNumberBase10WithLongsRequiringScientificNotation()
        {
            (StringUtil.SqueezeNumber(1000000000000000L, 5, ScientificNotationFormat.Base10)).Should().Be("1.00x10^15");
        }

        [Fact]
        public void TestSqueezeNumberBase10Spaced1()
        {
            (StringUtil.SqueezeNumber(9999999999, 5, ScientificNotationFormat.Base10Spaced)).Should().Be("1.00 x 10^10");
        }

        [Fact]
        public void TestSqueezeNumberBase10Spaced2()
        {
            (StringUtil.SqueezeNumber(9999999999, 12, ScientificNotationFormat.Base10Spaced)).Should().Be("1.00 x 10^10");
        }

        [Fact]
        public void TestSqueezeNumberBase10Spaced3()
        {
            (StringUtil.SqueezeNumber(9999999999, 13, ScientificNotationFormat.Base10Spaced)).Should().Be("9,999,999,999");
        }

        [Fact]
        public void TestSqueezeNumberBase10Spaced4()
        {
            (StringUtil.SqueezeNumber(9999999999, 20, ScientificNotationFormat.Base10Spaced)).Should().Be("9,999,999,999");
        }

        [Fact]
        public void TestSqueezeNumberBase10SpacedWithNegativeNumbersThatFit()
        {
            (StringUtil.SqueezeNumber(-123, 10, ScientificNotationFormat.Base10Spaced)).Should().Be("-123");
        }

        [Fact]
        public void TestSqueezeNumberBase10SpacedWithNegativeNumbersThatFitLarge()
        {
            (StringUtil.SqueezeNumber(-1234567, 15, ScientificNotationFormat.Base10Spaced)).Should().Be("-1,234,567");
        }

        [Fact]
        public void TestSqueezeNumberBase10SpacedWithNegativeNumbersRequiringScientificNotation()
        {
            (StringUtil.SqueezeNumber(-9999999999, 5, ScientificNotationFormat.Base10Spaced)).Should().Be("-1.00 x 10^10");
        }

        [Fact]
        public void TestSqueezeNumberBase10SpacedWithNegativeNumbersRequiringScientificNotationLarge()
        {
            (StringUtil.SqueezeNumber(-9999999999, 12, ScientificNotationFormat.Base10Spaced)).Should().Be("-1.00 x 10^10");
        }

        [Fact]
        public void TestSqueezeNumberBase10SpacedWithZero()
        {
            (StringUtil.SqueezeNumber(0, 5, ScientificNotationFormat.Base10Spaced)).Should().Be("0");
        }

        [Fact]
        public void TestSqueezeNumberBase10SpacedWithSmallDecimals()
        {
            (StringUtil.SqueezeNumber(0.123, 10, ScientificNotationFormat.Base10Spaced)).Should().Be("0");
        }

        [Fact]
        public void TestSqueezeNumberBase10SpacedWithSmallDecimalsSmallLength()
        {
            (StringUtil.SqueezeNumber(0.123, 4, ScientificNotationFormat.Base10Spaced)).Should().Be("0");
        }

        [Fact]
        public void TestSqueezeNumberBase10SpacedWithVerySmallNumbers()
        {
            (StringUtil.SqueezeNumber(0.000000000123, 5, ScientificNotationFormat.Base10Spaced)).Should().Be("0");
        }

        [Fact]
        public void TestSqueezeNumberBase10SpacedWithDoubles()
        {
            (StringUtil.SqueezeNumber(123.456, 10, ScientificNotationFormat.Base10Spaced)).Should().Be("123");
        }

        [Fact]
        public void TestSqueezeNumberBase10SpacedWithDoublesSmallLength()
        {
            (StringUtil.SqueezeNumber(123.456, 4, ScientificNotationFormat.Base10Spaced)).Should().Be("123");
        }

        [Fact]
        public void TestSqueezeNumberBase10SpacedWithFloats()
        {
            (StringUtil.SqueezeNumber(456.789f, 10, ScientificNotationFormat.Base10Spaced)).Should().Be("457");
        }

        [Fact]
        public void TestSqueezeNumberBase10SpacedWithDecimals()
        {
            (StringUtil.SqueezeNumber(789.123m, 10, ScientificNotationFormat.Base10Spaced)).Should().Be("789");
        }

        [Fact]
        public void TestSqueezeNumberBase10SpacedWithLongs()
        {
            (StringUtil.SqueezeNumber(1000000L, 10, ScientificNotationFormat.Base10Spaced)).Should().Be("1,000,000");
        }

        [Fact]
        public void TestSqueezeNumberBase10SpacedWithLongsRequiringScientificNotation()
        {
            (StringUtil.SqueezeNumber(1000000000000000L, 5, ScientificNotationFormat.Base10Spaced)).Should().Be("1.00 x 10^15");
        }

        [Fact]
        public void TestSqueezeNumberBase10Superscript1()
        {
            (StringUtil.SqueezeNumber(9999999999, 5, ScientificNotationFormat.Base10Superscript)).Should().Be("1.00x10" + StringUtil.Superscript1 + StringUtil.Superscript0);
        }

        [Fact]
        public void TestSqueezeNumberBase10Superscript2()
        {
            (StringUtil.SqueezeNumber(9999999999, 12, ScientificNotationFormat.Base10Superscript)).Should().Be("1.00x10" + StringUtil.Superscript1 + StringUtil.Superscript0);
        }

        [Fact]
        public void TestSqueezeNumberBase10Superscript3()
        {
            (StringUtil.SqueezeNumber(9999999999, 13, ScientificNotationFormat.Base10Superscript)).Should().Be("9,999,999,999");
        }

        [Fact]
        public void TestSqueezeNumberBase10Superscript4()
        {
            (StringUtil.SqueezeNumber(9999999999, 20, ScientificNotationFormat.Base10Superscript)).Should().Be("9,999,999,999");
        }

        [Fact]
        public void TestSqueezeNumberBase10SuperscriptWithNegativeNumbersThatFit()
        {
            (StringUtil.SqueezeNumber(-123, 10, ScientificNotationFormat.Base10Superscript)).Should().Be("-123");
        }

        [Fact]
        public void TestSqueezeNumberBase10SuperscriptWithNegativeNumbersThatFitLarge()
        {
            (StringUtil.SqueezeNumber(-1234567, 15, ScientificNotationFormat.Base10Superscript)).Should().Be("-1,234,567");
        }

        [Fact]
        public void TestSqueezeNumberBase10SuperscriptWithNegativeNumbersRequiringScientificNotation()
        {
            (StringUtil.SqueezeNumber(-9999999999, 5, ScientificNotationFormat.Base10Superscript)).Should().Be("-1.00x10" + StringUtil.Superscript1 + StringUtil.Superscript0);
        }

        [Fact]
        public void TestSqueezeNumberBase10SuperscriptWithNegativeNumbersRequiringScientificNotationLarge()
        {
            (StringUtil.SqueezeNumber(-9999999999, 12, ScientificNotationFormat.Base10Superscript)).Should().Be("-1.00x10" + StringUtil.Superscript1 + StringUtil.Superscript0);
        }

        [Fact]
        public void TestSqueezeNumberBase10SuperscriptWithZero()
        {
            (StringUtil.SqueezeNumber(0, 5, ScientificNotationFormat.Base10Superscript)).Should().Be("0");
        }

        [Fact]
        public void TestSqueezeNumberBase10SuperscriptWithSmallDecimals()
        {
            (StringUtil.SqueezeNumber(0.123, 10, ScientificNotationFormat.Base10Superscript)).Should().Be("0");
        }

        [Fact]
        public void TestSqueezeNumberBase10SuperscriptWithSmallDecimalsSmallLength()
        {
            (StringUtil.SqueezeNumber(0.1, 4, ScientificNotationFormat.Base10Superscript)).Should().Be("0");
        }

        [Fact]
        public void TestSqueezeNumberBase10SuperscriptWithDoubles()
        {
            (StringUtil.SqueezeNumber(123.456, 10, ScientificNotationFormat.Base10Superscript)).Should().Be("123");
        }

        [Fact]
        public void TestSqueezeNumberBase10SuperscriptWithDoublesSmallLength()
        {
            (StringUtil.SqueezeNumber(123.456, 4, ScientificNotationFormat.Base10Superscript)).Should().Be("123");
        }

        [Fact]
        public void TestSqueezeNumberBase10SuperscriptWithFloats()
        {
            (StringUtil.SqueezeNumber(456.789f, 10, ScientificNotationFormat.Base10Superscript)).Should().Be("457");
        }

        [Fact]
        public void TestSqueezeNumberBase10SuperscriptWithDecimals()
        {
            (StringUtil.SqueezeNumber(789.123m, 10, ScientificNotationFormat.Base10Superscript)).Should().Be("789");
        }

        [Fact]
        public void TestSqueezeNumberBase10SuperscriptWithLongs()
        {
            (StringUtil.SqueezeNumber(1000000L, 10, ScientificNotationFormat.Base10Superscript)).Should().Be("1,000,000");
        }

        [Fact]
        public void TestSqueezeNumberBase10SuperscriptWithLongsRequiringScientificNotation()
        {
            (StringUtil.SqueezeNumber(1000000000000000L, 5, ScientificNotationFormat.Base10Superscript)).Should().Be("1.00x10" + StringUtil.Superscript1 + StringUtil.Superscript5);
        }

        [Fact]
        public void TestSqueezeNumberBase10SuperscriptSpaced1()
        {
            (StringUtil.SqueezeNumber(9999999999, 5, ScientificNotationFormat.Base10SuperscriptSpaced)).Should().Be("1.00 x 10" + StringUtil.Superscript1 + StringUtil.Superscript0);
        }

        [Fact]
        public void TestSqueezeNumberBase10SuperscriptSpaced2()
        {
            (StringUtil.SqueezeNumber(9999999999, 12, ScientificNotationFormat.Base10SuperscriptSpaced)).Should().Be("1.00 x 10" + StringUtil.Superscript1 + StringUtil.Superscript0);
        }

        [Fact]
        public void TestSqueezeNumberBase10SuperscriptSpaced3()
        {
            (StringUtil.SqueezeNumber(9999999999, 13, ScientificNotationFormat.Base10SuperscriptSpaced)).Should().Be("9,999,999,999");
        }

        [Fact]
        public void TestSqueezeNumberBase10SuperscriptSpaced4()
        {
            (StringUtil.SqueezeNumber(9999999999, 20, ScientificNotationFormat.Base10SuperscriptSpaced)).Should().Be("9,999,999,999");
        }

        [Fact]
        public void TestSqueezeNumberBase10SuperscriptSpacedWithNegativeNumbersThatFit()
        {
            (StringUtil.SqueezeNumber(-123, 10, ScientificNotationFormat.Base10SuperscriptSpaced)).Should().Be("-123");
        }

        [Fact]
        public void TestSqueezeNumberBase10SuperscriptSpacedWithNegativeNumbersThatFitLarge()
        {
            (StringUtil.SqueezeNumber(-1234567, 15, ScientificNotationFormat.Base10SuperscriptSpaced)).Should().Be("-1,234,567");
        }

        [Fact]
        public void TestSqueezeNumberBase10SuperscriptSpacedWithNegativeNumbersRequiringScientificNotation()
        {
            (StringUtil.SqueezeNumber(-9999999999, 5, ScientificNotationFormat.Base10SuperscriptSpaced)).Should().Be("-1.00 x 10" + StringUtil.Superscript1 + StringUtil.Superscript0);
        }

        [Fact]
        public void TestSqueezeNumberBase10SuperscriptSpacedWithNegativeNumbersRequiringScientificNotationLarge()
        {
            (StringUtil.SqueezeNumber(-9999999999, 12, ScientificNotationFormat.Base10SuperscriptSpaced)).Should().Be("-1.00 x 10" + StringUtil.Superscript1 + StringUtil.Superscript0);
        }

        [Fact]
        public void TestSqueezeNumberBase10SuperscriptSpacedWithZero()
        {
            (StringUtil.SqueezeNumber(0, 5, ScientificNotationFormat.Base10SuperscriptSpaced)).Should().Be("0");
        }

        [Fact]
        public void TestSqueezeNumberBase10SuperscriptSpacedWithSmallDecimals()
        {
            (StringUtil.SqueezeNumber(0.123, 10, ScientificNotationFormat.Base10SuperscriptSpaced)).Should().Be("0");
        }

        [Fact]
        public void TestSqueezeNumberBase10SuperscriptSpacedWithSmallDecimalsSmallLength()
        {
            (StringUtil.SqueezeNumber(0.1, 4, ScientificNotationFormat.Base10SuperscriptSpaced)).Should().Be("0");
        }

        [Fact]
        public void TestSqueezeNumberBase10SuperscriptSpacedWithDoubles()
        {
            (StringUtil.SqueezeNumber(123.456, 10, ScientificNotationFormat.Base10SuperscriptSpaced)).Should().Be("123");
        }

        [Fact]
        public void TestSqueezeNumberBase10SuperscriptSpacedWithDoublesSmallLength()
        {
            (StringUtil.SqueezeNumber(123.456, 4, ScientificNotationFormat.Base10SuperscriptSpaced)).Should().Be("123");
        }

        [Fact]
        public void TestSqueezeNumberBase10SuperscriptSpacedWithFloats()
        {
            (StringUtil.SqueezeNumber(456.789f, 10, ScientificNotationFormat.Base10SuperscriptSpaced)).Should().Be("457");
        }

        [Fact]
        public void TestSqueezeNumberBase10SuperscriptSpacedWithDecimals()
        {
            (StringUtil.SqueezeNumber(789.123m, 10, ScientificNotationFormat.Base10SuperscriptSpaced)).Should().Be("789");
        }

        [Fact]
        public void TestSqueezeNumberBase10SuperscriptSpacedWithLongs()
        {
            (StringUtil.SqueezeNumber(1000000L, 10, ScientificNotationFormat.Base10SuperscriptSpaced)).Should().Be("1,000,000");
        }

        [Fact]
        public void TestSqueezeNumberBase10SuperscriptSpacedWithLongsRequiringScientificNotation()
        {
            (StringUtil.SqueezeNumber(1000000000000000L, 5, ScientificNotationFormat.Base10SuperscriptSpaced)).Should().Be("1.00 x 10" + StringUtil.Superscript1 + StringUtil.Superscript5);
        }

        #endregion


        #region ENotationToBaseTenNotation(string, bool, bool, bool, bool) tests

        // Exception and null tests
        [Fact]
        public void TestENotationToBaseTenNotation1NullSource()
        {
            Action act = () => StringUtil.ENotationToBaseTenNotation(null, false, false, false, false);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestENotationToBaseTenNotation2InvalidExponent()
        {
            // Invalid exponent that can't be parsed as integer
            Action act = () => StringUtil.ENotationToBaseTenNotation("1.5Eabc", false, false, false, false);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestENotationToBaseTenNotation3InvalidExponentWithDecimal()
        {
            // Exponent with decimal point - can't parse as int
            Action act = () => StringUtil.ENotationToBaseTenNotation("1.5E2.5", false, false, false, false);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        // No E notation tests - string should return unchanged (uppercased)
        [Fact]
        public void TestENotationToBaseTenNotation4NoENotationSimpleNumber()
        {
            string result = StringUtil.ENotationToBaseTenNotation("123.45", false, false, false, false);
            (result).Should().Be("123.45");
        }

        [Fact]
        public void TestENotationToBaseTenNotation5NoENotationLowerCase()
        {
            // Should return uppercased but since no E, should be unchanged except for case
            string result = StringUtil.ENotationToBaseTenNotation("abc", false, false, false, false);
            (result).Should().Be("ABC");
        }

        [Fact]
        public void TestENotationToBaseTenNotation6NoENotationMixedCase()
        {
            string result = StringUtil.ENotationToBaseTenNotation("AbC123", false, false, false, false);
            (result).Should().Be("ABC123");
        }

        // Zero power tests
        [Fact]
        public void TestENotationToBaseTenNotation7ZeroPowerExcludeTrue()
        {
            // 1.5E0 with excludeZeroPower=true should return just base value
            string result = StringUtil.ENotationToBaseTenNotation("1.5E0", false, false, false, true);
            (result).Should().Be("1.5");
        }

        [Fact]
        public void TestENotationToBaseTenNotation8ZeroPowerExcludeFalseNoSuperscriptNoSpace()
        {
            // 1.5E0 with excludeZeroPower=false should include x10^0
            string result = StringUtil.ENotationToBaseTenNotation("1.5E0", false, false, false, false);
            (result).Should().Be("1.5x10^0");
        }

        [Fact]
        public void TestENotationToBaseTenNotation9ZeroPowerExcludeFalseNoSuperscriptSpaced()
        {
            string result = StringUtil.ENotationToBaseTenNotation("1.5E0", false, true, false, false);
            (result).Should().Be("1.5 x 10^0");
        }

        [Fact]
        public void TestENotationToBaseTenNotation10ZeroPowerExcludeFalseSuperscriptNoSpace()
        {
            string baseValue = "1.5";
            string superscriptZero = StringUtil.Superscript0;
            string result = StringUtil.ENotationToBaseTenNotation("1.5E0", true, false, false, false);
            (result).Should().Be(baseValue + "x10" + superscriptZero);
        }

        [Fact]
        public void TestENotationToBaseTenNotation11ZeroPowerExcludeFalseSuperscriptSpaced()
        {
            string baseValue = "1.5";
            string superscriptZero = StringUtil.Superscript0;
            string result = StringUtil.ENotationToBaseTenNotation("1.5E0", true, true, false, false);
            (result).Should().Be(baseValue + " x 10" + superscriptZero);
        }

        // Positive exponent tests - all 16 combinations
        [Fact]
        public void TestENotationToBaseTenNotation12PositiveExponentNoSuperscriptNoSpaceIncludePlusExcludeZero()
        {
            string result = StringUtil.ENotationToBaseTenNotation("2.5E+3", false, false, false, true);
            (result).Should().Be("2.5x10^+3");
        }

        [Fact]
        public void TestENotationToBaseTenNotation13PositiveExponentNoSuperscriptNoSpaceExcludePlusExcludeZero()
        {
            string result = StringUtil.ENotationToBaseTenNotation("2.5E+3", false, false, true, true);
            (result).Should().Be("2.5x10^3");
        }

        [Fact]
        public void TestENotationToBaseTenNotation14PositiveExponentNoSuperscriptSpacedIncludePlusExcludeZero()
        {
            string result = StringUtil.ENotationToBaseTenNotation("2.5E+3", false, true, false, true);
            (result).Should().Be("2.5 x 10^+3");
        }

        [Fact]
        public void TestENotationToBaseTenNotation15PositiveExponentNoSuperscriptSpacedExcludePlusExcludeZero()
        {
            string result = StringUtil.ENotationToBaseTenNotation("2.5E+3", false, true, true, true);
            (result).Should().Be("2.5 x 10^3");
        }

        [Fact]
        public void TestENotationToBaseTenNotation16PositiveExponentSuperscriptNoSpaceIncludePlusExcludeZero()
        {
            string baseValue = "2.5";
            string superscriptPlus = StringUtil.SuperscriptPlus;
            string superscript3 = StringUtil.Superscript3;
            string result = StringUtil.ENotationToBaseTenNotation("2.5E+3", true, false, false, true);
            (result).Should().Be(baseValue + "x10" + superscriptPlus + superscript3);
        }

        [Fact]
        public void TestENotationToBaseTenNotation17PositiveExponentSuperscriptNoSpaceExcludePlusExcludeZero()
        {
            string baseValue = "2.5";
            string superscript3 = StringUtil.Superscript3;
            string result = StringUtil.ENotationToBaseTenNotation("2.5E+3", true, false, true, true);
            (result).Should().Be(baseValue + "x10" + superscript3);
        }

        [Fact]
        public void TestENotationToBaseTenNotation18PositiveExponentSuperscriptSpacedIncludePlusExcludeZero()
        {
            string baseValue = "2.5";
            string superscriptPlus = StringUtil.SuperscriptPlus;
            string superscript3 = StringUtil.Superscript3;
            string result = StringUtil.ENotationToBaseTenNotation("2.5E+3", true, true, false, true);
            (result).Should().Be(baseValue + " x 10" + superscriptPlus + superscript3);
        }

        [Fact]
        public void TestENotationToBaseTenNotation19PositiveExponentSuperscriptSpacedExcludePlusExcludeZero()
        {
            string baseValue = "2.5";
            string superscript3 = StringUtil.Superscript3;
            string result = StringUtil.ENotationToBaseTenNotation("2.5E+3", true, true, true, true);
            (result).Should().Be(baseValue + " x 10" + superscript3);
        }

        // Negative exponent tests - all 16 combinations
        [Fact]
        public void TestENotationToBaseTenNotation20NegativeExponentNoSuperscriptNoSpaceIncludePlusExcludeZero()
        {
            string result = StringUtil.ENotationToBaseTenNotation("1.2E-5", false, false, false, true);
            (result).Should().Be("1.2x10^-5");
        }

        [Fact]
        public void TestENotationToBaseTenNotation21NegativeExponentNoSuperscriptNoSpaceExcludePlusExcludeZero()
        {
            // excludePlusSign should not affect negative sign
            string result = StringUtil.ENotationToBaseTenNotation("1.2E-5", false, false, true, true);
            (result).Should().Be("1.2x10^-5");
        }

        [Fact]
        public void TestENotationToBaseTenNotation22NegativeExponentNoSuperscriptSpacedIncludePlusExcludeZero()
        {
            string result = StringUtil.ENotationToBaseTenNotation("1.2E-5", false, true, false, true);
            (result).Should().Be("1.2 x 10^-5");
        }

        [Fact]
        public void TestENotationToBaseTenNotation23NegativeExponentNoSuperscriptSpacedExcludePlusExcludeZero()
        {
            string result = StringUtil.ENotationToBaseTenNotation("1.2E-5", false, true, true, true);
            (result).Should().Be("1.2 x 10^-5");
        }

        [Fact]
        public void TestENotationToBaseTenNotation24NegativeExponentSuperscriptNoSpaceIncludePlusExcludeZero()
        {
            string baseValue = "1.2";
            string superscriptMinus = StringUtil.SuperscriptMinus;
            string superscript5 = StringUtil.Superscript5;
            string result = StringUtil.ENotationToBaseTenNotation("1.2E-5", true, false, false, true);
            (result).Should().Be(baseValue + "x10" + superscriptMinus + superscript5);
        }

        [Fact]
        public void TestENotationToBaseTenNotation25NegativeExponentSuperscriptNoSpaceExcludePlusExcludeZero()
        {
            string baseValue = "1.2";
            string superscriptMinus = StringUtil.SuperscriptMinus;
            string superscript5 = StringUtil.Superscript5;
            string result = StringUtil.ENotationToBaseTenNotation("1.2E-5", true, false, true, true);
            (result).Should().Be(baseValue + "x10" + superscriptMinus + superscript5);
        }

        [Fact]
        public void TestENotationToBaseTenNotation26NegativeExponentSuperscriptSpacedIncludePlusExcludeZero()
        {
            string baseValue = "1.2";
            string superscriptMinus = StringUtil.SuperscriptMinus;
            string superscript5 = StringUtil.Superscript5;
            string result = StringUtil.ENotationToBaseTenNotation("1.2E-5", true, true, false, true);
            (result).Should().Be(baseValue + " x 10" + superscriptMinus + superscript5);
        }

        [Fact]
        public void TestENotationToBaseTenNotation27NegativeExponentSuperscriptSpacedExcludePlusExcludeZero()
        {
            string baseValue = "1.2";
            string superscriptMinus = StringUtil.SuperscriptMinus;
            string superscript5 = StringUtil.Superscript5;
            string result = StringUtil.ENotationToBaseTenNotation("1.2E-5", true, true, true, true);
            (result).Should().Be(baseValue + " x 10" + superscriptMinus + superscript5);
        }

        // Edge cases
        [Fact]
        public void TestENotationToBaseTenNotation28SingleCharBase()
        {
            string result = StringUtil.ENotationToBaseTenNotation("5E2", false, false, false, true);
            (result).Should().Be("5x10^2");
        }

        [Fact]
        public void TestENotationToBaseTenNotation29LargePositiveExponent()
        {
            string result = StringUtil.ENotationToBaseTenNotation("3.14E100", false, true, true, true);
            string expected = "3.14 x 10^100";
            (result).Should().Be(expected);
        }

        [Fact]
        public void TestENotationToBaseTenNotation30LargeNegativeExponent()
        {
            string result = StringUtil.ENotationToBaseTenNotation("3.14E-100", false, true, false, true);
            string expected = "3.14 x 10^-100";
            (result).Should().Be(expected);
        }

        [Fact]
        public void TestENotationToBaseTenNotation31LowercaseENotation()
        {
            // Should convert lowercase 'e' to uppercase 'E' internally
            string result = StringUtil.ENotationToBaseTenNotation("2e4", false, false, false, true);
            (result).Should().Be("2x10^4");
        }

        [Fact]
        public void TestENotationToBaseTenNotation32IntegerBase()
        {
            string result = StringUtil.ENotationToBaseTenNotation("42E3", true, true, true, true);
            string expected = "42 x 10" + StringUtil.Superscript3;
            (result).Should().Be(expected);
        }

        [Fact]
        public void TestENotationToBaseTenNotation33ExponentWithExplicitPlus()
        {
            string result = StringUtil.ENotationToBaseTenNotation("1.5E+2", false, false, false, true);
            (result).Should().Be("1.5x10^+2");
        }

        [Fact]
        public void TestENotationToBaseTenNotation34ExponentWithoutExplicitPlus()
        {
            string result = StringUtil.ENotationToBaseTenNotation("1.5E2", false, false, false, true);
            (result).Should().Be("1.5x10^2");
        }

        [Fact]
        public void TestENotationToBaseTenNotation35MultiDigitBase()
        {
            string result = StringUtil.ENotationToBaseTenNotation("123.456E7", true, true, true, true);
            string superscript7 = StringUtil.Superscript7;
            (result).Should().Be("123.456 x 10" + superscript7);
        }

        [Fact]
        public void TestENotationToBaseTenNotation36OneAsExponent()
        {
            string result = StringUtil.ENotationToBaseTenNotation("5E1", false, false, false, true);
            string expected = "5x10^1";
            (result).Should().Be(expected);
        }

        [Fact]
        public void TestENotationToBaseTenNotation37NegativeOne()
        {
            string result = StringUtil.ENotationToBaseTenNotation("5E-1", true, false, false, true);
            string superscriptMinus = StringUtil.SuperscriptMinus;
            string superscript1 = StringUtil.Superscript1;
            string expected = "5x10" + superscriptMinus + superscript1;
            (result).Should().Be(expected);
        }

        [Fact]
        public void TestENotationToBaseTenNotation38PositiveOneWithExplicitPlus()
        {
            string result = StringUtil.ENotationToBaseTenNotation("5E+1", true, true, false, true);
            string superscriptPlus = StringUtil.SuperscriptPlus;
            string superscript1 = StringUtil.Superscript1;
            string expected = "5 x 10" + superscriptPlus + superscript1;
            (result).Should().Be(expected);
        }

        [Fact]
        public void TestENotationToBaseTenNotation39SmallDecimalBase()
        {
            string result = StringUtil.ENotationToBaseTenNotation("0.001E6", false, true, true, true);
            (result).Should().Be("0.001 x 10^6");
        }

        [Fact]
        public void TestENotationToBaseTenNotation40ExponentTwo()
        {
            string result = StringUtil.ENotationToBaseTenNotation("7E2", true, false, true, true);
            string superscript2 = StringUtil.Superscript2;
            (result).Should().Be("7x10" + superscript2);
        }

        #endregion


        #region ToSuperscript(string) tests

        [Fact]
        public void TestToSuperscript()
        {
            string expected = StringUtil.SuperscriptPlus + StringUtil.Superscript0 + StringUtil.Superscript1 + StringUtil.Superscript2 + StringUtil.Superscript3 + StringUtil.Superscript4 + StringUtil.Superscript5 + StringUtil.Superscript6 + StringUtil.Superscript7 + StringUtil.Superscript8 + StringUtil.Superscript9;
            (StringUtil.ToSuperscript("+0123456789")).Should().Be(expected);

            expected = StringUtil.SuperscriptMinus + StringUtil.Superscript0 + StringUtil.Superscript1 + StringUtil.Superscript2 + StringUtil.Superscript3 + StringUtil.Superscript4 + StringUtil.Superscript5 + StringUtil.Superscript6 + StringUtil.Superscript7 + StringUtil.Superscript8 + StringUtil.Superscript9;
            (StringUtil.ToSuperscript("-0123456789")).Should().Be(expected);
        }

        [Fact]
        public void TestToSuperscriptArgumentOutOfRange()
        {
            Action act = () => StringUtil.ToSuperscript("asdf");
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestToSuperscriptArgumentNull()
        {
            string? s = null;
            Action act = () => StringUtil.ToSuperscript(s);
            act.Should().Throw<ArgumentNullException>();
        }

        // Individual digit tests
        [Fact]
        public void TestToSuperscriptDigit0()
        {
            string result = StringUtil.ToSuperscript("0");
            (result).Should().Be(StringUtil.Superscript0);
        }

        [Fact]
        public void TestToSuperscriptDigit1()
        {
            string result = StringUtil.ToSuperscript("1");
            (result).Should().Be(StringUtil.Superscript1);
        }

        [Fact]
        public void TestToSuperscriptDigit2()
        {
            string result = StringUtil.ToSuperscript("2");
            (result).Should().Be(StringUtil.Superscript2);
        }

        [Fact]
        public void TestToSuperscriptDigit3()
        {
            string result = StringUtil.ToSuperscript("3");
            (result).Should().Be(StringUtil.Superscript3);
        }

        [Fact]
        public void TestToSuperscriptDigit4()
        {
            string result = StringUtil.ToSuperscript("4");
            (result).Should().Be(StringUtil.Superscript4);
        }

        [Fact]
        public void TestToSuperscriptDigit5()
        {
            string result = StringUtil.ToSuperscript("5");
            (result).Should().Be(StringUtil.Superscript5);
        }

        [Fact]
        public void TestToSuperscriptDigit6()
        {
            string result = StringUtil.ToSuperscript("6");
            (result).Should().Be(StringUtil.Superscript6);
        }

        [Fact]
        public void TestToSuperscriptDigit7()
        {
            string result = StringUtil.ToSuperscript("7");
            (result).Should().Be(StringUtil.Superscript7);
        }

        [Fact]
        public void TestToSuperscriptDigit8()
        {
            string result = StringUtil.ToSuperscript("8");
            (result).Should().Be(StringUtil.Superscript8);
        }

        [Fact]
        public void TestToSuperscriptDigit9()
        {
            string result = StringUtil.ToSuperscript("9");
            (result).Should().Be(StringUtil.Superscript9);
        }

        // Plus sign tests
        [Fact]
        public void TestToSuperscriptPlusOnly()
        {
            // Plus sign alone is not a valid integer
            Action act = () => StringUtil.ToSuperscript("+");
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestToSuperscriptPlusWith0()
        {
            string result = StringUtil.ToSuperscript("+0");
            (result).Should().Be(StringUtil.SuperscriptPlus + StringUtil.Superscript0);
        }

        [Fact]
        public void TestToSuperscriptPlusWith5()
        {
            string result = StringUtil.ToSuperscript("+5");
            (result).Should().Be(StringUtil.SuperscriptPlus + StringUtil.Superscript5);
        }

        [Fact]
        public void TestToSuperscriptPlusWith9()
        {
            string result = StringUtil.ToSuperscript("+9");
            (result).Should().Be(StringUtil.SuperscriptPlus + StringUtil.Superscript9);
        }

        // Minus sign tests
        [Fact]
        public void TestToSuperscriptMinusOnly()
        {
            // Minus sign alone is not a valid integer
            Action act = () => StringUtil.ToSuperscript("-");
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestToSuperscriptMinusWith0()
        {
            string result = StringUtil.ToSuperscript("-0");
            (result).Should().Be(StringUtil.SuperscriptMinus + StringUtil.Superscript0);
        }

        [Fact]
        public void TestToSuperscriptMinusWith5()
        {
            string result = StringUtil.ToSuperscript("-5");
            (result).Should().Be(StringUtil.SuperscriptMinus + StringUtil.Superscript5);
        }

        [Fact]
        public void TestToSuperscriptMinusWith9()
        {
            string result = StringUtil.ToSuperscript("-9");
            (result).Should().Be(StringUtil.SuperscriptMinus + StringUtil.Superscript9);
        }

        // Multi-digit number tests
        [Fact]
        public void TestToSuperscriptTwoDigits()
        {
            string result = StringUtil.ToSuperscript("12");
            (result).Should().Be(StringUtil.Superscript1 + StringUtil.Superscript2);
        }

        [Fact]
        public void TestToSuperscriptThreeDigits()
        {
            string result = StringUtil.ToSuperscript("123");
            (result).Should().Be(StringUtil.Superscript1 + StringUtil.Superscript2 + StringUtil.Superscript3);
        }

        [Fact]
        public void TestToSuperscriptPlusWithTwoDigits()
        {
            string result = StringUtil.ToSuperscript("+12");
            (result).Should().Be(StringUtil.SuperscriptPlus + StringUtil.Superscript1 + StringUtil.Superscript2);
        }

        [Fact]
        public void TestToSuperscriptMinusWithTwoDigits()
        {
            string result = StringUtil.ToSuperscript("-12");
            (result).Should().Be(StringUtil.SuperscriptMinus + StringUtil.Superscript1 + StringUtil.Superscript2);
        }

        [Fact]
        public void TestToSuperscriptPlusWithMultipleDigits()
        {
            string result = StringUtil.ToSuperscript("+456");
            (result).Should().Be(StringUtil.SuperscriptPlus + StringUtil.Superscript4 + StringUtil.Superscript5 + StringUtil.Superscript6);
        }

        [Fact]
        public void TestToSuperscriptMinusWithMultipleDigits()
        {
            string result = StringUtil.ToSuperscript("-456");
            (result).Should().Be(StringUtil.SuperscriptMinus + StringUtil.Superscript4 + StringUtil.Superscript5 + StringUtil.Superscript6);
        }

        [Fact]
        public void TestToSuperscriptLargeNumber()
        {
            string result = StringUtil.ToSuperscript("123456789");
            (result).Should().Be(StringUtil.Superscript1 + StringUtil.Superscript2 + StringUtil.Superscript3 + StringUtil.Superscript4 + StringUtil.Superscript5 + StringUtil.Superscript6 + StringUtil.Superscript7 + StringUtil.Superscript8 + StringUtil.Superscript9);
        }

        [Fact]
        public void TestToSuperscriptPlusWithLargeNumber()
        {
            string result = StringUtil.ToSuperscript("+123456789");
            (result).Should().Be(StringUtil.SuperscriptPlus + StringUtil.Superscript1 + StringUtil.Superscript2 + StringUtil.Superscript3 + StringUtil.Superscript4 + StringUtil.Superscript5 + StringUtil.Superscript6 + StringUtil.Superscript7 + StringUtil.Superscript8 + StringUtil.Superscript9);
        }

        [Fact]
        public void TestToSuperscriptMinusWithLargeNumber()
        {
            string result = StringUtil.ToSuperscript("-123456789");
            (result).Should().Be(StringUtil.SuperscriptMinus + StringUtil.Superscript1 + StringUtil.Superscript2 + StringUtil.Superscript3 + StringUtil.Superscript4 + StringUtil.Superscript5 + StringUtil.Superscript6 + StringUtil.Superscript7 + StringUtil.Superscript8 + StringUtil.Superscript9);
        }

        [Fact]
        public void TestToSuperscriptLeadingZeros()
        {
            string result = StringUtil.ToSuperscript("007");
            (result).Should().Be(StringUtil.Superscript0 + StringUtil.Superscript0 + StringUtil.Superscript7);
        }

        [Fact]
        public void TestToSuperscriptAllZeros()
        {
            string result = StringUtil.ToSuperscript("000");
            (result).Should().Be(StringUtil.Superscript0 + StringUtil.Superscript0 + StringUtil.Superscript0);
        }

        [Fact]
        public void TestToSuperscriptPlusWithAllZeros()
        {
            string result = StringUtil.ToSuperscript("+000");
            (result).Should().Be(StringUtil.SuperscriptPlus + StringUtil.Superscript0 + StringUtil.Superscript0 + StringUtil.Superscript0);
        }

        [Fact]
        public void TestToSuperscriptMinusWithAllZeros()
        {
            string result = StringUtil.ToSuperscript("-000");
            (result).Should().Be(StringUtil.SuperscriptMinus + StringUtil.Superscript0 + StringUtil.Superscript0 + StringUtil.Superscript0);
        }

        // Invalid input tests
        [Fact]
        public void TestToSuperscriptDecimalNumber()
        {
            Action act = () => StringUtil.ToSuperscript("1.5");
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestToSuperscriptWithSpaces()
        {
            Action act = () => StringUtil.ToSuperscript("1 2");
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestToSuperscriptWithLetters()
        {
            Action act = () => StringUtil.ToSuperscript("+12a");
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestToSuperscriptInvalidCharacters()
        {
            Action act = () => StringUtil.ToSuperscript("12@34");
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestToSuperscriptEmptyString()
        {
            Action act = () => StringUtil.ToSuperscript("");
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestToSuperscriptOnlyPlusAndMinus()
        {
            Action act = () => StringUtil.ToSuperscript("+-");
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestToSuperscriptMultipleSignsAtStart()
        {
            Action act = () => StringUtil.ToSuperscript("++123");
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestToSuperscriptSignInMiddle()
        {
            Action act = () => StringUtil.ToSuperscript("12+3");
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        #endregion


        #region ToXmlString(this DateTime)

        // Basic datetime tests
        [Fact]
        public void TestToXmlStringBasicDateTime()
        {
            DateTime dt = new DateTime(2024, 3, 15, 14, 30, 45, 123);
            string result = dt.ToXmlString();
            (result).Should().Be("2024-03-15T14:30:45.123Z");
        }

        [Fact]
        public void TestToXmlStringMidnight()
        {
            DateTime dt = new DateTime(2024, 1, 1, 0, 0, 0, 0);
            string result = dt.ToXmlString();
            (result).Should().Be("2024-01-01T00:00:00.0Z");
        }

        [Fact]
        public void TestToXmlStringEndOfDay()
        {
            DateTime dt = new DateTime(2024, 12, 31, 23, 59, 59, 999);
            string result = dt.ToXmlString();
            (result).Should().Be("2024-12-31T23:59:59.999Z");
        }

        [Fact]
        public void TestToXmlStringNoon()
        {
            DateTime dt = new DateTime(2024, 6, 15, 12, 0, 0, 0);
            string result = dt.ToXmlString();
            (result).Should().Be("2024-06-15T12:00:00.0Z");
        }

        // Year formatting tests - single digit year
        [Fact]
        public void TestToXmlStringYearOneDigit()
        {
            DateTime dt = new DateTime(1, 1, 1, 0, 0, 0, 0);
            string result = dt.ToXmlString();
            (result).Should().Be("0001-01-01T00:00:00.0Z");
        }

        [Fact]
        public void TestToXmlStringYearNine()
        {
            DateTime dt = new DateTime(9, 6, 15, 12, 30, 45, 500);
            string result = dt.ToXmlString();
            (result).Should().Be("0009-06-15T12:30:45.500Z");
        }

        // Year formatting tests - two digit year
        [Fact]
        public void TestToXmlStringYearTwoDigits()
        {
            DateTime dt = new DateTime(10, 3, 20, 8, 15, 30, 250);
            string result = dt.ToXmlString();
            (result).Should().Be("0010-03-20T08:15:30.250Z");
        }

        [Fact]
        public void TestToXmlStringYearNinetyNine()
        {
            DateTime dt = new DateTime(99, 12, 25, 18, 45, 20, 100);
            string result = dt.ToXmlString();
            (result).Should().Be("0099-12-25T18:45:20.100Z");
        }

        // Year formatting tests - three digit year
        [Fact]
        public void TestToXmlStringYearThreeDigits()
        {
            DateTime dt = new DateTime(100, 5, 10, 9, 0, 0, 0);
            string result = dt.ToXmlString();
            (result).Should().Be("0100-05-10T09:00:00.0Z");
        }

        [Fact]
        public void TestToXmlStringYearNineHundredNinetyNine()
        {
            DateTime dt = new DateTime(999, 7, 4, 16, 20, 15, 75);
            string result = dt.ToXmlString();
            (result).Should().Be("0999-07-04T16:20:15.75Z");
        }

        // Year formatting tests - four digit year
        [Fact]
        public void TestToXmlStringYearFourDigits()
        {
            DateTime dt = new DateTime(1000, 2, 28, 13, 10, 5, 500);
            string result = dt.ToXmlString();
            (result).Should().Be("1000-02-28T13:10:05.500Z");
        }

        [Fact]
        public void TestToXmlStringYearMaxValue()
        {
            DateTime dt = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            string result = dt.ToXmlString();
            (result).Should().Be("9999-12-31T23:59:59.999Z");
        }

        // Month formatting - single digit
        [Fact]
        public void TestToXmlStringMonthJanuary()
        {
            DateTime dt = new DateTime(2024, 1, 15, 12, 0, 0, 0);
            string result = dt.ToXmlString();
            (result).Should().Be("2024-01-15T12:00:00.0Z");
        }

        [Fact]
        public void TestToXmlStringMonthSeptember()
        {
            DateTime dt = new DateTime(2024, 9, 15, 12, 0, 0, 0);
            string result = dt.ToXmlString();
            (result).Should().Be("2024-09-15T12:00:00.0Z");
        }

        // Month formatting - double digit
        [Fact]
        public void TestToXmlStringMonthOctober()
        {
            DateTime dt = new DateTime(2024, 10, 15, 12, 0, 0, 0);
            string result = dt.ToXmlString();
            (result).Should().Be("2024-10-15T12:00:00.0Z");
        }

        [Fact]
        public void TestToXmlStringMonthDecember()
        {
            DateTime dt = new DateTime(2024, 12, 15, 12, 0, 0, 0);
            string result = dt.ToXmlString();
            (result).Should().Be("2024-12-15T12:00:00.0Z");
        }

        // Day formatting - single digit
        [Fact]
        public void TestToXmlStringDayOne()
        {
            DateTime dt = new DateTime(2024, 6, 1, 12, 0, 0, 0);
            string result = dt.ToXmlString();
            (result).Should().Be("2024-06-01T12:00:00.0Z");
        }

        [Fact]
        public void TestToXmlStringDayNine()
        {
            DateTime dt = new DateTime(2024, 6, 9, 12, 0, 0, 0);
            string result = dt.ToXmlString();
            (result).Should().Be("2024-06-09T12:00:00.0Z");
        }

        // Day formatting - double digit
        [Fact]
        public void TestToXmlStringDayTen()
        {
            DateTime dt = new DateTime(2024, 6, 10, 12, 0, 0, 0);
            string result = dt.ToXmlString();
            (result).Should().Be("2024-06-10T12:00:00.0Z");
        }

        [Fact]
        public void TestToXmlStringDayThirtyOne()
        {
            DateTime dt = new DateTime(2024, 5, 31, 12, 0, 0, 0);
            string result = dt.ToXmlString();
            (result).Should().Be("2024-05-31T12:00:00.0Z");
        }

        // Hour formatting - single digit
        [Fact]
        public void TestToXmlStringHourZero()
        {
            DateTime dt = new DateTime(2024, 6, 15, 0, 0, 0, 0);
            string result = dt.ToXmlString();
            (result).Should().Be("2024-06-15T00:00:00.0Z");
        }

        [Fact]
        public void TestToXmlStringHourNine()
        {
            DateTime dt = new DateTime(2024, 6, 15, 9, 0, 0, 0);
            string result = dt.ToXmlString();
            (result).Should().Be("2024-06-15T09:00:00.0Z");
        }

        // Hour formatting - double digit
        [Fact]
        public void TestToXmlStringHourTen()
        {
            DateTime dt = new DateTime(2024, 6, 15, 10, 0, 0, 0);
            string result = dt.ToXmlString();
            (result).Should().Be("2024-06-15T10:00:00.0Z");
        }

        [Fact]
        public void TestToXmlStringHourTwentyThree()
        {
            DateTime dt = new DateTime(2024, 6, 15, 23, 0, 0, 0);
            string result = dt.ToXmlString();
            (result).Should().Be("2024-06-15T23:00:00.0Z");
        }

        // Minute formatting - single digit
        [Fact]
        public void TestToXmlStringMinuteZero()
        {
            DateTime dt = new DateTime(2024, 6, 15, 12, 0, 0, 0);
            string result = dt.ToXmlString();
            (result).Should().Be("2024-06-15T12:00:00.0Z");
        }

        [Fact]
        public void TestToXmlStringMinuteNine()
        {
            DateTime dt = new DateTime(2024, 6, 15, 12, 9, 0, 0);
            string result = dt.ToXmlString();
            (result).Should().Be("2024-06-15T12:09:00.0Z");
        }

        // Minute formatting - double digit
        [Fact]
        public void TestToXmlStringMinuteTen()
        {
            DateTime dt = new DateTime(2024, 6, 15, 12, 10, 0, 0);
            string result = dt.ToXmlString();
            (result).Should().Be("2024-06-15T12:10:00.0Z");
        }

        [Fact]
        public void TestToXmlStringMinuteFiftyNine()
        {
            DateTime dt = new DateTime(2024, 6, 15, 12, 59, 0, 0);
            string result = dt.ToXmlString();
            (result).Should().Be("2024-06-15T12:59:00.0Z");
        }

        // Second formatting - single digit
        [Fact]
        public void TestToXmlStringSecondZero()
        {
            DateTime dt = new DateTime(2024, 6, 15, 12, 0, 0, 0);
            string result = dt.ToXmlString();
            (result).Should().Be("2024-06-15T12:00:00.0Z");
        }

        [Fact]
        public void TestToXmlStringSecondNine()
        {
            DateTime dt = new DateTime(2024, 6, 15, 12, 0, 9, 0);
            string result = dt.ToXmlString();
            (result).Should().Be("2024-06-15T12:00:09.0Z");
        }

        // Second formatting - double digit
        [Fact]
        public void TestToXmlStringSecondTen()
        {
            DateTime dt = new DateTime(2024, 6, 15, 12, 0, 10, 0);
            string result = dt.ToXmlString();
            (result).Should().Be("2024-06-15T12:00:10.0Z");
        }

        [Fact]
        public void TestToXmlStringSecondFiftyNine()
        {
            DateTime dt = new DateTime(2024, 6, 15, 12, 0, 59, 0);
            string result = dt.ToXmlString();
            (result).Should().Be("2024-06-15T12:00:59.0Z");
        }

        // Millisecond formatting - single digit
        [Fact]
        public void TestToXmlStringMillisecondZero()
        {
            DateTime dt = new DateTime(2024, 6, 15, 12, 0, 0, 0);
            string result = dt.ToXmlString();
            (result).Should().Be("2024-06-15T12:00:00.0Z");
        }

        [Fact]
        public void TestToXmlStringMillisecondOne()
        {
            DateTime dt = new DateTime(2024, 6, 15, 12, 0, 0, 1);
            string result = dt.ToXmlString();
            (result).Should().Be("2024-06-15T12:00:00.1Z");
        }

        [Fact]
        public void TestToXmlStringMillisecondNine()
        {
            DateTime dt = new DateTime(2024, 6, 15, 12, 0, 0, 9);
            string result = dt.ToXmlString();
            (result).Should().Be("2024-06-15T12:00:00.9Z");
        }

        // Millisecond formatting - double digit
        [Fact]
        public void TestToXmlStringMillisecondTen()
        {
            DateTime dt = new DateTime(2024, 6, 15, 12, 0, 0, 10);
            string result = dt.ToXmlString();
            (result).Should().Be("2024-06-15T12:00:00.10Z");
        }

        [Fact]
        public void TestToXmlStringMillisecondNinetynine()
        {
            DateTime dt = new DateTime(2024, 6, 15, 12, 0, 0, 99);
            string result = dt.ToXmlString();
            (result).Should().Be("2024-06-15T12:00:00.99Z");
        }

        // Millisecond formatting - triple digit
        [Fact]
        public void TestToXmlStringMillisecondHundred()
        {
            DateTime dt = new DateTime(2024, 6, 15, 12, 0, 0, 100);
            string result = dt.ToXmlString();
            (result).Should().Be("2024-06-15T12:00:00.100Z");
        }

        [Fact]
        public void TestToXmlStringMillisecondFiveHundred()
        {
            DateTime dt = new DateTime(2024, 6, 15, 12, 0, 0, 500);
            string result = dt.ToXmlString();
            (result).Should().Be("2024-06-15T12:00:00.500Z");
        }

        [Fact]
        public void TestToXmlStringMillisecondNineHundredNinetyNine()
        {
            DateTime dt = new DateTime(2024, 6, 15, 12, 0, 0, 999);
            string result = dt.ToXmlString();
            (result).Should().Be("2024-06-15T12:00:00.999Z");
        }

        // Leap year tests
        [Fact]
        public void TestToXmlStringLeapYearFeb292024()
        {
            DateTime dt = new DateTime(2024, 2, 29, 12, 0, 0, 0);
            string result = dt.ToXmlString();
            (result).Should().Be("2024-02-29T12:00:00.0Z");
        }

        [Fact]
        public void TestToXmlStringLeapYearFeb292000()
        {
            DateTime dt = new DateTime(2000, 2, 29, 0, 0, 0, 0);
            string result = dt.ToXmlString();
            (result).Should().Be("2000-02-29T00:00:00.0Z");
        }

        // Century boundary tests
        [Fact]
        public void TestToXmlStringCenturyBoundary1900()
        {
            DateTime dt = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            string result = dt.ToXmlString();
            (result).Should().Be("1900-01-01T00:00:00.0Z");
        }

        [Fact]
        public void TestToXmlStringCenturyBoundary2000()
        {
            DateTime dt = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            string result = dt.ToXmlString();
            (result).Should().Be("2000-01-01T00:00:00.0Z");
        }

        [Fact]
        public void TestToXmlStringCenturyBoundary2100()
        {
            DateTime dt = new DateTime(2100, 12, 31, 23, 59, 59, 999);
            string result = dt.ToXmlString();
            (result).Should().Be("2100-12-31T23:59:59.999Z");
        }

        // All components with boundary values
        [Fact]
        public void TestToXmlStringAllMinimumValues()
        {
            DateTime dt = new DateTime(1, 1, 1, 0, 0, 0, 0);
            string result = dt.ToXmlString();
            (result).Should().Be("0001-01-01T00:00:00.0Z");
        }

        [Fact]
        public void TestToXmlStringAllMaximumValues()
        {
            DateTime dt = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            string result = dt.ToXmlString();
            (result).Should().Be("9999-12-31T23:59:59.999Z");
        }

        // Mixed edge case combinations
        [Fact]
        public void TestToXmlStringMixedMinMax()
        {
            DateTime dt = new DateTime(1000, 1, 31, 23, 59, 0, 0);
            string result = dt.ToXmlString();
            (result).Should().Be("1000-01-31T23:59:00.0Z");
        }

        [Fact]
        public void TestToXmlStringMixedEdgeCases()
        {
            DateTime dt = new DateTime(999, 9, 9, 9, 9, 9, 9);
            string result = dt.ToXmlString();
            (result).Should().Be("0999-09-09T09:09:09.9Z");
        }

        // Format validation tests
        [Fact]
        public void TestToXmlStringFormatContainsDash()
        {
            DateTime dt = new DateTime(2024, 3, 15, 14, 30, 45, 123);
            string result = dt.ToXmlString();
            (result).Should().Contain("-");
        }

        [Fact]
        public void TestToXmlStringFormatContainsT()
        {
            DateTime dt = new DateTime(2024, 3, 15, 14, 30, 45, 123);
            string result = dt.ToXmlString();
            (result).Should().Contain("T");
        }

        [Fact]
        public void TestToXmlStringFormatContainsColon()
        {
            DateTime dt = new DateTime(2024, 3, 15, 14, 30, 45, 123);
            string result = dt.ToXmlString();
            (result).Should().Contain(":");
        }

        [Fact]
        public void TestToXmlStringFormatContainsDot()
        {
            DateTime dt = new DateTime(2024, 3, 15, 14, 30, 45, 123);
            string result = dt.ToXmlString();
            (result).Should().Contain(".");
        }

        [Fact]
        public void TestToXmlStringFormatEndsWithZ()
        {
            DateTime dt = new DateTime(2024, 3, 15, 14, 30, 45, 123);
            string result = dt.ToXmlString();
            (result).Should().EndWith("Z");
        }

        [Fact]
        public void TestToXmlStringCorrectLength()
        {
            DateTime dt = new DateTime(2024, 3, 15, 14, 30, 45, 123);
            string result = dt.ToXmlString();
            // Format: YYYY-MM-DDTHH:MM:SS.fffZ = 24 chars exactly when milliseconds are 3 digits
            // But if milliseconds are 1 or 2 digits, length varies
            (result.Length >= 21 && result.Length <= 24).Should().BeTrue();
        }

        #endregion


        #region ToXmlString(this TimeSpan) tests

        // Zero/Minimum value tests
        [Fact]
        public void TestToXmlStringTimeSpanZero()
        {
            TimeSpan ts = TimeSpan.Zero;
            string result = ts.ToXmlString();
            (result).Should().Be("P0Y0M0DT0H0M0.0S");
        }

        [Fact]
        public void TestToXmlStringTimeSpanOneMicrosecond()
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(0.001);
            string result = ts.ToXmlString();
            (result).Should().Be("P0Y0M0DT0H0M0.0S");
        }

        // Millisecond tests
        [Fact]
        public void TestToXmlStringTimeSpanOneMillisecond()
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(1);
            string result = ts.ToXmlString();
            (result).Should().Be("P0Y0M0DT0H0M0.1S");
        }

        [Fact]
        public void TestToXmlStringTimeSpanTenMilliseconds()
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(10);
            string result = ts.ToXmlString();
            (result).Should().Be("P0Y0M0DT0H0M0.10S");
        }

        [Fact]
        public void TestToXmlStringTimeSpanNinetynineMilliseconds()
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(99);
            string result = ts.ToXmlString();
            (result).Should().Be("P0Y0M0DT0H0M0.99S");
        }

        [Fact]
        public void TestToXmlStringTimeSpanHundredMilliseconds()
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(100);
            string result = ts.ToXmlString();
            (result).Should().Be("P0Y0M0DT0H0M0.100S");
        }

        [Fact]
        public void TestToXmlStringTimeSpanFiveHundredMilliseconds()
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(500);
            string result = ts.ToXmlString();
            (result).Should().Be("P0Y0M0DT0H0M0.500S");
        }

        [Fact]
        public void TestToXmlStringTimeSpanNineHundredNinetynineMilliseconds()
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(999);
            string result = ts.ToXmlString();
            (result).Should().Be("P0Y0M0DT0H0M0.999S");
        }

        // Second tests
        [Fact]
        public void TestToXmlStringTimeSpanOneSecond()
        {
            TimeSpan ts = TimeSpan.FromSeconds(1);
            string result = ts.ToXmlString();
            (result).Should().Be("P0Y0M0DT0H0M1.0S");
        }

        [Fact]
        public void TestToXmlStringTimeSpanTenSeconds()
        {
            TimeSpan ts = TimeSpan.FromSeconds(10);
            string result = ts.ToXmlString();
            (result).Should().Be("P0Y0M0DT0H0M10.0S");
        }

        [Fact]
        public void TestToXmlStringTimeSpanFiftyNineSeconds()
        {
            TimeSpan ts = TimeSpan.FromSeconds(59);
            string result = ts.ToXmlString();
            (result).Should().Be("P0Y0M0DT0H0M59.0S");
        }

        [Fact]
        public void TestToXmlStringTimeSpanOneSecondWithMilliseconds()
        {
            TimeSpan ts = TimeSpan.FromSeconds(1.500);
            string result = ts.ToXmlString();
            (result).Should().Be("P0Y0M0DT0H0M1.500S");
        }

        // Minute tests
        [Fact]
        public void TestToXmlStringTimeSpanOneMinute()
        {
            TimeSpan ts = TimeSpan.FromMinutes(1);
            string result = ts.ToXmlString();
            (result).Should().Be("P0Y0M0DT0H1M0.0S");
        }

        [Fact]
        public void TestToXmlStringTimeSpanTenMinutes()
        {
            TimeSpan ts = TimeSpan.FromMinutes(10);
            string result = ts.ToXmlString();
            (result).Should().Be("P0Y0M0DT0H10M0.0S");
        }

        [Fact]
        public void TestToXmlStringTimeSpanFiftyNineMinutes()
        {
            TimeSpan ts = TimeSpan.FromMinutes(59);
            string result = ts.ToXmlString();
            (result).Should().Be("P0Y0M0DT0H59M0.0S");
        }

        [Fact]
        public void TestToXmlStringTimeSpanOneMinuteWithSeconds()
        {
            TimeSpan ts = TimeSpan.FromMinutes(1).Add(TimeSpan.FromSeconds(30));
            string result = ts.ToXmlString();
            (result).Should().Be("P0Y0M0DT0H1M30.0S");
        }

        // Hour tests
        [Fact]
        public void TestToXmlStringTimeSpanOneHour()
        {
            TimeSpan ts = TimeSpan.FromHours(1);
            string result = ts.ToXmlString();
            (result).Should().Be("P0Y0M0DT1H0M0.0S");
        }

        [Fact]
        public void TestToXmlStringTimeSpanTwelveHours()
        {
            TimeSpan ts = TimeSpan.FromHours(12);
            string result = ts.ToXmlString();
            (result).Should().Be("P0Y0M0DT12H0M0.0S");
        }

        [Fact]
        public void TestToXmlStringTimeSpanTwentyThreeHours()
        {
            TimeSpan ts = TimeSpan.FromHours(23);
            string result = ts.ToXmlString();
            (result).Should().Be("P0Y0M0DT23H0M0.0S");
        }

        [Fact]
        public void TestToXmlStringTimeSpanOneHourWithMinutesSeconds()
        {
            TimeSpan ts = TimeSpan.FromHours(1).Add(TimeSpan.FromMinutes(30)).Add(TimeSpan.FromSeconds(45));
            string result = ts.ToXmlString();
            (result).Should().Be("P0Y0M0DT1H30M45.0S");
        }

        // Day tests
        [Fact]
        public void TestToXmlStringTimeSpanOneDay()
        {
            TimeSpan ts = TimeSpan.FromDays(1);
            string result = ts.ToXmlString();
            (result).Should().Be("P0Y0M1DT0H0M0.0S");
        }

        [Fact]
        public void TestToXmlStringTimeSpanTenDays()
        {
            TimeSpan ts = TimeSpan.FromDays(10);
            string result = ts.ToXmlString();
            (result).Should().Be("P0Y0M10DT0H0M0.0S");
        }

        [Fact]
        public void TestToXmlStringTimeSpanThirtyDays()
        {
            TimeSpan ts = TimeSpan.FromDays(30);
            string result = ts.ToXmlString();
            (result).Should().Be("P0Y1M0DT0H0M0.0S");
        }

        [Fact]
        public void TestToXmlStringTimeSpanSixtyDays()
        {
            TimeSpan ts = TimeSpan.FromDays(60);
            string result = ts.ToXmlString();
            (result).Should().Be("P0Y2M0DT0H0M0.0S");
        }

        [Fact]
        public void TestToXmlStringTimeSpanThreeSixtyFiveDays()
        {
            TimeSpan ts = TimeSpan.FromDays(365);
            string result = ts.ToXmlString();
            (result).Should().Be("P1Y0M0DT0H0M0.0S");
        }

        // Complex combinations
        [Fact]
        public void TestToXmlStringTimeSpanComplexCombination()
        {
            TimeSpan ts = TimeSpan.FromDays(400).Add(TimeSpan.FromHours(5)).Add(TimeSpan.FromMinutes(30)).Add(TimeSpan.FromSeconds(45).Add(TimeSpan.FromMilliseconds(250)));
            string result = ts.ToXmlString();
            // 400 days = 1 year (365) + 35 days (1 month of 30 days) + 5 days
            (result).Should().Be("P1Y1M5DT5H30M45.250S");
        }

        [Fact]
        public void TestToXmlStringTimeSpanYearAndMinutes()
        {
            TimeSpan ts = TimeSpan.FromDays(365).Add(TimeSpan.FromMinutes(45));
            string result = ts.ToXmlString();
            (result).Should().Be("P1Y0M0DT0H45M0.0S");
        }

        [Fact]
        public void TestToXmlStringTimeSpanMultipleYears()
        {
            TimeSpan ts = TimeSpan.FromDays(730);
            string result = ts.ToXmlString();
            (result).Should().Be("P2Y0M0DT0H0M0.0S");
        }

        [Fact]
        public void TestToXmlStringTimeSpanMultipleMonths()
        {
            TimeSpan ts = TimeSpan.FromDays(90);
            string result = ts.ToXmlString();
            (result).Should().Be("P0Y3M0DT0H0M0.0S");
        }

        // All time components
        [Fact]
        public void TestToXmlStringTimeSpanAllComponents()
        {
            TimeSpan ts = TimeSpan.FromDays(500)
                .Add(TimeSpan.FromHours(18))
                .Add(TimeSpan.FromMinutes(45))
                .Add(TimeSpan.FromSeconds(30))
                .Add(TimeSpan.FromMilliseconds(750));
            string result = ts.ToXmlString();
            // 500 days = 1 year (365) + 135 days (4 months of 30 days) + 15 days
            (result).Should().Be("P1Y4M15DT18H45M30.750S");
        }

        // Format validation tests
        [Fact]
        public void TestToXmlStringTimeSpanStartsWithP()
        {
            TimeSpan ts = TimeSpan.FromHours(1);
            string result = ts.ToXmlString();
            (result).Should().StartWith("P");
        }

        [Fact]
        public void TestToXmlStringTimeSpanContainsT()
        {
            TimeSpan ts = TimeSpan.FromHours(1);
            string result = ts.ToXmlString();
            (result).Should().Contain("T");
        }

        [Fact]
        public void TestToXmlStringTimeSpanContainsYearComponent()
        {
            TimeSpan ts = TimeSpan.FromDays(365);
            string result = ts.ToXmlString();
            (result).Should().Contain("Y");
        }

        [Fact]
        public void TestToXmlStringTimeSpanContainsMonthComponent()
        {
            TimeSpan ts = TimeSpan.FromDays(30);
            string result = ts.ToXmlString();
            (result).Should().Contain("M");
        }

        [Fact]
        public void TestToXmlStringTimeSpanContainsDayComponent()
        {
            TimeSpan ts = TimeSpan.FromDays(1);
            string result = ts.ToXmlString();
            (result).Should().Contain("D");
        }

        [Fact]
        public void TestToXmlStringTimeSpanContainsHourComponent()
        {
            TimeSpan ts = TimeSpan.FromHours(1);
            string result = ts.ToXmlString();
            (result).Should().Contain("H");
        }

        [Fact]
        public void TestToXmlStringTimeSpanContainsSecondComponent()
        {
            TimeSpan ts = TimeSpan.FromSeconds(1);
            string result = ts.ToXmlString();
            (result).Should().Contain("S");
        }

        [Fact]
        public void TestToXmlStringTimeSpanContainsDecimalPoint()
        {
            TimeSpan ts = TimeSpan.FromSeconds(1);
            string result = ts.ToXmlString();
            (result).Should().Contain(".");
        }

        #endregion
    }
}
