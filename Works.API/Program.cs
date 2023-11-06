using FavoriteLiterature.Works.Extensions;
using FavoriteLiterature.Works.Extensions.Builder;
using FavoriteLiterature.Works.Extensions.Builder.Common;
using FavoriteLiterature.Works.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.Local.json", optional: true);

builder.AddPostgresDatabase();
builder.Services.AddControllers();

builder.AddRabbitMqSubscriber();
builder.AddSwagger();
builder.AddRepositories();
builder.AddMediatr();
builder.AddAutoMapper();
builder.AddCustomMiddlewares();
builder.AddNormalizeRoute();
builder.AddAttachmentStorage();
builder.AddFluentValidation();

var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.SeedDatabase();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.UseExceptionHandlingMiddleware();
app.MapControllers();
app.Run();