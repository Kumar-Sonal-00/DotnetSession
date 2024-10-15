namespace ProducerKafka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var producer = new ProducerService();
            producer.CreateMessage().Wait();
        }
    }
}
