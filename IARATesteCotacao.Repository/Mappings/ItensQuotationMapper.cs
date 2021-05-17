using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using IARATesteCotacao.Domain.Entities;

namespace IARATesteCotacao.Data.Mappings
{
    public class ItensQuotationMapper : IEntityTypeConfiguration<ItensQuotation>
    {
        public void Configure(EntityTypeBuilder<ItensQuotation> builder)
        {
            builder.ToTable("ItensQuotation");           

            builder.HasKey(ix => new { ix.QuotationId, ix.ProductId });                     

            //builder.HasOne(x => x.Product);

            //builder.HasOne(x => x.Quotation)
            //    .WithMany(p => p.ItensQuotation)
            //    .HasForeignKey(ix => new { ix.QuotationId, ix.ProductId });

            builder.Property(x => x.Price)
                .HasDefaultValue(0)
                .HasColumnType("decimal(18,4)");

            builder.Property(x => x.ItemNumber)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Quantity)
               .HasColumnType("int")
               .IsRequired();

            builder.Property(x => x.Manufacturer)
               .HasColumnType("varchar(32)");

            builder.Property(x => x.Unit)
                .HasColumnType("varchar(32)");

        }
    }
}
