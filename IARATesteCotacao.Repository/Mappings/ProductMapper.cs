using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using IARATesteCotacao.Domain.Entities;

namespace IARATesteCotacao.Data.Mappings
{
    public class ProductMapper : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.ProductId);

            builder.Property(x => x.ProductId)
                .IsRequired();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(64)");

            builder.Property(x => x.Status)
                .IsRequired()
                .HasColumnType("bit")
                .HasDefaultValue(1);
        }
    }
}
