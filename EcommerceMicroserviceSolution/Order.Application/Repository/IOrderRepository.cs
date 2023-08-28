using Order.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Repository
{
    public interface IOrderRepository
    {
        List<Orders> GetOrders();
        Task<Orders> GetOrdersById(int id);
        Task<bool> UpdateOrder(Orders orders);
        Task<bool> CreateOrder(Orders orders);
        Task<bool> DeleteOrdersById(int id);
    }
}
