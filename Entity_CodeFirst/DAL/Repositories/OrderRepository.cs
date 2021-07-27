using Entity_CodeFirst.DAL.Interfaces;
using Entity_CodeFirst.Entities;
using Entity_CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_CodeFirst.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _dbContext;

        public OrderRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<OrderModel>> GetOrdersAsync()
        {
            var query = from o in _dbContext.Orders
                        select new OrderModel
                        {
                            Id = o.Id,
                            CustomerId = o.CustomerId,
                            TrackingNumber = o.TrackingNumber
                        };

            var orders = await query.ToListAsync();

            return orders;
        }

        public async Task<OrderModel> GetOrderAsync(int id)
        {
            var query = from o in _dbContext.Orders
                        where o.Id == id
                        select new OrderModel
                        {
                            Id = o.Id,
                            CustomerId = o.CustomerId,
                            TrackingNumber = o.TrackingNumber
                        };

            var order = await query.FirstOrDefaultAsync();

            return order;
        }

        public async Task AddOrderAsync(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateOrderAsync(int orderId, Order order)
        {
            var newOrder = await _dbContext.Orders.FirstOrDefaultAsync(o => o.Id == orderId);

            if (newOrder == null)
            {
                return;
            }

            newOrder.CustomerId = order.CustomerId;
            newOrder.TrackingNumber = order.TrackingNumber;

            _dbContext.Orders.Update(newOrder);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var order = await _dbContext.Orders.FirstOrDefaultAsync(c => c.Id == orderId);

            if (order == null)
            {
                return;
            }

            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync();
        }
    }
}
