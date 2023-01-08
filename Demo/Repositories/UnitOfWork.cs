using Demo.EF;
using Demo.Interfaces;

namespace Demo.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IProductRepository Products { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context=context;
            Products=new ProductRepository(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}