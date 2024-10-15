using EFCodeCodeFirstApproach.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCodeCodeFirstApproach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductDbContext _db;
        public ProductsController(ProductDbContext dbContext)
        {
            this._db = dbContext;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _db.tbl_products.ToList(); ;
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _db.tbl_products.Find(id);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] Product product)
        {
            _db.tbl_products.Add(product);
            _db.SaveChanges();
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            var record = _db.tbl_products.Find(id);
            if (record != null) 
            {
                record.Price = product.Price;
                _db.SaveChanges();
            }
            else
            {
                throw new Exception("Product id not found");
            }            
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var record = _db.tbl_products.Find(id);
            if (record != null)
            {
                _db.tbl_products.Remove(record);
                _db.SaveChanges();
            }
            else
            {
                throw new Exception("Product id not found");
            }
        }
    }
}
