using AutoMapper;
using Demo.Interfaces;
using Demo.Models;

namespace Demo.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork=unitOfWork;
            _mapper=mapper;
        }

        public async Task<IEnumerable<ProductViewModel>> GetProductsAsync()
        {
            var productList=await _unitOfWork.Products.GetAllAsync();
            var productViewModelList= _mapper.Map<IEnumerable<ProductViewModel>>(productList);
            return productViewModelList;
        }

        public async Task<ProductViewModel> GetProductByIdAsync(Guid id)
        {
            var products = await _unitOfWork.Products.GetByAsync(p=>p.ProductId==id);
            var product = products.FirstOrDefault();
            var productViewModel = _mapper.Map<ProductViewModel>(product);
            return productViewModel;
        }

        public async Task<ProductViewModel> CreateProductAsync(ProductViewModel productViewModel)
        {
            var product = _mapper.Map<Product>(productViewModel);
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
            return productViewModel;
        }

        public async Task<ProductViewModel> UpdateProductAsync(ProductViewModel productViewModel)
        {
            var product = _mapper.Map<Product>(productViewModel);
            _unitOfWork.Products.Update(product);
            await _unitOfWork.SaveChangesAsync();
            return productViewModel;
        }

        public async Task<ProductViewModel> DeleteProductAsync(ProductViewModel productViewModel)
        {
            var product = _mapper.Map<Product>(productViewModel);
            _unitOfWork.Products.Delete(product);
            await _unitOfWork.SaveChangesAsync();
            return productViewModel;
        }
    }
}