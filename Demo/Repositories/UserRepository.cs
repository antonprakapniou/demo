using Demo.EF;
using Demo.Interfaces;
using Demo.Models;

namespace Demo.Repositories
{
    public class UserRepository:GenericRepository<User>,IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}