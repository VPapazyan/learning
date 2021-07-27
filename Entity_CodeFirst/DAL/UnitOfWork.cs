using Entity_CodeFirst.DAL.Interfaces;
using Entity_CodeFirst.DAL.Repositories;
using Entity_CodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_CodeFirst.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICustomerRepository Customers
        {
            get
            {
                return new CustomerRepository(_dbContext);
            }
        }

        public IOrderRepository Orders
        {
            get
            {
                return new OrderRepository(_dbContext);
            }
        }
    }
}
