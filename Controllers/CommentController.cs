using System;
using Microsoft.AspNetCore.Mvc;
using StrikkebutikkBackend.Model;

namespace StrikkebutikkBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : Controller
    {

        private readonly AppDBContext appDBContext;

        public CommentController(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        [HttpPost(Name = "PostComment")]
        public IActionResult PostComment(Comment comment)
        {

            appDBContext.Comments.Add(comment);
            appDBContext.SaveChanges();
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return Ok();
        }


        [HttpGet(Name = "GetComment")]
        public IEnumerable<Comment> GetComment()
        {
            var comments = appDBContext.Comments.ToList();

            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return comments;
        }


    }
}
