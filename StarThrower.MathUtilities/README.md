# StarThrower.MathUtilities

Mathematical helper methods for common numeric operations, rounding, and numeric-string validation.

`StarThrower.MathUtilities` is a small collection of static helpers for numeric rounding and for checking whether a string represents a number, whole number, integer, or long — useful for validating user input before parsing.

---

## Installation

```bash
dotnet add package StarThrower.MathUtilities
```

---

## `MathUtil`

A static class containing all of the library's functionality.

### Constants

| Member | Description |
|---|---|
| `Degree` | The value of one degree in radians (`Math.PI / 180.0`), useful for degree↔radian conversions. |

### Rounding

| Method | Description |
|---|---|
| `RoundTowardsZero(double number)` | Rounds toward zero — truncates the fractional part for non-negative numbers, rounds up (toward zero) for negative numbers. `RoundTowardsZero(2.5) == 2`, `RoundTowardsZero(-2.5) == -2`. |
| `RoundTo(double value, long digits)` | Rounds `value` to `digits` decimal places using "round half away from zero" (`Math.Floor(value * 10^digits + 0.5) / 10^digits`). If `digits <= 0`, always rounds to the nearest whole number — it does not scale to round to the nearest power of ten for negative `digits`. |

### Numeric String Validation

These methods check whether a string can be interpreted as a particular kind of number, without throwing on invalid input:

| Method | Description |
|---|---|
| `IsNumeric(string? test)` | Returns `true` if the string parses as a `double` under `NumberStyles.Any` (currency symbols, thousands separators, decimals, scientific notation, etc.), matching VB.NET's `IsNumeric` behavior. Returns `false` for `null` or empty strings. |
| `IsWholeNumber(string? test)` | Returns `true` if the string parses as a `double` with no fractional component. |
| `IsInteger(string? test)` | Returns `true` if the string parses as an `int`. |
| `IsLong(string? test)` | Returns `true` if the string parses as a `long`. |

`IsWholeNumber`, `IsInteger`, and `IsLong` throw `ArgumentNullException` if `test` is `null`; `IsNumeric` returns `false` instead.

---

## Usage

```csharp
using StarThrower.MathUtilities;

// Validate input before parsing
if (MathUtil.IsInteger(userInput))
{
    int value = int.Parse(userInput);
}

// Rounding
double rounded = MathUtil.RoundTo(3.14159, 2); // 3.14
long truncated = MathUtil.RoundTowardsZero(-7.8); // -7

// Degree/radian conversion
double radians = 45 * MathUtil.Degree;
```

---

## Dependencies

None.

---

## License

Copyright © 2026 Stephen Elmer. Licensed under the [MIT License](../LICENSE.md).
