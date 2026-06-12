# StarThrower.ByteUtilities

Byte and bit manipulation utilities including endianness conversion, bitwise operations, and non-destructive byte array reversal.

`StarThrower.ByteUtilities` provides `ByteUtil`, a static class of helper methods for working with raw byte arrays — extracting subsets, reversing byte/bit order, XOR-ing arrays, and converting between byte arrays and numeric types (`Int16`, `Int32`, `float`, `double`) with explicit control over byte and bit endianness. This is useful when parsing binary file formats or network protocols with a fixed, documented byte layout.

---

## Installation

```bash
dotnet add package StarThrower.ByteUtilities
```

---

## `ByteUtil`

### Byte Array Manipulation

| Method | Description |
|---|---|
| `ByteSubstring(byte[]? source, long startIndex, long length)` | Returns a new array containing `length` bytes from `source` starting at `startIndex`. |
| `ByteSubstring(byte[]? source, long startIndex, long length, bool trimWithNulls)` | As above, but if `trimWithNulls` is `true`, stops copying at the first `0x00` byte and pads the remainder of the result with zeros. |
| `ReverseBytes(byte[]? source)` | Returns a new array with the bytes in reverse order. Non-destructive — `source` is unchanged. |
| `ReverseBits(byte value)` | Returns a byte with its bits in reverse order. |
| `ReverseBits(byte[]? source)` | Returns a new array with the bits of each byte reversed (byte order is unchanged). |
| `XorByteArray(byte[]? value1, byte[]? value2)` | XORs two byte arrays element-wise. If the arrays differ in length, the shorter array is treated as if padded with zeros; the result has the length of the longer array. |
| `BytesAreEqual(byte[]? value1, byte[]? value2)` | **Obsolete** — use `value1.AsSpan().SequenceEqual(value2)` instead. |

### Endianness-Aware Numeric Conversion

These methods convert between byte arrays and numeric types, given the `ByteEndian` (order of bytes) and `BitEndian` (order of bits within each byte) of the data:

| Method | Description |
|---|---|
| `ByteArrayToInt16(byte[]? value, ByteEndian byteEndian, BitEndian bitEndian)` | Converts a byte array to `Int16`. |
| `ByteArrayToInt32(byte[]? value, ByteEndian byteEndian, BitEndian bitEndian)` | Converts a byte array to `Int32`. |
| `ByteArrayToSingle(byte[]? value, ByteEndian byteEndian, BitEndian bitEndian)` | Converts a byte array to `float`. |
| `ByteArrayToDouble(byte[]? value, ByteEndian byteEndian, BitEndian bitEndian)` | Converts a byte array to `double`. |
| `ByteToInt16(byte bytes, BitEndian bitEndian)` | Converts a single byte to `Int16`. |
| `Int16ToByteArray(Int16 target, ByteEndian byteEndian, BitEndian bitEndian)` | Converts an `Int16` to a byte array. |
| `Int32ToByteArray(Int32 target, ByteEndian byteEndian, BitEndian bitEndian)` | Converts an `Int32` to a byte array. |
| `DoubleToByteArray(double target, ByteEndian byteEndian, BitEndian bitEndian)` | Converts a `double` to a byte array. |
| `Int16ToByte(Int16 target, BitEndian bitEndian)` | Converts an `Int16` in the range 0–255 to a single byte. |

> **Note:** `BitEndian.Big` (non-default bit ordering within a byte) is only implemented for `ByteArrayToInt32` and `ByteArrayToSingle`. The remaining conversion methods throw `NotImplementedException` for `BitEndian.Big`.

### `ByteEndian` / `BitEndian`

```csharp
public enum ByteEndian { Little = 0, Big = 1 }
public enum BitEndian  { Little = 0, Big = 1 }
```

`ByteEndian` describes the order of bytes within a multi-byte value (e.g. the bytes of an `Int32`). `BitEndian` describes the order of bits within each individual byte.

### `InvalidEndianException`

Thrown by the conversion methods above when an undefined `ByteEndian` or `BitEndian` value is supplied.

---

## Usage

```csharp
using StarThrower.ByteUtilities;

byte[] data = [0x01, 0x00, 0x00, 0x00];

// Little-endian byte order, normal bit order
int value = ByteUtil.ByteArrayToInt32(data, ByteEndian.Little, BitEndian.Little); // 1

// Extract a 4-byte field starting at offset 8
byte[] field = ByteUtil.ByteSubstring(record, startIndex: 8, length: 4);

// Reverse a byte array without mutating the original
byte[] reversed = ByteUtil.ReverseBytes(data);
```

---

## Dependencies

None.

---

## License

Copyright © 2026 Stephen Elmer. Licensed under the [MIT License](../LICENSE.md).
