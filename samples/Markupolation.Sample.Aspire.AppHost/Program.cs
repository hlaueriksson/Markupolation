var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.Markupolation_Sample_Api>("api");

builder.AddProject<Projects.Markupolation_Sample_ApiGateway>("apigateway")
    .WithReference(api);

builder.AddProject<Projects.Markupolation_Sample_Htmx>("htmx")
    .WithReference(api);

builder.Build().Run();
