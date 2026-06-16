// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using AwesomeAssertions;
using Xunit;
using StarThrower.ByteUtilities;

namespace StarThrower.ByteUtilities.Test
{
    public class ByteUtilTest
    {
        #region XorByteArray() tests

        [Fact]
        public void TestXorByteArrayEqualLength()
        {
            byte[] value1 = new byte[] { 0xFF, 0xAA, 0x55, 0x00 };
            byte[] value2 = new byte[] { 0x0F, 0xF0, 0x0F, 0xF0 };
            byte[] expected = new byte[] { 0xF0, 0x5A, 0x5A, 0xF0 };
            
            byte[] actual = ByteUtil.XorByteArray(value1, value2);
            
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestXorByteArrayArgumentNull1()
        {
            byte[]? a = null;
            byte[]? b = new byte[] { 1, 2 };
            Action act = () => ByteUtil.XorByteArray(a, b);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TextXorByteArrayArgumentNull2()
        {
            byte[] a = new byte[] { 1, 2 };
            byte[]? b = null;
            Action act = () => ByteUtil.XorByteArray(a, b);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestXorByteArrayValue1Longer()
        {
            byte[] value1 = new byte[] { 0xFF, 0xAA, 0x55, 0x00, 0x12, 0x34 };
            byte[] value2 = new byte[] { 0x0F, 0xF0, 0x0F, 0xF0 };
            byte[] expected = new byte[] { 0xF0, 0x5A, 0x5A, 0xF0, 0x12, 0x34 };
            
            byte[] actual = ByteUtil.XorByteArray(value1, value2);
            
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestXorByteArrayValue2Longer()
        {
            byte[] value1 = new byte[] { 0xFF, 0xAA };
            byte[] value2 = new byte[] { 0x0F, 0xF0, 0x0F, 0xF0, 0xAB, 0xCD };
            byte[] expected = new byte[] { 0xF0, 0x5A, 0x0F, 0xF0, 0xAB, 0xCD };
            
            byte[] actual = ByteUtil.XorByteArray(value1, value2);
            
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestXorByteArrayEmptyArrays()
        {
            byte[] value1 = Array.Empty<byte>();
            byte[] value2 = Array.Empty<byte>();
            byte[] expected = Array.Empty<byte>();
            
            byte[] actual = ByteUtil.XorByteArray(value1, value2);
            
            (actual.Length).Should().Be(expected.Length);
        }

        [Fact]
        public void TestXorByteArraySingleByte()
        {
            byte[] value1 = new byte[] { 0xFF };
            byte[] value2 = new byte[] { 0x0F };
            byte[] expected = new byte[] { 0xF0 };
            
            byte[] actual = ByteUtil.XorByteArray(value1, value2);
            
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestXorByteArrayOneEmpty()
        {
            byte[] value1 = new byte[] { 0xFF, 0xAA, 0x55 };
            byte[] value2 = Array.Empty<byte>();
            byte[] expected = new byte[] { 0xFF, 0xAA, 0x55 };
            
            byte[] actual = ByteUtil.XorByteArray(value1, value2);
            
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestXorByteArrayAllZeros()
        {
            byte[] value1 = new byte[] { 0x00, 0x00, 0x00 };
            byte[] value2 = new byte[] { 0x00, 0x00, 0x00 };
            byte[] expected = new byte[] { 0x00, 0x00, 0x00 };
            
            byte[] actual = ByteUtil.XorByteArray(value1, value2);
            
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestXorByteArrayAllOnes()
        {
            byte[] value1 = new byte[] { 0xFF, 0xFF, 0xFF };
            byte[] value2 = new byte[] { 0xFF, 0xFF, 0xFF };
            byte[] expected = new byte[] { 0x00, 0x00, 0x00 };
            
            byte[] actual = ByteUtil.XorByteArray(value1, value2);
            
            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        #endregion


        #region ByteSubstring() tests

        [Fact]
        public void TestByteSubstring1()
        {
            byte[] source = new byte[] { 1, 2, 3, 4 };
            byte[] expected = new byte[] { 1, 2, 3, 4 };
            byte[] actual = ByteUtil.ByteSubstring(source, 0, source.Length);

            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestByteSubstring2()
        {
            byte[] source = new byte[] { 1, 2, 3, 4 };
            byte[] expected = new byte[] { 1 };
            byte[] actual = ByteUtil.ByteSubstring(source, 0, 1);

            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestByteSubstring3()
        {
            byte[] source = new byte[] { 1, 2, 3, 4 };
            byte[] expected = new byte[] { 4 };
            byte[] actual = ByteUtil.ByteSubstring(source, source.Length - 1, 1);

            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestByteSubstring4()
        {
            byte[] source = new byte[] { 1, 2, 3, 4 };
            byte[] expected = new byte[] { 1, 2 };
            byte[] actual = ByteUtil.ByteSubstring(source, 0, 2);

            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestByteSubstring5()
        {
            byte[] source = new byte[] { 1, 2, 3, 4 };
            byte[] expected = new byte[] { 3, 4 };
            byte[] actual = ByteUtil.ByteSubstring(source, source.Length - 2, 2);

            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestByteSubstring6()
        {
            byte[] source = new byte[] { 1, 2, 3, 4 };
            byte[] expected = new byte[] { 2, 3 };
            byte[] actual = ByteUtil.ByteSubstring(source, 1, 2);

            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestByteSubstring7()
        {
            byte[] source = new byte[] { 1, 2, 3, 4 };
            byte[] expected = new byte[] { 2 };
            byte[] actual = ByteUtil.ByteSubstring(source, 1, 1);

            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestByteSubstringArgumentOutOfRange1()
        {
            byte[] source = new byte[] { 1, 2, 3, 4 };
            Action act = () => ByteUtil.ByteSubstring(source, -1, 1);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestByteSubstringArgumentOutOfRange2()
        {
            byte[] source = new byte[] { 1, 2, 3, 4 };
            Action act = () => ByteUtil.ByteSubstring(source, 4, 1);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestByteSubstringArgumentOutOfRange3()
        {
            byte[] source = new byte[] { 1, 2, 3, 4 };
            Action act = () => ByteUtil.ByteSubstring(source, 5, 1);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestByteSubstringArgumentOutOfRange4()
        {
            byte[] source = new byte[] { 1, 2, 3, 4 };
            Action act = () => ByteUtil.ByteSubstring(source, 0, 5);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestByteSubstringWithTrimWithNullsFalse()
        {
            byte[] source = new byte[] { 1, 0, 3, 4 };
            byte[] expected = new byte[] { 1, 0, 3, 4 };
            byte[] actual = ByteUtil.ByteSubstring(source, 0, source.Length, false);

            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestByteSubstringWithTrimWithNullsTrue()
        {
            byte[] source = new byte[] { 1, 2, 0, 4 };
            byte[] expected = new byte[] { 1, 2, 0, 0 };
            byte[] actual = ByteUtil.ByteSubstring(source, 0, source.Length, true);

            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestByteSubstringWithTrimWithNullsTrueNoNullFound()
        {
            byte[] source = new byte[] { 1, 2, 3, 4 };
            byte[] expected = new byte[] { 1, 2, 3, 4 };
            byte[] actual = ByteUtil.ByteSubstring(source, 0, source.Length, true);

            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestByteSubstringWithTrimWithNullsTrueNullAtStart()
        {
            byte[] source = new byte[] { 0, 2, 3, 4 };
            byte[] expected = new byte[] { 0, 0, 0, 0 };
            byte[] actual = ByteUtil.ByteSubstring(source, 0, source.Length, true);

            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestByteSubstringWithTrimWithNullsTrueNullAtEnd()
        {
            byte[] source = new byte[] { 1, 2, 3, 0 };
            byte[] expected = new byte[] { 1, 2, 3, 0 };
            byte[] actual = ByteUtil.ByteSubstring(source, 0, source.Length, true);

            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestByteSubstringWithTrimWithNullsTruePartialLength()
        {
            byte[] source = new byte[] { 1, 2, 3, 4, 5, 6 };
            byte[] expected = new byte[] { 1, 2, 3 };
            byte[] actual = ByteUtil.ByteSubstring(source, 0, 3, true);

            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestByteSubstringWithTrimWithNullsTrueMultipleNulls()
        {
            byte[] source = new byte[] { 1, 0, 3, 0, 5, 6 };
            byte[] expected = new byte[] { 1, 0, 0, 0, 0, 0 };
            byte[] actual = ByteUtil.ByteSubstring(source, 0, source.Length, true);

            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestByteSubstringWithTrimWithNullsTrueStartIndex()
        {
            byte[] source = new byte[] { 10, 1, 2, 0, 4 };
            byte[] expected = new byte[] { 1, 2, 0, 0 };
            byte[] actual = ByteUtil.ByteSubstring(source, 1, 4, true);

            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestByteSubstringWithTrimWithNullsFalsePartialLength()
        {
            byte[] source = new byte[] { 1, 2, 3, 4, 5, 6 };
            byte[] expected = new byte[] { 2, 3, 4 };
            byte[] actual = ByteUtil.ByteSubstring(source, 1, 3, false);

            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestByteSubstringWithTrimWithNullsTrueMiddleNull()
        {
            byte[] source = new byte[] { 1, 2, 0, 4, 5, 6 };
            byte[] expected = new byte[] { 1, 2, 0, 0, 0, 0 };
            byte[] actual = ByteUtil.ByteSubstring(source, 0, 6, true);

            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestByteSubstringWithTrimWithNullsSingleByteNoNull()
        {
            byte[] source = new byte[] { 5 };
            byte[] expected = new byte[] { 5 };
            byte[] actual = ByteUtil.ByteSubstring(source, 0, 1, true);

            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestByteSubstringWithTrimWithNullsSingleByteIsNull()
        {
            byte[] source = new byte[] { 0 };
            byte[] expected = new byte[] { 0 };
            byte[] actual = ByteUtil.ByteSubstring(source, 0, 1, true);

            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestByteSubstringWithTrimWithNullsAllNulls()
        {
            byte[] source = new byte[] { 0, 0, 0, 0 };
            byte[] expected = new byte[] { 0, 0, 0, 0 };
            byte[] actual = ByteUtil.ByteSubstring(source, 0, source.Length, true);

            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestByteSubstringWithTrimWithNullsTrueLastElementNull()
        {
            byte[] source = new byte[] { 1, 2, 3, 4, 5, 0 };
            byte[] expected = new byte[] { 1, 2, 3, 4, 5, 0 };
            byte[] actual = ByteUtil.ByteSubstring(source, 0, source.Length, true);

            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestByteSubstringWithTrimWithNullsTrueNullInMiddle()
        {
            byte[] source = new byte[] { 1, 2, 0, 4, 5, 6 };
            byte[] expected = new byte[] { 1, 2, 0, 0, 0, 0 };
            byte[] actual = ByteUtil.ByteSubstring(source, 0, source.Length, true);

            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestByteSubstringWithTrimWithNullsArgumentNull()
        {
            byte[]? source = null;
            Action act = () => ByteUtil.ByteSubstring(source, 0, 1, true);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestByteSubstringWithTrimWithNullsArgumentOutOfRangeNegativeStart()
        {
            byte[] source = new byte[] { 1, 2, 3, 4 };
            Action act = () => ByteUtil.ByteSubstring(source, -1, 1, true);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestByteSubstringWithTrimWithNullsArgumentOutOfRangeStartAtLength()
        {
            byte[] source = new byte[] { 1, 2, 3, 4 };
            Action act = () => ByteUtil.ByteSubstring(source, 4, 1, true);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestByteSubstringWithTrimWithNullsArgumentOutOfRangeStartBeyondLength()
        {
            byte[] source = new byte[] { 1, 2, 3, 4 };
            Action act = () => ByteUtil.ByteSubstring(source, 5, 1, true);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestByteSubstringWithTrimWithNullsArgumentOutOfRangeLengthTooLong()
        {
            byte[] source = new byte[] { 1, 2, 3, 4 };
            Action act = () => ByteUtil.ByteSubstring(source, 0, 5, true);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestByteSubstringWithTrimWithNullsArgumentOutOfRangeLengthExceedsEnd()
        {
            byte[] source = new byte[] { 1, 2, 3, 4 };
            Action act = () => ByteUtil.ByteSubstring(source, 2, 3, true);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        #endregion


        #region ReverseBytes() tests

        [Fact]
        public void TestReverseBytes1()
        {
            byte[] expected = new byte[] { 4, 3, 2, 1 };
            byte[] source = new byte[] { 1, 2, 3, 4 };
            byte[] actual = ByteUtil.ReverseBytes(source);

            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestReverseBytes2()
        {
            byte[] expected = new byte[] { 1 };
            byte[] source = new byte[] { 1 };
            byte[] actual = ByteUtil.ReverseBytes(source);

            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestReverseBytes3()
        {
            byte[] expected = new byte[] { 2, 1 };
            byte[] source = new byte[] { 1, 2 };
            byte[] actual = ByteUtil.ReverseBytes(source);

            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestReverseBytes4()
        {
            byte[] expected = new byte[] { 5, 4, 3, 2, 1 };
            byte[] source = new byte[] { 1, 2, 3, 4, 5 };
            byte[] actual = ByteUtil.ReverseBytes(source);

            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestReverseBytes5()
        {
            byte[] expected = new byte[] { 3, 2, 1 };
            byte[] source = new byte[] { 1, 2, 3 };
            byte[] actual = ByteUtil.ReverseBytes(source);

            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        #endregion


        #region ReverseBits() tests

        [Fact]
        public void TestReverseBitsSingleByte()
        {
            // Test 0x01 (0000_0001) -> 0x80 (1000_0000)
            byte source = 0x01;
            byte expected = 0x80;
            byte actual = ByteUtil.ReverseBits(source);
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestReverseBitsSingleByteAllZeros()
        {
            // Test 0x00 (0000_0000) -> 0x00 (0000_0000)
            byte source = 0x00;
            byte expected = 0x00;
            byte actual = ByteUtil.ReverseBits(source);
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestReverseBitsSingleByteAllOnes()
        {
            // Test 0xFF (1111_1111) -> 0xFF (1111_1111)
            byte source = 0xFF;
            byte expected = 0xFF;
            byte actual = ByteUtil.ReverseBits(source);
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestReverseBitsSingleByteAlternatingPattern()
        {
            // Test 0xAA (1010_1010) -> 0x55 (0101_0101)
            byte source = 0xAA;
            byte expected = 0x55;
            byte actual = ByteUtil.ReverseBits(source);
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestReverseBitsSingleByteAlternatingPatternReverse()
        {
            // Test 0x55 (0101_0101) -> 0xAA (1010_1010)
            byte source = 0x55;
            byte expected = 0xAA;
            byte actual = ByteUtil.ReverseBits(source);
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestReverseBitsSingleByteHighBitSet()
        {
            // Test 0x80 (1000_0000) -> 0x01 (0000_0001)
            byte source = 0x80;
            byte expected = 0x01;
            byte actual = ByteUtil.ReverseBits(source);
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestReverseBitsArray()
        {
            byte[] source = new byte[] { 0x01, 0x80, 0xAA, 0xFF };
            byte[] expected = new byte[] { 0x80, 0x01, 0x55, 0xFF };
            byte[] actual = ByteUtil.ReverseBits(source);

            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestReverseBitsArraySingleElement()
        {
            byte[] source = new byte[] { 0xAA };
            byte[] expected = new byte[] { 0x55 };
            byte[] actual = ByteUtil.ReverseBits(source);

            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestReverseBitsArrayArgumentNull()
        {
            byte[]? source = null;
            Action act = () => ByteUtil.ReverseBits(source);
            act.Should().Throw<ArgumentNullException>();
        }

        #endregion


        #region ByteArrayToInt32() tests

        [Fact]
        public void TestByteArrayToInt32LittleEndianLittleBitEndian()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] value = new byte[] { 0xFF, 0xFE, 0xFF, 0xFF };
            Int32 expected = -257;
            Int32 actual = ByteUtil.ByteArrayToInt32(value, byteEndian, bitEndian);

            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToInt32LittleEndianLittleBitEndianZero()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] value = new byte[] { 0x00, 0x00, 0x00, 0x00 };
            Int32 expected = 0;
            Int32 actual = ByteUtil.ByteArrayToInt32(value, byteEndian, bitEndian);

            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToInt32LittleEndianLittleBitEndianAllOnes()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] value = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF };
            Int32 expected = -1;
            Int32 actual = ByteUtil.ByteArrayToInt32(value, byteEndian, bitEndian);

            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToInt32LittleEndianLittleBitEndianPositive()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] value = new byte[] { 0x01, 0x00, 0x00, 0x00 };
            Int32 expected = 1;
            Int32 actual = ByteUtil.ByteArrayToInt32(value, byteEndian, bitEndian);

            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToInt32BigEndianLittleBitEndian()
        {
            ByteEndian byteEndian = ByteEndian.Big;
            BitEndian bitEndian = BitEndian.Little;

            byte[] value = new byte[] { 0xFF, 0xFF, 0xFE, 0xFF };
            Int32 expected = -257;
            Int32 actual = ByteUtil.ByteArrayToInt32(value, byteEndian, bitEndian);

            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToInt32BigEndianLittleBitEndianZero()
        {
            ByteEndian byteEndian = ByteEndian.Big;
            BitEndian bitEndian = BitEndian.Little;

            byte[] value = new byte[] { 0x00, 0x00, 0x00, 0x00 };
            Int32 expected = 0;
            Int32 actual = ByteUtil.ByteArrayToInt32(value, byteEndian, bitEndian);

            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToInt32BigEndianLittleBitEndianAllOnes()
        {
            ByteEndian byteEndian = ByteEndian.Big;
            BitEndian bitEndian = BitEndian.Little;

            byte[] value = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF };
            Int32 expected = -1;
            Int32 actual = ByteUtil.ByteArrayToInt32(value, byteEndian, bitEndian);

            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToInt32LittleEndianBigBitEndian()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Big;

            // 0x01 reversed = 0x80, so 0x01 0x00 0x00 0x00 becomes 0x80 0x00 0x00 0x00 = -2147483648
            byte[] value = new byte[] { 0x01, 0x00, 0x00, 0x00 };
            Int32 expected = BitConverter.ToInt32(new byte[] { 0x80, 0x00, 0x00, 0x00 }, 0);
            Int32 actual = ByteUtil.ByteArrayToInt32(value, byteEndian, bitEndian);

            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToInt32LittleEndianBigBitEndianAllZeros()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Big;

            byte[] value = new byte[] { 0x00, 0x00, 0x00, 0x00 };
            Int32 expected = 0;
            Int32 actual = ByteUtil.ByteArrayToInt32(value, byteEndian, bitEndian);

            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToInt32LittleEndianBigBitEndianAllOnes()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Big;

            // 0xFF reversed = 0xFF, so all ones stays all ones = -1
            byte[] value = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF };
            Int32 expected = -1;
            Int32 actual = ByteUtil.ByteArrayToInt32(value, byteEndian, bitEndian);

            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToInt32BigEndianBigBitEndian()
        {
            ByteEndian byteEndian = ByteEndian.Big;
            BitEndian bitEndian = BitEndian.Big;

            // First reverse bytes: 0x00 0x00 0x00 0x01 becomes 0x01 0x00 0x00 0x00
            // Then reverse bits: 0x01 becomes 0x80, so 0x80 0x00 0x00 0x00 = -2147483648
            byte[] value = new byte[] { 0x00, 0x00, 0x00, 0x01 };
            Int32 expected = BitConverter.ToInt32(new byte[] { 0x80, 0x00, 0x00, 0x00 }, 0);
            Int32 actual = ByteUtil.ByteArrayToInt32(value, byteEndian, bitEndian);

            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToInt32BigEndianBigBitEndianAllZeros()
        {
            ByteEndian byteEndian = ByteEndian.Big;
            BitEndian bitEndian = BitEndian.Big;

            byte[] value = new byte[] { 0x00, 0x00, 0x00, 0x00 };
            Int32 expected = 0;
            Int32 actual = ByteUtil.ByteArrayToInt32(value, byteEndian, bitEndian);

            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToInt32BigEndianBigBitEndianAllOnes()
        {
            ByteEndian byteEndian = ByteEndian.Big;
            BitEndian bitEndian = BitEndian.Big;

            byte[] value = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF };
            Int32 expected = -1;
            Int32 actual = ByteUtil.ByteArrayToInt32(value, byteEndian, bitEndian);

            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToInt32ArgumentNull()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[]? value = null;
            Action act = () => ByteUtil.ByteArrayToInt32(value, byteEndian, bitEndian);
            act.Should().Throw<ArgumentNullException>();
        }

        #endregion


        #region ByteArrayToInt16() tests

        [Fact]
        public void TestByteArrayToInt16ArgumentNull()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[]? bytes = null;
            Action act = () => ByteUtil.ByteArrayToInt16(bytes, byteEndian, bitEndian);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestByteArrayToInt16ArgumentOutOfRange()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] bytes = new byte[] { 0 };
            Action act = () => ByteUtil.ByteArrayToInt16(bytes, byteEndian, bitEndian);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TestByteArrayToInt16Little2Little1()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] bytes = new byte[] { 0, 0 };
            short expected = 0;
            short actual = ByteUtil.ByteArrayToInt16(bytes, byteEndian, bitEndian);
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToInt16Little2Little2()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] bytes = new byte[] { 255, 0 };
            short expected = 255;
            short actual = ByteUtil.ByteArrayToInt16(bytes, byteEndian, bitEndian);
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToInt16Little2Little3()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] bytes = new byte[] { 0, 255 };
            short expected = -256;
            short actual = ByteUtil.ByteArrayToInt16(bytes, byteEndian, bitEndian);
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToInt16Little2Little4()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] bytes = new byte[] { 255, 255 };
            short expected = -1;
            short actual = ByteUtil.ByteArrayToInt16(bytes, byteEndian, bitEndian);
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToInt16Little2Little5()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] bytes = new byte[] { 1, 0 };
            short expected = 1;
            short actual = ByteUtil.ByteArrayToInt16(bytes, byteEndian, bitEndian);
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToInt16Little2Little6()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] bytes = new byte[] { 0, 1 };
            short expected = 256;
            short actual = ByteUtil.ByteArrayToInt16(bytes, byteEndian, bitEndian);
            (actual).Should().Be(expected);
        }


        [Fact]
        public void TestByteArrayToInt16Little2Little7()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] bytes = new byte[] { 1, 1 };
            short expected = 257;
            short actual = ByteUtil.ByteArrayToInt16(bytes, byteEndian, bitEndian);
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToInt16Little2Little8()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] bytes = new byte[] { 0, 2 };
            short expected = 512;
            short actual = ByteUtil.ByteArrayToInt16(bytes, byteEndian, bitEndian);
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToInt16Little2Little9()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] bytes = new byte[] { 255, 254 };
            short expected = -257;
            short actual = ByteUtil.ByteArrayToInt16(bytes, byteEndian, bitEndian);
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToInt16Little2Little10()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] bytes = new byte[] { 255, 254 };
            short expected = -257;
            short actual = ByteUtil.ByteArrayToInt16(bytes, byteEndian, bitEndian);
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToInt16BigEndianLittleBitEndianZero()
        {
            byte[] bytes = new byte[] { 0x00, 0x00 };
            short expected = 0;
            short actual = ByteUtil.ByteArrayToInt16(bytes, ByteEndian.Big, BitEndian.Little);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToInt16BigEndianLittleBitEndianOne()
        {
            // Big-endian { 0x00, 0x01 } → ReverseBytes → { 0x01, 0x00 } → BitConverter.ToInt16 → 1
            byte[] bytes = new byte[] { 0x00, 0x01 };
            short expected = 1;
            short actual = ByteUtil.ByteArrayToInt16(bytes, ByteEndian.Big, BitEndian.Little);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToInt16BigEndianLittleBitEndianAllOnes()
        {
            byte[] bytes = new byte[] { 0xFF, 0xFF };
            short expected = -1;
            short actual = ByteUtil.ByteArrayToInt16(bytes, ByteEndian.Big, BitEndian.Little);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToInt16LittleEndianBigBitEndianZero()
        {
            byte[] bytes = new byte[] { 0x00, 0x00 };
            short expected = 0;
            short actual = ByteUtil.ByteArrayToInt16(bytes, ByteEndian.Little, BitEndian.Big);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToInt16LittleEndianBigBitEndianAllOnes()
        {
            // ReverseBits(0xFF) = 0xFF, so all-ones stays -1
            byte[] bytes = new byte[] { 0xFF, 0xFF };
            short expected = -1;
            short actual = ByteUtil.ByteArrayToInt16(bytes, ByteEndian.Little, BitEndian.Big);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToInt16LittleEndianBigBitEndian()
        {
            // { 0x01, 0x00 } → ReverseBits each → { 0x80, 0x00 } → BitConverter.ToInt16 → 128
            byte[] bytes = new byte[] { 0x01, 0x00 };
            short expected = BitConverter.ToInt16(new byte[] { 0x80, 0x00 }, 0);
            short actual = ByteUtil.ByteArrayToInt16(bytes, ByteEndian.Little, BitEndian.Big);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToInt16BigEndianBigBitEndianZero()
        {
            byte[] bytes = new byte[] { 0x00, 0x00 };
            short expected = 0;
            short actual = ByteUtil.ByteArrayToInt16(bytes, ByteEndian.Big, BitEndian.Big);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToInt16BigEndianBigBitEndianAllOnes()
        {
            byte[] bytes = new byte[] { 0xFF, 0xFF };
            short expected = -1;
            short actual = ByteUtil.ByteArrayToInt16(bytes, ByteEndian.Big, BitEndian.Big);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToInt16BigEndianBigBitEndian()
        {
            // { 0x00, 0x01 } → ReverseBytes → { 0x01, 0x00 } → ReverseBits each → { 0x80, 0x00 } → BitConverter.ToInt16 → 128
            byte[] bytes = new byte[] { 0x00, 0x01 };
            short expected = BitConverter.ToInt16(new byte[] { 0x80, 0x00 }, 0);
            short actual = ByteUtil.ByteArrayToInt16(bytes, ByteEndian.Big, BitEndian.Big);
            actual.Should().Be(expected);
        }

        #endregion


        #region ByteToInt16() tests

        [Fact]
        public void TestByteToInt16LittleBitEndianZero()
        {
            byte b = 0x00;
            short expected = 0;
            short actual = ByteUtil.ByteToInt16(b, BitEndian.Little);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestByteToInt16LittleBitEndianOne()
        {
            byte b = 0x01;
            short expected = 1;
            short actual = ByteUtil.ByteToInt16(b, BitEndian.Little);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestByteToInt16LittleBitEndianMaxByte()
        {
            byte b = 0xFF;
            short expected = 255;
            short actual = ByteUtil.ByteToInt16(b, BitEndian.Little);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestByteToInt16BigBitEndianZero()
        {
            byte b = 0x00;
            short expected = 0;
            short actual = ByteUtil.ByteToInt16(b, BitEndian.Big);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestByteToInt16BigBitEndianOne()
        {
            // ReverseBits(0x01) = 0x80 = 128
            byte b = 0x01;
            short expected = 128;
            short actual = ByteUtil.ByteToInt16(b, BitEndian.Big);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestByteToInt16BigBitEndianMaxByte()
        {
            // ReverseBits(0xFF) = 0xFF = 255
            byte b = 0xFF;
            short expected = 255;
            short actual = ByteUtil.ByteToInt16(b, BitEndian.Big);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestByteToInt16BigBitEndianHighBitSet()
        {
            // ReverseBits(0x80) = 0x01 = 1
            byte b = 0x80;
            short expected = 1;
            short actual = ByteUtil.ByteToInt16(b, BitEndian.Big);
            actual.Should().Be(expected);
        }

        #endregion


        #region ByteArrayToSingle() tests

        [Fact]
        public void TestByteArrayToSingleLittleEndianLittleBitEndianZero()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] value = new byte[] { 0x00, 0x00, 0x00, 0x00 };
            float expected = 0.0f;
            float actual = ByteUtil.ByteArrayToSingle(value, byteEndian, bitEndian);
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToSingleLittleEndianLittleBitEndianPositive()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] value = BitConverter.GetBytes(3.14f);
            float expected = 3.14f;
            float actual = ByteUtil.ByteArrayToSingle(value, byteEndian, bitEndian);
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToSingleLittleEndianLittleBitEndianNegative()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] value = BitConverter.GetBytes(-3.14f);
            float expected = -3.14f;
            float actual = ByteUtil.ByteArrayToSingle(value, byteEndian, bitEndian);
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToSingleLittleEndianLittleBitEndianOne()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] value = BitConverter.GetBytes(1.0f);
            float expected = 1.0f;
            float actual = ByteUtil.ByteArrayToSingle(value, byteEndian, bitEndian);
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToSingleLittleEndianLittleBitEndianNegativeOne()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] value = BitConverter.GetBytes(-1.0f);
            float expected = -1.0f;
            float actual = ByteUtil.ByteArrayToSingle(value, byteEndian, bitEndian);
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToSingleLittleEndianLittleBitEndianLargeValue()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] value = BitConverter.GetBytes(12345.6789f);
            float expected = 12345.6789f;
            float actual = ByteUtil.ByteArrayToSingle(value, byteEndian, bitEndian);
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToSingleLittleEndianBigBitEndianZero()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Big;

            byte[] value = new byte[] { 0x00, 0x00, 0x00, 0x00 };
            float expected = 0.0f;
            float actual = ByteUtil.ByteArrayToSingle(value, byteEndian, bitEndian);
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToSingleLittleEndianBigBitEndianPositive()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Big;

            byte[] value = ByteUtil.ReverseBits(BitConverter.GetBytes(3.14f));
            float expected = 3.14f;
            float actual = ByteUtil.ByteArrayToSingle(value, byteEndian, bitEndian);
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToSingleLittleEndianBigBitEndianOne()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Big;

            byte[] value = ByteUtil.ReverseBits(BitConverter.GetBytes(1.0f));
            float expected = 1.0f;
            float actual = ByteUtil.ByteArrayToSingle(value, byteEndian, bitEndian);
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToSingleBigEndianLittleBitEndianZero()
        {
            ByteEndian byteEndian = ByteEndian.Big;
            BitEndian bitEndian = BitEndian.Little;

            byte[] value = new byte[] { 0x00, 0x00, 0x00, 0x00 };
            float expected = 0.0f;
            float actual = ByteUtil.ByteArrayToSingle(value, byteEndian, bitEndian);
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToSingleBigEndianLittleBitEndianPositive()
        {
            ByteEndian byteEndian = ByteEndian.Big;
            BitEndian bitEndian = BitEndian.Little;

            byte[] value = ByteUtil.ReverseBytes(BitConverter.GetBytes(3.14f));
            float expected = 3.14f;
            float actual = ByteUtil.ByteArrayToSingle(value, byteEndian, bitEndian);
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToSingleBigEndianLittleBitEndianNegative()
        {
            ByteEndian byteEndian = ByteEndian.Big;
            BitEndian bitEndian = BitEndian.Little;

            byte[] value = ByteUtil.ReverseBytes(BitConverter.GetBytes(-3.14f));
            float expected = -3.14f;
            float actual = ByteUtil.ByteArrayToSingle(value, byteEndian, bitEndian);
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToSingleBigEndianBigBitEndianZero()
        {
            ByteEndian byteEndian = ByteEndian.Big;
            BitEndian bitEndian = BitEndian.Big;

            byte[] value = new byte[] { 0x00, 0x00, 0x00, 0x00 };
            float expected = 0.0f;
            float actual = ByteUtil.ByteArrayToSingle(value, byteEndian, bitEndian);
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToSingleBigEndianBigBitEndianPositive()
        {
            ByteEndian byteEndian = ByteEndian.Big;
            BitEndian bitEndian = BitEndian.Big;

            byte[] value = ByteUtil.ReverseBits(ByteUtil.ReverseBytes(BitConverter.GetBytes(3.14f)));
            float expected = 3.14f;
            float actual = ByteUtil.ByteArrayToSingle(value, byteEndian, bitEndian);
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToSingleBigEndianBigBitEndianNegative()
        {
            ByteEndian byteEndian = ByteEndian.Big;
            BitEndian bitEndian = BitEndian.Big;

            byte[] value = ByteUtil.ReverseBits(ByteUtil.ReverseBytes(BitConverter.GetBytes(-3.14f)));
            float expected = -3.14f;
            float actual = ByteUtil.ByteArrayToSingle(value, byteEndian, bitEndian);
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToSingleBigEndianBigBitEndianOne()
        {
            ByteEndian byteEndian = ByteEndian.Big;
            BitEndian bitEndian = BitEndian.Big;

            byte[] value = ByteUtil.ReverseBits(ByteUtil.ReverseBytes(BitConverter.GetBytes(1.0f)));
            float expected = 1.0f;
            float actual = ByteUtil.ByteArrayToSingle(value, byteEndian, bitEndian);
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToSingleArgumentNull()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[]? value = null;
            Action act = () => ByteUtil.ByteArrayToSingle(value, byteEndian, bitEndian);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestByteArrayToSingleBigEndianLittleBitEndianPositiveHardCoded()
        {
            // big-endian bytes of 3.14f: ReverseBytes({ 0xC3, 0xF5, 0x48, 0x40 }) = { 0x40, 0x48, 0xF5, 0xC3 }
            byte[] value = new byte[] { 0x40, 0x48, 0xF5, 0xC3 };
            float expected = 3.14f;
            float actual = ByteUtil.ByteArrayToSingle(value, ByteEndian.Big, BitEndian.Little);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToSingleBigEndianLittleBitEndianNegativeHardCoded()
        {
            // big-endian bytes of -3.14f: ReverseBytes({ 0xC3, 0xF5, 0x48, 0xC0 }) = { 0xC0, 0x48, 0xF5, 0xC3 }
            byte[] value = new byte[] { 0xC0, 0x48, 0xF5, 0xC3 };
            float expected = -3.14f;
            float actual = ByteUtil.ByteArrayToSingle(value, ByteEndian.Big, BitEndian.Little);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToSingleLittleEndianBigBitEndianPositiveHardCoded()
        {
            // ReverseBits of each LE byte of 3.14f: { 0xC3, 0xF5, 0x48, 0x40 } → { 0xC3, 0xAF, 0x12, 0x02 }
            byte[] value = new byte[] { 0xC3, 0xAF, 0x12, 0x02 };
            float expected = 3.14f;
            float actual = ByteUtil.ByteArrayToSingle(value, ByteEndian.Little, BitEndian.Big);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToSingleLittleEndianBigBitEndianOneHardCoded()
        {
            // ReverseBits of each LE byte of 1.0f: { 0x00, 0x00, 0x80, 0x3F } → { 0x00, 0x00, 0x01, 0xFC }
            byte[] value = new byte[] { 0x00, 0x00, 0x01, 0xFC };
            float expected = 1.0f;
            float actual = ByteUtil.ByteArrayToSingle(value, ByteEndian.Little, BitEndian.Big);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToSingleBigEndianBigBitEndianPositiveHardCoded()
        {
            // ReverseBits of each BE byte of 3.14f: { 0x40, 0x48, 0xF5, 0xC3 } → { 0x02, 0x12, 0xAF, 0xC3 }
            byte[] value = new byte[] { 0x02, 0x12, 0xAF, 0xC3 };
            float expected = 3.14f;
            float actual = ByteUtil.ByteArrayToSingle(value, ByteEndian.Big, BitEndian.Big);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToSingleBigEndianBigBitEndianNegativeHardCoded()
        {
            // ReverseBits of each BE byte of -3.14f: { 0xC0, 0x48, 0xF5, 0xC3 } → { 0x03, 0x12, 0xAF, 0xC3 }
            byte[] value = new byte[] { 0x03, 0x12, 0xAF, 0xC3 };
            float expected = -3.14f;
            float actual = ByteUtil.ByteArrayToSingle(value, ByteEndian.Big, BitEndian.Big);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToSingleBigEndianBigBitEndianOneHardCoded()
        {
            // ReverseBits of each BE byte of 1.0f: { 0x3F, 0x80, 0x00, 0x00 } → { 0xFC, 0x01, 0x00, 0x00 }
            byte[] value = new byte[] { 0xFC, 0x01, 0x00, 0x00 };
            float expected = 1.0f;
            float actual = ByteUtil.ByteArrayToSingle(value, ByteEndian.Big, BitEndian.Big);
            actual.Should().Be(expected);
        }

        #endregion


        #region ByteArrayToDouble() tests

        [Fact]
        public void TestByteArrayToDouble()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] bytes = new byte[] { 0, 0, 0, 0, 0, 16, 112, 192 };
            double expected = -257;
            double actual = ByteUtil.ByteArrayToDouble(bytes, byteEndian, bitEndian);
            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToDoubleBigEndianLittleBitEndianZero()
        {
            byte[] bytes = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            double expected = 0.0;
            double actual = ByteUtil.ByteArrayToDouble(bytes, ByteEndian.Big, BitEndian.Little);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToDoubleBigEndianLittleBitEndian()
        {
            byte[] bytes = ByteUtil.ReverseBytes(BitConverter.GetBytes(-257.0));
            double expected = -257.0;
            double actual = ByteUtil.ByteArrayToDouble(bytes, ByteEndian.Big, BitEndian.Little);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToDoubleLittleEndianBigBitEndianZero()
        {
            byte[] bytes = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            double expected = 0.0;
            double actual = ByteUtil.ByteArrayToDouble(bytes, ByteEndian.Little, BitEndian.Big);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToDoubleLittleEndianBigBitEndian()
        {
            byte[] bytes = ByteUtil.ReverseBits(BitConverter.GetBytes(-257.0));
            double expected = -257.0;
            double actual = ByteUtil.ByteArrayToDouble(bytes, ByteEndian.Little, BitEndian.Big);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToDoubleBigEndianBigBitEndianZero()
        {
            byte[] bytes = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            double expected = 0.0;
            double actual = ByteUtil.ByteArrayToDouble(bytes, ByteEndian.Big, BitEndian.Big);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToDoubleBigEndianBigBitEndian()
        {
            byte[] bytes = ByteUtil.ReverseBits(ByteUtil.ReverseBytes(BitConverter.GetBytes(-257.0)));
            double expected = -257.0;
            double actual = ByteUtil.ByteArrayToDouble(bytes, ByteEndian.Big, BitEndian.Big);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToDoubleBigEndianLittleBitEndianHardCoded()
        {
            // big-endian bytes of -257.0: ReverseBytes({ 0x00, 0x00, 0x00, 0x00, 0x00, 0x10, 0x70, 0xC0 }) = { 0xC0, 0x70, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00 }
            byte[] bytes = new byte[] { 0xC0, 0x70, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00 };
            double expected = -257.0;
            double actual = ByteUtil.ByteArrayToDouble(bytes, ByteEndian.Big, BitEndian.Little);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToDoubleLittleEndianBigBitEndianHardCoded()
        {
            // ReverseBits of each LE byte of -257.0: { 0x00,0x00,0x00,0x00,0x00,0x10,0x70,0xC0 } → { 0x00,0x00,0x00,0x00,0x00,0x08,0x0E,0x03 }
            byte[] bytes = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x08, 0x0E, 0x03 };
            double expected = -257.0;
            double actual = ByteUtil.ByteArrayToDouble(bytes, ByteEndian.Little, BitEndian.Big);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestByteArrayToDoubleBigEndianBigBitEndianHardCoded()
        {
            // ReverseBits of each BE byte of -257.0: { 0xC0,0x70,0x10,0x00,0x00,0x00,0x00,0x00 } → { 0x03,0x0E,0x08,0x00,0x00,0x00,0x00,0x00 }
            byte[] bytes = new byte[] { 0x03, 0x0E, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00 };
            double expected = -257.0;
            double actual = ByteUtil.ByteArrayToDouble(bytes, ByteEndian.Big, BitEndian.Big);
            actual.Should().Be(expected);
        }

        #endregion


        #region Int32ToByteArray() tests

        [Fact]
        public void TestInt32ToByteArray()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] expected = new byte[] { 255, 254, 255, 255 };
            byte[] actual = ByteUtil.Int32ToByteArray(-257, byteEndian, bitEndian);

            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestInt32ToByteArrayBigEndianLittleBitEndianZero()
        {
            byte[] expected = new byte[] { 0, 0, 0, 0 };
            byte[] actual = ByteUtil.Int32ToByteArray(0, ByteEndian.Big, BitEndian.Little);
            actual.Length.Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++) actual[i].Should().Be(expected[i]);
        }

        [Fact]
        public void TestInt32ToByteArrayBigEndianLittleBitEndian()
        {
            byte[] expected = ByteUtil.ReverseBytes(BitConverter.GetBytes(-257));
            byte[] actual = ByteUtil.Int32ToByteArray(-257, ByteEndian.Big, BitEndian.Little);
            actual.Length.Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++) actual[i].Should().Be(expected[i]);
        }

        [Fact]
        public void TestInt32ToByteArrayLittleEndianBigBitEndianZero()
        {
            byte[] expected = new byte[] { 0, 0, 0, 0 };
            byte[] actual = ByteUtil.Int32ToByteArray(0, ByteEndian.Little, BitEndian.Big);
            actual.Length.Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++) actual[i].Should().Be(expected[i]);
        }

        [Fact]
        public void TestInt32ToByteArrayLittleEndianBigBitEndian()
        {
            byte[] expected = ByteUtil.ReverseBits(BitConverter.GetBytes(-257));
            byte[] actual = ByteUtil.Int32ToByteArray(-257, ByteEndian.Little, BitEndian.Big);
            actual.Length.Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++) actual[i].Should().Be(expected[i]);
        }

        [Fact]
        public void TestInt32ToByteArrayBigEndianBigBitEndianZero()
        {
            byte[] expected = new byte[] { 0, 0, 0, 0 };
            byte[] actual = ByteUtil.Int32ToByteArray(0, ByteEndian.Big, BitEndian.Big);
            actual.Length.Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++) actual[i].Should().Be(expected[i]);
        }

        [Fact]
        public void TestInt32ToByteArrayBigEndianBigBitEndian()
        {
            byte[] expected = ByteUtil.ReverseBits(ByteUtil.ReverseBytes(BitConverter.GetBytes(-257)));
            byte[] actual = ByteUtil.Int32ToByteArray(-257, ByteEndian.Big, BitEndian.Big);
            actual.Length.Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++) actual[i].Should().Be(expected[i]);
        }

        [Fact]
        public void TestInt32ToByteArrayBigEndianLittleBitEndianHardCoded()
        {
            // -257 = 0xFFFFFEFF LE; big-endian = { 0xFF, 0xFF, 0xFE, 0xFF }
            byte[] expected = new byte[] { 0xFF, 0xFF, 0xFE, 0xFF };
            byte[] actual = ByteUtil.Int32ToByteArray(-257, ByteEndian.Big, BitEndian.Little);
            actual.Length.Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++) actual[i].Should().Be(expected[i]);
        }

        [Fact]
        public void TestInt32ToByteArrayLittleEndianBigBitEndianHardCoded()
        {
            // -257 LE = { 0xFF, 0xFE, 0xFF, 0xFF }; ReverseBits each: { 0xFF, 0x7F, 0xFF, 0xFF }
            byte[] expected = new byte[] { 0xFF, 0x7F, 0xFF, 0xFF };
            byte[] actual = ByteUtil.Int32ToByteArray(-257, ByteEndian.Little, BitEndian.Big);
            actual.Length.Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++) actual[i].Should().Be(expected[i]);
        }

        [Fact]
        public void TestInt32ToByteArrayBigEndianBigBitEndianHardCoded()
        {
            // -257 BE = { 0xFF, 0xFF, 0xFE, 0xFF }; ReverseBits each: { 0xFF, 0xFF, 0x7F, 0xFF }
            byte[] expected = new byte[] { 0xFF, 0xFF, 0x7F, 0xFF };
            byte[] actual = ByteUtil.Int32ToByteArray(-257, ByteEndian.Big, BitEndian.Big);
            actual.Length.Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++) actual[i].Should().Be(expected[i]);
        }

        #endregion


        #region Int16ToByteArray() tests

        [Fact]
        public void TestInt16ToByteArray()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] expected = new byte[] { 255, 254 };
            byte[] actual = ByteUtil.Int16ToByteArray(-257, byteEndian, bitEndian);

            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestInt16ToByteArrayBigEndianLittleBitEndianZero()
        {
            byte[] expected = new byte[] { 0, 0 };
            byte[] actual = ByteUtil.Int16ToByteArray(0, ByteEndian.Big, BitEndian.Little);
            actual.Length.Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++) actual[i].Should().Be(expected[i]);
        }

        [Fact]
        public void TestInt16ToByteArrayBigEndianLittleBitEndian()
        {
            byte[] expected = ByteUtil.ReverseBytes(BitConverter.GetBytes((Int16)(-257)));
            byte[] actual = ByteUtil.Int16ToByteArray(-257, ByteEndian.Big, BitEndian.Little);
            actual.Length.Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++) actual[i].Should().Be(expected[i]);
        }

        [Fact]
        public void TestInt16ToByteArrayLittleEndianBigBitEndianZero()
        {
            byte[] expected = new byte[] { 0, 0 };
            byte[] actual = ByteUtil.Int16ToByteArray(0, ByteEndian.Little, BitEndian.Big);
            actual.Length.Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++) actual[i].Should().Be(expected[i]);
        }

        [Fact]
        public void TestInt16ToByteArrayLittleEndianBigBitEndian()
        {
            byte[] expected = ByteUtil.ReverseBits(BitConverter.GetBytes((Int16)(-257)));
            byte[] actual = ByteUtil.Int16ToByteArray(-257, ByteEndian.Little, BitEndian.Big);
            actual.Length.Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++) actual[i].Should().Be(expected[i]);
        }

        [Fact]
        public void TestInt16ToByteArrayBigEndianBigBitEndianZero()
        {
            byte[] expected = new byte[] { 0, 0 };
            byte[] actual = ByteUtil.Int16ToByteArray(0, ByteEndian.Big, BitEndian.Big);
            actual.Length.Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++) actual[i].Should().Be(expected[i]);
        }

        [Fact]
        public void TestInt16ToByteArrayBigEndianBigBitEndian()
        {
            byte[] expected = ByteUtil.ReverseBits(ByteUtil.ReverseBytes(BitConverter.GetBytes((Int16)(-257))));
            byte[] actual = ByteUtil.Int16ToByteArray(-257, ByteEndian.Big, BitEndian.Big);
            actual.Length.Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++) actual[i].Should().Be(expected[i]);
        }

        [Fact]
        public void TestInt16ToByteArrayBigEndianLittleBitEndianHardCoded()
        {
            // -257 as Int16 = 0xFEFF LE; big-endian = { 0xFE, 0xFF }
            byte[] expected = new byte[] { 0xFE, 0xFF };
            byte[] actual = ByteUtil.Int16ToByteArray(-257, ByteEndian.Big, BitEndian.Little);
            actual.Length.Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++) actual[i].Should().Be(expected[i]);
        }

        [Fact]
        public void TestInt16ToByteArrayLittleEndianBigBitEndianHardCoded()
        {
            // -257 as Int16 LE = { 0xFF, 0xFE }; ReverseBits each: { 0xFF, 0x7F }
            byte[] expected = new byte[] { 0xFF, 0x7F };
            byte[] actual = ByteUtil.Int16ToByteArray(-257, ByteEndian.Little, BitEndian.Big);
            actual.Length.Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++) actual[i].Should().Be(expected[i]);
        }

        [Fact]
        public void TestInt16ToByteArrayBigEndianBigBitEndianHardCoded()
        {
            // -257 as Int16 BE = { 0xFE, 0xFF }; ReverseBits each: { 0x7F, 0xFF }
            byte[] expected = new byte[] { 0x7F, 0xFF };
            byte[] actual = ByteUtil.Int16ToByteArray(-257, ByteEndian.Big, BitEndian.Big);
            actual.Length.Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++) actual[i].Should().Be(expected[i]);
        }

        #endregion


        #region Int16ToByte() tests

        [Fact]
        public void TestInt16ToByteLittleBitEndianZero()
        {
            byte expected = 0;
            byte actual = ByteUtil.Int16ToByte(0, BitEndian.Little);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestInt16ToByteLittleBitEndianOne()
        {
            byte expected = 1;
            byte actual = ByteUtil.Int16ToByte(1, BitEndian.Little);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestInt16ToByteLittleBitEndianMaxByte()
        {
            byte expected = 255;
            byte actual = ByteUtil.Int16ToByte(255, BitEndian.Little);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestInt16ToByteBigBitEndianZero()
        {
            byte expected = 0;
            byte actual = ByteUtil.Int16ToByte(0, BitEndian.Big);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestInt16ToByteBigBitEndianOne()
        {
            // ReverseBits((byte)1) = ReverseBits(0x01) = 0x80 = 128
            byte expected = 0x80;
            byte actual = ByteUtil.Int16ToByte(1, BitEndian.Big);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestInt16ToByteBigBitEndianMaxByte()
        {
            // ReverseBits(0xFF) = 0xFF = 255
            byte expected = 0xFF;
            byte actual = ByteUtil.Int16ToByte(255, BitEndian.Big);
            actual.Should().Be(expected);
        }

        #endregion


        #region DoubleToByteArray() tests

        [Fact]
        public void TestDoubleToByteArray()
        {
            ByteEndian byteEndian = ByteEndian.Little;
            BitEndian bitEndian = BitEndian.Little;

            byte[] expected = new byte[] { 0, 0, 0, 0, 0, 16, 112, 192 };
            byte[] actual = ByteUtil.DoubleToByteArray(-257.0, byteEndian, bitEndian);

            (actual.Length).Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                (actual[i]).Should().Be(expected[i]);
            }
        }

        [Fact]
        public void TestDoubleToByteArrayBigEndianLittleBitEndianZero()
        {
            byte[] expected = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            byte[] actual = ByteUtil.DoubleToByteArray(0.0, ByteEndian.Big, BitEndian.Little);
            actual.Length.Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++) actual[i].Should().Be(expected[i]);
        }

        [Fact]
        public void TestDoubleToByteArrayBigEndianLittleBitEndian()
        {
            byte[] expected = ByteUtil.ReverseBytes(BitConverter.GetBytes(-257.0));
            byte[] actual = ByteUtil.DoubleToByteArray(-257.0, ByteEndian.Big, BitEndian.Little);
            actual.Length.Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++) actual[i].Should().Be(expected[i]);
        }

        [Fact]
        public void TestDoubleToByteArrayLittleEndianBigBitEndianZero()
        {
            byte[] expected = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            byte[] actual = ByteUtil.DoubleToByteArray(0.0, ByteEndian.Little, BitEndian.Big);
            actual.Length.Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++) actual[i].Should().Be(expected[i]);
        }

        [Fact]
        public void TestDoubleToByteArrayLittleEndianBigBitEndian()
        {
            byte[] expected = ByteUtil.ReverseBits(BitConverter.GetBytes(-257.0));
            byte[] actual = ByteUtil.DoubleToByteArray(-257.0, ByteEndian.Little, BitEndian.Big);
            actual.Length.Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++) actual[i].Should().Be(expected[i]);
        }

        [Fact]
        public void TestDoubleToByteArrayBigEndianBigBitEndianZero()
        {
            byte[] expected = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            byte[] actual = ByteUtil.DoubleToByteArray(0.0, ByteEndian.Big, BitEndian.Big);
            actual.Length.Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++) actual[i].Should().Be(expected[i]);
        }

        [Fact]
        public void TestDoubleToByteArrayBigEndianBigBitEndian()
        {
            byte[] expected = ByteUtil.ReverseBits(ByteUtil.ReverseBytes(BitConverter.GetBytes(-257.0)));
            byte[] actual = ByteUtil.DoubleToByteArray(-257.0, ByteEndian.Big, BitEndian.Big);
            actual.Length.Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++) actual[i].Should().Be(expected[i]);
        }

        [Fact]
        public void TestDoubleToByteArrayBigEndianLittleBitEndianHardCoded()
        {
            // -257.0 LE = { 0x00,0x00,0x00,0x00,0x00,0x10,0x70,0xC0 }; big-endian = { 0xC0,0x70,0x10,0x00,0x00,0x00,0x00,0x00 }
            byte[] expected = new byte[] { 0xC0, 0x70, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00 };
            byte[] actual = ByteUtil.DoubleToByteArray(-257.0, ByteEndian.Big, BitEndian.Little);
            actual.Length.Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++) actual[i].Should().Be(expected[i]);
        }

        [Fact]
        public void TestDoubleToByteArrayLittleEndianBigBitEndianHardCoded()
        {
            // -257.0 LE = { 0x00,0x00,0x00,0x00,0x00,0x10,0x70,0xC0 }; ReverseBits each: { 0x00,0x00,0x00,0x00,0x00,0x08,0x0E,0x03 }
            byte[] expected = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x08, 0x0E, 0x03 };
            byte[] actual = ByteUtil.DoubleToByteArray(-257.0, ByteEndian.Little, BitEndian.Big);
            actual.Length.Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++) actual[i].Should().Be(expected[i]);
        }

        [Fact]
        public void TestDoubleToByteArrayBigEndianBigBitEndianHardCoded()
        {
            // -257.0 BE = { 0xC0,0x70,0x10,0x00,0x00,0x00,0x00,0x00 }; ReverseBits each: { 0x03,0x0E,0x08,0x00,0x00,0x00,0x00,0x00 }
            byte[] expected = new byte[] { 0x03, 0x0E, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00 };
            byte[] actual = ByteUtil.DoubleToByteArray(-257.0, ByteEndian.Big, BitEndian.Big);
            actual.Length.Should().Be(expected.Length);
            for (int i = 0; i < expected.Length; i++) actual[i].Should().Be(expected[i]);
        }

        #endregion


        #region BytesAreEqual() tests

        [Fact]
        public void TestBytesAreEqualIdenticalArrays()
        {
            byte[] arr1 = new byte[] { 0x01, 0x02, 0x03, 0x04 };
            byte[] arr2 = new byte[] { 0x01, 0x02, 0x03, 0x04 };
            bool expected = true;
            bool actual = arr1.AsSpan().SequenceEqual(arr2);

            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestBytesAreEqualEmptyArrays()
        {
            byte[] arr1 = Array.Empty<byte>();
            byte[] arr2 = Array.Empty<byte>();
            bool expected = true;
            bool actual = arr1.AsSpan().SequenceEqual(arr2);

            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestBytesAreEqualSingleElementArraysSame()
        {
            byte[] arr1 = new byte[] { 0xFF };
            byte[] arr2 = new byte[] { 0xFF };
            bool expected = true;
            bool actual = arr1.AsSpan().SequenceEqual(arr2);

            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestBytesAreEqualSingleElementArraysDifferent()
        {
            byte[] arr1 = new byte[] { 0xFF };
            byte[] arr2 = new byte[] { 0x00 };
            bool expected = false;
            bool actual = arr1.AsSpan().SequenceEqual(arr2);

            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestBytesAreEqualDifferentLength()
        {
            byte[] arr1 = new byte[] { 0x01, 0x02, 0x03 };
            byte[] arr2 = new byte[] { 0x01, 0x02, 0x03, 0x04 };
            bool expected = false;
            bool actual = arr1.AsSpan().SequenceEqual(arr2);

            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestBytesAreEqualDifferentContent()
        {
            byte[] arr1 = new byte[] { 0x01, 0x02, 0x03, 0x04 };
            byte[] arr2 = new byte[] { 0x01, 0x02, 0x03, 0x05 };
            bool expected = false;
            bool actual = arr1.AsSpan().SequenceEqual(arr2);

            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestBytesAreEqualAllZeros()
        {
            byte[] arr1 = new byte[] { 0x00, 0x00, 0x00, 0x00 };
            byte[] arr2 = new byte[] { 0x00, 0x00, 0x00, 0x00 };
            bool expected = true;
            bool actual = arr1.AsSpan().SequenceEqual(arr2);

            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestBytesAreEqualAllOnes()
        {
            byte[] arr1 = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF };
            byte[] arr2 = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF };
            bool expected = true;
            bool actual = arr1.AsSpan().SequenceEqual(arr2);

            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestBytesAreEqualDifferentAtFirstPosition()
        {
            byte[] arr1 = new byte[] { 0xFF, 0x02, 0x03, 0x04 };
            byte[] arr2 = new byte[] { 0x00, 0x02, 0x03, 0x04 };
            bool expected = false;
            bool actual = arr1.AsSpan().SequenceEqual(arr2);

            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestBytesAreEqualDifferentAtLastPosition()
        {
            byte[] arr1 = new byte[] { 0x01, 0x02, 0x03, 0xFF };
            byte[] arr2 = new byte[] { 0x01, 0x02, 0x03, 0x00 };
            bool expected = false;
            bool actual = arr1.AsSpan().SequenceEqual(arr2);

            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestBytesAreEqualDifferentAtMiddlePosition()
        {
            byte[] arr1 = new byte[] { 0x01, 0x02, 0xFF, 0x04 };
            byte[] arr2 = new byte[] { 0x01, 0x02, 0x00, 0x04 };
            bool expected = false;
            bool actual = arr1.AsSpan().SequenceEqual(arr2);

            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestBytesAreEqualLongerArrays()
        {
            byte[] arr1 = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };
            byte[] arr2 = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };
            bool expected = true;
            bool actual = arr1.AsSpan().SequenceEqual(arr2);

            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestBytesAreEqualLongerArraysDifferent()
        {
            byte[] arr1 = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };
            byte[] arr2 = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x09 };
            bool expected = false;
            bool actual = arr1.AsSpan().SequenceEqual(arr2);

            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestBytesAreEqualAlternatingPattern()
        {
            byte[] arr1 = new byte[] { 0xAA, 0x55, 0xAA, 0x55 };
            byte[] arr2 = new byte[] { 0xAA, 0x55, 0xAA, 0x55 };
            bool expected = true;
            bool actual = arr1.AsSpan().SequenceEqual(arr2);

            (actual).Should().Be(expected);
        }

        [Fact]
        public void TestBytesAreEqualFirstArrayNull()
        {
            byte[]? arr1 = null;
            byte[] arr2 = new byte[] { 0x01, 0x02 };
#pragma warning disable CS0618 // Type or member is obsolete
            Action act = () => ByteUtil.BytesAreEqual(arr1, arr2);
#pragma warning restore CS0618 // Type or member is obsolete
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestBytesAreEqualSecondArrayNull()
        {
            byte[] arr1 = new byte[] { 0x01, 0x02 };
            byte[]? arr2 = null;
#pragma warning disable CS0618 // Type or member is obsolete
            Action act = () => ByteUtil.BytesAreEqual(arr1, arr2);
#pragma warning restore CS0618 // Type or member is obsolete
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TestBytesAreEqualBothArraysNull()
        {
            byte[]? arr1 = null;
            byte[]? arr2 = null;
#pragma warning disable CS0618 // Type or member is obsolete
            Action act = () => ByteUtil.BytesAreEqual(arr1, arr2);
#pragma warning restore CS0618 // Type or member is obsolete
            act.Should().Throw<ArgumentNullException>();
        }

        #endregion
    }
}
