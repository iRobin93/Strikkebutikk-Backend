using Microsoft.AspNetCore.Mvc;
using StrikkebutikkBackend.Model;

namespace StrikkebutikkBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssortmentController : Controller
    {

        private readonly AppDBContext appDBContext;

        public AssortmentController(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        [HttpGet(Name = "GetAssortment")]
        public IEnumerable<Assortment> GetAssortment()
        {
            var assortments = appDBContext.Assortments.ToList();

            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return assortments;
        }

        [HttpPost(Name = "PostAssortment")]
        public IActionResult PostAssortment(Assortment assortment)
        {

            appDBContext.Assortments.Add(assortment);
            appDBContext.SaveChanges();
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return Ok();
        }


        [HttpDelete(Name = "DeleteAssortment")]
        public IActionResult DeleteAssortment(int id)
        {
            var assortment = appDBContext.Assortments.Find(id);
            if (assortment == null)
            {
                // 2. If the entity is not found, return a 404 Not Found
                return NotFound(new { message = "Assortment not found" });
            }
            appDBContext.Assortments.Remove(assortment);
            appDBContext.SaveChanges();
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return Ok();
        }


    }
}
