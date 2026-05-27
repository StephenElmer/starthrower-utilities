using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarThrower.MathUtilities;

namespace StarThrower.MathUtilities.Test
{
    [TestClass]
    public class MathUtilTest
    {
        private void Ignore()
        {
#if FAIL_ON_IGNORE
                Assert.Fail("This test has been ignored.");
#else
            Assert.Inconclusive("this test has been ignored");
#endif
        }


        #region IsNumeric() tests

        [TestMethod]
        public void TestIsNumeric1()
        {
            Assert.AreEqual(MathUtil.IsNumeric("asdf"), false);
        }

        [TestMethod]
        public void TestIsNumeric2()
        {
            Assert.AreEqual(MathUtil.IsNumeric("one"), false);
        }

        [TestMethod]
        public void TestIsNumeric3()
        {
            Assert.AreEqual(MathUtil.IsNumeric("1a"), false);
        }

        [TestMethod]
        public void TestIsNumeric4()
        {
            Assert.AreEqual(MathUtil.IsNumeric("12345.asdf"), false);
        }

        [TestMethod]
        public void TestIsNumeric5()
        {
            Assert.AreEqual(MathUtil.IsNumeric("0"), true);
        }

        [TestMethod]
        public void TestIsNumeric6()
        {
            Assert.AreEqual(MathUtil.IsNumeric("00000"), true);
        }

        [TestMethod]
        public void TestIsNumeric7()
        {
            Assert.AreEqual(MathUtil.IsNumeric("0.0"), true);
        }

        [TestMethod]
        public void TestIsNumeric8()
        {
            Assert.AreEqual(MathUtil.IsNumeric("-0"), true);
        }

        [TestMethod]
        public void TestIsNumeric9()
        {
            Assert.AreEqual(MathUtil.IsNumeric("-00000"), true);
        }

        [TestMethod]
        public void TestIsNumeric10()
        {
            Assert.AreEqual(MathUtil.IsNumeric("-0.0"), true);
        }

        [TestMethod]
        public void TestIsNumeric11()
        {
            Assert.AreEqual(MathUtil.IsNumeric("+0"), true);
        }

        [TestMethod]
        public void TestIsNumeric12()
        {
            Assert.AreEqual(MathUtil.IsNumeric("+00000"), true);
        }

        [TestMethod]
        public void TestIsNumeric13()
        {
            Assert.AreEqual(MathUtil.IsNumeric("+0.0"), true);
        }

        [TestMethod]
        public void TestIsNumeric14()
        {
            Assert.AreEqual(MathUtil.IsNumeric("1"), true);
        }

        [TestMethod]
        public void TestIsNumeric15()
        {
            Assert.AreEqual(MathUtil.IsNumeric("+1"), true);
        }

        [TestMethod]
        public void TestIsNumeric16()
        {
            Assert.AreEqual(MathUtil.IsNumeric("1.0"), true);
        }

        [TestMethod]
        public void TestIsNumeric17()
        {
            Assert.AreEqual(MathUtil.IsNumeric("+1.0"), true);
        }

        [TestMethod]
        public void TestIsNumeric18()
        {
            Assert.AreEqual(MathUtil.IsNumeric("0.1"), true);
        }

        [TestMethod]
        public void TestIsNumeric19()
        {
            Assert.AreEqual(MathUtil.IsNumeric("+0.1"), true);
        }

        [TestMethod]
        public void TestIsNumeric20()
        {
            Assert.AreEqual(MathUtil.IsNumeric("1.2"), true);
        }

        [TestMethod]
        public void TestIsNumeric21()
        {
            Assert.AreEqual(MathUtil.IsNumeric("+1.2"), true);
        }

        [TestMethod]
        public void TestIsNumeric22()
        {
            Assert.AreEqual(MathUtil.IsNumeric("12345"), true);
        }

        [TestMethod]
        public void TestIsNumeric23()
        {
            Assert.AreEqual(MathUtil.IsNumeric("+12345"), true);
        }

        [TestMethod]
        public void TestIsNumeric24()
        {
            Assert.AreEqual(MathUtil.IsNumeric("12345.12345"), true);
        }

        [TestMethod]
        public void TestIsNumeric25()
        {
            Assert.AreEqual(MathUtil.IsNumeric("+12345.12345"), true);
        }

        [TestMethod]
        public void TestIsNumeric26()
        {
            Assert.AreEqual(MathUtil.IsNumeric("-1"), true);
        }

        [TestMethod]
        public void TestIsNumeric27()
        {
            Assert.AreEqual(MathUtil.IsNumeric("-1.0"), true);
        }

