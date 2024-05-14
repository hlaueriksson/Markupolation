var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.Markupolation_Sample_Api>("api");

builder.AddProject<Projects.Markupolation_Sample_ApiGateway>("apigateway")
    .WithReference(api);

builder.AddProject<Projects.Markupolation_Sample_Htmx>("htmx")
    .WithExternalHttpEndpoints()
    .WithReference(api);

var functions = builder.AddProject<Projects.Markupolation_Sample_Functions>("functions");

builder.AddProject<Projects.Markupolation_Sample_Blazor>("blazor")
    .WithExternalHttpEndpoints()
    .WithReference(functions);

builder.Build().Run();
