using App.Metrics.AspNetCore;
using App.Metrics.Formatters.Prometheus;
using FavoriteLiterature.Works.Extensions;
using FavoriteLiterature.Works.Extensions.Builder;
using FavoriteLiterature.Works.Extensions.Builder.Common;
using FavoriteLiterature.Works.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.Local.json", optional: true);

builder.Host.UseMetricsWebTracking().UseMetrics(options => 
{
    // Настройка endpoints для Prometheus метрик
    options.EndpointOptions = endpointsOptions =>
    {
        endpointsOptions.MetricsTextEndpointOutputFormatter = new MetricsPrometheusTextOutputFormatter();
        endpointsOptions.MetricsEndpointOutputFormatter = new MetricsPrometheusProtobufOutputFormatter();
        endpointsOptions.EnvironmentInfoEndpointEnabled = false;
    };
});

builder.Services.AddControllers();
builder.Services.AddMetrics();

builder.AddPostgresDatabase();
builder.AddRepositories();
builder.AddMediatr();
builder.AddAutoMapper();
builder.AddCustomMiddlewares();
builder.AddNormalizeRoute();
builder.AddAttachmentStorage();
builder.AddFluentValidation();
builder.AddSwagger();

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