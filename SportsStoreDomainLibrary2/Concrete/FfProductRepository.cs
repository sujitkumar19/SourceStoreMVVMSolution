using SportsStoreDomainLibrary2.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStoreDomainLibrary2.Entities;
using System.Data.Entity;

namespace SportsStoreDomainLibrary2.Concrete
{
    public class FfProductRepository: iProductRepository
    {
        SportsStoreDBcontext _context;
        public FfProductRepository() {
            _context = new SportsStoreDBcontext();
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProductAsync(int productID)
        {
            var prod = await _context.Products.FirstOrDefaultAsync(p=>p.ProductID==productID);
            if (prod != null)
            {
                _context.Products.Remove(prod);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Product> GetProductAsync(int productId)
        {
            var prod= _context.Products.FirstOrDefaultAsync(p => p.ProductID == productId);
            return await prod;
        }

        public Task<List<Product>> getProductByCategoryAsync(string categoryName)
        {
            return _context.Products.Where(p => p.category == categoryName).ToListAsync();
        }

        public Task<List<Product>> getProductsAsync()
        {
            return _context.Products.ToListAsync();
        }

        public async Task<Product> UpdateProdcutAsync(Product product)
        {
            if (!_context.Products.Local.Any(p => p.ProductID == product.ProductID))
            {
                _context.Products.Attach(product);
            }
            _context.Entry<Product>(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
