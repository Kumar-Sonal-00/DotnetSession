using Confluent.Kafka;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderServiceAPI.KafkaProducer;
using OrderServiceAPI.Models;
using System.Text.Json.Serialization;

namespace OrderServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderDbContext _dbCtx;
        public OrdersController(OrderDbContext dbCtx)
        {
            this._dbCtx = dbCtx;
        }
        [HttpPost]
        public async Task Post([FromBody] Order order)
        {
            //create order record
            _dbCtx.tbl_orders.Add(order);
            _dbCtx.SaveChanges();
            //produce the msg into kafka topic
            var producerService = new ProducerService();
            await producerService.CreateMessage("topic1", new Message<int, string>
            {
                Key = order.Id,
                Value = JsonConvert.SerializeObject(order)
            });
        }
    }
}
