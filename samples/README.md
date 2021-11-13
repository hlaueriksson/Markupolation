# Markupolation Sample Code

This code has been written with *Visual Studio 2022*.

## Blazor + Api

Blazor WebAssembly + Minimal API:

* `Markupolation.Sample.Api`
* `Markupolation.Sample.Blazor`

Prerequisite:

1. [Install .NET 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)
2. [Install Tye](https://github.com/dotnet/tye/blob/main/docs/getting_started.md#installing-tye)

Run sample:

```cmd
tye run
```

Tye Dashboard:

http://localhost:8000/

Blazor Site:

https://localhost:8080/

## Functions

Azure Functions:

* `Markupolation.Sample.Functions`

Prerequisite:

1. [Install .NET 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)
2. [Install the Azure Functions Core Tools](https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local?tabs=v4%2Cwindows%2Ccsharp%2Cportal%2Cbash%2Ckeda#install-the-azure-functions-core-tools)

Run sample:

```cmd
cd Markupolation.Sample.Functions
func start
```

## Examples

Console application:

* `Markupolation.Sample.Examples`

Prerequisite:

1. [Install .NET 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)

Run sample:

```cmd
cd Markupolation.Sample.Examples
dotnet run
```
