﻿using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerKafka
{
    internal class ConsumerService
    {
        public void ReadMessage()
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest,
                ClientId = "my-app",
                GroupId = "my-group",
                BrokerAddressFamily = BrokerAddressFamily.V4,
            };
            using
            var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
            consumer.Subscribe("topic1");
            try
            {
                while (true)
                {
                    var consumeResult = consumer.Consume();
                    Console.WriteLine($"Message received from: {consumeResult.Message.Value}");
                }
            }
            catch (OperationCanceledException)
            {
                // The consumer was stopped via cancellation token.
            }
            finally
            {
                consumer.Close();
            }
            Console.ReadLine();
        }

    }
}
