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

    }
}