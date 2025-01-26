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


        [HttpPost(Name = "PostProduct")]
        public IActionResult PostProduct(Product product)
        {

            appDBContext.Products.Add(product);
            appDBContext.SaveChanges();
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return Ok();
        }

    }
}