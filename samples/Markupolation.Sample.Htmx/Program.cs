var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
builder.Services.AddHttpForwarderWithServiceDiscovery();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapForwarder("/api/{**catch-all}", "http://api", "/{**catch-all}");
app.MapDefaultEndpoints();

app.Run();
