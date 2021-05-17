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
    public class ProductRepository : IProductRepository
    {
        private readonly ContextDb _contextDb;
        public ProductRepository(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }

        public async Task<Product> AddAsync(Product product)
        {
            var productEntity = await _contextDb.Set<Product>().AddAsync(product);
            await _contextDb.SaveChangesAsync();
            return productEntity.Entity; 
        }

        public async Task<Product> DeleteAsync(Product product)
        {
            var productEntity = _contextDb.Set<Product>().Remove(product);
            await _contextDb.SaveChangesAsync();
            return productEntity.Entity;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _contextDb.Products.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int Id)
        {
            return await _contextDb.Products
                .Where(x => x.ProductId == Id)
                .SingleOrDefaultAsync();
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            var productEntity = _contextDb.Set<Product>().Update(product);
            await _contextDb.SaveChangesAsync();
            return productEntity.Entity;
        }
    }
}
