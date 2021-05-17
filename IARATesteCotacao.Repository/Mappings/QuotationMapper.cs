using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using IARATesteCotacao.Domain.Entities;

namespace IARATesteCotacao.Data.Mappings
{
    public class QuotationMapper : IEntityTypeConfiguration<Quotation>
    {

        public void Configure(EntityTypeBuilder<Quotation> builder)
        {
            builder.ToTable("Quotation");

            builder.HasKey(x => x.QuotationId);

            builder.Property(x => x.QuotationId)
                .IsRequired();

            builder.Property(x => x.CnpjClient)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Property(x => x.CnpjSeller)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Property(x => x.DateStart)
               .IsRequired();

            builder.Property(x => x.DateLimit)
                .IsRequired();

            builder.Property(x => x.ZipCode)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(x => x.Address)
                .HasColumnType("varchar(64)");

            builder.Property(x => x.ComplementAddress)
                .HasColumnType("varchar(32)");

            builder.Property(x => x.District)
                .HasColumnType("varchar(32)");

            builder.Property(x => x.State)
                .HasColumnType("varchar(2)");

            builder.Property(x => x.Comments)
                .HasColumnType("varchar(300)");

            builder.HasMany(x => x.ItensQuotation)
                .WithOne(p => p.Quotation);
        }
    }
}