        [TestMethod]
        public void TestIsNumeric28()
        {
            Assert.AreEqual(MathUtil.IsNumeric("-0.1"), true);
        }

        [TestMethod]
        public void TestIsNumeric29()
        {
            Assert.AreEqual(MathUtil.IsNumeric("-1.2"), true);
        }

        [TestMethod]
        public void TestIsNumeric30()
        {
            Assert.AreEqual(MathUtil.IsNumeric("-12345"), true);
        }

        [TestMethod]
        public void TestIsNumeric31()
        {
            Assert.AreEqual(MathUtil.IsNumeric("-12345.12345"), true);
        }

        [TestMethod]
        public void TestIsNumeric32()
        {
            //When run against Microsoft.VisualBasic.IsNumeric(), this test breaks
            //therefore I am going to assume that it is an invalid case and check for the
            //false condition instead.  If Microsoft doesn't accept this case as a valid
            //numeric string, then I don't need to either.
            //Assert.AreEqual(MathUtil.IsNumeric("+-+-+-+++-1234"), true);

            //As double.TryParse() fails in this situation, it seems appropriate that IsNumeric should also fail.
            Assert.AreEqual(MathUtil.IsNumeric("+-+-+-+++-1234"), false);
            Assert.AreEqual(MathUtil.IsNumeric("+-1234"), false);
            Assert.AreEqual(MathUtil.IsNumeric("--1234"), false);
        }

