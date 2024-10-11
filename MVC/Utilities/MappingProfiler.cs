using AutoMapper;
using E_CommerceWebsiteProject.MVC.Dtos;
using ECommerceProject.src.Models;

namespace E_CommerceWebsiteProject.MVC.Utilities
{
    public class MappingProfiler : Profile
    {
        public MappingProfiler(){
            CreateMap<UserDto,User>();
            CreateMap<User,UserDto>();
        }
    }
}