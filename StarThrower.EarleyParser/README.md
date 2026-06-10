# StarThrower.EarleyParser

A full Earley parsing algorithm implementation supporting context-free grammars defined via XML grammar files.

`StarThrower.EarleyParser` provides a complete implementation of the Earley parsing algorithm — a chart-based parser capable of recognizing and parsing strings against any context-free grammar (including ambiguous and left-recursive grammars). Grammars can be authored as XML files and loaded with `GrammarParser`, then used with `Parser` to recognize token sequences, inspect the resulting parse chart, and extract one or more parse trees.

---

## Installation

```bash
dotnet add package StarThrower.EarleyParser
```

---

## Core Types

| Type | Description |
|---|---|
| `Category` | A terminal or non-terminal symbol in a grammar (e.g. `NP`, `"the"`). Immutable; `Category.Root` is a special start symbol used internally for seeding parses. |
| `Rule` | A production rule with a left-side `Category` and a `ReadOnlyCollection<Category>` right side (e.g. `S -> NP VP`). |
| `Grammar` | A named collection of `Rule`s, indexed by left-side category. Built up with `AddRule` or loaded via `GrammarParser`. |
| `GrammarParser` | Parses a grammar definition from an `XmlDocument` or XML file into a `Grammar`. |
| `DottedRule` | A `Rule` with a "dot" position marking how much of the rule has been matched. `ActiveCategory` is the category immediately after the dot, or `null` if the rule is fully matched. |
| `Edge` | A `DottedRule` paired with an origin position in the input. Edges are *passive* (fully matched) or *active* (still expecting more categories). |
| `Chart` | A set of `Edge`s indexed by string position, produced by `Parser.Parse`. |
| `Parser` | Runs the Earley algorithm (predict/scan/complete) against a `Grammar` to build a `Chart` for a token sequence. |
| `ParserOptions` | Configures parser behavior: `IgnoreCase` (default `false`) and `PredictPreterminals` (default `true`). |
| `Parse` | The result of `Parser.Parse`: holds the tokens, seed category, completed `Chart`, overall `Status`, and derivable `ParseTrees`. |
| `ParseTree` | A node in a derivation tree, with a `Node` category, optional `Parent`, and ordered `Children`. |
| `Status` | `Reject`, `Accept`, or `Error` — the outcome of a `Parse`. |
| `EdgeEventArgs` | Event arguments for `Parser.OnEdgePredicted`, `OnEdgeScanned`, and `OnEdgeCompleted`. |

---

## Grammar XML Format

A grammar file has a root `<grammar name="...">` element containing `<rule>` elements. Each `<rule category="Left">` contains one or more `<category name="...">` elements representing its right-hand side. A `<category terminal="true" name="...">` represents a terminal (literal token).

```xml
<?xml version="1.0"?>
<grammar name="tiny">
  <rule category="S">
    <category name="NP"/>
    <category name="VP"/>
  </rule>
  <rule category="NP">
    <category name="Det"/>
    <category name="N"/>
  </rule>
  <rule category="NP">
    <category terminal="true" name="Mary"/>
  </rule>
  <rule category="Det">
    <category terminal="true" name="the"/>
  </rule>
  <rule category="N">
    <category terminal="true" name="man"/>
  </rule>
  <rule category="VP">
    <category terminal="true" name="left"/>
  </rule>
</grammar>
```

The `Samples/Languages/` folder in this repository contains additional example grammars and the `grammar.xsd` schema.

---

## Usage

```csharp
using StarThrower.EarleyParser;

// Load a grammar from an XML file
GrammarParser grammarParser = new GrammarParser(@"Samples\Languages\tiny.xml");
Grammar grammar = grammarParser.Parse();

Parser parser = new Parser(grammar);

string[] tokens = { "Mary", "saw", "the", "man" };
Category seed = new Category("S");

// Recognize: just check whether the tokens are valid for category S
Status status = parser.Recognize(tokens, seed); // Status.Accept, Reject, or Error

// Parse: get the full chart and extract parse trees
Parse parse = parser.Parse(tokens, seed);
if (parse.Status == Status.Accept)
{
    foreach (ParseTree tree in parse.ParseTrees)
    {
        Console.WriteLine(tree.ToString()); // e.g. "[S[NP[Mary]][VP[VT[saw]][NP[Det[the]][N[man]]]]]"
    }
}
```

### Subscribing to Parsing Events

`Parser` raises events as it builds the chart, which is useful for visualizing or tracing the algorithm:

```csharp
parser.OnEdgePredicted += (s, e) => Console.WriteLine($"Predicted at {e.Index}: {e.Edge}");
parser.OnEdgeScanned   += (s, e) => Console.WriteLine($"Scanned at {e.Index}: {e.Edge}");
parser.OnEdgeCompleted += (s, e) => Console.WriteLine($"Completed at {e.Index}: {e.Edge}");
```

---

## Usage Notes

- **Ambiguous grammars are supported.** `Parse.ParseTrees` returns a `Collection<ParseTree>` because a string may have more than one valid derivation under a given grammar.
- **`ParserOptions.PredictPreterminals`** (default `true`) controls whether the parser eagerly predicts preterminal rules (rules whose right side contains a terminal). The parser automatically forces this to `true` if the grammar contains a preterminal rule with more than one category on its right side, since just-in-time prediction cannot handle that case.
- **`ParserOptions.IgnoreCase`** (default `false`) controls whether terminal matching during scanning is case-sensitive.
- `Category.Root` is a reserved internal category used to seed parses; it should not be used as a category name in grammar files.

---

## Dependencies

This package has no dependencies on other StarThrower packages.

---

## License

Copyright © 2026 Stephen Elmer. Licensed under the [MIT License](../LICENSE.md).
