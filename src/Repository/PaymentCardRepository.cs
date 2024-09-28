using Microsoft.EntityFrameworkCore;
using src.Database;
using src.Entity;

namespace src.Repository
{
    public class PaymentCardRepository
    {
        protected DbSet<PaymentCard> _paymentCard;
        protected DatabaseContext _databaseContext;

        public PaymentCardRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _paymentCard = databaseContext.Set<PaymentCard>();
        }
    }
}