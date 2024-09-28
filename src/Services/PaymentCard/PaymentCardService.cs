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
            var paymentCard = _mapper.Map<PaymentCardCreateDto, Entity.PaymentCard>(createDto);
            var paymentCardCreated = await _paymentCardRepo.CreateOneAsync(paymentCard);
            return _mapper.Map<Entity.PaymentCard, PaymentCardReadDto>(paymentCardCreated);
        }


        public async Task<List<PaymentCardReadDto>> GetAllAsync()
        {
            var paymentCardList = await _paymentCardRepo.GetAllAsync();
            return _mapper.Map<List<Entity.PaymentCard>, List<PaymentCardReadDto>>(paymentCardList);
        }

        public async Task<PaymentCardReadDto> GetByIdAsync(Guid id)
        {
            var foundPaymentCard = await _paymentCardRepo.GetByIdAsync(id);
            // TODO: Add error handling
            return _mapper.Map<Entity.PaymentCard, PaymentCardReadDto>(foundPaymentCard);
        }

    }
}
