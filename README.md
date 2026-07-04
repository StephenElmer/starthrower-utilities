# StarThrower.Utilities

A suite of general-purpose C# utility libraries for .NET 10, maintained by [Stephen Elmer](https://github.com/StephenElmer) at [StarThrower Utilities](https://github.com/StephenElmer/starthrower-utilities).

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
- **Windows only** for `StarThrower.DataUtilities`, which uses `System.Data.OleDb` (Windows-only)
- All other packages are **cross-platform** (Windows, Linux, macOS)

---

## History

StarThrower.Utilities has a 25-year history as a private consulting utility library,
carried forward through successive technology generations before its first public
release in 2026.

| Era | Technology | Source Control |
|---|---|---|
| 1998–2004 | VB6 + C++/COM | Visual SourceSafe |
| 2004–2005 | C# .NET 2 | Seapine Surround |
| 2005–2006 | C# .NET 2 — first StarThrower release | VSS |
| 2006–2013 | C# .NET 2 / .NET 4 — first public open source release | SVN / [SourceForge](https://sourceforge.net/projects/starthrower/) |
| 2014–2025 | C# .NET 4.8 — private | TFS |
| 2026 | C# .NET 10 — open source | GitHub |

The library traces its earliest roots to **D2-Puff**, atmospheric dispersion modeling
software developed for the U.S. Department of Defense at
[Innovative Emergency Management (IEM)](https://www.ieminc.com) — modeling the
airborne spread of hazardous materials near chemical weapons stockpile sites. The
geospatial stack (`Gis.EsriLibrary`) descends from a C++ ActiveX control written
in 1998 for that project — a 28-year lineage from COM OCX to NuGet package.

Over the years the library has served projects spanning:
- **Emergency management** — evacuee tracking (EvacuTrack, built post-Hurricane Katrina), cooperative agreement tracking, emergency response planning
- **Defense** — atmospheric dispersion modeling for DoD chemical stockpile sites
- **Oil and gas risk** — risk-based inspection platforms (Arivu at Lloyd's Register; RBI Migrator at AOC)
- **Nonprofit technology** — Gallery Gorilla, a, now retired, platform providing portfolio websites to visual artists
- **Enterprise software** — corporate websites, data migration tools, AI-driven data extraction

The original bits of the library was previously published on SourceForge (2007–2014) under LGPL v2.1.
The 2026 release re-publishes it under MIT on GitHub and NuGet for the first time.

See [CHANGELOG.md](CHANGELOG.md) for the complete history.

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

- [Open an issue](https://github.com/StephenElmer/starthrower-utilities/issues)
- [View the changelog](https://github.com/StephenElmer/starthrower-utilities/releases)

---

## License

Copyright © 2026 Stephen Elmer

Licensed under the [MIT License](LICENSE.md).

---

## Author

**Stephen Elmer** — Senior .NET Solutions Architect  
[GitHub](https://github.com/StephenElmer) · [LinkedIn](https://www.linkedin.com/in/steveelmer/)

*StarThrower Software — consulting practice specializing in enterprise .NET, geospatial systems, risk modeling, and AI-assisted development tooling.*
