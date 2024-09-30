using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static src.DTO.CartDTO;

namespace src.Services.cart
{
    public interface ICartService // interface
    {
        Task<CartReadDTO> CreateOneAsync(CartCreateDTO createDto);
        Task<List<CartReadDTO>> GetAllAsync();
        Task<CartReadDTO> GetByIdAsync(Guid id);
        // Task<bool> DeleteOneAsync(Guid id);
        Task<bool> UpdateOneAsync(Guid id, CartUpdateDTO updateDto);

    }
}