# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

---

## [2.0.0] - 2026-06-11

First public release as open source on GitHub and NuGet.

### Added
- Full migration to .NET 10 / C# 14
- xUnit v3 + AwesomeAssertions test framework
- Source Link for step-through debugging
- Deterministic builds
- MIT license
- XML documentation throughout for full IntelliSense support
- Per-package READMEs on NuGet.org
- GitHub Actions CI/CD pipeline (ci.yml, pack.yml, publish.yml)
- NuGet Trusted Publishing (OIDC) — no long-lived API keys

### Changed
- SDK-style project files throughout
- Nullable reference types enabled and fully annotated
- Roslyn analyzers configured (`AnalysisMode: Recommended`)
- Tests migrated from MSTest to xUnit v3 + AwesomeAssertions
- `ByteUtilities.BytesAreEqual` delegated to `SequenceEqual` and marked `[Obsolete]`
- `DataUtilities` OleDb overloads marked `[Obsolete]` — new `DbDataReader` overloads
  are the going-forward API

### Removed
- `StarThrower.Logging` — deprecated; use `Microsoft.Extensions.Logging.Abstractions`
- .NET Framework provider libraries — extracted to
  [starthrower-providers-framework](https://github.com/StephenElmer/starthrower-providers-framework)

---

## Pre-release History

This library predates public version control. The following is a chronological
reconstruction of its evolution across platforms, source control systems, employers,
and two and a half decades of consulting engagements. Dates are approximate.

---

### 2014–2026 — C# .NET 4.8 / TFS (private)

SourceForge was abandoned in favor of Team Foundation Server for private source
control. The library continued to serve active consulting projects but was no longer
publicly available.

**Source control:** TFS (Team Foundation Server)
**License:** none (private)

**Applications during this period:**

| Application | Client | Description |
|---|---|---|
| Gallery Gorilla | Gallery Gorilla | Nonprofit platform providing portfolio websites to visual artists |
| AOC Corporate Website | AOC | Corporate website (ongoing) |
| RPOA Website | RPOA | Small HOA website |
| RBI Migrator | AOC | Risk-based inspection data migration tool (WPF) |
| Data Collector | AOC | AI-driven data extraction tool (.NET 8 / WPF) |

---

### 2011–2014 — C# .NET 4 / SourceForge + SVN

Ported to .NET 4. New components added to support **PROMPT** — a configurable
multi-dimensional risk scoring and prioritization engine with a custom DSL.

**Source control:** SVN / SourceForge
**License:** LGPL v2.1

**New components:**
- `EarleyParser` — full Earley parsing algorithm implementation supporting
  context-free grammars defined in XML, built to parse PROMPT's custom
  rule definition language
- `Matrices` — matrix data structures and operations, supporting PROMPT's
  multi-dimensional scoring model
- `WcfProviders` / `EfProviders` — provider abstractions for WCF services and
  Entity Framework, eliminating recurring boilerplate across web projects
  *(extracted to [starthrower-providers-framework](https://github.com/StephenElmer/starthrower-providers-framework) in 2026)*

**Applications during this period:**

| Application | Client | Description |
|---|---|---|
| PROMPT | StarThrower | Generic risk scoring and optimization engine with custom DSL (WPF) |
| CakesByMacauley | Cakes by Macauley | Small portfolio website |
| LeahDevun | Leah Devun | Small portfolio website |
| StellarWriter | Stellar Communications | Corporate website for independent publisher |
| AOC Corporate Website | AOC | Corporate website |

---

### 2006–2011 — C# .NET 2 / SourceForge + SVN

Formally published to SourceForge as open source under the StarThrower name.
The geospatial stack was rewritten from scratch as pure managed .NET — replacing
the original C++ OCX with a fully managed shapefile implementation.

**Source control:** SVN / SourceForge
**SourceForge:** https://sourceforge.net/projects/starthrower/ (registered 2007-02-21)
**License:** LGPL v2.1

**New components:**
- `Gis.EsriLibrary` — complete rewrite of shapefile I/O as pure managed .NET,
  replacing the original 1998 C++ OCX
- `Gis.GeoUtilities` — geographic coordinate system utilities, UTM zone calculations,
  and coordinate transformations
- `XBase` — dBASE (.dbf) file read/write, supporting shapefile attribute tables
  and legacy data migration workflows
- `ByteUtilities` — byte and bit manipulation, endianness conversion; required for
  correct binary parsing of the ESRI shapefile binary format

**Applications during this period:**

| Application | Client | Description |
|---|---|---|
| Arivu | LRTS | Risk-based inspection platform for petrochemical equipment (WinForms + ASP.NET WebForms) |

---

### 2005 — C# .NET 2 / VSS (personal) — First StarThrower release

The loosely coupled VB utilities and .NET 2 ports were consolidated, formalized,
and published for the first time under the StarThrower name with an open source
license. `Logging` was added to support swappable logging backends across
deployment environments.

**Source control:** VSS (personal)
**License:** LGPL v2.1

**New components:**
- `StarThrower.Logging` *(removed in 2.0.0)* — lightweight logging abstraction
  built for EvacuTrack; deprecated in 2026 in favor of
  `Microsoft.Extensions.Logging.Abstractions`

**Applications during this period:**

| Application | Client | Description |
|---|---|---|
| EvacuTrack | FiRST | Evacuee tracking system built in the aftermath of Hurricane Katrina (WinForms) |

---

### 2004–2005 — C# .NET 2 / Seapine Surround

The VB6 utility functions were ported to C# .NET 2 — the first managed .NET
incarnation of the library.

**Source control:** Seapine Surround
**Owner:** IEM (Innovative Emergency Management)

**Components ported:**
- `StringUtilities`, `DateTimeUtilities`, `FileUtilities`, `MathUtilities`,
  `DataUtilities` — all ported from VB6 to C# .NET 2

**Applications during this period:**

| Application | Client | Description |
|---|---|---|
| CA Tools | IEM | Cooperative agreement tracking tool for the Chemical Stockpile Emergency Preparedness Program (WinForms) |
| Plan Manager | IEM | Workflow planning tool for emergency response plan development (WinForms) |

---

### 1998–2004 — VB6 / Visual SourceSafe

Origins as loosely coupled VB6 shared functions, developed during commercial
consulting work at **Innovative Emergency Management (IEM)**. A parallel C++/COM
component handled geospatial shapefile I/O.

**Source control:** Visual SourceSafe (VSS)
**Owner:** IEM (Innovative Emergency Management)

**Components:**
- `StringUtilities`, `DateTimeUtilities`, `FileUtilities`, `MathUtilities`,
  `DataUtilities` — VB6 shared function libraries
- `IShapeLib.dll` — C++/COM ActiveX control for ESRI shapefile I/O,
  ancestor of `Gis.EsriLibrary`

**Applications during this period:**

| Application | Client | Description |
|---|---|---|
| D2-Puff | IEM / DoD | Atmospheric dispersion modeling software for the U.S. Department of Defense — modeled airborne spread of hazardous materials near chemical weapons stockpile sites |
| UrboGenerator | IEM | GIS application estimating population distribution from nighttime light satellite imagery |
| Various small VB apps | IEM | Emergency management tools |

---

### 1998 — C++ / ActiveX (OCX)

The earliest ancestor of `Gis.EsriLibrary` was a C++ ActiveX control (OCX)
written for integration with **ESRI MapObjects** — a COM-based mapping component
used in desktop GIS applications of the era. Originally built for the D2-Puff
atmospheric dispersion modeling platform at IEM.

That control (`IShapeLib.dll`) was eventually wrapped in a .NET interop layer,
then completely rewritten as pure managed .NET circa 2006–2010, and has now
arrived at .NET 10 as `StarThrower.Gis.EsriLibrary` — a 28-year lineage from
C++ ActiveX to modern NuGet package.
