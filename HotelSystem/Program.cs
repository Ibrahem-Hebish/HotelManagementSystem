WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddUserSecrets<Program>(true);

builder.Host.UseSerilog();

builder.Services.AddDataDependancies(builder.Configuration);

builder.Services.AddServiceDependencies(builder.Configuration);

builder.Services.AddCore();

builder.Services.AddWeb();

var app = builder.Build();

await app.ConfigureAsync();

app.Run();
