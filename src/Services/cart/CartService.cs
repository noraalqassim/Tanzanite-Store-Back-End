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
    public class CartService : ICartService
    {
        protected readonly CartRepository _cartRepo;
        protected readonly IMapper _mapper;

        public CartService(CartRepository cartRepo, IMapper mapper)
        {
            _cartRepo = cartRepo;
            _mapper = mapper;
        }

        public async Task<CartReadDTO> CreateOneAsync(Guid id, CartCreateDTO createDto)
        {
            var cart = _mapper.Map<CartCreateDTO, Entity.Cart>(createDto);
            cart.UserId = id;
            await _cartRepo.CreateOneAsync(cart);

            return _mapper.Map<Cart, CartReadDTO>(cart);
        }

        public async Task<List<CartReadDTO>> GetAllAsync()
        {
            var cartList = await _cartRepo.GetAllAsync();
            return _mapper.Map<List<Cart>, List<CartReadDTO>>(cartList);
        }

        public async Task<CartReadDTO> GetByIdAsync(Guid id)
        {
            var foundCartList = await _cartRepo.GetByIdUserAsync(id);

            if (foundCartList != null && foundCartList.Count > 0)
            {
                var foundCart = foundCartList.First();
                var cartDto = _mapper.Map<Cart, CartReadDTO>(foundCart);

                return cartDto;
            }
            else
            {
                return null;
            }
        }


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
    } 
} 
