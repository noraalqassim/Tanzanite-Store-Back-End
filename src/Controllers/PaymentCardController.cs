using src.Entity;
using Microsoft.AspNetCore.Mvc;

namespace src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]

    public class PaymentCardController : ControllerBase
    {
        // PaymentCard Entity
        private static List<PaymentCard> cards = new List<PaymentCard>
        {
            new PaymentCard
            {
                Id = 1,
                ExpiryDate = new DateTime(2025, 12, 31),
                Balance = 150.00f,
                CardHolderName = "John Doe",
                CardType = "Visa",
                CardNumber = "1234567890123456",
                BillingAddress = "123 Main St, City, Country"
            },
            new PaymentCard
            {
                Id = 2,
                ExpiryDate = new DateTime(2024, 11, 30),
                Balance = 250.25f,
                CardHolderName = "Jane Smith",
                CardType = "MasterCard",
                CardNumber = "6543210987654321",
                BillingAddress = "456 Oak St, Another City, Country"
            },
            new PaymentCard
            {
                Id = 3,
                ExpiryDate = new DateTime(2026, 10, 29),
                Balance = 375.50f,
                CardHolderName = "Alice Johnson",
                CardType = "American Express",
                CardNumber = "9876543210123456",
                BillingAddress = "789 Pine St, Third City, Country"
            }
        };

        [HttpGet]
        public ActionResult GetCards()
        {
            return Ok(cards);
        }

        [HttpGet("{id}")]
        public ActionResult GetCardById(int id)
        {
            PaymentCard? foundCard = cards.FirstOrDefault(c => c.Id == id);

            if (foundCard == null)
            {
                return NotFound();
            }
            return Ok(foundCard);
        }

        [HttpPost]
        public ActionResult CreateCard(PaymentCard newPaymentCard)
        {
            cards.Add(newPaymentCard);
            return CreatedAtAction(nameof(GetCards), new { id = newPaymentCard.Id }, newPaymentCard);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCard(int id, PaymentCard paymentCardInfo)
        {
            var updatedPaymentCard = cards.FirstOrDefault(c => c.Id == id);

            if (updatedPaymentCard == null)
            {
                return NotFound();
            }

            updatedPaymentCard.Id = paymentCardInfo.Id;
            updatedPaymentCard.ExpiryDate = paymentCardInfo.ExpiryDate;
            updatedPaymentCard.Balance = paymentCardInfo.Balance;
            updatedPaymentCard.CardNumber = paymentCardInfo.CardNumber;
            updatedPaymentCard.CardHolderName = paymentCardInfo.CardHolderName;
            updatedPaymentCard.CardType = paymentCardInfo.CardType;
            updatedPaymentCard.BillingAddress = paymentCardInfo.BillingAddress;

            return Ok(updatedPaymentCard);
        }
    }
}