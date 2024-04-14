var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.Markupolation_Sample_Api>("api");

builder.AddProject<Projects.Markupolation_Sample_ApiGateway>("apigateway")
    .WithReference(api);

builder.AddProject<Projects.Markupolation_Sample_Htmx>("htmx")
    .WithReference(api);

//var functions = builder.AddProject<Projects.Markupolation_Sample_Functions>("functions");
builder.AddAzureFunction<Projects.Markupolation_Sample_Functions>(
    "functions", port: 7074, debugPort: 5944);

builder.AddProject<Projects.Markupolation_Sample_Blazor>("blazor");
    //.WithReference(functions);

builder.Build().Run();
