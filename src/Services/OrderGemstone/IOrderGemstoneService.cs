using static src.DTO.OrderDTO;

namespace src.Services.OrderGemstone
{
    public interface IOrderGemstoneService
    {
        Task<OrderGemstoneReadDto> CreateOnAsync(DTO.OrderGemstoneDTO.OrderGemstoneCreateDto createDto);
        Task<List<OrderGemstoneReadDto>> GetAllAsync();
        Task<OrderGemstoneReadDto> GetByIdAsync(Guid orderGemstoneId);
        Task<bool> DeleteOnAsync(Guid orderGemstoneId);
        Task<bool> UpdateOnAsync(Guid orderGemstoneId, DTO.OrderGemstoneDTO.OrderGemstoneUpdateDto updateDto);
    }
}