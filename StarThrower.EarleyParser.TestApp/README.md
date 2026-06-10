# StarThrower.EarleyParser.TestApp

A WPF desktop application for interactively testing [`StarThrower.EarleyParser`](../StarThrower.EarleyParser/README.md) grammars and inputs.

This is a developer tool, not a NuGet package — it is not published and has no `PackageId`. It exists to make it easy to load an XML grammar file, parse it, and run an Earley parse against a sample input file without writing test code.

---

## Running the App

```bash
dotnet run --project StarThrower.EarleyParser.TestApp
```

The app is a `net10.0-windows` WPF `WinExe` and only runs on Windows.

---

## Using the App

The main window has two file fields and a set of options:

| Control | Purpose |
|---|---|
| **Grammar** | Path to an XML grammar file (see the [grammar XML format](../StarThrower.EarleyParser/README.md#grammar-xml-format)). Use **Browse...** to pick a file. |
| **Input** | Path to a text file containing the input string to parse. Use **Browse...** to pick a file. |
| **Parse Grammar** | Loads and parses the grammar file with `GrammarParser`, then displays its `ToString()` representation in a message box. Useful for verifying a grammar file loads correctly before running it against input. |
| **Parse Input** | Loads the grammar, reads the input file, tokenizes it, runs `Parser.Parse` with seed category `S`, and displays the grammar, input text, and resulting `Parse.ToString()` (status, tokens, and parse tree count) in a message box. |
| **Ignore Case** | Sets `ParserOptions.IgnoreCase` for the parse. |
| **Predict Preterminals** | Sets `ParserOptions.PredictPreterminals` for the parse. |
| **Tokenization: Lex / Tokenize** | **Lex** splits the input into individual characters (optionally skipping whitespace via **Ignore Whitespace**). **Tokenize** splits the input on spaces into whitespace-delimited words. |

---

## Sample Grammars and Inputs

The `Samples/Languages/` and `Samples/Inputs/` folders at the repository root contain example grammar files (e.g. `tiny.xml`, `TRAM.xml`) and corresponding input files (e.g. `TRAM2.txt`) that can be used directly with this app.

---

## License

Copyright © 2026 Stephen Elmer. Licensed under the [MIT License](../LICENSE.md).
