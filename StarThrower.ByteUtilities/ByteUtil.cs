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
using StarThrower.Logging;

namespace StarThrower.ByteUtilities
{
    public static class ByteUtil
    {

        /// <summary>
        /// Retrieves a subset of bytes from a byte array. The subset starts at a specified position and has a specified length.
        /// </summary>
        /// <param name="source">The original array of bytes.</param>
        /// <param name="startIndex">The index of the start of the subset.</param>
        /// <param name="length">The number of bytes in the subset.</param>
        /// <returns>A byte array equivalent to the subset of length length that begins at startIndex in the original byte array, or an empty byte array if startIndex is equal to the length of the original byte array and length is zero.</returns>
        /// <exception cref="ArgumentNullException">Thrown if source is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if startIndex is less than zero or greater than source.Length - 1.  Also thrown if startIndex + length exceeds the length of the array.</exception>
        public static byte[] ByteSubstring(byte[]? source, long startIndex, long length)
        {
            return ByteSubstring(source, startIndex, length, false);
        }

        /// <summary>
        /// Retrieves a subset of bytes from a byte array. The subset starts at a specified position and has a specified length.
        /// </summary>
        /// <param name="source">The original array of bytes.</param>
        /// <param name="startIndex">The index of the start of the subset.</param>
        /// <param name="length">The number of bytes in the subset.</param>
        /// <param name="trimWithNulls">Whether or not to pad the space remaining after startIndex + length with nulls</param>
        /// <returns>A byte array equivalent to the subset of length length that begins at startIndex in the original byte array, or an empty byte array if startIndex is equal to the length of the original byte array and length is zero.</returns>
        /// <exception cref="ArgumentNullException">Thrown if source is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if startIndex is less than zero or greater than source.Length - 1.  Also thrown if startIndex + length exceeds the length of the array.</exception>
        public static byte[] ByteSubstring(byte[]? source, long startIndex, long length, bool trimWithNulls)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentOutOfRangeException.ThrowIfNegative(startIndex);
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(startIndex, source.Length);
            if ((startIndex + length) > source.Length) throw new ArgumentOutOfRangeException(nameof(length));

            bool isNullTerminated = false;

