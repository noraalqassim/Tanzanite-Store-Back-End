using src.Entity;
using Microsoft.AspNetCore.Mvc;

namespace src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]

    public class PaymentsController : ControllerBase
    {
        // Payment Entity
        private static List<Payment> payments = new List<Payment>
        {
            new Payment {PaymentId = 1, PaymentDate = new DateTime(2023, 1, 1), Amount = 100.00f, PaymentOption = "Card"},
            new Payment {PaymentId = 2, PaymentDate = new DateTime(2023, 2, 1), Amount = 250.25f, PaymentOption = "Cash"},
            new Payment {PaymentId = 3, PaymentDate = new DateTime(2023, 3, 1), Amount = 375.50f, PaymentOption = "Card"},
        };

        // endpoint: http://localhost:5125/api/v1/payments

        [HttpGet]
        public ActionResult GetPayments()
        {
            return Ok(payments);
        }

        [HttpGet("{id}")]
        public ActionResult GetPaymentById(int id)
        {
            Payment? foundPayment = payments.FirstOrDefault(p => p.PaymentId == id);
        
            if (foundPayment == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(foundPayment);
            }
            return Ok(payments);
        }

        [HttpPost]
        public ActionResult CreatePayment(Payment newPayment)
        {
            payments.Add(newPayment);
            return CreatedAtAction(nameof(GetPayments), new { id = newPayment.PaymentId }, newPayment); 
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePayment(int id, Payment paymentInfo)
        {
            var updatedPayment = payments.FirstOrDefault(p => p.PaymentId == id);

            if (updatedPayment == null)
            {
                return NotFound();
            }

            updatedPayment.PaymentId = paymentInfo.PaymentId;
            updatedPayment.PaymentDate = paymentInfo.PaymentDate;
            updatedPayment.Amount = paymentInfo.Amount;
            updatedPayment.PaymentOption = paymentInfo.PaymentOption;

            return Ok(updatedPayment);
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePayment(int id)
        {
            var foundAddress = payments.FirstOrDefault(p => p.PaymentId == id);

            if (foundAddress == null)
            {
                return NotFound();
            }

            payments.Remove(foundAddress);

            return Ok();
        }
    }
}