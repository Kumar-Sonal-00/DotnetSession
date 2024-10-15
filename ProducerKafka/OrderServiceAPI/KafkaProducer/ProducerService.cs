using Confluent.Kafka;

namespace OrderServiceAPI.KafkaProducer
{
    public class ProducerService
    {
        public async Task CreateMessage(string topic,Message<int,string> message)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092",
                ClientId = "my-app",
                BrokerAddressFamily = BrokerAddressFamily.V4,
            };
            using
            var producer = new ProducerBuilder<int, string>(config).Build();
            await producer.ProduceAsync(topic, message);
            
        }
    }
}
