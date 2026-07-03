// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Globalization;
using AwesomeAssertions;
using Xunit;
using StarThrower.MathUtilities;

namespace StarThrower.MathUtilities.Test
{
    public class MathUtilTest
    {
        #region IsNumeric() tests

        [Fact]
        public void TestIsNumeric1()
        {
            (MathUtil.IsNumeric("asdf")).Should().Be(false);
        }

        [Fact]
        public void TestIsNumeric2()
        {
            (MathUtil.IsNumeric("one")).Should().Be(false);
        }

        [Fact]
        public void TestIsNumeric3()
        {
            (MathUtil.IsNumeric("1a")).Should().Be(false);
        }

        [Fact]
        public void TestIsNumeric4()
        {
            (MathUtil.IsNumeric("12345.asdf")).Should().Be(false);
        }

        [Fact]
        public void TestIsNumeric5()
        {
            (MathUtil.IsNumeric("0")).Should().Be(true);
        }

        [Fact]
        public void TestIsNumeric6()
        {
            (MathUtil.IsNumeric("00000")).Should().Be(true);
        }

        [Fact]
        public void TestIsNumeric7()
        {
            (MathUtil.IsNumeric("0.0")).Should().Be(true);
        }

        [Fact]
        public void TestIsNumeric8()
        {
            (MathUtil.IsNumeric("-0")).Should().Be(true);
        }

        [Fact]
        public void TestIsNumeric9()
        {
            (MathUtil.IsNumeric("-00000")).Should().Be(true);
        }

        [Fact]
        public void TestIsNumeric10()
        {
            (MathUtil.IsNumeric("-0.0")).Should().Be(true);
        }

        [Fact]
        public void TestIsNumeric11()
        {
            (MathUtil.IsNumeric("+0")).Should().Be(true);
        }

        [Fact]
        public void TestIsNumeric12()
        {
            (MathUtil.IsNumeric("+00000")).Should().Be(true);
        }

        [Fact]
        public void TestIsNumeric13()
        {
            (MathUtil.IsNumeric("+0.0")).Should().Be(true);
        }

        [Fact]
        public void TestIsNumeric14()
        {
            (MathUtil.IsNumeric("1")).Should().Be(true);
        }

        [Fact]
        public void TestIsNumeric15()
        {
            (MathUtil.IsNumeric("+1")).Should().Be(true);
        }

        [Fact]
        public void TestIsNumeric16()
        {
            (MathUtil.IsNumeric("1.0")).Should().Be(true);
        }

        [Fact]
        public void TestIsNumeric17()
        {
            (MathUtil.IsNumeric("+1.0")).Should().Be(true);
        }

        [Fact]
        public void TestIsNumeric18()
        {
            (MathUtil.IsNumeric("0.1")).Should().Be(true);
        }

        [Fact]
        public void TestIsNumeric19()
        {
            (MathUtil.IsNumeric("+0.1")).Should().Be(true);
        }

        [Fact]
        public void TestIsNumeric20()
        {
            (MathUtil.IsNumeric("1.2")).Should().Be(true);
        }

        [Fact]
        public void TestIsNumeric21()
        {
            (MathUtil.IsNumeric("+1.2")).Should().Be(true);
        }

        [Fact]
        public void TestIsNumeric22()
        {
            (MathUtil.IsNumeric("12345")).Should().Be(true);
        }

        [Fact]
        public void TestIsNumeric23()
        {
            (MathUtil.IsNumeric("+12345")).Should().Be(true);
        }

        [Fact]
        public void TestIsNumeric24()
        {
            (MathUtil.IsNumeric("12345.12345")).Should().Be(true);
        }

        [Fact]
        public void TestIsNumeric25()
        {
            (MathUtil.IsNumeric("+12345.12345")).Should().Be(true);
        }

        [Fact]
        public void TestIsNumeric26()
        {
            (MathUtil.IsNumeric("-1")).Should().Be(true);
        }

        [Fact]
        public void TestIsNumeric27()
        {
            (MathUtil.IsNumeric("-1.0")).Should().Be(true);
        }

        [Fact]
        public void TestIsNumeric28()
        {
            (MathUtil.IsNumeric("-0.1")).Should().Be(true);
        }

        [Fact]
        public void TestIsNumeric29()
        {
            (MathUtil.IsNumeric("-1.2")).Should().Be(true);
        }

