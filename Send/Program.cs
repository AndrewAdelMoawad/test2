// See https://aka.ms/new-console-template for more information
using System;
using RabbitMQ.Client;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Send
{
    internal class Send : Dbcontext
    {


        static void Main(string[] args)
        {

            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "demo-queue",
                                durable: true,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);
            var message = new { Name = "Producer", Message = "Hello!" };
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            channel.BasicPublish("", "demo-queue", null, body);
        }


    }
}
