using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using API_Kassim_Co.Data;
using API_BDTN.Models;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<API_Kassim_CoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("API_Kassim_CoContext") ?? throw new
InvalidOperationException("Connection string 'API_BDTNContext' not found.")));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
