### Markupolation.Extensions <📜>

[![build](https://github.com/hlaueriksson/Markupolation/actions/workflows/build.yml/badge.svg)](https://github.com/hlaueriksson/Markupolation/actions/workflows/build.yml) [![CodeFactor](https://codefactor.io/repository/github/hlaueriksson/markupolation/badge)](https://codefactor.io/repository/github/hlaueriksson/markupolation)

`Markupolation.Extensions` is a library with extensions for HTML templating with a fluent API:

```cs
Func<int, bool> fizz = (int i) => i % 3 == 0;
Func<int, bool> buzz = (int i) => i % 5 == 0;
var numbers = Enumerable.Range(1, 15);
$@"{DOCTYPE() +
html(lang("en"),
    head(
        meta(charset("utf-8")),
        e.title("Markupolation.Extensions"),
        meta(name("description"), content("Sample of how to use Markupolation.Extensions")),
        meta(name("viewport"), content("width=device-width, initial-scale=1"))
    ),
    body(
        ul(
            numbers.Each(x => li(
                x.IfMatch(i => fizz(i) && buzz(i), i => strong("FizzBuzz")),
                x.IfMatch(i => fizz(i) && !buzz(i), i => em("Fizz")),
                x.IfMatch(i => !fizz(i) && buzz(i), i => em("Buzz")),
                x.IfMatch(i => !fizz(i) && !buzz(i), i => i.ToString())
            ))
        )
    )
)}";
```

Result (formatted):

```html
<!DOCTYPE html>
<html lang="en">

<head>
  <meta charset="utf-8" />
  <title>Markupolation.Extensions</title>
  <meta name="description" content="Sample of how to use Markupolation.Extensions" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>

<body>
  <ul>
    <li>1</li>
    <li>2</li>
    <li><em>Fizz</em></li>
    <li>4</li>
    <li><em>Buzz</em></li>
    <li><em>Fizz</em></li>
    <li>7</li>
    <li>8</li>
    <li><em>Fizz</em></li>
    <li><em>Buzz</em></li>
    <li>11</li>
    <li><em>Fizz</em></li>
    <li>13</li>
    <li>14</li>
    <li><strong>FizzBuzz</strong></li>
  </ul>
</body>

</html>
```

Configuration in `csproj` file:

```xml
<ItemGroup>
  <PackageReference Include="Markupolation" Version="1.0.0" />
  <Using Include="Markupolation" />
  <Using Include="Markupolation.Elements" Static="True" />
  <Using Include="Markupolation.Elements" Alias="e" />
  <Using Include="Markupolation.Attributes" Static="True" />
  <Using Include="Markupolation.Attributes" Alias="a" />
</ItemGroup>
```

### Extensions

Extensions on `IEnumerable<T>`:

* `Each<T>`
* `IfEmpty<T>`
* `IfNotEmpty<T>`

Extensions on `T`:

* `IfNull<T>`
* `IfNotNull<T>`
* `IfMatch<T>`

Extensions on `string`:

* `IfNullOrEmpty`
* `IfNotNullOrEmpty`

Extensions on `T?`:

* `IfHasValue<T>`

### Would you like to know more? 🤔

Further documentation is available at [https://github.com/hlaueriksson/Markupolation](https://github.com/hlaueriksson/Markupolation)