        [Fact]
        public void TestIsNumeric30()
        {
            (MathUtil.IsNumeric("-12345")).Should().Be(true);
        }

        [Fact]
        public void TestIsNumeric31()
        {
            (MathUtil.IsNumeric("-12345.12345")).Should().Be(true);
        }

        [Fact]
        public void TestIsNumeric32()
        {
            //When run against Microsoft.VisualBasic.IsNumeric(), this test breaks
            //therefore I am going to assume that it is an invalid case and check for the
            //false condition instead.  If Microsoft doesn't accept this case as a valid
            //numeric string, then I don't need to either.
            //(MathUtil.IsNumeric("+-+-+-+++-1234")).Should().Be(true);

            //As double.TryParse() fails in this situation, it seems appropriate that IsNumeric should also fail.
            (MathUtil.IsNumeric("+-+-+-+++-1234")).Should().Be(false);
            (MathUtil.IsNumeric("+-1234")).Should().Be(false);
            (MathUtil.IsNumeric("--1234")).Should().Be(false);
        }

        [Fact]
        public void TestIsNumeric33()
        {
            double d = 0.0;
            //double x = 123450;
            //string s = x.ToString("Scientific");
            //bool result = double.TryParse(s, out d);
            //(result).Should().Be(true);

            //interesting - this works:
            bool result = double.TryParse("123.45E+3", out d);
            (result).Should().Be(true);
        }

        [Fact]
        public void TestIsNumeric34()
        {
            double d = 0.0;
            double x = 123450;
            string s = x.ToString("E", CultureInfo.InvariantCulture); // "E" formats as scientific notation
            bool result = double.TryParse(s, out d);
            (result).Should().Be(true);
        }

        [Fact]
        public void TestIsNumericNull()
        {
            // Null should return false (IsNullOrEmpty check)
            (MathUtil.IsNumeric(null)).Should().Be(false);
        }

        [Fact]
        public void TestIsNumericEmpty()
        {
            // Empty string should return false
            (MathUtil.IsNumeric("")).Should().Be(false);
        }

        [Fact]
        public void TestIsNumericWhitespaceOnly()
        {
            // Whitespace-only strings should be invalid for IsNumeric
            (MathUtil.IsNumeric(" ")).Should().Be(false);
            (MathUtil.IsNumeric("  ")).Should().Be(false);
            (MathUtil.IsNumeric("\t")).Should().Be(false);
        }

        [Fact]
        public void TestIsNumericCurrencySymbols()
        {
            // Currency symbols are NOT supported with InvariantCulture
            (MathUtil.IsNumeric("$123")).Should().Be(false);
            (MathUtil.IsNumeric("123$")).Should().Be(false);
        }

        [Fact]
        public void TestIsNumericThousandsSeparator()
        {
            // Thousands separator should be valid with NumberStyles.Any
            (MathUtil.IsNumeric("1,234")).Should().Be(true);
            (MathUtil.IsNumeric("1,234.56")).Should().Be(true);
        }

        [Fact]
        public void TestIsNumericVeryLargeNumbers()
        {
            // Very large numbers should be valid
            (MathUtil.IsNumeric("999999999999999999999")).Should().Be(true);
            (MathUtil.IsNumeric("-999999999999999999999")).Should().Be(true);
        }

        [Fact]
        public void TestIsNumericVerySmallDecimals()
        {
            // Very small decimal numbers should be valid
            (MathUtil.IsNumeric("0.00000000001")).Should().Be(true);
            (MathUtil.IsNumeric("-0.00000000001")).Should().Be(true);
        }

        [Fact]
        public void TestIsNumericSpecialFormats()
        {
            // Percent format is NOT supported with InvariantCulture
            (MathUtil.IsNumeric("50%")).Should().Be(false);
            // Parentheses for negative numbers ARE supported with NumberStyles.Any
            (MathUtil.IsNumeric("(123)")).Should().Be(true);
            (MathUtil.IsNumeric("(45.67)")).Should().Be(true);
        }

        #endregion


        #region IsInteger() tests

        [Fact]
        public void TestIsInteger1()
        {
            (MathUtil.IsInteger("0")).Should().Be(true);
        }

        [Fact]
        public void TestIsInteger2()
        {
            (MathUtil.IsInteger("1")).Should().Be(true);
        }

        [Fact]
        public void TestIsInteger3()
        {
            (MathUtil.IsInteger("12345")).Should().Be(true);
        }

