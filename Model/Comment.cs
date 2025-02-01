using System.ComponentModel.DataAnnotations;

namespace StrikkebutikkBackend.Model
{
    public class Comment
    {
        public int id { get; set; }
        public string comment {  get; set; }
        public string email { get; set; }
        public int productId { get; set; }

        public bool read { get; set; }
    }
}
