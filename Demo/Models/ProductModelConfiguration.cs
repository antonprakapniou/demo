using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.Models
{
    public class ProductModelConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasKey("ProductId")
                .HasName("PrimaryKey_ProductId");
            builder
                .Property(p=>p.Name)
                .IsRequired();
            builder
                .Property(p => p.PicturePath)
                .IsRequired();
            builder
                .Property(p => p.Price)
                .IsRequired()
                .HasDefaultValue(0.01);
        }
    }
}