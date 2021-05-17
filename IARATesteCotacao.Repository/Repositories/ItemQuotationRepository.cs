using IARATesteCotacao.Domain.Entities;
using IARATesteCotacao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IARATesteCotacao.Data.Repositories
{
    public class ItemQuotationRepository : IItemQuotationRepository
    {
        private readonly ContextDb _contextDb;
        public ItemQuotationRepository(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }

        public async Task<ItensQuotation> AddAsync(ItensQuotation itensQuotation)
        {
            var itemQuotationEntity = await _contextDb.Set<ItensQuotation>().AddAsync(itensQuotation);
            await _contextDb.SaveChangesAsync();
            return itemQuotationEntity.Entity;
        }

        public async Task<ItensQuotation> DeleteAsync(ItensQuotation itensQuotation)
        {
            var itemQuotationEntity = _contextDb.Set<ItensQuotation>().Remove(itensQuotation);
            await _contextDb.SaveChangesAsync();
            return itemQuotationEntity.Entity;
        }

        public async Task<IEnumerable<ItensQuotation>> GetAllAsync(long QuotationId)
        {
            return await _contextDb.ItensQuotations
                .Where(x => x.QuotationId == QuotationId)
                .OrderBy(x => x.ItemNumber).ToListAsync();
        }

        public async Task<ItensQuotation> GetByIdAsync(int ProductId, long QuotationId)
        {
            return await _contextDb.ItensQuotations
                .Where(x => x.QuotationId == QuotationId && x.ProductId == ProductId)
                .SingleOrDefaultAsync(); 
        }

        public async Task<ItensQuotation> UpdateAsync(ItensQuotation itensQuotation)
        {
            var itemQuotationEntity = _contextDb.Set<ItensQuotation>().Update(itensQuotation);
            await _contextDb.SaveChangesAsync();
            return itemQuotationEntity.Entity;
        }
    }
}
