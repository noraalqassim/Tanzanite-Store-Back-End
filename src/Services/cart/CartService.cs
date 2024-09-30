using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using src.Entity;
using src.Repository;
using static src.DTO.CartDTO;

namespace src.Services.cart
{
    /// <summary>
    /// Services Contain the business logic of your application and interact with entities, repositories, and other services.
    //  Services use DTOs to transfer data between different layers of the application, such as between the controller and the repository.
    /// </summary>
    public class CartService : ICartService // CartService implements from ICartService
    {

        // fields
        protected readonly CartRepository _cartRepo;
        protected readonly IMapper _mapper;

        // Constructor for DI (Dependency Injection)
        public CartService(CartRepository cartRepo, IMapper mapper)
        {
            _cartRepo = cartRepo;
            _mapper = mapper;
        }

        // Create new Cart Asynchronously
        public async Task<CartReadDTO> CreateOneAsync(CartCreateDTO createDto)
        {
            var cart = _mapper.Map<CartCreateDTO, Cart>(createDto);

            var cartCreated = await _cartRepo.CreateOneAsync(cart);

            return _mapper.Map<Cart, CartReadDTO>(cartCreated);

        }

        // Get all carts Asynchronously
        public async Task<List<CartReadDTO>> GetAllAsync()
        {
            var cartList = await _cartRepo.GetAllAsync();
            return _mapper.Map<List<Cart>, List<CartReadDTO>>(cartList);
        }

        // Get cart by Id Asynchronously
        public async Task<CartReadDTO> GetByIdAsync(Guid id)
        {
            var foundCart = await _cartRepo.GetByIdAsync(id);
            // TO DO: handle error
            // throw
            return _mapper.Map<Cart, CartReadDTO>(foundCart);

        }

        // Delete cart by Id Asynchronously
        // public async Task<bool> DeleteOneAsync(Guid id)
        // {

        //     // find the cart id
        //     var foundCart = await _cartRepo.GetByIdAsync(id);
        //     bool isDeleted = await _cartRepo.DeleteOneAsync(foundCart);

        //     if (isDeleted)
        //     {
        //         return true;
        //     }
        //     return false;
        // }

        // Update cart Asynchronously
        public async Task<bool> UpdateOneAsync(Guid id, CartUpdateDTO updateDto)
        {
            var foundCart = await _cartRepo.GetByIdAsync(id);

            if (foundCart == null)
            {
                return false;
            }

            _mapper.Map(updateDto, foundCart);
            return await _cartRepo.UpdateOneAsync(foundCart);

        }

    } // end class 
} // end namespace