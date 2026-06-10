# StarThrower.Collections

General-purpose collection types for .NET.

`StarThrower.Collections` currently provides a single, obsolete compatibility type: `ReadOnlyDictionary<TKey, TValue>`, retained for consumers migrating from older versions of this library.

---

## Installation

```bash
dotnet add package StarThrower.Collections
```

---

## `ReadOnlyDictionary<TKey, TValue>`

> **Obsolete.** Use [`System.Collections.ObjectModel.ReadOnlyDictionary<TKey, TValue>`](https://learn.microsoft.com/dotnet/api/system.collections.objectmodel.readonlydictionary-2) directly instead.

This type predates the BCL's own `ReadOnlyDictionary<TKey, TValue>` (introduced in .NET 4.5). It is now a thin subclass of the BCL type, provided only so existing code referencing `StarThrower.Collections.ReadOnlyDictionary<TKey, TValue>` continues to compile and behave identically.

```csharp
// Old code using this package's type still works, but is flagged obsolete:
var dict = new StarThrower.Collections.ReadOnlyDictionary<string, int>(source);

// New code should use the BCL type directly:
var dict = new System.Collections.ObjectModel.ReadOnlyDictionary<string, int>(source);
```

---

## License

Copyright © 2026 Stephen Elmer. Licensed under the [MIT License](../LICENSE.md).
