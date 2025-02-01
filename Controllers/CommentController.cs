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



        [HttpDelete(Name = "DeleteComment")]
        public IActionResult DeleteComment(int id)
        {
            var comment = appDBContext.Comments.Find(id);
            if (comment == null)
            {
                // 2. If the entity is not found, return a 404 Not Found
                return NotFound(new { message = "Comment not found" });
            }
            appDBContext.Comments.Remove(comment);
            appDBContext.SaveChanges();
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return Ok();
        }

        [HttpPut(Name = "UpdateComment")]
        public IActionResult UpdateComment(int id)
        {
            // Find the comment in the database by ID
            var existingComment = appDBContext.Comments.Find(id);
            if (existingComment == null)
            {
                // 2. If the entity is not found, return a 404 Not Found
                return NotFound(new { message = "Comment not found" });
            }

            // Update the fields of the existing comment with the new values
            existingComment.read = true; // Assuming 'Text' is a property of your Comment model
            

            // Save the changes to the database
            appDBContext.SaveChanges();

            // Set CORS header for allowing requests from different origins
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            return Ok(existingComment); // Optionally return the updated comment
        }


    }
}
