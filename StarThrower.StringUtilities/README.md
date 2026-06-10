# StarThrower.StringUtilities

String manipulation and analysis utilities including encoding-aware character operations with consistent cross-platform Windows-1252 behavior.

`StarThrower.StringUtilities` provides `StringUtil`, a static class of string-handling helpers: token parsing, substitution, padding, quoting, ASCII/hex/byte conversions, XML escaping, scientific-notation formatting, and ISO 8601 `DateTime`/`TimeSpan` extension methods. Several methods replicate the behavior of legacy VB6/VB.NET string functions (`Asc`, `Chr`, `Hex`, `Mid`) using explicit Windows-1252 encoding, so results are deterministic across platforms.

---

## Installation

```bash
dotnet add package StarThrower.StringUtilities
```

---

## `StringUtil`

### Hex / ASCII / Byte Conversion

| Method | Description |
|---|---|
| `ToHex(string? source)` | Converts each character of `source` to its Windows-1252 byte value and returns the hexadecimal representation (e.g. `"A"` → `"41"`). |
| `ToHex(int source)` | Converts an `int` to its hexadecimal string representation (e.g. `255` → `"FF"`). |
| `ToChar(int characterCode)` | Returns the character at `characterCode` (0–255) as a string. Codes above `0xFFFF` are encoded as a UTF-16 surrogate pair. |
| `ToAscii(string? target)` | Returns the Windows-1252 byte value of the first character of `target`, replicating VB's `Asc()`. |
| `ToByteArray(string? source)` | Casts each character to a `byte` (truncating values above 255) and returns the resulting array. |
| `FromByteArray(byte[]? target)` | Decodes a byte array as ASCII text. |

### Parsing and Tokens

| Method | Description |
|---|---|
| `ParseString(ref string source, string? delimiter)` | Removes and returns the first token of `source` up to `delimiter`; `source` is mutated to the remainder. |
| `ParseStringFromRight(ref string source, string? delimiter)` | Removes and returns the last token of `source` after the final `delimiter`; `source` is mutated to the remainder. |
| `CountTokens(string? source, string? delimiter)` | Returns the number of `delimiter`-separated tokens in `source` (an empty source counts as 1 token). |
| `GetToken(string? source, string? delimiter, int pos)` | Returns the 1-based `pos`-th token of `source`. |
| `IsToken(string? source, string? target, string? delimiter)` | Returns `true` if `target` is one of the `delimiter`-separated tokens in `source`. |

### Substitution and Replacement

| Method | Description |
|---|---|
| `Substitute(string? source, string? target, string? replacement)` | Replaces all case-sensitive occurrences of `target` in `source` with `replacement`. |
| `Substitute(string? source, string? target, string? replacement, ComparisonType compare)` | As above, with an explicit `ComparisonType` (case-sensitive or case-insensitive). |
| `Replace(string? source, string? replacement, int startIndex, int length)` | Replaces the `length` characters of `source` starting at `startIndex` with `replacement`. |
| `ConvertComparisonType(ComparisonType compare)` | Converts a `ComparisonType` to the equivalent `StringComparison` (`CaseSensitive` → `Ordinal`, `CaseInsensitive` → `OrdinalIgnoreCase`). Throws for `Database`. |

### Substrings and Trimming

| Method | Description |
|---|---|
| `Left(string? source, int length)` | Returns the leftmost `length` characters of `source`. |
| `Right(string? source, int length)` | Returns the rightmost `length` characters of `source`. |
| `TrimCrLf(string? source)` | Trims trailing `\n` and `\r` characters from `source`. |
| `RemoveDoubleQuoteWrapper(string? source)` | If `source` begins and ends with `"`, returns it with those quotes removed; otherwise returns `source` unchanged. |
| `StripLeadingDoubleQuotes(string? text)` | Removes any number of leading `"` characters from `text`. |

### Quoting and SQL Helpers

| Method | Description |
|---|---|
| `WrapWithDoubleQuotes(object? value)` | Returns `value.ToString()` wrapped in `"`. |
| `WrapWithSingleQuotes(object? value)` | Returns `value.ToString()` wrapped in `'`. |
| `SqlText(string? text)` | Doubles every `"` in `text`, for use in SQL string literals. |

### Validation

| Method | Description |
|---|---|
| `IsValidString(string? test, string? validChars)` | Returns `true` if every character in `test` appears in `validChars`. |
| `IsValidCharacter(string? test, string? validChars)` | Returns `true` if the single-character string `test` appears in `validChars`. |
| `IsValid(string? test, string? regularExpression)` | Returns `true` if `test` matches the regular expression `regularExpression`. |

### Other String Operations

