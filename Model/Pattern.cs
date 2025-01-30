using System.ComponentModel.DataAnnotations.Schema;

namespace StrikkebutikkBackend.Model
{
    public class Pattern
    {
        
        public int id {  get; set; }
        public string name { get; set; }
        public string img {  get; set; }
    }
}
