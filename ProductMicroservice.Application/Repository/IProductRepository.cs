using ProductMicroService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Application.Repository
{
    public interface IProductRepository
    {
        List<Products> GetProducts();
    }
}
