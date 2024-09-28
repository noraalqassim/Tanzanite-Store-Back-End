using Microsoft.AspNetCore.Mvc;
using static src.DTO.PaymentDTO;
using src.Services.PaymentCard;

namespace src.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController] 
    public class PaymentCardController : ControllerBase
    {
        protected readonly IPaymentCardService _paymentCardService;

        public PaymentCardController(IPaymentCardService service)
        {
            _paymentCardService = service;
        }
        
    }
}
