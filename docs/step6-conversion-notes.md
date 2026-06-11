# Step 6 Conversion Notes — MSTest → xUnit v3 + AwesomeAssertions

This file archives the project-by-project gotchas and patterns encountered while
converting Groups 1–7 test projects from MSTest to xUnit v3 + AwesomeAssertions
(Phase 1, Step 6 of the StarThrower.Utilities migration — see `CLAUDE.md`). Kept for
reference during Phase 2 documentation writeups.

**Step 6 conversion script — known gotchas (from StringUtilities, the largest project
converted so far at 1,584+ tests):** for large test files, a one-shot Python script
doing regex-based conversion is workable, but watch for:
- A regex like `Assert\.AreEqual\((.+)\);` (no `re.DOTALL`) only matches **single-line**
  calls. Multi-line `Assert.AreEqual(expr,\n    actual);` calls are missed and must be
  found (`grep -n "Assert\."` after the script runs) and fixed by hand.
- When converting `[TestMethod]\n[ExpectedException(typeof(X))]\n` (or the combined
  `[TestMethod, ExpectedException(typeof(X))]`) forms, if the regex match starts at
  `[TestMethod...` (not including the leading indentation whitespace), the replacement's
  `{indent}[Fact]` ends up **double-indented** — the original indentation before
  `[TestMethod]` is left in place AND the captured `indent` group is prepended again.
  Fix with a follow-up pass: `re.sub(r'^                \[Fact\]', '        [Fact]', text,
  flags=re.MULTILINE)` (or capture/consume the leading whitespace in the original regex).
- A `split_top_level_args` helper (depth-aware comma splitting that respects parens and
  string/char literals) is needed for `Assert.AreEqual`/`IsTrue`/`IsFalse` calls with
  nested method calls or char literals (`Assert.AreEqual('a', ...)`); make it aware of
  both `"..."` and `'...'` so commas inside literals aren't treated as argument
  separators.
- For `[ExpectedException]` bodies, locate the SUT call as the **last** line containing
  the class-under-test prefix (e.g. `StringUtil.`/`DataUtil.`) — not the first — since
  setup lines (e.g. `DateTime expected = DataUtil.DTNull;`) can also contain the prefix.
- After the script runs, grep for leftover `Assert.`, `TestMethod`, `TestClass`,
  `ExpectedException`, `StringAssert`, and `Microsoft.VisualStudio.TestTools` to confirm
  nothing was missed before running the test suite.

**Step 6 conversion notes (from EarleyParser.Test, ~2,900 lines / 136 tests across 13
files):** for projects this size, direct file-by-file `Read`/`Write` conversion (no
regex script) was faster and avoided the StringUtilities-style script gotchas above.
Additional translation patterns observed:
- `ReadOnlyCollection<T>` (and other types using AwesomeAssertions'
  `GenericCollectionAssertions<T>`) do **not** support `.Should().Be(...)` — that
  assertion type has no `Be` member. `Assert.AreEqual(collectionA, collectionB)` on a
  type that doesn't override `Equals` (i.e. the assert was really checking reference
  equality) becomes `.Should().BeSameAs(...)`, not `.Should().Be(...)`.
- `Assert.AreSame`/`Assert.AreNotSame` → `.Should().BeSameAs(...)` /
  `.Should().NotBeSameAs(...)`.
- `Assert.AreEqual(true, x == null)` / `Assert.AreEqual(null, x)` → `x.Should().BeNull()`
  (clearer than `(x == null).Should().Be(true)`).
- `[ExpectedException]` conversions where the constructor/method-under-test takes a
  variable that is itself the null/invalid argument (e.g.
  `Category? nullSeed = null; DottedRule.CreateStartRule(nullSeed);`) — wrap the whole
  call in the lambda: `Action act = () => DottedRule.CreateStartRule(nullSeed);`. The
  variable declaration stays outside the lambda; only the SUT call moves in.
- MSTest scaffolding boilerplate (`#region [ Construction ]` ctor stub, `TestContext`
  field/property, `#region [ Additional test attributes ]`) is removed entirely — even
  when the constructor contains real fixture-setup logic, just keep the meaningful
  constructor body and drop the regions/attributes/TestContext around it. An empty,
  active `[TestInitialize] MyTestInitialize() { }` (as opposed to the commented-out
  template version) is also just deleted, not converted to a constructor.

**Step 6 conversion notes (from XBase.Test, ~1,760 lines / 90 tests across 9 files):**
- `Assert.IsInstanceOfType<T>(x)` → `x.Should().BeOfType<T>()`.
- `Assert.ThrowsException<T>(() => ...)` (the modern MSTest inline-lambda assertion,
  as opposed to the `[ExpectedException]` attribute form) converts the same way as
  `[ExpectedException]`: `Action act = () => ...; act.Should().Throw<T>();`.
