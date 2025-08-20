using SimuladorCredito.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfig();
builder.Services.AddControllers();
builder.Services.AddDependencyInjection();
builder.Services.AddOpenTelemetryConfiguration("SimuladorCreditoApi");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfig();
}

app.UseHttpsRedirection();
app.UseCustomMiddlewares();

app.MapControllers();

app.Run();
