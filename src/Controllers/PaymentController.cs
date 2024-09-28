using Microsoft.AspNetCore.Mvc;

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
    }
}
