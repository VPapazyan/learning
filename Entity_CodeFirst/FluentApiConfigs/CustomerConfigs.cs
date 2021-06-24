using Entity_CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity_CodeFirst.FluentApiConfigs
{
    public class CustomerConfigs : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .HasOne(c => c.OrderHistory)
                .WithMany(c => c.Customers)
                .HasForeignKey(c => c.OrderHistoryId);
        }
    }
}
