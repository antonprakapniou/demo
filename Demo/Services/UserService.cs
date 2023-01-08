using AutoMapper;
using Demo.Interfaces;
using Demo.Models;

namespace Demo.Services
{
    public class UserService:IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork=unitOfWork;
            _mapper=mapper;
        }

        public async Task<IEnumerable<UserViewModel>> GetUsersAsync()
        {
            var userList = await _unitOfWork.Users.GetAllAsync();
            var userViewModelList = _mapper.Map<IEnumerable<UserViewModel>>(userList);
            return userViewModelList;
        }

        public async Task<UserViewModel> GetUserByIdAsync(Guid id)
        {
            var users = await _unitOfWork.Users.GetByAsync(p => p.UserId==id);
            var user = users.FirstOrDefault();
            var userViewModel = _mapper.Map<UserViewModel>(user);
            return userViewModel;
        }

        public async Task<UserViewModel> CreateUserAsync(UserViewModel userViewModel)
        {
            var user = _mapper.Map<User>(userViewModel);
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
            return userViewModel;
        }

        public async Task<UserViewModel> UpdateUserAsync(UserViewModel userViewModel)
        {
            var user = _mapper.Map<User>(userViewModel);
            _unitOfWork.Users.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return userViewModel;
        }

        public async Task<UserViewModel> DeleteUserAsync(UserViewModel userViewModel)
        {
            var user = _mapper.Map<User>(userViewModel);
            _unitOfWork.Users.Delete(user);
            await _unitOfWork.SaveChangesAsync();
            return userViewModel;
        }
    }
}