using Entity_CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity_CodeFirst.FluentApiConfigs
{
    public class ProductListConfigs : IEntityTypeConfiguration<ProductList>
    {
        public void Configure(EntityTypeBuilder<ProductList> builder)
        {
            builder.HasKey(pl => pl.Id);

            builder
                .HasOne(pl => pl.Inventory)
                .WithMany(pl => pl.ProductLists)
                .HasForeignKey(pl => pl.InventoryId);
        }
    }
}
