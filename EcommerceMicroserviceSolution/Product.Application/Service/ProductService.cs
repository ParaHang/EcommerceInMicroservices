using Product.Application.Interface;
using Product.Application.Repository;
using Product.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Product.Application.Service
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public List<Products> GetProducts()
        {
            return _productRepository.GetProducts();
        }
        public async Task<Products> GetProductById(int id)
        {
            return await _productRepository.GetProductsById(id);
        }
        public async Task<bool> DeleteProductById(int id)
        {
            return await _productRepository.DeleteProductsById(id);
        }
        public async Task<bool> UpdateProduct(Products products)
        {
            return await _productRepository.UpdateProduct(products);
        }
        public async Task<bool> CreateProduct(Products products)
        {
            return await _productRepository.CreateProduct(products);
        }
    }
}
