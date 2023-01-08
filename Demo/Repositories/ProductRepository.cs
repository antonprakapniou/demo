using Demo.EF;
using Demo.Interfaces;
using Demo.Models;

namespace Demo.Repositories
{
    public class ProductRepository: GenericRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}