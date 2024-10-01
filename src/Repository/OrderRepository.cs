using Microsoft.EntityFrameworkCore;
using src.Database;
using src.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Repository
{
    public class OrderRepository
    {
        protected DbSet<Order> _order;
        private readonly DatabaseContext _databaseContext;

        public OrderRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _order = databaseContext.Set<Order>();
        }

        //get all Order
        public async Task<List<Order>> GetAllAsync()
        {
            return await _order.ToListAsync();
        }
        //get order by id
        public async Task<Order> GetByIdAsync(Guid Orderid)
        {
            return await _order.FindAsync(Orderid);
        }

        //Create new order 
        public async Task<Order> CreateOnAsync(Order newOrder)
        {
            await _order.AddAsync(newOrder);
            await _databaseContext.SaveChangesAsync();
            return newOrder;
        }
        //update 
        public async Task<bool> UpdateOnAsync(Order updateOrder)
        {
            _order.Update(updateOrder);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        //Delete 
        public async Task<bool> DeleteOnAsync(Order deleteOrder)
        {
            _order.Remove(deleteOrder);
            await _databaseContext.SaveChangesAsync();
            return true;
        }
    }
}