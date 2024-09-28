using AutoMapper;
using src.Repository;
using static src.DTO.PaymentCardDTO;

namespace src.Services.PaymentCard
{
    public class PaymentCardService : IPaymentCardService
    {
        protected readonly PaymentCardRepository _paymentCardRepo;
        protected readonly IMapper _mapper;

        public PaymentService(PaymentCardRepository paymentCardRepo, IMapper mapper)
        {
            _paymentCardRepo = paymentCardRepo;
            _mapper = mapper;
        }

        public async Task<PaymentCardReadDto> CreateOneAsync(PaymentCardCreateDto createDto)
        {
            var paymentCard = _mapper.Map<PaymentCardCreateDto, Entity.Payment>(createDto);
            var paymentCardCreated = await _paymentCardRepo.CreateOneAsync(paymentCard);
            return _mapper.Map<Entity.Payment, PaymentCardReadDto>(paymentCardCreated);
        }

    }
}
