WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddUserSecrets<Program>(true);

builder.Host.UseSerilog();

builder.Services.AddData(builder.Configuration);

builder.Services.AddService(builder.Configuration);

builder.Services.AddCore(builder.Configuration);

builder.Services.AddWeb();

var app = builder.Build();

await app.ConfigureAsync();

app.Run();
