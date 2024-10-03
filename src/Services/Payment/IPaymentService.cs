using static src.DTO.PaymentDTO;

namespace src.Services.Payment
{
    public interface IPaymentService
    {
        Task<PaymentReadDto> CreateOneAsync(Guid userGuid, PaymentCreateDto createDto);

        Task<List<PaymentReadDto>> GetAllAsync();

        Task<PaymentReadDto> GetByIdAsync(Guid id);

        Task<bool> DeleteOneAsync(Guid id);

        Task<bool> UpdateOneAsync(Guid id, PaymentUpdateDto updateDto);
    }
}
