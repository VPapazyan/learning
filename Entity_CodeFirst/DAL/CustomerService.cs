using Entity_CodeFirst.Entities;
using Entity_CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_CodeFirst.DAL
{
    public class CustomerService
    {
        private readonly AppDbContext _dbContext;

        public CustomerService()
        {
            _dbContext = new AppDbContext();
        }

        public async Task<List<CustomerModel>> GetCustomersAsync()
        {
            var query = from c in _dbContext.Customers
                        select new CustomerModel
                        {
                            Name = c.Name,
                            Address = c.Address
                        };

            var customers = await query.ToListAsync();

            return customers;
        }

        public async Task<List<Customer>> GetCustomerAsync(int id)
        {
            var query = from c in _dbContext.Customers
                        where c.Id == id
                        select new Customer
                        {
                            OrderHistoryId = c.OrderHistoryId,
                            Name = c.Name,
                            Address = c.Address
                        };

            var customer = await query.ToListAsync();

            return customer;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCustomerAsync(int customerId, Customer customer)
        {
            var newCustomer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == customerId);

            if (customer == null)
            {
                return;
            }

            newCustomer.OrderHistoryId = customer.OrderHistoryId;
            newCustomer.Name = customer.Name;
            newCustomer.Address = customer.Address;

            _dbContext.Customers.Update(newCustomer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == customerId);

            if (customer == null)
            {
                return;
            }

            _dbContext.Customers.Remove(customer);
            await _dbContext.SaveChangesAsync();
        }

    }
}
