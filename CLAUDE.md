# StarThrower.Utilities — Claude Code Context

This file provides context for Claude Code sessions working on the StarThrower.Utilities
project. Read this before taking any action on the codebase.

---

## Working Style

This project is as much about learning and skill development as it is about modernizing
the code. The developer wants to be hands-on and involved in decisions. Claude Code should
operate accordingly:

- **Explain before executing.** For any non-trivial change, describe what you are about
  to do and why before doing it. Wait for confirmation unless the task is explicitly
  scoped and pre-approved.
- **One step at a time.** Do not chain multiple migration steps together autonomously.
  Complete a step, report what was done, and wait for direction before proceeding.
- **Prefer teaching over doing.** Where practical, explain the reasoning behind a change
  so the developer understands the pattern, not just the result.
- **Flag decisions.** If a change involves a judgment call (e.g. which nullable annotation
  pattern to use, how to restructure a test), surface the options rather than picking one
  silently.
- **Ask before adding anything new.** New packages, new files, new patterns — ask first.
- **Do not run git commands.** Leave all source control operations (add, commit, push,
  branch) to the developer.
- **Do not run dotnet test autonomously** unless explicitly asked to do so for a specific
  project or the full solution.

---

## What This Project Is

StarThrower.Utilities is a general-purpose C# utility library with roots going back to the
early 2000s as a VB6 shared library. Over more than two decades it has been expanded,
modernized, and carried forward through successive technology generations:

- VB6 shared library (early 2000s)
- .NET 2 migration
- .NET 3 migration
- .NET 4 migration
- .NET 4.8 (current, upgraded by VS 2026 on open)

The library has served as a foundation for virtually every consulting project the author
has worked on — growing organically as reusable pieces from new projects were folded back
in. It is now being modernized for public release on GitHub and NuGet as part of a
portfolio project supporting a career transition toward AI, data science, and civic tech.

### Deployment Strategy

Given the disparate nature of the components, the library will be published as **multiple
NuGet packages** rather than a single monolithic package. Each assembly (or closely related
group) will be its own NuGet package under the `StarThrower` namespace, allowing consumers
to take only what they need.

### Assemblies

| Project | Description |
|---|---|
| `StarThrower.ByteUtilities` | Byte and bit manipulation, endianness |
| `StarThrower.Collections` | General-purpose collection types |
| `StarThrower.DataUtilities` | General data manipulation utilities |
| `StarThrower.DateTimeUtilities` | Date/time helpers |
| `StarThrower.EarleyParser` | Full Earley parser implementation with XML-defined grammars |
| `StarThrower.EfProviders` | Entity Framework provider abstractions |
| `StarThrower.FileUtilities` | File I/O helpers |
| `StarThrower.Gis.EsriLibrary` | ESRI shapefile read/write |
| `StarThrower.Gis.GeoUtilities` | Geographic/coordinate utilities |
| `StarThrower.Logging` | Logging abstraction layer |
| `StarThrower.MathUtilities` | Math helpers |
| `StarThrower.Matrices` | Matrix operations |
| `StarThrower.StringUtilities` | String helpers |
| `StarThrower.WcfProviders` | WCF service provider abstractions |
| `StarThrower.WcfProviders.Contract` | WCF contract definitions |
| `StarThrower.XBase` | dBASE (.dbf) file read/write |

### Test Projects

Each library has a paired `*.Test` project. Tests currently use MSTest (VS Test).
Migration target is **xUnit + FluentAssertions**.

Additional projects:
- `StarThrower.EarleyParser.TestApp` — console app for interactive parser testing
- `StarThrower.Providers.TestWebApp` — ASP.NET MVC 4 web app for provider testing (see
  constraints below)

### Samples

`Code/Samples/` contains:
- `Inputs/` — sample grammar input text files for the EarleyParser
- `Languages/` — XML grammar definition files (including `grammar.xsd` schema)

These are source artifacts and are committed to the repo.

---

## Repository Structure