- All field-type test classes (`BooleanFieldTest`, `DateFieldTest`, etc.) carried the
  same unused `Ignore()` MSTest-Inconclusive helper, copy-pasted from a template and
  never called — confirmed via grep before deleting, then removed from every file.
- Test project `.csproj` files in this solution were copy-pasted from an earlier
  project's template and can carry a stale header comment (e.g. `XBase.Test.csproj`'s
  banner comment still said `StarThrower.ByteUtilities.Test.csproj`). Check/fix this
  comment during the package-reference edit.

**Step 6 conversion notes (from Gis.GeoUtilities.Test, ~5,800 lines / ~390 tests across
9 files — largest Step 6 project so far by total `Assert.AreEqual` count):**
- `Assert.IsInstanceOfType<IInterface>(x)` does **not** work for interface types —
  `BeOfType<T>()` requires an exact runtime type match. Use
  `x.Should().BeAssignableTo<IInterface>()` instead when the expected type is an
  interface.
- The C# enclosing-namespace lookup rule (verified again here): a type in
  `StarThrower.Gis.GeoUtilities` (or a sub-namespace like
  `StarThrower.Gis.GeoUtilities.Zones.Utm`) is visible from
  `StarThrower.Gis.GeoUtilities.Test` without an explicit `using`, because the compiler
  searches enclosing namespaces of the *current* namespace. This applies to namespace
  segments too (e.g. `Zones.Utm.UtmZone` resolves even without
  `using StarThrower.Gis.GeoUtilities;`, but if that using is already present for other
  reasons, keep it — don't strip a using just because part of what it covers is also
  reachable via the enclosing-namespace rule).
- **3-argument `Assert.AreEqual(expected, actual, "message")`** (seen for the first time
  in `WGS84TranslationTest.cs`): convert to `actual.Should().Be(expected, "message")`.
  AwesomeAssertions' `Be(expected, because, becauseArgs)` overload treats the 2nd
  argument as a "because" reason appended to failure output — passing the original
  short label (e.g. `"(x)"`, `"(zone)"`) preserves the diagnostic value of knowing which
  of several related assertions in a helper method failed.
- **`Assert.AreEqual(true, expr)` / `Assert.AreEqual(false, expr)`** → `expr.Should()
  .BeTrue()` / `expr.Should().BeFalse()` — cleaner than `.Should().Be(true)` and matches
  the existing guidance for `Assert.AreEqual(true, x == null)` → `x.Should().BeNull()`.
- **Generalized depth-aware `Assert.AreEqual` converter** (used for `CsUtilTest.cs`,
  701 calls across 13 `[Fact]`s, all single-line but with deeply nested `new
  Foo(Bar.Baz, Bar.Qux).Property` expressions containing top-level-irrelevant commas):
  a single `convert_calls(text, name)` Python function combining `find_matching_paren`
  and `split_top_level_args` handled all three patterns above (`Be`, `BeTrue`,
  `BeFalse`) in one pass, including correctly **skipping commented-out
  `//Assert.AreEqual(...)` lines** (check `line.lstrip().startswith('//')` before
  converting — left 8 such lines untouched verbatim).
- **`[TestMethod, ExpectedException(typeof(X))]` on a single line with a comma** (as
  opposed to two separate attribute lines) is easy to miss with an exact-match
  `\[TestMethod\]` replace/grep — it has trailing characters before `]`. Always grep
  for `ExpectedException` separately as a final check, even after a `[TestMethod]`
  count looks like it accounts for all test methods.
- For `[ExpectedException]` conversions where the only purpose of the original code was
  to *read* a property/method that's expected to throw (no meaningful return value),
  use a discard: `Action act = () => _ = expr;` — avoids declaring an unused local
  variable (e.g. `double lon = ...;`) that would otherwise trigger an analyzer warning.
- **ripgrep does not support regex lookahead** (`(?!...)`). A pattern like
  `Assert\.(?!AreEqual)` silently returns "No matches found" instead of erroring or
  matching as expected — it does **not** mean the file is clean. Use a different
  verification strategy instead, e.g. anchor on `^\s*Assert\.` plus separate explicit
  alternatives (`TestMethod|TestClass|ExpectedException|...`), or grep for `Assert\.`
  generally and inspect the matches.
- Hard-coded absolute test-data paths in constructors (e.g.
  `WGS84TranslationTest`'s `_inputFolder = @"D:\StarThrower\...\TestInput"`) are
  Step 8 territory — left untouched during Step 6 conversions.
