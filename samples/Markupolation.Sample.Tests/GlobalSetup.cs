using Aspire.Hosting;

namespace Markupolation.Sample.Tests;

[SetUpFixture]
public class GlobalSetup
{
    public static DistributedApplication App { get; private set; } = null!;

    [OneTimeSetUp]
    public async Task Init()
    {
        var appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.Markupolation_Sample_Aspire_AppHost>();
        App = await appHost.BuildAsync();
        await App.StartAsync();
    }

    [OneTimeTearDown]
    public async Task Cleanup()
    {
        await App.DisposeAsync();
    }
}
