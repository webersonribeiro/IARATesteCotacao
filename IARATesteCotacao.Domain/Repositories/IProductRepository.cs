using IARATesteCotacao.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IARATesteCotacao.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product> AddAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<Product> DeleteAsync(Product product);
        Task<Product> GetByIdAsync(int Id);
        Task<IEnumerable<Product>> GetAllAsync();

    }
}
