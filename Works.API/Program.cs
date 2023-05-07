using FavoriteLiterature.Works.Data;
using FavoriteLiterature.Works.Extensions.Builder;
using FavoriteLiterature.Works.Extensions.Builder.Common;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new Exception("Connection string is missing.");
}

builder.Services.AddControllers();
builder.AddSwagger();
builder.Services
    .AddDbContext<FavoriteLiteratureWorksDbContext>(options => options.UseNpgsql(connectionString));
builder.AddRepositories();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();