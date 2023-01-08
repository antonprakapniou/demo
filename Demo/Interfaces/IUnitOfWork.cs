namespace Demo.Interfaces
{
    public interface IUnitOfWork
    {
        public IProductRepository Products { get; }
        public IUserRepository Users { get; }

        public Task SaveChangesAsync();
    }
}