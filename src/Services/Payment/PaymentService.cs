using AutoMapper;
using src.Repository;
using static src.DTO.PaymentDTO;

namespace src.Services.Payment
{
    public class PaymentService : IPaymentService
    {
        protected readonly PaymentRepository _paymentRepo;
        protected readonly IMapper _mapper;

        public PaymentService(PaymentRepository paymentRepo, IMapper mapper)
        {
            _paymentRepo = paymentRepo;
            _mapper = mapper;
        }

        public async Task<PaymentReadDto> CreateOneAsync(PaymentCreateDto createDto)
        {
            var payment = _mapper.Map<PaymentCreateDto, src.Entity.Payment>(createDto);
            var paymentCreated = await _paymentRepo.CreateOneAsync(payment);
            return _mapper.Map<src.Entity.Payment, PaymentReadDto>(paymentCreated);
        }
    }
}
