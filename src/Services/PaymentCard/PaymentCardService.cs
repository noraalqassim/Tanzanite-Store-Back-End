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

    }
}
