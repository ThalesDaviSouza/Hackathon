using SimuladorCredito.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigServices();
builder.ConfigSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfig();
}

app.UseHttpsRedirection();
app.ConfigMiddlewares();

app.MapControllers();

app.Run();