        [Fact]
        public void TestIsInteger4()
        {
            (MathUtil.IsInteger(int.MaxValue.ToString(CultureInfo.InvariantCulture))).Should().Be(true);
        }

        [Fact]
        public void TestIsInteger5()
        {
            (MathUtil.IsInteger(int.MinValue.ToString(CultureInfo.InvariantCulture))).Should().Be(true);
        }

        [Fact]
        public void TestIsInteger6()
        {
            (MathUtil.IsInteger("+0")).Should().Be(true);
        }

        [Fact]
        public void TestIsInteger7()
        {
            (MathUtil.IsInteger("+1")).Should().Be(true);
        }

        [Fact]
        public void TestIsInteger8()
        {
            (MathUtil.IsInteger("+12345")).Should().Be(true);
        }

        [Fact]
        public void TestIsInteger9()
        {
            (MathUtil.IsInteger("+" + int.MaxValue.ToString(CultureInfo.InvariantCulture))).Should().Be(true);
        }

        [Fact]
        public void TestIsInteger10()
        {
            (MathUtil.IsInteger("+" + int.MinValue.ToString(CultureInfo.InvariantCulture))).Should().Be(false);
        }

        [Fact]
        public void TestIsInteger11()
        {
            (MathUtil.IsInteger("-0")).Should().Be(true);
        }

        [Fact]
        public void TestIsInteger12()
        {
            (MathUtil.IsInteger("-1")).Should().Be(true);
        }

        [Fact]
        public void TestIsInteger13()
        {
            (MathUtil.IsInteger("-12345")).Should().Be(true);
        }

        [Fact]
        public void TestIsInteger14()
        {
            (MathUtil.IsInteger("asdf")).Should().Be(false);
        }

        [Fact]
        public void TestIsInteger15()
        {
            (MathUtil.IsInteger("one")).Should().Be(false);
        }

        [Fact]
        public void TestIsInteger16()
        {
            (MathUtil.IsInteger("1a")).Should().Be(false);
        }

        [Fact]
        public void TestIsInteger17()
        {
            (MathUtil.IsInteger("12345.asdf")).Should().Be(false);
        }

        [Fact]
        public void TestIsInteger18()
        {
            (MathUtil.IsInteger("0.1")).Should().Be(false);
        }

        [Fact]
        public void TestIsInteger19()
        {
            (MathUtil.IsInteger("1.2")).Should().Be(false);
        }

        [Fact]
        public void TestIsInteger20()
        {
            (MathUtil.IsInteger("12345.12345")).Should().Be(false);
        }

        [Fact]
        public void TestIsInteger21()
        {
            (MathUtil.IsInteger("-0.1")).Should().Be(false);
        }

        [Fact]
        public void TestIsInteger22()
        {
            (MathUtil.IsInteger("-1.2")).Should().Be(false);
        }

        [Fact]
        public void TestIsInteger23()
        {
            (MathUtil.IsInteger("-12345.12345")).Should().Be(false);
        }

        [Fact]
        public void TestIsInteger24()
        {
            double x = 123.0;
            (MathUtil.IsInteger(x.ToString("E", CultureInfo.InvariantCulture))).Should().Be(false); // "E" formats as scientific notation
        }

        [Fact]
        public void TestIsInteger25()
        {
            long one = 1;
            (MathUtil.IsInteger((int.MaxValue + one).ToString(CultureInfo.InvariantCulture))).Should().Be(false);
            (MathUtil.IsInteger((int.MinValue - one).ToString(CultureInfo.InvariantCulture))).Should().Be(false);

            //After examining the int.TryParse() function, it is clear that passing
            //any sort of decimal into it should fail.

            (MathUtil.IsInteger("0.0")).Should().Be(false);
            (MathUtil.IsInteger("1.0")).Should().Be(false);
            (MathUtil.IsInteger("-1.0")).Should().Be(false);
        }

        [Fact]
        public void TestIsInteger26()
        {
            long one = 1;
            (MathUtil.IsInteger((int.MaxValue + one).ToString(CultureInfo.InvariantCulture))).Should().Be(false);
            (MathUtil.IsInteger((int.MinValue - one).ToString(CultureInfo.InvariantCulture))).Should().Be(false);
        }

