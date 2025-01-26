namespace StrikkebutikkBackend.Model
{
    public class Product
    {
        public int id { get; set; }
        public string productImg { get; set; }
        public string productAlbumJSON { get; set; }
        public string productName { get; set; }
        public string sizesJSON { get; set; }
        public string category { get; set; }
        public int patternId { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public int assortmentId { get; set; }
        public string productInfo { get; set; }
    }
}


/*
 *  id: 0,
        productImg: "source/img/seven-sister-genser.png",
        productAlbum: [
          "source/img/seven-sisters1.png",
          "source/img/seven-sisters2.png",
          "source/img/seven-sisters3.png",
        ],
        productName: "Seven Sisters - genser",
        sizes: ["s", "m", "l"],
        category: "genser",
        patternId: 0,
        quantity: 2,
        price: 799,
        assortmentId: 0,
        productInfo:
          "Genseren strikkes sømløst ovenfra og ned og har et grafisk rutemønstersom minner om det ikoniskerutemønsteret som finnes på setene på t-banen i London. Det fremre og bakre bærestykket, samt raglanermene, strikkes samtidig i ett stykke for å oppnå nøyaktig samme mål.",
      },
*/