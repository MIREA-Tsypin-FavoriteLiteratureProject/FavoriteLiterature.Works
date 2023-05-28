using System.Text;
using System.Text.Json;
using FavoriteLiterature.Works.Domain.RabbitMq;
using FavoriteLiterature.Works.Domain.Works.Requests.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace FavoriteLiterature.Works.Application.Handlers.RabbitMq;

public class RabbitMqService : BackgroundService
{
    private readonly IModel _channel;
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly EventingBasicConsumer _consumer;
    private readonly string _queue;

    public RabbitMqService(IServiceScopeFactory serviceScopeFactory, IOptions<RabbitMqOptions> options)
    {
        _serviceScopeFactory = serviceScopeFactory;
        
        var rabbitMqOptions = options.Value;
        var factory = new ConnectionFactory { 
            HostName = rabbitMqOptions.HostName,
            Port = rabbitMqOptions.Port,
            UserName = rabbitMqOptions.UserName,
            Password = rabbitMqOptions.Password, 
        };
        
        var connection = factory.CreateConnection();
        _channel = connection.CreateModel();
        _queue = rabbitMqOptions.Queue;
        
        _channel.QueueDeclare(
            queue: _queue, 
            durable: true, 
            exclusive: false, 
            autoDelete: false, 
            arguments: null);
        
        _consumer = new EventingBasicConsumer(_channel);
    }

    protected override Task ExecuteAsync(CancellationToken cancellationToken)
    {
        _consumer.Received += async (_, eventArgs) =>
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            
            var jsonString = Encoding.UTF8.GetString(eventArgs.Body.ToArray());
            
            var request = JsonSerializer.Deserialize<CreateWorkCommand>(
                json: jsonString, 
                options: new JsonSerializerOptions 
                {
                    PropertyNameCaseInsensitive = true
                });

            if (request is null)
            {
                _channel.BasicReject(eventArgs.DeliveryTag, false);
            }
            else
            {
                try
                {
                    await mediator.Send(request, cancellationToken);
                    _channel.BasicAck(eventArgs.DeliveryTag, false);
                }
                catch (Exception exception)
                {
                    _channel.BasicReject(eventArgs.DeliveryTag, false);
                }
            }
        };

        _channel.BasicConsume(_queue, false, _consumer);
        return Task.CompletedTask;
    }

    public override void Dispose()
    {
        _channel.Close();
        base.Dispose();
    }
}