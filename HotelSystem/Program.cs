using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

builder.Services.AddWeb();

builder.Services.AddServiceDependencies();

builder.Services.AddDataDependancies();


var app = builder.Build();

app.ConfigureAsync();

app.Run();
