using Microsoft.EntityFrameworkCore;
using src.Database;
using src.Entity;

namespace src.Repository
{
    public class PaymentRepository
    {
        protected DbSet<Payment> _payment;
        protected DatabaseContext _databaseContext;

        public PaymentRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _payment = databaseContext.Set<Payment>();
        }

        public async Task<Payment> CreateOnAsync(Payment newPayment)
        {
            await _payment.AddAsync(newPayment);
            await _databaseContext.SaveChangesAsync();
            return newPayment;
        }
    }
}