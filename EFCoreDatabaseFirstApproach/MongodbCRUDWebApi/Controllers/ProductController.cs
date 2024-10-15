using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongodbCRUDWebApi.Models;

namespace MongodbCRUDWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        MongoDbContext dbCtx;
        public ProductController()
        {
            this.dbCtx = new MongoDbContext();
        }

        [HttpGet]
        public List<Product> Get()
        {
            return dbCtx.Products.Find(p=>true).ToList();
        }

        [HttpPost]
        public void Post(Product product)
        {
            dbCtx.Products.InsertOne(product);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public Product GetById(string id)
        {
            return dbCtx.Products
                        .Find(p => p.ProductId == id)
                        .SingleOrDefault();
        }

        [HttpDelete]
        [Route("DeleteById/{id}")]
        public void DeleteById(string id)
        {
            dbCtx.Products.DeleteOne(p => p.ProductId == id);
        }

        [HttpPut]
        public void Put(Product product)
        {
            var filter=Builders<Product>.Filter.Where(p=>p.ProductId == product.ProductId);

            var update = Builders<Product>.Update
                                          .Set("Price",product.Price)
                                          .Set("Description",product.Description);
            
            dbCtx.Products.UpdateOne(filter,update);
        }
    }
}
