using Entity_CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity_CodeFirst.FluentApiConfigs
{
    public class SaleConfigs : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(s => s.Id);

            builder
                .HasOne(s => s.Product)
                .WithMany(s => s.Sales)
                .HasForeignKey(s => s.ProductId);
        }
    }
}
