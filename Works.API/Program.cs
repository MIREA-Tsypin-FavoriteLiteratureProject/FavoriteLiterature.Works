using FavoriteLiterature.Works.Extensions;
using FavoriteLiterature.Works.Extensions.Builder;
using FavoriteLiterature.Works.Extensions.Builder.Common;

var builder = WebApplication.CreateBuilder(args);

builder.AddPostgresDatabase();
builder.Services.AddControllers();
builder.AddRabbitMqSubscriber();
builder.AddSwagger();
builder.AddRepositories();
builder.AddMediatr();
builder.AddAutoMapper();
builder.AddNormalizeRoute();
builder.AddAttachmentStorage();

var app = builder.Build();
app.SeedDatabase();

app.UseSwagger();
app.UseSwaggerUI();

app.UseExceptionHandlingMiddleware();
app.MapControllers();
app.Run();