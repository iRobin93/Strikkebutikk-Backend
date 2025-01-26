using StrikkebutikkBackend.Model;
using Newtonsoft.Json;
namespace StrikkebutikkBackend
{
    internal class StartupService
    {

        public StartupService(AppDBContext appDBContext) 
        {
            Product newProduct = new Product
            {
                id = 0,
                productImg = "source/img/seven-sister-genser.png",
                // Serialize the productAlbum and sizes to JSON strings
                productAlbumJSON = JsonConvert.SerializeObject(new string[] {
                "source/img/seven-sisters1.png",
                "source/img/seven-sisters2.png",
                "source/img/seven-sisters3.png"
            }),
                productName = "Seven Sisters - genser",
                sizesJSON = JsonConvert.SerializeObject(new string[] { "s", "m", "l" }),
                category = "genser",
                patternId = 0,
                quantity = 2,
                price = 799,
                assortmentId = 0,
                productInfo = "Genseren strikkes sømløst ovenfra og ned og har et grafisk rutemønstersom minner om det ikoniskerutemønsteret som finnes på setene på t-banen i London. Det fremre og bakre bærestykket, samt raglanermene, strikkes samtidig i ett stykke for å oppnå nøyaktig samme mål."
            };



            appDBContext.Products.Add(newProduct);
            appDBContext.SaveChanges();
        }
    }
}
