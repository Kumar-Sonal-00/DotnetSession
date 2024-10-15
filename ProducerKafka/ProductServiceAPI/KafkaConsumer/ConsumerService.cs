using Confluent.Kafka;
using Newtonsoft.Json;
using ProductServiceAPI.DAL;
using ProductServiceAPI.Models;

namespace ProductServiceAPI.KafkaConsumer
{
    public class ConsumerService : BackgroundService
    {
        private readonly IServiceScopeFactory scopeFactory;
        public ConsumerService(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;   
        }
        public void ReadMessage(string topic)
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
            var consumer = new ConsumerBuilder<int, string>(config).Build();
            consumer.Subscribe(topic);
            try
            {
                while (true)
                {
                    var consumeResult = consumer.Consume();
                    var order = JsonConvert.DeserializeObject<Order>(consumeResult.Message.Value);
                    //get the DbContext service
                    var dbCtx =scopeFactory.CreateScope().ServiceProvider.GetRequiredService<ProductDbContext>();
                    //find the product by pid from order
                    var product = dbCtx.tbl_product.Find(order.Pid);
                    //update(reduce) the product qty by ordered quantity
                    product.Quantity -= order.Order_Quantity;
                    dbCtx.SaveChanges();
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

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Run(() =>
            {
                ReadMessage("topic1");
            });
        }
    }
}
