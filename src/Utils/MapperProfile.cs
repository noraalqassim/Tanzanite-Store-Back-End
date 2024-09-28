using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using src.Entity;
using static src.DTO.AddressDTO;
using static src.DTO.CartDTO;
using static src.DTO.CategoryDTO;
using static src.DTO.ReviewDTO;
using static src.DTO.UserDTO;

// Utils
// Role: store common logic for the whole application

namespace src.Utils
{
    /// <summary>
    /// MapperProfile class is typically used to:
    /// mappings between entity classes and DTOs (Data Transfer Objects)
    /// </summary>
    /// 
    public class MapperProfile : Profile // MapperProfile inherits from Profile
    {

        // constructor
        public MapperProfile()
        {
            // category

            CreateMap<Category, CategoryReadDto>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>().
            ForAllMembers(opts => opts.Condition((src, dest, srcProperty) => srcProperty != null));

            // review

            CreateMap<Review, ReviewReadDTO>();
            CreateMap<ReviewCreateDTO, Review>();
            CreateMap<ReviewUpdateDTO, Review>().
            ForAllMembers(opts => opts.Condition((src, dest, srcProperty) => srcProperty != null));

            // cart

            CreateMap<Cart, CartReadDTO>();
            CreateMap<CartCreateDTO, Cart>();
            CreateMap<CartUpdateDTO, Cart>().
            ForAllMembers(opts => opts.Condition((src, dest, srcProperty) => srcProperty != null));

            // Mapping configurations between entity classes and DTOs
            CreateMap<Users, UserReadDto>();
            CreateMap<UserCreateDto, Users>();

            // Mapping from UserUpdateDto to Users with a condition to map properties only if they are not null
            CreateMap<UserUpdateDto, Users>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Additional mappings
            CreateMap<UserLoginDto, Users>();
            CreateMap<PasswordUpdateDto, Users>();

            CreateMap<Address, AddressReadDto>();
            CreateMap<AddressCreateDto, Address>();

            // Mapping from AddressUpdateDto to Address with a condition to map properties only if they are not null
            CreateMap<AddressUpdateDto, Address>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        }

    } // end class
} // end namespace
