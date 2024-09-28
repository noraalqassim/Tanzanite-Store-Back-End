using static src.DTO.PaymentDTO;

namespace src.Services.Payment
{
    public interface IPaymentService
    {
        Task<PaymentReadDto> CreateOnAsync(PaymentCreateDto createDto);

        Task<List<PaymentReadDto>> GetAllAsync();

        Task<PaymentReadDto> GetByIdAsync(Guid id);

        Task<bool> DeleteOnAsync(Guid id);

        Task<bool> UpdateOnAsync(Guid id, PaymentUpdateDto updateDto);
    }
}
