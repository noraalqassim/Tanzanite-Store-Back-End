using Microsoft.AspNetCore.Mvc;
using static src.DTO.PaymentDTO;
using src.Services.Payment;

namespace src.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController] 
    public class PaymentController : ControllerBase
    {
        protected readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService service)
        {
            _paymentService = service;
        }
        
        [HttpPost]
        public async Task<ActionResult<PaymentCreateDto>> CreateOne(PaymentCreateDto createDto)
        {
            var paymentCreated = await _paymentService.CreateOneAsync(createDto);
            return Ok(paymentCreated);
        }

        [HttpGet]
        public async Task<ActionResult<PaymentReadDto>> GetAllAsync()
        {
            var paymentList = await _paymentService.GetAllAsync();
            return Ok(paymentList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentReadDto>> GetByIdAsync(Guid id)
        {
            var foundPayment = await _paymentService.GetByIdAsync(id);
            return Ok(foundPayment);
        }
    }
}
