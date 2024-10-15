using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductServiceAPI.DAL;
using ProductServiceAPI.Models;

namespace ProductServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductDbContext _dbCtx;
        public ProductsController(ProductDbContext dbCtx)
        {
            _dbCtx=dbCtx;
        }
        [HttpGet]
        public List<Product> Get()
        {
            return _dbCtx.tbl_product.ToList();
        }
    }
}
