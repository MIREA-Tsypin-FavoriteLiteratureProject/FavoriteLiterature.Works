using System.Reflection;
using Jaeger;
using Jaeger.Reporters;
using Jaeger.Samplers;
using Jaeger.Senders.Thrift;
using OpenTracing;
using OpenTracing.Util;

namespace FavoriteLiterature.Works.Extensions.Builder.Common;

public static class JaegerExtensions
{
    public static void AddJaeger(this IServiceCollection services)
    {
        services.AddSingleton<ITracer>(serviceProvider =>
        {
            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
            var reporter = new RemoteReporter.Builder()
                .WithLoggerFactory(loggerFactory)
                .WithSender(new UdpSender())
                .Build();
            var serviceName = Assembly.GetEntryAssembly()!.GetName().Name;

            var tracer = new Tracer.Builder(serviceName)
                .WithSampler(new ConstSampler(true))
                .WithLoggerFactory(loggerFactory)
                .WithReporter(reporter)
                .Build();
            GlobalTracer.Register(tracer);
            return tracer;
        });

        services.AddOpenTracing();
    }
}