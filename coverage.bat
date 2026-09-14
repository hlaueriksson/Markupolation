dotnet tool restore
dotnet test tests\Markupolation.Tests --collect:"XPlat Code Coverage" --results-directory tests\Markupolation.Tests\TestResults
dotnet reportgenerator -reports:tests\Markupolation.Tests\TestResults\**\coverage.cobertura.xml -targetdir:tests\Markupolation.Tests\TestResults\CoverageReport -reporttypes:Html;TextSummary
type tests\Markupolation.Tests\TestResults\CoverageReport\Summary.txt
