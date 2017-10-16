using SportsStoreDomainLibrary2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStoreDomainLibrary2.Abstract
{
    public interface iProductRepository
    {
        Task<List<Product>> getProductsAsync();
        Task<List<Product>> getProductByCategoryAsync(string categoryName);
        Task<Product> GetProductAsync(int productId);
        Task<Product> AddProductAsync(Product product);
        Task<Product> UpdateProdcutAsync(Product product);
        Task DeleteProductAsync(int productID);
    }
}
