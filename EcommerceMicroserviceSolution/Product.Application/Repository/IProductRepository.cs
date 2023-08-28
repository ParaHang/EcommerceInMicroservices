using Product.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Repository
{
    public interface IProductRepository
    {
        List<Products> GetProducts();
        Task<Products> GetProductsById(int id);
        Task<bool> UpdateProduct(Products products);
        Task<bool> CreateProduct(Products products);
        Task<bool> DeleteProductsById(int id);
    }
}
