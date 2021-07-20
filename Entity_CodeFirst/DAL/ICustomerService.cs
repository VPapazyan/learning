using Entity_CodeFirst.Entities;
using Entity_CodeFirst.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entity_CodeFirst.DAL
{
    public interface ICustomerService
    {
        Task<List<CustomerModel>> GetCustomersAsync();

        Task<CustomerModel> GetCustomerAsync(int id);

        Task AddCustomerAsync(Customer customer);

        Task UpdateCustomerAsync(int customerId, Customer customer);

        Task DeleteCustomerAsync(int customerId);
    }
}
