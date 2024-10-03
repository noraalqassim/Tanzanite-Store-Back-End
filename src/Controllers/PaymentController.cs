using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.Services.Payment;
using static src.DTO.PaymentDTO;

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

    [ApiController]
    [Route("api/v1/[controller]")]
    public class PaymentController : ControllerBase
    {
        protected readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService service)
        {
            _paymentService = service;
        }

        [HttpPost]
        [Authorize] // --> For users
        public async Task<ActionResult<PaymentReadDto>> CreateOne(
            [FromBody] PaymentCreateDto createDto
        )
        {
            // exact user information by token
            var authenticateClaims = HttpContext.User;
            // get user id by claims
            var UserId = authenticateClaims
                .FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!
                .Value;
            // string => Guid
            var userGuid = new Guid(UserId);

            return await _paymentService.CreateOneAsync(userGuid, createDto);
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
