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
            new Payment {Payment_id = 1, Payment_date = new DateTime(2023, 1, 1), Amount = 100.00f, Payment_option = "Card"},
            new Payment {Payment_id = 2, Payment_date = new DateTime(2023, 2, 1), Amount = 250.25f, Payment_option = "Cash"},
            new Payment {Payment_id = 3, Payment_date = new DateTime(2023, 3, 1), Amount = 375.50f, Payment_option = "Card"},
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
            Payment? foundPayment = payments.FirstOrDefault(p => p.Payment_id == id);
        
            if (foundPayment == null)
            {
                return NotFound();
            }
            return Ok(payments);
        }

        [HttpPost]
        public ActionResult CreatePayment(Payment newPayment)
        {
            payments.Add(newPayment);
            return CreatedAtAction(nameof(GetPayments), new { id = newPayment.Payment_id }, newPayment); 
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePayment(int id, Payment paymentInfo)
        {
            var updatedPayment = payments.FirstOrDefault(p => p.Payment_id == id);

            if (updatedPayment == null)
            {
                return NotFound();
            }

            updatedPayment.Payment_id = paymentInfo.Payment_id;
            updatedPayment.Payment_date = paymentInfo.Payment_date;
            updatedPayment.Amount = paymentInfo.Amount;
            updatedPayment.Payment_option = paymentInfo.Payment_option;

            return Ok(updatedPayment);
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePayment(int id)
        {
            var foundPayment = payments.FirstOrDefault(p => p.Payment_id == id);

            if (foundPayment == null)
            {
                return NotFound();
            }

            payments.Remove(foundPayment);

            return Ok();
        }
    }
}