# StarThrower.XBase

Read and write dBASE (.dbf) file format including field type support for character, numeric, date, logical, and memo types.

`StarThrower.XBase` provides `XBaseFile`, a high-level wrapper for opening, querying, and modifying dBASE III (.dbf) database files — including field schema management, record CRUD operations, and an XML representation of the file's contents.

---

## Installation

```bash
dotnet add package StarThrower.XBase
```

---

## Core Types

| Type | Description |
|---|---|
| `XBaseFile` | The main entry point. Opens, reads, writes, and saves a `.dbf` file; manages its field schema and records. Implements `IDisposable`. |
| `XBaseFileType` | Enumerates known dBASE/FoxPro/Clipper file format codes (e.g. `dBaseIII`, `FoxBase`, `VisualFoxPro`). Currently only `XBaseFileType.dBaseIII` is supported by `XBaseFile`'s constructors — any other value throws `NotSupportedException`. |
| `XBaseField` | Describes a single field's schema: `Name`, `FieldType`, `Length`, and `DecimalCount`. |
| `FieldType` | Abstract base class for field type definitions. Defines `Text`, `Code`, `MinLength`/`MaxLength`, `MinDecimalCount`/`MaxDecimalCount`, `IsValidLength`, `IsValidDecimalCount`, `IsValidData`, and `Translate`. |
| `XBaseFieldCollection` | An `IList<XBaseField>` / `IList` collection of a record's fields, with name-based lookup via `Find` and the `this[string fieldName]` indexer. |
| `XBaseRecord` | A single row of data. Provides `GetData`/`SetData` overloads (by field name) and an `IsDeleted` flag. |

### Field Types

| Type | Code | Description |
|---|---|---|
| `StringField` | `C` | Character data, 1–253 bytes. `Translate` returns the raw string; `IsValidData` pads with spaces to the field's `Length`. |
| `NumericField` | `N` | Numeric data, 1–17 characters, 0–15 decimal places. A `DecimalCount` of `0` is treated as an `Int64`; a non-zero `DecimalCount` is treated as a `double`. |
| `FloatField` | `F` | Floating-point data. Fixed `Length` of 20, 0–19 decimal places. `Translate` parses the value as a `double`. |
| `DateField` | `D` | Date data stored as an 8-character `yyyyMMdd` string. Fixed `Length` of 8, `DecimalCount` of 0. `Translate` returns a `DateTime`. |
| `BooleanField` | `L` | Logical (true/false) data stored as a single `T`/`F` character. `Translate` accepts `Y`/`y`/`T`/`t` as `true` and `N`/`n`/`F`/`f`/`?` as `false` (case-insensitive); any other value throws `BadDataException`. |
| `MemoField` | `M` | Memo field reference. Fixed `Length` of 10, `DecimalCount` of 0. |
| `UndefinedField` | `U` | Placeholder used when a field's type code is not recognized. `IsValidData` always fails and `Translate` always returns an empty string. |

Setting `XBaseField.FieldType` to a `DateField`, `BooleanField`, `MemoField`, or `FloatField` automatically sets that field's `Length` (and `DecimalCount` where applicable) to the type's fixed values.

---

## Exceptions

| Exception | Thrown When |
|---|---|
| `BadDataException` | A value cannot be converted to or from a field's on-disk representation (e.g. an unrecognized `BooleanField` string, or numeric data that overflows the field). |
| `FieldNotFoundException` | A field name passed to `XBaseRecord.GetData`/`SetData` or `XBaseFieldCollection`'s name indexer does not exist. |
| `InvalidDataTypeException` | Reserved for invalid field type code scenarios. |
| `InvalidDecimalCountException` | An `XBaseField.DecimalCount` is set to a value outside the range allowed by its `FieldType`. |
| `InvalidFieldLengthException` | An `XBaseField.Length` is set to a value outside the range allowed by its `FieldType`. |

---

## Usage

```csharp
using StarThrower.XBase;

// Create a new dBASE III file and define its schema
using XBaseFile dbf = new XBaseFile(XBaseFileType.dBaseIII, "people.dbf", FileMode.Create, FileAccess.ReadWrite);

dbf.AddField(new XBaseField { Name = "NAME", FieldType = new StringField(), Length = 30 });
dbf.AddField(new XBaseField { Name = "BIRTHDATE", FieldType = new DateField() });
dbf.AddField(new XBaseField { Name = "ACTIVE", FieldType = new BooleanField() });

// Add a record
XBaseRecord record = dbf.CreateRecord();
record.SetData("NAME", "Jane Doe");
record.SetData("BIRTHDATE", new DateTime(1990, 5, 17));
record.SetData("ACTIVE", true);
dbf.AddRecord(record);

dbf.Save();

// Read records back
for (int i = 0; i < dbf.RecordCount; i++)
{
    XBaseRecord r = dbf.GetRecord(i);
    string name = (string)r.GetData("NAME");
    DateTime birthDate = (DateTime)r.GetData("BIRTHDATE");
    bool active = (bool)r.GetData("ACTIVE");
}
```

### Exporting to XML

```csharp
string xml = dbf.ToXml();
```

---

## Usage Notes

- **Only dBASE III is supported.** `XBaseFile`'s constructors throw `NotSupportedException` for any `XBaseFileType` other than `dBaseIII`, even though `XBaseFileType` enumerates many other historical formats (FoxBase, Visual FoxPro, Clipper, etc.) for reference.
- **`DeleteRecord` vs. `DestroyRecord`.** `DeleteRecord` marks a record's deleted flag (a "soft" delete, recoverable until the file is compacted); `DestroyRecord` removes the record entirely.
- **Field name matching is fixed-width.** `XBaseFieldCollection.Find` compares field names by padding the shorter name with `\0` characters to match the on-disk fixed-width field name, replicating dBASE's field name storage format.
- `XBaseFile.LastUpdate` reads/writes the file header's last-modified date.

---

## Dependencies

- [`StarThrower.ByteUtilities`](../StarThrower.ByteUtilities/README.md) — endian-aware byte/`Int16` conversions used internally for header and date fields.
- [`StarThrower.StringUtilities`](../StarThrower.StringUtilities/README.md) — string/byte array conversion and padding helpers.

---

## License

Copyright © 2026 Stephen Elmer. Licensed under the [MIT License](../LICENSE.md).
