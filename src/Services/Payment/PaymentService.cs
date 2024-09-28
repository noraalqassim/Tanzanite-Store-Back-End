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
            var payment = _mapper.Map<PaymentCreateDto, Entity.Payment>(createDto);
            var paymentCreated = await _paymentRepo.CreateOneAsync(payment);
            return _mapper.Map<Entity.Payment, PaymentReadDto>(paymentCreated);
        }

        public async Task<List<PaymentReadDto>> GetAllAsync(){
            var paymentList = await _paymentRepo.GetAllAsync();
            return _mapper.Map<List<Entity.Payment>, List<PaymentReadDto>>(paymentList);
        }

        public async Task<PaymentReadDto> GetByIdAsync(Guid id){
            var foundPayment = await _paymentRepo.GetByIdAsync(id);
            // TODO: Add error handling
            return _mapper.Map<Entity.Payment, PaymentReadDto>(foundPayment);
        }

        public async Task<bool> DeleteOneAsync(Guid id){
            var foundPayment = await _paymentRepo.GetByIdAsync(id);
            bool isDeleted = await _paymentRepo.DeleteOneAsync(foundPayment);
            if (isDeleted)
            {
                return true;
            } 
            return false;
        }
    }
}
