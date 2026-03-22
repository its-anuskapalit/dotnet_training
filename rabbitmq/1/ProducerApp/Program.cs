using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory()
{
    HostName = "localhost"
};

var connection = await factory.CreateConnectionAsync();
var channel = await connection.CreateChannelAsync();

await channel.QueueDeclareAsync(
    queue: "user_queue",
    durable: false,
    exclusive: false,
    autoDelete: false,
    arguments: null
);

string message = "User Registered Successfully!";
var body = Encoding.UTF8.GetBytes(message);

await channel.BasicPublishAsync(
    exchange: "",
    routingKey: "user_queue",
    body: body
);

Console.WriteLine($"Sent: {message}");