using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlFire.Data;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

// See https://aka.ms/new-console-template for more information
namespace Receive
{
    class Prooogram {
        public static void Main(string[] args)
        {
            ConnectionFactory factory = new ConnectionFactory();

            factory.Uri = new Uri("amqp://guest:guest@localhost:5672");
            IConnection connection = factory.CreateConnection();
           
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "demo-queue",
                                durable: true,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);


            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };
            channel.BasicConsume("demo-queue", true, consumer);

            Console.ReadLine();


            CreateDbSeedData();
            static void CreateDbSeedData()
            {
                using (var context = new LibraryContext())
                {
                    // Creates the database if not exists
                    context.Database.EnsureCreated();
                }
            }
        }
    }
}