| Method | Description |
|---|---|
| `SplitStringIntoArray(string? source)` | Splits `source` into a `string[]` with one element per character. |
| `AppendSpaces(string? original, int finalLength)` | Pads `original` on the right with spaces to reach `finalLength`. If `original` is already that long or longer, it is returned unchanged. |
| `GetCountOf(string? source, string? target)` | Counts non-overlapping occurrences of `target` in `source`. |
| `XmlEncode(string? text)` | Escapes `&`, `<`, `>`, `"`, `=`, `'` as XML numeric character references and replaces tabs and newlines with spaces. |

### Numeric Formatting

| Method | Description |
|---|---|
| `SqueezeNumber(object? number, int length)` | Formats `number` with thousands separators if it fits within `length` characters; otherwise switches to exponential notation (`SqueezeNumber(number, length, ScientificNotationFormat.Exponential)`). |
| `SqueezeNumber(object? number, int length, ScientificNotationFormat format)` | As above, with the scientific notation style controlled by `format`. |
| `ENotationToBaseTenNotation(string? source, bool useSuperscript, bool spaced, bool excludePlusSign, bool excludeZeroPower)` | Converts an `E`-notation string (e.g. `"1.23E+05"`) into base-10 power notation, optionally using Unicode superscripts, spacing, and sign/zero-exponent suppression. |
| `ToSuperscript(string? target)` | Converts a string representation of a whole number (optionally signed) into Unicode superscript characters. |

### `DateTime` / `TimeSpan` XML Extensions

| Method | Description |
|---|---|
| `ToXmlString(this DateTime dt)` | Converts `dt` to an XML/ISO 8601-style string: `YYYY-MM-DDTHH:MM:SS.fZ`. |
| `ToXmlString(this TimeSpan ts)` | Converts `ts` to an XML schema duration string: `P[y]Y[m]MD[d]T[h]H[m]M[s.f]S`, approximating years as 365 days and months as 30 days. |

### Constants

| Member | Value | Description |
|---|---|---|
| `DegreeSymbol` | `"°"` | The degree symbol (°). |
| `Superscript0`–`Superscript9` | `"⁰"`, `"¹"`, `"²"`, `"³"`, `"⁴"`–`"⁹"` | Unicode superscript digits 0–9. |
| `SuperscriptPlus` / `SuperscriptMinus` | `"⁺"` / `"⁻"` | Unicode superscript `+` and `-`. |

### `ComparisonType`

```csharp
public enum ComparisonType
{
    CaseSensitive = 0,
    CaseInsensitive = 1,
    Database = 2
}
```

Used by `Substitute` and `ConvertComparisonType`. Note that `ConvertComparisonType` does not support `Database` and throws `ArgumentOutOfRangeException` if passed.

### `ScientificNotationFormat`

```csharp
public enum ScientificNotationFormat
{
    Exponential = 0,             // 123E+4
    Base10 = 1,                  // 123x10^+4
    Base10Spaced = 2,            // 123 x 10^+4
    Base10Superscript = 3,       // 123x10⁺⁴
    Base10SuperscriptSpaced = 4  // 123 x 10⁺⁴
}
```

---

## Usage

```csharp
using StarThrower.StringUtilities;

// Tokenizing
string csv = "a,b,c,d";
string first = StringUtil.ParseString(ref csv, ","); // first = "a", csv = "b,c,d"

// Substitution
string result = StringUtil.Substitute("hello world", "world", "there"); // "hello there"

// Squeeze a large number to fit a fixed-width field
string squeezed = StringUtil.SqueezeNumber(123456789, 8, ScientificNotationFormat.Base10Superscript);

// XML/ISO 8601 formatting
string xmlDate = DateTime.UtcNow.ToXmlString();
string xmlDuration = TimeSpan.FromMinutes(90).ToXmlString();
```

---

## Platform Notes

`StringUtil` registers `CodePagesEncodingProvider` in a static constructor so that `Encoding.GetEncoding("Windows-1252")` works on all platforms, including .NET Core/.NET on Linux and macOS where non-Unicode code pages are not registered by default. Methods such as `ToHex(string?)` and `ToAscii(string?)` rely on this to replicate VB.NET's `Hex()`/`Asc()` behavior for characters 128–255 deterministically, regardless of the host's locale.

---

## Dependencies

- [`StarThrower.Logging`](../StarThrower.Logging/README.md) — internal error reporting.
- [`StarThrower.MathUtilities`](../StarThrower.MathUtilities/README.md) — numeric validation used by `SqueezeNumber` and `ToSuperscript`.

---

## License

Copyright © 2026 Stephen Elmer. Licensed under the [MIT License](../LICENSE.md).
