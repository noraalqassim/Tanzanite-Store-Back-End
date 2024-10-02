using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static src.DTO.OrderDTO;

namespace src.Services.Order
{
    public interface IOrderService
    {
        Task<OrderReadDto> CreateOnAsync(Guid UserId, OrderCreateDto createDto);//create new order
        // Task<List<OrderReadDto>> GetAllAsync(); //get all
        // Task<OrderReadDto> GetByIdAsync(Guid OrderId);//get by id
        // Task<bool> DeleteOneAsync(Guid OrderId);
        // Task<bool> UpdateOnAsync(Guid OrderId, OrderUpdateDto updateDto);
    }
}