The Git repository is rooted at `Code/` where the `.sln` file lives. `TestInput/`,
`TestOutput/`, and `TestResults/` are subfolders of `Code/`. `Deploy/` is a sibling of
`Code/` under `Current/` and is outside the repo entirely.

```
Current/
    Deploy/                     ← outside repo (compiled output)
    Code/                       ← Git repo root / VS Code workspace root
        .gitignore
        .github/
            workflows/          ← CI/CD (to be created)
        CLAUDE.md               ← this file
        README.md               ← to be created
        StarThrower.Utilities.sln
        StarThrower.public.snk  ← strong-name key, do not delete
        CustomDictionary.xml
        packages/               ← GITIGNORED (old NuGet packages folder)
        Samples/                ← COMMITTED
            Inputs/
            Languages/
        TestInput/              ← COMMITTED (read-only test fixture files)
        TestOutput/             ← GITIGNORED (ephemeral; tests create it on demand)
        TestResults/            ← GITIGNORED (generated by test runner)
        StarThrower.ByteUtilities/
        StarThrower.ByteUtilities.Test/
        StarThrower.Collections/
        ... (one folder per project)
```

---

## Current State

- **Framework:** .NET 4.8 (upgraded from .NET 4.0 by VS 2026 on open)
- **Language:** C# (legacy, no modern idioms)
- **Source control:** Currently also bound to TFS/TFVC (being migrated away from)
- **Test framework:** MSTest (VS Test)
- **NuGet:** Old `packages.config` style, local `packages/` folder
- **Code analysis:** Post-build FxCopCmd.exe (legacy; to be replaced with Roslyn analyzers)
- **Pending NuGet updates:** 14 updates outstanding, including at least one flagged with
  a vulnerability and one deprecated — these will be resolved during the NuGet migration
  to PackageReference, not before
- **All existing tests pass** — this is the verified baseline before any migration work

---

## Migration Goals

Migration proceeds in deliberate steps with developer review between each. Do not chain
steps together autonomously.

### Phase 1 — Foundation (current priority)

**Step 1 — Clean up TFS artifacts** before first Git commit:
- Remove `GlobalSection(TeamFoundationVersionControl)` block from
  `StarThrower.Utilities.sln`
- Remove `<SccProjectName>`, `<SccLocalPath>`, `<SccAuxPath>`, `<SccProvider>` elements
  from every `.csproj` file
- Delete all `*.vssscc` and `*.vspscc` files (TFS binding files, one per project)

**Step 2 — Convert all projects to SDK-style `.csproj` format:**
- Target framework: `net10.0`
- Language version: `14.0`
- Enable nullable reference types: `<Nullable>enable</Nullable>`
- Enable implicit usings: `<ImplicitUsings>enable</ImplicitUsings>`
- Delete `packages.config` files — replace with `<PackageReference>` items
- Delete `Properties/AssemblyInfo.cs` files — SDK generates assembly info automatically
- Known NuGet dependencies (from packages folder): Castle.Core, Moq, Newtonsoft.Json
- Remove FxCopCmd.exe post-build steps; Roslyn analyzers are configured separately

**Step 3 — Configure Roslyn analyzers** (replaces FxCopCmd):
- Add `<AnalysisMode>Recommended</AnalysisMode>` to shared build props or each csproj
- `Microsoft.CodeAnalysis.NetAnalyzers` ships with the .NET 10 SDK — no additional
  package needed
- Review and address analyzer warnings as a separate pass after build is clean

**Step 4 — Add NuGet package metadata** to each library `.csproj` (not test projects):
```xml
<PackageId>StarThrower.{AssemblyName}</PackageId>
<Version>1.0.0</Version>
<Authors>Stephen</Authors>
<Description><!-- to be filled per assembly --></Description>
<GenerateDocumentationFile>true</GenerateDocumentationFile>
```

