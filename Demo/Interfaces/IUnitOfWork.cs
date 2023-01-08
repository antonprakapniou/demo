namespace Demo.Interfaces
{
    public interface IUnitOfWork
    {
        public IProductRepository Products { get; }

        public Task SaveChangesAsync();
    }
}