using Microsoft.AspNetCore.Mvc;
using StrikkebutikkBackend.Model;
using AutoMapper;

namespace StrikkebutikkBackend.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly AppDBContext appDBContext;
        private readonly IMapper _mapper;


        public ProductController(AppDBContext appDBContext, IMapper mapper) 
        {
            _mapper = mapper;
            this.appDBContext = appDBContext;
        }

        [HttpGet(Name = "GetProduct")]
        public IEnumerable<ProductBase> GetProduct()
        {
           
            List<ProductWithForeignKey> products = appDBContext.Products.ToList();
            var productBaseList = products.Cast<ProductBase>().ToList();

            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return productBaseList;
        }


        [HttpPost(Name = "PostProduct")]
        public IActionResult PostProduct(ProductBase product)
        {



            var productWithForeignKey = _mapper.Map<ProductWithForeignKey>(product);

            appDBContext.Products.Add(productWithForeignKey);// Cast was successful
            appDBContext.SaveChanges();
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return Ok();
        }

    }
}