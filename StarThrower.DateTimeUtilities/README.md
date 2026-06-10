# StarThrower.DateTimeUtilities

Date and time helper methods for common calculations, formatting, and manipulation operations.

`StarThrower.DateTimeUtilities` provides `DTUtil`, a static class of helpers for formatting `DateTime` values, computing differences between dates in various units, and converting to/from ISO 8601 strings.

---

## Installation

```bash
dotnet add package StarThrower.DateTimeUtilities
```

---

## `DTUtil`

| Method | Description |
|---|---|
| `ToMmddyyString(DateTime dt)` | Returns `dt` formatted as `MMDDYY` (e.g. `2026-06-09` → `"060926"`). |
| `DateDiff(DateInterval interval, DateTime date1, DateTime date2)` | Returns `date2 - date1` expressed in the units specified by `interval` (`Year`, `Month`, `Weekday`, `Day`, `Hour`, `Minute`, or `Second`). Corrects rounding/calendar issues present in the classic VB `DateDiff` function. |
| `DateTimeToIso8601(DateTime dt)` | Converts `dt` to an ISO 8601 string in the form `YYYY-MM-DDTHH:MM:SS.f+00:00` (always reports a `+00:00` time zone designator, regardless of `dt.Kind`). |
| `Iso8601ToDateTime(string? iso)` | Parses an ISO 8601 string (as produced by `DateTimeToIso8601`) back into a `DateTime`. The time zone designator (`+`/`-` offset or `Z`) is discarded rather than applied. |
| `RoundToSeconds(DateTime dt)` | Returns a new `DateTime` with the same year, month, day, hour, minute, and second as `dt`, with any sub-second component truncated. |

```csharp
using StarThrower.DateTimeUtilities;

DateTime now = DateTime.Now;

string mmddyy = DTUtil.ToMmddyyString(now); // e.g. "060926"

long monthsApart = DTUtil.DateDiff(DateInterval.Month, new DateTime(2025, 1, 15), new DateTime(2026, 6, 9));

string iso = DTUtil.DateTimeToIso8601(now);     // e.g. "2026-06-09T14:30:45.123+00:00"
DateTime parsed = DTUtil.Iso8601ToDateTime(iso);

DateTime truncated = DTUtil.RoundToSeconds(now); // milliseconds dropped
```

### `DateInterval`

```csharp
public enum DateInterval
{
    Year = 0,
    Month = 1,
    Weekday = 2,
    Day = 3,
    Hour = 4,
    Minute = 5,
    Second = 6
}
```

Used by `DateDiff` to specify the unit of the result. `Weekday` returns whole weeks elapsed (`TotalDays / 7`), not a day-of-week name.

---

## Usage Notes

- `DateTimeToIso8601` and `Iso8601ToDateTime` are not fully round-trip safe: the time zone designator written by `DateTimeToIso8601` is always `+00:00`, but `Iso8601ToDateTime` discards whatever offset (or `Z`) is present in the input rather than converting it. Both methods operate on local date/time components without performing UTC conversion.
- `DateDiff(DateInterval.Year, ...)` and `DateDiff(DateInterval.Month, ...)` use calendar-aware arithmetic (accounting for month/day boundaries), while `Day`, `Hour`, `Minute`, and `Second` are based on the total elapsed `TimeSpan`, truncated toward zero.

---

## Dependencies

- [`StarThrower.Logging`](../StarThrower.Logging/README.md) — internal error reporting.
- [`StarThrower.MathUtilities`](../StarThrower.MathUtilities/README.md) — `MathUtil.RoundTowardsZero` used by `DateDiff`.
- [`StarThrower.StringUtilities`](../StarThrower.StringUtilities/README.md) — `StringUtil.Right` used by `ToMmddyyString`.

---

## License

Copyright © 2026 Stephen Elmer. Licensed under the [MIT License](../LICENSE.md).