            try
            {
                byte[] result = new byte[length];

                for (long i = 0; i < length; i++)
                {
                    if (!isNullTerminated)
                    {
                        byte b = source[startIndex + i];
                        result[i] = b;
                        if (trimWithNulls && b == 0)
                        {
                            isNullTerminated = true;
                        }
                    }
                    else
                    {
                        result[i] = 0;
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Bytes.ByteSubstring(byte[], long, long)", ex);
                throw;
            }
        }

        /// <summary>
        /// Given reverses the order of elements in a byte array.
        /// </summary>
        /// <param name="source">The byte array to be reversed.</param>
        /// <returns>A new instance of a byte array with the elements in reverse order from the original.</returns>
        /// <exception cref="ArgumentNullException">Thrown if source is null.</exception>
        public static byte[] ReverseBytes(byte[]? source)
        {
            ArgumentNullException.ThrowIfNull(source);

            try
            {
                byte[] result = new byte[source.Length];

                for (int i = 0, j = source.Length - 1; i < source.Length; i++, j--)
                {
                    result[i] = source[j];
                }

                return result;
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Bytes.ReverseBytes(byte[])", ex);
                throw;
            }
        }

        /// <summary>
        /// Reverses the order of bits within a single byte.
        /// </summary>
        /// <param name="value">The byte whose bits are to be reversed.</param>
        /// <returns>A byte with the bits in reverse order from the original.</returns>
        public static byte ReverseBits(byte value)
        {
            try
            {
                byte result = 0;
                for (int i = 0; i < 8; i++)
                {
                    result = (byte)((result << 1) | (value & 1));
                    value >>= 1;
                }
                return result;
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Bytes.ReverseBits(byte)", ex);
                throw;
            }
        }

        /// <summary>
        /// Reverses the order of bits within each byte in a byte array.
        /// </summary>
        /// <param name="source">The byte array whose bits are to be reversed.</param>
        /// <returns>A new instance of a byte array with the bits in each byte reversed.</returns>
        /// <exception cref="ArgumentNullException">Thrown if source is null.</exception>
        public static byte[] ReverseBits(byte[]? source)
        {
            ArgumentNullException.ThrowIfNull(source);

            try
            {
                byte[] result = new byte[source.Length];
                for (int i = 0; i < source.Length; i++)
                {
                    result[i] = ReverseBits(source[i]);
                }
                return result;
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Bytes.ReverseBits(byte[])", ex);
                throw;
            }
        }

        /// <summary>
        /// Converts a byte array to a single (float).
        /// </summary>
        /// <param name="value">The array of bytes to be converted</param>
        /// <param name="byteEndian">The Byte Endian of the byte array</param>
        /// <param name="bitEndian">The Bit Endian of each byte in the array.</param>
        /// <returns>The float value of the byte array.</returns>
        /// <exception cref="ArgumentNullException">Thrown if bytes is null.</exception>
        public static float ByteArrayToSingle(byte[]? value, ByteEndian byteEndian, BitEndian bitEndian)
        {
            ArgumentNullException.ThrowIfNull(value);

            try
            {
                switch (byteEndian)
                {
                    case ByteEndian.Little:
                        switch (bitEndian)
                        {
                            case BitEndian.Little:
                                return BitConverter.ToSingle(value, 0);
                            case BitEndian.Big:
                                return BitConverter.ToSingle(ReverseBits(value), 0);
                            default:
                                throw new InvalidEndianException();
                        }
                    case ByteEndian.Big:
                        switch (bitEndian)
                        {
                            case BitEndian.Little:
                                return BitConverter.ToSingle(ReverseBytes(value), 0);
                            case BitEndian.Big:
                                return BitConverter.ToSingle(ReverseBits(ReverseBytes(value)), 0);
                            default:
                                throw new InvalidEndianException();
                        }
                    default:
                        throw new InvalidEndianException();
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Bytes.ByteArrayToInt32(byte[], ByteEndian, BitEndian)", ex);
                throw;
            }
        }

        /// <summary>
        /// Converts a byte array to an Int.
        /// </summary>
        /// <param name="value">The array of bytes to be converted</param>
        /// <param name="byteEndian">The Byte Endian of the byte array</param>
        /// <param name="bitEndian">The Bit Endian of each byte in the array.</param>
        /// <returns>The Integer value of the byte array.</returns>
        /// <exception cref="ArgumentNullException">Thrown if bytes is null.</exception>
        public static Int32 ByteArrayToInt32(byte[]? value, ByteEndian byteEndian, BitEndian bitEndian)
        {
            ArgumentNullException.ThrowIfNull(value);

            try
            {
                switch (byteEndian)
                {
                    case ByteEndian.Little:
                        switch (bitEndian)
                        {
                            case BitEndian.Little:
                                //return bytes[3] << 32 | bytes[2] << 16 | bytes[1] << 8 | bytes[0];
                                return BitConverter.ToInt32(value, 0);
                            case BitEndian.Big:
                                return BitConverter.ToInt32(ReverseBits(value), 0);
                            default:
                                throw new InvalidEndianException();
                        }
                    case ByteEndian.Big:
                        switch (bitEndian)
                        {
                            case BitEndian.Little:
                                //return bytes[0] << 32 | bytes[1] << 16 | bytes[2] << 8 | bytes[3]; //This works for fileCode (9994) and version (1000)
                                return BitConverter.ToInt32(ReverseBytes(value), 0);
                            case BitEndian.Big:
                                return BitConverter.ToInt32(ReverseBits(ReverseBytes(value)), 0);
                            default:
                                throw new InvalidEndianException();
                        }
                    default:
                        throw new InvalidEndianException();
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Bytes.ByteArrayToInt32(byte[], ByteEndian, BitEndian)", ex);
                throw;
            }
        }

        /// <summary>
        /// Converts a byte array to a short.
        /// </summary>
        /// <param name="value">The array of bytes to be converted</param>
        /// <param name="byteEndian">The Byte Endian of the byte array</param>
        /// <param name="bitEndian">The Bit Endian of each byte in the array.</param>
        /// <returns>The short value of the byte array.</returns>
        /// <exception cref="ArgumentNullException">Thrown if bytes is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if there are not at least two bytes in the array.</exception>
        public static Int16 ByteArrayToInt16(byte[]? value, ByteEndian byteEndian, BitEndian bitEndian)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value.Length < 2) throw new ArgumentOutOfRangeException(nameof(value));

            try
            {
                switch (byteEndian)
                {
                    case ByteEndian.Little:
                        switch (bitEndian)
                        {
                            case BitEndian.Little:
                                //return bytes[1] << 8 | bytes[0];
                                return BitConverter.ToInt16(value, 0);
                            case BitEndian.Big:
                                throw new NotImplementedException();
                            default:
                                throw new InvalidEndianException();
                        }
                    case ByteEndian.Big:
                        switch (bitEndian)
                        {
                            case BitEndian.Little:
                                //return bytes[1] * 2 + bytes[0] * 4;
                                return BitConverter.ToInt16(ReverseBytes(value), 0);
                            case BitEndian.Big:
                                throw new NotImplementedException();
                            default:
                                throw new InvalidEndianException();
                        }
                    default:
                        throw new InvalidEndianException();
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Bytes.ByteArrayToInt16(byte[], ByteEndian, BitEndian)", ex);
                throw;
            }
        }

        /// <summary>
        /// Converts a byte to an Int16 (short)
        /// </summary>
        /// <param name="bytes">The byte to be converted.</param>
        /// <param name="bitEndian">Whether the bits of the byte should be treated as big or little endian.</param>
        /// <returns>The resulting Int16.</returns>
        /// <remarks>
        /// It is possible to indicate the Endian of the byte array by specifying bitEndian.
        /// 
        /// NOTE: BitEndian.Big is not yet supported
        /// </remarks>
        /// <exception cref="InvalidEndianException">Thrown if bitEndian is something other than Little or Big.</exception>
        public static Int16 ByteToInt16(byte bytes, BitEndian bitEndian)
        {
            try
            {
                switch (bitEndian)
                {
                    case BitEndian.Little:
                        return (Int16)bytes;
                    case BitEndian.Big:
                        throw new NotImplementedException();
                    default:
                        throw new InvalidEndianException();
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Bytes.ByteToInt16(byte, BitEndian)", ex);
                throw;
            }
        }

        /// <summary>
        /// Converts a byte array to a double
        /// </summary>
        /// <param name="value">The byte array to be converted.</param>
        /// <param name="byteEndian">Whether the bytes should be treated as big or little endian.</param>
        /// <param name="bitEndian">Whether the bits of each byte should be treated as big or little endian.</param>
        /// <returns>The resulting double.</returns>
        /// <remarks>
        /// It is possible to indicate the Endian of the byte array by specifying byteEndian and bitEndian.
        /// 
        /// NOTE: BitEndian.Big is not yet supported
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown if bytes is null.</exception>
        /// <exception cref="InvalidEndianException">Thrown if byteEndian or bitEndian are something other than Little or Big.</exception>
        /// <exception cref="NotImplementedException">Thrown if dealing with a big endian bit order.</exception>
        public static double ByteArrayToDouble(byte[]? value, ByteEndian byteEndian, BitEndian bitEndian)
        {
            ArgumentNullException.ThrowIfNull(value);

            try
            {
                switch (byteEndian)
                {
                    case ByteEndian.Little:
                        switch (bitEndian)
                        {
                            case BitEndian.Little:
                                return BitConverter.ToDouble(value, 0);
                            case BitEndian.Big:
                                throw new NotImplementedException();
                            default:
                                throw new InvalidEndianException();
                        }
                    case ByteEndian.Big:
                        switch (bitEndian)
                        {
                            case BitEndian.Little:
                                return BitConverter.ToDouble(ReverseBytes(value), 0);
                            case BitEndian.Big:
                                throw new NotImplementedException();
                            default:
                                throw new InvalidEndianException();
                        }
                    default:
                        throw new InvalidEndianException();
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Bytes.ByteArrayToDouble(byte[], ByteEndian, BitEndian)", ex);
                throw;
            }
        }

        /// <summary>
        /// Converts an Int32 (int) to a byte array.
        /// </summary>
        /// <param name="target">The Int32 to be converted.</param>
        /// <param name="byteEndian">Whether the bytes should be big or little endian.</param>
        /// <param name="bitEndian">Whether the bits of each byte should be big or little endian.</param>
        /// <returns>The resulting byte array.</returns>
        /// <remarks>
        /// It is possible to indicate the Endian of the byte array by specifying byteEndian and bitEndian.
        /// 
        /// NOTE: BitEndian.Big is not yet supported
        /// </remarks>
        /// <exception cref="InvalidEndianException">Thrown if byteEndian or bitEndian are something other than Little or Big.</exception>
        /// <exception cref="NotImplementedException">Thrown if dealing with a big endian bit order.</exception>
        public static byte[] Int32ToByteArray(Int32 target, ByteEndian byteEndian, BitEndian bitEndian)
        {
            try
            {
                switch (byteEndian)
                {
                    case ByteEndian.Little:
                        switch (bitEndian)
                        {
                            case BitEndian.Little:
                                //result[0] = (byte)target;
                                //result[1] = (byte)(target >> 8);
                                //result[2] = (byte)(target >> 16);
                                //result[3] = (byte)(target >> 24);
                                return BitConverter.GetBytes(target);
                            case BitEndian.Big:
                                throw new NotImplementedException();
                            default:
                                throw new InvalidEndianException();
                        }
                    case ByteEndian.Big:
                        switch (bitEndian)
                        {
                            case BitEndian.Little:
                                return ReverseBytes(BitConverter.GetBytes(target));
                            case BitEndian.Big:
                                throw new NotImplementedException();
                            default:
                                throw new InvalidEndianException();
                        }
                    default:
                        throw new InvalidEndianException();
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Bytes.Int32ToByteArray(Int32, ByteEndian, BitEndian)", ex);
                throw;
            }
        }

        /// <summary>
        /// Converts an Int16 (short) to a byte array.
        /// </summary>
        /// <param name="target">The Int16 to be converted.</param>
        /// <param name="byteEndian">Whether the bytes should be big or little endian.</param>
        /// <param name="bitEndian">Whether the bits of each byte should be big or little endian.</param>
        /// <returns>The resulting byte array.</returns>
        /// <remarks>
        /// It is possible to indicate the Endian of the byte array by specifying byteEndian and bitEndian.
        /// 
        /// NOTE: BitEndian.Big is not yet supported
        /// </remarks>
        /// <exception cref="InvalidEndianException">Thrown if byteEndian or bitEndian are something other than Little or Big.</exception>
        /// <exception cref="NotImplementedException">Thrown if dealing with a big endian bit order.</exception>
        public static byte[] Int16ToByteArray(Int16 target, ByteEndian byteEndian, BitEndian bitEndian)
        {
            try
            {
                switch (byteEndian)
                {
                    case ByteEndian.Little:
                        switch (bitEndian)
                        {
                            case BitEndian.Little:
                                //result[0] = (byte)target;
                                //result[1] = (byte)(target >> 8);
                                return BitConverter.GetBytes(target);
                            case BitEndian.Big:
                                throw new NotImplementedException();
                            default:
                                throw new InvalidEndianException();
                        }
                    case ByteEndian.Big:
                        switch (bitEndian)
                        {
                            case BitEndian.Little:
                                return ReverseBytes(BitConverter.GetBytes(target));
                            case BitEndian.Big:
                                throw new NotImplementedException();
                            default:
                                throw new InvalidEndianException();
                        }
                    default:
                        throw new InvalidEndianException();
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Bytes.Int16ToByteArray(Int16, ByteEndian, BitEndian)", ex);
                throw;
            }
        }

        /// <summary>
        /// Converts an Int16 (short) to a byte array.
        /// </summary>
        /// <param name="target">The Int16 to be converted.</param>
        /// <param name="bitEndian">Whether the bits should be big or little endian.</param>
        /// <returns>The resulting byte.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if target is less than zero or greater than 255.</exception>
        /// <exception cref="InvalidEndianException">Thrown if byteEndian or bitEndian are something other than Little or Big.</exception>
        /// <exception cref="NotImplementedException">Thrown if dealing with a big endian bit order.</exception>
        public static byte Int16ToByte(Int16 target, BitEndian bitEndian)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(target);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(target, 255);

            try
            {
                switch (bitEndian)
                {
                    case BitEndian.Little:
                        return (byte)target;
                    case BitEndian.Big:
                        throw new NotImplementedException();
                    default:
                        throw new InvalidEndianException();
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Bytes.Int16ToByte(Int16, BitEndian)", ex);
                throw;
            }
        }

        /// <summary>
        /// Converts a double to a byte array.
        /// </summary>
        /// <param name="target">The double to be converted.</param>
        /// <param name="byteEndian">Whether the bytes should be big or little endian.</param>
        /// <param name="bitEndian">Whether the bits of each byte should be big or little endian.</param>
        /// <returns>The resulting byte array.</returns>
        /// <remarks>
        /// It is possible to indicate the Endian of the byte array by specifying byteEndian and bitEndian.
        /// 
        /// NOTE: BitEndian.Big is not yet supported
        /// </remarks>
        /// <exception cref="InvalidEndianException">Thrown if byteEndian or bitEndian are something other than Little or Big.</exception>
        /// <exception cref="NotImplementedException">Thrown if dealing with a big endian bit order.</exception>
        public static byte[] DoubleToByteArray(double target, ByteEndian byteEndian, BitEndian bitEndian)
        {
            try
            {
                switch (byteEndian)
                {
                    case ByteEndian.Little:
                        switch (bitEndian)
                        {
                            case BitEndian.Little:
                                return BitConverter.GetBytes(target);
                            case BitEndian.Big:
                                throw new NotImplementedException();
                            default:
                                throw new InvalidEndianException();
                        }
                    case ByteEndian.Big:
                        switch (bitEndian)
                        {
                            case BitEndian.Little:
                                return ReverseBytes(BitConverter.GetBytes(target));
                            case BitEndian.Big:
                                throw new NotImplementedException();
                            default:
                                throw new InvalidEndianException();
                        }
                    default:
                        throw new InvalidEndianException();
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Bytes.DoubleToByteArray(double, ByteEndian, BitEndian)", ex);
                throw;
            }
        }

        /// <summary>
        /// Compares two byte arrays for equality.
        /// </summary>
        /// <param name="value1">The first byte array</param>
        /// <param name="value2">The second byte array</param>
        /// <returns>True if the lengths are the same and every element matches.  False if otherwise.</returns>
        /// <exception cref="ArgumentNullException">Thrown if value1 or value2 is null.</exception>
        [Obsolete("Use SequenceEqual instead: value1.AsSpan().SequenceEqual(value2).")]
        public static bool BytesAreEqual(byte[]? value1, byte[]? value2)
        {
            ArgumentNullException.ThrowIfNull(value1);
            ArgumentNullException.ThrowIfNull(value2);
            return value1.AsSpan().SequenceEqual(value2);
        }

        /// <summary>
        /// XORs two byte arrays with one another.
        /// </summary>
        /// <param name="value1">The first byte array.</param>
        /// <param name="value2">The second byte array.</param>
        /// <returns>a xor b</returns>
        /// <exception cref="ArgumentNullException">Thrown if a or b is null.</exception>
        public static byte[] XorByteArray(byte[]? value1, byte[]? value2)
        {
            ArgumentNullException.ThrowIfNull(value1);
            ArgumentNullException.ThrowIfNull(value2);

            try
            {
                bool aIsLonger = false;
                int maxLen = -1;
                if (value1.Length >= value2.Length)
                {
                    maxLen = value1.Length;
                    aIsLonger = true;
                }
                else
                {
                    maxLen = value2.Length;
                }

                int minLen = int.MaxValue;
                if (value1.Length < value2.Length)
                {
                    minLen = value1.Length;
                }
                else
                {
                    minLen = value2.Length;
                }

                byte[] rval = new byte[maxLen];

                for (int i = 0; i < maxLen; i++)
                {
                    if (i < minLen)
                    {
                        rval[i] = (byte)(value1[i] ^ value2[i]);
                    }
                    else
                    {
                        if (aIsLonger)
                        {
                            rval[i] = (byte)(value1[i] ^ 0);
                        }
                        else
                        {
                            rval[i] = (byte)(value2[i] ^ 0);
                        }
                    }
                }

                return rval;
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "Bytes.XorByteArray(byte[], byte[])", ex);
                throw;
            }
        }
    }
}
