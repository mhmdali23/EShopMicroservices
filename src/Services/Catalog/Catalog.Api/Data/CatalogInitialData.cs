

namespace Catalog.Api.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            var session = store.LightweightSession();

            if (await session.Query<Product>().AnyAsync())
                return;

            session.Store<Product>(GetPreconfiguredProducts());
            await session.SaveChangesAsync(cancellation);
        }


        private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>
        {
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 1",
                Category = new List<string> { "Category A", "Category B" },
                Description = "Description of Product 1",
                ImageFile = "product1.png",
                Price = 100.50m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 2",
                Category = new List<string> { "Category A" },
                Description = "Description of Product 2",
                ImageFile = "product2.png",
                Price = 150.75m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 3",
                Category = new List<string> { "Category B", "Category C" },
                Description = "Description of Product 3",
                ImageFile = "product3.png",
                Price = 200.00m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 4",
                Category = new List<string> { "Category D" },
                Description = "Description of Product 4",
                ImageFile = "product4.png",
                Price = 99.99m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 5",
                Category = new List<string> { "Category E" },
                Description = "Description of Product 5",
                ImageFile = "product5.png",
                Price = 50.00m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 6",
                Category = new List<string> { "Category A", "Category F" },
                Description = "Description of Product 6",
                ImageFile = "product6.png",
                Price = 300.45m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 7",
                Category = new List<string> { "Category B" },
                Description = "Description of Product 7",
                ImageFile = "product7.png",
                Price = 120.00m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 8",
                Category = new List<string> { "Category C", "Category D" },
                Description = "Description of Product 8",
                ImageFile = "product8.png",
                Price = 75.20m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 9",
                Category = new List<string> { "Category A" },
                Description = "Description of Product 9",
                ImageFile = "product9.png",
                Price = 180.99m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 10",
                Category = new List<string> { "Category F" },
                Description = "Description of Product 10",
                ImageFile = "product10.png",
                Price = 250.00m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 11",
                Category = new List<string> { "Category G", "Category H" },
                Description = "Description of Product 11",
                ImageFile = "product11.png",
                Price = 199.99m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 12",
                Category = new List<string> { "Category A" },
                Description = "Description of Product 12",
                ImageFile = "product12.png",
                Price = 90.75m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 13",
                Category = new List<string> { "Category C", "Category D" },
                Description = "Description of Product 13",
                ImageFile = "product13.png",
                Price = 160.50m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 14",
                Category = new List<string> { "Category E", "Category F" },
                Description = "Description of Product 14",
                ImageFile = "product14.png",
                Price = 210.00m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 15",
                Category = new List<string> { "Category B" },
                Description = "Description of Product 15",
                ImageFile = "product15.png",
                Price = 99.99m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 16",
                Category = new List<string> { "Category D" },
                Description = "Description of Product 16",
                ImageFile = "product16.png",
                Price = 140.00m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 17",
                Category = new List<string> { "Category F", "Category G" },
                Description = "Description of Product 17",
                ImageFile = "product17.png",
                Price = 175.25m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 18",
                Category = new List<string> { "Category A", "Category H" },
                Description = "Description of Product 18",
                ImageFile = "product18.png",
                Price = 230.00m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 19",
                Category = new List<string> { "Category B", "Category G" },
                Description = "Description of Product 19",
                ImageFile = "product19.png",
                Price = 210.99m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 20",
                Category = new List<string> { "Category E" },
                Description = "Description of Product 20",
                ImageFile = "product20.png",
                Price = 110.00m
            }
        };



    }
}
