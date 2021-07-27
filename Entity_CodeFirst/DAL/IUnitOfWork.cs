using Entity_CodeFirst.DAL.Interfaces;

namespace Entity_CodeFirst.DAL
{
    public interface IUnitOfWork
    {
        public ICustomerRepository Customers { get; }
        public IOrderRepository Orders { get; }
    }
}
