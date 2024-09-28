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
    }
}