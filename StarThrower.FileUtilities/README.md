# StarThrower.FileUtilities

File and directory I/O helper methods for common read, write, and comparison operations.

`StarThrower.FileUtilities` provides `FileSystem`, a small static class with helpers for byte-level file comparison, writing text files, and bulk-deleting files in a directory.

---

## Installation

```bash
dotnet add package StarThrower.FileUtilities
```

---

## `FileSystem`

| Method | Description |
|---|---|
| `FileCompare(string? file1, string? file2)` | Returns `true` if the two files have identical content (same length and byte-for-byte equal), or if `file1` and `file2` refer to the same path. Returns `false` otherwise. |
| `WriteTextFile(string fileName, string text)` | Writes `text` to `fileName`, deleting and recreating the file if it already exists. **Encodes the text as ASCII** — characters outside the ASCII range will be replaced with `?`. |
| `DeleteFiles(string directory)` | Deletes every file directly inside `directory` on a best-effort basis. Subdirectories and their contents are left untouched. If one or more files fail to delete, every other file is still attempted, and an `AggregateException` collecting all the per-file failures is thrown once all files have been attempted. |

```csharp
using StarThrower.FileUtilities;

if (FileSystem.FileCompare(@"C:\data\a.txt", @"C:\data\b.txt"))
{
    Console.WriteLine("Files are identical.");
}

FileSystem.WriteTextFile(@"C:\output\report.txt", "Hello, world!");

// Clear out a temp directory (subfolders are preserved)
FileSystem.DeleteFiles(@"C:\temp\working");
```

---

## Usage Notes

- `WriteTextFile` uses `ASCIIEncoding`, not UTF-8. If you need to write non-ASCII text (accented characters, non-Latin scripts, etc.), encode the file yourself with `File.WriteAllText` and an explicit `Encoding`.
- `DeleteFiles` is non-recursive by design — it will not remove subdirectories.
- `DeleteFiles` deletes on a best-effort basis: a file that fails to delete (e.g. locked, permission denied) does not stop the rest from being deleted. Any failures are reported together via a single `AggregateException` thrown after every file has been attempted, with one inner exception per failed file.

---

## Dependencies

None.

---

## License

Copyright © 2026 Stephen Elmer. Licensed under the [MIT License](../LICENSE.md).
