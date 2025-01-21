using Microsoft.AspNetCore.Mvc;
using StrikkebutikkBackend.Model;
using Microsoft.Data.SqlClient;

namespace StrikkebutikkBackend.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        [HttpGet(Name = "GetProduct")]
        public IEnumerable<Product> GetProduct()
        {
            List<Product> products = new();
            SqlConnection con = new SqlConnection("Data Source = (localdb)\\local; Initial Catalog = Strikkebutikk; Integrated Security = True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Product", con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    products.Add(new Product { Id = (int)reader["Id"], ProductName = reader["ProductName"].ToString() });
                }
            }
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return products;
        }
    }
}