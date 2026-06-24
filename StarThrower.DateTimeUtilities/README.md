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
| `DateTimeToIso8601(DateTime dt)` | **Obsolete** — use `new DateTimeOffset(DateTime.SpecifyKind(dt, DateTimeKind.Utc)).ToString("o", CultureInfo.InvariantCulture)` instead. Converts `dt` to an ISO 8601 string in the form `YYYY-MM-DDTHH:MM:SS.fffffff+00:00` (always reports a `+00:00` time zone designator, regardless of `dt.Kind`). |
| `Iso8601ToDateTime(string? iso)` | **Obsolete** — use `DateTimeOffset.Parse(iso, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal \| DateTimeStyles.AdjustToUniversal).UtcDateTime` instead. Parses an ISO 8601 string back into a `DateTime`, converting any time zone designator (`+`/`-` offset or `Z`) present in the input to UTC. |
| `TruncateToSeconds(DateTime dt)` | Returns a new `DateTime` with the same year, month, day, hour, minute, and second as `dt`, with any sub-second component discarded (floored, not rounded). |
| `RoundToSeconds(DateTime dt)` | **Obsolete** — use `TruncateToSeconds(DateTime)` instead. Despite the name, this method truncates rather than rounds; it is kept only for backward compatibility. |

```csharp
using StarThrower.DateTimeUtilities;

DateTime now = DateTime.Now;

string mmddyy = DTUtil.ToMmddyyString(now); // e.g. "060926"

long monthsApart = DTUtil.DateDiff(DateInterval.Month, new DateTime(2025, 1, 15), new DateTime(2026, 6, 9));

string iso = new DateTimeOffset(DateTime.SpecifyKind(now, DateTimeKind.Utc)).ToString("o", CultureInfo.InvariantCulture);
// e.g. "2026-06-09T14:30:45.1234567+00:00"
DateTime parsed = DateTimeOffset.Parse(iso, CultureInfo.InvariantCulture,
    DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal).UtcDateTime;

DateTime truncated = DTUtil.TruncateToSeconds(now); // milliseconds dropped
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

- `DateTimeToIso8601` always treats its input as UTC and writes a `+00:00` time zone designator, regardless of the input `DateTime`'s `Kind`. `Iso8601ToDateTime` correctly converts whatever offset (or `Z`) is present in the input to UTC, so round-tripping is safe provided the original `DateTime` was in fact UTC.
- `DateDiff(DateInterval.Year, ...)` and `DateDiff(DateInterval.Month, ...)` use calendar-aware arithmetic (accounting for month/day boundaries), while `Day`, `Hour`, `Minute`, and `Second` are based on the total elapsed `TimeSpan`, truncated toward zero.

---

## Dependencies

- [`StarThrower.MathUtilities`](../StarThrower.MathUtilities/README.md) — `MathUtil.RoundTowardsZero` used by `DateDiff`.
- [`StarThrower.StringUtilities`](../StarThrower.StringUtilities/README.md) — `StringUtil.Right` used by `ToMmddyyString`.

---

## License

Copyright © 2026 Stephen Elmer. Licensed under the [MIT License](../LICENSE.md).
