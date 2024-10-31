using AutoMapper;
using E_CommerceWebsiteProject.MVC.Dtos.Categories;
using E_CommerceWebsiteProject.MVC.Dtos.Roles;
using E_CommerceWebsiteProject.MVC.Dtos.Users;
using E_CommerceWebsiteProject.src.Models;
using E_CommerceWebsiteProject.src.MVC.Dtos.Authorization;
using E_CommerceWebsiteProject.src.MVC.Dtos.Images;
using E_CommerceWebsiteProject.src.MVC.Dtos.Inventories;
using E_CommerceWebsiteProject.src.MVC.Dtos.OrderDetails;
using E_CommerceWebsiteProject.src.MVC.Dtos.Orders;
using E_CommerceWebsiteProject.src.MVC.Dtos.Products;
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
            CreateMap<UserRegisterDto, User>();
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

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>()
                .ForMember(dest => dest.Price, act => act.Condition(src => src.Price > 0))
                .ForMember(dest => dest.Quantity, act => act.Condition(src => src.Quantity >= 0))
                .ForMember(dest => dest.ProductDescription, act => act.Condition(src => !string.IsNullOrEmpty(src.ProductDescription)))
                .ForMember(dest => dest.CategoryID, act => act.Condition(src => src.CategoryID != Guid.Empty))
                .ForMember(dest => dest.ProductName, act => act.Condition(src => !string.IsNullOrEmpty(src.ProductName)));

            CreateMap<Image, ImageDto>();
            CreateMap<ImageDto, Image>();
            CreateMap<ImageCreateDto, Image>();
            CreateMap<ImageUpdateDto, Image>()
                .ForAllMembers(opts => opts.Condition((src, dest, sMember) => sMember != null));

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
            CreateMap<OrderCreateDto, Order>();
            CreateMap<OrderUpdateDto, Order>()
            .ForAllMembers(opts => opts.Condition((src, dest, sMember) => sMember != null));

            CreateMap<OrderDetail, OrderDetailsDto>();
            CreateMap<OrderDetailsDto, OrderDetail>();
            CreateMap<OrderDetailsCreateDto, OrderDetail>();
        }
    }
}