using Microsoft.EntityFrameworkCore;
using RinhaBackend2024.Context;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NOME");
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");

var connectionString =
    $"Data Source={dbHost}; Initial Catalog={dbName}; User id=sa; Password={dbPassword}; TrustServerCertificate=true";
builder.Services.AddDbContext<AppDbContext>(options => options
    .UseSqlServer(connectionString, x => x
        .MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

var port = builder.Configuration["APIPORT"];
builder.WebHost.UseUrls($"http://*:{port}");

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();