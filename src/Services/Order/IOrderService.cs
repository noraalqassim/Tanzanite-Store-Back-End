using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static src.DTO.OrderDTO;

namespace src.Services.Order
{
    public interface IOrderService
    {
        Task<OrderReadDto> CreateOnAsync(Guid UserId, OrderCreateDto createDto, Guid addressId);
        Task<List<OrderReadDto>> GetAllAsync();
        Task<List<OrderReadDto>> GetByUserIdAsync(Guid userId);
        Task<bool> DeleteOneAsync(Guid orderId);
        Task<bool> UpdateOnAsync(Guid orderId, OrderUpdateDto updateDto);
        
    }
}
