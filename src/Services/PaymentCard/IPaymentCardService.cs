using static src.DTO.PaymentCardDTO;

namespace src.Services.PaymentCard
{
    public interface IPaymentCardService
    {
        Task<PaymentCardReadDto> CreateOneAsync(PaymentCardCreateDto createDto);

        Task<List<PaymentCardReadDto>> GetAllAsync();

        Task<PaymentCardReadDto> GetByIdAsync(Guid id);

        Task<bool> DeleteOneAsync(Guid id);

        Task<bool> UpdateOneAsync(Guid id, PaymentCardUpdateDto updateDto);
    }
}
