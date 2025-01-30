using Microsoft.AspNetCore.Mvc;
using StrikkebutikkBackend.Model;

namespace StrikkebutikkBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatternController : Controller
    {
        private readonly AppDBContext appDBContext;

        public PatternController(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        [HttpGet(Name = "GetPattern")]
        public IEnumerable<Pattern> GetPattern()
        {
            var patterns = appDBContext.Patterns.ToList();

            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return patterns;
        }

        [HttpPost(Name = "PostPattern")]
        public IActionResult PostPattern(Pattern pattern)
        {

            appDBContext.Patterns.Add(pattern);
            appDBContext.SaveChanges();
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return Ok();
        }


        [HttpDelete(Name = "DeletePattern")]
        public IActionResult DeletePattern(int id)
        {
            var pattern = appDBContext.Patterns.Find(id);
            if (pattern == null)
            {
                // 2. If the entity is not found, return a 404 Not Found
                return NotFound(new { message = "Pattern not found" });
            }

            try
            {
                appDBContext.Patterns.Remove(pattern);
                appDBContext.SaveChanges();
            }
            catch (Exception error)
            {
                return Conflict(new {message = "Foreign key conflict"});
            }


            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return Ok();
        }


    }
}
