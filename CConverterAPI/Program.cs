using Dtos;
using CConverterAPI.api;
using Services;
using Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddValidators();
builder.Services.RegisterControllers();
builder.Services.AddServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddEndpoints();

app.Run();