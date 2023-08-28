using Product.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Interface
{
    public interface IProductService
    {
        List<Products> GetProducts();
        Task<Products> GetProductById(int id);
        Task<bool> DeleteProductById(int id);
        Task<bool> UpdateProduct(Products products);
        Task<bool> CreateProduct(Products products);
    }
}
