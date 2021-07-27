using Entity_CodeFirst.Entities;
using Entity_CodeFirst.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entity_CodeFirst.DAL.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<OrderModel>> GetOrdersAsync();

        Task<OrderModel> GetOrderAsync(int id);

        Task AddOrderAsync(Order order);

        Task UpdateOrderAsync(int orderId, Order order);

        Task DeleteOrderAsync(int orderId);
    }
}
