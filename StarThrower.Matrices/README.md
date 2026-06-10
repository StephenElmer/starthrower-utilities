# StarThrower.Matrices

A generic, multi-dimensional, key-indexed matrix data structure.

`StarThrower.Matrices` provides `Matrix<TIndex, TValue>` — an N-dimensional array-like structure where each dimension is addressed by a fixed, caller-supplied set of keys (`TIndex`) rather than by a contiguous numeric range. Cells can also be accessed by positional (`int`) offset within each dimension. This makes it useful for representing things like cross-tabulations or lookup tables keyed by enums, GUIDs, dates, or other domain identifiers — not strictly numeric linear-algebra matrices.

> **Note:** Despite the name, this library does not currently provide linear-algebra operations (addition, multiplication, transposition, etc.). It is a fixed-shape, dictionary-backed associative array.

---

## Installation

```bash
dotnet add package StarThrower.Matrices
```

---

## `Matrix<TIndex, TValue>`

A matrix with one or more dimensions, where `TIndex` is the key type for each dimension's labels (must be `notnull`) and `TValue` is the cell type (may be nullable).

### Construction

The number of dimensions is determined by how many index collections are passed to the constructor — one `IEnumerable<TIndex>` per dimension:

```csharp
// 1-D matrix with 3 cells, keyed by int
var vector = new Matrix<int, int>([1, 2, 3]);

// 2-D matrix (3x3), keyed by int in each dimension
var grid = new Matrix<int, int>([1, 2, 3], [1, 2, 3]);

// 3-D matrix, keyed by Guid in each dimension
var cube = new Matrix<Guid, int>(xKeys, yKeys, zKeys);
```

All cells are initialized to `default(TValue)` (e.g. `0`, `null`, etc.).

### Accessing Cells

Cells can be read or written two ways:

- **By key** — the indexer `this[params TIndex[] indexes]`, using the actual key values supplied at construction.
- **By position** — `GetItemAt(params int[] indexes)` / `SetItemAt(TValue? value, params int[] indexes)`, using zero-based positional offsets within each dimension.

```csharp
var grid = new Matrix<int, int>([1, 2, 3], [1, 2, 3]);

grid[1, 1] = 10;            // set by key
int v = grid[1, 1];         // get by key

grid.SetItemAt(20, 0, 1);   // set by position (row 0, column 1)
int v2 = grid.GetItemAt(0, 1);
```

### Looking Up Keys by Position

`GetIndexesAt(params int[] indexes)` returns the key values corresponding to a positional location, one per dimension:

```csharp
var grid = new Matrix<int, int>([10, 20, 30], [100, 200, 300]);

Collection<int> keys = grid.GetIndexesAt(0, 1); // returns [10, 200]
```

---

## Usage Notes

- The set of valid keys for each dimension is fixed at construction time; matrices cannot be resized or have keys added/removed afterward.
- `TIndex` must be `notnull` and is typically used as a dictionary key — types with well-defined equality (e.g. `int`, `Guid`, `string`, `enum`) work best.
- `TValue` may be a nullable reference or value type (`Matrix<int, string?>`, `Matrix<int, int?>`).
- Internally, a `Matrix<TIndex, TValue>` delegates to either a `OneDimensionMatrix<TIndex, TValue>` (1 dimension) or a recursively-nested `MultipleDimensionMatrix<TIndex, TValue>` (2+ dimensions), both built on `Dictionary<TIndex, ...>`.

---

## Dependencies

This package references [`StarThrower.Logging`](../StarThrower.Logging/README.md).

---

## License

Copyright © 2026 Stephen Elmer. Licensed under the [MIT License](../LICENSE.md).
