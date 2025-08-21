using DotNetEnv;
using SimuladorCredito.Api.Configuration;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigServices();
builder.Services.ConfigProfiles();
builder.ConfigSerilog();
builder.ConfigDbContexts();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfig();
}

app.UseHttpsRedirection();
app.ConfigMiddlewares();

app.MapControllers();

app.Run();