        [TestMethod]
        public void TestIsNumeric33()
        {
            double d = 0.0;
            //double x = 123450;
            //string s = x.ToString("Scientific");
            //bool result = double.TryParse(s, out d);
            //Assert.AreEqual(true, result);

            //interesting - this works:
            bool result = double.TryParse("123.45E+3", out d);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestIsNumeric34()
        {
            double d = 0.0;
            double x = 123450;
            string s = x.ToString("E");
            bool result = double.TryParse(s, out d);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestIsNumericNull()
        {
            // Null should return false (IsNullOrEmpty check)
            Assert.AreEqual(MathUtil.IsNumeric(null), false);
        }

        [TestMethod]
        public void TestIsNumericEmpty()
        {
            // Empty string should return false
            Assert.AreEqual(MathUtil.IsNumeric(""), false);
        }

        [TestMethod]
        public void TestIsNumericWhitespaceOnly()
        {
            // Whitespace-only strings should be invalid for IsNumeric
            Assert.AreEqual(MathUtil.IsNumeric(" "), false);
            Assert.AreEqual(MathUtil.IsNumeric("  "), false);
            Assert.AreEqual(MathUtil.IsNumeric("\t"), false);
        }

        [TestMethod]
        public void TestIsNumericCurrencySymbols()
        {
            // Currency symbols are NOT supported with InvariantCulture
            Assert.AreEqual(MathUtil.IsNumeric("$123"), false);
            Assert.AreEqual(MathUtil.IsNumeric("123$"), false);
        }

        [TestMethod]
        public void TestIsNumericThousandsSeparator()
        {
            // Thousands separator should be valid with NumberStyles.Any
            Assert.AreEqual(MathUtil.IsNumeric("1,234"), true);
            Assert.AreEqual(MathUtil.IsNumeric("1,234.56"), true);
        }

        [TestMethod]
        public void TestIsNumericVeryLargeNumbers()
        {
            // Very large numbers should be valid
            Assert.AreEqual(MathUtil.IsNumeric("999999999999999999999"), true);
            Assert.AreEqual(MathUtil.IsNumeric("-999999999999999999999"), true);
        }

        [TestMethod]
        public void TestIsNumericVerySmallDecimals()
        {
            // Very small decimal numbers should be valid
            Assert.AreEqual(MathUtil.IsNumeric("0.00000000001"), true);
            Assert.AreEqual(MathUtil.IsNumeric("-0.00000000001"), true);
        }

        [TestMethod]
        public void TestIsNumericSpecialFormats()
        {
            // Percent format is NOT supported with InvariantCulture
            Assert.AreEqual(MathUtil.IsNumeric("50%"), false);
            // Parentheses for negative numbers ARE supported with NumberStyles.Any
            Assert.AreEqual(MathUtil.IsNumeric("(123)"), true);
            Assert.AreEqual(MathUtil.IsNumeric("(45.67)"), true);
        }

        #endregion


        #region IsInteger() tests

        [TestMethod]
        public void TestIsInteger1()
        {
            Assert.AreEqual(MathUtil.IsInteger("0"), true);
        }

        [TestMethod]
        public void TestIsInteger2()
        {
            Assert.AreEqual(MathUtil.IsInteger("1"), true);
        }

        [TestMethod]
        public void TestIsInteger3()
        {
            Assert.AreEqual(MathUtil.IsInteger("12345"), true);
        }

        [TestMethod]
        public void TestIsInteger4()
        {
            Assert.AreEqual(MathUtil.IsInteger(int.MaxValue.ToString()), true);
        }

        [TestMethod]
        public void TestIsInteger5()
        {
            Assert.AreEqual(MathUtil.IsInteger(int.MinValue.ToString()), true);
        }

        [TestMethod]
        public void TestIsInteger6()
        {
            Assert.AreEqual(MathUtil.IsInteger("+0"), true);
        }

        [TestMethod]
        public void TestIsInteger7()
        {
            Assert.AreEqual(MathUtil.IsInteger("+1"), true);
        }

        [TestMethod]
        public void TestIsInteger8()
        {
            Assert.AreEqual(MathUtil.IsInteger("+12345"), true);
        }

        [TestMethod]
        public void TestIsInteger9()
        {
            Assert.AreEqual(MathUtil.IsInteger("+" + int.MaxValue.ToString()), true);
        }

        [TestMethod]
        public void TestIsInteger10()
        {
            //TODO: this test breaks.  But is it valid?  Should "+-124" be considered a valid integer?  What about "+-+-+-+++-1234"?
            //      I'm going to say that such a case is not valid.  (See my comments for the similar test for IsNumeric(), above
            //Assert.AreEqual(MathUtil.IsInteger("+" + int.MinValue.ToString()), true);

            //After examining how int.TryParse() works, it is clear that only one sign character is allowed.
            //Therefore "+" + int.MinValue.ToString() should be invalid.
            Assert.AreEqual(MathUtil.IsInteger("+" + int.MinValue.ToString()), false);
        }

        [TestMethod]
        public void TestIsInteger11()
        {
            Assert.AreEqual(MathUtil.IsInteger("-0"), true);
        }

        [TestMethod]
        public void TestIsInteger12()
        {
            Assert.AreEqual(MathUtil.IsInteger("-1"), true);
        }

        [TestMethod]
        public void TestIsInteger13()
        {
            Assert.AreEqual(MathUtil.IsInteger("-12345"), true);
        }

        [TestMethod]
        public void TestIsInteger14()
        {
            Assert.AreEqual(MathUtil.IsInteger("asdf"), false);
        }

        [TestMethod]
        public void TestIsInteger15()
        {
            Assert.AreEqual(MathUtil.IsInteger("one"), false);
        }

        [TestMethod]
        public void TestIsInteger16()
        {
            Assert.AreEqual(MathUtil.IsInteger("1a"), false);
        }

        [TestMethod]
        public void TestIsInteger17()
        {
            Assert.AreEqual(MathUtil.IsInteger("12345.asdf"), false);
        }

        [TestMethod]
        public void TestIsInteger18()
        {
            Assert.AreEqual(MathUtil.IsInteger("0.1"), false);
        }

        [TestMethod]
        public void TestIsInteger19()
        {
            Assert.AreEqual(MathUtil.IsInteger("1.2"), false);
        }

        [TestMethod]
        public void TestIsInteger20()
        {
            Assert.AreEqual(MathUtil.IsInteger("12345.12345"), false);
        }

        [TestMethod]
        public void TestIsInteger21()
        {
            Assert.AreEqual(MathUtil.IsInteger("-0.1"), false);
        }

        [TestMethod]
        public void TestIsInteger22()
        {
            Assert.AreEqual(MathUtil.IsInteger("-1.2"), false);
        }

        [TestMethod]
        public void TestIsInteger23()
        {
            Assert.AreEqual(MathUtil.IsInteger("-12345.12345"), false);
        }

        [TestMethod]
        public void TestIsInteger24()
        {
            double x = 123.0;
            Assert.AreEqual(false, MathUtil.IsInteger(x.ToString("Scientific")));
        }

        [TestMethod]
        public void TestIsInteger25()
        {
            /* TODO: I'm not sure how these cases should be treated
            Assert.AreEqual(MathUtil.IsInteger("0.0"), false);
            Assert.AreEqual(MathUtil.IsInteger("1.0"), false);
            Assert.AreEqual(MathUtil.IsInteger("-1.0"), false);
            long one = 1;
            Assert.AreEqual(MathUtil.IsInteger((int.MaxValue + one).ToString()), false);
            Assert.AreEqual(MathUtil.IsInteger((int.MinValue - one).ToString()), false);
            */

            //After examining the int.TryParse() function, it is clear that passing
            //any sort of decimal into it should fail.

            Assert.AreEqual(MathUtil.IsInteger("0.0"), false);
            Assert.AreEqual(MathUtil.IsInteger("1.0"), false);
            Assert.AreEqual(MathUtil.IsInteger("-1.0"), false);
        }

        [TestMethod]
        public void TestIsInteger26()
        {
            long one = 1;
            Assert.AreEqual(MathUtil.IsInteger((int.MaxValue + one).ToString()), false);
            Assert.AreEqual(MathUtil.IsInteger((int.MinValue - one).ToString()), false);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIsIntegerNull()
        {
            // Null should throw ArgumentNullException
            MathUtil.IsInteger(null);
        }

        [TestMethod]
        public void TestIsIntegerEmpty()
        {
            // Empty string should return false
            Assert.AreEqual(MathUtil.IsInteger(""), false);
        }

        [TestMethod]
        public void TestIsIntegerWhitespaceOnly()
        {
            // Whitespace-only should be invalid
            Assert.AreEqual(MathUtil.IsInteger(" "), false);
        }

        [TestMethod]
        public void TestIsIntegerWithWhitespace()
        {
            // Whitespace around integers should be valid (int.TryParse accepts this)
            Assert.AreEqual(MathUtil.IsInteger("  123  "), true);
            Assert.AreEqual(MathUtil.IsInteger("  -456  "), true);
        }

        [TestMethod]
        public void TestIsIntegerNegativeZero()
        {
            // -0 should be valid
            Assert.AreEqual(MathUtil.IsInteger("-0"), true);
        }

        [TestMethod]
        public void TestIsIntegerLeadingZeros()
        {
            // Leading zeros should be valid
            Assert.AreEqual(MathUtil.IsInteger("00000"), true);
            Assert.AreEqual(MathUtil.IsInteger("00123"), true);
            Assert.AreEqual(MathUtil.IsInteger("-00456"), true);
        }

        #endregion


        #region RoundTo() tests

        [TestMethod]
        public void TestRoundTo1()
        {
            Assert.AreEqual(0.12, MathUtil.RoundTo(0.12345, 2));
        }

        [TestMethod]
        public void TestRoundTo2()
        {
            Assert.AreEqual(0.1234500000, MathUtil.RoundTo(0.12345, 10));
        }

        [TestMethod]
        public void TestRoundTo3()
        {
            Assert.AreNotEqual(0.13, MathUtil.RoundTo(0.12345, 2));
        }

        [TestMethod]
        public void TestRoundTo4()
        {
            Assert.AreEqual("0.12", MathUtil.RoundTo(0.12345, 2).ToString());
        }

        [TestMethod]
        public void TestRoundTo5()
        {
            Assert.AreEqual("0.12345", MathUtil.RoundTo(0.12345, 10).ToString());
        }

        [TestMethod]
        public void TestRoundTo6()
        {
            Assert.AreNotEqual("0.13", MathUtil.RoundTo(0.12345, 2).ToString());
        }

        [TestMethod]
        public void TestRoundTo7()
        {
            Assert.AreEqual("0.003367003", MathUtil.RoundTo(1 / 297.0, 9).ToString());
        }

        [TestMethod]
        public void TestRoundToZeroDigits()
        {
            // Zero digits should round to nearest whole number
            Assert.AreEqual(1.0, MathUtil.RoundTo(0.7, 0));
            Assert.AreEqual(2.0, MathUtil.RoundTo(1.5, 0));
            Assert.AreEqual(2.0, MathUtil.RoundTo(2.4, 0));
        }

        [TestMethod]
        public void TestRoundToNegativeDigits()
        {
            // Negative digits should still round to whole number (falls into else branch)
            Assert.AreEqual(1.0, MathUtil.RoundTo(0.5, -1));
            Assert.AreEqual(1.0, MathUtil.RoundTo(1.4, -5));
        }

        [TestMethod]
        public void TestRoundToNegativeNumbers()
        {
            // Rounding negative numbers should work correctly
            Assert.AreEqual(-0.12, MathUtil.RoundTo(-0.12345, 2));
            // RoundTo uses: Math.Floor(value * Math.Pow(10.0, digits) + 0.5)
            // -0.5 * 1 + 0.5 = 0, floor(0) = 0
            Assert.AreEqual(0.0, MathUtil.RoundTo(-0.5, 0));
            // -1.5 * 1 + 0.5 = -1, floor(-1) = -1
            Assert.AreEqual(-1.0, MathUtil.RoundTo(-1.5, 0));
        }

        [TestMethod]
        public void TestRoundToVeryLargeDigits()
        {
            // Very large digit count should preserve precision
            Assert.AreEqual(0.123456789, MathUtil.RoundTo(0.123456789, 20));
        }

        [TestMethod]
        public void TestRoundToZeroValue()
        {
            // Rounding zero should return zero
            Assert.AreEqual(0.0, MathUtil.RoundTo(0.0, 5));
            Assert.AreEqual(0.0, MathUtil.RoundTo(0.0, 0));
        }

        [TestMethod]
        public void TestRoundToVerySmallValue()
        {
            // Rounding very small values - due to floating point precision
            Assert.AreEqual(0.0, MathUtil.RoundTo(0.00001, 3));
            Assert.AreEqual(0.0, MathUtil.RoundTo(0.000001, 5));
        }

        [TestMethod]
        public void TestRoundToVeryLargeValue()
        {
            // Rounding very large values
            Assert.AreEqual(123456.79, MathUtil.RoundTo(123456.789, 2));
            Assert.AreEqual(1000000.0, MathUtil.RoundTo(999999.95, 1));
        }

        [TestMethod]
        public void TestRoundToEdgeCaseRounding()
        {
            // Test rounding at the 0.5 boundary
            Assert.AreEqual(0.5, MathUtil.RoundTo(0.45, 1));
            Assert.AreEqual(1.5, MathUtil.RoundTo(1.45, 1));
            Assert.AreEqual(2.5, MathUtil.RoundTo(2.45, 1));
        }

        [TestMethod]
        public void TestRoundToMultipleDecimalPlaces()
        {
            // Test rounding to different decimal places
            Assert.AreEqual(0.1, MathUtil.RoundTo(0.12345, 1));
            Assert.AreEqual(0.123, MathUtil.RoundTo(0.12345, 3));
            Assert.AreEqual(0.12345, MathUtil.RoundTo(0.12345, 5));
        }

        #endregion


        #region IsWholeNumber() tests

        [TestMethod]
        public void TestIsWholeNumber1()
        {
            Assert.AreEqual(MathUtil.IsWholeNumber("0"), true);
        }

        [TestMethod]
        public void TestIsWholeNumber2()
        {
            Assert.AreEqual(MathUtil.IsWholeNumber("10"), true);
        }

        [TestMethod]
        public void TestIsWholeNumber3()
        {
            Assert.AreEqual(MathUtil.IsWholeNumber("10.0"), true);
        }

        [TestMethod]
        public void TestIsWholeNumber4()
        {
            Assert.AreEqual(MathUtil.IsWholeNumber("-10"), true);
        }

        [TestMethod]
        public void TestIsWholeNumber5()
        {
            Assert.AreEqual(MathUtil.IsWholeNumber("-10.0"), true);
        }

        [TestMethod]
        public void TestIsWholeNumber6()
        {
            Assert.AreEqual(MathUtil.IsWholeNumber("0.5"), false);
        }

        [TestMethod]
        public void TestIsWholeNumber7()
        {
            Assert.AreEqual(MathUtil.IsWholeNumber("-0.5"), false);
        }

        [TestMethod]
        public void TestIsWholeNumber8()
        {
            Assert.AreEqual(MathUtil.IsWholeNumber("1.5"), false);
        }

        [TestMethod]
        public void TestIsWholeNumber9()
        {
            Assert.AreEqual(MathUtil.IsWholeNumber("-1.5"), false);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIsWholeNumberNull()
        {
            // Null should throw ArgumentNullException
            MathUtil.IsWholeNumber(null);
        }

        [TestMethod]
        public void TestIsWholeNumberEmpty()
        {
            // Empty string should return false
            Assert.AreEqual(MathUtil.IsWholeNumber(""), false);
        }

        [TestMethod]
        public void TestIsWholeNumberWhitespaceOnly()
        {
            // Whitespace-only should be invalid
            Assert.AreEqual(MathUtil.IsWholeNumber(" "), false);
        }

        [TestMethod]
        public void TestIsWholeNumberWithWhitespace()
        {
            // Whitespace around numbers should be valid (double.TryParse accepts this)
            Assert.AreEqual(MathUtil.IsWholeNumber("  123  "), true);
            Assert.AreEqual(MathUtil.IsWholeNumber("  10.0  "), true);
        }

        [TestMethod]
        public void TestIsWholeNumberNegativeDecimals()
        {
            // Negative decimals should be invalid
            Assert.AreEqual(MathUtil.IsWholeNumber("-0.1"), false);
            Assert.AreEqual(MathUtil.IsWholeNumber("-1.5"), false);
            Assert.AreEqual(MathUtil.IsWholeNumber("-100.999"), false);
        }

        [TestMethod]
        public void TestIsWholeNumberLeadingZeros()
        {
            // Leading zeros should be valid
            Assert.AreEqual(MathUtil.IsWholeNumber("00000"), true);
            Assert.AreEqual(MathUtil.IsWholeNumber("00100.0"), true);
        }

        [TestMethod]
        public void TestIsWholeNumberNegativeZero()
        {
            // -0 and -0.0 should be valid whole numbers
            Assert.AreEqual(MathUtil.IsWholeNumber("-0"), true);
            Assert.AreEqual(MathUtil.IsWholeNumber("-0.0"), true);
        }

        [TestMethod]
        public void TestIsWholeNumberVeryLargeNumbers()
        {
            // Very large whole numbers should be valid
            Assert.AreEqual(MathUtil.IsWholeNumber("999999999999999999999.0"), true);
            Assert.AreEqual(MathUtil.IsWholeNumber("-999999999999999999999.0"), true);
        }

        [TestMethod]
        public void TestIsWholeNumberScientificNotation()
        {
            // Scientific notation representing whole numbers should be valid
            Assert.AreEqual(MathUtil.IsWholeNumber("1e2"), true);
            Assert.AreEqual(MathUtil.IsWholeNumber("5e0"), true);
        }

        [TestMethod]
        public void TestIsWholeNumberScientificNotationWithDecimals()
        {
            // 1.5e2 = 150.0, which is a whole number
            Assert.AreEqual(MathUtil.IsWholeNumber("1.5e2"), true);
            // But 1.5e1 = 15.0, also whole
            Assert.AreEqual(MathUtil.IsWholeNumber("1.5e1"), true);
        }

        #endregion


        #region RoundTowardsZero() tests

        [TestMethod]
        public void TestRoundTowardsZero1()
        {
            // Positive whole number
            Assert.AreEqual(2L, MathUtil.RoundTowardsZero(2.0));
        }

        [TestMethod]
        public void TestRoundTowardsZero2()
        {
            // Positive number with fractional part (should truncate)
            Assert.AreEqual(2L, MathUtil.RoundTowardsZero(2.5));
        }

        [TestMethod]
        public void TestRoundTowardsZero3()
        {
            // Positive small decimal (should truncate to 0)
            Assert.AreEqual(0L, MathUtil.RoundTowardsZero(0.5));
        }

        [TestMethod]
        public void TestRoundTowardsZero4()
        {
            // Zero
            Assert.AreEqual(0L, MathUtil.RoundTowardsZero(0.0));
        }

        [TestMethod]
        public void TestRoundTowardsZero5()
        {
            // Negative small decimal (should round up to 0)
            Assert.AreEqual(0L, MathUtil.RoundTowardsZero(-0.5));
        }

        [TestMethod]
        public void TestRoundTowardsZero6()
        {
            // Negative number with fractional part (should round up towards zero)
            Assert.AreEqual(-2L, MathUtil.RoundTowardsZero(-2.5));
        }

        [TestMethod]
        public void TestRoundTowardsZero7()
        {
            // Negative whole number
            Assert.AreEqual(-2L, MathUtil.RoundTowardsZero(-2.0));
        }

        [TestMethod]
        public void TestRoundTowardsZero8()
        {
            // Positive large number with fractional part
            Assert.AreEqual(123L, MathUtil.RoundTowardsZero(123.999));
        }

        [TestMethod]
        public void TestRoundTowardsZero9()
        {
            // Negative large number with fractional part
            Assert.AreEqual(-123L, MathUtil.RoundTowardsZero(-123.999));
        }

        [TestMethod]
        public void TestRoundTowardsZero10()
        {
            // Positive very small decimal close to zero
            Assert.AreEqual(0L, MathUtil.RoundTowardsZero(0.0001));
        }

        [TestMethod]
        public void TestRoundTowardsZero11()
        {
            // Negative very small decimal close to zero
            Assert.AreEqual(0L, MathUtil.RoundTowardsZero(-0.0001));
        }

        [TestMethod]
        public void TestRoundTowardsZero12()
        {
            // Positive number with fractional part less than 1
            Assert.AreEqual(0L, MathUtil.RoundTowardsZero(0.9999));
        }

        [TestMethod]
        public void TestRoundTowardsZero13()
        {
            // Negative number with fractional part less than 1
            Assert.AreEqual(0L, MathUtil.RoundTowardsZero(-0.9999));
        }

        [TestMethod]
        public void TestRoundTowardsZero14()
        {
            // Positive integer as double
            Assert.AreEqual(5L, MathUtil.RoundTowardsZero(5.0));
        }

        [TestMethod]
        public void TestRoundTowardsZero15()
        {
            // Negative integer as double
            Assert.AreEqual(-5L, MathUtil.RoundTowardsZero(-5.0));
        }

        [TestMethod]
        public void TestRoundTowardsZero16()
        {
            // Positive number just under a whole number
            Assert.AreEqual(9L, MathUtil.RoundTowardsZero(9.1));
        }

        [TestMethod]
        public void TestRoundTowardsZero17()
        {
            // Negative number just over a whole number
            Assert.AreEqual(-9L, MathUtil.RoundTowardsZero(-9.1));
        }

        [TestMethod]
        public void TestRoundTowardsZeroVeryLargePositive()
        {
            // Very large positive numbers - test with a value that accounts for floating point precision
            // The actual value due to floating point representation will be 9223372036854774784
            Assert.AreEqual(9223372036854774784L, MathUtil.RoundTowardsZero(9223372036854775000.5));
        }

        [TestMethod]
        public void TestRoundTowardsZeroVeryLargeNegative()
        {
            // Very large negative numbers - test with a value that accounts for floating point precision
            // The actual value due to floating point representation will be -9223372036854774784
            Assert.AreEqual(-9223372036854774784L, MathUtil.RoundTowardsZero(-9223372036854775000.5));
        }

        [TestMethod]
        public void TestRoundTowardsZeroExactHalf()
        {
            // Test exact 0.5 values
            Assert.AreEqual(1L, MathUtil.RoundTowardsZero(1.5));
            Assert.AreEqual(10L, MathUtil.RoundTowardsZero(10.5));
            Assert.AreEqual(-1L, MathUtil.RoundTowardsZero(-1.5));
            Assert.AreEqual(-10L, MathUtil.RoundTowardsZero(-10.5));
        }

        [TestMethod]
        public void TestRoundTowardsZeroJustAboveWhole()
        {
            // Numbers just above whole numbers
            Assert.AreEqual(5L, MathUtil.RoundTowardsZero(5.000001));
            Assert.AreEqual(-5L, MathUtil.RoundTowardsZero(-5.000001));
        }

        [TestMethod]
        public void TestRoundTowardsZeroJustBelowWhole()
        {
            // Numbers just below whole numbers
            Assert.AreEqual(4L, MathUtil.RoundTowardsZero(4.999999));
            Assert.AreEqual(-4L, MathUtil.RoundTowardsZero(-4.999999));
        }

        [TestMethod]
        public void TestRoundTowardsZeroOne()
        {
            // Test 1 and -1
            Assert.AreEqual(1L, MathUtil.RoundTowardsZero(1.0));
            Assert.AreEqual(-1L, MathUtil.RoundTowardsZero(-1.0));
            Assert.AreEqual(1L, MathUtil.RoundTowardsZero(1.9999));
            Assert.AreEqual(-1L, MathUtil.RoundTowardsZero(-1.9999));
        }

        #endregion


        #region IsLong() tests

        [TestMethod]
        public void TestIsLong1()
        {
            Assert.AreEqual(MathUtil.IsLong("0"), true);
        }

        [TestMethod]
        public void TestIsLong2()
        {
            Assert.AreEqual(MathUtil.IsLong("1"), true);
        }

        [TestMethod]
        public void TestIsLong3()
        {
            Assert.AreEqual(MathUtil.IsLong("12345"), true);
        }

        [TestMethod]
        public void TestIsLong4()
        {
            Assert.AreEqual(MathUtil.IsLong(long.MaxValue.ToString()), true);
        }

        [TestMethod]
        public void TestIsLong5()
        {
            Assert.AreEqual(MathUtil.IsLong(long.MinValue.ToString()), true);
        }

        [TestMethod]
        public void TestIsLong6()
        {
            Assert.AreEqual(MathUtil.IsLong("+0"), true);
        }

        [TestMethod]
        public void TestIsLong7()
        {
            Assert.AreEqual(MathUtil.IsLong("+1"), true);
        }

        [TestMethod]
        public void TestIsLong8()
        {
            Assert.AreEqual(MathUtil.IsLong("+12345"), true);
        }

        [TestMethod]
        public void TestIsLong9()
        {
            Assert.AreEqual(MathUtil.IsLong("+" + long.MaxValue.ToString()), true);
        }

        [TestMethod]
        public void TestIsLong10()
        {
            // Only one sign character is allowed, so "+" + long.MinValue is invalid
            Assert.AreEqual(MathUtil.IsLong("+" + long.MinValue.ToString()), false);
        }

        [TestMethod]
        public void TestIsLong11()
        {
            Assert.AreEqual(MathUtil.IsLong("-0"), true);
        }

        [TestMethod]
        public void TestIsLong12()
        {
            Assert.AreEqual(MathUtil.IsLong("-1"), true);
        }

        [TestMethod]
        public void TestIsLong13()
        {
            Assert.AreEqual(MathUtil.IsLong("-12345"), true);
        }

        [TestMethod]
        public void TestIsLong14()
        {
            Assert.AreEqual(MathUtil.IsLong("asdf"), false);
        }

        [TestMethod]
        public void TestIsLong15()
        {
            Assert.AreEqual(MathUtil.IsLong("one"), false);
        }

        [TestMethod]
        public void TestIsLong16()
        {
            Assert.AreEqual(MathUtil.IsLong("1a"), false);
        }

        [TestMethod]
        public void TestIsLong17()
        {
            Assert.AreEqual(MathUtil.IsLong("12345.asdf"), false);
        }

        [TestMethod]
        public void TestIsLong18()
        {
            Assert.AreEqual(MathUtil.IsLong("0.1"), false);
        }

        [TestMethod]
        public void TestIsLong19()
        {
            Assert.AreEqual(MathUtil.IsLong("1.2"), false);
        }

        [TestMethod]
        public void TestIsLong20()
        {
            Assert.AreEqual(MathUtil.IsLong("12345.12345"), false);
        }

        [TestMethod]
        public void TestIsLong21()
        {
            Assert.AreEqual(MathUtil.IsLong("-0.1"), false);
        }

        [TestMethod]
        public void TestIsLong22()
        {
            Assert.AreEqual(MathUtil.IsLong("-1.2"), false);
        }

        [TestMethod]
        public void TestIsLong23()
        {
            Assert.AreEqual(MathUtil.IsLong("-12345.12345"), false);
        }

        [TestMethod]
        public void TestIsLong24()
        {
            // Scientific notation should not be valid for IsLong
            double x = 123.0;
            Assert.AreEqual(false, MathUtil.IsLong(x.ToString("Scientific")));
        }

        [TestMethod]
        public void TestIsLong25()
        {
            // Decimal numbers should all be invalid
            Assert.AreEqual(MathUtil.IsLong("0.0"), false);
            Assert.AreEqual(MathUtil.IsLong("1.0"), false);
            Assert.AreEqual(MathUtil.IsLong("-1.0"), false);
        }

        [TestMethod]
        public void TestIsLong26()
        {
            // Large numbers beyond int but within long range
            long one = 1;
            Assert.AreEqual(MathUtil.IsLong((int.MaxValue + one).ToString()), true);
            Assert.AreEqual(MathUtil.IsLong((int.MinValue - one).ToString()), true);
        }

        [TestMethod]
        public void TestIsLong27()
        {
            // Empty string should be invalid
            Assert.AreEqual(MathUtil.IsLong(""), false);
            // Whitespace-only string should be invalid
            Assert.AreEqual(MathUtil.IsLong(" "), false);
            // Whitespace around numbers should be valid (long.TryParse accepts this)
            Assert.AreEqual(MathUtil.IsLong("  123  "), true);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIsLong28()
        {
            // Null should throw ArgumentNullException
            MathUtil.IsLong(null);
        }

        [TestMethod]
        public void TestIsLong29()
        {
            // Multiple signs should be invalid
            Assert.AreEqual(MathUtil.IsLong("+-1"), false);
            Assert.AreEqual(MathUtil.IsLong("--1"), false);
            Assert.AreEqual(MathUtil.IsLong("++1"), false);
        }

        [TestMethod]
        public void TestIsLong30()
        {
            // Leading zeros should be valid
            Assert.AreEqual(MathUtil.IsLong("00000"), true);
            Assert.AreEqual(MathUtil.IsLong("00123"), true);
            Assert.AreEqual(MathUtil.IsLong("-00123"), true);
        }

        #endregion


        #region Degree constant tests

        [TestMethod]
        public void TestDegreeConstant()
        {
            // Degree should equal Math.PI / 180.0
            Assert.AreEqual(Math.PI / 180.0, MathUtil.Degree);
        }

        [TestMethod]
        public void TestDegreeConstantValue()
        {
            // One degree should be approximately 0.0174533 radians
            Assert.IsTrue(Math.Abs(MathUtil.Degree - 0.0174533) < 0.0000001);
        }

        [TestMethod]
        public void TestDegreeConstantConversion()
        {
            // 180 degrees should equal Math.PI radians
            Assert.IsTrue(Math.Abs(180.0 * MathUtil.Degree - Math.PI) < 0.0000001);
        }

        [TestMethod]
        public void TestDegreeConstant360()
        {
            // 360 degrees should equal 2*Math.PI radians
            Assert.IsTrue(Math.Abs(360.0 * MathUtil.Degree - 2.0 * Math.PI) < 0.0000001);
        }

        #endregion

    }
}
