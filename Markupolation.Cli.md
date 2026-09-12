### Markupolation.Cli <📜>

A `dotnet tool` that converts HTML into [Markupolation](https://github.com/hlaueriksson/Markupolation) source.

### Installation

```
dotnet tool install --global Markupolation.Cli
```

### Usage

```
markupolation convert index.html
markupolation convert -            # standard input
cat index.html | markupolation convert
```

```
Options:
  --fragment       emit the nodes as given, with no html/head/body wrapper
  --document       emit a whole document, even if the input is a fragment
  --no-aliases     do not qualify ambiguous names with e. and a.
  --indent <n>     spaces per level (default 4)
  --output <file>  write to a file instead of standard output
```

### Example

```
$ echo '<div class="card"><h1>Hi</h1><input type="checkbox" checked></div>' | markupolation convert
```

```cs
div(class_("card"),
    h1("Hi"),
    input(type("checkbox"), checked_())
)
```

Paste a component from anywhere and get compiling C# back. Useful for getting started, and for
agents that need to produce Markupolation reliably.

### What it knows

The conversion is driven by the same generated metadata the library renders from, so it does not
restate the specification: whether a name is an element or an attribute, whether an element is
void, whether an attribute is boolean, and which nine names need `e.` or `a.` to compile.

Anything outside the specification falls back to the escape hatches — `new A("hx-get", "/x")` for
an unknown attribute, `new E("<svg …>")` for foreign content such as SVG.

Input is a fragment or a whole document depending on what it looks like; `--fragment` and
`--document` force it either way.

### Would you like to know more? 🤔

Further documentation is available at [https://github.com/hlaueriksson/Markupolation](https://github.com/hlaueriksson/Markupolation)
