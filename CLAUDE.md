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
- .NET 4.8 (upgraded by VS 2026 on open)
- .NET 10.0 (current)

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
| `StarThrower.FileUtilities` | File I/O helpers |
| `StarThrower.Gis.EsriLibrary` | ESRI shapefile read/write |
| `StarThrower.Gis.GeoUtilities` | Geographic/coordinate utilities |
| `StarThrower.Logging` | Logging abstraction layer |
| `StarThrower.MathUtilities` | Math helpers |
| `StarThrower.Matrices` | Matrix operations |
| `StarThrower.StringUtilities` | String helpers |
| `StarThrower.XBase` | dBASE (.dbf) file read/write |

### Extracted Projects — StarThrower.Providers.Framework

On 2026-06-11, three net48 projects (and their test/web projects) were extracted into
a separate repo, **[starthrower-providers-framework](https://github.com/StephenElmer/starthrower-providers-framework)**,
and removed from this solution:

- `StarThrower.EfProviders` → `StarThrower.EfProviders.Framework`
- `StarThrower.WcfProviders` → `StarThrower.WcfProviders.Framework`
- `StarThrower.WcfProviders.Contract` → `StarThrower.WcfProviders.Contract.Framework`
- `StarThrower.Providers.TestWebApp` → `StarThrower.Providers.Framework.TestWebApp` (ASP.NET MVC 4 reference app)

Reasons: these projects depend on `System.Web` and WCF with no clean path to net10.0;
they were causing net48/net10.0 mixed-TFM friction with xUnit v3 MTP test running; and
extracting them reserves the clean `StarThrower.EfProviders` / `StarThrower.WcfProviders`
namespaces for a future modern (.NET 10 / ASP.NET Core Identity / EF Core) rebuild.

**This solution is now pure net10.0 / C# 14 — no net48 projects remain.**

### Test Projects

Each library has a paired `*.Test` project. All test projects use
**xUnit v3 + AwesomeAssertions** (Step 6 complete).

Additional projects:
- `StarThrower.EarleyParser.TestApp` — WPF app for interactive parser testing (WinExe, not a console app)

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

- **Framework:** `net10.0` — all 13 projects (Logging, MathUtilities, Matrices,
  Collections, ByteUtilities, DataUtilities, FileUtilities, StringUtilities,
  DateTimeUtilities, EarleyParser, XBase, Gis.GeoUtilities, Gis.EsriLibrary)
- **Language:** `C# 14` (modern idioms applied) — all 13 projects
- **Source control:** Git / GitHub (TFS artifacts removed — Step 1 complete)
- **Test framework:** xUnit v3 + AwesomeAssertions — all projects (Step 6 complete)
- **NuGet:** PackageReference (packages.config removed — Step 2a complete)
- **Code analysis:** Roslyn analyzers configured — `<AnalysisMode>Recommended</AnalysisMode>` (Step 3 complete)
- **NuGet packages:** All core library projects updated to latest versions (Step 4 complete)
- **Add NuGet package metadata:** Add metadata and associated additional files to prepare for NuGet publication (Step 5 complete)
- **Steps complete:** 1, 2a, 2b, 2c, 2d, 3, 4, 5, 6, 7, 8, 9 — Phase 1 complete
- **All tests passing** on all migrated (net10.0) projects

---

## Migration Goals

**Phase 1 is COMPLETE (2026-06-11).** The steps below are preserved as a historical
record of the migration — including project groups 8–10 (EfProviders, WcfProviders,
WcfProviders.Contract, Providers.TestWebApp), which were carried through Steps 1–2b on
net48 before being extracted to **starthrower-providers-framework** on 2026-06-11 (see
"Extracted Projects" above). References to those groups below describe what was actually
done at the time and are kept for reference; they are no longer part of this solution.

Migration proceeds in deliberate steps with developer review between each. Do not chain
steps together autonomously.

### Phase 1 — Foundation (current priority)

**Note: Project-by-project order**
Start with simplest, least-dependent projects first:
Good starting order (test projects will be done in conjunction with their respective libraries):
1. Logging
2. MathUtilities, Matrices, Collections, ByteUtilities, DataUtilities, FileUtilities
3. StringUtilities
4. DateTimeUtilities 
5. EarleyParser
6. XBase, Gis.GeoUtilities
7. Gis.EsriLibrary
8. WcfProviders.Contract
9. WcfProviders
10. EfProviders
11. Providers.TestWebApp

**Step 1 — Clean up TFS artifacts** before first Git commit:
- Remove `GlobalSection(TeamFoundationVersionControl)` block from
  `StarThrower.Utilities.sln`
- Remove `<SccProjectName>`, `<SccLocalPath>`, `<SccAuxPath>`, `<SccProvider>` elements
  from every `.csproj` file
- Delete all `*.vssscc` and `*.vspscc` files (TFS binding files, one per project)

**Step 2 — Modernize project format and runtime**

***Step 2a — Convert all projects to SDK-style csproj (net48) — full solution sweep***

Goal: get the entire solution building with SDK-style project files before changing any
runtime behavior. Safe to do in one sweep since the TFM stays at net48 throughout.

Process each group as a unit (library + its test project together):
1. `Logging` + `Logging.Test`
2. `MathUtilities` + test, `Matrices` + test, `Collections` (no test project),
   `ByteUtilities` + test, `DataUtilities` + test, `FileUtilities` (no test project)
3. `StringUtilities` + test
4. `DateTimeUtilities` + test
5. `EarleyParser` + test + `EarleyParser.TestApp`
6. `XBase` + test, `Gis.GeoUtilities` + test
7. `Gis.EsriLibrary` (no test project)
8. `WcfProviders.Contract`, `WcfProviders` + test
9. `EfProviders` + test
10. `Providers.TestWebApp`

For each project, the conversion steps are:
- Replace legacy `.csproj` XML with SDK-style (`<Project Sdk="Microsoft.NET.Sdk">`)
- Delete `packages.config` → convert to `<PackageReference>` elements in the csproj
- Delete `Properties/AssemblyInfo.cs`
- Remove any FxCopCmd post-build event steps
- Convert the legacy `<PostBuildEvent>` (sn.exe re-sign + Deploy copy) to a proper
  MSBuild `<Target>` — the old `<PostBuildEvent>` in a `<PropertyGroup>` does not
  evaluate `$(TargetPath)` correctly in SDK-style projects. Use this pattern on all
  library projects (not test projects):
  ```xml
  <Target Name="SignAndDeploy" AfterTargets="Build"
          Condition="Exists('D:\Keys\StarThrower\StarThrower.snk')">
    <Exec Command='"C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\sn.exe" -R "$(TargetPath)" "D:\Keys\StarThrower\StarThrower.snk"' />
    <Copy SourceFiles="$(TargetPath)" DestinationFolder="$(SolutionDir)..\Deploy\"
          ContinueOnError="true" />
  </Target>
  ```
  **Why this is needed for net48:** The .NET Framework CLR enforces strong-name
  verification at load time. A delay-signed assembly (public key only) has an invalid
  signature and will fail to load, causing all tests to fail. The `sn.exe -R` step
  applies the full private-key signature. The `Condition` makes the target a silent
  no-op if the private key is not present (e.g. on a CI machine).
- Known NuGet packages in use: Castle.Core, Moq, Newtonsoft.Json (verify per project
  from its `packages.config` before deleting it)

After each group: `dotnet build` the solution and confirm it compiles.
After the full sweep: `dotnet test` the solution and confirm all tests pass. Commit.

***Step 2b — Upgrade TFM to `net10.0`, project by project***

Same group order as 2a. After upgrading each project, fix any breaking API changes and
verify tests pass before moving to the next group. Commit per group.

**For each project upgraded to net10.0: remove the `SignAndDeploy` target.** The .NET
runtime does not enforce strong-name verification, so delay-signed assemblies load and
test without it. Signing for NuGet publication will be handled in the CI/CD pipeline
(Phase 2).

Groups 1–7 (through `Gis.EsriLibrary`): upgrade to net10.0 in order.

**Special case — `StarThrower.DataUtilities`:** `System.Data.OleDb` was removed from
.NET itself in .NET Core and requires the `System.Data.OleDb` NuGet package on net10.
The migration added `DbDataReader` overloads as the going-forward API, with the original
`OleDbDataReader` overloads preserved as `[Obsolete]` wrappers delegating to them.
This makes the library Windows-only (OleDb is Windows-only); revisit if cross-platform
support is needed in Phase 2. The pattern established here — new abstract/provider-
agnostic implementation + `[Obsolete]` wrapper for the old concrete type — is the
template for similar cases elsewhere.

**Special case — `StarThrower.StringUtilities`:** `Microsoft.VisualBasic` was removed from
the production code in an earlier pass (when the library targeted PCL) because the VB
runtime was not PCL-compatible. The VB-compatible behavior (e.g. `Asc`/`Chr`/`Hex` byte
mapping for characters 128–255) was re-implemented explicitly using `Encoding.GetEncoding
("Windows-1252")`.

On .NET Core, non-Unicode code page encodings are not registered by default.
`Encoding.GetEncoding("Windows-1252")` throws unless `CodePagesEncodingProvider` is
registered first. The fix is a static constructor on `StringUtil`:
```csharp
static StringUtil()
{
    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
}
```
`CodePagesEncodingProvider` ships in the .NET shared framework (no NuGet package needed)
and works on all platforms, making `StringUtilities` fully cross-platform.

**Why not restore the VB library?** `Microsoft.VisualBasic.Core` is cross-platform on
.NET 5+, but `Strings.Chr()` for values 128–255 uses `CultureInfo.CurrentCulture
.TextInfo.ANSICodePage` internally. On Linux/macOS the ANSI code page is typically 0 or
undefined, so behavior is locale-dependent and potentially wrong. The explicit
Windows-1252 encoding is deterministic everywhere and is the better choice.

**Test oracle pattern:** The test project (`StringUtilities.Test`) retains
`Microsoft.VisualBasic.Strings.Chr()` calls deliberately — they serve as an independent
oracle to verify that the production implementation produces results consistent with VB
behavior. The explicit `<Reference Include="Microsoft.VisualBasic" />` is a net48
artifact; on net10.0 the assembly is part of the shared framework and no explicit
reference is needed (remove it when upgrading the test project).

**Special case — `[Serializable]` custom exceptions (`StarThrower.XBase` and
`StarThrower.Gis.GeoUtilities`):** All custom exceptions in these two assemblies carry
the legacy FxCop-recommended serializable exception pattern: `[Serializable]` attribute
plus a protected `(SerializationInfo, StreamingContext)` constructor delegating to base.

In .NET 8+, the base `Exception(SerializationInfo, StreamingContext)` constructor is
marked `[Obsolete]` (diagnostic ID `SYSLIB0051`), so every such constructor produces a
build warning on net10.0. Additionally, `BinaryFormatter` — the only consumer of this
pattern — is fully removed in .NET 9+.

Since none of these exceptions have custom fields (the serialization constructor is pure
boilerplate that only calls `base(info, context)`), the fix is to remove `[Serializable]`
and the serialization constructor from all affected classes. The three meaningful
constructors (default, message, message+inner) are untouched, so this is a non-breaking
public API change. Apply during the Step 2b upgrade for each affected assembly:
- **XBase**: 5 exceptions — `BadDataException`, `FieldNotFoundException`,
  `InvalidDataTypeException`, `InvalidDecimalCountException`, `InvalidFieldLengthException`
- **Gis.GeoUtilities**: 17 exceptions in the `Exceptions/` folder

Groups 8–10 — **staying at net48 indefinitely**; do not upgrade these projects during
Phase 1. The shared blocker across all three groups is `System.Web` — the ASP.NET
Framework Membership/Profile/Role provider model (`MembershipProvider`, `RoleProvider`,
`ProfileProvider`) does not exist in .NET Core and has no shim. Each group has
additional blockers on top of that:
- `WcfProviders.Contract` / `WcfProviders` / `WcfProviders.Test` — `System.ServiceModel`
  (WCF) requires a full migration to `CoreWCF` (not just a namespace swap); additionally
  the contract DTOs reference `System.Web.Security.MembershipUser` and
  `System.Web.Profile.ProfileInfoCollection`, which are Framework-only types
- `EfProviders` / `EfProviders.Test` — uses EF6 Database-First (`ObjectContext`,
  `ObjectSet<T>`, EDMX designer); migrating to EF Core requires scaffolding a new
  `DbContext` and rewriting ~3,500 lines of business logic; additionally blocked by the
  `System.Web` provider model above
- `Providers.TestWebApp` — ASP.NET MVC 4; every layer (routing, controllers, views,
  authentication, session) depends on `System.Web`; would be a full rewrite as ASP.NET
  Core, not a migration; out of scope for Phase 1 regardless

**EfProviders / ByteUtilities dependency:** `EfProviders` previously had a project
reference to `StarThrower.ByteUtilities` (now net10.0) solely for one call —
`ByteUtil.ByteSubstring()` inside `EfProfileProvider.GetBinaryPropertyValue()`. The
project reference was removed and the method was inlined directly into `EfProfileProvider`
with a comment explaining why. The modern equivalent (`AsSpan(start, length).ToArray()`)
requires net6.0+ and cannot be used while the project stays on net48.

These projects will remain at net48 until a deliberate redesign decision is made for a
future phase. Exclude them from Steps 2c, 2d, 3, 4, 5, and 6.

***Step 2c — Enable C# 14 and nullable — project by project***

**Scope: Groups 1–7 (net10.0 projects) only.** Do not apply to WcfProviders,
EfProviders, or Providers.TestWebApp — these remain on net48 and are excluded from
this step and all subsequent steps unless explicitly noted.

Same group order as 2b:
1. `Logging` + test
2. `MathUtilities` + test, `Matrices` + test, `Collections`, `ByteUtilities` + test,
   `DataUtilities` + test, `FileUtilities`
3. `StringUtilities` + test
4. `DateTimeUtilities` + test
5. `EarleyParser` + test + `EarleyParser.TestApp`
6. `XBase` + test, `Gis.GeoUtilities` + test
7. `Gis.EsriLibrary`

**Note on implicit usings:** `<ImplicitUsings>enable</ImplicitUsings>` is deliberately
omitted. This solution mixes net10.0 and net48 projects; applying implicit usings only
to net10.0 projects would create asymmetric conventions across the solution. Also,
`System.Collections.ObjectModel` and other commonly-used namespaces are not on the
implicit list, which caused confusing linter noise in practice. Explicit using directives
are easier to grep, consistent across all TFMs, and make each file self-contained.

For each project:
- Add `<Nullable>enable</Nullable>` to csproj (do **not** add `<ImplicitUsings>`)
- Work through nullable warnings — do not suppress with `!`, fix the root cause
- Add `?` to reference types that are legitimately nullable
- Add null guards where parameters must be non-null
- Remove only `using` directives that are genuinely unused by the file
- Verify build is clean and tests pass
- Commit per group

***Step 2d — BCL supersedence audit***

During Steps 2b and 2c, log any types or methods that the BCL now provides natively
in the **BCL Supersedence Log** section at the bottom of this file. Address them here
as a dedicated pass after 2c is complete.

For each logged item, choose one of:
- **Keep as-is** — if the implementation differs meaningfully from the BCL equivalent
- **Wrapper + deprecate** — convert the implementation to delegate to the BCL type, and
  mark the public API `[Obsolete("Use X instead.")]` to signal consumers to migrate;
  preserve the public signature so nothing breaks
- **Remove** — only if the type/method is internal or confirmed to have no external
  consumers, and only with explicit approval

Do not remove or deprecate any public API without explicit discussion first.

**Step 3 — Configure Roslyn analyzers** (replaces FxCopCmd): ✅ COMPLETE
- `<AnalysisMode>Recommended</AnalysisMode>` added to all net10.0 library projects
- All pre-logged CA2200 and CA2022 warnings addressed
- ~2,400 warnings reviewed and resolved across Groups 1–7

**Step 4 — Update NuGet packages:** ✅ COMPLETE
- All core library projects (Groups 1–7) updated to latest stable package versions
- Vulnerability and deprecation warnings resolved

**Step 5 — Add NuGet package metadata** ✅ COMPLETE
- create `icon.png`
- create `LICENSE.md`
- create root-level `README.md`
- to `Directory.Build.props` for global properties
```xml
<Authors>Stephen Elmer</Authors>
<Company>StarThrower Software</Company>
<Copyright>Copyright © 2026 Stephen Elmer</Copyright>
<NeutralLanguage>en-US</NeutralLanguage>
<PackageProjectUrl>https://github.com/StephenElmer/starthrower-utilities</PackageProjectUrl>
<RepositoryUrl>https://github.com/StephenElmer/starthrower-utilities</RepositoryUrl>
<RepositoryType>git</RepositoryType>
<PackageTags>utilities;csharp;dotnet;starthrower</PackageTags>
<PackageLicenseExpression>MIT</PackageLicenseExpression>
<PackageReleaseNotes>See $(PackageProjectUrl)/releases</PackageReleaseNotes>
<PackageIcon>icon.png</PackageIcon>                       
<Version>1.0.0</Version>
<AssemblyVersion>1.0.0.0</AssemblyVersion>
<FileVersion>$(Version).0</FileVersion>
```
- to each library `.csproj`
```xml
<IsPackable>true</IsPackable>
<PackageId>$(AssemblyName)</PackageId>
<Version>1.0.0</Version>
<AssemblyVersion>1.0.0.0</AssemblyVersion>
<FileVersion>$(Version).0</FileVersion>
<Description><!-- to be filled per assembly --></Description>
<GenerateDocumentationFile>true</GenerateDocumentationFile>
<PackageTags>$(PackageTags);<!-- to be filled per assembly --></PackageTags>
<PackageReadme>README.md</PackageReadme>
```


**Step 6 — Migrate tests from MSTest to xUnit v3 + AwesomeAssertions:** ✅ COMPLETE for
Groups 1–7 (2026-06-11). `WcfProviders.Test` and `EfProviders.Test` (net48) remain
MSTest indefinitely — see net48 special case above.

**Decision (2026-06-10): xUnit v3 + AwesomeAssertions.**

- **xUnit v3** — chosen over v2 because v3 is the actively-developed line, built on
  Microsoft.Testing.Platform (MTP) rather than the legacy VSTest adapter model. v3 test
  projects are self-hosted executables (`OutputType=Exe`) with no AppDomain isolation
  baggage and no dependency on `Microsoft.NET.Test.Sdk`. This aligns with the project's
  general direction of shedding .NET Framework-era plumbing. v2 remains the fallback for
  any project where v3/MTP tooling proves problematic during the pilot.
- **AwesomeAssertions** — chosen over FluentAssertions and Shouldly:
  - FluentAssertions v8+ relicensed (Jan 2025) under the Xceed Community License —
    free for non-commercial use only; commercial use requires a paid per-developer
    license (~$130/dev/year). Given this library may see commercial use, that risk was
    judged not worth taking on.
  - AwesomeAssertions is a community-governed fork of FluentAssertions v7, **API-compatible**
    with FluentAssertions, and the maintainers have committed to keeping it Apache 2.0
    permanently.
  - Over Shouldly: the API-compatibility with FluentAssertions matters for AI-assisted
    development — FluentAssertions syntax (`.Should().Be(...)`, `.Should().BeEquivalentTo()`,
    `.Should().Throw<T>()`) is the most heavily-represented assertion style in LLM training
    data, so AwesomeAssertions minimizes friction/incorrect-syntax cycles when Claude Code
    writes or updates tests.

**Pilot project — `StarThrower.DateTimeUtilities.Test`: ✅ COMPLETE (2026-06-10)**

Converted manually by the developer (with Claude Code guidance) as a hands-on learning
exercise, rather than having Claude perform the conversion directly. Validated:
- Project builds cleanly with `xunit.v3` + `AwesomeAssertions` package references and
  `OutputType=Exe`.
- All 25 tests pass via `dotnet run --project <test-csproj>` (xUnit v3 in-process runner).
- Test Explorer in both **VS Code (C# Dev Kit)** and **VS 2026** discovers and runs tests
  correctly.

**Resolved — `dotnet test` CLI gap, and the permanent net48/MSTest split (2026-06-11):**

The .NET 10 SDK's native MTP mode for `dotnet test` is enabled via a `global.json`
setting:
```json
{ "test": { "runner": "Microsoft.Testing.Platform" } }
```
This mode is all-or-nothing per `dotnet test` invocation — if the discovered
`global.json` enables MTP mode and the targeted project is VSTest-only (not
MTP-capable), it errors outright. Since `WcfProviders.Test` and `EfProviders.Test`
remain on net48 + MSTest **indefinitely** (excluded from Step 6 — see net48 special
case above), the solution permanently contains a mix of MTP (net10/xUnit v3) and
VSTest-only (net48/MSTest) test projects.

**Fix — nested `global.json` shadowing:** `global.json` discovery walks up from the
current working directory and uses the *nearest* file found. A root `Code/global.json`
enables MTP mode for the net10/xUnit v3 projects. A second, empty `global.json` (`{}`)
placed in `StarThrower.WcfProviders.Test/` and `StarThrower.EfProviders.Test/` shadows
the root file for those two projects, reverting them to default VSTest mode. As long as
`dotnet test` for those two projects is invoked with the working directory set to the
project folder (so the nearer `global.json` is discovered), both groups work correctly
with `dotnet test`. See "Build and Test Commands" below for the resulting commands.

This avoids the "VSTest mode" bridge (`Microsoft.Testing.Platform.MSBuild` +
`TestingPlatformDotnetTestSupport=true`), which Microsoft documents as legacy (removed
in MTP v2) and not officially supported for mixed solutions (CLI option collisions
between frameworks, e.g. xUnit's `--filter-trait` vs MSTest's `--filter`).

No fallback to xUnit v2 was needed; v3 + AwesomeAssertions tooling worked end-to-end
across all of Groups 1–7.

Conversion steps:
- Replace `[TestClass]` / `[TestMethod]` with `[Fact]` / `[Theory]`
- Replace `Assert.AreEqual(expected, actual)` with `actual.Should().Be(expected)`
- Replace `Assert.IsNotNull(x)` with `x.Should().NotBeNull()`
- Replace `Assert.IsTrue(x)` with `x.Should().BeTrue()`
- Replace `[ExpectedException(typeof(T))]` + trailing `Assert.Fail()` with
  `Action act = () => ...; act.Should().Throw<T>();`
- Replace `Ignore()`-style TDD placeholder calls with `[Fact(Skip = "reason")]` on the
  test method
- Preserve all existing test logic — only update the framework scaffolding
- Package changes per test project:
  - Remove: `Microsoft.NET.Test.Sdk`, `MSTest.TestAdapter`, `MSTest.TestFramework`
  - Add: `xunit.v3`, `AwesomeAssertions`
  - Add `<OutputType>Exe</OutputType>` to the existing build-configuration
    `<PropertyGroup>` (xUnit v3 test projects are self-hosted executables)
  - `UseMicrosoftTestingPlatformRunner` and `xunit.v3.runner.visualstudio` were tried
    and found unnecessary — `OutputType=Exe` alone was sufficient for `dotnet run` and
    for VS Code/VS 2026 Test Explorer discovery in the pilot

**Step 6 conversion notes:** Detailed gotchas, regex-script pitfalls, and project-specific
translation patterns from each Step 6 conversion (StringUtilities, EarleyParser, XBase,
Gis.GeoUtilities) are archived in [docs/step6-conversion-notes.md](docs/step6-conversion-notes.md)
for reference during Phase 2 documentation writeups.

**Step 7 — Fix nullable warnings:** ✅ COMPLETE (2026-06-11)
- A clean rebuild (`dotnet build -t:Rebuild`) of the full solution produced 0 warnings /
  0 errors. Nullable warnings were already fully resolved during Steps 2c/3; no further
  action was needed.

**Step 8 — Fix test paths** ✅ COMPLETE (2026-06-11) — replaced hard-coded
`D:\StarThrower\...\Code\TestInput` / `TestOutput` paths with assembly-relative paths
in `StarThrower.XBase.Test/XBaseFileTest.cs` and
`StarThrower.Gis.GeoUtilities.Test/WGS84TranslationTest.cs`:
```csharp
var testInputPath = Path.GetFullPath(
    Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "TestInput"));
var testOutputPath = Path.GetFullPath(
    Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "TestOutput"));
```
Verified relative depth: build output is `Code/<Project>/bin/Debug/net10.0/`, which is
**four** levels below `Code/` (net10.0 → Debug → bin → project folder → Code), so four
`".."` segments are required.

**Step 9 — Verify all tests still pass** after each step via `dotnet test`.

### Phase 2 — Polish and Publish (after Phase 1 complete)

- Set up GitHub Actions CI/CD workflow (build + test on push/PR), using the split
  `dotnet test` commands documented in "Build and Test Commands" (net10/xUnit v3 via
  MTP mode, net48/MSTest via the project-local `global.json` overrides)
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

---

## C# 14 Style Preferences

Apply these modernizations opportunistically when touching code, but do not rewrite
working logic solely to apply them. Always explain the pattern when applying it.

- Prefer `record` types for immutable value objects
- Prefer primary constructors on classes that only store constructor parameters
- Use collection expressions `[x, y, z]` instead of `new List<T> { x, y, z }`
- Use pattern matching instead of long if/else chains
- Use `ReadOnlySpan<T>` in string-parsing or byte-manipulation hot paths where appropriate

---

## Build and Test Commands

```powershell
# From Code/ directory
dotnet build StarThrower.Utilities.sln
dotnet test StarThrower.Utilities.sln
```

A root `global.json` enables MTP mode for `dotnet test`, required by the xUnit v3
test projects. With the net48/MSTest projects extracted to
`starthrower-providers-framework` (2026-06-11), the solution is now uniformly
net10.0/xUnit v3/MTP, so the split per-project test commands and `global.json`
shadowing workaround documented previously are no longer needed.

---

## What NOT to Do

- Do not rewrite working logic — this is a migration, not a rewrite
- Do not add `Console.WriteLine` or debug output to library code
- Do not change exception types thrown by existing public methods
- Do not reorganize namespaces or move types between assemblies
- Do not run git commands
- Do not run dotnet test unless explicitly asked
- Do not make multiple changes in one pass without developer review between them

---

## BCL Supersedence Log

Types and methods identified during migration that the BCL now provides natively.
To be addressed in Step 2d. Do not modify these items during Steps 2b or 2c.

| Assembly | Type / Member | BCL Equivalent | Notes |
|---|---|---|---|
| `StarThrower.Collections` | `ReadOnlyDictionary<TKey,TValue>` | `System.Collections.ObjectModel.ReadOnlyDictionary<TKey,TValue>` (added .NET 4.5) | **Done in Step 2d.** Class now inherits from BCL version; marked `[Obsolete]`. |
| `StarThrower.ByteUtilities` | `ByteUtil.ReverseBytes` | `Array.Reverse(byte[])` or `Span<T>` in-place reversal | **Keep as-is.** BCL equivalents are in-place (destructive); `ReverseBytes` returns a new array (non-destructive). No single-call BCL equivalent. |
| `StarThrower.ByteUtilities` | `ByteUtil.BytesAreEqual` | `span.SequenceEqual()` (.NET Core 2.1+) | **Done in Step 2d.** Null guards preserved; body replaced with `value1.AsSpan().SequenceEqual(value2)`; marked `[Obsolete]`. Test project intentionally calls the obsolete method; CS0618 warnings left standing (tests verify the wrapper works; suppression would hide that an obsolete API is under test). Migrate tests to BCL API in Step 6. |
| `StarThrower.DataUtilities` | All `OleDbDataReader` overloads | `DbDataReader` (abstract base in `System.Data.Common`) | **Done in Step 2b.** New `DbDataReader` overloads added as primary API; `OleDbDataReader` overloads marked `[Obsolete]` and delegate to them. Requires `System.Data.OleDb` NuGet package (Windows-only). |

---

## Pending Analyzer Warnings Log

Warnings surfaced during Step 2b/2c that are pre-existing issues (not introduced by the
migration). To be addressed in Step 3. Do not fix these during Steps 2b or 2c.

| Assembly | File | Rule | Description |
|---|---|---|---|
| `StarThrower.EarleyParser` | `Parser.cs:165` | CA2200 | `throw ex;` re-throws caught exception, losing original stack trace. Change to bare `throw;`. |
| `StarThrower.XBase` | `Internal/Record.cs:317` | CA2200 | Same `throw ex;` pattern as above. |
| `StarThrower.XBase` | `Internal/Field.cs:353` | CA2200 | Same `throw ex;` pattern as above. |
| `StarThrower.XBase` | `Internal/File.cs:468, 479, 491` | CA2022 | `FileStream.Read()` may return fewer bytes than requested (partial read). Review whether the dBASE file format guarantees full reads; if not, replace with `ReadExactly()` (available in .NET 7+). |
| `StarThrower.Gis.GeoUtilities` | `Shapes/*.cs` (18 occurrences) | CA2200 | `throw ex;` pattern in shape-parsing code across all shape type files (`Shape.cs:88`, `PointShape.cs:108`, `PolylineShape.cs:148`, `PolygonShape.cs:148`, `Part.cs:116`, `OpenPart.cs:68`, `ClosedPart.cs:68`, and 11 specialized shape files at line 71). Change to bare `throw;`. |
