namespace ProductAPI.Data
{
    public static class SeedData
    {
        public static void Seed(WebApplication app)
        {
            var scope = app.Services.CreateScope();
            ProductDbContext context = scope.ServiceProvider.GetRequiredService<ProductDbContext>();
            if (!context.Products.Any())
            {
                var products =
                    new List<Product>()
                    {
                        new Product()
                        {
                            Name = "Keyboard",
                            Description = "Gaming Keyboard with lights",
                            Price = 150,
                            ProductType = ProductType.PERIPHERALS
                        },
                        new Product()
                        {
                            Name = "Mouse",
                            Description = "Gaming Mouse",
                            Price = 40,
                            ProductType = ProductType.PERIPHERALS
                        },
                        new Product()
                        {
                            Name = "Monitor",
                            Description = "HD monitor",
                            Price = 400,
                            ProductType = ProductType.MONITOR
                        },
                        new Product()
                        {
                            Name = "Cabinet",
                            ProductType = ProductType.EXTERNAL,
                            Description = "Business Cabinet with lights",
                            Price = 60
                        }
                    };

                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }
    }
}
