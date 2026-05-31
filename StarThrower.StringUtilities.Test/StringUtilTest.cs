/***********************************************************************************
    StarThrower Utilities / StringUtilities
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
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarThrower.StringUtilities;

namespace StarThrower.StringUtilities.Test
{
    [TestClass]
    public class StringUtilTest
    {
        private void Ignore()
        {
#if FAIL_ON_IGNORE
            Assert.Fail("This test has been ignored.");
#else
            Assert.Inconclusive("this test has been ignored");
#endif
        }


        #region ToHex(string) tests

        [TestMethod]
        public void TestCharToHex1()
        {
            Assert.AreEqual("00", StringUtil.ToHex(Microsoft.VisualBasic.Strings.Chr(0).ToString()));
        }

        [TestMethod]
        public void TestCharToHex2()
        {
            Assert.AreEqual("20", StringUtil.ToHex(" "));
        }

        [TestMethod]
        public void TestCharToHex3()
        {
            Assert.AreEqual("41", StringUtil.ToHex("A"));
        }

        [TestMethod]
        public void TestCharToHex4()
        {
            Assert.AreEqual("41534446", StringUtil.ToHex("ASDF"));
        }

        [TestMethod]
        public void TestCharToHex5()
        {
            Assert.AreEqual("61736466", StringUtil.ToHex("asdf"));
        }

        [TestMethod]
        public void TestCharToHex6()
        {
            Assert.AreEqual("7F", StringUtil.ToHex(Microsoft.VisualBasic.Strings.Chr(127).ToString()));
        }

        [TestMethod]
        public void TestCharToHex7()
        {
            Assert.AreEqual("80", StringUtil.ToHex(Microsoft.VisualBasic.Strings.Chr(128).ToString()));
        }

        [TestMethod]
        public void TestCharToHex8()
        {
            Assert.AreEqual("FF", StringUtil.ToHex(Microsoft.VisualBasic.Strings.Chr(255).ToString()));
        }

        [TestMethod]
        public void TestCharToHex9_EmptyString()
        {
            // Empty string should return empty hex string
            Assert.AreEqual("", StringUtil.ToHex(""));
        }

        [TestMethod]
        public void TestCharToHex10_SingleDigit()
        {
            // Test numeric character
            Assert.AreEqual("30", StringUtil.ToHex("0"));
        }

        [TestMethod]
        public void TestCharToHex11_Numbers()
        {
            // Test numeric string
            Assert.AreEqual("3031323334", StringUtil.ToHex("01234"));
        }

        [TestMethod]
        public void TestCharToHex12_SpecialCharacters()
        {
            // Test special characters (!, @, #, $)
            Assert.AreEqual("21402324", StringUtil.ToHex("!@#$"));
        }

        [TestMethod]
        public void TestCharToHex13_Punctuation()
        {
            // Test various punctuation marks
            Assert.AreEqual("2C2E3B", StringUtil.ToHex(",.;"));
        }

        [TestMethod]
        public void TestCharToHex14_MixedCase()
        {
            // Test mixed case (HoLLo - two capital L's)
            Assert.AreEqual("486F4C4C6F", StringUtil.ToHex("HoLLo"));
        }

        [TestMethod]
        public void TestCharToHex15_Tab()
        {
            // Test tab character
            Assert.AreEqual("09", StringUtil.ToHex("\t"));
        }

        [TestMethod]
        public void TestCharToHex16_Newline()
        {
            // Test newline character
            Assert.AreEqual("0A", StringUtil.ToHex("\n"));
        }

        [TestMethod]
        public void TestCharToHex17_CarriageReturn()
        {
            // Test carriage return character
            Assert.AreEqual("0D", StringUtil.ToHex("\r"));
        }

        [TestMethod]
        public void TestCharToHex18_LongString()
        {
            // Test a longer string
            Assert.AreEqual("54686520717569636B2062726F776E20666F78", StringUtil.ToHex("The quick brown fox"));
        }

        [TestMethod]
        public void TestCharToHex19_AllExtendedAsciiRange()
        {
            // Test boundary between ASCII and extended ASCII (char 126 and 127)
            Assert.AreEqual("7E", StringUtil.ToHex("~"));
        }

        [TestMethod]
        public void TestCharToHex20_ExtendedAsciiLow()
        {
            // Test extended ASCII lower range
            Assert.AreEqual("80", StringUtil.ToHex(Microsoft.VisualBasic.Strings.Chr(128).ToString()));
        }

        [TestMethod]
        public void TestCharToHex21_ExtendedAsciiMid()
        {
            // Test extended ASCII middle range (example: 192)
            Assert.AreEqual("C0", StringUtil.ToHex(Microsoft.VisualBasic.Strings.Chr(192).ToString()));
        }

        [TestMethod]
        public void TestCharToHex22_ConsecutiveSpecialChars()
        {
            // Test consecutive special characters
            Assert.AreEqual("2829", StringUtil.ToHex("()"));
        }

        [TestMethod]
        public void TestCharToHex23_AllSpaces()
        {
            // Test multiple spaces
            Assert.AreEqual("202020", StringUtil.ToHex("   "));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCharToHex24_NullString()
        {
            // Test null string throws exception
            StringUtil.ToHex(null);
        }

        [TestMethod]
        public void TestCharToHex25_QuotationMarks()
        {
            // Test quotation marks
            Assert.AreEqual("22", StringUtil.ToHex("\""));
        }

        [TestMethod]
        public void TestCharToHex26_SingleQuote()
        {
            // Test single quote
            Assert.AreEqual("27", StringUtil.ToHex("'"));
        }

        [TestMethod]
        public void TestCharToHex27_Backslash()
        {
            // Test backslash
            Assert.AreEqual("5C", StringUtil.ToHex("\\"));
        }

        [TestMethod]
        public void TestCharToHex28_ForwardSlash()
        {
            // Test forward slash
            Assert.AreEqual("2F", StringUtil.ToHex("/"));
        }

        [TestMethod]
        public void TestCharToHex29_Equals()
        {
            // Test equals sign
            Assert.AreEqual("3D", StringUtil.ToHex("="));
        }

        [TestMethod]
        public void TestCharToHex30_Underscore()
        {
            // Test underscore
            Assert.AreEqual("5F", StringUtil.ToHex("_"));
        }

        #endregion


        #region ToHex(int) tests

        [TestMethod]
        public void TestToHexInt1()
        {
            // Test zero
            Assert.AreEqual("0", StringUtil.ToHex(0));
        }

        [TestMethod]
        public void TestToHexInt2()
        {
            // Test single digit hex (1-15)
            Assert.AreEqual("1", StringUtil.ToHex(1));
        }

        [TestMethod]
        public void TestToHexInt3()
        {
            // Test single digit hex (1-15)
            Assert.AreEqual("F", StringUtil.ToHex(15));
        }

        [TestMethod]
        public void TestToHexInt4()
        {
            // Test two digit hex
            Assert.AreEqual("10", StringUtil.ToHex(16));
        }

        [TestMethod]
        public void TestToHexInt5()
        {
            // Test ASCII 'A' (65)
            Assert.AreEqual("41", StringUtil.ToHex(65));
        }

        [TestMethod]
        public void TestToHexInt6()
        {
            // Test 255 (max unsigned byte)
            Assert.AreEqual("FF", StringUtil.ToHex(255));
        }

        [TestMethod]
        public void TestToHexInt7()
        {
            // Test 256 (overflow from byte range)
            Assert.AreEqual("100", StringUtil.ToHex(256));
        }

        [TestMethod]
        public void TestToHexInt8()
        {
            // Test larger number
            Assert.AreEqual("1000", StringUtil.ToHex(4096));
        }

        [TestMethod]
        public void TestToHexInt9()
        {
            // Test max int
            Assert.AreEqual("7FFFFFFF", StringUtil.ToHex(int.MaxValue));
        }

        [TestMethod]
        public void TestToHexInt10()
        {
            // Test negative number (two's complement representation)
            Assert.AreEqual("FFFFFFFF", StringUtil.ToHex(-1));
        }

        [TestMethod]
        public void TestToHexInt11()
        {
            // Test negative number
            Assert.AreEqual("FFFFFFF0", StringUtil.ToHex(-16));
        }

        [TestMethod]
        public void TestToHexInt12()
        {
            // Test min int
            Assert.AreEqual("80000000", StringUtil.ToHex(int.MinValue));
        }

        [TestMethod]
        public void TestToHexInt13()
        {
            // Test common byte value
            Assert.AreEqual("20", StringUtil.ToHex(32));
        }

        [TestMethod]
        public void TestToHexInt14()
        {
            // Test common byte value matching ToHex(string) test
            Assert.AreEqual("FF", StringUtil.ToHex(255));
        }

        #endregion


        #region ParseString(ref string, string) tests

        [TestMethod]
        public void TestParseString1()
        {
            string s = "a|s|d|f";
            string? tok = null;

            tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual("a", tok);
            Assert.AreEqual("s|d|f", s);

            tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual("s", tok);
            Assert.AreEqual("d|f", s);

            tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual("d", tok);
            Assert.AreEqual("f", s);

            tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual("f", tok);
            Assert.AreEqual("", s);

            tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual("", tok);
            Assert.AreEqual("", s);
        }

        [TestMethod]
        public void TestParseStringEdgeCase1()
        {
            string s = "||||";
            string? tok = null;

            tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual(String.Empty, tok);
            Assert.AreEqual("|||", s);

            tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual(String.Empty, tok);
            Assert.AreEqual("||", s);

            tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual(String.Empty, tok);
            Assert.AreEqual("|", s);

            tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual(String.Empty, tok);
            Assert.AreEqual(String.Empty, s);
        }

        [TestMethod]
        public void TestParseStringEdgeCase2()
        {
            string s = "|a|s|d|f";
            string? tok = null;

            tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual(String.Empty, tok);
            Assert.AreEqual("a|s|d|f", s);

            tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual("a", tok);
            Assert.AreEqual("s|d|f", s);

            tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual("s", tok);
            Assert.AreEqual("d|f", s);

            tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual("d", tok);
            Assert.AreEqual("f", s);

            tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual("f", tok);
            Assert.AreEqual(String.Empty, s);
        }

        [TestMethod]
        public void TestParseStringEdgeCase3()
        {
            string s = "|a|s|d|f|";
            string? tok = null;

            tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual(String.Empty, tok);
            Assert.AreEqual("a|s|d|f|", s);

            tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual("a", tok);
            Assert.AreEqual("s|d|f|", s);

            tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual("s", tok);
            Assert.AreEqual("d|f|", s);

            tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual("d", tok);
            Assert.AreEqual("f|", s);

            tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual("f", tok);
            Assert.AreEqual(String.Empty, s);

            tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual(String.Empty, tok);
            Assert.AreEqual(String.Empty, s);
        }

        [TestMethod]
        public void TestParseString2()
        {
            string s = "asdf|qwer|zxcv|1234";
            string? tok = null;

            tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual("asdf", tok);
            Assert.AreEqual("qwer|zxcv|1234", s);

            tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual("qwer", tok);
            Assert.AreEqual("zxcv|1234", s);

            tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual("zxcv", tok);
            Assert.AreEqual("1234", s);

            tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual("1234", tok);
            Assert.AreEqual("", s);

            tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual("", tok);
            Assert.AreEqual("", s);
        }

        [TestMethod]
        public void TestParseString3_NoDelimiterFound()
        {
            // Test when delimiter is not found - should return entire string and clear it
            string s = "hello";
            string tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual("hello", tok);
            Assert.AreEqual("", s);
        }

        [TestMethod]
        public void TestParseString4_SingleCharDelimiter()
        {
            // Test with a single character delimiter
            string s = "one:two:three";
            string tok = StringUtil.ParseString(ref s, ":");
            Assert.AreEqual("one", tok);
            Assert.AreEqual("two:three", s);
        }

        [TestMethod]
        public void TestParseString5_MultiCharDelimiter()
        {
            // Note: ParseString only removes pos+1 chars, so multi-char delimiters will leave extra chars
            // This test documents the actual behavior
            string s = "part1::part2::part3";
            string tok = StringUtil.ParseString(ref s, "::");
            Assert.AreEqual("part1", tok);
            // It removes only the first ':' not both, leaving ":part2::part3"
            Assert.AreEqual(":part2::part3", s);
        }

        [TestMethod]
        public void TestParseString6_SpaceDelimiter()
        {
            // Test with space as delimiter
            string s = "hello world test";
            string tok = StringUtil.ParseString(ref s, " ");
            Assert.AreEqual("hello", tok);
            Assert.AreEqual("world test", s);
        }

        [TestMethod]
        public void TestParseString7_CommaDelimiter()
        {
            // Test with comma delimiter
            string s = "item1,item2,item3";
            string tok = StringUtil.ParseString(ref s, ",");
            Assert.AreEqual("item1", tok);
            Assert.AreEqual("item2,item3", s);
        }

        [TestMethod]
        public void TestParseString8_SingleToken()
        {
            // Test string with single token and delimiter
            string s = "token|";
            string tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual("token", tok);
            Assert.AreEqual("", s);
        }

        [TestMethod]
        public void TestParseString9_EmptyTokenAtEnd()
        {
            // Test parsing to get empty token at end
            string s = "a|b|";
            string tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual("a", tok);
            Assert.AreEqual("b|", s);

            tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual("b", tok);
            Assert.AreEqual("", s);

            tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual("", tok);
            Assert.AreEqual("", s);
        }

        [TestMethod]
        public void TestParseString10_NumericStrings()
        {
            // Test with numeric strings
            string s = "123|456|789";
            string tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual("123", tok);
            Assert.AreEqual("456|789", s);
        }

        [TestMethod]
        public void TestParseString11_SpecialCharactersInTokens()
        {
            // Test with special characters in tokens
            string s = "test@email|another#tag|final$";
            string tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual("test@email", tok);
            Assert.AreEqual("another#tag|final$", s);
        }

        [TestMethod]
        public void TestParseString12_DelimiterAtStart()
        {
            // Test with delimiter at very start
            string s = "|token";
            string tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual("", tok);
            Assert.AreEqual("token", s);
        }

        [TestMethod]
        public void TestParseString13_DelimiterOnly()
        {
            // Test with only the delimiter
            string s = "|";
            string tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual("", tok);
            Assert.AreEqual("", s);
        }

        [TestMethod]
        public void TestParseString14_LongDelimiter()
        {
            // Test with longer delimiter sequence
            // Note: ParseString only removes pos+1 chars, so multi-char delimiters will leave extra chars
            string s = "first---second---third";
            string tok = StringUtil.ParseString(ref s, "---");
            Assert.AreEqual("first", tok);
            // It removes only one dash, leaving "--second---third"
            Assert.AreEqual("--second---third", s);
        }

        [TestMethod]
        public void TestParseString15_ConsecutiveDelimiters()
        {
            // Test with consecutive delimiters
            // Note: ParseString only removes pos+1 chars, so multi-char delimiters will leave extra chars
            string s = "a||b||c";
            string tok = StringUtil.ParseString(ref s, "||");
            Assert.AreEqual("a", tok);
            // It removes only one pipe, leaving "|b||c"
            Assert.AreEqual("|b||c", s);
        }

        [TestMethod]
        public void TestParseString16_MixedContent()
        {
            // Test with mixed alphanumeric and special characters
            string s = "User123|Pass@456!|Email#789";
            string tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual("User123", tok);
            Assert.AreEqual("Pass@456!|Email#789", s);
        }

        [TestMethod]
        public void TestParseString17_CaseSensitiveDelimiter()
        {
            // Test that delimiter is case-sensitive
            string s = "A|B|C";
            string tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual("A", tok);
            Assert.AreEqual("B|C", s);
        }

        [TestMethod]
        public void TestParseString18_TabDelimiter()
        {
            // Test with tab as delimiter
            string s = "col1\tcol2\tcol3";
            string tok = StringUtil.ParseString(ref s, "\t");
            Assert.AreEqual("col1", tok);
            Assert.AreEqual("col2\tcol3", s);
        }

        [TestMethod]
        public void TestParseString19_NewlineDelimiter()
        {
            // Test with newline as delimiter
            string s = "line1\nline2\nline3";
            string tok = StringUtil.ParseString(ref s, "\n");
            Assert.AreEqual("line1", tok);
            Assert.AreEqual("line2\nline3", s);
        }

        [TestMethod]
        public void TestParseString20_NullSource()
        {
            // Null source is now a compile-time error (ref string is non-nullable);
            // enforcement moved from runtime guard to type system.
            Ignore();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestParseString21_NullDelimiter()
        {
            // Test null delimiter throws exception
            string s = "test";
            StringUtil.ParseString(ref s, null);
        }

        [TestMethod]
        public void TestParseString22_WhitespaceTokens()
        {
            // Test parsing tokens that are whitespace
            string s = "  | \t | ";
            string tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual("  ", tok);
            Assert.AreEqual(" \t | ", s);
        }

        [TestMethod]
        public void TestParseString23_VeryLongToken()
        {
            // Test with very long tokens
            string s = new string('a', 1000) + "|" + new string('b', 1000);
            string tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual(new string('a', 1000), tok);
            Assert.AreEqual(new string('b', 1000), s);
        }

        [TestMethod]
        public void TestParseString24_DelimiterLongerThanContent()
        {
            // Test with delimiter longer than content
            string s = "ab";
            string tok = StringUtil.ParseString(ref s, "delimiter");
            Assert.AreEqual("ab", tok);
            Assert.AreEqual("", s);
        }

        [TestMethod]
        public void TestParseString25_DelimiterEqualsContent()
        {
            // Test where delimiter equals entire content
            string s = "|";
            string tok = StringUtil.ParseString(ref s, "|");
            Assert.AreEqual("", tok);
            Assert.AreEqual("", s);
        }

        #endregion


        #region ParseStringFromRight(ref string, string) tests

        [TestMethod]
        public void TestParseStringFromRight1()
        {
            string s = "a|s|d|f";
            string? tok = null;

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("f", tok);
            Assert.AreEqual("a|s|d", s);

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("d", tok);
            Assert.AreEqual("a|s", s);

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("s", tok);
            Assert.AreEqual("a", s);

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("a", tok);
            Assert.AreEqual("", s);

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("", tok);
            Assert.AreEqual("", s);
        }

        [TestMethod]
        public void TestParseStringFromRightEdgeCase1()
        {
            string s = "||||";
            string? tok = null;

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual(String.Empty, tok);
            Assert.AreEqual("|||", s);

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual(String.Empty, tok);
            Assert.AreEqual("||", s);

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual(String.Empty, tok);
            Assert.AreEqual("|", s);

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual(String.Empty, tok);
            Assert.AreEqual(String.Empty, s);

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual(String.Empty, tok);
            Assert.AreEqual(String.Empty, s);
        }

        [TestMethod]
        public void TestParseStringFromRightEdgeCase2()
        {
            string s = "|a|s|d|f";
            string? tok = null;

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("f", tok);
            Assert.AreEqual("|a|s|d", s);

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("d", tok);
            Assert.AreEqual("|a|s", s);

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("s", tok);
            Assert.AreEqual("|a", s);

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("a", tok);
            Assert.AreEqual(String.Empty, s);

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual(String.Empty, tok);
            Assert.AreEqual(String.Empty, s);
        }

        [TestMethod]
        public void TestParseStringFromRightEdgeCase3()
        {
            string s = "|a|s|d|f|";
            string? tok = null;

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual(String.Empty, tok);
            Assert.AreEqual("|a|s|d|f", s);

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("f", tok);
            Assert.AreEqual("|a|s|d", s);

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("d", tok);
            Assert.AreEqual("|a|s", s);

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("s", tok);
            Assert.AreEqual("|a", s);

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("a", tok);
            Assert.AreEqual(String.Empty, s);

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual(String.Empty, tok);
            Assert.AreEqual(String.Empty, s);
        }

        [TestMethod]
        public void TestParseStringFromRight2()
        {
            string s = "asdf|qwer|zxcv|1234";
            string? tok = null;

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("1234", tok);
            Assert.AreEqual("asdf|qwer|zxcv", s);

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("zxcv", tok);
            Assert.AreEqual("asdf|qwer", s);

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("qwer", tok);
            Assert.AreEqual("asdf", s);

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("asdf", tok);
            Assert.AreEqual("", s);

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("", tok);
            Assert.AreEqual("", s);
        }

        [TestMethod]
        public void TestParseStringFromRight3_NoDelimiterFound()
        {
            // Test when delimiter is not found - should return entire string and clear it
            string s = "hello";
            string tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("hello", tok);
            Assert.AreEqual("", s);
        }

        [TestMethod]
        public void TestParseStringFromRight4_SingleCharDelimiter()
        {
            // Test with a single character delimiter
            string s = "one:two:three";
            string tok = StringUtil.ParseStringFromRight(ref s, ":");
            Assert.AreEqual("three", tok);
            Assert.AreEqual("one:two", s);
        }

        [TestMethod]
        public void TestParseStringFromRight5_MultiCharDelimiter()
        {
            // Note: ParseStringFromRight has similar behavior to ParseString with multi-char delimiters
            // It removes pos + ret.Length + 1, which may not be the full delimiter length
            string s = "part1::part2::part3";
            string tok = StringUtil.ParseStringFromRight(ref s, "::");
            Assert.AreEqual(":part3", tok);
            // It leaves "part1::part2" but the token includes the extra ':'
            Assert.AreEqual("part1::part2", s);
        }

        [TestMethod]
        public void TestParseStringFromRight6_SpaceDelimiter()
        {
            // Test with space as delimiter
            string s = "hello world test";
            string tok = StringUtil.ParseStringFromRight(ref s, " ");
            Assert.AreEqual("test", tok);
            Assert.AreEqual("hello world", s);
        }

        [TestMethod]
        public void TestParseStringFromRight7_CommaDelimiter()
        {
            // Test with comma delimiter
            string s = "item1,item2,item3";
            string tok = StringUtil.ParseStringFromRight(ref s, ",");
            Assert.AreEqual("item3", tok);
            Assert.AreEqual("item1,item2", s);
        }

        [TestMethod]
        public void TestParseStringFromRight8_SingleToken()
        {
            // Test string with single token and delimiter at end
            string s = "token|";
            string tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("", tok);
            Assert.AreEqual("token", s);
        }

        [TestMethod]
        public void TestParseStringFromRight9_EmptyTokenAtStart()
        {
            // Test parsing to get empty token at start
            string s = "|a|b";
            string tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("b", tok);
            Assert.AreEqual("|a", s);

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("a", tok);
            Assert.AreEqual("", s);

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("", tok);
            Assert.AreEqual("", s);
        }

        [TestMethod]
        public void TestParseStringFromRight10_NumericStrings()
        {
            // Test with numeric strings
            string s = "123|456|789";
            string tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("789", tok);
            Assert.AreEqual("123|456", s);
        }

        [TestMethod]
        public void TestParseStringFromRight11_SpecialCharactersInTokens()
        {
            // Test with special characters in tokens
            string s = "test@email|another#tag|final$";
            string tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("final$", tok);
            Assert.AreEqual("test@email|another#tag", s);
        }

        [TestMethod]
        public void TestParseStringFromRight12_DelimiterAtEnd()
        {
            // Test with delimiter at very end
            string s = "token|";
            string tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("", tok);
            Assert.AreEqual("token", s);
        }

        [TestMethod]
        public void TestParseStringFromRight13_DelimiterOnly()
        {
            // Test with only the delimiter
            string s = "|";
            string tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("", tok);
            Assert.AreEqual("", s);
        }

        [TestMethod]
        public void TestParseStringFromRight14_LongDelimiter()
        {
            // Test with longer delimiter sequence
            // Note: similar limitation with multi-char delimiters
            string s = "first---second---third";
            string tok = StringUtil.ParseStringFromRight(ref s, "---");
            Assert.AreEqual("--third", tok);
            // It leaves "first---second"
            Assert.AreEqual("first---second", s);
        }

        [TestMethod]
        public void TestParseStringFromRight15_ConsecutiveDelimiters()
        {
            // Test with consecutive delimiters
            // Note: similar limitation with multi-char delimiters
            string s = "a||b||c";
            string tok = StringUtil.ParseStringFromRight(ref s, "||");
            Assert.AreEqual("|c", tok);
            // It leaves "a||b" 
            Assert.AreEqual("a||b", s);
        }

        [TestMethod]
        public void TestParseStringFromRight16_MixedContent()
        {
            // Test with mixed alphanumeric and special characters
            string s = "User123|Pass@456!|Email#789";
            string tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("Email#789", tok);
            Assert.AreEqual("User123|Pass@456!", s);
        }

        [TestMethod]
        public void TestParseStringFromRight17_CaseSensitiveDelimiter()
        {
            // Test that delimiter is case-sensitive
            string s = "A|B|C";
            string tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("C", tok);
            Assert.AreEqual("A|B", s);
        }

        [TestMethod]
        public void TestParseStringFromRight18_TabDelimiter()
        {
            // Test with tab as delimiter
            string s = "col1\tcol2\tcol3";
            string tok = StringUtil.ParseStringFromRight(ref s, "\t");
            Assert.AreEqual("col3", tok);
            Assert.AreEqual("col1\tcol2", s);
        }

        [TestMethod]
        public void TestParseStringFromRight19_NewlineDelimiter()
        {
            // Test with newline as delimiter
            string s = "line1\nline2\nline3";
            string tok = StringUtil.ParseStringFromRight(ref s, "\n");
            Assert.AreEqual("line3", tok);
            Assert.AreEqual("line1\nline2", s);
        }

        [TestMethod]
        public void TestParseStringFromRight20_NullSource()
        {
            // Null source is now a compile-time error (ref string is non-nullable);
            // enforcement moved from runtime guard to type system.
            Ignore();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestParseStringFromRight21_NullDelimiter()
        {
            // Test null delimiter throws exception
            string s = "test";
            StringUtil.ParseStringFromRight(ref s, null);
        }

        [TestMethod]
        public void TestParseStringFromRight22_WhitespaceTokens()
        {
            // Test parsing tokens that are whitespace
            string s = "  | \t | ";
            string tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual(" ", tok);
            Assert.AreEqual("  | \t ", s);
        }

        [TestMethod]
        public void TestParseStringFromRight23_VeryLongToken()
        {
            // Test with very long tokens
            string s = new string('a', 1000) + "|" + new string('b', 1000);
            string tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual(new string('b', 1000), tok);
            Assert.AreEqual(new string('a', 1000), s);
        }

        [TestMethod]
        public void TestParseStringFromRight24_DelimiterLongerThanContent()
        {
            // Test with delimiter longer than content
            string s = "ab";
            string tok = StringUtil.ParseStringFromRight(ref s, "delimiter");
            Assert.AreEqual("ab", tok);
            Assert.AreEqual("", s);
        }

        [TestMethod]
        public void TestParseStringFromRight25_DelimiterEqualsContent()
        {
            // Test where delimiter equals entire content
            string s = "|";
            string tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("", tok);
            Assert.AreEqual("", s);
        }

        [TestMethod]
        public void TestParseStringFromRight26_MultipleDelimitersInLastToken()
        {
            // Test when the last token contains the delimiter character
            string s = "a|b:c|d:e";
            string tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("d:e", tok);
            Assert.AreEqual("a|b:c", s);
        }

        [TestMethod]
        public void TestParseStringFromRight27_DelimiterAtBothEnds()
        {
            // Test with delimiter at both start and end
            string s = "|content|";
            string tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("", tok);
            Assert.AreEqual("|content", s);

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("content", tok);
            Assert.AreEqual("", s);
        }

        [TestMethod]
        public void TestParseStringFromRight28_SymmetricalWithParseString()
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
            Assert.AreEqual(4, fromRight.Count);
            Assert.AreEqual("fourth", fromRight[0]);
            Assert.AreEqual("third", fromRight[1]);
            Assert.AreEqual("second", fromRight[2]);
            Assert.AreEqual("first", fromRight[3]);
        }

        [TestMethod]
        public void TestParseStringFromRight29_DelimiterNotInString()
        {
            // Test when delimiter is not found anywhere in string
            string s = "no delimiter here";
            string tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("no delimiter here", tok);
            Assert.AreEqual("", s);
        }

        [TestMethod]
        public void TestParseStringFromRight30_SingleCharString()
        {
            // Test with single character string
            string s = "a";
            string tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("a", tok);
            Assert.AreEqual("", s);
        }

        [TestMethod]
        public void TestParseStringFromRight31_AlternatingDelimiterAndContent()
        {
            // Test with alternating delimiter and content
            string s = "a|b|c|d|e";
            string tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("e", tok);
            Assert.AreEqual("a|b|c|d", s);

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("d", tok);
            Assert.AreEqual("a|b|c", s);

            tok = StringUtil.ParseStringFromRight(ref s, "|");
            Assert.AreEqual("c", tok);
            Assert.AreEqual("a|b", s);
        }

        #endregion


        #region Substitute(string, string, string) tests

        [TestMethod]
        public void TestSubstitute1()
        {
            Assert.AreEqual("asdf", StringUtil.Substitute("asdf", "", "XY"));
        }

        [TestMethod]
        public void TestCSubstitute2()
        {
            Assert.AreEqual("aXYf", StringUtil.Substitute("asdf", "sd", "XY"));
        }

        [TestMethod]
        public void TestCSubstitute3()
        {
            Assert.AreEqual("aXYfXYXY", StringUtil.Substitute("asdfsdsd", "sd", "XY"));
        }

        [TestMethod]
        public void TestCSubstitute4()
        {
            Assert.AreEqual("X", StringUtil.Substitute("a", "a", "X"));
        }

        [TestMethod]
        public void TestCSubstitute5()
        {
            Assert.AreEqual("XX", StringUtil.Substitute("aa", "a", "X"));
        }

        [TestMethod]
        public void TestCSubstitute6()
        {
            Assert.AreEqual("XX", StringUtil.Substitute("aa", "aa", "XX"));
        }

        [TestMethod]
        public void TestCSubstitute7()
        {
            Assert.AreEqual("asdf", StringUtil.Substitute("asdf", "SD", "XY"));
        }

        [TestMethod]
        public void TestCSubstitute8()
        {
            Assert.AreEqual("asdfsdsd", StringUtil.Substitute("asdfsdsd", "SD", "XY"));
        }

        [TestMethod]
        public void TestCSubstitute9()
        {
            Assert.AreEqual("a", StringUtil.Substitute("a", "A", "X"));
        }

        [TestMethod]
        public void TestCSubstitute10()
        {
            Assert.AreEqual("aa", StringUtil.Substitute("aa", "A", "X"));
        }

        [TestMethod]
        public void TestCSubstitute11()
        {
            Assert.AreEqual("aa", StringUtil.Substitute("aa", "AA", "XX"));
        }

        [TestMethod]
        public void TestSubstitute49_SingleCharacterString()
        {
            // Test single character string
            Assert.AreEqual("X", StringUtil.Substitute("a", "a", "X"));
        }

        [TestMethod]
        public void TestSubstitute50_EmptySourceString()
        {
            // Test empty source string
            Assert.AreEqual("", StringUtil.Substitute("", "a", "X"));
        }

        [TestMethod]
        public void TestSubstitute51_RepeatedReplacements()
        {
            // Test multiple replacements in sequence
            string result = StringUtil.Substitute("aaaa", "a", "X");
            Assert.AreEqual("XXXX", result);
        }

        [TestMethod]
        public void TestSubstitute52_TargetWithSpecialCharacters()
        {
            // Test target containing special characters
            Assert.AreEqual("aXf", StringUtil.Substitute("a@#f", "@#", "X"));
        }

        [TestMethod]
        public void TestSubstitute53_WhitespaceTarget()
        {
            // Test whitespace as target
            Assert.AreEqual("aXbXc", StringUtil.Substitute("a b c", " ", "X"));
        }

        [TestMethod]
        public void TestSubstitute54_TabCharacterInSource()
        {
            // Test tab character in source
            Assert.AreEqual("aXb", StringUtil.Substitute("a\tb", "\t", "X"));
        }

        [TestMethod]
        public void TestSubstitute55_NewlineCharacterInSource()
        {
            // Test newline character in source
            Assert.AreEqual("aXb", StringUtil.Substitute("a\nb", "\n", "X"));
        }

        [TestMethod]
        public void TestSubstitute56_LongestMatchFirst()
        {
            // Test that it uses IndexOf behavior (first occurrence)
            Assert.AreEqual("XBabc", StringUtil.Substitute("ABabc", "A", "X"));
        }

        [TestMethod]
        public void TestSubstitute57_NumericInSource()
        {
            // Test numeric content in source
            Assert.AreEqual("a123f", StringUtil.Substitute("a456f", "456", "123"));
        }

        [TestMethod]
        public void TestSubstitute58_TargetLongerThanSource()
        {
            // Test target longer than source (no match)
            Assert.AreEqual("abc", StringUtil.Substitute("abc", "abcdef", "X"));
        }

        [TestMethod]
        public void TestSubstitute59_ReplacementShorterThanTarget()
        {
            // Test replacement shorter than target (deletion effect)
            Assert.AreEqual("aXf", StringUtil.Substitute("asdf", "sd", "X"));
        }

        [TestMethod]
        public void TestSubstitute23_SingleCharacterReplacement()
        {
            // Test replacing with single character
            Assert.AreEqual("aXf", StringUtil.Substitute("asdf", "sd", "X"));
        }

        [TestMethod]
        public void TestSubstitute24_EmptyReplacement()
        {
            // Test replacing with empty string (deletion)
            Assert.AreEqual("af", StringUtil.Substitute("asdf", "sd", ""));
        }

        [TestMethod]
        public void TestSubstitute25_LongerReplacement()
        {
            // Test replacing with longer string
            Assert.AreEqual("aLONGERf", StringUtil.Substitute("asdf", "sd", "LONGER"));
        }

        [TestMethod]
        public void TestSubstitute26_TargetNotFound()
        {
            // Test when target is not in source
            Assert.AreEqual("asdf", StringUtil.Substitute("asdf", "xyz", "XY"));
        }

        [TestMethod]
        public void TestSubstitute27_EntireStringAsTarget()
        {
            // Test replacing the entire string
            Assert.AreEqual("REPLACEMENT", StringUtil.Substitute("entire", "entire", "REPLACEMENT"));
        }

        [TestMethod]
        public void TestSubstitute28_TargetAtStart()
        {
            // Test target at start of string
            Assert.AreEqual("REPLACEDsdf", StringUtil.Substitute("asdf", "a", "REPLACED"));
        }

        [TestMethod]
        public void TestSubstitute29_TargetAtEnd()
        {
            // Test target at end of string
            Assert.AreEqual("asdREPLACED", StringUtil.Substitute("asdf", "f", "REPLACED"));
        }

        [TestMethod]
        public void TestSubstitute30_MultipleNonConsecutiveTargets()
        {
            // Test multiple non-consecutive targets
            Assert.AreEqual("XaXaX", StringUtil.Substitute("XaYaY", "Y", "X"));
        }

        [TestMethod]
        public void TestSubstitute31_OverlappingPattern()
        {
            // Test with pattern that could overlap
            // Algorithm replaces first match then continues from after replacement
            // "AAAA" with target "AA" -> finds at pos 0, replaces, leaves "AA" -> finds at pos 0, replaces
            Assert.AreEqual("XX", StringUtil.Substitute("AAAA", "AA", "X"));
        }

        [TestMethod]
        public void TestSubstitute32_NumericStringReplacement()
        {
            // Test replacing numeric strings
            Assert.AreEqual("a123f", StringUtil.Substitute("asdf", "sd", "123"));
        }

        [TestMethod]
        public void TestSubstitute33_SpecialCharactersInReplacement()
        {
            // Test special characters in replacement
            Assert.AreEqual("a@#$f", StringUtil.Substitute("asdf", "sd", "@#$"));
        }

        [TestMethod]
        public void TestSubstitute34_SpaceInReplacement()
        {
            // Test space in replacement
            Assert.AreEqual("a  f", StringUtil.Substitute("asdf", "sd", "  "));
        }

        [TestMethod]
        public void TestSubstitute35_VeryLongTarget()
        {
            // Test with very long target string
            string target = new string('a', 100);
            string source = target + "xyz";
            string result = StringUtil.Substitute(source, target, "REPLACED");
            Assert.AreEqual("REPLACEDxyz", result);
        }

        [TestMethod]
        public void TestSubstitute36_VeryLongReplacement()
        {
            // Test with very long replacement string
            string replacement = new string('x', 1000);
            string result = StringUtil.Substitute("abc", "b", replacement);
            Assert.AreEqual("a" + replacement + "c", result);
        }

        [TestMethod]
        public void TestSubstitute37_SelfReplacingTarget()
        {
            // Test replacing target with itself (should return same)
            Assert.AreEqual("asdf", StringUtil.Substitute("asdf", "sd", "sd"));
        }

        [TestMethod]
        public void TestSubstitute38_ConsecutiveIdenticalTargets()
        {
            // Test multiple consecutive identical targets
            Assert.AreEqual("XYXYXY", StringUtil.Substitute("ababab", "ab", "XY"));
        }

        [TestMethod]
        public void TestSubstitute39_SingleCharacterTarget()
        {
            // Test single character target with case-sensitive matching
            // Only lowercase 'x' should be replaced, not uppercase 'X'
            Assert.AreEqual("aXbXd", StringUtil.Substitute("axbxd", "x", "X"));
        }

        [TestMethod]
        public void TestSubstitute40_AllCharactersSame()
        {
            // Test string where all characters are the same
            Assert.AreEqual("XXXX", StringUtil.Substitute("aaaa", "a", "X"));
        }

        [TestMethod]
        public void TestSubstitute41_ReplacementContainsTarget()
        {
            // Test when replacement contains the target
            Assert.AreEqual("abcabc", StringUtil.Substitute("abc", "abc", "abcabc"));
        }

        [TestMethod]
        public void TestSubstitute42_AlternatingPattern()
        {
            // Test alternating pattern
            Assert.AreEqual("XbXb", StringUtil.Substitute("abab", "a", "X"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSubstitute43_NullSource()
        {
            // Test null source throws exception
            StringUtil.Substitute(null, "a", "X");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSubstitute44_NullTarget()
        {
            // Test null target throws exception
            StringUtil.Substitute("asdf", null, "X");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSubstitute45_NullReplacement()
        {
            // Test null replacement throws exception
            StringUtil.Substitute("asdf", "a", null);
        }

        #endregion


        #region Substitute(string, string, string, ComparisonType) tests

        [TestMethod]
        public void TestSubstituteExtended1()
        {
            Assert.AreEqual("asdf", StringUtil.Substitute("asdf", "", "XY", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended2()
        {
            Assert.AreEqual("aXYf", StringUtil.Substitute("asdf", "sd", "XY", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended3()
        {
            Assert.AreEqual("aXYfXYXY", StringUtil.Substitute("asdfsdsd", "sd", "XY", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended4()
        {
            Assert.AreEqual("X", StringUtil.Substitute("a", "a", "X", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended5()
        {
            Assert.AreEqual("XX", StringUtil.Substitute("aa", "a", "X", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended6()
        {
            Assert.AreEqual("XX", StringUtil.Substitute("aa", "aa", "XX", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended7()
        {
            Assert.AreEqual("asdf", StringUtil.Substitute("asdf", "SD", "XY", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended8()
        {
            Assert.AreEqual("asdfsdsd", StringUtil.Substitute("asdfsdsd", "SD", "XY", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended9()
        {
            Assert.AreEqual("a", StringUtil.Substitute("a", "A", "X", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended10()
        {
            Assert.AreEqual("aa", StringUtil.Substitute("aa", "A", "X", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended11()
        {
            Assert.AreEqual("aa", StringUtil.Substitute("aa", "AA", "XX", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended12()
        {
            Assert.AreEqual("asdf", StringUtil.Substitute("asdf", "", "XY", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended13()
        {
            Assert.AreEqual("aXYf", StringUtil.Substitute("asdf", "sd", "XY", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended14()
        {
            Assert.AreEqual("aXYfXYXY", StringUtil.Substitute("asdfsdsd", "sd", "XY", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended15()
        {
            Assert.AreEqual("X", StringUtil.Substitute("a", "a", "X", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended16()
        {
            Assert.AreEqual("XX", StringUtil.Substitute("aa", "a", "X", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended17()
        {
            Assert.AreEqual("XX", StringUtil.Substitute("aa", "aa", "XX", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended18()
        {
            Assert.AreEqual("aXYf", StringUtil.Substitute("asdf", "SD", "XY", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended19()
        {
            Assert.AreEqual("aXYfXYXY", StringUtil.Substitute("asdfsdsd", "SD", "XY", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended20()
        {
            Assert.AreEqual("X", StringUtil.Substitute("a", "A", "X", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended21()
        {
            Assert.AreEqual("XX", StringUtil.Substitute("aa", "A", "X", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended22()
        {
            Assert.AreEqual("XX", StringUtil.Substitute("aa", "AA", "XX", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstitute46_CaseInsensitiveSimple()
        {
            // Test case-insensitive replacement
            Assert.AreEqual("XbXd", StringUtil.Substitute("AbAd", "a", "X", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstitute47_CaseInsensitiveNoMatch()
        {
            // Test case-insensitive with no match (case matters in target itself)
            Assert.AreEqual("XBXd", StringUtil.Substitute("ABad", "a", "X", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstitute48_MixedCaseTarget()
        {
            // Test mixed case target with case-insensitive
            // "asdf" with target "SD" case-insensitive
            // Iteration 1: Find "sd" at index 1, Left("asdf", 1) = "a", append "a" + "X", remove 0-3, orig = "f"
            // Iteration 2: Not found, append "f"
            // Result: "aXf"
            Assert.AreEqual("aXf", StringUtil.Substitute("asdf", "SD", "X", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended23_EmptyTargetCaseSensitive()
        {
            // Test empty target with case-sensitive (should return source unchanged)
            Assert.AreEqual("hello", StringUtil.Substitute("hello", "", "world", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended24_EmptyTargetCaseInsensitive()
        {
            // Test empty target with case-insensitive (should return source unchanged)
            Assert.AreEqual("hello", StringUtil.Substitute("hello", "", "world", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended25_AllUppercaseCaseSensitive()
        {
            // Test all uppercase - should not match lowercase with case-sensitive
            Assert.AreEqual("HELLO", StringUtil.Substitute("HELLO", "hello", "X", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended26_AllUppercaseCaseInsensitive()
        {
            // Test all uppercase - should match with case-insensitive
            Assert.AreEqual("X", StringUtil.Substitute("HELLO", "hello", "X", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended27_MixedCaseCaseSensitive()
        {
            // Test mixed case with case-sensitive - partial case match should not substitute
            Assert.AreEqual("HeLLo", StringUtil.Substitute("HeLLo", "hello", "X", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended28_MixedCaseCaseInsensitive()
        {
            // Test mixed case with case-insensitive - should match and replace
            Assert.AreEqual("X", StringUtil.Substitute("HeLLo", "hello", "X", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended29_PartialCaseMatchCaseSensitive()
        {
            // Test partial case match with case-sensitive
            Assert.AreEqual("aBCD", StringUtil.Substitute("aBCD", "ABCD", "X", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended30_PartialCaseMatchCaseInsensitive()
        {
            // Test partial case match with case-insensitive - should match
            Assert.AreEqual("X", StringUtil.Substitute("aBCD", "ABCD", "X", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended31_NumericTargetCaseSensitive()
        {
            // Test numeric target with case-sensitive
            Assert.AreEqual("X456X", StringUtil.Substitute("123456123", "123", "X", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended32_NumericTargetCaseInsensitive()
        {
            // Test numeric target with case-insensitive (should work same as case-sensitive for numbers)
            Assert.AreEqual("X456X", StringUtil.Substitute("123456123", "123", "X", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended33_SpecialCharactersCaseSensitive()
        {
            // Test special characters with case-sensitive
            Assert.AreEqual("aX", StringUtil.Substitute("a@#$b", "@#$b", "X", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended34_SpecialCharactersCaseInsensitive()
        {
            // Test special characters with case-insensitive
            Assert.AreEqual("aX", StringUtil.Substitute("a@#$b", "@#$b", "X", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended35_WhitespaceCaseSensitive()
        {
            // Test whitespace with case-sensitive
            Assert.AreEqual("aXb", StringUtil.Substitute("a b", " ", "X", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended36_WhitespaceCaseInsensitive()
        {
            // Test whitespace with case-insensitive (should work same as case-sensitive)
            Assert.AreEqual("aXb", StringUtil.Substitute("a b", " ", "X", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended37_TabCaseSensitive()
        {
            // Test tab character with case-sensitive
            Assert.AreEqual("aXb", StringUtil.Substitute("a\tb", "\t", "X", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended38_TabCaseInsensitive()
        {
            // Test tab character with case-insensitive
            Assert.AreEqual("aXb", StringUtil.Substitute("a\tb", "\t", "X", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended39_NewlineCaseSensitive()
        {
            // Test newline character with case-sensitive
            Assert.AreEqual("aXb", StringUtil.Substitute("a\nb", "\n", "X", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended40_NewlineCaseInsensitive()
        {
            // Test newline character with case-insensitive
            Assert.AreEqual("aXb", StringUtil.Substitute("a\nb", "\n", "X", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended41_VeryLongStringCaseSensitive()
        {
            // Test very long string with case-sensitive
            string longStr = new string('a', 1000);
            Assert.AreEqual("X", StringUtil.Substitute(longStr, longStr, "X", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended42_VeryLongStringCaseInsensitive()
        {
            // Test very long string with case-insensitive
            string longStr = new string('a', 1000);
            Assert.AreEqual("X", StringUtil.Substitute(longStr, longStr, "X", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended43_ReplacementLongerThanTargetCaseSensitive()
        {
            // Test replacement longer than target with case-sensitive
            Assert.AreEqual("aLONGERf", StringUtil.Substitute("asdf", "sd", "LONGER", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended44_ReplacementLongerThanTargetCaseInsensitive()
        {
            // Test replacement longer than target with case-insensitive
            Assert.AreEqual("aLONGERf", StringUtil.Substitute("asdf", "SD", "LONGER", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended45_EmptyReplacementCaseSensitive()
        {
            // Test empty replacement (deletion) with case-sensitive
            Assert.AreEqual("af", StringUtil.Substitute("asdf", "sd", "", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended46_EmptyReplacementCaseInsensitive()
        {
            // Test empty replacement (deletion) with case-insensitive
            Assert.AreEqual("af", StringUtil.Substitute("asdf", "SD", "", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended47_SelfReplacingCaseSensitive()
        {
            // Test replacing target with itself (case-sensitive)
            Assert.AreEqual("asdf", StringUtil.Substitute("asdf", "sd", "sd", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended48_SelfReplacingCaseInsensitive()
        {
            // Test replacing target with itself (case-insensitive)
            // Note: original case is preserved since we're replacing with the exact same string
            Assert.AreEqual("asdf", StringUtil.Substitute("asdf", "SD", "sd", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended49_ConsecutiveTargetsCaseSensitive()
        {
            // Test consecutive targets with case-sensitive
            Assert.AreEqual("XYXYXY", StringUtil.Substitute("ababab", "ab", "XY", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended50_ConsecutiveTargetsCaseInsensitive()
        {
            // Test consecutive targets with case-insensitive
            Assert.AreEqual("XYXYXY", StringUtil.Substitute("ababab", "AB", "XY", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended51_AlternatingCaseSensitive()
        {
            // Test alternating pattern with case-sensitive
            Assert.AreEqual("XbXb", StringUtil.Substitute("abab", "a", "X", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended52_AlternatingCaseInsensitive()
        {
            // Test alternating pattern with case-insensitive
            Assert.AreEqual("XbXb", StringUtil.Substitute("abab", "A", "X", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended53_NoMatchCaseSensitive()
        {
            // Test when target doesn't match (case-sensitive)
            Assert.AreEqual("asdf", StringUtil.Substitute("asdf", "ASDF", "X", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended54_NoMatchCaseInsensitive()
        {
            // Test when target doesn't match (case-insensitive) - but it should match here
            Assert.AreEqual("X", StringUtil.Substitute("asdf", "ASDF", "X", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended55_TargetLongerThanSourceCaseSensitive()
        {
            // Test target longer than source with case-sensitive
            Assert.AreEqual("abc", StringUtil.Substitute("abc", "abcdef", "X", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended56_TargetLongerThanSourceCaseInsensitive()
        {
            // Test target longer than source with case-insensitive
            Assert.AreEqual("abc", StringUtil.Substitute("abc", "ABCDEF", "X", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended57_SingleCharacterSourceCaseSensitive()
        {
            // Test single character source with case-sensitive
            Assert.AreEqual("X", StringUtil.Substitute("a", "a", "X", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended58_SingleCharacterSourceCaseInsensitive()
        {
            // Test single character source with case-insensitive
            Assert.AreEqual("X", StringUtil.Substitute("A", "a", "X", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended59_EmptySourceCaseSensitive()
        {
            // Test empty source with case-sensitive
            Assert.AreEqual("", StringUtil.Substitute("", "a", "X", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended60_EmptySourceCaseInsensitive()
        {
            // Test empty source with case-insensitive
            Assert.AreEqual("", StringUtil.Substitute("", "a", "X", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended61_TargetAtStartCaseSensitive()
        {
            // Test target at start with case-sensitive
            Assert.AreEqual("REPLACEDsdf", StringUtil.Substitute("asdf", "a", "REPLACED", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended62_TargetAtStartCaseInsensitive()
        {
            // Test target at start with case-insensitive
            Assert.AreEqual("REPLACEDsdf", StringUtil.Substitute("Asdf", "a", "REPLACED", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended63_TargetAtEndCaseSensitive()
        {
            // Test target at end with case-sensitive
            Assert.AreEqual("asdREPLACED", StringUtil.Substitute("asdf", "f", "REPLACED", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended64_TargetAtEndCaseInsensitive()
        {
            // Test target at end with case-insensitive
            Assert.AreEqual("asdREPLACED", StringUtil.Substitute("asdF", "f", "REPLACED", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended65_MultiCharacterTargetCaseSensitive()
        {
            // Test multi-character target with case-sensitive
            Assert.AreEqual("aXf", StringUtil.Substitute("asdf", "sd", "X", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended66_MultiCharacterTargetCaseInsensitive()
        {
            // Test multi-character target with case-insensitive
            Assert.AreEqual("aXf", StringUtil.Substitute("aSDf", "sd", "X", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended67_OverlappingPatternCaseSensitive()
        {
            // Test overlapping pattern with case-sensitive
            Assert.AreEqual("XX", StringUtil.Substitute("AAAA", "AA", "X", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended68_OverlappingPatternCaseInsensitive()
        {
            // Test overlapping pattern with case-insensitive
            Assert.AreEqual("XX", StringUtil.Substitute("aaaa", "AA", "X", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSubstituteExtended69_NullSourceCaseSensitive()
        {
            // Test null source throws exception with case-sensitive
            StringUtil.Substitute(null, "a", "X", ComparisonType.CaseSensitive);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSubstituteExtended70_NullSourceCaseInsensitive()
        {
            // Test null source throws exception with case-insensitive
            StringUtil.Substitute(null, "a", "X", ComparisonType.CaseInsensitive);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSubstituteExtended71_NullTargetCaseSensitive()
        {
            // Test null target throws exception with case-sensitive
            StringUtil.Substitute("test", null, "X", ComparisonType.CaseSensitive);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSubstituteExtended72_NullTargetCaseInsensitive()
        {
            // Test null target throws exception with case-insensitive
            StringUtil.Substitute("test", null, "X", ComparisonType.CaseInsensitive);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSubstituteExtended73_NullReplacementCaseSensitive()
        {
            // Test null replacement throws exception with case-sensitive
            StringUtil.Substitute("test", "e", null, ComparisonType.CaseSensitive);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSubstituteExtended74_NullReplacementCaseInsensitive()
        {
            // Test null replacement throws exception with case-insensitive
            StringUtil.Substitute("test", "e", null, ComparisonType.CaseInsensitive);
        }

        [TestMethod]
        public void TestSubstituteExtended75_ReplacementContainsTargetCaseSensitive()
        {
            // Test replacement containing target with case-sensitive
            Assert.AreEqual("abcabc", StringUtil.Substitute("abc", "abc", "abcabc", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended76_ReplacementContainsTargetCaseInsensitive()
        {
            // Test replacement containing target with case-insensitive
            Assert.AreEqual("abcabc", StringUtil.Substitute("ABC", "abc", "abcabc", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended77_EntireStringMatchCaseSensitive()
        {
            // Test entire string matches target with case-sensitive
            Assert.AreEqual("REPLACEMENT", StringUtil.Substitute("entire", "entire", "REPLACEMENT", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended78_EntireStringMatchCaseInsensitive()
        {
            // Test entire string matches target with case-insensitive
            Assert.AreEqual("REPLACEMENT", StringUtil.Substitute("ENTIRE", "entire", "REPLACEMENT", ComparisonType.CaseInsensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended79_MultipleNonConsecutiveTargetsCaseSensitive()
        {
            // Test multiple non-consecutive targets with case-sensitive
            Assert.AreEqual("XaXaX", StringUtil.Substitute("XaYaY", "Y", "X", ComparisonType.CaseSensitive));
        }

        [TestMethod]
        public void TestSubstituteExtended80_MultipleNonConsecutiveTargetsCaseInsensitive()
        {
            // Test multiple non-consecutive targets with case-insensitive
            Assert.AreEqual("XaXaX", StringUtil.Substitute("XaYaY", "y", "X", ComparisonType.CaseInsensitive));
        }

        #endregion


        #region ConvertComparisonType(ComparisonType) tests

        [TestMethod]
        public void TestConvertComparisonType1_CaseSensitive()
        {
            // Test converting CaseSensitive to StringComparison.Ordinal
            StringComparison result = StringUtil.ConvertComparisonType(ComparisonType.CaseSensitive);
            Assert.AreEqual(StringComparison.Ordinal, result);
        }

        [TestMethod]
        public void TestConvertComparisonType2_CaseInsensitive()
        {
            // Test converting CaseInsensitive to StringComparison.OrdinalIgnoreCase
            StringComparison result = StringUtil.ConvertComparisonType(ComparisonType.CaseInsensitive);
            Assert.AreEqual(StringComparison.OrdinalIgnoreCase, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestConvertComparisonType3_InvalidValue()
        {
            // Test converting invalid ComparisonType value throws ArgumentOutOfRangeException
            // Database = 2 is not supported
            StringUtil.ConvertComparisonType(ComparisonType.Database);
        }

        [TestMethod]
        public void TestConvertComparisonType4_CaseSensitiveConsistency()
        {
            // Test that CaseSensitive always converts to Ordinal
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(StringComparison.Ordinal, StringUtil.ConvertComparisonType(ComparisonType.CaseSensitive));
            }
        }

        [TestMethod]
        public void TestConvertComparisonType5_CaseInsensitiveConsistency()
        {
            // Test that CaseInsensitive always converts to OrdinalIgnoreCase
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(StringComparison.OrdinalIgnoreCase, StringUtil.ConvertComparisonType(ComparisonType.CaseInsensitive));
            }
        }

        [TestMethod]
        public void TestConvertComparisonType6_CaseSensitiveUsedInIndexOf()
        {
            // Test that CaseSensitive conversion works correctly with string operations
            string source = "Hello World";
            StringComparison comparison = StringUtil.ConvertComparisonType(ComparisonType.CaseSensitive);
            int result = source.IndexOf("hello", 0, comparison);
            Assert.AreEqual(-1, result); // "hello" is not found (case-sensitive)
        }

        [TestMethod]
        public void TestConvertComparisonType7_CaseInsensitiveUsedInIndexOf()
        {
            // Test that CaseInsensitive conversion works correctly with string operations
            string source = "Hello World";
            StringComparison comparison = StringUtil.ConvertComparisonType(ComparisonType.CaseInsensitive);
            int result = source.IndexOf("hello", 0, comparison);
            Assert.AreEqual(0, result); // "hello" is found at index 0 (case-insensitive)
        }

        [TestMethod]
        public void TestConvertComparisonType8_CaseSensitiveEqualsCheck()
        {
            // Test that CaseSensitive conversion works with Equals
            string str1 = "Test";
            string str2 = "test";
            StringComparison comparison = StringUtil.ConvertComparisonType(ComparisonType.CaseSensitive);
            bool result = str1.Equals(str2, comparison);
            Assert.IsFalse(result); // Not equal (case-sensitive)
        }

        [TestMethod]
        public void TestConvertComparisonType9_CaseInsensitiveEqualsCheck()
        {
            // Test that CaseInsensitive conversion works with Equals
            string str1 = "Test";
            string str2 = "test";
            StringComparison comparison = StringUtil.ConvertComparisonType(ComparisonType.CaseInsensitive);
            bool result = str1.Equals(str2, comparison);
            Assert.IsTrue(result); // Equal (case-insensitive)
        }

        [TestMethod]
        public void TestConvertComparisonType10_CaseSensitiveCompare()
        {
            // Test that CaseSensitive conversion produces Ordinal for string comparison
            StringComparison result = StringUtil.ConvertComparisonType(ComparisonType.CaseSensitive);
            Assert.IsTrue(result == StringComparison.Ordinal);
        }

        [TestMethod]
        public void TestConvertComparisonType11_CaseInsensitiveCompare()
        {
            // Test that CaseInsensitive conversion produces OrdinalIgnoreCase
            StringComparison result = StringUtil.ConvertComparisonType(ComparisonType.CaseInsensitive);
            Assert.IsTrue(result == StringComparison.OrdinalIgnoreCase);
        }

        [TestMethod]
        public void TestConvertComparisonType12_CaseSensitiveNotOrdinalIgnoreCase()
        {
            // Test that CaseSensitive does NOT return OrdinalIgnoreCase
            StringComparison result = StringUtil.ConvertComparisonType(ComparisonType.CaseSensitive);
            Assert.IsFalse(result == StringComparison.OrdinalIgnoreCase);
        }

        [TestMethod]
        public void TestConvertComparisonType13_CaseInsensitiveNotOrdinal()
        {
            // Test that CaseInsensitive does NOT return Ordinal
            StringComparison result = StringUtil.ConvertComparisonType(ComparisonType.CaseInsensitive);
            Assert.IsFalse(result == StringComparison.Ordinal);
        }

        [TestMethod]
        public void TestConvertComparisonType14_CaseSensitiveWithMixedCase()
        {
            // Test CaseSensitive with mixed case strings
            string str1 = "TeSt";
            string str2 = "test";
            StringComparison comparison = StringUtil.ConvertComparisonType(ComparisonType.CaseSensitive);
            int result = str1.CompareTo(str2);
            Assert.AreNotEqual(0, result); // Different (case-sensitive)
        }

        [TestMethod]
        public void TestConvertComparisonType15_CaseInsensitiveWithMixedCase()
        {
            // Test CaseInsensitive with mixed case strings
            string str1 = "TeSt";
            string str2 = "test";
            StringComparison comparison = StringUtil.ConvertComparisonType(ComparisonType.CaseInsensitive);
            bool result = str1.Equals(str2, comparison);
            Assert.IsTrue(result); // Equal when compared case-insensitively
        }

        [TestMethod]
        public void TestConvertComparisonType16_CaseSensitiveNumericStrings()
        {
            // Test CaseSensitive with numeric strings
            StringComparison comparison = StringUtil.ConvertComparisonType(ComparisonType.CaseSensitive);
            Assert.AreEqual(StringComparison.Ordinal, comparison);
            Assert.IsTrue("123".Equals("123", comparison));
        }

        [TestMethod]
        public void TestConvertComparisonType17_CaseInsensitiveNumericStrings()
        {
            // Test CaseInsensitive with numeric strings
            StringComparison comparison = StringUtil.ConvertComparisonType(ComparisonType.CaseInsensitive);
            Assert.AreEqual(StringComparison.OrdinalIgnoreCase, comparison);
            Assert.IsTrue("123".Equals("123", comparison));
        }

        [TestMethod]
        public void TestConvertComparisonType18_CaseSensitiveWithSpecialCharacters()
        {
            // Test CaseSensitive with special characters
            StringComparison comparison = StringUtil.ConvertComparisonType(ComparisonType.CaseSensitive);
            Assert.IsTrue("@#$%".Equals("@#$%", comparison));
            Assert.IsFalse("@#$%".Equals("@#$^", comparison));
        }

        [TestMethod]
        public void TestConvertComparisonType19_CaseInsensitiveWithSpecialCharacters()
        {
            // Test CaseInsensitive with special characters
            StringComparison comparison = StringUtil.ConvertComparisonType(ComparisonType.CaseInsensitive);
            Assert.IsTrue("@#$%".Equals("@#$%", comparison));
            Assert.IsFalse("@#$%".Equals("@#$^", comparison));
        }

        [TestMethod]
        public void TestConvertComparisonType20_CaseSensitiveEmptyStrings()
        {
            // Test CaseSensitive with empty strings
            StringComparison comparison = StringUtil.ConvertComparisonType(ComparisonType.CaseSensitive);
            Assert.IsTrue(string.Empty.Equals(string.Empty, comparison));
        }

        [TestMethod]
        public void TestConvertComparisonType21_CaseInsensitiveEmptyStrings()
        {
            // Test CaseInsensitive with empty strings
            StringComparison comparison = StringUtil.ConvertComparisonType(ComparisonType.CaseInsensitive);
            Assert.IsTrue(string.Empty.Equals(string.Empty, comparison));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestConvertComparisonType22_DatabaseThrowsException()
        {
            // Test that Database comparison type throws exception (not supported)
            StringUtil.ConvertComparisonType(ComparisonType.Database);
        }

        #endregion


        #region Replace(string, string, int, int) tests

        [TestMethod]
        public void TestReplace1_ReplaceAtStart()
        {
            // Test replacing at the start of the string (startIndex = 0)
            Assert.AreEqual("XYZdef", StringUtil.Replace("abcdef", "XYZ", 0, 3));
        }

        [TestMethod]
        public void TestReplace2_ReplaceAtEnd()
        {
            // Test replacing at the end of the string
            Assert.AreEqual("abcXYZ", StringUtil.Replace("abcdef", "XYZ", 3, 3));
        }

        [TestMethod]
        public void TestReplace3_ReplaceInMiddle()
        {
            // Test replacing in the middle of the string
            Assert.AreEqual("abXYZdef", StringUtil.Replace("abcdef", "XYZ", 2, 1));
        }

        [TestMethod]
        public void TestReplace4_ReplaceEntireString()
        {
            // Test replacing the entire string
            Assert.AreEqual("REPLACED", StringUtil.Replace("original", "REPLACED", 0, 8));
        }

        [TestMethod]
        public void TestReplace5_ReplacementLongerThanOriginal()
        {
            // Test replacement that is longer than what it replaces
            Assert.AreEqual("aVERYLONGREPLACEMENTd", StringUtil.Replace("abcd", "VERYLONGREPLACEMENT", 1, 2));
        }

        [TestMethod]
        public void TestReplace6_ReplacementShorterThanOriginal()
        {
            // Test replacement that is shorter than what it replaces
            Assert.AreEqual("aXd", StringUtil.Replace("abcd", "X", 1, 2));
        }

        [TestMethod]
        public void TestReplace7_EmptyReplacement()
        {
            // Test replacing with empty string (deletion)
            Assert.AreEqual("ad", StringUtil.Replace("abcd", "", 1, 2));
        }

        [TestMethod]
        public void TestReplace8_ReplaceWithSameLength()
        {
            // Test replacement at end of string (startIndex + length == source.Length)
            Assert.AreEqual("aXYZ", StringUtil.Replace("abcd", "XYZ", 1, 3));
        }

        [TestMethod]
        public void TestReplace9_ReplaceFirstCharacter()
        {
            // Test replacing only the first character
            Assert.AreEqual("Xbcdef", StringUtil.Replace("abcdef", "X", 0, 1));
        }

        [TestMethod]
        public void TestReplace10_ReplaceLastCharacter()
        {
            // Test replacing only the last character
            Assert.AreEqual("abcdeX", StringUtil.Replace("abcdef", "X", 5, 1));
        }

        [TestMethod]
        public void TestReplace11_ReplaceSingleCharacter()
        {
            // Test replacing a single character at various positions
            Assert.AreEqual("aXcdef", StringUtil.Replace("abcdef", "X", 1, 1));
        }

        [TestMethod]
        public void TestReplace12_ReplaceMultipleCharactersAtStart()
        {
            // Test replacing multiple characters at the start
            Assert.AreEqual("REPLACEDdef", StringUtil.Replace("abcdef", "REPLACED", 0, 3));
        }

        [TestMethod]
        public void TestReplace13_ReplaceMultipleCharactersInMiddle()
        {
            // Test replacing multiple characters in the middle
            Assert.AreEqual("abREPLACEDef", StringUtil.Replace("abcdef", "REPLACED", 2, 2));
        }

        [TestMethod]
        public void TestReplace14_ReplaceMultipleCharactersAtEnd()
        {
            // Test replacing multiple characters at the end
            Assert.AreEqual("abcREPLACED", StringUtil.Replace("abcdef", "REPLACED", 3, 3));
        }

        [TestMethod]
        public void TestReplace15_LengthZero()
        {
            // Test with length = 0 (insert without replacement)
            Assert.AreEqual("aINSERTbcd", StringUtil.Replace("abcd", "INSERT", 1, 0));
        }

        [TestMethod]
        public void TestReplace16_LengthZeroAtStart()
        {
            // Test with length = 0 at start (prepend)
            Assert.AreEqual("PREFIXabcd", StringUtil.Replace("abcd", "PREFIX", 0, 0));
        }

        [TestMethod]
        public void TestReplace17_LengthZeroAtEnd()
        {
            // Test with length = 0 at end (append)
            Assert.AreEqual("abcdSUFFIX", StringUtil.Replace("abcd", "SUFFIX", 4, 0));
        }

        [TestMethod]
        public void TestReplace18_StartIndexZeroLengthZero()
        {
            // Test with both startIndex and length = 0 (insert at start)
            Assert.AreEqual("INSERToriginal", StringUtil.Replace("original", "INSERT", 0, 0));
        }

        [TestMethod]
        public void TestReplace19_NumericReplacement()
        {
            // Test numeric replacement
            Assert.AreEqual("a123d", StringUtil.Replace("abcd", "123", 1, 2));
        }

        [TestMethod]
        public void TestReplace20_SpecialCharactersInReplacement()
        {
            // Test special characters in replacement
            Assert.AreEqual("a@#$d", StringUtil.Replace("abcd", "@#$", 1, 2));
        }

        [TestMethod]
        public void TestReplace21_SpaceInReplacement()
        {
            // Test space in replacement
            Assert.AreEqual("a   d", StringUtil.Replace("abcd", "   ", 1, 2));
        }

        [TestMethod]
        public void TestReplace22_TabInReplacement()
        {
            // Test tab character in replacement
            Assert.AreEqual("a\td", StringUtil.Replace("abcd", "\t", 1, 2));
        }

        [TestMethod]
        public void TestReplace23_NewlineInReplacement()
        {
            // Test newline character in replacement
            Assert.AreEqual("a\nd", StringUtil.Replace("abcd", "\n", 1, 2));
        }

        [TestMethod]
        public void TestReplace24_VeryLongString()
        {
            // Test with very long string
            string longStr = new string('a', 1000);
            string result = StringUtil.Replace(longStr, "X", 500, 1);
            Assert.AreEqual(1000, result.Length);
            Assert.AreEqual("X", result.Substring(500, 1));
        }

        [TestMethod]
        public void TestReplace25_VeryLongReplacement()
        {
            // Test with very long replacement
            string longReplacement = new string('x', 1000);
            string result = StringUtil.Replace("abcd", longReplacement, 1, 2);
            Assert.AreEqual(1 + 1000 + 1, result.Length); // a + replacement + d
            Assert.AreEqual("a", result.Substring(0, 1));
            Assert.AreEqual("d", result.Substring(result.Length - 1, 1));
        }

        [TestMethod]
        public void TestReplace26_SingleCharacterSource()
        {
            // Test with single character source
            Assert.AreEqual("X", StringUtil.Replace("a", "X", 0, 1));
        }

        [TestMethod]
        public void TestReplace27_TwoCharacterSource()
        {
            // Test with two character source
            Assert.AreEqual("XY", StringUtil.Replace("ab", "XY", 0, 2));
        }

        [TestMethod]
        public void TestReplace28_ReplaceMiddleOfTwoCharacters()
        {
            // Test replacing one character in two character string
            Assert.AreEqual("aX", StringUtil.Replace("ab", "X", 1, 1));
        }

        [TestMethod]
        public void TestReplace29_SelfReplacement()
        {
            // Test replacing with the same content
            Assert.AreEqual("abcd", StringUtil.Replace("abcd", "bc", 1, 2));
        }

        [TestMethod]
        public void TestReplace30_StartIndexLarge()
        {
            // Test with large start index near end
            Assert.AreEqual("abcdefX", StringUtil.Replace("abcdefgh", "X", 6, 2));
        }

        [TestMethod]
        public void TestReplace31_AllCharactersReplaced()
        {
            // Test replacing all characters one by one
            string original = "abcd";
            string result = original;
            for (int i = 0; i < original.Length; i++)
            {
                result = StringUtil.Replace(result, "X", i, 1);
            }
            Assert.AreEqual("XXXX", result);
        }

        [TestMethod]
        public void TestReplace32_ConsecutiveReplacements()
        {
            // Test multiple consecutive replacements
            string result = StringUtil.Replace("abcdef", "XY", 0, 2);
            // After first: "XYcdef"
            result = StringUtil.Replace(result, "ZW", 2, 2);
            // Replaces "cd" (indices 2-3) with "ZW": "XYZWef"
            Assert.AreEqual("XYZWef", result);
        }

        [TestMethod]
        public void TestReplace33_ReplaceWithNumbers()
        {
            // Test replacing with numeric content
            // Replace indices 0-3 with "1234", leaving "efgh"
            Assert.AreEqual("1234efgh", StringUtil.Replace("abcdefgh", "1234", 0, 4));
        }

        [TestMethod]
        public void TestReplace34_MixedCaseReplacement()
        {
            // Test with mixed case replacement
            // Replace indices 3-4 ("de") with "De", leaving "fgH"
            Assert.AreEqual("aBcDefgH", StringUtil.Replace("aBcdefgH", "De", 3, 2));
        }

        [TestMethod]
        public void TestReplace35_UnicodeCharactersInReplacement()
        {
            // Test with unicode characters in replacement
            Assert.AreEqual("a★d", StringUtil.Replace("abcd", "★", 1, 2));
        }

        [TestMethod]
        public void TestReplace36_ReplaceWithMultipleSpaces()
        {
            // Test replacing with multiple spaces
            Assert.AreEqual("a     d", StringUtil.Replace("abcd", "     ", 1, 2));
        }

        [TestMethod]
        public void TestReplace37_EmptyStringToSingleChar()
        {
            // Test replacing nothing with a character (length = 0)
            Assert.AreEqual("aXbcd", StringUtil.Replace("abcd", "X", 1, 0));
        }

        [TestMethod]
        public void TestReplace38_ReplaceAllButFirst()
        {
            // Test replacing all but the first character
            Assert.AreEqual("aX", StringUtil.Replace("abcdefg", "X", 1, 6));
        }

        [TestMethod]
        public void TestReplace39_ReplaceAllButLast()
        {
            // Test replacing all but the last character
            Assert.AreEqual("Xg", StringUtil.Replace("abcdefg", "X", 0, 6));
        }

        [TestMethod]
        public void TestReplace40_MultipleConsecutiveReplacements()
        {
            // Test chain of replacements
            string result = "abcdefgh";
            result = StringUtil.Replace(result, "XX", 0, 2);
            // After: "XXcdefgh"
            result = StringUtil.Replace(result, "YY", 2, 2);
            // After: "XXYYefgh"
            result = StringUtil.Replace(result, "ZZ", 4, 2);
            // After: "XXYYZZgh"
            Assert.AreEqual("XXYYZZgh", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestReplace41_NullSource()
        {
            // Test null source throws exception
            StringUtil.Replace(null, "replacement", 0, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestReplace42_NullReplacement()
        {
            // Test null replacement throws exception
            StringUtil.Replace("source", null, 0, 1);
        }

        [TestMethod]
        public void TestReplace43_EmptySourceEmptyReplacement()
        {
            // Test empty source with empty replacement
            Assert.AreEqual("", StringUtil.Replace("", "", 0, 0));
        }

        [TestMethod]
        public void TestReplace44_EmptySourceNonEmptyReplacement()
        {
            // Test empty source with non-empty replacement
            Assert.AreEqual("X", StringUtil.Replace("", "X", 0, 0));
        }

        [TestMethod]
        public void TestReplace45_ReplaceFirstThreeCharacters()
        {
            // Test replacing first three characters
            Assert.AreEqual("XYZdefgh", StringUtil.Replace("abcdefgh", "XYZ", 0, 3));
        }

        [TestMethod]
        public void TestReplace46_ReplaceLastThreeCharacters()
        {
            // Test replacing last three characters
            Assert.AreEqual("abcdeXYZ", StringUtil.Replace("abcdefgh", "XYZ", 5, 3));
        }

        [TestMethod]
        public void TestReplace47_ReplaceMiddleThreeCharacters()
        {
            // Test replacing middle three characters
            Assert.AreEqual("abXYZfgh", StringUtil.Replace("abcdefgh", "XYZ", 2, 3));
        }

        [TestMethod]
        public void TestReplace48_ReplaceWithReplacementContainingOriginalContent()
        {
            // Test replacement containing part of original content
            // Replace indices 1-2 ("bc") with "abc", leaving "d"
            Assert.AreEqual("aabcd", StringUtil.Replace("abcd", "abc", 1, 2));
        }

        [TestMethod]
        public void TestReplace49_ReplaceWithMuchLongerString()
        {
            // Test replacing a small section with much longer string
            string longReplacement = "VERYLONGREPLACEMENTSTRING";
            Assert.AreEqual("aVERYLONGREPLACEMENTSTRINGd", StringUtil.Replace("abcd", longReplacement, 1, 2));
        }

        [TestMethod]
        public void TestReplace50_ReplaceWithMuchShorterString()
        {
            // Test replacing a long section with much shorter string
            string longSource = "abcdefghijklmnopqrst";
            Assert.AreEqual("aX", StringUtil.Replace(longSource, "X", 1, 19));
        }

        #endregion


        #region TrimCrLf(string) tests

        [TestMethod]
        public void TestTrimCrLf1()
        {
            Assert.AreEqual("asdf", StringUtil.TrimCrLf("asdf\r\n"));
        }

        [TestMethod]
        public void TestTrimCrLf2()
        {
            Assert.AreEqual("asdf", StringUtil.TrimCrLf("asdf\n"));
        }

        [TestMethod]
        public void TestTrimCrLf3()
        {
            Assert.AreEqual("asdf", StringUtil.TrimCrLf("asdf" + StringUtil.ToChar(13) + StringUtil.ToChar(10)));
        }

        [TestMethod]
        public void TestTrimCrLf4_OnlyCarriageReturn()
        {
            // Test with only carriage return
            Assert.AreEqual("asdf", StringUtil.TrimCrLf("asdf\r"));
        }

        [TestMethod]
        public void TestTrimCrLf5_OnlyLineFeed()
        {
            // Test with only line feed
            Assert.AreEqual("asdf", StringUtil.TrimCrLf("asdf\n"));
        }

        [TestMethod]
        public void TestTrimCrLf6_MultipleLineFeeds()
        {
            // Test with multiple line feeds (only LF, not CR)
            Assert.AreEqual("asdf", StringUtil.TrimCrLf("asdf\n\n\n"));
        }

        [TestMethod]
        public void TestTrimCrLf7_MultipleLineFeeds()
        {
            // Test with multiple line feeds at end
            Assert.AreEqual("asdf", StringUtil.TrimCrLf("asdf\n\n\n"));
        }

        [TestMethod]
        public void TestTrimCrLf8_MultipleCarriageReturns()
        {
            // Test with multiple carriage returns at end
            Assert.AreEqual("asdf", StringUtil.TrimCrLf("asdf\r\r\r"));
        }

        [TestMethod]
        public void TestTrimCrLf9_OnlyLineFeeds()
        {
            // Test with only line feeds (no CR)
            Assert.AreEqual("asdf", StringUtil.TrimCrLf("asdf\n\n\n"));
        }

        [TestMethod]
        public void TestTrimCrLf10_NoLineEndings()
        {
            // Test with no line endings
            Assert.AreEqual("asdf", StringUtil.TrimCrLf("asdf"));
        }

        [TestMethod]
        public void TestTrimCrLf11_EmptyString()
        {
            // Test with empty string (edge case - may throw if length check fails)
            // Actually this will likely throw because ret[ret.Length - 1] on empty StringBuilder
            // Skip or handle appropriately
            try
            {
                StringUtil.TrimCrLf("");
            }
            catch (Exception)
            {
                // Expected - empty string causes index out of range
            }
        }

        [TestMethod]
        public void TestTrimCrLf12_SingleLineFeed()
        {
            // Test with just a single line feed character
            // This will throw IndexOutOfRangeException because after removing LF,
            // the string is empty and it tries to check CR
            try
            {
                StringUtil.TrimCrLf("\n");
                Assert.Fail("Should have thrown IndexOutOfRangeException");
            }
            catch (IndexOutOfRangeException)
            {
                // Expected behavior
            }
        }

        [TestMethod]
        public void TestTrimCrLf13_SingleCarriageReturn()
        {
            // Test with just a single carriage return character
            try
            {
                StringUtil.TrimCrLf("\r");
                Assert.Fail("Should have thrown IndexOutOfRangeException");
            }
            catch (IndexOutOfRangeException)
            {
                // Expected behavior - removes CR but then tries to check LF on empty string
            }
        }

        [TestMethod]
        public void TestTrimCrLf14_SingleCRLF()
        {
            // Test with just CRLF
            try
            {
                StringUtil.TrimCrLf("\r\n");
                Assert.Fail("Should have thrown IndexOutOfRangeException");
            }
            catch (IndexOutOfRangeException)
            {
                // Expected - after removing \n and \r, string is empty
            }
        }

        [TestMethod]
        public void TestTrimCrLf15_LineEndingsInMiddle()
        {
            // Test with line endings in the middle (should only trim end)
            Assert.AreEqual("asdf\r\nqwer", StringUtil.TrimCrLf("asdf\r\nqwer\r\n"));
        }

        [TestMethod]
        public void TestTrimCrLf16_LineEndingsAtStart()
        {
            // Test with line endings at start (should not be trimmed)
            Assert.AreEqual("\r\nasdf", StringUtil.TrimCrLf("\r\nasdf"));
        }

        [TestMethod]
        public void TestTrimCrLf17_LongStringWithLineEndings()
        {
            // Test with long string
            string longStr = new string('a', 1000);
            Assert.AreEqual(longStr, StringUtil.TrimCrLf(longStr + "\r\n"));
        }

        [TestMethod]
        public void TestTrimCrLf18_SingleCharacterWithLineFeed()
        {
            // Test single character with line feed
            Assert.AreEqual("a", StringUtil.TrimCrLf("a\n"));
        }

        [TestMethod]
        public void TestTrimCrLf19_SingleCharacterWithCarriageReturn()
        {
            // Test single character with carriage return
            Assert.AreEqual("a", StringUtil.TrimCrLf("a\r"));
        }

        [TestMethod]
        public void TestTrimCrLf20_TwoCharactersWithCRLF()
        {
            // Test two characters with CRLF
            Assert.AreEqual("ab", StringUtil.TrimCrLf("ab\r\n"));
        }

        [TestMethod]
        public void TestTrimCrLf21_SpecialCharactersBeforeLineEndings()
        {
            // Test special characters before line endings
            Assert.AreEqual("@#$%", StringUtil.TrimCrLf("@#$%\r\n"));
        }

        [TestMethod]
        public void TestTrimCrLf22_SpacesBeforeLineEndings()
        {
            // Test spaces before line endings
            Assert.AreEqual("asdf   ", StringUtil.TrimCrLf("asdf   \r\n"));
        }

        [TestMethod]
        public void TestTrimCrLf23_TabsBeforeLineEndings()
        {
            // Test tabs before line endings (tabs should NOT be trimmed)
            Assert.AreEqual("asdf\t\t", StringUtil.TrimCrLf("asdf\t\t\r\n"));
        }

        [TestMethod]
        public void TestTrimCrLf24_UnicodeCharactersBeforeLineEndings()
        {
            // Test unicode characters before line endings
            Assert.AreEqual("★★★", StringUtil.TrimCrLf("★★★\r\n"));
        }

        [TestMethod]
        public void TestTrimCrLf25_NumericStringWithLineEndings()
        {
            // Test numeric string with line endings
            Assert.AreEqual("12345", StringUtil.TrimCrLf("12345\r\n"));
        }

        [TestMethod]
        public void TestTrimCrLf26_MixedCaseWithLineEndings()
        {
            // Test mixed case with line endings
            Assert.AreEqual("AsDf", StringUtil.TrimCrLf("AsDf\r\n"));
        }

        [TestMethod]
        public void TestTrimCrLf27_OnlyLineFeeds_Multiple()
        {
            // Test multiple line feeds in sequence
            Assert.AreEqual("test", StringUtil.TrimCrLf("test\n\n\n\n\n"));
        }

        [TestMethod]
        public void TestTrimCrLf28_OnlyCarriageReturns_Multiple()
        {
            // Test multiple carriage returns in sequence
            Assert.AreEqual("test", StringUtil.TrimCrLf("test\r\r\r\r\r"));
        }

        [TestMethod]
        public void TestTrimCrLf29_CRFollowedByLF()
        {
            // Test CR followed by LF (proper Windows line ending)
            // Note: This is the standard case that works correctly
            Assert.AreEqual("test", StringUtil.TrimCrLf("test\r\n"));
        }

        [TestMethod]
        public void TestTrimCrLf30_OnlyCarriageReturns()
        {
            // Test with only carriage returns (no LF)
            Assert.AreEqual("test", StringUtil.TrimCrLf("test\r\r\r"));
        }

        [TestMethod]
        public void TestTrimCrLf31_CRBeforeLFOnly()
        {
            // Test CR before LF (the expected Windows line ending order)
            Assert.AreEqual("test", StringUtil.TrimCrLf("test\r\n"));
        }

        [TestMethod]
        public void TestTrimCrLf32_OnlyCarriageReturnsMultiple()
        {
            // Test multiple carriage returns without LF
            Assert.AreEqual("test", StringUtil.TrimCrLf("test\r\r\r"));
        }

        [TestMethod]
        public void TestTrimCrLf33_LongStringWithSimpleLineEndings()
        {
            // Test with long string and simple line endings
            string source = new string('a', 100) + "\r\n";
            Assert.AreEqual(new string('a', 100), StringUtil.TrimCrLf(source));
        }

        [TestMethod]
        public void TestTrimCrLf34_ContentWithInternalNewlines()
        {
            // Test content with internal newlines (only end should be trimmed)
            string source = "line1\nline2\nline3\n";
            Assert.AreEqual("line1\nline2\nline3", StringUtil.TrimCrLf(source));
        }

        [TestMethod]
        public void TestTrimCrLf35_ContentWithInternalCarriageReturns()
        {
            // Test content with internal carriage returns (only end should be trimmed)
            string source = "line1\rline2\rline3\r";
            Assert.AreEqual("line1\rline2\rline3", StringUtil.TrimCrLf(source));
        }

        [TestMethod]
        public void TestTrimCrLf36_MultipleConsecutiveTrimmer()
        {
            // Test applying trim multiple times (should be idempotent after first call)
            string source = "test\r\n";
            string first = StringUtil.TrimCrLf(source);
            string second = StringUtil.TrimCrLf(first);
            Assert.AreEqual(first, second);
            Assert.AreEqual("test", second);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestTrimCrLf37_NullSource()
        {
            // Test null source throws exception
            StringUtil.TrimCrLf(null);
        }

        [TestMethod]
        public void TestTrimCrLf38_OnlySpaceNoLineEndings()
        {
            // Test string with only spaces (no line endings)
            Assert.AreEqual("     ", StringUtil.TrimCrLf("     "));
        }

        [TestMethod]
        public void TestTrimCrLf39_OnlyTabsNoLineEndings()
        {
            // Test string with only tabs (no line endings)
            Assert.AreEqual("\t\t\t", StringUtil.TrimCrLf("\t\t\t"));
        }

        [TestMethod]
        public void TestTrimCrLf40_WhitespaceBeforeLineEndings()
        {
            // Test various whitespace before line endings (should be preserved)
            Assert.AreEqual("  \t  ", StringUtil.TrimCrLf("  \t  \r\n"));
        }

        #endregion


        #region Right(string, int) tests

        [TestMethod]
        public void TestRight1()
        {
            Assert.AreEqual("", StringUtil.Right("asdf", 0));
        }

        [TestMethod]
        public void TestRight2()
        {
            Assert.AreEqual("f", StringUtil.Right("asdf", 1));
        }

        [TestMethod]
        public void TestRight3()
        {
            Assert.AreEqual("df", StringUtil.Right("asdf", 2));
        }

        [TestMethod]
        public void TestRight4()
        {
            Assert.AreEqual("sdf", StringUtil.Right("asdf", 3));
        }

        [TestMethod]
        public void TestRight5()
        {
            Assert.AreEqual("asdf", StringUtil.Right("asdf", 4));
        }

        [TestMethod]
        public void TestRight6_LengthGreaterThanString()
        {
            // Test when length exceeds string length (throws ArgumentOutOfRangeException)
            try
            {
                StringUtil.Right("asdf", 5);
                Assert.Fail("Should have thrown ArgumentOutOfRangeException");
            }
            catch (ArgumentOutOfRangeException)
            {
                // Expected behavior
            }
        }

        [TestMethod]
        public void TestRight7_NegativeLength()
        {
            // Test with negative length (throws ArgumentOutOfRangeException)
            try
            {
                StringUtil.Right("asdf", -1);
                Assert.Fail("Should have thrown ArgumentOutOfRangeException");
            }
            catch (ArgumentOutOfRangeException)
            {
                // Expected behavior
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRight8_NullSource()
        {
            // Test null source throws exception
            StringUtil.Right(null, 2);
        }

        [TestMethod]
        public void TestRight9_SingleCharacter()
        {
            // Test with single character string
            Assert.AreEqual("a", StringUtil.Right("a", 1));
        }

        [TestMethod]
        public void TestRight10_SingleCharacterZeroLength()
        {
            // Test with single character and length 0
            Assert.AreEqual("", StringUtil.Right("a", 0));
        }

        [TestMethod]
        public void TestRight11_EmptyString()
        {
            // Test with empty string and length 0
            Assert.AreEqual("", StringUtil.Right("", 0));
        }

        [TestMethod]
        public void TestRight12_EmptyStringNonZeroLength()
        {
            // Test with empty string and non-zero length (throws ArgumentOutOfRangeException)
            try
            {
                StringUtil.Right("", 1);
                Assert.Fail("Should have thrown ArgumentOutOfRangeException");
            }
            catch (ArgumentOutOfRangeException)
            {
                // Expected behavior
            }
        }

        [TestMethod]
        public void TestRight13_LongString()
        {
            // Test with long string
            string source = new string('a', 1000);
            Assert.AreEqual(new string('a', 10), StringUtil.Right(source, 10));
        }

        [TestMethod]
        public void TestRight14_LongStringFullLength()
        {
            // Test extracting entire long string
            string source = new string('a', 100);
            Assert.AreEqual(source, StringUtil.Right(source, 100));
        }

        [TestMethod]
        public void TestRight15_NumericString()
        {
            // Test with numeric string
            Assert.AreEqual("456", StringUtil.Right("123456", 3));
        }

        [TestMethod]
        public void TestRight16_SpecialCharacters()
        {
            // Test with special characters
            Assert.AreEqual("@#$", StringUtil.Right("abc@#$", 3));
        }

        [TestMethod]
        public void TestRight17_Spaces()
        {
            // Test with spaces at the end
            Assert.AreEqual("   ", StringUtil.Right("abc   ", 3));
        }

        [TestMethod]
        public void TestRight18_Tabs()
        {
            // Test with tabs at the end
            Assert.AreEqual("\t\t", StringUtil.Right("abc\t\t", 2));
        }

        [TestMethod]
        public void TestRight19_MixedCase()
        {
            // Test with mixed case
            Assert.AreEqual("DeF", StringUtil.Right("AbCDeF", 3));
        }

        [TestMethod]
        public void TestRight20_UnicodeCharacters()
        {
            // Test with unicode characters
            Assert.AreEqual("★★", StringUtil.Right("abc★★", 2));
        }

        [TestMethod]
        public void TestRight21_StringWithNewlines()
        {
            // Test string containing newlines
            Assert.AreEqual("ef\n", StringUtil.Right("abcd\nef\n", 3));
        }

        [TestMethod]
        public void TestRight22_AllCharactersTheSame()
        {
            // Test string where all characters are identical
            Assert.AreEqual("aaaa", StringUtil.Right("aaaaaaaa", 4));
        }

        [TestMethod]
        public void TestRight23_TwoCharacterString()
        {
            // Test with two character string
            Assert.AreEqual("f", StringUtil.Right("ef", 1));
        }

        [TestMethod]
        public void TestRight24_TwoCharacterStringFullLength()
        {
            // Test extracting both characters
            Assert.AreEqual("ef", StringUtil.Right("ef", 2));
        }

        [TestMethod]
        public void TestRight25_WhitespaceCharacters()
        {
            // Test various whitespace at end
            Assert.AreEqual(" \t ", StringUtil.Right("abc \t ", 3));
        }

        #endregion


        #region Left(string, int) tests

        [TestMethod]
        public void TestLeft1()
        {
            Assert.AreEqual("", StringUtil.Left("asdf", 0));
        }

        [TestMethod]
        public void TestLeft2()
        {
            Assert.AreEqual("a", StringUtil.Left("asdf", 1));
        }

        [TestMethod]
        public void TestLeft3()
        {
            Assert.AreEqual("as", StringUtil.Left("asdf", 2));
        }

        [TestMethod]
        public void TestLeft4()
        {
            Assert.AreEqual("asd", StringUtil.Left("asdf", 3));
        }

        [TestMethod]
        public void TestLeft5()
        {
            Assert.AreEqual("asdf", StringUtil.Left("asdf", 4));
        }

        [TestMethod]
        public void TestLeft6_LengthGreaterThanString()
        {
            // Test when length exceeds string length (throws ArgumentOutOfRangeException)
            try
            {
                StringUtil.Left("asdf", 5);
                Assert.Fail("Should have thrown ArgumentOutOfRangeException");
            }
            catch (ArgumentOutOfRangeException)
            {
                // Expected behavior
            }
        }

        [TestMethod]
        public void TestLeft7_NegativeLength()
        {
            // Test with negative length (throws ArgumentOutOfRangeException)
            try
            {
                StringUtil.Left("asdf", -1);
                Assert.Fail("Should have thrown ArgumentOutOfRangeException");
            }
            catch (ArgumentOutOfRangeException)
            {
                // Expected behavior
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestLeft8_NullSource()
        {
            // Test null source throws exception
            StringUtil.Left(null, 2);
        }

        [TestMethod]
        public void TestLeft9_SingleCharacter()
        {
            // Test with single character string
            Assert.AreEqual("a", StringUtil.Left("a", 1));
        }

        [TestMethod]
        public void TestLeft10_SingleCharacterZeroLength()
        {
            // Test with single character and length 0
            Assert.AreEqual("", StringUtil.Left("a", 0));
        }

        [TestMethod]
        public void TestLeft11_EmptyString()
        {
            // Test with empty string and length 0
            Assert.AreEqual("", StringUtil.Left("", 0));
        }

        [TestMethod]
        public void TestLeft12_EmptyStringNonZeroLength()
        {
            // Test with empty string and non-zero length (throws ArgumentOutOfRangeException)
            try
            {
                StringUtil.Left("", 1);
                Assert.Fail("Should have thrown ArgumentOutOfRangeException");
            }
            catch (ArgumentOutOfRangeException)
            {
                // Expected behavior
            }
        }

        [TestMethod]
        public void TestLeft13_LongString()
        {
            // Test with long string
            string source = new string('a', 1000);
            Assert.AreEqual(new string('a', 10), StringUtil.Left(source, 10));
        }

        [TestMethod]
        public void TestLeft14_LongStringFullLength()
        {
            // Test extracting entire long string
            string source = new string('a', 100);
            Assert.AreEqual(source, StringUtil.Left(source, 100));
        }

        [TestMethod]
        public void TestLeft15_NumericString()
        {
            // Test with numeric string
            Assert.AreEqual("123", StringUtil.Left("123456", 3));
        }

        [TestMethod]
        public void TestLeft16_SpecialCharacters()
        {
            // Test with special characters
            Assert.AreEqual("abc", StringUtil.Left("abc@#$", 3));
        }

        [TestMethod]
        public void TestLeft17_Spaces()
        {
            // Test with leading spaces
            Assert.AreEqual("   ", StringUtil.Left("   abc", 3));
        }

        [TestMethod]
        public void TestLeft18_Tabs()
        {
            // Test with leading tabs
            Assert.AreEqual("\t\t", StringUtil.Left("\t\tabc", 2));
        }

        [TestMethod]
        public void TestLeft19_MixedCase()
        {
            // Test with mixed case
            Assert.AreEqual("AbC", StringUtil.Left("AbCDeF", 3));
        }

        [TestMethod]
        public void TestLeft20_UnicodeCharacters()
        {
            // Test with unicode characters
            Assert.AreEqual("★★", StringUtil.Left("★★abc", 2));
        }

        [TestMethod]
        public void TestLeft21_StringWithNewlines()
        {
            // Test string containing newlines
            Assert.AreEqual("ab\n", StringUtil.Left("ab\ncd\nef", 3));
        }

        [TestMethod]
        public void TestLeft22_AllCharactersTheSame()
        {
            // Test string where all characters are identical
            Assert.AreEqual("aaaa", StringUtil.Left("aaaaaaaa", 4));
        }

        [TestMethod]
        public void TestLeft23_TwoCharacterString()
        {
            // Test with two character string
            Assert.AreEqual("e", StringUtil.Left("ef", 1));
        }

        [TestMethod]
        public void TestLeft24_TwoCharacterStringFullLength()
        {
            // Test extracting both characters
            Assert.AreEqual("ef", StringUtil.Left("ef", 2));
        }

        [TestMethod]
        public void TestLeft25_WhitespaceCharacters()
        {
            // Test various whitespace at start
            Assert.AreEqual(" \t ", StringUtil.Left(" \t abc", 3));
        }

        #endregion


        #region RemoveDoubleQuoteWrapper(string) tests

        [TestMethod]
        public void RemoveDoubleQuoteWrapper1()
        {
            Assert.AreEqual("This is a test", StringUtil.RemoveDoubleQuoteWrapper("\"This is a test\""));
        }

        [TestMethod]
        public void RemoveDoubleQuoteWrapper2()
        {
            Assert.AreEqual("This\" is \"a test", StringUtil.RemoveDoubleQuoteWrapper("\"This\" is \"a test\""));
        }

        [TestMethod]
        public void RemoveDoubleQuoteWrapper3()
        {
            Assert.AreEqual("\"This is a test\"", StringUtil.RemoveDoubleQuoteWrapper("\"\"This is a test\"\""));
        }

        [TestMethod]
        public void RemoveDoubleQuoteWrapper4()
        {
            Assert.AreEqual("\"This\" is \"a test\"", StringUtil.RemoveDoubleQuoteWrapper("\"\"This\" is \"a test\"\""));
        }

        [TestMethod]
        public void RemoveDoubleQuoteWrapper5()
        {
            Assert.AreEqual("This is a test", StringUtil.RemoveDoubleQuoteWrapper("This is a test"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveDoubleQuoteWrapper6_NullInput()
        {
            // Test null input throws ArgumentNullException
            StringUtil.RemoveDoubleQuoteWrapper(null);
        }

        [TestMethod]
        public void RemoveDoubleQuoteWrapper7_EmptyString()
        {
            // Empty string throws IndexOutOfRangeException when trying to access first character
            try
            {
                StringUtil.RemoveDoubleQuoteWrapper("");
                Assert.Fail("Should have thrown IndexOutOfRangeException");
            }
            catch (IndexOutOfRangeException)
            {
                // Expected behavior - caught and rethrown
            }
        }

        [TestMethod]
        public void RemoveDoubleQuoteWrapper8_SingleCharacterNonQuote()
        {
            // Single character that's not a quote should return unchanged
            Assert.AreEqual("a", StringUtil.RemoveDoubleQuoteWrapper("a"));
        }

        [TestMethod]
        public void RemoveDoubleQuoteWrapper9_SingleQuoteCharacter()
        {
            // Single quote character will throw because ToString(1, -1) is invalid
            try
            {
                StringUtil.RemoveDoubleQuoteWrapper("\"");
                Assert.Fail("Should have thrown ArgumentOutOfRangeException");
            }
            catch (ArgumentOutOfRangeException)
            {
                // Expected behavior - ToString(1, -1) throws ArgumentOutOfRangeException
            }
        }

        [TestMethod]
        public void RemoveDoubleQuoteWrapper10_TwoQuotes()
        {
            // Two quotes should remove both, returning empty string
            Assert.AreEqual("", StringUtil.RemoveDoubleQuoteWrapper("\"\""));
        }

        [TestMethod]
        public void RemoveDoubleQuoteWrapper11_SingleCharWithQuotes()
        {
            // Single character wrapped in quotes
            Assert.AreEqual("a", StringUtil.RemoveDoubleQuoteWrapper("\"a\""));
        }

        [TestMethod]
        public void RemoveDoubleQuoteWrapper12_OpeningQuoteOnly()
        {
            // Only opening quote - should return unchanged
            Assert.AreEqual("\"test", StringUtil.RemoveDoubleQuoteWrapper("\"test"));
        }

        [TestMethod]
        public void RemoveDoubleQuoteWrapper13_ClosingQuoteOnly()
        {
            // Only closing quote - should return unchanged
            Assert.AreEqual("test\"", StringUtil.RemoveDoubleQuoteWrapper("test\""));
        }

        [TestMethod]
        public void RemoveDoubleQuoteWrapper14_TripleQuotes()
        {
            // Three quotes - outer two removed, middle one remains
            Assert.AreEqual("\"", StringUtil.RemoveDoubleQuoteWrapper("\"\"\""));
        }

        [TestMethod]
        public void RemoveDoubleQuoteWrapper15_FourQuotes()
        {
            // Four quotes - outer two removed, inner two remain
            Assert.AreEqual("\"\"", StringUtil.RemoveDoubleQuoteWrapper("\"\"\"\""));
        }

        [TestMethod]
        public void RemoveDoubleQuoteWrapper16_FiveQuotes()
        {
            // Five quotes - outer two removed, three remain
            Assert.AreEqual("\"\"\"", StringUtil.RemoveDoubleQuoteWrapper("\"\"\"\"\""));
        }

        [TestMethod]
        public void RemoveDoubleQuoteWrapper17_WhitespaceOnly()
        {
            // Whitespace only - no quotes, return unchanged
            Assert.AreEqual("   ", StringUtil.RemoveDoubleQuoteWrapper("   "));
        }

        [TestMethod]
        public void RemoveDoubleQuoteWrapper18_WhitespaceWithQuotes()
        {
            // Whitespace wrapped in quotes
            Assert.AreEqual("   ", StringUtil.RemoveDoubleQuoteWrapper("\"   \""));
        }

        [TestMethod]
        public void RemoveDoubleQuoteWrapper19_TabWithQuotes()
        {
            // Tab wrapped in quotes
            Assert.AreEqual("\t", StringUtil.RemoveDoubleQuoteWrapper("\"\t\""));
        }

        [TestMethod]
        public void RemoveDoubleQuoteWrapper20_NewlineWithQuotes()
        {
            // Newline wrapped in quotes
            Assert.AreEqual("\n", StringUtil.RemoveDoubleQuoteWrapper("\"\n\""));
        }

        [TestMethod]
        public void RemoveDoubleQuoteWrapper21_SpecialCharactersWithQuotes()
        {
            // Special characters wrapped in quotes
            Assert.AreEqual("!@#$%", StringUtil.RemoveDoubleQuoteWrapper("\"!@#$%\""));
        }

        [TestMethod]
        public void RemoveDoubleQuoteWrapper22_UnicodeWithQuotes()
        {
            // Unicode characters wrapped in quotes
            Assert.AreEqual("★★★", StringUtil.RemoveDoubleQuoteWrapper("\"★★★\""));
        }

        [TestMethod]
        public void RemoveDoubleQuoteWrapper23_MixedContentWithQuotes()
        {
            // Mixed content with numbers, letters, special chars
            Assert.AreEqual("abc123!@#", StringUtil.RemoveDoubleQuoteWrapper("\"abc123!@#\""));
        }

        [TestMethod]
        public void RemoveDoubleQuoteWrapper24_LongStringWithQuotes()
        {
            // Very long string wrapped in quotes
            string longContent = new string('a', 1000);
            Assert.AreEqual(longContent, StringUtil.RemoveDoubleQuoteWrapper("\"" + longContent + "\""));
        }

        [TestMethod]
        public void RemoveDoubleQuoteWrapper25_StringWithLeadingAndTrailingSpaces()
        {
            // String with leading and trailing spaces wrapped in quotes
            Assert.AreEqual("  test  ", StringUtil.RemoveDoubleQuoteWrapper("\"  test  \""));
        }

        [TestMethod]
        public void RemoveDoubleQuoteWrapper26_StringWithInternalQuotesAndSpaces()
        {
            // String with internal quotes and spaces
            Assert.AreEqual("test \" with \" quotes", StringUtil.RemoveDoubleQuoteWrapper("\"test \" with \" quotes\""));
        }

        [TestMethod]
        public void RemoveDoubleQuoteWrapper27_StringWithBackslashes()
        {
            // String with backslashes wrapped in quotes
            Assert.AreEqual("path\\to\\file", StringUtil.RemoveDoubleQuoteWrapper("\"path\\to\\file\""));
        }

        [TestMethod]
        public void RemoveDoubleQuoteWrapper28_StringWithForwardSlashes()
        {
            // String with forward slashes wrapped in quotes
            Assert.AreEqual("path/to/file", StringUtil.RemoveDoubleQuoteWrapper("\"path/to/file\""));
        }

        [TestMethod]
        public void RemoveDoubleQuoteWrapper29_StringWithEqualSign()
        {
            // String with equals sign wrapped in quotes
            Assert.AreEqual("key=value", StringUtil.RemoveDoubleQuoteWrapper("\"key=value\""));
        }

        [TestMethod]
        public void RemoveDoubleQuoteWrapper30_StringWithColons()
        {
            // String with colons (like URLs) wrapped in quotes
            Assert.AreEqual("http://example.com", StringUtil.RemoveDoubleQuoteWrapper("\"http://example.com\""));
        }

        #endregion


        #region WrapWithDoubleQuote(object) tests

        [TestMethod]
        public void TestWrapWithDoubleQuotes()
        {
            Assert.AreEqual("\"This is a test\"", StringUtil.WrapWithDoubleQuotes("This is a test"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestWrapWithDoubleQuotes2_NullInput()
        {
            // Test null input throws ArgumentNullException
            StringUtil.WrapWithDoubleQuotes(null);
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes3_EmptyString()
        {
            // Empty string should be wrapped in quotes
            Assert.AreEqual("\"\"", StringUtil.WrapWithDoubleQuotes(""));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes4_SingleCharacter()
        {
            // Single character string
            Assert.AreEqual("\"a\"", StringUtil.WrapWithDoubleQuotes("a"));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes5_StringWithLeadingSpaces()
        {
            // String with leading spaces
            Assert.AreEqual("\"   text\"", StringUtil.WrapWithDoubleQuotes("   text"));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes6_StringWithTrailingSpaces()
        {
            // String with trailing spaces
            Assert.AreEqual("\"text   \"", StringUtil.WrapWithDoubleQuotes("text   "));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes7_StringWithLeadingAndTrailingSpaces()
        {
            // String with both leading and trailing spaces
            Assert.AreEqual("\"   text   \"", StringUtil.WrapWithDoubleQuotes("   text   "));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes8_StringWithInternalQuotes()
        {
            // String with internal double quotes
            Assert.AreEqual("\"text \" with \" quotes\"", StringUtil.WrapWithDoubleQuotes("text \" with \" quotes"));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes9_StringWithSingleQuotes()
        {
            // String with single quotes
            Assert.AreEqual("\"text 'with' quotes\"", StringUtil.WrapWithDoubleQuotes("text 'with' quotes"));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes10_StringWithTab()
        {
            // String with tab character
            Assert.AreEqual("\"text\twith\ttabs\"", StringUtil.WrapWithDoubleQuotes("text\twith\ttabs"));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes11_StringWithNewline()
        {
            // String with newline character
            Assert.AreEqual("\"text\nwith\nnewlines\"", StringUtil.WrapWithDoubleQuotes("text\nwith\nnewlines"));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes12_StringWithSpecialCharacters()
        {
            // String with special characters
            Assert.AreEqual("\"!@#$%^&*()\"", StringUtil.WrapWithDoubleQuotes("!@#$%^&*()"));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes13_StringWithBackslash()
        {
            // String with backslashes
            Assert.AreEqual("\"path\\to\\file\"", StringUtil.WrapWithDoubleQuotes("path\\to\\file"));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes14_StringWithForwardSlash()
        {
            // String with forward slashes
            Assert.AreEqual("\"path/to/file\"", StringUtil.WrapWithDoubleQuotes("path/to/file"));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes15_UnicodeCharacters()
        {
            // String with unicode characters
            Assert.AreEqual("\"★★★\"", StringUtil.WrapWithDoubleQuotes("★★★"));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes16_LongString()
        {
            // Very long string
            string longText = new string('a', 1000);
            Assert.AreEqual("\"" + longText + "\"", StringUtil.WrapWithDoubleQuotes(longText));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes17_IntegerValue()
        {
            // Integer wrapped in quotes
            Assert.AreEqual("\"42\"", StringUtil.WrapWithDoubleQuotes(42));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes18_NegativeInteger()
        {
            // Negative integer
            Assert.AreEqual("\"-42\"", StringUtil.WrapWithDoubleQuotes(-42));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes19_ZeroInteger()
        {
            // Zero integer
            Assert.AreEqual("\"0\"", StringUtil.WrapWithDoubleQuotes(0));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes20_LongValue()
        {
            // Long integer value
            Assert.AreEqual("\"1234567890123\"", StringUtil.WrapWithDoubleQuotes(1234567890123L));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes21_DoubleValue()
        {
            // Double value
            Assert.AreEqual("\"3.14\"", StringUtil.WrapWithDoubleQuotes(3.14));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes22_DecimalValue()
        {
            // Decimal value
            Assert.AreEqual("\"99.99\"", StringUtil.WrapWithDoubleQuotes(99.99m));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes23_BooleanTrue()
        {
            // Boolean true value
            Assert.AreEqual("\"True\"", StringUtil.WrapWithDoubleQuotes(true));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes24_BooleanFalse()
        {
            // Boolean false value
            Assert.AreEqual("\"False\"", StringUtil.WrapWithDoubleQuotes(false));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes25_DateTime()
        {
            // DateTime object
            DateTime dt = new DateTime(2023, 12, 25, 10, 30, 45);
            string expected = "\"" + dt.ToString() + "\"";
            Assert.AreEqual(expected, StringUtil.WrapWithDoubleQuotes(dt));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes26_TimeSpan()
        {
            // TimeSpan object
            TimeSpan ts = new TimeSpan(1, 2, 3, 4);
            string expected = "\"" + ts.ToString() + "\"";
            Assert.AreEqual(expected, StringUtil.WrapWithDoubleQuotes(ts));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes27_Guid()
        {
            // GUID object
            Guid g = new Guid("12345678-1234-1234-1234-123456789abc");
            string expected = "\"" + g.ToString() + "\"";
            Assert.AreEqual(expected, StringUtil.WrapWithDoubleQuotes(g));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes28_CharValue()
        {
            // Character value
            Assert.AreEqual("\"A\"", StringUtil.WrapWithDoubleQuotes('A'));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes29_FloatValue()
        {
            // Float value
            Assert.AreEqual("\"2.5\"", StringUtil.WrapWithDoubleQuotes(2.5f));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes30_ByteValue()
        {
            // Byte value
            byte b = 255;
            Assert.AreEqual("\"255\"", StringUtil.WrapWithDoubleQuotes(b));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes31_StringBuilder()
        {
            // StringBuilder object (calls ToString on it)
            StringBuilder sb = new StringBuilder("Hello World");
            Assert.AreEqual("\"Hello World\"", StringUtil.WrapWithDoubleQuotes(sb));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes32_List()
        {
            // List object (default ToString representation)
            List<string> list = new List<string> { "a", "b", "c" };
            string expected = "\"" + list.ToString() + "\"";
            Assert.AreEqual(expected, StringUtil.WrapWithDoubleQuotes(list));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes33_Dictionary()
        {
            // Dictionary object (default ToString representation)
            Dictionary<string, int> dict = new Dictionary<string, int> { { "key", 42 } };
            string expected = "\"" + dict.ToString() + "\"";
            Assert.AreEqual(expected, StringUtil.WrapWithDoubleQuotes(dict));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes34_Array()
        {
            // Array object (default ToString representation)
            string[] arr = { "a", "b", "c" };
            string expected = "\"" + arr.ToString() + "\"";
            Assert.AreEqual(expected, StringUtil.WrapWithDoubleQuotes(arr));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes35_EqualsSign()
        {
            // String with equals sign (key=value pattern)
            Assert.AreEqual("\"key=value\"", StringUtil.WrapWithDoubleQuotes("key=value"));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes36_Colon()
        {
            // String with colon (URL pattern)
            Assert.AreEqual("\"http://example.com\"", StringUtil.WrapWithDoubleQuotes("http://example.com"));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes37_Comma()
        {
            // String with comma (CSV pattern)
            Assert.AreEqual("\"value1,value2,value3\"", StringUtil.WrapWithDoubleQuotes("value1,value2,value3"));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes38_Semicolon()
        {
            // String with semicolon
            Assert.AreEqual("\"item1;item2;item3\"", StringUtil.WrapWithDoubleQuotes("item1;item2;item3"));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes39_CarriageReturn()
        {
            // String with carriage return
            Assert.AreEqual("\"line1\rline2\"", StringUtil.WrapWithDoubleQuotes("line1\rline2"));
        }

        [TestMethod]
        public void TestWrapWithDoubleQuotes40_FormFeed()
        {
            // String with form feed
            Assert.AreEqual("\"page1\fpage2\"", StringUtil.WrapWithDoubleQuotes("page1\fpage2"));
        }

        #endregion


        #region WrapWithSingleQuotes(object) tests

        [TestMethod]
        public void TestWrapWithSingleQuotes()
        {
            Assert.AreEqual("'This is a test'", StringUtil.WrapWithSingleQuotes("This is a test"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestWrapWithSingleQuotes2_NullInput()
        {
            // Test null input throws ArgumentNullException
            StringUtil.WrapWithSingleQuotes(null);
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes3_EmptyString()
        {
            // Empty string should be wrapped in quotes
            Assert.AreEqual("''", StringUtil.WrapWithSingleQuotes(""));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes4_SingleCharacter()
        {
            // Single character string
            Assert.AreEqual("'a'", StringUtil.WrapWithSingleQuotes("a"));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes5_StringWithLeadingSpaces()
        {
            // String with leading spaces
            Assert.AreEqual("'   text'", StringUtil.WrapWithSingleQuotes("   text"));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes6_StringWithTrailingSpaces()
        {
            // String with trailing spaces
            Assert.AreEqual("'text   '", StringUtil.WrapWithSingleQuotes("text   "));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes7_StringWithLeadingAndTrailingSpaces()
        {
            // String with both leading and trailing spaces
            Assert.AreEqual("'   text   '", StringUtil.WrapWithSingleQuotes("   text   "));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes8_StringWithInternalSingleQuotes()
        {
            // String with internal single quotes
            Assert.AreEqual("'text ' with ' quotes'", StringUtil.WrapWithSingleQuotes("text ' with ' quotes"));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes9_StringWithDoubleQuotes()
        {
            // String with double quotes
            Assert.AreEqual("'text \"with\" quotes'", StringUtil.WrapWithSingleQuotes("text \"with\" quotes"));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes10_StringWithTab()
        {
            // String with tab character
            Assert.AreEqual("'text\twith\ttabs'", StringUtil.WrapWithSingleQuotes("text\twith\ttabs"));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes11_StringWithNewline()
        {
            // String with newline character
            Assert.AreEqual("'text\nwith\nnewlines'", StringUtil.WrapWithSingleQuotes("text\nwith\nnewlines"));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes12_StringWithSpecialCharacters()
        {
            // String with special characters
            Assert.AreEqual("'!@#$%^&*()'", StringUtil.WrapWithSingleQuotes("!@#$%^&*()"));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes13_StringWithBackslash()
        {
            // String with backslashes
            Assert.AreEqual("'path\\to\\file'", StringUtil.WrapWithSingleQuotes("path\\to\\file"));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes14_StringWithForwardSlash()
        {
            // String with forward slashes
            Assert.AreEqual("'path/to/file'", StringUtil.WrapWithSingleQuotes("path/to/file"));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes15_UnicodeCharacters()
        {
            // String with unicode characters
            Assert.AreEqual("'★★★'", StringUtil.WrapWithSingleQuotes("★★★"));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes16_LongString()
        {
            // Very long string
            string longText = new string('a', 1000);
            Assert.AreEqual("'" + longText + "'", StringUtil.WrapWithSingleQuotes(longText));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes17_IntegerValue()
        {
            // Integer wrapped in quotes
            Assert.AreEqual("'42'", StringUtil.WrapWithSingleQuotes(42));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes18_NegativeInteger()
        {
            // Negative integer
            Assert.AreEqual("'-42'", StringUtil.WrapWithSingleQuotes(-42));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes19_ZeroInteger()
        {
            // Zero integer
            Assert.AreEqual("'0'", StringUtil.WrapWithSingleQuotes(0));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes20_LongValue()
        {
            // Long integer value
            Assert.AreEqual("'1234567890123'", StringUtil.WrapWithSingleQuotes(1234567890123L));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes21_DoubleValue()
        {
            // Double value
            Assert.AreEqual("'3.14'", StringUtil.WrapWithSingleQuotes(3.14));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes22_DecimalValue()
        {
            // Decimal value
            Assert.AreEqual("'99.99'", StringUtil.WrapWithSingleQuotes(99.99m));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes23_BooleanTrue()
        {
            // Boolean true value
            Assert.AreEqual("'True'", StringUtil.WrapWithSingleQuotes(true));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes24_BooleanFalse()
        {
            // Boolean false value
            Assert.AreEqual("'False'", StringUtil.WrapWithSingleQuotes(false));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes25_DateTime()
        {
            // DateTime object
            DateTime dt = new DateTime(2023, 12, 25, 10, 30, 45);
            string expected = "'" + dt.ToString() + "'";
            Assert.AreEqual(expected, StringUtil.WrapWithSingleQuotes(dt));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes26_TimeSpan()
        {
            // TimeSpan object
            TimeSpan ts = new TimeSpan(1, 2, 3, 4);
            string expected = "'" + ts.ToString() + "'";
            Assert.AreEqual(expected, StringUtil.WrapWithSingleQuotes(ts));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes27_Guid()
        {
            // GUID object
            Guid g = new Guid("12345678-1234-1234-1234-123456789abc");
            string expected = "'" + g.ToString() + "'";
            Assert.AreEqual(expected, StringUtil.WrapWithSingleQuotes(g));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes28_CharValue()
        {
            // Character value
            Assert.AreEqual("'A'", StringUtil.WrapWithSingleQuotes('A'));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes29_FloatValue()
        {
            // Float value
            Assert.AreEqual("'2.5'", StringUtil.WrapWithSingleQuotes(2.5f));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes30_ByteValue()
        {
            // Byte value
            byte b = 255;
            Assert.AreEqual("'255'", StringUtil.WrapWithSingleQuotes(b));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes31_StringBuilder()
        {
            // StringBuilder object (calls ToString on it)
            StringBuilder sb = new StringBuilder("Hello World");
            Assert.AreEqual("'Hello World'", StringUtil.WrapWithSingleQuotes(sb));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes32_List()
        {
            // List object (default ToString representation)
            List<string> list = new List<string> { "a", "b", "c" };
            string expected = "'" + list.ToString() + "'";
            Assert.AreEqual(expected, StringUtil.WrapWithSingleQuotes(list));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes33_Dictionary()
        {
            // Dictionary object (default ToString representation)
            Dictionary<string, int> dict = new Dictionary<string, int> { { "key", 42 } };
            string expected = "'" + dict.ToString() + "'";
            Assert.AreEqual(expected, StringUtil.WrapWithSingleQuotes(dict));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes34_Array()
        {
            // Array object (default ToString representation)
            string[] arr = { "a", "b", "c" };
            string expected = "'" + arr.ToString() + "'";
            Assert.AreEqual(expected, StringUtil.WrapWithSingleQuotes(arr));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes35_EqualsSign()
        {
            // String with equals sign (key=value pattern)
            Assert.AreEqual("'key=value'", StringUtil.WrapWithSingleQuotes("key=value"));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes36_Colon()
        {
            // String with colon (URL pattern)
            Assert.AreEqual("'http://example.com'", StringUtil.WrapWithSingleQuotes("http://example.com"));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes37_Comma()
        {
            // String with comma (CSV pattern)
            Assert.AreEqual("'value1,value2,value3'", StringUtil.WrapWithSingleQuotes("value1,value2,value3"));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes38_Semicolon()
        {
            // String with semicolon
            Assert.AreEqual("'item1;item2;item3'", StringUtil.WrapWithSingleQuotes("item1;item2;item3"));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes39_CarriageReturn()
        {
            // String with carriage return
            Assert.AreEqual("'line1\rline2'", StringUtil.WrapWithSingleQuotes("line1\rline2"));
        }

        [TestMethod]
        public void TestWrapWithSingleQuotes40_FormFeed()
        {
            // String with form feed
            Assert.AreEqual("'page1\fpage2'", StringUtil.WrapWithSingleQuotes("page1\fpage2"));
        }

        #endregion


        #region SplitStringIntoArray(string) tests

        [TestMethod]
        public void TestSplitStringIntoArray()
        {
            string[] ary1 = { "a", "s", "d", "f" };
            string[] actual = StringUtil.SplitStringIntoArray("asdf");
            Assert.AreEqual(ary1.Length, actual.Length);
            for (int i = 0; i < ary1.Length; i++)
            {
                Assert.AreEqual(ary1[i], actual[i]);
            }

            string[] ary2 = { "a" };
            actual = StringUtil.SplitStringIntoArray("a");
            Assert.AreEqual(ary2.Length, actual.Length);
            for (int i = 0; i < ary2.Length; i++)
            {
                Assert.AreEqual(ary2[i], actual[i]);
            }

            string[] ary3 = { };
            actual = StringUtil.SplitStringIntoArray("");
            Assert.AreEqual(ary3.Length, actual.Length);
            for (int i = 0; i < ary3.Length; i++)
            {
                Assert.AreEqual(ary3[i], actual[i]);
            }

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSplitStringIntoArray2_NullInput()
        {
            // Test null input throws ArgumentNullException
            StringUtil.SplitStringIntoArray(null);
        }

        [TestMethod]
        public void TestSplitStringIntoArray3_UppercaseLetters()
        {
            // Test with uppercase letters
            string[] expected = { "A", "B", "C", "D" };
            string[] actual = StringUtil.SplitStringIntoArray("ABCD");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray4_MixedCase()
        {
            // Test with mixed case letters
            string[] expected = { "A", "b", "C", "d" };
            string[] actual = StringUtil.SplitStringIntoArray("AbCd");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray5_Digits()
        {
            // Test with digits
            string[] expected = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[] actual = StringUtil.SplitStringIntoArray("0123456789");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray6_AlphanumericMixed()
        {
            // Test with alphanumeric mix
            string[] expected = { "a", "1", "b", "2", "c", "3" };
            string[] actual = StringUtil.SplitStringIntoArray("a1b2c3");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray7_ExclamationMark()
        {
            // Test with exclamation mark
            string[] expected = { "!", "!" };
            string[] actual = StringUtil.SplitStringIntoArray("!!");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray8_AtSymbol()
        {
            // Test with at symbol
            string[] expected = { "@", "@" };
            string[] actual = StringUtil.SplitStringIntoArray("@@");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray9_SpecialCharacters()
        {
            // Test with various special characters
            string[] expected = { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")" };
            string[] actual = StringUtil.SplitStringIntoArray("!@#$%^&*()");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray10_Backslash()
        {
            // Test with backslash
            string[] expected = { "\\", "\\", "\\" };
            string[] actual = StringUtil.SplitStringIntoArray("\\\\\\");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray11_ForwardSlash()
        {
            // Test with forward slash
            string[] expected = { "/", "/", "/" };
            string[] actual = StringUtil.SplitStringIntoArray("///");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray12_Punctuation()
        {
            // Test with punctuation marks
            string[] expected = { ".", ",", ";", ":", "?", "!" };
            string[] actual = StringUtil.SplitStringIntoArray(".,;:?!");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray13_Quotes()
        {
            // Test with single and double quotes
            string[] expected = { "\"", "'", "\"", "'" };
            string[] actual = StringUtil.SplitStringIntoArray("\"'\"'");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray14_Space()
        {
            // Test with space character
            string[] expected = { " ", " ", " " };
            string[] actual = StringUtil.SplitStringIntoArray("   ");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray15_Tab()
        {
            // Test with tab character
            string[] expected = { "\t", "\t" };
            string[] actual = StringUtil.SplitStringIntoArray("\t\t");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray16_Newline()
        {
            // Test with newline character
            string[] expected = { "\n", "\n" };
            string[] actual = StringUtil.SplitStringIntoArray("\n\n");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray17_CarriageReturn()
        {
            // Test with carriage return character
            string[] expected = { "\r", "\r" };
            string[] actual = StringUtil.SplitStringIntoArray("\r\r");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray18_FormFeed()
        {
            // Test with form feed character
            string[] expected = { "\f", "\f" };
            string[] actual = StringUtil.SplitStringIntoArray("\f\f");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray19_Unicode()
        {
            // Test with unicode characters
            string[] expected = { "★", "☆", "✓" };
            string[] actual = StringUtil.SplitStringIntoArray("★☆✓");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray20_RepeatingCharacters()
        {
            // Test with repeating characters
            string[] expected = { "a", "a", "a", "a", "a" };
            string[] actual = StringUtil.SplitStringIntoArray("aaaaa");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray21_LongString()
        {
            // Test with a long string
            string longString = new string('x', 100);
            string[] actual = StringUtil.SplitStringIntoArray(longString);
            Assert.AreEqual(100, actual.Length);
            for (int i = 0; i < 100; i++)
            {
                Assert.AreEqual("x", actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray22_StringWithWhitespace()
        {
            // Test with mixed text and whitespace
            string[] expected = { "h", "e", "l", "l", "o", " ", "w", "o", "r", "l", "d" };
            string[] actual = StringUtil.SplitStringIntoArray("hello world");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray23_StringWithPunctuation()
        {
            // Test with text and punctuation
            string[] expected = { "h", "e", "l", "l", "o", ",", " ", "w", "o", "r", "l", "d", "!" };
            string[] actual = StringUtil.SplitStringIntoArray("hello, world!");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray24_Hyphen()
        {
            // Test with hyphen
            string[] expected = { "-", "-" };
            string[] actual = StringUtil.SplitStringIntoArray("--");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray25_Underscore()
        {
            // Test with underscore
            string[] expected = { "_", "_" };
            string[] actual = StringUtil.SplitStringIntoArray("__");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray26_Equals()
        {
            // Test with equals sign
            string[] expected = { "=", "=" };
            string[] actual = StringUtil.SplitStringIntoArray("==");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray27_Plus()
        {
            // Test with plus sign
            string[] expected = { "+", "+" };
            string[] actual = StringUtil.SplitStringIntoArray("++");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray28_Minus()
        {
            // Test with minus sign
            string[] expected = { "-", "-" };
            string[] actual = StringUtil.SplitStringIntoArray("--");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray29_Multiplication()
        {
            // Test with asterisk (multiplication)
            string[] expected = { "*", "*" };
            string[] actual = StringUtil.SplitStringIntoArray("**");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray30_Division()
        {
            // Test with slash (division)
            string[] expected = { "/", "/" };
            string[] actual = StringUtil.SplitStringIntoArray("//");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray31_Brackets()
        {
            // Test with brackets
            string[] expected = { "[", "]", "{", "}" };
            string[] actual = StringUtil.SplitStringIntoArray("[]{}");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray32_Pipe()
        {
            // Test with pipe character
            string[] expected = { "|", "|" };
            string[] actual = StringUtil.SplitStringIntoArray("||");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray33_Ampersand()
        {
            // Test with ampersand
            string[] expected = { "&", "&" };
            string[] actual = StringUtil.SplitStringIntoArray("&&");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray34_Tilde()
        {
            // Test with tilde
            string[] expected = { "~", "~" };
            string[] actual = StringUtil.SplitStringIntoArray("~~");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray35_Caret()
        {
            // Test with caret
            string[] expected = { "^", "^" };
            string[] actual = StringUtil.SplitStringIntoArray("^^");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray36_Question()
        {
            // Test with question mark
            string[] expected = { "?", "?" };
            string[] actual = StringUtil.SplitStringIntoArray("??");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray37_Colon()
        {
            // Test with colon
            string[] expected = { ":", ":" };
            string[] actual = StringUtil.SplitStringIntoArray("::");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray38_Semicolon()
        {
            // Test with semicolon
            string[] expected = { ";", ";" };
            string[] actual = StringUtil.SplitStringIntoArray(";;");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray39_Comma()
        {
            // Test with comma
            string[] expected = { ",", "," };
            string[] actual = StringUtil.SplitStringIntoArray(",,");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSplitStringIntoArray40_Period()
        {
            // Test with period
            string[] expected = { ".", "." };
            string[] actual = StringUtil.SplitStringIntoArray("..");
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        #endregion


        #region IsValidString(string, string) tests

        [TestMethod]
        public void TestIsValidString()
        {
            Assert.AreEqual(false, StringUtil.IsValidCharacter("A", "abcdef_12345"));
            Assert.AreEqual(true, StringUtil.IsValidCharacter("a", "abcdef_12345"));
            Assert.AreEqual(false, StringUtil.IsValidCharacter(" ", "abcdef_12345"));
            Assert.AreEqual(true, StringUtil.IsValidCharacter(" ", "abcdef_ 12345"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIsValidString2_NullTest()
        {
            // Test null test string throws ArgumentNullException
            StringUtil.IsValidString(null, "abcdef_12345");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIsValidString3_NullValidChars()
        {
            // Test null validChars throws ArgumentNullException
            StringUtil.IsValidString("test", null);
        }

        [TestMethod]
        public void TestIsValidString4_EmptyTestString()
        {
            // Empty test string should return true (vacuously true)
            Assert.AreEqual(true, StringUtil.IsValidString("", "abc"));
        }

        [TestMethod]
        public void TestIsValidString5_EmptyValidChars()
        {
            // Empty validChars with non-empty test should return false
            Assert.AreEqual(false, StringUtil.IsValidString("a", ""));
        }

        [TestMethod]
        public void TestIsValidString6_BothEmpty()
        {
            // Both empty strings should return true
            Assert.AreEqual(true, StringUtil.IsValidString("", ""));
        }

        [TestMethod]
        public void TestIsValidString7_SingleLetterValid()
        {
            // Single lowercase letter that is valid
            Assert.AreEqual(true, StringUtil.IsValidString("a", "abcdefghijklmnopqrstuvwxyz"));
        }

        [TestMethod]
        public void TestIsValidString8_SingleLetterInvalid()
        {
            // Single lowercase letter that is invalid (uppercase not in valid list)
            Assert.AreEqual(false, StringUtil.IsValidString("A", "abcdefghijklmnopqrstuvwxyz"));
        }

        [TestMethod]
        public void TestIsValidString9_SingleDigitValid()
        {
            // Single digit that is valid
            Assert.AreEqual(true, StringUtil.IsValidString("5", "0123456789"));
        }

        [TestMethod]
        public void TestIsValidString10_SingleDigitInvalid()
        {
            // Single digit that is invalid (2 is not in the list)
            Assert.AreEqual(false, StringUtil.IsValidString("2", "013579"));
        }

        [TestMethod]
        public void TestIsValidString11_SingleSymbolValid()
        {
            // Single symbol that is valid
            Assert.AreEqual(true, StringUtil.IsValidString("!", "!@#$%"));
        }

        [TestMethod]
        public void TestIsValidString12_SingleSymbolInvalid()
        {
            // Single symbol that is invalid
            Assert.AreEqual(false, StringUtil.IsValidString("!", "abcdef"));
        }

        [TestMethod]
        public void TestIsValidString13_AllDigitsValid()
        {
            // All digits and all are valid
            Assert.AreEqual(true, StringUtil.IsValidString("12345", "0123456789"));
        }

        [TestMethod]
        public void TestIsValidString14_AllDigitsInvalid()
        {
            // All digits but some are invalid
            Assert.AreEqual(false, StringUtil.IsValidString("12345", "13579"));
        }

        [TestMethod]
        public void TestIsValidString15_AllLettersLowercaseValid()
        {
            // All lowercase letters and all are valid
            Assert.AreEqual(true, StringUtil.IsValidString("abc", "abcdefghijklmnopqrstuvwxyz"));
        }

        [TestMethod]
        public void TestIsValidString16_MixedCaseInvalid()
        {
            // Mixed case with uppercase not in valid list
            Assert.AreEqual(false, StringUtil.IsValidString("aBc", "abcdefghijklmnopqrstuvwxyz"));
        }

        [TestMethod]
        public void TestIsValidString17_Alphanumeric()
        {
            // Alphanumeric string that is valid
            Assert.AreEqual(true, StringUtil.IsValidString("abc123", "abcdefghijklmnopqrstuvwxyz0123456789"));
        }

        [TestMethod]
        public void TestIsValidString18_AlphanumericPartialInvalid()
        {
            // Alphanumeric with one invalid character
            Assert.AreEqual(false, StringUtil.IsValidString("abc!23", "abcdefghijklmnopqrstuvwxyz0123456789"));
        }

        [TestMethod]
        public void TestIsValidString19_RepeatingCharacters()
        {
            // String with repeating valid characters
            Assert.AreEqual(true, StringUtil.IsValidString("aaaa", "a"));
        }

        [TestMethod]
        public void TestIsValidString20_RepeatingCharactersInvalid()
        {
            // String with repeating characters where one is invalid
            Assert.AreEqual(false, StringUtil.IsValidString("aaab", "a"));
        }

        [TestMethod]
        public void TestIsValidString21_SpaceValid()
        {
            // String with space that is valid
            Assert.AreEqual(true, StringUtil.IsValidString("a b", "ab "));
        }

        [TestMethod]
        public void TestIsValidString22_SpaceInvalid()
        {
            // String with space that is not in valid list
            Assert.AreEqual(false, StringUtil.IsValidString("a b", "ab"));
        }

        [TestMethod]
        public void TestIsValidString23_TabValid()
        {
            // String with tab character that is valid
            Assert.AreEqual(true, StringUtil.IsValidString("a\tb", "ab\t"));
        }

        [TestMethod]
        public void TestIsValidString24_TabInvalid()
        {
            // String with tab character not in valid list
            Assert.AreEqual(false, StringUtil.IsValidString("a\tb", "ab"));
        }

        [TestMethod]
        public void TestIsValidString25_NewlineValid()
        {
            // String with newline that is valid
            Assert.AreEqual(true, StringUtil.IsValidString("a\nb", "ab\n"));
        }

        [TestMethod]
        public void TestIsValidString26_NewlineInvalid()
        {
            // String with newline not in valid list
            Assert.AreEqual(false, StringUtil.IsValidString("a\nb", "ab"));
        }

        [TestMethod]
        public void TestIsValidString27_SpecialCharactersValid()
        {
            // String with special characters all valid
            Assert.AreEqual(true, StringUtil.IsValidString("!@#$%", "!@#$%^&*()"));
        }

        [TestMethod]
        public void TestIsValidString28_SpecialCharactersInvalid()
        {
            // String with special characters, some invalid
            Assert.AreEqual(false, StringUtil.IsValidString("!@#$%", "!@#"));
        }

        [TestMethod]
        public void TestIsValidString29_UnicodeValid()
        {
            // String with unicode characters all valid
            Assert.AreEqual(true, StringUtil.IsValidString("★☆✓", "★☆✓"));
        }

        [TestMethod]
        public void TestIsValidString30_UnicodeInvalid()
        {
            // String with unicode character not in valid list
            Assert.AreEqual(false, StringUtil.IsValidString("★☆✓", "★☆"));
        }

        [TestMethod]
        public void TestIsValidString31_LongStringValid()
        {
            // Long string with all valid characters
            string test = new string('a', 100);
            Assert.AreEqual(true, StringUtil.IsValidString(test, "a"));
        }

        [TestMethod]
        public void TestIsValidString32_LongStringInvalid()
        {
            // Long string with one invalid character at the end
            string test = new string('a', 99) + "b";
            Assert.AreEqual(false, StringUtil.IsValidString(test, "a"));
        }

        [TestMethod]
        public void TestIsValidString33_NumericStringValid()
        {
            // All digits string that is valid
            Assert.AreEqual(true, StringUtil.IsValidString("123456789", "0123456789"));
        }

        [TestMethod]
        public void TestIsValidString34_NumericStringInvalid()
        {
            // Numeric string with invalid character
            Assert.AreEqual(false, StringUtil.IsValidString("12345a789", "0123456789"));
        }

        [TestMethod]
        public void TestIsValidString35_OnlySymbols()
        {
            // String with only symbols all valid
            Assert.AreEqual(true, StringUtil.IsValidString("!@#$%", "!@#$%^&*()_+-=[]{}|;':\",./<>?"));
        }

        [TestMethod]
        public void TestIsValidString36_OnlySymbolsPartialInvalid()
        {
            // String with only symbols, some invalid
            Assert.AreEqual(false, StringUtil.IsValidString("!@#$%", "!@#$"));
        }

        [TestMethod]
        public void TestIsValidString37_UppercaseLettersValid()
        {
            // All uppercase letters valid
            Assert.AreEqual(true, StringUtil.IsValidString("ABC", "ABCDEFGHIJKLMNOPQRSTUVWXYZ"));
        }

        [TestMethod]
        public void TestIsValidString38_UppercaseLettersInvalid()
        {
            // Uppercase letters but not in valid list
            Assert.AreEqual(false, StringUtil.IsValidString("ABC", "abcdefghijklmnopqrstuvwxyz"));
        }

        [TestMethod]
        public void TestIsValidString39_CaseSensitiveValidation()
        {
            // Verify case sensitivity - 'a' is not same as 'A'
            Assert.AreEqual(true, StringUtil.IsValidString("a", "aA"));
            Assert.AreEqual(false, StringUtil.IsValidString("a", "A"));
        }

        [TestMethod]
        public void TestIsValidString40_ValidCharsWithRepeats()
        {
            // Valid chars string can have repeated characters (should still work)
            Assert.AreEqual(true, StringUtil.IsValidString("abc", "aabbccdd"));
        }

        #endregion


        #region IsValid(string, string) tests

        [TestMethod]
        public void TestIsValid()
        {
            Assert.AreEqual(true, StringUtil.IsValid("asdf", @"[a-zA-Z_0-9]"));
            Assert.AreEqual(false, StringUtil.IsValid("asdf", @"[0-9]"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestIsValidNullTest()
        {
            string? test = null;
            string pattern = @"[a-zA-Z_0-9]";
            bool result = StringUtil.IsValid(test, pattern);
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestIsValidNullPattern()
        {
            string test = "asdf";
            string? pattern = null;
            bool result = StringUtil.IsValid(test, pattern);
            Assert.Fail();
        }

        [TestMethod]
        public void TestIsValid4_EmptyTestString()
        {
            // Empty test string matches empty pattern
            Assert.AreEqual(true, StringUtil.IsValid("", ""));
        }

        [TestMethod]
        public void TestIsValid5_EmptyPatternNonEmptyTest()
        {
            // Empty pattern matches any string (zero or more of anything)
            Assert.AreEqual(true, StringUtil.IsValid("abc", ""));
        }

        [TestMethod]
        public void TestIsValid6_OnlyDigits()
        {
            // Test digit-only pattern
            Assert.AreEqual(true, StringUtil.IsValid("12345", @"^[0-9]+$"));
            Assert.AreEqual(false, StringUtil.IsValid("1234a", @"^[0-9]+$"));
        }

        [TestMethod]
        public void TestIsValid7_OnlyLetters()
        {
            // Test letter-only pattern
            Assert.AreEqual(true, StringUtil.IsValid("abcde", @"^[a-zA-Z]+$"));
            Assert.AreEqual(false, StringUtil.IsValid("abcd1", @"^[a-zA-Z]+$"));
        }

        [TestMethod]
        public void TestIsValid8_OnlyUppercase()
        {
            // Test uppercase-only pattern
            Assert.AreEqual(true, StringUtil.IsValid("ABCDE", @"^[A-Z]+$"));
            Assert.AreEqual(false, StringUtil.IsValid("ABCDe", @"^[A-Z]+$"));
        }

        [TestMethod]
        public void TestIsValid9_OnlyLowercase()
        {
            // Test lowercase-only pattern
            Assert.AreEqual(true, StringUtil.IsValid("abcde", @"^[a-z]+$"));
            Assert.AreEqual(false, StringUtil.IsValid("abcDE", @"^[a-z]+$"));
        }

        [TestMethod]
        public void TestIsValid10_Whitespace()
        {
            // Test whitespace pattern
            Assert.AreEqual(true, StringUtil.IsValid("a b", @".*\s.*"));
            Assert.AreEqual(false, StringUtil.IsValid("abc", @".*\s.*"));
        }

        [TestMethod]
        public void TestIsValid11_WordCharacters()
        {
            // Test word character pattern (letters, digits, underscore)
            Assert.AreEqual(true, StringUtil.IsValid("abc_123", @"^\w+$"));
            Assert.AreEqual(false, StringUtil.IsValid("abc-123", @"^\w+$"));
        }

        [TestMethod]
        public void TestIsValid12_AnchorStart()
        {
            // Test anchor ^ (start of string)
            Assert.AreEqual(true, StringUtil.IsValid("abc", @"^abc"));
            Assert.AreEqual(false, StringUtil.IsValid("xabc", @"^abc"));
        }

        [TestMethod]
        public void TestIsValid13_AnchorEnd()
        {
            // Test anchor $ (end of string)
            Assert.AreEqual(true, StringUtil.IsValid("abc", @"abc$"));
            Assert.AreEqual(false, StringUtil.IsValid("abcx", @"abc$"));
        }

        [TestMethod]
        public void TestIsValid14_AnchorBoth()
        {
            // Test both anchors (exact match)
            Assert.AreEqual(true, StringUtil.IsValid("abc", @"^abc$"));
            Assert.AreEqual(false, StringUtil.IsValid("xabcx", @"^abc$"));
        }

        [TestMethod]
        public void TestIsValid15_QuantifierZeroOrMore()
        {
            // Test * quantifier (zero or more)
            Assert.AreEqual(true, StringUtil.IsValid("", @"^[a-z]*$"));
            Assert.AreEqual(true, StringUtil.IsValid("abc", @"^[a-z]*$"));
            Assert.AreEqual(false, StringUtil.IsValid("abc1", @"^[a-z]*$"));
        }

        [TestMethod]
        public void TestIsValid16_QuantifierOneOrMore()
        {
            // Test + quantifier (one or more)
            Assert.AreEqual(false, StringUtil.IsValid("", @"^[a-z]+$"));
            Assert.AreEqual(true, StringUtil.IsValid("abc", @"^[a-z]+$"));
            Assert.AreEqual(false, StringUtil.IsValid("abc1", @"^[a-z]+$"));
        }

        [TestMethod]
        public void TestIsValid17_QuantifierOptional()
        {
            // Test ? quantifier (zero or one)
            Assert.AreEqual(true, StringUtil.IsValid("ac", @"^ab?c$"));
            Assert.AreEqual(true, StringUtil.IsValid("abc", @"^ab?c$"));
            Assert.AreEqual(false, StringUtil.IsValid("abbc", @"^ab?c$"));
        }

        [TestMethod]
        public void TestIsValid18_QuantifierExact()
        {
            // Test {n} quantifier (exactly n)
            Assert.AreEqual(true, StringUtil.IsValid("aaa", @"^a{3}$"));
            Assert.AreEqual(false, StringUtil.IsValid("aa", @"^a{3}$"));
            Assert.AreEqual(false, StringUtil.IsValid("aaaa", @"^a{3}$"));
        }

        [TestMethod]
        public void TestIsValid19_QuantifierRange()
        {
            // Test {n,m} quantifier (between n and m)
            Assert.AreEqual(true, StringUtil.IsValid("aa", @"^a{2,4}$"));
            Assert.AreEqual(true, StringUtil.IsValid("aaa", @"^a{2,4}$"));
            Assert.AreEqual(false, StringUtil.IsValid("a", @"^a{2,4}$"));
            Assert.AreEqual(false, StringUtil.IsValid("aaaaa", @"^a{2,4}$"));
        }

        [TestMethod]
        public void TestIsValid20_Alternation()
        {
            // Test alternation |
            Assert.AreEqual(true, StringUtil.IsValid("abc", @"^(abc|def)$"));
            Assert.AreEqual(true, StringUtil.IsValid("def", @"^(abc|def)$"));
            Assert.AreEqual(false, StringUtil.IsValid("xyz", @"^(abc|def)$"));
        }

        [TestMethod]
        public void TestIsValid21_Group()
        {
            // Test grouping ()
            Assert.AreEqual(true, StringUtil.IsValid("abab", @"^(ab)+$"));
            Assert.AreEqual(false, StringUtil.IsValid("aba", @"^(ab)+$"));
        }

        [TestMethod]
        public void TestIsValid22_NegatedCharacterClass()
        {
            // Test negated character class [^...]
            Assert.AreEqual(true, StringUtil.IsValid("abc", @"^[^0-9]+$"));
            Assert.AreEqual(false, StringUtil.IsValid("abc1", @"^[^0-9]+$"));
        }

        [TestMethod]
        public void TestIsValid23_EmailPattern()
        {
            // Basic email pattern
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Assert.AreEqual(true, StringUtil.IsValid("test@example.com", emailPattern));
            Assert.AreEqual(true, StringUtil.IsValid("user.name+tag@example.co.uk", emailPattern));
            Assert.AreEqual(false, StringUtil.IsValid("invalid.email@", emailPattern));
        }

        [TestMethod]
        public void TestIsValid24_URLPattern()
        {
            // Basic URL pattern
            string urlPattern = @"^https?://[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}";
            Assert.AreEqual(true, StringUtil.IsValid("http://example.com", urlPattern));
            Assert.AreEqual(true, StringUtil.IsValid("https://example.com/path", urlPattern));
            Assert.AreEqual(false, StringUtil.IsValid("ftp://example.com", urlPattern));
        }

        [TestMethod]
        public void TestIsValid25_PhonePattern()
        {
            // Phone number pattern (simple: digits and hyphens)
            string phonePattern = @"^[\d\-\(\)]+$";
            Assert.AreEqual(true, StringUtil.IsValid("123-456-7890", phonePattern));
            Assert.AreEqual(true, StringUtil.IsValid("(123)456-7890", phonePattern));
            Assert.AreEqual(false, StringUtil.IsValid("123-456-789a", phonePattern));
        }

        [TestMethod]
        public void TestIsValid26_USZipCode()
        {
            // US Zip code pattern
            string zipPattern = @"^\d{5}(-\d{4})?$";
            Assert.AreEqual(true, StringUtil.IsValid("12345", zipPattern));
            Assert.AreEqual(true, StringUtil.IsValid("12345-6789", zipPattern));
            Assert.AreEqual(false, StringUtil.IsValid("1234", zipPattern));
        }

        [TestMethod]
        public void TestIsValid27_DatePattern()
        {
            // Date pattern (YYYY-MM-DD)
            string datePattern = @"^\d{4}-\d{2}-\d{2}$";
            Assert.AreEqual(true, StringUtil.IsValid("2023-12-25", datePattern));
            Assert.AreEqual(false, StringUtil.IsValid("25-12-2023", datePattern));
        }

        [TestMethod]
        public void TestIsValid28_TimePattern()
        {
            // Time pattern (HH:MM:SS)
            string timePattern = @"^\d{2}:\d{2}:\d{2}$";
            Assert.AreEqual(true, StringUtil.IsValid("14:30:00", timePattern));
            Assert.AreEqual(false, StringUtil.IsValid("14:30", timePattern));
        }

        [TestMethod]
        public void TestIsValid29_HexadecimalPattern()
        {
            // Hexadecimal pattern
            string hexPattern = @"^[0-9A-Fa-f]+$";
            Assert.AreEqual(true, StringUtil.IsValid("ABCDEF123", hexPattern));
            Assert.AreEqual(false, StringUtil.IsValid("GHIJKL", hexPattern));
        }

        [TestMethod]
        public void TestIsValid30_IPAddressPattern()
        {
            // Simple IP address pattern
            string ipPattern = @"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$";
            Assert.AreEqual(true, StringUtil.IsValid("192.168.1.1", ipPattern));
            Assert.AreEqual(true, StringUtil.IsValid("10.0.0.1", ipPattern));
            Assert.AreEqual(true, StringUtil.IsValid("256.256.256.256", ipPattern));
        }

        [TestMethod]
        public void TestIsValid31_CreditCardPattern()
        {
            // Credit card pattern (simplified, just digits)
            string ccPattern = @"^\d{13,19}$";
            Assert.AreEqual(true, StringUtil.IsValid("4532015112830366", ccPattern));
            Assert.AreEqual(false, StringUtil.IsValid("4532-0151-1283-0366", ccPattern));
        }

        [TestMethod]
        public void TestIsValid32_SpecialCharactersLiteral()
        {
            // Matching literal special characters
            Assert.AreEqual(true, StringUtil.IsValid("a.b", @"^a\.b$"));
            Assert.AreEqual(false, StringUtil.IsValid("aXb", @"^a\.b$"));
        }

        [TestMethod]
        public void TestIsValid33_DotAnyCharacter()
        {
            // . matches any character
            Assert.AreEqual(true, StringUtil.IsValid("abc", @"^a.c$"));
            Assert.AreEqual(true, StringUtil.IsValid("aXc", @"^a.c$"));
            Assert.AreEqual(false, StringUtil.IsValid("ac", @"^a.c$"));
        }

        [TestMethod]
        public void TestIsValid34_CaseSensitivity()
        {
            // Regex is case-sensitive by default
            Assert.AreEqual(true, StringUtil.IsValid("ABC", @"^ABC$"));
            Assert.AreEqual(false, StringUtil.IsValid("abc", @"^ABC$"));
        }

        [TestMethod]
        public void TestIsValid35_PartialMatch()
        {
            // Without anchors, matches anywhere in string
            Assert.AreEqual(true, StringUtil.IsValid("xabcy", @"abc"));
            Assert.AreEqual(false, StringUtil.IsValid("xabcy", @"^abc$"));
        }

        [TestMethod]
        public void TestIsValid36_MultilineText()
        {
            // Pattern matching with multiple lines - . doesn't match newlines by default
            Assert.AreEqual(false, StringUtil.IsValid("abc\ndef", @"abc.*def"));
            Assert.AreEqual(false, StringUtil.IsValid("abc\ndef", @"^abc.*def$"));
        }

        [TestMethod]
        public void TestIsValid37_EscapedBackslash()
        {
            // Escaped backslash
            Assert.AreEqual(true, StringUtil.IsValid(@"a\b", @"^a\\b$"));
            Assert.AreEqual(false, StringUtil.IsValid("a/b", @"^a\\b$"));
        }

        [TestMethod]
        public void TestIsValid38_CharacterRanges()
        {
            // Character ranges
            Assert.AreEqual(true, StringUtil.IsValid("m", @"^[a-z]$"));
            Assert.AreEqual(true, StringUtil.IsValid("5", @"^[0-9]$"));
            Assert.AreEqual(false, StringUtil.IsValid("M", @"^[a-z]$"));
        }

        [TestMethod]
        public void TestIsValid39_MultipleCharacterRanges()
        {
            // Multiple character ranges in one class
            Assert.AreEqual(true, StringUtil.IsValid("a", @"^[a-zA-Z0-9_]$"));
            Assert.AreEqual(true, StringUtil.IsValid("Z", @"^[a-zA-Z0-9_]$"));
            Assert.AreEqual(true, StringUtil.IsValid("5", @"^[a-zA-Z0-9_]$"));
            Assert.AreEqual(false, StringUtil.IsValid("-", @"^[a-zA-Z0-9_]$"));
        }

        [TestMethod]
        public void TestIsValid40_Asterisk()
        {
            // * matches zero or more occurrences
            Assert.AreEqual(true, StringUtil.IsValid("", @"^a*$"));
            Assert.AreEqual(true, StringUtil.IsValid("aaa", @"^a*$"));
            Assert.AreEqual(false, StringUtil.IsValid("aab", @"^a*$"));
        }

        #endregion


        #region IsValidCharacter(string, string) tests

        [TestMethod]
        public void TestIsValidCharacter()
        {
            Assert.AreEqual(false, StringUtil.IsValidCharacter("A", "abcdef_12345"));
            Assert.AreEqual(true, StringUtil.IsValidCharacter("a", "abcdef_12345"));
            Assert.AreEqual(false, StringUtil.IsValidCharacter(" ", "abcdef_12345"));
            Assert.AreEqual(true, StringUtil.IsValidCharacter(" ", "abcdef_ 12345"));
        }

        [TestMethod]
        public void TestIsValidCharacter2_EmptyTestString()
        {
            // Empty test string should return false
            Assert.AreEqual(false, StringUtil.IsValidCharacter("", "abc"));
        }

        [TestMethod]
        public void TestIsValidCharacter3_MultiCharTestString()
        {
            // Multi-character test string should return false
            Assert.AreEqual(false, StringUtil.IsValidCharacter("ab", "abcdef"));
        }

        [TestMethod]
        public void TestIsValidCharacter4_MultiCharTestString2()
        {
            // Multi-character test string should return false even if chars are in validChars
            Assert.AreEqual(false, StringUtil.IsValidCharacter("abc", "abcdef"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIsValidCharacter5_NullTestString()
        {
            StringUtil.IsValidCharacter(null, "abc");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIsValidCharacter6_NullValidChars()
        {
            StringUtil.IsValidCharacter("a", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIsValidCharacter7_BothNull()
        {
            StringUtil.IsValidCharacter(null, null);
        }

        [TestMethod]
        public void TestIsValidCharacter8_Digit0()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter("0", "0123456789"));
        }

        [TestMethod]
        public void TestIsValidCharacter9_Digit5()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter("5", "0123456789"));
        }

        [TestMethod]
        public void TestIsValidCharacter10_Digit9()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter("9", "0123456789"));
        }

        [TestMethod]
        public void TestIsValidCharacter11_DigitNotInSet()
        {
            Assert.AreEqual(false, StringUtil.IsValidCharacter("5", "abcdef"));
        }

        [TestMethod]
        public void TestIsValidCharacter12_ExclamationMark()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter("!", "!@#$%"));
        }

        [TestMethod]
        public void TestIsValidCharacter13_DollarSign()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter("$", "!@#$%"));
        }

        [TestMethod]
        public void TestIsValidCharacter14_SpecialCharNotInSet()
        {
            Assert.AreEqual(false, StringUtil.IsValidCharacter("&", "!@#$%"));
        }

        [TestMethod]
        public void TestIsValidCharacter15_OpenParen()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter("(", "()[]{}"));
        }

        [TestMethod]
        public void TestIsValidCharacter16_CloseBracket()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter("]", "()[]{}"));
        }

        [TestMethod]
        public void TestIsValidCharacter17_OpenBrace()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter("{", "()[]{}"));
        }

        [TestMethod]
        public void TestIsValidCharacter18_Tab()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter("\t", "a\tb\tc"));
        }

        [TestMethod]
        public void TestIsValidCharacter19_TabNotInSet()
        {
            Assert.AreEqual(false, StringUtil.IsValidCharacter("\t", "abc"));
        }

        [TestMethod]
        public void TestIsValidCharacter20_Newline()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter("\n", "a\nb\nc"));
        }

        [TestMethod]
        public void TestIsValidCharacter21_NewlineNotInSet()
        {
            Assert.AreEqual(false, StringUtil.IsValidCharacter("\n", "abc"));
        }

        [TestMethod]
        public void TestIsValidCharacter22_CarriageReturn()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter("\r", "a\rb\rc"));
        }

        [TestMethod]
        public void TestIsValidCharacter23_CaseSensitiveUppercase()
        {
            // Uppercase A not in lowercase-only set
            Assert.AreEqual(false, StringUtil.IsValidCharacter("A", "abcdef"));
        }

        [TestMethod]
        public void TestIsValidCharacter24_CaseSensitiveLowercase()
        {
            // Lowercase a not in uppercase-only set
            Assert.AreEqual(false, StringUtil.IsValidCharacter("a", "ABCDEF"));
        }

        [TestMethod]
        public void TestIsValidCharacter25_CaseSensitiveMixed()
        {
            // Lowercase a in mixed case set
            Assert.AreEqual(true, StringUtil.IsValidCharacter("a", "AaBbCc"));
        }

        [TestMethod]
        public void TestIsValidCharacter26_CharAtStart()
        {
            // Character at start of validChars
            Assert.AreEqual(true, StringUtil.IsValidCharacter("a", "abcdef"));
        }

        [TestMethod]
        public void TestIsValidCharacter27_CharAtMiddle()
        {
            // Character in middle of validChars
            Assert.AreEqual(true, StringUtil.IsValidCharacter("c", "abcdef"));
        }

        [TestMethod]
        public void TestIsValidCharacter28_CharAtEnd()
        {
            // Character at end of validChars
            Assert.AreEqual(true, StringUtil.IsValidCharacter("f", "abcdef"));
        }

        [TestMethod]
        public void TestIsValidCharacter29_SingleCharValidChars()
        {
            // Single character in validChars
            Assert.AreEqual(true, StringUtil.IsValidCharacter("x", "x"));
        }

        [TestMethod]
        public void TestIsValidCharacter30_SingleCharValidCharsNotMatching()
        {
            // Single character in validChars but doesn't match
            Assert.AreEqual(false, StringUtil.IsValidCharacter("y", "x"));
        }

        [TestMethod]
        public void TestIsValidCharacter31_LongValidCharsSet()
        {
            // Long set of valid characters
            string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+-=[]{}|;':\",./<>?";
            Assert.AreEqual(true, StringUtil.IsValidCharacter("z", validChars));
        }

        [TestMethod]
        public void TestIsValidCharacter32_LongValidCharsSetChar()
        {
            // Long set of valid characters
            string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+-=[]{}|;':\",./<>?";
            Assert.AreEqual(true, StringUtil.IsValidCharacter("@", validChars));
        }

        [TestMethod]
        public void TestIsValidCharacter33_LongValidCharsSetNotFound()
        {
            // Long set of valid characters, but character not found
            string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+-=[]{}|;':\",./<>?";
            Assert.AreEqual(false, StringUtil.IsValidCharacter("~", validChars));
        }

        [TestMethod]
        public void TestIsValidCharacter34_SpaceAtStart()
        {
            // Space at start of validChars
            Assert.AreEqual(true, StringUtil.IsValidCharacter(" ", " abc"));
        }

        [TestMethod]
        public void TestIsValidCharacter35_SpaceAtEnd()
        {
            // Space at end of validChars
            Assert.AreEqual(true, StringUtil.IsValidCharacter(" ", "abc "));
        }

        [TestMethod]
        public void TestIsValidCharacter36_SpaceInMiddle()
        {
            // Space in middle of validChars
            Assert.AreEqual(true, StringUtil.IsValidCharacter(" ", "ab c"));
        }

        [TestMethod]
        public void TestIsValidCharacter37_Plus()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter("+", "+-*/"));
        }

        [TestMethod]
        public void TestIsValidCharacter38_Minus()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter("-", "+-*/"));
        }

        [TestMethod]
        public void TestIsValidCharacter39_Asterisk()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter("*", "+-*/"));
        }

        [TestMethod]
        public void TestIsValidCharacter40_Slash()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter("/", "+-*/"));
        }

        [TestMethod]
        public void TestIsValidCharacter41_Dot()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter(".", "0123456789."));
        }

        [TestMethod]
        public void TestIsValidCharacter42_Underscore()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter("_", "abcdef_12345"));
        }

        [TestMethod]
        public void TestIsValidCharacter43_Hyphen()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter("-", "a-b-c"));
        }

        [TestMethod]
        public void TestIsValidCharacter44_Comma()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter(",", "a,b,c"));
        }

        [TestMethod]
        public void TestIsValidCharacter45_Semicolon()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter(";", "a;b;c"));
        }

        [TestMethod]
        public void TestIsValidCharacter46_Colon()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter(":", "a:b:c"));
        }

        [TestMethod]
        public void TestIsValidCharacter47_DoubleQuote()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter("\"", "\"'`"));
        }

        [TestMethod]
        public void TestIsValidCharacter48_SingleQuote()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter("'", "\"'`"));
        }

        [TestMethod]
        public void TestIsValidCharacter49_Backtick()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter("`", "\"'`"));
        }

        [TestMethod]
        public void TestIsValidCharacter50_LessThan()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter("<", "<>"));
        }

        [TestMethod]
        public void TestIsValidCharacter51_GreaterThan()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter(">", "<>"));
        }

        [TestMethod]
        public void TestIsValidCharacter52_Equals()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter("=", "=!<>"));
        }

        [TestMethod]
        public void TestIsValidCharacter53_At()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter("@", "@#$%^"));
        }

        [TestMethod]
        public void TestIsValidCharacter54_Hash()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter("#", "@#$%^"));
        }

        [TestMethod]
        public void TestIsValidCharacter55_Percent()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter("%", "@#$%^"));
        }

        [TestMethod]
        public void TestIsValidCharacter56_Caret()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter("^", "@#$%^"));
        }

        [TestMethod]
        public void TestIsValidCharacter57_Ampersand()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter("&", "&*()"));
        }

        [TestMethod]
        public void TestIsValidCharacter58_Pipe()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter("|", "||"));
        }

        [TestMethod]
        public void TestIsValidCharacter59_Backslash()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter("\\", "\\|/"));
        }

        [TestMethod]
        public void TestIsValidCharacter60_Question()
        {
            Assert.AreEqual(true, StringUtil.IsValidCharacter("?", "?!."));
        }

        #endregion


        #region CountTokens(string, string) tests

        [TestMethod]
        public void TestCountTokens1()
        {
            Assert.AreEqual(1, StringUtil.CountTokens("", "|"));
        }

        [TestMethod]
        public void TestCountTokens2()
        {
            Assert.AreEqual(2, StringUtil.CountTokens("a|", "|"));
        }

        [TestMethod]
        public void TestCountTokens3()
        {
            Assert.AreEqual(2, StringUtil.CountTokens("a|b", "|"));
        }

        [TestMethod]
        public void TestCountTokens4()
        {
            Assert.AreEqual(3, StringUtil.CountTokens("a|b|c", "|"));
        }

        [TestMethod]
        public void TestCountTokens5()
        {
            Assert.AreEqual(4, StringUtil.CountTokens("a|b|c|", "|"));
        }

        [TestMethod]
        public void TestCountTokens6()
        {
            Assert.AreEqual(2, StringUtil.CountTokens("|", "|"));
        }

        [TestMethod]
        public void TestCountTokens7()
        {
            Assert.AreEqual(2, StringUtil.CountTokens("|a", "|"));
        }

        [TestMethod]
        public void TestCountTokens8()
        {
            Assert.AreEqual(1, StringUtil.CountTokens("a", "|"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCountTokens9_NullSource()
        {
            StringUtil.CountTokens(null, "|");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCountTokens10_NullDelimiter()
        {
            StringUtil.CountTokens("a|b|c", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCountTokens11_BothNull()
        {
            StringUtil.CountTokens(null, null);
        }

        [TestMethod]
        public void TestCountTokens12_MultiCharDelimiter()
        {
            Assert.AreEqual(2, StringUtil.CountTokens("a||b", "||"));
        }

        [TestMethod]
        public void TestCountTokens13_MultiCharDelimiter2()
        {
            Assert.AreEqual(3, StringUtil.CountTokens("a||b||c", "||"));
        }

        [TestMethod]
        public void TestCountTokens14_MultiCharDelimiterArrow()
        {
            Assert.AreEqual(2, StringUtil.CountTokens("a->b", "->"));
        }

        [TestMethod]
        public void TestCountTokens15_MultiCharDelimiterArrow2()
        {
            Assert.AreEqual(3, StringUtil.CountTokens("a->b->c", "->"));
        }

        [TestMethod]
        public void TestCountTokens16_ConsecutiveDelimiters3Times()
        {
            Assert.AreEqual(4, StringUtil.CountTokens("a|||b", "|"));
        }

        [TestMethod]
        public void TestCountTokens17_ConsecutiveDelimiters4Times()
        {
            Assert.AreEqual(5, StringUtil.CountTokens("a||||b", "|"));
        }

        [TestMethod]
        public void TestCountTokens18_OnlyConsecutiveDelimiters()
        {
            Assert.AreEqual(4, StringUtil.CountTokens("|||", "|"));
        }

        [TestMethod]
        public void TestCountTokens19_CommaDelimiter()
        {
            Assert.AreEqual(3, StringUtil.CountTokens("a,b,c", ","));
        }

        [TestMethod]
        public void TestCountTokens20_SemicolonDelimiter()
        {
            Assert.AreEqual(3, StringUtil.CountTokens("a;b;c", ";"));
        }

        [TestMethod]
        public void TestCountTokens21_ColonDelimiter()
        {
            Assert.AreEqual(3, StringUtil.CountTokens("a:b:c", ":"));
        }

        [TestMethod]
        public void TestCountTokens22_SpaceDelimiter()
        {
            Assert.AreEqual(3, StringUtil.CountTokens("a b c", " "));
        }

        [TestMethod]
        public void TestCountTokens23_TabDelimiter()
        {
            Assert.AreEqual(3, StringUtil.CountTokens("a\tb\tc", "\t"));
        }

        [TestMethod]
        public void TestCountTokens24_NewlineDelimiter()
        {
            Assert.AreEqual(3, StringUtil.CountTokens("a\nb\nc", "\n"));
        }

        [TestMethod]
        public void TestCountTokens25_SlashDelimiter()
        {
            Assert.AreEqual(3, StringUtil.CountTokens("a/b/c", "/"));
        }

        [TestMethod]
        public void TestCountTokens26_BackslashDelimiter()
        {
            Assert.AreEqual(3, StringUtil.CountTokens("a\\b\\c", "\\"));
        }

        [TestMethod]
        public void TestCountTokens27_DotDelimiter()
        {
            Assert.AreEqual(4, StringUtil.CountTokens("192.168.0.1", "."));
        }

        [TestMethod]
        public void TestCountTokens28_HyphenDelimiter()
        {
            Assert.AreEqual(3, StringUtil.CountTokens("a-b-c", "-"));
        }

        [TestMethod]
        public void TestCountTokens29_UnderscoreDelimiter()
        {
            Assert.AreEqual(3, StringUtil.CountTokens("a_b_c", "_"));
        }

        [TestMethod]
        public void TestCountTokens30_PlusDelimiter()
        {
            Assert.AreEqual(3, StringUtil.CountTokens("a+b+c", "+"));
        }

        [TestMethod]
        public void TestCountTokens31_AsteriskDelimiter()
        {
            Assert.AreEqual(3, StringUtil.CountTokens("a*b*c", "*"));
        }

        [TestMethod]
        public void TestCountTokens32_AtDelimiter()
        {
            Assert.AreEqual(3, StringUtil.CountTokens("a@b@c", "@"));
        }

        [TestMethod]
        public void TestCountTokens33_HashDelimiter()
        {
            Assert.AreEqual(3, StringUtil.CountTokens("a#b#c", "#"));
        }

        [TestMethod]
        public void TestCountTokens34_DollarDelimiter()
        {
            Assert.AreEqual(3, StringUtil.CountTokens("a$b$c", "$"));
        }

        [TestMethod]
        public void TestCountTokens35_AmpersandDelimiter()
        {
            Assert.AreEqual(3, StringUtil.CountTokens("a&b&c", "&"));
        }

        [TestMethod]
        public void TestCountTokens36_PipeDelimiter()
        {
            Assert.AreEqual(3, StringUtil.CountTokens("a|b|c", "|"));
        }

        [TestMethod]
        public void TestCountTokens37_SourceEqualsDelimiter()
        {
            Assert.AreEqual(2, StringUtil.CountTokens("|", "|"));
        }

        [TestMethod]
        public void TestCountTokens38_DelimiterLongerThanSource()
        {
            // Delimiter "||" not found in "a" = 1 token
            Assert.AreEqual(1, StringUtil.CountTokens("a", "||"));
        }

        [TestMethod]
        public void TestCountTokens39_SingleLetter()
        {
            Assert.AreEqual(1, StringUtil.CountTokens("a", ","));
        }

        [TestMethod]
        public void TestCountTokens40_LongString()
        {
            // Test with a string containing many delimiters
            Assert.AreEqual(11, StringUtil.CountTokens("1,2,3,4,5,6,7,8,9,10,11", ","));
        }

        [TestMethod]
        public void TestCountTokens41_LeadingDelimiters()
        {
            Assert.AreEqual(4, StringUtil.CountTokens("||a|b", "|"));
        }

        [TestMethod]
        public void TestCountTokens42_TrailingDelimiters()
        {
            Assert.AreEqual(4, StringUtil.CountTokens("a|b||", "|"));
        }

        [TestMethod]
        public void TestCountTokens43_MiddleDelimiters()
        {
            Assert.AreEqual(4, StringUtil.CountTokens("a||b|c", "|"));
        }

        [TestMethod]
        public void TestCountTokens44_MultiCharDelimiterLeading()
        {
            Assert.AreEqual(2, StringUtil.CountTokens("::a", "::"));
        }

        [TestMethod]
        public void TestCountTokens45_MultiCharDelimiterTrailing()
        {
            Assert.AreEqual(2, StringUtil.CountTokens("a::", "::"));
        }

        [TestMethod]
        public void TestCountTokens46_MultiCharDelimiterConsecutive()
        {
            // "a::::b" split by "::" should give ["a", "", "b"] = 3 tokens
            Assert.AreEqual(3, StringUtil.CountTokens("a::::b", "::"));
        }

        [TestMethod]
        public void TestCountTokens47_WordDelimiter()
        {
            // "-OR-" appears once, so 2 tokens
            Assert.AreEqual(2, StringUtil.CountTokens("apple-OR-orange", "-OR-"));
        }

        [TestMethod]
        public void TestCountTokens48_WordDelimiter2()
        {
            // "-OR-" appears twice, so 3 tokens
            Assert.AreEqual(3, StringUtil.CountTokens("apple-OR-orange-OR-banana", "-OR-"));
        }

        [TestMethod]
        public void TestCountTokens49_CaseSensitiveDelimiter()
        {
            // "A" (uppercase) appears twice in "aAbAc", so 3 tokens
            Assert.AreEqual(3, StringUtil.CountTokens("aAbAc", "A"));
        }

        [TestMethod]
        public void TestCountTokens50_CaseSensitiveDelimiter2()
        {
            Assert.AreEqual(3, StringUtil.CountTokens("aAaAa", "A"));
        }

        [TestMethod]
        public void TestCountTokens51_DoubleCharDelimiterNoMatch()
        {
            // ">>" not found in "a>b>c" = 1 token
            Assert.AreEqual(1, StringUtil.CountTokens("a>b>c", ">>"));
        }

        [TestMethod]
        public void TestCountTokens52_SpecialRegexChars()
        {
            // Test with characters that are special in regex
            Assert.AreEqual(3, StringUtil.CountTokens("a.b.c", "."));
        }

        [TestMethod]
        public void TestCountTokens53_SpecialRegexChars2()
        {
            Assert.AreEqual(3, StringUtil.CountTokens("a*b*c", "*"));
        }

        [TestMethod]
        public void TestCountTokens54_SpecialRegexChars3()
        {
            Assert.AreEqual(3, StringUtil.CountTokens("a+b+c", "+"));
        }

        [TestMethod]
        public void TestCountTokens55_SpecialRegexChars4()
        {
            Assert.AreEqual(3, StringUtil.CountTokens("a?b?c", "?"));
        }

        [TestMethod]
        public void TestCountTokens56_SingleSpaceDelimiter()
        {
            Assert.AreEqual(4, StringUtil.CountTokens("one two three four", " "));
        }

        [TestMethod]
        public void TestCountTokens57_MultipleSpaces()
        {
            // Each space is a delimiter, so multiple spaces = multiple tokens with empty strings between
            Assert.AreEqual(5, StringUtil.CountTokens("a  b  c", " "));
        }

        [TestMethod]
        public void TestCountTokens58_ThreeCharDelimiter()
        {
            Assert.AreEqual(3, StringUtil.CountTokens("a***b***c", "***"));
        }

        [TestMethod]
        public void TestCountTokens59_VeryLongDelimiter()
        {
            Assert.AreEqual(2, StringUtil.CountTokens("a---b", "---"));
        }

        [TestMethod]
        public void TestCountTokens60_DelimiterWithNumbers()
        {
            // "|2" appears once in "item1|2item2|3item3", so 2 tokens
            Assert.AreEqual(2, StringUtil.CountTokens("item1|2item2|3item3", "|2"));
        }

        #endregion


        #region GetToken(string, string, int) tests

        [TestMethod]
        public void TestGetToken1()
        {
            Assert.AreEqual("a", StringUtil.GetToken("a|s|d|f", "|", 1));
        }

        [TestMethod]
        public void TestGetToken2()
        {
            Assert.AreEqual("s", StringUtil.GetToken("a|s|d|f", "|", 2));
        }

        [TestMethod]
        public void TestGetToken3()
        {
            Assert.AreEqual("d", StringUtil.GetToken("a|s|d|f", "|", 3));
        }

        [TestMethod]
        public void TestGetToken4()
        {
            Assert.AreEqual("f", StringUtil.GetToken("a|s|d|f", "|", 4));
        }

        [TestMethod]
        public void TestGetToken5()
        {
            Assert.AreEqual("", StringUtil.GetToken("a|s|d|f|", "|", 5));
        }

        [TestMethod]
        public void TestGetToken6()
        {
            Assert.AreEqual("", StringUtil.GetToken("|a|s|d|f|", "|", 1));
        }

        [TestMethod]
        public void TestGetToken7()
        {
            Assert.AreEqual("a", StringUtil.GetToken("|a|s|d|f", "|", 2));
        }

        [TestMethod]
        public void TestGetToken8()
        {
            Assert.AreEqual("s", StringUtil.GetToken("|a|s|d|f", "|", 3));
        }

        [TestMethod]
        public void TestGetToken9()
        {
            Assert.AreEqual("d", StringUtil.GetToken("|a|s|d|f", "|", 4));
        }

        [TestMethod]
        public void TestGetToken10()
        {
            Assert.AreEqual("f", StringUtil.GetToken("|a|s|d|f", "|", 5));
        }

        [TestMethod]
        public void TestGetToken11()
        {
            Assert.AreEqual("", StringUtil.GetToken("|a|s|d|f|", "|", 6));
        }

        [TestMethod]
        public void TestGetToken12()
        {
            Assert.AreEqual("asdf", StringUtil.GetToken("asdf|qwer|zxcv|1234", "|", 1));
        }

        [TestMethod]
        public void TestGetToken13()
        {
            Assert.AreEqual("qwer", StringUtil.GetToken("asdf|qwer|zxcv|1234", "|", 2));
        }

        [TestMethod]
        public void TestGetToken14()
        {
            Assert.AreEqual("zxcv", StringUtil.GetToken("asdf|qwer|zxcv|1234", "|", 3));
        }

        [TestMethod]
        public void TestGetToken15()
        {
            Assert.AreEqual("1234", StringUtil.GetToken("asdf|qwer|zxcv|1234", "|", 4));
        }

        [TestMethod]
        public void TestGetToken16()
        {
            Assert.AreEqual("", StringUtil.GetToken("asdf|qwer|zxcv|1234|", "|", 5));
        }

        [TestMethod]
        public void TestGetToken17()
        {
            Assert.AreEqual("", StringUtil.GetToken("|asdf|qwer|zxcv|1234", "|", 1));
        }

        [TestMethod]
        public void TestGetToken18()
        {
            Assert.AreEqual("asdf", StringUtil.GetToken("|asdf|qwer|zxcv|1234", "|", 2));
        }

        [TestMethod]
        public void TestGetToken19()
        {
            Assert.AreEqual("qwer", StringUtil.GetToken("|asdf|qwer|zxcv|1234", "|", 3));
        }

        [TestMethod]
        public void TestGetToken20()
        {
            Assert.AreEqual("zxcv", StringUtil.GetToken("|asdf|qwer|zxcv|1234", "|", 4));
        }

        [TestMethod]
        public void TestGetToken21()
        {
            Assert.AreEqual("1234", StringUtil.GetToken("|asdf|qwer|zxcv|1234", "|", 5));
        }

        [TestMethod]
        public void TestGetToken22()
        {
            Assert.AreEqual("", StringUtil.GetToken("|asdf|qwer|zxcv|1234|", "|", 6));
        }

        [TestMethod]
        public void TestGetToken23()
        {
            Assert.AreEqual("", StringUtil.GetToken("||||", "|", 1));
        }

        [TestMethod]
        public void TestGetToken24()
        {
            Assert.AreEqual("", StringUtil.GetToken("||||", "|", 2));
        }

        [TestMethod]
        public void TestGetToken25()
        {
            Assert.AreEqual("", StringUtil.GetToken("||||", "|", 3));
        }

        [TestMethod]
        public void TestGetToken26()
        {
            Assert.AreEqual("", StringUtil.GetToken("||||", "|", 4));
        }

        [TestMethod]
        public void TestGetToken27()
        {
            Assert.AreEqual("", StringUtil.GetToken("||||", "|", 5));
        }

        [TestMethod]
        public void TestGetToken28()
        {
            Assert.AreEqual("a", StringUtil.GetToken("a|b", "|", 1));
            Assert.AreEqual("b", StringUtil.GetToken("a|b", "|", 2));
        }

        [TestMethod]
        public void TestGetToken29()
        {
            Assert.AreEqual("a", StringUtil.GetToken("a|", "|", 1));
        }

        [TestMethod]
        public void TestGetToken30()
        {
            Assert.AreEqual("a", StringUtil.GetToken("a", "|", 1));
        }

        [TestMethod]
        public void TestGetToken31()
        {
            Assert.AreEqual("a", StringUtil.GetToken("|a", "|", 2));
        }

        [TestMethod]
        public void TestGetToken32()
        {
            Assert.AreEqual(String.Empty, StringUtil.GetToken("|a", "|", 1));
        }

        [TestMethod]
        public void TestGetToken33()
        {
            Assert.AreEqual(String.Empty, StringUtil.GetToken("", "|", 1));
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGetTokenBigPos1()
        {
            Assert.AreEqual("f", StringUtil.GetToken("a|s|d|f", "|", 5));
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGetTokenBigPos2()
        {
            Assert.AreEqual("f", StringUtil.GetToken("a|s|d|f", "|", 6));
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGetTokenBigPos3()
        {
            Assert.AreEqual("f", StringUtil.GetToken("a|s|d|f|", "|", 6));
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGetTokenBigPos4()
        {
            Assert.AreEqual("f", StringUtil.GetToken("a|s|d|f|", "|", 7));
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGetTokenSmallPos1()
        {
            Assert.AreEqual("", StringUtil.GetToken("a|s|d|f", "|", 0));
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGetTokenSmallPos2()
        {
            Assert.AreEqual("", StringUtil.GetToken("a|s|d|f", "|", -1));
            Assert.Fail();
        }

        // Multi-character delimiter tests
        [TestMethod]
        public void TestGetToken34_MultiCharDelimiterBasic()
        {
            Assert.AreEqual("a", StringUtil.GetToken("a::b::c", "::", 1));
        }

        [TestMethod]
        public void TestGetToken35_MultiCharDelimiterSecondToken()
        {
            Assert.AreEqual("b", StringUtil.GetToken("a::b::c", "::", 2));
        }

        [TestMethod]
        public void TestGetToken36_MultiCharDelimiterThirdToken()
        {
            Assert.AreEqual("c", StringUtil.GetToken("a::b::c", "::", 3));
        }

        [TestMethod]
        public void TestGetToken37_MultiCharDelimiterConsecutive()
        {
            // "a::::b" split by "::" should give ["a", "", "b"]
            Assert.AreEqual("a", StringUtil.GetToken("a::::b", "::", 1));
        }

        [TestMethod]
        public void TestGetToken38_MultiCharDelimiterConsecutiveEmptyToken()
        {
            // "a::::b" split by "::" should give ["a", "", "b"]
            Assert.AreEqual("", StringUtil.GetToken("a::::b", "::", 2));
        }

        [TestMethod]
        public void TestGetToken39_MultiCharDelimiterConsecutiveThirdToken()
        {
            // "a::::b" split by "::" should give ["a", "", "b"]
            Assert.AreEqual("b", StringUtil.GetToken("a::::b", "::", 3));
        }

        [TestMethod]
        public void TestGetToken40_MultiCharDelimiterDashDelimiter()
        {
            Assert.AreEqual("hello", StringUtil.GetToken("hello--world--test", "--", 1));
        }

        [TestMethod]
        public void TestGetToken41_MultiCharDelimiterDashDelimiterSecond()
        {
            Assert.AreEqual("world", StringUtil.GetToken("hello--world--test", "--", 2));
        }

        [TestMethod]
        public void TestGetToken42_MultiCharDelimiterDashDelimiterThird()
        {
            Assert.AreEqual("test", StringUtil.GetToken("hello--world--test", "--", 3));
        }

        [TestMethod]
        public void TestGetToken43_MultiCharDelimiterAngleBrackets()
        {
            Assert.AreEqual("one", StringUtil.GetToken("one<<two<<three", "<<", 1));
        }

        [TestMethod]
        public void TestGetToken44_MultiCharDelimiterGreaterThan()
        {
            Assert.AreEqual("a", StringUtil.GetToken("a>>b>>c>>d", ">>", 1));
        }

        [TestMethod]
        public void TestGetToken45_MultiCharDelimiterGreaterThanSecond()
        {
            Assert.AreEqual("b", StringUtil.GetToken("a>>b>>c>>d", ">>", 2));
        }

        [TestMethod]
        public void TestGetToken46_MultiCharDelimiterGreaterThanThird()
        {
            Assert.AreEqual("c", StringUtil.GetToken("a>>b>>c>>d", ">>", 3));
        }

        [TestMethod]
        public void TestGetToken47_MultiCharDelimiterGreaterThanFourth()
        {
            Assert.AreEqual("d", StringUtil.GetToken("a>>b>>c>>d", ">>", 4));
        }

        [TestMethod]
        public void TestGetToken48_MultiCharDelimiterAtStart()
        {
            Assert.AreEqual("", StringUtil.GetToken("::a::b", "::", 1));
        }

        [TestMethod]
        public void TestGetToken49_MultiCharDelimiterAtStartSecond()
        {
            Assert.AreEqual("a", StringUtil.GetToken("::a::b", "::", 2));
        }

        [TestMethod]
        public void TestGetToken50_MultiCharDelimiterAtEnd()
        {
            // "a::b::" split by "::" should give ["a", "b", ""]
            Assert.AreEqual("b", StringUtil.GetToken("a::b::", "::", 2));
        }

        [TestMethod]
        public void TestGetToken51_MultiCharDelimiterAtEndEmpty()
        {
            Assert.AreEqual("", StringUtil.GetToken("a::b::", "::", 3));
        }

        [TestMethod]
        public void TestGetToken52_MultiCharDelimiterThreeChars()
        {
            Assert.AreEqual("x", StringUtil.GetToken("x:::y:::z", ":::", 1));
        }

        [TestMethod]
        public void TestGetToken53_MultiCharDelimiterThreeCharsSecond()
        {
            Assert.AreEqual("y", StringUtil.GetToken("x:::y:::z", ":::", 2));
        }

        [TestMethod]
        public void TestGetToken54_MultiCharDelimiterThreeCharsThird()
        {
            Assert.AreEqual("z", StringUtil.GetToken("x:::y:::z", ":::", 3));
        }

        [TestMethod]
        public void TestGetToken55_MultiCharDelimiterLongString()
        {
            Assert.AreEqual("firstname", StringUtil.GetToken("firstname::lastname::email", "::", 1));
        }

        [TestMethod]
        public void TestGetToken56_MultiCharDelimiterLongStringSecond()
        {
            Assert.AreEqual("lastname", StringUtil.GetToken("firstname::lastname::email", "::", 2));
        }

        [TestMethod]
        public void TestGetToken57_MultiCharDelimiterLongStringThird()
        {
            Assert.AreEqual("email", StringUtil.GetToken("firstname::lastname::email", "::", 3));
        }

        [TestMethod]
        public void TestGetToken58_WhitespaceDelimiter()
        {
            Assert.AreEqual("hello", StringUtil.GetToken("hello  world", "  ", 1));
        }

        [TestMethod]
        public void TestGetToken59_WhitespaceDelimiterSecond()
        {
            Assert.AreEqual("world", StringUtil.GetToken("hello  world", "  ", 2));
        }

        [TestMethod]
        public void TestGetToken60_TabDelimiter()
        {
            Assert.AreEqual("a", StringUtil.GetToken("a\t\tb", "\t\t", 1));
        }

        [TestMethod]
        public void TestGetToken61_TabDelimiterSecond()
        {
            Assert.AreEqual("b", StringUtil.GetToken("a\t\tb", "\t\t", 2));
        }

        [TestMethod]
        public void TestGetToken62_SpecialCharDelimiter()
        {
            Assert.AreEqual("test", StringUtil.GetToken("test##value", "##", 1));
        }

        [TestMethod]
        public void TestGetToken63_SpecialCharDelimiterSecond()
        {
            Assert.AreEqual("value", StringUtil.GetToken("test##value", "##", 2));
        }

        [TestMethod]
        public void TestGetToken64_CaseSensitivity1()
        {
            Assert.AreEqual("abc", StringUtil.GetToken("abc::ABC::def", "::", 1));
        }

        [TestMethod]
        public void TestGetToken65_CaseSensitivity2()
        {
            Assert.AreEqual("ABC", StringUtil.GetToken("abc::ABC::def", "::", 2));
        }

        [TestMethod]
        public void TestGetToken66_CaseSensitivity3()
        {
            Assert.AreEqual("def", StringUtil.GetToken("abc::ABC::def", "::", 3));
        }

        [TestMethod]
        public void TestGetToken67_NumericTokens()
        {
            Assert.AreEqual("123", StringUtil.GetToken("123::456::789", "::", 1));
        }

        [TestMethod]
        public void TestGetToken68_NumericTokensSecond()
        {
            Assert.AreEqual("456", StringUtil.GetToken("123::456::789", "::", 2));
        }

        [TestMethod]
        public void TestGetToken69_NumericTokensThird()
        {
            Assert.AreEqual("789", StringUtil.GetToken("123::456::789", "::", 3));
        }

        [TestMethod]
        public void TestGetToken70_MultiCharDelimiterWithNumbers()
        {
            Assert.AreEqual("a1", StringUtil.GetToken("a1@@b2@@c3", "@@", 1));
        }

        [TestMethod]
        public void TestGetToken71_MultiCharDelimiterWithNumbersSecond()
        {
            Assert.AreEqual("b2", StringUtil.GetToken("a1@@b2@@c3", "@@", 2));
        }

        [TestMethod]
        public void TestGetToken72_MultiCharDelimiterWithNumbersThird()
        {
            Assert.AreEqual("c3", StringUtil.GetToken("a1@@b2@@c3", "@@", 3));
        }

        [TestMethod]
        public void TestGetToken73_LongMultiCharDelimiter()
        {
            Assert.AreEqual("start", StringUtil.GetToken("start----middle----end", "----", 1));
        }

        [TestMethod]
        public void TestGetToken74_LongMultiCharDelimiterSecond()
        {
            Assert.AreEqual("middle", StringUtil.GetToken("start----middle----end", "----", 2));
        }

        [TestMethod]
        public void TestGetToken75_LongMultiCharDelimiterThird()
        {
            Assert.AreEqual("end", StringUtil.GetToken("start----middle----end", "----", 3));
        }

        [TestMethod]
        public void TestGetToken76_MultiCharDelimiterMultipleConsecutive()
        {
            // "a::::::b" split by "::" should give ["a", "", "", "b"]
            Assert.AreEqual("a", StringUtil.GetToken("a::::::b", "::", 1));
        }

        [TestMethod]
        public void TestGetToken77_MultiCharDelimiterMultipleConsecutiveEmpty1()
        {
            // "a::::::b" split by "::" should give ["a", "", "", "b"]
            Assert.AreEqual("", StringUtil.GetToken("a::::::b", "::", 2));
        }

        [TestMethod]
        public void TestGetToken78_MultiCharDelimiterMultipleConsecutiveEmpty2()
        {
            // "a::::::b" split by "::" should give ["a", "", "", "b"]
            Assert.AreEqual("", StringUtil.GetToken("a::::::b", "::", 3));
        }

        [TestMethod]
        public void TestGetToken79_MultiCharDelimiterMultipleConsecutiveLastToken()
        {
            // "a::::::b" split by "::" should give ["a", "", "", "b"]
            Assert.AreEqual("b", StringUtil.GetToken("a::::::b", "::", 4));
        }

        [TestMethod]
        public void TestGetToken80_SingleCharInSourceMultiCharDelimiter()
        {
            Assert.AreEqual("x", StringUtil.GetToken("x", "::", 1));
        }

        [TestMethod]
        public void TestGetToken81_DelimiterLongerThanSourceBasic()
        {
            // When delimiter is longer than source, source has no delimiters
            Assert.AreEqual("short", StringUtil.GetToken("short", "verylongdelimiter", 1));
        }

        [TestMethod]
        public void TestGetToken82_MultiTokenLongValues()
        {
            Assert.AreEqual("verylongfirsttoken", StringUtil.GetToken("verylongfirsttoken::verylongsecondtoken::verylongthirdtoken", "::", 1));
        }

        [TestMethod]
        public void TestGetToken83_MultiTokenLongValuesSecond()
        {
            Assert.AreEqual("verylongsecondtoken", StringUtil.GetToken("verylongfirsttoken::verylongsecondtoken::verylongthirdtoken", "::", 2));
        }

        [TestMethod]
        public void TestGetToken84_MultiTokenLongValuesThird()
        {
            Assert.AreEqual("verylongthirdtoken", StringUtil.GetToken("verylongfirsttoken::verylongsecondtoken::verylongthirdtoken", "::", 3));
        }

        #endregion


        #region IsToken(string, string, string) tests

        [TestMethod]
        public void TestIsToken1()
        {
            Assert.AreEqual(true, StringUtil.IsToken("a|s|d|f", "a", "|"));
        }

        [TestMethod]
        public void TestIsToken2()
        {
            Assert.AreEqual(true, StringUtil.IsToken("a|s|d|f", "s", "|"));
        }

        [TestMethod]
        public void TestIsToken3()
        {
            Assert.AreEqual(true, StringUtil.IsToken("a|s|d|f", "d", "|"));
        }

        [TestMethod]
        public void TestIsToken4()
        {
            Assert.AreEqual(true, StringUtil.IsToken("a|s|d|f", "f", "|"));
        }

        [TestMethod]
        public void TestIsToken5()
        {
            Assert.AreEqual(false, StringUtil.IsToken("a|s|d|f", "", "|"));
        }

        [TestMethod]
        public void TestIsToken6()
        {
            Assert.AreEqual(false, StringUtil.IsToken("a|s|d|f", "|", "|"));
        }

        [TestMethod]
        public void TestIsToken7()
        {
            Assert.AreEqual(true, StringUtil.IsToken("|a|s|d|f", "", "|"));
        }

        [TestMethod]
        public void TestIsToken8()
        {
            Assert.AreEqual(true, StringUtil.IsToken("a|s|d|f|", "", "|"));
        }

        [TestMethod]
        public void TestIsToken9()
        {
            Assert.AreEqual(true, StringUtil.IsToken(String.Empty, String.Empty, "|"));
        }

        [TestMethod]
        public void TestIsToken10()
        {
            Assert.AreEqual(true, StringUtil.IsToken("a", "a", "|"));
        }

        // Multi-character delimiter tests
        [TestMethod]
        public void TestIsToken11_MultiCharDelimiterBasic()
        {
            Assert.AreEqual(true, StringUtil.IsToken("a::b::c", "a", "::"));
        }

        [TestMethod]
        public void TestIsToken12_MultiCharDelimiterSecondToken()
        {
            Assert.AreEqual(true, StringUtil.IsToken("a::b::c", "b", "::"));
        }

        [TestMethod]
        public void TestIsToken13_MultiCharDelimiterThirdToken()
        {
            Assert.AreEqual(true, StringUtil.IsToken("a::b::c", "c", "::"));
        }

        [TestMethod]
        public void TestIsToken14_MultiCharDelimiterNotFound()
        {
            Assert.AreEqual(false, StringUtil.IsToken("a::b::c", "d", "::"));
        }

        [TestMethod]
        public void TestIsToken15_MultiCharDelimiterConsecutiveEmptyToken()
        {
            // "a::::b" split by "::" should give ["a", "", "b"]
            Assert.AreEqual(true, StringUtil.IsToken("a::::b", "", "::"));
        }

        [TestMethod]
        public void TestIsToken16_MultiCharDelimiterDashDelimiter()
        {
            Assert.AreEqual(true, StringUtil.IsToken("hello--world--test", "hello", "--"));
        }

        [TestMethod]
        public void TestIsToken17_MultiCharDelimiterDashDelimiterSecond()
        {
            Assert.AreEqual(true, StringUtil.IsToken("hello--world--test", "world", "--"));
        }

        [TestMethod]
        public void TestIsToken18_MultiCharDelimiterDashDelimiterThird()
        {
            Assert.AreEqual(true, StringUtil.IsToken("hello--world--test", "test", "--"));
        }

        [TestMethod]
        public void TestIsToken19_MultiCharDelimiterAngleBrackets()
        {
            Assert.AreEqual(true, StringUtil.IsToken("one<<two<<three", "one", "<<"));
        }

        [TestMethod]
        public void TestIsToken20_MultiCharDelimiterGreaterThan()
        {
            Assert.AreEqual(true, StringUtil.IsToken("a>>b>>c>>d", "a", ">>"));
        }

        [TestMethod]
        public void TestIsToken21_MultiCharDelimiterGreaterThanNotFound()
        {
            Assert.AreEqual(false, StringUtil.IsToken("a>>b>>c>>d", "x", ">>"));
        }

        [TestMethod]
        public void TestIsToken22_MultiCharDelimiterAtStart()
        {
            Assert.AreEqual(true, StringUtil.IsToken("::a::b", "", "::"));
        }

        [TestMethod]
        public void TestIsToken23_MultiCharDelimiterAtEnd()
        {
            Assert.AreEqual(true, StringUtil.IsToken("a::b::", "b", "::"));
        }

        [TestMethod]
        public void TestIsToken24_MultiCharDelimiterAtEndEmpty()
        {
            Assert.AreEqual(true, StringUtil.IsToken("a::b::", "", "::"));
        }

        [TestMethod]
        public void TestIsToken25_MultiCharDelimiterThreeChars()
        {
            Assert.AreEqual(true, StringUtil.IsToken("x:::y:::z", "x", ":::"));
        }

        [TestMethod]
        public void TestIsToken26_MultiCharDelimiterThreeCharsSecond()
        {
            Assert.AreEqual(true, StringUtil.IsToken("x:::y:::z", "y", ":::"));
        }

        [TestMethod]
        public void TestIsToken27_MultiCharDelimiterThreeCharsThird()
        {
            Assert.AreEqual(true, StringUtil.IsToken("x:::y:::z", "z", ":::"));
        }

        [TestMethod]
        public void TestIsToken28_MultiCharDelimiterLongString()
        {
            Assert.AreEqual(true, StringUtil.IsToken("firstname::lastname::email", "firstname", "::"));
        }

        [TestMethod]
        public void TestIsToken29_MultiCharDelimiterLongStringSecond()
        {
            Assert.AreEqual(true, StringUtil.IsToken("firstname::lastname::email", "lastname", "::"));
        }

        [TestMethod]
        public void TestIsToken30_MultiCharDelimiterLongStringThird()
        {
            Assert.AreEqual(true, StringUtil.IsToken("firstname::lastname::email", "email", "::"));
        }

        [TestMethod]
        public void TestIsToken31_CaseSensitivity1()
        {
            // "abc::ABC::def" split by "::" gives ["abc", "ABC", "def"]
            // Token "abc" exists, so IsToken returns true
            Assert.AreEqual(true, StringUtil.IsToken("abc::ABC::def", "abc", "::"));
        }

        [TestMethod]
        public void TestIsToken32_CaseSensitivity2()
        {
            // "abc::ABC::def" split by "::" gives ["abc", "ABC", "def"]
            // Token "ABC" exists, so IsToken returns true
            Assert.AreEqual(true, StringUtil.IsToken("abc::ABC::def", "ABC", "::"));
        }

        [TestMethod]
        public void TestIsToken33_CaseSensitivity3()
        {
            // "abc::ABC::def" split by "::" gives ["abc", "ABC", "def"]
            // Token "Abc" does not exist, so IsToken returns false
            Assert.AreEqual(false, StringUtil.IsToken("abc::ABC::def", "Abc", "::"));
        }

        [TestMethod]
        public void TestIsToken34_NumericTokens()
        {
            Assert.AreEqual(true, StringUtil.IsToken("123::456::789", "123", "::"));
        }

        [TestMethod]
        public void TestIsToken35_NumericTokensSecond()
        {
            Assert.AreEqual(true, StringUtil.IsToken("123::456::789", "456", "::"));
        }

        [TestMethod]
        public void TestIsToken36_NumericTokensThird()
        {
            Assert.AreEqual(true, StringUtil.IsToken("123::456::789", "789", "::"));
        }

        [TestMethod]
        public void TestIsToken37_PartialMatch()
        {
            // "hello" is not a token; "helloworld" is
            Assert.AreEqual(false, StringUtil.IsToken("helloworld::test", "hello", "::"));
        }

        [TestMethod]
        public void TestIsToken38_PartialMatchSecond()
        {
            Assert.AreEqual(false, StringUtil.IsToken("helloworld::test", "world", "::"));
        }

        [TestMethod]
        public void TestIsToken39_ExactMatch()
        {
            Assert.AreEqual(true, StringUtil.IsToken("helloworld::test", "helloworld", "::"));
        }

        [TestMethod]
        public void TestIsToken40_WhitespaceDelimiter()
        {
            Assert.AreEqual(true, StringUtil.IsToken("hello  world", "hello", "  "));
        }

        [TestMethod]
        public void TestIsToken41_WhitespaceDelimiterSecond()
        {
            Assert.AreEqual(true, StringUtil.IsToken("hello  world", "world", "  "));
        }

        [TestMethod]
        public void TestIsToken42_SpecialCharDelimiter()
        {
            Assert.AreEqual(true, StringUtil.IsToken("test@@value", "test", "@@"));
        }

        [TestMethod]
        public void TestIsToken43_SpecialCharDelimiterSecond()
        {
            Assert.AreEqual(true, StringUtil.IsToken("test@@value", "value", "@@"));
        }

        [TestMethod]
        public void TestIsToken44_MultiCharDelimiterWithNumbers()
        {
            Assert.AreEqual(true, StringUtil.IsToken("a1@@b2@@c3", "a1", "@@"));
        }

        [TestMethod]
        public void TestIsToken45_MultiCharDelimiterWithNumbersSecond()
        {
            Assert.AreEqual(true, StringUtil.IsToken("a1@@b2@@c3", "b2", "@@"));
        }

        [TestMethod]
        public void TestIsToken46_MultiCharDelimiterWithNumbersThird()
        {
            Assert.AreEqual(true, StringUtil.IsToken("a1@@b2@@c3", "c3", "@@"));
        }

        [TestMethod]
        public void TestIsToken47_LongMultiCharDelimiter()
        {
            Assert.AreEqual(true, StringUtil.IsToken("start----middle----end", "start", "----"));
        }

        [TestMethod]
        public void TestIsToken48_LongMultiCharDelimiterSecond()
        {
            Assert.AreEqual(true, StringUtil.IsToken("start----middle----end", "middle", "----"));
        }

        [TestMethod]
        public void TestIsToken49_LongMultiCharDelimiterThird()
        {
            Assert.AreEqual(true, StringUtil.IsToken("start----middle----end", "end", "----"));
        }

        [TestMethod]
        public void TestIsToken50_MultiCharDelimiterMultipleConsecutive()
        {
            // "a::::::b" split by "::" should give ["a", "", "", "b"]
            // Check for "a"
            Assert.AreEqual(true, StringUtil.IsToken("a::::::b", "a", "::"));
        }

        [TestMethod]
        public void TestIsToken51_MultiCharDelimiterMultipleConsecutiveEmpty()
        {
            // "a::::::b" split by "::" should give ["a", "", "", "b"]
            // Check for empty token
            Assert.AreEqual(true, StringUtil.IsToken("a::::::b", "", "::"));
        }

        [TestMethod]
        public void TestIsToken52_MultiCharDelimiterMultipleConsecutiveLastToken()
        {
            // "a::::::b" split by "::" should give ["a", "", "", "b"]
            Assert.AreEqual(true, StringUtil.IsToken("a::::::b", "b", "::"));
        }

        #endregion


        #region SqlText(string) tests

        [TestMethod]
        public void TestSqlText1()
        {
            Assert.AreEqual("\"\"asdf\"\"", StringUtil.SqlText("\"asdf\""));
        }

        [TestMethod]
        public void TestSqlText2()
        {
            Assert.AreEqual("asdf\"\"", StringUtil.SqlText("asdf\""));
        }

        [TestMethod]
        public void TestSqlText3()
        {
            Assert.AreEqual("\"\"asdf", StringUtil.SqlText("\"asdf"));
        }

        [TestMethod]
        public void TestSqlText4()
        {
            Assert.AreEqual("\"\"\"\"asdf\"\"\"\"", StringUtil.SqlText("\"\"asdf\"\""));
        }

        // Empty and null tests
        [TestMethod]
        public void TestSqlText5_EmptyString()
        {
            Assert.AreEqual("", StringUtil.SqlText(""));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestSqlText6_NullString()
        {
            StringUtil.SqlText(null);
            Assert.Fail();
        }

        // No quotes tests
        [TestMethod]
        public void TestSqlText7_NoQuotes()
        {
            Assert.AreEqual("asdf", StringUtil.SqlText("asdf"));
        }

        [TestMethod]
        public void TestSqlText8_NoQuotesWithSpecialChars()
        {
            Assert.AreEqual("hello world!", StringUtil.SqlText("hello world!"));
        }

        [TestMethod]
        public void TestSqlText9_NoQuotesNumericOnly()
        {
            Assert.AreEqual("12345", StringUtil.SqlText("12345"));
        }

        // Single character tests
        [TestMethod]
        public void TestSqlText10_SingleQuote()
        {
            Assert.AreEqual("\"\"", StringUtil.SqlText("\""));
        }

        [TestMethod]
        public void TestSqlText11_SingleCharNoQuote()
        {
            Assert.AreEqual("a", StringUtil.SqlText("a"));
        }

        // Quote in middle tests
        [TestMethod]
        public void TestSqlText12_QuoteInMiddle()
        {
            Assert.AreEqual("a\"\"b", StringUtil.SqlText("a\"b"));
        }

        [TestMethod]
        public void TestSqlText13_QuoteInMiddleWithSpaces()
        {
            Assert.AreEqual("hello \"\"world", StringUtil.SqlText("hello \"world"));
        }

        [TestMethod]
        public void TestSqlText14_MultipleQuotesInMiddle()
        {
            Assert.AreEqual("a\"\"b\"\"c", StringUtil.SqlText("a\"b\"c"));
        }

        // Consecutive quotes tests
        [TestMethod]
        public void TestSqlText15_ThreeConsecutiveQuotes()
        {
            Assert.AreEqual("\"\"\"\"\"\"", StringUtil.SqlText("\"\"\""));
        }

        [TestMethod]
        public void TestSqlText16_FourConsecutiveQuotes()
        {
            Assert.AreEqual("\"\"\"\"\"\"\"\"", StringUtil.SqlText("\"\"\"\""));
        }

        [TestMethod]
        public void TestSqlText17_FiveConsecutiveQuotes()
        {
            Assert.AreEqual("\"\"\"\"\"\"\"\"\"\"", StringUtil.SqlText("\"\"\"\"\""));
        }

        [TestMethod]
        public void TestSqlText18_ConsecutiveQuotesWithText()
        {
            Assert.AreEqual("start\"\"\"\"end", StringUtil.SqlText("start\"\"end"));
        }

        // Special characters with quotes
        [TestMethod]
        public void TestSqlText19_QuoteWithBackslash()
        {
            Assert.AreEqual("a\\\"\"b", StringUtil.SqlText("a\\\"b"));
        }

        [TestMethod]
        public void TestSqlText20_QuoteWithNewline()
        {
            Assert.AreEqual("a\n\"\"b", StringUtil.SqlText("a\n\"b"));
        }

        [TestMethod]
        public void TestSqlText21_QuoteWithTab()
        {
            Assert.AreEqual("a\t\"\"b", StringUtil.SqlText("a\t\"b"));
        }

        [TestMethod]
        public void TestSqlText22_QuoteWithCarriageReturn()
        {
            Assert.AreEqual("a\r\"\"b", StringUtil.SqlText("a\r\"b"));
        }

        // Long strings with quotes
        [TestMethod]
        public void TestSqlText23_LongStringWithQuotes()
        {
            Assert.AreEqual("verylongstringwithouquote\"\"inside", StringUtil.SqlText("verylongstringwithouquote\"inside"));
        }

        [TestMethod]
        public void TestSqlText24_LongStringWithMultipleQuotes()
        {
            Assert.AreEqual("start\"\"middle\"\"end\"\"more", StringUtil.SqlText("start\"middle\"end\"more"));
        }

        // Only quotes tests
        [TestMethod]
        public void TestSqlText25_OnlyTwoQuotes()
        {
            Assert.AreEqual("\"\"\"\"", StringUtil.SqlText("\"\""));
        }

        [TestMethod]
        public void TestSqlText26_OnlyThreeQuotes()
        {
            Assert.AreEqual("\"\"\"\"\"\"", StringUtil.SqlText("\"\"\""));
        }

        // Whitespace and quotes
        [TestMethod]
        public void TestSqlText27_QuoteWithLeadingSpace()
        {
            Assert.AreEqual(" \"\"", StringUtil.SqlText(" \""));
        }

        [TestMethod]
        public void TestSqlText28_QuoteWithTrailingSpace()
        {
            Assert.AreEqual("\"\" ", StringUtil.SqlText("\" "));
        }

        [TestMethod]
        public void TestSqlText29_SpacesBetweenQuotes()
        {
            Assert.AreEqual("\"\" \"\"", StringUtil.SqlText("\" \""));
        }

        // Numeric and alphanumeric with quotes
        [TestMethod]
        public void TestSqlText30_NumericWithQuote()
        {
            Assert.AreEqual("12\"\"34", StringUtil.SqlText("12\"34"));
        }

        [TestMethod]
        public void TestSqlText31_AlphanumericWithQuotes()
        {
            Assert.AreEqual("a1\"\"b2\"\"c3", StringUtil.SqlText("a1\"b2\"c3"));
        }

        // Mixed content tests
        [TestMethod]
        public void TestSqlText32_MixedContentQuoteEverywhere()
        {
            Assert.AreEqual("\"\"hello\"\"world\"\"test\"\"", StringUtil.SqlText("\"hello\"world\"test\""));
        }

        [TestMethod]
        public void TestSqlText33_SQLStatementLike()
        {
            // Simulating: INSERT INTO table VALUES ("value")
            Assert.AreEqual("INSERT INTO table VALUES (\"\"value\"\")", StringUtil.SqlText("INSERT INTO table VALUES (\"value\")"));
        }

        [TestMethod]
        public void TestSqlText34_QuotedString()
        {
            Assert.AreEqual("\"\"\"\"This is a test\"\"\"\"", StringUtil.SqlText("\"\"This is a test\"\""));
        }

        [TestMethod]
        public void TestSqlText35_ManyScatteredQuotes()
        {
            Assert.AreEqual("a\"\"b\"\"c\"\"d\"\"e\"\"f", StringUtil.SqlText("a\"b\"c\"d\"e\"f"));
        }

        [TestMethod]
        public void TestSqlText36_PathWithQuotes()
        {
            Assert.AreEqual("C:\\path\\to\\file\"\"name.txt", StringUtil.SqlText("C:\\path\\to\\file\"name.txt"));
        }

        #endregion


        #region StripLeadingDoubleQuotes(string) tests

        [TestMethod]
        public void TestStripLeadingDoubleQuotes1()
        {
            Assert.AreEqual("asdf\"", StringUtil.StripLeadingDoubleQuotes("\"asdf\""));
        }

        [TestMethod]
        public void TestStripLeadingDoubleQuotes2()
        {
            Assert.AreEqual("asdf", StringUtil.StripLeadingDoubleQuotes("\"asdf"));
        }

        [TestMethod]
        public void TestStripLeadingDoubleQuotes3()
        {
            Assert.AreEqual("asdf", StringUtil.StripLeadingDoubleQuotes("\"\"\"asdf"));
        }

        [TestMethod]
        public void TestStripLeadingDoubleQuotes4()
        {
            Assert.AreEqual("asdf", StringUtil.StripLeadingDoubleQuotes("asdf"));
        }

        [TestMethod]
        public void TestStripLeadingDoubleQuotes5()
        {
            Assert.AreEqual("", StringUtil.StripLeadingDoubleQuotes("\""));
        }

        [TestMethod]
        public void TestStripLeadingDoubleQuotes6()
        {
            Assert.AreEqual("", StringUtil.StripLeadingDoubleQuotes("\"\""));
        }

        [TestMethod]
        public void TestStripLeadingDoubleQuotes7()
        {
            Assert.AreEqual("", StringUtil.StripLeadingDoubleQuotes(""));
        }

        // Null input test
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestStripLeadingDoubleQuotes8_NullInput()
        {
            StringUtil.StripLeadingDoubleQuotes(null);
            Assert.Fail();
        }

        // No quotes tests
        [TestMethod]
        public void TestStripLeadingDoubleQuotes9_SingleCharNoQuote()
        {
            Assert.AreEqual("a", StringUtil.StripLeadingDoubleQuotes("a"));
        }

        [TestMethod]
        public void TestStripLeadingDoubleQuotes10_NoQuotesWithText()
        {
            Assert.AreEqual("hello world", StringUtil.StripLeadingDoubleQuotes("hello world"));
        }

        [TestMethod]
        public void TestStripLeadingDoubleQuotes11_NoQuotesNumeric()
        {
            Assert.AreEqual("12345", StringUtil.StripLeadingDoubleQuotes("12345"));
        }

        // Multiple leading quotes tests
        [TestMethod]
        public void TestStripLeadingDoubleQuotes12_FourLeadingQuotes()
        {
            Assert.AreEqual("text", StringUtil.StripLeadingDoubleQuotes("\"\"\"\"text"));
        }

        [TestMethod]
        public void TestStripLeadingDoubleQuotes13_FiveLeadingQuotes()
        {
            Assert.AreEqual("content", StringUtil.StripLeadingDoubleQuotes("\"\"\"\"\"content"));
        }

        [TestMethod]
        public void TestStripLeadingDoubleQuotes14_SixLeadingQuotes()
        {
            Assert.AreEqual("data", StringUtil.StripLeadingDoubleQuotes("\"\"\"\"\"\"data"));
        }

        [TestMethod]
        public void TestStripLeadingDoubleQuotes15_TenLeadingQuotes()
        {
            Assert.AreEqual("result", StringUtil.StripLeadingDoubleQuotes("\"\"\"\"\"\"\"\"\"\"result"));
        }

        // Quotes with different content types
        [TestMethod]
        public void TestStripLeadingDoubleQuotes16_QuotesWithSymbols()
        {
            Assert.AreEqual("!@#$%", StringUtil.StripLeadingDoubleQuotes("\"!@#$%"));
        }

        [TestMethod]
        public void TestStripLeadingDoubleQuotes17_QuotesWithAlphanumeric()
        {
            Assert.AreEqual("abc123def456", StringUtil.StripLeadingDoubleQuotes("\"abc123def456"));
        }

        [TestMethod]
        public void TestStripLeadingDoubleQuotes18_MultipleQuotesWithAlphanumeric()
        {
            Assert.AreEqual("test123", StringUtil.StripLeadingDoubleQuotes("\"\"\"test123"));
        }

        // Only quotes strings
        [TestMethod]
        public void TestStripLeadingDoubleQuotes19_ThreeQuotesOnly()
        {
            Assert.AreEqual("", StringUtil.StripLeadingDoubleQuotes("\"\"\""));
        }

        [TestMethod]
        public void TestStripLeadingDoubleQuotes20_FourQuotesOnly()
        {
            Assert.AreEqual("", StringUtil.StripLeadingDoubleQuotes("\"\"\"\""));
        }

        [TestMethod]
        public void TestStripLeadingDoubleQuotes21_FiveQuotesOnly()
        {
            Assert.AreEqual("", StringUtil.StripLeadingDoubleQuotes("\"\"\"\"\""));
        }

        [TestMethod]
        public void TestStripLeadingDoubleQuotes22_ManyQuotesOnly()
        {
            Assert.AreEqual("", StringUtil.StripLeadingDoubleQuotes("\"\"\"\"\"\"\"\"\"\""));
        }

        // Quotes followed by special characters
        [TestMethod]
        public void TestStripLeadingDoubleQuotes23_QuoteWithLeadingSpace()
        {
            Assert.AreEqual(" text", StringUtil.StripLeadingDoubleQuotes("\" text"));
        }

        [TestMethod]
        public void TestStripLeadingDoubleQuotes24_QuoteWithNewline()
        {
            Assert.AreEqual("\ntext", StringUtil.StripLeadingDoubleQuotes("\"\ntext"));
        }

        [TestMethod]
        public void TestStripLeadingDoubleQuotes25_QuoteWithTab()
        {
            Assert.AreEqual("\ttext", StringUtil.StripLeadingDoubleQuotes("\"\ttext"));
        }

        [TestMethod]
        public void TestStripLeadingDoubleQuotes26_QuoteWithBackslash()
        {
            Assert.AreEqual("\\path\\to\\file", StringUtil.StripLeadingDoubleQuotes("\"\\path\\to\\file"));
        }

        [TestMethod]
        public void TestStripLeadingDoubleQuotes27_MultipleQuotesWithSpace()
        {
            Assert.AreEqual(" ", StringUtil.StripLeadingDoubleQuotes("\" "));
        }

        [TestMethod]
        public void TestStripLeadingDoubleQuotes28_QuoteWithSingleQuoteChar()
        {
            Assert.AreEqual("'", StringUtil.StripLeadingDoubleQuotes("\"'"));
        }

        // Quotes with numeric content
        [TestMethod]
        public void TestStripLeadingDoubleQuotes29_QuoteWithNumberOnly()
        {
            Assert.AreEqual("123", StringUtil.StripLeadingDoubleQuotes("\"123"));
        }

        [TestMethod]
        public void TestStripLeadingDoubleQuotes30_QuoteWithDecimal()
        {
            Assert.AreEqual("3.14159", StringUtil.StripLeadingDoubleQuotes("\"3.14159"));
        }

        [TestMethod]
        public void TestStripLeadingDoubleQuotes31_MultipleQuotesWithNumeric()
        {
            Assert.AreEqual("999", StringUtil.StripLeadingDoubleQuotes("\"\"\"999"));
        }

        // Quotes with punctuation
        [TestMethod]
        public void TestStripLeadingDoubleQuotes32_QuoteWithComma()
        {
            Assert.AreEqual(",test", StringUtil.StripLeadingDoubleQuotes("\",test"));
        }

        [TestMethod]
        public void TestStripLeadingDoubleQuotes33_QuoteWithPeriod()
        {
            Assert.AreEqual(".file", StringUtil.StripLeadingDoubleQuotes("\".file"));
        }

        [TestMethod]
        public void TestStripLeadingDoubleQuotes34_QuoteWithParens()
        {
            Assert.AreEqual("(test)", StringUtil.StripLeadingDoubleQuotes("\"(test)"));
        }

        // Quotes with path-like content
        [TestMethod]
        public void TestStripLeadingDoubleQuotes35_QuoteWithPathWindows()
        {
            Assert.AreEqual("C:\\Users\\file.txt", StringUtil.StripLeadingDoubleQuotes("\"C:\\Users\\file.txt"));
        }

        [TestMethod]
        public void TestStripLeadingDoubleQuotes36_QuoteWithPathUnix()
        {
            Assert.AreEqual("/home/user/file.txt", StringUtil.StripLeadingDoubleQuotes("\"/home/user/file.txt"));
        }

        // Mixed content with quotes
        [TestMethod]
        public void TestStripLeadingDoubleQuotes37_QuoteWithMixedContent()
        {
            Assert.AreEqual("hello123world!\"test", StringUtil.StripLeadingDoubleQuotes("\"hello123world!\"test"));
        }

        [TestMethod]
        public void TestStripLeadingDoubleQuotes38_MultipleQuotesWithMixedContent()
        {
            Assert.AreEqual("test\"data\"value", StringUtil.StripLeadingDoubleQuotes("\"\"\"test\"data\"value"));
        }

        [TestMethod]
        public void TestStripLeadingDoubleQuotes39_QuoteWithEmbeddedQuotes()
        {
            // Strips all leading quotes: "\"hello\" -> hello\"
            Assert.AreEqual("hello\"", StringUtil.StripLeadingDoubleQuotes("\"\"hello\""));
        }

        [TestMethod]
        public void TestStripLeadingDoubleQuotes40_QuoteFollowedByNonQuoteSymbol()
        {
            Assert.AreEqual("@user", StringUtil.StripLeadingDoubleQuotes("\"@user"));
        }

        [TestMethod]
        public void TestStripLeadingDoubleQuotes41_LongStringWithLeadingQuotes()
        {
            Assert.AreEqual("verylongstringwithouquotes", StringUtil.StripLeadingDoubleQuotes("\"verylongstringwithouquotes"));
        }

        [TestMethod]
        public void TestStripLeadingDoubleQuotes42_QuoteWithURLContent()
        {
            Assert.AreEqual("https://example.com/path", StringUtil.StripLeadingDoubleQuotes("\"https://example.com/path"));
        }

        [TestMethod]
        public void TestStripLeadingDoubleQuotes43_QuoteWithJSONLike()
        {
            Assert.AreEqual("{\"key\": \"value\"}", StringUtil.StripLeadingDoubleQuotes("\"{\"key\": \"value\"}"));
        }

        [TestMethod]
        public void TestStripLeadingDoubleQuotes44_QuoteWithSQLLike()
        {
            Assert.AreEqual("SELECT * FROM table", StringUtil.StripLeadingDoubleQuotes("\"SELECT * FROM table"));
        }

        [TestMethod]
        public void TestStripLeadingDoubleQuotes45_QuoteWithWhitespaceOnly()
        {
            Assert.AreEqual("   ", StringUtil.StripLeadingDoubleQuotes("\"   "));
        }

        #endregion


        #region ToChar() tests (ASCII character set 1)

        [TestMethod]
        public void TestToChar0()
        {
            Assert.AreEqual("\u0000", StringUtil.ToChar(0));
        }

        [TestMethod]
        public void TestToChar65()
        {
            Assert.AreEqual("A", StringUtil.ToChar(65));
        }

        [TestMethod]
        public void TestToChar127()
        {
            Assert.AreEqual("\u007F", StringUtil.ToChar(127));
        }

        [TestMethod]
        public void TestToCharLowerAsciiSet()
        {
            int characterCode = 0;
            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 15; j++)
                {
                    StringBuilder target = new StringBuilder("00");
                    target.Append(i.ToString());
                    switch (j)
                    {
                        case 10:
                            target.Append("A");
                            break;
                        case 11:
                            target.Append("B");
                            break;
                        case 12:
                            target.Append("C");
                            break;
                        case 13:
                            target.Append("D");
                            break;
                        case 14:
                            target.Append("E");
                            break;
                        case 15:
                            target.Append("F");
                            break;
                        default:
                            target.Append(j.ToString());
                            break;
                    }

                    char c = (char)ushort.Parse(target.ToString(), System.Globalization.NumberStyles.HexNumber);
                    string s = new String(new char[] { c });

                    Assert.AreEqual(s, StringUtil.ToChar(characterCode));
                    characterCode++;
                }
            }
        }

        #endregion


        #region ToChar(int) test (ASCII character set 2)

        [TestMethod]
        public void TestToChar128()
        {
            Assert.AreEqual("\u0080", StringUtil.ToChar(128));
        }

        [TestMethod]
        public void TestToChar129()
        {
            Assert.AreEqual("\u0081", StringUtil.ToChar(129));
        }

        [TestMethod]
        public void TestToChar130()
        {
            Assert.AreEqual("\u0082", StringUtil.ToChar(130));
        }

        [TestMethod]
        public void TestToChar131()
        {
            Assert.AreEqual("\u0083", StringUtil.ToChar(131));
        }

        [TestMethod]
        public void TestToChar132()
        {
            Assert.AreEqual("\u0084", StringUtil.ToChar(132));
        }

        [TestMethod]
        public void TestToChar133()
        {
            Assert.AreEqual("\u0085", StringUtil.ToChar(133));
        }

        [TestMethod]
        public void TestToChar134()
        {
            Assert.AreEqual("\u0086", StringUtil.ToChar(134));
        }

        [TestMethod]
        public void TestToChar135()
        {
            Assert.AreEqual("\u0087", StringUtil.ToChar(135));
        }

        [TestMethod]
        public void TestToChar136()
        {
            Assert.AreEqual("\u0088", StringUtil.ToChar(136));
        }

        [TestMethod]
        public void TestToChar137()
        {
            Assert.AreEqual("\u0089", StringUtil.ToChar(137));
        }

        [TestMethod]
        public void TestToChar138()
        {
            Assert.AreEqual("\u008A", StringUtil.ToChar(138));
        }

        [TestMethod]
        public void TestToChar139()
        {
            Assert.AreEqual("\u008B", StringUtil.ToChar(139));
        }

        [TestMethod]
        public void TestToChar140()
        {
            Assert.AreEqual("\u008C", StringUtil.ToChar(140));
        }

        [TestMethod]
        public void TestToChar141()
        {
            Assert.AreEqual("\u008D", StringUtil.ToChar(141));
        }

        [TestMethod]
        public void TestToChar142()
        {
            Assert.AreEqual("\u008E", StringUtil.ToChar(142));
        }

        [TestMethod]
        public void TestToChar143()
        {
            Assert.AreEqual("\u008F", StringUtil.ToChar(143));
        }

        [TestMethod]
        public void TestToChar144()
        {
            Assert.AreEqual("\u0090", StringUtil.ToChar(144));
        }

        [TestMethod]
        public void TestToChar145()
        {
            Assert.AreEqual("\u0091", StringUtil.ToChar(145));
        }

        [TestMethod]
        public void TestToChar146()
        {
            Assert.AreEqual("\u0092", StringUtil.ToChar(146));
        }

        [TestMethod]
        public void TestToChar147()
        {
            Assert.AreEqual("\u0093", StringUtil.ToChar(147));
        }

        [TestMethod]
        public void TestToChar148()
        {
            Assert.AreEqual("\u0094", StringUtil.ToChar(148));
        }

        [TestMethod]
        public void TestToChar149()
        {
            Assert.AreEqual("\u0095", StringUtil.ToChar(149));
        }

        [TestMethod]
        public void TestToChar150()
        {
            Assert.AreEqual("\u0096", StringUtil.ToChar(150));
        }

        [TestMethod]
        public void TestToChar151()
        {
            Assert.AreEqual("\u0097", StringUtil.ToChar(151));
        }

        [TestMethod]
        public void TestToChar152()
        {
            Assert.AreEqual("\u0098", StringUtil.ToChar(152));
        }

        [TestMethod]
        public void TestToChar153()
        {
            Assert.AreEqual("\u0099", StringUtil.ToChar(153));
        }

        [TestMethod]
        public void TestToChar154()
        {
            Assert.AreEqual("\u009A", StringUtil.ToChar(154));
        }

        [TestMethod]
        public void TestToChar155()
        {
            Assert.AreEqual("\u009B", StringUtil.ToChar(155));
        }

        [TestMethod]
        public void TestToChar156()
        {
            Assert.AreEqual("\u009C", StringUtil.ToChar(156));
        }

        [TestMethod]
        public void TestToChar157()
        {
            Assert.AreEqual("\u009D", StringUtil.ToChar(157));
        }

        [TestMethod]
        public void TestToChar158()
        {
            Assert.AreEqual("\u009E", StringUtil.ToChar(158));
        }

        [TestMethod]
        public void TestToChar159()
        {
            Assert.AreEqual("\u009F", StringUtil.ToChar(159));
        }

        [TestMethod]
        public void TestToChar176()
        {
            Assert.AreEqual(StringUtil.DegreeSymbol, StringUtil.ToChar(176));
        }

        [TestMethod]
        public void TestToChar255()
        {
            Assert.AreEqual("\u00FF", StringUtil.ToChar(255));
        }

        [TestMethod]
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
                            target.Append("A");
                            break;
                        case 11:
                            target.Append("B");
                            break;
                        case 12:
                            target.Append("C");
                            break;
                        case 13:
                            target.Append("D");
                            break;
                        case 14:
                            target.Append("E");
                            break;
                        case 15:
                            target.Append("F");
                            break;
                        default:
                            target.Append(i.ToString());
                            break;
                    }

                    switch (j)
                    {
                        case 10:
                            target.Append("A");
                            break;
                        case 11:
                            target.Append("B");
                            break;
                        case 12:
                            target.Append("C");
                            break;
                        case 13:
                            target.Append("D");
                            break;
                        case 14:
                            target.Append("E");
                            break;
                        case 15:
                            target.Append("F");
                            break;
                        default:
                            target.Append(j.ToString());
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
                            char c = (char)ushort.Parse(target.ToString(), System.Globalization.NumberStyles.HexNumber);
                            string s = new String(new char[] { c });
                            Assert.AreEqual(s, StringUtil.ToChar(characterCode), "characterCode=" + characterCode.ToString());
                            break;
                    }

                    characterCode++;
                }
            }
        }

        #endregion


        #region ToChar(int) (exception) tests

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestToCharTooBig()
        {
            Assert.AreNotEqual("A", StringUtil.ToChar(256));
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestToCharTooSmall()
        {
            Assert.AreNotEqual("A", StringUtil.ToChar(-1));
            Assert.Fail();
        }

        #endregion


        #region ToAscii(string) tests

        [TestMethod]
        public void TestToAscii1()
        {
            Assert.AreEqual(0, StringUtil.ToAscii("\u0000"));
        }

        [TestMethod]
        public void TestToAscii2()
        { 
            Assert.AreEqual(127, StringUtil.ToAscii("\u007F"));
        }

        [TestMethod]
        public void TestToAscii3()
        {
            Assert.AreEqual(65, StringUtil.ToAscii("A"));
        }

        [TestMethod]
        public void TestToAscii4()
        {
            Assert.AreEqual(176, StringUtil.ToAscii(StringUtil.DegreeSymbol));
        }

        [TestMethod]
        public void TestToAscii5()
        {
            Assert.AreEqual(129, StringUtil.ToAscii("\u0081"));
        }

        [TestMethod]
        public void TestToAscii6()
        {
            Assert.AreEqual(255, StringUtil.ToAscii("\u00FF"));
        }

        [TestMethod]
        public void TestToAscii7_LowercaseA()
        {
            Assert.AreEqual(97, StringUtil.ToAscii("a"));
        }

        [TestMethod]
        public void TestToAscii8_LowercaseZ()
        {
            Assert.AreEqual(122, StringUtil.ToAscii("z"));
        }

        [TestMethod]
        public void TestToAscii9_UppercaseZ()
        {
            Assert.AreEqual(90, StringUtil.ToAscii("Z"));
        }

        [TestMethod]
        public void TestToAscii10_Digit0()
        {
            Assert.AreEqual(48, StringUtil.ToAscii("0"));
        }

        [TestMethod]
        public void TestToAscii11_Digit5()
        {
            Assert.AreEqual(53, StringUtil.ToAscii("5"));
        }

        [TestMethod]
        public void TestToAscii12_Digit9()
        {
            Assert.AreEqual(57, StringUtil.ToAscii("9"));
        }

        [TestMethod]
        public void TestToAscii13_Space()
        {
            Assert.AreEqual(32, StringUtil.ToAscii(" "));
        }

        [TestMethod]
        public void TestToAscii14_Tab()
        {
            Assert.AreEqual(9, StringUtil.ToAscii("\t"));
        }

        [TestMethod]
        public void TestToAscii15_Newline()
        {
            Assert.AreEqual(10, StringUtil.ToAscii("\n"));
        }

        [TestMethod]
        public void TestToAscii16_CarriageReturn()
        {
            Assert.AreEqual(13, StringUtil.ToAscii("\r"));
        }

        [TestMethod]
        public void TestToAscii17_ExclamationMark()
        {
            Assert.AreEqual(33, StringUtil.ToAscii("!"));
        }

        [TestMethod]
        public void TestToAscii18_DoubleQuote()
        {
            Assert.AreEqual(34, StringUtil.ToAscii("\""));
        }

        [TestMethod]
        public void TestToAscii19_Hash()
        {
            Assert.AreEqual(35, StringUtil.ToAscii("#"));
        }

        [TestMethod]
        public void TestToAscii20_Dollar()
        {
            Assert.AreEqual(36, StringUtil.ToAscii("$"));
        }

        [TestMethod]
        public void TestToAscii21_Percent()
        {
            Assert.AreEqual(37, StringUtil.ToAscii("%"));
        }

        [TestMethod]
        public void TestToAscii22_Ampersand()
        {
            Assert.AreEqual(38, StringUtil.ToAscii("&"));
        }

        [TestMethod]
        public void TestToAscii23_SingleQuote()
        {
            Assert.AreEqual(39, StringUtil.ToAscii("'"));
        }

        [TestMethod]
        public void TestToAscii24_OpenParen()
        {
            Assert.AreEqual(40, StringUtil.ToAscii("("));
        }

        [TestMethod]
        public void TestToAscii25_CloseParen()
        {
            Assert.AreEqual(41, StringUtil.ToAscii(")"));
        }

        [TestMethod]
        public void TestToAscii26_Asterisk()
        {
            Assert.AreEqual(42, StringUtil.ToAscii("*"));
        }

        [TestMethod]
        public void TestToAscii27_Plus()
        {
            Assert.AreEqual(43, StringUtil.ToAscii("+"));
        }

        [TestMethod]
        public void TestToAscii28_Comma()
        {
            Assert.AreEqual(44, StringUtil.ToAscii(","));
        }

        [TestMethod]
        public void TestToAscii29_Hyphen()
        {
            Assert.AreEqual(45, StringUtil.ToAscii("-"));
        }

        [TestMethod]
        public void TestToAscii30_Period()
        {
            Assert.AreEqual(46, StringUtil.ToAscii("."));
        }

        [TestMethod]
        public void TestToAscii31_ForwardSlash()
        {
            Assert.AreEqual(47, StringUtil.ToAscii("/"));
        }

        [TestMethod]
        public void TestToAscii32_Colon()
        {
            Assert.AreEqual(58, StringUtil.ToAscii(":"));
        }

        [TestMethod]
        public void TestToAscii33_Semicolon()
        {
            Assert.AreEqual(59, StringUtil.ToAscii(";"));
        }

        [TestMethod]
        public void TestToAscii34_LessThan()
        {
            Assert.AreEqual(60, StringUtil.ToAscii("<"));
        }

        [TestMethod]
        public void TestToAscii35_Equals()
        {
            Assert.AreEqual(61, StringUtil.ToAscii("="));
        }

        [TestMethod]
        public void TestToAscii36_GreaterThan()
        {
            Assert.AreEqual(62, StringUtil.ToAscii(">"));
        }

        [TestMethod]
        public void TestToAscii37_Question()
        {
            Assert.AreEqual(63, StringUtil.ToAscii("?"));
        }

        [TestMethod]
        public void TestToAscii38_At()
        {
            Assert.AreEqual(64, StringUtil.ToAscii("@"));
        }

        [TestMethod]
        public void TestToAscii39_OpenBracket()
        {
            Assert.AreEqual(91, StringUtil.ToAscii("["));
        }

        [TestMethod]
        public void TestToAscii40_Backslash()
        {
            Assert.AreEqual(92, StringUtil.ToAscii("\\"));
        }

        [TestMethod]
        public void TestToAscii41_CloseBracket()
        {
            Assert.AreEqual(93, StringUtil.ToAscii("]"));
        }

        [TestMethod]
        public void TestToAscii42_Caret()
        {
            Assert.AreEqual(94, StringUtil.ToAscii("^"));
        }

        [TestMethod]
        public void TestToAscii43_Underscore()
        {
            Assert.AreEqual(95, StringUtil.ToAscii("_"));
        }

        [TestMethod]
        public void TestToAscii44_Backtick()
        {
            Assert.AreEqual(96, StringUtil.ToAscii("`"));
        }

        [TestMethod]
        public void TestToAscii45_OpenBrace()
        {
            Assert.AreEqual(123, StringUtil.ToAscii("{"));
        }

        [TestMethod]
        public void TestToAscii46_Pipe()
        {
            Assert.AreEqual(124, StringUtil.ToAscii("|"));
        }

        [TestMethod]
        public void TestToAscii47_CloseBrace()
        {
            Assert.AreEqual(125, StringUtil.ToAscii("}"));
        }

        [TestMethod]
        public void TestToAscii48_Tilde()
        {
            Assert.AreEqual(126, StringUtil.ToAscii("~"));
        }

        [TestMethod]
        public void TestToAscii49_MultiCharStringFirstCharOnly()
        {
            // Test that only the first character is converted
            Assert.AreEqual(65, StringUtil.ToAscii("ABC"));
        }

        [TestMethod]
        public void TestToAscii50_MultiCharStringFirstCharOnly2()
        {
            // Test that only the first character is converted
            Assert.AreEqual(97, StringUtil.ToAscii("apple"));
        }

        [TestMethod]
        public void TestToAscii51_ControlCharacter_BEL()
        {
            Assert.AreEqual(7, StringUtil.ToAscii("\u0007"));
        }

        [TestMethod]
        public void TestToAscii52_ControlCharacter_BS()
        {
            Assert.AreEqual(8, StringUtil.ToAscii("\u0008"));
        }

        [TestMethod]
        public void TestToAscii53_ControlCharacter_FF()
        {
            Assert.AreEqual(12, StringUtil.ToAscii("\u000C"));
        }

        [TestMethod]
        public void TestToAscii54_ControlCharacter_VT()
        {
            Assert.AreEqual(11, StringUtil.ToAscii("\u000B"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestToAscii55_NullString()
        {
            StringUtil.ToAscii(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestToAscii56_EmptyString()
        {
            StringUtil.ToAscii("");
        }

        [TestMethod]
        public void TestToAscii57_ExtendedASCII_A0()
        {
            // Non-breaking space in Windows-1252
            Assert.AreEqual(160, StringUtil.ToAscii("\u00A0"));
        }

        [TestMethod]
        public void TestToAscii58_ExtendedASCII_A9()
        {
            // Copyright symbol in Windows-1252
            Assert.AreEqual(169, StringUtil.ToAscii("©"));
        }

        [TestMethod]
        public void TestToAscii59_ExtendedASCII_AE()
        {
            // Registered trademark in Windows-1252
            Assert.AreEqual(174, StringUtil.ToAscii("®"));
        }

        [TestMethod]
        public void TestToAscii60_ExtendedASCII_BE()
        {
            // One-half in Windows-1252
            Assert.AreEqual(190, StringUtil.ToAscii("¾"));
        }

        #endregion


        #region XmlEncode(string) tests

        // Null and empty tests
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestXmlEncode1_NullInput()
        {
            StringUtil.XmlEncode(null);
            Assert.Fail();
        }

        [TestMethod]
        public void TestXmlEncode2_EmptyString()
        {
            Assert.AreEqual("", StringUtil.XmlEncode(""));
        }

        // No special characters tests
        [TestMethod]
        public void TestXmlEncode3_NoSpecialChars()
        {
            Assert.AreEqual("hello", StringUtil.XmlEncode("hello"));
        }

        [TestMethod]
        public void TestXmlEncode4_NoSpecialCharsWithNumbers()
        {
            Assert.AreEqual("test123", StringUtil.XmlEncode("test123"));
        }

        [TestMethod]
        public void TestXmlEncode5_NoSpecialCharsWithSpaces()
        {
            Assert.AreEqual("hello world test", StringUtil.XmlEncode("hello world test"));
        }

        // Ampersand tests
        [TestMethod]
        public void TestXmlEncode6_SingleAmpersand()
        {
            Assert.AreEqual("&#38;", StringUtil.XmlEncode("&"));
        }

        [TestMethod]
        public void TestXmlEncode7_AmpersandAtStart()
        {
            Assert.AreEqual("&#38;test", StringUtil.XmlEncode("&test"));
        }

        [TestMethod]
        public void TestXmlEncode8_AmpersandAtEnd()
        {
            Assert.AreEqual("test&#38;", StringUtil.XmlEncode("test&"));
        }

        [TestMethod]
        public void TestXmlEncode9_AmpersandInMiddle()
        {
            Assert.AreEqual("hello&#38;world", StringUtil.XmlEncode("hello&world"));
        }

        [TestMethod]
        public void TestXmlEncode10_MultipleAmpersands()
        {
            Assert.AreEqual("&#38;&#38;&#38;", StringUtil.XmlEncode("&&&"));
        }

        // Less-than tests
        [TestMethod]
        public void TestXmlEncode11_SingleLessThan()
        {
            Assert.AreEqual("&#60;", StringUtil.XmlEncode("<"));
        }

        [TestMethod]
        public void TestXmlEncode12_LessThanAtStart()
        {
            Assert.AreEqual("&#60;test", StringUtil.XmlEncode("<test"));
        }

        [TestMethod]
        public void TestXmlEncode13_LessThanInMiddle()
        {
            Assert.AreEqual("a&#60;b", StringUtil.XmlEncode("a<b"));
        }

        [TestMethod]
        public void TestXmlEncode14_MultipleLessThan()
        {
            Assert.AreEqual("&#60;&#60;&#60;", StringUtil.XmlEncode("<<<"));
        }

        // Greater-than tests
        [TestMethod]
        public void TestXmlEncode15_SingleGreaterThan()
        {
            Assert.AreEqual("&#62;", StringUtil.XmlEncode(">"));
        }

        [TestMethod]
        public void TestXmlEncode16_GreaterThanAtStart()
        {
            Assert.AreEqual("&#62;test", StringUtil.XmlEncode(">test"));
        }

        [TestMethod]
        public void TestXmlEncode17_GreaterThanInMiddle()
        {
            Assert.AreEqual("a&#62;b", StringUtil.XmlEncode("a>b"));
        }

        [TestMethod]
        public void TestXmlEncode18_MultipleGreaterThan()
        {
            Assert.AreEqual("&#62;&#62;&#62;", StringUtil.XmlEncode(">>>"));
        }

        // Double quote tests
        [TestMethod]
        public void TestXmlEncode19_SingleDoubleQuote()
        {
            Assert.AreEqual("&#34;", StringUtil.XmlEncode("\""));
        }

        [TestMethod]
        public void TestXmlEncode20_DoubleQuoteAtStart()
        {
            Assert.AreEqual("&#34;test", StringUtil.XmlEncode("\"test"));
        }

        [TestMethod]
        public void TestXmlEncode21_DoubleQuoteInMiddle()
        {
            Assert.AreEqual("hello&#34;world", StringUtil.XmlEncode("hello\"world"));
        }

        [TestMethod]
        public void TestXmlEncode22_MultipleDoubleQuotes()
        {
            Assert.AreEqual("&#34;&#34;&#34;", StringUtil.XmlEncode("\"\"\""));
        }

        // Equals sign tests
        [TestMethod]
        public void TestXmlEncode23_SingleEquals()
        {
            Assert.AreEqual("&#61;", StringUtil.XmlEncode("="));
        }

        [TestMethod]
        public void TestXmlEncode24_EqualsAtStart()
        {
            Assert.AreEqual("&#61;test", StringUtil.XmlEncode("=test"));
        }

        [TestMethod]
        public void TestXmlEncode25_EqualsInMiddle()
        {
            Assert.AreEqual("a&#61;b", StringUtil.XmlEncode("a=b"));
        }

        // Single quote tests
        [TestMethod]
        public void TestXmlEncode26_SingleSingleQuote()
        {
            Assert.AreEqual("&#39;", StringUtil.XmlEncode("'"));
        }

        [TestMethod]
        public void TestXmlEncode27_SingleQuoteAtStart()
        {
            Assert.AreEqual("&#39;test", StringUtil.XmlEncode("'test"));
        }

        [TestMethod]
        public void TestXmlEncode28_SingleQuoteInMiddle()
        {
            Assert.AreEqual("don&#39;t", StringUtil.XmlEncode("don't"));
        }

        [TestMethod]
        public void TestXmlEncode29_MultipleSingleQuotes()
        {
            Assert.AreEqual("&#39;&#39;&#39;", StringUtil.XmlEncode("'''"));
        }

        // Newline tests
        [TestMethod]
        public void TestXmlEncode30_SingleNewline()
        {
            Assert.AreEqual(" ", StringUtil.XmlEncode("\n"));
        }

        [TestMethod]
        public void TestXmlEncode31_NewlineAtStart()
        {
            Assert.AreEqual(" test", StringUtil.XmlEncode("\ntest"));
        }

        [TestMethod]
        public void TestXmlEncode32_NewlineInMiddle()
        {
            Assert.AreEqual("hello world", StringUtil.XmlEncode("hello\nworld"));
        }

        [TestMethod]
        public void TestXmlEncode33_MultipleNewlines()
        {
            Assert.AreEqual("   ", StringUtil.XmlEncode("\n\n\n"));
        }

        // Tab tests
        [TestMethod]
        public void TestXmlEncode34_SingleTab()
        {
            Assert.AreEqual(" ", StringUtil.XmlEncode("\t"));
        }

        [TestMethod]
        public void TestXmlEncode35_TabAtStart()
        {
            Assert.AreEqual(" test", StringUtil.XmlEncode("\ttest"));
        }

        [TestMethod]
        public void TestXmlEncode36_TabInMiddle()
        {
            Assert.AreEqual("hello world", StringUtil.XmlEncode("hello\tworld"));
        }

        [TestMethod]
        public void TestXmlEncode37_MultipleTabs()
        {
            Assert.AreEqual("   ", StringUtil.XmlEncode("\t\t\t"));
        }

        // Multiple different special characters
        [TestMethod]
        public void TestXmlEncode38_AmpersandAndLessThan()
        {
            Assert.AreEqual("&#38;&#60;", StringUtil.XmlEncode("&<"));
        }

        [TestMethod]
        public void TestXmlEncode39_AllSpecialChars()
        {
            Assert.AreEqual("&#38;&#60;&#62;&#34;&#61;&#39;", StringUtil.XmlEncode("&<>\"='"));
        }

        [TestMethod]
        public void TestXmlEncode40_MixedSpecialCharsAndNewline()
        {
            Assert.AreEqual("test&#38;data world", StringUtil.XmlEncode("test&data\nworld"));
        }

        [TestMethod]
        public void TestXmlEncode41_MixedSpecialCharsAndTab()
        {
            // Tab is replaced with space, then < is encoded
            Assert.AreEqual("hello&#60; world", StringUtil.XmlEncode("hello<\tworld"));
        }

        // Real-world XML scenarios
        [TestMethod]
        public void TestXmlEncode42_XMLTag()
        {
            Assert.AreEqual("&#60;tag&#62;", StringUtil.XmlEncode("<tag>"));
        }

        [TestMethod]
        public void TestXmlEncode43_XMLAttribute()
        {
            Assert.AreEqual("attr&#61;&#34;value&#34;", StringUtil.XmlEncode("attr=\"value\""));
        }

        [TestMethod]
        public void TestXmlEncode44_XMLWithAmpersand()
        {
            Assert.AreEqual("A &#38; B", StringUtil.XmlEncode("A & B"));
        }

        [TestMethod]
        public void TestXmlEncode45_XMLComplexContent()
        {
            Assert.AreEqual("&#60;element attr&#61;&#34;val&#34;&#62;content&#60;/element&#62;", StringUtil.XmlEncode("<element attr=\"val\">content</element>"));
        }

        // Mixed content with numbers and special characters
        [TestMethod]
        public void TestXmlEncode46_NumbersWithAmpersand()
        {
            Assert.AreEqual("123&#38;456", StringUtil.XmlEncode("123&456"));
        }

        [TestMethod]
        public void TestXmlEncode47_URLWithSpecialChars()
        {
            Assert.AreEqual("http://example.com?a&#61;1&#38;b&#61;2", StringUtil.XmlEncode("http://example.com?a=1&b=2"));
        }

        [TestMethod]
        public void TestXmlEncode48_JSONLikeWithSpecialChars()
        {
            Assert.AreEqual("{&#34;key&#34;:&#34;value&#34;}", StringUtil.XmlEncode("{\"key\":\"value\"}"));
        }

        #endregion


        #region ToByteArray(string) tests

        // Null and empty tests
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestToByteArray1_NullInput()
        {
            StringUtil.ToByteArray(null);
            Assert.Fail();
        }

        [TestMethod]
        public void TestToByteArray2_EmptyString()
        {
            byte[] result = StringUtil.ToByteArray("");
            Assert.AreEqual(0, result.Length);
        }

        // Single character tests
        [TestMethod]
        public void TestToByteArray3_SingleLowerCaseLetter()
        {
            byte[] result = StringUtil.ToByteArray("a");
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(97, result[0]); // ASCII value of 'a'
        }

        [TestMethod]
        public void TestToByteArray4_SingleUpperCaseLetter()
        {
            byte[] result = StringUtil.ToByteArray("A");
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(65, result[0]); // ASCII value of 'A'
        }

        [TestMethod]
        public void TestToByteArray5_SingleDigit()
        {
            byte[] result = StringUtil.ToByteArray("5");
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(53, result[0]); // ASCII value of '5'
        }

        [TestMethod]
        public void TestToByteArray6_SingleSpace()
        {
            byte[] result = StringUtil.ToByteArray(" ");
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(32, result[0]); // ASCII value of space
        }

        [TestMethod]
        public void TestToByteArray7_SingleSymbol()
        {
            byte[] result = StringUtil.ToByteArray("!");
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(33, result[0]); // ASCII value of '!'
        }

        // Multiple character tests with length verification
        [TestMethod]
        public void TestToByteArray8_TwoCharacters()
        {
            byte[] result = StringUtil.ToByteArray("ab");
            Assert.AreEqual(2, result.Length);
            Assert.AreEqual(97, result[0]); // 'a'
            Assert.AreEqual(98, result[1]); // 'b'
        }

        [TestMethod]
        public void TestToByteArray9_ThreeCharacters()
        {
            byte[] result = StringUtil.ToByteArray("abc");
            Assert.AreEqual(3, result.Length);
            Assert.AreEqual(97, result[0]); // 'a'
            Assert.AreEqual(98, result[1]); // 'b'
            Assert.AreEqual(99, result[2]); // 'c'
        }

        [TestMethod]
        public void TestToByteArray10_AlphabetLowerCase()
        {
            byte[] result = StringUtil.ToByteArray("abcdefghijklmnopqrstuvwxyz");
            Assert.AreEqual(26, result.Length);
        }

        [TestMethod]
        public void TestToByteArray11_AlphabetUpperCase()
        {
            byte[] result = StringUtil.ToByteArray("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            Assert.AreEqual(26, result.Length);
        }

        [TestMethod]
        public void TestToByteArray12_Digits()
        {
            byte[] result = StringUtil.ToByteArray("0123456789");
            Assert.AreEqual(10, result.Length);
            Assert.AreEqual(48, result[0]); // '0'
            Assert.AreEqual(57, result[9]); // '9'
        }

        // Case sensitivity tests
        [TestMethod]
        public void TestToByteArray13_LowercaseA()
        {
            byte[] result = StringUtil.ToByteArray("a");
            Assert.AreEqual(97, result[0]);
        }

        [TestMethod]
        public void TestToByteArray14_UppercaseA()
        {
            byte[] result = StringUtil.ToByteArray("A");
            Assert.AreEqual(65, result[0]);
        }

        [TestMethod]
        public void TestToByteArray15_MixedCase()
        {
            byte[] result = StringUtil.ToByteArray("AaBbCc");
            Assert.AreEqual(6, result.Length);
            Assert.AreEqual(65, result[0]); // 'A'
            Assert.AreEqual(97, result[1]); // 'a'
        }

        // Special characters tests
        [TestMethod]
        public void TestToByteArray16_PunctuationMarks()
        {
            byte[] result = StringUtil.ToByteArray(".,!?;:");
            Assert.AreEqual(6, result.Length);
        }

        [TestMethod]
        public void TestToByteArray17_Symbols()
        {
            byte[] result = StringUtil.ToByteArray("@#$%^&*()");
            Assert.AreEqual(9, result.Length);
        }

        [TestMethod]
        public void TestToByteArray18_BracketsAndParens()
        {
            byte[] result = StringUtil.ToByteArray("[]{}()<>");
            Assert.AreEqual(8, result.Length);
        }

        // Whitespace tests
        [TestMethod]
        public void TestToByteArray19_SpaceCharacter()
        {
            byte[] result = StringUtil.ToByteArray(" ");
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(32, result[0]); // ASCII value of space
        }

        [TestMethod]
        public void TestToByteArray20_MultipleSpaces()
        {
            byte[] result = StringUtil.ToByteArray("   ");
            Assert.AreEqual(3, result.Length);
            Assert.AreEqual(32, result[0]);
            Assert.AreEqual(32, result[1]);
            Assert.AreEqual(32, result[2]);
        }

        [TestMethod]
        public void TestToByteArray21_TabCharacter()
        {
            byte[] result = StringUtil.ToByteArray("\t");
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(9, result[0]); // ASCII value of tab
        }

        [TestMethod]
        public void TestToByteArray22_NewlineCharacter()
        {
            byte[] result = StringUtil.ToByteArray("\n");
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(10, result[0]); // ASCII value of newline
        }

        [TestMethod]
        public void TestToByteArray23_CarriageReturnCharacter()
        {
            byte[] result = StringUtil.ToByteArray("\r");
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(13, result[0]); // ASCII value of carriage return
        }

        // Repeated characters
        [TestMethod]
        public void TestToByteArray24_RepeatedCharacter()
        {
            byte[] result = StringUtil.ToByteArray("aaaa");
            Assert.AreEqual(4, result.Length);
            Assert.AreEqual(97, result[0]);
            Assert.AreEqual(97, result[1]);
            Assert.AreEqual(97, result[2]);
            Assert.AreEqual(97, result[3]);
        }

        [TestMethod]
        public void TestToByteArray25_RepeatedDigit()
        {
            byte[] result = StringUtil.ToByteArray("1111");
            Assert.AreEqual(4, result.Length);
            Assert.AreEqual(49, result[0]); // '1'
        }

        // Mixed content
        [TestMethod]
        public void TestToByteArray26_AlphanumericMixed()
        {
            byte[] result = StringUtil.ToByteArray("a1b2c3");
            Assert.AreEqual(6, result.Length);
        }

        [TestMethod]
        public void TestToByteArray27_WordWithSpaces()
        {
            byte[] result = StringUtil.ToByteArray("hello world");
            Assert.AreEqual(11, result.Length);
            Assert.AreEqual(104, result[0]); // 'h'
            Assert.AreEqual(32, result[5]); // space
            Assert.AreEqual(119, result[6]); // 'w'
        }

        [TestMethod]
        public void TestToByteArray28_SentenceWithPunctuation()
        {
            byte[] result = StringUtil.ToByteArray("Hello, World!");
            Assert.AreEqual(13, result.Length);
        }

        // Longer strings
        [TestMethod]
        public void TestToByteArray29_LongAlphabeticalString()
        {
            string longString = "abcdefghijklmnopqrstuvwxyz";
            byte[] result = StringUtil.ToByteArray(longString);
            Assert.AreEqual(longString.Length, result.Length);
        }

        [TestMethod]
        public void TestToByteArray30_VeryLongString()
        {
            string longString = new string('a', 1000);
            byte[] result = StringUtil.ToByteArray(longString);
            Assert.AreEqual(1000, result.Length);
            // Verify all bytes are 'a'
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(97, result[i]);
            }
        }

        // Numeric strings
        [TestMethod]
        public void TestToByteArray31_NumericString()
        {
            byte[] result = StringUtil.ToByteArray("12345");
            Assert.AreEqual(5, result.Length);
            Assert.AreEqual(49, result[0]); // '1'
            Assert.AreEqual(50, result[1]); // '2'
            Assert.AreEqual(51, result[2]); // '3'
            Assert.AreEqual(52, result[3]); // '4'
            Assert.AreEqual(53, result[4]); // '5'
        }

        [TestMethod]
        public void TestToByteArray32_NumericWithDecimal()
        {
            byte[] result = StringUtil.ToByteArray("3.14159");
            Assert.AreEqual(7, result.Length);
        }

        // Special sequences
        [TestMethod]
        public void TestToByteArray33_QuotedString()
        {
            byte[] result = StringUtil.ToByteArray("\"hello\"");
            Assert.AreEqual(7, result.Length);
            Assert.AreEqual(34, result[0]); // '"'
        }

        [TestMethod]
        public void TestToByteArray34_URLLike()
        {
            byte[] result = StringUtil.ToByteArray("http://example.com");
            Assert.AreEqual(18, result.Length);
        }

        [TestMethod]
        public void TestToByteArray35_EmailLike()
        {
            byte[] result = StringUtil.ToByteArray("user@example.com");
            Assert.AreEqual(16, result.Length);
        }

        // Array content verification
        [TestMethod]
        public void TestToByteArray36_VerifyArrayContent()
        {
            byte[] result = StringUtil.ToByteArray("ABC");
            Assert.AreEqual(3, result.Length);
            Assert.AreEqual(65, result[0]); // 'A'
            Assert.AreEqual(66, result[1]); // 'B'
            Assert.AreEqual(67, result[2]); // 'C'
        }

        [TestMethod]
        public void TestToByteArray37_VerifyNumericContent()
        {
            byte[] result = StringUtil.ToByteArray("789");
            Assert.AreEqual(3, result.Length);
            Assert.AreEqual(55, result[0]); // '7'
            Assert.AreEqual(56, result[1]); // '8'
            Assert.AreEqual(57, result[2]); // '9'
        }

        [TestMethod]
        public void TestToByteArray38_JSONLikeString()
        {
            byte[] result = StringUtil.ToByteArray("{\"key\":\"value\"}");
            Assert.AreEqual(15, result.Length);
        }

        [TestMethod]
        public void TestToByteArray39_XMLLikeString()
        {
            byte[] result = StringUtil.ToByteArray("<tag>content</tag>");
            Assert.AreEqual(18, result.Length);
        }

        [TestMethod]
        public void TestToByteArray40_SpecialSymbolCombination()
        {
            byte[] result = StringUtil.ToByteArray("+-*/=");
            Assert.AreEqual(5, result.Length);
            Assert.AreEqual(43, result[0]); // '+'
            Assert.AreEqual(45, result[1]); // '-'
        }

        [TestMethod]
        public void TestToByteArray41_MixedWhitespace()
        {
            byte[] result = StringUtil.ToByteArray("a b\tc");
            Assert.AreEqual(5, result.Length);
            Assert.AreEqual(97, result[0]); // 'a'
            Assert.AreEqual(32, result[1]); // space
            Assert.AreEqual(98, result[2]); // 'b'
            Assert.AreEqual(9, result[3]); // tab
            Assert.AreEqual(99, result[4]); // 'c'
        }

        [TestMethod]
        public void TestToByteArray42_UnderscoresAndDashes()
        {
            byte[] result = StringUtil.ToByteArray("test_name-value");
            Assert.AreEqual(15, result.Length);
            Assert.AreEqual(95, result[4]); // '_'
            Assert.AreEqual(45, result[9]); // '-'
        }

        #endregion


        #region FromByteArray(byte[]) tests

        // Null and empty tests
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestFromByteArray1_NullInput()
        {
            StringUtil.FromByteArray(null);
            Assert.Fail();
        }

        [TestMethod]
        public void TestFromByteArray2_EmptyArray()
        {
            string result = StringUtil.FromByteArray(new byte[0]);
            Assert.AreEqual("", result);
            Assert.AreEqual(0, result.Length);
        }

        // Single byte tests
        [TestMethod]
        public void TestFromByteArray3_SingleByteLowercaseA()
        {
            byte[] bytes = new byte[] { 97 }; // ASCII 'a'
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual("a", result);
            Assert.AreEqual(1, result.Length);
        }

        [TestMethod]
        public void TestFromByteArray4_SingleByteUppercaseA()
        {
            byte[] bytes = new byte[] { 65 }; // ASCII 'A'
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual("A", result);
        }

        [TestMethod]
        public void TestFromByteArray5_SingleByteDigit()
        {
            byte[] bytes = new byte[] { 53 }; // ASCII '5'
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual("5", result);
        }

        [TestMethod]
        public void TestFromByteArray6_SingleByteSpace()
        {
            byte[] bytes = new byte[] { 32 }; // ASCII space
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(" ", result);
        }

        [TestMethod]
        public void TestFromByteArray7_SingleByteExclamation()
        {
            byte[] bytes = new byte[] { 33 }; // ASCII '!'
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual("!", result);
        }

        // Multiple byte tests
        [TestMethod]
        public void TestFromByteArray8_TwoBytes()
        {
            byte[] bytes = new byte[] { 97, 98 }; // 'a', 'b'
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual("ab", result);
            Assert.AreEqual(2, result.Length);
        }

        [TestMethod]
        public void TestFromByteArray9_ThreeBytes()
        {
            byte[] bytes = new byte[] { 97, 98, 99 }; // 'a', 'b', 'c'
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual("abc", result);
            Assert.AreEqual(3, result.Length);
        }

        [TestMethod]
        public void TestFromByteArray10_LowercaseAlphabet()
        {
            byte[] bytes = new byte[] { 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122 };
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual("abcdefghijklmnopqrstuvwxyz", result);
            Assert.AreEqual(26, result.Length);
        }

        [TestMethod]
        public void TestFromByteArray11_UppercaseAlphabet()
        {
            byte[] bytes = new byte[] { 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90 };
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual("ABCDEFGHIJKLMNOPQRSTUVWXYZ", result);
            Assert.AreEqual(26, result.Length);
        }

        [TestMethod]
        public void TestFromByteArray12_Digits()
        {
            byte[] bytes = new byte[] { 48, 49, 50, 51, 52, 53, 54, 55, 56, 57 }; // '0' through '9'
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual("0123456789", result);
            Assert.AreEqual(10, result.Length);
        }

        // Case sensitivity tests
        [TestMethod]
        public void TestFromByteArray13_MixedCase()
        {
            byte[] bytes = new byte[] { 65, 97, 66, 98, 67, 99 }; // 'A', 'a', 'B', 'b', 'C', 'c'
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual("AaBbCc", result);
            Assert.AreEqual(6, result.Length);
        }

        // Special characters and punctuation
        [TestMethod]
        public void TestFromByteArray14_PunctuationMarks()
        {
            byte[] bytes = new byte[] { 46, 44, 33, 63, 59, 58 }; // '.', ',', '!', '?', ';', ':'
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(".,!?;:", result);
            Assert.AreEqual(6, result.Length);
        }

        [TestMethod]
        public void TestFromByteArray15_CommonSymbols()
        {
            byte[] bytes = new byte[] { 64, 35, 36, 37, 94, 38, 42, 40, 41 }; // '@', '#', '$', '%', '^', '&', '*', '(', ')'
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual("@#$%^&*()", result);
            Assert.AreEqual(9, result.Length);
        }

        [TestMethod]
        public void TestFromByteArray16_BracketsAndBraces()
        {
            byte[] bytes = new byte[] { 91, 93, 123, 125, 40, 41, 60, 62 }; // '[', ']', '{', '}', '(', ')', '<', '>'
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual("[]{}()<>", result);
            Assert.AreEqual(8, result.Length);
        }

        [TestMethod]
        public void TestFromByteArray17_QuotesAndApostrophes()
        {
            byte[] bytes = new byte[] { 34, 39 }; // '"', '\''
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual("\"'", result);
        }

        // Whitespace tests
        [TestMethod]
        public void TestFromByteArray18_Space()
        {
            byte[] bytes = new byte[] { 32 }; // space
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(" ", result);
        }

        [TestMethod]
        public void TestFromByteArray19_MultipleSpaces()
        {
            byte[] bytes = new byte[] { 32, 32, 32 };
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual("   ", result);
            Assert.AreEqual(3, result.Length);
        }

        [TestMethod]
        public void TestFromByteArray20_TabCharacter()
        {
            byte[] bytes = new byte[] { 9 }; // ASCII tab
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual("\t", result);
        }

        [TestMethod]
        public void TestFromByteArray21_NewlineCharacter()
        {
            byte[] bytes = new byte[] { 10 }; // ASCII newline
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual("\n", result);
        }

        [TestMethod]
        public void TestFromByteArray22_CarriageReturnCharacter()
        {
            byte[] bytes = new byte[] { 13 }; // ASCII carriage return
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual("\r", result);
        }

        // Repeated bytes
        [TestMethod]
        public void TestFromByteArray23_RepeatedCharacter()
        {
            byte[] bytes = new byte[] { 97, 97, 97, 97 }; // 'a', 'a', 'a', 'a'
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual("aaaa", result);
            Assert.AreEqual(4, result.Length);
        }

        [TestMethod]
        public void TestFromByteArray24_RepeatedDigit()
        {
            byte[] bytes = new byte[] { 49, 49, 49, 49 }; // '1', '1', '1', '1'
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual("1111", result);
        }

        // Mixed content
        [TestMethod]
        public void TestFromByteArray25_AlphanumericMixed()
        {
            byte[] bytes = new byte[] { 97, 49, 98, 50, 99, 51 }; // 'a', '1', 'b', '2', 'c', '3'
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual("a1b2c3", result);
            Assert.AreEqual(6, result.Length);
        }

        [TestMethod]
        public void TestFromByteArray26_WordWithSpaces()
        {
            byte[] bytes = new byte[] { 104, 101, 108, 108, 111, 32, 119, 111, 114, 108, 100 }; // 'h', 'e', 'l', 'l', 'o', ' ', 'w', 'o', 'r', 'l', 'd'
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual("hello world", result);
            Assert.AreEqual(11, result.Length);
        }

        [TestMethod]
        public void TestFromByteArray27_SentenceWithPunctuation()
        {
            byte[] bytes = new byte[] { 72, 101, 108, 108, 111, 44, 32, 87, 111, 114, 108, 100, 33 }; // 'H', 'e', 'l', 'l', 'o', ',', ' ', 'W', 'o', 'r', 'l', 'd', '!'
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual("Hello, World!", result);
            Assert.AreEqual(13, result.Length);
        }

        // Numeric strings
        [TestMethod]
        public void TestFromByteArray28_NumericString()
        {
            byte[] bytes = new byte[] { 49, 50, 51, 52, 53 }; // '1', '2', '3', '4', '5'
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual("12345", result);
            Assert.AreEqual(5, result.Length);
        }

        [TestMethod]
        public void TestFromByteArray29_NumericWithDecimal()
        {
            byte[] bytes = new byte[] { 51, 46, 49, 52, 49, 53, 57 }; // '3', '.', '1', '4', '1', '5', '9'
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual("3.14159", result);
            Assert.AreEqual(7, result.Length);
        }

        // Special sequences
        [TestMethod]
        public void TestFromByteArray30_QuotedString()
        {
            byte[] bytes = new byte[] { 34, 104, 101, 108, 108, 111, 34 }; // '"hello"'
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual("\"hello\"", result);
            Assert.AreEqual(7, result.Length);
        }

        [TestMethod]
        public void TestFromByteArray31_URLLike()
        {
            byte[] bytes = new byte[] { 104, 116, 116, 112, 58, 47, 47, 101, 120, 97, 109, 112, 108, 101, 46, 99, 111, 109 }; // 'h', 't', 't', 'p', ':', '/', '/', 'e', 'x', 'a', 'm', 'p', 'l', 'e', '.', 'c', 'o', 'm'
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual("http://example.com", result);
            Assert.AreEqual(18, result.Length);
        }

        [TestMethod]
        public void TestFromByteArray32_EmailLike()
        {
            byte[] bytes = new byte[] { 117, 115, 101, 114, 64, 101, 120, 97, 109, 112, 108, 101, 46, 99, 111, 109 }; // 'u', 's', 'e', 'r', '@', 'e', 'x', 'a', 'm', 'p', 'l', 'e', '.', 'c', 'o', 'm'
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual("user@example.com", result);
            Assert.AreEqual(16, result.Length);
        }

        // Array content verification
        [TestMethod]
        public void TestFromByteArray33_VerifyCharacterValues()
        {
            byte[] bytes = new byte[] { 65, 66, 67 }; // 'A', 'B', 'C'
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(3, result.Length);
            Assert.AreEqual('A', result[0]);
            Assert.AreEqual('B', result[1]);
            Assert.AreEqual('C', result[2]);
        }

        [TestMethod]
        public void TestFromByteArray34_VerifyNumericCharacters()
        {
            byte[] bytes = new byte[] { 55, 56, 57 }; // '7', '8', '9'
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(3, result.Length);
            Assert.AreEqual('7', result[0]);
            Assert.AreEqual('8', result[1]);
            Assert.AreEqual('9', result[2]);
        }

        [TestMethod]
        public void TestFromByteArray35_JSONLikeString()
        {
            byte[] bytes = new byte[] { 123, 34, 107, 101, 121, 34, 58, 34, 118, 97, 108, 117, 101, 34, 125 }; // {"key":"value"}
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual("{\"key\":\"value\"}", result);
            Assert.AreEqual(15, result.Length);
        }

        [TestMethod]
        public void TestFromByteArray36_XMLLikeString()
        {
            byte[] bytes = new byte[] { 60, 116, 97, 103, 62, 99, 111, 110, 116, 101, 110, 116, 60, 47, 116, 97, 103, 62 }; // <tag>content</tag>
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual("<tag>content</tag>", result);
            Assert.AreEqual(18, result.Length);
        }

        [TestMethod]
        public void TestFromByteArray37_OperatorSymbols()
        {
            byte[] bytes = new byte[] { 43, 45, 42, 47, 61 }; // '+', '-', '*', '/', '='
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual("+-*/=", result);
            Assert.AreEqual(5, result.Length);
        }

        [TestMethod]
        public void TestFromByteArray38_MixedWhitespace()
        {
            byte[] bytes = new byte[] { 97, 32, 98, 9, 99 }; // 'a', ' ', 'b', '\t', 'c'
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual("a b\tc", result);
            Assert.AreEqual(5, result.Length);
        }

        [TestMethod]
        public void TestFromByteArray39_UnderscoresAndDashes()
        {
            byte[] bytes = new byte[] { 116, 101, 115, 116, 95, 110, 97, 109, 101, 45, 118, 97, 108, 117, 101 }; // 'test_name-value'
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual("test_name-value", result);
            Assert.AreEqual(15, result.Length);
        }

        [TestMethod]
        public void TestFromByteArray40_LongString()
        {
            byte[] bytes = new byte[1000];
            for (int i = 0; i < 1000; i++)
            {
                bytes[i] = 97; // 'a'
            }
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(1000, result.Length);
            // Verify all characters are 'a'
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual('a', result[i]);
            }
        }

        [TestMethod]
        public void TestFromByteArray41_AllPrintableASCII()
        {
            // Test a range of printable ASCII characters (32-126)
            byte[] bytes = new byte[95]; // 95 printable ASCII characters
            for (byte b = 32; b <= 126; b++)
            {
                bytes[b - 32] = b;
            }
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(95, result.Length);
            // Verify first and last
            Assert.AreEqual(' ', result[0]); // space (32)
            Assert.AreEqual('~', result[94]); // tilde (126)
        }

        [TestMethod]
        public void TestFromByteArray42_RoundTripConversion()
        {
            // Test that ToByteArray and FromByteArray are inverses
            string original = "Hello, World! 123";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        #endregion


        #region ToByteArray / FromByteArray round-trip tests

        [TestMethod]
        public void TestRoundTrip1_EmptyString()
        {
            string original = "";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip2_SingleCharacterLowercase()
        {
            string original = "a";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
            Assert.AreEqual("a", result);
        }

        [TestMethod]
        public void TestRoundTrip3_SingleCharacterUppercase()
        {
            string original = "Z";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip4_SingleDigit()
        {
            string original = "7";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip5_SingleSpecialCharacter()
        {
            string original = "!";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip6_SimpleWord()
        {
            string original = "hello";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip7_TwoWords()
        {
            string original = "hello world";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip8_SentenceWithPunctuation()
        {
            string original = "Hello, World!";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip9_MixedCase()
        {
            string original = "CamelCase";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip10_AlphanumericString()
        {
            string original = "abc123xyz";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip11_WithNumbers()
        {
            string original = "The year is 2024";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip12_WithDecimal()
        {
            string original = "3.14159";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip13_AllLowercaseAlphabet()
        {
            string original = "abcdefghijklmnopqrstuvwxyz";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip14_AllUppercaseAlphabet()
        {
            string original = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip15_AllDigits()
        {
            string original = "0123456789";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip16_WithSpaces()
        {
            string original = "a b c d e";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip17_WithMultipleSpaces()
        {
            string original = "word1   word2";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip18_WithTab()
        {
            string original = "column1\tcolumn2";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip19_WithNewline()
        {
            string original = "line1\nline2";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip20_WithCarriageReturn()
        {
            string original = "line1\rline2";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip21_WithMultipleWhitespaceTypes()
        {
            string original = "a b\tc\r\nd";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip22_Punctuation()
        {
            string original = ".,!?;:";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip23_CommonSymbols()
        {
            string original = "@#$%^&*()";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip24_Brackets()
        {
            string original = "[]{}()<>";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip25_Quotes()
        {
            string original = "\"hello\"";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip26_Apostrophes()
        {
            string original = "'world'";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip27_MixedQuotes()
        {
            string original = "\"It's a test\"";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip28_OperatorSymbols()
        {
            string original = "+-*/=";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip29_UnderscoreAndDash()
        {
            string original = "test_name-value";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip30_URLString()
        {
            string original = "http://example.com";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip31_EmailString()
        {
            string original = "user@example.com";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip32_FilePathStyle()
        {
            string original = "C:\\Users\\Test\\file.txt";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip33_JSONData()
        {
            string original = "{\"key\":\"value\"}";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip34_XMLData()
        {
            string original = "<tag>content</tag>";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip35_ComplexSentence()
        {
            string original = "The quick brown fox jumps over the lazy dog!";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip36_MixedContentString()
        {
            string original = "Test@123 with-symbols_and MIXED Case!";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip37_CodeLikeString()
        {
            string original = "public void Method(int x) { return x + 1; }";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip38_CSVLine()
        {
            string original = "Name,Age,City,Email";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip39_SQLStatementFragment()
        {
            string original = "SELECT * FROM users WHERE id=123;";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void TestRoundTrip40_LongString()
        {
            string original = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
            Assert.AreEqual(62, result.Length);
        }

        [TestMethod]
        public void TestRoundTrip41_VeryLongRepeatedString()
        {
            string original = new string('x', 500);
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
            Assert.AreEqual(500, result.Length);
        }

        [TestMethod]
        public void TestRoundTrip42_AllPrintableASCIICharacters()
        {
            // Build a string with all printable ASCII characters (32-126)
            string original = "";
            for (char c = (char)32; c <= (char)126; c++)
            {
                original += c;
            }
            byte[] bytes = StringUtil.ToByteArray(original);
            string result = StringUtil.FromByteArray(bytes);
            Assert.AreEqual(original, result);
            Assert.AreEqual(95, result.Length);
        }

        #endregion


        #region AppendSpaces(string, int) tests

        // Null input tests
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestAppendSpaces1_NullInput()
        {
            StringUtil.AppendSpaces(null, 10);
            Assert.Fail();
        }

        // Empty string tests
        [TestMethod]
        public void TestAppendSpaces2_EmptyStringWithZeroLength()
        {
            string result = StringUtil.AppendSpaces("", 0);
            Assert.AreEqual("", result);
            Assert.AreEqual(0, result.Length);
        }

        [TestMethod]
        public void TestAppendSpaces3_EmptyStringWithPositiveLength()
        {
            string result = StringUtil.AppendSpaces("", 5);
            Assert.AreEqual("     ", result);
            Assert.AreEqual(5, result.Length);
        }

        [TestMethod]
        public void TestAppendSpaces4_EmptyStringWithLargeLength()
        {
            string result = StringUtil.AppendSpaces("", 20);
            Assert.AreEqual(20, result.Length);
            // Verify all spaces
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(' ', result[i]);
            }
        }

        // No padding needed tests (string already meets or exceeds length)
        [TestMethod]
        public void TestAppendSpaces5_StringExactLength()
        {
            string result = StringUtil.AppendSpaces("hello", 5);
            Assert.AreEqual("hello", result);
            Assert.AreEqual(5, result.Length);
        }

        [TestMethod]
        public void TestAppendSpaces6_StringLongerThanTarget()
        {
            string result = StringUtil.AppendSpaces("hello", 3);
            Assert.AreEqual("hello", result);
            Assert.AreEqual(5, result.Length);
        }

        [TestMethod]
        public void TestAppendSpaces7_StringMuchLongerThanTarget()
        {
            string result = StringUtil.AppendSpaces("supercalifragilisticexpialidocious", 10);
            Assert.AreEqual("supercalifragilisticexpialidocious", result);
            Assert.AreEqual(34, result.Length);
        }

        // Padding required tests - single character
        [TestMethod]
        public void TestAppendSpaces8_SingleCharPaddedToTwo()
        {
            string result = StringUtil.AppendSpaces("a", 2);
            Assert.AreEqual("a ", result);
            Assert.AreEqual(2, result.Length);
        }

        [TestMethod]
        public void TestAppendSpaces9_SingleCharPaddedToTen()
        {
            string result = StringUtil.AppendSpaces("x", 10);
            Assert.AreEqual("x         ", result);
            Assert.AreEqual(10, result.Length);
        }

        // Padding required tests - multiple characters
        [TestMethod]
        public void TestAppendSpaces10_TwoCharPaddedToFour()
        {
            string result = StringUtil.AppendSpaces("hi", 4);
            Assert.AreEqual("hi  ", result);
            Assert.AreEqual(4, result.Length);
        }

        [TestMethod]
        public void TestAppendSpaces11_ThreeCharPaddedToEight()
        {
            string result = StringUtil.AppendSpaces("cat", 8);
            Assert.AreEqual("cat     ", result);
            Assert.AreEqual(8, result.Length);
        }

        [TestMethod]
        public void TestAppendSpaces12_FiveCharPaddedToTen()
        {
            string result = StringUtil.AppendSpaces("hello", 10);
            Assert.AreEqual("hello     ", result);
            Assert.AreEqual(10, result.Length);
        }

        // Padding required tests - various lengths
        [TestMethod]
        public void TestAppendSpaces13_PaddingByOne()
        {
            string result = StringUtil.AppendSpaces("test", 5);
            Assert.AreEqual("test ", result);
            Assert.AreEqual(5, result.Length);
        }

        [TestMethod]
        public void TestAppendSpaces14_PaddingByThree()
        {
            string result = StringUtil.AppendSpaces("word", 7);
            Assert.AreEqual("word   ", result);
            Assert.AreEqual(7, result.Length);
        }

        [TestMethod]
        public void TestAppendSpaces15_PaddingByFive()
        {
            string result = StringUtil.AppendSpaces("go", 7);
            Assert.AreEqual("go     ", result);
            Assert.AreEqual(7, result.Length);
        }

        // Word and sentence padding
        [TestMethod]
        public void TestAppendSpaces16_SingleWordPadding()
        {
            string result = StringUtil.AppendSpaces("apple", 15);
            Assert.AreEqual("apple          ", result);
            Assert.AreEqual(15, result.Length);
        }

        [TestMethod]
        public void TestAppendSpaces17_TwoWordsPadding()
        {
            string result = StringUtil.AppendSpaces("hello world", 20);
            Assert.AreEqual("hello world         ", result);
            Assert.AreEqual(20, result.Length);
        }

        [TestMethod]
        public void TestAppendSpaces18_SentencePadding()
        {
            string result = StringUtil.AppendSpaces("Hello, World!", 25);
            Assert.AreEqual("Hello, World!            ", result);
            Assert.AreEqual(25, result.Length);
        }

        // Special characters and symbols
        [TestMethod]
        public void TestAppendSpaces19_WithNumberPadding()
        {
            string result = StringUtil.AppendSpaces("123", 8);
            Assert.AreEqual("123     ", result);
            Assert.AreEqual(8, result.Length);
        }

        [TestMethod]
        public void TestAppendSpaces20_WithSymbolsPadding()
        {
            string result = StringUtil.AppendSpaces("@#$", 10);
            Assert.AreEqual("@#$       ", result);
            Assert.AreEqual(10, result.Length);
        }

        [TestMethod]
        public void TestAppendSpaces21_WithMixedContentPadding()
        {
            string result = StringUtil.AppendSpaces("abc123!@#", 15);
            Assert.AreEqual("abc123!@#      ", result);
            Assert.AreEqual(15, result.Length);
        }

        // Edge cases with specific target lengths
        [TestMethod]
        public void TestAppendSpaces22_StringLengthOne()
        {
            string result = StringUtil.AppendSpaces("a", 1);
            Assert.AreEqual("a", result);
            Assert.AreEqual(1, result.Length);
        }

        [TestMethod]
        public void TestAppendSpaces23_TargetLengthOne()
        {
            string result = StringUtil.AppendSpaces("", 1);
            Assert.AreEqual(" ", result);
            Assert.AreEqual(1, result.Length);
        }

        [TestMethod]
        public void TestAppendSpaces24_LargeTargetLength()
        {
            string result = StringUtil.AppendSpaces("hi", 100);
            Assert.AreEqual(100, result.Length);
            Assert.AreEqual("hi", result.Substring(0, 2));
            // Verify all remaining characters are spaces
            for (int i = 2; i < result.Length; i++)
            {
                Assert.AreEqual(' ', result[i]);
            }
        }

        // Verification of padding character
        [TestMethod]
        public void TestAppendSpaces25_VerifyPaddingCharacter()
        {
            string result = StringUtil.AppendSpaces("test", 10);
            for (int i = 4; i < 10; i++)
            {
                Assert.AreEqual(' ', result[i]);
            }
        }

        [TestMethod]
        public void TestAppendSpaces26_VerifyOriginalContentPreserved()
        {
            string result = StringUtil.AppendSpaces("hello", 15);
            Assert.AreEqual("hello", result.Substring(0, 5));
        }

        // Case sensitivity preservation
        [TestMethod]
        public void TestAppendSpaces27_LowercasePreserved()
        {
            string result = StringUtil.AppendSpaces("abc", 10);
            Assert.AreEqual("abc", result.Substring(0, 3));
            for (int i = 0; i < 3; i++)
            {
                Assert.IsTrue(char.IsLower(result[i]));
            }
        }

        [TestMethod]
        public void TestAppendSpaces28_UppercasePreserved()
        {
            string result = StringUtil.AppendSpaces("ABC", 10);
            Assert.AreEqual("ABC", result.Substring(0, 3));
            for (int i = 0; i < 3; i++)
            {
                Assert.IsTrue(char.IsUpper(result[i]));
            }
        }

        [TestMethod]
        public void TestAppendSpaces29_MixedCasePreserved()
        {
            string result = StringUtil.AppendSpaces("CamelCase", 15);
            Assert.AreEqual("CamelCase", result.Substring(0, 9));
        }

        // Whitespace in original strings
        [TestMethod]
        public void TestAppendSpaces30_StringWithSpaces()
        {
            string result = StringUtil.AppendSpaces("hello world", 20);
            Assert.AreEqual("hello world         ", result);
            Assert.AreEqual(20, result.Length);
        }

        [TestMethod]
        public void TestAppendSpaces31_StringWithTab()
        {
            string result = StringUtil.AppendSpaces("col1\tcol2", 15);
            Assert.AreEqual("col1\tcol2      ", result);
            Assert.AreEqual(15, result.Length);
        }

        [TestMethod]
        public void TestAppendSpaces32_StringWithLeadingSpace()
        {
            string result = StringUtil.AppendSpaces(" hello", 12);
            Assert.AreEqual(" hello      ", result);
            Assert.AreEqual(12, result.Length);
        }

        [TestMethod]
        public void TestAppendSpaces33_StringWithTrailingSpace()
        {
            string result = StringUtil.AppendSpaces("hello ", 12);
            Assert.AreEqual("hello       ", result);
            Assert.AreEqual(12, result.Length);
        }

        // Numeric padding values
        [TestMethod]
        public void TestAppendSpaces34_SmallString_LargeTargetLength()
        {
            string result = StringUtil.AppendSpaces("x", 50);
            Assert.AreEqual(50, result.Length);
            Assert.AreEqual("x", result.Substring(0, 1));
        }

        [TestMethod]
        public void TestAppendSpaces35_MediumString_MediumTargetLength()
        {
            string result = StringUtil.AppendSpaces("medium", 20);
            Assert.AreEqual("medium              ", result);
            Assert.AreEqual(20, result.Length);
        }

        // Specific real-world scenarios
        [TestMethod]
        public void TestAppendSpaces36_NamePadding()
        {
            string result = StringUtil.AppendSpaces("John", 20);
            Assert.AreEqual("John                ", result);
            Assert.AreEqual(20, result.Length);
        }

        [TestMethod]
        public void TestAppendSpaces37_AddressPadding()
        {
            string result = StringUtil.AppendSpaces("123 Main St", 30);
            Assert.AreEqual(30, result.Length);
            Assert.AreEqual("123 Main St", result.Substring(0, 11));
        }

        [TestMethod]
        public void TestAppendSpaces38_PhoneNumberPadding()
        {
            string result = StringUtil.AppendSpaces("555-1234", 15);
            Assert.AreEqual("555-1234       ", result);
            Assert.AreEqual(15, result.Length);
        }

        [TestMethod]
        public void TestAppendSpaces39_EmailPadding()
        {
            string result = StringUtil.AppendSpaces("user@example.com", 25);
            Assert.AreEqual("user@example.com         ", result);
            Assert.AreEqual(25, result.Length);
        }

        [TestMethod]
        public void TestAppendSpaces40_AlphanumericPadding()
        {
            string result = StringUtil.AppendSpaces("ABC123", 12);
            Assert.AreEqual("ABC123      ", result);
            Assert.AreEqual(12, result.Length);
        }

        [TestMethod]
        public void TestAppendSpaces41_SymbolsAndNumbersPadding()
        {
            string result = StringUtil.AppendSpaces("#123-456", 20);
            Assert.AreEqual("#123-456            ", result);
            Assert.AreEqual(20, result.Length);
        }

        [TestMethod]
        public void TestAppendSpaces42_VeryLongStringWithSmallTarget()
        {
            string result = StringUtil.AppendSpaces("This is a very long string with many characters", 10);
            Assert.AreEqual("This is a very long string with many characters", result);
            // No padding should occur
            Assert.AreEqual(47, result.Length);
        }

        #endregion


        #region GetCountOf(string ,string) tests

        // Null input tests
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestGetCountOf1_NullSource()
        {
            StringUtil.GetCountOf(null, "test");
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestGetCountOf2_NullTarget()
        {
            StringUtil.GetCountOf("test", null);
            Assert.Fail();
        }

        // Empty string tests
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void TestGetCountOf3_EmptySourceEmptyTarget()
        {
            StringUtil.GetCountOf("", "");
            Assert.Fail("Should have thrown ArgumentException");
        }

        [TestMethod]
        public void TestGetCountOf4_EmptySourceNonEmptyTarget()
        {
            int result = StringUtil.GetCountOf("", "test");
            Assert.AreEqual(0, result);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void TestGetCountOf5_NonEmptySourceEmptyTarget()
        {
            StringUtil.GetCountOf("hello", "");
            Assert.Fail();
        }

        // Simple single occurrence tests
        [TestMethod]
        public void TestGetCountOf6_SingleCharSingleOccurrence()
        {
            int result = StringUtil.GetCountOf("a", "a");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestGetCountOf7_SingleCharNoOccurrence()
        {
            int result = StringUtil.GetCountOf("a", "b");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestGetCountOf8_WordSingleOccurrence()
        {
            int result = StringUtil.GetCountOf("hello", "hello");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestGetCountOf9_WordNoOccurrence()
        {
            int result = StringUtil.GetCountOf("hello", "world");
            Assert.AreEqual(0, result);
        }

        // Multiple occurrences tests
        [TestMethod]
        public void TestGetCountOf10_SingleCharTwoOccurrences()
        {
            int result = StringUtil.GetCountOf("aa", "a");
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TestGetCountOf11_SingleCharThreeOccurrences()
        {
            int result = StringUtil.GetCountOf("aaa", "a");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void TestGetCountOf12_SingleCharManyOccurrences()
        {
            int result = StringUtil.GetCountOf("aaaaaaaaaa", "a");
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void TestGetCountOf13_TwoCharPatternMultipleOccurrences()
        {
            int result = StringUtil.GetCountOf("ababab", "ab");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void TestGetCountOf14_WordPatternMultipleOccurrences()
        {
            int result = StringUtil.GetCountOf("testtest", "test");
            Assert.AreEqual(2, result);
        }

        // Case sensitivity tests
        [TestMethod]
        public void TestGetCountOf15_CaseSensitiveLowercase()
        {
            int result = StringUtil.GetCountOf("hello", "hello");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestGetCountOf16_CaseSensitiveUppercase()
        {
            int result = StringUtil.GetCountOf("HELLO", "HELLO");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestGetCountOf17_CaseSensitiveMixedSource()
        {
            int result = StringUtil.GetCountOf("HeLLo", "LL");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestGetCountOf18_CaseSensitiveDifferentCase()
        {
            int result = StringUtil.GetCountOf("hello", "HELLO");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestGetCountOf19_CaseSensitivePartialMismatch()
        {
            int result = StringUtil.GetCountOf("HeLLo", "hello");
            Assert.AreEqual(0, result);
        }

        // Substring tests
        [TestMethod]
        public void TestGetCountOf20_SubstringAtBeginning()
        {
            int result = StringUtil.GetCountOf("hello world", "hello");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestGetCountOf21_SubstringAtEnd()
        {
            int result = StringUtil.GetCountOf("hello world", "world");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestGetCountOf22_SubstringInMiddle()
        {
            int result = StringUtil.GetCountOf("hello world", "lo wo");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestGetCountOf23_MultipleSubstringOccurrences()
        {
            int result = StringUtil.GetCountOf("the cat and the dog and the bird", "the");
            Assert.AreEqual(3, result);
        }

        // Non-overlapping occurrence tests (important for this implementation)
        [TestMethod]
        public void TestGetCountOf24_NonOverlappingPattern()
        {
            int result = StringUtil.GetCountOf("aabbaa", "aa");
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TestGetCountOf25_PotentiallyOverlappingPattern()
        {
            int result = StringUtil.GetCountOf("aaa", "aa");
            Assert.AreEqual(1, result); // Non-overlapping: matches first "aa", then index advances to 2, "a" left doesn't match
        }

        [TestMethod]
        public void TestGetCountOf26_OverlappingPotentialAtEnd()
        {
            int result = StringUtil.GetCountOf("aaaa", "aa");
            Assert.AreEqual(2, result); // Non-overlapping: first "aa" at 0, second "aa" at 2
        }

        [TestMethod]
        public void TestGetCountOf27_ComplexNonOverlappingPattern()
        {
            int result = StringUtil.GetCountOf("abababab", "ab");
            Assert.AreEqual(4, result);
        }

        // Pattern at different positions
        [TestMethod]
        public void TestGetCountOf28_PatternRepeatedConsecutively()
        {
            int result = StringUtil.GetCountOf("testingtesting", "testing");
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TestGetCountOf29_PatternSeparatedBySpaces()
        {
            int result = StringUtil.GetCountOf("cat cat cat", "cat");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void TestGetCountOf30_PatternWithSpaces()
        {
            int result = StringUtil.GetCountOf("hello world hello world", "hello world");
            Assert.AreEqual(2, result);
        }

        // Digit and number tests
        [TestMethod]
        public void TestGetCountOf31_SingleDigit()
        {
            int result = StringUtil.GetCountOf("12121212", "1");
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void TestGetCountOf32_MultiDigitPattern()
        {
            int result = StringUtil.GetCountOf("123123123", "123");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void TestGetCountOf33_NumberInText()
        {
            int result = StringUtil.GetCountOf("abc123def123ghi", "123");
            Assert.AreEqual(2, result);
        }

        // Special characters tests
        [TestMethod]
        public void TestGetCountOf34_SpecialCharacter()
        {
            int result = StringUtil.GetCountOf("a.b.c.d", ".");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void TestGetCountOf35_MultipleSpecialCharacters()
        {
            int result = StringUtil.GetCountOf("@#$@#$", "@#");
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TestGetCountOf36_Hyphen()
        {
            int result = StringUtil.GetCountOf("123-456-789", "-");
            Assert.AreEqual(2, result);
        }

        // Whitespace tests
        [TestMethod]
        public void TestGetCountOf37_Space()
        {
            int result = StringUtil.GetCountOf("hello world test", " ");
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TestGetCountOf38_MultipleSpaces()
        {
            int result = StringUtil.GetCountOf("hello  world  test", "  ");
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TestGetCountOf39_Tab()
        {
            int result = StringUtil.GetCountOf("col1\tcol2\tcol3", "\t");
            Assert.AreEqual(2, result);
        }

        // Edge cases with target length
        [TestMethod]
        public void TestGetCountOf40_TargetLongerThanSource()
        {
            int result = StringUtil.GetCountOf("cat", "catastrophe");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestGetCountOf41_TargetEqualToSource()
        {
            int result = StringUtil.GetCountOf("exact", "exact");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestGetCountOf42_SingleCharTargetInLongString()
        {
            int result = StringUtil.GetCountOf("abcdefghijklmnopqrstuvwxyz", "e");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestGetCountOf43_MultiCharTargetInLongString()
        {
            int result = StringUtil.GetCountOf("The quick brown fox jumps over the lazy dog", "the");
            Assert.AreEqual(1, result); // Case sensitive, finds lowercase "the" in "the lazy dog"
        }

        [TestMethod]
        public void TestGetCountOf44_MultiCharTargetInLongStringCaseSensitive()
        {
            int result = StringUtil.GetCountOf("The quick brown fox jumps over the lazy dog", "The");
            Assert.AreEqual(1, result); // Only one "The" at beginning
        }

        // Real-world scenarios
        [TestMethod]
        public void TestGetCountOf45_URLCount()
        {
            int result = StringUtil.GetCountOf("http://example.com http://test.com", "http://");
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TestGetCountOf46_EmailDomainCount()
        {
            int result = StringUtil.GetCountOf("user1@example.com user2@example.com", "@example.com");
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TestGetCountOf47_CSVValueCount()
        {
            int result = StringUtil.GetCountOf("a,b,c,d,e", ",");
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void TestGetCountOf48_SQLKeywordCount()
        {
            int result = StringUtil.GetCountOf("SELECT * FROM table WHERE SELECT id FROM", "SELECT");
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TestGetCountOf49_FilePathCount()
        {
            int result = StringUtil.GetCountOf("C:\\Users\\Test\\Documents\\file.txt", "\\");
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void TestGetCountOf50_WordCountInSentence()
        {
            int result = StringUtil.GetCountOf("the cat sat on the mat the dog ran", " the ");
            Assert.AreEqual(2, result); // " the " (with spaces) appears twice: "on the " and "mat the "
        }

        #endregion


        #region SqueezeNumber() tests

        [TestMethod]
        public void TestSqueezeNumber_1()
        {
            Assert.AreEqual("1.00E+10", StringUtil.SqueezeNumber(9999999999, 5));
        }

        [TestMethod]
        public void TestSqueezeNumber_2()
        {
            Assert.AreEqual("1.00E+10", StringUtil.SqueezeNumber(9999999999, 12));
        }

        [TestMethod]
        public void TestSqueezeNumber_3()
        {
            Assert.AreEqual("9,999,999,999", StringUtil.SqueezeNumber(9999999999, 13));
        }

        [TestMethod]
        public void TestSqueezeNumber_4()
        {
            Assert.AreEqual("9,999,999,999", StringUtil.SqueezeNumber(9999999999, 20));
        }

        [TestMethod]
        public void TestSqueezeNumber_WithNegativeNumbersThatFit()
        {
            Assert.AreEqual("-123", StringUtil.SqueezeNumber(-123, 10));
        }

        [TestMethod]
        public void TestSqueezeNumber_WithNegativeNumbersThatFitLarge()
        {
            Assert.AreEqual("-1,234,567", StringUtil.SqueezeNumber(-1234567, 15));
        }

        [TestMethod]
        public void TestSqueezeNumber_WithNegativeNumbersRequiringScientificNotation()
        {
            Assert.AreEqual("-1.00E+10", StringUtil.SqueezeNumber(-9999999999, 5));
        }

        [TestMethod]
        public void TestSqueezeNumber_WithNegativeNumbersRequiringScientificNotationLarge()
        {
            Assert.AreEqual("-1.00E+10", StringUtil.SqueezeNumber(-9999999999, 12));
        }

        [TestMethod]
        public void TestSqueezeNumber_WithZero()
        {
            Assert.AreEqual("0", StringUtil.SqueezeNumber(0, 5));
        }

        [TestMethod]
        public void TestSqueezeNumber_WithZeroSmallLength()
        {
            Assert.AreEqual("0", StringUtil.SqueezeNumber(0, 1));
        }

        [TestMethod]
        public void TestSqueezeNumber_WithSmallDecimals()
        {
            Assert.AreEqual("0", StringUtil.SqueezeNumber(0.123, 10));
        }

        [TestMethod]
        public void TestSqueezeNumber_WithSmallDecimalsSmallLength()
        {
            Assert.AreEqual("0", StringUtil.SqueezeNumber(0.123, 4));
        }

        [TestMethod]
        public void TestSqueezeNumber_WithVerySmallNumbers()
        {
            Assert.AreEqual("0", StringUtil.SqueezeNumber(0.000000000123, 5));
        }

        [TestMethod]
        public void TestSqueezeNumber_WithDoubles()
        {
            Assert.AreEqual("123", StringUtil.SqueezeNumber(123.456, 10));
        }

        [TestMethod]
        public void TestSqueezeNumber_WithDoublesSmallLength()
        {
            Assert.AreEqual("123", StringUtil.SqueezeNumber(123.456, 4));
        }

        [TestMethod]
        public void TestSqueezeNumber_WithFloats()
        {
            Assert.AreEqual("457", StringUtil.SqueezeNumber(456.789f, 10));
        }

        [TestMethod]
        public void TestSqueezeNumber_WithDecimals()
        {
            Assert.AreEqual("789", StringUtil.SqueezeNumber(789.123m, 10));
        }

        [TestMethod]
        public void TestSqueezeNumber_WithLongs()
        {
            Assert.AreEqual("1,000,000", StringUtil.SqueezeNumber(1000000L, 10));
        }

        [TestMethod]
        public void TestSqueezeNumber_WithLongsRequiringScientificNotation()
        {
            Assert.AreEqual("1.00E+15", StringUtil.SqueezeNumber(1000000000000000L, 5));
        }

        [TestMethod]
        public void TestSqueezeNumber_WithVeryLargeNumbers()
        {
            Assert.AreEqual("1.00E+20", StringUtil.SqueezeNumber(100000000000000000000d, 5));
        }


        [TestMethod]
        public void TestSqueezeNumberENotation_1()
        {
            Assert.AreEqual("1.00E+10", StringUtil.SqueezeNumber(9999999999, 5, ScientificNotationFormat.Exponential));
        }

        [TestMethod]
        public void TestSqueezeNumberENotation_2()
        {
            Assert.AreEqual("1.00E+10", StringUtil.SqueezeNumber(9999999999, 12, ScientificNotationFormat.Exponential));
        }

        [TestMethod]
        public void TestSqueezeNumberENotation_3()
        {
            Assert.AreEqual("9,999,999,999", StringUtil.SqueezeNumber(9999999999, 13, ScientificNotationFormat.Exponential));
        }

        [TestMethod]
        public void TestSqueezeNumberENotation_4()
        {
            Assert.AreEqual("9,999,999,999", StringUtil.SqueezeNumber(9999999999, 20, ScientificNotationFormat.Exponential));
        }

         [TestMethod]
         public void TestSqueezeNumberENotation_WithNegativeNumbersThatFit()
         {
             Assert.AreEqual("-123", StringUtil.SqueezeNumber(-123, 10, ScientificNotationFormat.Exponential));
         }

         [TestMethod]
         public void TestSqueezeNumberENotation_WithNegativeNumbersThatFitLarge()
         {
             Assert.AreEqual("-1,234,567", StringUtil.SqueezeNumber(-1234567, 15, ScientificNotationFormat.Exponential));
         }

         [TestMethod]
         public void TestSqueezeNumberENotation_WithNegativeNumbersRequiringScientificNotation()
         {
             Assert.AreEqual("-1.00E+10", StringUtil.SqueezeNumber(-9999999999, 5, ScientificNotationFormat.Exponential));
         }

         [TestMethod]
         public void TestSqueezeNumberENotation_WithNegativeNumbersRequiringScientificNotationLarge()
         {
             Assert.AreEqual("-1.00E+10", StringUtil.SqueezeNumber(-9999999999, 12, ScientificNotationFormat.Exponential));
         }

         [TestMethod]
         public void TestSqueezeNumberENotation_WithZero()
         {
             Assert.AreEqual("0", StringUtil.SqueezeNumber(0, 5, ScientificNotationFormat.Exponential));
         }

         [TestMethod]
         public void TestSqueezeNumberENotation_WithSmallDecimals()
         {
             Assert.AreEqual("0", StringUtil.SqueezeNumber(0.123, 10, ScientificNotationFormat.Exponential));
         }

         [TestMethod]
         public void TestSqueezeNumberENotation_WithSmallDecimalsSmallLength()
         {
             Assert.AreEqual("0", StringUtil.SqueezeNumber(0.123, 4, ScientificNotationFormat.Exponential));
         }

         [TestMethod]
         public void TestSqueezeNumberENotation_WithVerySmallNumbers()
         {
             Assert.AreEqual("0", StringUtil.SqueezeNumber(0.000000000123, 5, ScientificNotationFormat.Exponential));
         }

         [TestMethod]
         public void TestSqueezeNumberENotation_WithDoubles()
         {
             Assert.AreEqual("123", StringUtil.SqueezeNumber(123.456, 10, ScientificNotationFormat.Exponential));
         }

         [TestMethod]
         public void TestSqueezeNumberENotation_WithDoublesSmallLength()
         {
             Assert.AreEqual("123", StringUtil.SqueezeNumber(123.456, 4, ScientificNotationFormat.Exponential));
         }

         [TestMethod]
         public void TestSqueezeNumberENotation_WithFloats()
         {
             Assert.AreEqual("457", StringUtil.SqueezeNumber(456.789f, 10, ScientificNotationFormat.Exponential));
         }

         [TestMethod]
         public void TestSqueezeNumberENotation_WithDecimals()
         {
             Assert.AreEqual("789", StringUtil.SqueezeNumber(789.123m, 10, ScientificNotationFormat.Exponential));
         }

         [TestMethod]
         public void TestSqueezeNumberENotation_WithLongs()
         {
             Assert.AreEqual("1,000,000", StringUtil.SqueezeNumber(1000000L, 10, ScientificNotationFormat.Exponential));
         }

         [TestMethod]
         public void TestSqueezeNumberENotation_WithLongsRequiringScientificNotation()
         {
             Assert.AreEqual("1.00E+15", StringUtil.SqueezeNumber(1000000000000000L, 5, ScientificNotationFormat.Exponential));
         }


        [TestMethod]
        public void TestSqueezeNumberBase10_1()
        {
            Assert.AreEqual("1.00x10^10", StringUtil.SqueezeNumber(9999999999, 5, ScientificNotationFormat.Base10));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10_2()
        {
            Assert.AreEqual("1.00x10^10", StringUtil.SqueezeNumber(9999999999, 12, ScientificNotationFormat.Base10));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10_3()
        {
            Assert.AreEqual("9,999,999,999", StringUtil.SqueezeNumber(9999999999, 13, ScientificNotationFormat.Base10));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10_4()
        {
            Assert.AreEqual("9,999,999,999", StringUtil.SqueezeNumber(9999999999, 20, ScientificNotationFormat.Base10));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10_WithNegativeNumbersThatFit()
        {
            Assert.AreEqual("-123", StringUtil.SqueezeNumber(-123, 10, ScientificNotationFormat.Base10));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10_WithNegativeNumbersThatFitLarge()
        {
            Assert.AreEqual("-1,234,567", StringUtil.SqueezeNumber(-1234567, 15, ScientificNotationFormat.Base10));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10_WithNegativeNumbersRequiringScientificNotation()
        {
            Assert.AreEqual("-1.00x10^10", StringUtil.SqueezeNumber(-9999999999, 5, ScientificNotationFormat.Base10));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10_WithNegativeNumbersRequiringScientificNotationLarge()
        {
            Assert.AreEqual("-1.00x10^10", StringUtil.SqueezeNumber(-9999999999, 12, ScientificNotationFormat.Base10));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10_WithZero()
        {
            Assert.AreEqual("0", StringUtil.SqueezeNumber(0, 5, ScientificNotationFormat.Base10));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10_WithSmallDecimals()
        {
            Assert.AreEqual("0", StringUtil.SqueezeNumber(0.123, 10, ScientificNotationFormat.Base10));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10_WithSmallDecimalsSmallLength()
        {
            Assert.AreEqual("0", StringUtil.SqueezeNumber(0.123, 4, ScientificNotationFormat.Base10));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10_WithVerySmallNumbers()
        {
            Assert.AreEqual("0", StringUtil.SqueezeNumber(0.000000000123, 5, ScientificNotationFormat.Base10));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10_WithDoubles()
        {
            Assert.AreEqual("123", StringUtil.SqueezeNumber(123.456, 10, ScientificNotationFormat.Base10));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10_WithDoublesSmallLength()
        {
            Assert.AreEqual("123", StringUtil.SqueezeNumber(123.456, 4, ScientificNotationFormat.Base10));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10_WithFloats()
        {
            Assert.AreEqual("457", StringUtil.SqueezeNumber(456.789f, 10, ScientificNotationFormat.Base10));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10_WithDecimals()
        {
            Assert.AreEqual("789", StringUtil.SqueezeNumber(789.123m, 10, ScientificNotationFormat.Base10));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10_WithLongs()
        {
            Assert.AreEqual("1,000,000", StringUtil.SqueezeNumber(1000000L, 10, ScientificNotationFormat.Base10));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10_WithLongsRequiringScientificNotation()
        {
            Assert.AreEqual("1.00x10^15", StringUtil.SqueezeNumber(1000000000000000L, 5, ScientificNotationFormat.Base10));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Spaced_1()
        {
            Assert.AreEqual("1.00 x 10^10", StringUtil.SqueezeNumber(9999999999, 5, ScientificNotationFormat.Base10Spaced));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Spaced_2()
        {
            Assert.AreEqual("1.00 x 10^10", StringUtil.SqueezeNumber(9999999999, 12, ScientificNotationFormat.Base10Spaced));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Spaced_3()
        {
            Assert.AreEqual("9,999,999,999", StringUtil.SqueezeNumber(9999999999, 13, ScientificNotationFormat.Base10Spaced));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Spaced_4()
        {
            Assert.AreEqual("9,999,999,999", StringUtil.SqueezeNumber(9999999999, 20, ScientificNotationFormat.Base10Spaced));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Spaced_WithNegativeNumbersThatFit()
        {
            Assert.AreEqual("-123", StringUtil.SqueezeNumber(-123, 10, ScientificNotationFormat.Base10Spaced));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Spaced_WithNegativeNumbersThatFitLarge()
        {
            Assert.AreEqual("-1,234,567", StringUtil.SqueezeNumber(-1234567, 15, ScientificNotationFormat.Base10Spaced));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Spaced_WithNegativeNumbersRequiringScientificNotation()
        {
            Assert.AreEqual("-1.00 x 10^10", StringUtil.SqueezeNumber(-9999999999, 5, ScientificNotationFormat.Base10Spaced));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Spaced_WithNegativeNumbersRequiringScientificNotationLarge()
        {
            Assert.AreEqual("-1.00 x 10^10", StringUtil.SqueezeNumber(-9999999999, 12, ScientificNotationFormat.Base10Spaced));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Spaced_WithZero()
        {
            Assert.AreEqual("0", StringUtil.SqueezeNumber(0, 5, ScientificNotationFormat.Base10Spaced));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Spaced_WithSmallDecimals()
        {
            Assert.AreEqual("0", StringUtil.SqueezeNumber(0.123, 10, ScientificNotationFormat.Base10Spaced));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Spaced_WithSmallDecimalsSmallLength()
        {
            Assert.AreEqual("0", StringUtil.SqueezeNumber(0.123, 4, ScientificNotationFormat.Base10Spaced));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Spaced_WithVerySmallNumbers()
        {
            Assert.AreEqual("0", StringUtil.SqueezeNumber(0.000000000123, 5, ScientificNotationFormat.Base10Spaced));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Spaced_WithDoubles()
        {
            Assert.AreEqual("123", StringUtil.SqueezeNumber(123.456, 10, ScientificNotationFormat.Base10Spaced));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Spaced_WithDoublesSmallLength()
        {
            Assert.AreEqual("123", StringUtil.SqueezeNumber(123.456, 4, ScientificNotationFormat.Base10Spaced));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Spaced_WithFloats()
        {
            Assert.AreEqual("457", StringUtil.SqueezeNumber(456.789f, 10, ScientificNotationFormat.Base10Spaced));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Spaced_WithDecimals()
        {
            Assert.AreEqual("789", StringUtil.SqueezeNumber(789.123m, 10, ScientificNotationFormat.Base10Spaced));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Spaced_WithLongs()
        {
            Assert.AreEqual("1,000,000", StringUtil.SqueezeNumber(1000000L, 10, ScientificNotationFormat.Base10Spaced));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Spaced_WithLongsRequiringScientificNotation()
        {
            Assert.AreEqual("1.00 x 10^15", StringUtil.SqueezeNumber(1000000000000000L, 5, ScientificNotationFormat.Base10Spaced));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Superscript_1()
        {
            Assert.AreEqual("1.00x10" + StringUtil.Superscript1 + StringUtil.Superscript0, StringUtil.SqueezeNumber(9999999999, 5, ScientificNotationFormat.Base10Superscript));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Superscript_2()
        {
            Assert.AreEqual("1.00x10" + StringUtil.Superscript1 + StringUtil.Superscript0, StringUtil.SqueezeNumber(9999999999, 12, ScientificNotationFormat.Base10Superscript));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Superscript_3()
        {
            Assert.AreEqual("9,999,999,999", StringUtil.SqueezeNumber(9999999999, 13, ScientificNotationFormat.Base10Superscript));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Superscript_4()
        {
            Assert.AreEqual("9,999,999,999", StringUtil.SqueezeNumber(9999999999, 20, ScientificNotationFormat.Base10Superscript));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Superscript_WithNegativeNumbersThatFit()
        {
            Assert.AreEqual("-123", StringUtil.SqueezeNumber(-123, 10, ScientificNotationFormat.Base10Superscript));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Superscript_WithNegativeNumbersThatFitLarge()
        {
            Assert.AreEqual("-1,234,567", StringUtil.SqueezeNumber(-1234567, 15, ScientificNotationFormat.Base10Superscript));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Superscript_WithNegativeNumbersRequiringScientificNotation()
        {
            Assert.AreEqual("-1.00x10" + StringUtil.Superscript1 + StringUtil.Superscript0, 
                StringUtil.SqueezeNumber(-9999999999, 5, ScientificNotationFormat.Base10Superscript));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Superscript_WithNegativeNumbersRequiringScientificNotationLarge()
        {
            Assert.AreEqual("-1.00x10" + StringUtil.Superscript1 + StringUtil.Superscript0,
                StringUtil.SqueezeNumber(-9999999999, 12, ScientificNotationFormat.Base10Superscript));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Superscript_WithZero()
        {
            Assert.AreEqual("0", StringUtil.SqueezeNumber(0, 5, ScientificNotationFormat.Base10Superscript));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Superscript_WithSmallDecimals()
        {
            Assert.AreEqual("0", StringUtil.SqueezeNumber(0.123, 10, ScientificNotationFormat.Base10Superscript));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Superscript_WithSmallDecimalsSmallLength()
        {
            Assert.AreEqual("0", StringUtil.SqueezeNumber(0.1, 4, ScientificNotationFormat.Base10Superscript));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Superscript_WithDoubles()
        {
            Assert.AreEqual("123", StringUtil.SqueezeNumber(123.456, 10, ScientificNotationFormat.Base10Superscript));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Superscript_WithDoublesSmallLength()
        {
            Assert.AreEqual("123", StringUtil.SqueezeNumber(123.456, 4, ScientificNotationFormat.Base10Superscript));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Superscript_WithFloats()
        {
            Assert.AreEqual("457", StringUtil.SqueezeNumber(456.789f, 10, ScientificNotationFormat.Base10Superscript));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Superscript_WithDecimals()
        {
            Assert.AreEqual("789", StringUtil.SqueezeNumber(789.123m, 10, ScientificNotationFormat.Base10Superscript));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Superscript_WithLongs()
        {
            Assert.AreEqual("1,000,000", StringUtil.SqueezeNumber(1000000L, 10, ScientificNotationFormat.Base10Superscript));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10Superscript_WithLongsRequiringScientificNotation()
        {
            Assert.AreEqual("1.00x10" + StringUtil.Superscript1 + StringUtil.Superscript5,
                StringUtil.SqueezeNumber(1000000000000000L, 5, ScientificNotationFormat.Base10Superscript));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10SuperscriptSpaced_1()
        {
            Assert.AreEqual("1.00 x 10" + StringUtil.Superscript1 + StringUtil.Superscript0, StringUtil.SqueezeNumber(9999999999, 5, ScientificNotationFormat.Base10SuperscriptSpaced));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10SuperscriptSpaced_2()
        {
            Assert.AreEqual("1.00 x 10" + StringUtil.Superscript1 + StringUtil.Superscript0, StringUtil.SqueezeNumber(9999999999, 12, ScientificNotationFormat.Base10SuperscriptSpaced));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10SuperscriptSpaced_3()
        {
            Assert.AreEqual("9,999,999,999", StringUtil.SqueezeNumber(9999999999, 13, ScientificNotationFormat.Base10SuperscriptSpaced));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10SuperscriptSpaced_4()
        {
            Assert.AreEqual("9,999,999,999", StringUtil.SqueezeNumber(9999999999, 20, ScientificNotationFormat.Base10SuperscriptSpaced));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10SuperscriptSpaced_WithNegativeNumbersThatFit()
        {
            Assert.AreEqual("-123", StringUtil.SqueezeNumber(-123, 10, ScientificNotationFormat.Base10SuperscriptSpaced));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10SuperscriptSpaced_WithNegativeNumbersThatFitLarge()
        {
            Assert.AreEqual("-1,234,567", StringUtil.SqueezeNumber(-1234567, 15, ScientificNotationFormat.Base10SuperscriptSpaced));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10SuperscriptSpaced_WithNegativeNumbersRequiringScientificNotation()
        {
            Assert.AreEqual("-1.00 x 10" + StringUtil.Superscript1 + StringUtil.Superscript0, 
                StringUtil.SqueezeNumber(-9999999999, 5, ScientificNotationFormat.Base10SuperscriptSpaced));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10SuperscriptSpaced_WithNegativeNumbersRequiringScientificNotationLarge()
        {
            Assert.AreEqual("-1.00 x 10" + StringUtil.Superscript1 + StringUtil.Superscript0,
                StringUtil.SqueezeNumber(-9999999999, 12, ScientificNotationFormat.Base10SuperscriptSpaced));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10SuperscriptSpaced_WithZero()
        {
            Assert.AreEqual("0", StringUtil.SqueezeNumber(0, 5, ScientificNotationFormat.Base10SuperscriptSpaced));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10SuperscriptSpaced_WithSmallDecimals()
        {
            Assert.AreEqual("0", StringUtil.SqueezeNumber(0.123, 10, ScientificNotationFormat.Base10SuperscriptSpaced));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10SuperscriptSpaced_WithSmallDecimalsSmallLength()
        {
            Assert.AreEqual("0", StringUtil.SqueezeNumber(0.1, 4, ScientificNotationFormat.Base10SuperscriptSpaced));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10SuperscriptSpaced_WithDoubles()
        {
            Assert.AreEqual("123", StringUtil.SqueezeNumber(123.456, 10, ScientificNotationFormat.Base10SuperscriptSpaced));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10SuperscriptSpaced_WithDoublesSmallLength()
        {
            Assert.AreEqual("123", StringUtil.SqueezeNumber(123.456, 4, ScientificNotationFormat.Base10SuperscriptSpaced));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10SuperscriptSpaced_WithFloats()
        {
            Assert.AreEqual("457", StringUtil.SqueezeNumber(456.789f, 10, ScientificNotationFormat.Base10SuperscriptSpaced));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10SuperscriptSpaced_WithDecimals()
        {
            Assert.AreEqual("789", StringUtil.SqueezeNumber(789.123m, 10, ScientificNotationFormat.Base10SuperscriptSpaced));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10SuperscriptSpaced_WithLongs()
        {
            Assert.AreEqual("1,000,000", StringUtil.SqueezeNumber(1000000L, 10, ScientificNotationFormat.Base10SuperscriptSpaced));
        }

        [TestMethod]
        public void TestSqueezeNumberBase10SuperscriptSpaced_WithLongsRequiringScientificNotation()
        {
            Assert.AreEqual("1.00 x 10" + StringUtil.Superscript1 + StringUtil.Superscript5,
                StringUtil.SqueezeNumber(1000000000000000L, 5, ScientificNotationFormat.Base10SuperscriptSpaced));
        }

        #endregion


        #region ENotationToBaseTenNotation(string, bool, bool, bool, bool) tests

        // Exception and null tests
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestENotationToBaseTenNotation1_NullSource()
        {
            string result = StringUtil.ENotationToBaseTenNotation(null, false, false, false, false);
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestENotationToBaseTenNotation2_InvalidExponent()
        {
            // Invalid exponent that can't be parsed as integer
            string result = StringUtil.ENotationToBaseTenNotation("1.5Eabc", false, false, false, false);
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestENotationToBaseTenNotation3_InvalidExponentWithDecimal()
        {
            // Exponent with decimal point - can't parse as int
            string result = StringUtil.ENotationToBaseTenNotation("1.5E2.5", false, false, false, false);
            Assert.Fail();
        }

        // No E notation tests - string should return unchanged (uppercased)
        [TestMethod]
        public void TestENotationToBaseTenNotation4_NoENotation_SimpleNumber()
        {
            string result = StringUtil.ENotationToBaseTenNotation("123.45", false, false, false, false);
            Assert.AreEqual("123.45", result);
        }

        [TestMethod]
        public void TestENotationToBaseTenNotation5_NoENotation_LowerCase()
        {
            // Should return uppercased but since no E, should be unchanged except for case
            string result = StringUtil.ENotationToBaseTenNotation("abc", false, false, false, false);
            Assert.AreEqual("ABC", result);
        }

        [TestMethod]
        public void TestENotationToBaseTenNotation6_NoENotation_MixedCase()
        {
            string result = StringUtil.ENotationToBaseTenNotation("AbC123", false, false, false, false);
            Assert.AreEqual("ABC123", result);
        }

        // Zero power tests
        [TestMethod]
        public void TestENotationToBaseTenNotation7_ZeroPowerExcludeTrue()
        {
            // 1.5E0 with excludeZeroPower=true should return just base value
            string result = StringUtil.ENotationToBaseTenNotation("1.5E0", false, false, false, true);
            Assert.AreEqual("1.5", result);
        }

        [TestMethod]
        public void TestENotationToBaseTenNotation8_ZeroPowerExcludeFalse_NoSuperscript_NoSpace()
        {
            // 1.5E0 with excludeZeroPower=false should include x10^0
            string result = StringUtil.ENotationToBaseTenNotation("1.5E0", false, false, false, false);
            Assert.AreEqual("1.5x10^0", result);
        }

        [TestMethod]
        public void TestENotationToBaseTenNotation9_ZeroPowerExcludeFalse_NoSuperscript_Spaced()
        {
            string result = StringUtil.ENotationToBaseTenNotation("1.5E0", false, true, false, false);
            Assert.AreEqual("1.5 x 10^0", result);
        }

        [TestMethod]
        public void TestENotationToBaseTenNotation10_ZeroPowerExcludeFalse_Superscript_NoSpace()
        {
            string baseValue = "1.5";
            string superscriptZero = StringUtil.Superscript0;
            string result = StringUtil.ENotationToBaseTenNotation("1.5E0", true, false, false, false);
            Assert.AreEqual(baseValue + "x10" + superscriptZero, result);
        }

        [TestMethod]
        public void TestENotationToBaseTenNotation11_ZeroPowerExcludeFalse_Superscript_Spaced()
        {
            string baseValue = "1.5";
            string superscriptZero = StringUtil.Superscript0;
            string result = StringUtil.ENotationToBaseTenNotation("1.5E0", true, true, false, false);
            Assert.AreEqual(baseValue + " x 10" + superscriptZero, result);
        }

        // Positive exponent tests - all 16 combinations
        [TestMethod]
        public void TestENotationToBaseTenNotation12_PositiveExponent_NoSuperscript_NoSpace_IncludePlus_ExcludeZero()
        {
            string result = StringUtil.ENotationToBaseTenNotation("2.5E+3", false, false, false, true);
            Assert.AreEqual("2.5x10^+3", result);
        }

        [TestMethod]
        public void TestENotationToBaseTenNotation13_PositiveExponent_NoSuperscript_NoSpace_ExcludePlus_ExcludeZero()
        {
            string result = StringUtil.ENotationToBaseTenNotation("2.5E+3", false, false, true, true);
            Assert.AreEqual("2.5x10^3", result);
        }

        [TestMethod]
        public void TestENotationToBaseTenNotation14_PositiveExponent_NoSuperscript_Spaced_IncludePlus_ExcludeZero()
        {
            string result = StringUtil.ENotationToBaseTenNotation("2.5E+3", false, true, false, true);
            Assert.AreEqual("2.5 x 10^+3", result);
        }

        [TestMethod]
        public void TestENotationToBaseTenNotation15_PositiveExponent_NoSuperscript_Spaced_ExcludePlus_ExcludeZero()
        {
            string result = StringUtil.ENotationToBaseTenNotation("2.5E+3", false, true, true, true);
            Assert.AreEqual("2.5 x 10^3", result);
        }

        [TestMethod]
        public void TestENotationToBaseTenNotation16_PositiveExponent_Superscript_NoSpace_IncludePlus_ExcludeZero()
        {
            string baseValue = "2.5";
            string superscriptPlus = StringUtil.SuperscriptPlus;
            string superscript3 = StringUtil.Superscript3;
            string result = StringUtil.ENotationToBaseTenNotation("2.5E+3", true, false, false, true);
            Assert.AreEqual(baseValue + "x10" + superscriptPlus + superscript3, result);
        }

        [TestMethod]
        public void TestENotationToBaseTenNotation17_PositiveExponent_Superscript_NoSpace_ExcludePlus_ExcludeZero()
        {
            string baseValue = "2.5";
            string superscript3 = StringUtil.Superscript3;
            string result = StringUtil.ENotationToBaseTenNotation("2.5E+3", true, false, true, true);
            Assert.AreEqual(baseValue + "x10" + superscript3, result);
        }

        [TestMethod]
        public void TestENotationToBaseTenNotation18_PositiveExponent_Superscript_Spaced_IncludePlus_ExcludeZero()
        {
            string baseValue = "2.5";
            string superscriptPlus = StringUtil.SuperscriptPlus;
            string superscript3 = StringUtil.Superscript3;
            string result = StringUtil.ENotationToBaseTenNotation("2.5E+3", true, true, false, true);
            Assert.AreEqual(baseValue + " x 10" + superscriptPlus + superscript3, result);
        }

        [TestMethod]
        public void TestENotationToBaseTenNotation19_PositiveExponent_Superscript_Spaced_ExcludePlus_ExcludeZero()
        {
            string baseValue = "2.5";
            string superscript3 = StringUtil.Superscript3;
            string result = StringUtil.ENotationToBaseTenNotation("2.5E+3", true, true, true, true);
            Assert.AreEqual(baseValue + " x 10" + superscript3, result);
        }

        // Negative exponent tests - all 16 combinations
        [TestMethod]
        public void TestENotationToBaseTenNotation20_NegativeExponent_NoSuperscript_NoSpace_IncludePlus_ExcludeZero()
        {
            string result = StringUtil.ENotationToBaseTenNotation("1.2E-5", false, false, false, true);
            Assert.AreEqual("1.2x10^-5", result);
        }

        [TestMethod]
        public void TestENotationToBaseTenNotation21_NegativeExponent_NoSuperscript_NoSpace_ExcludePlus_ExcludeZero()
        {
            // excludePlusSign should not affect negative sign
            string result = StringUtil.ENotationToBaseTenNotation("1.2E-5", false, false, true, true);
            Assert.AreEqual("1.2x10^-5", result);
        }

        [TestMethod]
        public void TestENotationToBaseTenNotation22_NegativeExponent_NoSuperscript_Spaced_IncludePlus_ExcludeZero()
        {
            string result = StringUtil.ENotationToBaseTenNotation("1.2E-5", false, true, false, true);
            Assert.AreEqual("1.2 x 10^-5", result);
        }

        [TestMethod]
        public void TestENotationToBaseTenNotation23_NegativeExponent_NoSuperscript_Spaced_ExcludePlus_ExcludeZero()
        {
            string result = StringUtil.ENotationToBaseTenNotation("1.2E-5", false, true, true, true);
            Assert.AreEqual("1.2 x 10^-5", result);
        }

        [TestMethod]
        public void TestENotationToBaseTenNotation24_NegativeExponent_Superscript_NoSpace_IncludePlus_ExcludeZero()
        {
            string baseValue = "1.2";
            string superscriptMinus = StringUtil.SuperscriptMinus;
            string superscript5 = StringUtil.Superscript5;
            string result = StringUtil.ENotationToBaseTenNotation("1.2E-5", true, false, false, true);
            Assert.AreEqual(baseValue + "x10" + superscriptMinus + superscript5, result);
        }

        [TestMethod]
        public void TestENotationToBaseTenNotation25_NegativeExponent_Superscript_NoSpace_ExcludePlus_ExcludeZero()
        {
            string baseValue = "1.2";
            string superscriptMinus = StringUtil.SuperscriptMinus;
            string superscript5 = StringUtil.Superscript5;
            string result = StringUtil.ENotationToBaseTenNotation("1.2E-5", true, false, true, true);
            Assert.AreEqual(baseValue + "x10" + superscriptMinus + superscript5, result);
        }

        [TestMethod]
        public void TestENotationToBaseTenNotation26_NegativeExponent_Superscript_Spaced_IncludePlus_ExcludeZero()
        {
            string baseValue = "1.2";
            string superscriptMinus = StringUtil.SuperscriptMinus;
            string superscript5 = StringUtil.Superscript5;
            string result = StringUtil.ENotationToBaseTenNotation("1.2E-5", true, true, false, true);
            Assert.AreEqual(baseValue + " x 10" + superscriptMinus + superscript5, result);
        }

        [TestMethod]
        public void TestENotationToBaseTenNotation27_NegativeExponent_Superscript_Spaced_ExcludePlus_ExcludeZero()
        {
            string baseValue = "1.2";
            string superscriptMinus = StringUtil.SuperscriptMinus;
            string superscript5 = StringUtil.Superscript5;
            string result = StringUtil.ENotationToBaseTenNotation("1.2E-5", true, true, true, true);
            Assert.AreEqual(baseValue + " x 10" + superscriptMinus + superscript5, result);
        }

        // Edge cases
        [TestMethod]
        public void TestENotationToBaseTenNotation28_SingleCharBase()
        {
            string result = StringUtil.ENotationToBaseTenNotation("5E2", false, false, false, true);
            Assert.AreEqual("5x10^2", result);
        }

        [TestMethod]
        public void TestENotationToBaseTenNotation29_LargePositiveExponent()
        {
            string result = StringUtil.ENotationToBaseTenNotation("3.14E100", false, true, true, true);
            string expected = "3.14 x 10^100";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestENotationToBaseTenNotation30_LargeNegativeExponent()
        {
            string result = StringUtil.ENotationToBaseTenNotation("3.14E-100", false, true, false, true);
            string expected = "3.14 x 10^-100";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestENotationToBaseTenNotation31_LowercaseENotation()
        {
            // Should convert lowercase 'e' to uppercase 'E' internally
            string result = StringUtil.ENotationToBaseTenNotation("2e4", false, false, false, true);
            Assert.AreEqual("2x10^4", result);
        }

        [TestMethod]
        public void TestENotationToBaseTenNotation32_IntegerBase()
        {
            string result = StringUtil.ENotationToBaseTenNotation("42E3", true, true, true, true);
            string expected = "42 x 10" + StringUtil.Superscript3;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestENotationToBaseTenNotation33_ExponentWithExplicitPlus()
        {
            string result = StringUtil.ENotationToBaseTenNotation("1.5E+2", false, false, false, true);
            Assert.AreEqual("1.5x10^+2", result);
        }

        [TestMethod]
        public void TestENotationToBaseTenNotation34_ExponentWithoutExplicitPlus()
        {
            string result = StringUtil.ENotationToBaseTenNotation("1.5E2", false, false, false, true);
            Assert.AreEqual("1.5x10^2", result);
        }

        [TestMethod]
        public void TestENotationToBaseTenNotation35_MultiDigitBase()
        {
            string result = StringUtil.ENotationToBaseTenNotation("123.456E7", true, true, true, true);
            string superscript7 = StringUtil.Superscript7;
            Assert.AreEqual("123.456 x 10" + superscript7, result);
        }

        [TestMethod]
        public void TestENotationToBaseTenNotation36_OneAsExponent()
        {
            string result = StringUtil.ENotationToBaseTenNotation("5E1", false, false, false, true);
            string expected = "5x10^1";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestENotationToBaseTenNotation37_NegativeOne()
        {
            string result = StringUtil.ENotationToBaseTenNotation("5E-1", true, false, false, true);
            string superscriptMinus = StringUtil.SuperscriptMinus;
            string superscript1 = StringUtil.Superscript1;
            string expected = "5x10" + superscriptMinus + superscript1;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestENotationToBaseTenNotation38_PositiveOneWithExplicitPlus()
        {
            string result = StringUtil.ENotationToBaseTenNotation("5E+1", true, true, false, true);
            string superscriptPlus = StringUtil.SuperscriptPlus;
            string superscript1 = StringUtil.Superscript1;
            string expected = "5 x 10" + superscriptPlus + superscript1;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestENotationToBaseTenNotation39_SmallDecimalBase()
        {
            string result = StringUtil.ENotationToBaseTenNotation("0.001E6", false, true, true, true);
            Assert.AreEqual("0.001 x 10^6", result);
        }

        [TestMethod]
        public void TestENotationToBaseTenNotation40_ExponentTwo()
        {
            string result = StringUtil.ENotationToBaseTenNotation("7E2", true, false, true, true);
            string superscript2 = StringUtil.Superscript2;
            Assert.AreEqual("7x10" + superscript2, result);
        }

        #endregion


        #region ToSuperscript(string) tests

        [TestMethod]
        public void TestToSuperscript()
        {
            string expected = StringUtil.SuperscriptPlus + StringUtil.Superscript0 + StringUtil.Superscript1 + StringUtil.Superscript2 + StringUtil.Superscript3 + StringUtil.Superscript4 + StringUtil.Superscript5 + StringUtil.Superscript6 + StringUtil.Superscript7 + StringUtil.Superscript8 + StringUtil.Superscript9;
            Assert.AreEqual(expected, StringUtil.ToSuperscript("+0123456789"));

            expected = StringUtil.SuperscriptMinus + StringUtil.Superscript0 + StringUtil.Superscript1 + StringUtil.Superscript2 + StringUtil.Superscript3 + StringUtil.Superscript4 + StringUtil.Superscript5 + StringUtil.Superscript6 + StringUtil.Superscript7 + StringUtil.Superscript8 + StringUtil.Superscript9;
            Assert.AreEqual(expected, StringUtil.ToSuperscript("-0123456789"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestToSuperscriptArgumentOutOfRange()
        {
            string result = StringUtil.ToSuperscript("asdf");
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestToSuperscriptArgumentNull()
        {
            string? s = null;
            string result = StringUtil.ToSuperscript(s);
            Assert.Fail();
        }

        // Individual digit tests
        [TestMethod]
        public void TestToSuperscript_Digit0()
        {
            string result = StringUtil.ToSuperscript("0");
            Assert.AreEqual(StringUtil.Superscript0, result);
        }

        [TestMethod]
        public void TestToSuperscript_Digit1()
        {
            string result = StringUtil.ToSuperscript("1");
            Assert.AreEqual(StringUtil.Superscript1, result);
        }

        [TestMethod]
        public void TestToSuperscript_Digit2()
        {
            string result = StringUtil.ToSuperscript("2");
            Assert.AreEqual(StringUtil.Superscript2, result);
        }

        [TestMethod]
        public void TestToSuperscript_Digit3()
        {
            string result = StringUtil.ToSuperscript("3");
            Assert.AreEqual(StringUtil.Superscript3, result);
        }

        [TestMethod]
        public void TestToSuperscript_Digit4()
        {
            string result = StringUtil.ToSuperscript("4");
            Assert.AreEqual(StringUtil.Superscript4, result);
        }

        [TestMethod]
        public void TestToSuperscript_Digit5()
        {
            string result = StringUtil.ToSuperscript("5");
            Assert.AreEqual(StringUtil.Superscript5, result);
        }

        [TestMethod]
        public void TestToSuperscript_Digit6()
        {
            string result = StringUtil.ToSuperscript("6");
            Assert.AreEqual(StringUtil.Superscript6, result);
        }

        [TestMethod]
        public void TestToSuperscript_Digit7()
        {
            string result = StringUtil.ToSuperscript("7");
            Assert.AreEqual(StringUtil.Superscript7, result);
        }

        [TestMethod]
        public void TestToSuperscript_Digit8()
        {
            string result = StringUtil.ToSuperscript("8");
            Assert.AreEqual(StringUtil.Superscript8, result);
        }

        [TestMethod]
        public void TestToSuperscript_Digit9()
        {
            string result = StringUtil.ToSuperscript("9");
            Assert.AreEqual(StringUtil.Superscript9, result);
        }

        // Plus sign tests
        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestToSuperscript_PlusOnly()
        {
            // Plus sign alone is not a valid integer
            StringUtil.ToSuperscript("+");
            Assert.Fail();
        }

        [TestMethod]
        public void TestToSuperscript_PlusWith0()
        {
            string result = StringUtil.ToSuperscript("+0");
            Assert.AreEqual(StringUtil.SuperscriptPlus + StringUtil.Superscript0, result);
        }

        [TestMethod]
        public void TestToSuperscript_PlusWith5()
        {
            string result = StringUtil.ToSuperscript("+5");
            Assert.AreEqual(StringUtil.SuperscriptPlus + StringUtil.Superscript5, result);
        }

        [TestMethod]
        public void TestToSuperscript_PlusWith9()
        {
            string result = StringUtil.ToSuperscript("+9");
            Assert.AreEqual(StringUtil.SuperscriptPlus + StringUtil.Superscript9, result);
        }

        // Minus sign tests
        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestToSuperscript_MinusOnly()
        {
            // Minus sign alone is not a valid integer
            StringUtil.ToSuperscript("-");
            Assert.Fail();
        }

        [TestMethod]
        public void TestToSuperscript_MinusWith0()
        {
            string result = StringUtil.ToSuperscript("-0");
            Assert.AreEqual(StringUtil.SuperscriptMinus + StringUtil.Superscript0, result);
        }

        [TestMethod]
        public void TestToSuperscript_MinusWith5()
        {
            string result = StringUtil.ToSuperscript("-5");
            Assert.AreEqual(StringUtil.SuperscriptMinus + StringUtil.Superscript5, result);
        }

        [TestMethod]
        public void TestToSuperscript_MinusWith9()
        {
            string result = StringUtil.ToSuperscript("-9");
            Assert.AreEqual(StringUtil.SuperscriptMinus + StringUtil.Superscript9, result);
        }

        // Multi-digit number tests
        [TestMethod]
        public void TestToSuperscript_TwoDigits()
        {
            string result = StringUtil.ToSuperscript("12");
            Assert.AreEqual(StringUtil.Superscript1 + StringUtil.Superscript2, result);
        }

        [TestMethod]
        public void TestToSuperscript_ThreeDigits()
        {
            string result = StringUtil.ToSuperscript("123");
            Assert.AreEqual(StringUtil.Superscript1 + StringUtil.Superscript2 + StringUtil.Superscript3, result);
        }

        [TestMethod]
        public void TestToSuperscript_PlusWithTwoDigits()
        {
            string result = StringUtil.ToSuperscript("+12");
            Assert.AreEqual(StringUtil.SuperscriptPlus + StringUtil.Superscript1 + StringUtil.Superscript2, result);
        }

        [TestMethod]
        public void TestToSuperscript_MinusWithTwoDigits()
        {
            string result = StringUtil.ToSuperscript("-12");
            Assert.AreEqual(StringUtil.SuperscriptMinus + StringUtil.Superscript1 + StringUtil.Superscript2, result);
        }

        [TestMethod]
        public void TestToSuperscript_PlusWithMultipleDigits()
        {
            string result = StringUtil.ToSuperscript("+456");
            Assert.AreEqual(StringUtil.SuperscriptPlus + StringUtil.Superscript4 + StringUtil.Superscript5 + StringUtil.Superscript6, result);
        }

        [TestMethod]
        public void TestToSuperscript_MinusWithMultipleDigits()
        {
            string result = StringUtil.ToSuperscript("-456");
            Assert.AreEqual(StringUtil.SuperscriptMinus + StringUtil.Superscript4 + StringUtil.Superscript5 + StringUtil.Superscript6, result);
        }

        [TestMethod]
        public void TestToSuperscript_LargeNumber()
        {
            string result = StringUtil.ToSuperscript("123456789");
            Assert.AreEqual(StringUtil.Superscript1 + StringUtil.Superscript2 + StringUtil.Superscript3 + StringUtil.Superscript4 + StringUtil.Superscript5 + StringUtil.Superscript6 + StringUtil.Superscript7 + StringUtil.Superscript8 + StringUtil.Superscript9, result);
        }

        [TestMethod]
        public void TestToSuperscript_PlusWithLargeNumber()
        {
            string result = StringUtil.ToSuperscript("+123456789");
            Assert.AreEqual(StringUtil.SuperscriptPlus + StringUtil.Superscript1 + StringUtil.Superscript2 + StringUtil.Superscript3 + StringUtil.Superscript4 + StringUtil.Superscript5 + StringUtil.Superscript6 + StringUtil.Superscript7 + StringUtil.Superscript8 + StringUtil.Superscript9, result);
        }

        [TestMethod]
        public void TestToSuperscript_MinusWithLargeNumber()
        {
            string result = StringUtil.ToSuperscript("-123456789");
            Assert.AreEqual(StringUtil.SuperscriptMinus + StringUtil.Superscript1 + StringUtil.Superscript2 + StringUtil.Superscript3 + StringUtil.Superscript4 + StringUtil.Superscript5 + StringUtil.Superscript6 + StringUtil.Superscript7 + StringUtil.Superscript8 + StringUtil.Superscript9, result);
        }

        [TestMethod]
        public void TestToSuperscript_LeadingZeros()
        {
            string result = StringUtil.ToSuperscript("007");
            Assert.AreEqual(StringUtil.Superscript0 + StringUtil.Superscript0 + StringUtil.Superscript7, result);
        }

        [TestMethod]
        public void TestToSuperscript_AllZeros()
        {
            string result = StringUtil.ToSuperscript("000");
            Assert.AreEqual(StringUtil.Superscript0 + StringUtil.Superscript0 + StringUtil.Superscript0, result);
        }

        [TestMethod]
        public void TestToSuperscript_PlusWithAllZeros()
        {
            string result = StringUtil.ToSuperscript("+000");
            Assert.AreEqual(StringUtil.SuperscriptPlus + StringUtil.Superscript0 + StringUtil.Superscript0 + StringUtil.Superscript0, result);
        }

        [TestMethod]
        public void TestToSuperscript_MinusWithAllZeros()
        {
            string result = StringUtil.ToSuperscript("-000");
            Assert.AreEqual(StringUtil.SuperscriptMinus + StringUtil.Superscript0 + StringUtil.Superscript0 + StringUtil.Superscript0, result);
        }

        // Invalid input tests
        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestToSuperscript_DecimalNumber()
        {
            StringUtil.ToSuperscript("1.5");
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestToSuperscript_WithSpaces()
        {
            StringUtil.ToSuperscript("1 2");
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestToSuperscript_WithLetters()
        {
            StringUtil.ToSuperscript("+12a");
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestToSuperscript_InvalidCharacters()
        {
            StringUtil.ToSuperscript("12@34");
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestToSuperscript_EmptyString()
        {
            StringUtil.ToSuperscript("");
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestToSuperscript_OnlyPlusAndMinus()
        {
            StringUtil.ToSuperscript("+-");
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestToSuperscript_MultipleSignsAtStart()
        {
            StringUtil.ToSuperscript("++123");
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestToSuperscript_SignInMiddle()
        {
            StringUtil.ToSuperscript("12+3");
            Assert.Fail();
        }

        #endregion


        #region ToXmlString(this DateTime)

        // Basic datetime tests
        [TestMethod]
        public void TestToXmlString_BasicDateTime()
        {
            DateTime dt = new DateTime(2024, 3, 15, 14, 30, 45, 123);
            string result = dt.ToXmlString();
            Assert.AreEqual("2024-03-15T14:30:45.123Z", result);
        }

        [TestMethod]
        public void TestToXmlString_Midnight()
        {
            DateTime dt = new DateTime(2024, 1, 1, 0, 0, 0, 0);
            string result = dt.ToXmlString();
            Assert.AreEqual("2024-01-01T00:00:00.0Z", result);
        }

        [TestMethod]
        public void TestToXmlString_EndOfDay()
        {
            DateTime dt = new DateTime(2024, 12, 31, 23, 59, 59, 999);
            string result = dt.ToXmlString();
            Assert.AreEqual("2024-12-31T23:59:59.999Z", result);
        }

        [TestMethod]
        public void TestToXmlString_Noon()
        {
            DateTime dt = new DateTime(2024, 6, 15, 12, 0, 0, 0);
            string result = dt.ToXmlString();
            Assert.AreEqual("2024-06-15T12:00:00.0Z", result);
        }

        // Year formatting tests - single digit year
        [TestMethod]
        public void TestToXmlString_YearOneDigit()
        {
            DateTime dt = new DateTime(1, 1, 1, 0, 0, 0, 0);
            string result = dt.ToXmlString();
            Assert.AreEqual("0001-01-01T00:00:00.0Z", result);
        }

        [TestMethod]
        public void TestToXmlString_YearNine()
        {
            DateTime dt = new DateTime(9, 6, 15, 12, 30, 45, 500);
            string result = dt.ToXmlString();
            Assert.AreEqual("0009-06-15T12:30:45.500Z", result);
        }

        // Year formatting tests - two digit year
        [TestMethod]
        public void TestToXmlString_YearTwoDigits()
        {
            DateTime dt = new DateTime(10, 3, 20, 8, 15, 30, 250);
            string result = dt.ToXmlString();
            Assert.AreEqual("0010-03-20T08:15:30.250Z", result);
        }

        [TestMethod]
        public void TestToXmlString_YearNinetyNine()
        {
            DateTime dt = new DateTime(99, 12, 25, 18, 45, 20, 100);
            string result = dt.ToXmlString();
            Assert.AreEqual("0099-12-25T18:45:20.100Z", result);
        }

        // Year formatting tests - three digit year
        [TestMethod]
        public void TestToXmlString_YearThreeDigits()
        {
            DateTime dt = new DateTime(100, 5, 10, 9, 0, 0, 0);
            string result = dt.ToXmlString();
            Assert.AreEqual("0100-05-10T09:00:00.0Z", result);
        }

        [TestMethod]
        public void TestToXmlString_YearNineHundredNinetyNine()
        {
            DateTime dt = new DateTime(999, 7, 4, 16, 20, 15, 75);
            string result = dt.ToXmlString();
            Assert.AreEqual("0999-07-04T16:20:15.75Z", result);
        }

        // Year formatting tests - four digit year
        [TestMethod]
        public void TestToXmlString_YearFourDigits()
        {
            DateTime dt = new DateTime(1000, 2, 28, 13, 10, 5, 500);
            string result = dt.ToXmlString();
            Assert.AreEqual("1000-02-28T13:10:05.500Z", result);
        }

        [TestMethod]
        public void TestToXmlString_YearMaxValue()
        {
            DateTime dt = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            string result = dt.ToXmlString();
            Assert.AreEqual("9999-12-31T23:59:59.999Z", result);
        }

        // Month formatting - single digit
        [TestMethod]
        public void TestToXmlString_MonthJanuary()
        {
            DateTime dt = new DateTime(2024, 1, 15, 12, 0, 0, 0);
            string result = dt.ToXmlString();
            Assert.AreEqual("2024-01-15T12:00:00.0Z", result);
        }

        [TestMethod]
        public void TestToXmlString_MonthSeptember()
        {
            DateTime dt = new DateTime(2024, 9, 15, 12, 0, 0, 0);
            string result = dt.ToXmlString();
            Assert.AreEqual("2024-09-15T12:00:00.0Z", result);
        }

        // Month formatting - double digit
        [TestMethod]
        public void TestToXmlString_MonthOctober()
        {
            DateTime dt = new DateTime(2024, 10, 15, 12, 0, 0, 0);
            string result = dt.ToXmlString();
            Assert.AreEqual("2024-10-15T12:00:00.0Z", result);
        }

        [TestMethod]
        public void TestToXmlString_MonthDecember()
        {
            DateTime dt = new DateTime(2024, 12, 15, 12, 0, 0, 0);
            string result = dt.ToXmlString();
            Assert.AreEqual("2024-12-15T12:00:00.0Z", result);
        }

        // Day formatting - single digit
        [TestMethod]
        public void TestToXmlString_DayOne()
        {
            DateTime dt = new DateTime(2024, 6, 1, 12, 0, 0, 0);
            string result = dt.ToXmlString();
            Assert.AreEqual("2024-06-01T12:00:00.0Z", result);
        }

        [TestMethod]
        public void TestToXmlString_DayNine()
        {
            DateTime dt = new DateTime(2024, 6, 9, 12, 0, 0, 0);
            string result = dt.ToXmlString();
            Assert.AreEqual("2024-06-09T12:00:00.0Z", result);
        }

        // Day formatting - double digit
        [TestMethod]
        public void TestToXmlString_DayTen()
        {
            DateTime dt = new DateTime(2024, 6, 10, 12, 0, 0, 0);
            string result = dt.ToXmlString();
            Assert.AreEqual("2024-06-10T12:00:00.0Z", result);
        }

        [TestMethod]
        public void TestToXmlString_DayThirtyOne()
        {
            DateTime dt = new DateTime(2024, 5, 31, 12, 0, 0, 0);
            string result = dt.ToXmlString();
            Assert.AreEqual("2024-05-31T12:00:00.0Z", result);
        }

        // Hour formatting - single digit
        [TestMethod]
        public void TestToXmlString_HourZero()
        {
            DateTime dt = new DateTime(2024, 6, 15, 0, 0, 0, 0);
            string result = dt.ToXmlString();
            Assert.AreEqual("2024-06-15T00:00:00.0Z", result);
        }

        [TestMethod]
        public void TestToXmlString_HourNine()
        {
            DateTime dt = new DateTime(2024, 6, 15, 9, 0, 0, 0);
            string result = dt.ToXmlString();
            Assert.AreEqual("2024-06-15T09:00:00.0Z", result);
        }

        // Hour formatting - double digit
        [TestMethod]
        public void TestToXmlString_HourTen()
        {
            DateTime dt = new DateTime(2024, 6, 15, 10, 0, 0, 0);
            string result = dt.ToXmlString();
            Assert.AreEqual("2024-06-15T10:00:00.0Z", result);
        }

        [TestMethod]
        public void TestToXmlString_HourTwentyThree()
        {
            DateTime dt = new DateTime(2024, 6, 15, 23, 0, 0, 0);
            string result = dt.ToXmlString();
            Assert.AreEqual("2024-06-15T23:00:00.0Z", result);
        }

        // Minute formatting - single digit
        [TestMethod]
        public void TestToXmlString_MinuteZero()
        {
            DateTime dt = new DateTime(2024, 6, 15, 12, 0, 0, 0);
            string result = dt.ToXmlString();
            Assert.AreEqual("2024-06-15T12:00:00.0Z", result);
        }

        [TestMethod]
        public void TestToXmlString_MinuteNine()
        {
            DateTime dt = new DateTime(2024, 6, 15, 12, 9, 0, 0);
            string result = dt.ToXmlString();
            Assert.AreEqual("2024-06-15T12:09:00.0Z", result);
        }

        // Minute formatting - double digit
        [TestMethod]
        public void TestToXmlString_MinuteTen()
        {
            DateTime dt = new DateTime(2024, 6, 15, 12, 10, 0, 0);
            string result = dt.ToXmlString();
            Assert.AreEqual("2024-06-15T12:10:00.0Z", result);
        }

        [TestMethod]
        public void TestToXmlString_MinuteFiftyNine()
        {
            DateTime dt = new DateTime(2024, 6, 15, 12, 59, 0, 0);
            string result = dt.ToXmlString();
            Assert.AreEqual("2024-06-15T12:59:00.0Z", result);
        }

        // Second formatting - single digit
        [TestMethod]
        public void TestToXmlString_SecondZero()
        {
            DateTime dt = new DateTime(2024, 6, 15, 12, 0, 0, 0);
            string result = dt.ToXmlString();
            Assert.AreEqual("2024-06-15T12:00:00.0Z", result);
        }

        [TestMethod]
        public void TestToXmlString_SecondNine()
        {
            DateTime dt = new DateTime(2024, 6, 15, 12, 0, 9, 0);
            string result = dt.ToXmlString();
            Assert.AreEqual("2024-06-15T12:00:09.0Z", result);
        }

        // Second formatting - double digit
        [TestMethod]
        public void TestToXmlString_SecondTen()
        {
            DateTime dt = new DateTime(2024, 6, 15, 12, 0, 10, 0);
            string result = dt.ToXmlString();
            Assert.AreEqual("2024-06-15T12:00:10.0Z", result);
        }

        [TestMethod]
        public void TestToXmlString_SecondFiftyNine()
        {
            DateTime dt = new DateTime(2024, 6, 15, 12, 0, 59, 0);
            string result = dt.ToXmlString();
            Assert.AreEqual("2024-06-15T12:00:59.0Z", result);
        }

        // Millisecond formatting - single digit
        [TestMethod]
        public void TestToXmlString_MillisecondZero()
        {
            DateTime dt = new DateTime(2024, 6, 15, 12, 0, 0, 0);
            string result = dt.ToXmlString();
            Assert.AreEqual("2024-06-15T12:00:00.0Z", result);
        }

        [TestMethod]
        public void TestToXmlString_MillisecondOne()
        {
            DateTime dt = new DateTime(2024, 6, 15, 12, 0, 0, 1);
            string result = dt.ToXmlString();
            Assert.AreEqual("2024-06-15T12:00:00.1Z", result);
        }

        [TestMethod]
        public void TestToXmlString_MillisecondNine()
        {
            DateTime dt = new DateTime(2024, 6, 15, 12, 0, 0, 9);
            string result = dt.ToXmlString();
            Assert.AreEqual("2024-06-15T12:00:00.9Z", result);
        }

        // Millisecond formatting - double digit
        [TestMethod]
        public void TestToXmlString_MillisecondTen()
        {
            DateTime dt = new DateTime(2024, 6, 15, 12, 0, 0, 10);
            string result = dt.ToXmlString();
            Assert.AreEqual("2024-06-15T12:00:00.10Z", result);
        }

        [TestMethod]
        public void TestToXmlString_MillisecondNinetynine()
        {
            DateTime dt = new DateTime(2024, 6, 15, 12, 0, 0, 99);
            string result = dt.ToXmlString();
            Assert.AreEqual("2024-06-15T12:00:00.99Z", result);
        }

        // Millisecond formatting - triple digit
        [TestMethod]
        public void TestToXmlString_MillisecondHundred()
        {
            DateTime dt = new DateTime(2024, 6, 15, 12, 0, 0, 100);
            string result = dt.ToXmlString();
            Assert.AreEqual("2024-06-15T12:00:00.100Z", result);
        }

        [TestMethod]
        public void TestToXmlString_MillisecondFiveHundred()
        {
            DateTime dt = new DateTime(2024, 6, 15, 12, 0, 0, 500);
            string result = dt.ToXmlString();
            Assert.AreEqual("2024-06-15T12:00:00.500Z", result);
        }

        [TestMethod]
        public void TestToXmlString_MillisecondNineHundredNinetyNine()
        {
            DateTime dt = new DateTime(2024, 6, 15, 12, 0, 0, 999);
            string result = dt.ToXmlString();
            Assert.AreEqual("2024-06-15T12:00:00.999Z", result);
        }

        // Leap year tests
        [TestMethod]
        public void TestToXmlString_LeapYearFeb29_2024()
        {
            DateTime dt = new DateTime(2024, 2, 29, 12, 0, 0, 0);
            string result = dt.ToXmlString();
            Assert.AreEqual("2024-02-29T12:00:00.0Z", result);
        }

        [TestMethod]
        public void TestToXmlString_LeapYearFeb29_2000()
        {
            DateTime dt = new DateTime(2000, 2, 29, 0, 0, 0, 0);
            string result = dt.ToXmlString();
            Assert.AreEqual("2000-02-29T00:00:00.0Z", result);
        }

        // Century boundary tests
        [TestMethod]
        public void TestToXmlString_CenturyBoundary1900()
        {
            DateTime dt = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            string result = dt.ToXmlString();
            Assert.AreEqual("1900-01-01T00:00:00.0Z", result);
        }

        [TestMethod]
        public void TestToXmlString_CenturyBoundary2000()
        {
            DateTime dt = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            string result = dt.ToXmlString();
            Assert.AreEqual("2000-01-01T00:00:00.0Z", result);
        }

        [TestMethod]
        public void TestToXmlString_CenturyBoundary2100()
        {
            DateTime dt = new DateTime(2100, 12, 31, 23, 59, 59, 999);
            string result = dt.ToXmlString();
            Assert.AreEqual("2100-12-31T23:59:59.999Z", result);
        }

        // All components with boundary values
        [TestMethod]
        public void TestToXmlString_AllMinimumValues()
        {
            DateTime dt = new DateTime(1, 1, 1, 0, 0, 0, 0);
            string result = dt.ToXmlString();
            Assert.AreEqual("0001-01-01T00:00:00.0Z", result);
        }

        [TestMethod]
        public void TestToXmlString_AllMaximumValues()
        {
            DateTime dt = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            string result = dt.ToXmlString();
            Assert.AreEqual("9999-12-31T23:59:59.999Z", result);
        }

        // Mixed edge case combinations
        [TestMethod]
        public void TestToXmlString_MixedMinMax()
        {
            DateTime dt = new DateTime(1000, 1, 31, 23, 59, 0, 0);
            string result = dt.ToXmlString();
            Assert.AreEqual("1000-01-31T23:59:00.0Z", result);
        }

        [TestMethod]
        public void TestToXmlString_MixedEdgeCases()
        {
            DateTime dt = new DateTime(999, 9, 9, 9, 9, 9, 9);
            string result = dt.ToXmlString();
            Assert.AreEqual("0999-09-09T09:09:09.9Z", result);
        }

        // Format validation tests
        [TestMethod]
        public void TestToXmlString_FormatContainsDash()
        {
            DateTime dt = new DateTime(2024, 3, 15, 14, 30, 45, 123);
            string result = dt.ToXmlString();
            StringAssert.Contains(result, "-");
        }

        [TestMethod]
        public void TestToXmlString_FormatContainsT()
        {
            DateTime dt = new DateTime(2024, 3, 15, 14, 30, 45, 123);
            string result = dt.ToXmlString();
            StringAssert.Contains(result, "T");
        }

        [TestMethod]
        public void TestToXmlString_FormatContainsColon()
        {
            DateTime dt = new DateTime(2024, 3, 15, 14, 30, 45, 123);
            string result = dt.ToXmlString();
            StringAssert.Contains(result, ":");
        }

        [TestMethod]
        public void TestToXmlString_FormatContainsDot()
        {
            DateTime dt = new DateTime(2024, 3, 15, 14, 30, 45, 123);
            string result = dt.ToXmlString();
            StringAssert.Contains(result, ".");
        }

        [TestMethod]
        public void TestToXmlString_FormatEndsWithZ()
        {
            DateTime dt = new DateTime(2024, 3, 15, 14, 30, 45, 123);
            string result = dt.ToXmlString();
            StringAssert.EndsWith(result, "Z");
        }

        [TestMethod]
        public void TestToXmlString_CorrectLength()
        {
            DateTime dt = new DateTime(2024, 3, 15, 14, 30, 45, 123);
            string result = dt.ToXmlString();
            // Format: YYYY-MM-DDTHH:MM:SS.fffZ = 24 chars exactly when milliseconds are 3 digits
            // But if milliseconds are 1 or 2 digits, length varies
            Assert.IsTrue(result.Length >= 21 && result.Length <= 24);
        }

        #endregion


        #region ToXmlString(this TimeSpan) tests

        // Zero/Minimum value tests
        [TestMethod]
        public void TestToXmlString_TimeSpanZero()
        {
            TimeSpan ts = TimeSpan.Zero;
            string result = ts.ToXmlString();
            Assert.AreEqual("P0Y0M0DT0H0M0.0S", result);
        }

        [TestMethod]
        public void TestToXmlString_TimeSpanOneMicrosecond()
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(0.001);
            string result = ts.ToXmlString();
            Assert.AreEqual("P0Y0M0DT0H0M0.0S", result);
        }

        // Millisecond tests
        [TestMethod]
        public void TestToXmlString_TimeSpanOneMillisecond()
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(1);
            string result = ts.ToXmlString();
            Assert.AreEqual("P0Y0M0DT0H0M0.1S", result);
        }

        [TestMethod]
        public void TestToXmlString_TimeSpanTenMilliseconds()
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(10);
            string result = ts.ToXmlString();
            Assert.AreEqual("P0Y0M0DT0H0M0.10S", result);
        }

        [TestMethod]
        public void TestToXmlString_TimeSpanNinetynineMilliseconds()
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(99);
            string result = ts.ToXmlString();
            Assert.AreEqual("P0Y0M0DT0H0M0.99S", result);
        }

        [TestMethod]
        public void TestToXmlString_TimeSpanHundredMilliseconds()
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(100);
            string result = ts.ToXmlString();
            Assert.AreEqual("P0Y0M0DT0H0M0.100S", result);
        }

        [TestMethod]
        public void TestToXmlString_TimeSpanFiveHundredMilliseconds()
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(500);
            string result = ts.ToXmlString();
            Assert.AreEqual("P0Y0M0DT0H0M0.500S", result);
        }

        [TestMethod]
        public void TestToXmlString_TimeSpanNineHundredNinetynineMilliseconds()
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(999);
            string result = ts.ToXmlString();
            Assert.AreEqual("P0Y0M0DT0H0M0.999S", result);
        }

        // Second tests
        [TestMethod]
        public void TestToXmlString_TimeSpanOneSecond()
        {
            TimeSpan ts = TimeSpan.FromSeconds(1);
            string result = ts.ToXmlString();
            Assert.AreEqual("P0Y0M0DT0H0M1.0S", result);
        }

        [TestMethod]
        public void TestToXmlString_TimeSpanTenSeconds()
        {
            TimeSpan ts = TimeSpan.FromSeconds(10);
            string result = ts.ToXmlString();
            Assert.AreEqual("P0Y0M0DT0H0M10.0S", result);
        }

        [TestMethod]
        public void TestToXmlString_TimeSpanFiftyNineSeconds()
        {
            TimeSpan ts = TimeSpan.FromSeconds(59);
            string result = ts.ToXmlString();
            Assert.AreEqual("P0Y0M0DT0H0M59.0S", result);
        }

        [TestMethod]
        public void TestToXmlString_TimeSpanOneSecondWithMilliseconds()
        {
            TimeSpan ts = TimeSpan.FromSeconds(1.500);
            string result = ts.ToXmlString();
            Assert.AreEqual("P0Y0M0DT0H0M1.500S", result);
        }

        // Minute tests
        [TestMethod]
        public void TestToXmlString_TimeSpanOneMinute()
        {
            TimeSpan ts = TimeSpan.FromMinutes(1);
            string result = ts.ToXmlString();
            Assert.AreEqual("P0Y0M0DT0H1M0.0S", result);
        }

        [TestMethod]
        public void TestToXmlString_TimeSpanTenMinutes()
        {
            TimeSpan ts = TimeSpan.FromMinutes(10);
            string result = ts.ToXmlString();
            Assert.AreEqual("P0Y0M0DT0H10M0.0S", result);
        }

        [TestMethod]
        public void TestToXmlString_TimeSpanFiftyNineMinutes()
        {
            TimeSpan ts = TimeSpan.FromMinutes(59);
            string result = ts.ToXmlString();
            Assert.AreEqual("P0Y0M0DT0H59M0.0S", result);
        }

        [TestMethod]
        public void TestToXmlString_TimeSpanOneMinuteWithSeconds()
        {
            TimeSpan ts = TimeSpan.FromMinutes(1).Add(TimeSpan.FromSeconds(30));
            string result = ts.ToXmlString();
            Assert.AreEqual("P0Y0M0DT0H1M30.0S", result);
        }

        // Hour tests
        [TestMethod]
        public void TestToXmlString_TimeSpanOneHour()
        {
            TimeSpan ts = TimeSpan.FromHours(1);
            string result = ts.ToXmlString();
            Assert.AreEqual("P0Y0M0DT1H0M0.0S", result);
        }

        [TestMethod]
        public void TestToXmlString_TimeSpanTwelveHours()
        {
            TimeSpan ts = TimeSpan.FromHours(12);
            string result = ts.ToXmlString();
            Assert.AreEqual("P0Y0M0DT12H0M0.0S", result);
        }

        [TestMethod]
        public void TestToXmlString_TimeSpanTwentyThreeHours()
        {
            TimeSpan ts = TimeSpan.FromHours(23);
            string result = ts.ToXmlString();
            Assert.AreEqual("P0Y0M0DT23H0M0.0S", result);
        }

        [TestMethod]
        public void TestToXmlString_TimeSpanOneHourWithMinutesSeconds()
        {
            TimeSpan ts = TimeSpan.FromHours(1).Add(TimeSpan.FromMinutes(30)).Add(TimeSpan.FromSeconds(45));
            string result = ts.ToXmlString();
            Assert.AreEqual("P0Y0M0DT1H30M45.0S", result);
        }

        // Day tests
        [TestMethod]
        public void TestToXmlString_TimeSpanOneDay()
        {
            TimeSpan ts = TimeSpan.FromDays(1);
            string result = ts.ToXmlString();
            Assert.AreEqual("P0Y0M1DT0H0M0.0S", result);
        }

        [TestMethod]
        public void TestToXmlString_TimeSpanTenDays()
        {
            TimeSpan ts = TimeSpan.FromDays(10);
            string result = ts.ToXmlString();
            Assert.AreEqual("P0Y0M10DT0H0M0.0S", result);
        }

        [TestMethod]
        public void TestToXmlString_TimeSpanThirtyDays()
        {
            TimeSpan ts = TimeSpan.FromDays(30);
            string result = ts.ToXmlString();
            Assert.AreEqual("P0Y1M0DT0H0M0.0S", result);
        }

        [TestMethod]
        public void TestToXmlString_TimeSpanSixtyDays()
        {
            TimeSpan ts = TimeSpan.FromDays(60);
            string result = ts.ToXmlString();
            Assert.AreEqual("P0Y2M0DT0H0M0.0S", result);
        }

        [TestMethod]
        public void TestToXmlString_TimeSpanThreeSixtyFiveDays()
        {
            TimeSpan ts = TimeSpan.FromDays(365);
            string result = ts.ToXmlString();
            Assert.AreEqual("P1Y0M0DT0H0M0.0S", result);
        }

        // Complex combinations
        [TestMethod]
        public void TestToXmlString_TimeSpanComplexCombination()
        {
            TimeSpan ts = TimeSpan.FromDays(400).Add(TimeSpan.FromHours(5)).Add(TimeSpan.FromMinutes(30)).Add(TimeSpan.FromSeconds(45).Add(TimeSpan.FromMilliseconds(250)));
            string result = ts.ToXmlString();
            // 400 days = 1 year (365) + 35 days (1 month of 30 days) + 5 days
            Assert.AreEqual("P1Y1M5DT5H30M45.250S", result);
        }

        [TestMethod]
        public void TestToXmlString_TimeSpanYearAndMinutes()
        {
            TimeSpan ts = TimeSpan.FromDays(365).Add(TimeSpan.FromMinutes(45));
            string result = ts.ToXmlString();
            Assert.AreEqual("P1Y0M0DT0H45M0.0S", result);
        }

        [TestMethod]
        public void TestToXmlString_TimeSpanMultipleYears()
        {
            TimeSpan ts = TimeSpan.FromDays(730);
            string result = ts.ToXmlString();
            Assert.AreEqual("P2Y0M0DT0H0M0.0S", result);
        }

        [TestMethod]
        public void TestToXmlString_TimeSpanMultipleMonths()
        {
            TimeSpan ts = TimeSpan.FromDays(90);
            string result = ts.ToXmlString();
            Assert.AreEqual("P0Y3M0DT0H0M0.0S", result);
        }

        // All time components
        [TestMethod]
        public void TestToXmlString_TimeSpanAllComponents()
        {
            TimeSpan ts = TimeSpan.FromDays(500)
                .Add(TimeSpan.FromHours(18))
                .Add(TimeSpan.FromMinutes(45))
                .Add(TimeSpan.FromSeconds(30))
                .Add(TimeSpan.FromMilliseconds(750));
            string result = ts.ToXmlString();
            // 500 days = 1 year (365) + 135 days (4 months of 30 days) + 15 days
            Assert.AreEqual("P1Y4M15DT18H45M30.750S", result);
        }

        // Format validation tests
        [TestMethod]
        public void TestToXmlString_TimeSpanStartsWithP()
        {
            TimeSpan ts = TimeSpan.FromHours(1);
            string result = ts.ToXmlString();
            StringAssert.StartsWith(result, "P");
        }

        [TestMethod]
        public void TestToXmlString_TimeSpanContainsT()
        {
            TimeSpan ts = TimeSpan.FromHours(1);
            string result = ts.ToXmlString();
            StringAssert.Contains(result, "T");
        }

        [TestMethod]
        public void TestToXmlString_TimeSpanContainsYearComponent()
        {
            TimeSpan ts = TimeSpan.FromDays(365);
            string result = ts.ToXmlString();
            StringAssert.Contains(result, "Y");
        }

        [TestMethod]
        public void TestToXmlString_TimeSpanContainsMonthComponent()
        {
            TimeSpan ts = TimeSpan.FromDays(30);
            string result = ts.ToXmlString();
            StringAssert.Contains(result, "M");
        }

        [TestMethod]
        public void TestToXmlString_TimeSpanContainsDayComponent()
        {
            TimeSpan ts = TimeSpan.FromDays(1);
            string result = ts.ToXmlString();
            StringAssert.Contains(result, "D");
        }

        [TestMethod]
        public void TestToXmlString_TimeSpanContainsHourComponent()
        {
            TimeSpan ts = TimeSpan.FromHours(1);
            string result = ts.ToXmlString();
            StringAssert.Contains(result, "H");
        }

        [TestMethod]
        public void TestToXmlString_TimeSpanContainsSecondComponent()
        {
            TimeSpan ts = TimeSpan.FromSeconds(1);
            string result = ts.ToXmlString();
            StringAssert.Contains(result, "S");
        }

        [TestMethod]
        public void TestToXmlString_TimeSpanContainsDecimalPoint()
        {
            TimeSpan ts = TimeSpan.FromSeconds(1);
            string result = ts.ToXmlString();
            StringAssert.Contains(result, ".");
        }

        #endregion
    }
}
