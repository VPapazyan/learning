using Entity_CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity_CodeFirst.FluentApiConfigs
{
    public class OrderConfigs : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder
                .HasOne(o => o.Customer)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.CustomerId);
        }
    }
}
