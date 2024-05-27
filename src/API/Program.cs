using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NPoco;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//Configuration
ConfigurationManager configuration = builder.Configuration;
builder.Configuration.AddJsonFile("appsettings.json", true, true);

// Add serilog services to the container and read config from appsettings
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

//AddServices
builder.Services.AddEndpointsApiExplorer()
                .AddSwaggerGen()
                .AddControllers();


var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();

