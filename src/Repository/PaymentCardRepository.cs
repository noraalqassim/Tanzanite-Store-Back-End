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

        public async Task<PaymentCard> CreateOnAsync(PaymentCard newPaymentCard)
        {
            await _paymentCard.AddAsync(newPaymentCard);
            await _databaseContext.SaveChangesAsync();
            return newPaymentCard;
        }

        public async Task<PaymentCard?> GetByIdAsync(Guid id)
        {
            return await _paymentCard.FindAsync(id);
        }

        
        public async Task<bool> DeleteOneAsync(PaymentCard paymentCard){
            _paymentCard.Remove(paymentCard);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateOnAsync(PaymentCard updatePaymentCard)
        {
            _paymentCard.Update(updatePaymentCard);
            await _databaseContext.SaveChangesAsync();
            return true;
        }
    }
}