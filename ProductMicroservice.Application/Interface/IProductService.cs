using ProductMicroService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Application.Interface
{
    public interface IProductService
    {
        List<Products> GetProducts();
    }
}
