using Application;
using Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigurePersistanceServices(builder.Configuration);
builder.Services.AddControllers();
builder.Host.UseSerilog((context, configuration) =>
configuration.ReadFrom.Configuration(context.Configuration));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.UseSerilogRequestLogging();

app.Run();
