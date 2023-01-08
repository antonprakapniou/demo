using Demo.Models;

namespace Demo.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductViewModel>> GetProductsAsync();
        public Task<ProductViewModel> GetProductByIdAsync(Guid id);
        public Task<ProductViewModel> CreateProductAsync(ProductViewModel productViewModel);
        public Task<ProductViewModel> UpdateProductAsync(ProductViewModel productViewModel);
        public Task<ProductViewModel> DeleteProductAsync(ProductViewModel productViewModel);
    }
}