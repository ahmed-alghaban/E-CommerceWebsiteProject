using AutoMapper;
using E_CommerceWebsiteProject.MVC.Dtos.Users;
using ECommerceProject.src.Models;

namespace E_CommerceWebsiteProject.MVC.Utilities
{
    public class MappingProfiler : Profile
    {
        public MappingProfiler()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<User, UserCreateDto>();
            CreateMap<UserUpdateDto, User>().ForAllMembers(opts => opts.Condition((src, dest, sMember) => sMember != null));
            CreateMap<User, UserUpdateDto>();

        }
    }
}