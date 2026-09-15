using UTB.Eshop.Domain.Entities;

namespace UTB.Eshop.Infrastructure.Database.Seeding
{
    internal class ProductInit
    {
        public IList<Domain.Entities.Product> GetProductsFood3()
        {
            IList<Domain.Entities.Product> products = new List<Domain.Entities.Product>();

            products.Add(new Domain.Entities.Product
            {
                Id = 1,
                Name = "Rohlík",
                Description = "nejlepší rohlík na světě",
                Price = 2,
                ImageSrc = "/img/products/produkty-01.jpg"
            });
            products.Add(new Domain.Entities.Product
            {
                Id = 2,
                Name = "Chleba",
                Description = "nejlepší chleba v galaxii",
                Price = 50,
                ImageSrc = "/img/products/produkty-02.jpg"
            });
            products.Add(new Domain.Entities.Product
            {
                Id = 3,
                Name = "Bageta",
                Description = "nejlepší bageta ve vesmíru",
                Price = 40,
                ImageSrc = "/img/products/produkty-05.jpg"
            });

            return products;
        }
    }
}
