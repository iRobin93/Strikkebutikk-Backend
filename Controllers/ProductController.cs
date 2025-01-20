using Microsoft.AspNetCore.Mvc;
using StrikkebutikkBackend.Model;
using System.Data.SqlClient;

namespace StrikkebutikkBackend.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {


        [HttpGet(Name = "GetProduct")]
        public IEnumerable<Product> GetProduct()
        {

            return [new Product { Id = 0, ProductName = "Seven Sisters - genser" },
                    new Product {Id = 1, ProductName = "Bobbie"}];
        }
    }
}
