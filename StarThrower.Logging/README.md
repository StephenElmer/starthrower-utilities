# StarThrower.Logging

A lightweight logging abstraction layer providing a consistent interface across different logging backends.

`StarThrower.Logging` is a thin, dependency-free error-reporting facade. Rather than tying your code to a specific logging framework, you register one or more `IErrorReporter` implementations (file, console, email, event log, etc.) with a static `Logger` class, then call `Logger.ReportError(...)` from your catch blocks. Each registered reporter decides — based on a configurable policy — whether it should handle a given error.

It is intentionally minimal: a "lighter weight version of the exception handling application block" from the old Enterprise Library, predating `Microsoft.Extensions.Logging` and similar abstractions.

---

## Installation

```bash
dotnet add package StarThrower.Logging
```

---

## Core Concepts

### `Logger` (static)

The central registry and dispatcher. Your application registers reporters with it once at startup, and calls `ReportError` throughout the codebase.

| Method | Purpose |
|---|---|
| `RegisterErrorReporter(key, reporter)` | Adds an `IErrorReporter` to the registry under a unique key. |
| `UnregisterErrorReporter(key)` | Removes a previously registered reporter. |
| `RegisterErrorPolicy(reporterName, policyName)` | Associates a registered reporter with an additional policy it should handle. |
| `ReportError(ex)` | Reports an exception under the default `ErrorPolicy.Internal` policy with source `"Unknown"`. |
| `ReportError(source, ex)` | Reports an exception under `ErrorPolicy.Internal`, tagged with a source (typically `"ClassName.MethodName()"`). |
| `ReportError(policy, source, ex)` | Reports an exception under a specific policy. Only reporters that `SupportsPolicy(policy)` will receive it. |

### `IErrorReporter`

The interface implemented by each output medium (log file, email, dialog box, event log, etc.):

- `Report(source, ex)` — handle a reported exception.
- `RegisterPolicy(policy)` / `RegisterPolicy(policy, description)` — opt in to a policy.
- `UnregisterPolicy(policy)` — opt out of a policy.
- `SupportsPolicy(policy)` — whether this reporter currently handles the given policy.

### `ErrorReporterBase`

An abstract base class implementing the policy-tracking plumbing of `IErrorReporter` (a `Dictionary<string, string>` of registered policies). Derived classes need only implement `Report(source, ex)`.

### `ErrorPolicy`

Well-known policy name constants:

| Constant | Value | Meaning |
|---|---|---|
| `ErrorPolicy.Internal` | `"errorPolicyInternal"` | Default policy used by the parameterless and `(source, ex)` overloads of `ReportError`. |
| `ErrorPolicy.Global` | `"errorPolicyGlobal"` | A general-purpose policy intended to apply to all error reporting. |

Custom policy names (e.g. `"errorPolicyEmail"`, `"errorPolicyAudit"`) can be registered and used freely — these constants are just conventions for common cases.

---

## Usage

### 1. Implement a reporter

```csharp
using StarThrower.Logging;

public class FileErrorReporter : ErrorReporterBase
{
    private readonly string _logFilePath;

    public FileErrorReporter(string logFilePath)
    {
        _logFilePath = logFilePath;
    }

    public override void Report(string source, Exception ex)
    {
        File.AppendAllText(_logFilePath,
            $"{DateTime.UtcNow:O} [{source}] {ex}{Environment.NewLine}");
    }
}
```

### 2. Register it at startup

```csharp
var fileReporter = new FileErrorReporter(@"C:\Logs\app.log");
fileReporter.RegisterPolicy(ErrorPolicy.Internal);
fileReporter.RegisterPolicy(ErrorPolicy.Global);

Logger.RegisterErrorReporter("file", fileReporter);
```

### 3. Report errors from catch blocks

```csharp
try
{
    DoSomethingRisky();
}
catch (Exception ex)
{
    Logger.ReportError("MyClass.DoSomethingRisky()", ex);
    throw;
}
```

### 4. (Optional) Route specific errors to additional reporters

```csharp
// emailReporter only handles "errorPolicyEmail" by default
Logger.RegisterErrorPolicy("email", ErrorPolicy.Global);

// Now both "file" and "email" reporters receive Global-policy errors
Logger.ReportError(ErrorPolicy.Global, "MyClass.CriticalOperation()", ex);
```

---

## Design Notes

- `Logger` is a static class with a process-wide registry — register reporters once during application startup (e.g. in `Main()` / composition root).
- All public methods throw `ArgumentNullException` for `null` arguments.
- Multiple reporters can be registered, and each independently decides (via `SupportsPolicy`) whether to act on a given `ReportError` call — so the same exception can be written to a log file, emailed, and shown in a dialog, depending on configuration.

---

## License

Copyright © 2026 Stephen Elmer. Licensed under the [MIT License](../LICENSE.md).
