using IARATesteCotacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IARATesteCotacao.Domain.Repositories
{
    public interface IItemQuotationRepository
    {
        Task<ItensQuotation> AddAsync(ItensQuotation  itensQuotation);
        Task<ItensQuotation> UpdateAsync(ItensQuotation itensQuotation);
        Task<ItensQuotation> DeleteAsync(ItensQuotation itensQuotation);
        Task<ItensQuotation> GetByIdAsync(int ProductId, Int64 QuotationId);
        Task<IEnumerable<ItensQuotation>> GetAllAsync(long QuotationId);
    }
}
