using AutoMapper;
using Demo.Models;

namespace Demo.Services
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Product,ProductViewModel>().ReverseMap();
            CreateMap<User,UserViewModel>().ReverseMap();
        }
    }
}