using src.Entity;
using Microsoft.AspNetCore.Mvc;

namespace src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]

    public class PaymentsController : ControllerBase
    {
        // Payment Entity
        List<Payment> payments = new List<Payment>
        {
            new Payment {PaymentId = 1, PaymentDate = new DateTime(2023, 1, 1), Amount = 100.00f, PaymentOption = "Card"},
            new Payment {PaymentId = 2, PaymentDate = new DateTime(2023, 2, 1), Amount = 250.25f, PaymentOption = "Cash"},
            new Payment {PaymentId = 3, PaymentDate = new DateTime(2023, 3, 1), Amount = 375.50f, PaymentOption = "Card"},
        };
    }
}