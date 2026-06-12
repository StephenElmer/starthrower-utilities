# StarThrower.Utilities

A suite of general-purpose C# utility libraries for .NET 10, maintained by [Stephen Elmer](https://github.com/TODO) at [StarThrower Software](https://github.com/TODO/starthrower-utilities).

These libraries have been in active use across commercial consulting projects since the early 2000s — originating as a VB6 shared library and modernized through successive .NET generations. They represent battle-tested, production-proven utility code published here as open source for the first time.

---

## Packages

| Package | Description | NuGet |
|---|---|---|
| [StarThrower.ByteUtilities](StarThrower.ByteUtilities/README.md) | Byte and bit manipulation, endianness conversion | [![NuGet](https://img.shields.io/nuget/v/StarThrower.ByteUtilities)](https://www.nuget.org/packages/StarThrower.ByteUtilities) |
| [StarThrower.Collections](StarThrower.Collections/README.md) | General-purpose collection types | [![NuGet](https://img.shields.io/nuget/v/StarThrower.Collections)](https://www.nuget.org/packages/StarThrower.Collections) |
| [StarThrower.DataUtilities](StarThrower.DataUtilities/README.md) | Provider-agnostic database reader extensions | [![NuGet](https://img.shields.io/nuget/v/StarThrower.DataUtilities)](https://www.nuget.org/packages/StarThrower.DataUtilities) |
| [StarThrower.DateTimeUtilities](StarThrower.DateTimeUtilities/README.md) | Date and time helpers | [![NuGet](https://img.shields.io/nuget/v/StarThrower.DateTimeUtilities)](https://www.nuget.org/packages/StarThrower.DateTimeUtilities) |
| [StarThrower.EarleyParser](StarThrower.EarleyParser/README.md) | Full Earley parser with XML-defined grammars | [![NuGet](https://img.shields.io/nuget/v/StarThrower.EarleyParser)](https://www.nuget.org/packages/StarThrower.EarleyParser) |
| [StarThrower.FileUtilities](StarThrower.FileUtilities/README.md) | File and directory I/O helpers | [![NuGet](https://img.shields.io/nuget/v/StarThrower.FileUtilities)](https://www.nuget.org/packages/StarThrower.FileUtilities) |
| [StarThrower.Gis.EsriLibrary](StarThrower.Gis.EsriLibrary/README.md) | ESRI shapefile (.shp/.dbf) read/write | [![NuGet](https://img.shields.io/nuget/v/StarThrower.Gis.EsriLibrary)](https://www.nuget.org/packages/StarThrower.Gis.EsriLibrary) |
| [StarThrower.Gis.GeoUtilities](StarThrower.Gis.GeoUtilities/README.md) | Geographic and coordinate system utilities | [![NuGet](https://img.shields.io/nuget/v/StarThrower.Gis.GeoUtilities)](https://www.nuget.org/packages/StarThrower.Gis.GeoUtilities) |
| [StarThrower.Logging](StarThrower.Logging/README.md) | Lightweight logging abstraction | [![NuGet](https://img.shields.io/nuget/v/StarThrower.Logging)](https://www.nuget.org/packages/StarThrower.Logging) |
| [StarThrower.MathUtilities](StarThrower.MathUtilities/README.md) | Mathematical helpers and numeric operations | [![NuGet](https://img.shields.io/nuget/v/StarThrower.MathUtilities)](https://www.nuget.org/packages/StarThrower.MathUtilities) |
| [StarThrower.Matrices](StarThrower.Matrices/README.md) | Matrix data structures and operations | [![NuGet](https://img.shields.io/nuget/v/StarThrower.Matrices)](https://www.nuget.org/packages/StarThrower.Matrices) |
| [StarThrower.StringUtilities](StarThrower.StringUtilities/README.md) | String manipulation and encoding-aware character operations | [![NuGet](https://img.shields.io/nuget/v/StarThrower.StringUtilities)](https://www.nuget.org/packages/StarThrower.StringUtilities) |
| [StarThrower.XBase](StarThrower.XBase/README.md) | dBASE (.dbf) file read/write | [![NuGet](https://img.shields.io/nuget/v/StarThrower.XBase)](https://www.nuget.org/packages/StarThrower.XBase) |

---

## Installation

Install individual packages via the .NET CLI:

```bash
dotnet add package StarThrower.ByteUtilities
dotnet add package StarThrower.EarleyParser
dotnet add package StarThrower.Gis.EsriLibrary
# etc.
```

Or via the Visual Studio / VS Code NuGet Package Manager — search for `StarThrower`.

Each package is independent. Install only what you need.

---

## Requirements

- **.NET 10** or later
- **Windows only** for the following packages due to platform-specific dependencies:
  - `StarThrower.DataUtilities` — uses `System.Data.OleDb` (Windows-only)
  - `StarThrower.Gis.EsriLibrary` — shapefile I/O depends on Windows file system conventions
- All other packages are **cross-platform** (Windows, Linux, macOS)

---

## History

StarThrower.Utilities began in the early 2000s as a VB6 shared library, folding in reusable components from commercial consulting projects. It has been carried forward through successive modernizations:

| Era | Technology |
|---|---|
| Early 2000s | VB6 shared library |
| Mid 2000s | .NET 2 |
| Late 2000s | .NET 3 |
| 2010s | .NET 4 / .NET 4.8 |
| 2026 | .NET 10 / C# 14 — first public release |

The library has served as a foundation for projects spanning emergency management software, oil and gas risk modeling, geospatial analysis, and enterprise data integration. The `.NET 10` release is its first publication as open source.

---

## Notable Components

**EarleyParser** — A full implementation of the [Earley parsing algorithm](https://en.wikipedia.org/wiki/Earley_parser) supporting context-free grammars defined in XML. The parser handles ambiguous grammars and was originally built to support a custom DSL for risk-scoring models. Grammar definitions follow the schema in [`Samples/Languages/grammar.xsd`](Samples/Languages/).

**GIS Stack** — Two complementary packages for geospatial work: `Gis.EsriLibrary` for reading and writing ESRI shapefiles, and `Gis.GeoUtilities` for coordinate system calculations and geometric operations. Both have been validated against real-world geographic datasets.

**XBase** — A complete dBASE (.dbf) file reader/writer supporting character, numeric, date, logical, and memo field types. Used in production for legacy data migration and GIS attribute table processing.

---

## Related Projects

**[starthrower-providers-framework](https://github.com/StephenElmer/starthrower-providers-framework)** —
Legacy .NET Framework 4.8 provider libraries (EF6 Database-First and WCF service
abstractions), extracted from this repo during the .NET 10 modernization. These
depend on `System.Web` and WCF with no clean migration path to .NET 10 and are
preserved there for reference. A modern rebuild targeting .NET 10 / ASP.NET Core
Identity / EF Core may appear under the `StarThrower.EfProviders` /
`StarThrower.WcfProviders` namespaces in a future release.

---

## Platform Notes

### Windows-1252 Encoding (StringUtilities)

`StarThrower.StringUtilities` includes character operations with explicit Windows-1252 encoding behavior, implemented using `CodePagesEncodingProvider` for consistent cross-platform results. The encoding provider is registered automatically via a static constructor — no additional setup required.

### OleDb (DataUtilities)

`StarThrower.DataUtilities` provides both `OleDbDataReader` overloads (marked `[Obsolete]`) and modern `DbDataReader` overloads as the going-forward API. New code should use the `DbDataReader` overloads. The `OleDbDataReader` overloads are retained for backward compatibility and require the `System.Data.OleDb` NuGet package on .NET 10 (Windows only).

### Strong Naming

Prior versions of this library used strong naming for .NET Framework consumers. The .NET 10 packages are not strong-named. If you require strong-named assemblies for a .NET Framework project, use the legacy releases.

---

## Contributing

This is primarily a personal portfolio and consulting utility library. Issues and pull requests are welcome but response times may vary.

- [Open an issue](https://github.com/TODO/starthrower-utilities/issues)
- [View the changelog](https://github.com/TODO/starthrower-utilities/releases)

---

## License

Copyright © 2026 Stephen Elmer

Licensed under the [MIT License](LICENSE.md).

---

## Author

**Stephen Elmer** — Senior .NET Solutions Architect  
[GitHub](https://github.com/TODO) · [LinkedIn](https://www.linkedin.com/in/TODO)

*StarThrower Software — consulting practice specializing in enterprise .NET, geospatial systems, risk modeling, and AI-assisted development tooling.*
