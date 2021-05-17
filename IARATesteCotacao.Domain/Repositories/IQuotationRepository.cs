using IARATesteCotacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IARATesteCotacao.Domain.Repositories
{
    public interface IQuotationRepository
    {
        Task<Quotation> AddAsync(Quotation quotation);
        Task<Quotation> UpdateAsync(Quotation quotation);
        Task<Quotation> DeleteAsync(Quotation quotation);
        Task<Quotation> GetByIdAsync(Int64 Id);
        Task<IEnumerable<Quotation>> GetAllAsync();
    }
}
