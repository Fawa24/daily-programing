using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Handler_Demo
{
	public static class Handler
	{
		public static void Main(string[] args)
		{
			ConnectionFactory factory = new ConnectionFactory()
			{
				HostName = "localhost"
			};

			using (IConnection connection = factory.CreateConnection())
			using (IModel channel = connection.CreateModel())
			{
				EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
				consumer.Received += (model, ea) =>
				{
					ReadOnlyMemory<byte> body = ea.Body;
					string message = Encoding.UTF8.GetString(body.Span);
					Console.WriteLine($"Received message: {message}");
				};

				channel.BasicConsume(
					queue: "BasicTest",
					autoAck: true,
					consumerTag: "",	
					consumer: consumer);

				Console.WriteLine();
			}
		}
	}
}