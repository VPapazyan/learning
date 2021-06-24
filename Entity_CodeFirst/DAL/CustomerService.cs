using Entity_CodeFirst.Entities;
using Entity_CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<List<CustomerModel>> GetCustomers()
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

        public async Task AddCustomer(string name, string address)
        {
            var customer = new Customer
            {
                Name = name,
                Address = address,
            };

            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCustomer(int customerId, string name, string address)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == customerId);

            if (customer == null)
            {
                // TODO 
                return;
            }

            customer.Name = name;
            customer.Address = address;

            _dbContext.Customers.Update(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveCustomer(int customerId)
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
