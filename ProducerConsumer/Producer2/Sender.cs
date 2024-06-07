using RabbitMQ.Client;
using System.Text;

namespace Sender_Demo
{
	public static class Sender
	{
		public static void Main(string[] args)
		{
			ConnectionFactory factory = new ConnectionFactory()
			{
				HostName = "localhost"
			};

			try
			{
				using (IConnection connection = factory.CreateConnection())
				using (IModel channel = connection.CreateModel())
				{
					string message = $"Hello RabbitMQ #{new Random().Next()}!";
					byte[] encodedMessage = Encoding.UTF8.GetBytes(message);

					channel.BasicPublish(
						exchange: "",
						routingKey: "BasicTest",
						body: encodedMessage);
					Console.WriteLine("Message sent.");
				}
			}
			catch (RabbitMQ.Client.Exceptions.BrokerUnreachableException ex)
			{
				Console.WriteLine("Could not reach the RabbitMQ broker: " + ex.Message);
			}
			catch (Exception ex)
			{
				Console.WriteLine("An error occurred: " + ex.Message);
			}

			Console.ReadKey();
		}
	}
}
