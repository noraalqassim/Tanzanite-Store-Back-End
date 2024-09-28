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
    }
}
