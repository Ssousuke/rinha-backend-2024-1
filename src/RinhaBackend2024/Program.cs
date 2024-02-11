using Microsoft.EntityFrameworkCore;
using RinhaBackend2024.Context;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("Dev")));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var port = builder.Configuration["APIPORT"];
builder.WebHost.UseUrls($"http://*:{port}");

var app = builder.Build();

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