using Microsoft.EntityFrameworkCore;
using Product.Application.Repository;
using Product.Domain;
using Product.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public List<Products> GetProducts()
        {
            return _applicationDbContext.Products.ToList();
        }
        public async Task<Products> GetProductsById(int id)
        {
            var product = await _applicationDbContext.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(product != null)
            {
                return product;
            }
            return new Products();
        }
        public async Task<bool> UpdateProduct(Products products)
        {
            var product = await _applicationDbContext.Products.Where(x => x.Id == products.Id).FirstOrDefaultAsync();
            if(product != null)
            {
                _applicationDbContext.Products.Update(products);
                _applicationDbContext.SaveChanges();    
                return true;
            }
            return false;
        }
        public async Task<bool> CreateProduct(Products products)
        {
            await _applicationDbContext.Products.AddAsync(products);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteProductsById(int id)
        {
            var product = await _applicationDbContext.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(product != null)
            {
                _applicationDbContext.Products.Remove(product); 
                _applicationDbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
