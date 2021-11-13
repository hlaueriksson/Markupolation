### Markupolation <📜>

[![build](https://github.com/hlaueriksson/Markupolation/actions/workflows/build.yml/badge.svg)](https://github.com/hlaueriksson/Markupolation/actions/workflows/build.yml) [![CodeFactor](https://codefactor.io/repository/github/hlaueriksson/markupolation/badge)](https://codefactor.io/repository/github/hlaueriksson/markupolation)

`Markupolation` is a library for HTML templating with a fluent API:

```cs
$@"{DOCTYPE() +
html(lang("en"),
    head(
        meta(charset("utf-8")),
        e.title("Markupolation"),
        meta(name("description"), content("Sample of how to use Markupolation")),
        meta(name("viewport"), content("width=device-width, initial-scale=1"))
    ),
    body(
        h1("Hello, World!"),
        p("This is ", mark(a.title("Markup with string interpolation"), "Markupolation"), " in action.")
    )
)}";
```

Result (formatted):

```html
<!DOCTYPE html>
<html lang="en">

<head>
  <meta charset="utf-8" />
  <title>Markupolation</title>
  <meta name="description" content="Sample of how to use Markupolation" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>

<body>
  <h1>Hello, World!</h1>
  <p>This is <mark title="Markup with string interpolation">Markupolation</mark> in action.</p>
</body>

</html>
```

Configuration in `csproj` file:

```xml
<ItemGroup>
  <PackageReference Include="Markupolation" Version="1.0.0" />
  <Using Include="Markupolation.Elements" Static="True" />
  <Using Include="Markupolation.Elements" Alias="e" />
  <Using Include="Markupolation.Attributes" Static="True" />
  <Using Include="Markupolation.Attributes" Alias="a" />
</ItemGroup>
```

### Would you like to know more? 🤔

Further documentation is available at [https://github.com/hlaueriksson/Markupolation](https://github.com/hlaueriksson/Markupolation)
