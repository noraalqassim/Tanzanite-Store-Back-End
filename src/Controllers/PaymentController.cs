using Microsoft.AspNetCore.Mvc;
using static src.DTO.PaymentDTO;
using src.Services.Payment;
using Microsoft.AspNetCore.Authorization;

namespace src.Controllers
{
    /// <API>
    /// POST: /api/v1/Payment
    /// {
    ///     "paymentDate": "DateTime",
    ///     "amount": 0,
    ///     "paymentOption": "string",
    ///     "orderId": "Guid"
    /// }
    /// Returns the created payment information.
    ///
    /// GET: /api/v1/Payment
    /// Returns the list of all payments.
    ///
    /// GET: /api/v1/Payment/{id}
    /// Returns the payment details associated with the given id.
    /// </API>

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
        [Authorize] // --> For users
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
