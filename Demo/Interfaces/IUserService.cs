using Demo.Models;

namespace Demo.Interfaces
{
    public interface IUserService
    {
        public Task<IEnumerable<UserViewModel>> GetUsersAsync();
        public Task<UserViewModel> GetUserByIdAsync(Guid id);
        public Task<UserViewModel> CreateUserAsync(UserViewModel userViewModel);
        public Task<UserViewModel> UpdateUserAsync(UserViewModel userViewModel);
        public Task<UserViewModel> DeleteUserAsync(UserViewModel userViewModel);
    }
}