using IARATesteCotacao.Domain.Entities;
using IARATesteCotacao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IARATesteCotacao.Data.Repositories
{
    public class QuotationRepository : IQuotationRepository
    {
        private readonly ContextDb _contextDb;

        public QuotationRepository(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }

        public async Task<Quotation> AddAsync(Quotation quotation)
        {
            var quotationEtity = await _contextDb.Set<Quotation>().AddAsync(quotation);
            await _contextDb.SaveChangesAsync();
            return quotationEtity.Entity;
        }

        public async Task<Quotation> DeleteAsync(Quotation quotation)
        {
            var quotationEtity = _contextDb.Set<Quotation>().Remove(quotation);
            await _contextDb.SaveChangesAsync();
            return quotationEtity.Entity;
        }

        public async Task<IEnumerable<Quotation>> GetAllAsync()
        {
            return await _contextDb.Quotations.AsNoTracking()
                .Include(x => x.ItensQuotation)
                .OrderBy(x => x.QuotationId)
                .ToListAsync();
        }

        public async Task<Quotation> GetByIdAsync(Int64 Id)
        {
            return await _contextDb.Quotations.AsNoTracking()
                .Include(x => x.ItensQuotation)
                .Where(x => x.QuotationId == Id)
                .SingleOrDefaultAsync();
        }

        public async Task<Quotation> UpdateAsync(Quotation quotation)
        {
            var quotationEtity = _contextDb.Set<Quotation>().Update(quotation);
            await _contextDb.SaveChangesAsync();
            return quotationEtity.Entity;
        }
    }
}
