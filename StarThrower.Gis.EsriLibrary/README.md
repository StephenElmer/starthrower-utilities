# StarThrower.Gis.EsriLibrary

Read and write ESRI shapefile format (.shp/.dbf) including support for points, polylines, polygons, and multipart shapes.

`StarThrower.Gis.EsriLibrary` provides `ShapeFile`, a high-level wrapper that pairs a `.shp`
geometry file with its companion `.dbf` attribute table (via
[`StarThrower.XBase`](../StarThrower.XBase/README.md)) and exposes them as a single set of
records — each combining an attribute `Record` with a
[`StarThrower.Gis.GeoUtilities.Shapes.Shape`](../StarThrower.Gis.GeoUtilities/README.md#shapes)
geometry.

---

## Installation

```bash
dotnet add package StarThrower.Gis.EsriLibrary
```

---

## Core Types

| Type | Description |
|---|---|
| `ShapeFile` | The main entry point. Opens, reads, writes, and saves a shapefile (`.shp` + `.dbf` pair); manages its field schema, records, and overall `Extent`. Implements `IDisposable`. |
| `ShapeType` | Enumerates the ESRI shapefile geometry types: `NullShape`, `Point`, `PolyLine`, `Polygon`, `MultiPoint`, and their `Z`/`M`/`Multipatch` variants, with values matching the `.shp` format specification. |
| `Field` | Describes a single attribute field's schema: `Name`, `Type` (`Types.FieldType`), `Length`, and `DecimalCount`. Implements `ICloneable`. |
| `Record` | A single feature: an attribute data dictionary (set/get via `SetData`/`GetData` overloads by field name) plus a `GetShape()`/`SetShape()` geometry (`StarThrower.Gis.GeoUtilities.Shapes.Shape`). |

### Field Types (`Types` namespace)

| Type | Code | Description |
|---|---|---|
| `StringField` | `C` | Character data. Wraps `StarThrower.XBase.StringField`. |
| `NumericField` | `N` | Numeric data (`Int64` if `DecimalCount` is `0`, otherwise `double`). Wraps `StarThrower.XBase.NumericField`. |
| `FloatField` | `F` | Floating-point data. Wraps `StarThrower.XBase.FloatField`. |
| `DateField` | `D` | Date data (`yyyyMMdd`). Wraps `StarThrower.XBase.DateField`. |
| `BooleanField` | `L` | Logical (`T`/`F`) data. Wraps `StarThrower.XBase.BooleanField`. |
| `MemoField` | `M` | Memo field reference. Wraps `StarThrower.XBase.MemoField`. |
| `UndefinedField` | `U` | Placeholder for an unrecognized field type. Wraps `StarThrower.XBase.UndefinedField`. |

`Types.FieldType` is an abstract base deriving from `StarThrower.XBase.FieldType`; each concrete
type delegates `MinLength`/`MaxLength`, `MinDecimalCount`/`MaxDecimalCount`,
`IsValidLength`/`IsValidDecimalCount`/`IsValidData`, and `Translate` to the corresponding
`StarThrower.XBase` field type, so validation and on-disk representation match the underlying
`.dbf` exactly.

---

## Usage

```csharp
using StarThrower.Gis.EsriLibrary;
using StarThrower.Gis.EsriLibrary.Types;
using StarThrower.Gis.GeoUtilities.Shapes;

// Create a new point shapefile and define its attribute schema
using ShapeFile shapeFile = new ShapeFile();
shapeFile.ShapeType = ShapeType.Point;

shapeFile.AddField(new Field { Name = "NAME", Type = new StringField(), Length = 30 });
shapeFile.AddField(new Field { Name = "POP", Type = new NumericField(), Length = 9 });

// Add a record
Record record = shapeFile.CreateNewRecord();
record.SetShape(new PointShape(-77.0365, 38.8977));
record.SetData("NAME", "Washington, DC");
record.SetData("POP", 689545L);
shapeFile.AddRecord(record);

shapeFile.SaveAs(@"cities.shp"); // writes cities.shp and cities.dbf

// Read records back
shapeFile.Open(@"cities.shp", FileMode.Open, FileAccess.Read);
for (int i = 0; i < shapeFile.RecordCount; i++)
{
    Record r = shapeFile.GetRecord(i);
    PointShape point = (PointShape)r.GetShape();
    string name = (string)r.GetData("NAME")!;
}
```

### Exporting to XML

```csharp
using StarThrower.Gis.GeoUtilities.Formatting;

string fileWiseXml = shapeFile.ToXml(XmlFormat.FileWise);  // separate geography/data sections
string layerWiseXml = shapeFile.ToXml(XmlFormat.LayerWise); // combined geography+data per record
```

`LoadXml(XmlDocument, XmlFormat)` reads the `LayerWise` format back (schema, extent, and field
definitions); `Gml` and `ToJson`/`LoadJson` are not yet implemented.

---

## Usage Notes

- **Opening a shapefile.** `Open`/`SaveAs` take the `.shp` path; the companion `.dbf` is
  derived by replacing the extension and opened/saved alongside it. `Open` throws
  `InvalidDataException` if the `.shp` and `.dbf` record counts don't match.
- **`AddRecord` validates `ShapeType`.** A `Record`'s shape must match the `ShapeFile`'s
  `ShapeType`, or `AddRecord` throws `ArgumentException`.
- **`AlterRecord` is not implemented** and throws `NotImplementedException`.
- **Field type round-tripping.** `Field`/`Types.FieldType` mirror
  [`StarThrower.XBase`](../StarThrower.XBase/README.md)'s `XBaseField`/`FieldType` exactly —
  internal conversion helpers translate between the two so the `.dbf` written alongside the
  `.shp` is a standard dBASE III file.
- **Geometry types.** `ShapeType` values map one-to-one to
  [`StarThrower.Gis.GeoUtilities.Shapes.ShapeType`](../StarThrower.Gis.GeoUtilities/README.md#shapes)
  values; `CreateNewRecord()` returns a `Record` pre-populated with the matching
  `Shapes.Shape` subtype (e.g. `PointShape`, `PolygonShape`, `PolylineZShape`) for the
  shapefile's `ShapeType`.

---

## Dependencies

- [`StarThrower.ByteUtilities`](../StarThrower.ByteUtilities/README.md) — endian-aware byte conversions used internally for `.shp`/`.shx` binary record headers and geometry data.
- [`StarThrower.Gis.GeoUtilities`](../StarThrower.Gis.GeoUtilities/README.md) — `Shapes` geometry types, `GeoRectangle`, and XML formatting (`XmlFormat`).
- [`StarThrower.StringUtilities`](../StarThrower.StringUtilities/README.md) — XML encoding and string padding helpers.
- [`StarThrower.XBase`](../StarThrower.XBase/README.md) — the `.dbf` attribute table read/write implementation underlying `ShapeFile`'s field and record support.

---

## License

Copyright © 2026 Stephen Elmer. Licensed under the [MIT License](../LICENSE.md).
