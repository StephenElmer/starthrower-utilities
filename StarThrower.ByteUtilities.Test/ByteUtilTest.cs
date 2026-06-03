/***********************************************************************************
    StarThrower Utilities / ByteUtilities
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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarThrower.ByteUtilities;

namespace StarThrower.ByteUtilities.Test
{
    [TestClass]
    public class ByteUtilTest
    {
        private void Ignore()
        {
#if FAIL_ON_IGNORE
                Assert.Fail("This test has been ignored.");
#else
            Assert.Inconclusive("this test has been ignored");
#endif
        }


        #region XorByteArray() tests

        [TestMethod]
        public void TestXorByteArrayEqualLength()
        {
            byte[] value1 = new byte[] { 0xFF, 0xAA, 0x55, 0x00 };
            byte[] value2 = new byte[] { 0x0F, 0xF0, 0x0F, 0xF0 };
            byte[] expected = new byte[] { 0xF0, 0x5A, 0x5A, 0xF0 };
            
            byte[] actual = ByteUtil.XorByteArray(value1, value2);
            
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestXorByteArrayArgumentNull1()
        {
            byte[]? a = null;
            byte[]? b = new byte[] { 1, 2 };
            byte[] result = ByteUtil.XorByteArray(a, b);
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TextXorByteArrayArgumentNull2()
        {
            byte[] a = new byte[] { 1, 2 };
            byte[]? b = null;
            byte[] result = ByteUtil.XorByteArray(a, b);
            Assert.Fail();
        }

        [TestMethod]
        public void TestXorByteArrayValue1Longer()
        {
            byte[] value1 = new byte[] { 0xFF, 0xAA, 0x55, 0x00, 0x12, 0x34 };
            byte[] value2 = new byte[] { 0x0F, 0xF0, 0x0F, 0xF0 };
            byte[] expected = new byte[] { 0xF0, 0x5A, 0x5A, 0xF0, 0x12, 0x34 };
            
            byte[] actual = ByteUtil.XorByteArray(value1, value2);
            
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestXorByteArrayValue2Longer()
        {
            byte[] value1 = new byte[] { 0xFF, 0xAA };
            byte[] value2 = new byte[] { 0x0F, 0xF0, 0x0F, 0xF0, 0xAB, 0xCD };
            byte[] expected = new byte[] { 0xF0, 0x5A, 0x0F, 0xF0, 0xAB, 0xCD };
            
            byte[] actual = ByteUtil.XorByteArray(value1, value2);
            
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestXorByteArrayEmptyArrays()
        {
            byte[] value1 = Array.Empty<byte>();
            byte[] value2 = Array.Empty<byte>();
            byte[] expected = Array.Empty<byte>();
            
            byte[] actual = ByteUtil.XorByteArray(value1, value2);
            
            Assert.AreEqual(expected.Length, actual.Length);
        }

        [TestMethod]
        public void TestXorByteArraySingleByte()
        {
            byte[] value1 = new byte[] { 0xFF };
            byte[] value2 = new byte[] { 0x0F };
            byte[] expected = new byte[] { 0xF0 };
            
            byte[] actual = ByteUtil.XorByteArray(value1, value2);
            
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestXorByteArrayOneEmpty()
        {
            byte[] value1 = new byte[] { 0xFF, 0xAA, 0x55 };
            byte[] value2 = Array.Empty<byte>();
            byte[] expected = new byte[] { 0xFF, 0xAA, 0x55 };
            
            byte[] actual = ByteUtil.XorByteArray(value1, value2);
            
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestXorByteArrayAllZeros()
        {
            byte[] value1 = new byte[] { 0x00, 0x00, 0x00 };
            byte[] value2 = new byte[] { 0x00, 0x00, 0x00 };
            byte[] expected = new byte[] { 0x00, 0x00, 0x00 };
            
            byte[] actual = ByteUtil.XorByteArray(value1, value2);
            
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestXorByteArrayAllOnes()
        {
            byte[] value1 = new byte[] { 0xFF, 0xFF, 0xFF };
            byte[] value2 = new byte[] { 0xFF, 0xFF, 0xFF };
            byte[] expected = new byte[] { 0x00, 0x00, 0x00 };
            
            byte[] actual = ByteUtil.XorByteArray(value1, value2);
            
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        #endregion


        #region ByteSubstring() tests

        [TestMethod]
        public void TestByteSubstring1()
        {
            byte[] source = new byte[] { 1, 2, 3, 4 };
            byte[] expected = new byte[] { 1, 2, 3, 4 };
            byte[] actual = ByteUtil.ByteSubstring(source, 0, source.Length);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestByteSubstring2()
        {
            byte[] source = new byte[] { 1, 2, 3, 4 };
            byte[] expected = new byte[] { 1 };
            byte[] actual = ByteUtil.ByteSubstring(source, 0, 1);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestByteSubstring3()
        {
            byte[] source = new byte[] { 1, 2, 3, 4 };
            byte[] expected = new byte[] { 4 };
            byte[] actual = ByteUtil.ByteSubstring(source, source.Length - 1, 1);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestByteSubstring4()
        {
            byte[] source = new byte[] { 1, 2, 3, 4 };
            byte[] expected = new byte[] { 1, 2 };
            byte[] actual = ByteUtil.ByteSubstring(source, 0, 2);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestByteSubstring5()
        {
            byte[] source = new byte[] { 1, 2, 3, 4 };
            byte[] expected = new byte[] { 3, 4 };
            byte[] actual = ByteUtil.ByteSubstring(source, source.Length - 2, 2);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestByteSubstring6()
        {
            byte[] source = new byte[] { 1, 2, 3, 4 };
            byte[] expected = new byte[] { 2, 3 };
            byte[] actual = ByteUtil.ByteSubstring(source, 1, 2);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestByteSubstring7()
        {
            byte[] source = new byte[] { 1, 2, 3, 4 };
            byte[] expected = new byte[] { 2 };
            byte[] actual = ByteUtil.ByteSubstring(source, 1, 1);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestByteSubstringArgumentOutOfRange1()
        {
            byte[] source = new byte[] { 1, 2, 3, 4 };
            byte[] actual = ByteUtil.ByteSubstring(source, -1, 1);
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestByteSubstringArgumentOutOfRange2()
        {
            byte[] source = new byte[] { 1, 2, 3, 4 };
            byte[] actual = ByteUtil.ByteSubstring(source, 4, 1);
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestByteSubstringArgumentOutOfRange3()
        {
            byte[] source = new byte[] { 1, 2, 3, 4 };
            byte[] actual = ByteUtil.ByteSubstring(source, 5, 1);
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestByteSubstringArgumentOutOfRange4()
        {
            byte[] source = new byte[] { 1, 2, 3, 4 };
            byte[] actual = ByteUtil.ByteSubstring(source, 0, 5);
            Assert.Fail();
        }

        [TestMethod]
        public void TestByteSubstringWithTrimWithNullsFalse()
        {
            byte[] source = new byte[] { 1, 0, 3, 4 };
            byte[] expected = new byte[] { 1, 0, 3, 4 };
            byte[] actual = ByteUtil.ByteSubstring(source, 0, source.Length, false);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestByteSubstringWithTrimWithNullsTrue()
        {
            byte[] source = new byte[] { 1, 2, 0, 4 };
            byte[] expected = new byte[] { 1, 2, 0, 0 };
            byte[] actual = ByteUtil.ByteSubstring(source, 0, source.Length, true);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestByteSubstringWithTrimWithNullsTrueNoNullFound()
        {
            byte[] source = new byte[] { 1, 2, 3, 4 };
            byte[] expected = new byte[] { 1, 2, 3, 4 };
            byte[] actual = ByteUtil.ByteSubstring(source, 0, source.Length, true);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestByteSubstringWithTrimWithNullsTrueNullAtStart()
        {
            byte[] source = new byte[] { 0, 2, 3, 4 };
            byte[] expected = new byte[] { 0, 0, 0, 0 };
            byte[] actual = ByteUtil.ByteSubstring(source, 0, source.Length, true);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestByteSubstringWithTrimWithNullsTrueNullAtEnd()
        {
            byte[] source = new byte[] { 1, 2, 3, 0 };
            byte[] expected = new byte[] { 1, 2, 3, 0 };
            byte[] actual = ByteUtil.ByteSubstring(source, 0, source.Length, true);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestByteSubstringWithTrimWithNullsTruePartialLength()
        {
            byte[] source = new byte[] { 1, 2, 3, 4, 5, 6 };
            byte[] expected = new byte[] { 1, 2, 3 };
            byte[] actual = ByteUtil.ByteSubstring(source, 0, 3, true);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestByteSubstringWithTrimWithNullsTrueMultipleNulls()
        {
            byte[] source = new byte[] { 1, 0, 3, 0, 5, 6 };
            byte[] expected = new byte[] { 1, 0, 0, 0, 0, 0 };
            byte[] actual = ByteUtil.ByteSubstring(source, 0, source.Length, true);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestByteSubstringWithTrimWithNullsTrueStartIndex()
        {
            byte[] source = new byte[] { 10, 1, 2, 0, 4 };
            byte[] expected = new byte[] { 1, 2, 0, 0 };
            byte[] actual = ByteUtil.ByteSubstring(source, 1, 4, true);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestByteSubstringWithTrimWithNullsFalsePartialLength()
        {
            byte[] source = new byte[] { 1, 2, 3, 4, 5, 6 };
            byte[] expected = new byte[] { 2, 3, 4 };
            byte[] actual = ByteUtil.ByteSubstring(source, 1, 3, false);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestByteSubstringWithTrimWithNullsTrueMiddleNull()
        {
            byte[] source = new byte[] { 1, 2, 0, 4, 5, 6 };
            byte[] expected = new byte[] { 1, 2, 0, 0, 0, 0 };
            byte[] actual = ByteUtil.ByteSubstring(source, 0, 6, true);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestByteSubstringWithTrimWithNullsSingleByteNoNull()
        {
            byte[] source = new byte[] { 5 };
            byte[] expected = new byte[] { 5 };
            byte[] actual = ByteUtil.ByteSubstring(source, 0, 1, true);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestByteSubstringWithTrimWithNullsSingleByteIsNull()
        {
            byte[] source = new byte[] { 0 };
            byte[] expected = new byte[] { 0 };
            byte[] actual = ByteUtil.ByteSubstring(source, 0, 1, true);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestByteSubstringWithTrimWithNullsAllNulls()
        {
            byte[] source = new byte[] { 0, 0, 0, 0 };
            byte[] expected = new byte[] { 0, 0, 0, 0 };
            byte[] actual = ByteUtil.ByteSubstring(source, 0, source.Length, true);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestByteSubstringWithTrimWithNullsTrueLastElementNull()
        {
            byte[] source = new byte[] { 1, 2, 3, 4, 5, 0 };
            byte[] expected = new byte[] { 1, 2, 3, 4, 5, 0 };
            byte[] actual = ByteUtil.ByteSubstring(source, 0, source.Length, true);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestByteSubstringWithTrimWithNullsTrueNullInMiddle()
        {
            byte[] source = new byte[] { 1, 2, 0, 4, 5, 6 };
            byte[] expected = new byte[] { 1, 2, 0, 0, 0, 0 };
            byte[] actual = ByteUtil.ByteSubstring(source, 0, source.Length, true);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestByteSubstringWithTrimWithNullsArgumentNull()
        {
            byte[]? source = null;
            byte[] actual = ByteUtil.ByteSubstring(source, 0, 1, true);
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestByteSubstringWithTrimWithNullsArgumentOutOfRangeNegativeStart()
        {
            byte[] source = new byte[] { 1, 2, 3, 4 };
            byte[] actual = ByteUtil.ByteSubstring(source, -1, 1, true);
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestByteSubstringWithTrimWithNullsArgumentOutOfRangeStartAtLength()
        {
            byte[] source = new byte[] { 1, 2, 3, 4 };
            byte[] actual = ByteUtil.ByteSubstring(source, 4, 1, true);
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestByteSubstringWithTrimWithNullsArgumentOutOfRangeStartBeyondLength()
        {
            byte[] source = new byte[] { 1, 2, 3, 4 };
            byte[] actual = ByteUtil.ByteSubstring(source, 5, 1, true);
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestByteSubstringWithTrimWithNullsArgumentOutOfRangeLengthTooLong()
        {
            byte[] source = new byte[] { 1, 2, 3, 4 };
            byte[] actual = ByteUtil.ByteSubstring(source, 0, 5, true);
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestByteSubstringWithTrimWithNullsArgumentOutOfRangeLengthExceedsEnd()
        {
            byte[] source = new byte[] { 1, 2, 3, 4 };
            byte[] actual = ByteUtil.ByteSubstring(source, 2, 3, true);
            Assert.Fail();
        }

        #endregion


        #region ReverseBytes() tests

        [TestMethod]
        public void TestReverseBytes1()
        {
            byte[] expected = new byte[] { 4, 3, 2, 1 };
            byte[] source = new byte[] { 1, 2, 3, 4 };
            byte[] actual = ByteUtil.ReverseBytes(source);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestReverseBytes2()
        {
            byte[] expected = new byte[] { 1 };
            byte[] source = new byte[] { 1 };
            byte[] actual = ByteUtil.ReverseBytes(source);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestReverseBytes3()
        {
            byte[] expected = new byte[] { 2, 1 };
            byte[] source = new byte[] { 1, 2 };
            byte[] actual = ByteUtil.ReverseBytes(source);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestReverseBytes4()
        {
            byte[] expected = new byte[] { 5, 4, 3, 2, 1 };
            byte[] source = new byte[] { 1, 2, 3, 4, 5 };
            byte[] actual = ByteUtil.ReverseBytes(source);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestReverseBytes5()
        {
            byte[] expected = new byte[] { 3, 2, 1 };
            byte[] source = new byte[] { 1, 2, 3 };
            byte[] actual = ByteUtil.ReverseBytes(source);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        #endregion


        #region ReverseBits() tests

        [TestMethod]
        public void TestReverseBitsSingleByte()
        {
            // Test 0x01 (0000_0001) -> 0x80 (1000_0000)
            byte source = 0x01;
            byte expected = 0x80;
            byte actual = ByteUtil.ReverseBits(source);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestReverseBitsSingleByteAllZeros()
        {
            // Test 0x00 (0000_0000) -> 0x00 (0000_0000)
            byte source = 0x00;
            byte expected = 0x00;
            byte actual = ByteUtil.ReverseBits(source);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestReverseBitsSingleByteAllOnes()
        {
            // Test 0xFF (1111_1111) -> 0xFF (1111_1111)
            byte source = 0xFF;
            byte expected = 0xFF;
            byte actual = ByteUtil.ReverseBits(source);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestReverseBitsSingleByteAlternatingPattern()
        {
            // Test 0xAA (1010_1010) -> 0x55 (0101_0101)
            byte source = 0xAA;
            byte expected = 0x55;
            byte actual = ByteUtil.ReverseBits(source);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestReverseBitsSingleByteAlternatingPatternReverse()
        {
            // Test 0x55 (0101_0101) -> 0xAA (1010_1010)
            byte source = 0x55;
            byte expected = 0xAA;
            byte actual = ByteUtil.ReverseBits(source);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestReverseBitsSingleByteHighBitSet()
        {
            // Test 0x80 (1000_0000) -> 0x01 (0000_0001)
            byte source = 0x80;
            byte expected = 0x01;
            byte actual = ByteUtil.ReverseBits(source);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestReverseBitsArray()
        {
            byte[] source = new byte[] { 0x01, 0x80, 0xAA, 0xFF };
            byte[] expected = new byte[] { 0x80, 0x01, 0x55, 0xFF };
            byte[] actual = ByteUtil.ReverseBits(source);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestReverseBitsArraySingleElement()
        {
            byte[] source = new byte[] { 0xAA };
            byte[] expected = new byte[] { 0x55 };
            byte[] actual = ByteUtil.ReverseBits(source);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestReverseBitsArrayArgumentNull()
        {
            byte[]? source = null;
            byte[] actual = ByteUtil.ReverseBits(source);
            Assert.Fail();
        }

        #endregion


        #region ByteArrayToInt32() tests

        [TestMethod]
        public void TestByteArrayToInt32LittleEndianLittleBitEndian()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] value = new byte[] { 0xFF, 0xFE, 0xFF, 0xFF };
            Int32 expected = -257;
            Int32 actual = ByteUtil.ByteArrayToInt32(value, byteEndian, bitEndian);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToInt32LittleEndianLittleBitEndianZero()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] value = new byte[] { 0x00, 0x00, 0x00, 0x00 };
            Int32 expected = 0;
            Int32 actual = ByteUtil.ByteArrayToInt32(value, byteEndian, bitEndian);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToInt32LittleEndianLittleBitEndianAllOnes()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] value = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF };
            Int32 expected = -1;
            Int32 actual = ByteUtil.ByteArrayToInt32(value, byteEndian, bitEndian);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToInt32LittleEndianLittleBitEndianPositive()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] value = new byte[] { 0x01, 0x00, 0x00, 0x00 };
            Int32 expected = 1;
            Int32 actual = ByteUtil.ByteArrayToInt32(value, byteEndian, bitEndian);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToInt32BigEndianLittleBitEndian()
        {
            ByteEndian byteEndian = ByteEndian.Big;
            BitEndian bitEndian = BitEndian.Little;

            byte[] value = new byte[] { 0xFF, 0xFF, 0xFE, 0xFF };
            Int32 expected = -257;
            Int32 actual = ByteUtil.ByteArrayToInt32(value, byteEndian, bitEndian);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToInt32BigEndianLittleBitEndianZero()
        {
            ByteEndian byteEndian = ByteEndian.Big;
            BitEndian bitEndian = BitEndian.Little;

            byte[] value = new byte[] { 0x00, 0x00, 0x00, 0x00 };
            Int32 expected = 0;
            Int32 actual = ByteUtil.ByteArrayToInt32(value, byteEndian, bitEndian);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToInt32BigEndianLittleBitEndianAllOnes()
        {
            ByteEndian byteEndian = ByteEndian.Big;
            BitEndian bitEndian = BitEndian.Little;

            byte[] value = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF };
            Int32 expected = -1;
            Int32 actual = ByteUtil.ByteArrayToInt32(value, byteEndian, bitEndian);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToInt32LittleEndianBigBitEndian()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Big;

            // 0x01 reversed = 0x80, so 0x01 0x00 0x00 0x00 becomes 0x80 0x00 0x00 0x00 = -2147483648
            byte[] value = new byte[] { 0x01, 0x00, 0x00, 0x00 };
            Int32 expected = BitConverter.ToInt32(new byte[] { 0x80, 0x00, 0x00, 0x00 }, 0);
            Int32 actual = ByteUtil.ByteArrayToInt32(value, byteEndian, bitEndian);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToInt32LittleEndianBigBitEndianAllZeros()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Big;

            byte[] value = new byte[] { 0x00, 0x00, 0x00, 0x00 };
            Int32 expected = 0;
            Int32 actual = ByteUtil.ByteArrayToInt32(value, byteEndian, bitEndian);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToInt32LittleEndianBigBitEndianAllOnes()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Big;

            // 0xFF reversed = 0xFF, so all ones stays all ones = -1
            byte[] value = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF };
            Int32 expected = -1;
            Int32 actual = ByteUtil.ByteArrayToInt32(value, byteEndian, bitEndian);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToInt32BigEndianBigBitEndian()
        {
            ByteEndian byteEndian = ByteEndian.Big;
            BitEndian bitEndian = BitEndian.Big;

            // First reverse bytes: 0x00 0x00 0x00 0x01 becomes 0x01 0x00 0x00 0x00
            // Then reverse bits: 0x01 becomes 0x80, so 0x80 0x00 0x00 0x00 = -2147483648
            byte[] value = new byte[] { 0x00, 0x00, 0x00, 0x01 };
            Int32 expected = BitConverter.ToInt32(new byte[] { 0x80, 0x00, 0x00, 0x00 }, 0);
            Int32 actual = ByteUtil.ByteArrayToInt32(value, byteEndian, bitEndian);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToInt32BigEndianBigBitEndianAllZeros()
        {
            ByteEndian byteEndian = ByteEndian.Big;
            BitEndian bitEndian = BitEndian.Big;

            byte[] value = new byte[] { 0x00, 0x00, 0x00, 0x00 };
            Int32 expected = 0;
            Int32 actual = ByteUtil.ByteArrayToInt32(value, byteEndian, bitEndian);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToInt32BigEndianBigBitEndianAllOnes()
        {
            ByteEndian byteEndian = ByteEndian.Big;
            BitEndian bitEndian = BitEndian.Big;

            byte[] value = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF };
            Int32 expected = -1;
            Int32 actual = ByteUtil.ByteArrayToInt32(value, byteEndian, bitEndian);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestByteArrayToInt32ArgumentNull()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[]? value = null;
            Int32 actual = ByteUtil.ByteArrayToInt32(value, byteEndian, bitEndian);
            Assert.Fail();
        }

        #endregion


        #region ByteArrayToInt16() tests

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestByteArrayToInt16ArgumentNull()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[]? bytes = null;
            short actual = ByteUtil.ByteArrayToInt16(bytes, byteEndian, bitEndian);
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestByteArrayToInt16ArgumentOutOfRange()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] bytes = new byte[] { 0 };
            short actual = ByteUtil.ByteArrayToInt16(bytes, byteEndian, bitEndian);
            Assert.Fail();
        }

        [TestMethod]
        public void TestByteArrayToInt16Little2Little1()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] bytes = new byte[] { 0, 0 };
            short expected = 0;
            short actual = ByteUtil.ByteArrayToInt16(bytes, byteEndian, bitEndian);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToInt16Little2Little2()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] bytes = new byte[] { 255, 0 };
            short expected = 255;
            short actual = ByteUtil.ByteArrayToInt16(bytes, byteEndian, bitEndian);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToInt16Little2Little3()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] bytes = new byte[] { 0, 255 };
            short expected = -256;
            short actual = ByteUtil.ByteArrayToInt16(bytes, byteEndian, bitEndian);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToInt16Little2Little4()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] bytes = new byte[] { 255, 255 };
            short expected = -1;
            short actual = ByteUtil.ByteArrayToInt16(bytes, byteEndian, bitEndian);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToInt16Little2Little5()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] bytes = new byte[] { 1, 0 };
            short expected = 1;
            short actual = ByteUtil.ByteArrayToInt16(bytes, byteEndian, bitEndian);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToInt16Little2Little6()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] bytes = new byte[] { 0, 1 };
            short expected = 256;
            short actual = ByteUtil.ByteArrayToInt16(bytes, byteEndian, bitEndian);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestByteArrayToInt16Little2Little7()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] bytes = new byte[] { 1, 1 };
            short expected = 257;
            short actual = ByteUtil.ByteArrayToInt16(bytes, byteEndian, bitEndian);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToInt16Little2Little8()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] bytes = new byte[] { 0, 2 };
            short expected = 512;
            short actual = ByteUtil.ByteArrayToInt16(bytes, byteEndian, bitEndian);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToInt16Little2Little9()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] bytes = new byte[] { 255, 254 };
            short expected = -257;
            short actual = ByteUtil.ByteArrayToInt16(bytes, byteEndian, bitEndian);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToInt16Little2Little10()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] bytes = new byte[] { 255, 254 };
            short expected = -257;
            short actual = ByteUtil.ByteArrayToInt16(bytes, byteEndian, bitEndian);
            Assert.AreEqual(expected, actual);
        }

        #endregion


        #region ByteArrayToSingle() tests

        [TestMethod]
        public void TestByteArrayToSingleLittleEndianLittleBitEndianZero()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] value = new byte[] { 0x00, 0x00, 0x00, 0x00 };
            float expected = 0.0f;
            float actual = ByteUtil.ByteArrayToSingle(value, byteEndian, bitEndian);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToSingleLittleEndianLittleBitEndianPositive()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] value = BitConverter.GetBytes(3.14f);
            float expected = 3.14f;
            float actual = ByteUtil.ByteArrayToSingle(value, byteEndian, bitEndian);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToSingleLittleEndianLittleBitEndianNegative()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] value = BitConverter.GetBytes(-3.14f);
            float expected = -3.14f;
            float actual = ByteUtil.ByteArrayToSingle(value, byteEndian, bitEndian);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToSingleLittleEndianLittleBitEndianOne()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] value = BitConverter.GetBytes(1.0f);
            float expected = 1.0f;
            float actual = ByteUtil.ByteArrayToSingle(value, byteEndian, bitEndian);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToSingleLittleEndianLittleBitEndianNegativeOne()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] value = BitConverter.GetBytes(-1.0f);
            float expected = -1.0f;
            float actual = ByteUtil.ByteArrayToSingle(value, byteEndian, bitEndian);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToSingleLittleEndianLittleBitEndianLargeValue()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] value = BitConverter.GetBytes(12345.6789f);
            float expected = 12345.6789f;
            float actual = ByteUtil.ByteArrayToSingle(value, byteEndian, bitEndian);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToSingleLittleEndianBigBitEndianZero()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Big;

            byte[] value = new byte[] { 0x00, 0x00, 0x00, 0x00 };
            float expected = 0.0f;
            float actual = ByteUtil.ByteArrayToSingle(value, byteEndian, bitEndian);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToSingleLittleEndianBigBitEndianPositive()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Big;

            byte[] value = ByteUtil.ReverseBits(BitConverter.GetBytes(3.14f));
            float expected = 3.14f;
            float actual = ByteUtil.ByteArrayToSingle(value, byteEndian, bitEndian);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToSingleLittleEndianBigBitEndianOne()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Big;

            byte[] value = ByteUtil.ReverseBits(BitConverter.GetBytes(1.0f));
            float expected = 1.0f;
            float actual = ByteUtil.ByteArrayToSingle(value, byteEndian, bitEndian);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToSingleBigEndianLittleBitEndianZero()
        {
            ByteEndian byteEndian = ByteEndian.Big;
            BitEndian bitEndian = BitEndian.Little;

            byte[] value = new byte[] { 0x00, 0x00, 0x00, 0x00 };
            float expected = 0.0f;
            float actual = ByteUtil.ByteArrayToSingle(value, byteEndian, bitEndian);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToSingleBigEndianLittleBitEndianPositive()
        {
            ByteEndian byteEndian = ByteEndian.Big;
            BitEndian bitEndian = BitEndian.Little;

            byte[] value = ByteUtil.ReverseBytes(BitConverter.GetBytes(3.14f));
            float expected = 3.14f;
            float actual = ByteUtil.ByteArrayToSingle(value, byteEndian, bitEndian);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToSingleBigEndianLittleBitEndianNegative()
        {
            ByteEndian byteEndian = ByteEndian.Big;
            BitEndian bitEndian = BitEndian.Little;

            byte[] value = ByteUtil.ReverseBytes(BitConverter.GetBytes(-3.14f));
            float expected = -3.14f;
            float actual = ByteUtil.ByteArrayToSingle(value, byteEndian, bitEndian);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToSingleBigEndianBigBitEndianZero()
        {
            ByteEndian byteEndian = ByteEndian.Big;
            BitEndian bitEndian = BitEndian.Big;

            byte[] value = new byte[] { 0x00, 0x00, 0x00, 0x00 };
            float expected = 0.0f;
            float actual = ByteUtil.ByteArrayToSingle(value, byteEndian, bitEndian);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToSingleBigEndianBigBitEndianPositive()
        {
            ByteEndian byteEndian = ByteEndian.Big;
            BitEndian bitEndian = BitEndian.Big;

            byte[] value = ByteUtil.ReverseBits(ByteUtil.ReverseBytes(BitConverter.GetBytes(3.14f)));
            float expected = 3.14f;
            float actual = ByteUtil.ByteArrayToSingle(value, byteEndian, bitEndian);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToSingleBigEndianBigBitEndianNegative()
        {
            ByteEndian byteEndian = ByteEndian.Big;
            BitEndian bitEndian = BitEndian.Big;

            byte[] value = ByteUtil.ReverseBits(ByteUtil.ReverseBytes(BitConverter.GetBytes(-3.14f)));
            float expected = -3.14f;
            float actual = ByteUtil.ByteArrayToSingle(value, byteEndian, bitEndian);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestByteArrayToSingleBigEndianBigBitEndianOne()
        {
            ByteEndian byteEndian = ByteEndian.Big;
            BitEndian bitEndian = BitEndian.Big;

            byte[] value = ByteUtil.ReverseBits(ByteUtil.ReverseBytes(BitConverter.GetBytes(1.0f)));
            float expected = 1.0f;
            float actual = ByteUtil.ByteArrayToSingle(value, byteEndian, bitEndian);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestByteArrayToSingleArgumentNull()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[]? value = null;
            float actual = ByteUtil.ByteArrayToSingle(value, byteEndian, bitEndian);
            Assert.Fail();
        }

        #endregion


        #region ByteArrayToDouble() tests

        [TestMethod]
        public void TestByteArrayToDouble()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] bytes = new byte[] { 0, 0, 0, 0, 0, 16, 112, 192 };
            double expected = -257;
            double actual = ByteUtil.ByteArrayToDouble(bytes, byteEndian, bitEndian);
            Assert.AreEqual(expected, actual);
        }

        #endregion


        #region Int32ToByteArray() tests

        [TestMethod]
        public void TestInt32ToByteArray()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] expected = new byte[] { 255, 254, 255, 255 };
            byte[] actual = ByteUtil.Int32ToByteArray(-257, byteEndian, bitEndian);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        #endregion


        #region Int16ToByteArray() tests

        [TestMethod]
        public void TestInt16ToByteArray()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] expected = new byte[] { 255, 254 };
            byte[] actual = ByteUtil.Int16ToByteArray(-257, byteEndian, bitEndian);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        #endregion


        #region DoubleToByteArray() tests

        [TestMethod]
        public void TestDoubleToByteArray()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] expected = new byte[] { 0, 0, 0, 0, 0, 16, 112, 192 };
            byte[] actual = ByteUtil.DoubleToByteArray(-257.0, byteEndian, bitEndian);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        #endregion


        #region BytesAreEqual() tests

        [TestMethod]
        public void TestBytesAreEqualIdenticalArrays()
        {
            byte[] arr1 = new byte[] { 0x01, 0x02, 0x03, 0x04 };
            byte[] arr2 = new byte[] { 0x01, 0x02, 0x03, 0x04 };
            bool expected = true;
            bool actual = arr1.AsSpan().SequenceEqual(arr2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBytesAreEqualEmptyArrays()
        {
            byte[] arr1 = Array.Empty<byte>();
            byte[] arr2 = Array.Empty<byte>();
            bool expected = true;
            bool actual = arr1.AsSpan().SequenceEqual(arr2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBytesAreEqualSingleElementArraysSame()
        {
            byte[] arr1 = new byte[] { 0xFF };
            byte[] arr2 = new byte[] { 0xFF };
            bool expected = true;
            bool actual = arr1.AsSpan().SequenceEqual(arr2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBytesAreEqualSingleElementArraysDifferent()
        {
            byte[] arr1 = new byte[] { 0xFF };
            byte[] arr2 = new byte[] { 0x00 };
            bool expected = false;
            bool actual = arr1.AsSpan().SequenceEqual(arr2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBytesAreEqualDifferentLength()
        {
            byte[] arr1 = new byte[] { 0x01, 0x02, 0x03 };
            byte[] arr2 = new byte[] { 0x01, 0x02, 0x03, 0x04 };
            bool expected = false;
            bool actual = arr1.AsSpan().SequenceEqual(arr2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBytesAreEqualDifferentContent()
        {
            byte[] arr1 = new byte[] { 0x01, 0x02, 0x03, 0x04 };
            byte[] arr2 = new byte[] { 0x01, 0x02, 0x03, 0x05 };
            bool expected = false;
            bool actual = arr1.AsSpan().SequenceEqual(arr2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBytesAreEqualAllZeros()
        {
            byte[] arr1 = new byte[] { 0x00, 0x00, 0x00, 0x00 };
            byte[] arr2 = new byte[] { 0x00, 0x00, 0x00, 0x00 };
            bool expected = true;
            bool actual = arr1.AsSpan().SequenceEqual(arr2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBytesAreEqualAllOnes()
        {
            byte[] arr1 = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF };
            byte[] arr2 = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF };
            bool expected = true;
            bool actual = arr1.AsSpan().SequenceEqual(arr2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBytesAreEqualDifferentAtFirstPosition()
        {
            byte[] arr1 = new byte[] { 0xFF, 0x02, 0x03, 0x04 };
            byte[] arr2 = new byte[] { 0x00, 0x02, 0x03, 0x04 };
            bool expected = false;
            bool actual = arr1.AsSpan().SequenceEqual(arr2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBytesAreEqualDifferentAtLastPosition()
        {
            byte[] arr1 = new byte[] { 0x01, 0x02, 0x03, 0xFF };
            byte[] arr2 = new byte[] { 0x01, 0x02, 0x03, 0x00 };
            bool expected = false;
            bool actual = arr1.AsSpan().SequenceEqual(arr2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBytesAreEqualDifferentAtMiddlePosition()
        {
            byte[] arr1 = new byte[] { 0x01, 0x02, 0xFF, 0x04 };
            byte[] arr2 = new byte[] { 0x01, 0x02, 0x00, 0x04 };
            bool expected = false;
            bool actual = arr1.AsSpan().SequenceEqual(arr2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBytesAreEqualLongerArrays()
        {
            byte[] arr1 = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };
            byte[] arr2 = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };
            bool expected = true;
            bool actual = arr1.AsSpan().SequenceEqual(arr2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBytesAreEqualLongerArraysDifferent()
        {
            byte[] arr1 = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };
            byte[] arr2 = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x09 };
            bool expected = false;
            bool actual = arr1.AsSpan().SequenceEqual(arr2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBytesAreEqualAlternatingPattern()
        {
            byte[] arr1 = new byte[] { 0xAA, 0x55, 0xAA, 0x55 };
            byte[] arr2 = new byte[] { 0xAA, 0x55, 0xAA, 0x55 };
            bool expected = true;
            bool actual = arr1.AsSpan().SequenceEqual(arr2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestBytesAreEqualFirstArrayNull()
        {
            byte[]? arr1 = null;
            byte[] arr2 = new byte[] { 0x01, 0x02 };
#pragma warning disable CS0618 // Type or member is obsolete
            bool actual = ByteUtil.BytesAreEqual(arr1, arr2);
#pragma warning restore CS0618 // Type or member is obsolete
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestBytesAreEqualSecondArrayNull()
        {
            byte[] arr1 = new byte[] { 0x01, 0x02 };
            byte[]? arr2 = null;
#pragma warning disable CS0618 // Type or member is obsolete
            bool actual = ByteUtil.BytesAreEqual(arr1, arr2);
#pragma warning restore CS0618 // Type or member is obsolete
            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestBytesAreEqualBothArraysNull()
        {
            byte[]? arr1 = null;
            byte[]? arr2 = null;
#pragma warning disable CS0618 // Type or member is obsolete
            bool actual = ByteUtil.BytesAreEqual(arr1, arr2);
#pragma warning restore CS0618 // Type or member is obsolete
            Assert.Fail();
        }

        #endregion
    }
}
