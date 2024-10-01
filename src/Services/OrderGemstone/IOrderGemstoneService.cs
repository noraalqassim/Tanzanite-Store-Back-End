using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static src.DTO.OrderGemstoneDTO;

namespace src.Services.OrderGemstone
{
    public interface IOrderGemstoneService
    {
        Task<OrderGemstoneReadDto> CreateOnAsync(OrderGemstoneCreateDto createDto);
        Task<List<OrderGemstoneReadDto>> GetAllAsync();
        Task<OrderGemstoneReadDto> GetByIdAsync(Guid orderGemstoneId);
        Task<bool> DeleteOnAsync(Guid orderGemstoneId);
        Task<bool> UpdateOnAsync(Guid orderGemstoneId, OrderGemstoneUpdateDto updateDto);
    }
}