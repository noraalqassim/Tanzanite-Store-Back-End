using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.Services.Payment;
using static src.DTO.PaymentDTO;

namespace src.Controllers
{
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
        [Authorize]
        public async Task<ActionResult<PaymentReadDto>> CreateOne(
            [FromBody] PaymentCreateDto createDto
        )
        {
            var authenticateClaims = HttpContext.User;
            var UserId = authenticateClaims
                .FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!
                .Value;
            var userGuid = new Guid(UserId);

            return await _paymentService.CreateOneAsync(userGuid, createDto);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<PaymentReadDto>> GetAllAsync()
        {
            var paymentList = await _paymentService.GetAllAsync();
            return Ok(paymentList);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<PaymentReadDto>> GetByIdAsync(Guid id)
        {
            var foundPayment = await _paymentService.GetByIdAsync(id);
            return Ok(foundPayment);
        }
    }
}
