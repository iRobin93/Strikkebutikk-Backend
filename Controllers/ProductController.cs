using Microsoft.AspNetCore.Mvc;
using StrikkebutikkBackend.Model;

namespace StrikkebutikkBackend.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly AppDBContext appDBContext;

        public ProductController(AppDBContext appDBContext) 
        {
            this.appDBContext = appDBContext;
        }

        [HttpGet(Name = "GetProduct")]
        public IEnumerable<Product> GetProduct()
        {
            var products = appDBContext.Products.ToList();
            
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return products;
        }
    }
}