using AutoMapper;
using MyItemShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemShop
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BaseClass, BaseDTO>()
                .Include<Item, ItemDTO>()
                .Include<User, UserDTO>()
                .Include<Category, CategoryDTO>()
                .Include<Order, OrderDTO>()
                .Include<Cart, CartDTO>();
            CreateMap<BaseDTO, BaseClass>()
                .Include<ItemDTO, Item>()
                .Include<UserDTO, User>()
                .Include<CategoryDTO, Category>()
                .Include<OrderDTO, Order>()
                .Include<CartDTO, Cart>(); 
        }
    }
}
