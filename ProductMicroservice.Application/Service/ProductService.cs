using ProductMicroservice.Application.Interface;
using ProductMicroservice.Application.Repository;
using ProductMicroService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Application.Service
{
    public class MovieService: IProductService
    {
        private readonly IProductRepository _productRepository;
        public MovieService(IProductRepository productRepository)
        {
                _productRepository = productRepository;
        }
        public List<Products> GetProducts()
        {

            return _productRepository.GetProducts();
        }
    }
}
