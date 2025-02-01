using System.ComponentModel.DataAnnotations.Schema;

namespace StrikkebutikkBackend.Model
{
    public class ProductBase
    {
        public int id { get; set; }
        public string productImg { get; set; }
        public string[] productAlbum { get; set; }
        public string productName { get; set; }
        public string[] sizes { get; set; }
        public int[] colorAltIds { get; set; }
        public string category { get; set; }

        public int patternId { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public int assortmentId { get; set; }
        public string productInfo { get; set; }
        
    }
}
