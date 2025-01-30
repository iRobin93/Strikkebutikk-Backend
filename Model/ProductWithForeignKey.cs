using System.ComponentModel.DataAnnotations.Schema;

namespace StrikkebutikkBackend.Model
{
    public class ProductWithForeignKey : ProductBase
    {
        [ForeignKey("patternId")]
        public Pattern pattern { get; set; }

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