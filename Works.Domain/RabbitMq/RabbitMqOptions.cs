namespace FavoriteLiterature.Works.Domain.RabbitMq;

public class RabbitMqOptions
{
    public string HostName { get; set; }
    
    public int Port { get; set; }
    
    public string UserName { get; set; }
    
    public string Password { get; set; }
    
    public string Queue { get; set; }
}