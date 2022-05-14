using Microsoft.AspNetCore.Mvc;
using Sorter.Api.Extensions;
using Sorter.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddLogging();
builder.Services.AddSwaggerGen();
builder.Services.RegisterApp(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.AddExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();