**Step 5 — Migrate tests from MSTest to xUnit + FluentAssertions:**
- Replace `[TestClass]` / `[TestMethod]` with `[Fact]` / `[Theory]`
- Replace `Assert.AreEqual(expected, actual)` with `actual.Should().Be(expected)`
- Replace `Assert.IsNotNull(x)` with `x.Should().NotBeNull()`
- Replace `Assert.IsTrue(x)` with `x.Should().BeTrue()`
- Preserve all existing test logic — only update the framework scaffolding

**Step 6 — Fix nullable warnings:**
- Do not suppress with `!` operator — annotate properly
- Add `?` to reference types that are legitimately nullable
- Add null guards where parameters must be non-null

**Step 7 — Fix test paths** — replace hard-coded paths with assembly-relative paths:
```csharp
var testInputPath = Path.GetFullPath(
    Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "TestInput"));
var testOutputPath = Path.GetFullPath(
    Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "TestOutput"));
```
Note: verify the exact relative depth once `dotnet test` output paths are confirmed.

**Step 8 — Verify all tests still pass** after each step via `dotnet test`.

### Phase 2 — Polish and Publish (after Phase 1 complete)

- Set up GitHub Actions CI/CD workflow (build + test on push/PR)
- NuGet publish workflow (on tagged release, one package per library)
- XML doc comments review and augmentation
- README.md at repo root and per-package documentation
- Claude-assisted documentation pipeline

---

## Constraints — Read Before Making Changes

### Do not change
- **Public API surface** — method signatures, class names, namespace structure must be
  preserved. Downstream projects depend on this library. Breaking changes require explicit
  discussion and approval.
- **XML doc comments** — preserve all existing `/// <summary>` documentation
- **Test logic** — only the test framework scaffolding changes; assertions and test data
  must remain intact
- **`StarThrower.public.snk`** — strong-name key file; do not delete or replace

### Do not add
- New NuGet dependencies without asking first
- Logging frameworks (the library has its own `StarThrower.Logging`)
- Nullable suppression operators (`!`) to silence warnings — fix the root cause instead
- `#pragma warning disable` suppression blocks

### Do not touch
- `TestInput/` contents — read-only test fixtures; do not modify any files here

### Special cases — discuss before touching
- `StarThrower.EfProviders` — Entity Framework integration; the EF version story on
  .NET 10 needs separate evaluation before touching this project
- `StarThrower.WcfProviders` / `StarThrower.WcfProviders.Contract` — WCF on .NET 10
  requires the `CoreWCF` package; this is a known breaking change requiring explicit
  handling and is out of scope for Phase 1
- `StarThrower.Providers.TestWebApp` — old ASP.NET MVC 4 web app; migration to ASP.NET
  Core is out of scope for Phase 1 and this project may be temporarily excluded from the
  solution

---

## C# 14 Style Preferences

Apply these modernizations opportunistically when touching code, but do not rewrite
working logic solely to apply them. Always explain the pattern when applying it.

- Prefer `record` types for immutable value objects
- Prefer primary constructors on classes that only store constructor parameters
- Use collection expressions `[x, y, z]` instead of `new List<T> { x, y, z }`
- Use pattern matching instead of long if/else chains
- Use `ReadOnlySpan<T>` in string-parsing or byte-manipulation hot paths where appropriate
- Remove redundant `using` directives made unnecessary by `ImplicitUsings`

---

## Build and Test Commands

```powershell
# From Code/ directory
dotnet build StarThrower.Utilities.sln
dotnet test StarThrower.Utilities.sln

# Single project
dotnet test StarThrower.ByteUtilities.Test/StarThrower.ByteUtilities.Test.csproj
```

---

## What NOT to Do

- Do not rewrite working logic — this is a migration, not a rewrite
- Do not add `Console.WriteLine` or debug output to library code
- Do not change exception types thrown by existing public methods
- Do not reorganize namespaces or move types between assemblies
- Do not run git commands
- Do not run dotnet test unless explicitly asked
- Do not make multiple changes in one pass without developer review between them
