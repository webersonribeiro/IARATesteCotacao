using IARATesteCotacao.Data.Mappings;
using IARATesteCotacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IARATesteCotacao.Data
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions<ContextDb> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ItensQuotation> ItensQuotations { get; set; }
        public DbSet<Quotation> Quotations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMapper());
            modelBuilder.ApplyConfiguration(new QuotationMapper());
            modelBuilder.ApplyConfiguration(new ItensQuotationMapper());

            base.OnModelCreating(modelBuilder);
        }
    }
}
