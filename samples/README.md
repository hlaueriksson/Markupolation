# Markupolation Sample Code<!-- omit in toc -->

Content:

- [Blazor + Api](#blazor--api)
- [HTMX + Api](#htmx--api)
- [Functions](#functions)
- [Examples](#examples)

This code has been written with *Visual Studio 2022*.

## Blazor + Api

> [Blazor](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor) - Use the power of .NET and C# to build full stack web apps without writing a line of JavaScript.

Blazor WebAssembly + Minimal API:

- `Markupolation.Sample.Api`
- `Markupolation.Sample.Blazor`

Prerequisite:

1. [Install .NET 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
2. [Install Tye](https://github.com/dotnet/tye/blob/main/docs/getting_started.md#installing-tye)

Run sample:

```cmd
tye run tye-blazor.yaml
```

Blazor Site:

https://localhost:8080/

Tye Dashboard:

http://localhost:8000/

![Markupolation.Sample.Blazor](Markupolation.Sample.Blazor.gif)

## HTMX + Api

> </> [htmx](https://htmx.org/) - high power tools for HTML

HTMX + Minimal API:

- `Markupolation.Sample.Api`
- `Markupolation.Sample.Htmx`

Prerequisite:

1. [Install .NET 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
2. [Install Tye](https://github.com/dotnet/tye/blob/main/docs/getting_started.md#installing-tye)

Run sample:

```cmd
tye run tye-htmx.yaml
```

HTMX Site:

https://localhost:8080/

Tye Dashboard:

http://localhost:8000/

![Markupolation.Sample.Htmx](Markupolation.Sample.Htmx.gif)

## Functions

> [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) is a serverless solution that allows you to write less code, maintain less infrastructure, and save on costs.

Azure Functions:

- `Markupolation.Sample.Functions`

Prerequisite:

1. [Install .NET 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)
2. [Install the Azure Functions Core Tools](https://learn.microsoft.com/en-us/azure/azure-functions/functions-run-local)

Run sample:

```cmd
cd Markupolation.Sample.Functions
func start
```

## Examples

Console application:

- `Markupolation.Sample.Examples`

Prerequisite:

1. [Install .NET 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
2. Build:
   - `dotnet build Markupolation.Sample.Examples`
3. [Install Playwright](https://playwright.dev/dotnet/docs/intro):
   - `.\bin\Debug\net8.0\playwright.ps1 install`

Run sample:

```cmd
dotnet run --project Markupolation.Sample.Examples
```

![Markupolation.Sample.Examples](Markupolation.Sample.Examples.gif)
