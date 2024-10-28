using AutoMapper;
using E_CommerceWebsiteProject.MVC.Dtos.Categories;
using E_CommerceWebsiteProject.MVC.Dtos.Roles;
using E_CommerceWebsiteProject.MVC.Dtos.Users;
using E_CommerceWebsiteProject.src.MVC.Dtos.Inventories;
using E_CommerceWebsiteProject.src.MVC.Dtos.Stores;
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
            CreateMap<UserUpdateDto, User>()
            .ForAllMembers(opts => opts.Condition((src, dest, sMember) => sMember != null));

            CreateMap<RoleDto, Role>();
            CreateMap<Role, RoleDto>();
            CreateMap<RoleCreateDto, Role>();
            CreateMap<RoleUpdateDto, Role>()
            .ForAllMembers(opts => opts.Condition((src, dest, sMember) => sMember != null));

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>()
            .ForAllMembers(opts => opts.Condition((src, dest, sMember) => sMember != null));

            CreateMap<Store, StoreDto>();
            CreateMap<StoreDto, Store>();
            CreateMap<StoreCreateDto, Store>();
            CreateMap<StoreUpdateDto, Store>()
            .ForAllMembers(opts => opts.Condition((src, dest, sMember) => sMember != null));

            CreateMap<Inventory, InventoryDto>();
            CreateMap<InventoryDto, Inventory>();
            CreateMap<InventoryCreateDto, Inventory>();
            CreateMap<InventoryUpdateDto, Inventory>()
            .ForAllMembers(opts => opts.Condition((src, dest, sMember) => sMember != null));
        }
    }
}