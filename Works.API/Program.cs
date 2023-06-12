using FavoriteLiterature.Works.Extensions;
using FavoriteLiterature.Works.Extensions.Builder;
using FavoriteLiterature.Works.Extensions.Builder.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.AddPostgresDatabase();
builder.Services.AddControllers();
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearerAuthentication(builder.Configuration);

builder.AddRabbitMqSubscriber();
builder.AddSwagger();
builder.AddRepositories();
builder.AddMediatr();
builder.AddAutoMapper();
builder.AddNormalizeRoute();
builder.AddAttachmentStorage();
builder.AddFluentValidation();

var app = builder.Build();
app.SeedDatabase();

app.UseSwagger();
app.UseSwaggerUI();

app.UseExceptionHandlingMiddleware();
app.MapControllers();
app.Run();