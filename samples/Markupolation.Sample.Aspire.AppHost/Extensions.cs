public static class Extensions
{
    public static IResourceBuilder<ExecutableResource> AddAzureFunction<TProjectMetadata>(
        this IDistributedApplicationBuilder builder,
        string name,
        int port,
        int debugPort)
        where TProjectMetadata : IProjectMetadata, new()
    {
        var projectMetadata = new TProjectMetadata();
        var projectPath = projectMetadata.ProjectPath;
        var projectDirectory = Path.GetDirectoryName(projectPath)!;

        var args = new[]
        {
            "host",
            "start",
            "--port",
            port.ToString(),
            "--nodeDebugPort",
            debugPort.ToString()
        };

        return builder.AddExecutable(name, "func", projectDirectory, args)
            .WithOtlpExporter();
    }
}
