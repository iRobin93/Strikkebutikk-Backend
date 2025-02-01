using Microsoft.AspNetCore.Mvc;
using StrikkebutikkBackend.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
        public async Task<IActionResult> GetProduct()
        {
           
            List<ProductWithForeignKey> products = await appDBContext.Products.ToListAsync();
            //var productBaseList = products.Cast<ProductBase>().ToList();

            // Convert each product to a dictionary with base64-encoded image
            var productsWithBase64Images = products.Select(p => ConvertProductToDictionary(p)).ToList();

            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            // Return the products as JSON
            return Ok(productsWithBase64Images);

        }


        // Helper method to convert a product to a dictionary with base64-encoded image
        private Dictionary<string, object> ConvertProductToDictionary(ProductBase product)
        {
            var dictionary = new Dictionary<string, object>();

            // Use reflection to get all properties of the Product class
            var properties = typeof(ProductBase).GetProperties();

            foreach (var property in properties)
            {
                var value = property.GetValue(product);

                // Convert the productImg byte array to a base64-encoded string
                if (property.Name == nameof(ProductBase.productImg) && value is byte[] byteArray)
                {
                    dictionary[property.Name] = byteArray != null ? Convert.ToBase64String(byteArray) : null;
                }
                else
                {
                    // Add other properties as-is
                    dictionary[property.Name] = value;
                }
            }

            return dictionary;
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



        [HttpDelete(Name = "DeleteProduct")]
        public IActionResult DeleteProduct(int id)
        {
            var product = appDBContext.Products.Find(id);
            if (product == null)
            {
                // 2. If the entity is not found, return a 404 Not Found
                return NotFound(new { message = "Product not found" });
            }
            appDBContext.Products.Remove(product);
            appDBContext.SaveChanges();
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return Ok();
        }

    }
}