# StarThrower.DataUtilities

Data manipulation helpers with provider-agnostic database reader extensions supporting both legacy OleDb and modern `DbDataReader` APIs.

`StarThrower.DataUtilities` provides `DataUtil`, a static class of "safe getter" methods for reading typed values out of `DataRow` and `DbDataReader` objects — handling `null`/`DBNull` values, type conversion, and optional default values, so calling code doesn't need repetitive `is DBNull` checks scattered throughout.

---

## Installation

```bash
dotnet add package StarThrower.DataUtilities
```

> **Platform note:** This package depends on the `System.Data.OleDb` NuGet package (for the obsolete `OleDbDataReader` overloads described below), which is **Windows-only**. If you only use the `DataRow` and `DbDataReader` overloads, the rest of the library has no platform restrictions, but the package as a whole currently requires Windows.

---

## `DataUtil`

### Field Existence

| Method | Description |
|---|---|
| `CheckFieldExists(DbDataReader dr, string fieldName)` | Returns `true` if `fieldName` is one of the columns in `dr`. |

### Typed Field Getters

For each supported type, three overload families are provided, all following the same pattern:

- **`DataRow` overloads** — operate on `DataRow[fieldName]`.
- **`DbDataReader` overloads** — the modern, provider-agnostic API; operate on `dr[field]`.
- **`OleDbDataReader` overloads** — `[Obsolete]`; thin wrappers that cast to `DbDataReader` and delegate to the `DbDataReader` overload. Retained for backward compatibility; new code should use the `DbDataReader` overloads directly.

Each getter has a "default" overload (returns a built-in default — `0`, `false`, `string.Empty`, `DateTime.Now`, etc. — if the field is `null`/`DBNull`) and an overload accepting an explicit `defaultValue`. Several also have a `Nullable<T>`-returning variant (`GetNullable*Field`) that returns `null` instead of a default.

| Type | Methods |
|---|---|
| `bool` | `GetBooleanField`, `GetBoolField` (with default overload) |
| `string` | `GetStringField` (with default overload) |
| `DateTime` | `GetDateTimeField`, `GetNullableDateTimeField` (each with default overload) |
| `float` | `GetSingleField`, `GetFloatField` (with default overload) |
| `double` | `GetDoubleField`, `GetNullableDoubleField` (each with default overload) |
| `long` | `GetInt64Field`, `GetLongField` (with default overload) |
| `int` | `GetInt32Field`, `GetIntField`, `GetNullableIntField` (each with default overload) |
| `short` | `GetShortField`, `GetNullableShortField` (each with default overload) |
| `Guid` | `GetGuidField` (`DbDataReader` only) |
| `byte[]` | `GetBinaryField` (`DbDataReader` only) |

```csharp
using StarThrower.DataUtilities;

// DbDataReader (recommended)
while (reader.Read())
{
    string name = DataUtil.GetStringField(reader, "Name");
    int? age = DataUtil.GetNullableIntField(reader, "Age");
    DateTime created = DataUtil.GetDateTimeField(reader, "CreatedDate", DateTime.UtcNow);
}

// DataRow
foreach (DataRow row in table.Rows)
{
    bool active = DataUtil.GetBoolField(row, "IsActive");
}
```

### `DTNull`

```csharp
public static readonly DateTime DTNull = DateTime.MinValue;
```

A sentinel value used elsewhere in StarThrower.Utilities to represent a "null" date.

### SQL `DATETIME` / `TimeSpan` Conversion

| Method | Description |
|---|---|
| `GetTimeSpanFromSQLDateTime(DateTime? sqlDateTime)` | Converts a SQL Server `datetime` value (stored relative to `1900-01-01`) to a `TimeSpan` representing the elapsed time since that base date. Returns `null` if `sqlDateTime` is `null`. |
| `GetSQLDateTimeFromTimeSpan(TimeSpan? timeSpan)` | The inverse — adds `timeSpan` to `1900-01-01` to produce a `DateTime`. Returns `null` if `timeSpan` is `null`. |

---

## Migrating from `OleDbDataReader`

If your code currently calls an `OleDbDataReader` overload (e.g. `DataUtil.GetIntField(oleDbReader, "Count")`), it will continue to work but is marked `[Obsolete]`. Since `OleDbDataReader` derives from `DbDataReader`, the fix is typically a no-op — the existing call resolves to the `DbDataReader` overload once the obsolete overload is removed from consideration, or you can pass the reader as `DbDataReader` explicitly.

---

## Dependencies

- `System.Data.OleDb` — required for the obsolete `OleDbDataReader` overloads (Windows-only).

---

## License

Copyright © 2026 Stephen Elmer. Licensed under the [MIT License](../LICENSE.md).