        [Fact]
        public void TestIsIntegerNull()
        {
            // Null should throw ArgumentNullException
            Action act = () => MathUtil.IsInteger(null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestIsIntegerEmpty()
        {
            // Empty string should return false
            (MathUtil.IsInteger("")).Should().Be(false);
        }

        [Fact]
        public void TestIsIntegerWhitespaceOnly()
        {
            // Whitespace-only should be invalid
            (MathUtil.IsInteger(" ")).Should().Be(false);
        }

        [Fact]
        public void TestIsIntegerWithWhitespace()
        {
            // Whitespace around integers should be valid (int.TryParse accepts this)
            (MathUtil.IsInteger("  123  ")).Should().Be(true);
            (MathUtil.IsInteger("  -456  ")).Should().Be(true);
        }

        [Fact]
        public void TestIsIntegerNegativeZero()
        {
            // -0 should be valid
            (MathUtil.IsInteger("-0")).Should().Be(true);
        }

        [Fact]
        public void TestIsIntegerLeadingZeros()
        {
            // Leading zeros should be valid
            (MathUtil.IsInteger("00000")).Should().Be(true);
            (MathUtil.IsInteger("00123")).Should().Be(true);
            (MathUtil.IsInteger("-00456")).Should().Be(true);
        }

        #endregion


        #region RoundTo() tests

        [Fact]
        public void TestRoundTo1()
        {
            (MathUtil.RoundTo(0.12345, 2)).Should().Be(0.12);
        }

        [Fact]
        public void TestRoundTo2()
        {
            (MathUtil.RoundTo(0.12345, 10)).Should().Be(0.1234500000);
        }

        [Fact]
        public void TestRoundTo3()
        {
            (MathUtil.RoundTo(0.12345, 2)).Should().NotBe(0.13);
        }

        [Fact]
        public void TestRoundTo4()
        {
            (MathUtil.RoundTo(0.12345, 2).ToString(CultureInfo.InvariantCulture)).Should().Be("0.12");
        }

        [Fact]
        public void TestRoundTo5()
        {
            (MathUtil.RoundTo(0.12345, 10).ToString(CultureInfo.InvariantCulture)).Should().Be("0.12345");
        }

        [Fact]
        public void TestRoundTo6()
        {
            (MathUtil.RoundTo(0.12345, 2).ToString(CultureInfo.InvariantCulture)).Should().NotBe("0.13");
        }

        [Fact]
        public void TestRoundTo7()
        {
            (MathUtil.RoundTo(1 / 297.0, 9).ToString(CultureInfo.InvariantCulture)).Should().Be("0.003367003");
        }

        [Fact]
        public void TestRoundToZeroDigits()
        {
            // Zero digits should round to nearest whole number
            (MathUtil.RoundTo(0.7, 0)).Should().Be(1.0);
            (MathUtil.RoundTo(1.5, 0)).Should().Be(2.0);
            (MathUtil.RoundTo(2.4, 0)).Should().Be(2.0);
        }

        [Fact]
        public void TestRoundToNegativeDigits()
        {
            // Negative digits should still round to whole number (falls into else branch)
            (MathUtil.RoundTo(0.5, -1)).Should().Be(1.0);
            (MathUtil.RoundTo(1.4, -5)).Should().Be(1.0);
        }

        [Fact]
        public void TestRoundToNegativeNumbers()
        {
            // Rounding negative numbers should work correctly
            (MathUtil.RoundTo(-0.12345, 2)).Should().Be(-0.12);
            // RoundTo uses: Math.Floor(value * Math.Pow(10.0, digits) + 0.5)
            // -0.5 * 1 + 0.5 = 0, floor(0) = 0
            (MathUtil.RoundTo(-0.5, 0)).Should().Be(0.0);
            // -1.5 * 1 + 0.5 = -1, floor(-1) = -1
            (MathUtil.RoundTo(-1.5, 0)).Should().Be(-1.0);
        }

        [Fact]
        public void TestRoundToVeryLargeDigits()
        {
            // Very large digit count should preserve precision
            (MathUtil.RoundTo(0.123456789, 20)).Should().Be(0.123456789);
        }

        [Fact]
        public void TestRoundToZeroValue()
        {
            // Rounding zero should return zero
            (MathUtil.RoundTo(0.0, 5)).Should().Be(0.0);
            (MathUtil.RoundTo(0.0, 0)).Should().Be(0.0);
        }

        [Fact]
        public void TestRoundToVerySmallValue()
        {
            // Rounding very small values - due to floating point precision
            (MathUtil.RoundTo(0.00001, 3)).Should().Be(0.0);
            (MathUtil.RoundTo(0.000001, 5)).Should().Be(0.0);
        }

        [Fact]
        public void TestRoundToVeryLargeValue()
        {
            // Rounding very large values
            (MathUtil.RoundTo(123456.789, 2)).Should().Be(123456.79);
            (MathUtil.RoundTo(999999.95, 1)).Should().Be(1000000.0);
        }

        [Fact]
        public void TestRoundToEdgeCaseRounding()
        {
            // Test rounding at the 0.5 boundary
            (MathUtil.RoundTo(0.45, 1)).Should().Be(0.5);
            (MathUtil.RoundTo(1.45, 1)).Should().Be(1.5);
            (MathUtil.RoundTo(2.45, 1)).Should().Be(2.5);
        }

        [Fact]
        public void TestRoundToMultipleDecimalPlaces()
        {
            // Test rounding to different decimal places
            (MathUtil.RoundTo(0.12345, 1)).Should().Be(0.1);
            (MathUtil.RoundTo(0.12345, 3)).Should().Be(0.123);
            (MathUtil.RoundTo(0.12345, 5)).Should().Be(0.12345);
        }

        #endregion


        #region IsWholeNumber() tests

        [Fact]
        public void TestIsWholeNumber1()
        {
            (MathUtil.IsWholeNumber("0")).Should().Be(true);
        }

        [Fact]
        public void TestIsWholeNumber2()
        {
            (MathUtil.IsWholeNumber("10")).Should().Be(true);
        }

        [Fact]
        public void TestIsWholeNumber3()
        {
            (MathUtil.IsWholeNumber("10.0")).Should().Be(true);
        }

        [Fact]
        public void TestIsWholeNumber4()
        {
            (MathUtil.IsWholeNumber("-10")).Should().Be(true);
        }

        [Fact]
        public void TestIsWholeNumber5()
        {
            (MathUtil.IsWholeNumber("-10.0")).Should().Be(true);
        }

        [Fact]
        public void TestIsWholeNumber6()
        {
            (MathUtil.IsWholeNumber("0.5")).Should().Be(false);
        }

        [Fact]
        public void TestIsWholeNumber7()
        {
            (MathUtil.IsWholeNumber("-0.5")).Should().Be(false);
        }

        [Fact]
        public void TestIsWholeNumber8()
        {
            (MathUtil.IsWholeNumber("1.5")).Should().Be(false);
        }

        [Fact]
        public void TestIsWholeNumber9()
        {
            (MathUtil.IsWholeNumber("-1.5")).Should().Be(false);
        }

        [Fact]
        public void TestIsWholeNumberNull()
        {
            // Null should throw ArgumentNullException
            Action act = () => MathUtil.IsWholeNumber(null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestIsWholeNumberEmpty()
        {
            // Empty string should return false
            (MathUtil.IsWholeNumber("")).Should().Be(false);
        }

        [Fact]
        public void TestIsWholeNumberWhitespaceOnly()
        {
            // Whitespace-only should be invalid
            (MathUtil.IsWholeNumber(" ")).Should().Be(false);
        }

        [Fact]
        public void TestIsWholeNumberWithWhitespace()
        {
            // Whitespace around numbers should be valid (double.TryParse accepts this)
            (MathUtil.IsWholeNumber("  123  ")).Should().Be(true);
            (MathUtil.IsWholeNumber("  10.0  ")).Should().Be(true);
        }

        [Fact]
        public void TestIsWholeNumberNegativeDecimals()
        {
            // Negative decimals should be invalid
            (MathUtil.IsWholeNumber("-0.1")).Should().Be(false);
            (MathUtil.IsWholeNumber("-1.5")).Should().Be(false);
            (MathUtil.IsWholeNumber("-100.999")).Should().Be(false);
        }

        [Fact]
        public void TestIsWholeNumberLeadingZeros()
        {
            // Leading zeros should be valid
            (MathUtil.IsWholeNumber("00000")).Should().Be(true);
            (MathUtil.IsWholeNumber("00100.0")).Should().Be(true);
        }

        [Fact]
        public void TestIsWholeNumberNegativeZero()
        {
            // -0 and -0.0 should be valid whole numbers
            (MathUtil.IsWholeNumber("-0")).Should().Be(true);
            (MathUtil.IsWholeNumber("-0.0")).Should().Be(true);
        }

        [Fact]
        public void TestIsWholeNumberVeryLargeNumbers()
        {
            // Very large whole numbers should be valid
            (MathUtil.IsWholeNumber("999999999999999999999.0")).Should().Be(true);
            (MathUtil.IsWholeNumber("-999999999999999999999.0")).Should().Be(true);
        }

        [Fact]
        public void TestIsWholeNumberScientificNotation()
        {
            // Scientific notation representing whole numbers should be valid
            (MathUtil.IsWholeNumber("1e2")).Should().Be(true);
            (MathUtil.IsWholeNumber("5e0")).Should().Be(true);
        }

        [Fact]
        public void TestIsWholeNumberScientificNotationWithDecimals()
        {
            // 1.5e2 = 150.0, which is a whole number
            (MathUtil.IsWholeNumber("1.5e2")).Should().Be(true);
            // But 1.5e1 = 15.0, also whole
            (MathUtil.IsWholeNumber("1.5e1")).Should().Be(true);
        }

        #endregion


        #region RoundTowardsZero() tests

        [Fact]
        public void TestRoundTowardsZero1()
        {
            // Positive whole number
            (MathUtil.RoundTowardsZero(2.0)).Should().Be(2L);
        }

        [Fact]
        public void TestRoundTowardsZero2()
        {
            // Positive number with fractional part (should truncate)
            (MathUtil.RoundTowardsZero(2.5)).Should().Be(2L);
        }

        [Fact]
        public void TestRoundTowardsZero3()
        {
            // Positive small decimal (should truncate to 0)
            (MathUtil.RoundTowardsZero(0.5)).Should().Be(0L);
        }

        [Fact]
        public void TestRoundTowardsZero4()
        {
            // Zero
            (MathUtil.RoundTowardsZero(0.0)).Should().Be(0L);
        }

        [Fact]
        public void TestRoundTowardsZero5()
        {
            // Negative small decimal (should round up to 0)
            (MathUtil.RoundTowardsZero(-0.5)).Should().Be(0L);
        }

        [Fact]
        public void TestRoundTowardsZero6()
        {
            // Negative number with fractional part (should round up towards zero)
            (MathUtil.RoundTowardsZero(-2.5)).Should().Be(-2L);
        }

        [Fact]
        public void TestRoundTowardsZero7()
        {
            // Negative whole number
            (MathUtil.RoundTowardsZero(-2.0)).Should().Be(-2L);
        }

        [Fact]
        public void TestRoundTowardsZero8()
        {
            // Positive large number with fractional part
            (MathUtil.RoundTowardsZero(123.999)).Should().Be(123L);
        }

        [Fact]
        public void TestRoundTowardsZero9()
        {
            // Negative large number with fractional part
            (MathUtil.RoundTowardsZero(-123.999)).Should().Be(-123L);
        }

        [Fact]
        public void TestRoundTowardsZero10()
        {
            // Positive very small decimal close to zero
            (MathUtil.RoundTowardsZero(0.0001)).Should().Be(0L);
        }

        [Fact]
        public void TestRoundTowardsZero11()
        {
            // Negative very small decimal close to zero
            (MathUtil.RoundTowardsZero(-0.0001)).Should().Be(0L);
        }

        [Fact]
        public void TestRoundTowardsZero12()
        {
            // Positive number with fractional part less than 1
            (MathUtil.RoundTowardsZero(0.9999)).Should().Be(0L);
        }

        [Fact]
        public void TestRoundTowardsZero13()
        {
            // Negative number with fractional part less than 1
            (MathUtil.RoundTowardsZero(-0.9999)).Should().Be(0L);
        }

        [Fact]
        public void TestRoundTowardsZero14()
        {
            // Positive integer as double
            (MathUtil.RoundTowardsZero(5.0)).Should().Be(5L);
        }

        [Fact]
        public void TestRoundTowardsZero15()
        {
            // Negative integer as double
            (MathUtil.RoundTowardsZero(-5.0)).Should().Be(-5L);
        }

        [Fact]
        public void TestRoundTowardsZero16()
        {
            // Positive number just under a whole number
            (MathUtil.RoundTowardsZero(9.1)).Should().Be(9L);
        }

        [Fact]
        public void TestRoundTowardsZero17()
        {
            // Negative number just over a whole number
            (MathUtil.RoundTowardsZero(-9.1)).Should().Be(-9L);
        }

        [Fact]
        public void TestRoundTowardsZeroVeryLargePositive()
        {
            // Very large positive numbers - test with a value that accounts for floating point precision
            // The actual value due to floating point representation will be 9223372036854774784
            (MathUtil.RoundTowardsZero(9223372036854775000.5)).Should().Be(9223372036854774784L);
        }

        [Fact]
        public void TestRoundTowardsZeroVeryLargeNegative()
        {
            // Very large negative numbers - test with a value that accounts for floating point precision
            // The actual value due to floating point representation will be -9223372036854774784
            (MathUtil.RoundTowardsZero(-9223372036854775000.5)).Should().Be(-9223372036854774784L);
        }

        [Fact]
        public void TestRoundTowardsZeroExactHalf()
        {
            // Test exact 0.5 values
            (MathUtil.RoundTowardsZero(1.5)).Should().Be(1L);
            (MathUtil.RoundTowardsZero(10.5)).Should().Be(10L);
            (MathUtil.RoundTowardsZero(-1.5)).Should().Be(-1L);
            (MathUtil.RoundTowardsZero(-10.5)).Should().Be(-10L);
        }

        [Fact]
        public void TestRoundTowardsZeroJustAboveWhole()
        {
            // Numbers just above whole numbers
            (MathUtil.RoundTowardsZero(5.000001)).Should().Be(5L);
            (MathUtil.RoundTowardsZero(-5.000001)).Should().Be(-5L);
        }

        [Fact]
        public void TestRoundTowardsZeroJustBelowWhole()
        {
            // Numbers just below whole numbers
            (MathUtil.RoundTowardsZero(4.999999)).Should().Be(4L);
            (MathUtil.RoundTowardsZero(-4.999999)).Should().Be(-4L);
        }

        [Fact]
        public void TestRoundTowardsZeroOne()
        {
            // Test 1 and -1
            (MathUtil.RoundTowardsZero(1.0)).Should().Be(1L);
            (MathUtil.RoundTowardsZero(-1.0)).Should().Be(-1L);
            (MathUtil.RoundTowardsZero(1.9999)).Should().Be(1L);
            (MathUtil.RoundTowardsZero(-1.9999)).Should().Be(-1L);
        }

        #endregion


        #region IsLong() tests

        [Fact]
        public void TestIsLong1()
        {
            (MathUtil.IsLong("0")).Should().Be(true);
        }

        [Fact]
        public void TestIsLong2()
        {
            (MathUtil.IsLong("1")).Should().Be(true);
        }

        [Fact]
        public void TestIsLong3()
        {
            (MathUtil.IsLong("12345")).Should().Be(true);
        }

        [Fact]
        public void TestIsLong4()
        {
            (MathUtil.IsLong(long.MaxValue.ToString(CultureInfo.InvariantCulture))).Should().Be(true);
        }

        [Fact]
        public void TestIsLong5()
        {
            (MathUtil.IsLong(long.MinValue.ToString(CultureInfo.InvariantCulture))).Should().Be(true);
        }

        [Fact]
        public void TestIsLong6()
        {
            (MathUtil.IsLong("+0")).Should().Be(true);
        }

        [Fact]
        public void TestIsLong7()
        {
            (MathUtil.IsLong("+1")).Should().Be(true);
        }

        [Fact]
        public void TestIsLong8()
        {
            (MathUtil.IsLong("+12345")).Should().Be(true);
        }

        [Fact]
        public void TestIsLong9()
        {
            (MathUtil.IsLong("+" + long.MaxValue.ToString(CultureInfo.InvariantCulture))).Should().Be(true);
        }

        [Fact]
        public void TestIsLong10()
        {
            // Only one sign character is allowed, so "+" + long.MinValue is invalid
            (MathUtil.IsLong("+" + long.MinValue.ToString(CultureInfo.InvariantCulture))).Should().Be(false);
        }

        [Fact]
        public void TestIsLong11()
        {
            (MathUtil.IsLong("-0")).Should().Be(true);
        }

        [Fact]
        public void TestIsLong12()
        {
            (MathUtil.IsLong("-1")).Should().Be(true);
        }

        [Fact]
        public void TestIsLong13()
        {
            (MathUtil.IsLong("-12345")).Should().Be(true);
        }

        [Fact]
        public void TestIsLong14()
        {
            (MathUtil.IsLong("asdf")).Should().Be(false);
        }

        [Fact]
        public void TestIsLong15()
        {
            (MathUtil.IsLong("one")).Should().Be(false);
        }

        [Fact]
        public void TestIsLong16()
        {
            (MathUtil.IsLong("1a")).Should().Be(false);
        }

        [Fact]
        public void TestIsLong17()
        {
            (MathUtil.IsLong("12345.asdf")).Should().Be(false);
        }

        [Fact]
        public void TestIsLong18()
        {
            (MathUtil.IsLong("0.1")).Should().Be(false);
        }

        [Fact]
        public void TestIsLong19()
        {
            (MathUtil.IsLong("1.2")).Should().Be(false);
        }

        [Fact]
        public void TestIsLong20()
        {
            (MathUtil.IsLong("12345.12345")).Should().Be(false);
        }

        [Fact]
        public void TestIsLong21()
        {
            (MathUtil.IsLong("-0.1")).Should().Be(false);
        }

        [Fact]
        public void TestIsLong22()
        {
            (MathUtil.IsLong("-1.2")).Should().Be(false);
        }

        [Fact]
        public void TestIsLong23()
        {
            (MathUtil.IsLong("-12345.12345")).Should().Be(false);
        }

        [Fact]
        public void TestIsLong24()
        {
            // Scientific notation should not be valid for IsLong
            double x = 123.0;
            (MathUtil.IsLong(x.ToString("E", CultureInfo.InvariantCulture))).Should().Be(false); // "E" formats as scientific notation
        }

        [Fact]
        public void TestIsLong25()
        {
            // Decimal numbers should all be invalid
            (MathUtil.IsLong("0.0")).Should().Be(false);
            (MathUtil.IsLong("1.0")).Should().Be(false);
            (MathUtil.IsLong("-1.0")).Should().Be(false);
        }

        [Fact]
        public void TestIsLong26()
        {
            // Large numbers beyond int but within long range
            long one = 1;
            (MathUtil.IsLong((int.MaxValue + one).ToString(CultureInfo.InvariantCulture))).Should().Be(true);
            (MathUtil.IsLong((int.MinValue - one).ToString(CultureInfo.InvariantCulture))).Should().Be(true);
        }

        [Fact]
        public void TestIsLong27()
        {
            // Empty string should be invalid
            (MathUtil.IsLong("")).Should().Be(false);
            // Whitespace-only string should be invalid
            (MathUtil.IsLong(" ")).Should().Be(false);
            // Whitespace around numbers should be valid (long.TryParse accepts this)
            (MathUtil.IsLong("  123  ")).Should().Be(true);
        }

        [Fact]
        public void TestIsLong28()
        {
            // Null should throw ArgumentNullException
            Action act = () => MathUtil.IsLong(null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestIsLong29()
        {
            // Multiple signs should be invalid
            (MathUtil.IsLong("+-1")).Should().Be(false);
            (MathUtil.IsLong("--1")).Should().Be(false);
            (MathUtil.IsLong("++1")).Should().Be(false);
        }

        [Fact]
        public void TestIsLong30()
        {
            // Leading zeros should be valid
            (MathUtil.IsLong("00000")).Should().Be(true);
            (MathUtil.IsLong("00123")).Should().Be(true);
            (MathUtil.IsLong("-00123")).Should().Be(true);
        }

        #endregion


        #region Degree constant tests

        [Fact]
        public void TestDegreeConstant()
        {
            // Degree should equal Math.PI / 180.0
            (MathUtil.Degree).Should().Be(Math.PI / 180.0);
        }

        [Fact]
        public void TestDegreeConstantValue()
        {
            // One degree should be approximately 0.0174533 radians
            (Math.Abs(MathUtil.Degree - 0.0174533) < 0.0000001).Should().BeTrue();
        }

        [Fact]
        public void TestDegreeConstantConversion()
        {
            // 180 degrees should equal Math.PI radians
            (Math.Abs(180.0 * MathUtil.Degree - Math.PI) < 0.0000001).Should().BeTrue();
        }

        [Fact]
        public void TestDegreeConstant360()
        {
            // 360 degrees should equal 2*Math.PI radians
            (Math.Abs(360.0 * MathUtil.Degree - 2.0 * Math.PI) < 0.0000001).Should().BeTrue();
        }

        #endregion

    }
}
