namespace ProductWebApp.Producer
{
    public class ProductUtil : IProductUtil
    {
        private readonly SwaggerClient _productApiClient;

        public ProductUtil() => _productApiClient = new SwaggerClient("https://localhost:7111", new HttpClient());

        public async Task<Product> CreateProduct(Product product)
        {
            return await _productApiClient.CreateAsync(product);
        }

        public async Task DeleteProduct(int id)
        {
            await _productApiClient.DeleteAsync(id);
        }

        public async Task<Product> EditProduct(Product product)
        {
            return await _productApiClient.UpdateAsync(product);
        }

        public async Task<ICollection<Product>> GetProduct()
        {
            return await _productApiClient.GetProductsAsync();
        }

        public async Task<Product> GetProductById(int Id)
        {
            return await _productApiClient.GetProductByIdAsync(Id);
        }
    }
}
